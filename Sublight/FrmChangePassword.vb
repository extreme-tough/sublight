Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmChangePassword
        Inherits Sublight.BaseForm

        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblNewPassword As System.Windows.Forms.Label 
        Private lblNewPasswordReentered As System.Windows.Forms.Label 
        Private lblOldPassword As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private txtNewPassword As Sublight.Controls.MyTextBox 
        Private txtNewPasswordReentered As Sublight.Controls.MyTextBox 
        Private txtOldPassword As Sublight.Controls.MyTextBox 

        Public Sub New()
            InitializeComponent()
            btnOK.Text = Sublight.Translation.Common_Button_OK
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            Text = Sublight.Translation.FrmChangePassword_Text
            lblOldPassword.Text = Sublight.Translation.FrmChangePassword_Label_OldPassword
            lblNewPassword.Text = Sublight.Translation.FrmChangePassword_Label_NewPassword
            lblNewPasswordReentered.Text = Sublight.Translation.FrmChangePassword_Label_NewPasswordReentered
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            If System.String.IsNullOrEmpty(txtOldPassword.Text) Then
                ShowError(Sublight.Translation.FrmChangePassword_Error_NoOldPassword, New object(0) {})
                Return
            End If
            If System.String.IsNullOrEmpty(txtNewPassword.Text) OrElse System.String.IsNullOrEmpty(txtNewPasswordReentered.Text) Then
                ShowError(Sublight.Translation.FrmChangePassword_Error_NoNewPassword, New object(0) {})
                Return
            End If
            If txtNewPassword.Text <> txtNewPasswordReentered.Text Then
                ShowError(Sublight.Translation.FrmChangePassword_Error_NewPasswordReenteredDoesNotMatch, New object(0) {})
                Return
            End If
            Dim sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
            Try
                If Not sublight1.ChangePassword(Sublight.BaseForm.Session, txtOldPassword.Text, txtNewPassword.Text, out s1) Then
                    ShowError(s1, New object(0) {})
                Else 
                    ShowInfo(Sublight.Translation.FrmChangePassword_Info_PasswordChanged, New object(0) {})
                    Close()
                End If
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmChangePassword.btnOK_Click?", e1)
                ExceptionHandlerUI(e1)
            Finally
                If Not (sublight1) Is Nothing Then
                    sublight1.Dispose()
                End If
            End Try
        End Sub

        Private Sub FrmChangePassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub InitializeComponent()
            lblNewPasswordReentered = New System.Windows.Forms.Label
            lblOldPassword = New System.Windows.Forms.Label
            lblNewPassword = New System.Windows.Forms.Label
            txtNewPassword = New Sublight.Controls.MyTextBox
            niceLine1 = New Sublight.Controls.NiceLine
            btnCancel = New Sublight.Controls.Button.Button
            btnOK = New Sublight.Controls.Button.Button
            txtNewPasswordReentered = New Sublight.Controls.MyTextBox
            txtOldPassword = New Sublight.Controls.MyTextBox
            SuspendLayout()
            lblNewPasswordReentered.Location = New System.Drawing.Point(8, 64)
            lblNewPasswordReentered.Name = "lblNewPasswordReentered?"
            lblNewPasswordReentered.Size = New System.Drawing.Size(104, 20)
            lblNewPasswordReentered.TabIndex = 13
            lblNewPasswordReentered.Text = "Ponovljeno geslo:?"
            lblNewPasswordReentered.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            lblOldPassword.Location = New System.Drawing.Point(8, 12)
            lblOldPassword.Name = "lblOldPassword?"
            lblOldPassword.Size = New System.Drawing.Size(104, 20)
            lblOldPassword.TabIndex = 11
            lblOldPassword.Text = "Staro geslo:?"
            lblOldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            lblNewPassword.Location = New System.Drawing.Point(8, 38)
            lblNewPassword.Name = "lblNewPassword?"
            lblNewPassword.Size = New System.Drawing.Size(104, 20)
            lblNewPassword.TabIndex = 18
            lblNewPassword.Text = "Novo geslo:?"
            lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            txtNewPassword.Location = New System.Drawing.Point(118, 38)
            txtNewPassword.Name = "txtNewPassword?"
            txtNewPassword.Size = New System.Drawing.Size(194, 20)
            txtNewPassword.TabIndex = 1
            txtNewPassword.UseSystemPasswordChar = True
            niceLine1.Location = New System.Drawing.Point(11, 90)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(301, 15)
            niceLine1.TabIndex = 16
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.None
            btnCancel.Location = New System.Drawing.Point(237, 108)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 15
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnOK.DialogResult = System.Windows.Forms.DialogResult.None
            btnOK.Location = New System.Drawing.Point(156, 108)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 14
            btnOK.Text = "V redu?"
            btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnOK.Click, AddressOf btnOK_Click
            txtNewPasswordReentered.Location = New System.Drawing.Point(118, 64)
            txtNewPasswordReentered.Name = "txtNewPasswordReentered?"
            txtNewPasswordReentered.Size = New System.Drawing.Size(194, 20)
            txtNewPasswordReentered.TabIndex = 2
            txtNewPasswordReentered.UseSystemPasswordChar = True
            txtOldPassword.Location = New System.Drawing.Point(118, 12)
            txtOldPassword.Name = "txtOldPassword?"
            txtOldPassword.Size = New System.Drawing.Size(194, 20)
            txtOldPassword.TabIndex = 0
            txtOldPassword.UseSystemPasswordChar = True
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(320, 140)
            Controls.Add(txtNewPassword)
            Controls.Add(lblNewPassword)
            Controls.Add(niceLine1)
            Controls.Add(btnCancel)
            Controls.Add(btnOK)
            Controls.Add(txtNewPasswordReentered)
            Controls.Add(lblNewPasswordReentered)
            Controls.Add(txtOldPassword)
            Controls.Add(lblOldPassword)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            KeyPreview = True
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmChangePassword?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "FrmChangePassword?"
            AddHandler KeyUp, AddressOf FrmChangePassword_KeyUp
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmChangePassword

End Namespace

