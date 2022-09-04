Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.WS_SublightClient

Namespace Sublight

    Public NotInheritable Class FrmAbout
        Inherits Sublight.BaseForm

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass5

            Public <>4__this As Sublight.FrmAbout 
            Public sbHistory As System.Text.StringBuilder 

            Public Sub New()
            End Sub

            Public Sub <CheckNewVersion>b__0()
                Try
                    <>4__this.rtb.Rtf = sbHistory.ToString()
                Catch 
                End Try
            End Sub

        End Class ' class <>c__DisplayClass5

        Private ReadOnly m_centerScreen As Boolean 

        Private btnClose As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblCopyright As System.Windows.Forms.Label 
        Private lblHistory As System.Windows.Forms.Label 
        Private lblLink As System.Windows.Forms.LinkLabel 
        Private lblTitle As System.Windows.Forms.Label 
        Private lblVersion As System.Windows.Forms.Label 
        Private lnkUpdate As System.Windows.Forms.LinkLabel 
        Private m_newVersion As String 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private rtb As System.Windows.Forms.RichTextBox 
        Private tV_Control1 As Sublight.Controls.TV_Control 

        Public Sub New()
        End Sub

        Public Sub New(ByVal centerScreen As Boolean)
            InitializeComponent()
            m_centerScreen = centerScreen
            lblCopyright.Text = System.String.Format("Verzija: {0}?", Sublight.BaseForm.AppVersion)
            lblHistory.Text = Sublight.Translation.About_History
            btnClose.Text = Sublight.Translation.Common_Button_Close
            Text = Sublight.Translation.About_Title
            lblCopyright.Text = Sublight.Translation.About_Copyright
            lblVersion.Text = System.String.Format(Sublight.Translation.About_Version, Sublight.BaseForm.AppVersion, Sublight.BaseForm.GetSetting("Server_Version?"))
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <CheckNewVersion>b__1()
            lnkUpdate.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
            lnkUpdate.LinkColor = System.Drawing.Color.Blue
            lnkUpdate.Text = System.String.Format(Sublight.Translation.About_Version_NewVersionIsAvailable, m_newVersion)
            lnkUpdate.Enabled = True
            lnkUpdate.Visible = True
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <CheckNewVersion>b__2()
            lnkUpdate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
            lnkUpdate.LinkColor = System.Drawing.Color.Black
            lnkUpdate.Text = System.String.Format(Sublight.Translation.About_Version_ApplicationIsUpToDate, Sublight.BaseForm.AppVersion)
            lnkUpdate.Enabled = False
            lnkUpdate.Visible = True
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub CheckNewVersion()
            Dim s1 As String, s3 As String
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker
            Dim versionInfo2 As Sublight.WS_SublightClient.VersionInfo
            Dim versionInfoArr1 As Sublight.WS_SublightClient.VersionInfo()

            Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = Nothing
            Dim methodInvoker4 As System.Windows.Forms.MethodInvoker = Nothing
            Try
                Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                    If sublightClient1.GetHistory2(Sublight.BaseForm.AppVersion, out versionInfoArr1, out s1) AndAlso (Not (versionInfoArr1) Is Nothing) Then
                        Dim <>c__DisplayClass5_1 As Sublight.FrmAbout.<>c__DisplayClass5 = New Sublight.FrmAbout.<>c__DisplayClass5
                        <>c__DisplayClass5_1.<>4__this = Me
                        <>c__DisplayClass5_1.sbHistory = New System.Text.StringBuilder
                        <>c__DisplayClass5_1.sbHistory.Append("{\rtf1\ansi\ansicpg1250\deff0\deflang1060\deflangfe1060\deftab709{\fonttbl{\f0\fswiss\fprq2\fcharset238 Microsoft Sans Serif;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Microsoft Sans Serif;}{\f3\fmodern\fprq1\fcharset238{\*\fname Courier New;}Courier New CE;}{\f4\fnil\fcharset2 Symbol;}}
{\colortbl ;\red0\green0\blue255;}
{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1?")
                        Dim versionInfoArr2 As Sublight.WS_SublightClient.VersionInfo() = versionInfoArr1
                        Dim i2 As Integer = 0
                        While i2 < versionInfoArr2.Length
                            Dim versionInfo1 As Sublight.WS_SublightClient.VersionInfo = versionInfoArr2(i2)
                            <>c__DisplayClass5_1.sbHistory.Append("\pard\nowidctlpar\sl276\slmult1\ul\f0\fs18 ?")
                            Dim dateTime1 As System.DateTime = versionInfo1.Published
                            <>c__DisplayClass5_1.sbHistory.AppendFormat("Version {0} ({1}):\par?", versionInfo1.NewVersion, dateTime1.ToString("MM\/dd\/yyyy?"))
                            If Not (versionInfo1.Changes) Is Nothing Then
                                Dim i1 As Integer = 0
                                While i1 < versionInfo1.Changes.Length
                                    If i1 = 0 Then
                                        <>c__DisplayClass5_1.sbHistory.AppendFormat("\pard\nowidctlpar\fi-357\li714\sl276\slmult1\lang1033\ulnone\f1\'b7\tab\lang1060\f0 {0}\par?", versionInfo1.Changes(i1))
                                    Else 
                                        <>c__DisplayClass5_1.sbHistory.AppendFormat("\lang1033\f1\'b7\tab\lang1060\f0 {0}\par?", versionInfo1.Changes(i1))
                                    End If
                                    i1 = i1 + 1
                                End While
                            End If
                            <>c__DisplayClass5_1.sbHistory.Append("\pard\nowidctlpar\sl276\slmult1\ul\par?")
                            i2 = i2 + 1
                        End While
                        Dim bArr1 As Byte() = TryCast(Sublight.Properties.Resources.ResourceManager.GetObject("History?"), Byte[])
                        If Not (bArr1) Is Nothing Then
                            Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream(bArr1)
                                Using streamReader1 As System.IO.StreamReader = New System.IO.StreamReader(memoryStream1)
                                    While True
                                        Dim s2 As String = streamReader1.ReadLine()
                                        If Not (s2) Is Nothing Then
                                            <>c__DisplayClass5_1.sbHistory.AppendLine(s2)
                                        End If
                                    End While
                                End Using
                            End Using
                        End If
                        <>c__DisplayClass5_1.sbHistory.Append("}?")
                        Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass5_1.<CheckNewVersion>b__0)
                        Sublight.BaseForm.DoCtrlInvoke(rtb, Me, methodInvoker1)
                    End If
                End Using
            Catch 
            End Try
            Try
                Using sublightClient2 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                    If sublightClient2.CheckForUpdates(Sublight.BaseForm.AppVersion, out versionInfo2, out s3) AndAlso (Not (versionInfo2) Is Nothing) Then
                        m_newVersion = versionInfo2.NewVersion
                    Else 
                        m_newVersion = Nothing
                    End If
                End Using
                If Not System.String.IsNullOrEmpty(m_newVersion) Then
                    If (methodInvoker3) Is Nothing Then
                        methodInvoker3 = New System.Windows.Forms.MethodInvoker(<CheckNewVersion>b__1)
                    End If
                    methodInvoker2 = methodInvoker3
                Else 
                    If (methodInvoker4) Is Nothing Then
                        methodInvoker4 = New System.Windows.Forms.MethodInvoker(<CheckNewVersion>b__2)
                    End If
                    methodInvoker2 = methodInvoker4
                End If
                Sublight.BaseForm.DoCtrlInvoke(lnkUpdate, Me, methodInvoker2)
            Catch e As System.Exception
            End Try
        End Sub

        Private Sub CheckNewVersionThread()
            Try
                CheckNewVersion()
            Finally
                HideLoader(Me)
            End Try
        End Sub

        Private Sub FrmAbout_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub InitializeComponent()
            btnClose = New Sublight.Controls.Button.Button
            lblCopyright = New System.Windows.Forms.Label
            lblLink = New System.Windows.Forms.LinkLabel
            lblHistory = New System.Windows.Forms.Label
            rtb = New System.Windows.Forms.RichTextBox
            niceLine1 = New Sublight.Controls.NiceLine
            lblVersion = New System.Windows.Forms.Label
            lblTitle = New System.Windows.Forms.Label
            lnkUpdate = New System.Windows.Forms.LinkLabel
            tV_Control1 = New Sublight.Controls.TV_Control
            SuspendLayout()
            btnClose.AutoResize = False
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnClose.Id = "c3e83678-a22d-4210-9541-4d1b4b6a3bc5?"
            btnClose.Image = Nothing
            btnClose.Location = New System.Drawing.Point(341, 302)
            btnClose.Name = "btnClose?"
            btnClose.Size = New System.Drawing.Size(75, 23)
            btnClose.TabIndex = 1
            btnClose.Text = "Zapri?"
            btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnClose.UseVisualStyleBackColor = True
            AddHandler btnClose.Click, AddressOf btnClose_Click
            lblCopyright.AutoSize = True
            lblCopyright.Location = New System.Drawing.Point(136, 65)
            lblCopyright.Name = "lblCopyright?"
            lblCopyright.Size = New System.Drawing.Size(162, 13)
            lblCopyright.TabIndex = 3
            lblCopyright.Text = "© 2007-2008. All rights reserved.?"
            lblCopyright.UseMnemonic = False
            lblLink.Location = New System.Drawing.Point(0, 0)
            lblLink.Name = "lblLink?"
            lblLink.Size = New System.Drawing.Size(100, 23)
            lblLink.TabIndex = 21
            lblHistory.AutoSize = True
            lblHistory.Location = New System.Drawing.Point(12, 98)
            lblHistory.Name = "lblHistory?"
            lblHistory.Size = New System.Drawing.Size(61, 13)
            lblHistory.TabIndex = 5
            lblHistory.Text = "Zgodovina:?"
            rtb.BackColor = System.Drawing.Color.White
            rtb.Location = New System.Drawing.Point(12, 123)
            rtb.Name = "rtb?"
            rtb.ReadOnly = True
            rtb.Size = New System.Drawing.Size(404, 156)
            rtb.TabIndex = 6
            rtb.Text = "?"
            niceLine1.Location = New System.Drawing.Point(12, 285)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(404, 15)
            niceLine1.TabIndex = 7
            lblVersion.AutoSize = True
            lblVersion.Location = New System.Drawing.Point(137, 33)
            lblVersion.Name = "lblVersion?"
            lblVersion.Size = New System.Drawing.Size(65, 13)
            lblVersion.TabIndex = 17
            lblVersion.Text = "Verzija 1.0.0?"
            lblTitle.AutoSize = True
            lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblTitle.Location = New System.Drawing.Point(135, 6)
            lblTitle.Name = "lblTitle?"
            lblTitle.Size = New System.Drawing.Size(75, 20)
            lblTitle.TabIndex = 16
            lblTitle.Text = "Sublight?"
            lnkUpdate.AutoSize = True
            lnkUpdate.Location = New System.Drawing.Point(9, 307)
            lnkUpdate.Name = "lnkUpdate?"
            lnkUpdate.Size = New System.Drawing.Size(124, 13)
            lnkUpdate.TabIndex = 19
            lnkUpdate.TabStop = True
            lnkUpdate.Text = "Sublight je ažuren (1.0.0)?"
            lnkUpdate.Visible = False
            AddHandler lnkUpdate.LinkClicked, AddressOf lnkUpdate_LinkClicked
            tV_Control1.Location = New System.Drawing.Point(12, 6)
            tV_Control1.Name = "tV_Control1?"
            tV_Control1.Size = New System.Drawing.Size(114, 82)
            tV_Control1.TabIndex = 20
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            CancelButton = btnClose
            ClientSize = New System.Drawing.Size(428, 334)
            Controls.Add(tV_Control1)
            Controls.Add(lnkUpdate)
            Controls.Add(lblVersion)
            Controls.Add(lblTitle)
            Controls.Add(niceLine1)
            Controls.Add(lblCopyright)
            Controls.Add(rtb)
            Controls.Add(lblHistory)
            Controls.Add(lblLink)
            Controls.Add(btnClose)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            KeyPreview = True
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmAbout?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "O programu?"
            AddHandler KeyUp, AddressOf FrmAbout_KeyUp
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub lnkUpdate_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
            If Not lnkUpdate.Enabled OrElse (lnkUpdate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline) Then
                Return
            End If
            Sublight.MyUtility.UpdateChecker.OpenInBrowser(Me)
        End Sub

        Private Sub pbDonate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowPurchasePoints()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            ShowLoader(Me)
            Dim sArr1 As String() = New string() { _
                                                   "podnapisi?", _
                                                   "subtitles?", _
                                                   "titlovi?", _
                                                   "?????????", _
                                                   "subtítulos?", _
                                                   "Untertitel?", _
                                                   "sottotitoli?", _
                                                   "?p?t?t????", _
                                                   "???" }
            tV_Control1.LoadSubtitles(sArr1)
            If m_centerScreen Then
                Dim rectangle1 As System.Drawing.Rectangle = System.Windows.Forms.Screen.GetWorkingArea(Me)
                Top = System.Convert.ToInt32((CDbl(rectangle1.Height) / 2.0R) - (CDbl(Height) / 2.0R))
                Left = System.Convert.ToInt32((CDbl(rectangle1.Width) / 2.0R) - (CDbl(Width) / 2.0R))
            End If
            Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(CheckNewVersionThread))
            thread1.Start()
        End Sub

    End Class ' class FrmAbout

End Namespace

