Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class SettingsUI
        Inherits Sublight.Controls.BaseSettings

        Private cbDisplayListTooltips As Sublight.Controls.MyCheckBox 
        Private cbMinimizeToTray As Sublight.Controls.MyCheckBox 
        Private cbTabSearch As Sublight.Controls.MyComboBox 
        Private cbTabView As Sublight.Controls.MyComboBox 
        Private components As System.ComponentModel.IContainer 
        Private gbDblClickAction As Sublight.Controls.MyGroupBox 
        Private label1 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private pictureBox2 As System.Windows.Forms.PictureBox 
        Private pictureBox3 As System.Windows.Forms.PictureBox 

        Public Overrides ReadOnly Property Title As String
            Get
                Return Sublight.Translation.Settings_Panel_SettingsUI
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm)
            InitializeComponent()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            FillDblClickComboboxes()
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <FillDblClickComboboxes>b__0()
            cbTabSearch.Items.Clear()
            cbTabSearch.Items.Add(New Sublight.Types.ListItem(Sublight.Translation.Settings_Panel_SettingsUI_SubtitleDoubleClickAction_DownloadAndPlay, 0))
            cbTabSearch.Items.Add(New Sublight.Types.ListItem(Sublight.Translation.Settings_Panel_SettingsUI_SubtitleDoubleClickAction_Download, 1))
            cbTabSearch.Items.Add(New Sublight.Types.ListItem(Sublight.Translation.Settings_Panel_SettingsUI_SubtitleDoubleClickAction_Details, 2))
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <FillDblClickComboboxes>b__1()
            cbTabView.Items.Clear()
            cbTabView.Items.Add(New Sublight.Types.ListItem(Sublight.Translation.Settings_Panel_SettingsUI_SubtitleDoubleClickAction_Download, 1))
            cbTabView.Items.Add(New Sublight.Types.ListItem(Sublight.Translation.Settings_Panel_SettingsUI_SubtitleDoubleClickAction_Details, 2))
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            MyBase.Translate()
        End Sub

        Private Sub FillDblClickComboboxes()
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<FillDblClickComboboxes>b__0)
            Sublight.BaseForm.DoCtrlInvoke(cbTabSearch, Me, methodInvoker1)
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<FillDblClickComboboxes>b__1)
            Sublight.BaseForm.DoCtrlInvoke(cbTabView, Me, methodInvoker2)
        End Sub

        Private Sub InitializeComponent()
            cbDisplayListTooltips = New Sublight.Controls.MyCheckBox
            myPanel2 = New Sublight.Controls.MyPanel
            pictureBox2 = New System.Windows.Forms.PictureBox
            cbMinimizeToTray = New Sublight.Controls.MyCheckBox
            pictureBox3 = New System.Windows.Forms.PictureBox
            pictureBox1 = New System.Windows.Forms.PictureBox
            gbDblClickAction = New Sublight.Controls.MyGroupBox
            label1 = New System.Windows.Forms.Label
            cbTabSearch = New Sublight.Controls.MyComboBox
            cbTabView = New Sublight.Controls.MyComboBox
            label2 = New System.Windows.Forms.Label
            myPanel2.SuspendLayout()
            pictureBox2.BeginInit()
            pictureBox3.BeginInit()
            pictureBox1.BeginInit()
            gbDblClickAction.SuspendLayout()
            SuspendLayout()
            cbDisplayListTooltips.Id = "6373d59e-ae1e-43fa-8179-f9449c31848a?"
            cbDisplayListTooltips.Location = New System.Drawing.Point(649, 289)
            cbDisplayListTooltips.Name = "cbDisplayListTooltips?"
            cbDisplayListTooltips.Size = New System.Drawing.Size(187, 26)
            cbDisplayListTooltips.TabIndex = 24
            cbDisplayListTooltips.Text = "RES: Prikaži sliko filma v seznamu?"
            cbDisplayListTooltips.UseVisualStyleBackColor = True
            cbDisplayListTooltips.Visible = False
            myPanel2.Controls.Add(pictureBox2)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Right
            myPanel2.Location = New System.Drawing.Point(860, 0)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(38, 412)
            myPanel2.TabIndex = 137
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox2.Image = Sublight.Properties.Resources.SettingsUI
            pictureBox2.Location = New System.Drawing.Point(0, 0)
            pictureBox2.Name = "pictureBox2?"
            pictureBox2.Size = New System.Drawing.Size(37, 39)
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox2.TabIndex = 24
            pictureBox2.TabStop = False
            cbMinimizeToTray.Id = "a0168606-b0d0-4215-9fe7-62bb1322a221?"
            cbMinimizeToTray.Location = New System.Drawing.Point(13, 12)
            cbMinimizeToTray.Name = "cbMinimizeToTray?"
            cbMinimizeToTray.Size = New System.Drawing.Size(225, 26)
            cbMinimizeToTray.TabIndex = 138
            cbMinimizeToTray.Text = "Minimiraj aplikacijo v podrocje za obvestila?"
            cbMinimizeToTray.UseVisualStyleBackColor = True
            pictureBox3.Image = Sublight.Properties.Resources.MinimizeToTray
            pictureBox3.Location = New System.Drawing.Point(29, 44)
            pictureBox3.Name = "pictureBox3?"
            pictureBox3.Size = New System.Drawing.Size(181, 40)
            pictureBox3.TabIndex = 139
            pictureBox3.TabStop = False
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox1.Image = Sublight.Properties.Resources.UISettings_DisplayTooltips
            pictureBox1.Location = New System.Drawing.Point(667, 312)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(169, 86)
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox1.TabIndex = 25
            pictureBox1.TabStop = False
            pictureBox1.Visible = False
            gbDblClickAction.Controls.Add(cbTabView)
            gbDblClickAction.Controls.Add(label2)
            gbDblClickAction.Controls.Add(cbTabSearch)
            gbDblClickAction.Controls.Add(label1)
            gbDblClickAction.DrawTextBackground = True
            gbDblClickAction.Location = New System.Drawing.Point(13, 105)
            gbDblClickAction.Name = "gbDblClickAction?"
            gbDblClickAction.Size = New System.Drawing.Size(659, 100)
            gbDblClickAction.TabIndex = 140
            gbDblClickAction.TabStop = False
            gbDblClickAction.Text = "???Double click action?"
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(28, 29)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(80, 13)
            label1.TabIndex = 142
            label1.Text = "???Search tab:?"
            cbTabSearch.DrawMode = System.Windows.Forms.DrawMode.Normal
            cbTabSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbTabSearch.DroppedDown = False
            cbTabSearch.Editable = False
            cbTabSearch.FormatInfo = Nothing
            cbTabSearch.FormatString = "?"
            cbTabSearch.FormattingEnabled = False
            cbTabSearch.Id = "8d4553cf-9014-40a7-b8c2-1caf17afaf94?"
            cbTabSearch.ItemHeight = 22
            cbTabSearch.LabelText = "?"
            cbTabSearch.Location = New System.Drawing.Point(122, 25)
            cbTabSearch.Name = "cbTabSearch?"
            cbTabSearch.Size = New System.Drawing.Size(204, 21)
            cbTabSearch.Sorted = False
            cbTabSearch.TabIndex = 143
            cbTabSearch.TextEditorWidth = 185
            cbTabView.DrawMode = System.Windows.Forms.DrawMode.Normal
            cbTabView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbTabView.DroppedDown = False
            cbTabView.Editable = False
            cbTabView.FormatInfo = Nothing
            cbTabView.FormatString = "?"
            cbTabView.FormattingEnabled = False
            cbTabView.Id = "f99ec4e5-ec44-4da7-8d31-e1430d79f111?"
            cbTabView.ItemHeight = 22
            cbTabView.LabelText = "?"
            cbTabView.Location = New System.Drawing.Point(122, 56)
            cbTabView.Name = "cbTabView?"
            cbTabView.Size = New System.Drawing.Size(204, 21)
            cbTabView.Sorted = False
            cbTabView.TabIndex = 145
            cbTabView.TextEditorWidth = 185
            label2.AutoSize = True
            label2.Location = New System.Drawing.Point(28, 60)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(69, 13)
            label2.TabIndex = 144
            label2.Text = "???View tab:?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(gbDblClickAction)
            Controls.Add(pictureBox3)
            Controls.Add(cbMinimizeToTray)
            Controls.Add(myPanel2)
            Controls.Add(pictureBox1)
            Controls.Add(cbDisplayListTooltips)
            Name = "SettingsUI?"
            Size = New System.Drawing.Size(898, 412)
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            pictureBox2.EndInit()
            pictureBox3.EndInit()
            pictureBox1.EndInit()
            gbDblClickAction.ResumeLayout(False)
            gbDblClickAction.PerformLayout()
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
                error = Nothing
                cbDisplayListTooltips.Checked = Sublight.Properties.Settings.Default.List_DisplayTooltips
                cbMinimizeToTray.Checked = Sublight.Properties.Settings.Default.App_MinimizeToTray
                Sublight.Types.ListItem.Select(cbTabSearch, Sublight.Properties.Settings.Default.Search_DblClickAction)
                If Sublight.Properties.Settings.Default.View_DblClickAction <> Sublight.Types.SubtitleDblClickAction.DownloadSubtitleAndPlay Then
                    Sublight.Types.ListItem.Select(cbTabView, Sublight.Properties.Settings.Default.View_DblClickAction)
                Else 
                    Sublight.Types.ListItem.Select(cbTabView, 2)
                End If
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            gbDblClickAction.Width = myPanel2.Left - gbDblClickAction.Left
        End Sub

        Public Overrides Function SaveSettings(ByVal quietMode As Boolean, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                Sublight.Properties.Settings.Default.List_DisplayTooltips = cbDisplayListTooltips.Checked
                Sublight.Properties.Settings.Default.App_MinimizeToTray = cbMinimizeToTray.Checked
                Dim listItem1 As Sublight.Types.ListItem = TryCast(cbTabSearch.SelectedItem, Sublight.Types.ListItem)
                If Not (listItem1) Is Nothing Then
                    Sublight.Properties.Settings.Default.Search_DblClickAction = DirectCast(listItem1.Value, Sublight.Types.SubtitleDblClickAction)
                End If
                listItem1 = TryCast(cbTabView.SelectedItem, Sublight.Types.ListItem)
                If Not (listItem1) Is Nothing Then
                    Sublight.Properties.Settings.Default.View_DblClickAction = DirectCast(listItem1.Value, Sublight.Types.SubtitleDblClickAction)
                End If
                error = Nothing
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub Translate()
            Dim i3 As Integer

            MyBase.Translate()
            cbMinimizeToTray.Text = Sublight.Translation.Settings_Panel_SettingsUI_MinimizeToTray
            gbDblClickAction.Text = Sublight.Translation.Settings_Panel_SettingsUI_SubtitleDoubleClickAction
            label1.Text = Sublight.Translation.Settings_Panel_SettingsUI_SubtitleDoubleClickAction_Search
            label2.Text = Sublight.Translation.Settings_Panel_SettingsUI_SubtitleDoubleClickAction_View
            Dim i1 As Integer = label1.Right + 14
            Dim i2 As Integer = label2.Right + 14
            If i1 > i2 Then
                i3 = i1
            Else 
                i3 = i2
            End If
            cbTabSearch.Left = i3
            cbTabView.Left = i3
        End Sub

    End Class ' class SettingsUI

End Namespace

