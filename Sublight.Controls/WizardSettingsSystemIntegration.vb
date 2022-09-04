Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.MyUtility.Explorer
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class WizardSettingsSystemIntegration
        Inherits Sublight.Controls.BaseWizard

        Private btnDeselectAll As Sublight.Controls.Button.Button 
        Private btnSelectAll As Sublight.Controls.Button.Button 
        Private cbBatchDownload As Sublight.Controls.MyCheckBox 
        Private cbExt As System.Windows.Forms.CheckedListBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private myPanel1 As Sublight.Controls.MyPanel 
        Private myPanel2 As Sublight.Controls.MyPanel 

        Public Overrides ReadOnly Property HeaderText As String
            Get
                Return Sublight.Translation.Settings_Wizard_SystemIntegration_Title
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
            If Not (Sublight.Globals.VideoExtensions) Is Nothing Then
                Dim sArr1 As String() = Sublight.Globals.VideoExtensions
                Dim i1 As Integer = 0
                While i1 < sArr1.Length
                    Dim s1 As String = sArr1(i1)
                    cbExt.Items.Add(New Sublight.Types.ListItem(System.String.Format(".{0}?", s1), s1))
                    i1 = i1 + 1
                End While
            End If
            SetCheckBoxes()
            cbBatchDownload_CheckedChanged(Me, Nothing)
        End Sub

        Private Sub btnDeselectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i1 As Integer = 0
            While i1 < cbExt.Items.Count
                cbExt.SetItemChecked(i1, False)
                i1 = i1 + 1
            End While
        End Sub

        Private Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i1 As Integer = 0
            While i1 < cbExt.Items.Count
                cbExt.SetItemChecked(i1, True)
                i1 = i1 + 1
            End While
        End Sub

        Private Sub cbBatchDownload_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            cbExt.Enabled = cbBatchDownload.Checked
            label1.Enabled = cbBatchDownload.Checked
            btnSelectAll.Enabled = cbBatchDownload.Checked
            btnDeselectAll.Enabled = cbBatchDownload.Checked
        End Sub

        Private Sub InitializeComponent()
            myPanel1 = New Sublight.Controls.MyPanel
            myPanel2 = New Sublight.Controls.MyPanel
            cbExt = New System.Windows.Forms.CheckedListBox
            label1 = New System.Windows.Forms.Label
            cbBatchDownload = New Sublight.Controls.MyCheckBox
            btnDeselectAll = New Sublight.Controls.Button.Button
            btnSelectAll = New Sublight.Controls.Button.Button
            SuspendLayout()
            myPanel1.Dock = System.Windows.Forms.DockStyle.Top
            myPanel1.Location = New System.Drawing.Point(0, 0)
            myPanel1.Name = "myPanel1?"
            myPanel1.Size = New System.Drawing.Size(799, 3)
            myPanel1.TabIndex = 0
            myPanel2.Dock = System.Windows.Forms.DockStyle.Left
            myPanel2.Location = New System.Drawing.Point(0, 3)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(3, 454)
            myPanel2.TabIndex = 1
            cbExt.Dock = System.Windows.Forms.DockStyle.Left
            cbExt.FormattingEnabled = True
            cbExt.IntegralHeight = False
            cbExt.Location = New System.Drawing.Point(3, 68)
            cbExt.Name = "cbExt?"
            cbExt.Size = New System.Drawing.Size(111, 389)
            cbExt.TabIndex = 176
            label1.Dock = System.Windows.Forms.DockStyle.Top
            label1.Location = New System.Drawing.Point(3, 29)
            label1.Name = "label1?"
            label1.Padding = New System.Windows.Forms.Padding(0, 15, 5, 5)
            label1.Size = New System.Drawing.Size(796, 39)
            label1.TabIndex = 175
            label1.Text = "Prikaži bližnjico za prenos podnapisov v Raziskovalcu?"
            cbBatchDownload.Checked = True
            cbBatchDownload.CheckState = System.Windows.Forms.CheckState.Checked
            cbBatchDownload.Dock = System.Windows.Forms.DockStyle.Top
            cbBatchDownload.Id = "2d55c737-138f-490c-8abb-c12e7e962906?"
            cbBatchDownload.Location = New System.Drawing.Point(3, 3)
            cbBatchDownload.Name = "cbBatchDownload?"
            cbBatchDownload.Size = New System.Drawing.Size(796, 26)
            cbBatchDownload.TabIndex = 174
            cbBatchDownload.Text = "Omogoci ""Batch download...""?"
            cbBatchDownload.UseVisualStyleBackColor = True
            AddHandler cbBatchDownload.CheckedChanged, AddressOf cbBatchDownload_CheckedChanged
            btnDeselectAll.AutoResize = False
            btnDeselectAll.BackColor = System.Drawing.SystemColors.Control
            btnDeselectAll.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnDeselectAll.Id = "b8fdeae8-b485-4906-af57-adbf9495d121?"
            btnDeselectAll.Image = Nothing
            btnDeselectAll.Location = New System.Drawing.Point(122, 100)
            btnDeselectAll.Name = "btnDeselectAll?"
            btnDeselectAll.Size = New System.Drawing.Size(120, 23)
            btnDeselectAll.TabIndex = 173
            btnDeselectAll.Text = "Odstrani vse?"
            btnDeselectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnDeselectAll.UseVisualStyleBackColor = True
            AddHandler btnDeselectAll.Click, AddressOf btnDeselectAll_Click
            btnSelectAll.AutoResize = False
            btnSelectAll.BackColor = System.Drawing.SystemColors.Control
            btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnSelectAll.Id = "17aeb117-bdc1-404f-90c4-7108a6f6369a?"
            btnSelectAll.Image = Nothing
            btnSelectAll.Location = New System.Drawing.Point(122, 68)
            btnSelectAll.Name = "btnSelectAll?"
            btnSelectAll.Size = New System.Drawing.Size(120, 23)
            btnSelectAll.TabIndex = 172
            btnSelectAll.Text = "Izberi vse?"
            btnSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnSelectAll.UseVisualStyleBackColor = True
            AddHandler btnSelectAll.Click, AddressOf btnSelectAll_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(cbExt)
            Controls.Add(label1)
            Controls.Add(cbBatchDownload)
            Controls.Add(btnDeselectAll)
            Controls.Add(btnSelectAll)
            Controls.Add(myPanel2)
            Controls.Add(myPanel1)
            Name = "WizardSettingsSystemIntegration?"
            Size = New System.Drawing.Size(799, 457)
            ResumeLayout(False)
        End Sub

        Private Sub SetCheckBoxes()
            Dim i1 As Integer = 0
            While i1 < cbExt.Items.Count
                Dim listItem1 As Sublight.Types.ListItem = CType(cbExt.Items(i1), Sublight.Types.ListItem)
                Try
                    Dim s1 As String = TryCast(listItem1.Value, string)
                    If System.String.IsNullOrEmpty(s1) Then
                        GoTo label_1
                    End If
                    If Sublight.MyUtility.Explorer.ContextMenu.IsRegistered(System.String.Format(".{0}?", s1), "Sublight?") Then
                        cbExt.SetItemChecked(i1, True)
                    Else 
                        cbExt.SetItemChecked(i1, False)
                    End If
                Catch e As System.Exception
                    cbExt.SetItemChecked(i1, False)
                End Try
            label_1: _
                i1 = i1 + 1
            End While
            cbBatchDownload.Checked = False
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Function Finalize(ByRef msg As String) As Boolean
            Dim flag1 As Boolean

            Try
                If (System.Diagnostics.Process.GetCurrentProcess().MainModule) Is Nothing Then
                    Throw New System.Exception("Could not get instance of MainModule.?")
                End If
                Dim s1 As String = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
                If Not (Sublight.Globals.VideoExtensions) Is Nothing Then
                    Dim sArr1 As String() = Sublight.Globals.VideoExtensions
                    Dim i2 As Integer = 0
                    While i2 < sArr1.Length
                        Dim s2 As String = sArr1(i2)
                        Try
                            Sublight.MyUtility.Explorer.ContextMenu.Unregister(System.String.Format(".{0}?", s2), "SubtitlesClient?")
                        Catch e As System.Exception
                        End Try
                        i2 = i2 + 1
                    End While
                End If
                Dim i1 As Integer = 0
                While i1 < cbExt.Items.Count
                    Dim listItem1 As Sublight.Types.ListItem = TryCast(cbExt.Items(i1), Sublight.Types.ListItem)
                    If Not (listItem1) Is Nothing Then
                        Dim s3 As String = TryCast(listItem1.Value, string)
                        If Not System.String.IsNullOrEmpty(s3) Then
                            Try
                                If cbExt.GetItemChecked(i1) Then
                                    Sublight.MyUtility.Explorer.ContextMenu.Register(System.String.Format(".{0}?", s3), "Sublight?", Sublight.Translation.WindowsExplorer_ContextMenu_FindSubtitles, System.String.Format("""{0}"" file=""%L""?", s1))
                                Else 
                                    Sublight.MyUtility.Explorer.ContextMenu.Unregister(System.String.Format(".{0}?", s3), "Sublight?")
                                End If
                            Catch 
                            End Try
                        End If
                    End If
                    i1 = i1 + 1
                End While
                If cbBatchDownload.Checked Then
                    Sublight.MyUtility.Explorer.ContextMenu.RegisterFolder("Sublight?", Sublight.Translation.WindowsExplorer_ContextMenu_BatchDownload, System.String.Format("""{0}"" /batch folder=""%L""?", s1))
                Else 
                    Sublight.MyUtility.Explorer.ContextMenu.UnregisterFolder("Sublight?")
                End If
                msg = Nothing
                flag1 = True
            Catch e As System.Exception
                msg = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub Translate()
            MyBase.Translate()
            btnSelectAll.Text = Sublight.Translation.Common_Button_SelectAll
            btnDeselectAll.Text = Sublight.Translation.Common_Button_RemoveAll
            label1.Text = Sublight.Translation.Settings_Panel_ExplorerIntegration_ContextMenu
            cbBatchDownload.Text = Sublight.Translation.Settings_Panel_ExplorerIntegration_BatchDownload
        End Sub

    End Class ' class WizardSettingsSystemIntegration

End Namespace

