Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Threading
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Properties

Namespace Sublight

    Public Class FrmBalloon
        Inherits System.Windows.Forms.Form

        Public Enum alAlign
            al_lhs
            al_mid
            al_rhs
        End Enum

        Public Enum sdSide
            sd_top
            sd_left
            sd_bottom
            sd_right
            sd_horizontal
            sd_vertical
        End Enum

        Private Const C_ARCH As Integer  = 5
        Private Const C_QUOTEH As Integer  = 25
        Private Const C_SHADOW As Integer  = 5

        Private btnClose As Sublight.Controls.Button.Button 
        Private cbDoNotDisplay As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.Container 
        Private label1 As System.Windows.Forms.Label 
        Protected m_bHasShadow As Boolean 
        Protected m_bIsShadow As Boolean 
        Protected m_bShowFrame As Boolean 
        Protected m_cBotRite As System.Drawing.Color 
        Protected m_cTopLeft As System.Drawing.Color 
        Public m_evhMove As System.EventHandler 
        Private m_fmParent As System.Windows.Forms.Form 
        Private m_fmShadow As Sublight.FrmBalloon 
        Protected m_nTailOffset As Integer 
        Protected m_path As System.Drawing.Drawing2D.GraphicsPath 
        Private m_ptCenter As System.Drawing.Point 
        Public m_ptTipPosition As System.Drawing.Point 
        Protected m_rInnerFrame As System.Drawing.Region 
        Protected m_rOuterFrame As System.Drawing.Region 
        Protected m_rtAnchor As System.Drawing.Rectangle 
        Public m_rtBalloonF As System.Drawing.RectangleF 
        Private m_tipAlign As Sublight.FrmBalloon.alAlign 
        Private m_tipSide As Sublight.FrmBalloon.sdSide 
        Private pictureBox1 As System.Windows.Forms.PictureBox 

        Public Property FrameBottomRight As System.Drawing.Color
            Get
                Return m_cBotRite
            End Get
            Set
                m_cBotRite = value
                reDrawMe()
            End Set
        End Property

        Public Property FrameTopLeft As System.Drawing.Color
            Get
                Return m_cTopLeft
            End Get
            Set
                m_cTopLeft = value
                reDrawMe()
            End Set
        End Property

        Public Property HasShadow As Boolean
            Get
                Return m_bHasShadow
            End Get
            Set
                m_bHasShadow = value
                If m_bHasShadow Then
                    bMakeShadow()
                    Return
                End If
                DestroyShadow()
            End Set
        End Property

        Public Property IsShadow As Boolean
            Get
                Return m_bIsShadow
            End Get
            Set
                If value AndAlso Not m_bIsShadow Then
                    ShowFrame = False
                    BackColor = System.Drawing.Color.DarkGray
                End If
                m_bIsShadow = value
            End Set
        End Property

        Public Property ShowFrame As Boolean
            Get
                Return m_bShowFrame
            End Get
            Set
                If m_bShowFrame <> value Then
                    m_bShowFrame = value
                    reDrawMe()
                End If
            End Set
        End Property

        Public Property tailAlign As Sublight.FrmBalloon.alAlign
            Get
                Return m_tipAlign
            End Get
            Set
                m_tipAlign = value
                reSizeMe()
                If Not (m_fmShadow) Is Nothing Then
                    m_fmShadow.tailAlign = value
                End If
            End Set
        End Property

        Public Property tailOffset As Integer
            Get
                Return m_nTailOffset
            End Get
            Set
                m_nTailOffset = value
                reSizeMe()
                If Not (m_fmShadow) Is Nothing Then
                    m_fmShadow.tailOffset = value
                End If
            End Set
        End Property

        Public Property tailSide As Sublight.FrmBalloon.sdSide
            Get
                Return m_tipSide
            End Get
            Set
                m_tipSide = value
                reSizeMe()
                If m_bHasShadow AndAlso (Not (m_fmShadow) Is Nothing) Then
                    m_fmShadow.tailSide = value
                End If
            End Set
        End Property

        Public Sub New()
            m_bShowFrame = True
            m_cTopLeft = System.Drawing.ColorTranslator.FromHtml("#15428B?")
            m_cBotRite = System.Drawing.ColorTranslator.FromHtml("#15428B?")
            m_ptTipPosition = New System.Drawing.Point(0, 0)
            m_rtBalloonF = New System.Drawing.RectangleF(0.0F, 0.0F, 1.0F, 1.0F)
            m_ptCenter = New System.Drawing.Point(0, 0)
            m_nTailOffset = 30
            m_rtAnchor = New System.Drawing.Rectangle(0, 0, 0, 0)
            InitializeComponent()
            btnClose.Left = Width - 117
            btnClose.Top = Height - 62
            pictureBox1.Image = New System.Drawing.Bitmap(System.Drawing.SystemIcons.Information.ToBitmap())
            btnClose.Text = Sublight.Translation.Common_Button_Close
            cbDoNotDisplay.Text = Sublight.Translation.Common_DoNotDisplayThisMessageAnymore
            cbDoNotDisplay.Top = btnClose.Top + btnClose.Height - cbDoNotDisplay.Height
            label1.Text = Sublight.Translation.MessageBox_HelpUsLink
        End Sub

        Private Function bCalcTailPos(ByVal ptA As System.Drawing.Point, ByVal bOnlyBelow As Boolean) As Boolean
            Width
            Dim i1 As Integer = Height + 5
            Dim screenArr1 As System.Windows.Forms.Screen() = System.Windows.Forms.Screen.AllScreens
            Dim rectangle1 As System.Drawing.Rectangle = screenArr1(0).Bounds
            Dim i2 As Integer = rectangle1.Width
            Dim rectangle2 As System.Drawing.Rectangle = screenArr1(0).Bounds
            Dim i3 As Integer = rectangle2.Height
            If Not bOnlyBelow Then
                tailSide = Sublight.FrmBalloon.sdSide.sd_bottom
            Else 
                If (ptA.Y + i1) >= i3 Then
                    Return False
                End If
                tailSide = Sublight.FrmBalloon.sdSide.sd_top
            End If
            Dim i4 As Integer = i2 - ptA.X
            Dim i5 As Integer = Width + 5 - 25
            If i4 > i5 Then
                tailOffset = 5
                tailAlign = Sublight.FrmBalloon.alAlign.al_lhs
            Else 
                Dim i6 As Integer = i5 - i4
                If i6 < System.Math.Round(CDbl(i5) / 3.0R) Then
                    tailOffset = i6 + 5
                    tailAlign = Sublight.FrmBalloon.alAlign.al_lhs
                ElseIf i6 > System.Math.Round(CDbl((i5 - 30)) / 2.0R) Then
                    Dim i7 As Integer = i5 - i6 - 30
                    If i7 < 0 Then
                        i7 = 0
                    End If
                    tailOffset = i7 + 5
                    tailAlign = Sublight.FrmBalloon.alAlign.al_rhs
                Else 
                    tailOffset = 0
                    tailAlign = Sublight.FrmBalloon.alAlign.al_mid
                End If
            End If
            Dim point1 As System.Drawing.Point = New System.Drawing.Point(0, 0)
            point1.X = ptA.X - m_ptTipPosition.X
            point1.Y = ptA.Y - m_ptTipPosition.Y
            Location = point1
            Return True
        End Function

        Private Function bMakeShadow() As Boolean
            If m_bIsShadow Then
                Return False
            End If
            If Not m_bHasShadow Then
                Return False
            End If
            If DesignMode Then
                Return False
            End If
            If (m_fmShadow) Is Nothing Then
                m_fmShadow = New Sublight.FrmBalloon
                Owner = m_fmShadow
                m_fmShadow.Width = Width
                m_fmShadow.Height = Height
                m_fmShadow.StartPosition = System.Windows.Forms.FormStartPosition.Manual
                Dim point1 As System.Drawing.Point = Location
                Dim point2 As System.Drawing.Point = Location
                m_fmShadow.Location = New System.Drawing.Point(point1.X + 5, point2.Y + 5)
                m_fmShadow.IsShadow = True
                m_fmShadow.Opacity = 0.6R
            End If
            Return True
        End Function

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim flag1 As Boolean = Not cbDoNotDisplay.Checked
            If Sublight.Properties.Settings.Default.AskToLinkFile2 <> flag1 Then
                Sublight.Properties.Settings.Default.AskToLinkFile2 = flag1
                Sublight.FrmBalloon.SaveUserSettings()
            End If
            Close()
        End Sub

        Private Sub CBalloonBase_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            If Not (Owner) Is Nothing Then
                Owner.RemoveOwnedForm(Me)
                Owner = Nothing
            End If
            If Not (m_fmShadow) Is Nothing Then
                If Not (m_fmShadow.Owner) Is Nothing Then
                    m_fmShadow.Owner.RemoveOwnedForm(m_fmShadow)
                    m_fmShadow.Owner = Nothing
                End If
                m_fmShadow.Close()
            End If
            If Not (m_fmParent) Is Nothing Then
                RemoveHandler m_fmParent.Move, AddressOf m_evhMove
                m_fmParent = Nothing
            End If
        End Sub

        Private Sub CBalloonBase_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub CBalloonBase_Move(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not (m_fmShadow) Is Nothing Then
                Dim point1 As System.Drawing.Point = Location
                Dim point2 As System.Drawing.Point = Location
                m_fmShadow.Location = New System.Drawing.Point(point1.X + 5, point2.Y + 5)
            End If
        End Sub

        Private Sub CBalloonBase_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            reDrawMe()
        End Sub

        Private Sub CBalloonBase_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
            reSizeMe()
        End Sub

        Private Sub CBalloonBase_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not m_bHasShadow Then
                Return
            End If
            If Visible AndAlso (Not (m_fmShadow) Is Nothing) Then
                m_fmShadow.Show()
            End If
        End Sub

        Private Sub DestroyShadow()
            If Not (m_fmShadow) Is Nothing Then
                If Not (m_fmShadow.Owner) Is Nothing Then
                    Owner = m_fmShadow.Owner
                    m_fmShadow.RemoveOwnedForm(Me)
                    Owner.RemoveOwnedForm(m_fmShadow)
                End If
                m_fmShadow.Close()
                m_fmShadow.Dispose()
                m_fmShadow = Nothing
            End If
        End Sub

        Private Sub InitializeComponent()
            cbDoNotDisplay = New Sublight.Controls.MyCheckBox
            label1 = New System.Windows.Forms.Label
            pictureBox1 = New System.Windows.Forms.PictureBox
            btnClose = New Sublight.Controls.Button.Button
            pictureBox1.BeginInit()
            SuspendLayout()
            cbDoNotDisplay.AutoSize = True
            cbDoNotDisplay.Location = New System.Drawing.Point(39, 139)
            cbDoNotDisplay.Name = "cbDoNotDisplay?"
            cbDoNotDisplay.Size = New System.Drawing.Size(171, 17)
            cbDoNotDisplay.TabIndex = 18
            cbDoNotDisplay.Text = "Tega sporocila vec ne prikazuj?"
            cbDoNotDisplay.UseVisualStyleBackColor = True
            label1.Location = New System.Drawing.Point(77, 40)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(361, 84)
            label1.TabIndex = 17
            label1.Text = "Ce podnapis ustreza predvajani video datoteki vas prosimo, da s klikom na gumb ""Dodaj povezavo"" povežete podnapis s tem posnetkom.

Uporabniki vam bodo hvaležni.?"
            pictureBox1.Location = New System.Drawing.Point(39, 40)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(32, 32)
            pictureBox1.TabIndex = 16
            pictureBox1.TabStop = False
            btnClose.DialogResult = System.Windows.Forms.DialogResult.None
            btnClose.Location = New System.Drawing.Point(240, 139)
            btnClose.Name = "btnClose?"
            btnClose.Size = New System.Drawing.Size(75, 23)
            btnClose.TabIndex = 15
            btnClose.Text = "Zapri?"
            btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnClose.Click, AddressOf btnClose_Click
            AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            BackColor = System.Drawing.Color.FromArgb(255, 255, 192)
            ClientSize = New System.Drawing.Size(481, 189)
            Controls.Add(cbDoNotDisplay)
            Controls.Add(label1)
            Controls.Add(pictureBox1)
            Controls.Add(btnClose)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmBalloon?"
            ShowInTaskbar = False
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            StartPosition = System.Windows.Forms.FormStartPosition.Manual
            AddHandler Load, AddressOf CBalloonBase_Load
            AddHandler Paint, AddressOf CBalloonBase_Paint
            AddHandler VisibleChanged, AddressOf CBalloonBase_VisibleChanged
            AddHandler Closing, AddressOf CBalloonBase_Closing
            AddHandler Move, AddressOf CBalloonBase_Move
            AddHandler Resize, AddressOf CBalloonBase_Resize
            pictureBox1.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Public Sub Parent_Move(ByVal sender As Object, ByVal e As System.EventArgs)
            If TypeOf sender Is System.Windows.Forms.Form Then
                Return
            End If
            Dim point1 As System.Drawing.Point = m_rtAnchor.Location
            Dim point2 As System.Drawing.Point = point1
            point2.Y = point2.Y + m_rtAnchor.Height
            Dim point3 As System.Drawing.Point = CType(sender, System.Windows.Forms.Form).PointToScreen(point2)
            If Not bCalcTailPos(point3, True) Then
                point3 = CType(sender, System.Windows.Forms.Form).PointToScreen(point1)
                bCalcTailPos(point3, False)
            End If
        End Sub

        Public Sub reDrawMe()
            If m_bShowFrame Then
                Dim graphics1 As System.Drawing.Graphics = System.Drawing.Graphics.FromHwnd(Handle)
                graphics1.RenderingOrigin = m_ptCenter
                graphics1.FillRegion(New System.Drawing.Drawing2D.LinearGradientBrush(m_rtBalloonF, m_cTopLeft, m_cBotRite, 45.0F, True), m_rInnerFrame)
                graphics1.Dispose()
            End If
        End Sub

        Public Sub reSizeMe()
            Dim point1 As System.Drawing.Point, point2 As System.Drawing.Point, point3 As System.Drawing.Point, point4 As System.Drawing.Point, point5 As System.Drawing.Point, point6 As System.Drawing.Point

            m_path = New System.Drawing.Drawing2D.GraphicsPath
            Dim i1 As Integer = Width
            Dim i2 As Integer = Height
            Dim i3 As Integer = 25
            Dim i4 As Integer = 30
            point1 = New System.Drawing.Point
            point2 = New System.Drawing.Point
            point3 = New System.Drawing.Point
            point4 = New System.Drawing.Point
            point5 = New System.Drawing.Point
            point6 = New System.Drawing.Point
            Select Case m_tipSide
                Case Sublight.FrmBalloon.sdSide.sd_top
                    point1.Y = i3
                    point3.Y = 0
                    point5.Y = i3
                    point2.Y = point1.Y + 4
                    point4.Y = point3.Y + 4
                    point6.Y = point5.Y + 4

                Case Sublight.FrmBalloon.sdSide.sd_left
                    point1.X = i3
                    point5.X = i3
                    point3.X = 0
                    point2.X = point1.X + 4
                    point6.X = point5.X + 4
                    point4.X = point3.X + 4

                Case Sublight.FrmBalloon.sdSide.sd_right
                    point1.X = i1 - i3
                    point5.X = i1 - i3
                    point3.X = i1
                    point2.X = point1.X - 4
                    point6.X = point5.X - 4
                    point4.X = point3.X - 4

                Case Sublight.FrmBalloon.sdSide.sd_bottom
                    point1.Y = i2 - i3
                    point5.Y = i2 - i3
                    point3.Y = i2
                    point2.Y = point1.Y - 4
                    point6.Y = point5.Y - 4
                    point4.Y = point3.Y - 4

                Case Sublight.FrmBalloon.sdSide.sd_horizontal
                    If m_tipAlign = Sublight.FrmBalloon.alAlign.al_lhs Then
                        point1.X = i4 + m_nTailOffset
                        point3.X = point1.X - 10
                        point5.X = point1.X + 30
                        point2.X = point1.X + 4
                        point4.X = point3.X + 3
                        point6.X = point5.X + 2
                        GoTo label_0
                    End If
                    If m_tipAlign = Sublight.FrmBalloon.alAlign.al_mid Then
                        point3.X = i1 / 2
                        point1.X = point3.X - 10
                        point5.X = point3.X + 10
                        point2.X = point1.X
                        point4.X = point3.X
                        point6.X = point5.X
                        GoTo label_0
                    End If
                    point5.X = i1 - i4 - m_nTailOffset
                    point1.X = point5.X - 30
                    point3.X = point5.X + 10
                    point2.X = point1.X - 2
                    point4.X = point3.X - 3
                    point6.X = point5.X - 4

                Case Sublight.FrmBalloon.sdSide.sd_vertical
                    If m_tipAlign = Sublight.FrmBalloon.alAlign.al_lhs Then
                        point1.Y = i4 + m_nTailOffset
                        point5.Y = point1.Y + 30
                        point3.Y = point1.Y - 10
                        point2.Y = point1.Y + 4
                        point4.Y = point3.Y + 3
                        point6.Y = point5.Y + 2
                        GoTo label_0
                    End If
                    If m_tipAlign = Sublight.FrmBalloon.alAlign.al_mid Then
                        point3.Y = i2 / 2
                        point1.Y = point3.Y - 10
                        point5.Y = point3.Y + 10
                        point2.Y = point1.Y
                        point4.Y = point3.Y
                        point6.Y = point5.Y
                        GoTo label_0
                    End If
                    point5.Y = i2 - i4 - m_nTailOffset
                    point1.Y = point5.Y - 30
                    point3.Y = point5.Y + 10
                    point2.Y = point1.Y - 2
                    point4.Y = point3.Y - 3
                    point6.Y = point5.Y - 4

                Case Else
                    m_ptTipPosition = point3
                    Dim pointArr1 As System.Drawing.Point() = New System.Drawing.Point(3) {}
                    pointArr1(0) = point1
                    pointArr1(1) = point3
                    pointArr1(2) = point5
                    m_path.AddLines(pointArr1)
                    m_path.CloseFigure()
                    Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
                    Dim pointArr2 As System.Drawing.Point() = New System.Drawing.Point(3) {}
                    pointArr2(0) = point2
                    pointArr2(1) = point4
                    pointArr2(2) = point6
                    graphicsPath1.AddLines(pointArr2)
                    graphicsPath1.CloseFigure()
                    Dim size1 As System.Drawing.Size = New System.Drawing.Size(i1 - (i4 + i4), i2 - (i3 + i3))
                    Dim point7 As System.Drawing.Point = New System.Drawing.Point(i4, i3)
                    Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(point7, size1)
                    m_rOuterFrame = New System.Drawing.Region(rectangle1)
                    size1.Width = size1.Width + 4
                    size1.Height = size1.Height - 2
                    point7.X = point7.X - 2
                    point7.Y = point7.Y + 1
                    m_rOuterFrame.Union(New System.Drawing.Rectangle(point7, size1))
                    size1.Width = size1.Width + 2
                    size1.Height = size1.Height - 2
                    point7.X = point7.X - 1
                    point7.Y = point7.Y + 1
                    m_rOuterFrame.Union(New System.Drawing.Rectangle(point7, size1))
                    size1.Width = size1.Width + 2
                    size1.Height = size1.Height - 2
                    point7.X = point7.X - 1
                    point7.Y = point7.Y + 1
                    m_rOuterFrame.Union(New System.Drawing.Rectangle(point7, size1))
                    size1.Width = size1.Width + 2
                    size1.Height = size1.Height - 4
                    point7.X = point7.X - 1
                    point7.Y = point7.Y + 2
                    m_rOuterFrame.Union(New System.Drawing.Rectangle(point7, size1))
                    m_rOuterFrame.Union(m_path)
                    If m_bIsShadow Then
                        Dim region1 As System.Drawing.Region = m_rOuterFrame.Clone()
                        region1.Translate(-5, -5)
                        m_rOuterFrame.Exclude(region1)
                    End If
                    Region = m_rOuterFrame
                    Dim graphics1 As System.Drawing.Graphics = System.Drawing.Graphics.FromHwnd(Handle)
                    m_rtBalloonF = Region.GetBounds(graphics1)
                    m_ptCenter = New System.Drawing.Point(CInt(((m_rtBalloonF.Width / 2.0F) + m_rtBalloonF.X)), CInt(((m_rtBalloonF.Height / 2.0F) + m_rtBalloonF.Y)))
                    graphics1.Dispose()
                    Dim rectangle2 As System.Drawing.Rectangle = New System.Drawing.Rectangle(29, 27, i1 - 58, i2 - 54)
                    Dim region2 As System.Drawing.Region = New System.Drawing.Region(rectangle2)
                    rectangle2.X = rectangle2.X - 1
                    rectangle2.Y = rectangle2.Y + 1
                    rectangle2.Width = rectangle2.Width + 2
                    rectangle2.Height = rectangle2.Height - 2
                    region2.Union(rectangle2)
                    rectangle2.X = rectangle2.X - 1
                    rectangle2.Y = rectangle2.Y + 1
                    rectangle2.Width = rectangle2.Width + 2
                    rectangle2.Height = rectangle2.Height - 2
                    region2.Union(rectangle2)
                    m_rInnerFrame = m_rOuterFrame.Clone()
                    m_rInnerFrame.Exclude(region2)
                    m_rInnerFrame.Exclude(graphicsPath1)
                    Invalidate()
            End Select
        End Sub

        Public Sub setBalloonPosition(ByVal onForm As System.Windows.Forms.Form, ByVal atPoint As System.Drawing.Point)
            If (m_fmShadow) Is Nothing Then
                Owner = onForm
            Else 
                m_fmShadow.Owner = onForm
            End If
            m_rtAnchor = New System.Drawing.Rectangle(atPoint, New System.Drawing.Size(0, 0))
            Dim point1 As System.Drawing.Point = onForm.PointToScreen(m_rtAnchor.Location)
            If Not bCalcTailPos(point1, True) Then
                point1 = onForm.PointToScreen(point1)
                bCalcTailPos(point1, False)
            End If
            m_fmParent = onForm
            m_evhMove = New System.EventHandler(Parent_Move)
            AddHandler onForm.Move, AddressOf m_evhMove
        End Sub

        Public Sub setBalloonPosition(ByVal onForm As System.Windows.Forms.Form, ByVal onControl As System.Windows.Forms.Control)
            If (m_fmShadow) Is Nothing Then
                Owner = onForm
            Else 
                m_fmShadow.Owner = onForm
            End If
            m_rtAnchor = New System.Drawing.Rectangle(onControl.Location, onControl.Size)
            Dim point1 As System.Drawing.Point = m_rtAnchor.Location
            Dim point2 As System.Drawing.Point = point1
            point1.Y = point1.Y + m_rtAnchor.Height
            Dim point3 As System.Drawing.Point = onForm.PointToScreen(point1)
            If Not bCalcTailPos(point3, True) Then
                point3 = onForm.PointToScreen(point2)
                bCalcTailPos(point3, False)
            End If
            m_fmParent = onForm
            m_evhMove = New System.EventHandler(Parent_Move)
            AddHandler onForm.Move, AddressOf m_evhMove
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Friend Shared Sub SaveUserSettings()
            Dim i1 As Integer = 0
            While i1 < 5
                Try
                    Sublight.Properties.Settings.Default.Save()
                    Return
                Catch 
                    System.Threading.Thread.Sleep(100)
                End Try
                i1 = i1 + 1
            End While
        End Sub

    End Class ' class FrmBalloon

End Namespace

