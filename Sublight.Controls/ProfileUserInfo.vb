Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.WS
Imports Sublight.WS_SublightClient

Namespace Sublight.Controls

    Friend Class ProfileUserInfo
        Inherits Sublight.Controls.ProfileBase

        Private _contributionsLoading As Boolean 
        Private _fontContributionsInUse As System.Drawing.Font 
        Private _tabUserLogInitialized As Boolean 
        Private btnChangePassword As Sublight.Controls.Button.Button 
        Private btnContributionsRefresh As Sublight.Controls.Button.Button 
        Private btnRefresh As Sublight.Controls.Button.Button 
        Private btnUpdateEmail As Sublight.Controls.Button.Button 
        Private btnUserLogRefresh As Sublight.Controls.Button.Button 
        Private colContrAmount As System.Windows.Forms.ColumnHeader 
        Private colContrDate As System.Windows.Forms.ColumnHeader 
        Private colContrPointsCurrent As System.Windows.Forms.ColumnHeader 
        Private colContrPointsInitial As System.Windows.Forms.ColumnHeader 
        Private colContrStatus As System.Windows.Forms.ColumnHeader 
        Private colContrType As System.Windows.Forms.ColumnHeader 
        Private colContrValidTo As System.Windows.Forms.ColumnHeader 
        Private colUserLogAction As System.Windows.Forms.ColumnHeader 
        Private colUserLogComment As System.Windows.Forms.ColumnHeader 
        Private colUserLogCreated As System.Windows.Forms.ColumnHeader 
        Private colUserLogPoints As System.Windows.Forms.ColumnHeader 
        Private colUserLogUpdatedBy As System.Windows.Forms.ColumnHeader 
        Private components As System.ComponentModel.IContainer 
        Private lblAvarageRate As System.Windows.Forms.Label 
        Private lblClickToDonate As System.Windows.Forms.LinkLabel 
        Private lblDeletedSubtitlesCount As System.Windows.Forms.Label 
        Private lblEmail As System.Windows.Forms.Label 
        Private lblMyDownloads As System.Windows.Forms.Label 
        Private lblMySubtitlesDownloads As System.Windows.Forms.Label 
        Private lblPublishedSubtitlesCount As System.Windows.Forms.Label 
        Private lblRegistered As System.Windows.Forms.Label 
        Private lblStatus As System.Windows.Forms.Label 
        Private lblSubtitleEditorLanguages As System.Windows.Forms.Label 
        Private lblSubtitleThanks As System.Windows.Forms.Label 
        Private lblTotalPoints As System.Windows.Forms.Label 
        Private lblUserLogNote As System.Windows.Forms.Label 
        Private lblUsername As System.Windows.Forms.Label 
        Private lvPayments As System.Windows.Forms.ListView 
        Private lvUserLog As System.Windows.Forms.ListView 
        Private m_dataLoaded As Boolean 
        Private m_isDisplayed As Boolean 
        Private myPanel1 As Sublight.Controls.MyPanel 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private panelBottomRight As System.Windows.Forms.Panel 
        Private tabDonations As System.Windows.Forms.TabPage 
        Private tabGeneral As System.Windows.Forms.TabPage 
        Private tabStatistics As System.Windows.Forms.TabPage 
        Private tabUserLog As System.Windows.Forms.TabPage 
        Private tc As System.Windows.Forms.TabControl 
        Private txtAvarageRate As Sublight.Controls.MyTextBox 
        Private txtDeletedSubtitlesCount As Sublight.Controls.MyTextBox 
        Private txtEmail As Sublight.Controls.MyTextBox 
        Private txtMyDownloads As Sublight.Controls.MyTextBox 
        Private txtMySubtitlesDownloads As Sublight.Controls.MyTextBox 
        Private txtPublishedSubtitlesCount As Sublight.Controls.MyTextBox 
        Private txtRegistered As Sublight.Controls.MyTextBox 
        Private txtStatus As Sublight.Controls.MyTextBox 
        Private txtSubtitleThanks As Sublight.Controls.MyTextBox 
        Private txtTotalPoints As Sublight.Controls.MyTextBox 
        Private txtUsername As Sublight.Controls.MyTextBox 

        Public Sub New(ByVal baseForm As Sublight.BaseForm)
            InitializeComponent()
            lvPayments.Dock = System.Windows.Forms.DockStyle.Fill
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            AddHandler Sublight.Globals.Events.UserLogIn, AddressOf Events_UserLogIn
        End Sub

        Private Sub btnChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Using frmChangePassword1 As Sublight.FrmChangePassword = New Sublight.FrmChangePassword
                frmChangePassword1.ShowDialog(Me)
            End Using
        End Sub

        Private Sub btnContributionsRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RefreshContributions()
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            LoadUserStatistics()
        End Sub

        Private Sub btnUpdateEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            Dim sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
            Try
                If Not sublight1.UpdateEmail(Sublight.BaseForm.Session, txtEmail.Text, out s1) Then
                    ParentBaseForm.ShowError(s1, New object(0) {})
                Else 
                    ParentBaseForm.ShowInfo(Sublight.Translation.Profile_UserInfo_Info_EmailWasUpdated, New object(0) {})
                End If
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("Sublight.Controls.ProfileUserInfo.btnUpdateEmail_Click?", e1)
                ParentBaseForm.ExceptionHandlerUI(e1)
            Finally
                If Not (sublight1) Is Nothing Then
                    sublight1.Dispose()
                End If
            End Try
        End Sub

        Private Sub btnUserLogRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RefreshUserLog()
        End Sub

        Public Sub ClearUserInfo()
            m_dataLoaded = False
            txtPublishedSubtitlesCount.Text = System.String.Format("{0:#,0}?", 0)
            txtDeletedSubtitlesCount.Text = System.String.Format("{0:#,0}?", 0)
            txtAvarageRate.Text = System.String.Format("{0:#,0.00}?", 0)
            txtSubtitleThanks.Text = System.String.Format("{0:#,0}?", 0)
            txtTotalPoints.Text = System.String.Format("{0:#,0}?", 0)
            txtUsername.Text = System.String.Empty
            txtEmail.Text = System.String.Empty
            txtRegistered.Text = System.String.Empty
            txtStatus.Text = System.String.Empty
        End Sub

        Public Sub EnsureData()
            If Not m_dataLoaded Then
                If Sublight.BaseForm.IsAnonymous Then
                    Return
                End If
                m_dataLoaded = True
                LoadUserStatistics()
                RefreshContributions()
            End If
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            lblUsername.Text = Sublight.Translation.Profile_UserInfo_Label_User
            lblEmail.Text = Sublight.Translation.Profile_UserInfo_Label_Email
            lblRegistered.Text = Sublight.Translation.Profile_UserInfo_Label_Registered
            lblStatus.Text = Sublight.Translation.Profile_UserInfo_Label_Status
            btnChangePassword.Text = Sublight.Translation.Profile_UserInfo_Button_ChangePassword
            btnUpdateEmail.Text = Sublight.Translation.Profile_UserInfo_Button_UpdateEmail
            tabGeneral.Text = Sublight.Translation.Profile_UserInfo_General_Text
            tabStatistics.Text = Sublight.Translation.Profile_UserInfo_MyStatistics_Text
            tabDonations.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Text
            tabUserLog.Text = Sublight.Translation.Profile_UserInfo_UserLog_Text
            lblPublishedSubtitlesCount.Text = Sublight.Translation.Profile_UserInfo_MyStatistics_Label_PublishedSubtitlesCount
            lblDeletedSubtitlesCount.Text = Sublight.Translation.Profile_UserInfo_MyStatistics_Label_DeletedSubtitlesCount
            lblSubtitleThanks.Text = Sublight.Translation.Profile_UserInfo_MyStatistics_Label_SubtitleThanksCount
            lblTotalPoints.Text = Sublight.Translation.Profile_UserInfo_MyStatistics_Label_TotalPoints
            lblAvarageRate.Text = Sublight.Translation.Profile_UserInfo_MyStatistics_Label_AvgSubtitleRate
            lblClickToDonate.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Field_PurchasePoints
            colContrDate.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Column_Date
            colContrType.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Column_Channel
            colContrAmount.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Column_Amount
            colContrValidTo.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Column_ValidTo
            colContrPointsInitial.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Column_InitialPoints
            colContrPointsCurrent.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Column_CurrentPoints
            colContrStatus.Text = Sublight.Translation.Profile_UserInfo_MyContributions_Column_Status
            lblMySubtitlesDownloads.Text = Sublight.Translation.Profile_UserInfo_MyStatistics_Label_MySubtitlesDownloads
            lblMyDownloads.Text = Sublight.Translation.Profile_UserInfo_General_Label_MyDownloads
            btnRefresh.Text = Sublight.Translation.Common_Button_Refresh
            btnUserLogRefresh.Text = Sublight.Translation.Common_Button_Refresh
            lblUserLogNote.Text = Sublight.Translation.Profile_UserInfo_UserLog_Note
            colUserLogAction.Text = Sublight.Translation.Profile_UserInfo_UserLog_Column_Action
            colUserLogPoints.Text = Sublight.Translation.Profile_UserInfo_UserLog_Column_Points
            colUserLogUpdatedBy.Text = Sublight.Translation.Profile_UserInfo_UserLog_Column_UpdatedBy
            colUserLogCreated.Text = Sublight.Translation.Profile_UserInfo_UserLog_Column_Created
            colUserLogComment.Text = Sublight.Translation.Profile_UserInfo_UserLog_Column_Comment
            btnContributionsRefresh.Text = Sublight.Translation.Common_Button_Refresh
            Dim buttonArr1 As Sublight.Controls.Button.Button() = New Sublight.Controls.Button.Button() { _
                                                                                                          btnChangePassword, _
                                                                                                          btnUpdateEmail }
            Sublight.Controls.Button.Button.MakeSameWidth(buttonArr1)
        End Sub

        Private Sub Events_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            m_dataLoaded = False
            _tabUserLogInitialized = False
        End Sub

        Private Sub InitializeComponent()
            tc = New System.Windows.Forms.TabControl
            tabDonations = New System.Windows.Forms.TabPage
            lvPayments = New System.Windows.Forms.ListView
            colContrDate = New System.Windows.Forms.ColumnHeader
            colContrType = New System.Windows.Forms.ColumnHeader
            colContrAmount = New System.Windows.Forms.ColumnHeader
            colContrValidTo = New System.Windows.Forms.ColumnHeader
            colContrPointsInitial = New System.Windows.Forms.ColumnHeader
            colContrPointsCurrent = New System.Windows.Forms.ColumnHeader
            colContrStatus = New System.Windows.Forms.ColumnHeader
            myPanel2 = New Sublight.Controls.MyPanel
            panelBottomRight = New System.Windows.Forms.Panel
            btnContributionsRefresh = New Sublight.Controls.Button.Button
            lblClickToDonate = New System.Windows.Forms.LinkLabel
            tabUserLog = New System.Windows.Forms.TabPage
            lvUserLog = New System.Windows.Forms.ListView
            colUserLogAction = New System.Windows.Forms.ColumnHeader
            colUserLogPoints = New System.Windows.Forms.ColumnHeader
            colUserLogUpdatedBy = New System.Windows.Forms.ColumnHeader
            colUserLogCreated = New System.Windows.Forms.ColumnHeader
            colUserLogComment = New System.Windows.Forms.ColumnHeader
            myPanel1 = New Sublight.Controls.MyPanel
            lblUserLogNote = New System.Windows.Forms.Label
            btnUserLogRefresh = New Sublight.Controls.Button.Button
            tabStatistics = New System.Windows.Forms.TabPage
            txtMySubtitlesDownloads = New Sublight.Controls.MyTextBox
            lblMySubtitlesDownloads = New System.Windows.Forms.Label
            btnRefresh = New Sublight.Controls.Button.Button
            txtTotalPoints = New Sublight.Controls.MyTextBox
            lblTotalPoints = New System.Windows.Forms.Label
            txtAvarageRate = New Sublight.Controls.MyTextBox
            lblAvarageRate = New System.Windows.Forms.Label
            txtSubtitleThanks = New Sublight.Controls.MyTextBox
            lblSubtitleThanks = New System.Windows.Forms.Label
            txtDeletedSubtitlesCount = New Sublight.Controls.MyTextBox
            lblDeletedSubtitlesCount = New System.Windows.Forms.Label
            txtPublishedSubtitlesCount = New Sublight.Controls.MyTextBox
            lblPublishedSubtitlesCount = New System.Windows.Forms.Label
            tabGeneral = New System.Windows.Forms.TabPage
            txtMyDownloads = New Sublight.Controls.MyTextBox
            lblMyDownloads = New System.Windows.Forms.Label
            btnUpdateEmail = New Sublight.Controls.Button.Button
            btnChangePassword = New Sublight.Controls.Button.Button
            txtEmail = New Sublight.Controls.MyTextBox
            lblEmail = New System.Windows.Forms.Label
            lblSubtitleEditorLanguages = New System.Windows.Forms.Label
            txtStatus = New Sublight.Controls.MyTextBox
            lblStatus = New System.Windows.Forms.Label
            txtRegistered = New Sublight.Controls.MyTextBox
            lblRegistered = New System.Windows.Forms.Label
            txtUsername = New Sublight.Controls.MyTextBox
            lblUsername = New System.Windows.Forms.Label
            tc.SuspendLayout()
            tabDonations.SuspendLayout()
            myPanel2.SuspendLayout()
            panelBottomRight.SuspendLayout()
            tabUserLog.SuspendLayout()
            myPanel1.SuspendLayout()
            tabStatistics.SuspendLayout()
            tabGeneral.SuspendLayout()
            SuspendLayout()
            tc.Controls.Add(tabDonations)
            tc.Controls.Add(tabUserLog)
            tc.Controls.Add(tabStatistics)
            tc.Controls.Add(tabGeneral)
            tc.Dock = System.Windows.Forms.DockStyle.Fill
            tc.Location = New System.Drawing.Point(0, 0)
            tc.Name = "tc?"
            tc.SelectedIndex = 0
            tc.Size = New System.Drawing.Size(747, 376)
            tc.TabIndex = 32
            AddHandler tc.SelectedIndexChanged, AddressOf tc_SelectedIndexChanged
            tabDonations.Controls.Add(lvPayments)
            tabDonations.Controls.Add(myPanel2)
            tabDonations.Location = New System.Drawing.Point(4, 22)
            tabDonations.Name = "tabDonations?"
            tabDonations.Size = New System.Drawing.Size(739, 350)
            tabDonations.TabIndex = 2
            tabDonations.Text = "Donations?"
            tabDonations.UseVisualStyleBackColor = True
            Dim columnHeaderArr1 As System.Windows.Forms.ColumnHeader() = New System.Windows.Forms.ColumnHeader() { _
                                                                                                                    colContrDate, _
                                                                                                                    colContrType, _
                                                                                                                    colContrAmount, _
                                                                                                                    colContrValidTo, _
                                                                                                                    colContrPointsInitial, _
                                                                                                                    colContrPointsCurrent, _
                                                                                                                    colContrStatus }
            lvPayments.Columns.AddRange(columnHeaderArr1)
            lvPayments.FullRowSelect = True
            lvPayments.GridLines = True
            lvPayments.Location = New System.Drawing.Point(2, 56)
            lvPayments.MultiSelect = False
            lvPayments.Name = "lvPayments?"
            lvPayments.Size = New System.Drawing.Size(717, 250)
            lvPayments.TabIndex = 43
            lvPayments.UseCompatibleStateImageBehavior = False
            lvPayments.View = System.Windows.Forms.View.Details
            colContrDate.Text = "colContrDate?"
            colContrType.Text = "colContrType?"
            colContrAmount.Text = "colContrAmount?"
            colContrAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            colContrValidTo.Text = "colContrValidTo?"
            colContrPointsInitial.Text = "colContrPointsInitial?"
            colContrPointsInitial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            colContrPointsCurrent.Text = "colContrPointsCurrent?"
            colContrPointsCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            colContrStatus.Text = "colContrStatus?"
            myPanel2.Controls.Add(panelBottomRight)
            myPanel2.Controls.Add(lblClickToDonate)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
            myPanel2.Location = New System.Drawing.Point(0, 307)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(739, 43)
            myPanel2.TabIndex = 41
            panelBottomRight.Controls.Add(btnContributionsRefresh)
            panelBottomRight.Dock = System.Windows.Forms.DockStyle.Right
            panelBottomRight.Location = New System.Drawing.Point(539, 0)
            panelBottomRight.Name = "panelBottomRight?"
            panelBottomRight.Size = New System.Drawing.Size(200, 43)
            panelBottomRight.TabIndex = 129
            btnContributionsRefresh.AutoResize = False
            btnContributionsRefresh.Id = "bf86e2f5-6033-4e42-a160-3a86fe5cc4cd?"
            btnContributionsRefresh.Image = Nothing
            btnContributionsRefresh.Location = New System.Drawing.Point(122, 10)
            btnContributionsRefresh.Name = "btnContributionsRefresh?"
            btnContributionsRefresh.Size = New System.Drawing.Size(75, 23)
            btnContributionsRefresh.TabIndex = 129
            btnContributionsRefresh.Text = "Osveži?"
            btnContributionsRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnContributionsRefresh.UseVisualStyleBackColor = True
            AddHandler btnContributionsRefresh.Click, AddressOf btnContributionsRefresh_Click
            lblClickToDonate.AutoSize = True
            lblClickToDonate.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblClickToDonate.Location = New System.Drawing.Point(3, 15)
            lblClickToDonate.Name = "lblClickToDonate?"
            lblClickToDonate.Size = New System.Drawing.Size(340, 13)
            lblClickToDonate.TabIndex = 37
            lblClickToDonate.TabStop = True
            lblClickToDonate.Text = "Kliknite gumb za donacijo. Ce imate vprašanje nas prosim kontaktirajte.?"
            AddHandler lblClickToDonate.LinkClicked, AddressOf lblClickToDonate_LinkClicked
            tabUserLog.Controls.Add(lvUserLog)
            tabUserLog.Controls.Add(myPanel1)
            tabUserLog.Location = New System.Drawing.Point(4, 22)
            tabUserLog.Name = "tabUserLog?"
            tabUserLog.Size = New System.Drawing.Size(739, 350)
            tabUserLog.TabIndex = 3
            tabUserLog.Text = "User Log?"
            tabUserLog.UseVisualStyleBackColor = True
            Dim columnHeaderArr2 As System.Windows.Forms.ColumnHeader() = New System.Windows.Forms.ColumnHeader() { _
                                                                                                                    colUserLogAction, _
                                                                                                                    colUserLogPoints, _
                                                                                                                    colUserLogUpdatedBy, _
                                                                                                                    colUserLogCreated, _
                                                                                                                    colUserLogComment }
            lvUserLog.Columns.AddRange(columnHeaderArr2)
            lvUserLog.Dock = System.Windows.Forms.DockStyle.Fill
            lvUserLog.FullRowSelect = True
            lvUserLog.GridLines = True
            lvUserLog.Location = New System.Drawing.Point(0, 0)
            lvUserLog.MultiSelect = False
            lvUserLog.Name = "lvUserLog?"
            lvUserLog.Size = New System.Drawing.Size(739, 317)
            lvUserLog.TabIndex = 46
            lvUserLog.UseCompatibleStateImageBehavior = False
            lvUserLog.View = System.Windows.Forms.View.Details
            colUserLogAction.Text = "Action?"
            colUserLogAction.Width = 200
            colUserLogPoints.Text = "Points?"
            colUserLogPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            colUserLogUpdatedBy.Text = "Updated By?"
            colUserLogUpdatedBy.Width = 80
            colUserLogCreated.Text = "Created?"
            colUserLogComment.Text = "Comment?"
            colUserLogComment.Width = 300
            myPanel1.Controls.Add(lblUserLogNote)
            myPanel1.Controls.Add(btnUserLogRefresh)
            myPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
            myPanel1.Location = New System.Drawing.Point(0, 317)
            myPanel1.Name = "myPanel1?"
            myPanel1.Size = New System.Drawing.Size(739, 33)
            myPanel1.TabIndex = 45
            lblUserLogNote.Dock = System.Windows.Forms.DockStyle.Right
            lblUserLogNote.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblUserLogNote.Location = New System.Drawing.Point(234, 0)
            lblUserLogNote.Name = "lblUserLogNote?"
            lblUserLogNote.Size = New System.Drawing.Size(505, 33)
            lblUserLogNote.TabIndex = 156
            lblUserLogNote.Text = "Opomba: prikazani so zapisi za zadnjih 30 dni?"
            lblUserLogNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            btnUserLogRefresh.AutoResize = False
            btnUserLogRefresh.Id = "b12fa490-336d-427c-a2a3-b9e12226e186?"
            btnUserLogRefresh.Image = Nothing
            btnUserLogRefresh.Location = New System.Drawing.Point(0, 6)
            btnUserLogRefresh.Name = "btnUserLogRefresh?"
            btnUserLogRefresh.Size = New System.Drawing.Size(75, 23)
            btnUserLogRefresh.TabIndex = 127
            btnUserLogRefresh.Text = "Osveži?"
            btnUserLogRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnUserLogRefresh.UseVisualStyleBackColor = True
            AddHandler btnUserLogRefresh.Click, AddressOf btnUserLogRefresh_Click
            tabStatistics.Controls.Add(txtMySubtitlesDownloads)
            tabStatistics.Controls.Add(lblMySubtitlesDownloads)
            tabStatistics.Controls.Add(btnRefresh)
            tabStatistics.Controls.Add(txtTotalPoints)
            tabStatistics.Controls.Add(lblTotalPoints)
            tabStatistics.Controls.Add(txtAvarageRate)
            tabStatistics.Controls.Add(lblAvarageRate)
            tabStatistics.Controls.Add(txtSubtitleThanks)
            tabStatistics.Controls.Add(lblSubtitleThanks)
            tabStatistics.Controls.Add(txtDeletedSubtitlesCount)
            tabStatistics.Controls.Add(lblDeletedSubtitlesCount)
            tabStatistics.Controls.Add(txtPublishedSubtitlesCount)
            tabStatistics.Controls.Add(lblPublishedSubtitlesCount)
            tabStatistics.Location = New System.Drawing.Point(4, 22)
            tabStatistics.Name = "tabStatistics?"
            tabStatistics.Padding = New System.Windows.Forms.Padding(3)
            tabStatistics.Size = New System.Drawing.Size(739, 350)
            tabStatistics.TabIndex = 0
            tabStatistics.Text = "Statistics?"
            tabStatistics.UseVisualStyleBackColor = True
            txtMySubtitlesDownloads.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtMySubtitlesDownloads.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtMySubtitlesDownloads.EnableDisableColor = True
            txtMySubtitlesDownloads.Id = "338e2f35-bfcb-4657-98d4-3d751781a573?"
            txtMySubtitlesDownloads.Location = New System.Drawing.Point(421, 10)
            txtMySubtitlesDownloads.Name = "txtMySubtitlesDownloads?"
            txtMySubtitlesDownloads.ReadOnly = True
            txtMySubtitlesDownloads.Size = New System.Drawing.Size(65, 21)
            txtMySubtitlesDownloads.TabIndex = 4
            txtMySubtitlesDownloads.Text = "0?"
            lblMySubtitlesDownloads.Location = New System.Drawing.Point(258, 14)
            lblMySubtitlesDownloads.Name = "lblMySubtitlesDownloads?"
            lblMySubtitlesDownloads.Size = New System.Drawing.Size(157, 42)
            lblMySubtitlesDownloads.TabIndex = 127
            lblMySubtitlesDownloads.Text = "Prenosi mojih podnapisov:?"
            btnRefresh.AutoResize = False
            btnRefresh.Id = "bed35c3b-a7bd-4f9b-9ea0-9c5131945440?"
            btnRefresh.Image = Nothing
            btnRefresh.Location = New System.Drawing.Point(7, 158)
            btnRefresh.Name = "btnRefresh?"
            btnRefresh.Size = New System.Drawing.Size(75, 23)
            btnRefresh.TabIndex = 126
            btnRefresh.Text = "Osveži?"
            btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnRefresh.UseVisualStyleBackColor = True
            AddHandler btnRefresh.Click, AddressOf btnRefresh_Click
            txtTotalPoints.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtTotalPoints.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtTotalPoints.EnableDisableColor = True
            txtTotalPoints.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            txtTotalPoints.Id = "2c3b9c55-5c99-4c58-8623-63e2178cff4e?"
            txtTotalPoints.Location = New System.Drawing.Point(167, 125)
            txtTotalPoints.Name = "txtTotalPoints?"
            txtTotalPoints.ReadOnly = True
            txtTotalPoints.Size = New System.Drawing.Size(65, 21)
            txtTotalPoints.TabIndex = 20
            txtTotalPoints.Text = "0?"
            lblTotalPoints.AutoSize = True
            lblTotalPoints.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblTotalPoints.Location = New System.Drawing.Point(6, 129)
            lblTotalPoints.Name = "lblTotalPoints?"
            lblTotalPoints.Size = New System.Drawing.Size(47, 13)
            lblTotalPoints.TabIndex = 19
            lblTotalPoints.Text = "Tocke:?"
            txtAvarageRate.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtAvarageRate.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtAvarageRate.EnableDisableColor = True
            txtAvarageRate.Id = "30a6e798-48c2-4968-8e1b-a50a53247ca2?"
            txtAvarageRate.Location = New System.Drawing.Point(167, 88)
            txtAvarageRate.Name = "txtAvarageRate?"
            txtAvarageRate.ReadOnly = True
            txtAvarageRate.Size = New System.Drawing.Size(65, 21)
            txtAvarageRate.TabIndex = 3
            txtAvarageRate.Text = "0?"
            lblAvarageRate.AutoSize = True
            lblAvarageRate.Location = New System.Drawing.Point(7, 92)
            lblAvarageRate.Name = "lblAvarageRate?"
            lblAvarageRate.Size = New System.Drawing.Size(95, 13)
            lblAvarageRate.TabIndex = 17
            lblAvarageRate.Text = "Povprecna ocena:?"
            txtSubtitleThanks.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtSubtitleThanks.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtSubtitleThanks.EnableDisableColor = True
            txtSubtitleThanks.Id = "9f03e17b-6617-4e77-9afd-9eae8fe8c67e?"
            txtSubtitleThanks.Location = New System.Drawing.Point(167, 62)
            txtSubtitleThanks.Name = "txtSubtitleThanks?"
            txtSubtitleThanks.ReadOnly = True
            txtSubtitleThanks.Size = New System.Drawing.Size(65, 21)
            txtSubtitleThanks.TabIndex = 2
            txtSubtitleThanks.Text = "0?"
            lblSubtitleThanks.AutoSize = True
            lblSubtitleThanks.Location = New System.Drawing.Point(6, 66)
            lblSubtitleThanks.Name = "lblSubtitleThanks?"
            lblSubtitleThanks.Size = New System.Drawing.Size(49, 13)
            lblSubtitleThanks.TabIndex = 15
            lblSubtitleThanks.Text = "Zahvale:?"
            txtDeletedSubtitlesCount.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtDeletedSubtitlesCount.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtDeletedSubtitlesCount.EnableDisableColor = True
            txtDeletedSubtitlesCount.Id = "91979756-0337-406a-ba6c-d4953191e55c?"
            txtDeletedSubtitlesCount.Location = New System.Drawing.Point(167, 36)
            txtDeletedSubtitlesCount.Name = "txtDeletedSubtitlesCount?"
            txtDeletedSubtitlesCount.ReadOnly = True
            txtDeletedSubtitlesCount.Size = New System.Drawing.Size(65, 21)
            txtDeletedSubtitlesCount.TabIndex = 1
            txtDeletedSubtitlesCount.Text = "0?"
            lblDeletedSubtitlesCount.AutoSize = True
            lblDeletedSubtitlesCount.Location = New System.Drawing.Point(6, 40)
            lblDeletedSubtitlesCount.Name = "lblDeletedSubtitlesCount?"
            lblDeletedSubtitlesCount.Size = New System.Drawing.Size(96, 13)
            lblDeletedSubtitlesCount.TabIndex = 13
            lblDeletedSubtitlesCount.Text = "Izbrisani podnapisi:?"
            txtPublishedSubtitlesCount.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtPublishedSubtitlesCount.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtPublishedSubtitlesCount.EnableDisableColor = True
            txtPublishedSubtitlesCount.Id = "6266ca73-cca7-4e9a-8116-c860d9c6cb3e?"
            txtPublishedSubtitlesCount.Location = New System.Drawing.Point(167, 10)
            txtPublishedSubtitlesCount.Name = "txtPublishedSubtitlesCount?"
            txtPublishedSubtitlesCount.ReadOnly = True
            txtPublishedSubtitlesCount.Size = New System.Drawing.Size(65, 21)
            txtPublishedSubtitlesCount.TabIndex = 0
            txtPublishedSubtitlesCount.Text = "0?"
            lblPublishedSubtitlesCount.AutoSize = True
            lblPublishedSubtitlesCount.Location = New System.Drawing.Point(6, 13)
            lblPublishedSubtitlesCount.Name = "lblPublishedSubtitlesCount?"
            lblPublishedSubtitlesCount.Size = New System.Drawing.Size(104, 13)
            lblPublishedSubtitlesCount.TabIndex = 11
            lblPublishedSubtitlesCount.Text = "Objavljeni podnapisi:?"
            tabGeneral.Controls.Add(txtMyDownloads)
            tabGeneral.Controls.Add(lblMyDownloads)
            tabGeneral.Controls.Add(btnUpdateEmail)
            tabGeneral.Controls.Add(btnChangePassword)
            tabGeneral.Controls.Add(txtEmail)
            tabGeneral.Controls.Add(lblEmail)
            tabGeneral.Controls.Add(lblSubtitleEditorLanguages)
            tabGeneral.Controls.Add(txtStatus)
            tabGeneral.Controls.Add(lblStatus)
            tabGeneral.Controls.Add(txtRegistered)
            tabGeneral.Controls.Add(lblRegistered)
            tabGeneral.Controls.Add(txtUsername)
            tabGeneral.Controls.Add(lblUsername)
            tabGeneral.Location = New System.Drawing.Point(4, 22)
            tabGeneral.Name = "tabGeneral?"
            tabGeneral.Padding = New System.Windows.Forms.Padding(3)
            tabGeneral.Size = New System.Drawing.Size(739, 350)
            tabGeneral.TabIndex = 1
            tabGeneral.Text = "General?"
            tabGeneral.UseVisualStyleBackColor = True
            txtMyDownloads.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtMyDownloads.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtMyDownloads.EnableDisableColor = True
            txtMyDownloads.Id = "e8ebadd5-eca4-4471-9d63-98e3e761dfdf?"
            txtMyDownloads.Location = New System.Drawing.Point(116, 115)
            txtMyDownloads.Name = "txtMyDownloads?"
            txtMyDownloads.ReadOnly = True
            txtMyDownloads.Size = New System.Drawing.Size(65, 21)
            txtMyDownloads.TabIndex = 139
            txtMyDownloads.Text = "0?"
            lblMyDownloads.Location = New System.Drawing.Point(6, 119)
            lblMyDownloads.Name = "lblMyDownloads?"
            lblMyDownloads.Size = New System.Drawing.Size(104, 34)
            lblMyDownloads.TabIndex = 140
            lblMyDownloads.Text = "Moji prenosi:?"
            btnUpdateEmail.AutoResize = False
            btnUpdateEmail.Id = "a0d0d033-3aa0-47b2-bfdc-550d0a15253d?"
            btnUpdateEmail.Image = Nothing
            btnUpdateEmail.Location = New System.Drawing.Point(301, 36)
            btnUpdateEmail.Name = "btnUpdateEmail?"
            btnUpdateEmail.Size = New System.Drawing.Size(180, 23)
            btnUpdateEmail.TabIndex = 138
            btnUpdateEmail.Text = "Posodobi?"
            btnUpdateEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnUpdateEmail.UseVisualStyleBackColor = True
            AddHandler btnUpdateEmail.Click, AddressOf btnUpdateEmail_Click
            btnChangePassword.AutoResize = False
            btnChangePassword.Id = "bcd9bf96-5e07-47cb-8783-768b7a31e9ec?"
            btnChangePassword.Image = Nothing
            btnChangePassword.Location = New System.Drawing.Point(301, 10)
            btnChangePassword.Name = "btnChangePassword?"
            btnChangePassword.Size = New System.Drawing.Size(180, 23)
            btnChangePassword.TabIndex = 137
            btnChangePassword.Text = "Zamenjaj geslo...?"
            btnChangePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnChangePassword.UseVisualStyleBackColor = True
            AddHandler btnChangePassword.Click, AddressOf btnChangePassword_Click
            txtEmail.BackColor = System.Drawing.SystemColors.Window
            txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtEmail.EnableDisableColor = True
            txtEmail.Id = "4088b1f3-fdad-468c-b81d-025dd9d543df?"
            txtEmail.Location = New System.Drawing.Point(116, 37)
            txtEmail.Name = "txtEmail?"
            txtEmail.Size = New System.Drawing.Size(179, 21)
            txtEmail.TabIndex = 136
            txtEmail.Text = "username@provider.com?"
            lblEmail.AutoSize = True
            lblEmail.Location = New System.Drawing.Point(6, 41)
            lblEmail.Name = "lblEmail?"
            lblEmail.Size = New System.Drawing.Size(35, 13)
            lblEmail.TabIndex = 135
            lblEmail.Text = "Email:?"
            lblSubtitleEditorLanguages.AutoSize = True
            lblSubtitleEditorLanguages.Location = New System.Drawing.Point(301, 93)
            lblSubtitleEditorLanguages.Name = "lblSubtitleEditorLanguages?"
            lblSubtitleEditorLanguages.Size = New System.Drawing.Size(132, 13)
            lblSubtitleEditorLanguages.TabIndex = 134
            lblSubtitleEditorLanguages.Text = "lblSubtitleEditorLanguages?"
            lblSubtitleEditorLanguages.Visible = False
            txtStatus.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtStatus.EnableDisableColor = True
            txtStatus.Id = "3e2a875c-56f7-441b-885c-3cd9938f1869?"
            txtStatus.Location = New System.Drawing.Point(116, 89)
            txtStatus.Name = "txtStatus?"
            txtStatus.ReadOnly = True
            txtStatus.Size = New System.Drawing.Size(179, 21)
            txtStatus.TabIndex = 133
            txtStatus.Text = "uporabnik?"
            lblStatus.AutoSize = True
            lblStatus.Location = New System.Drawing.Point(6, 93)
            lblStatus.Name = "lblStatus?"
            lblStatus.Size = New System.Drawing.Size(40, 13)
            lblStatus.TabIndex = 132
            lblStatus.Text = "Status:?"
            txtRegistered.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtRegistered.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtRegistered.EnableDisableColor = True
            txtRegistered.Id = "51b7ac15-d704-4f74-8998-8bbf0113da75?"
            txtRegistered.Location = New System.Drawing.Point(116, 63)
            txtRegistered.Name = "txtRegistered?"
            txtRegistered.ReadOnly = True
            txtRegistered.Size = New System.Drawing.Size(179, 21)
            txtRegistered.TabIndex = 131
            txtRegistered.Text = "01.01.9999?"
            lblRegistered.AutoSize = True
            lblRegistered.Location = New System.Drawing.Point(6, 67)
            lblRegistered.Name = "lblRegistered?"
            lblRegistered.Size = New System.Drawing.Size(60, 13)
            lblRegistered.TabIndex = 130
            lblRegistered.Text = "Registriran:?"
            txtUsername.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtUsername.EnableDisableColor = True
            txtUsername.Id = "75fc394a-b45f-42de-80ad-ddb9c6a48c00?"
            txtUsername.Location = New System.Drawing.Point(116, 11)
            txtUsername.Name = "txtUsername?"
            txtUsername.ReadOnly = True
            txtUsername.Size = New System.Drawing.Size(179, 21)
            txtUsername.TabIndex = 129
            txtUsername.Text = "username?"
            lblUsername.AutoSize = True
            lblUsername.Location = New System.Drawing.Point(6, 15)
            lblUsername.Name = "lblUsername?"
            lblUsername.Size = New System.Drawing.Size(59, 13)
            lblUsername.TabIndex = 128
            lblUsername.Text = "Uporabnik:?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(tc)
            Name = "ProfileUserInfo?"
            Size = New System.Drawing.Size(747, 376)
            tc.ResumeLayout(False)
            tabDonations.ResumeLayout(False)
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            panelBottomRight.ResumeLayout(False)
            tabUserLog.ResumeLayout(False)
            myPanel1.ResumeLayout(False)
            tabStatistics.ResumeLayout(False)
            tabStatistics.PerformLayout()
            tabGeneral.ResumeLayout(False)
            tabGeneral.PerformLayout()
            ResumeLayout(False)
        End Sub

        Private Sub lblClickToDonate_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
            ParentBaseForm.ShowPurchasePoints()
        End Sub

        Private Sub LoadUserStatistics()
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                ParentBaseForm.HideLoader(Me)
                ParentBaseForm.ShowLoader(Me)
                AddHandler sublight1.GetUserInfoCompleted, AddressOf ws_GetUserInfoCompleted
                sublight1.GetUserInfoAsync(Sublight.BaseForm.Session)
            End Using
        End Sub

        Friend Sub OnDisplayed()
            m_isDisplayed = True
            EnsureData()
        End Sub

        Private Sub RefreshContributions()
            If _contributionsLoading Then
                Return
            End If
            If Sublight.BaseForm.IsAnonymous Then
                Return
            End If
            Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                btnContributionsRefresh.Enabled = False
                _contributionsLoading = True
                AddHandler sublightClient1.GetContributions2Completed, AddressOf sc_GetContributionsCompleted
                ParentBaseForm.ShowLoader(Me)
                sublightClient1.GetContributions2Async(Sublight.BaseForm.Session)
            End Using
        End Sub

        Private Sub RefreshUserLog()
            ParentBaseForm.ShowLoader(Me)
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.GetUserLog2Completed, AddressOf ws_GetUserLog2Completed
                sublight1.GetUserLog2Async(Sublight.BaseForm.Session)
            End Using
        End Sub

        Private Sub sc_GetContributionsCompleted(ByVal sender As Object, ByVal e As Sublight.WS_SublightClient.GetContributions2CompletedEventArgs)
            Try
                lvPayments.BeginUpdate()
                lvPayments.Items.Clear()
                If Not (e.Error) Is Nothing Then
                    ParentBaseForm.ShowError(e.Error.Message, New object(0) {})
                    Return
                End If
                If Not e.Result Then
                    ParentBaseForm.ShowError(e.error, New object(0) {})
                    Return
                End If
                Dim color1 As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#D4F1C3?")
                Dim color2 As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFE1?")
                Dim color3 As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#FFB5B6?")
                If (_fontContributionsInUse) Is Nothing Then
                    _fontContributionsInUse = New System.Drawing.Font("Microsoft Sans Serif?", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
                End If
                Dim dataSet1 As System.Data.DataSet = e.ds
                If (Not (dataSet1) Is Nothing) AndAlso (dataSet1.Tables.Count > 0) Then
                    Dim dataTable1 As System.Data.DataTable = dataSet1.Tables(0)
                    Dim dataRow1 As System.Data.DataRow 
                    For Each dataRow1 In dataTable1.Rows
                        Dim dateTime1 As System.DateTime = DirectCast(dataRow1("ValidTo?"), System.DateTime)
                        Dim i1 As Integer = DirectCast(dataRow1("InitialPoints?"), int)
                        Dim s1 As String = TryCast(dataRow1("Amount?"), string)
                        Dim i2 As Integer = DirectCast(dataRow1("CurrentPoints?"), int)
                        Dim flag1 As Boolean = DirectCast(dataRow1("Active?"), short) > 0
                        Dim sArr1 As String() = New string(7) {}
                        Dim dateTime2 As System.DateTime = DirectCast(dataRow1("Created?"), System.DateTime)
                        sArr1(0) = dateTime2.ToShortDateString()
                        sArr1(1) = TryCast(dataRow1("Channel?"), string)
                        sArr1(2) = IIf(System.String.IsNullOrEmpty(s1), "/?", s1)
                        sArr1(3) = IIf(dateTime1 = System.DateTime.MinValue, Sublight.Translation.Profile_UserInfo_MyContributions_Value_ValidTo_Unlimited, dateTime1.ToString())
                        sArr1(4) = IIf(i1 < 0, "/?", System.String.Format("{0:#,0}?", i1))
                        sArr1(5) = System.String.Format("{0:#,0}?", i2)
                        sArr1(6) = IIf(flag1, Sublight.Translation.Profile_UserInfo_MyContributions_Value_Status_InUse, Sublight.Translation.Profile_UserInfo_MyContributions_Value_Status_NotInUse)
                        Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(sArr1)
                        listViewItem1.UseItemStyleForSubItems = False
                        If flag1 Then
                            If i2 < 0 Then
                                listViewItem1.BackColor = color3
                                listViewItem1.SubItems(5).Font = _fontContributionsInUse
                            Else 
                                listViewItem1.BackColor = color1
                                listViewItem1.SubItems(5).Font = _fontContributionsInUse
                            End If
                        Else 
                            listViewItem1.BackColor = color2
                            listViewItem1.ForeColor = System.Drawing.Color.Gray
                        End If
                        Dim i3 As Integer = 1
                        While i3 < lvPayments.Columns.Count
                            listViewItem1.SubItems(i3).BackColor = listViewItem1.BackColor
                            listViewItem1.SubItems(i3).ForeColor = listViewItem1.ForeColor
                            i3 = i3 + 1
                        End While
                        lvPayments.Items.Add(listViewItem1)
                    Next
                End If
                If Not (dataSet1) Is Nothing Then
                    dataSet1.Dispose()
                End If
                Dim columnHeader1 As System.Windows.Forms.ColumnHeader 
                For Each columnHeader1 In lvPayments.Columns
                    lvPayments.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent)
                    Dim i4 As Integer = columnHeader1.Width
                    lvPayments.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize)
                    Dim i5 As Integer = columnHeader1.Width
                    If i4 > i5 Then
                        columnHeader1.Width = i4
                    Else 
                        columnHeader1.Width = i5
                    End If
                Next
                Sublight.Globals.UpdateUserPoints(e.effectivePoints)
            Catch e As System.Exception
            Finally
                _contributionsLoading = False
                btnContributionsRefresh.Enabled = True
                lvPayments.EndUpdate()
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Friend Sub ShowMyContributions()
            RefreshContributions()
            Dim i1 As Integer = tc.TabPages.IndexOf(tabDonations)
            If tc.SelectedIndex = i1 Then
                Return
            End If
            tc.SelectedIndex = tc.TabPages.IndexOf(tabDonations)
        End Sub

        Friend Sub ShowUserLog()
            Dim i1 As Integer = tc.TabPages.IndexOf(tabUserLog)
            If tc.SelectedIndex = i1 Then
                If _tabUserLogInitialized Then
                    Return
                End If
                _tabUserLogInitialized = True
                RefreshUserLog()
                Return
            End If
            tc.SelectedIndex = tc.TabPages.IndexOf(tabUserLog)
        End Sub

        Private Sub tc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If (tc.SelectedIndex = tc.TabPages.IndexOf(tabUserLog)) AndAlso Not _tabUserLogInitialized Then
                _tabUserLogInitialized = True
                RefreshUserLog()
            End If
        End Sub

        Private Sub ws_GetUserInfoCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetUserInfoCompletedEventArgs)
            Try
                If Not e.Result Then
                    ParentBaseForm.ShowError(e.error, New object(0) {})
                    Return
                End If
                txtPublishedSubtitlesCount.Text = System.String.Format("{0:#,0}?", e.userInfo.SubtitlesPublished)
                txtDeletedSubtitlesCount.Text = System.String.Format("{0:#,0}?", e.userInfo.SubtitlesDeleted)
                If e.userInfo.AverageRate > 0.0R Then
                    txtAvarageRate.Text = System.String.Format("{0:#,0.00}?", e.userInfo.AverageRate)
                Else 
                    txtAvarageRate.Text = "/?"
                End If
                txtSubtitleThanks.Text = System.String.Format("{0:#,0}?", e.userInfo.SubtitleThanks)
                txtTotalPoints.Text = System.String.Format("{0:#,0}?", e.userInfo.Points)
                txtMySubtitlesDownloads.Text = System.String.Format("{0:#,0}?", e.userInfo.MySubtitleDownloads)
                txtMyDownloads.Text = System.String.Format("{0:#,0}?", e.userInfo.TotalSubtitleDownloads)
                txtUsername.Text = e.userInfo.Username
                txtEmail.Text = e.userInfo.Email
                Dim dateTime1 As System.DateTime = e.userInfo.Created
                txtRegistered.Text = dateTime1.ToShortDateString()
                txtStatus.Text = System.String.Empty
                If Not (Sublight.BaseForm.Roles) Is Nothing Then
                    Dim i1 As Integer = 0
                    While i1 < Sublight.BaseForm.Roles.Length
                        txtStatus.Text = txtStatus.Text + Sublight.Globals.GetString(System.String.Format("Security_Role_{0}?", Sublight.BaseForm.Roles(i1)))
                        If i1 < (Sublight.BaseForm.Roles.Length - 1) Then
                            txtStatus.Text = txtStatus.Text + ", ?"
                        End If
                        i1 = i1 + 1
                    End While
                End If
                Dim frmMain1 As Sublight.FrmMain = TryCast(ParentBaseForm, Sublight.FrmMain)
                If (Not (frmMain1) Is Nothing) AndAlso Not frmMain1.IsDisposed Then
                    frmMain1.UpdatePoints(e.userInfo.Points)
                End If
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("Sublight.Controls.ProfileUserInfo.ws_GetUserInfoCompleted?", e1)
                ParentBaseForm.ExceptionHandlerUI(e1)
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Sub ws_GetUserLog2Completed(ByVal sender As Object, ByVal e As Sublight.WS.GetUserLog2CompletedEventArgs)
            Dim s1 As String

            Try
                If Sublight.BaseForm.HandleWSErrors(ParentBaseForm, e) Then
                    Return
                End If
                If ((e.ds) Is Nothing) OrElse (e.ds.Tables.Count <> 1) Then
                    Return
                End If
                Dim dataTable1 As System.Data.DataTable = e.ds.Tables(0)
                If (dataTable1) Is Nothing Then
                    Return
                End If
                lvUserLog.BeginUpdate()
                lvUserLog.Items.Clear()
                Dim color1 As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#D4F1C3?")
                Dim color2 As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#FFB5B6?")
                Dim dataRow1 As System.Data.DataRow 
                For Each dataRow1 In dataTable1.Rows
                    Dim i1 As Integer = System.Convert.ToInt32(dataRow1("Points?"))
                    Dim dateTime1 As System.DateTime = DirectCast(dataRow1("Created?"), System.DateTime)
                    If (dateTime1.Hour = 0) AndAlso (dateTime1.Minute = 0) AndAlso (dateTime1.Second = 0) Then
                        s1 = dateTime1.ToShortDateString()
                    Else 
                        s1 = dateTime1.ToString()
                    End If
                    Dim sArr1 As String() = New string() { _
                                                           CType(dataRow1("Action?"), string), _
                                                           System.String.Format("{0:#,0}?", i1), _
                                                           CType(dataRow1("UpdatedBy?"), string), _
                                                           s1, _
                                                           IIf(dataRow1.IsNull("Comment?"), System.String.Empty, CType(dataRow1("Comment?"), string)) }
                    Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(sArr1)
                    If i1 > 0 Then
                        listViewItem1.BackColor = color1
                    ElseIf i1 < 0 Then
                        listViewItem1.BackColor = color2
                        listViewItem1.ForeColor = System.Drawing.Color.DarkBlue
                    End If
                    lvUserLog.Items.Add(listViewItem1)
                Next
                Dim columnHeader1 As System.Windows.Forms.ColumnHeader 
                For Each columnHeader1 In lvUserLog.Columns
                    lvUserLog.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent)
                    Dim i2 As Integer = columnHeader1.Width
                    lvUserLog.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize)
                    Dim i3 As Integer = columnHeader1.Width
                    If i2 > i3 Then
                        columnHeader1.Width = i2
                    Else 
                        columnHeader1.Width = i3
                    End If
                Next
                Sublight.Globals.UpdateUserPoints(e.points)
            Finally
                If (Not (e) Is Nothing) AndAlso (Not (e.ds) Is Nothing) Then
                    e.ds.Dispose()
                End If
                ParentBaseForm.HideLoader(Me)
                lvUserLog.EndUpdate()
            End Try
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (_fontContributionsInUse) Is Nothing) Then
                _fontContributionsInUse.Dispose()
                _fontContributionsInUse = Nothing
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class ProfileUserInfo

End Namespace

