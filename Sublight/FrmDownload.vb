Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.WS_SublightClient

Namespace Sublight

    Public Class FrmDownload
        Inherits Sublight.BaseForm

        Private _adId As System.Guid 
        Private _delay As Integer 
        Private _points As Double 
        Private _readyForDownload As Boolean 
        Private _started As System.DateTime 
        Private _target As String 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnPurchasePoints As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private lblLoading As System.Windows.Forms.Label 
        Private lblNote As System.Windows.Forms.Label 
        Private lblPleaseWait As System.Windows.Forms.Label 
        Private lnkHowToAdvertise As System.Windows.Forms.LinkLabel 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private timer1 As System.Windows.Forms.Timer 
        Private wb As System.Windows.Forms.WebBrowser 

        Public Sub New()
        End Sub

        Public Sub New(ByVal delay As Integer, ByVal points As Double)
            InitializeComponent()
            label1.Visible = False
            lnkHowToAdvertise.Text = Sublight.Translation.FrmDownload_Link_HowToAdvertise
            btnPurchasePoints.Text = Sublight.Translation.Application_Menu_PurchasePoints
            Dim buttonArr1 As Sublight.Controls.Button.Button() = New Sublight.Controls.Button.Button() { btnPurchasePoints }
            Sublight.Controls.Button.Button.MakeSameWidth(buttonArr1)
            Text = Sublight.Translation.FrmDownload_Title
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            _delay = delay
            _points = points
            _started = System.DateTime.Now
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            lblPleaseWait.Text = System.String.Format(Sublight.Translation.FrmDownload_DownloadCountdown, delay)
            If Sublight.BaseForm.IsAnonymous Then
                lblNote.Text = Sublight.Translation.FrmDownload_NoteAnonymousUser
            Else 
                lblNote.Text = System.String.Format(Sublight.Translation.FrmDownload_NoteRegisteredUser, System.Convert.ToInt32(points))
            End If
            timer1.Start()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnPurchasePoints_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowPurchasePoints()
        End Sub

        Private Sub DisplayMessageIfNecessary()
            If Not _readyForDownload Then
                timer1.Stop()
                ShowInfo(Sublight.Translation.FrmDownload_Info_DownloadCanceledByUser, New object(0) {})
            End If
        End Sub

        Private Sub Document_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs)
            If System.String.IsNullOrEmpty(_target) Then
                Return
            End If
            Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                sublightClient1.UpdateAdStatisticAsync(Sublight.BaseForm.Session, _adId, _target)
            End Using
            OpenInBrowser(_target)
        End Sub

        Private Sub FrmDownload_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            lblPleaseWait = New System.Windows.Forms.Label
            lblNote = New System.Windows.Forms.Label
            btnCancel = New Sublight.Controls.Button.Button
            niceLine1 = New Sublight.Controls.NiceLine
            btnPurchasePoints = New Sublight.Controls.Button.Button
            label1 = New System.Windows.Forms.Label
            lnkHowToAdvertise = New System.Windows.Forms.LinkLabel
            wb = New System.Windows.Forms.WebBrowser
            lblLoading = New System.Windows.Forms.Label
            timer1 = New System.Windows.Forms.Timer(components)
            SuspendLayout()
            lblPleaseWait.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblPleaseWait.Location = New System.Drawing.Point(9, 9)
            lblPleaseWait.Name = "lblPleaseWait?"
            lblPleaseWait.Size = New System.Drawing.Size(475, 38)
            lblPleaseWait.TabIndex = 0
            lblPleaseWait.Text = "Please wait few seconds for your download to begin:?"
            lblNote.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblNote.Location = New System.Drawing.Point(9, 47)
            lblNote.Name = "lblNote?"
            lblNote.Size = New System.Drawing.Size(475, 31)
            lblNote.TabIndex = 193
            lblNote.Text = "Note: you have % points. Users with positive points do not wait for download.?"
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Id = "ba08ae99-b2db-4d0b-b046-277ec2337634?"
            btnCancel.Image = Nothing
            btnCancel.Location = New System.Drawing.Point(409, 204)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 195
            btnCancel.Text = "Preklici?"
            btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnCancel.UseVisualStyleBackColor = True
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            niceLine1.Location = New System.Drawing.Point(12, 180)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(472, 15)
            niceLine1.TabIndex = 194
            btnPurchasePoints.AutoResize = False
            btnPurchasePoints.Id = "aca760cb-2ea2-4bf9-89e2-2af3c7b205c2?"
            btnPurchasePoints.Image = Nothing
            btnPurchasePoints.Location = New System.Drawing.Point(9, 204)
            btnPurchasePoints.Name = "btnPurchasePoints?"
            btnPurchasePoints.Size = New System.Drawing.Size(172, 23)
            btnPurchasePoints.TabIndex = 196
            btnPurchasePoints.Text = "Purchase points...?"
            btnPurchasePoints.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnPurchasePoints.UseVisualStyleBackColor = True
            AddHandler btnPurchasePoints.Click, AddressOf btnPurchasePoints_Click
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            label1.Location = New System.Drawing.Point(9, 90)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(236, 17)
            label1.TabIndex = 200
            label1.Text = "Ads:?"
            lnkHowToAdvertise.Location = New System.Drawing.Point(243, 90)
            lnkHowToAdvertise.Name = "lnkHowToAdvertise?"
            lnkHowToAdvertise.Size = New System.Drawing.Size(241, 17)
            lnkHowToAdvertise.TabIndex = 201
            lnkHowToAdvertise.TabStop = True
            lnkHowToAdvertise.Text = "How to advertise??"
            lnkHowToAdvertise.TextAlign = System.Drawing.ContentAlignment.TopRight
            AddHandler lnkHowToAdvertise.LinkClicked, AddressOf lnkHowToAdvertise_LinkClicked
            wb.Location = New System.Drawing.Point(12, 110)
            wb.MinimumSize = New System.Drawing.Size(20, 20)
            wb.Name = "wb?"
            wb.ScriptErrorsSuppressed = True
            wb.ScrollBarsEnabled = False
            wb.Size = New System.Drawing.Size(472, 64)
            wb.TabIndex = 202
            wb.Visible = False
            lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblLoading.Location = New System.Drawing.Point(9, 110)
            lblLoading.Name = "lblLoading?"
            lblLoading.Size = New System.Drawing.Size(475, 64)
            lblLoading.TabIndex = 203
            lblLoading.Text = "Loading...?"
            lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler timer1.Tick, AddressOf timer1_Tick
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(496, 240)
            Controls.Add(lblLoading)
            Controls.Add(wb)
            Controls.Add(lnkHowToAdvertise)
            Controls.Add(label1)
            Controls.Add(btnPurchasePoints)
            Controls.Add(btnCancel)
            Controls.Add(niceLine1)
            Controls.Add(lblNote)
            Controls.Add(lblPleaseWait)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmDownload?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Your download will start in few seconds...?"
            AddHandler Load, AddressOf FrmDownload_Load
            ResumeLayout(False)
        End Sub

        Private Sub lnkHowToAdvertise_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
            OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl("Advertise.aspx?"))
        End Sub

        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim timeSpan1 As System.TimeSpan = System.DateTime.Now - _started
            Dim i1 As Integer = System.Convert.ToInt32(timeSpan1.TotalMilliseconds)
            Dim i2 As Integer = _delay * 1000
            If i1 >= i2 Then
                timer1.Stop()
                lblPleaseWait.Text = System.String.Format(Sublight.Translation.FrmDownload_DownloadCountdown, 0)
                _readyForDownload = True
                DialogResult = System.Windows.Forms.DialogResult.OK
                Close()
                Return
            End If
            Dim i3 As Integer = i2 - i1
            If i3 >= 0 Then
                Dim s1 As String = System.String.Format(Sublight.Translation.FrmDownload_DownloadCountdown, System.Math.Ceiling(CDbl(i3) / 1000.0R))
                If lblPleaseWait.Text <> s1 Then
                    lblPleaseWait.Text = s1
                End If
            End If
        End Sub

        Private Sub wb_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs)
            If IsDisposed Then
                Return
            End If
            lblLoading.Visible = False
            wb.Visible = True
            If Not (wb.Document) Is Nothing Then
                AddHandler wb.Document.Click, AddressOf Document_Click
            End If
            RemoveHandler wb.Navigated, AddressOf wb_Navigated
            AddHandler wb.Navigating, AddressOf wb_Navigating
        End Sub

        Private Sub wb_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs)
            e.Cancel = True
            Dim s1 As String = e.Url.ToString()
            Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                sublightClient1.UpdateAdStatisticAsync(Sublight.BaseForm.Session, _adId, s1)
            End Using
            OpenInBrowser(s1)
        End Sub

        Private Sub ws_GetAdCompleted(ByVal sender As Object, ByVal e As Sublight.WS_SublightClient.GetAdCompletedEventArgs)
            If IsDisposed Then
                Return
            End If
            If Not (e.Error) Is Nothing Then
                Return
            End If
            If Not e.Result Then
                Return
            End If
            If System.String.IsNullOrEmpty(e.banner) Then
                Return
            End If
            _adId = e.id
            _target = e.target
            wb.Navigate(e.banner)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
            DisplayMessageIfNecessary()
            MyBase.OnClosing(e)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            AddHandler wb.Navigated, AddressOf wb_Navigated
            Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                AddHandler sublightClient1.GetAdCompleted, AddressOf ws_GetAdCompleted
                sublightClient1.GetAdAsync(Sublight.BaseForm.Session)
            End Using
        End Sub

    End Class ' class FrmDownload

End Namespace

