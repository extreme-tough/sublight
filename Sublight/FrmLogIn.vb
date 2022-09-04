Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmLogIn
        Inherits Sublight.BaseForm

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <NewUsername>k__BackingField As String 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private cbNRememberMe As Sublight.Controls.MyCheckBox 
        Private cbRememberMe As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private label3 As System.Windows.Forms.Label 
        Private label4 As System.Windows.Forms.Label 
        Private label5 As System.Windows.Forms.Label 
        Private label6 As System.Windows.Forms.Label 
        Private lblCaption As System.Windows.Forms.Label 
        Private lnkNewUser As System.Windows.Forms.LinkLabel 
        Private lnkResetPassword As System.Windows.Forms.LinkLabel 
        Private myPanel1 As Sublight.Controls.MyPanel 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private panelLogin As Sublight.Controls.MyPanel 
        Private panelRegister As Sublight.Controls.MyPanel 
        Private pictureBoxTop As System.Windows.Forms.PictureBox 
        Private ttNEmailTip As Sublight.Controls.ToolTip 
        Private txtNEmail As Sublight.Controls.MyTextBox 
        Private txtNPassword As Sublight.Controls.MyTextBox 
        Private txtNRepeatedPassword As Sublight.Controls.MyTextBox 
        Private txtNUsername As Sublight.Controls.MyTextBox 
        Private txtPassword As Sublight.Controls.MyTextBox 
        Private txtUsername As Sublight.Controls.MyTextBox 

        Public Property NewUsername As String
            Get
                Return <NewUsername>k__BackingField
            End Get
            Set
                <NewUsername>k__BackingField = value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal showNewUser As Boolean)
            InitializeComponent()
            pictureBoxTop.BackColor = System.Drawing.Color.FromArgb(41, 69, 222)
            cbRememberMe.Checked = Sublight.Properties.Settings.Default.LogIn_RememberMe
            txtUsername.Text = Sublight.Properties.Settings.Default.LogIn_Username
            txtPassword.Text = IIf(cbRememberMe.Checked, Sublight.MyUtility.Encryption.DecryptPassword(Sublight.Properties.Settings.Default.LogIn_Password), System.String.Empty)
            panelLogin.Top = 61
            panelRegister.Top = 61
            LoginRegisterSwitch(True)
            btnOK.Text = Sublight.Translation.Common_Button_OK
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            Text = Sublight.Translation.LogIn_Title
            cbRememberMe.Text = Sublight.Translation.LogIn_RememberMe
            label1.Text = Sublight.Translation.LogIn_Username
            label2.Text = Sublight.Translation.LogIn_Password
            cbNRememberMe.Text = cbRememberMe.Text
            cbNRememberMe.Checked = cbRememberMe.Checked
            lnkNewUser.Text = Sublight.Translation.LogIn_Button_NewUser
            label4.Text = Sublight.Translation.LogIn_Username
            label3.Text = Sublight.Translation.LogIn_Password
            label5.Text = Sublight.Translation.LogIn_ReenterPassword
            label6.Text = Sublight.Translation.LogIn_Email
            lnkResetPassword.Text = Sublight.Translation.LogIn_Button_ResetPassword
            ttNEmailTip.AutoPopDelay = 15000
            ttNEmailTip.Text = Sublight.Translation.LogIn_Email_Privacy
            If showNewUser Then
                LoginRegisterSwitch(False)
            End If
            EnableDisableResetPassword()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String, s2 As String

            If panelRegister.Visible Then
                Try
                    EnableDisableControls(False)
                    Sublight.Properties.Settings.Default.LogIn_RememberMe = cbNRememberMe.Checked
                    If cbNRememberMe.Checked Then
                        Sublight.Properties.Settings.Default.LogIn_Username = txtNUsername.Text
                    End If
                    Sublight.Properties.Settings.Default.LogIn_Password = System.String.Empty
                    SaveUserSettings()
                    If System.String.IsNullOrEmpty(txtNUsername.Text) Then
                        ShowError(Sublight.Translation.LogIn_Error_NoUsername, New object(0) {})
                        Return
                    End If
                    If System.String.IsNullOrEmpty(txtNEmail.Text) Then
                        ShowError(Sublight.Translation.LogIn_Error_NoEmail, New object(0) {})
                        Return
                    End If
                    If System.String.IsNullOrEmpty(txtNPassword.Text) OrElse System.String.IsNullOrEmpty(txtNRepeatedPassword.Text) Then
                        ShowError(Sublight.Translation.LogIn_Error_NoPassword, New object(0) {})
                        Return
                    End If
                    If System.String.Compare(txtNPassword.Text, txtNRepeatedPassword.Text, False) <> 0 Then
                        ShowError(Sublight.Translation.LogIn_Error_PasswordsDoNotMatch, New object(0) {})
                        Return
                    End If
                    If Not Register(Me, txtNUsername.Text, txtNPassword.Text, txtNEmail.Text, out s1) Then
                        Dim objArr1 As Object() = New object() { s1 }
                        ShowError(Sublight.Translation.LogIn_Error_NewUserRegistration, objArr1)
                        Return
                    End If
                    NewUsername = txtNUsername.Text
                    Dim flag1 As Boolean = LogIn(txtNUsername.Text, Sublight.BaseForm.ToHash(txtNPassword.Text), out s1)
                    If flag1 Then
                        If Sublight.Properties.Settings.Default.LogIn_RememberMe Then
                            Sublight.Properties.Settings.Default.LogIn_Password = Sublight.MyUtility.Encryption.EncryptPassword(txtNPassword.Text)
                            SaveUserSettings()
                        End If
                        Sublight.Globals.Events.OnUserLogIn(Sublight.BaseForm.IsAnonymous)
                        CloseForm()
                    Else 
                        ShowError(Sublight.Translation.LogIn_Error_WrongUsernameOrPassword, New object(0) {})
                    End If
                    Return
                Finally
                    EnableDisableControls(True)
                End Try
            End If
            If panelLogin.Visible Then
                Try
                    EnableDisableControls(False)
                    Sublight.Properties.Settings.Default.LogIn_RememberMe = cbRememberMe.Checked
                    If cbRememberMe.Checked Then
                        Sublight.Properties.Settings.Default.LogIn_Username = txtUsername.Text
                    End If
                    Sublight.Properties.Settings.Default.LogIn_Password = System.String.Empty
                    SaveUserSettings()
                    Dim flag2 As Boolean = LogIn(txtUsername.Text, Sublight.BaseForm.ToHash(txtPassword.Text), out s2)
                    If flag2 Then
                        If Sublight.Properties.Settings.Default.LogIn_RememberMe Then
                            Sublight.Properties.Settings.Default.LogIn_Password = Sublight.MyUtility.Encryption.EncryptPassword(txtPassword.Text)
                            SaveUserSettings()
                        End If
                        Sublight.Globals.Events.OnUserLogIn(Sublight.BaseForm.IsAnonymous)
                        CloseForm()
                    Else 
                        ShowError(Sublight.Translation.LogIn_Error_WrongUsernameOrPassword, New object(0) {})
                    End If
                Finally
                    EnableDisableControls(True)
                End Try
            End If
        End Sub

        Private Sub CloseForm()
            If InvokeRequired Then
                Dim objArr1 As Object() = New object(2) {}
                objArr1(0) = Me
                Dim objArr2 As Object() = New object(1) {}
                objArr1(1) = objArr2
                BeginInvoke(New System.Windows.Forms.MethodInvoker(CloseForm2), objArr1)
                Return
            End If
            CloseForm2()
        End Sub

        Private Sub CloseForm2()
            EnableDisableControls(True)
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub EnableDisableControls(ByVal enabled As Boolean)
            btnOK.Enabled = enabled
            btnCancel.Enabled = enabled
            lnkNewUser.Enabled = enabled
            lnkResetPassword.Enabled = enabled
            txtUsername.Enabled = enabled
            txtPassword.Enabled = enabled
            txtNUsername.Enabled = enabled
            txtNPassword.Enabled = enabled
            txtNRepeatedPassword.Enabled = enabled
            txtNEmail.Enabled = enabled
            cbRememberMe.Enabled = enabled
            cbNRememberMe.Enabled = enabled
        End Sub

        Private Sub EnableDisableResetPassword()
            lnkResetPassword.Enabled = txtUsername.Text.Trim().Length > 0
        End Sub

        Private Sub FrmLogIn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
            If Not btnCancel.Enabled Then
                e.Cancel = True
            End If
        End Sub

        Private Sub FrmLogIn_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub InitializeComponent()
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.FrmLogIn))
            pictureBoxTop = New System.Windows.Forms.PictureBox
            myPanel1 = New Sublight.Controls.MyPanel
            lnkResetPassword = New System.Windows.Forms.LinkLabel
            lnkNewUser = New System.Windows.Forms.LinkLabel
            niceLine1 = New Sublight.Controls.NiceLine
            btnCancel = New Sublight.Controls.Button.Button
            btnOK = New Sublight.Controls.Button.Button
            panelLogin = New Sublight.Controls.MyPanel
            cbRememberMe = New Sublight.Controls.MyCheckBox
            txtPassword = New Sublight.Controls.MyTextBox
            label2 = New System.Windows.Forms.Label
            txtUsername = New Sublight.Controls.MyTextBox
            label1 = New System.Windows.Forms.Label
            panelRegister = New Sublight.Controls.MyPanel
            ttNEmailTip = New Sublight.Controls.ToolTip
            txtNEmail = New Sublight.Controls.MyTextBox
            label6 = New System.Windows.Forms.Label
            txtNRepeatedPassword = New Sublight.Controls.MyTextBox
            label5 = New System.Windows.Forms.Label
            cbNRememberMe = New Sublight.Controls.MyCheckBox
            txtNPassword = New Sublight.Controls.MyTextBox
            label3 = New System.Windows.Forms.Label
            txtNUsername = New Sublight.Controls.MyTextBox
            label4 = New System.Windows.Forms.Label
            lblCaption = New System.Windows.Forms.Label
            pictureBoxTop.BeginInit()
            myPanel1.SuspendLayout()
            panelLogin.SuspendLayout()
            panelRegister.SuspendLayout()
            SuspendLayout()
            pictureBoxTop.Dock = System.Windows.Forms.DockStyle.Top
            pictureBoxTop.Image = CType(componentResourceManager1.GetObject("pictureBoxTop.Image?"), System.Drawing.Image)
            pictureBoxTop.Location = New System.Drawing.Point(0, 0)
            pictureBoxTop.Margin = New System.Windows.Forms.Padding(0)
            pictureBoxTop.Name = "pictureBoxTop?"
            pictureBoxTop.Size = New System.Drawing.Size(318, 58)
            pictureBoxTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBoxTop.TabIndex = 5
            pictureBoxTop.TabStop = False
            AddHandler pictureBoxTop.Paint, AddressOf pictureBoxTop_Paint
            myPanel1.Controls.Add(lnkResetPassword)
            myPanel1.Controls.Add(lnkNewUser)
            myPanel1.Controls.Add(niceLine1)
            myPanel1.Controls.Add(btnCancel)
            myPanel1.Controls.Add(btnOK)
            myPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
            myPanel1.Location = New System.Drawing.Point(0, 323)
            myPanel1.Name = "myPanel1?"
            myPanel1.Size = New System.Drawing.Size(318, 52)
            myPanel1.TabIndex = 10
            lnkResetPassword.AutoSize = True
            lnkResetPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
            lnkResetPassword.LinkColor = System.Drawing.Color.FromArgb(82, 102, 204)
            lnkResetPassword.Location = New System.Drawing.Point(9, 33)
            lnkResetPassword.Name = "lnkResetPassword?"
            lnkResetPassword.Size = New System.Drawing.Size(92, 13)
            lnkResetPassword.TabIndex = 14
            lnkResetPassword.TabStop = True
            lnkResetPassword.Text = "Reset password...?"
            AddHandler lnkResetPassword.LinkClicked, AddressOf lnkResetPassword_LinkClicked
            lnkNewUser.AutoSize = True
            lnkNewUser.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
            lnkNewUser.LinkColor = System.Drawing.Color.FromArgb(82, 102, 204)
            lnkNewUser.Location = New System.Drawing.Point(9, 16)
            lnkNewUser.Name = "lnkNewUser?"
            lnkNewUser.Size = New System.Drawing.Size(52, 13)
            lnkNewUser.TabIndex = 13
            lnkNewUser.TabStop = True
            lnkNewUser.Text = "New user?"
            AddHandler lnkNewUser.LinkClicked, AddressOf lnkNewUser_LinkClicked
            niceLine1.Location = New System.Drawing.Point(12, 3)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(294, 15)
            niceLine1.TabIndex = 12
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.None
            btnCancel.Location = New System.Drawing.Point(231, 20)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 11
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnOK.AutoResize = False
            btnOK.DialogResult = System.Windows.Forms.DialogResult.None
            btnOK.Location = New System.Drawing.Point(150, 20)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 10
            btnOK.Text = "V redu?"
            btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnOK.Click, AddressOf btnOK_Click
            panelLogin.Controls.Add(cbRememberMe)
            panelLogin.Controls.Add(txtPassword)
            panelLogin.Controls.Add(label2)
            panelLogin.Controls.Add(txtUsername)
            panelLogin.Controls.Add(label1)
            panelLogin.Location = New System.Drawing.Point(0, 61)
            panelLogin.Name = "panelLogin?"
            panelLogin.Size = New System.Drawing.Size(318, 79)
            panelLogin.TabIndex = 11
            cbRememberMe.Location = New System.Drawing.Point(15, 55)
            cbRememberMe.Name = "cbRememberMe?"
            cbRememberMe.Size = New System.Drawing.Size(291, 17)
            cbRememberMe.TabIndex = 6
            cbRememberMe.Text = "Zapomni si me na tem racunalniku.?"
            cbRememberMe.UseVisualStyleBackColor = True
            txtPassword.EnableDisableColor = True
            txtPassword.Location = New System.Drawing.Point(129, 29)
            txtPassword.Name = "txtPassword?"
            txtPassword.Size = New System.Drawing.Size(177, 20)
            txtPassword.TabIndex = 5
            txtPassword.UseSystemPasswordChar = True
            AddHandler txtPassword.KeyDown, AddressOf txtPassword_KeyDown
            label2.Location = New System.Drawing.Point(12, 29)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(111, 20)
            label2.TabIndex = 7
            label2.Text = "Geslo:?"
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            txtUsername.EnableDisableColor = True
            txtUsername.Location = New System.Drawing.Point(129, 3)
            txtUsername.Name = "txtUsername?"
            txtUsername.Size = New System.Drawing.Size(177, 20)
            txtUsername.TabIndex = 3
            AddHandler txtUsername.TextChanged, AddressOf txtUsername_TextChanged
            AddHandler txtUsername.KeyDown, AddressOf txtUsername_KeyDown
            label1.Location = New System.Drawing.Point(12, 3)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(111, 20)
            label1.TabIndex = 4
            label1.Text = "Uporabniško ime:?"
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            panelRegister.Controls.Add(ttNEmailTip)
            panelRegister.Controls.Add(txtNEmail)
            panelRegister.Controls.Add(label6)
            panelRegister.Controls.Add(txtNRepeatedPassword)
            panelRegister.Controls.Add(label5)
            panelRegister.Controls.Add(cbNRememberMe)
            panelRegister.Controls.Add(txtNPassword)
            panelRegister.Controls.Add(label3)
            panelRegister.Controls.Add(txtNUsername)
            panelRegister.Controls.Add(label4)
            panelRegister.Location = New System.Drawing.Point(0, 146)
            panelRegister.Name = "panelRegister?"
            panelRegister.Size = New System.Drawing.Size(318, 130)
            panelRegister.TabIndex = 12
            panelRegister.Visible = False
            ttNEmailTip.AutoPopDelay = 5000
            ttNEmailTip.Location = New System.Drawing.Point(300, 85)
            ttNEmailTip.Name = "ttNEmailTip?"
            ttNEmailTip.Size = New System.Drawing.Size(13, 13)
            ttNEmailTip.TabIndex = 19
            ttNEmailTip.Title = System.String.Empty
            txtNEmail.EnableDisableColor = True
            txtNEmail.Location = New System.Drawing.Point(129, 81)
            txtNEmail.Name = "txtNEmail?"
            txtNEmail.Size = New System.Drawing.Size(168, 20)
            txtNEmail.TabIndex = 10
            label6.Location = New System.Drawing.Point(12, 81)
            label6.Name = "label6?"
            label6.Size = New System.Drawing.Size(111, 20)
            label6.TabIndex = 11
            label6.Text = "El. pošta:?"
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            txtNRepeatedPassword.EnableDisableColor = True
            txtNRepeatedPassword.Location = New System.Drawing.Point(129, 55)
            txtNRepeatedPassword.Name = "txtNRepeatedPassword?"
            txtNRepeatedPassword.Size = New System.Drawing.Size(168, 20)
            txtNRepeatedPassword.TabIndex = 8
            txtNRepeatedPassword.UseSystemPasswordChar = True
            label5.Location = New System.Drawing.Point(12, 52)
            label5.Name = "label5?"
            label5.Size = New System.Drawing.Size(111, 26)
            label5.TabIndex = 9
            label5.Text = "Ponovljeno geslo:?"
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            cbNRememberMe.Location = New System.Drawing.Point(15, 107)
            cbNRememberMe.Name = "cbNRememberMe?"
            cbNRememberMe.Size = New System.Drawing.Size(282, 17)
            cbNRememberMe.TabIndex = 12
            cbNRememberMe.Text = "Zapomni si me na tem racunalniku.?"
            cbNRememberMe.UseVisualStyleBackColor = True
            txtNPassword.EnableDisableColor = True
            txtNPassword.Location = New System.Drawing.Point(129, 29)
            txtNPassword.Name = "txtNPassword?"
            txtNPassword.Size = New System.Drawing.Size(168, 20)
            txtNPassword.TabIndex = 5
            txtNPassword.UseSystemPasswordChar = True
            label3.Location = New System.Drawing.Point(12, 29)
            label3.Name = "label3?"
            label3.Size = New System.Drawing.Size(111, 20)
            label3.TabIndex = 7
            label3.Text = "Geslo:?"
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            txtNUsername.EnableDisableColor = True
            txtNUsername.Location = New System.Drawing.Point(129, 3)
            txtNUsername.Name = "txtNUsername?"
            txtNUsername.Size = New System.Drawing.Size(168, 20)
            txtNUsername.TabIndex = 3
            label4.Location = New System.Drawing.Point(12, 3)
            label4.Name = "label4?"
            label4.Size = New System.Drawing.Size(111, 20)
            label4.TabIndex = 4
            label4.Text = "Uporabniško ime:?"
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            lblCaption.AutoSize = True
            lblCaption.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblCaption.Location = New System.Drawing.Point(9, 291)
            lblCaption.Name = "lblCaption?"
            lblCaption.Size = New System.Drawing.Size(72, 15)
            lblCaption.TabIndex = 13
            lblCaption.Text = "lblCaption?"
            lblCaption.Visible = False
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(318, 375)
            Controls.Add(lblCaption)
            Controls.Add(panelRegister)
            Controls.Add(panelLogin)
            Controls.Add(myPanel1)
            Controls.Add(pictureBoxTop)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            KeyPreview = True
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmLogIn?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Prijava?"
            AddHandler KeyUp, AddressOf FrmLogIn_KeyUp
            AddHandler FormClosing, AddressOf FrmLogIn_FormClosing
            pictureBoxTop.EndInit()
            myPanel1.ResumeLayout(False)
            myPanel1.PerformLayout()
            panelLogin.ResumeLayout(False)
            panelLogin.PerformLayout()
            panelRegister.ResumeLayout(False)
            panelRegister.PerformLayout()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub lnkNewUser_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
            LoginRegisterSwitch(Not panelLogin.Visible)
        End Sub

        Private Sub lnkResetPassword_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                lnkResetPassword.Enabled = False
                AddHandler sublight1.RequestPasswordResetCompleted, AddressOf ws_RequestPasswordResetCompleted
                sublight1.RequestPasswordResetAsync(Sublight.BaseForm.Session, txtUsername.Text)
            End Using
        End Sub

        Private Sub LoginRegisterSwitch(ByVal isLogin As Boolean)
            panelLogin.Visible = isLogin
            panelRegister.Visible = Not isLogin
            If isLogin Then
                Height = panelLogin.Top + panelLogin.Height + myPanel1.Height + 20
                txtUsername.Select()
                txtUsername.SelectAll()
            Else 
                lnkNewUser.Visible = False
                lnkResetPassword.Visible = False
                Height = panelRegister.Top + panelRegister.Height + myPanel1.Height + 20
                txtNUsername.Select()
                txtNUsername.SelectAll()
            End If
            pictureBoxTop.Refresh()
        End Sub

        Private Sub pictureBoxTop_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim s1 As String

            If panelLogin.Visible Then
                s1 = Sublight.Translation.LogIn_UserLoginCaption
            Else 
                s1 = Sublight.Translation.LogIn_NewUserCaption
            End If
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(80, 5, pictureBoxTop.Width - 90, pictureBoxTop.Height - 5)
            e.Graphics.DrawString(s1, lblCaption.Font, System.Drawing.Brushes.White, rectangle1)
        End Sub

        Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnOK_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtUsername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                txtPassword.Select()
                txtPassword.Focus()
            End If
        End Sub

        Private Sub txtUsername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            EnableDisableResetPassword()
        End Sub

        Private Sub ws_RequestPasswordResetCompleted(ByVal sender As Object, ByVal e As Sublight.WS.RequestPasswordResetCompletedEventArgs)
            Try
                If Sublight.BaseForm.HandleWSErrors(Me, e) Then
                    lnkResetPassword.Enabled = True
                    Return
                End If
                ShowInfo(Sublight.Translation.LogIn_Info_ConfirmPasswordReset, New object(0) {})
            Finally
                HideLoader(Me)
            End Try
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmLogIn

End Namespace

