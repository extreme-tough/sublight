Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class SettingsSubtitleDownloadFolder
        Inherits Sublight.Controls.BaseSettings

        Private btnClearAutoDownloadFolder As Sublight.Controls.Button.Button 
        Private btnSelectDownloadsFolder As Sublight.Controls.Button.Button 
        Private btnSelectDownloadsFolderS As Sublight.Controls.Button.Button 
        Private cbFileNamingAppendLangId As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.IContainer 
        Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog 
        Private lblAutoDownloadFolderFiles As System.Windows.Forms.Label 
        Private lblAutoDownloadFolderLocation As System.Windows.Forms.Label 
        Private myGroupBox1 As Sublight.Controls.MyGroupBox 
        Private myGroupBox2 As Sublight.Controls.MyGroupBox 
        Private myGroupBox3 As Sublight.Controls.MyGroupBox 
        Private myGroupBox4 As Sublight.Controls.MyGroupBox 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private pictureBox2 As System.Windows.Forms.PictureBox 
        Private rbAutoDownloadFolder As Sublight.Controls.MyRadioButton 
        Private rbAutoDownloadFolderS As Sublight.Controls.MyRadioButton 
        Private rbDownloadsManual As Sublight.Controls.MyRadioButton 
        Private rbDownloadsManualS As Sublight.Controls.MyRadioButton 
        Private rbDownloadsPredefined As Sublight.Controls.MyRadioButton 
        Private rbDownloadsPredefinedS As Sublight.Controls.MyRadioButton 
        Private rbDownloadsVideo As Sublight.Controls.MyRadioButton 
        Private rbDownloadsVideoS As Sublight.Controls.MyRadioButton 
        Private txtAutoDownloadFolder As Sublight.Controls.MyTextBox 
        Private txtAutoDownloadFolderFiles As Sublight.Controls.MyTextBox 
        Private txtDownloadsFolder As Sublight.Controls.MyTextBox 
        Private txtDownloadsFolderS As Sublight.Controls.MyTextBox 

        Public Overrides ReadOnly Property Title As String
            Get
                Return Sublight.Translation.Settings_Panel_DownloadFolder
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm)
            InitializeComponent()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            txtAutoDownloadFolder.Text = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Sublight.Globals.AutoDownloadLocation)
        End Sub

        Private Sub btnClearAutoDownloadFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Sublight.Globals.AutoDownloadLocation)
            If System.IO.Directory.Exists(s1) Then
                Dim sArr1 As String() = System.IO.Directory.GetFiles(s1)
                If Not (sArr1) Is Nothing Then
                    Dim sArr2 As String() = sArr1
                    Dim i1 As Integer = 0
                    While i1 < sArr2.Length
                        Dim s2 As String = sArr2(i1)
                        Try
                            System.IO.File.Delete(s2)
                        Catch 
                        End Try
                        i1 = i1 + 1
                    End While
                End If
            End If
            SetAutoDownloadFolderFilesCount()
        End Sub

        Private Sub btnSelectDownloadsFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            folderBrowserDialog1.Description = Sublight.Translation.Dialog_SaveSubtitleToFolder_Description
            If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                txtDownloadsFolder.Text = folderBrowserDialog1.SelectedPath
                rbDownloadsPredefined.Checked = True
            End If
        End Sub

        Private Sub btnSelectDownloadsFolderS_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            folderBrowserDialog1.Description = Sublight.Translation.Dialog_SaveSubtitleToFolder_Description
            If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                txtDownloadsFolderS.Text = folderBrowserDialog1.SelectedPath
                rbDownloadsPredefinedS.Checked = True
            End If
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            MyBase.Translate()
        End Sub

        Private Sub InitializeComponent()
            folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
            myGroupBox1 = New Sublight.Controls.MyGroupBox
            rbAutoDownloadFolder = New Sublight.Controls.MyRadioButton
            btnSelectDownloadsFolder = New Sublight.Controls.Button.Button
            txtDownloadsFolder = New Sublight.Controls.MyTextBox
            rbDownloadsPredefined = New Sublight.Controls.MyRadioButton
            rbDownloadsVideo = New Sublight.Controls.MyRadioButton
            rbDownloadsManual = New Sublight.Controls.MyRadioButton
            myGroupBox2 = New Sublight.Controls.MyGroupBox
            rbAutoDownloadFolderS = New Sublight.Controls.MyRadioButton
            btnSelectDownloadsFolderS = New Sublight.Controls.Button.Button
            txtDownloadsFolderS = New Sublight.Controls.MyTextBox
            rbDownloadsPredefinedS = New Sublight.Controls.MyRadioButton
            rbDownloadsVideoS = New Sublight.Controls.MyRadioButton
            rbDownloadsManualS = New Sublight.Controls.MyRadioButton
            myGroupBox3 = New Sublight.Controls.MyGroupBox
            btnClearAutoDownloadFolder = New Sublight.Controls.Button.Button
            txtAutoDownloadFolderFiles = New Sublight.Controls.MyTextBox
            lblAutoDownloadFolderFiles = New System.Windows.Forms.Label
            txtAutoDownloadFolder = New Sublight.Controls.MyTextBox
            lblAutoDownloadFolderLocation = New System.Windows.Forms.Label
            myPanel2 = New Sublight.Controls.MyPanel
            pictureBox2 = New System.Windows.Forms.PictureBox
            myGroupBox4 = New Sublight.Controls.MyGroupBox
            cbFileNamingAppendLangId = New Sublight.Controls.MyCheckBox
            myGroupBox1.SuspendLayout()
            myGroupBox2.SuspendLayout()
            myGroupBox3.SuspendLayout()
            myPanel2.SuspendLayout()
            pictureBox2.BeginInit()
            myGroupBox4.SuspendLayout()
            SuspendLayout()
            myGroupBox1.Controls.Add(rbAutoDownloadFolder)
            myGroupBox1.Controls.Add(btnSelectDownloadsFolder)
            myGroupBox1.Controls.Add(txtDownloadsFolder)
            myGroupBox1.Controls.Add(rbDownloadsPredefined)
            myGroupBox1.Controls.Add(rbDownloadsVideo)
            myGroupBox1.Controls.Add(rbDownloadsManual)
            myGroupBox1.DrawTextBackground = True
            myGroupBox1.Location = New System.Drawing.Point(0, 0)
            myGroupBox1.Name = "myGroupBox1?"
            myGroupBox1.Size = New System.Drawing.Size(595, 116)
            myGroupBox1.TabIndex = 23
            myGroupBox1.TabStop = False
            myGroupBox1.Text = "Primarna lokacija?"
            rbAutoDownloadFolder.AutoSize = True
            rbAutoDownloadFolder.Location = New System.Drawing.Point(6, 88)
            rbAutoDownloadFolder.Name = "rbAutoDownloadFolder?"
            rbAutoDownloadFolder.Size = New System.Drawing.Size(78, 17)
            rbAutoDownloadFolder.TabIndex = 26
            rbAutoDownloadFolder.Text = "Samodejno?"
            rbAutoDownloadFolder.UseVisualStyleBackColor = True
            btnSelectDownloadsFolder.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelectDownloadsFolder.Location = New System.Drawing.Point(506, 62)
            btnSelectDownloadsFolder.Name = "btnSelectDownloadsFolder?"
            btnSelectDownloadsFolder.Size = New System.Drawing.Size(75, 23)
            btnSelectDownloadsFolder.TabIndex = 25
            btnSelectDownloadsFolder.Text = "Izberi...?"
            btnSelectDownloadsFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelectDownloadsFolder.Click, AddressOf btnSelectDownloadsFolder_Click
            txtDownloadsFolder.AllowDrop = True
            txtDownloadsFolder.EnableDisableColor = True
            txtDownloadsFolder.Location = New System.Drawing.Point(149, 64)
            txtDownloadsFolder.Name = "txtDownloadsFolder?"
            txtDownloadsFolder.Size = New System.Drawing.Size(351, 20)
            txtDownloadsFolder.TabIndex = 24
            rbDownloadsPredefined.AutoSize = True
            rbDownloadsPredefined.Location = New System.Drawing.Point(6, 65)
            rbDownloadsPredefined.Name = "rbDownloadsPredefined?"
            rbDownloadsPredefined.Size = New System.Drawing.Size(98, 17)
            rbDownloadsPredefined.TabIndex = 23
            rbDownloadsPredefined.Text = "Mapa na disku:?"
            rbDownloadsPredefined.UseVisualStyleBackColor = True
            rbDownloadsVideo.AutoSize = True
            rbDownloadsVideo.Location = New System.Drawing.Point(6, 42)
            rbDownloadsVideo.Name = "rbDownloadsVideo?"
            rbDownloadsVideo.Size = New System.Drawing.Size(134, 17)
            rbDownloadsVideo.TabIndex = 22
            rbDownloadsVideo.Text = "Mapa z video datoteko?"
            rbDownloadsVideo.UseVisualStyleBackColor = True
            rbDownloadsManual.AutoSize = True
            rbDownloadsManual.Checked = True
            rbDownloadsManual.Location = New System.Drawing.Point(6, 19)
            rbDownloadsManual.Name = "rbDownloadsManual?"
            rbDownloadsManual.Size = New System.Drawing.Size(137, 17)
            rbDownloadsManual.TabIndex = 21
            rbDownloadsManual.TabStop = True
            rbDownloadsManual.Text = "Vedno doloci uporabnik?"
            rbDownloadsManual.UseVisualStyleBackColor = True
            myGroupBox2.Controls.Add(rbAutoDownloadFolderS)
            myGroupBox2.Controls.Add(btnSelectDownloadsFolderS)
            myGroupBox2.Controls.Add(txtDownloadsFolderS)
            myGroupBox2.Controls.Add(rbDownloadsPredefinedS)
            myGroupBox2.Controls.Add(rbDownloadsVideoS)
            myGroupBox2.Controls.Add(rbDownloadsManualS)
            myGroupBox2.DrawTextBackground = True
            myGroupBox2.Location = New System.Drawing.Point(0, 124)
            myGroupBox2.Name = "myGroupBox2?"
            myGroupBox2.Size = New System.Drawing.Size(595, 116)
            myGroupBox2.TabIndex = 26
            myGroupBox2.TabStop = False
            myGroupBox2.Text = "Sekundarna lokacija (ce shranjevanje na primarno lokacijo ne uspe)?"
            rbAutoDownloadFolderS.AutoSize = True
            rbAutoDownloadFolderS.Location = New System.Drawing.Point(6, 88)
            rbAutoDownloadFolderS.Name = "rbAutoDownloadFolderS?"
            rbAutoDownloadFolderS.Size = New System.Drawing.Size(78, 17)
            rbAutoDownloadFolderS.TabIndex = 26
            rbAutoDownloadFolderS.Text = "Samodejno?"
            rbAutoDownloadFolderS.UseVisualStyleBackColor = True
            btnSelectDownloadsFolderS.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelectDownloadsFolderS.Location = New System.Drawing.Point(506, 62)
            btnSelectDownloadsFolderS.Name = "btnSelectDownloadsFolderS?"
            btnSelectDownloadsFolderS.Size = New System.Drawing.Size(75, 23)
            btnSelectDownloadsFolderS.TabIndex = 25
            btnSelectDownloadsFolderS.Text = "Izberi...?"
            btnSelectDownloadsFolderS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelectDownloadsFolderS.Click, AddressOf btnSelectDownloadsFolderS_Click
            txtDownloadsFolderS.AllowDrop = True
            txtDownloadsFolderS.EnableDisableColor = True
            txtDownloadsFolderS.Location = New System.Drawing.Point(149, 64)
            txtDownloadsFolderS.Name = "txtDownloadsFolderS?"
            txtDownloadsFolderS.Size = New System.Drawing.Size(351, 20)
            txtDownloadsFolderS.TabIndex = 24
            rbDownloadsPredefinedS.AutoSize = True
            rbDownloadsPredefinedS.Location = New System.Drawing.Point(6, 65)
            rbDownloadsPredefinedS.Name = "rbDownloadsPredefinedS?"
            rbDownloadsPredefinedS.Size = New System.Drawing.Size(98, 17)
            rbDownloadsPredefinedS.TabIndex = 23
            rbDownloadsPredefinedS.Text = "Mapa na disku:?"
            rbDownloadsPredefinedS.UseVisualStyleBackColor = True
            rbDownloadsVideoS.AutoSize = True
            rbDownloadsVideoS.Location = New System.Drawing.Point(6, 42)
            rbDownloadsVideoS.Name = "rbDownloadsVideoS?"
            rbDownloadsVideoS.Size = New System.Drawing.Size(134, 17)
            rbDownloadsVideoS.TabIndex = 22
            rbDownloadsVideoS.Text = "Mapa z video datoteko?"
            rbDownloadsVideoS.UseVisualStyleBackColor = True
            rbDownloadsManualS.AutoSize = True
            rbDownloadsManualS.Checked = True
            rbDownloadsManualS.Location = New System.Drawing.Point(6, 19)
            rbDownloadsManualS.Name = "rbDownloadsManualS?"
            rbDownloadsManualS.Size = New System.Drawing.Size(137, 17)
            rbDownloadsManualS.TabIndex = 21
            rbDownloadsManualS.TabStop = True
            rbDownloadsManualS.Text = "Vedno doloci uporabnik?"
            rbDownloadsManualS.UseVisualStyleBackColor = True
            myGroupBox3.Controls.Add(btnClearAutoDownloadFolder)
            myGroupBox3.Controls.Add(txtAutoDownloadFolderFiles)
            myGroupBox3.Controls.Add(lblAutoDownloadFolderFiles)
            myGroupBox3.Controls.Add(txtAutoDownloadFolder)
            myGroupBox3.Controls.Add(lblAutoDownloadFolderLocation)
            myGroupBox3.DrawTextBackground = True
            myGroupBox3.Location = New System.Drawing.Point(0, 248)
            myGroupBox3.Name = "myGroupBox3?"
            myGroupBox3.Size = New System.Drawing.Size(595, 75)
            myGroupBox3.TabIndex = 28
            myGroupBox3.TabStop = False
            myGroupBox3.Text = "Lokacija za samodejno shranjevanje?"
            btnClearAutoDownloadFolder.DialogResult = System.Windows.Forms.DialogResult.None
            btnClearAutoDownloadFolder.Location = New System.Drawing.Point(160, 39)
            btnClearAutoDownloadFolder.Name = "btnClearAutoDownloadFolder?"
            btnClearAutoDownloadFolder.Size = New System.Drawing.Size(75, 23)
            btnClearAutoDownloadFolder.TabIndex = 28
            btnClearAutoDownloadFolder.Text = "Pocisti?"
            btnClearAutoDownloadFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnClearAutoDownloadFolder.Click, AddressOf btnClearAutoDownloadFolder_Click
            txtAutoDownloadFolderFiles.AllowDrop = True
            txtAutoDownloadFolderFiles.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtAutoDownloadFolderFiles.EnableDisableColor = True
            txtAutoDownloadFolderFiles.Location = New System.Drawing.Point(110, 41)
            txtAutoDownloadFolderFiles.Name = "txtAutoDownloadFolderFiles?"
            txtAutoDownloadFolderFiles.ReadOnly = True
            txtAutoDownloadFolderFiles.Size = New System.Drawing.Size(44, 20)
            txtAutoDownloadFolderFiles.TabIndex = 27
            txtAutoDownloadFolderFiles.Text = "100?"
            lblAutoDownloadFolderFiles.AutoSize = True
            lblAutoDownloadFolderFiles.Location = New System.Drawing.Point(6, 44)
            lblAutoDownloadFolderFiles.Name = "lblAutoDownloadFolderFiles?"
            lblAutoDownloadFolderFiles.Size = New System.Drawing.Size(62, 13)
            lblAutoDownloadFolderFiles.TabIndex = 26
            lblAutoDownloadFolderFiles.Text = "Št. datotek:?"
            txtAutoDownloadFolder.AllowDrop = True
            txtAutoDownloadFolder.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtAutoDownloadFolder.EnableDisableColor = True
            txtAutoDownloadFolder.Location = New System.Drawing.Point(110, 16)
            txtAutoDownloadFolder.Name = "txtAutoDownloadFolder?"
            txtAutoDownloadFolder.ReadOnly = True
            txtAutoDownloadFolder.Size = New System.Drawing.Size(398, 20)
            txtAutoDownloadFolder.TabIndex = 25
            lblAutoDownloadFolderLocation.AutoSize = True
            lblAutoDownloadFolderLocation.Location = New System.Drawing.Point(6, 19)
            lblAutoDownloadFolderLocation.Name = "lblAutoDownloadFolderLocation?"
            lblAutoDownloadFolderLocation.Size = New System.Drawing.Size(50, 13)
            lblAutoDownloadFolderLocation.TabIndex = 0
            lblAutoDownloadFolderLocation.Text = "Lokacija:?"
            myPanel2.Controls.Add(pictureBox2)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Right
            myPanel2.Location = New System.Drawing.Point(821, 0)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(38, 448)
            myPanel2.TabIndex = 138
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox2.Image = Sublight.Properties.Resources.SettingsFolder
            pictureBox2.Location = New System.Drawing.Point(0, 0)
            pictureBox2.Name = "pictureBox2?"
            pictureBox2.Size = New System.Drawing.Size(37, 39)
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox2.TabIndex = 24
            pictureBox2.TabStop = False
            myGroupBox4.Controls.Add(cbFileNamingAppendLangId)
            myGroupBox4.DrawTextBackground = True
            myGroupBox4.Location = New System.Drawing.Point(0, 329)
            myGroupBox4.Name = "myGroupBox4?"
            myGroupBox4.Size = New System.Drawing.Size(595, 66)
            myGroupBox4.TabIndex = 139
            myGroupBox4.TabStop = False
            myGroupBox4.Text = "Poimenovanje datotek?"
            cbFileNamingAppendLangId.AutoSize = True
            cbFileNamingAppendLangId.Location = New System.Drawing.Point(9, 28)
            cbFileNamingAppendLangId.Name = "cbFileNamingAppendLangId?"
            cbFileNamingAppendLangId.Size = New System.Drawing.Size(202, 17)
            cbFileNamingAppendLangId.TabIndex = 0
            cbFileNamingAppendLangId.Text = "Imenu datoteke dodaj oznako države?"
            cbFileNamingAppendLangId.UseVisualStyleBackColor = True
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(myGroupBox4)
            Controls.Add(myGroupBox3)
            Controls.Add(myGroupBox2)
            Controls.Add(myGroupBox1)
            Controls.Add(myPanel2)
            Name = "SettingsSubtitleDownloadFolder?"
            Size = New System.Drawing.Size(859, 448)
            myGroupBox1.ResumeLayout(False)
            myGroupBox1.PerformLayout()
            myGroupBox2.ResumeLayout(False)
            myGroupBox2.PerformLayout()
            myGroupBox3.ResumeLayout(False)
            myGroupBox3.PerformLayout()
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            pictureBox2.EndInit()
            myGroupBox4.ResumeLayout(False)
            myGroupBox4.PerformLayout()
            ResumeLayout(False)
        End Sub

        Private Sub SetAutoDownloadFolderFilesCount()
            Try
                Dim s1 As String = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Sublight.Globals.AutoDownloadLocation)
                If Not System.IO.Directory.Exists(s1) Then
                    txtAutoDownloadFolderFiles.Text = "0?"
                Else 
                    Dim i1 As Integer = System.IO.Directory.GetFiles(s1).Length
                    txtAutoDownloadFolderFiles.Text = i1.ToString()
                End If
            Catch 
                txtAutoDownloadFolderFiles.Text = "0?"
            End Try
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
                rbDownloadsManual.Checked = False
                rbDownloadsVideo.Checked = False
                rbDownloadsPredefined.Checked = False
                If Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.AlwaysChosenByUser Then
                    rbDownloadsManual.Checked = True
                ElseIf Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.VideoFolder Then
                    rbDownloadsVideo.Checked = True
                ElseIf Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.CustomFolder Then
                    rbDownloadsPredefined.Checked = True
                Else 
                    rbAutoDownloadFolder.Checked = True
                End If
                txtDownloadsFolder.Text = Sublight.Properties.Settings.Default.CustomDownloadLocation
                rbDownloadsManualS.Checked = False
                rbDownloadsVideoS.Checked = False
                rbDownloadsPredefinedS.Checked = False
                If Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.AlwaysChosenByUser Then
                    rbDownloadsManualS.Checked = True
                ElseIf Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.VideoFolder Then
                    rbDownloadsVideoS.Checked = True
                ElseIf Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.CustomFolder Then
                    rbDownloadsPredefinedS.Checked = True
                Else 
                    rbAutoDownloadFolderS.Checked = True
                End If
                txtDownloadsFolderS.Text = Sublight.Properties.Settings.Default.CustomDownloadLocationS
                cbFileNamingAppendLangId.Checked = Sublight.Properties.Settings.Default.SubtitleFileNaming_AppendLangId
                error = Nothing
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub OnDisplayed()
            MyBase.OnDisplayed()
            SetAutoDownloadFolderFilesCount()
        End Sub

        Public Overrides Function SaveSettings(ByVal quietMode As Boolean, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                If rbDownloadsManual.Checked Then
                    Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.AlwaysChosenByUser
                ElseIf rbDownloadsVideo.Checked Then
                    Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.VideoFolder
                ElseIf rbDownloadsPredefined.Checked Then
                    If System.String.IsNullOrEmpty(txtDownloadsFolder.Text) OrElse Not System.IO.Directory.Exists(txtDownloadsFolder.Text) Then
                        Throw New System.Exception(Sublight.Translation.Settings_Warning_DownloadFolderNotValid)
                    End If
                    Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.CustomFolder
                ElseIf rbAutoDownloadFolder.Checked Then
                    Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.Auto
                Else 
                    Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.Auto
                End If
                Sublight.Properties.Settings.Default.CustomDownloadLocation = txtDownloadsFolder.Text
                If rbDownloadsManualS.Checked Then
                    Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.AlwaysChosenByUser
                ElseIf rbDownloadsVideoS.Checked Then
                    Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.VideoFolder
                ElseIf rbDownloadsPredefinedS.Checked Then
                    If System.String.IsNullOrEmpty(txtDownloadsFolderS.Text) OrElse Not System.IO.Directory.Exists(txtDownloadsFolderS.Text) Then
                        Throw New System.Exception(Sublight.Translation.Settings_Warning_DownloadFolderNotValid)
                    End If
                    Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.CustomFolder
                ElseIf rbAutoDownloadFolderS.Checked Then
                    Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.Auto
                Else 
                    Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.Auto
                End If
                Sublight.Properties.Settings.Default.CustomDownloadLocationS = txtDownloadsFolderS.Text
                Sublight.Properties.Settings.Default.SubtitleFileNaming_AppendLangId = cbFileNamingAppendLangId.Checked
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
            rbDownloadsManual.Text = Sublight.Translation.Settings_Panel_DownloadFolder_Manual
            rbDownloadsVideo.Text = Sublight.Translation.Settings_Panel_DownloadFolder_SameAsVideo
            rbDownloadsPredefined.Text = Sublight.Translation.Settings_Panel_DownloadFolder_Predefined
            btnSelectDownloadsFolder.Text = Sublight.Translation.Common_Button_ChooseFile
            rbAutoDownloadFolder.Text = System.String.Format(Sublight.Translation.Settings_Panel_DownloadFolder_Auto, System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Sublight.Globals.AutoDownloadLocation))
            rbDownloadsManualS.Text = Sublight.Translation.Settings_Panel_DownloadFolder_Manual
            rbDownloadsVideoS.Text = Sublight.Translation.Settings_Panel_DownloadFolder_SameAsVideo
            rbDownloadsPredefinedS.Text = Sublight.Translation.Settings_Panel_DownloadFolder_Predefined
            btnSelectDownloadsFolderS.Text = Sublight.Translation.Common_Button_ChooseFile
            rbAutoDownloadFolderS.Text = System.String.Format(Sublight.Translation.Settings_Panel_DownloadFolder_Auto, System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Sublight.Globals.AutoDownloadLocation))
            myGroupBox1.Text = Sublight.Translation.Settings_Panel_DownloadFolder_GroupPrimary
            myGroupBox2.Text = Sublight.Translation.Settings_Panel_DownloadFolder_GroupSecondary
            btnClearAutoDownloadFolder.Text = Sublight.Translation.Common_Button_Clear
            myGroupBox3.Text = Sublight.Translation.Settings_Panel_DownloadFolder_GroupAutoDownloadLocation
            lblAutoDownloadFolderLocation.Text = Sublight.Translation.Settings_Panel_DownloadFolder_GroupAutoDownloadLocation_Location
            lblAutoDownloadFolderFiles.Text = Sublight.Translation.Settings_Panel_DownloadFolder_GroupAutoDownloadLocation_NumberOfFiles
            myGroupBox4.Text = Sublight.Translation.Settings_Panel_DownloadFolder_FileNaming
            cbFileNamingAppendLangId.Text = Sublight.Translation.Settings_Panel_DownloadFolder_FileNaming_AppendLanguageId
        End Sub

    End Class ' class SettingsSubtitleDownloadFolder

End Namespace

