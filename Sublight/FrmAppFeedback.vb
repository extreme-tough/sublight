Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS_SublightClient

Namespace Sublight

    Public Class FrmAppFeedback
        Inherits Sublight.BaseForm

        Private ReadOnly _message As String 

        Private _applyErrorHandlingSettingCalled As Boolean 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnSubmit As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private label3 As System.Windows.Forms.Label 
        Private lblHeader As System.Windows.Forms.Label 
        Private lblUserComment As System.Windows.Forms.Label 
        Private rbDisplayDialog As Sublight.Controls.MyRadioButton 
        Private rbDisplayDialogAfterOneDay As Sublight.Controls.MyRadioButton 
        Private rbDisplayDialogAfterOneWeek As Sublight.Controls.MyRadioButton 
        Private rbDoNotDisplayDialog As Sublight.Controls.MyRadioButton 
        Private rbErrorNoticableNo As Sublight.Controls.MyRadioButton 
        Private rbErrorNoticableYes As Sublight.Controls.MyRadioButton 
        Private txtReportDetails As Sublight.Controls.MyTextBox 
        Private txtUserComment As Sublight.Controls.MyTextBox 

        Public Sub New(ByVal message As String, ByVal reportDetails As String)
            InitializeComponent()
            Text = Sublight.Translation.FrmReportError_Title
            btnSubmit.Text = Sublight.Translation.Common_Button_Send
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            lblHeader.Text = Sublight.Translation.FrmReportError_Header
            lblUserComment.Text = Sublight.Translation.FrmReportError_UserComment
            label1.Text = Sublight.Translation.FrmReportError_WasErrorNoticable
            rbErrorNoticableYes.Text = Sublight.Translation.Common_Yes
            rbErrorNoticableNo.Text = Sublight.Translation.Common_No
            label2.Text = Sublight.Translation.FrmReportError_ReportDetails
            label3.Text = Sublight.Translation.FrmReportError_HowToHandleFutureErrors
            rbDisplayDialog.Text = Sublight.Translation.FrmReportError_HowToHandleFutureErrors_DisplayDialog
            rbDisplayDialogAfterOneDay.Text = Sublight.Translation.FrmReportError_HowToHandleFutureErrors_DisplayDialogAfterOneDay
            rbDisplayDialogAfterOneWeek.Text = Sublight.Translation.FrmReportError_HowToHandleFutureErrors_DisplayDialogAfterOneWeek
            rbDoNotDisplayDialog.Text = Sublight.Translation.FrmReportError_HowToHandleFutureErrors_DoNotDisplayDialog
            _message = message
            txtReportDetails.Text = reportDetails
        End Sub

        Private Sub ApplyErrorHandlingSetting(ByVal isCancel As Boolean)
            Dim errorHandling1 As Sublight.Types.ErrorHandling

            If _applyErrorHandlingSettingCalled Then
                Return
            End If
            _applyErrorHandlingSettingCalled = True
            If rbDisplayDialog.Checked Then
                errorHandling1 = Sublight.Types.ErrorHandling.DisplayDialog
            ElseIf rbDisplayDialogAfterOneDay.Checked Then
                errorHandling1 = Sublight.Types.ErrorHandling.DisplayDialogAfterOneDay
            ElseIf rbDisplayDialogAfterOneWeek.Checked Then
                errorHandling1 = Sublight.Types.ErrorHandling.DisplayDialogAfterOneWeek
            ElseIf rbDoNotDisplayDialog.Checked Then
                errorHandling1 = Sublight.Types.ErrorHandling.DoNotDisplayDialog
            Else 
                errorHandling1 = Sublight.Types.ErrorHandling.DisplayDialog
            End If
            If Sublight.Properties.Settings.Default.App_ErrorHandling <> errorHandling1 Then
                If isCancel AndAlso (ShowQuestion(Sublight.Translation.FrmReportError_Question_ApplyNewSettings, New object(0) {}) = System.Windows.Forms.DialogResult.No) Then
                    Return
                End If
                Sublight.Properties.Settings.Default.App_ErrorHandling = errorHandling1
                Sublight.BaseForm.SaveUserSettingsSilent()
            End If
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ApplyErrorHandlingSetting(True)
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim nullable1 As System.Nullable(Of Boolean)

            ApplyErrorHandlingSetting(False)
            Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                If rbErrorNoticableYes.Checked Then
                    nullable1 = New System.Nullable(Of Boolean)(1)
                ElseIf rbErrorNoticableNo.Checked Then
                    nullable1 = New System.Nullable(Of Boolean)(0)
                Else 
                    nullable1 = New System.Nullable(Of Boolean)[]
                End If
                Dim i1 As Integer = _message.GetHashCode()
                sublightClient1.ReportError2Async(Sublight.Properties.Settings.Default.UserId, Sublight.BaseForm.Session, i1.ToString(), Sublight.BaseForm.ClientInfo, txtUserComment.Text, nullable1, _message)
            End Using
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub FrmAppFeedback_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            rbDisplayDialog.Checked = False
            rbDisplayDialogAfterOneDay.Checked = False
            rbDisplayDialogAfterOneWeek.Checked = False
            rbDoNotDisplayDialog.Checked = False
            If Sublight.Properties.Settings.Default.App_ErrorHandling = Sublight.Types.ErrorHandling.DisplayDialog Then
                rbDisplayDialog.Checked = True
                Return
            End If
            If Sublight.Properties.Settings.Default.App_ErrorHandling = Sublight.Types.ErrorHandling.DisplayDialogAfterOneDay Then
                rbDisplayDialogAfterOneDay.Checked = True
                Return
            End If
            If Sublight.Properties.Settings.Default.App_ErrorHandling = Sublight.Types.ErrorHandling.DisplayDialogAfterOneWeek Then
                rbDisplayDialogAfterOneWeek.Checked = True
                Return
            End If
            If Sublight.Properties.Settings.Default.App_ErrorHandling = Sublight.Types.ErrorHandling.DoNotDisplayDialog Then
                rbDoNotDisplayDialog.Checked = True
            End If
        End Sub

        Private Sub InitializeComponent()
            lblHeader = New System.Windows.Forms.Label
            btnCancel = New Sublight.Controls.Button.Button
            btnSubmit = New Sublight.Controls.Button.Button
            txtReportDetails = New Sublight.Controls.MyTextBox
            label2 = New System.Windows.Forms.Label
            lblUserComment = New System.Windows.Forms.Label
            txtUserComment = New Sublight.Controls.MyTextBox
            label1 = New System.Windows.Forms.Label
            rbErrorNoticableYes = New Sublight.Controls.MyRadioButton
            rbErrorNoticableNo = New Sublight.Controls.MyRadioButton
            label3 = New System.Windows.Forms.Label
            rbDisplayDialog = New Sublight.Controls.MyRadioButton
            rbDisplayDialogAfterOneDay = New Sublight.Controls.MyRadioButton
            rbDisplayDialogAfterOneWeek = New Sublight.Controls.MyRadioButton
            rbDoNotDisplayDialog = New Sublight.Controls.MyRadioButton
            SuspendLayout()
            lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblHeader.Location = New System.Drawing.Point(3, 9)
            lblHeader.Name = "lblHeader?"
            lblHeader.Size = New System.Drawing.Size(564, 44)
            lblHeader.TabIndex = 0
            lblHeader.Text = "Sublight detected error and created report that you can send to us. We will treat this report as confidential.?"
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Id = "936f881b-373e-4914-99da-2450588e4067?"
            btnCancel.Image = Nothing
            btnCancel.Location = New System.Drawing.Point(492, 537)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 1
            btnCancel.Text = "Cancel?"
            btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnCancel.UseVisualStyleBackColor = True
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnSubmit.AutoResize = False
            btnSubmit.Id = "6f737fd1-33aa-4e91-ba09-f2fa98809cd5?"
            btnSubmit.Image = Nothing
            btnSubmit.Location = New System.Drawing.Point(402, 537)
            btnSubmit.Name = "btnSubmit?"
            btnSubmit.Size = New System.Drawing.Size(75, 23)
            btnSubmit.TabIndex = 2
            btnSubmit.Text = "Submit?"
            btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnSubmit.UseVisualStyleBackColor = True
            AddHandler btnSubmit.Click, AddressOf btnSubmit_Click
            txtReportDetails.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtReportDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtReportDetails.EnableDisableColor = True
            txtReportDetails.Id = "36aed6a5-c630-4c3f-9aa9-26b105fd4a98?"
            txtReportDetails.LabelText = "LabelText?"
            txtReportDetails.Location = New System.Drawing.Point(5, 273)
            txtReportDetails.Multiline = True
            txtReportDetails.Name = "txtReportDetails?"
            txtReportDetails.ReadOnly = True
            txtReportDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
            txtReportDetails.Size = New System.Drawing.Size(561, 80)
            txtReportDetails.TabIndex = 3
            txtReportDetails.TextEditorWidth = 557
            txtReportDetails.WordWrap = False
            label2.AutoSize = True
            label2.Location = New System.Drawing.Point(3, 245)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(75, 13)
            label2.TabIndex = 4
            label2.Text = "Report details:?"
            lblUserComment.Location = New System.Drawing.Point(3, 53)
            lblUserComment.Name = "lblUserComment?"
            lblUserComment.Size = New System.Drawing.Size(564, 30)
            lblUserComment.TabIndex = 6
            lblUserComment.Text = "To help us diagnose the cause of this error and improve this software, please describe what you were doing:?"
            txtUserComment.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtUserComment.EnableDisableColor = True
            txtUserComment.Id = "413a1687-f5ac-4a5a-a459-8f711019a0e5?"
            txtUserComment.LabelText = "LabelText?"
            txtUserComment.Location = New System.Drawing.Point(6, 83)
            txtUserComment.Multiline = True
            txtUserComment.Name = "txtUserComment?"
            txtUserComment.ScrollBars = System.Windows.Forms.ScrollBars.Both
            txtUserComment.Size = New System.Drawing.Size(561, 80)
            txtUserComment.TabIndex = 7
            txtUserComment.TextEditorWidth = 555
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(2, 185)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(124, 13)
            label1.TabIndex = 8
            label1.Text = "Did you notice this error??"
            rbErrorNoticableYes.Id = "967f0e91-b264-432f-b10b-1f61729c3d3c?"
            rbErrorNoticableYes.Location = New System.Drawing.Point(18, 207)
            rbErrorNoticableYes.Name = "rbErrorNoticableYes?"
            rbErrorNoticableYes.RadioGroupName = "rgn1?"
            rbErrorNoticableYes.Size = New System.Drawing.Size(75, 26)
            rbErrorNoticableYes.TabIndex = 9
            rbErrorNoticableYes.Text = "Yes?"
            rbErrorNoticableYes.UseVisualStyleBackColor = False
            rbErrorNoticableNo.Id = "503f639e-3060-4dcc-85d7-fe139f1f9ac0?"
            rbErrorNoticableNo.Location = New System.Drawing.Point(93, 207)
            rbErrorNoticableNo.Name = "rbErrorNoticableNo?"
            rbErrorNoticableNo.RadioGroupName = "rgn1?"
            rbErrorNoticableNo.Size = New System.Drawing.Size(75, 26)
            rbErrorNoticableNo.TabIndex = 10
            rbErrorNoticableNo.Text = "No?"
            rbErrorNoticableNo.UseVisualStyleBackColor = False
            label3.AutoSize = True
            label3.Location = New System.Drawing.Point(3, 382)
            label3.Name = "label3?"
            label3.Size = New System.Drawing.Size(211, 13)
            label3.TabIndex = 11
            label3.Text = "How would you like to handle future errors??"
            rbDisplayDialog.Checked = True
            rbDisplayDialog.Id = "6d4b43f7-7836-4b5c-b0f6-e0139a387817?"
            rbDisplayDialog.Location = New System.Drawing.Point(18, 408)
            rbDisplayDialog.Name = "rbDisplayDialog?"
            rbDisplayDialog.RadioGroupName = "rgn2?"
            rbDisplayDialog.Size = New System.Drawing.Size(548, 26)
            rbDisplayDialog.TabIndex = 12
            rbDisplayDialog.Text = "Display this dialog?"
            rbDisplayDialog.UseVisualStyleBackColor = False
            rbDisplayDialogAfterOneDay.Id = "a43a039a-a900-4337-a951-0b75d9f7bd07?"
            rbDisplayDialogAfterOneDay.Location = New System.Drawing.Point(18, 434)
            rbDisplayDialogAfterOneDay.Name = "rbDisplayDialogAfterOneDay?"
            rbDisplayDialogAfterOneDay.RadioGroupName = "rgn2?"
            rbDisplayDialogAfterOneDay.Size = New System.Drawing.Size(548, 26)
            rbDisplayDialogAfterOneDay.TabIndex = 13
            rbDisplayDialogAfterOneDay.Text = "Do not display this dialog for one day?"
            rbDisplayDialogAfterOneDay.UseVisualStyleBackColor = False
            rbDisplayDialogAfterOneWeek.Id = "0c3466af-bf5f-4a5a-978d-057dcce86959?"
            rbDisplayDialogAfterOneWeek.Location = New System.Drawing.Point(18, 460)
            rbDisplayDialogAfterOneWeek.Name = "rbDisplayDialogAfterOneWeek?"
            rbDisplayDialogAfterOneWeek.RadioGroupName = "rgn2?"
            rbDisplayDialogAfterOneWeek.Size = New System.Drawing.Size(548, 26)
            rbDisplayDialogAfterOneWeek.TabIndex = 14
            rbDisplayDialogAfterOneWeek.Text = "Do not display this dialog for one week?"
            rbDisplayDialogAfterOneWeek.UseVisualStyleBackColor = False
            rbDoNotDisplayDialog.Id = "6fb1551e-5e94-474a-bd90-de91f5029506?"
            rbDoNotDisplayDialog.Location = New System.Drawing.Point(18, 486)
            rbDoNotDisplayDialog.Name = "rbDoNotDisplayDialog?"
            rbDoNotDisplayDialog.RadioGroupName = "rgn2?"
            rbDoNotDisplayDialog.Size = New System.Drawing.Size(548, 26)
            rbDoNotDisplayDialog.TabIndex = 15
            rbDoNotDisplayDialog.Text = "Do not display this dialog anymore (not recommended)?"
            rbDoNotDisplayDialog.UseVisualStyleBackColor = False
            AcceptButton = btnSubmit
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            CancelButton = btnCancel
            ClientSize = New System.Drawing.Size(576, 569)
            Controls.Add(rbDoNotDisplayDialog)
            Controls.Add(rbDisplayDialogAfterOneWeek)
            Controls.Add(rbDisplayDialogAfterOneDay)
            Controls.Add(rbDisplayDialog)
            Controls.Add(label3)
            Controls.Add(rbErrorNoticableNo)
            Controls.Add(rbErrorNoticableYes)
            Controls.Add(label1)
            Controls.Add(txtUserComment)
            Controls.Add(lblUserComment)
            Controls.Add(label2)
            Controls.Add(txtReportDetails)
            Controls.Add(btnSubmit)
            Controls.Add(btnCancel)
            Controls.Add(lblHeader)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmAppFeedback?"
            ShowIcon = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Text = "Sublight - error reporting?"
            AddHandler Load, AddressOf FrmAppFeedback_Load
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
            MyBase.OnClosing(e)
            ApplyErrorHandlingSetting(True)
        End Sub

    End Class ' class FrmAppFeedback

End Namespace

