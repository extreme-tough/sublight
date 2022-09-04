Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Windows.Forms
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmTooltip
        Inherits Sublight.BaseForm

        Private Class QueueItem

            Public Bitmap As System.Drawing.Image 
            Public IMDB As String 

            Public Sub New()
            End Sub

        End Class ' class QueueItem

        Private Const _IMDB_EXPR As String  = "<a\s*?name=['""]poster['""].*?<img.*?src\s*?=\s*?['""](?<src>.*?)['""]"
        Private Const CS_DROPSHADOW As Integer  = 131072
        Private Const m_maxTitleWidth As Integer  = 200
        Private Const m_minHeight As Integer  = 100
        Private Const m_queueCapacity As Integer  = 10

        Private ReadOnly m_Bitmaps As System.Collections.Generic.Queue(Of Sublight.FrmTooltip.QueueItem) 
        Private ReadOnly m_Ratings As System.Collections.Generic.Dictionary(Of String,String) 

        Private components As System.ComponentModel.IContainer 
        Private lblOverview As System.Windows.Forms.Label 
        Private lblTitle As System.Windows.Forms.Label 
        Private m_BackImage As System.Drawing.Image 
        Private m_BorderPen1 As System.Drawing.Pen 
        Private m_BorderPen2 As System.Drawing.Pen 
        Private m_IgnoreDeactivate As Boolean 
        Private m_parent As System.Windows.Forms.Form 
        Private m_steps As Integer 
        Private m_stepX As Integer 
        Private m_stepY As Integer 
        Private m_targetHeight As Integer 
        Private m_targetWidth As Integer 
        Private m_tickCount As Integer 
        Private m_TitleBrush As System.Drawing.Brush 
        Private timer1 As System.Windows.Forms.Timer 

        Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams
            Get
                Dim createParams1 As System.Windows.Forms.CreateParams = MyBase.CreateParams
                createParams1.ClassStyle = createParams1.ClassStyle Or 131072
                Return createParams1
            End Get
        End Property

        Public Sub New()
            m_BorderPen1 = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#3399FF?"))
            m_BorderPen2 = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#FFFFFF?"))
            m_steps = 10
            m_Bitmaps = New System.Collections.Generic.Queue(Of Sublight.FrmTooltip.QueueItem)(10)
            m_Ratings = New System.Collections.Generic.Dictionary(Of String,String)
            InitializeComponent()
            lblTitle.Visible = False
            lblTitle.Top = -10
            BackColor = System.Drawing.ColorTranslator.FromHtml("#E0F0FF?")
            m_TitleBrush = New System.Drawing.SolidBrush(lblTitle.ForeColor)
            Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
            timer1.Interval = 5
        End Sub

        Public Sub HideTip()
            timer1.Stop()
            Hide()
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.FrmTooltip))
            timer1 = New System.Windows.Forms.Timer(components)
            lblTitle = New System.Windows.Forms.Label
            lblOverview = New System.Windows.Forms.Label
            SuspendLayout()
            timer1.Interval = 25
            AddHandler timer1.Tick, AddressOf timer1_Tick
            lblTitle.AutoSize = True
            lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif?", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblTitle.ForeColor = System.Drawing.Color.DimGray
            lblTitle.Location = New System.Drawing.Point(116, 9)
            lblTitle.Name = "lblTitle?"
            lblTitle.Size = New System.Drawing.Size(51, 20)
            lblTitle.TabIndex = 0
            lblTitle.Text = "label1?"
            lblOverview.AutoSize = True
            lblOverview.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblOverview.ForeColor = System.Drawing.Color.DimGray
            lblOverview.Location = New System.Drawing.Point(116, 54)
            lblOverview.Name = "lblOverview?"
            lblOverview.Size = New System.Drawing.Size(69, 15)
            lblOverview.TabIndex = 1
            lblOverview.Text = "lblOverview?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            ClientSize = New System.Drawing.Size(284, 264)
            ControlBox = False
            Controls.Add(lblOverview)
            Controls.Add(lblTitle)
            ForeColor = System.Drawing.Color.Gray
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Icon = CType(componentResourceManager1.GetObject("$this.Icon?"), System.Drawing.Icon)
            Name = "FrmTooltip?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Text = "FrmTooltip?"
            TopMost = True
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub parent_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs)
            If m_IgnoreDeactivate Then
                Return
            End If
            Hide()
        End Sub

        Private Sub ParseUpdateRating(ByVal rawData As String)
            Dim s1 As String = TryCast(Tag, string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            rawData = System.Web.HttpUtility.HtmlDecode(rawData)
            Dim match1 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(rawData, "<div class=""info"".*?>.*?User Rating:.*?<div class=""meta"">(?<rating>.*?)</div>?", System.Text.RegularExpressions.RegexOptions.Singleline)
            If match1.Success Then
                Dim s2 As String = match1.Groups("rating?").Value
                match1 = System.Text.RegularExpressions.Regex.Match(s2, "<b>(?<rate>.*?)</b>.*?<a href=""ratings"".*?>(?<votes>.*?)</a>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                Dim s3 As String = Nothing
                If match1.Groups("rate?").Success Then
                    s3 = match1.Groups("rate?").Value.Trim()
                End If
                If Not System.String.IsNullOrEmpty(s3) Then
                    Dim s4 As String = s3
                    If s4.IndexOf("/"C) >= 0 Then
                        s4 = s3.Substring(0, s4.IndexOf("/"C)).Trim()
                    End If
                    Dim f1 As Single = -1.0F
                    Try
                        f1 = System.Single.Parse(s4, System.Globalization.CultureInfo.InvariantCulture)
                    Catch 
                    End Try
                    If f1 < 0.0F Then
                        Return
                    End If
                    lblOverview.Text = System.String.Format("{0}: {1:N1}?", Sublight.Translation.SubtitleTooltip_IMDB_UserRating, f1)
                    If m_Ratings.ContainsKey(s1) Then
                        m_Ratings.set_Item(s1, lblOverview.Text)
                    Else 
                        m_Ratings.Add(s1, lblOverview.Text)
                    End If
                    Invalidate()
                    Dim sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    Try
                        sublight1.UpdateUserRatingAsync(Sublight.BaseForm.Session, s1, f1)
                    Catch 
                    Finally
                        If Not (sublight1) Is Nothing Then
                            sublight1.Dispose()
                        End If
                    End Try
                End If
            End If
        End Sub

        Private Sub SetImageAndSize(ByVal qi As Sublight.FrmTooltip.QueueItem)
            If ((qi) Is Nothing) OrElse ((qi.Bitmap) Is Nothing) Then
                Return
            End If
            lblTitle.Top = -lblTitle.Height - 10
            Dim padding1 As System.Windows.Forms.Padding = Padding
            lblTitle.Left = padding1.Left + qi.Bitmap.Width + 5
            Dim s1 As String = TryCast(Tag, string)
            If (Not (s1) Is Nothing) AndAlso m_Ratings.ContainsKey(s1) Then
                lblOverview.Text = m_Ratings.get_Item(s1)
            End If
            lblOverview.Top = -lblOverview.Height - 10
            Dim padding2 As System.Windows.Forms.Padding = Padding
            lblOverview.Left = padding2.Left + qi.Bitmap.Width + 5
            m_BackImage = qi.Bitmap
            m_IgnoreDeactivate = True
            m_tickCount = 0
            Dim padding3 As System.Windows.Forms.Padding = Padding
            Dim padding4 As System.Windows.Forms.Padding = Padding
            m_targetWidth = IIf(lblTitle.Width < 200, lblTitle.Width, 200) + qi.Bitmap.Width + padding3.Left + padding4.Right + 5
            Dim padding5 As System.Windows.Forms.Padding = Padding
            Dim padding6 As System.Windows.Forms.Padding = Padding
            m_targetHeight = IIf(qi.Bitmap.Height < 100, 100, qi.Bitmap.Height) + padding5.Top + padding6.Bottom
            Dim i1 As Integer = Left
            Dim i2 As Integer = Top
            Left = Left + 30
            Top = Top + 100
            Dim rectangle1 As System.Drawing.Rectangle = System.Windows.Forms.Screen.GetBounds(Me)
            If (Top + m_targetHeight + 10) > rectangle1.Height Then
                Dim rectangle2 As System.Drawing.Rectangle = System.Windows.Forms.Screen.GetBounds(Me)
                Top = rectangle2.Height - m_targetHeight - 10
            End If
            Dim rectangle3 As System.Drawing.Rectangle = System.Windows.Forms.Screen.GetBounds(Me)
            If (Left + m_targetWidth + 10) > rectangle3.Width Then
                Dim rectangle4 As System.Drawing.Rectangle = System.Windows.Forms.Screen.GetBounds(Me)
                Left = rectangle4.Width - m_targetWidth - 10
            End If
            If (i1 >= Left) AndAlso (i1 <= Right) Then
                Left = i1 - m_targetWidth
            End If
            If (i2 >= Top) AndAlso (i2 <= Bottom) Then
                Top = i2 - m_targetHeight - 100
            End If
            m_stepX = System.Convert.ToInt32(System.Math.Floor(CDbl(m_targetWidth) / System.Convert.ToDouble(m_steps)))
            m_stepY = System.Convert.ToInt32(System.Math.Floor(CDbl(m_targetHeight) / System.Convert.ToDouble(m_steps)))
            MyBase.Show()
            Width = 0
            Height = 0
            timer1.Start()
            m_parent.Focus()
            m_IgnoreDeactivate = False
        End Sub

        Public Sub Show(ByVal parent As System.Windows.Forms.Form, ByVal imdb As String, ByVal title As String, ByVal year As System.Nullable(Of Integer))
            Dim s1 As String, s2 As String

            lblTitle.Visible = False
            lblOverview.Visible = False
            If (parent) Is Nothing Then
                Return
            End If
            lblTitle.Text = title
            lblOverview.Text = System.String.Empty
            If year.get_HasValue() Then
                lblTitle.Text = lblTitle.Text + System.String.Format(" ({0})?", year.get_Value())
            End If
            AddHandler parent.Deactivate, AddressOf parent_Deactivate
            m_parent = parent
            If System.String.IsNullOrEmpty(imdb) Then
                Return
            End If
            Dim i1 As Integer = imdb.LastIndexOf("/"C)
            If i1 >= 0 Then
                imdb = imdb.Substring(i1 + 1)
            End If
            Tag = imdb
            Dim enumerator1 As System.Collections.Generic.Queue(Of Sublight.FrmTooltip.QueueItem).Enumerator = m_Bitmaps.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim queueItem1 As Sublight.FrmTooltip.QueueItem = enumerator1.get_Current()
                    If System.String.Compare(queueItem1.IMDB, imdb, True) = 0 Then
                        SetImageAndSize(queueItem1)
                        Return
                    End If
                End While
            Finally
                enumerator1.Dispose()
            End Try
            Try
                While m_Bitmaps.get_Count() >= 10
                    Dim queueItem2 As Sublight.FrmTooltip.QueueItem = m_Bitmaps.Dequeue()
                    If Not (queueItem2.Bitmap) Is Nothing Then
                        queueItem2.Bitmap.Dispose()
                    End If
                End While
            Catch e As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmTooltip.Show (disposing old posters)?", e)
            End Try
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                If sublight1.GetPoster(Sublight.BaseForm.Session, imdb, out s1, out s2) AndAlso Not System.String.IsNullOrEmpty(s1) Then
                    Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream(System.Convert.FromBase64String(s1))
                        Dim image1 As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream1)
                        Dim queueItem3 As Sublight.FrmTooltip.QueueItem = New Sublight.FrmTooltip.QueueItem
                        queueItem3.IMDB = TryCast(Tag, string)
                        queueItem3.Bitmap = image1
                        m_Bitmaps.Enqueue(queueItem3)
                        SetImageAndSize(queueItem3)
                        Return
                    End Using
                End If
            End Using
            Using webClient1 As System.Net.WebClient = New System.Net.WebClient
                AddHandler webClient1.DownloadStringCompleted, AddressOf wc_DownloadStringCompleted
                webClient1.DownloadStringAsync(New System.Uri(System.String.Format("http://www.imdb.com/title/{0}?", imdb)))
            End Using
        End Sub

        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            If IsDisposed Then
                timer1.Stop()
            End If
            Dim baseForm1 As Sublight.BaseForm = TryCast(m_parent, Sublight.BaseForm)
            If (Not (baseForm1) Is Nothing) AndAlso baseForm1.IsDisposed Then
                timer1.Stop()
                Return
            End If
            If (Not (baseForm1) Is Nothing) AndAlso Not baseForm1.IsActive Then
                timer1.Stop()
                Close()
            End If
            If m_tickCount < m_steps Then
                Width = Width + m_stepX
                Height = Height + m_stepY
                m_tickCount = m_tickCount + 1
                Return
            End If
            timer1.Stop()
            Width = m_targetWidth
            Height = m_targetHeight
            lblTitle.Visible = True
            lblOverview.Visible = True
            Invalidate()
        End Sub

        Private Sub wc_DownloadDataCompleted(ByVal sender As Object, ByVal e As System.Net.DownloadDataCompletedEventArgs)
            Try
                Dim bArr1 As Byte() = e.Result
                Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream(bArr1)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim s1 As String = TryCast(e.UserState, string)
                        sublight1.UpdatePoster2Async(Sublight.BaseForm.Session, TryCast(Tag, string), s1, System.Convert.ToBase64String(memoryStream1.ToArray()))
                    End Using
                    memoryStream1.Seek(CLng(0), System.IO.SeekOrigin.Begin)
                    Dim image1 As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream1)
                    Dim queueItem1 As Sublight.FrmTooltip.QueueItem = New Sublight.FrmTooltip.QueueItem
                    queueItem1.IMDB = TryCast(Tag, string)
                    queueItem1.Bitmap = image1
                    m_Bitmaps.Enqueue(queueItem1)
                    SetImageAndSize(queueItem1)
                End Using
            Catch 
            End Try
        End Sub

        Private Sub wc_DownloadStringCompleted(ByVal sender As Object, ByVal e As System.Net.DownloadStringCompletedEventArgs)
            Dim s3 As String

            Dim webClient1 As System.Net.WebClient = Nothing
            Try
                webClient1 = New System.Net.WebClient
                Dim s1 As String = e.Result
                Dim match1 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s1, "<a\s*?name=['""]poster['""].*?<img.*?src\s*?=\s*?['""](?<src>.*?)['""]?")
                If match1.Success Then
                    Dim s2 As String = match1.Groups("src?").Value
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        If Not sublight1.GetPosterUrl(Sublight.BaseForm.Session, s2, out s2, out s3) Then
                            Return
                        End If
                    End Using
                    AddHandler webClient1.DownloadDataCompleted, AddressOf wc_DownloadDataCompleted
                    webClient1.DownloadDataAsync(New System.Uri(s2), s2)
                End If
                ParseUpdateRating(e.Result)
            Catch 
            Finally
                If Not (webClient1) Is Nothing Then
                    webClient1.Dispose()
                End If
            End Try
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            If disposing Then
                If Not (m_BorderPen1) Is Nothing Then
                    m_BorderPen1.Dispose()
                    m_BorderPen1 = Nothing
                End If
                If Not (m_BorderPen2) Is Nothing Then
                    m_BorderPen2.Dispose()
                    m_BorderPen2 = Nothing
                End If
                If Not (m_TitleBrush) Is Nothing Then
                    m_TitleBrush.Dispose()
                    m_TitleBrush = Nothing
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Using brush1 As System.Drawing.Brush = New System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, System.Drawing.ColorTranslator.FromHtml("#AED6FF?"), System.Drawing.ColorTranslator.FromHtml("#FEFEFF?"), System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush1, ClientRectangle)
            End Using
            e.Graphics.DrawRectangle(m_BorderPen2, 1, 1, Width - 3, Height - 3)
            e.Graphics.DrawRectangle(m_BorderPen1, 0, 0, Width - 1, Height - 1)
            If (Not (m_BackImage) Is Nothing) AndAlso (m_tickCount >= m_steps) Then
                Dim padding1 As System.Windows.Forms.Padding = Padding
                Dim padding2 As System.Windows.Forms.Padding = Padding
                e.Graphics.DrawImageUnscaled(m_BackImage, padding1.Top, padding2.Left)
            End If
            Dim f1 As Single = 0.0F
            If lblTitle.Visible Then
                Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString(lblTitle.Text, lblTitle.Font, 200)
                f1 = sizeF1.Height
                Dim padding3 As System.Windows.Forms.Padding = Padding
                e.Graphics.DrawString(lblTitle.Text, lblTitle.Font, m_TitleBrush, New System.Drawing.RectangleF(CSng(lblTitle.Left), CSng(padding3.Top), 200.0F, CSng(Height)))
            End If
            If lblOverview.Visible Then
                Dim padding4 As System.Windows.Forms.Padding = Padding
                e.Graphics.DrawString(lblOverview.Text, lblOverview.Font, m_TitleBrush, New System.Drawing.RectangleF(CSng(lblOverview.Left), CSng(padding4.Top) + f1 + 5.0F, 200.0F, CSng(Height)))
            End If
        End Sub

    End Class ' class FrmTooltip

End Namespace

