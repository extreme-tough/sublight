Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight

    Public Class FrmSubtitleReport
        Inherits Sublight.BaseForm

        Private ReadOnly m_subtitleId As System.Guid 

        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private cbReason As Sublight.Controls.MyComboBox 
        Private components As System.ComponentModel.IContainer 
        Private lblComment As System.Windows.Forms.Label 
        Private lblInfo As System.Windows.Forms.Label 
        Private lblReason As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private txtComment As Sublight.Controls.MyTextBox 

        Public Sub New(ByVal subtitleId As System.Guid)
            InitializeComponent()
            m_subtitleId = subtitleId
            FillReason()
            txtComment.Enabled = False
            Text = Sublight.Translation.FrmSubtitleReport_Title
            lblInfo.Text = Sublight.Translation.FrmSubtitleReport_Info
            btnOK.Text = Sublight.Translation.Common_Button_OK
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            lblReason.Text = Sublight.Translation.FrmSubtitleReport_Field_Reason
            lblComment.Text = Sublight.Translation.FrmSubtitleReport_Field_Comment
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.None
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbReason.SelectedItem, Sublight.Types.ListItem)
            If (listItem1) Is Nothing Then
                Return
            End If
            If Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                ShowError(Sublight.Translation.FrmSubtitleReport_Error_NoReason, New object(0) {})
                Return
            End If
            Dim reportReason1 As Sublight.WS.ReportReason = DirectCast(listItem1.Value, Sublight.WS.ReportReason)
            If (reportReason1 = Sublight.WS.ReportReason.Custom) AndAlso System.String.IsNullOrEmpty(txtComment.Text.Trim()) Then
                ShowError(Sublight.Translation.FrmSubtitleReport_Error_NoComment, New object(0) {})
                Return
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                Dim s1 As String = txtComment.Text.Trim()
                sublight1.ReportSubtitle2Async(Sublight.BaseForm.Session, m_subtitleId, reportReason1, IIf(System.String.IsNullOrEmpty(s1), Nothing, s1))
            End Using
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub cbReason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            txtComment.Text = System.String.Empty
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbReason.SelectedItem, Sublight.Types.ListItem)
            If (listItem1) Is Nothing Then
                Return
            End If
            If Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                txtComment.Enabled = False
                Return
            End If
            Dim reportReason1 As Sublight.WS.ReportReason = DirectCast(listItem1.Value, Sublight.WS.ReportReason)
            If reportReason1 = Sublight.WS.ReportReason.Custom Then
                txtComment.Enabled = True
                Return
            End If
            txtComment.Enabled = False
        End Sub

        Private Sub FillReason()
            cbReason.Items.Clear()
            Dim reportReasonArr1 As Sublight.WS.ReportReason() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.ReportReason)), Sublight.WS.ReportReason[])
            If Not (reportReasonArr1) Is Nothing Then
                Dim reportReasonArr2 As Sublight.WS.ReportReason() = reportReasonArr1
                Dim i1 As Integer = 0
                While i1 < reportReasonArr2.Length
                    Dim reportReason1 As Sublight.WS.ReportReason = CType(reportReasonArr2(i1), Sublight.WS.ReportReason)
                    cbReason.Items.Add(New Sublight.Types.ListItem(Sublight.Globals.GetString(System.String.Format("Common_SubtitleReportReason_Status_{0}?", reportReason1)), reportReason1))
                    i1 = i1 + 1
                End While
            End If
            Sublight.Globals.BindNotSelected(cbReason, True)
        End Sub

        Private Sub InitializeComponent()
            btnOK = New Sublight.Controls.Button.Button
            btnCancel = New Sublight.Controls.Button.Button
            niceLine1 = New Sublight.Controls.NiceLine
            lblInfo = New System.Windows.Forms.Label
            txtComment = New Sublight.Controls.MyTextBox
            lblReason = New System.Windows.Forms.Label
            lblComment = New System.Windows.Forms.Label
            cbReason = New Sublight.Controls.MyComboBox
            SuspendLayout()
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            btnOK.Location = New System.Drawing.Point(176, 175)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 16
            btnOK.Text = "V redu?"
            btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnOK.Click, AddressOf btnOK_Click
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(257, 175)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 17
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            niceLine1.Location = New System.Drawing.Point(12, 159)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(320, 15)
            niceLine1.TabIndex = 15
            lblInfo.Location = New System.Drawing.Point(12, 9)
            lblInfo.Name = "lblInfo?"
            lblInfo.Size = New System.Drawing.Size(320, 32)
            lblInfo.TabIndex = 14
            lblInfo.Text = "Prosimo, ce izberete ali vpišete razlog za prijavo podnapisa.?"
            txtComment.Location = New System.Drawing.Point(73, 68)
            txtComment.Multiline = True
            txtComment.Name = "txtComment?"
            txtComment.Size = New System.Drawing.Size(259, 85)
            txtComment.TabIndex = 19
            lblReason.AutoSize = True
            lblReason.Location = New System.Drawing.Point(12, 44)
            lblReason.Name = "lblReason?"
            lblReason.Size = New System.Drawing.Size(43, 13)
            lblReason.TabIndex = 20
            lblReason.Text = "Razlog:?"
            lblComment.AutoSize = True
            lblComment.Location = New System.Drawing.Point(12, 71)
            lblComment.Name = "lblComment?"
            lblComment.Size = New System.Drawing.Size(55, 13)
            lblComment.TabIndex = 21
            lblComment.Text = "Komentar:?"
            cbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbReason.FormattingEnabled = True
            cbReason.Location = New System.Drawing.Point(73, 44)
            cbReason.Name = "cbReason?"
            cbReason.Size = New System.Drawing.Size(259, 21)
            cbReason.TabIndex = 22
            AddHandler cbReason.SelectedIndexChanged, AddressOf cbReason_SelectedIndexChanged
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(345, 209)
            Controls.Add(cbReason)
            Controls.Add(lblComment)
            Controls.Add(lblReason)
            Controls.Add(txtComment)
            Controls.Add(btnOK)
            Controls.Add(btnCancel)
            Controls.Add(niceLine1)
            Controls.Add(lblInfo)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmSubtitleReport?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Prijava podnapisa?"
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmSubtitleReport

End Namespace

