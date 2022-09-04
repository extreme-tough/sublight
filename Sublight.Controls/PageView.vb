Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BinaryComponents.SuperList
Imports BinaryComponents.WinFormsUtility.Drawing
Imports Elegant.Ui
Imports Sublight
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight.Controls

    Friend Class PageView
        Inherits Sublight.Controls.BasePageResults

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass2

            Public <>4__this As Sublight.Controls.PageView 
            Public subtitleReleases As System.Collections.Generic.Dictionary(Of System.Guid,System.Collections.Generic.List(Of String)) 
            Public subtitles As Sublight.WS.Subtitle() 

            Public Sub New()
            End Sub

            Public Sub <BindSubtitles>b__1()
                Dim sArr1 As String()

                <>4__this.lvResults.Items.Clear()
                <>4__this.m_data = New Sublight.Controls.SuperListItem.Data(subtitles.Length) {}
                Dim i1 As Integer = 0
                While i1 < subtitles.Length
                    If subtitleReleases.ContainsKey(subtitles(i1).SubtitleID) Then
                        sArr1 = subtitleReleases.get_Item(subtitles(i1).SubtitleID).ToArray()
                        If sArr1.Length <= 0 Then
                            sArr1 = Nothing
                        End If
                    Else 
                        sArr1 = Nothing
                    End If
                    <>4__this.m_data(i1) = New Sublight.Controls.SuperListItem.Data(subtitles(i1), sArr1, Nothing)
                    i1 = i1 + 1
                End While
                <>4__this.lvResults.Items.AddRange(<>4__this.m_data)
                <>4__this.lvResults.Items.SynchroniseWithUINow()
                If <>4__this.lvResults.Columns.get_Count() > 0 Then
                    <>4__this.lvResults.SizeColumnsToFit()
                End If
            End Sub

        End Class ' class <>c__DisplayClass2

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClassf

            Public <>4__this As Sublight.Controls.PageView 
            Public enabled As Boolean 

            Public Sub New()
            End Sub

            Public Sub <EnableAll>b__7()
                <>4__this._btnNew.Enabled = enabled
            End Sub

            Public Sub <EnableAll>b__8()
                <>4__this._btnFavorite.Enabled = enabled
            End Sub

            Public Sub <EnableAll>b__9()
                <>4__this._btnPublished.Enabled = enabled
            End Sub

            Public Sub <EnableAll>b__a()
                <>4__this._btnDownloaded.Enabled = enabled
            End Sub

        End Class ' class <>c__DisplayClassf

        Private ReadOnly itt As Sublight.Controls.ImageToolTip 
        Private ReadOnly m_searchPage As Sublight.Controls.PageSearch 
        Private ReadOnly m_tssl As Elegant.Ui.Control 

        Private _btnDownloaded As Elegant.Ui.ToggleButton 
        Private _btnFavorite As Elegant.Ui.ToggleButton 
        Private _btnNew As Elegant.Ui.ToggleButton 
        Private _btnPublished As Elegant.Ui.ToggleButton 
        Private _btnStatistics As Elegant.Ui.ToggleButton 
        Private btnClearMyDownloads As System.Windows.Forms.ToolStripButton 
        Private btnDownload As System.Windows.Forms.ToolStripButton 
        Private btnIMDB As System.Windows.Forms.ToolStripButton 
        Private btnRefresh As System.Windows.Forms.ToolStripButton 
        Private components As System.ComponentModel.IContainer 
        Private contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip 
        Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog 
        Private lblViewTitle As System.Windows.Forms.ToolStripLabel 
        Private lvResults As Sublight.Controls.MySuperList 
        Private m_data As Sublight.Controls.SuperListItem.Data() 
        Private m_Initialized As Boolean 
        Private m_PageViewStatistics As Sublight.Controls.PageViewStatistics 
        Private m_subtitlesWithoutReleaseInfo As System.Collections.Generic.List(Of System.Guid) 
        Private mnuAddAlternativeTitle As System.Windows.Forms.ToolStripMenuItem 
        Private mnuAddRelease As System.Windows.Forms.ToolStripMenuItem 
        Private mnuDelete As System.Windows.Forms.ToolStripMenuItem 
        Private mnuDownload As System.Windows.Forms.ToolStripMenuItem 
        Private mnuEdit As System.Windows.Forms.ToolStripMenuItem 
        Private mnuIMDB As System.Windows.Forms.ToolStripMenuItem 
        Private mnuNFO As System.Windows.Forms.ToolStripMenuItem 
        Private mnuProperties As System.Windows.Forms.ToolStripMenuItem 
        Private mnuRate As System.Windows.Forms.ToolStripMenuItem 
        Private mnuRateVal1 As System.Windows.Forms.ToolStripMenuItem 
        Private mnuRateVal2 As System.Windows.Forms.ToolStripMenuItem 
        Private mnuRateVal3 As System.Windows.Forms.ToolStripMenuItem 
        Private mnuRateVal4 As System.Windows.Forms.ToolStripMenuItem 
        Private mnuRateVal5 As System.Windows.Forms.ToolStripMenuItem 
        Private mnuReportSubtitle As System.Windows.Forms.ToolStripMenuItem 
        Private mnuSearchAllMovieSubtitles As System.Windows.Forms.ToolStripMenuItem 
        Private mnuSearchAllSubtitlesForThisPublisher As System.Windows.Forms.ToolStripMenuItem 
        Private mnuSubtitlePreview As System.Windows.Forms.ToolStripMenuItem 
        Private toolStrip2 As Sublight.Controls.SecondaryToolStrip 
        Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator 
        Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator 
        Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator 
        Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator 
        Private toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator 

        Friend ReadOnly Property BtnStatistics As Elegant.Ui.ToggleButton
            Get
                Return _btnStatistics
            End Get
        End Property

        Friend Shadows ReadOnly Property IsActiveTab As Boolean
            Get
                Return MyBase.IsActiveTab
            End Get
        End Property

        Friend ReadOnly Property SelectedImdb As String
            Get
                Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
                If (subtitle1) Is Nothing Then
                    Return Nothing
                End If
                If Sublight.MyUtility.SubtitleUtil.IsNonImdbMovie(subtitle1) Then
                    Return Nothing
                End If
                Return subtitle1.IMDB
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal tssl As Elegant.Ui.Control, ByVal searchPage As Sublight.Controls.PageSearch, ByVal rtp As Elegant.Ui.RibbonTabPage)
            InitializeComponent()
            m_searchPage = searchPage
            _btnNew = TryCast(GetTabControlByName("tbViewNew?"), Elegant.Ui.ToggleButton)
            If (_btnNew) Is Nothing Then
                Throw New System.NullReferenceException("tbViewNew?")
            End If
            _btnNew.Pressed = True
            AddHandler _btnNew.Click, AddressOf btnNew_Click
            _btnFavorite = TryCast(GetTabControlByName("tbViewFavorite?"), Elegant.Ui.ToggleButton)
            If (_btnFavorite) Is Nothing Then
                Throw New System.NullReferenceException("tbViewFavorite?")
            End If
            AddHandler _btnFavorite.Click, AddressOf btnFavorites_Click
            _btnPublished = TryCast(GetTabControlByName("tbViewPublished?"), Elegant.Ui.ToggleButton)
            If (_btnPublished) Is Nothing Then
                Throw New System.NullReferenceException("tbViewPublished?")
            End If
            AddHandler _btnPublished.Click, AddressOf btnPublishedByMe_Click
            _btnDownloaded = TryCast(GetTabControlByName("tbViewDownloaded?"), Elegant.Ui.ToggleButton)
            If (_btnDownloaded) Is Nothing Then
                Throw New System.NullReferenceException("tbViewDownloaded?")
            End If
            AddHandler _btnDownloaded.Click, AddressOf btnDownloadedByMe_Click
            _btnStatistics = TryCast(GetTabControlByName("tbViewStatistics?"), Elegant.Ui.ToggleButton)
            If (_btnStatistics) Is Nothing Then
                Throw New System.NullReferenceException("tbViewStatistics?")
            End If
            AddHandler _btnStatistics.Click, AddressOf btnStatistics_Click
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            AddHandler Sublight.Globals.Events.UserLogIn, AddressOf Events_UserLogIn
            AddHandler Sublight.Globals.Events.UserLogOff, AddressOf Events_UserLogOff
            AddHandler Sublight.Globals.Events.SettingsLoaded, AddressOf Events_SettingsLoaded
            m_tssl = tssl
            AddHandler lvResults.SelectedItems.DataChanged, AddressOf SelectedItems_DataChanged
            AddHandler lvResults.DoubleClick, AddressOf mnuDownload_DoubleClick
            itt = New Sublight.Controls.ImageToolTip(lvResults)
            AddHandler lvResults.MouseMove, AddressOf lvSearchResults_MouseMove
            AddHandler lvResults.MouseLeave, AddressOf lvSearchResults_MouseLeave
            AddHandler lvResults.MouseWheel, AddressOf lvSearchResults_MouseWheel
            mnuProperties.ShowShortcutKeys = True
            mnuProperties.ShortcutKeys = System.Windows.Forms.Keys.F4
            mnuSubtitlePreview.ShowShortcutKeys = True
            mnuSubtitlePreview.ShortcutKeys = System.Windows.Forms.Keys.F6
            mnuNFO.ShowShortcutKeys = True
            mnuNFO.ShortcutKeys = System.Windows.Forms.Keys.RButton Or System.Windows.Forms.Keys.MButton Or System.Windows.Forms.Keys.Back Or System.Windows.Forms.Keys.Control
            mnuEdit.ShowShortcutKeys = True
            mnuEdit.ShortcutKeys = System.Windows.Forms.Keys.LButton Or System.Windows.Forms.Keys.MButton Or System.Windows.Forms.Keys.Control
            mnuDelete.ShowShortcutKeys = True
            mnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
            AddHandler ParentBaseForm.KeyUp, AddressOf ParentBaseForm_KeyUp
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <Events_UserLogIn>b__5()
            _btnPublished.Enabled = False
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <Events_UserLogIn>b__6()
            _btnPublished.Enabled = True
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <Events_UserLogOff>b__4()
            _btnPublished.Enabled = False
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <RefreshMatchesCount>b__11()
            m_tssl.Text = System.String.Format(Sublight.Translation.Search_Status_NumberOfHits, lvResults.Items.Count)
        End Sub

        Private Sub BindSubtitles(ByVal subtitles As Sublight.WS.Subtitle(), ByVal allReleases As Sublight.WS.Release())
            Dim list3 As System.Collections.Generic.List(Of String)

            Dim <>c__DisplayClass2_1 As Sublight.Controls.PageView.<>c__DisplayClass2 = New Sublight.Controls.PageView.<>c__DisplayClass2
            <>c__DisplayClass2_1.subtitles = subtitles
            <>c__DisplayClass2_1.<>4__this = Me
            If (<>c__DisplayClass2_1.subtitles) Is Nothing Then
                <>c__DisplayClass2_1.subtitles = New Sublight.WS.Subtitle(0) {}
            End If
            m_subtitlesWithoutReleaseInfo = New System.Collections.Generic.List(Of System.Guid)
            <>c__DisplayClass2_1.subtitleReleases = New System.Collections.Generic.Dictionary(Of System.Guid,System.Collections.Generic.List(Of String))
            If Not (allReleases) Is Nothing Then
                Dim i1 As Integer = 0
                While i1 < allReleases.Length
                    Dim release1 As Sublight.WS.Release = allReleases(i1)
                    If Not <>c__DisplayClass2_1.subtitleReleases.ContainsKey(release1.SubtitleID) Then
                        list3 = New System.Collections.Generic.List(Of String)
                        <>c__DisplayClass2_1.subtitleReleases.Add(release1.SubtitleID, list3)
                    Else 
                        list3 = <>c__DisplayClass2_1.subtitleReleases.get_Item(release1.SubtitleID)
                    End If
                    If list3.get_Count() < 3 Then
                        list3.Add(Sublight.Controls.BasePageResults.ReleaseToString(release1))
                    ElseIf list3.get_Count() = 3 Then
                        list3.Add("...?")
                    End If
                    i1 = i1 + 1
                End While
            End If
            Dim i2 As Integer = 0
            While i2 < <>c__DisplayClass2_1.subtitles.Length
                If Not <>c__DisplayClass2_1.subtitleReleases.ContainsKey(<>c__DisplayClass2_1.subtitles(i2).SubtitleID) Then
                    m_subtitlesWithoutReleaseInfo.Add(<>c__DisplayClass2_1.subtitles(i2).SubtitleID)
                    Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                    list1.Add(Sublight.Translation.Common_SearchResults_NoReleaseInfo)
                    Dim list2 As System.Collections.Generic.List(Of String) = list1
                    <>c__DisplayClass2_1.subtitleReleases.Add(<>c__DisplayClass2_1.subtitles(i2).SubtitleID, list2)
                End If
                i2 = i2 + 1
            End While
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass2_1.<BindSubtitles>b__1)
            Sublight.BaseForm.DoCtrlInvoke(lvResults, Me, methodInvoker1)
            RefreshMatchesCount()
            OnResultsChanged()
            EnableAll(True)
        End Sub

        Private Sub btnClearMyDownloads_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not (Sublight.Properties.Settings.Default.View_MyDownloads) Is Nothing Then
                Sublight.Properties.Settings.Default.View_MyDownloads.Clear()
            Else 
                Sublight.Properties.Settings.Default.View_MyDownloads = New Sublight.Types.DownloadedSubtitleCollection
            End If
            ParentBaseForm.SaveUserSettings()
            btnRefresh_Click(Me, Nothing)
            itt.Hide()
        End Sub

        Private Sub btnDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            OnDownload(lvResults, folderBrowserDialog1, Nothing, False)
        End Sub

        Private Sub btnDownloadedByMe_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim guidArr1 As System.Guid()

            If TryCast(sender, System.Windows.Forms.ToolStripButton) AndAlso _btnDownloaded.Pressed Then
                Return
            End If
            CheckButton(sender)
            If Not (Sublight.Properties.Settings.Default.View_MyDownloads) Is Nothing Then
                Dim list1 As System.Collections.Generic.List(Of System.Guid) = New System.Collections.Generic.List(Of System.Guid)(Sublight.Properties.Settings.Default.View_MyDownloads.ToArray())
                list1.Reverse()
                guidArr1 = list1.ToArray()
            Else 
                guidArr1 = Nothing
            End If
            Dim objArr1 As Object() = New object() { _
                                                     Sublight.BaseForm.Session, _
                                                     guidArr1 }
            Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_DOWNLOADDBYME, ParentBaseForm, Me, objArr1)
            AddHandler webServiceHandler1.OnException, AddressOf wsh_OnException
            AddHandler webServiceHandler1.DoCall, AddressOf Sublight.Controls.PageView.wshDownloadedSubtitles_DoCall
            AddHandler webServiceHandler1.OnResult, AddressOf wshDownloadedSubtitles_OnResult
            AddHandler webServiceHandler1.OnCompleted, AddressOf wsh_OnCompleted
            webServiceHandler1.RunWorkerAsync()
        End Sub

        Private Sub btnFavorites_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If TryCast(sender, System.Windows.Forms.ToolStripButton) AndAlso _btnFavorite.Pressed Then
                Return
            End If
            CheckButton(sender)
            Dim objArr1 As Object() = New object() { Sublight.BaseForm.Session }
            Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_FAVORITE, ParentBaseForm, Me, objArr1)
            AddHandler webServiceHandler1.OnException, AddressOf wsh_OnException
            AddHandler webServiceHandler1.DoCall, AddressOf Sublight.Controls.PageView.wshFavoriteSubtitles_DoCall
            AddHandler webServiceHandler1.OnResult, AddressOf wshFavoriteSubtitles_OnResult
            AddHandler webServiceHandler1.OnCompleted, AddressOf wsh_OnCompleted
            webServiceHandler1.RunWorkerAsync()
        End Sub

        Private Sub btnIMDB_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            ParentBaseForm.OpenInBrowser(subtitle1.IMDB)
        End Sub

        Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If TryCast(sender, System.Windows.Forms.ToolStripButton) AndAlso _btnNew.Pressed Then
                Return
            End If
            CheckButton(sender)
            Dim objArr1 As Object() = New object() { Sublight.BaseForm.Session }
            Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_NEW, ParentBaseForm, Me, objArr1)
            AddHandler webServiceHandler1.OnException, AddressOf wsh_OnException
            AddHandler webServiceHandler1.DoCall, AddressOf Sublight.Controls.PageView.wshNewSubtitles_DoCall
            AddHandler webServiceHandler1.OnResult, AddressOf wshNewSubtitles_OnResult
            AddHandler webServiceHandler1.OnCompleted, AddressOf wsh_OnCompleted
            webServiceHandler1.RunWorkerAsync()
        End Sub

        Private Sub btnPublishedByMe_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If TryCast(sender, System.Windows.Forms.ToolStripButton) AndAlso _btnPublished.Pressed Then
                Return
            End If
            CheckButton(sender)
            Dim objArr1 As Object() = New object() { Sublight.BaseForm.Session }
            Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_PUBLISHEDBYME, ParentBaseForm, Me, objArr1)
            AddHandler webServiceHandler1.OnException, AddressOf wsh_OnException
            AddHandler webServiceHandler1.DoCall, AddressOf Sublight.Controls.PageView.wshUploadedSubtitles_DoCall
            AddHandler webServiceHandler1.OnResult, AddressOf wshUploadedSubtitles_OnResult
            AddHandler webServiceHandler1.OnCompleted, AddressOf wsh_OnCompleted
            webServiceHandler1.RunWorkerAsync()
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Using ienumerator1 As System.Collections.Generic.IEnumerator(Of BinaryComponents.SuperList.Column) = lvResults.Columns.GetEnumerator()
                While ienumerator1.MoveNext()
                    Dim column1 As BinaryComponents.SuperList.Column = ienumerator1.get_Current()
                    column1.SortOrder = System.Windows.Forms.SortOrder.None
                End While
            End Using
            If _btnNew.Pressed Then
                btnNew_Click(Me, Nothing)
                Return
            End If
            If _btnFavorite.Pressed Then
                btnFavorites_Click(Me, Nothing)
                Return
            End If
            If _btnPublished.Pressed Then
                btnPublishedByMe_Click(Me, Nothing)
                Return
            End If
            If _btnDownloaded.Pressed Then
                btnDownloadedByMe_Click(Me, Nothing)
            End If
        End Sub

        Private Sub btnStatistics_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If TryCast(sender, System.Windows.Forms.ToolStripButton) AndAlso _btnStatistics.Pressed Then
                Return
            End If
            CheckButton(sender)
            If (m_PageViewStatistics) Is Nothing Then
                SuspendLayout()
                m_PageViewStatistics = New Sublight.Controls.PageViewStatistics(ParentBaseForm, Me)
                m_PageViewStatistics.SuspendLayout()
                m_PageViewStatistics.Dock = System.Windows.Forms.DockStyle.Fill
                Controls.Add(m_PageViewStatistics)
                m_PageViewStatistics.ResumeLayout()
                ResumeLayout()
            End If
            lvResults.Visible = False
            m_PageViewStatistics.Visible = True
            m_PageViewStatistics.BindControl()
            EnableAll(True)
        End Sub

        Private Sub CheckButton(ByVal sender As Object)
            Dim toggleButton1 As Elegant.Ui.ToggleButton = TryCast(sender, Elegant.Ui.ToggleButton)
            EnableAll(False)
            If (toggleButton1) Is Nothing Then
                Return
            End If
            If toggleButton1.Pressed Then
                Return
            End If
            UncheckAll()
            toggleButton1.Pressed = True
            If toggleButton1 = _btnDownloaded Then
                btnClearMyDownloads.Visible = True
            Else 
                btnClearMyDownloads.Visible = False
            End If
            lvResults.Visible = True
            If Not (m_PageViewStatistics) Is Nothing Then
                m_PageViewStatistics.Visible = False
            End If
            toolStrip2.Visible = toggleButton1.Name <> _btnStatistics.Name
            SetInfoLabel()
        End Sub

        Private Sub contextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            If ((lvResults.SelectedItems) Is Nothing) OrElse ((lvResults.Items) Is Nothing) OrElse (lvResults.SelectedItems.Count <= 0) OrElse (lvResults.Items.Count <= 0) Then
                e.Cancel = True
                Return
            End If
            mnuDownload.Visible = btnDownload.Enabled
            mnuIMDB.Visible = btnIMDB.Enabled
            mnuAddRelease.Visible = Not Sublight.BaseForm.IsAnonymous
            mnuDelete.Visible = False
            mnuEdit.Visible = False
            mnuProperties.Visible = btnIMDB.Enabled
            mnuSubtitlePreview.Visible = btnIMDB.Enabled
            mnuAddAlternativeTitle.Visible = False
            mnuAddRelease.Text = Sublight.Translation.Search_Context_AddRelease
            mnuRate.Text = Sublight.Translation.Search_Context_RateSubtitle
            mnuReportSubtitle.Text = Sublight.Translation.Search_Context_ReportSubtitle
            mnuIMDB.Text = Sublight.Translation.Search_Context_IMDB
            mnuSearchAllMovieSubtitles.Text = Sublight.Translation.Search_Context_SearchAllSubtitlesForThisMovie
            mnuSearchAllSubtitlesForThisPublisher.Text = Sublight.Translation.Search_Context_SearchAllSubtitlesFromThisPublisher
            mnuRateVal1.Text = Sublight.Translation.Search_Context_RateSubtitle_1
            mnuRateVal2.Text = Sublight.Translation.Search_Context_RateSubtitle_2
            mnuRateVal3.Text = Sublight.Translation.Search_Context_RateSubtitle_3
            mnuRateVal4.Text = Sublight.Translation.Search_Context_RateSubtitle_4
            mnuRateVal5.Text = Sublight.Translation.Search_Context_RateSubtitle_5
            mnuProperties.Text = Sublight.Translation.Common_Menu_Properties
            mnuSubtitlePreview.Text = Sublight.Translation.FrmDetails_Tab_SubtitlePreview
            mnuSearchAllMovieSubtitles.Text = Sublight.Translation.Search_Context_SearchAllSubtitlesForThisMovie
            mnuSearchAllSubtitlesForThisPublisher.Text = Sublight.Translation.Search_Context_SearchAllSubtitlesFromThisPublisher
            If Sublight.Controls.BasePageResults.AreMultipleItemsSelected(lvResults) Then
                mnuDownload.Text = Sublight.Translation.Search_Context_DownloadSubtitles
                toolStripSeparator3.Visible = False
                toolStripSeparator5.Visible = False
                mnuAddRelease.Visible = False
                mnuRate.Visible = False
                mnuReportSubtitle.Visible = False
                mnuIMDB.Visible = False
                mnuNFO.Visible = False
                toolStripSeparator7.Visible = False
                toolStripSeparator8.Visible = False
                mnuSearchAllMovieSubtitles.Visible = False
                mnuSearchAllSubtitlesForThisPublisher.Visible = False
            Else 
                toolStripSeparator3.Visible = True
                toolStripSeparator5.Visible = True
                mnuRate.Visible = True
                mnuReportSubtitle.Visible = True
                mnuDownload.Text = Sublight.Translation.View_Context_DownloadSubtitle
                Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
                If (Not (subtitle1) Is Nothing) AndAlso Sublight.MyUtility.SubtitleUtil.IsNonImdbMovie(subtitle1) Then
                    mnuIMDB.Visible = False
                    mnuNFO.Visible = False
                    toolStripSeparator7.Visible = False
                Else 
                    mnuIMDB.Visible = True
                    mnuNFO.Visible = True
                    toolStripSeparator7.Visible = True
                End If
                If Not (subtitle1) Is Nothing Then
                    mnuDelete.Visible = subtitle1.CanDelete
                    mnuEdit.Visible = Not Sublight.BaseForm.IsAnonymous
                End If
                toolStripSeparator8.Visible = True
                mnuSearchAllMovieSubtitles.Visible = True
                mnuSearchAllSubtitlesForThisPublisher.Visible = True
            End If
            Dim flag1 As Boolean = lvResults.Items.Count > 0
            e.Cancel = Not flag1
        End Sub

        Private Sub EnableAll(ByVal enabled As Boolean)
            Dim methodInvoker5 As System.Windows.Forms.MethodInvoker = Nothing
            Dim methodInvoker6 As System.Windows.Forms.MethodInvoker = Nothing
            Dim methodInvoker7 As System.Windows.Forms.MethodInvoker = Nothing
            Dim methodInvoker8 As System.Windows.Forms.MethodInvoker = Nothing
            Dim <>c__DisplayClassf1 As Sublight.Controls.PageView.<>c__DisplayClassf = New Sublight.Controls.PageView.<>c__DisplayClassf
            <>c__DisplayClassf1.enabled = enabled
            <>c__DisplayClassf1.<>4__this = Me
            If <>c__DisplayClassf1.enabled <> _btnNew.Enabled Then
                If (methodInvoker5) Is Nothing Then
                    methodInvoker5 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClassf1.<EnableAll>b__7)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker5
                Sublight.BaseForm.DoCtrlInvoke(_btnNew, Me, methodInvoker1)
            End If
            If <>c__DisplayClassf1.enabled <> _btnFavorite.Enabled Then
                If (methodInvoker6) Is Nothing Then
                    methodInvoker6 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClassf1.<EnableAll>b__8)
                End If
                Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = methodInvoker6
                Sublight.BaseForm.DoCtrlInvoke(_btnFavorite, Me, methodInvoker2)
            End If
            If (<>c__DisplayClassf1.enabled <> _btnPublished.Enabled) AndAlso Not Sublight.BaseForm.IsAnonymous Then
                If (methodInvoker7) Is Nothing Then
                    methodInvoker7 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClassf1.<EnableAll>b__9)
                End If
                Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = methodInvoker7
                Sublight.BaseForm.DoCtrlInvoke(_btnPublished, Me, methodInvoker3)
            End If
            If <>c__DisplayClassf1.enabled <> _btnDownloaded.Enabled Then
                If (methodInvoker8) Is Nothing Then
                    methodInvoker8 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClassf1.<EnableAll>b__a)
                End If
                Dim methodInvoker4 As System.Windows.Forms.MethodInvoker = methodInvoker8
                Sublight.BaseForm.DoCtrlInvoke(_btnDownloaded, Me, methodInvoker4)
            End If
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            _btnNew.Text = Sublight.Translation.View_Toolbar_New
            _btnFavorite.Text = Sublight.Translation.View_Toolbar_Favorites
            _btnDownloaded.Text = Sublight.Translation.View_Toolbar_DownloadedByMe
            _btnPublished.Text = Sublight.Translation.View_Toolbar_PublishedByMe
            btnRefresh.Text = Sublight.Translation.View_Toolbar_Refresh + " (F5)?"
            btnIMDB.Text = Sublight.Translation.View_Toolbar_IMDB
            btnClearMyDownloads.Text = Sublight.Translation.Common_Button_Clear
            _btnStatistics.Text = Sublight.Translation.View_Toolbar_Statistics
            TranslateResults()
            SetInfoLabel()
            RefreshMatchesCount()
            SetDownloadButtonText()
            mnuDelete.Text = Sublight.Translation.Common_Button_Delete
            mnuEdit.Text = Sublight.Translation.Common_Button_Edit
        End Sub

        Private Sub Events_SettingsLoaded(ByVal sender As Object)
            SetDownloadButtonText()
        End Sub

        Private Sub Events_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<Events_UserLogIn>b__5)
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<Events_UserLogIn>b__6)
            mnuEdit.Visible = Not isAnonymous
            If isAnonymous Then
                Sublight.BaseForm.DoCtrlInvoke(_btnPublished, Me, methodInvoker1)
                Return
            End If
            Sublight.BaseForm.DoCtrlInvoke(_btnPublished, Me, methodInvoker2)
        End Sub

        Private Sub Events_UserLogOff(ByVal sender As Object)
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<Events_UserLogOff>b__4)
            Sublight.BaseForm.DoCtrlInvoke(_btnPublished, Me, methodInvoker1)
            If _btnPublished.Pressed Then
                btnNew_Click(_btnNew, Nothing)
            End If
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            Dim mySectionFactory1 As Sublight.Controls.SuperListItem.MySectionFactory = New Sublight.Controls.SuperListItem.MySectionFactory
            toolStrip2 = New Sublight.Controls.SecondaryToolStrip
            lblViewTitle = New System.Windows.Forms.ToolStripLabel
            btnDownload = New System.Windows.Forms.ToolStripButton
            btnRefresh = New System.Windows.Forms.ToolStripButton
            btnClearMyDownloads = New System.Windows.Forms.ToolStripButton
            toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            btnIMDB = New System.Windows.Forms.ToolStripButton
            lvResults = New Sublight.Controls.MySuperList
            contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(components)
            mnuDownload = New System.Windows.Forms.ToolStripMenuItem
            mnuAddRelease = New System.Windows.Forms.ToolStripMenuItem
            mnuAddAlternativeTitle = New System.Windows.Forms.ToolStripMenuItem
            mnuReportSubtitle = New System.Windows.Forms.ToolStripMenuItem
            mnuEdit = New System.Windows.Forms.ToolStripMenuItem
            mnuDelete = New System.Windows.Forms.ToolStripMenuItem
            toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            mnuRate = New System.Windows.Forms.ToolStripMenuItem
            mnuRateVal1 = New System.Windows.Forms.ToolStripMenuItem
            mnuRateVal2 = New System.Windows.Forms.ToolStripMenuItem
            mnuRateVal3 = New System.Windows.Forms.ToolStripMenuItem
            mnuRateVal4 = New System.Windows.Forms.ToolStripMenuItem
            mnuRateVal5 = New System.Windows.Forms.ToolStripMenuItem
            toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
            mnuSearchAllMovieSubtitles = New System.Windows.Forms.ToolStripMenuItem
            mnuSearchAllSubtitlesForThisPublisher = New System.Windows.Forms.ToolStripMenuItem
            toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
            mnuIMDB = New System.Windows.Forms.ToolStripMenuItem
            toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
            mnuSubtitlePreview = New System.Windows.Forms.ToolStripMenuItem
            mnuNFO = New System.Windows.Forms.ToolStripMenuItem
            mnuProperties = New System.Windows.Forms.ToolStripMenuItem
            folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
            toolStrip2.SuspendLayout()
            contextMenuStrip1.SuspendLayout()
            SuspendLayout()
            Dim toolStripItemArr1 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       lblViewTitle, _
                                                                                                                       btnDownload, _
                                                                                                                       btnRefresh, _
                                                                                                                       btnClearMyDownloads, _
                                                                                                                       toolStripSeparator2, _
                                                                                                                       btnIMDB }
            toolStrip2.Items.AddRange(toolStripItemArr1)
            toolStrip2.Location = New System.Drawing.Point(0, 0)
            toolStrip2.Name = "toolStrip2?"
            toolStrip2.Size = New System.Drawing.Size(668, 27)
            toolStrip2.TabIndex = 102
            toolStrip2.Text = "toolStrip2?"
            lblViewTitle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            lblViewTitle.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblViewTitle.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblViewTitle.Name = "lblViewTitle?"
            lblViewTitle.Size = New System.Drawing.Size(232, 24)
            lblViewTitle.Text = "Seznam najnovejših podnapisov?"
            btnDownload.Enabled = False
            btnDownload.ForeColor = System.Drawing.SystemColors.ControlText
            btnDownload.Image = Sublight.Properties.Resources.ToolbarDownload
            btnDownload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            btnDownload.ImageTransparentColor = System.Drawing.Color.Magenta
            btnDownload.Name = "btnDownload?"
            btnDownload.Size = New System.Drawing.Size(76, 24)
            btnDownload.Text = "Prenos...?"
            AddHandler btnDownload.Click, AddressOf btnDownload_Click
            btnRefresh.BackColor = System.Drawing.Color.Transparent
            btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText
            btnRefresh.Image = Sublight.Properties.Resources.ToolbarReloadSmall
            btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
            btnRefresh.Name = "btnRefresh?"
            btnRefresh.Size = New System.Drawing.Size(64, 24)
            btnRefresh.Text = "Osveži?"
            AddHandler btnRefresh.Click, AddressOf btnRefresh_Click
            btnClearMyDownloads.ForeColor = System.Drawing.SystemColors.ControlText
            btnClearMyDownloads.Image = Sublight.Properties.Resources.ToolbarDeleteSmall
            btnClearMyDownloads.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            btnClearMyDownloads.ImageTransparentColor = System.Drawing.Color.Magenta
            btnClearMyDownloads.Name = "btnClearMyDownloads?"
            btnClearMyDownloads.Size = New System.Drawing.Size(65, 24)
            btnClearMyDownloads.Text = "Osveži?"
            AddHandler btnClearMyDownloads.Click, AddressOf btnClearMyDownloads_Click
            toolStripSeparator2.Name = "toolStripSeparator2?"
            toolStripSeparator2.Size = New System.Drawing.Size(6, 27)
            toolStripSeparator2.Visible = False
            btnIMDB.Enabled = False
            btnIMDB.ForeColor = System.Drawing.SystemColors.ControlText
            btnIMDB.Image = Sublight.Properties.Resources.ToolbarIMDB
            btnIMDB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            btnIMDB.ImageTransparentColor = System.Drawing.Color.Magenta
            btnIMDB.Name = "btnIMDB?"
            btnIMDB.Size = New System.Drawing.Size(60, 24)
            btnIMDB.Text = "IMDb?"
            btnIMDB.Visible = False
            AddHandler btnIMDB.Click, AddressOf btnIMDB_Click
            lvResults.AllowDrop = True
            lvResults.AllowRowDragDrop = False
            lvResults.AllowSorting = True
            lvResults.AlternatingRowColor = System.Drawing.Color.Empty
            lvResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            lvResults.ContextMenuStrip = contextMenuStrip1
            lvResults.Dock = System.Windows.Forms.DockStyle.Fill
            lvResults.FocusedItem = Nothing
            lvResults.GroupSectionFont = Nothing
            lvResults.GroupSectionForeColor = System.Drawing.SystemColors.WindowText
            lvResults.GroupSectionTextPlural = "Items?"
            lvResults.GroupSectionTextSingular = "Item?"
            lvResults.GroupSectionVerticalAlignment = BinaryComponents.WinFormsUtility.Drawing.GdiPlusEx.VAlignment.Top
            lvResults.IndentColor = System.Drawing.Color.LightGoldenrodYellow
            lvResults.Location = New System.Drawing.Point(0, 27)
            lvResults.MultiSelect = True
            lvResults.Name = "lvResults?"
            lvResults.SectionFactory = mySectionFactory1
            lvResults.SeparatorColor = System.Drawing.Color.FromArgb(123, 164, 224)
            lvResults.ShowCustomizeSection = False
            lvResults.ShowHeaderSection = True
            lvResults.Size = New System.Drawing.Size(668, 267)
            lvResults.TabIndex = 103
            contextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
            Dim toolStripItemArr2 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       mnuDownload, _
                                                                                                                       mnuAddRelease, _
                                                                                                                       mnuAddAlternativeTitle, _
                                                                                                                       mnuReportSubtitle, _
                                                                                                                       mnuEdit, _
                                                                                                                       mnuDelete, _
                                                                                                                       toolStripSeparator3, _
                                                                                                                       mnuRate, _
                                                                                                                       toolStripSeparator5, _
                                                                                                                       mnuSearchAllMovieSubtitles, _
                                                                                                                       mnuSearchAllSubtitlesForThisPublisher, _
                                                                                                                       toolStripSeparator8, _
                                                                                                                       mnuIMDB, _
                                                                                                                       toolStripSeparator7, _
                                                                                                                       mnuSubtitlePreview, _
                                                                                                                       mnuNFO, _
                                                                                                                       mnuProperties }
            contextMenuStrip1.Items.AddRange(toolStripItemArr2)
            contextMenuStrip1.Name = "contextMenuStrip1?"
            contextMenuStrip1.Size = New System.Drawing.Size(270, 388)
            AddHandler contextMenuStrip1.Opening, AddressOf contextMenuStrip1_Opening
            mnuDownload.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            mnuDownload.Image = Sublight.Properties.Resources.ToolbarDownloadSmall
            mnuDownload.Name = "mnuDownload?"
            mnuDownload.Size = New System.Drawing.Size(269, 26)
            mnuDownload.Text = "Prenos?"
            AddHandler mnuDownload.DoubleClick, AddressOf mnuDownload_DoubleClick
            AddHandler mnuDownload.Click, AddressOf mnuDownload_Click
            mnuAddRelease.Name = "mnuAddRelease?"
            mnuAddRelease.Size = New System.Drawing.Size(269, 26)
            mnuAddRelease.Text = "Dodaj razlicico...?"
            AddHandler mnuAddRelease.Click, AddressOf mnuAddRelease_Click
            mnuAddAlternativeTitle.Name = "mnuAddAlternativeTitle?"
            mnuAddAlternativeTitle.Size = New System.Drawing.Size(269, 26)
            mnuAddAlternativeTitle.Text = "Dodaj alternativni naslov...?"
            mnuReportSubtitle.Image = Sublight.Properties.Resources.ToolbarReportSmall
            mnuReportSubtitle.Name = "mnuReportSubtitle?"
            mnuReportSubtitle.Size = New System.Drawing.Size(269, 26)
            mnuReportSubtitle.Text = "Prijava neustreznega podnapisa?"
            AddHandler mnuReportSubtitle.Click, AddressOf mnuReportSubtitle_Click
            mnuEdit.Image = Sublight.Properties.Resources.ToolbarEditSmall
            mnuEdit.Name = "mnuEdit?"
            mnuEdit.Size = New System.Drawing.Size(269, 26)
            mnuEdit.Text = "Edit...?"
            AddHandler mnuEdit.Click, AddressOf mnuEdit_Click
            mnuDelete.Image = Sublight.Properties.Resources.ToolbarDeleteSmall
            mnuDelete.Name = "mnuDelete?"
            mnuDelete.Size = New System.Drawing.Size(269, 26)
            mnuDelete.Text = "Izbriši?"
            AddHandler mnuDelete.Click, AddressOf mnuDelete_Click
            toolStripSeparator3.Name = "toolStripSeparator3?"
            toolStripSeparator3.Size = New System.Drawing.Size(266, 6)
            Dim toolStripItemArr3 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       mnuRateVal1, _
                                                                                                                       mnuRateVal2, _
                                                                                                                       mnuRateVal3, _
                                                                                                                       mnuRateVal4, _
                                                                                                                       mnuRateVal5 }
            mnuRate.DropDownItems.AddRange(toolStripItemArr3)
            mnuRate.Name = "mnuRate?"
            mnuRate.Size = New System.Drawing.Size(269, 26)
            mnuRate.Text = "Oceni podnapis?"
            mnuRateVal1.Name = "mnuRateVal1?"
            mnuRateVal1.Size = New System.Drawing.Size(180, 22)
            mnuRateVal1.Text = "Ocena 1 (zelo slabo)?"
            AddHandler mnuRateVal1.Click, AddressOf mnuRateVal1_Click
            mnuRateVal2.Name = "mnuRateVal2?"
            mnuRateVal2.Size = New System.Drawing.Size(180, 22)
            mnuRateVal2.Text = "Ocena 2?"
            AddHandler mnuRateVal2.Click, AddressOf mnuRateVal2_Click
            mnuRateVal3.Name = "mnuRateVal3?"
            mnuRateVal3.Size = New System.Drawing.Size(180, 22)
            mnuRateVal3.Text = "Ocena 3?"
            AddHandler mnuRateVal3.Click, AddressOf mnuRateVal3_Click
            mnuRateVal4.Name = "mnuRateVal4?"
            mnuRateVal4.Size = New System.Drawing.Size(180, 22)
            mnuRateVal4.Text = "Ocena 4?"
            AddHandler mnuRateVal4.Click, AddressOf mnuRateVal4_Click
            mnuRateVal5.Name = "mnuRateVal5?"
            mnuRateVal5.Size = New System.Drawing.Size(180, 22)
            mnuRateVal5.Text = "Ocena 5 (odlicno)?"
            AddHandler mnuRateVal5.Click, AddressOf mnuRateVal5_Click
            toolStripSeparator5.Name = "toolStripSeparator5?"
            toolStripSeparator5.Size = New System.Drawing.Size(266, 6)
            mnuSearchAllMovieSubtitles.Name = "mnuSearchAllMovieSubtitles?"
            mnuSearchAllMovieSubtitles.Size = New System.Drawing.Size(269, 26)
            mnuSearchAllMovieSubtitles.Text = "Najdi vse podnapise za ta film?"
            AddHandler mnuSearchAllMovieSubtitles.Click, AddressOf mnuSearchAllMovieSubtitles_Click
            mnuSearchAllSubtitlesForThisPublisher.Name = "mnuSearchAllSubtitlesForThisPublisher?"
            mnuSearchAllSubtitlesForThisPublisher.Size = New System.Drawing.Size(269, 26)
            mnuSearchAllSubtitlesForThisPublisher.Text = "Najdi vse podnapise tega pošiljatelja?"
            AddHandler mnuSearchAllSubtitlesForThisPublisher.Click, AddressOf mnuSearchAllSubtitlesForThisPublisher_Click
            toolStripSeparator8.Name = "toolStripSeparator8?"
            toolStripSeparator8.Size = New System.Drawing.Size(266, 6)
            mnuIMDB.Image = Sublight.Properties.Resources.ToolbarIMDB
            mnuIMDB.Name = "mnuIMDB?"
            mnuIMDB.Size = New System.Drawing.Size(269, 26)
            mnuIMDB.Text = "IMDb?"
            AddHandler mnuIMDB.Click, AddressOf mnuIMDB_Click
            toolStripSeparator7.Name = "toolStripSeparator7?"
            toolStripSeparator7.Size = New System.Drawing.Size(266, 6)
            mnuSubtitlePreview.Image = Sublight.Properties.Resources.ToolbarSearch
            mnuSubtitlePreview.Name = "mnuSubtitlePreview?"
            mnuSubtitlePreview.Size = New System.Drawing.Size(269, 26)
            mnuSubtitlePreview.Text = "Predogled podnapisa?"
            AddHandler mnuSubtitlePreview.Click, AddressOf mnuSubtitlePreview_Click
            mnuNFO.Image = Sublight.Properties.Resources.ToolbarNFO
            mnuNFO.Name = "mnuNFO?"
            mnuNFO.Size = New System.Drawing.Size(269, 26)
            mnuNFO.Text = ".NFO?"
            AddHandler mnuNFO.Click, AddressOf mnuNFO_Click
            mnuProperties.Image = Sublight.Properties.Resources.ToolbarDetailsMedium
            mnuProperties.Name = "mnuProperties?"
            mnuProperties.Size = New System.Drawing.Size(269, 26)
            mnuProperties.Text = "Lastnosti?"
            AddHandler mnuProperties.Click, AddressOf mnuProperties_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(lvResults)
            Controls.Add(toolStrip2)
            Name = "PageView?"
            Size = New System.Drawing.Size(668, 294)
            toolStrip2.ResumeLayout(False)
            toolStrip2.PerformLayout()
            contextMenuStrip1.ResumeLayout(False)
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub lvSearchResults_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
            If DisplayImageTooltips Then
                itt.Hide()
            End If
        End Sub

        Private Sub lvSearchResults_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If DisplayImageTooltips Then
                itt.Show(e)
            End If
        End Sub

        Private Sub lvSearchResults_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If DisplayImageTooltips Then
                itt.Hide()
            End If
        End Sub

        Private Sub mnuAddRelease_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            Dim frmAddRelease1 As Sublight.FrmAddRelease = New Sublight.FrmAddRelease(subtitle1.SubtitleID)
            If (frmAddRelease1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) AndAlso frmAddRelease1.Status Then
                Dim data1 As Sublight.Controls.SuperListItem.Data = Sublight.Controls.BasePageResults.GetSelectedSubtitleData(lvResults)
                If Not (data1) Is Nothing Then
                    If (m_subtitlesWithoutReleaseInfo) Is Nothing Then
                        m_subtitlesWithoutReleaseInfo = New System.Collections.Generic.List(Of System.Guid)
                    End If
                    Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                    If Not m_subtitlesWithoutReleaseInfo.Contains(subtitle1.SubtitleID) AndAlso (Not (data1.Releases) Is Nothing) AndAlso (data1.Releases.Length > 0) Then
                        list1.AddRange(data1.Releases)
                    End If
                    list1.Add(Sublight.Controls.BasePageResults.ReleaseToString(frmAddRelease1.Release))
                    data1.Releases = list1.ToArray()
                    If m_subtitlesWithoutReleaseInfo.Contains(subtitle1.SubtitleID) Then
                        m_subtitlesWithoutReleaseInfo.Remove(subtitle1.SubtitleID)
                    End If
                    Sublight.Controls.BasePageResults.RebindSearchResults(lvResults, m_data)
                End If
            End If
            frmAddRelease1.Dispose()
        End Sub

        Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If ((subtitle1) Is Nothing) OrElse Not subtitle1.CanDelete Then
                Return
            End If
            If ParentBaseForm.ShowQuestion(Sublight.Translation.Common_Question_ConfirmSubtitleDeletion, New object(0) {}) = System.Windows.Forms.DialogResult.Yes Then
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    ParentBaseForm.ShowLoader(Me)
                    AddHandler sublight1.DeleteSubtitleCompleted, AddressOf ws_DeleteSubtitleCompleted
                    sublight1.DeleteSubtitleAsync(Sublight.BaseForm.Session, subtitle1.SubtitleID)
                End Using
            End If
        End Sub

        Private Sub mnuDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If btnDownload.Enabled Then
                btnDownload_Click(Me, Nothing)
            End If
        End Sub

        Private Sub mnuDownload_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Select Case Sublight.Properties.Settings.Default.View_DblClickAction
                Case Sublight.Types.SubtitleDblClickAction.DownloadSubtitle
                    If Not btnDownload.Enabled Then
                        GoTo label_0
                    End If
                    btnDownload_Click(Me, Nothing)
                    Return

                Case Sublight.Types.SubtitleDblClickAction.SubtitleDetails
                    If Sublight.Controls.BasePageResults.AreMultipleItemsSelected(lvResults) Then
                        GoTo label_0
                    End If
                    mnuProperties_Click(Me, Nothing)
            End Select
        End Sub

        Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Sublight.BaseForm.IsAnonymous Then
                Return
            End If
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            EditSubtitle(subtitle1)
        End Sub

        Private Sub mnuIMDB_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If mnuIMDB.Enabled Then
                btnIMDB_Click(Me, Nothing)
            End If
        End Sub

        Private Sub mnuNFO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            itt.Hide()
            Dim frmDetails2_1 As Sublight.FrmDetails2 = New Sublight.FrmDetails2(subtitle1, Sublight.FrmDetails2.FirstTab.NFO)
            frmDetails2_1.ShowDialog(Me)
            frmDetails2_1.Dispose()
        End Sub

        Private Sub mnuProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            itt.Hide()
            Dim frmDetails2_1 As Sublight.FrmDetails2 = New Sublight.FrmDetails2(subtitle1, Sublight.FrmDetails2.FirstTab.Details)
            frmDetails2_1.ShowDialog(Me)
            frmDetails2_1.Dispose()
        End Sub

        Private Sub mnuRateVal1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvResults, m_data, 1)
        End Sub

        Private Sub mnuRateVal2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvResults, m_data, 2)
        End Sub

        Private Sub mnuRateVal3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvResults, m_data, 3)
        End Sub

        Private Sub mnuRateVal4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvResults, m_data, 4)
        End Sub

        Private Sub mnuRateVal5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvResults, m_data, 5)
        End Sub

        Private Sub mnuReportSubtitle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            Dim frmSubtitleReport1 As Sublight.FrmSubtitleReport = New Sublight.FrmSubtitleReport(subtitle1.SubtitleID)
            frmSubtitleReport1.ShowDialog(Me)
            frmSubtitleReport1.Dispose()
        End Sub

        Private Sub mnuSearchAllMovieSubtitles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Sublight.Globals.MainForm.SwitchTab(Sublight.FrmMain.RibbonTab.Search)
            m_searchPage.PerformSearchByImdb(Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults))
        End Sub

        Private Sub mnuSearchAllSubtitlesForThisPublisher_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Sublight.Globals.MainForm.SwitchTab(Sublight.FrmMain.RibbonTab.Search)
            m_searchPage.PerformSearchByPublisher(Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults))
        End Sub

        Private Sub mnuSubtitlePreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            itt.Hide()
            Dim frmDetails2_1 As Sublight.FrmDetails2 = New Sublight.FrmDetails2(subtitle1, Sublight.FrmDetails2.FirstTab.Preview)
            frmDetails2_1.ShowDialog(Me)
            frmDetails2_1.Dispose()
        End Sub

        Private Sub OnResultsChanged()
            Dim flag1 As Boolean

            If (lvResults.SelectedItems) Is Nothing Then
                flag1 = False
            ElseIf lvResults.SelectedItems.Count <= 0 Then
                flag1 = False
            Else 
                flag1 = True
            End If
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
            If Not (subtitle1) Is Nothing Then
                btnIMDB.Enabled = True
                btnDownload.Enabled = flag1
                If Sublight.MyUtility.SubtitleUtil.IsNonImdbMovie(subtitle1) Then
                    mnuNFO.ShortcutKeys = System.Windows.Forms.Keys.None
                    Return
                End If
                mnuNFO.ShortcutKeys = System.Windows.Forms.Keys.RButton Or System.Windows.Forms.Keys.MButton Or System.Windows.Forms.Keys.Back Or System.Windows.Forms.Keys.Control
                Return
            End If
            btnIMDB.Enabled = False
            btnDownload.Enabled = flag1
        End Sub

        Private Sub ParentBaseForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If IsActiveTab AndAlso Not _btnStatistics.Pressed AndAlso (e.KeyCode = System.Windows.Forms.Keys.F5) Then
                btnRefresh_Click(Me, Nothing)
            End If
        End Sub

        Private Sub RefreshMatchesCount()
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            If IsActiveTab AndAlso (Not (m_tssl) Is Nothing) Then
                If (methodInvoker2) Is Nothing Then
                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<RefreshMatchesCount>b__11)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                Sublight.BaseForm.DoCtrlInvoke(m_tssl, Me, methodInvoker1)
            End If
        End Sub

        Private Sub SelectedItems_DataChanged(ByVal sender As Object, ByVal e As BinaryComponents.SuperList.SelectedItemsChangedEventArgs)
            OnResultsChanged()
        End Sub

        Private Sub SetDownloadButtonText()
            If Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.CustomFolder Then
                btnDownload.Text = Sublight.Translation.View_Toolbar_Download
                Return
            End If
            btnDownload.Text = Sublight.Translation.View_Toolbar_DownloadToCustomFolder
        End Sub

        Private Sub SetInfoLabel()
            If _btnNew.Pressed Then
                lblViewTitle.Text = Sublight.Translation.View_Label_NewSubtitles
                Return
            End If
            If _btnFavorite.Pressed Then
                lblViewTitle.Text = Sublight.Translation.View_Label_FavoriteSubtitles
                Return
            End If
            If _btnDownloaded.Pressed Then
                lblViewTitle.Text = Sublight.Translation.View_Label_DownloadedByMe
                Return
            End If
            If _btnPublished.Pressed Then
                lblViewTitle.Text = Sublight.Translation.View_Label_PublishedByMe
            End If
        End Sub

        Private Sub TranslateResults()
            lvResults.Translate()
            lvResults.Items.SynchroniseWithUINow()
            If lvResults.Columns.get_Count() > 0 Then
                lvResults.SizeColumnsToFit()
                Return
            End If
            lvResults.Refresh()
        End Sub

        Private Sub UncheckAll()
            _btnNew.Pressed = False
            _btnFavorite.Pressed = False
            _btnPublished.Pressed = False
            _btnDownloaded.Pressed = False
            _btnStatistics.Pressed = False
        End Sub

        Private Sub ws_DeleteSubtitleCompleted(ByVal sender As Object, ByVal e As Sublight.WS.DeleteSubtitleCompletedEventArgs)
            Try
                If Sublight.BaseForm.HandleWSErrors(ParentBaseForm, e) Then
                    Return
                End If
                Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvResults)
                If Not (subtitle1) Is Nothing Then
                    subtitle1.Status = 128
                End If
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Sub wsh_OnCompleted(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim flag1 As Boolean = btnRefresh.Enabled
            btnRefresh.Enabled = Not flag1
            btnRefresh.Enabled = flag1
        End Sub

        Private Sub wsh_OnException(ByVal ex As System.Exception)
            EnableAll(True)
            Dim objArr1 As Object() = New object() { ex.Message }
            ParentBaseForm.ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
        End Sub

        Private Sub wshDownloadedSubtitles_OnResult(ByVal result As Object())
            If ((result) Is Nothing) OrElse (result.Length < 2) Then
                Return
            End If
            BindSubtitles(CType(result(0), Sublight.WS.Subtitle[]), CType(result(1), Sublight.WS.Release[]))
        End Sub

        Private Sub wshFavoriteSubtitles_OnResult(ByVal result As Object())
            If ((result) Is Nothing) OrElse (result.Length < 2) Then
                Return
            End If
            BindSubtitles(CType(result(0), Sublight.WS.Subtitle[]), CType(result(1), Sublight.WS.Release[]))
        End Sub

        Private Sub wshNewSubtitles_OnResult(ByVal result As Object())
            If ((result) Is Nothing) OrElse (result.Length < 2) Then
                Return
            End If
            BindSubtitles(CType(result(0), Sublight.WS.Subtitle[]), CType(result(1), Sublight.WS.Release[]))
        End Sub

        Private Sub wshUploadedSubtitles_OnResult(ByVal result As Object())
            If ((result) Is Nothing) OrElse (result.Length < 2) Then
                Return
            End If
            BindSubtitles(CType(result(0), Sublight.WS.Subtitle[]), CType(result(1), Sublight.WS.Release[]))
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Sub OnDisplayed()
            MyBase.OnDisplayed()
            If Not m_Initialized Then
                m_Initialized = True
                btnClearMyDownloads.Visible = False
                EnableAll(False)
                btnNew_Click(Me, Nothing)
            End If
            RefreshMatchesCount()
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            lvResults.Translate()
        End Sub

        Private Shared Function wshDownloadedSubtitles_DoCall(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim s1 As String
            Dim releaseArr1 As Sublight.WS.Release()
            Dim subtitleActionsArr1 As Sublight.WS.SubtitleActions()
            Dim subtitleArr1 As Sublight.WS.Subtitle()

            If ws.GetMyDownloads(DirectCast(args(0), System.Guid), CType(args(1), System.Guid[]), out subtitleArr1, out releaseArr1, out subtitleActionsArr1, out s1) Then
                Dim objArr1 As Object() = New object() { _
                                                         subtitleArr1, _
                                                         releaseArr1, _
                                                         subtitleActionsArr1, _
                                                         s1 }
                result = objArr1
                Return True
            End If
            result = Nothing
            Return False
        End Function

        Private Shared Function wshFavoriteSubtitles_DoCall(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim s1 As String
            Dim releaseArr1 As Sublight.WS.Release()
            Dim subtitleActionsArr1 As Sublight.WS.SubtitleActions()
            Dim subtitleArr1 As Sublight.WS.Subtitle()

            If ws.GetFavoriteSubtitles(DirectCast(args(0), System.Guid), out subtitleArr1, out releaseArr1, out subtitleActionsArr1, out s1) Then
                Dim objArr1 As Object() = New object() { _
                                                         subtitleArr1, _
                                                         releaseArr1, _
                                                         subtitleActionsArr1, _
                                                         s1 }
                result = objArr1
                Return True
            End If
            result = Nothing
            Return False
        End Function

        Private Shared Function wshNewSubtitles_DoCall(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim s1 As String
            Dim releaseArr1 As Sublight.WS.Release()
            Dim subtitleActionsArr1 As Sublight.WS.SubtitleActions()
            Dim subtitleArr1 As Sublight.WS.Subtitle()

            If ws.GetNewSubtitles(DirectCast(args(0), System.Guid), out subtitleArr1, out releaseArr1, out subtitleActionsArr1, out s1) Then
                Dim objArr1 As Object() = New object() { _
                                                         subtitleArr1, _
                                                         releaseArr1, _
                                                         subtitleActionsArr1, _
                                                         s1 }
                result = objArr1
                Return True
            End If
            result = Nothing
            Return False
        End Function

        Private Shared Function wshUploadedSubtitles_DoCall(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim s1 As String
            Dim releaseArr1 As Sublight.WS.Release()
            Dim subtitleActionsArr1 As Sublight.WS.SubtitleActions()
            Dim subtitleArr1 As Sublight.WS.Subtitle()

            If ws.GetMyUploads(DirectCast(args(0), System.Guid), out subtitleArr1, out releaseArr1, out subtitleActionsArr1, out s1) Then
                Dim objArr1 As Object() = New object() { _
                                                         subtitleArr1, _
                                                         releaseArr1, _
                                                         subtitleActionsArr1, _
                                                         s1 }
                result = objArr1
                Return True
            End If
            result = Nothing
            Return False
        End Function

    End Class ' class PageView

End Namespace

