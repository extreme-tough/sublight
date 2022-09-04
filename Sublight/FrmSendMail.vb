Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.WS_SublightClient

Namespace Sublight

    Public Class FrmSendMail
        Inherits Sublight.BaseForm

        Private ReadOnly m_commentResponse As Boolean 
        Private ReadOnly m_message As String 
        Private ReadOnly m_to As String 
        Private ReadOnly m_userId As System.Guid 

        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnSend As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private lblSubject As System.Windows.Forms.Label 
        Private txtMessage As Sublight.Controls.MyTextBox 
        Private txtSubject As Sublight.Controls.MyTextBox 

        Public Sub New(ByVal userId As System.Guid)
            InitializeComponent()
            m_userId = userId
        End Sub

        Public Sub New(ByVal to As String, ByVal subject As String, ByVal message As String)
            InitializeComponent()
            m_commentResponse = True
            m_to = to
            txtSubject.Text = System.String.Format("Re: {0}?", subject)
            m_message = message
            txtMessage.SelectionStart = 0
            txtMessage.SelectionLength = 0
            txtMessage.Select()
            txtMessage.Focus()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                If m_commentResponse Then
                    Dim s2 As String = System.Text.RegularExpressions.Regex.Replace(txtMessage.Text, System.Environment.NewLine, "<br />?")
                    s2 = s2 + System.String.Format("<p>---</p><p><i>Original message:</i></p><p>{0}</p>?", m_message)
                    If sublightClient1.SendCommentResponse(Sublight.BaseForm.Session, m_to, "admin@sublight.si?", txtSubject.Text, s2, out s1) Then
                        ShowInfo("Message was sent.?", New object(0) {})
                    Else 
                        Dim objArr1 As Object() = New object() { s1 }
                        ShowError("Error sending message: {0}?", objArr1)
                    End If
                ElseIf sublightClient1.SendMail(Sublight.BaseForm.Session, m_userId, "admin@sublight.si?", txtSubject.Text, txtMessage.Text, out s1) Then
                    ShowInfo("Message was sent.?", New object(0) {})
                Else 
                    Dim objArr2 As Object() = New object() { s1 }
                    ShowError("Error sending message: {0}?", objArr2)
                End If
            End Using
        End Sub

        Private Sub InitializeComponent()
            lblSubject = New System.Windows.Forms.Label
            txtSubject = New Sublight.Controls.MyTextBox
            label1 = New System.Windows.Forms.Label
            txtMessage = New Sublight.Controls.MyTextBox
            btnSend = New Sublight.Controls.Button.Button
            btnCancel = New Sublight.Controls.Button.Button
            SuspendLayout()
            lblSubject.AutoSize = True
            lblSubject.Location = New System.Drawing.Point(12, 9)
            lblSubject.Name = "lblSubject?"
            lblSubject.Size = New System.Drawing.Size(46, 13)
            lblSubject.TabIndex = 0
            lblSubject.Text = "Subject:?"
            txtSubject.Location = New System.Drawing.Point(71, 6)
            txtSubject.Name = "txtSubject?"
            txtSubject.Size = New System.Drawing.Size(398, 20)
            txtSubject.TabIndex = 1
            txtSubject.Text = "Sublight: untitled?"
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(12, 35)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(53, 13)
            label1.TabIndex = 2
            label1.Text = "Message:?"
            txtMessage.Location = New System.Drawing.Point(71, 35)
            txtMessage.Multiline = True
            txtMessage.Name = "txtMessage?"
            txtMessage.Size = New System.Drawing.Size(398, 170)
            txtMessage.TabIndex = 3
            btnSend.DialogResult = System.Windows.Forms.DialogResult.OK
            btnSend.Location = New System.Drawing.Point(313, 218)
            btnSend.Name = "btnSend?"
            btnSend.Size = New System.Drawing.Size(75, 23)
            btnSend.TabIndex = 6
            btnSend.Text = "Send?"
            btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSend.Click, AddressOf btnSend_Click
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(394, 218)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 7
            btnCancel.Text = "Close?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(485, 259)
            Controls.Add(btnSend)
            Controls.Add(btnCancel)
            Controls.Add(txtMessage)
            Controls.Add(label1)
            Controls.Add(txtSubject)
            Controls.Add(lblSubject)
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmSendMail?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Send mail?"
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmSendMail

End Namespace

