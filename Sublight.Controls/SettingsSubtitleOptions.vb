Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class SettingsSubtitleOptions
        Inherits Sublight.Controls.BaseSettings

        Private cbRemoveFormatting As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.IContainer 
        Private gbSubtitleEncoding As Sublight.Controls.MyGroupBox 
        Private gbSubtitleFormatting As Sublight.Controls.MyGroupBox 
        Private lblNote As System.Windows.Forms.Label 
        Private lblSubtitle As System.Windows.Forms.Label 
        Private lblSubtitlePreserveFormatting As System.Windows.Forms.Label 
        Private lblSubtitleRemoveFormatting As System.Windows.Forms.Label 
        Private myPanel1 As Sublight.Controls.MyPanel 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private myPanel3 As Sublight.Controls.MyPanel 
        Private panel1 As Sublight.Controls.Panel 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private pictureBox2 As System.Windows.Forms.PictureBox 
        Private rbEncodingANSI As Sublight.Controls.MyRadioButton 
        Private rbEncodingCodePage As Sublight.Controls.MyRadioButton 
        Private rbEncodingUnicode As Sublight.Controls.MyRadioButton 
        Private rbEncodingUTF8 As Sublight.Controls.MyRadioButton 
        Private txtEncodingCodePage As Sublight.Controls.MyTextBox 

        Public Overrides ReadOnly Property Title As String
            Get
                Return Sublight.Translation.Settings_Panel_OtherSettings_SubtitleOptions
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm)
            InitializeComponent()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Private Sub cbRemoveFormatting_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If cbRemoveFormatting.Checked Then
                lblSubtitleRemoveFormatting.Visible = True
                lblSubtitlePreserveFormatting.Visible = False
                Return
            End If
            lblSubtitleRemoveFormatting.Visible = False
            lblSubtitlePreserveFormatting.Visible = True
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            MyBase.Translate()
        End Sub

        Private Sub InitializeComponent()
            myPanel2 = New Sublight.Controls.MyPanel
            pictureBox2 = New System.Windows.Forms.PictureBox
            panel1 = New Sublight.Controls.Panel
            gbSubtitleEncoding = New Sublight.Controls.MyGroupBox
            rbEncodingUnicode = New Sublight.Controls.MyRadioButton
            rbEncodingUTF8 = New Sublight.Controls.MyRadioButton
            txtEncodingCodePage = New Sublight.Controls.MyTextBox
            rbEncodingCodePage = New Sublight.Controls.MyRadioButton
            rbEncodingANSI = New Sublight.Controls.MyRadioButton
            myPanel3 = New Sublight.Controls.MyPanel
            gbSubtitleFormatting = New Sublight.Controls.MyGroupBox
            myPanel1 = New Sublight.Controls.MyPanel
            pictureBox1 = New System.Windows.Forms.PictureBox
            lblSubtitlePreserveFormatting = New System.Windows.Forms.Label
            lblSubtitleRemoveFormatting = New System.Windows.Forms.Label
            lblSubtitle = New System.Windows.Forms.Label
            cbRemoveFormatting = New Sublight.Controls.MyCheckBox
            lblNote = New System.Windows.Forms.Label
            myPanel2.SuspendLayout()
            pictureBox2.BeginInit()
            gbSubtitleEncoding.SuspendLayout()
            gbSubtitleFormatting.SuspendLayout()
            myPanel1.SuspendLayout()
            pictureBox1.BeginInit()
            SuspendLayout()
            myPanel2.Controls.Add(pictureBox2)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Right
            myPanel2.Location = New System.Drawing.Point(786, 0)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(38, 553)
            myPanel2.TabIndex = 140
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox2.Image = Sublight.Properties.Resources.SettingsShell
            pictureBox2.Location = New System.Drawing.Point(0, 0)
            pictureBox2.Name = "pictureBox2?"
            pictureBox2.Size = New System.Drawing.Size(37, 39)
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox2.TabIndex = 24
            pictureBox2.TabStop = False
            panel1.Dock = System.Windows.Forms.DockStyle.Right
            panel1.Location = New System.Drawing.Point(774, 0)
            panel1.Name = "panel1?"
            panel1.Size = New System.Drawing.Size(12, 553)
            panel1.TabIndex = 144
            gbSubtitleEncoding.Controls.Add(rbEncodingUnicode)
            gbSubtitleEncoding.Controls.Add(rbEncodingUTF8)
            gbSubtitleEncoding.Controls.Add(txtEncodingCodePage)
            gbSubtitleEncoding.Controls.Add(rbEncodingCodePage)
            gbSubtitleEncoding.Controls.Add(rbEncodingANSI)
            gbSubtitleEncoding.Dock = System.Windows.Forms.DockStyle.Top
            gbSubtitleEncoding.DrawTextBackground = True
            gbSubtitleEncoding.Location = New System.Drawing.Point(0, 0)
            gbSubtitleEncoding.Name = "gbSubtitleEncoding?"
            gbSubtitleEncoding.Size = New System.Drawing.Size(774, 121)
            gbSubtitleEncoding.TabIndex = 145
            gbSubtitleEncoding.TabStop = False
            gbSubtitleEncoding.Text = "Kodiranje datotek?"
            rbEncodingUnicode.AutoSize = True
            rbEncodingUnicode.Location = New System.Drawing.Point(6, 91)
            rbEncodingUnicode.Name = "rbEncodingUnicode?"
            rbEncodingUnicode.Size = New System.Drawing.Size(65, 17)
            rbEncodingUnicode.TabIndex = 22
            rbEncodingUnicode.Text = "Unicode?"
            rbEncodingUnicode.UseVisualStyleBackColor = True
            rbEncodingUTF8.AutoSize = True
            rbEncodingUTF8.Location = New System.Drawing.Point(6, 68)
            rbEncodingUTF8.Name = "rbEncodingUTF8?"
            rbEncodingUTF8.Size = New System.Drawing.Size(55, 17)
            rbEncodingUTF8.TabIndex = 21
            rbEncodingUTF8.Text = "UTF-8?"
            rbEncodingUTF8.UseVisualStyleBackColor = True
            txtEncodingCodePage.Enabled = False
            txtEncodingCodePage.EnableDisableColor = True
            txtEncodingCodePage.Location = New System.Drawing.Point(92, 45)
            txtEncodingCodePage.Name = "txtEncodingCodePage?"
            txtEncodingCodePage.Size = New System.Drawing.Size(46, 20)
            txtEncodingCodePage.TabIndex = 20
            txtEncodingCodePage.Text = "1250?"
            rbEncodingCodePage.AutoSize = True
            rbEncodingCodePage.Location = New System.Drawing.Point(6, 45)
            rbEncodingCodePage.Name = "rbEncodingCodePage?"
            rbEncodingCodePage.Size = New System.Drawing.Size(80, 17)
            rbEncodingCodePage.TabIndex = 19
            rbEncodingCodePage.Text = "Code page:?"
            rbEncodingCodePage.UseVisualStyleBackColor = True
            AddHandler rbEncodingCodePage.CheckedChanged, AddressOf rbEncodingCodePage_CheckedChanged
            rbEncodingANSI.AutoSize = True
            rbEncodingANSI.Checked = True
            rbEncodingANSI.Location = New System.Drawing.Point(6, 22)
            rbEncodingANSI.Name = "rbEncodingANSI?"
            rbEncodingANSI.Size = New System.Drawing.Size(50, 17)
            rbEncodingANSI.TabIndex = 18
            rbEncodingANSI.TabStop = True
            rbEncodingANSI.Text = "ANSI?"
            rbEncodingANSI.UseVisualStyleBackColor = True
            myPanel3.Dock = System.Windows.Forms.DockStyle.Top
            myPanel3.Location = New System.Drawing.Point(0, 121)
            myPanel3.Name = "myPanel3?"
            myPanel3.Size = New System.Drawing.Size(774, 5)
            myPanel3.TabIndex = 147
            gbSubtitleFormatting.Controls.Add(myPanel1)
            gbSubtitleFormatting.Controls.Add(cbRemoveFormatting)
            gbSubtitleFormatting.Dock = System.Windows.Forms.DockStyle.Top
            gbSubtitleFormatting.DrawTextBackground = True
            gbSubtitleFormatting.Location = New System.Drawing.Point(0, 126)
            gbSubtitleFormatting.Name = "gbSubtitleFormatting?"
            gbSubtitleFormatting.Size = New System.Drawing.Size(774, 94)
            gbSubtitleFormatting.TabIndex = 148
            gbSubtitleFormatting.TabStop = False
            gbSubtitleFormatting.Text = "Oblikovanje podnapisov?"
            myPanel1.Controls.Add(pictureBox1)
            myPanel1.Controls.Add(lblSubtitlePreserveFormatting)
            myPanel1.Controls.Add(lblSubtitleRemoveFormatting)
            myPanel1.Controls.Add(lblSubtitle)
            myPanel1.Location = New System.Drawing.Point(6, 55)
            myPanel1.Name = "myPanel1?"
            myPanel1.Size = New System.Drawing.Size(382, 30)
            myPanel1.TabIndex = 6
            pictureBox1.Image = Sublight.Properties.Resources.ArrowRight
            pictureBox1.Location = New System.Drawing.Point(163, 5)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(45, 15)
            pictureBox1.TabIndex = 8
            pictureBox1.TabStop = False
            lblSubtitlePreserveFormatting.BackColor = System.Drawing.Color.Black
            lblSubtitlePreserveFormatting.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 238)
            lblSubtitlePreserveFormatting.ForeColor = System.Drawing.Color.White
            lblSubtitlePreserveFormatting.Location = New System.Drawing.Point(214, 0)
            lblSubtitlePreserveFormatting.Name = "lblSubtitlePreserveFormatting?"
            lblSubtitlePreserveFormatting.Size = New System.Drawing.Size(157, 23)
            lblSubtitlePreserveFormatting.TabIndex = 7
            lblSubtitlePreserveFormatting.Text = "Sample text?"
            lblSubtitlePreserveFormatting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            lblSubtitleRemoveFormatting.BackColor = System.Drawing.Color.Black
            lblSubtitleRemoveFormatting.ForeColor = System.Drawing.Color.White
            lblSubtitleRemoveFormatting.Location = New System.Drawing.Point(214, 0)
            lblSubtitleRemoveFormatting.Name = "lblSubtitleRemoveFormatting?"
            lblSubtitleRemoveFormatting.Size = New System.Drawing.Size(157, 23)
            lblSubtitleRemoveFormatting.TabIndex = 4
            lblSubtitleRemoveFormatting.Text = "Sample text?"
            lblSubtitleRemoveFormatting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            lblSubtitle.BackColor = System.Drawing.Color.Black
            lblSubtitle.ForeColor = System.Drawing.Color.White
            lblSubtitle.Location = New System.Drawing.Point(0, 0)
            lblSubtitle.Name = "lblSubtitle?"
            lblSubtitle.Size = New System.Drawing.Size(157, 23)
            lblSubtitle.TabIndex = 3
            lblSubtitle.Text = "<i>Sample text</i>?"
            lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            cbRemoveFormatting.AutoSize = True
            cbRemoveFormatting.Location = New System.Drawing.Point(6, 22)
            cbRemoveFormatting.Name = "cbRemoveFormatting?"
            cbRemoveFormatting.Size = New System.Drawing.Size(180, 17)
            cbRemoveFormatting.TabIndex = 0
            cbRemoveFormatting.Text = "Odstrani oblikovanje podnapisov?"
            cbRemoveFormatting.UseVisualStyleBackColor = True
            AddHandler cbRemoveFormatting.CheckedChanged, AddressOf cbRemoveFormatting_CheckedChanged
            lblNote.Dock = System.Windows.Forms.DockStyle.Top
            lblNote.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblNote.Location = New System.Drawing.Point(0, 220)
            lblNote.Name = "lblNote?"
            lblNote.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
            lblNote.Size = New System.Drawing.Size(774, 24)
            lblNote.TabIndex = 195
            lblNote.Text = "Opomba: velja samo za podnapise iz primarnega vira?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(lblNote)
            Controls.Add(gbSubtitleFormatting)
            Controls.Add(myPanel3)
            Controls.Add(gbSubtitleEncoding)
            Controls.Add(panel1)
            Controls.Add(myPanel2)
            Name = "SettingsSubtitleOptions?"
            Size = New System.Drawing.Size(824, 553)
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            pictureBox2.EndInit()
            gbSubtitleEncoding.ResumeLayout(False)
            gbSubtitleEncoding.PerformLayout()
            gbSubtitleFormatting.ResumeLayout(False)
            gbSubtitleFormatting.PerformLayout()
            myPanel1.ResumeLayout(False)
            pictureBox1.EndInit()
            ResumeLayout(False)
        End Sub

        Private Sub rbEncodingCodePage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            txtEncodingCodePage.Enabled = rbEncodingCodePage.Checked
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Function LoadSettings(ByRef error As String) As Boolean
            Dim flag1 As Boolean

            Try
                If Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.ANSI Then
                    rbEncodingANSI.Checked = True
                ElseIf Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.CustomCodePage Then
                    rbEncodingCodePage.Checked = True
                ElseIf Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.UTF8 Then
                    rbEncodingUTF8.Checked = True
                ElseIf Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.Unicode Then
                    rbEncodingUnicode.Checked = True
                End If
                Dim i1 As Integer = Sublight.Properties.Settings.Default.SubtitleEncoding_Custom
                txtEncodingCodePage.Text = i1.ToString()
                cbRemoveFormatting.Checked = Sublight.Properties.Settings.Default.SubtitleFormatting_Remove
                error = Nothing
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Function SaveSettings(ByVal quietMode As Boolean, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                Try
                    Dim i1 As Integer = System.Int32.Parse(txtEncodingCodePage.Text)
                    System.Text.Encoding.GetEncoding(i1)
                    Sublight.Properties.Settings.Default.SubtitleEncoding_Custom = i1
                Catch 
                    Sublight.Properties.Settings.Default.SubtitleEncoding_Custom = 1250
                End Try
                If rbEncodingANSI.Checked Then
                    Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.ANSI
                ElseIf rbEncodingCodePage.Checked Then
                    Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.CustomCodePage
                ElseIf rbEncodingUTF8.Checked Then
                    Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.UTF8
                ElseIf rbEncodingUnicode.Checked Then
                    Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.Unicode
                End If
                Sublight.Properties.Settings.Default.SubtitleFormatting_Remove = cbRemoveFormatting.Checked
                error = Nothing
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub Translate()
            gbSubtitleEncoding.Text = Sublight.Translation.Settings_Panel_OtherSettings_SubtitleEncoding
            gbSubtitleFormatting.Text = Sublight.Translation.Settings_Panel_OtherSettings_SubtitleOptions_SubtitleFormatting
            cbRemoveFormatting.Text = Sublight.Translation.Settings_Panel_OtherSettings_SubtitleOptions_RemoveSubtitleFormatting
            lblNote.Text = Sublight.Translation.Settings_Panel_OtherSettings_SubtitleOptions_Note
        End Sub

    End Class ' class SettingsSubtitleOptions

End Namespace

