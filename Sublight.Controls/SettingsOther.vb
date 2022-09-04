Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class SettingsOther
        Inherits Sublight.Controls.BaseSettings

        Private cbAutoDeleteSubtitles As Sublight.Controls.MyCheckBox 
        Private cbOverwriteSubtitleIfExists As Sublight.Controls.MyCheckBox 
        Private cbSemiAutomaticLinkingEnabled As Sublight.Controls.MyCheckBox 
        Private cbSingleInstance As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.IContainer 
        Private label4 As System.Windows.Forms.Label 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private niceLine2 As Sublight.Controls.NiceLine 
        Private pictureBox2 As System.Windows.Forms.PictureBox 
        Private rbAutoDeleteNewSearchAskForDeletion As Sublight.Controls.MyRadioButton 
        Private rbAutoDeleteNewSearchDelete As Sublight.Controls.MyRadioButton 
        Private rbAutoDeleteNewSearchDoNotDelete As Sublight.Controls.MyRadioButton 
        Private txtSemiAutomaticSearchIgnoreWords As Sublight.Controls.MyTextBox 

        Public Overrides ReadOnly Property Title As String
            Get
                Return Sublight.Translation.Settings_Panel_OtherSettings
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm)
            InitializeComponent()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Private Sub cbAutoDeleteSubtitles_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            rbAutoDeleteNewSearchAskForDeletion.Enabled = cbAutoDeleteSubtitles.Checked
            rbAutoDeleteNewSearchDelete.Enabled = cbAutoDeleteSubtitles.Checked
            rbAutoDeleteNewSearchDoNotDelete.Enabled = cbAutoDeleteSubtitles.Checked
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            MyBase.Translate()
        End Sub

        Private Sub InitializeComponent()
            rbAutoDeleteNewSearchAskForDeletion = New Sublight.Controls.MyRadioButton
            rbAutoDeleteNewSearchDelete = New Sublight.Controls.MyRadioButton
            rbAutoDeleteNewSearchDoNotDelete = New Sublight.Controls.MyRadioButton
            cbAutoDeleteSubtitles = New Sublight.Controls.MyCheckBox
            txtSemiAutomaticSearchIgnoreWords = New Sublight.Controls.MyTextBox
            label4 = New System.Windows.Forms.Label
            niceLine1 = New Sublight.Controls.NiceLine
            niceLine2 = New Sublight.Controls.NiceLine
            cbOverwriteSubtitleIfExists = New Sublight.Controls.MyCheckBox
            cbSingleInstance = New Sublight.Controls.MyCheckBox
            myPanel2 = New Sublight.Controls.MyPanel
            pictureBox2 = New System.Windows.Forms.PictureBox
            cbSemiAutomaticLinkingEnabled = New Sublight.Controls.MyCheckBox
            myPanel2.SuspendLayout()
            pictureBox2.BeginInit()
            SuspendLayout()
            rbAutoDeleteNewSearchAskForDeletion.AutoSize = True
            rbAutoDeleteNewSearchAskForDeletion.Location = New System.Drawing.Point(21, 219)
            rbAutoDeleteNewSearchAskForDeletion.Name = "rbAutoDeleteNewSearchAskForDeletion?"
            rbAutoDeleteNewSearchAskForDeletion.Size = New System.Drawing.Size(209, 17)
            rbAutoDeleteNewSearchAskForDeletion.TabIndex = 19
            rbAutoDeleteNewSearchAskForDeletion.Text = "Ob novem iskanju me vprašaj za akcijo?"
            rbAutoDeleteNewSearchAskForDeletion.UseVisualStyleBackColor = True
            rbAutoDeleteNewSearchDelete.AutoSize = True
            rbAutoDeleteNewSearchDelete.Location = New System.Drawing.Point(21, 196)
            rbAutoDeleteNewSearchDelete.Name = "rbAutoDeleteNewSearchDelete?"
            rbAutoDeleteNewSearchDelete.Size = New System.Drawing.Size(185, 17)
            rbAutoDeleteNewSearchDelete.TabIndex = 18
            rbAutoDeleteNewSearchDelete.Text = "Ob novem iskanju samodejno briši?"
            rbAutoDeleteNewSearchDelete.UseVisualStyleBackColor = True
            rbAutoDeleteNewSearchDoNotDelete.AutoSize = True
            rbAutoDeleteNewSearchDoNotDelete.Checked = True
            rbAutoDeleteNewSearchDoNotDelete.Location = New System.Drawing.Point(21, 173)
            rbAutoDeleteNewSearchDoNotDelete.Name = "rbAutoDeleteNewSearchDoNotDelete?"
            rbAutoDeleteNewSearchDoNotDelete.Size = New System.Drawing.Size(204, 17)
            rbAutoDeleteNewSearchDoNotDelete.TabIndex = 17
            rbAutoDeleteNewSearchDoNotDelete.TabStop = True
            rbAutoDeleteNewSearchDoNotDelete.Text = "Ob novem iskanju podnapisov ne briši?"
            rbAutoDeleteNewSearchDoNotDelete.UseVisualStyleBackColor = True
            cbAutoDeleteSubtitles.AutoSize = True
            cbAutoDeleteSubtitles.Location = New System.Drawing.Point(3, 150)
            cbAutoDeleteSubtitles.Name = "cbAutoDeleteSubtitles?"
            cbAutoDeleteSubtitles.Size = New System.Drawing.Size(231, 17)
            cbAutoDeleteSubtitles.TabIndex = 16
            cbAutoDeleteSubtitles.Text = "Samodejno brisanje prenesenih podnapisov?"
            cbAutoDeleteSubtitles.UseVisualStyleBackColor = True
            AddHandler cbAutoDeleteSubtitles.CheckedChanged, AddressOf cbAutoDeleteSubtitles_CheckedChanged
            txtSemiAutomaticSearchIgnoreWords.EnableDisableColor = True
            txtSemiAutomaticSearchIgnoreWords.Location = New System.Drawing.Point(3, 20)
            txtSemiAutomaticSearchIgnoreWords.Multiline = True
            txtSemiAutomaticSearchIgnoreWords.Name = "txtSemiAutomaticSearchIgnoreWords?"
            txtSemiAutomaticSearchIgnoreWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            txtSemiAutomaticSearchIgnoreWords.Size = New System.Drawing.Size(452, 80)
            txtSemiAutomaticSearchIgnoreWords.TabIndex = 14
            txtSemiAutomaticSearchIgnoreWords.Text = "HDTV DVD XOR AXXO XVID DIVX WS CAPH SEASON EPISODE ENG DVDRIP WS DSR NOTV DIMENSION PROPER R5 PUKKA AC3 MP3?"
            label4.AutoSize = True
            label4.Location = New System.Drawing.Point(0, 4)
            label4.Name = "label4?"
            label4.Size = New System.Drawing.Size(381, 13)
            label4.TabIndex = 13
            label4.Text = "Izpusti naslednje besede pri samodejnem sestavljanju iskalnega niza iz razlicice:?"
            niceLine1.AutoSize = True
            niceLine1.Location = New System.Drawing.Point(3, 106)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(550, 15)
            niceLine1.TabIndex = 20
            niceLine2.AutoSize = True
            niceLine2.Location = New System.Drawing.Point(3, 242)
            niceLine2.Name = "niceLine2?"
            niceLine2.Size = New System.Drawing.Size(550, 15)
            niceLine2.TabIndex = 21
            cbOverwriteSubtitleIfExists.AutoSize = True
            cbOverwriteSubtitleIfExists.Location = New System.Drawing.Point(3, 127)
            cbOverwriteSubtitleIfExists.Name = "cbOverwriteSubtitleIfExists?"
            cbOverwriteSubtitleIfExists.Size = New System.Drawing.Size(158, 17)
            cbOverwriteSubtitleIfExists.TabIndex = 15
            cbOverwriteSubtitleIfExists.Text = "Prepiši podnapis, ce obstaja?"
            cbOverwriteSubtitleIfExists.UseVisualStyleBackColor = True
            cbSingleInstance.AutoSize = True
            cbSingleInstance.Checked = True
            cbSingleInstance.CheckState = System.Windows.Forms.CheckState.Checked
            cbSingleInstance.Location = New System.Drawing.Point(3, 263)
            cbSingleInstance.Name = "cbSingleInstance?"
            cbSingleInstance.Size = New System.Drawing.Size(195, 17)
            cbSingleInstance.TabIndex = 23
            cbSingleInstance.Text = "Dovoli samo eno instanco aplikacije?"
            cbSingleInstance.UseVisualStyleBackColor = True
            myPanel2.Controls.Add(pictureBox2)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Right
            myPanel2.Location = New System.Drawing.Point(715, 0)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(38, 504)
            myPanel2.TabIndex = 139
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox2.Image = Sublight.Properties.Resources.SettingsShell
            pictureBox2.Location = New System.Drawing.Point(0, 0)
            pictureBox2.Name = "pictureBox2?"
            pictureBox2.Size = New System.Drawing.Size(37, 39)
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox2.TabIndex = 24
            pictureBox2.TabStop = False
            cbSemiAutomaticLinkingEnabled.AutoSize = True
            cbSemiAutomaticLinkingEnabled.Checked = True
            cbSemiAutomaticLinkingEnabled.CheckState = System.Windows.Forms.CheckState.Checked
            cbSemiAutomaticLinkingEnabled.Location = New System.Drawing.Point(3, 286)
            cbSemiAutomaticLinkingEnabled.Name = "cbSemiAutomaticLinkingEnabled?"
            cbSemiAutomaticLinkingEnabled.Size = New System.Drawing.Size(244, 17)
            cbSemiAutomaticLinkingEnabled.TabIndex = 140
            cbSemiAutomaticLinkingEnabled.Text = "Omogoci samodejno povezovanje podnapisov?"
            cbSemiAutomaticLinkingEnabled.UseVisualStyleBackColor = True
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(cbSemiAutomaticLinkingEnabled)
            Controls.Add(myPanel2)
            Controls.Add(cbSingleInstance)
            Controls.Add(cbOverwriteSubtitleIfExists)
            Controls.Add(niceLine2)
            Controls.Add(niceLine1)
            Controls.Add(rbAutoDeleteNewSearchAskForDeletion)
            Controls.Add(rbAutoDeleteNewSearchDelete)
            Controls.Add(rbAutoDeleteNewSearchDoNotDelete)
            Controls.Add(cbAutoDeleteSubtitles)
            Controls.Add(txtSemiAutomaticSearchIgnoreWords)
            Controls.Add(label4)
            Name = "SettingsOther?"
            Size = New System.Drawing.Size(753, 504)
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            pictureBox2.EndInit()
            ResumeLayout(False)
            PerformLayout()
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
                txtSemiAutomaticSearchIgnoreWords.Text = Sublight.Properties.Settings.Default.SemiAutomaticSearchIgnoreWords
                cbAutoDeleteSubtitles.Checked = Sublight.Properties.Settings.Default.AutoDelete
                If Sublight.Properties.Settings.Default.AutoDeleteOnNewSearch = Sublight.Types.AutoDeleteOnNewSearch.AskForAction Then
                    rbAutoDeleteNewSearchAskForDeletion.Checked = True
                ElseIf Sublight.Properties.Settings.Default.AutoDeleteOnNewSearch = Sublight.Types.AutoDeleteOnNewSearch.Automatic Then
                    rbAutoDeleteNewSearchDelete.Checked = True
                ElseIf Sublight.Properties.Settings.Default.AutoDeleteOnNewSearch = Sublight.Types.AutoDeleteOnNewSearch.DoNotDelete Then
                    rbAutoDeleteNewSearchDoNotDelete.Checked = True
                End If
                cbAutoDeleteSubtitles_CheckedChanged(Me, Nothing)
                cbOverwriteSubtitleIfExists.Checked = Sublight.Properties.Settings.Default.OverwriteSubtitleIfExists
                cbSingleInstance.Checked = Sublight.Properties.Settings.Default.SingleInstanceApplication
                cbSemiAutomaticLinkingEnabled.Checked = Sublight.Properties.Settings.Default.SemiAutomaticHashingEnabled
                error = Nothing
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            niceLine1.Width = Width - (2 * niceLine1.Left)
            niceLine2.Width = Width - (2 * niceLine2.Left)
        End Sub

        Public Overrides Function SaveSettings(ByVal quietMode As Boolean, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                Sublight.Properties.Settings.Default.SemiAutomaticSearchIgnoreWords = txtSemiAutomaticSearchIgnoreWords.Text
                Sublight.Properties.Settings.Default.AutoDelete = cbAutoDeleteSubtitles.Checked
                If rbAutoDeleteNewSearchAskForDeletion.Checked Then
                    Sublight.Properties.Settings.Default.AutoDeleteOnNewSearch = Sublight.Types.AutoDeleteOnNewSearch.AskForAction
                ElseIf rbAutoDeleteNewSearchDelete.Checked Then
                    Sublight.Properties.Settings.Default.AutoDeleteOnNewSearch = Sublight.Types.AutoDeleteOnNewSearch.Automatic
                ElseIf rbAutoDeleteNewSearchDoNotDelete.Checked Then
                    Sublight.Properties.Settings.Default.AutoDeleteOnNewSearch = Sublight.Types.AutoDeleteOnNewSearch.DoNotDelete
                End If
                Sublight.Properties.Settings.Default.OverwriteSubtitleIfExists = cbOverwriteSubtitleIfExists.Checked
                Sublight.Properties.Settings.Default.SingleInstanceApplication = cbSingleInstance.Checked
                Sublight.Properties.Settings.Default.SemiAutomaticHashingEnabled = cbSemiAutomaticLinkingEnabled.Checked
                error = Nothing
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub Translate()
            MyBase.Translate()
            label4.Text = Sublight.Translation.Settings_Panel_OtherSettings_AutoFillTitle_IgnoreWords
            cbAutoDeleteSubtitles.Text = Sublight.Translation.Settings_Panel_OtherSettings_AutoDeleteDownloadedSubtitles
            rbAutoDeleteNewSearchDoNotDelete.Text = Sublight.Translation.Settings_Panel_OtherSettings_DoNotAutoDelete
            rbAutoDeleteNewSearchDelete.Text = Sublight.Translation.Settings_Panel_OtherSettings_AutoDelete
            rbAutoDeleteNewSearchAskForDeletion.Text = Sublight.Translation.Settings_Panel_OtherSettings_AskForAction
            cbOverwriteSubtitleIfExists.Text = Sublight.Translation.Settings_Panel_OtherSettings_OverwriteSubtitleIfExists
            cbSingleInstance.Text = Sublight.Translation.Settings_Panel_OtherSettings_SingleInstanceApplication
            cbSemiAutomaticLinkingEnabled.Text = Sublight.Translation.Settings_Panel_OtherSettings_AutomaticLinkingEnabled
        End Sub

    End Class ' class SettingsOther

End Namespace

