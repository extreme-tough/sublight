Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.Plugins.SubtitleProvider
Imports Sublight.Plugins.SubtitleProvider.Types
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class SettingsPlugins
        Inherits Sublight.Controls.BaseSettings

        Private btnMoveDown As Sublight.Controls.Button.Button 
        Private btnMoveUp As Sublight.Controls.Button.Button 
        Private cbDirectDownload As Sublight.Controls.MyCheckBox 
        Private clbPlugins As System.Windows.Forms.CheckedListBox 
        Private components As System.ComponentModel.IContainer 
        Private gbSubtitleProvider As Sublight.Controls.MyGroupBox 
        Private gbSubtitleProviderOrder As Sublight.Controls.MyGroupBox 
        Private lblDirectDownload As System.Windows.Forms.Label 
        Private lblPluginDescription As System.Windows.Forms.Label 
        Private lblPluginFile As System.Windows.Forms.Label 
        Private lblPluginName As System.Windows.Forms.Label 
        Private lnkDevelopment As System.Windows.Forms.LinkLabel 
        Private myPanel1 As Sublight.Controls.MyPanel 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private myPanel3 As Sublight.Controls.MyPanel 
        Private panel1 As Sublight.Controls.Panel 
        Private pbProviderLogo As System.Windows.Forms.PictureBox 
        Private pictureBox4 As System.Windows.Forms.PictureBox 
        Private rbSearchAlways As Sublight.Controls.MyRadioButton 
        Private rbSearchNever As Sublight.Controls.MyRadioButton 
        Private rbSearchWhenNoResultsOnPrimarySource As Sublight.Controls.MyRadioButton 
        Private txtDescription As Sublight.Controls.MyTextBox 
        Private txtFile As Sublight.Controls.MyTextBox 
        Private txtName As Sublight.Controls.MyTextBox 

        Public Overrides ReadOnly Property Title As String
            Get
                Return Sublight.Translation.Settings_Panel_SettingsPlugins_SearchProvider
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm)
            InitializeComponent()
            pbProviderLogo.Visible = False
            pbProviderLogo.BorderStyle = System.Windows.Forms.BorderStyle.None
            btnMoveUp.Enabled = False
            btnMoveDown.Enabled = False
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Private Sub btnMoveDown_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If clbPlugins.SelectedIndex < 0 Then
                Return
            End If
            Dim i1 As Integer = clbPlugins.SelectedIndex
            Dim obj1 As Object = clbPlugins.Items(clbPlugins.SelectedIndex)
            Dim flag1 As Boolean = clbPlugins.GetItemChecked(clbPlugins.SelectedIndex)
            clbPlugins.Items.RemoveAt(clbPlugins.SelectedIndex)
            Dim i2 As Integer = i1 + 1
            clbPlugins.Items.Insert(i2, obj1)
            clbPlugins.SetItemChecked(i2, flag1)
            clbPlugins.SelectedIndex = i2
        End Sub

        Private Sub btnMoveUp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If clbPlugins.SelectedIndex < 0 Then
                Return
            End If
            Dim i1 As Integer = clbPlugins.SelectedIndex
            Dim obj1 As Object = clbPlugins.Items(clbPlugins.SelectedIndex)
            Dim flag1 As Boolean = clbPlugins.GetItemChecked(clbPlugins.SelectedIndex)
            clbPlugins.Items.RemoveAt(clbPlugins.SelectedIndex)
            Dim i2 As Integer = i1 - 1
            clbPlugins.Items.Insert(i2, obj1)
            clbPlugins.SetItemChecked(i2, flag1)
            clbPlugins.SelectedIndex = i2
        End Sub

        Private Sub clbPlugins_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If clbPlugins.SelectedIndex >= 0 Then
                Dim isubtitleProvider1 As Sublight.Plugins.SubtitleProvider.ISubtitleProvider = Sublight.Plugins.SubtitleProvider.PluginManager.CreateInstance(Sublight.Properties.Settings.Default.PluginDir, TryCast(clbPlugins.Items(clbPlugins.SelectedIndex), string))
                If Not (isubtitleProvider1) Is Nothing Then
                    txtName.Text = System.String.Format("{0} ({1})?", isubtitleProvider1.ShortName, isubtitleProvider1.Version.ToString(3))
                    txtDescription.Text = isubtitleProvider1.Info
                    txtFile.Text = isubtitleProvider1.GetType().Module.Name
                    cbDirectDownload.Checked = isubtitleProvider1.DownloadType = Sublight.Plugins.SubtitleProvider.Types.SubtitleProviderDownloadType.Direct
                    pbProviderLogo.Visible = False
                    If Not (isubtitleProvider1.Logo) Is Nothing Then
                        pbProviderLogo.Image = isubtitleProvider1.Logo
                        pbProviderLogo.Visible = True
                    End If
                Else 
                    ClearSubtitleProviderInfo()
                End If
            End If
            If (clbPlugins.SelectedIndex < 0) OrElse (clbPlugins.Items.Count <= 1) Then
                btnMoveUp.Enabled = False
                btnMoveDown.Enabled = False
                Return
            End If
            If clbPlugins.SelectedIndex = 0 Then
                btnMoveUp.Enabled = False
                btnMoveDown.Enabled = True
                Return
            End If
            If clbPlugins.SelectedIndex = (clbPlugins.Items.Count - 1) Then
                btnMoveUp.Enabled = True
                btnMoveDown.Enabled = False
                Return
            End If
            btnMoveUp.Enabled = True
            btnMoveDown.Enabled = True
        End Sub

        Private Sub ClearSubtitleProviderInfo()
            txtName.Text = System.String.Empty
            txtDescription.Text = System.String.Empty
            txtFile.Text = System.String.Empty
            cbDirectDownload.Checked = False
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            MyBase.Translate()
        End Sub

        Private Sub FillPlugins()
            clbPlugins.Items.Clear()
            Dim typeArr1 As System.Type() = Sublight.Plugins.SubtitleProvider.PluginManager.GetPlugins(Sublight.Properties.Settings.Default.PluginDir, Sublight.Properties.Settings.Default.Plugins_SubtitleProviderOrder)
            If Not (typeArr1) Is Nothing Then
                Dim typeArr3 As System.Type() = typeArr1
                Dim i1 As Integer = 0
                While i1 < typeArr3.Length
                    Dim type1 As System.Type = typeArr3(i1)
                    clbPlugins.Items.Add(type1.Name, True)
                    i1 = i1 + 1
                End While
            End If
            Dim typeArr2 As System.Type() = Sublight.Plugins.SubtitleProvider.PluginManager.GetAllPlugins(Sublight.Properties.Settings.Default.PluginDir)
            If Not (typeArr2) Is Nothing Then
                Dim typeArr4 As System.Type() = typeArr2
                Dim i2 As Integer = 0
                While i2 < typeArr4.Length
                    Dim type2 As System.Type = typeArr4(i2)
                    Dim flag1 As Boolean = False
                    If Not (typeArr1) Is Nothing Then
                        Dim typeArr5 As System.Type() = typeArr1
                        Dim i3 As Integer = 0
                        While i3 < typeArr5.Length
                            Dim type3 As System.Type = typeArr5(i3)
                            If type2 = type3 Then
                                flag1 = True
                                Exit While
                            End If
                            i3 = i3 + 1
                        End While
                    End If
                    If Not flag1 Then
                        clbPlugins.Items.Add(type2.Name, False)
                    End If
                    i2 = i2 + 1
                End While
            End If
        End Sub

        Private Sub InitializeComponent()
            myPanel2 = New Sublight.Controls.MyPanel
            pictureBox4 = New System.Windows.Forms.PictureBox
            panel1 = New Sublight.Controls.Panel
            myPanel1 = New Sublight.Controls.MyPanel
            gbSubtitleProvider = New Sublight.Controls.MyGroupBox
            rbSearchNever = New Sublight.Controls.MyRadioButton
            rbSearchAlways = New Sublight.Controls.MyRadioButton
            rbSearchWhenNoResultsOnPrimarySource = New Sublight.Controls.MyRadioButton
            myPanel3 = New Sublight.Controls.MyPanel
            gbSubtitleProviderOrder = New Sublight.Controls.MyGroupBox
            pbProviderLogo = New System.Windows.Forms.PictureBox
            cbDirectDownload = New Sublight.Controls.MyCheckBox
            lblDirectDownload = New System.Windows.Forms.Label
            lnkDevelopment = New System.Windows.Forms.LinkLabel
            txtFile = New Sublight.Controls.MyTextBox
            lblPluginFile = New System.Windows.Forms.Label
            txtDescription = New Sublight.Controls.MyTextBox
            lblPluginDescription = New System.Windows.Forms.Label
            txtName = New Sublight.Controls.MyTextBox
            lblPluginName = New System.Windows.Forms.Label
            clbPlugins = New System.Windows.Forms.CheckedListBox
            btnMoveDown = New Sublight.Controls.Button.Button
            btnMoveUp = New Sublight.Controls.Button.Button
            myPanel2.SuspendLayout()
            pictureBox4.BeginInit()
            gbSubtitleProvider.SuspendLayout()
            gbSubtitleProviderOrder.SuspendLayout()
            pbProviderLogo.BeginInit()
            SuspendLayout()
            myPanel2.Controls.Add(pictureBox4)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Right
            myPanel2.Location = New System.Drawing.Point(808, 0)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(38, 461)
            myPanel2.TabIndex = 137
            pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox4.Image = Sublight.Properties.Resources.SettingsPlugins
            pictureBox4.Location = New System.Drawing.Point(0, 0)
            pictureBox4.Name = "pictureBox4?"
            pictureBox4.Size = New System.Drawing.Size(37, 39)
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox4.TabIndex = 24
            pictureBox4.TabStop = False
            panel1.Dock = System.Windows.Forms.DockStyle.Right
            panel1.Location = New System.Drawing.Point(796, 0)
            panel1.Name = "panel1?"
            panel1.Size = New System.Drawing.Size(12, 461)
            panel1.TabIndex = 139
            myPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
            myPanel1.Location = New System.Drawing.Point(0, 456)
            myPanel1.Name = "myPanel1?"
            myPanel1.Size = New System.Drawing.Size(796, 5)
            myPanel1.TabIndex = 141
            gbSubtitleProvider.Controls.Add(rbSearchNever)
            gbSubtitleProvider.Controls.Add(rbSearchAlways)
            gbSubtitleProvider.Controls.Add(rbSearchWhenNoResultsOnPrimarySource)
            gbSubtitleProvider.Dock = System.Windows.Forms.DockStyle.Top
            gbSubtitleProvider.DrawTextBackground = True
            gbSubtitleProvider.Location = New System.Drawing.Point(0, 0)
            gbSubtitleProvider.Name = "gbSubtitleProvider?"
            gbSubtitleProvider.Size = New System.Drawing.Size(796, 94)
            gbSubtitleProvider.TabIndex = 142
            gbSubtitleProvider.TabStop = False
            gbSubtitleProvider.Text = "Podnapisi iz drugih virov?"
            rbSearchNever.AutoSize = True
            rbSearchNever.Location = New System.Drawing.Point(6, 68)
            rbSearchNever.Name = "rbSearchNever?"
            rbSearchNever.Size = New System.Drawing.Size(145, 17)
            rbSearchNever.TabIndex = 2
            rbSearchNever.Text = "Ne uporabljaj drugih virov?"
            rbSearchNever.UseVisualStyleBackColor = True
            rbSearchAlways.AutoSize = True
            rbSearchAlways.Location = New System.Drawing.Point(6, 45)
            rbSearchAlways.Name = "rbSearchAlways?"
            rbSearchAlways.Size = New System.Drawing.Size(95, 17)
            rbSearchAlways.TabIndex = 1
            rbSearchAlways.Text = "Uporabi vedno?"
            rbSearchAlways.UseVisualStyleBackColor = True
            rbSearchWhenNoResultsOnPrimarySource.AutoSize = True
            rbSearchWhenNoResultsOnPrimarySource.Checked = True
            rbSearchWhenNoResultsOnPrimarySource.Location = New System.Drawing.Point(6, 22)
            rbSearchWhenNoResultsOnPrimarySource.Name = "rbSearchWhenNoResultsOnPrimarySource?"
            rbSearchWhenNoResultsOnPrimarySource.Size = New System.Drawing.Size(224, 17)
            rbSearchWhenNoResultsOnPrimarySource.TabIndex = 0
            rbSearchWhenNoResultsOnPrimarySource.TabStop = True
            rbSearchWhenNoResultsOnPrimarySource.Text = "Uporabi, ko ni zadetkov na primarnem viru?"
            rbSearchWhenNoResultsOnPrimarySource.UseVisualStyleBackColor = True
            myPanel3.Dock = System.Windows.Forms.DockStyle.Top
            myPanel3.Location = New System.Drawing.Point(0, 94)
            myPanel3.Name = "myPanel3?"
            myPanel3.Size = New System.Drawing.Size(796, 5)
            myPanel3.TabIndex = 146
            gbSubtitleProviderOrder.Controls.Add(pbProviderLogo)
            gbSubtitleProviderOrder.Controls.Add(cbDirectDownload)
            gbSubtitleProviderOrder.Controls.Add(lblDirectDownload)
            gbSubtitleProviderOrder.Controls.Add(lnkDevelopment)
            gbSubtitleProviderOrder.Controls.Add(txtFile)
            gbSubtitleProviderOrder.Controls.Add(lblPluginFile)
            gbSubtitleProviderOrder.Controls.Add(txtDescription)
            gbSubtitleProviderOrder.Controls.Add(lblPluginDescription)
            gbSubtitleProviderOrder.Controls.Add(txtName)
            gbSubtitleProviderOrder.Controls.Add(lblPluginName)
            gbSubtitleProviderOrder.Controls.Add(clbPlugins)
            gbSubtitleProviderOrder.Controls.Add(btnMoveDown)
            gbSubtitleProviderOrder.Controls.Add(btnMoveUp)
            gbSubtitleProviderOrder.Dock = System.Windows.Forms.DockStyle.Fill
            gbSubtitleProviderOrder.DrawTextBackground = True
            gbSubtitleProviderOrder.Location = New System.Drawing.Point(0, 99)
            gbSubtitleProviderOrder.Name = "gbSubtitleProviderOrder?"
            gbSubtitleProviderOrder.Size = New System.Drawing.Size(796, 357)
            gbSubtitleProviderOrder.TabIndex = 147
            gbSubtitleProviderOrder.TabStop = False
            gbSubtitleProviderOrder.Text = "Vrstni red iskanja?"
            pbProviderLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pbProviderLogo.Location = New System.Drawing.Point(306, 275)
            pbProviderLogo.Name = "pbProviderLogo?"
            pbProviderLogo.Size = New System.Drawing.Size(37, 39)
            pbProviderLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pbProviderLogo.TabIndex = 150
            pbProviderLogo.TabStop = False
            cbDirectDownload.AutoSize = True
            cbDirectDownload.Enabled = False
            cbDirectDownload.Location = New System.Drawing.Point(420, 141)
            cbDirectDownload.Name = "cbDirectDownload?"
            cbDirectDownload.Size = New System.Drawing.Size(15, 14)
            cbDirectDownload.TabIndex = 142
            cbDirectDownload.UseVisualStyleBackColor = True
            lblDirectDownload.AutoSize = True
            lblDirectDownload.Location = New System.Drawing.Point(303, 141)
            lblDirectDownload.Name = "lblDirectDownload?"
            lblDirectDownload.Size = New System.Drawing.Size(81, 13)
            lblDirectDownload.TabIndex = 149
            lblDirectDownload.Text = "Direktni prenos:?"
            lnkDevelopment.Dock = System.Windows.Forms.DockStyle.Bottom
            lnkDevelopment.Location = New System.Drawing.Point(291, 317)
            lnkDevelopment.Name = "lnkDevelopment?"
            lnkDevelopment.Size = New System.Drawing.Size(502, 37)
            lnkDevelopment.TabIndex = 148
            lnkDevelopment.TabStop = True
            lnkDevelopment.Text = "Želite narediti lasten vticnik??"
            lnkDevelopment.TextAlign = System.Drawing.ContentAlignment.BottomRight
            AddHandler lnkDevelopment.LinkClicked, AddressOf lnkDevelopment_LinkClicked
            txtFile.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtFile.EnableDisableColor = True
            txtFile.Location = New System.Drawing.Point(420, 239)
            txtFile.Name = "txtFile?"
            txtFile.ReadOnly = True
            txtFile.Size = New System.Drawing.Size(210, 20)
            txtFile.TabIndex = 144
            lblPluginFile.AutoSize = True
            lblPluginFile.Location = New System.Drawing.Point(303, 242)
            lblPluginFile.Name = "lblPluginFile?"
            lblPluginFile.Size = New System.Drawing.Size(54, 13)
            lblPluginFile.TabIndex = 144
            lblPluginFile.Text = "Datoteka:?"
            txtDescription.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtDescription.EnableDisableColor = True
            txtDescription.Location = New System.Drawing.Point(420, 164)
            txtDescription.Multiline = True
            txtDescription.Name = "txtDescription?"
            txtDescription.ReadOnly = True
            txtDescription.Size = New System.Drawing.Size(210, 69)
            txtDescription.TabIndex = 143
            lblPluginDescription.AutoSize = True
            lblPluginDescription.Location = New System.Drawing.Point(303, 167)
            lblPluginDescription.Name = "lblPluginDescription?"
            lblPluginDescription.Size = New System.Drawing.Size(31, 13)
            lblPluginDescription.TabIndex = 142
            lblPluginDescription.Text = "Opis:?"
            txtName.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtName.EnableDisableColor = True
            txtName.Location = New System.Drawing.Point(420, 112)
            txtName.Name = "txtName?"
            txtName.ReadOnly = True
            txtName.Size = New System.Drawing.Size(210, 20)
            txtName.TabIndex = 141
            lblPluginName.AutoSize = True
            lblPluginName.Location = New System.Drawing.Point(303, 115)
            lblPluginName.Name = "lblPluginName?"
            lblPluginName.Size = New System.Drawing.Size(27, 13)
            lblPluginName.TabIndex = 140
            lblPluginName.Text = "Ime:?"
            clbPlugins.Dock = System.Windows.Forms.DockStyle.Left
            clbPlugins.FormattingEnabled = True
            clbPlugins.IntegralHeight = False
            clbPlugins.Location = New System.Drawing.Point(3, 16)
            clbPlugins.Name = "clbPlugins?"
            clbPlugins.Size = New System.Drawing.Size(288, 338)
            clbPlugins.TabIndex = 139
            AddHandler clbPlugins.SelectedIndexChanged, AddressOf clbPlugins_SelectedIndexChanged
            btnMoveDown.AutoResize = False
            btnMoveDown.BackColor = System.Drawing.Color.Transparent
            btnMoveDown.DialogResult = System.Windows.Forms.DialogResult.None
            btnMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnMoveDown.Location = New System.Drawing.Point(303, 51)
            btnMoveDown.Name = "btnMoveDown?"
            btnMoveDown.Size = New System.Drawing.Size(75, 23)
            btnMoveDown.TabIndex = 138
            btnMoveDown.Text = "Premakni dol?"
            btnMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnMoveDown.Click, AddressOf btnMoveDown_Click
            btnMoveUp.AutoResize = False
            btnMoveUp.BackColor = System.Drawing.Color.Transparent
            btnMoveUp.DialogResult = System.Windows.Forms.DialogResult.None
            btnMoveUp.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnMoveUp.Location = New System.Drawing.Point(303, 19)
            btnMoveUp.Name = "btnMoveUp?"
            btnMoveUp.Size = New System.Drawing.Size(75, 23)
            btnMoveUp.TabIndex = 137
            btnMoveUp.Text = "Premakni gor?"
            btnMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnMoveUp.Click, AddressOf btnMoveUp_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(gbSubtitleProviderOrder)
            Controls.Add(myPanel3)
            Controls.Add(gbSubtitleProvider)
            Controls.Add(myPanel1)
            Controls.Add(panel1)
            Controls.Add(myPanel2)
            Name = "SettingsPlugins?"
            Size = New System.Drawing.Size(846, 461)
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            pictureBox4.EndInit()
            gbSubtitleProvider.ResumeLayout(False)
            gbSubtitleProvider.PerformLayout()
            gbSubtitleProviderOrder.ResumeLayout(False)
            gbSubtitleProviderOrder.PerformLayout()
            pbProviderLogo.EndInit()
            ResumeLayout(False)
        End Sub

        Private Sub lnkDevelopment_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
            ParentBaseForm.OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl("Article/4/How-to-develop-Sublight-plugin.aspx?"))
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
                error = Nothing
                If Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseAlways Then
                    rbSearchAlways.Checked = True
                ElseIf Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseNewer Then
                    rbSearchNever.Checked = True
                Else 
                    rbSearchWhenNoResultsOnPrimarySource.Checked = True
                End If
                FillPlugins()
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
                If rbSearchWhenNoResultsOnPrimarySource.Checked Then
                    Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseWhenNoHitsOnPrimaryProvider
                ElseIf rbSearchAlways.Checked Then
                    Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseAlways
                ElseIf rbSearchNever.Checked Then
                    Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseNewer
                End If
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim i1 As Integer = 0
                While i1 < clbPlugins.Items.Count
                    If clbPlugins.GetItemChecked(i1) Then
                        stringBuilder1.AppendFormat("{0}; ?", clbPlugins.Items(i1))
                    End If
                    i1 = i1 + 1
                End While
                Sublight.Properties.Settings.Default.Plugins_SubtitleProviderOrder = stringBuilder1.ToString().Trim()
                FillPlugins()
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub Translate()
            MyBase.Translate()
            gbSubtitleProvider.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider
            rbSearchWhenNoResultsOnPrimarySource.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider_SearchWhenNoResultsOnPrimarySource
            rbSearchAlways.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider_SearchAlways
            rbSearchNever.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider_SearchNewer
            gbSubtitleProviderOrder.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProviderOrder
            btnMoveUp.Text = Sublight.Translation.Common_Button_MoveUp
            btnMoveDown.Text = Sublight.Translation.Common_Button_MoveDown
            lblPluginName.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider_Name
            lblPluginDescription.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider_Description
            lblPluginFile.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider_File
            lnkDevelopment.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider_DevelopYourOwnPlugin
            lblDirectDownload.Text = Sublight.Translation.Settings_Panel_Plugins_SubtitleProvider_DirectDownload
            Dim buttonArr1 As Sublight.Controls.Button.Button() = New Sublight.Controls.Button.Button() { _
                                                                                                          btnMoveUp, _
                                                                                                          btnMoveDown }
            Sublight.Controls.Button.Button.MakeSameWidth(buttonArr1)
        End Sub

    End Class ' class SettingsPlugins

End Namespace

