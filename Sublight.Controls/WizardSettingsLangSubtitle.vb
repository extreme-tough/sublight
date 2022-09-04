Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight.Controls

    Public Class WizardSettingsLangSubtitle
        Inherits Sublight.Controls.BaseWizard

        Private btnDeselectAll As Sublight.Controls.Button.Button 
        Private btnSelectAll As Sublight.Controls.Button.Button 
        Private cbLanguage As System.Windows.Forms.CheckedListBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 

        Public Overrides ReadOnly Property HeaderText As String
            Get
                Return Sublight.Translation.Settings_Wizard_LanguageSubtitle_Title
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        End Sub

        Private Sub btnDeselectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i1 As Integer = 0
            While i1 < cbLanguage.Items.Count
                cbLanguage.SetItemChecked(i1, False)
                i1 = i1 + 1
            End While
        End Sub

        Private Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i1 As Integer = 0
            While i1 < cbLanguage.Items.Count
                cbLanguage.SetItemChecked(i1, True)
                i1 = i1 + 1
            End While
        End Sub

        Private Sub FillLanguages()
            Dim i1 As Integer = cbLanguage.SelectedIndex
            cbLanguage.Items.Clear()
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = Sublight.MyUtility.LanguageUtil.GetSortedAllLanguages()
            Dim subtitleLanguageArr2 As Sublight.WS.SubtitleLanguage() = subtitleLanguageArr1
            Dim i2 As Integer = 0
            While i2 < subtitleLanguageArr2.Length
                Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(subtitleLanguageArr2(i2), Sublight.WS.SubtitleLanguage)
                If subtitleLanguage1 <> Sublight.WS.SubtitleLanguage.Unknown Then
                    Dim s1 As String = Sublight.Globals.GetString(subtitleLanguage1)
                    If Not System.String.IsNullOrEmpty(s1) Then
                        cbLanguage.Items.Add(New Sublight.Types.ListItem(s1, subtitleLanguage1))
                    End If
                End If
                i2 = i2 + 1
            End While
            If i1 >= 0 Then
                cbLanguage.SelectedIndex = i1
            End If
        End Sub

        Private Sub InitializeComponent()
            cbLanguage = New System.Windows.Forms.CheckedListBox
            label1 = New System.Windows.Forms.Label
            btnDeselectAll = New Sublight.Controls.Button.Button
            btnSelectAll = New Sublight.Controls.Button.Button
            SuspendLayout()
            cbLanguage.Dock = System.Windows.Forms.DockStyle.Left
            cbLanguage.FormattingEnabled = True
            cbLanguage.IntegralHeight = False
            cbLanguage.Location = New System.Drawing.Point(0, 0)
            cbLanguage.Name = "cbLanguage?"
            cbLanguage.Size = New System.Drawing.Size(288, 376)
            cbLanguage.TabIndex = 142
            label1.Dock = System.Windows.Forms.DockStyle.Top
            label1.Location = New System.Drawing.Point(0, 0)
            label1.Name = "label1?"
            label1.Padding = New System.Windows.Forms.Padding(0, 5, 5, 5)
            label1.Size = New System.Drawing.Size(710, 0)
            label1.TabIndex = 141
            label1.Text = "Prikaz jezikov (iskanje podnapisov, objava podnapisov, komentiranje podnapisov):?"
            label1.Visible = False
            btnDeselectAll.BackColor = System.Drawing.Color.Transparent
            btnDeselectAll.DialogResult = System.Windows.Forms.DialogResult.None
            btnDeselectAll.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnDeselectAll.Location = New System.Drawing.Point(294, 31)
            btnDeselectAll.Name = "btnDeselectAll?"
            btnDeselectAll.Size = New System.Drawing.Size(120, 23)
            btnDeselectAll.TabIndex = 140
            btnDeselectAll.Text = "Odstrani vse?"
            btnDeselectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnDeselectAll.Click, AddressOf btnDeselectAll_Click
            btnSelectAll.BackColor = System.Drawing.Color.Transparent
            btnSelectAll.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnSelectAll.Location = New System.Drawing.Point(294, 1)
            btnSelectAll.Name = "btnSelectAll?"
            btnSelectAll.Size = New System.Drawing.Size(120, 23)
            btnSelectAll.TabIndex = 139
            btnSelectAll.Text = "Izberi vse?"
            btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelectAll.Click, AddressOf btnSelectAll_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(cbLanguage)
            Controls.Add(label1)
            Controls.Add(btnDeselectAll)
            Controls.Add(btnSelectAll)
            Name = "WizardSettingsLangSubtitle?"
            Size = New System.Drawing.Size(710, 376)
            ResumeLayout(False)
        End Sub

        Private Sub SelectLanguages()
            If Not (Sublight.Properties.Settings.Default.Application_Filter_Language) Is Nothing Then
                Dim enumerator1 As System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage).Enumerator = Sublight.Properties.Settings.Default.Application_Filter_Language.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(enumerator1.get_Current(), Sublight.WS.SubtitleLanguage)
                        Dim i1 As Integer = 0
                        While i1 < cbLanguage.Items.Count
                            Dim listItem1 As Sublight.Types.ListItem = CType(cbLanguage.Items(i1), Sublight.Types.ListItem)
                            Dim subtitleLanguage2 As Sublight.WS.SubtitleLanguage = DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage)
                            If subtitleLanguage2 = subtitleLanguage1 Then
                                cbLanguage.SetItemChecked(i1, True)
                                Exit While
                            End If
                            i1 = i1 + 1
                        End While
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Function Finalize(ByRef msg As String) As Boolean
            Dim flag2 As Boolean

            Try
                Dim subtitleLanguageCollection1 As Sublight.Types.SubtitleLanguageCollection = New Sublight.Types.SubtitleLanguageCollection
                Dim flag1 As Boolean = False
                Dim i1 As Integer = 0
                While i1 < cbLanguage.Items.Count
                    If cbLanguage.GetItemChecked(i1) Then
                        flag1 = True
                        subtitleLanguageCollection1.Add(DirectCast(CType(cbLanguage.Items(i1), Sublight.Types.ListItem).Value, Sublight.WS.SubtitleLanguage))
                    End If
                    i1 = i1 + 1
                End While
                If Not flag1 Then
                    msg = "Subtitle language not selected.?"
                    Return False
                End If
                Sublight.Properties.Settings.Default.Application_Filter_Language = subtitleLanguageCollection1
                Sublight.Properties.Settings.Default.Search_Filter_Language = subtitleLanguageCollection1
                msg = Nothing
                flag2 = True
            Catch e As System.Exception
                msg = e.Message
                flag2 = False
            End Try
            Return flag2
        End Function

        Public Overrides Function IsStepValid(ByRef msg As String) As Boolean
            msg = Nothing
            Dim i1 As Integer = 0
            While i1 < cbLanguage.Items.Count
                If cbLanguage.GetItemChecked(i1) Then
                    Return True
                End If
                i1 = i1 + 1
            End While
            msg = Sublight.Translation.Settings_Wizard_LanguageSubtitle_Warning_NoLanguageSelected
            Return False
        End Function

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            FillLanguages()
            SelectLanguages()
        End Sub

        Public Overrides Sub Translate()
            MyBase.Translate()
            btnSelectAll.Text = Sublight.Translation.Common_Button_SelectAll
            btnDeselectAll.Text = Sublight.Translation.Common_Button_RemoveAll
            Dim listItem1 As Sublight.Types.ListItem 
            For Each listItem1 In cbLanguage.Items
                Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage)
                listItem1.Text = Sublight.Globals.GetString(subtitleLanguage1)
            Next
        End Sub

    End Class ' class WizardSettingsLangSubtitle

End Namespace

