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

    Public Class SettingsLanguages
        Inherits Sublight.Controls.BaseSettings

        Private btnDeselectAll As Sublight.Controls.Button.Button 
        Private btnSelectAll As Sublight.Controls.Button.Button 
        Private cbLanguage As System.Windows.Forms.CheckedListBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private myPanel1 As Sublight.Controls.MyPanel 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private pictureBox4 As System.Windows.Forms.PictureBox 

        Public Overrides ReadOnly Property Title As String
            Get
                Return Sublight.Translation.Settings_Languages
            End Get
        End Property

        Friend Sub New()
        End Sub

        Public Sub New(ByVal parent As Sublight.BaseForm)
            InitializeComponent()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
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

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            MyBase.Translate()
        End Sub

        Private Sub FillLanguages()
            Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = Sublight.WS.SubtitleLanguage.Unknown
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbLanguage.SelectedItem, Sublight.Types.ListItem)
            If (Not (listItem1) Is Nothing) AndAlso (Not (listItem1.Value) Is Nothing) AndAlso (TypeOf listItem1.Value Is Sublight.WS.SubtitleLanguage) Then
                subtitleLanguage1 = DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage)
            End If
            cbLanguage.Items.Clear()
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = Sublight.MyUtility.LanguageUtil.GetSortedAllLanguages()
            Dim subtitleLanguageArr2 As Sublight.WS.SubtitleLanguage() = subtitleLanguageArr1
            Dim i2 As Integer = 0
            While i2 < subtitleLanguageArr2.Length
                Dim subtitleLanguage2 As Sublight.WS.SubtitleLanguage = CType(subtitleLanguageArr2(i2), Sublight.WS.SubtitleLanguage)
                If subtitleLanguage2 <> Sublight.WS.SubtitleLanguage.Unknown Then
                    Dim s1 As String = Sublight.Globals.GetString(subtitleLanguage2)
                    If Not System.String.IsNullOrEmpty(s1) Then
                        cbLanguage.Items.Add(New Sublight.Types.ListItem(s1, subtitleLanguage2))
                    End If
                End If
                i2 = i2 + 1
            End While
            If subtitleLanguage1 <> Sublight.WS.SubtitleLanguage.Unknown Then
                Dim i1 As Integer = 0
                While i1 < cbLanguage.Items.Count
                    Dim listItem2 As Sublight.Types.ListItem = TryCast(cbLanguage.Items(i1), Sublight.Types.ListItem)
                    If Not (listItem2) Is Nothing Then
                        Dim subtitleLanguage3 As Sublight.WS.SubtitleLanguage = DirectCast(listItem2.Value, Sublight.WS.SubtitleLanguage)
                        If subtitleLanguage3 = subtitleLanguage1 Then
                            cbLanguage.SelectedIndex = i1
                            Return
                        End If
                    End If
                    i1 = i1 + 1
                End While
            End If
        End Sub

        Private Sub InitializeComponent()
            myPanel1 = New Sublight.Controls.MyPanel
            btnSelectAll = New Sublight.Controls.Button.Button
            btnDeselectAll = New Sublight.Controls.Button.Button
            myPanel2 = New Sublight.Controls.MyPanel
            pictureBox4 = New System.Windows.Forms.PictureBox
            label1 = New System.Windows.Forms.Label
            cbLanguage = New System.Windows.Forms.CheckedListBox
            myPanel2.SuspendLayout()
            pictureBox4.BeginInit()
            SuspendLayout()
            myPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
            myPanel1.Location = New System.Drawing.Point(0, 398)
            myPanel1.Name = "myPanel1?"
            myPanel1.Size = New System.Drawing.Size(717, 5)
            myPanel1.TabIndex = 28
            btnSelectAll.BackColor = System.Drawing.Color.Transparent
            btnSelectAll.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnSelectAll.Location = New System.Drawing.Point(294, 30)
            btnSelectAll.Name = "btnSelectAll?"
            btnSelectAll.Size = New System.Drawing.Size(105, 23)
            btnSelectAll.TabIndex = 133
            btnSelectAll.Text = "Izberi vse?"
            btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelectAll.Click, AddressOf btnSelectAll_Click
            btnDeselectAll.BackColor = System.Drawing.Color.Transparent
            btnDeselectAll.DialogResult = System.Windows.Forms.DialogResult.None
            btnDeselectAll.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnDeselectAll.Location = New System.Drawing.Point(294, 60)
            btnDeselectAll.Name = "btnDeselectAll?"
            btnDeselectAll.Size = New System.Drawing.Size(105, 23)
            btnDeselectAll.TabIndex = 134
            btnDeselectAll.Text = "Odstrani vse?"
            btnDeselectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnDeselectAll.Click, AddressOf btnDeselectAll_Click
            myPanel2.Controls.Add(pictureBox4)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Right
            myPanel2.Location = New System.Drawing.Point(679, 0)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(38, 398)
            myPanel2.TabIndex = 136
            pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox4.Image = Sublight.Properties.Resources.SettingsLanguage
            pictureBox4.Location = New System.Drawing.Point(0, 0)
            pictureBox4.Name = "pictureBox4?"
            pictureBox4.Size = New System.Drawing.Size(37, 39)
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox4.TabIndex = 24
            pictureBox4.TabStop = False
            label1.Dock = System.Windows.Forms.DockStyle.Top
            label1.Location = New System.Drawing.Point(0, 0)
            label1.Name = "label1?"
            label1.Padding = New System.Windows.Forms.Padding(0, 5, 5, 5)
            label1.Size = New System.Drawing.Size(679, 30)
            label1.TabIndex = 137
            label1.Text = "Prikaz jezikov (iskanje podnapisov, objava podnapisov, komentiranje podnapisov):?"
            cbLanguage.Dock = System.Windows.Forms.DockStyle.Left
            cbLanguage.FormattingEnabled = True
            cbLanguage.IntegralHeight = False
            cbLanguage.Location = New System.Drawing.Point(0, 30)
            cbLanguage.Name = "cbLanguage?"
            cbLanguage.Size = New System.Drawing.Size(288, 368)
            cbLanguage.TabIndex = 138
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(cbLanguage)
            Controls.Add(label1)
            Controls.Add(myPanel2)
            Controls.Add(btnDeselectAll)
            Controls.Add(btnSelectAll)
            Controls.Add(myPanel1)
            Name = "SettingsLanguages?"
            Size = New System.Drawing.Size(717, 403)
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            pictureBox4.EndInit()
            ResumeLayout(False)
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
                Dim i1 As Integer = 0
                While i1 < cbLanguage.Items.Count
                    cbLanguage.SetItemChecked(i1, False)
                    i1 = i1 + 1
                End While
                If Not (Sublight.Properties.Settings.Default.Application_Filter_Language) Is Nothing Then
                    Dim enumerator1 As System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage).Enumerator = Sublight.Properties.Settings.Default.Application_Filter_Language.GetEnumerator()
                    Try
                        While enumerator1.MoveNext()
                            Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(enumerator1.get_Current(), Sublight.WS.SubtitleLanguage)
                            Dim i2 As Integer = 0
                            While i2 < cbLanguage.Items.Count
                                Dim listItem1 As Sublight.Types.ListItem = CType(cbLanguage.Items(i2), Sublight.Types.ListItem)
                                Dim subtitleLanguage2 As Sublight.WS.SubtitleLanguage = DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage)
                                If subtitleLanguage2 = subtitleLanguage1 Then
                                    cbLanguage.SetItemChecked(i2, True)
                                    Exit While
                                End If
                                i2 = i2 + 1
                            End While
                        End While
                        GoTo label_1
                    Finally
                        enumerator1.Dispose()
                    End Try
                End If
                Dim i3 As Integer = 0
                While i3 < cbLanguage.Items.Count
                    cbLanguage.SetItemChecked(i3, True)
                    i3 = i3 + 1
                End While
            label_1: _
                flag1 = True
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Function SaveSettings(ByVal quietMode As Boolean, ByRef error As String) As Boolean
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
                    error = Sublight.Translation.Search_Warning_NoLanguageSelected
                    Return False
                End If
                Sublight.Properties.Settings.Default.Application_Filter_Language = subtitleLanguageCollection1
                error = Nothing
                flag2 = True
            Catch e As System.Exception
                error = e.Message
                flag2 = False
            End Try
            Return flag2
        End Function

        Public Overrides Sub Translate()
            MyBase.Translate()
            Dim subtitleLanguageCollection1 As Sublight.Types.SubtitleLanguageCollection = New Sublight.Types.SubtitleLanguageCollection
            Dim i1 As Integer = 0
            While i1 < cbLanguage.Items.Count
                If cbLanguage.GetItemChecked(i1) Then
                    subtitleLanguageCollection1.Add(DirectCast(CType(cbLanguage.Items(i1), Sublight.Types.ListItem).Value, Sublight.WS.SubtitleLanguage))
                End If
                i1 = i1 + 1
            End While
            FillLanguages()
            Dim i2 As Integer = 0
            While i2 < cbLanguage.Items.Count
                Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = DirectCast(CType(cbLanguage.Items(i2), Sublight.Types.ListItem).Value, Sublight.WS.SubtitleLanguage)
                Dim enumerator1 As System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage).Enumerator = subtitleLanguageCollection1.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim subtitleLanguage2 As Sublight.WS.SubtitleLanguage = CType(enumerator1.get_Current(), Sublight.WS.SubtitleLanguage)
                        If subtitleLanguage1 = subtitleLanguage2 Then
                            cbLanguage.SetItemChecked(i2, True)
                            Exit While
                        End If
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
                i2 = i2 + 1
            End While
            label1.Text = Sublight.Translation.Settings_Languages_Description
            btnSelectAll.Text = Sublight.Translation.Common_Button_SelectAll
            btnDeselectAll.Text = Sublight.Translation.Common_Button_RemoveAll
            Dim buttonArr1 As Sublight.Controls.Button.Button() = New Sublight.Controls.Button.Button() { _
                                                                                                          btnSelectAll, _
                                                                                                          btnDeselectAll }
            Sublight.Controls.Button.Button.MakeSameWidth(buttonArr1)
        End Sub

    End Class ' class SettingsLanguages

End Namespace

