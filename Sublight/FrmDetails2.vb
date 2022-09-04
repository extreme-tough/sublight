Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports Sublight.Common.Types
Imports Sublight.Common.Utility
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Controls.CommentsControl
Imports Sublight.Lib.IMDB
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmDetails2
        Inherits Sublight.BaseForm

        Public Enum FirstTab
            Details
            Preview
            NFO
        End Enum

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass1

            Public <>4__this As Sublight.FrmDetails2 
            Public info As String 

            Public Sub New()
            End Sub

            Public Sub <NfoThread>b__0()
                If System.String.IsNullOrEmpty(info) Then
                    <>4__this.txtNFO.Text = System.String.Empty
                Else 
                    <>4__this.txtNFO.Text = info
                End If
                <>4__this.HideLoader(<>4__this)
                <>4__this.BringToFront()
            End Sub

        End Class ' class <>c__DisplayClass1

        Private Const _IMDB_EXPR As String  = "<a\s*?name=['""]poster['""].*?<img.*?src\s*?=\s*?['""](?<src>.*?)['""]"

        Private btnAddAKA As Sublight.Controls.Button.Button 
        Private btnAddRelease As Sublight.Controls.Button.Button 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnEditAKA As Sublight.Controls.Button.Button 
        Private btnEditRelease As Sublight.Controls.Button.Button 
        Private btnFindIMDB As Sublight.Controls.Button.Button 
        Private btnRemoveAKA As Sublight.Controls.Button.Button 
        Private btnRemoveRelease As Sublight.Controls.Button.Button 
        Private btnReportSubtitle As Sublight.Controls.Button.Button 
        Private btnSave As Sublight.Controls.Button.Button 
        Private btnSendComment As Sublight.Controls.Button.Button 
        Private btnSendMessageToPublisher As Sublight.Controls.Button.Button 
        Private btnShowHideAddComment As Sublight.Controls.Button.Button 
        Private btnThanks As Sublight.Controls.Button.Button 
        Private cbCommentLanguage As Sublight.Controls.MyComboBox 
        Private cbLanguage As Sublight.Controls.MyComboBox 
        Private cbMediaCount As Sublight.Controls.MyComboBox 
        Private cbMediaType As Sublight.Controls.MyComboBox 
        Private cbStatus As Sublight.Controls.MyComboBox 
        Private cbType As Sublight.Controls.MyComboBox 
        Private cmHistory As System.Windows.Forms.ContextMenuStrip 
        Private colHistoryDescription As System.Windows.Forms.ColumnHeader 
        Private colHistoryDT As System.Windows.Forms.ColumnHeader 
        Private colHistoryUser As System.Windows.Forms.ColumnHeader 
        Private colNum As System.Windows.Forms.ColumnHeader 
        Private colText As System.Windows.Forms.ColumnHeader 
        Private colThanksCreated As System.Windows.Forms.ColumnHeader 
        Private colThanksUser As System.Windows.Forms.ColumnHeader 
        Private components As System.ComponentModel.IContainer 
        Private ctrlComments As Sublight.Controls.CommentsControl.CommentItems 
        Private ctrlSubtitleStatus As Sublight.Controls.CtrlSubtitleStatus 
        Private gbAddComment As Sublight.Controls.MyGroupBox 
        Private label1 As System.Windows.Forms.Label 
        Private lbAKA As System.Windows.Forms.ListBox 
        Private lblAKA As System.Windows.Forms.Label 
        Private lblAttrLinked As System.Windows.Forms.Label 
        Private lblAttrLinkedDesc As System.Windows.Forms.Label 
        Private lblAttrStandard As System.Windows.Forms.Label 
        Private lblAttrStandardDesc As System.Windows.Forms.Label 
        Private lblAttrStatus As System.Windows.Forms.Label 
        Private lblAttrStatusDesc As System.Windows.Forms.Label 
        Private lblComment As System.Windows.Forms.Label 
        Private lblCommentLanguage As System.Windows.Forms.Label 
        Private lblCommentNote As System.Windows.Forms.Label 
        Private lblDownloads As System.Windows.Forms.Label 
        Private lblEpisode As System.Windows.Forms.Label 
        Private lblImdb As System.Windows.Forms.Label 
        Private lblLanguage As System.Windows.Forms.Label 
        Private lblMedia As System.Windows.Forms.Label 
        Private lblNoImage As System.Windows.Forms.Label 
        Private lblNumDialogs As System.Windows.Forms.Label 
        Private lblNumWords As System.Windows.Forms.Label 
        Private lblPublisher As System.Windows.Forms.Label 
        Private lblPublishTS As System.Windows.Forms.Label 
        Private lblRate As System.Windows.Forms.Label 
        Private lblReports As System.Windows.Forms.Label 
        Private lblSeason As System.Windows.Forms.Label 
        Private lblSize As System.Windows.Forms.Label 
        Private lblSizeUnit As System.Windows.Forms.Label 
        Private lblSubtitleFormat As System.Windows.Forms.Label 
        Private lblTitle As System.Windows.Forms.Label 
        Private lblType As System.Windows.Forms.Label 
        Private lblVotes As System.Windows.Forms.Label 
        Private lblYear As System.Windows.Forms.Label 
        Private lblYearDash As System.Windows.Forms.Label 
        Private lbReleases As System.Windows.Forms.ListBox 
        Private ldPoster As Sublight.Controls.Loading 
        Private legendLabel1 As Sublight.Controls.LegendLabel 
        Private listView1 As System.Windows.Forms.ListView 
        Private lnkImdb As System.Windows.Forms.LinkLabel 
        Private lvHistory As System.Windows.Forms.ListView 
        Private lvThanks As System.Windows.Forms.ListView 
        Private m_commentsShown As Boolean 
        Private m_commentSuccessfullySent As Boolean 
        Private m_detailsLoaded As Boolean 
        Private m_displayDetailsFirst As Sublight.FrmDetails2.FirstTab 
        Private m_EditableControls As System.Collections.Generic.List(Of System.Windows.Forms.Control) 
        Private m_EditablePen As System.Drawing.Pen 
        Private m_historyShown As Boolean 
        Private m_imdbId As String 
        Private m_NFOShown As Boolean 
        Private m_releasesLoaded As Boolean 
        Private m_ShowThanks As Boolean 
        Private m_subtitle As Sublight.WS.Subtitle 
        Private m_wsCalled As Boolean 
        Private myGroupBox2 As Sublight.Controls.MyGroupBox 
        Private myPanel1 As Sublight.Controls.MyPanel 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private myPanel3 As Sublight.Controls.MyPanel 
        Private panelCommentsTop As Sublight.Controls.MyPanel 
        Private pbPoster As System.Windows.Forms.PictureBox 
        Private rateControl As Sublight.Controls.RateControl 
        Private tabComments As System.Windows.Forms.TabPage 
        Private tabControl As System.Windows.Forms.TabControl 
        Private tabDetails As System.Windows.Forms.TabPage 
        Private tabHistory As System.Windows.Forms.TabPage 
        Private tabNFO As System.Windows.Forms.TabPage 
        Private tabPreview As System.Windows.Forms.TabPage 
        Private tabThanks As System.Windows.Forms.TabPage 
        Private tcSubtitleDetails As System.Windows.Forms.TabControl 
        Private tmrDetailsHideLoader As System.Windows.Forms.Timer 
        Private tpSDAttributes As System.Windows.Forms.TabPage 
        Private tpSDGeneral As System.Windows.Forms.TabPage 
        Private tpSDReleases As System.Windows.Forms.TabPage 
        Private txtAddComment As Sublight.Controls.MyTextBox 
        Private txtAttrLinked As Sublight.Controls.MyTextBox 
        Private txtAttrStandard As Sublight.Controls.MyTextBox 
        Private txtAttrStatus As Sublight.Controls.MyTextBox 
        Private txtComment As Sublight.Controls.MyTextBox 
        Private txtDownloads As Sublight.Controls.MyTextBox 
        Private txtEpisode As Sublight.Controls.MyTextBox 
        Private txtImdb As Sublight.Controls.MyTextBox 
        Private txtNFO As Sublight.Controls.MyTextBox 
        Private txtNumDialogs As Sublight.Controls.MyTextBox 
        Private txtNumWords As Sublight.Controls.MyTextBox 
        Private txtPublisher As Sublight.Controls.MyTextBox 
        Private txtPublishTS As Sublight.Controls.MyTextBox 
        Private txtReports As Sublight.Controls.MyTextBox 
        Private txtSeason As Sublight.Controls.MyTextBox 
        Private txtSize As Sublight.Controls.MyTextBox 
        Private txtSubtitleFormat As Sublight.Controls.MyTextBox 
        Private txtTitle As Sublight.Controls.MyTextBox 
        Private txtVotes As Sublight.Controls.MyTextBox 
        Private txtYear As Sublight.Controls.MyTextBox 
        Private txtYearTo As Sublight.Controls.MyTextBox 

        Public Sub New(ByVal subtitle As Sublight.WS.Subtitle, ByVal firstTab As Sublight.FrmDetails2.FirstTab)
            m_EditablePen = New System.Drawing.Pen(System.Drawing.Color.Blue, 2.0F)
            m_EditableControls = New System.Collections.Generic.List(Of System.Windows.Forms.Control)
            InitializeComponent()
            InitMarkerEvents()
            Init(subtitle, firstTab)
        End Sub

        Public Sub New(ByVal subtitleId As System.Guid, ByVal firstTab As Sublight.FrmDetails2.FirstTab)
            Dim s1 As String
            Dim subtitle1 As Sublight.WS.Subtitle

            m_EditablePen = New System.Drawing.Pen(System.Drawing.Color.Blue, 2.0F)
            m_EditableControls = New System.Collections.Generic.List(Of System.Windows.Forms.Control)
            InitializeComponent()
            InitMarkerEvents()
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                If sublight1.GetSubtitleById(Sublight.BaseForm.Session, subtitleId, out subtitle1, out s1) Then
                    Init(subtitle1, firstTab)
                Else 
                    ShowError(s1, New object(0) {})
                    Close()
                End If
            End Using
        End Sub

        Private Sub btnAddAKA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim frmAddAlternativeTitle1 As Sublight.FrmAddAlternativeTitle = New Sublight.FrmAddAlternativeTitle(IIf(Not (m_subtitle) Is Nothing, m_subtitle.SubtitleID, System.Guid.Empty))
            If frmAddAlternativeTitle1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                lbAKA.Items.Add(frmAddAlternativeTitle1.AlternativeTitle)
            End If
            frmAddAlternativeTitle1.Dispose()
        End Sub

        Private Sub btnAddRelease_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim frmAddRelease1 As Sublight.FrmAddRelease = New Sublight.FrmAddRelease(m_subtitle.SubtitleID)
            If (frmAddRelease1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) AndAlso frmAddRelease1.Status Then
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    AddHandler sublight1.GetReleasesCompleted, AddressOf WS_GetReleasesCompleted
                    Dim guidArr1 As System.Guid() = New System.Guid(1) {}
                    guidArr1(0) = m_subtitle.SubtitleID
                    sublight1.GetReleasesAsync(guidArr1)
                End Using
            End If
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnEditRelease_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub btnFindIMDB_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim frmIMDBSelector1 As Sublight.FrmIMDBSelector = New Sublight.FrmIMDBSelector
            If frmIMDBSelector1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                txtImdb.Text = frmIMDBSelector1.ImdbId
            End If
            frmIMDBSelector1.Dispose()
        End Sub

        Private Sub btnRemoveRelease_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub btnReportSubtitle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If (m_subtitle) Is Nothing Then
                Return
            End If
            btnReportSubtitle.Enabled = False
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                sublight1.ReportSubtitleAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID)
            End Using
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If (m_subtitle) Is Nothing Then
                Return
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                m_subtitle.IMDB = txtImdb.Text
                m_subtitle.Language = DirectCast(TryCast(cbLanguage.SelectedItem, Sublight.Types.ListItem).Value, Sublight.WS.SubtitleLanguage)
                m_subtitle.Genre = DirectCast(TryCast(cbType.SelectedItem, Sublight.Types.ListItem).Value, Sublight.WS.Genre)
                m_subtitle.MediaType = DirectCast(TryCast(cbMediaType.SelectedItem, Sublight.Types.ListItem).Value, Sublight.WS.MediaType)
                If System.String.IsNullOrEmpty(txtComment.Text) Then
                    m_subtitle.Comment = Nothing
                Else 
                    m_subtitle.Comment = txtComment.Text
                End If
                If txtSeason.Visible AndAlso Not System.String.IsNullOrEmpty(txtSeason.Text) Then
                    Try
                        m_subtitle.Season = New System.Nullable(Of Byte)(System.Byte.Parse(txtSeason.Text))
                    Catch 
                        ShowError(Sublight.Translation.Publish_Error_ParsingSeason, New object(0) {})
                        Return
                    End Try
                End If
                If txtEpisode.Visible AndAlso Not System.String.IsNullOrEmpty(txtEpisode.Text) Then
                    Try
                        m_subtitle.Episode = New System.Nullable(Of Integer)(System.Int32.Parse(txtEpisode.Text))
                    Catch 
                        ShowError(Sublight.Translation.Publish_Error_ParsingEpisode, New object(0) {})
                        Return
                    End Try
                End If
                m_subtitle.Status = System.Convert.ToByte(DirectCast(TryCast(cbStatus.SelectedItem, Sublight.Types.ListItem).Value, Sublight.Common.Types.SubtitleStatus))
                ShowLoader(Me)
                AddHandler sublight1.UpdateSubtitleCompleted, AddressOf ws_UpdateSubtitleCompleted
                sublight1.UpdateSubtitleAsync(Sublight.BaseForm.Session, m_subtitle)
            End Using
        End Sub

        Private Sub btnSendComment_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If (m_subtitle) Is Nothing Then
                Return
            End If
            If System.String.IsNullOrEmpty(txtAddComment.Text) Then
                Return
            End If
            btnSendComment.Enabled = False
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.AddSubtitleCommentCompleted, AddressOf ws_AddSubtitleCommentCompleted
                sublight1.AddSubtitleCommentAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID, DirectCast(TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem).Value, Sublight.WS.SubtitleLanguage), txtAddComment.Text)
            End Using
        End Sub

        Private Sub btnSendMessageToPublisher_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If (m_subtitle) Is Nothing Then
                Return
            End If
            Dim frmSendMail1 As Sublight.FrmSendMail = New Sublight.FrmSendMail(m_subtitle.PublisherID)
            frmSendMail1.ShowDialog(Me)
            frmSendMail1.Dispose()
        End Sub

        Private Sub btnShowHideAddComment_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            lblCommentNote.Visible = False
            gbAddComment.Visible = True
            If TryCast(btnShowHideAddComment.Tag, string) = "Show?" Then
                btnShowHideAddComment.Tag = "Hide?"
                btnShowHideAddComment.Text = Sublight.Translation.FrmDetails_Tab_Comments_Button_HideComment
                panelCommentsTop.Height = 164
                Return
            End If
            DisplayShowAddComment()
        End Sub

        Private Sub btnThanks_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If (m_subtitle) Is Nothing Then
                Return
            End If
            btnThanks.Enabled = False
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.AddSubtitleThankCompleted, AddressOf ws_AddSubtitleThankCompleted
                sublight1.AddSubtitleThankAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID)
            End Using
        End Sub

        Private Sub cbCommentLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            DisplayShowAddComment()
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem)
            If Not (listItem1) Is Nothing Then
                If Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                    Sublight.Properties.Settings.Default.SubtitleCommentLanguage = -1
                Else 
                    Sublight.Properties.Settings.Default.SubtitleCommentLanguage = System.Convert.ToInt16(listItem1.Value)
                End If
                SaveUserSettings()
            End If
            EnableDisableShowHideAddComment()
            RefreshComments()
        End Sub

        Private Sub cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbType.SelectedItem, Sublight.Types.ListItem)
            If (listItem1) Is Nothing Then
                Return
            End If
            If TypeOf listItem1.Value Is Sublight.WS.Genre Then
                Return
            End If
            Dim flag1 As Boolean = DirectCast(listItem1.Value, Sublight.WS.Genre) <> Sublight.WS.Genre.Movie
            If flag1 Then
                If Not m_EditableControls.Contains(txtSeason) Then
                    m_EditableControls.Add(txtSeason)
                End If
                If Not m_EditableControls.Contains(txtEpisode) Then
                    m_EditableControls.Add(txtEpisode)
                End If
                txtSeason.ReadOnly = False
                txtEpisode.ReadOnly = False
                Return
            End If
            txtSeason.Text = System.String.Empty
            txtEpisode.Text = System.String.Empty
            If m_EditableControls.Contains(txtSeason) Then
                m_EditableControls.Remove(txtSeason)
            End If
            If m_EditableControls.Contains(txtEpisode) Then
                m_EditableControls.Remove(txtEpisode)
            End If
            txtSeason.ReadOnly = True
            txtEpisode.ReadOnly = True
        End Sub

        Private Sub Clear()
            txtImdb.Text = System.String.Empty
            lnkImdb.Text = System.String.Empty
            pbPoster.Image = Nothing
            txtTitle.Text = System.String.Empty
            txtYear.Text = System.String.Empty
            lblYearDash.Visible = True
            txtYearTo.Text = System.String.Empty
            txtYearTo.Visible = True
        End Sub

        Private Sub ctrlComments_AdminDeleteClicked(ByVal sender As Object, ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.SubtitleCommentDeleteCompleted, AddressOf ws_SubtitleCommentDeleteCompleted
                sublight1.SubtitleCommentDeleteAsync(Sublight.BaseForm.Session, DirectCast(commentItem.Tag, System.Guid), commentItem)
            End Using
        End Sub

        Private Sub ctrlComments_LoadFirstPage(ByVal sender As Object, ByVal page As Integer, ByVal elementIndexStart As Integer, ByVal elementIndexEnd As Integer, ByVal cip As Sublight.Controls.CommentsControl.CommentItemsPanel)
            Dim flag1 As Boolean = False
            If (m_subtitle) Is Nothing Then
                flag1 = True
            End If
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem)
            If (listItem1) Is Nothing Then
                flag1 = True
            End If
            If Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                flag1 = True
            End If
            If flag1 Then
                If Not (cip) Is Nothing Then
                    cip.ControlsAdded()
                End If
                HideLoader(Me)
                Return
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.GetSubtitleCommentsCompleted, AddressOf ws_GetSubtitleCommentsLFPCompleted
                sublight1.GetSubtitleCommentsAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID, DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage), elementIndexStart, elementIndexEnd, cip)
            End Using
        End Sub

        Private Sub ctrlComments_PageChanged(ByVal sender As Object, ByVal page As Integer, ByVal elementIndexStart As Integer, ByVal elementIndexEnd As Integer, ByVal cip As Sublight.Controls.CommentsControl.CommentItemsPanel)
            ShowLoader(Me)
            Dim flag1 As Boolean = False
            If (m_subtitle) Is Nothing Then
                flag1 = True
            End If
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem)
            If (listItem1) Is Nothing Then
                flag1 = True
            End If
            If Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                flag1 = True
            End If
            If flag1 Then
                If Not (cip) Is Nothing Then
                    cip.ControlsAdded()
                End If
                HideLoader(Me)
                Return
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.GetSubtitleCommentsCompleted, AddressOf ws_GetSubtitleCommentsPCCompleted
                sublight1.GetSubtitleCommentsAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID, DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage), elementIndexStart, elementIndexEnd, cip)
            End Using
        End Sub

        Private Sub ctrlComments_ReportClicked(ByVal sender As Object, ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.SubtitleCommentVoteCompleted, AddressOf ws_SubtitleCommentVoteCompleted
                sublight1.SubtitleCommentVoteAsync(Sublight.BaseForm.Session, DirectCast(commentItem.Tag, System.Guid), -1, commentItem)
            End Using
        End Sub

        Private Sub ctrlComments_VoteClicked(ByVal sender As Object, ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.SubtitleCommentVoteCompleted, AddressOf ws_SubtitleCommentVoteCompleted
                sublight1.SubtitleCommentVoteAsync(Sublight.BaseForm.Session, DirectCast(commentItem.Tag, System.Guid), 1, commentItem)
            End Using
        End Sub

        Private Sub ctrlSubtitleStatus_StatusClick(ByVal sender As Object, ByVal newStatus As Sublight.Common.Types.SubtitleStatus)
            Dim s1 As String

            Dim b1 As Byte = m_subtitle.Status
            Try
                m_subtitle.Status = System.Convert.ToByte(newStatus)
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    If Not sublight1.UpdateSubtitle(Sublight.BaseForm.Session, m_subtitle, out s1) Then
                        ShowError(s1, New object(0) {})
                        m_subtitle.Status = b1
                    End If
                End Using
            Catch e As System.Exception
                m_subtitle.Status = b1
            End Try
            FillStatuses()
            Sublight.Types.ListItem.Select(cbStatus, Sublight.Common.Utility.SubtitleStatusUtil.GetSubtitleStatus(m_subtitle.Status))
            ctrlSubtitleStatus.InitStatuses(m_subtitle)
        End Sub

        Private Sub DisplayShowAddComment()
            btnShowHideAddComment.Tag = "Show?"
            btnShowHideAddComment.Text = Sublight.Translation.FrmDetails_Tab_Comments_Button_AddComment
            panelCommentsTop.Height = 35
        End Sub

        Private Sub EnableDisableShowHideAddComment()
            If Sublight.BaseForm.IsAnonymous AndAlso Sublight.Types.ListItem.IsNotSelected(TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem)) Then
                ctrlComments.Visible = False
                lblCommentNote.Text = Sublight.Translation.FrmDetails_Tab_Comments_Note_SelectLanguageToViewComments
            ElseIf Sublight.BaseForm.IsAnonymous AndAlso Not Sublight.Types.ListItem.IsNotSelected(TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem)) Then
                ctrlComments.Visible = True
                lblCommentNote.Text = Sublight.Translation.FrmDetails_Tab_Comments_Note_LoginToAddComments
            ElseIf Not Sublight.BaseForm.IsAnonymous AndAlso Sublight.Types.ListItem.IsNotSelected(TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem)) Then
                ctrlComments.Visible = False
                lblCommentNote.Text = Sublight.Translation.FrmDetails_Tab_Comments_Note_SelectLanguageToViewAddComments
            ElseIf Not Sublight.BaseForm.IsAnonymous AndAlso Not Sublight.Types.ListItem.IsNotSelected(TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem)) Then
                ctrlComments.Visible = True
                lblCommentNote.Text = System.String.Empty
            End If
            If Sublight.BaseForm.IsAnonymous Then
                btnShowHideAddComment.Enabled = False
                gbAddComment.Visible = False
                lblCommentNote.Visible = True
                panelCommentsTop.Height = 60
                Return
            End If
            If Sublight.Types.ListItem.IsNotSelected(TryCast(cbCommentLanguage.SelectedItem, Sublight.Types.ListItem)) Then
                btnShowHideAddComment.Enabled = False
                gbAddComment.Visible = False
                lblCommentNote.Visible = True
                panelCommentsTop.Height = 60
                Return
            End If
            If Not m_commentSuccessfullySent Then
                btnShowHideAddComment.Enabled = True
            End If
            gbAddComment.Visible = True
            lblCommentNote.Visible = False
            If panelCommentsTop.Height = 60 Then
                panelCommentsTop.Height = 35
            End If
        End Sub

        Private Sub EndPosterLoadingAnim()
            ldPoster.Visible = False
            ldPoster.Stop()
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            lblTitle.Text = Sublight.Translation.FrmDetails_Field_Title
            lblYear.Text = Sublight.Translation.FrmDetails_Field_Year
            lblAKA.Text = Sublight.Translation.FrmDetails_Field_OtherTitles
            lblPublisher.Text = Sublight.Translation.FrmDetails_Field_Publisher
            lblPublishTS.Text = Sublight.Translation.FrmDetails_Field_Created
            lblLanguage.Text = Sublight.Translation.FrmDetails_Field_Language
            lblMedia.Text = Sublight.Translation.FrmDetails_Field_MediaType
            lblSubtitleFormat.Text = Sublight.Translation.FrmDetails_Field_SubtitleFormat
            lblSeason.Text = Sublight.Translation.FrmDetails_Field_Season
            lblEpisode.Text = Sublight.Translation.FrmDetails_Field_Episode
            lblVotes.Text = Sublight.Translation.FrmDetails_Field_Votes
            lblRate.Text = Sublight.Translation.FrmDetails_Field_Rate
            lblDownloads.Text = Sublight.Translation.FrmDetails_Field_Downloads
            lblSize.Text = Sublight.Translation.FrmDetails_Field_Size
            lblComment.Text = Sublight.Translation.FrmDetails_Field_Comment
            btnCancel.Text = Sublight.Translation.Common_Button_Close
            tabDetails.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails
            tabPreview.Text = Sublight.Translation.FrmDetails_Tab_SubtitlePreview
            tabHistory.Text = Sublight.Translation.FrmDetails_Tab_SubtitleHistory
            tabComments.Text = Sublight.Translation.FrmDetails_Tab_Comments
            myGroupBox2.Text = Sublight.Translation.FrmDetails_Group_MovieInfo
            lblNumDialogs.Text = Sublight.Translation.FrmDetails_Field_NumberOfLines
            lblNumWords.Text = Sublight.Translation.FrmDetails_Field_NumberOfWords
            If listView1.Columns.Count > 0 Then
                listView1.Columns(0).Text = Sublight.Translation.FrmDetails_Column_LineNumber
            End If
            If listView1.Columns.Count > 1 Then
                listView1.Columns(1).Text = Sublight.Translation.FrmDetails_Column_Text
            End If
            lblNoImage.Text = Sublight.Translation.FrmDetails_Field_NoImage
            lblReports.Text = Sublight.Translation.FrmDetails_Field_Reports
            btnReportSubtitle.Text = Sublight.Translation.FrmDetails_Button_ReportSubtitle
            tabNFO.Text = Sublight.Translation.FrmDetails_Tab_NFO
            colHistoryDT.Text = Sublight.Translation.FrmDetails_Tab_SubtitleHistory_Column_Changed
            colHistoryUser.Text = Sublight.Translation.FrmDetails_Tab_SubtitleHistory_Column_User
            colHistoryDescription.Text = Sublight.Translation.FrmDetails_Tab_SubtitleHistory_Column_Description
            btnAddAKA.Text = Sublight.Translation.Common_Button_Add
            btnAddRelease.Text = Sublight.Translation.Common_Button_Add
            btnEditAKA.Text = Sublight.Translation.Common_Button_Edit
            btnEditRelease.Text = Sublight.Translation.Common_Button_Edit
            btnRemoveAKA.Text = Sublight.Translation.Common_Button_Remove
            btnRemoveRelease.Text = Sublight.Translation.Common_Button_Remove
            btnSave.Text = Sublight.Translation.Common_Button_Save
            btnSendMessageToPublisher.Text = Sublight.Translation.FrmDetails_ButtonMessageToPublisher
            legendLabel1.LegendText = Sublight.Translation.FrmDetails_Legend_EditableMark
            lblCommentLanguage.Text = Sublight.Translation.FrmDetails_Tab_Comments_Field_Language
            gbAddComment.Text = Sublight.Translation.FrmDetails_Tab_Comments_Group_AddComment
            btnSendComment.Text = Sublight.Translation.Common_Button_Send
            tabThanks.Text = Sublight.Translation.FrmDetails_Tab_SubtitleThanks
            btnThanks.Text = Sublight.Translation.FrmDetails_Tab_SubtitleThanks_Button_Thanks
            colThanksCreated.Text = Sublight.Translation.FrmDetails_Tab_SubtitleThanks_Column_Created
            colThanksUser.Text = Sublight.Translation.FrmDetails_Tab_SubtitleThanks_Column_User
            ctrlSubtitleStatus.Translate()
            btnFindIMDB.Text = Sublight.Translation.Common_Button_FindDialog
            lblType.Text = Sublight.Translation.FrmDetails_Field_Type
            label1.Text = Sublight.Translation.FrmDetails_Field_Status
            tpSDGeneral.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Tab_General
            tpSDReleases.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Tab_Releases
            tpSDAttributes.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Tab_Attributes
        End Sub

        Private Sub FillAttributes()
            lblAttrStatus.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Label_Attr1
            lblAttrStandard.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Label_Attr2
            lblAttrLinked.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Label_Attr3
            Dim s1 As String = Sublight.MyUtility.SubtitleUtil.GetAttributes(m_subtitle)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            Dim chArr1 As Char() = New char() { " "C }
            Dim sArr1 As String() = s1.Split(chArr1, System.StringSplitOptions.RemoveEmptyEntries)
            If sArr1.Length <> 3 Then
                Return
            End If
            txtAttrStatus.Text = sArr1(0)
            txtAttrStandard.Text = sArr1(1)
            txtAttrLinked.Text = sArr1(2)
            If sArr1(0) = "-?" Then
                lblAttrStatusDesc.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Attr_NA
            Else 
                lblAttrStatusDesc.Text = Sublight.Globals.GetString(System.String.Format("FrmDetails_Tab_SubtitleDetails_Attr1_{0}?", sArr1(0)))
            End If
            If sArr1(1) = "-?" Then
                lblAttrStandardDesc.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Attr_NA
            Else 
                lblAttrStandardDesc.Text = Sublight.Globals.GetString(System.String.Format("FrmDetails_Tab_SubtitleDetails_Attr2_{0}?", sArr1(1)))
            End If
            If sArr1(2) = "-?" Then
                lblAttrLinkedDesc.Text = Sublight.Translation.FrmDetails_Tab_SubtitleDetails_Attr_NA
                Return
            End If
            lblAttrLinkedDesc.Text = Sublight.Globals.GetString(System.String.Format("FrmDetails_Tab_SubtitleDetails_Attr3_{0}?", sArr1(2)))
        End Sub

        Private Sub FillDiscsCount()
            Dim i1 As Integer = cbMediaCount.SelectedIndex
            cbMediaCount.Items.Clear()
            Dim i2 As Integer = 1
            While i2 <= 5
                cbMediaCount.Items.Add(New Sublight.Types.ListItem(System.String.Format("{0}?", i2), i2))
                i2 = i2 + 1
            End While
            If i1 >= 0 Then
                cbMediaCount.SelectedIndex = i1
            End If
        End Sub

        Private Sub FillGenres()
            Dim i1 As Integer = cbType.SelectedIndex
            cbType.Items.Clear()
            Dim genreArr1 As Sublight.WS.Genre() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.Genre)), Sublight.WS.Genre[])
            Dim genreArr2 As Sublight.WS.Genre() = genreArr1
            Dim i2 As Integer = 0
            While i2 < genreArr2.Length
                Dim genre1 As Sublight.WS.Genre = CType(genreArr2(i2), Sublight.WS.Genre)
                If genre1 <> Sublight.WS.Genre.Unknown Then
                    cbType.Items.Add(New Sublight.Types.ListItem(Sublight.Globals.GetString(System.String.Format("Genre_{0}?", System.Enum.GetName(GetType(Sublight.WS.Genre), genre1))), genre1))
                End If
                i2 = i2 + 1
            End While
            If i1 >= 0 Then
                cbType.SelectedIndex = i1
            End If
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

        Private Sub FillLanguagesComment()
            Dim i1 As Integer = cbCommentLanguage.SelectedIndex
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = Sublight.MyUtility.LanguageUtil.GetSortedLanguages()
            Dim subtitleLanguageArr2 As Sublight.WS.SubtitleLanguage() = subtitleLanguageArr1
            Dim i2 As Integer = 0
            While i2 < subtitleLanguageArr2.Length
                Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(subtitleLanguageArr2(i2), Sublight.WS.SubtitleLanguage)
                If subtitleLanguage1 <> Sublight.WS.SubtitleLanguage.Unknown Then
                    Dim s1 As String = Sublight.Globals.GetString(subtitleLanguage1)
                    If Not System.String.IsNullOrEmpty(s1) Then
                        cbCommentLanguage.Items.Add(New Sublight.Types.ListItem(s1, subtitleLanguage1))
                    End If
                End If
                i2 = i2 + 1
            End While
            Sublight.Globals.BindNotSelected(cbCommentLanguage, False)
            If i1 >= 0 Then
                cbCommentLanguage.SelectedIndex = i1
            End If
        End Sub

        Private Sub FillMediaType()
            Dim i1 As Integer = cbMediaType.SelectedIndex
            cbMediaType.Items.Clear()
            Dim mediaTypeArr1 As Sublight.WS.MediaType() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.MediaType)), Sublight.WS.MediaType[])
            Dim mediaTypeArr2 As Sublight.WS.MediaType() = mediaTypeArr1
            Dim i2 As Integer = 0
            While i2 < mediaTypeArr2.Length
                Dim mediaType1 As Sublight.WS.MediaType = CType(mediaTypeArr2(i2), Sublight.WS.MediaType)
                If (mediaType1 <> Sublight.WS.MediaType.Unknown) AndAlso (mediaType1 <> Sublight.WS.MediaType.BlueRay) Then
                    cbMediaType.Items.Add(New Sublight.Types.ListItem(Sublight.Globals.GetString(mediaType1), mediaType1))
                End If
                i2 = i2 + 1
            End While
            If i1 >= 0 Then
                cbMediaType.SelectedIndex = i1
            End If
        End Sub

        Private Sub FillStatuses()
            cbStatus.Items.Clear()
            Dim subtitleStatusArr1 As Sublight.Common.Types.SubtitleStatus() = Nothing
            If Not (m_subtitle) Is Nothing Then
                subtitleStatusArr1 = Sublight.Common.Utility.SubtitleStatusValidator.GetNext(m_subtitle.Status)
            End If
            If Not (subtitleStatusArr1) Is Nothing Then
                Dim subtitleStatusArr2 As Sublight.Common.Types.SubtitleStatus() = subtitleStatusArr1
                Dim i1 As Integer = 0
                While i1 < subtitleStatusArr2.Length
                    Dim subtitleStatus1 As Sublight.Common.Types.SubtitleStatus = CType(subtitleStatusArr2(i1), Sublight.Common.Types.SubtitleStatus)
                    cbStatus.Items.Add(New Sublight.Types.ListItem(Sublight.Globals.GetString(System.String.Format("Common_Subtitle_Status_{0}?", System.Enum.GetName(GetType(Sublight.Common.Types.SubtitleStatus), subtitleStatus1))), subtitleStatus1))
                    i1 = i1 + 1
                End While
            End If
        End Sub

        Private Sub FrmDetails2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub FrmDetails2_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            If Top < 10 Then
                Top = 10
            Else 
                Dim rectangle1 As System.Drawing.Rectangle = System.Windows.Forms.Screen.GetWorkingArea(Me)
                If Bottom > (rectangle1.Height - 10) Then
                    Dim rectangle2 As System.Drawing.Rectangle = System.Windows.Forms.Screen.GetWorkingArea(Me)
                    Top = rectangle2.Height - Height - 10
                End If
            End If
            If m_displayDetailsFirst = Sublight.FrmDetails2.FirstTab.Details Then
                ShowDetails()
            ElseIf m_displayDetailsFirst = Sublight.FrmDetails2.FirstTab.Preview Then
                ShowPreview()
            ElseIf m_displayDetailsFirst = Sublight.FrmDetails2.FirstTab.NFO Then
                ShowNFO()
            End If
            If Sublight.MyUtility.SubtitleUtil.IsNonImdbMovie(m_subtitle) Then
                lnkImdb.Visible = False
                tabControl.TabPages.Remove(tabNFO)
            End If
        End Sub

        Private Sub GetPoster()
            Dim s1 As String, s2 As String

            pbPoster.Image = Nothing
            Dim webClient1 As System.Net.WebClient = Nothing
            Try
                StartPosterLoadingAnim()
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    If sublight1.GetPoster(Sublight.BaseForm.Session, m_imdbId, out s2, out s1) AndAlso Not System.String.IsNullOrEmpty(s2) Then
                        Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream(System.Convert.FromBase64String(s2))
                            Dim image1 As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream1)
                            pbPoster.Image = image1
                            pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                            Dim d1 As Double = System.Convert.ToDouble(image1.Height) / System.Convert.ToDouble(image1.Width)
                            pbPoster.Width = 94
                            pbPoster.Height = System.Convert.ToInt32(d1 * CDbl(pbPoster.Width))
                            EndPosterLoadingAnim()
                            Return
                        End Using
                    End If
                End Using
                webClient1 = New System.Net.WebClient
                AddHandler webClient1.DownloadStringCompleted, AddressOf wc_DownloadStringCompleted
                webClient1.DownloadStringAsync(New System.Uri(System.String.Format("http://www.imdb.com/title/{0}?", m_imdbId)))
            Catch 
                pbPoster.Image = Nothing
                EndPosterLoadingAnim()
            Finally
                If Not (webClient1) Is Nothing Then
                    webClient1.Dispose()
                End If
            End Try
        End Sub

        Private Sub Init(ByVal subtitle As Sublight.WS.Subtitle, ByVal firstTab As Sublight.FrmDetails2.FirstTab)
            Dim nullable7 As System.Nullable(Of Integer)

            AddHandler ctrlSubtitleStatus.StatusClick, AddressOf ctrlSubtitleStatus_StatusClick
            m_displayDetailsFirst = firstTab
            btnSave.Visible = False
            btnRemoveAKA.Visible = False
            btnEditAKA.Visible = False
            If firstTab = Sublight.FrmDetails2.FirstTab.Details Then
                tabControl.SelectTab(tabDetails)
            ElseIf firstTab = Sublight.FrmDetails2.FirstTab.Preview Then
                tabControl.SelectTab(tabPreview)
            ElseIf firstTab = Sublight.FrmDetails2.FirstTab.NFO Then
                tabControl.SelectTab(tabNFO)
            End If
            rateControl.RateNA = Sublight.Translation.Common_NotAvailable
            m_subtitle = subtitle
            btnCancel.Text = Sublight.Translation.Common_Button_Close
            FillLanguages()
            FillLanguagesComment()
            FillMediaType()
            FillDiscsCount()
            FillStatuses()
            FillGenres()
            FillAttributes()
            Sublight.Globals.SelectNotSelected(cbCommentLanguage)
            If Sublight.Properties.Settings.Default.SubtitleCommentLanguage < 0 Then
                Sublight.Globals.SelectNotSelected(cbCommentLanguage)
            Else 
                Dim flag1 As Boolean = False
                Dim i1 As Integer = 0
                While i1 < cbCommentLanguage.Items.Count
                    Dim listItem1 As Sublight.Types.ListItem = TryCast(cbCommentLanguage.Items(i1), Sublight.Types.ListItem)
                    If (Not (listItem1) Is Nothing) AndAlso (TypeOf listItem1.Value Is Sublight.WS.SubtitleLanguage) AndAlso (System.Convert.ToInt16(DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage)) = Sublight.Properties.Settings.Default.SubtitleCommentLanguage) Then
                        flag1 = True
                        cbCommentLanguage.SelectedIndex = i1
                        Exit While
                    End If
                    i1 = i1 + 1
                End While
                If Not flag1 Then
                    Sublight.Globals.SelectNotSelected(cbCommentLanguage)
                End If
            End If
            AddHandler cbCommentLanguage.SelectedIndexChanged, AddressOf cbCommentLanguage_SelectedIndexChanged
            ldPoster.Visible = False
            ldPoster.Left = pbPoster.Left + (pbPoster.Width / 2) - (ldPoster.Width / 2)
            ldPoster.Top = pbPoster.Top + (pbPoster.Height / 2) - (ldPoster.Height / 2)
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            If Not (m_subtitle) Is Nothing Then
                Dim nullable6 As System.Nullable(Of Integer) = m_subtitle.Year
                If nullable6.get_HasValue() Then
                    Dim nullable5 As System.Nullable(Of Integer) = m_subtitle.Year
                    Text = System.String.Format("{0} ({1})?", m_subtitle.Title, nullable5.get_Value())
                Else 
                    Text = m_subtitle.Title
                End If
                Text = Text + System.String.Format(", {0}?", Sublight.Globals.GetString(m_subtitle.Language))
                m_imdbId = m_subtitle.IMDB
                Dim i2 As Integer = m_subtitle.IMDB.LastIndexOf("/"C)
                If i2 >= 0 Then
                    m_imdbId = m_imdbId.Substring(i2 + 1)
                End If
                txtPublisher.Text = m_subtitle.Publisher
                txtPublishTS.Text = System.String.Format("{0}?", m_subtitle.Created)
                Dim nullable8 As System.Nullable(Of Byte) = m_subtitle.Season
                If Not nullable8.get_HasValue() Then
                    GoTo label_0
                End If
                nullable7 = New System.Nullable(Of Integer)[]
                Dim nullable4 As System.Nullable(Of Integer) = New System.Nullable(Of Integer)(nullable8.GetValueOrDefault())
                If nullable4.get_HasValue() Then
                    Dim nullable1 As System.Nullable(Of Byte) = m_subtitle.Season
                    Dim b1 As Byte = nullable1.get_Value()
                    txtSeason.Text = b1.ToString()
                End If
                Dim nullable3 As System.Nullable(Of Integer) = m_subtitle.Episode
                If nullable3.get_HasValue() Then
                    Dim nullable2 As System.Nullable(Of Integer) = m_subtitle.Episode
                    Dim i3 As Integer = nullable2.get_Value()
                    txtEpisode.Text = i3.ToString()
                End If
                txtComment.Text = m_subtitle.Comment
                Dim i4 As Integer = m_subtitle.Downloads
                txtDownloads.Text = i4.ToString()
                Dim i5 As Integer = m_subtitle.Reports
                txtReports.Text = i5.ToString()
                Dim i6 As Integer = m_subtitle.Votes
                txtVotes.Text = i6.ToString()
                rateControl.Rate = CDbl(m_subtitle.Rate)
                txtSize.Text = System.String.Format("{0}?", System.Convert.ToInt32(CDbl(subtitle.Size) / 1024.0R))
                Sublight.Types.ListItem.Select(cbMediaType, m_subtitle.MediaType)
                Sublight.Types.ListItem.Select(cbMediaCount, m_subtitle.NumberOfDiscs)
                Sublight.Types.ListItem.Select(cbStatus, Sublight.Common.Utility.SubtitleStatusUtil.GetSubtitleStatus(m_subtitle.Status))
                Sublight.Types.ListItem.Select(cbType, m_subtitle.Genre)
                SelectLanguage(m_subtitle.Language)
                txtSubtitleFormat.Text = subtitle.SubtitleType.ToString().ToLower()
                btnShowHideAddComment_Click(Me, Nothing)
                AddHandler ctrlComments.ReportClicked, AddressOf ctrlComments_ReportClicked
                AddHandler ctrlComments.VoteClicked, AddressOf ctrlComments_VoteClicked
                AddHandler ctrlComments.PageChanged, AddressOf ctrlComments_PageChanged
                AddHandler ctrlComments.LoadFirstPage, AddressOf ctrlComments_LoadFirstPage
                AddHandler ctrlComments.AdminDeleteClicked, AddressOf ctrlComments_AdminDeleteClicked
            Else 
                Text = System.String.Empty
                m_imdbId = Nothing
            End If
            If Sublight.BaseForm.IsAdministrator() Then
                btnAddAKA.Visible = True
                btnAddAKA.Enabled = True
                btnEditRelease.Enabled = True
                btnEditRelease.Visible = True
                btnRemoveRelease.Enabled = True
                btnRemoveRelease.Visible = True
                cbStatus.Enabled = True
                btnReportSubtitle.Visible = False
                Height = 718
            ElseIf Sublight.BaseForm.IsSubtitleEditor(m_subtitle) Then
                btnAddAKA.Visible = True
                btnAddAKA.Enabled = True
                btnEditRelease.Visible = True
                btnRemoveRelease.Visible = True
                Height = 718
                cbStatus.Enabled = True
                btnReportSubtitle.Visible = False
            Else 
                btnAddAKA.Visible = True
                btnAddAKA.Enabled = False
                cbStatus.Enabled = False
                btnReportSubtitle.Visible = True
                btnEditRelease.Visible = False
                btnRemoveRelease.Visible = False
                Height = 718
                btnSave.Visible = False
            End If
            btnSendMessageToPublisher.Visible = False
            Events_LanguageChanged(Me, Nothing)
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            myPanel1 = New Sublight.Controls.MyPanel
            btnSendMessageToPublisher = New Sublight.Controls.Button.Button
            ctrlSubtitleStatus = New Sublight.Controls.CtrlSubtitleStatus
            btnReportSubtitle = New Sublight.Controls.Button.Button
            btnSave = New Sublight.Controls.Button.Button
            btnCancel = New Sublight.Controls.Button.Button
            tabControl = New System.Windows.Forms.TabControl
            tabDetails = New System.Windows.Forms.TabPage
            legendLabel1 = New Sublight.Controls.LegendLabel
            tcSubtitleDetails = New System.Windows.Forms.TabControl
            tpSDGeneral = New System.Windows.Forms.TabPage
            rateControl = New Sublight.Controls.RateControl
            txtReports = New Sublight.Controls.MyTextBox
            lblReports = New System.Windows.Forms.Label
            cbType = New Sublight.Controls.MyComboBox
            lblType = New System.Windows.Forms.Label
            cbStatus = New Sublight.Controls.MyComboBox
            label1 = New System.Windows.Forms.Label
            cbMediaType = New Sublight.Controls.MyComboBox
            cbMediaCount = New Sublight.Controls.MyComboBox
            cbLanguage = New Sublight.Controls.MyComboBox
            lblSizeUnit = New System.Windows.Forms.Label
            txtSubtitleFormat = New Sublight.Controls.MyTextBox
            lblSubtitleFormat = New System.Windows.Forms.Label
            lblLanguage = New System.Windows.Forms.Label
            lblMedia = New System.Windows.Forms.Label
            txtSize = New Sublight.Controls.MyTextBox
            lblSize = New System.Windows.Forms.Label
            txtDownloads = New Sublight.Controls.MyTextBox
            lblDownloads = New System.Windows.Forms.Label
            lblRate = New System.Windows.Forms.Label
            txtVotes = New Sublight.Controls.MyTextBox
            lblVotes = New System.Windows.Forms.Label
            lblComment = New System.Windows.Forms.Label
            txtComment = New Sublight.Controls.MyTextBox
            txtEpisode = New Sublight.Controls.MyTextBox
            lblEpisode = New System.Windows.Forms.Label
            txtSeason = New Sublight.Controls.MyTextBox
            lblSeason = New System.Windows.Forms.Label
            txtPublishTS = New Sublight.Controls.MyTextBox
            lblPublishTS = New System.Windows.Forms.Label
            txtPublisher = New Sublight.Controls.MyTextBox
            lblPublisher = New System.Windows.Forms.Label
            tpSDReleases = New System.Windows.Forms.TabPage
            btnRemoveRelease = New Sublight.Controls.Button.Button
            btnEditRelease = New Sublight.Controls.Button.Button
            btnAddRelease = New Sublight.Controls.Button.Button
            lbReleases = New System.Windows.Forms.ListBox
            tpSDAttributes = New System.Windows.Forms.TabPage
            lblAttrLinkedDesc = New System.Windows.Forms.Label
            lblAttrLinked = New System.Windows.Forms.Label
            txtAttrLinked = New Sublight.Controls.MyTextBox
            lblAttrStandardDesc = New System.Windows.Forms.Label
            lblAttrStandard = New System.Windows.Forms.Label
            txtAttrStandard = New Sublight.Controls.MyTextBox
            lblAttrStatusDesc = New System.Windows.Forms.Label
            lblAttrStatus = New System.Windows.Forms.Label
            txtAttrStatus = New Sublight.Controls.MyTextBox
            myGroupBox2 = New Sublight.Controls.MyGroupBox
            btnFindIMDB = New Sublight.Controls.Button.Button
            lblNoImage = New System.Windows.Forms.Label
            ldPoster = New Sublight.Controls.Loading
            btnRemoveAKA = New Sublight.Controls.Button.Button
            btnEditAKA = New Sublight.Controls.Button.Button
            btnAddAKA = New Sublight.Controls.Button.Button
            lblAKA = New System.Windows.Forms.Label
            lbAKA = New System.Windows.Forms.ListBox
            lnkImdb = New System.Windows.Forms.LinkLabel
            lblYearDash = New System.Windows.Forms.Label
            txtYearTo = New Sublight.Controls.MyTextBox
            txtYear = New Sublight.Controls.MyTextBox
            lblYear = New System.Windows.Forms.Label
            txtImdb = New Sublight.Controls.MyTextBox
            lblImdb = New System.Windows.Forms.Label
            txtTitle = New Sublight.Controls.MyTextBox
            lblTitle = New System.Windows.Forms.Label
            pbPoster = New System.Windows.Forms.PictureBox
            tabPreview = New System.Windows.Forms.TabPage
            listView1 = New System.Windows.Forms.ListView
            colNum = New System.Windows.Forms.ColumnHeader
            colText = New System.Windows.Forms.ColumnHeader
            myPanel2 = New Sublight.Controls.MyPanel
            txtNumWords = New Sublight.Controls.MyTextBox
            lblNumWords = New System.Windows.Forms.Label
            txtNumDialogs = New Sublight.Controls.MyTextBox
            lblNumDialogs = New System.Windows.Forms.Label
            tabHistory = New System.Windows.Forms.TabPage
            lvHistory = New System.Windows.Forms.ListView
            colHistoryDT = New System.Windows.Forms.ColumnHeader
            colHistoryUser = New System.Windows.Forms.ColumnHeader
            colHistoryDescription = New System.Windows.Forms.ColumnHeader
            tabComments = New System.Windows.Forms.TabPage
            ctrlComments = New Sublight.Controls.CommentsControl.CommentItems
            panelCommentsTop = New Sublight.Controls.MyPanel
            lblCommentNote = New System.Windows.Forms.Label
            gbAddComment = New Sublight.Controls.MyGroupBox
            btnSendComment = New Sublight.Controls.Button.Button
            txtAddComment = New Sublight.Controls.MyTextBox
            cbCommentLanguage = New Sublight.Controls.MyComboBox
            lblCommentLanguage = New System.Windows.Forms.Label
            btnShowHideAddComment = New Sublight.Controls.Button.Button
            tabThanks = New System.Windows.Forms.TabPage
            lvThanks = New System.Windows.Forms.ListView
            colThanksCreated = New System.Windows.Forms.ColumnHeader
            colThanksUser = New System.Windows.Forms.ColumnHeader
            myPanel3 = New Sublight.Controls.MyPanel
            btnThanks = New Sublight.Controls.Button.Button
            tabNFO = New System.Windows.Forms.TabPage
            txtNFO = New Sublight.Controls.MyTextBox
            cmHistory = New System.Windows.Forms.ContextMenuStrip(components)
            tmrDetailsHideLoader = New System.Windows.Forms.Timer(components)
            myPanel1.SuspendLayout()
            tabControl.SuspendLayout()
            tabDetails.SuspendLayout()
            tcSubtitleDetails.SuspendLayout()
            tpSDGeneral.SuspendLayout()
            tpSDReleases.SuspendLayout()
            tpSDAttributes.SuspendLayout()
            myGroupBox2.SuspendLayout()
            pbPoster.BeginInit()
            tabPreview.SuspendLayout()
            myPanel2.SuspendLayout()
            tabHistory.SuspendLayout()
            tabComments.SuspendLayout()
            panelCommentsTop.SuspendLayout()
            gbAddComment.SuspendLayout()
            tabThanks.SuspendLayout()
            myPanel3.SuspendLayout()
            tabNFO.SuspendLayout()
            SuspendLayout()
            myPanel1.Controls.Add(btnSendMessageToPublisher)
            myPanel1.Controls.Add(ctrlSubtitleStatus)
            myPanel1.Controls.Add(btnReportSubtitle)
            myPanel1.Controls.Add(btnSave)
            myPanel1.Controls.Add(btnCancel)
            myPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
            myPanel1.Location = New System.Drawing.Point(0, 664)
            myPanel1.Name = "myPanel1?"
            myPanel1.Size = New System.Drawing.Size(496, 31)
            myPanel1.TabIndex = 1
            btnSendMessageToPublisher.AutoResize = False
            btnSendMessageToPublisher.DialogResult = System.Windows.Forms.DialogResult.None
            btnSendMessageToPublisher.Location = New System.Drawing.Point(3, 3)
            btnSendMessageToPublisher.Name = "btnSendMessageToPublisher?"
            btnSendMessageToPublisher.Size = New System.Drawing.Size(183, 23)
            btnSendMessageToPublisher.TabIndex = 179
            btnSendMessageToPublisher.Text = "Pošlji sporocilo pošiljatelju...?"
            btnSendMessageToPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            btnSendMessageToPublisher.Visible = False
            AddHandler btnSendMessageToPublisher.Click, AddressOf btnSendMessageToPublisher_Click
            ctrlSubtitleStatus.Location = New System.Drawing.Point(3, 2)
            ctrlSubtitleStatus.Name = "ctrlSubtitleStatus?"
            ctrlSubtitleStatus.Size = New System.Drawing.Size(327, 26)
            ctrlSubtitleStatus.TabIndex = 180
            ctrlSubtitleStatus.Visible = False
            btnReportSubtitle.AutoResize = False
            btnReportSubtitle.DialogResult = System.Windows.Forms.DialogResult.None
            btnReportSubtitle.Location = New System.Drawing.Point(3, 3)
            btnReportSubtitle.Name = "btnReportSubtitle?"
            btnReportSubtitle.Size = New System.Drawing.Size(115, 23)
            btnReportSubtitle.TabIndex = 0
            btnReportSubtitle.Text = "Prijavi podnapis?"
            btnReportSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            btnReportSubtitle.Visible = False
            AddHandler btnReportSubtitle.Click, AddressOf btnReportSubtitle_Click
            btnSave.AutoResize = False
            btnSave.DialogResult = System.Windows.Forms.DialogResult.None
            btnSave.Location = New System.Drawing.Point(336, 3)
            btnSave.Name = "btnSave?"
            btnSave.Size = New System.Drawing.Size(75, 23)
            btnSave.TabIndex = 1
            btnSave.Text = "Shrani?"
            btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSave.Click, AddressOf btnSave_Click
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(417, 3)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 2
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            tabControl.Controls.Add(tabDetails)
            tabControl.Controls.Add(tabPreview)
            tabControl.Controls.Add(tabHistory)
            tabControl.Controls.Add(tabComments)
            tabControl.Controls.Add(tabThanks)
            tabControl.Controls.Add(tabNFO)
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill
            tabControl.Location = New System.Drawing.Point(0, 0)
            tabControl.Name = "tabControl?"
            tabControl.SelectedIndex = 0
            tabControl.Size = New System.Drawing.Size(496, 664)
            tabControl.TabIndex = 2
            AddHandler tabControl.SelectedIndexChanged, AddressOf tabControl_SelectedIndexChanged
            tabDetails.BackColor = System.Drawing.Color.Transparent
            tabDetails.Controls.Add(legendLabel1)
            tabDetails.Controls.Add(tcSubtitleDetails)
            tabDetails.Controls.Add(myGroupBox2)
            tabDetails.Location = New System.Drawing.Point(4, 22)
            tabDetails.Name = "tabDetails?"
            tabDetails.Padding = New System.Windows.Forms.Padding(3)
            tabDetails.Size = New System.Drawing.Size(488, 638)
            tabDetails.TabIndex = 0
            tabDetails.Text = "Podrobnosti?"
            tabDetails.UseVisualStyleBackColor = True
            legendLabel1.AutoSize = True
            legendLabel1.LegendText = "?"
            legendLabel1.Location = New System.Drawing.Point(65, 610)
            legendLabel1.Name = "legendLabel1?"
            legendLabel1.Size = New System.Drawing.Size(268, 13)
            legendLabel1.TabIndex = 2
            tcSubtitleDetails.Controls.Add(tpSDGeneral)
            tcSubtitleDetails.Controls.Add(tpSDReleases)
            tcSubtitleDetails.Controls.Add(tpSDAttributes)
            tcSubtitleDetails.Location = New System.Drawing.Point(6, 239)
            tcSubtitleDetails.Name = "tcSubtitleDetails?"
            tcSubtitleDetails.SelectedIndex = 0
            tcSubtitleDetails.Size = New System.Drawing.Size(476, 362)
            tcSubtitleDetails.TabIndex = 3
            AddHandler tcSubtitleDetails.SelectedIndexChanged, AddressOf tcSubtitleDetails_SelectedIndexChanged
            tpSDGeneral.Controls.Add(rateControl)
            tpSDGeneral.Controls.Add(txtReports)
            tpSDGeneral.Controls.Add(lblReports)
            tpSDGeneral.Controls.Add(cbType)
            tpSDGeneral.Controls.Add(lblType)
            tpSDGeneral.Controls.Add(cbStatus)
            tpSDGeneral.Controls.Add(label1)
            tpSDGeneral.Controls.Add(cbMediaType)
            tpSDGeneral.Controls.Add(cbMediaCount)
            tpSDGeneral.Controls.Add(cbLanguage)
            tpSDGeneral.Controls.Add(lblSizeUnit)
            tpSDGeneral.Controls.Add(txtSubtitleFormat)
            tpSDGeneral.Controls.Add(lblSubtitleFormat)
            tpSDGeneral.Controls.Add(lblLanguage)
            tpSDGeneral.Controls.Add(lblMedia)
            tpSDGeneral.Controls.Add(txtSize)
            tpSDGeneral.Controls.Add(lblSize)
            tpSDGeneral.Controls.Add(txtDownloads)
            tpSDGeneral.Controls.Add(lblDownloads)
            tpSDGeneral.Controls.Add(lblRate)
            tpSDGeneral.Controls.Add(txtVotes)
            tpSDGeneral.Controls.Add(lblVotes)
            tpSDGeneral.Controls.Add(lblComment)
            tpSDGeneral.Controls.Add(txtComment)
            tpSDGeneral.Controls.Add(txtEpisode)
            tpSDGeneral.Controls.Add(lblEpisode)
            tpSDGeneral.Controls.Add(txtSeason)
            tpSDGeneral.Controls.Add(lblSeason)
            tpSDGeneral.Controls.Add(txtPublishTS)
            tpSDGeneral.Controls.Add(lblPublishTS)
            tpSDGeneral.Controls.Add(txtPublisher)
            tpSDGeneral.Controls.Add(lblPublisher)
            tpSDGeneral.Location = New System.Drawing.Point(4, 22)
            tpSDGeneral.Name = "tpSDGeneral?"
            tpSDGeneral.Padding = New System.Windows.Forms.Padding(3)
            tpSDGeneral.Size = New System.Drawing.Size(468, 336)
            tpSDGeneral.TabIndex = 0
            tpSDGeneral.Text = "General?"
            tpSDGeneral.UseVisualStyleBackColor = True
            rateControl.EnableRating = True
            rateControl.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F)
            rateControl.Location = New System.Drawing.Point(288, 151)
            rateControl.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            rateControl.Name = "rateControl?"
            rateControl.Rate = 0.0R
            rateControl.RateNA = Nothing
            rateControl.Size = New System.Drawing.Size(165, 13)
            rateControl.TabIndex = 192
            AddHandler rateControl.RateClicked, AddressOf rateControl_RateClicked
            txtReports.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtReports.EnableDisableColor = True
            txtReports.Location = New System.Drawing.Point(288, 119)
            txtReports.Name = "txtReports?"
            txtReports.ReadOnly = True
            txtReports.Size = New System.Drawing.Size(36, 20)
            txtReports.TabIndex = 189
            lblReports.AutoSize = True
            lblReports.Location = New System.Drawing.Point(209, 123)
            lblReports.Name = "lblReports?"
            lblReports.Size = New System.Drawing.Size(42, 13)
            lblReports.TabIndex = 212
            lblReports.Text = "Prijave:?"
            cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbType.FormattingEnabled = True
            cbType.Location = New System.Drawing.Point(66, 119)
            cbType.Name = "cbType?"
            cbType.Size = New System.Drawing.Size(134, 21)
            cbType.TabIndex = 193
            lblType.AutoSize = True
            lblType.Location = New System.Drawing.Point(4, 123)
            lblType.Name = "lblType?"
            lblType.Size = New System.Drawing.Size(25, 13)
            lblType.TabIndex = 211
            lblType.Text = "Tip:?"
            cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbStatus.FormattingEnabled = True
            cbStatus.Location = New System.Drawing.Point(66, 175)
            cbStatus.Name = "cbStatus?"
            cbStatus.Size = New System.Drawing.Size(134, 21)
            cbStatus.TabIndex = 196
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(4, 178)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(40, 13)
            label1.TabIndex = 210
            label1.Text = "Status:?"
            cbMediaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbMediaType.FormattingEnabled = True
            cbMediaType.Location = New System.Drawing.Point(115, 147)
            cbMediaType.Name = "cbMediaType?"
            cbMediaType.Size = New System.Drawing.Size(85, 21)
            cbMediaType.TabIndex = 195
            cbMediaCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbMediaCount.FormattingEnabled = True
            cbMediaCount.Location = New System.Drawing.Point(66, 147)
            cbMediaCount.Name = "cbMediaCount?"
            cbMediaCount.Size = New System.Drawing.Size(42, 21)
            cbMediaCount.TabIndex = 209
            cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbLanguage.FormattingEnabled = True
            cbLanguage.Location = New System.Drawing.Point(66, 68)
            cbLanguage.Name = "cbLanguage?"
            cbLanguage.Size = New System.Drawing.Size(134, 21)
            cbLanguage.TabIndex = 186
            lblSizeUnit.AutoSize = True
            lblSizeUnit.Location = New System.Drawing.Point(333, 71)
            lblSizeUnit.Name = "lblSizeUnit?"
            lblSizeUnit.Size = New System.Drawing.Size(21, 13)
            lblSizeUnit.TabIndex = 208
            lblSizeUnit.Text = "KB?"
            txtSubtitleFormat.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtSubtitleFormat.EnableDisableColor = True
            txtSubtitleFormat.Location = New System.Drawing.Point(66, 94)
            txtSubtitleFormat.Name = "txtSubtitleFormat?"
            txtSubtitleFormat.ReadOnly = True
            txtSubtitleFormat.Size = New System.Drawing.Size(134, 20)
            txtSubtitleFormat.TabIndex = 190
            lblSubtitleFormat.AutoSize = True
            lblSubtitleFormat.Location = New System.Drawing.Point(4, 97)
            lblSubtitleFormat.Name = "lblSubtitleFormat?"
            lblSubtitleFormat.Size = New System.Drawing.Size(42, 13)
            lblSubtitleFormat.TabIndex = 206
            lblSubtitleFormat.Text = "Format:?"
            lblLanguage.AutoSize = True
            lblLanguage.Location = New System.Drawing.Point(4, 71)
            lblLanguage.Name = "lblLanguage?"
            lblLanguage.Size = New System.Drawing.Size(34, 13)
            lblLanguage.TabIndex = 205
            lblLanguage.Text = "Jezik:?"
            lblMedia.AutoSize = True
            lblMedia.Location = New System.Drawing.Point(4, 151)
            lblMedia.Name = "lblMedia?"
            lblMedia.Size = New System.Drawing.Size(35, 13)
            lblMedia.TabIndex = 204
            lblMedia.Text = "Medij:?"
            txtSize.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtSize.EnableDisableColor = True
            txtSize.Location = New System.Drawing.Point(288, 69)
            txtSize.Name = "txtSize?"
            txtSize.ReadOnly = True
            txtSize.Size = New System.Drawing.Size(36, 20)
            txtSize.TabIndex = 185
            lblSize.AutoSize = True
            lblSize.Location = New System.Drawing.Point(209, 71)
            lblSize.Name = "lblSize?"
            lblSize.Size = New System.Drawing.Size(47, 13)
            lblSize.TabIndex = 203
            lblSize.Text = "Velikost:?"
            txtDownloads.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtDownloads.EnableDisableColor = True
            txtDownloads.Location = New System.Drawing.Point(288, 42)
            txtDownloads.Name = "txtDownloads?"
            txtDownloads.ReadOnly = True
            txtDownloads.Size = New System.Drawing.Size(36, 20)
            txtDownloads.TabIndex = 184
            lblDownloads.AutoSize = True
            lblDownloads.Location = New System.Drawing.Point(209, 45)
            lblDownloads.Name = "lblDownloads?"
            lblDownloads.Size = New System.Drawing.Size(45, 13)
            lblDownloads.TabIndex = 202
            lblDownloads.Text = "Prenosi:?"
            lblRate.AutoSize = True
            lblRate.Location = New System.Drawing.Point(209, 151)
            lblRate.Name = "lblRate?"
            lblRate.Size = New System.Drawing.Size(42, 13)
            lblRate.TabIndex = 201
            lblRate.Text = "Ocena:?"
            txtVotes.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtVotes.EnableDisableColor = True
            txtVotes.Location = New System.Drawing.Point(288, 94)
            txtVotes.Name = "txtVotes?"
            txtVotes.ReadOnly = True
            txtVotes.Size = New System.Drawing.Size(36, 20)
            txtVotes.TabIndex = 187
            lblVotes.AutoSize = True
            lblVotes.Location = New System.Drawing.Point(209, 97)
            lblVotes.Name = "lblVotes?"
            lblVotes.Size = New System.Drawing.Size(45, 13)
            lblVotes.TabIndex = 200
            lblVotes.Text = "Glasovi:?"
            lblComment.AutoSize = True
            lblComment.Location = New System.Drawing.Point(4, 220)
            lblComment.Name = "lblComment?"
            lblComment.Size = New System.Drawing.Size(55, 13)
            lblComment.TabIndex = 199
            lblComment.Text = "Komentar:?"
            txtComment.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtComment.EnableDisableColor = True
            txtComment.Location = New System.Drawing.Point(7, 240)
            txtComment.Multiline = True
            txtComment.Name = "txtComment?"
            txtComment.ReadOnly = True
            txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            txtComment.Size = New System.Drawing.Size(419, 80)
            txtComment.TabIndex = 198
            txtEpisode.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtEpisode.EnableDisableColor = True
            txtEpisode.Location = New System.Drawing.Point(390, 15)
            txtEpisode.Name = "txtEpisode?"
            txtEpisode.ReadOnly = True
            txtEpisode.Size = New System.Drawing.Size(36, 20)
            txtEpisode.TabIndex = 182
            lblEpisode.AutoSize = True
            lblEpisode.Location = New System.Drawing.Point(333, 19)
            lblEpisode.Name = "lblEpisode?"
            lblEpisode.Size = New System.Drawing.Size(48, 13)
            lblEpisode.TabIndex = 197
            lblEpisode.Text = "Epizoda:?"
            txtSeason.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtSeason.EnableDisableColor = True
            txtSeason.Location = New System.Drawing.Point(288, 15)
            txtSeason.Name = "txtSeason?"
            txtSeason.ReadOnly = True
            txtSeason.Size = New System.Drawing.Size(36, 20)
            txtSeason.TabIndex = 181
            lblSeason.AutoSize = True
            lblSeason.Location = New System.Drawing.Point(209, 19)
            lblSeason.Name = "lblSeason?"
            lblSeason.Size = New System.Drawing.Size(46, 13)
            lblSeason.TabIndex = 194
            lblSeason.Text = "Sezona:?"
            txtPublishTS.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtPublishTS.EnableDisableColor = True
            txtPublishTS.Location = New System.Drawing.Point(66, 42)
            txtPublishTS.Name = "txtPublishTS?"
            txtPublishTS.ReadOnly = True
            txtPublishTS.Size = New System.Drawing.Size(134, 20)
            txtPublishTS.TabIndex = 183
            lblPublishTS.AutoSize = True
            lblPublishTS.Location = New System.Drawing.Point(4, 45)
            lblPublishTS.Name = "lblPublishTS?"
            lblPublishTS.Size = New System.Drawing.Size(48, 13)
            lblPublishTS.TabIndex = 191
            lblPublishTS.Text = "Poslano:?"
            txtPublisher.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtPublisher.EnableDisableColor = True
            txtPublisher.Location = New System.Drawing.Point(66, 16)
            txtPublisher.Name = "txtPublisher?"
            txtPublisher.ReadOnly = True
            txtPublisher.Size = New System.Drawing.Size(134, 20)
            txtPublisher.TabIndex = 180
            lblPublisher.AutoSize = True
            lblPublisher.Location = New System.Drawing.Point(4, 19)
            lblPublisher.Name = "lblPublisher?"
            lblPublisher.Size = New System.Drawing.Size(53, 13)
            lblPublisher.TabIndex = 188
            lblPublisher.Text = "Pošiljatelj:?"
            tpSDReleases.Controls.Add(btnRemoveRelease)
            tpSDReleases.Controls.Add(btnEditRelease)
            tpSDReleases.Controls.Add(btnAddRelease)
            tpSDReleases.Controls.Add(lbReleases)
            tpSDReleases.Location = New System.Drawing.Point(4, 22)
            tpSDReleases.Name = "tpSDReleases?"
            tpSDReleases.Size = New System.Drawing.Size(468, 336)
            tpSDReleases.TabIndex = 1
            tpSDReleases.Text = "Releases?"
            tpSDReleases.UseVisualStyleBackColor = True
            btnRemoveRelease.AutoResize = False
            btnRemoveRelease.DialogResult = System.Windows.Forms.DialogResult.None
            btnRemoveRelease.Enabled = False
            btnRemoveRelease.Location = New System.Drawing.Point(389, 65)
            btnRemoveRelease.Name = "btnRemoveRelease?"
            btnRemoveRelease.Size = New System.Drawing.Size(75, 23)
            btnRemoveRelease.TabIndex = 23
            btnRemoveRelease.Text = "Odstrani?"
            btnRemoveRelease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnRemoveRelease.Click, AddressOf btnRemoveRelease_Click
            btnEditRelease.AutoResize = False
            btnEditRelease.DialogResult = System.Windows.Forms.DialogResult.None
            btnEditRelease.Enabled = False
            btnEditRelease.Location = New System.Drawing.Point(389, 37)
            btnEditRelease.Name = "btnEditRelease?"
            btnEditRelease.Size = New System.Drawing.Size(75, 23)
            btnEditRelease.TabIndex = 22
            btnEditRelease.Text = "Uredi...?"
            btnEditRelease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnEditRelease.Click, AddressOf btnEditRelease_Click
            btnAddRelease.AutoResize = False
            btnAddRelease.DialogResult = System.Windows.Forms.DialogResult.None
            btnAddRelease.Enabled = False
            btnAddRelease.Location = New System.Drawing.Point(389, 9)
            btnAddRelease.Name = "btnAddRelease?"
            btnAddRelease.Size = New System.Drawing.Size(75, 23)
            btnAddRelease.TabIndex = 21
            btnAddRelease.Text = "Dodaj...?"
            btnAddRelease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnAddRelease.Click, AddressOf btnAddRelease_Click
            lbReleases.FormattingEnabled = True
            lbReleases.Location = New System.Drawing.Point(3, 9)
            lbReleases.Name = "lbReleases?"
            lbReleases.Size = New System.Drawing.Size(379, 238)
            lbReleases.TabIndex = 20
            tpSDAttributes.Controls.Add(lblAttrLinkedDesc)
            tpSDAttributes.Controls.Add(lblAttrLinked)
            tpSDAttributes.Controls.Add(txtAttrLinked)
            tpSDAttributes.Controls.Add(lblAttrStandardDesc)
            tpSDAttributes.Controls.Add(lblAttrStandard)
            tpSDAttributes.Controls.Add(txtAttrStandard)
            tpSDAttributes.Controls.Add(lblAttrStatusDesc)
            tpSDAttributes.Controls.Add(lblAttrStatus)
            tpSDAttributes.Controls.Add(txtAttrStatus)
            tpSDAttributes.Location = New System.Drawing.Point(4, 22)
            tpSDAttributes.Name = "tpSDAttributes?"
            tpSDAttributes.Size = New System.Drawing.Size(468, 336)
            tpSDAttributes.TabIndex = 2
            tpSDAttributes.Text = "Attributes?"
            tpSDAttributes.UseVisualStyleBackColor = True
            lblAttrLinkedDesc.AutoSize = True
            lblAttrLinkedDesc.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblAttrLinkedDesc.Location = New System.Drawing.Point(79, 191)
            lblAttrLinkedDesc.Name = "lblAttrLinkedDesc?"
            lblAttrLinkedDesc.Size = New System.Drawing.Size(60, 13)
            lblAttrLinkedDesc.TabIndex = 9
            lblAttrLinkedDesc.Text = "Description?"
            lblAttrLinked.AutoSize = True
            lblAttrLinked.Location = New System.Drawing.Point(12, 162)
            lblAttrLinked.Name = "lblAttrLinked?"
            lblAttrLinked.Size = New System.Drawing.Size(112, 13)
            lblAttrLinked.TabIndex = 8
            lblAttrLinked.Text = "Movie link information:?"
            txtAttrLinked.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtAttrLinked.EnableDisableColor = True
            txtAttrLinked.Location = New System.Drawing.Point(41, 188)
            txtAttrLinked.Name = "txtAttrLinked?"
            txtAttrLinked.ReadOnly = True
            txtAttrLinked.Size = New System.Drawing.Size(32, 20)
            txtAttrLinked.TabIndex = 7
            txtAttrLinked.Text = "X?"
            lblAttrStandardDesc.AutoSize = True
            lblAttrStandardDesc.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblAttrStandardDesc.Location = New System.Drawing.Point(79, 122)
            lblAttrStandardDesc.Name = "lblAttrStandardDesc?"
            lblAttrStandardDesc.Size = New System.Drawing.Size(60, 13)
            lblAttrStandardDesc.TabIndex = 6
            lblAttrStandardDesc.Text = "Description?"
            lblAttrStandard.AutoSize = True
            lblAttrStandard.Location = New System.Drawing.Point(12, 93)
            lblAttrStandard.Name = "lblAttrStandard?"
            lblAttrStandard.Size = New System.Drawing.Size(110, 13)
            lblAttrStandard.TabIndex = 5
            lblAttrStandard.Text = "Standard compliance:?"
            txtAttrStandard.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtAttrStandard.EnableDisableColor = True
            txtAttrStandard.Location = New System.Drawing.Point(41, 119)
            txtAttrStandard.Name = "txtAttrStandard?"
            txtAttrStandard.ReadOnly = True
            txtAttrStandard.Size = New System.Drawing.Size(32, 20)
            txtAttrStandard.TabIndex = 4
            txtAttrStandard.Text = "X?"
            lblAttrStatusDesc.AutoSize = True
            lblAttrStatusDesc.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblAttrStatusDesc.Location = New System.Drawing.Point(79, 51)
            lblAttrStatusDesc.Name = "lblAttrStatusDesc?"
            lblAttrStatusDesc.Size = New System.Drawing.Size(60, 13)
            lblAttrStatusDesc.TabIndex = 3
            lblAttrStatusDesc.Text = "Description?"
            lblAttrStatus.AutoSize = True
            lblAttrStatus.Location = New System.Drawing.Point(12, 22)
            lblAttrStatus.Name = "lblAttrStatus?"
            lblAttrStatus.Size = New System.Drawing.Size(76, 13)
            lblAttrStatus.TabIndex = 2
            lblAttrStatus.Text = "Subtitle status:?"
            txtAttrStatus.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtAttrStatus.EnableDisableColor = True
            txtAttrStatus.Location = New System.Drawing.Point(41, 48)
            txtAttrStatus.Name = "txtAttrStatus?"
            txtAttrStatus.ReadOnly = True
            txtAttrStatus.Size = New System.Drawing.Size(32, 20)
            txtAttrStatus.TabIndex = 1
            txtAttrStatus.Text = "X?"
            myGroupBox2.Controls.Add(btnFindIMDB)
            myGroupBox2.Controls.Add(lblNoImage)
            myGroupBox2.Controls.Add(ldPoster)
            myGroupBox2.Controls.Add(btnRemoveAKA)
            myGroupBox2.Controls.Add(btnEditAKA)
            myGroupBox2.Controls.Add(btnAddAKA)
            myGroupBox2.Controls.Add(lblAKA)
            myGroupBox2.Controls.Add(lbAKA)
            myGroupBox2.Controls.Add(lnkImdb)
            myGroupBox2.Controls.Add(lblYearDash)
            myGroupBox2.Controls.Add(txtYearTo)
            myGroupBox2.Controls.Add(txtYear)
            myGroupBox2.Controls.Add(lblYear)
            myGroupBox2.Controls.Add(txtImdb)
            myGroupBox2.Controls.Add(lblImdb)
            myGroupBox2.Controls.Add(txtTitle)
            myGroupBox2.Controls.Add(lblTitle)
            myGroupBox2.Controls.Add(pbPoster)
            myGroupBox2.DrawTextBackground = False
            myGroupBox2.Location = New System.Drawing.Point(6, 6)
            myGroupBox2.Name = "myGroupBox2?"
            myGroupBox2.Size = New System.Drawing.Size(476, 220)
            myGroupBox2.TabIndex = 1
            myGroupBox2.TabStop = False
            myGroupBox2.Text = "Informacije o filmu?"
            btnFindIMDB.AutoResize = False
            btnFindIMDB.BackColor = System.Drawing.Color.Transparent
            btnFindIMDB.DialogResult = System.Windows.Forms.DialogResult.None
            btnFindIMDB.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnFindIMDB.Location = New System.Drawing.Point(312, 18)
            btnFindIMDB.Name = "btnFindIMDB?"
            btnFindIMDB.Size = New System.Drawing.Size(75, 23)
            btnFindIMDB.TabIndex = 135
            btnFindIMDB.Text = "Najdi...?"
            btnFindIMDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnFindIMDB.Click, AddressOf btnFindIMDB_Click
            lblNoImage.Location = New System.Drawing.Point(16, 130)
            lblNoImage.Name = "lblNoImage?"
            lblNoImage.Size = New System.Drawing.Size(75, 23)
            lblNoImage.TabIndex = 20
            lblNoImage.Text = "No image?"
            lblNoImage.TextAlign = System.Drawing.ContentAlignment.TopRight
            lblNoImage.Visible = False
            ldPoster.DrawFrame = False
            ldPoster.Location = New System.Drawing.Point(45, 75)
            ldPoster.Name = "ldPoster?"
            ldPoster.Size = New System.Drawing.Size(16, 16)
            ldPoster.TabIndex = 18
            btnRemoveAKA.AutoResize = False
            btnRemoveAKA.DialogResult = System.Windows.Forms.DialogResult.None
            btnRemoveAKA.Enabled = False
            btnRemoveAKA.Location = New System.Drawing.Point(231, 189)
            btnRemoveAKA.Name = "btnRemoveAKA?"
            btnRemoveAKA.Size = New System.Drawing.Size(75, 23)
            btnRemoveAKA.TabIndex = 7
            btnRemoveAKA.Text = "Odstrani?"
            btnRemoveAKA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            btnEditAKA.AutoResize = False
            btnEditAKA.DialogResult = System.Windows.Forms.DialogResult.None
            btnEditAKA.Enabled = False
            btnEditAKA.Location = New System.Drawing.Point(312, 189)
            btnEditAKA.Name = "btnEditAKA?"
            btnEditAKA.Size = New System.Drawing.Size(75, 23)
            btnEditAKA.TabIndex = 6
            btnEditAKA.Text = "Uredi...?"
            btnEditAKA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            btnAddAKA.AutoResize = False
            btnAddAKA.DialogResult = System.Windows.Forms.DialogResult.None
            btnAddAKA.Enabled = False
            btnAddAKA.Location = New System.Drawing.Point(393, 189)
            btnAddAKA.Name = "btnAddAKA?"
            btnAddAKA.Size = New System.Drawing.Size(75, 23)
            btnAddAKA.TabIndex = 5
            btnAddAKA.Text = "Dodaj...?"
            btnAddAKA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnAddAKA.Click, AddressOf btnAddAKA_Click
            lblAKA.Location = New System.Drawing.Point(106, 97)
            lblAKA.Name = "lblAKA?"
            lblAKA.Size = New System.Drawing.Size(61, 82)
            lblAKA.TabIndex = 14
            lblAKA.Text = "Drugi naslovi:?"
            lbAKA.FormattingEnabled = True
            lbAKA.Location = New System.Drawing.Point(176, 97)
            lbAKA.Name = "lbAKA?"
            lbAKA.Size = New System.Drawing.Size(292, 82)
            lbAKA.TabIndex = 4
            lnkImdb.Location = New System.Drawing.Point(3, 189)
            lnkImdb.Name = "lnkImdb?"
            lnkImdb.Size = New System.Drawing.Size(383, 23)
            lnkImdb.TabIndex = 8
            lnkImdb.TabStop = True
            lnkImdb.Text = "http://www.imdb.com/title/tt0443649/?"
            lnkImdb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            AddHandler lnkImdb.LinkClicked, AddressOf lnkImdb_LinkClicked
            lblYearDash.AutoSize = True
            lblYearDash.Location = New System.Drawing.Point(222, 75)
            lblYearDash.Name = "lblYearDash?"
            lblYearDash.Size = New System.Drawing.Size(10, 13)
            lblYearDash.TabIndex = 3
            lblYearDash.Text = "-?"
            txtYearTo.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtYearTo.EnableDisableColor = True
            txtYearTo.Location = New System.Drawing.Point(238, 71)
            txtYearTo.Name = "txtYearTo?"
            txtYearTo.ReadOnly = True
            txtYearTo.Size = New System.Drawing.Size(40, 20)
            txtYearTo.TabIndex = 9
            txtYearTo.Text = "2004?"
            txtYear.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtYear.EnableDisableColor = True
            txtYear.Location = New System.Drawing.Point(176, 71)
            txtYear.Name = "txtYear?"
            txtYear.ReadOnly = True
            txtYear.Size = New System.Drawing.Size(40, 20)
            txtYear.TabIndex = 2
            txtYear.Text = "2000?"
            lblYear.AutoSize = True
            lblYear.Location = New System.Drawing.Point(106, 75)
            lblYear.Name = "lblYear?"
            lblYear.Size = New System.Drawing.Size(31, 13)
            lblYear.TabIndex = 7
            lblYear.Text = "Leto:?"
            txtImdb.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtImdb.EnableDisableColor = True
            txtImdb.Location = New System.Drawing.Point(176, 19)
            txtImdb.Name = "txtImdb?"
            txtImdb.ReadOnly = True
            txtImdb.Size = New System.Drawing.Size(130, 20)
            txtImdb.TabIndex = 0
            txtImdb.Text = "0443649?"
            lblImdb.AutoSize = True
            lblImdb.Location = New System.Drawing.Point(106, 23)
            lblImdb.Name = "lblImdb?"
            lblImdb.Size = New System.Drawing.Size(50, 13)
            lblImdb.TabIndex = 5
            lblImdb.Text = "IMDb ID:?"
            txtTitle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtTitle.EnableDisableColor = True
            txtTitle.Location = New System.Drawing.Point(176, 45)
            txtTitle.Name = "txtTitle?"
            txtTitle.ReadOnly = True
            txtTitle.Size = New System.Drawing.Size(292, 20)
            txtTitle.TabIndex = 1
            lblTitle.AutoSize = True
            lblTitle.Location = New System.Drawing.Point(106, 49)
            lblTitle.Name = "lblTitle?"
            lblTitle.Size = New System.Drawing.Size(43, 13)
            lblTitle.TabIndex = 3
            lblTitle.Text = "Naslov:?"
            pbPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pbPoster.Location = New System.Drawing.Point(6, 19)
            pbPoster.Name = "pbPoster?"
            pbPoster.Size = New System.Drawing.Size(94, 140)
            pbPoster.TabIndex = 2
            pbPoster.TabStop = False
            tabPreview.BackColor = System.Drawing.Color.Transparent
            tabPreview.Controls.Add(listView1)
            tabPreview.Controls.Add(myPanel2)
            tabPreview.Location = New System.Drawing.Point(4, 22)
            tabPreview.Name = "tabPreview?"
            tabPreview.Padding = New System.Windows.Forms.Padding(3)
            tabPreview.Size = New System.Drawing.Size(488, 638)
            tabPreview.TabIndex = 1
            tabPreview.Text = "Predogled podnapisa?"
            tabPreview.UseVisualStyleBackColor = True
            Dim columnHeaderArr1 As System.Windows.Forms.ColumnHeader() = New System.Windows.Forms.ColumnHeader() { _
                                                                                                                    colNum, _
                                                                                                                    colText }
            listView1.Columns.AddRange(columnHeaderArr1)
            listView1.Dock = System.Windows.Forms.DockStyle.Fill
            listView1.FullRowSelect = True
            listView1.GridLines = True
            listView1.Location = New System.Drawing.Point(3, 42)
            listView1.MultiSelect = False
            listView1.Name = "listView1?"
            listView1.Size = New System.Drawing.Size(482, 593)
            listView1.TabIndex = 1
            listView1.UseCompatibleStateImageBehavior = False
            listView1.View = System.Windows.Forms.View.Details
            colNum.Text = "Vrstica?"
            colText.Text = "Tekst?"
            myPanel2.Controls.Add(txtNumWords)
            myPanel2.Controls.Add(lblNumWords)
            myPanel2.Controls.Add(txtNumDialogs)
            myPanel2.Controls.Add(lblNumDialogs)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Top
            myPanel2.Location = New System.Drawing.Point(3, 3)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(482, 39)
            myPanel2.TabIndex = 0
            txtNumWords.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtNumWords.EnableDisableColor = True
            txtNumWords.Location = New System.Drawing.Point(245, 7)
            txtNumWords.Name = "txtNumWords?"
            txtNumWords.ReadOnly = True
            txtNumWords.Size = New System.Drawing.Size(71, 20)
            txtNumWords.TabIndex = 3
            lblNumWords.AutoSize = True
            lblNumWords.Location = New System.Drawing.Point(184, 10)
            lblNumWords.Name = "lblNumWords?"
            lblNumWords.Size = New System.Drawing.Size(55, 13)
            lblNumWords.TabIndex = 2
            lblNumWords.Text = "Št. besed:?"
            txtNumDialogs.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtNumDialogs.EnableDisableColor = True
            txtNumDialogs.Location = New System.Drawing.Point(62, 7)
            txtNumDialogs.Name = "txtNumDialogs?"
            txtNumDialogs.ReadOnly = True
            txtNumDialogs.Size = New System.Drawing.Size(71, 20)
            txtNumDialogs.TabIndex = 1
            lblNumDialogs.AutoSize = True
            lblNumDialogs.Location = New System.Drawing.Point(5, 10)
            lblNumDialogs.Name = "lblNumDialogs?"
            lblNumDialogs.Size = New System.Drawing.Size(51, 13)
            lblNumDialogs.TabIndex = 0
            lblNumDialogs.Text = "Št. vrstic:?"
            tabHistory.Controls.Add(lvHistory)
            tabHistory.Location = New System.Drawing.Point(4, 22)
            tabHistory.Name = "tabHistory?"
            tabHistory.Size = New System.Drawing.Size(488, 638)
            tabHistory.TabIndex = 2
            tabHistory.Text = "Zgodovina?"
            tabHistory.UseVisualStyleBackColor = True
            Dim columnHeaderArr2 As System.Windows.Forms.ColumnHeader() = New System.Windows.Forms.ColumnHeader() { _
                                                                                                                    colHistoryDT, _
                                                                                                                    colHistoryUser, _
                                                                                                                    colHistoryDescription }
            lvHistory.Columns.AddRange(columnHeaderArr2)
            lvHistory.Dock = System.Windows.Forms.DockStyle.Fill
            lvHistory.FullRowSelect = True
            lvHistory.GridLines = True
            lvHistory.Location = New System.Drawing.Point(0, 0)
            lvHistory.MultiSelect = False
            lvHistory.Name = "lvHistory?"
            lvHistory.Size = New System.Drawing.Size(488, 638)
            lvHistory.TabIndex = 2
            lvHistory.UseCompatibleStateImageBehavior = False
            lvHistory.View = System.Windows.Forms.View.Details
            colHistoryDT.Text = "Cas?"
            colHistoryUser.Text = "Uporabnik?"
            colHistoryUser.Width = 95
            colHistoryDescription.Text = "Opis?"
            colHistoryDescription.Width = 235
            tabComments.Controls.Add(ctrlComments)
            tabComments.Controls.Add(panelCommentsTop)
            tabComments.Location = New System.Drawing.Point(4, 22)
            tabComments.Name = "tabComments?"
            tabComments.Size = New System.Drawing.Size(488, 638)
            tabComments.TabIndex = 3
            tabComments.Text = "Komentarji?"
            tabComments.UseVisualStyleBackColor = True
            ctrlComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            ctrlComments.Dock = System.Windows.Forms.DockStyle.Fill
            ctrlComments.ItemsCount = 0
            ctrlComments.ItemsPerPage = 10
            ctrlComments.Location = New System.Drawing.Point(0, 35)
            ctrlComments.Name = "ctrlComments?"
            ctrlComments.Size = New System.Drawing.Size(488, 603)
            ctrlComments.TabIndex = 2
            panelCommentsTop.Controls.Add(lblCommentNote)
            panelCommentsTop.Controls.Add(gbAddComment)
            panelCommentsTop.Controls.Add(cbCommentLanguage)
            panelCommentsTop.Controls.Add(lblCommentLanguage)
            panelCommentsTop.Controls.Add(btnShowHideAddComment)
            panelCommentsTop.Dock = System.Windows.Forms.DockStyle.Top
            panelCommentsTop.Location = New System.Drawing.Point(0, 0)
            panelCommentsTop.Name = "panelCommentsTop?"
            panelCommentsTop.Size = New System.Drawing.Size(488, 35)
            panelCommentsTop.TabIndex = 1
            lblCommentNote.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblCommentNote.Location = New System.Drawing.Point(8, 38)
            lblCommentNote.Name = "lblCommentNote?"
            lblCommentNote.Size = New System.Drawing.Size(472, 65)
            lblCommentNote.TabIndex = 173
            lblCommentNote.Text = "Za dodajanje komentarjev morate biti prijavljeni.?"
            gbAddComment.Controls.Add(btnSendComment)
            gbAddComment.Controls.Add(txtAddComment)
            gbAddComment.DrawTextBackground = False
            gbAddComment.Location = New System.Drawing.Point(4, 38)
            gbAddComment.Name = "gbAddComment?"
            gbAddComment.Size = New System.Drawing.Size(480, 122)
            gbAddComment.TabIndex = 169
            gbAddComment.TabStop = False
            gbAddComment.Text = "Dodajanje komentarja?"
            btnSendComment.AutoResize = False
            btnSendComment.DialogResult = System.Windows.Forms.DialogResult.None
            btnSendComment.Location = New System.Drawing.Point(399, 92)
            btnSendComment.Name = "btnSendComment?"
            btnSendComment.Size = New System.Drawing.Size(75, 23)
            btnSendComment.TabIndex = 177
            btnSendComment.Text = "Pošlji?"
            btnSendComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSendComment.Click, AddressOf btnSendComment_Click
            txtAddComment.EnableDisableColor = True
            txtAddComment.Location = New System.Drawing.Point(6, 19)
            txtAddComment.Multiline = True
            txtAddComment.Name = "txtAddComment?"
            txtAddComment.Size = New System.Drawing.Size(468, 66)
            txtAddComment.TabIndex = 176
            cbCommentLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbCommentLanguage.FormattingEnabled = True
            cbCommentLanguage.Location = New System.Drawing.Point(65, 7)
            cbCommentLanguage.Name = "cbCommentLanguage?"
            cbCommentLanguage.Size = New System.Drawing.Size(212, 21)
            cbCommentLanguage.TabIndex = 167
            lblCommentLanguage.AutoSize = True
            lblCommentLanguage.Location = New System.Drawing.Point(8, 10)
            lblCommentLanguage.Name = "lblCommentLanguage?"
            lblCommentLanguage.Size = New System.Drawing.Size(34, 13)
            lblCommentLanguage.TabIndex = 3
            lblCommentLanguage.Text = "Jezik:?"
            btnShowHideAddComment.AutoResize = False
            btnShowHideAddComment.DialogResult = System.Windows.Forms.DialogResult.None
            btnShowHideAddComment.Location = New System.Drawing.Point(335, 5)
            btnShowHideAddComment.Name = "btnShowHideAddComment?"
            btnShowHideAddComment.Size = New System.Drawing.Size(145, 23)
            btnShowHideAddComment.TabIndex = 2
            btnShowHideAddComment.Text = "Dodaj komentar >>?"
            btnShowHideAddComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnShowHideAddComment.Click, AddressOf btnShowHideAddComment_Click
            tabThanks.Controls.Add(lvThanks)
            tabThanks.Controls.Add(myPanel3)
            tabThanks.Location = New System.Drawing.Point(4, 22)
            tabThanks.Name = "tabThanks?"
            tabThanks.Size = New System.Drawing.Size(488, 638)
            tabThanks.TabIndex = 5
            tabThanks.Text = "Zahvale?"
            tabThanks.UseVisualStyleBackColor = True
            Dim columnHeaderArr3 As System.Windows.Forms.ColumnHeader() = New System.Windows.Forms.ColumnHeader() { _
                                                                                                                    colThanksCreated, _
                                                                                                                    colThanksUser }
            lvThanks.Columns.AddRange(columnHeaderArr3)
            lvThanks.Dock = System.Windows.Forms.DockStyle.Fill
            lvThanks.FullRowSelect = True
            lvThanks.GridLines = True
            lvThanks.Location = New System.Drawing.Point(0, 0)
            lvThanks.MultiSelect = False
            lvThanks.Name = "lvThanks?"
            lvThanks.Size = New System.Drawing.Size(488, 608)
            lvThanks.TabIndex = 5
            lvThanks.UseCompatibleStateImageBehavior = False
            lvThanks.View = System.Windows.Forms.View.Details
            colThanksCreated.Text = "Cas?"
            colThanksUser.Text = "Uporabnik?"
            colThanksUser.Width = 95
            myPanel3.Controls.Add(btnThanks)
            myPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
            myPanel3.Location = New System.Drawing.Point(0, 608)
            myPanel3.Name = "myPanel3?"
            myPanel3.Size = New System.Drawing.Size(488, 30)
            myPanel3.TabIndex = 4
            btnThanks.AutoResize = False
            btnThanks.DialogResult = System.Windows.Forms.DialogResult.None
            btnThanks.Enabled = False
            btnThanks.Location = New System.Drawing.Point(410, 3)
            btnThanks.Name = "btnThanks?"
            btnThanks.Size = New System.Drawing.Size(75, 23)
            btnThanks.TabIndex = 8
            btnThanks.Text = "Zahvali se?"
            btnThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnThanks.Click, AddressOf btnThanks_Click
            tabNFO.Controls.Add(txtNFO)
            tabNFO.Location = New System.Drawing.Point(4, 22)
            tabNFO.Name = "tabNFO?"
            tabNFO.Size = New System.Drawing.Size(488, 638)
            tabNFO.TabIndex = 4
            tabNFO.Text = ".NFO?"
            tabNFO.UseVisualStyleBackColor = True
            txtNFO.Dock = System.Windows.Forms.DockStyle.Fill
            txtNFO.Font = New System.Drawing.Font("Lucida Console?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            txtNFO.Location = New System.Drawing.Point(0, 0)
            txtNFO.Multiline = True
            txtNFO.Name = "txtNFO?"
            txtNFO.ReadOnly = True
            txtNFO.ScrollBars = System.Windows.Forms.ScrollBars.Both
            txtNFO.Size = New System.Drawing.Size(488, 638)
            txtNFO.TabIndex = 0
            txtNFO.WordWrap = False
            cmHistory.Font = New System.Drawing.Font("Courier New?", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            cmHistory.Name = "cmHistory?"
            cmHistory.Size = New System.Drawing.Size(61, 4)
            AddHandler tmrDetailsHideLoader.Tick, AddressOf tmrDetailsHideLoader_Tick
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.SystemColors.Control
            CancelButton = btnCancel
            ClientSize = New System.Drawing.Size(496, 695)
            Controls.Add(tabControl)
            Controls.Add(myPanel1)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            KeyPreview = True
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmDetails2?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "%Title%, %year%?"
            AddHandler Load, AddressOf FrmDetails2_Load
            AddHandler KeyUp, AddressOf FrmDetails2_KeyUp
            myPanel1.ResumeLayout(False)
            tabControl.ResumeLayout(False)
            tabDetails.ResumeLayout(False)
            tabDetails.PerformLayout()
            tcSubtitleDetails.ResumeLayout(False)
            tpSDGeneral.ResumeLayout(False)
            tpSDGeneral.PerformLayout()
            tpSDReleases.ResumeLayout(False)
            tpSDAttributes.ResumeLayout(False)
            tpSDAttributes.PerformLayout()
            myGroupBox2.ResumeLayout(False)
            myGroupBox2.PerformLayout()
            pbPoster.EndInit()
            tabPreview.ResumeLayout(False)
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            tabHistory.ResumeLayout(False)
            tabComments.ResumeLayout(False)
            panelCommentsTop.ResumeLayout(False)
            panelCommentsTop.PerformLayout()
            gbAddComment.ResumeLayout(False)
            gbAddComment.PerformLayout()
            tabThanks.ResumeLayout(False)
            myPanel3.ResumeLayout(False)
            tabNFO.ResumeLayout(False)
            tabNFO.PerformLayout()
            ResumeLayout(False)
        End Sub

        Private Sub InitMarkerEvents()
            AddHandler tabDetails.Paint, AddressOf tabDetails_Paint
            AddHandler tpSDGeneral.Paint, AddressOf tpSDGeneral_Paint
        End Sub

        Private Sub lnkImdb_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
            OpenInBrowser(lnkImdb.Text)
        End Sub

        Private Sub NfoThread(ByVal args As Object)
            Try
                Dim <>c__DisplayClass1_1 As Sublight.FrmDetails2.<>c__DisplayClass1 = New Sublight.FrmDetails2.<>c__DisplayClass1
                <>c__DisplayClass1_1.<>4__this = Me
                Dim nfo1 As Sublight.Lib.IMDB.Nfo = New Sublight.Lib.IMDB.Nfo(TryCast(args, string))
                <>c__DisplayClass1_1.info = nfo1.GetInfo()
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass1_1.<NfoThread>b__0)
                Sublight.BaseForm.DoCtrlInvoke(txtNFO, Me, methodInvoker1)
            Catch e As System.Exception
                System.Windows.Forms.MessageBox.Show(e.Message)
            End Try
        End Sub

        Private Sub rateControl_RateClicked(ByVal sender As Object, ByVal e As Sublight.Controls.RateControl.RateArgs)
            rateControl.EnableRating = False
            tpSDGeneral.Invalidate()
            If (m_subtitle) Is Nothing Then
                Return
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.RateSubtitleCompleted, AddressOf ws_RateSubtitleCompleted
                sublight1.RateSubtitleAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID, System.Convert.ToInt32(e.Rate))
            End Using
        End Sub

        Private Sub RefreshComments()
            m_commentsShown = False
            ShowComments()
        End Sub

        Private Sub SelectLanguage(ByVal language As Sublight.WS.SubtitleLanguage)
            Dim i1 As Integer = 0
            While i1 < cbLanguage.Items.Count
                Dim listItem1 As Sublight.Types.ListItem = TryCast(cbLanguage.Items(i1), Sublight.Types.ListItem)
                If (Not (listItem1) Is Nothing) AndAlso TryCast(listItem1.Value, Sublight.WS.SubtitleLanguage) Then
                    Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage)
                    If subtitleLanguage1 = language Then
                        cbLanguage.SelectedIndex = i1
                        Return
                    End If
                End If
                i1 = i1 + 1
            End While
        End Sub

        Private Sub ShowComments()
            If (m_subtitle) Is Nothing Then
                Return
            End If
            If Not m_commentsShown Then
                m_commentsShown = True
                Try
                    ShowLoader(Me)
                    EnableDisableShowHideAddComment()
                    ctrlComments.DisplayFirstPage()
                Catch 
                    HideLoader(Me)
                    BringToFront()
                End Try
            End If
        End Sub

        Private Sub ShowDetails()
            If Sublight.BaseForm.IsAdministrator() Then
                btnSendMessageToPublisher.Visible = True
            End If
            If (m_subtitle) Is Nothing Then
                Return
            End If
            Dim flag1 As Boolean = m_subtitle.Genre <> Sublight.WS.Genre.Movie
            If Sublight.MyUtility.Permission.CanEditSubtitle(m_subtitle) Then
                cbLanguage.Enabled = True
                cbMediaCount.Enabled = False
                cbMediaType.Enabled = True
                txtSeason.ReadOnly = Not flag1
                txtEpisode.ReadOnly = Not flag1
                txtComment.ReadOnly = False
                cbType.Enabled = True
                btnSave.Visible = True
                txtImdb.ReadOnly = False
            Else 
                cbLanguage.Enabled = False
                cbMediaCount.Enabled = False
                cbMediaType.Enabled = False
                txtSeason.ReadOnly = True
                txtEpisode.ReadOnly = True
                txtComment.ReadOnly = True
                cbType.Enabled = False
                btnSave.Visible = False
                txtImdb.ReadOnly = True
            End If
            btnFindIMDB.Visible = Not txtImdb.ReadOnly
            If Sublight.MyUtility.Permission.CanAddRelease(m_subtitle) Then
                btnAddRelease.Visible = True
                btnAddRelease.Enabled = True
            Else 
                btnAddRelease.Visible = True
                btnAddRelease.Enabled = False
            End If
            If m_detailsLoaded Then
                Return
            End If
            tmrDetailsHideLoader.Start()
            ShowLoader(Me)
            Clear()
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.GetDetailsCompleted, AddressOf WS_GetDetailsCompleted
                sublight1.GetDetailsAsync(Sublight.BaseForm.Session, m_imdbId)
            End Using
            Using sublight2 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight2.GetReleasesCompleted, AddressOf WS_GetReleasesCompleted
                Dim guidArr1 As System.Guid() = New System.Guid(1) {}
                guidArr1(0) = m_subtitle.SubtitleID
                sublight2.GetReleasesAsync(guidArr1)
            End Using
            m_EditableControls.Add(txtImdb)
            m_EditableControls.Add(cbLanguage)
            m_EditableControls.Add(cbType)
            m_EditableControls.Add(cbMediaType)
            If flag1 Then
                m_EditableControls.Add(txtSeason)
                m_EditableControls.Add(txtEpisode)
            End If
            m_EditableControls.Add(txtComment)
            m_EditableControls.Add(cbStatus)
            m_EditableControls.Add(rateControl)
        End Sub

        Private Sub ShowHistory()
            If (m_subtitle) Is Nothing Then
                Return
            End If
            If Not m_historyShown Then
                m_historyShown = True
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    ShowLoader(Me)
                    AddHandler sublight1.GetHistoryCompleted, AddressOf ws_GetHistoryCompleted
                    sublight1.GetHistoryAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID)
                End Using
            End If
        End Sub

        Private Sub ShowNFO()
            If (m_subtitle) Is Nothing Then
                Return
            End If
            If Not m_NFOShown Then
                m_NFOShown = True
                Try
                    ShowLoader(Me)
                    Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ParameterizedThreadStart(NfoThread))
                    thread1.Start(m_subtitle.IMDB)
                Catch 
                    HideLoader(Me)
                    BringToFront()
                End Try
            End If
        End Sub

        Private Sub ShowPreview()
            If (m_subtitle) Is Nothing Then
                Return
            End If
            If Sublight.BaseForm.IsSubtitleEditor(m_subtitle) OrElse Sublight.BaseForm.IsAdministrator() Then
                ctrlSubtitleStatus.InitStatuses(m_subtitle)
                If btnReportSubtitle.Visible Then
                    ctrlSubtitleStatus.Left = btnReportSubtitle.Right + 5
                Else 
                    ctrlSubtitleStatus.Left = btnReportSubtitle.Left
                End If
                ctrlSubtitleStatus.Visible = True
            End If
            If Not m_wsCalled Then
                Try
                    ShowLoader(Me)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        AddHandler sublight1.SubtitlePreviewCompleted, AddressOf WS_SubtitlePreviewCompleted
                        sublight1.SubtitlePreviewAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID)
                    End Using
                Catch 
                    HideLoader(Me)
                    BringToFront()
                End Try
            End If
        End Sub

        Private Sub ShowThanks()
            If (m_subtitle) Is Nothing Then
                Return
            End If
            If m_ShowThanks Then
                Return
            End If
            btnThanks.Enabled = False
            lvThanks.Items.Clear()
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                ShowLoader(Me)
                AddHandler sublight1.GetSubtitleThanksCompleted, AddressOf ws_GetSubtitleThanksCompleted
                sublight1.GetSubtitleThanksAsync(Sublight.BaseForm.Session, m_subtitle.SubtitleID)
            End Using
        End Sub

        Private Sub StartPosterLoadingAnim()
            ldPoster.Start()
            ldPoster.Visible = True
        End Sub

        Private Sub tabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            btnSave.Visible = False
            If ctrlSubtitleStatus.Visible Then
                ctrlSubtitleStatus.Visible = False
            End If
            btnSendMessageToPublisher.Visible = False
            If tabControl.SelectedIndex = 0 Then
                ShowDetails()
                Return
            End If
            If tabControl.SelectedIndex = 1 Then
                ShowPreview()
                Return
            End If
            If tabControl.SelectedIndex = 2 Then
                ShowHistory()
                Return
            End If
            If tabControl.SelectedIndex = 3 Then
                ShowComments()
                Return
            End If
            If tabControl.SelectedIndex = 4 Then
                ShowThanks()
                Return
            End If
            If tabControl.SelectedIndex = 5 Then
                ShowNFO()
            End If
        End Sub

        Private Sub tabDetails_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim graphics1 As System.Drawing.Graphics = e.Graphics
            graphics1.DrawRectangle(m_EditablePen, tabDetails.Left + 3, legendLabel1.Top, legendLabel1.Left - tabDetails.Left - 8, legendLabel1.Height)
            If (m_EditableControls) Is Nothing Then
                Return
            End If
            Dim enumerator1 As System.Collections.Generic.List(Of System.Windows.Forms.Control).Enumerator = m_EditableControls.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim control1 As System.Windows.Forms.Control = enumerator1.get_Current()
                    Dim flag1 As Boolean = False
                    Dim myTextBox1 As Sublight.Controls.MyTextBox = TryCast(control1, Sublight.Controls.MyTextBox)
                    If (Not (myTextBox1) Is Nothing) AndAlso myTextBox1.Enabled AndAlso Not myTextBox1.ReadOnly Then
                        Dim i1 As Integer = myTextBox1.Left
                        Dim i2 As Integer = myTextBox1.Top
                        Dim control2 As System.Windows.Forms.Control = myTextBox1.Parent
                        While Not (control2) Is Nothing
                            i1 = i1 + control2.Left
                            i2 = i2 + control2.Top
                            If control2.Name = "myGroupBox2?" Then
                                flag1 = True
                                Exit While
                            End If
                            control2 = control2.Parent
                        End While
                        If flag1 Then
                            graphics1.DrawRectangle(m_EditablePen, i1 - 2, i2 - 2, myTextBox1.Width + 4, myTextBox1.Height + 4)
                        End If
                    End If
                End While
            Finally
                enumerator1.Dispose()
            End Try
        End Sub

        Private Sub tcSubtitleDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub tmrDetailsHideLoader_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            If m_detailsLoaded AndAlso m_releasesLoaded Then
                tmrDetailsHideLoader.Stop()
                HideLoader(Me)
                BringToFront()
            End If
        End Sub

        Private Sub tpSDGeneral_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim graphics1 As System.Drawing.Graphics = e.Graphics
            If (m_EditableControls) Is Nothing Then
                Return
            End If
            Dim enumerator1 As System.Collections.Generic.List(Of System.Windows.Forms.Control).Enumerator = m_EditableControls.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim control1 As System.Windows.Forms.Control = enumerator1.get_Current()
                    Dim flag1 As Boolean = False
                    Dim myTextBox1 As Sublight.Controls.MyTextBox = TryCast(control1, Sublight.Controls.MyTextBox)
                    If Not (myTextBox1) Is Nothing Then
                        If Not myTextBox1.Enabled OrElse myTextBox1.ReadOnly Then
                            GoTo label_1
                        End If
                        Dim i1 As Integer = myTextBox1.Left
                        Dim i2 As Integer = myTextBox1.Top
                        Dim control2 As System.Windows.Forms.Control = myTextBox1.Parent
                        While Not (control2) Is Nothing
                            If control2.Name = "tpSDGeneral?" Then
                                flag1 = True
                                Exit While
                            End If
                            control2 = control2.Parent
                        End While
                        If Not flag1 Then
                            GoTo label_1
                        End If
                        graphics1.DrawRectangle(m_EditablePen, i1 - 2, i2 - 2, myTextBox1.Width + 4, myTextBox1.Height + 4)
                    Else 
                        Dim myComboBox1 As Sublight.Controls.MyComboBox = TryCast(control1, Sublight.Controls.MyComboBox)
                        If Not (myComboBox1) Is Nothing Then
                            If Not myComboBox1.Enabled Then
                                GoTo label_1
                            End If
                            graphics1.DrawRectangle(m_EditablePen, myComboBox1.Left - 2, myComboBox1.Top - 2, myComboBox1.Width + 4, myComboBox1.Height + 4)
                            Continue
                        End If
                        Dim rateControl1 As Sublight.Controls.RateControl = TryCast(control1, Sublight.Controls.RateControl)
                        If (Not (rateControl1) Is Nothing) AndAlso rateControl1.EnableRating Then
                            graphics1.DrawRectangle(m_EditablePen, rateControl1.Left - 4, rateControl1.Top - 4, rateControl1.Width + 8, rateControl1.Height + 8)
                        End If
                    label_1: _
                    End If
                End While
            Finally
                enumerator1.Dispose()
            End Try
        End Sub

        Private Sub wc_DownloadDataCompleted(ByVal sender As Object, ByVal e As System.Net.DownloadDataCompletedEventArgs)
            Try
                Dim bArr1 As Byte() = e.Result
                Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream(bArr1)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim s1 As String = TryCast(e.UserState, string)
                        sublight1.UpdatePoster2Async(Sublight.BaseForm.Session, m_imdbId, s1, System.Convert.ToBase64String(memoryStream1.ToArray()))
                    End Using
                    memoryStream1.Seek(CLng(0), System.IO.SeekOrigin.Begin)
                    Dim image1 As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream1)
                    pbPoster.Image = image1
                    pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                    Dim d1 As Double = System.Convert.ToDouble(image1.Height) / System.Convert.ToDouble(image1.Width)
                    pbPoster.Width = 94
                    pbPoster.Height = System.Convert.ToInt32(d1 * CDbl(pbPoster.Width))
                End Using
            Catch 
                pbPoster.Image = Nothing
            Finally
                EndPosterLoadingAnim()
            End Try
        End Sub

        Private Sub wc_DownloadStringCompleted(ByVal sender As Object, ByVal e As System.Net.DownloadStringCompletedEventArgs)
            Dim s3 As String

            Dim webClient1 As System.Net.WebClient = Nothing
            Try
                webClient1 = New System.Net.WebClient
                Dim s1 As String = e.Result
                Dim match1 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s1, "<a\s*?name=['""]poster['""].*?<img.*?src\s*?=\s*?['""](?<src>.*?)['""]?")
                If match1.Success Then
                    Dim s2 As String = match1.Groups("src?").Value
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        If Not sublight1.GetPosterUrl(Sublight.BaseForm.Session, s2, out s2, out s3) Then
                            Return
                        End If
                    End Using
                    AddHandler webClient1.DownloadDataCompleted, AddressOf wc_DownloadDataCompleted
                    webClient1.DownloadDataAsync(New System.Uri(s2), s2)
                Else 
                    lblNoImage.Visible = True
                    EndPosterLoadingAnim()
                End If
            Catch 
                pbPoster.Image = Nothing
                EndPosterLoadingAnim()
            Finally
                If Not (webClient1) Is Nothing Then
                    webClient1.Dispose()
                End If
            End Try
        End Sub

        Private Sub ws_AddSubtitleCommentCompleted(ByVal sender As Object, ByVal e As Sublight.WS.AddSubtitleCommentCompletedEventArgs)
            Try
                If Not e.Result Then
                    btnSendComment.Enabled = True
                    Dim objArr1 As Object() = New object() { e.error }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                    Return
                End If
                btnShowHideAddComment_Click(Me, Nothing)
                RefreshComments()
                m_commentSuccessfullySent = True
                txtAddComment.Text = System.String.Empty
                btnShowHideAddComment.Enabled = False
                btnSendComment.Enabled = False
            Catch e1 As System.Exception
                btnSendComment.Enabled = True
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.ws_AddSubtitleCommentCompleted?", e1)
                ExceptionHandlerUI(e1)
            End Try
        End Sub

        Private Sub ws_AddSubtitleThankCompleted(ByVal sender As Object, ByVal e As Sublight.WS.AddSubtitleThankCompletedEventArgs)
            If Not (e.Error) Is Nothing Then
                Dim objArr1 As Object() = New object() { e.Error.Message }
                ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                btnThanks.Enabled = True
                Return
            End If
            If Not e.Result Then
                Dim objArr2 As Object() = New object() { e.error }
                ShowError(Sublight.Translation.Application_Error_WebException, objArr2)
                btnThanks.Enabled = True
                Return
            End If
            btnThanks.Enabled = False
            m_ShowThanks = False
            ShowThanks()
        End Sub

        Private Sub WS_GetDetailsCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetDetailsCompletedEventArgs)
            m_detailsLoaded = True
            Try
                If Not e.Result Then
                    Dim objArr1 As Object() = New object() { e.error }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                    Return
                End If
                txtImdb.Text = m_imdbId
                lnkImdb.Text = m_subtitle.IMDB
                If Not (e.imdbInfo) Is Nothing Then
                    txtTitle.Text = e.imdbInfo.Title
                    Dim nullable2 As System.Nullable(Of Integer) = e.imdbInfo.Year
                    If nullable2.get_HasValue() Then
                        Dim nullable3 As System.Nullable(Of Integer) = e.imdbInfo.Year
                        txtYear.Text = System.String.Format("{0}?", nullable3.get_Value())
                    Else 
                        txtYear.Text = System.String.Empty
                    End If
                    Dim nullable4 As System.Nullable(Of Integer) = e.imdbInfo.YearTo
                    If nullable4.get_HasValue() Then
                        Dim nullable1 As System.Nullable(Of Integer) = e.imdbInfo.YearTo
                        txtYearTo.Text = System.String.Format("{0}?", nullable1.get_Value())
                    End If
                End If
                lbAKA.Items.Clear()
                If Not (e.alternativeTitles) Is Nothing Then
                    Dim alternativeTitleArr1 As Sublight.WS.AlternativeTitle() = e.alternativeTitles
                    Dim i1 As Integer = 0
                    While i1 < alternativeTitleArr1.Length
                        Dim alternativeTitle1 As Sublight.WS.AlternativeTitle = alternativeTitleArr1(i1)
                        Dim s1 As String = System.String.Format("Language_{0}?", alternativeTitle1.Language.ToUpper().Replace("-"C, "_"C))
                        lbAKA.Items.Add(New Sublight.Types.ListItem(System.String.Format("{0} ({1})?", alternativeTitle1.Title, Sublight.Globals.GetString(s1).ToLower()), alternativeTitle1))
                        i1 = i1 + 1
                    End While
                End If
                If Not Sublight.MyUtility.SubtitleUtil.IsNonImdbMovie(m_subtitle) Then
                    GetPoster()
                End If
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.WS_GetDetailsCompleted?", e1)
                ExceptionHandlerUI(e1)
            End Try
        End Sub

        Private Sub ws_GetHistoryCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetHistoryCompletedEventArgs)
            Dim s2 As String
            Dim subtitle1 As Sublight.WS.Subtitle

            Try
                If Not e.Result Then
                    Return
                End If
                lvHistory.BeginUpdate()
                lvHistory.Items.Clear()
                If Not (e.items) Is Nothing Then
                    Dim historyItemArr1 As Sublight.WS.HistoryItem() = e.items
                    Dim i4 As Integer = 0
                    While i4 < historyItemArr1.Length
                        Dim historyItem1 As Sublight.WS.HistoryItem = historyItemArr1(i4)
                        Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                        If (historyItem1.Type And Sublight.WS.HistoryType.Published) > 0 Then
                            list1.Add(System.String.Format("FrmDetails_HistoryType_{0}?", System.Enum.GetName(GetType(Sublight.WS.HistoryType), 2)))
                        End If
                        If (historyItem1.Type And Sublight.WS.HistoryType.StatusChanged) > 0 Then
                            list1.Add(System.String.Format("FrmDetails_HistoryType_{0}?", System.Enum.GetName(GetType(Sublight.WS.HistoryType), 4)))
                        End If
                        If (historyItem1.Type And Sublight.WS.HistoryType.StatusChangedDeleted) > 0 Then
                            list1.Add(System.String.Format("FrmDetails_HistoryType_{0}?", System.Enum.GetName(GetType(Sublight.WS.HistoryType), 8)))
                        End If
                        If (historyItem1.Type And Sublight.WS.HistoryType.StatusChangedAuthorized) > 0 Then
                            list1.Add(System.String.Format("FrmDetails_HistoryType_{0}?", System.Enum.GetName(GetType(Sublight.WS.HistoryType), 16)))
                        End If
                        If (historyItem1.Type And Sublight.WS.HistoryType.SubtitleUpdated) > 0 Then
                            list1.Add(System.String.Format("FrmDetails_HistoryType_{0}?", System.Enum.GetName(GetType(Sublight.WS.HistoryType), 32)))
                        End If
                        If (historyItem1.Type And Sublight.WS.HistoryType.ImdbUpdated) > 0 Then
                            list1.Add(System.String.Format("FrmDetails_HistoryType_{0}?", System.Enum.GetName(GetType(Sublight.WS.HistoryType), 64)))
                        End If
                        If list1.get_Count() > 0 Then
                            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                            Dim i1 As Integer = 0
                            While i1 < list1.get_Count()
                                stringBuilder1.Append(Sublight.Globals.GetString(list1.get_Item(i1)))
                                If i1 < (list1.get_Count() - 1) Then
                                    stringBuilder1.Append(", ?")
                                End If
                                i1 = i1 + 1
                            End While
                            Dim sArr1 As String() = New string(3) {}
                            Dim dateTime1 As System.DateTime = historyItem1.Changed
                            sArr1(0) = dateTime1.ToString()
                            sArr1(1) = historyItem1.Username
                            sArr1(2) = stringBuilder1.ToString()
                            lvHistory.Items.Add(New System.Windows.Forms.ListViewItem(sArr1))
                        End If
                        i4 = i4 + 1
                    End While
                End If
                If (Not (m_subtitle) Is Nothing) AndAlso m_subtitle.ParentSubtitleID <> System.Guid.Empty Then
                    Dim s1 As String = Nothing
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        If sublight1.GetSubtitleById(Sublight.BaseForm.Session, m_subtitle.ParentSubtitleID, out subtitle1, out s2) AndAlso (Not (subtitle1) Is Nothing) Then
                            s1 = System.String.Format(Sublight.Translation.FrmDetails_History_DerivedSubtitle, subtitle1.Publisher)
                        End If
                    End Using
                    If System.String.IsNullOrEmpty(s1) Then
                        s1 = System.String.Format(Sublight.Translation.FrmDetails_History_DerivedSubtitle, "????")
                    End If
                    Dim sArr2 As String() = New string(3) {}
                    Dim dateTime2 As System.DateTime = subtitle1.Created
                    sArr2(0) = IIf(Not (subtitle1) Is Nothing, dateTime2.ToString(), System.String.Empty)
                    sArr2(1) = IIf(Not (subtitle1) Is Nothing, subtitle1.Publisher, System.String.Empty)
                    sArr2(2) = s1
                    Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(sArr2)
                    lvHistory.Items.Add(listViewItem1)
                End If
                Dim columnHeader1 As System.Windows.Forms.ColumnHeader 
                For Each columnHeader1 In lvHistory.Columns
                    lvHistory.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent)
                    Dim i2 As Integer = columnHeader1.Width
                    lvHistory.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize)
                    Dim i3 As Integer = columnHeader1.Width
                    If i2 > i3 Then
                        columnHeader1.Width = i2
                    Else 
                        columnHeader1.Width = i3
                    End If
                Next
                lvHistory.EndUpdate()
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.ws_GetHistoryCompleted?", e1)
                ExceptionHandlerUI(e1)
            Finally
                HideLoader(Me)
                BringToFront()
            End Try
        End Sub

        Private Sub WS_GetReleasesCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetReleasesCompletedEventArgs)
            m_releasesLoaded = True
            Try
                lbReleases.Items.Clear()
                If Not e.Result Then
                    Dim objArr1 As Object() = New object() { e.error }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                    Return
                End If
                If Not (e.releases) Is Nothing Then
                    Dim releaseArr1 As Sublight.WS.Release() = e.releases
                    Dim i1 As Integer = 0
                    While i1 < releaseArr1.Length
                        Dim release1 As Sublight.WS.Release = releaseArr1(i1)
                        lbReleases.Items.Add(New Sublight.Types.ListItem(Sublight.Controls.BasePageResults.ReleaseToString(release1), release1))
                        i1 = i1 + 1
                    End While
                End If
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.WS_GetReleasesCompleted?", e1)
                ExceptionHandlerUI(e1)
            End Try
        End Sub

        Private Sub ws_GetSubtitleCommentsLFPCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetSubtitleCommentsCompletedEventArgs)
            Dim commentItemsPanel1 As Sublight.Controls.CommentsControl.CommentItemsPanel = Nothing
            Try
                If Not e.Result Then
                    Dim objArr1 As Object() = New object() { e.error }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                    Return
                End If
                commentItemsPanel1 = TryCast(e.UserState, Sublight.Controls.CommentsControl.CommentItemsPanel)
                If (commentItemsPanel1) Is Nothing Then
                    Return
                End If
                ctrlComments.ItemsCount = e.totalComments
                ctrlComments.SelectFirstPage()
                If ((e.comments) Is Nothing) OrElse (e.comments.Length <= 0) Then
                    gbAddComment.Visible = False
                    lblCommentNote.Visible = True
                    lblCommentNote.Text = Sublight.Translation.FrmDetails_Tab_Comments_Note_SubtitleHasNoCommentsForSelectedLanguage
                    panelCommentsTop.Height = 60
                    Return
                End If
                Dim subtitleCommentArr1 As Sublight.WS.SubtitleComment() = e.comments
                Dim i1 As Integer = 0
                While i1 < subtitleCommentArr1.Length
                    Dim subtitleComment1 As Sublight.WS.SubtitleComment = subtitleCommentArr1(i1)
                    Dim commentItem1 As Sublight.Controls.CommentsControl.CommentItem = New Sublight.Controls.CommentsControl.CommentItem
                    commentItem1.Tag = subtitleComment1.ID
                    commentItem1.CanDelete = subtitleComment1.CanDelete
                    commentItem1.Points = subtitleComment1.Rate
                    commentItem1.HeaderText = System.String.Format("{0} ({1})?", subtitleComment1.User, subtitleComment1.Created)
                    commentItem1.Text = subtitleComment1.Message
                    commentItemsPanel1.Controls.Add(commentItem1)
                    i1 = i1 + 1
                End While
            Catch e1 As System.Exception
                btnSendComment.Enabled = True
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.ws_GetSubtitleCommentsLFPCompleted?", e1)
                ExceptionHandlerUI(e1)
            Finally
                If Not (commentItemsPanel1) Is Nothing Then
                    commentItemsPanel1.ControlsAdded()
                End If
                HideLoader(Me)
                BringToFront()
            End Try
        End Sub

        Private Sub ws_GetSubtitleCommentsPCCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetSubtitleCommentsCompletedEventArgs)
            Dim commentItemsPanel1 As Sublight.Controls.CommentsControl.CommentItemsPanel = Nothing
            Try
                If Not e.Result Then
                    Dim objArr1 As Object() = New object() { e.error }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                    Return
                End If
                commentItemsPanel1 = TryCast(e.UserState, Sublight.Controls.CommentsControl.CommentItemsPanel)
                If (commentItemsPanel1) Is Nothing Then
                    Return
                End If
                If (e.comments) Is Nothing Then
                    Return
                End If
                Dim subtitleCommentArr1 As Sublight.WS.SubtitleComment() = e.comments
                Dim i1 As Integer = 0
                While i1 < subtitleCommentArr1.Length
                    Dim subtitleComment1 As Sublight.WS.SubtitleComment = subtitleCommentArr1(i1)
                    Dim commentItem1 As Sublight.Controls.CommentsControl.CommentItem = New Sublight.Controls.CommentsControl.CommentItem
                    commentItem1.Tag = subtitleComment1.ID
                    commentItem1.CanDelete = subtitleComment1.CanDelete
                    commentItem1.Points = subtitleComment1.Rate
                    Dim dateTime1 As System.DateTime = subtitleComment1.Created
                    commentItem1.HeaderText = System.String.Format("{0} ({1})?", subtitleComment1.User, dateTime1.ToString())
                    commentItem1.Text = subtitleComment1.Message
                    commentItemsPanel1.Controls.Add(commentItem1)
                    i1 = i1 + 1
                End While
            Catch e1 As System.Exception
                btnSendComment.Enabled = True
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.ws_GetSubtitleCommentsPCCompleted?", e1)
                ExceptionHandlerUI(e1)
            Finally
                If Not (commentItemsPanel1) Is Nothing Then
                    commentItemsPanel1.ControlsAdded()
                End If
                HideLoader(Me)
            End Try
        End Sub

        Private Sub ws_GetSubtitleThanksCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetSubtitleThanksCompletedEventArgs)
            Try
                If Not (e.Error) Is Nothing Then
                    Dim objArr1 As Object() = New object() { e.Error.Message }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                    Return
                End If
                If Not e.Result Then
                    Dim objArr2 As Object() = New object() { e.error }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr2)
                    Return
                End If
                m_ShowThanks = True
                lvThanks.BeginUpdate()
                lvThanks.Items.Clear()
                If Not (e.users) Is Nothing Then
                    Dim subtitleThankArr1 As Sublight.WS.SubtitleThank() = e.users
                    Dim i3 As Integer = 0
                    While i3 < subtitleThankArr1.Length
                        Dim subtitleThank1 As Sublight.WS.SubtitleThank = subtitleThankArr1(i3)
                        Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(System.String.Format("{0}?", subtitleThank1.Created))
                        listViewItem1.SubItems.Add(subtitleThank1.Username)
                        lvThanks.Items.Add(listViewItem1)
                        i3 = i3 + 1
                    End While
                End If
                Dim columnHeader1 As System.Windows.Forms.ColumnHeader 
                For Each columnHeader1 In lvThanks.Columns
                    lvThanks.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent)
                    Dim i1 As Integer = columnHeader1.Width
                    lvThanks.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize)
                    Dim i2 As Integer = columnHeader1.Width
                    If i1 > i2 Then
                        columnHeader1.Width = i1
                    Else 
                        columnHeader1.Width = i2
                    End If
                Next
                lvThanks.EndUpdate()
                btnThanks.Enabled = e.allowThanks
            Finally
                HideLoader(Me)
                BringToFront()
            End Try
        End Sub

        Private Sub ws_RateSubtitleCompleted(ByVal sender As Object, ByVal e As Sublight.WS.RateSubtitleCompletedEventArgs)
            Try
                If Not e.Result Then
                    Return
                End If
                Dim l1 As Long = e.newVotes
                txtVotes.Text = l1.ToString()
                rateControl.Rate = e.newRate
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.ws_RateSubtitleCompleted?", e1)
                ExceptionHandlerUI(e1)
            End Try
        End Sub

        Private Sub ws_SubtitleCommentDeleteCompleted(ByVal sender As Object, ByVal e As Sublight.WS.SubtitleCommentDeleteCompletedEventArgs)
            If e.Result Then
                Dim commentItem1 As Sublight.Controls.CommentsControl.CommentItem = TryCast(e.UserState, Sublight.Controls.CommentsControl.CommentItem)
                If (commentItem1) Is Nothing Then
                    Return
                End If
                commentItem1.CanVote = False
                commentItem1.CanDelete = False
                commentItem1.Invalidate()
                Return
            End If
            Dim objArr1 As Object() = New object() { e.error }
            ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
        End Sub

        Private Sub ws_SubtitleCommentVoteCompleted(ByVal sender As Object, ByVal e As Sublight.WS.SubtitleCommentVoteCompletedEventArgs)
            If e.Result Then
                Dim commentItem1 As Sublight.Controls.CommentsControl.CommentItem = TryCast(e.UserState, Sublight.Controls.CommentsControl.CommentItem)
                If Not (commentItem1) Is Nothing Then
                    commentItem1.Points = e.newRate
                    commentItem1.CanVote = False
                    commentItem1.Invalidate()
                End If
            End If
        End Sub

        Private Sub WS_SubtitlePreviewCompleted(ByVal sender As Object, ByVal e As Sublight.WS.SubtitlePreviewCompletedEventArgs)
            m_wsCalled = True
            Try
                If Not e.Result Then
                    Dim objArr1 As Object() = New object() { e.error }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                    Return
                End If
                If (e.data) Is Nothing Then
                    Return
                End If
                Dim s1 As String = Sublight.FrmDetails2.Decompress(e.data)
                Dim stringReader1 As System.IO.StringReader = New System.IO.StringReader(s1)
                Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                While True
                    Dim s2 As String = stringReader1.ReadLine()
                    If Not (s2) Is Nothing Then
                        list1.Add(s2)
                    End If
                End While
                Dim i1 As Integer = 0
                listView1.BeginUpdate()
                listView1.Items.Clear()
                Dim i2 As Integer = 0
                While i2 < list1.get_Count()
                    Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(System.String.Format("{0}?", i2 + 1))
                    listViewItem1.SubItems.Add(list1.get_Item(i2))
                    listView1.Items.Add(listViewItem1)
                    i1 = i1 + Sublight.FrmDetails2.WordCount(list1.get_Item(i2))
                    i2 = i2 + 1
                End While
                txtNumDialogs.Text = System.String.Format("{0}?", list1.get_Count())
                txtNumWords.Text = System.String.Format("{0}?", i1)
                Dim columnHeader1 As System.Windows.Forms.ColumnHeader 
                For Each columnHeader1 In listView1.Columns
                    listView1.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent)
                    Dim i3 As Integer = columnHeader1.Width
                    listView1.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize)
                    Dim i4 As Integer = columnHeader1.Width
                    If i3 > i4 Then
                        columnHeader1.Width = i3
                    Else 
                        columnHeader1.Width = i4
                    End If
                Next
                listView1.EndUpdate()
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.WS_SubtitlePreviewCompleted?", e1)
                ExceptionHandlerUI(e1)
            Finally
                HideLoader(Me)
                BringToFront()
            End Try
        End Sub

        Private Sub ws_UpdateSubtitleCompleted(ByVal sender As Object, ByVal e As Sublight.WS.UpdateSubtitleCompletedEventArgs)
            Try
                HideLoader(Me)
                If Not e.Result Then
                    Dim objArr1 As Object() = New object() { e.error }
                    ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                    Return
                End If
                ShowInfo(Sublight.Translation.FrmDetails_SuccessfullyUpdated, New object(0) {})
            Catch e1 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmDetails2.ws_UpdateSubtitleCompleted?", e1)
                ExceptionHandlerUI(e1)
            End Try
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            If disposing AndAlso (Not (m_EditablePen) Is Nothing) Then
                m_EditablePen.Dispose()
                m_EditablePen = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Shared Function Decompress(ByVal compressedText As String) As String
            Dim s1 As String

            Dim bArr1 As Byte() = System.Convert.FromBase64String(compressedText)
            Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream
                Dim i1 As Integer = System.BitConverter.ToInt32(bArr1, 0)
                memoryStream1.Write(bArr1, 4, bArr1.Length - 4)
                Dim bArr2 As Byte() = New byte(i1) {}
                memoryStream1.Position = CLng(0)
                Using gzipStream1 As System.IO.Compression.GZipStream = New System.IO.Compression.GZipStream(memoryStream1, System.IO.Compression.CompressionMode.Decompress)
                    gzipStream1.Read(bArr2, 0, bArr2.Length)
                End Using
                s1 = System.Text.Encoding.UTF8.GetString(bArr2)
            End Using
            Return s1
        End Function

        Private Shared Function WordCount(ByVal txt As String) As Integer
            Dim i1 As Integer

            If System.String.IsNullOrEmpty(txt) Then
                Return 0
            End If
            Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\w+?")
            Dim matchCollection1 As System.Text.RegularExpressions.MatchCollection = regex1.Matches(txt)
            If matchCollection1.Count > 0 Then
                i1 = matchCollection1.Count
            Else 
                i1 = 0
            End If
            Return i1
        End Function

    End Class ' class FrmDetails2

End Namespace

