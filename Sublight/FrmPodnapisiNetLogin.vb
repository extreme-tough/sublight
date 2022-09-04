Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Properties

Namespace Sublight

    Public Class FrmPodnapisiNetLogin
        Inherits Sublight.BaseForm

        Public Enum ActionType
            SubtitleDownload
            Other
        End Enum

        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private cbRememberMe As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private lblDescription As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private txtPassword As Sublight.Controls.MyTextBox 
        Private txtUsername As Sublight.Controls.MyTextBox 

        Public ReadOnly Property LoginPassword As String
            Get
                Return txtPassword.Text
            End Get
        End Property

        Public ReadOnly Property LoginUsername As String
            Get
                Return txtUsername.Text
            End Get
        End Property

        Public ReadOnly Property LoginUsernamePasswordEmpty As Boolean
            Get
                If System.String.IsNullOrEmpty(LoginUsername) Then
                    Return System.String.IsNullOrEmpty(LoginPassword)
                End If
                Return False
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal type As Sublight.FrmPodnapisiNetLogin.ActionType)
            InitializeComponent()
            pictureBox1.Image = New System.Drawing.Bitmap(System.Drawing.SystemIcons.Information.ToBitmap())
            Text = "Podnapisi.NET login?"
            cbRememberMe.Text = "Remember me on this computer.?"
            btnOK.Text = "OK?"
            btnCancel.Text = "Cancel?"
            label1.Text = "Username:?"
            label2.Text = "Password:?"
            If type = Sublight.FrmPodnapisiNetLogin.ActionType.SubtitleDownload Then
                lblDescription.Text = "You must enter your Podnapisi.NET username and password to continue with download. If you are not member of Podnapisi.NET then please register on http://www.podnapisi.net?"
            Else 
                lblDescription.Text = "Here you can enter your Podnapisi.NET username and password. They will be used for auto login. If you leave these fields blank you will be logged anonymous.?"
            End If
            txtUsername.Text = Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Username
            If Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password) AndAlso Sublight.MyUtility.Encryption.IsPasswordEncrypted(Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password) Then
                txtPassword.Text = Sublight.MyUtility.Encryption.DecryptPassword(Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password)
                Return
            End If
            txtPassword.Text = Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If cbRememberMe.Checked Then
                Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Username = txtUsername.Text
                If System.String.IsNullOrEmpty(txtPassword.Text) Then
                    Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password = System.String.Empty
                Else 
                    Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password = Sublight.MyUtility.Encryption.EncryptPassword(txtPassword.Text)
                End If
                Sublight.BaseForm.SaveUserSettingsSilent()
            End If
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub InitializeComponent()
            niceLine1 = New Sublight.Controls.NiceLine
            btnCancel = New Sublight.Controls.Button.Button
            btnOK = New Sublight.Controls.Button.Button
            cbRememberMe = New Sublight.Controls.MyCheckBox
            txtPassword = New Sublight.Controls.MyTextBox
            label2 = New System.Windows.Forms.Label
            txtUsername = New Sublight.Controls.MyTextBox
            label1 = New System.Windows.Forms.Label
            pictureBox1 = New System.Windows.Forms.PictureBox
            lblDescription = New System.Windows.Forms.Label
            pictureBox1.BeginInit()
            SuspendLayout()
            niceLine1.Location = New System.Drawing.Point(15, 138)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(508, 15)
            niceLine1.TabIndex = 141
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(448, 156)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 140
            btnCancel.Text = "Cancel?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnOK.DialogResult = System.Windows.Forms.DialogResult.None
            btnOK.Location = New System.Drawing.Point(367, 156)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 139
            btnOK.Text = "OK?"
            btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnOK.Click, AddressOf btnOK_Click
            cbRememberMe.AutoSize = True
            cbRememberMe.Location = New System.Drawing.Point(112, 115)
            cbRememberMe.Name = "cbRememberMe?"
            cbRememberMe.Size = New System.Drawing.Size(190, 17)
            cbRememberMe.TabIndex = 2
            cbRememberMe.Text = "Zapomni si me na tem racunalniku.?"
            cbRememberMe.UseVisualStyleBackColor = True
            txtPassword.Location = New System.Drawing.Point(112, 89)
            txtPassword.Name = "txtPassword?"
            txtPassword.Size = New System.Drawing.Size(204, 20)
            txtPassword.TabIndex = 1
            txtPassword.UseSystemPasswordChar = True
            AddHandler txtPassword.KeyDown, AddressOf txtPassword_KeyDown
            label2.Location = New System.Drawing.Point(12, 89)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(94, 20)
            label2.TabIndex = 146
            label2.Text = "Geslo:?"
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            txtUsername.Location = New System.Drawing.Point(112, 63)
            txtUsername.Name = "txtUsername?"
            txtUsername.Size = New System.Drawing.Size(204, 20)
            txtUsername.TabIndex = 0
            AddHandler txtUsername.KeyDown, AddressOf txtUsername_KeyDown
            label1.Location = New System.Drawing.Point(12, 63)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(94, 20)
            label1.TabIndex = 143
            label1.Text = "Uporabniško ime:?"
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            pictureBox1.Location = New System.Drawing.Point(15, 9)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(32, 32)
            pictureBox1.TabIndex = 149
            pictureBox1.TabStop = False
            lblDescription.Location = New System.Drawing.Point(53, 9)
            lblDescription.Name = "lblDescription?"
            lblDescription.Size = New System.Drawing.Size(432, 54)
            lblDescription.TabIndex = 148
            lblDescription.Text = "Tukaj lahko vnesete vaše uporabniško ime in geslo za stran Podnapisi.NET. Podatki bodo uporabljeni za samodejno prijavo v sistem. Ce pustite pustite polja prazna boste prijavljeni anonimno.?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(535, 191)
            Controls.Add(pictureBox1)
            Controls.Add(lblDescription)
            Controls.Add(cbRememberMe)
            Controls.Add(txtPassword)
            Controls.Add(label2)
            Controls.Add(txtUsername)
            Controls.Add(label1)
            Controls.Add(niceLine1)
            Controls.Add(btnCancel)
            Controls.Add(btnOK)
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmPodnapisiNetLogin?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Podnapisi.NET login?"
            pictureBox1.EndInit()
            ResumeLayout(False)
            PerformLayout()
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

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            If System.String.IsNullOrEmpty(txtUsername.Text) Then
                txtUsername.Select()
                txtUsername.Focus()
                Return
            End If
            If System.String.IsNullOrEmpty(txtPassword.Text) Then
                txtPassword.Select()
                txtPassword.Focus()
            End If
        End Sub

    End Class ' class FrmPodnapisiNetLogin

End Namespace

