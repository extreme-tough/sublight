Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight

    Public NotInheritable Class FrmAddMyMovieFolder
        Inherits Sublight.BaseForm

        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private btnSelectFolder As Sublight.Controls.Button.Button 
        Private cbSearchSubfolders As System.Windows.Forms.CheckBox 
        Private components As System.ComponentModel.IContainer 
        Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog 
        Private label1 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private label3 As System.Windows.Forms.Label 
        Private label9 As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private txtFolder As Sublight.Controls.MyTextBox 
        Private txtTypes As Sublight.Controls.MyTextBox 

        Public Sub New()
        End Sub

        Public Sub New(ByVal directory As String)
            InitializeComponent()
            btnOK.Text = Sublight.Translation.Common_Button_OK
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            Text = Sublight.Translation.FrmAddMyMovieFolder_Title
            btnSelectFolder.Text = Sublight.Translation.Common_Button_ChooseFile
            label1.Text = Sublight.Translation.FrmAddMyMovieFolder_Folder
            label2.Text = Sublight.Translation.FrmAddMyMovieFolder_FileTypes
            label3.Text = Sublight.Translation.FrmAddMyMovieFolder_SearchSubfolders
            label9.Text = Sublight.Translation.FrmAddMyMovieFolder_FileTypes_Tip
            If Not System.String.IsNullOrEmpty(directory) Then
                txtFolder.Text = directory
            End If
            If Not (Sublight.Globals.VideoExtensionsFilter) Is Nothing Then
                txtTypes.Text = Sublight.Globals.VideoExtensionsFilter
            End If
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If System.String.IsNullOrEmpty(txtFolder.Text) Then
                ShowError(Sublight.Translation.FrmAddMyMovieFolder_Error_FolderNotSet, New object(0) {})
                Return
            End If
            If Not System.IO.Directory.Exists(txtFolder.Text) Then
                ShowError(Sublight.Translation.FrmAddMyMovieFolder_Error_FolderNotValid, New object(0) {})
                Return
            End If
            Sublight.Properties.Settings.Default.MyMovies_Folders.Add(New Sublight.Types.MovieFolder(txtFolder.Text, txtTypes.Text, cbSearchSubfolders.Checked))
            SaveUserSettings()
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub btnSelectFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If folderBrowserDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                txtFolder.Text = folderBrowserDialog1.SelectedPath
            End If
        End Sub

        Private Sub InitializeComponent()
            niceLine1 = New Sublight.Controls.NiceLine
            btnCancel = New Sublight.Controls.Button.Button
            btnOK = New Sublight.Controls.Button.Button
            label1 = New System.Windows.Forms.Label
            txtFolder = New Sublight.Controls.MyTextBox
            label2 = New System.Windows.Forms.Label
            txtTypes = New Sublight.Controls.MyTextBox
            label3 = New System.Windows.Forms.Label
            cbSearchSubfolders = New System.Windows.Forms.CheckBox
            btnSelectFolder = New Sublight.Controls.Button.Button
            folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
            label9 = New System.Windows.Forms.Label
            SuspendLayout()
            niceLine1.Location = New System.Drawing.Point(13, 103)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(616, 15)
            niceLine1.TabIndex = 138
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(553, 121)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 5
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnOK.DialogResult = System.Windows.Forms.DialogResult.None
            btnOK.Location = New System.Drawing.Point(472, 121)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 4
            btnOK.Text = "V redu?"
            btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnOK.Click, AddressOf btnOK_Click
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(12, 9)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(37, 13)
            label1.TabIndex = 139
            label1.Text = "Mapa:?"
            txtFolder.EnableDisableColor = True
            txtFolder.Location = New System.Drawing.Point(135, 6)
            txtFolder.Name = "txtFolder?"
            txtFolder.Size = New System.Drawing.Size(413, 20)
            txtFolder.TabIndex = 0
            AddHandler txtFolder.KeyDown, AddressOf txtFolder_KeyDown
            label2.AutoSize = True
            label2.Location = New System.Drawing.Point(12, 40)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(66, 13)
            label2.TabIndex = 141
            label2.Text = "Tipi datotek:?"
            txtTypes.EnableDisableColor = True
            txtTypes.Location = New System.Drawing.Point(135, 37)
            txtTypes.Name = "txtTypes?"
            txtTypes.Size = New System.Drawing.Size(182, 20)
            txtTypes.TabIndex = 2
            txtTypes.Text = "*.avi?"
            label3.Location = New System.Drawing.Point(12, 69)
            label3.Name = "label3?"
            label3.Size = New System.Drawing.Size(106, 31)
            label3.TabIndex = 143
            label3.Text = "Iskanje v podmapah:?"
            cbSearchSubfolders.AutoSize = True
            cbSearchSubfolders.Checked = True
            cbSearchSubfolders.CheckState = System.Windows.Forms.CheckState.Checked
            cbSearchSubfolders.Location = New System.Drawing.Point(135, 68)
            cbSearchSubfolders.Name = "cbSearchSubfolders?"
            cbSearchSubfolders.Size = New System.Drawing.Size(15, 14)
            cbSearchSubfolders.TabIndex = 3
            cbSearchSubfolders.UseVisualStyleBackColor = True
            btnSelectFolder.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelectFolder.Location = New System.Drawing.Point(554, 4)
            btnSelectFolder.Name = "btnSelectFolder?"
            btnSelectFolder.Size = New System.Drawing.Size(75, 23)
            btnSelectFolder.TabIndex = 1
            btnSelectFolder.Text = "Izberi...?"
            btnSelectFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelectFolder.Click, AddressOf btnSelectFolder_Click
            label9.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            label9.Location = New System.Drawing.Point(323, 40)
            label9.Name = "label9?"
            label9.Size = New System.Drawing.Size(305, 42)
            label9.TabIndex = 146
            label9.Text = "vec koncnic locite s podpicji, primer: *.avi; *.divx?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(641, 159)
            Controls.Add(label9)
            Controls.Add(btnSelectFolder)
            Controls.Add(cbSearchSubfolders)
            Controls.Add(label3)
            Controls.Add(txtTypes)
            Controls.Add(label2)
            Controls.Add(txtFolder)
            Controls.Add(label1)
            Controls.Add(niceLine1)
            Controls.Add(btnCancel)
            Controls.Add(btnOK)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Name = "FrmAddMyMovieFolder?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Dodajanje filmske mape?"
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub txtFolder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnOK_Click(Me, Nothing)
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmAddMyMovieFolder

End Namespace

