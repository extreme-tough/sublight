Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class SettingsExternalVideoApp
        Inherits Sublight.Controls.BaseSettings

        Private btnSelectApp As Sublight.Controls.Button.Button 
        Private btnVideoAppHelp As Sublight.Controls.Button.Button 
        Private btnWMPSetup As Sublight.Controls.Button.Button 
        Private cbVideoApp As Sublight.Controls.MyComboBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private label3 As System.Windows.Forms.Label 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private openFileDialog1 As System.Windows.Forms.OpenFileDialog 
        Private pictureBox2 As System.Windows.Forms.PictureBox 
        Private ttParameters As Sublight.Controls.ToolTip 
        Private txtAppParameters As Sublight.Controls.MyTextBox 
        Private txtAppPath As Sublight.Controls.MyTextBox 

        Public Overrides ReadOnly Property Title As String
            Get
                Return Sublight.Translation.Settings_ExternalVideoApplication
            End Get
        End Property

        Friend Sub New()
        End Sub

        Public Sub New(ByVal parent As Sublight.BaseForm)
            InitializeComponent()
            btnWMPSetup.Visible = False
            cbVideoApp.Items.Clear()
            cbVideoApp.Items.Add(Sublight.Types.ListItem.CreateNotSelected())
            cbVideoApp.Items.Add(New Sublight.Types.ListItem(Sublight.Translation.Common_Selection_Custom, "Custom?"))
            Dim sArr1 As String() = Sublight.MyUtility.VideoApp.GetDetectedApps()
            Dim sArr2 As String() = sArr1
            Dim i1 As Integer = 0
            While i1 < sArr2.Length
                Dim s1 As String = sArr2(i1)
                cbVideoApp.Items.Add(New Sublight.Types.ListItem(Sublight.MyUtility.VideoApp.GetName(s1), s1))
                i1 = i1 + 1
            End While
            Sublight.Globals.SelectNotSelected(cbVideoApp)
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Private Sub btnSelectApp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            openFileDialog1.FileName = System.String.Empty
            openFileDialog1.Title = Sublight.Translation.Dialog_OpenApplication_Title
            openFileDialog1.Filter = Sublight.Translation.Dialog_OpenApplication_Filter
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                txtAppPath.Text = openFileDialog1.FileName
            End If
        End Sub

        Private Sub btnVideoAppHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            stringBuilder1.AppendLine(Sublight.Translation.Settings_ExternalVideoApplication_Help)
            stringBuilder1.AppendFormat("
•  BS.Player (2.24)
•  GOM Player (2.1.8)
•  KMPlayer (2.9.3)
•  Media Player Classic (6.4.9.0)
•  VLC media player (0.8.6.0, 1.0.0.0)
•  Windows Media Player 11
•  Zoom Player 6?", New object(0) {})
            ParentBaseForm.ShowInfo(stringBuilder1.ToString(), New object(0) {})
        End Sub

        Private Sub btnWMPSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ParentBaseForm.OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl("Misc/WMP.jpg?"))
        End Sub

        Private Sub cbVideoApp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbVideoApp.SelectedItem, Sublight.Types.ListItem)
            If (listItem1) Is Nothing Then
                Return
            End If
            If Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                txtAppPath.Enabled = False
                txtAppParameters.Enabled = False
                btnSelectApp.Enabled = False
                btnWMPSetup.Visible = False
                txtAppParameters.Text = System.String.Empty
                Return
            End If
            Dim s1 As String = TryCast(listItem1.Value, string)
            txtAppPath.Enabled = System.String.Compare(s1, "Custom?", True) = 0
            btnWMPSetup.Visible = System.String.Compare(s1, "WMP?", True) = 0
            btnSelectApp.Enabled = txtAppPath.Enabled
            txtAppParameters.Enabled = True
            txtAppParameters.Text = Sublight.MyUtility.VideoApp.GetParameters(s1)
            txtAppPath.Text = System.String.Empty
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            MyBase.Translate()
        End Sub

        Private Sub InitializeComponent()
            btnVideoAppHelp = New Sublight.Controls.Button.Button
            txtAppParameters = New Sublight.Controls.MyTextBox
            label3 = New System.Windows.Forms.Label
            btnSelectApp = New Sublight.Controls.Button.Button
            txtAppPath = New Sublight.Controls.MyTextBox
            label2 = New System.Windows.Forms.Label
            cbVideoApp = New Sublight.Controls.MyComboBox
            label1 = New System.Windows.Forms.Label
            openFileDialog1 = New System.Windows.Forms.OpenFileDialog
            ttParameters = New Sublight.Controls.ToolTip
            myPanel2 = New Sublight.Controls.MyPanel
            pictureBox2 = New System.Windows.Forms.PictureBox
            btnWMPSetup = New Sublight.Controls.Button.Button
            myPanel2.SuspendLayout()
            pictureBox2.BeginInit()
            SuspendLayout()
            btnVideoAppHelp.DialogResult = System.Windows.Forms.DialogResult.None
            btnVideoAppHelp.Location = New System.Drawing.Point(272, 2)
            btnVideoAppHelp.Name = "btnVideoAppHelp?"
            btnVideoAppHelp.Size = New System.Drawing.Size(24, 23)
            btnVideoAppHelp.TabIndex = 133
            btnVideoAppHelp.Text = "??"
            btnVideoAppHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnVideoAppHelp.Click, AddressOf btnVideoAppHelp_Click
            txtAppParameters.AllowDrop = True
            txtAppParameters.Location = New System.Drawing.Point(123, 56)
            txtAppParameters.Name = "txtAppParameters?"
            txtAppParameters.Size = New System.Drawing.Size(351, 20)
            txtAppParameters.TabIndex = 136
            label3.AutoSize = True
            label3.Location = New System.Drawing.Point(5, 59)
            label3.Name = "label3?"
            label3.Size = New System.Drawing.Size(54, 13)
            label3.TabIndex = 137
            label3.Text = "Parametri:?"
            btnSelectApp.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelectApp.Location = New System.Drawing.Point(480, 27)
            btnSelectApp.Name = "btnSelectApp?"
            btnSelectApp.Size = New System.Drawing.Size(75, 23)
            btnSelectApp.TabIndex = 135
            btnSelectApp.Text = "Izberi...?"
            btnSelectApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelectApp.Click, AddressOf btnSelectApp_Click
            txtAppPath.AllowDrop = True
            txtAppPath.Location = New System.Drawing.Point(123, 30)
            txtAppPath.Name = "txtAppPath?"
            txtAppPath.Size = New System.Drawing.Size(351, 20)
            txtAppPath.TabIndex = 134
            label2.AutoSize = True
            label2.Location = New System.Drawing.Point(5, 33)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(97, 13)
            label2.TabIndex = 132
            label2.Text = "Lokacija aplikacije:?"
            cbVideoApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbVideoApp.FormattingEnabled = True
            cbVideoApp.Location = New System.Drawing.Point(123, 3)
            cbVideoApp.Name = "cbVideoApp?"
            cbVideoApp.Size = New System.Drawing.Size(143, 21)
            cbVideoApp.TabIndex = 131
            AddHandler cbVideoApp.SelectedIndexChanged, AddressOf cbVideoApp_SelectedIndexChanged
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(5, 6)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(84, 13)
            label1.TabIndex = 130
            label1.Text = "Video aplikacija:?"
            openFileDialog1.FileName = "openFileDialog1?"
            ttParameters.Location = New System.Drawing.Point(480, 59)
            ttParameters.Name = "ttParameters?"
            ttParameters.Size = New System.Drawing.Size(13, 16)
            ttParameters.TabIndex = 139
            ttParameters.Title = "?"
            myPanel2.Controls.Add(pictureBox2)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Right
            myPanel2.Location = New System.Drawing.Point(594, 0)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(38, 237)
            myPanel2.TabIndex = 140
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox2.Image = Sublight.Properties.Resources.SettingsPlay
            pictureBox2.Location = New System.Drawing.Point(0, 0)
            pictureBox2.Name = "pictureBox2?"
            pictureBox2.Size = New System.Drawing.Size(37, 39)
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox2.TabIndex = 24
            pictureBox2.TabStop = False
            btnWMPSetup.DialogResult = System.Windows.Forms.DialogResult.None
            btnWMPSetup.Location = New System.Drawing.Point(120, 88)
            btnWMPSetup.Name = "btnWMPSetup?"
            btnWMPSetup.Size = New System.Drawing.Size(354, 23)
            btnWMPSetup.TabIndex = 141
            btnWMPSetup.Text = "Kako nastavim Windows Media Player za predvajanje podnapisov??"
            btnWMPSetup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnWMPSetup.Click, AddressOf btnWMPSetup_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(btnWMPSetup)
            Controls.Add(myPanel2)
            Controls.Add(ttParameters)
            Controls.Add(btnVideoAppHelp)
            Controls.Add(txtAppParameters)
            Controls.Add(label3)
            Controls.Add(btnSelectApp)
            Controls.Add(txtAppPath)
            Controls.Add(label2)
            Controls.Add(cbVideoApp)
            Controls.Add(label1)
            Name = "SettingsExternalVideoApp?"
            Size = New System.Drawing.Size(632, 237)
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

            error = Nothing
            Try
                If System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.VideoApp) Then
                    Sublight.Globals.SelectNotSelected(cbVideoApp)
                Else 
                    Sublight.Globals.SelectNotSelected(cbVideoApp)
                    Dim listItem1 As Sublight.Types.ListItem 
                    For Each listItem1 In cbVideoApp.Items
                        Dim s1 As String = TryCast(listItem1.Value, string)
                        If System.String.Compare(s1, Sublight.Properties.Settings.Default.VideoApp, True) = 0 Then
                            cbVideoApp.SelectedItem = listItem1
                            Exit While
                        End If
                    Next
                End If
                txtAppPath.Text = Sublight.Properties.Settings.Default.VideoApp_Path
                txtAppParameters.Text = Sublight.Properties.Settings.Default.VideoApp_Params
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub OnAfterReset()
            OnBeforeReset()
            Sublight.Properties.Settings.Default.VideoApp = System.String.Empty
            Sublight.Properties.Settings.Default.VideoApp_Params = Sublight.MyUtility.VideoApp.GetParameters(Sublight.Properties.Settings.Default.VideoApp)
        End Sub

        Public Overrides Function SaveSettings(ByVal quietMode As Boolean, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                Dim listItem1 As Sublight.Types.ListItem = TryCast(cbVideoApp.SelectedItem, Sublight.Types.ListItem)
                If Not (listItem1) Is Nothing Then
                    If Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                        Sublight.Properties.Settings.Default.VideoApp = System.String.Empty
                    Else 
                        If (System.String.Compare(TryCast(listItem1.Value, string), "Custom?", True) = 0) AndAlso Not System.IO.File.Exists(txtAppPath.Text) Then
                            Throw New System.Exception(Sublight.Translation.Settings_Warning_SelectValidVideoAppPath)
                        End If
                        Dim s1 As String = Sublight.Properties.Settings.Default.VideoApp
                        Sublight.Properties.Settings.Default.VideoApp = TryCast(listItem1.Value, string)
                        If System.String.Compare(TryCast(listItem1.Value, string), "Custom?", True) <> 0 Then
                            Dim s2 As String = Sublight.MyUtility.VideoApp.GetVideoAppPath()
                            If Not System.IO.File.Exists(s2) Then
                                Sublight.Properties.Settings.Default.VideoApp = s1
                                Throw New System.Exception(Sublight.Translation.Settings_Warning_AutoVideoAppPathNotFound)
                            End If
                        End If
                    End If
                End If
                Sublight.Properties.Settings.Default.VideoApp_Path = txtAppPath.Text
                Sublight.Properties.Settings.Default.VideoApp_Params = txtAppParameters.Text
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub Translate()
            MyBase.Translate()
            btnSelectApp.Text = Sublight.Translation.Common_Button_ChooseFile
            label1.Text = Sublight.Translation.Settings_ExternalVideoApplication_Type
            label2.Text = Sublight.Translation.Settings_ExternalVideoApplication_Location
            label3.Text = Sublight.Translation.Settings_ExternalVideoApplication_Parameters
            ttParameters.Title = Sublight.Translation.Settings_ExternalVideoApplication_ParametersHelp
            ttParameters.Text = Sublight.Translation.Settings_ExternalVideoApplication_ParametersHelp_Tooltip
            btnWMPSetup.Text = Sublight.Translation.Settings_ExternalVideoApplication_WmpHelp
        End Sub

    End Class ' class SettingsExternalVideoApp

End Namespace

