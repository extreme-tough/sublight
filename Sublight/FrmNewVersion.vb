Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.WS_SublightClient

Namespace Sublight

    Public NotInheritable Class FrmNewVersion
        Inherits Sublight.BaseForm

        Private ReadOnly _newVersionInfo As Sublight.WS_SublightClient.VersionInfo 
        Private ReadOnly m_newVersion As String 

        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnUpdateNow As Sublight.Controls.Button.Button 
        Private cbDoNotDisplayForThisVersion As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private lblMandatoryVersionAvailable As System.Windows.Forms.Label 
        Private lblWhatIsNew As System.Windows.Forms.Label 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private txtWhatIsNew As Sublight.Controls.MyTextBox 

        Public Sub New(ByVal newVersion As String, ByVal newVersionInfo As Sublight.WS_SublightClient.VersionInfo)
            InitializeComponent()
            m_newVersion = newVersion
            _newVersionInfo = newVersionInfo
            btnCancel.Text = Sublight.Translation.Common_Button_Close
            label1.Text = System.String.Format(Sublight.Translation.Update_Question_NewVersionIsAvailable, newVersion)
            Text = Sublight.Translation.Update_Question_NewVersionIsAvailable_Title
            btnUpdateNow.Text = Sublight.Translation.Update_Question_Button_UpdateNow
            lblWhatIsNew.Text = Sublight.Translation.Update_Question_Field_WhatIsNew
            cbDoNotDisplayForThisVersion.Text = Sublight.Translation.Update_DoNotDisplayForThisVersion
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.No
            If cbDoNotDisplayForThisVersion.Checked Then
                Sublight.Properties.Settings.Default.AutoUpdate_Notification_Ignore = m_newVersion
                Sublight.BaseForm.SaveUserSettingsSilent()
            End If
            Close()
        End Sub

        Private Sub btnUpdateNow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Sublight.MyUtility.UpdateChecker.OpenInBrowser(Me)
            DialogResult = System.Windows.Forms.DialogResult.Yes
            Close()
        End Sub

        Private Sub FrmNewVersion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub FrmNewVersion_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            If System.String.IsNullOrEmpty(m_newVersion) OrElse (m_newVersion.Trim().Length <= 0) OrElse ((_newVersionInfo) Is Nothing) Then
                Close()
                Return
            End If
            If _newVersionInfo.IsUpgradeMandatory Then
                cbDoNotDisplayForThisVersion.Visible = False
                lblMandatoryVersionAvailable.Text = Sublight.Translation.Update_NewMandatoryVersionAvailable
                lblMandatoryVersionAvailable.Visible = True
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sArr1 As String() = _newVersionInfo.Changes
            Dim i1 As Integer = 0
            While i1 < sArr1.Length
                Dim s1 As String = sArr1(i1)
                stringBuilder1.AppendFormat("• {0}?", s1)
                stringBuilder1.AppendLine()
                i1 = i1 + 1
            End While
            txtWhatIsNew.Text = stringBuilder1.ToString()
        End Sub

        Private Sub InitializeComponent()
            label1 = New System.Windows.Forms.Label
            btnUpdateNow = New Sublight.Controls.Button.Button
            pictureBox1 = New System.Windows.Forms.PictureBox
            btnCancel = New Sublight.Controls.Button.Button
            lblWhatIsNew = New System.Windows.Forms.Label
            txtWhatIsNew = New Sublight.Controls.MyTextBox
            cbDoNotDisplayForThisVersion = New Sublight.Controls.MyCheckBox
            lblMandatoryVersionAvailable = New System.Windows.Forms.Label
            pictureBox1.BeginInit()
            SuspendLayout()
            label1.Location = New System.Drawing.Point(50, 12)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(346, 32)
            label1.TabIndex = 1
            label1.Text = "Na voljo je nova verzija (0.9.3). Zacnem s prenosom??"
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnUpdateNow.AutoResize = False
            btnUpdateNow.DialogResult = System.Windows.Forms.DialogResult.None
            btnUpdateNow.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            btnUpdateNow.Location = New System.Drawing.Point(275, 199)
            btnUpdateNow.Name = "btnUpdateNow?"
            btnUpdateNow.Size = New System.Drawing.Size(121, 23)
            btnUpdateNow.TabIndex = 2
            btnUpdateNow.Text = "Posodobi zdaj?"
            btnUpdateNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnUpdateNow.Click, AddressOf btnUpdateNow_Click
            pictureBox1.Image = Sublight.Properties.Resources.UpdateIcon
            pictureBox1.Location = New System.Drawing.Point(12, 12)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(32, 32)
            pictureBox1.TabIndex = 0
            pictureBox1.TabStop = False
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.None
            btnCancel.Location = New System.Drawing.Point(194, 199)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 3
            btnCancel.Text = "Zapri?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            lblWhatIsNew.AutoSize = True
            lblWhatIsNew.Location = New System.Drawing.Point(12, 59)
            lblWhatIsNew.Name = "lblWhatIsNew?"
            lblWhatIsNew.Size = New System.Drawing.Size(179, 13)
            lblWhatIsNew.TabIndex = 4
            lblWhatIsNew.Text = "Novosti (na voljo samo v anglešcini):?"
            txtWhatIsNew.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtWhatIsNew.EnableDisableColor = True
            txtWhatIsNew.Location = New System.Drawing.Point(15, 75)
            txtWhatIsNew.Multiline = True
            txtWhatIsNew.Name = "txtWhatIsNew?"
            txtWhatIsNew.ReadOnly = True
            txtWhatIsNew.ScrollBars = System.Windows.Forms.ScrollBars.Both
            txtWhatIsNew.Size = New System.Drawing.Size(381, 110)
            txtWhatIsNew.TabIndex = 5
            txtWhatIsNew.TabStop = False
            txtWhatIsNew.WordWrap = False
            cbDoNotDisplayForThisVersion.AutoSize = True
            cbDoNotDisplayForThisVersion.Location = New System.Drawing.Point(15, 203)
            cbDoNotDisplayForThisVersion.Name = "cbDoNotDisplayForThisVersion?"
            cbDoNotDisplayForThisVersion.Size = New System.Drawing.Size(159, 17)
            cbDoNotDisplayForThisVersion.TabIndex = 6
            cbDoNotDisplayForThisVersion.Text = "Ne prikazuj vec za to verzijo?"
            cbDoNotDisplayForThisVersion.UseVisualStyleBackColor = True
            lblMandatoryVersionAvailable.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            lblMandatoryVersionAvailable.Location = New System.Drawing.Point(12, 194)
            lblMandatoryVersionAvailable.Name = "lblMandatoryVersionAvailable?"
            lblMandatoryVersionAvailable.Size = New System.Drawing.Size(176, 32)
            lblMandatoryVersionAvailable.TabIndex = 7
            lblMandatoryVersionAvailable.Text = "Please upgrade as soon as possible?"
            lblMandatoryVersionAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            lblMandatoryVersionAvailable.Visible = False
            AcceptButton = btnUpdateNow
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(408, 236)
            Controls.Add(cbDoNotDisplayForThisVersion)
            Controls.Add(txtWhatIsNew)
            Controls.Add(lblWhatIsNew)
            Controls.Add(btnCancel)
            Controls.Add(btnUpdateNow)
            Controls.Add(label1)
            Controls.Add(pictureBox1)
            Controls.Add(lblMandatoryVersionAvailable)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            KeyPreview = True
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmNewVersion?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Na voljo je nova verzija?"
            AddHandler Load, AddressOf FrmNewVersion_Load
            AddHandler KeyUp, AddressOf FrmNewVersion_KeyUp
            pictureBox1.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmNewVersion

End Namespace

