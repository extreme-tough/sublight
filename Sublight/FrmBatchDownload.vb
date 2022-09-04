Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Lib.Language
Imports Sublight.Lib.SubtitlesAPI
Imports Sublight.Properties
Imports Sublight.WS

Namespace Sublight

    Public Class FrmBatchDownload
        Inherits Sublight.BaseForm

        Private ReadOnly _folder As String 

        Private _SublightCmdArgs As String 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private btnSelect As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog 
        Private gbCommandPreview As System.Windows.Forms.GroupBox 
        Private lblDirectory As System.Windows.Forms.Label 
        Private lblFileTypes As System.Windows.Forms.Label 
        Private lblLanguages As System.Windows.Forms.Label 
        Private lblUsername As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private txtCmd As Sublight.Controls.MyTextBox 
        Private txtDirectory As Sublight.Controls.MyTextBox 
        Private txtFileTypes As Sublight.Controls.MyTextBox 
        Private txtLanguages As Sublight.Controls.MyTextBox 
        Private txtUsername As Sublight.Controls.MyTextBox 

        Public Sub New()
            _SublightCmdArgs = System.String.Empty
            InitializeComponent()
            Text = Sublight.Translation.BatchDownload_Title
            btnSelect.Text = Sublight.Translation.Common_Button_ChooseFile
            lblDirectory.Text = Sublight.Translation.BatchDownload_Field_Folder
            lblFileTypes.Text = Sublight.Translation.BatchDownload_Field_FileTypes
            lblLanguages.Text = Sublight.Translation.BatchDownload_Field_Languages
            gbCommandPreview.Text = Sublight.Translation.BatchDownload_GroupBox_CommandPreview
            btnOK.Text = Sublight.Translation.MyMovies_FileScan_ContextMenu_FileActions_RunSublightCmd
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            lblUsername.Text = Sublight.Translation.BatchDownload_Field_Username
        End Sub

        Public Sub New(ByVal folder As String)
            _folder = folder
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If System.String.IsNullOrEmpty(txtUsername.Text) OrElse (txtUsername.Text.Trim().Length <= 0) Then
                txtUsername.BackColor = System.Drawing.Color.Red
                Return
            End If
            Sublight.FrmMain.RunSublightCmd(Me, _SublightCmdArgs, Nothing)
            Close()
        End Sub

        Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                txtDirectory.Text = folderBrowserDialog1.SelectedPath
            End If
        End Sub

        Private Sub cmdLineParamsChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            RefreshCmdPreview()
        End Sub

        Private Sub InitializeComponent()
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.FrmBatchDownload))
            niceLine1 = New Sublight.Controls.NiceLine
            btnCancel = New Sublight.Controls.Button.Button
            btnOK = New Sublight.Controls.Button.Button
            lblDirectory = New System.Windows.Forms.Label
            btnSelect = New Sublight.Controls.Button.Button
            txtDirectory = New Sublight.Controls.MyTextBox
            gbCommandPreview = New System.Windows.Forms.GroupBox
            txtCmd = New Sublight.Controls.MyTextBox
            folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
            txtFileTypes = New Sublight.Controls.MyTextBox
            lblFileTypes = New System.Windows.Forms.Label
            txtLanguages = New Sublight.Controls.MyTextBox
            lblLanguages = New System.Windows.Forms.Label
            txtUsername = New Sublight.Controls.MyTextBox
            lblUsername = New System.Windows.Forms.Label
            gbCommandPreview.SuspendLayout()
            SuspendLayout()
            niceLine1.Location = New System.Drawing.Point(12, 286)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(463, 15)
            niceLine1.TabIndex = 19
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.None
            btnCancel.Location = New System.Drawing.Point(400, 304)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 7
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnOK.AutoResize = False
            btnOK.DialogResult = System.Windows.Forms.DialogResult.None
            btnOK.Location = New System.Drawing.Point(242, 304)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(152, 23)
            btnOK.TabIndex = 6
            btnOK.Text = "Zaženi SublightCmd?"
            btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnOK.Click, AddressOf btnOK_Click
            lblDirectory.AutoSize = True
            lblDirectory.Location = New System.Drawing.Point(12, 9)
            lblDirectory.Name = "lblDirectory?"
            lblDirectory.Size = New System.Drawing.Size(52, 13)
            lblDirectory.TabIndex = 21
            lblDirectory.Text = "Directory:?"
            btnSelect.AutoResize = False
            btnSelect.BackColor = System.Drawing.Color.Transparent
            btnSelect.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnSelect.Location = New System.Drawing.Point(403, 4)
            btnSelect.Name = "btnSelect?"
            btnSelect.Size = New System.Drawing.Size(75, 23)
            btnSelect.TabIndex = 1
            btnSelect.Text = "Izberi...?"
            btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelect.Click, AddressOf btnSelect_Click
            txtDirectory.EnableDisableColor = True
            txtDirectory.Location = New System.Drawing.Point(107, 5)
            txtDirectory.Name = "txtDirectory?"
            txtDirectory.Size = New System.Drawing.Size(290, 20)
            txtDirectory.TabIndex = 0
            AddHandler txtDirectory.TextChanged, AddressOf cmdLineParamsChanged
            gbCommandPreview.Controls.Add(txtCmd)
            gbCommandPreview.Location = New System.Drawing.Point(12, 129)
            gbCommandPreview.Name = "gbCommandPreview?"
            gbCommandPreview.Size = New System.Drawing.Size(463, 151)
            gbCommandPreview.TabIndex = 5
            gbCommandPreview.TabStop = False
            gbCommandPreview.Text = "Command preview:?"
            txtCmd.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtCmd.EnableDisableColor = True
            txtCmd.Location = New System.Drawing.Point(6, 19)
            txtCmd.Multiline = True
            txtCmd.Name = "txtCmd?"
            txtCmd.ReadOnly = True
            txtCmd.Size = New System.Drawing.Size(451, 126)
            txtCmd.TabIndex = 6
            txtFileTypes.EnableDisableColor = True
            txtFileTypes.Location = New System.Drawing.Point(107, 31)
            txtFileTypes.Name = "txtFileTypes?"
            txtFileTypes.Size = New System.Drawing.Size(290, 20)
            txtFileTypes.TabIndex = 2
            AddHandler txtFileTypes.TextChanged, AddressOf cmdLineParamsChanged
            lblFileTypes.AutoSize = True
            lblFileTypes.Location = New System.Drawing.Point(12, 35)
            lblFileTypes.Name = "lblFileTypes?"
            lblFileTypes.Size = New System.Drawing.Size(54, 13)
            lblFileTypes.TabIndex = 136
            lblFileTypes.Text = "File types:?"
            txtLanguages.EnableDisableColor = True
            txtLanguages.Location = New System.Drawing.Point(107, 57)
            txtLanguages.Name = "txtLanguages?"
            txtLanguages.Size = New System.Drawing.Size(290, 20)
            txtLanguages.TabIndex = 3
            AddHandler txtLanguages.TextChanged, AddressOf cmdLineParamsChanged
            lblLanguages.AutoSize = True
            lblLanguages.Location = New System.Drawing.Point(12, 61)
            lblLanguages.Name = "lblLanguages?"
            lblLanguages.Size = New System.Drawing.Size(63, 13)
            lblLanguages.TabIndex = 138
            lblLanguages.Text = "Languages:?"
            txtUsername.EnableDisableColor = True
            txtUsername.Location = New System.Drawing.Point(107, 83)
            txtUsername.Name = "txtUsername?"
            txtUsername.Size = New System.Drawing.Size(290, 20)
            txtUsername.TabIndex = 4
            AddHandler txtUsername.TextChanged, AddressOf txtUsername_TextChanged
            lblUsername.AutoSize = True
            lblUsername.Location = New System.Drawing.Point(12, 87)
            lblUsername.Name = "lblUsername?"
            lblUsername.Size = New System.Drawing.Size(58, 13)
            lblUsername.TabIndex = 140
            lblUsername.Text = "Username:?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(494, 345)
            Controls.Add(txtUsername)
            Controls.Add(lblUsername)
            Controls.Add(txtLanguages)
            Controls.Add(lblLanguages)
            Controls.Add(txtFileTypes)
            Controls.Add(lblFileTypes)
            Controls.Add(gbCommandPreview)
            Controls.Add(btnSelect)
            Controls.Add(txtDirectory)
            Controls.Add(lblDirectory)
            Controls.Add(niceLine1)
            Controls.Add(btnCancel)
            Controls.Add(btnOK)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Icon = CType(componentResourceManager1.GetObject("$this.Icon?"), System.Drawing.Icon)
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmBatchDownload?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Batch download?"
            gbCommandPreview.ResumeLayout(False)
            gbCommandPreview.PerformLayout()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub RefreshCmdPreview()
            _SublightCmdArgs = System.String.Format("downloadbatch ""{0}"" ""{1}"" {2} /recursive:true?", txtDirectory.Text, txtFileTypes.Text, txtLanguages.Text)
            If Not Sublight.BaseForm.IsAnonymous Then
                _SublightCmdArgs = _SublightCmdArgs + System.String.Format(" /username:""{0}""?", txtUsername.Text)
            End If
            txtCmd.Text = System.String.Format("SublightCmd.exe {0}?", _SublightCmdArgs)
        End Sub

        Private Sub txtUsername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If txtUsername.BackColor <> System.Drawing.SystemColors.Window Then
                txtUsername.BackColor = System.Drawing.SystemColors.Window
            End If
            RefreshCmdPreview()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            If System.String.IsNullOrEmpty(_folder) Then
                txtDirectory.Text = "C:\?"
            Else 
                txtDirectory.Text = _folder
            End If
            txtFileTypes.Text = Sublight.Globals.VideoExtensionsFilter
            txtUsername.Text = IIf(System.String.IsNullOrEmpty(_folder), Sublight.BaseForm.Username, Sublight.Properties.Settings.Default.LogIn_Username)
            Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
            If Not (Sublight.Properties.Settings.Default.Application_Filter_Language) Is Nothing Then
                Dim enumerator1 As System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage).Enumerator = Sublight.Properties.Settings.Default.Application_Filter_Language.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim subtitleLanguage2 As Sublight.WS.SubtitleLanguage = CType(enumerator1.get_Current(), Sublight.WS.SubtitleLanguage)
                        Try
                            Dim subtitleLanguage1 As Sublight.Lib.SubtitlesAPI.SubtitleLanguage = DirectCast(System.Enum.Parse(GetType(Sublight.Lib.SubtitlesAPI.SubtitleLanguage), System.Enum.GetName(GetType(Sublight.WS.SubtitleLanguage), subtitleLanguage2)), Sublight.Lib.SubtitlesAPI.SubtitleLanguage)
                            Dim s1 As String = Sublight.Lib.Language.Util.GetCodeByLanguage(subtitleLanguage1)
                            If Not System.String.IsNullOrEmpty(s1) Then
                                list1.Add(s1)
                            End If
                        Catch 
                        End Try
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim i1 As Integer = 0
            While i1 < list1.get_Count()
                stringBuilder1.AppendFormat("""{0}""?", list1.get_Item(i1))
                If i1 < (list1.get_Count() - 1) Then
                    stringBuilder1.Append("+?")
                End If
                i1 = i1 + 1
            End While
            txtLanguages.Text = stringBuilder1.ToString()
            RefreshCmdPreview()
        End Sub

    End Class ' class FrmBatchDownload

End Namespace

