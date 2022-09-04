Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmAddAlternativeTitle
        Inherits Sublight.BaseForm

        Private ReadOnly m_subtitleId As System.Guid 

        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private cbLanguage As Sublight.Controls.MyComboBox 
        Private components As System.ComponentModel.IContainer 
        Private lblAlternativeTitle As System.Windows.Forms.Label 
        Private lblLanguage As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private txtTitle As Sublight.Controls.MyTextBox 

        Public ReadOnly Property AlternativeTitle As String
            Get
                Return txtTitle.Text
            End Get
        End Property

        Public Sub New(ByVal subtitleId As System.Guid)
            InitializeComponent()
            m_subtitleId = subtitleId
            FillLanguages()
            btnOK.Text = Sublight.Translation.Common_Button_OK
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            Text = Sublight.Translation.FrmAddAlternativeTitle_Title
            lblAlternativeTitle.Text = Sublight.Translation.FrmAddAlternativeTitle_Field_AlternativeTitle
            lblLanguage.Text = Sublight.Translation.FrmAddAlternativeTitle_Field_AlternativeTitleLanguage
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            If System.String.IsNullOrEmpty(txtTitle.Text) OrElse (txtTitle.Text.Trim().Length <= 0) Then
                ShowError(Sublight.Translation.FrmAddAlternativeTitle_Error_NoTitle, New object(0) {})
                Return
            End If
            If Sublight.Types.ListItem.IsNotSelected(TryCast(cbLanguage.SelectedItem, Sublight.Types.ListItem)) Then
                ShowError(Sublight.Translation.FrmAddAlternativeTitle_Error_LanguageNotSelected, New object(0) {})
                Return
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                If Not sublight1.AddAlternativeTitle(Sublight.BaseForm.Session, m_subtitleId, txtTitle.Text, DirectCast(TryCast(cbLanguage.SelectedItem, Sublight.Types.ListItem).Value, Sublight.WS.SubtitleLanguage), out s1) Then
                    ShowError(System.String.Format(Sublight.Translation.Application_WS_Error, s1), New object(0) {})
                    Return
                End If
            End Using
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub FillLanguages()
            cbLanguage.Items.Clear()
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = Sublight.MyUtility.LanguageUtil.GetSortedLanguages()
            Dim subtitleLanguageArr2 As Sublight.WS.SubtitleLanguage() = subtitleLanguageArr1
            Dim i1 As Integer = 0
            While i1 < subtitleLanguageArr2.Length
                Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(subtitleLanguageArr2(i1), Sublight.WS.SubtitleLanguage)
                If subtitleLanguage1 <> Sublight.WS.SubtitleLanguage.Unknown Then
                    Dim s1 As String = Sublight.Globals.GetString(subtitleLanguage1)
                    If Not System.String.IsNullOrEmpty(s1) Then
                        cbLanguage.Items.Add(New Sublight.Types.ListItem(s1, subtitleLanguage1))
                    End If
                End If
                i1 = i1 + 1
            End While
            Sublight.Globals.BindNotSelected(cbLanguage, True)
        End Sub

        Private Sub FrmAddAlternativeTitle_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub FrmAddAlternativeTitle_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            txtTitle.Select()
        End Sub

        Private Sub InitializeComponent()
            btnCancel = New Sublight.Controls.Button.Button
            btnOK = New Sublight.Controls.Button.Button
            lblAlternativeTitle = New System.Windows.Forms.Label
            txtTitle = New Sublight.Controls.MyTextBox
            cbLanguage = New Sublight.Controls.MyComboBox
            lblLanguage = New System.Windows.Forms.Label
            niceLine1 = New Sublight.Controls.NiceLine
            SuspendLayout()
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(331, 76)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 9
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnOK.DialogResult = System.Windows.Forms.DialogResult.None
            btnOK.Location = New System.Drawing.Point(250, 76)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 8
            btnOK.Text = "V redu?"
            btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnOK.Click, AddressOf btnOK_Click
            lblAlternativeTitle.Location = New System.Drawing.Point(12, 9)
            lblAlternativeTitle.Name = "lblAlternativeTitle?"
            lblAlternativeTitle.Size = New System.Drawing.Size(112, 21)
            lblAlternativeTitle.TabIndex = 128
            lblAlternativeTitle.Text = "Alternativni naslov:?"
            lblAlternativeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            txtTitle.Location = New System.Drawing.Point(130, 9)
            txtTitle.Name = "txtTitle?"
            txtTitle.Size = New System.Drawing.Size(276, 20)
            txtTitle.TabIndex = 125
            cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbLanguage.FormattingEnabled = True
            cbLanguage.Location = New System.Drawing.Point(130, 35)
            cbLanguage.Name = "cbLanguage?"
            cbLanguage.Size = New System.Drawing.Size(276, 21)
            cbLanguage.TabIndex = 126
            lblLanguage.Location = New System.Drawing.Point(12, 34)
            lblLanguage.Name = "lblLanguage?"
            lblLanguage.Size = New System.Drawing.Size(112, 21)
            lblLanguage.TabIndex = 127
            lblLanguage.Text = "Jezik naslova:?"
            lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            niceLine1.Location = New System.Drawing.Point(12, 58)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(394, 15)
            niceLine1.TabIndex = 139
            AcceptButton = btnOK
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            CancelButton = btnCancel
            ClientSize = New System.Drawing.Size(422, 114)
            Controls.Add(niceLine1)
            Controls.Add(lblAlternativeTitle)
            Controls.Add(txtTitle)
            Controls.Add(cbLanguage)
            Controls.Add(lblLanguage)
            Controls.Add(btnCancel)
            Controls.Add(btnOK)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            KeyPreview = True
            Name = "FrmAddAlternativeTitle?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Dodajanje alternativnega naslova?"
            AddHandler Load, AddressOf FrmAddAlternativeTitle_Load
            AddHandler KeyUp, AddressOf FrmAddAlternativeTitle_KeyUp
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmAddAlternativeTitle

End Namespace

