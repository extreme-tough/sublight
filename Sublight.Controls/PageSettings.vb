Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Elegant.Ui
Imports Sublight
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Friend Class PageSettings
        Inherits Sublight.Controls.BasePage

        Private ReadOnly m_parent As Sublight.BaseForm 

        Private _btnReload As Elegant.Ui.Button 
        Private _btnReset As Elegant.Ui.Button 
        Private _btnSave As Elegant.Ui.Button 
        Private _btnWizard As Elegant.Ui.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblCaption As System.Windows.Forms.Label 
        Private m_isInitialized As Boolean 
        Private panelContent As Sublight.Controls.MyPanel 
        Private panelTop As Sublight.Controls.MyPanel 
        Private splitContainer1 As System.Windows.Forms.SplitContainer 
        Private tvSettings As System.Windows.Forms.TreeView 

        Friend Shared ShellKeyName As String 

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal rtp As Elegant.Ui.RibbonTabPage)
            m_parent = parent
            InitializeComponent()
            _btnSave = TryCast(GetTabControlByName("btnSettingsSave?"), Elegant.Ui.Button)
            If (_btnSave) Is Nothing Then
                Throw New System.NullReferenceException("btnSettingsSave?")
            End If
            AddHandler _btnSave.Click, AddressOf btnApply_Click
            _btnReload = TryCast(GetTabControlByName("btnSettingsReload?"), Elegant.Ui.Button)
            If (_btnReload) Is Nothing Then
                Throw New System.NullReferenceException("btnSettingsReload?")
            End If
            AddHandler _btnReload.Click, AddressOf btnReload_Click
            _btnReset = TryCast(GetTabControlByName("btnSettingsReset?"), Elegant.Ui.Button)
            If (_btnReset) Is Nothing Then
                Throw New System.NullReferenceException("btnSettingsReset?")
            End If
            AddHandler _btnReset.Click, AddressOf btnReset_Click
            _btnWizard = TryCast(GetTabControlByName("btnSettingsWizard?"), Elegant.Ui.Button)
            If (_btnWizard) Is Nothing Then
                Throw New System.NullReferenceException("btnSettingsWizard?")
            End If
            AddHandler _btnWizard.Click, AddressOf btnWizard_Click
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Shared Sub New()
            Sublight.Controls.PageSettings.ShellKeyName = "SubtitlesClient?"
        End Sub

        Protected Sub AddSetting(ByVal settings As Sublight.Controls.BaseSettings)
            If (settings) Is Nothing Then
                Return
            End If
            Dim s1 As String = settings.GetType().Name
            tvSettings.Nodes.Add(s1, settings.Title)
            panelContent.SuspendLayout()
            settings.SuspendLayout()
            settings.Dock = System.Windows.Forms.DockStyle.Fill
            panelContent.Controls.Add(settings)
            settings.ResumeLayout(True)
            panelContent.ResumeLayout(True)
            tvSettings.Nodes(s1).Tag = settings
        End Sub

        Private Sub ApplySettings(ByVal showSummary As Boolean)
            Dim s1 As String

            Dim list1 As System.Collections.Generic.List(Of Sublight.FrmSaveSettings.ListElement) = New System.Collections.Generic.List(Of Sublight.FrmSaveSettings.ListElement)
            Dim treeNode1 As System.Windows.Forms.TreeNode 
            For Each treeNode1 In tvSettings.Nodes
                Dim baseSettings1 As Sublight.Controls.BaseSettings = TryCast(treeNode1.Tag, Sublight.Controls.BaseSettings)
                If Not (baseSettings1) Is Nothing Then
                    Dim flag1 As Boolean = baseSettings1.SaveSettings(False, out s1)
                    If flag1 Then
                        s1 = Sublight.Translation.Settings_SaveResults_Success
                    End If
                    list1.Add(New Sublight.FrmSaveSettings.ListElement(baseSettings1.Title, s1, Not flag1))
                End If
            Next
            Dim flag2 As Boolean = ParentBaseForm.SaveUserSettings()
            Sublight.Globals.Events.OnSettingsLoaded()
            If showSummary AndAlso flag2 Then
                Dim frmSaveSettings1 As Sublight.FrmSaveSettings = New Sublight.FrmSaveSettings(list1.ToArray())
                frmSaveSettings1.ShowDialog(Me)
                frmSaveSettings1.Dispose()
            End If
        End Sub

        Private Sub btnApply_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ApplySettings(True)
        End Sub

        Private Sub btnReload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If ParentBaseForm.ShowQuestion(Sublight.Translation.Settings_Question_ReloadSettings, New object(0) {}) = System.Windows.Forms.DialogResult.Yes Then
                LoadSettings()
            End If
        End Sub

        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If ParentBaseForm.ShowQuestion(Sublight.Translation.Settings_Question_ResetSettings, New object(0) {}) = System.Windows.Forms.DialogResult.Yes Then
                Dim treeNode1 As System.Windows.Forms.TreeNode 
                For Each treeNode1 In tvSettings.Nodes
                    Dim baseSettings1 As Sublight.Controls.BaseSettings = TryCast(treeNode1.Tag, Sublight.Controls.BaseSettings)
                    If Not (baseSettings1) Is Nothing Then
                        baseSettings1.OnBeforeReset()
                    End If
                Next
                Dim guid1 As System.Guid = Sublight.Properties.Settings.Default.UserId
                Sublight.Properties.Settings.Default.Reset()
                Dim treeNode2 As System.Windows.Forms.TreeNode 
                For Each treeNode2 In tvSettings.Nodes
                    Dim baseSettings2 As Sublight.Controls.BaseSettings = TryCast(treeNode2.Tag, Sublight.Controls.BaseSettings)
                    If Not (baseSettings2) Is Nothing Then
                        baseSettings2.OnAfterReset()
                    End If
                Next
                Sublight.Properties.Settings.Default.UserId = guid1
                Sublight.Properties.Settings.Default.AskRegisterShellMenu = False
                Sublight.Globals.SetAllSubtitleLanguages()
                LoadSettings()
                ApplySettings(True)
            End If
        End Sub

        Private Sub btnWizard_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim frmWizardSettings1 As Sublight.FrmWizardSettings = New Sublight.FrmWizardSettings(Sublight.Globals.MainForm, False)
            frmWizardSettings1.ShowDialog(Me)
            frmWizardSettings1.Dispose()
            LoadSettings()
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            TranslateControls(False)
        End Sub

        Private Sub InitializeComponent()
            splitContainer1 = New System.Windows.Forms.SplitContainer
            tvSettings = New System.Windows.Forms.TreeView
            panelContent = New Sublight.Controls.MyPanel
            panelTop = New Sublight.Controls.MyPanel
            lblCaption = New System.Windows.Forms.Label
            splitContainer1.Panel1.SuspendLayout()
            splitContainer1.Panel2.SuspendLayout()
            splitContainer1.SuspendLayout()
            panelTop.SuspendLayout()
            SuspendLayout()
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
            splitContainer1.Location = New System.Drawing.Point(0, 0)
            splitContainer1.Name = "splitContainer1?"
            splitContainer1.Panel1.Controls.Add(tvSettings)
            splitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(5, 5, 0, 5)
            splitContainer1.Panel2.Controls.Add(panelContent)
            splitContainer1.Panel2.Controls.Add(panelTop)
            splitContainer1.Size = New System.Drawing.Size(900, 319)
            splitContainer1.SplitterDistance = 270
            splitContainer1.TabIndex = 110
            tvSettings.Dock = System.Windows.Forms.DockStyle.Fill
            tvSettings.HideSelection = False
            tvSettings.Location = New System.Drawing.Point(5, 5)
            tvSettings.Name = "tvSettings?"
            tvSettings.Size = New System.Drawing.Size(265, 309)
            tvSettings.TabIndex = 110
            AddHandler tvSettings.AfterSelect, AddressOf tvSettings_AfterSelect
            panelContent.AutoScroll = True
            panelContent.Dock = System.Windows.Forms.DockStyle.Fill
            panelContent.Location = New System.Drawing.Point(0, 34)
            panelContent.Name = "panelContent?"
            panelContent.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
            panelContent.Size = New System.Drawing.Size(626, 285)
            panelContent.TabIndex = 109
            panelTop.Controls.Add(lblCaption)
            panelTop.Dock = System.Windows.Forms.DockStyle.Top
            panelTop.Location = New System.Drawing.Point(0, 0)
            panelTop.Name = "panelTop?"
            panelTop.Padding = New System.Windows.Forms.Padding(0, 5, 5, 5)
            panelTop.Size = New System.Drawing.Size(626, 34)
            panelTop.TabIndex = 108
            lblCaption.BackColor = System.Drawing.Color.FromArgb(51, 153, 255)
            lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            lblCaption.Dock = System.Windows.Forms.DockStyle.Fill
            lblCaption.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblCaption.ForeColor = System.Drawing.Color.White
            lblCaption.Location = New System.Drawing.Point(0, 5)
            lblCaption.Name = "lblCaption?"
            lblCaption.Size = New System.Drawing.Size(621, 24)
            lblCaption.TabIndex = 0
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(splitContainer1)
            Name = "PageSettings?"
            Size = New System.Drawing.Size(900, 319)
            splitContainer1.Panel1.ResumeLayout(False)
            splitContainer1.Panel2.ResumeLayout(False)
            splitContainer1.ResumeLayout(False)
            panelTop.ResumeLayout(False)
            ResumeLayout(False)
        End Sub

        Private Sub LoadSettings()
            Dim s1 As String

            Dim flag1 As Boolean = False
            Try
                Dim treeNode1 As System.Windows.Forms.TreeNode 
                For Each treeNode1 In tvSettings.Nodes
                    Dim baseSettings1 As Sublight.Controls.BaseSettings = TryCast(treeNode1.Tag, Sublight.Controls.BaseSettings)
                    If (Not (baseSettings1) Is Nothing) AndAlso Not baseSettings1.LoadSettings(out s1) Then
                        flag1 = True
                    End If
                Next
                If tvSettings.Nodes.Count > 0 Then
                    tvSettings.SelectedNode = tvSettings.Nodes(0)
                End If
                Sublight.Globals.Events.OnSettingsLoaded()
            Catch 
                flag1 = True
            End Try
        End Sub

        Private Sub TranslateControls(ByVal forceTranslation As Boolean)
            Dim treeNode1 As System.Windows.Forms.TreeNode 
            For Each treeNode1 In tvSettings.Nodes
                Dim baseSettings1 As Sublight.Controls.BaseSettings = TryCast(treeNode1.Tag, Sublight.Controls.BaseSettings)
                If Not (baseSettings1) Is Nothing Then
                    If forceTranslation Then
                        baseSettings1.Translate()
                    End If
                    treeNode1.Text = baseSettings1.Title
                    If tvSettings.SelectedNode = treeNode1 Then
                        lblCaption.Text = baseSettings1.Title
                    End If
                End If
            Next
            _btnReload.Text = Sublight.Translation.Settings_Toolbar_ReloadSettings
            _btnSave.Text = Sublight.Translation.Settings_Toolbar_SaveAndApplyChanges
            _btnReset.Text = Sublight.Translation.Settings_Toolbar_ResetSettings
            _btnWizard.Text = Sublight.Translation.Settings_Toolbar_Wizard
        End Sub

        Private Sub tvSettings_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
            Dim baseSettings1 As Sublight.Controls.BaseSettings 
            For Each baseSettings1 In panelContent.Controls
                baseSettings1.Visible = False
            Next
            Dim baseSettings2 As Sublight.Controls.BaseSettings = TryCast(e.Node.Tag, Sublight.Controls.BaseSettings)
            If (baseSettings2) Is Nothing Then
                Return
            End If
            lblCaption.Text = baseSettings2.Title
            baseSettings2.OnDisplayed()
            Dim padding1 As System.Windows.Forms.Padding = panelContent.Padding
            lblCaption.Width = panelTop.Width - padding1.Right
            System.Windows.Forms.Application.DoEvents()
            baseSettings2.Visible = True
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Sub OnDisplayed()
            MyBase.OnDisplayed()
            If Not m_isInitialized Then
                Try
                    m_isInitialized = True
                    ParentBaseForm.ShowLoader(Me)
                    SuspendLayout()
                    tvSettings.SuspendLayout()
                    tvSettings.BeginUpdate()
                    tvSettings.Nodes.Clear()
                    AddSetting(New Sublight.Controls.SettingsExternalVideoApp(m_parent))
                    AddSetting(New Sublight.Controls.SettingsSubtitleDownloadFolder(m_parent))
                    AddSetting(New Sublight.Controls.SettingsSystemIntegration(m_parent))
                    AddSetting(New Sublight.Controls.SettingsUI(m_parent))
                    AddSetting(New Sublight.Controls.SettingsLanguages(m_parent))
                    If Sublight.Globals.EditionType <> Sublight.Types.SpecialEdition.PodnapisiNET Then
                        AddSetting(New Sublight.Controls.SettingsPlugins(m_parent))
                    End If
                    AddSetting(New Sublight.Controls.SettingsSubtitleOptions(m_parent))
                    AddSetting(New Sublight.Controls.SettingsOther(m_parent))
                    TranslateControls(True)
                    LoadSettings()
                    tvSettings.EndUpdate()
                Finally
                    tvSettings.ResumeLayout(True)
                    ResumeLayout(True)
                    ParentBaseForm.HideLoader(Me)
                End Try
            End If
            tvSettings.Select()
        End Sub

    End Class ' class PageSettings

End Namespace

