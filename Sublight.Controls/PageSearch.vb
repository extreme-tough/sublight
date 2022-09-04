Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Web
Imports System.Windows.Forms
Imports System.Xml
Imports BinaryComponents.SuperList
Imports BinaryComponents.SuperList.Sections
Imports BinaryComponents.WinFormsUtility.Drawing
Imports Elegant.Ui
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Plugins.SubtitleProvider.Types
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS
Imports Utility.Video

Namespace Sublight.Controls

    Friend Class PageSearch
        Inherits Sublight.Controls.BasePageResults

        Friend Enum VideoCodec
            AVC
            DivX
            Xvid
            WMV
            Unknown
        End Enum

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass10

            Public <>4__this As Sublight.Controls.PageSearch 
            Public bmp As System.Drawing.Bitmap 
            Public info As System.Collections.Generic.Dictionary(Of String,String) 

            Public Sub New()
            End Sub

            Public Sub <vid_Result>b__f()
                <>4__this.pbMovieInfo.Image = bmp
                If <>4__this.pbMovieInfo.Width < <>4__this.btnSearchLinkedOpenFile.Width Then
                    <>4__this.pbMovieInfo.Left = <>4__this.btnSearchLinkedOpenFile.Left + (<>4__this.btnSearchLinkedOpenFile.Width / 2) - (<>4__this.pbMovieInfo.Width / 2)
                Else 
                    <>4__this.pbMovieInfo.Left = <>4__this.btnSearchLinkedOpenFile.Left - ((<>4__this.pbMovieInfo.Width - <>4__this.btnSearchLinkedOpenFile.Width) / 2)
                End If
                <>4__this.pbMovieInfo.Visible = True
                <>4__this.pbMovieInfo.Tag = info
                <>4__this.pbMovieInfo.Cursor = System.Windows.Forms.Cursors.Hand
            End Sub

        End Class ' class <>c__DisplayClass10

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass13

            Public <>4__this As Sublight.Controls.PageSearch 
            Public frmSearchItems As Sublight.Controls.SuperListItem.Data() 

            Public Sub New()
            End Sub

            Public Sub <btnSearchLinked_Click>b__12()
                <>4__this.lvSearchResults.Items.Clear()
                <>4__this.m_data = frmSearchItems
                If Not (<>4__this.m_data) Is Nothing Then
                    <>4__this.lvSearchResults.Items.AddRange(<>4__this.m_data)
                End If
                <>4__this.lvSearchResults.Items.SynchroniseWithUINow()
                If <>4__this.lvSearchResults.Columns.get_Count() > 0 Then
                    <>4__this.lvSearchResults.SizeColumnsToFit()
                End If
            End Sub

        End Class ' class <>c__DisplayClass13

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass18

            Public waitWS As Boolean 

            Public Sub New()
            End Sub

        End Class ' class <>c__DisplayClass18

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass1a

            Public CS$<>8__locals19 As Sublight.Controls.PageSearch.<>c__DisplayClass18 
            Public error As String 
            Public getDetailsByHashStatus As Boolean 
            Public imdb As Sublight.WS.IMDB 

            Public Sub New()
            End Sub

            Public Sub <AutoFillTitle>b__17(ByVal sender As Object, ByVal e As Sublight.WS.GetDetailsByHashCompletedEventArgs)
                Try
                    imdb = e.imdbInfo
                    error = e.error
                    getDetailsByHashStatus = e.Result
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("Sublight.Controls.PageSearch.AutoFillTitle?", e1)
                Finally
                    CS$<>8__locals19.waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClass1a

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass1e

            Public <>4__this As Sublight.Controls.PageSearch 
            Public videoFile As String 

            Public Sub New()
            End Sub

            Public Sub <PageSearchDragDropWshDoCall>b__1c()
                <>4__this.PerformSearch(videoFile, True)
            End Sub

        End Class ' class <>c__DisplayClass1e

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass8

            Public <>4__this As Sublight.Controls.PageSearch 
            Public args As Object 

            Public Sub New()
            End Sub

            Public Sub <HideSearchInfoThread>b__7()
                If <>4__this.tcSearchInfo.Tag = args Then
                    <>4__this.HideSearchInfo()
                End If
            End Sub

        End Class ' class <>c__DisplayClass8

        Private Class SearchElement

            Private _episode As System.Nullable(Of Integer) 
            Private _season As System.Nullable(Of Integer) 
            Private _title As String 
            Private _year As System.Nullable(Of Integer) 

            Public ReadOnly Property Episode As System.Nullable(Of Integer)
                Get
                    Return _episode
                End Get
            End Property

            Public ReadOnly Property Season As System.Nullable(Of Integer)
                Get
                    Return _season
                End Get
            End Property

            Public ReadOnly Property Title As String
                Get
                    Return _title
                End Get
            End Property

            Public ReadOnly Property Year As System.Nullable(Of Integer)
                Get
                    Return _year
                End Get
            End Property

            Public Sub New(ByVal title As String, ByVal year As System.Nullable(Of Integer), ByVal season As System.Nullable(Of Byte), ByVal episode As System.Nullable(Of Integer))
                Dim nullable1 As System.Nullable(Of Integer)

                _title = title
                _year = year
                Dim nullable2 As System.Nullable(Of Byte) = season
                If Not nullable2.get_HasValue() Then
                    GoTo label_0
                End If
                nullable1 = New System.Nullable(Of Integer)[]
                nullable1._season = New System.Nullable(Of Integer)(nullable2.GetValueOrDefault())
                _episode = episode
            End Sub

            Public Function SerializeToString() As String
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                stringBuilder1.AppendFormat("{0};?", System.Web.HttpUtility.UrlEncode(Title))
                Dim nullable5 As System.Nullable(Of Integer) = Year
                If nullable5.get_HasValue() Then
                    Dim nullable6 As System.Nullable(Of Integer) = Year
                    Dim i1 As Integer = nullable6.get_Value()
                    stringBuilder1.AppendFormat("{0};?", System.Web.HttpUtility.UrlEncode(i1.ToString()))
                Else 
                    stringBuilder1.Append(";?")
                End If
                Dim nullable4 As System.Nullable(Of Integer) = Season
                If nullable4.get_HasValue() Then
                    Dim nullable1 As System.Nullable(Of Integer) = Season
                    Dim i2 As Integer = nullable1.get_Value()
                    stringBuilder1.AppendFormat("{0};?", System.Web.HttpUtility.UrlEncode(i2.ToString()))
                Else 
                    stringBuilder1.Append(";?")
                End If
                Dim nullable2 As System.Nullable(Of Integer) = Episode
                If nullable2.get_HasValue() Then
                    Dim nullable3 As System.Nullable(Of Integer) = Episode
                    Dim i3 As Integer = nullable3.get_Value()
                    stringBuilder1.AppendFormat("{0};?", System.Web.HttpUtility.UrlEncode(i3.ToString()))
                Else 
                    stringBuilder1.Append(";?")
                End If
                Return stringBuilder1.ToString()
            End Function

            Public Overrides Function ToString() As String
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                stringBuilder1.Append(Title)
                Dim nullable5 As System.Nullable(Of Integer) = Year
                If nullable5.get_HasValue() Then
                    Dim nullable6 As System.Nullable(Of Integer) = Year
                    stringBuilder1.AppendFormat(" ({0})?", nullable6.get_Value())
                End If
                Dim nullable4 As System.Nullable(Of Integer) = Season
                If nullable4.get_HasValue() Then
                    Dim nullable1 As System.Nullable(Of Integer) = Episode
                    If nullable1.get_HasValue() Then
                        Dim nullable2 As System.Nullable(Of Integer) = Season
                        Dim nullable3 As System.Nullable(Of Integer) = Episode
                        stringBuilder1.AppendFormat(", S{0:00}E{1:00}?", nullable2.get_Value(), nullable3.get_Value())
                    End If
                End If
                Return stringBuilder1.ToString()
            End Function

            Public Shared Function DeserializeFromString(ByVal serializedElement As String) As Sublight.Controls.PageSearch.SearchElement
                Dim nullable1 As System.Nullable(Of Integer)
                Dim nullable2 As System.Nullable(Of Integer)
                Dim nullable3 As System.Nullable(Of Byte)
                Dim searchElement1 As Sublight.Controls.PageSearch.SearchElement

                If System.String.IsNullOrEmpty(serializedElement) Then
                    Return Nothing
                End If
                Try
                    Dim chArr1 As Char() = New char() { ";"C }
                    Dim sArr1 As String() = serializedElement.Split(chArr1)
                    If ((sArr1) Is Nothing) OrElse (sArr1.Length < 4) Then
                        Return Nothing
                    End If
                    Dim s1 As String = System.Web.HttpUtility.UrlDecode(sArr1(0))
                    nullable2 = New System.Nullable(Of Integer)[]
                    If Not System.String.IsNullOrEmpty(sArr1(1)) Then
                        nullable2 = New System.Nullable(Of Integer)(System.Int32.Parse(System.Web.HttpUtility.UrlDecode(sArr1(1))))
                    End If
                    nullable3 = New System.Nullable(Of Byte)[]
                    If Not System.String.IsNullOrEmpty(sArr1(2)) Then
                        nullable3 = New System.Nullable(Of Byte)(System.Byte.Parse(System.Web.HttpUtility.UrlDecode(sArr1(2))))
                    End If
                    nullable1 = New System.Nullable(Of Integer)[]
                    If Not System.String.IsNullOrEmpty(sArr1(3)) Then
                        nullable1 = New System.Nullable(Of Integer)(System.Int32.Parse(System.Web.HttpUtility.UrlDecode(sArr1(3))))
                    End If
                    searchElement1 = New Sublight.Controls.PageSearch.SearchElement(s1, nullable2, nullable3, nullable1)
                Catch 
                    searchElement1 = Nothing
                End Try
                Return searchElement1
            End Function

        End Class ' class SearchElement

        Friend Const SEASON_EPISODE_PATTERN_1 As String  = "\b(?<season>[0-9]*?)[xX]{1,1}(?<episode>[0-9]*?)\b"
        Friend Const SEASON_EPISODE_PATTERN_2 As String  = "\b[sS]{1,1}(?<season>[0-9]*?)[eE]{1,1}(?<episode>[0-9]*?)\b"

        Private ReadOnly m_pagePublish As Sublight.Controls.PagePublish 
        Private ReadOnly m_tssl As Elegant.Ui.Control 
        Private ReadOnly openFileDialog As System.Windows.Forms.OpenFileDialog 
        Private ReadOnly parent As Sublight.BaseForm 

        Private _btnClear As Elegant.Ui.Button 
        Private _btnLinkAdd As Elegant.Ui.Button 
        Private _btnLinkInvalid As Elegant.Ui.Button 
        Private _btnLinkValid As Elegant.Ui.Button 
        Private _btnPlay As Elegant.Ui.Button 
        Private _btnRate As Elegant.Ui.DropDown 
        Private _btnReport As Elegant.Ui.Button 
        Private _btnSearchDownload As Elegant.Ui.Button 
        Private _btnSearchFilter As Elegant.Ui.ToggleButton 
        Private _btnSearchSync As Elegant.Ui.Button 
        Private _doFeelingLuckySearch As Boolean 
        Private _imdbEnabled As Boolean 
        Private _lineBottom As System.Drawing.Pen 
        Private _txtTitleAutoFocus As Boolean 
        Private _txtTitleCtrl As Boolean 
        Private btnFeelingLucky As Sublight.Controls.Button.Button 
        Private btnLanguage As Sublight.Controls.Button.Button 
        Private btnRate As Sublight.Controls.Button.Button 
        Private btnSearchLinked As Sublight.Controls.Button.Button 
        Private btnSearchLinkedOpenFile As Sublight.Controls.Button.Button 
        Private btnSuggest As Sublight.Controls.Button.Button 
        Private btnTitleNOK As Sublight.Controls.Button.Button 
        Private btnTitleOK As Sublight.Controls.Button.Button 
        Private cbAutoFillTitle As Sublight.Controls.MyCheckBox 
        Private cmsFilterGenre As System.Windows.Forms.ContextMenuStrip 
        Private cmsFilterLanguage As System.Windows.Forms.ContextMenuStrip 
        Private cmsRate As System.Windows.Forms.ContextMenuStrip 
        Private cmsRibbonRate As System.Windows.Forms.ContextMenuStrip 
        Private cmsSuggestTitle As System.Windows.Forms.ContextMenuStrip 
        Private components As System.ComponentModel.IContainer 
        Private contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip 
        Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog 
        Private groupBox1 As Sublight.Controls.MyGroupBox 
        Private groupBox2 As Sublight.Controls.MyGroupBox 
        Private groupBox3 As Sublight.Controls.MyGroupBox 
        Private itt As Sublight.Controls.ImageToolTip 
        Private label1 As System.Windows.Forms.Label 
        Private label10 As System.Windows.Forms.Label 
        Private label11 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private label3 As System.Windows.Forms.Label 
        Private label4 As Sublight.Controls.LegendLabel 
        Private label5 As System.Windows.Forms.Label 
        Private label6 As Sublight.Controls.LegendLabel 
        Private label8 As System.Windows.Forms.Label 
        Private lblDetectedTitle As System.Windows.Forms.Label 
        Private lblEpisode As System.Windows.Forms.Label 
        Private lblSeason As System.Windows.Forms.Label 
        Private lblSubtitleLinked As System.Windows.Forms.Label 
        Private lblSubtitleUnlinked As System.Windows.Forms.Label 
        Private lblTipSuggest As System.Windows.Forms.Label 
        Private lvSearchResults As Sublight.Controls.MySuperList 
        Private m_data As Sublight.Controls.SuperListItem.Data() 
        Private m_shiftPressed As Boolean 
        Private m_subtitlesWithoutReleaseInfo As System.Collections.Generic.List(Of System.Guid) 
        Private m_ttHelpUsLink As Sublight.FrmBalloon 
        Private mnuAddAlternativeTitle As System.Windows.Forms.ToolStripMenuItem 
        Private mnuAddLink As System.Windows.Forms.ToolStripMenuItem 
        Private mnuAddRelease As System.Windows.Forms.ToolStripMenuItem 
        Private mnuDelete As System.Windows.Forms.ToolStripMenuItem 
        Private mnuDownload As System.Windows.Forms.ToolStripMenuItem 
        Private mnuEdit As System.Windows.Forms.ToolStripMenuItem 
        Private mnuIMDB As System.Windows.Forms.ToolStripMenuItem 
        Private mnuImportSubtitle As System.Windows.Forms.ToolStripMenuItem 
        Private mnuInvalidLink As System.Windows.Forms.ToolStripMenuItem 
        Private mnuNFO As System.Windows.Forms.ToolStripMenuItem 
        Private mnuPlay As System.Windows.Forms.ToolStripMenuItem 
        Private mnuPluginInfo As System.Windows.Forms.ToolStripMenuItem 
        Private mnuPluginSubtitleActions As System.Windows.Forms.ToolStripMenuItem 
        Private mnuPrimarySubDbInfo As System.Windows.Forms.ToolStripMenuItem 
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
        Private mnuValidLink As System.Windows.Forms.ToolStripMenuItem 
        Private panel1 As Sublight.Controls.MyPanel 
        Private panel2 As Sublight.Controls.MyPanel 
        Private panel4 As Sublight.Controls.Panel 
        Private panelSearchCriteriaSearchFilterSeparator As Sublight.Controls.MyPanel 
        Private panelSearchTop As Sublight.Controls.Panel 
        Private panelSearchTopCriteria As Sublight.Controls.Panel 
        Private pbMovieInfo As System.Windows.Forms.PictureBox 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private pictureBox2 As System.Windows.Forms.PictureBox 
        Private pictureBox3 As System.Windows.Forms.PictureBox 
        Private tcSearchInfo As Sublight.Controls.TipCtrl 
        Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator 
        Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator 
        Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator 
        Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator 
        Private toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator 
        Private ttSearchByHash As Sublight.Controls.ToolTip 
        Private ttSearchManual As Sublight.Controls.ToolTip 
        Private ttSearchResultsFilter As Sublight.Controls.ToolTip 
        Private ttTitleNOK As System.Windows.Forms.ToolTip 
        Private ttTitleOK As System.Windows.Forms.ToolTip 
        Private txtDetectedTitle As Sublight.Controls.MyTextBox 
        Private txtEpisode As Sublight.Controls.MyTextBox 
        Private txtFilterMediaCount As Sublight.Controls.MyTextBox 
        Private txtFilterSender As Sublight.Controls.MyTextBox 
        Private txtSearchLinkedFile As Sublight.Controls.PromptedTextBox 
        Private txtSeason As Sublight.Controls.MyTextBox 
        Private txtTitle As Sublight.Controls.PromptedTextBox 
        Private txtYear As Sublight.Controls.MyTextBox 

        Private Shared m_loginToken As String 

        Friend ReadOnly Property SelectedImdb As String
            Get
                Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
                If (subtitle1) Is Nothing Then
                    Return Nothing
                End If
                If Sublight.MyUtility.SubtitleUtil.IsNonImdbMovie(subtitle1) Then
                    Return Nothing
                End If
                Return subtitle1.IMDB
            End Get
        End Property

        Friend ReadOnly Property SelectedVideo As String
            Get
                Return txtSearchLinkedFile.Text
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal openFileDialog As System.Windows.Forms.OpenFileDialog, ByVal saveFileDialog As System.Windows.Forms.SaveFileDialog, ByVal tssl As Elegant.Ui.Control, ByVal rtp As Elegant.Ui.RibbonTabPage, ByVal pagePublish As Sublight.Controls.PagePublish)
            _lineBottom = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#CFDBEB?"))
            InitializeComponent()
            If Sublight.Controls.Button.Button.ThemedRendering Then
                btnTitleOK.Padding = New System.Windows.Forms.Padding(0)
                btnTitleNOK.Padding = New System.Windows.Forms.Padding(0)
            End If
            If (Not (Sublight.Globals.MainForm) Is Nothing) AndAlso Not Sublight.Globals.MainForm.IsDisposed Then
                Sublight.Globals.MainForm.AcceptButton = btnSearchLinked
            End If
            HideSearchInfo()
            txtSearchLinkedFile.Margin = New System.Windows.Forms.Padding(0, 0, 20, 0)
            m_pagePublish = pagePublish
            panelSearchTop.BackColor = Sublight.Globals.ColorBackgroundLight1
            panel1.BackColor = Sublight.Globals.ColorBackgroundLight1
            AddHandler panelSearchTop.Paint, AddressOf panelSearchTop_Paint
            Dim sectionFactory1 As BinaryComponents.SuperList.Sections.SectionFactory = New BinaryComponents.SuperList.Sections.SectionFactory
            lvSearchResults.SectionFactory = sectionFactory1
            m_tssl = tssl
            _btnSearchFilter = TryCast(GetTabControlByName("btnSearchFilter?"), Elegant.Ui.ToggleButton)
            If (_btnSearchFilter) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchFilter?")
            End If
            _btnClear = TryCast(GetTabControlByName("btnSearchClear?"), Elegant.Ui.Button)
            If (_btnClear) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchClear?")
            End If
            _btnSearchDownload = TryCast(GetTabControlByName("btnSearchDownload?"), Elegant.Ui.Button)
            If (_btnSearchDownload) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchDownload?")
            End If
            _btnPlay = TryCast(GetTabControlByName("btnSearchPlay?"), Elegant.Ui.Button)
            If (_btnPlay) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchPlay?")
            End If
            _btnReport = TryCast(GetTabControlByName("btnSearchReport?"), Elegant.Ui.Button)
            If (_btnReport) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchReport?")
            End If
            _btnLinkAdd = TryCast(GetTabControlByName("btnSearchAddLink?"), Elegant.Ui.Button)
            If (_btnLinkAdd) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchAddLink?")
            End If
            _btnLinkValid = TryCast(GetTabControlByName("btnSearchValidLink?"), Elegant.Ui.Button)
            If (_btnLinkValid) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchValidLink?")
            End If
            _btnLinkInvalid = TryCast(GetTabControlByName("btnSearchInvalidLink?"), Elegant.Ui.Button)
            If (_btnLinkInvalid) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchInvalidLink?")
            End If
            _btnRate = TryCast(GetTabControlByName("btnSearchRate?"), Elegant.Ui.DropDown)
            If (_btnRate) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchRate?")
            End If
            _btnSearchSync = TryCast(GetTabControlByName("btnSearchSync?"), Elegant.Ui.Button)
            If (_btnSearchSync) Is Nothing Then
                Throw New System.NullReferenceException("btnSearchSync?")
            End If
            FillDropDownRate()
            Me.openFileDialog = openFileDialog
            Me.parent = parent
            _btnSearchFilter.Pressed = Sublight.Properties.Settings.Default.Search_ShowFilter
            AddHandler _btnSearchFilter.Click, AddressOf btnShowFilter_Click
            AddHandler _btnClear.Click, AddressOf btnClear_Click
            AddHandler _btnSearchDownload.Click, AddressOf toolStripSearchLinkedDownload_Click
            AddHandler _btnPlay.Click, AddressOf btnPlay_Click
            AddHandler _btnReport.Click, AddressOf btnReportSubtitle_Click
            AddHandler _btnLinkAdd.Click, AddressOf toolStripSearchLinkedAddLink_Click
            AddHandler _btnLinkValid.Click, AddressOf toolStripSearchLinkedAddLink_Click
            AddHandler _btnLinkInvalid.Click, AddressOf toolStripSearchLinkedReportLink_Click
            AddHandler _btnSearchSync.Click, AddressOf _btnSearchSync_Click
            ShowHideFilter()
            AddHandler Sublight.Globals.Events.SettingsLoaded, AddressOf Events_SettingsLoaded
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            AddHandler Sublight.Globals.Events.UserLogIn, AddressOf Events_UserLogIn
            lblSubtitleLinked.BackColor = Sublight.Globals.ColorSubtitleLinkedBg
            AddHandler lblSubtitleLinked.Paint, AddressOf lblSubtitleLinked_Paint
            lblSubtitleUnlinked.BackColor = Sublight.Globals.ColorSubtitleUnlinkedBg
            AddHandler lblSubtitleUnlinked.Paint, AddressOf lblSubtitleUnlinked_Paint
            AddHandler lvSearchResults.SelectedItems.DataChanged, AddressOf SelectedItems_DataChanged
            AddHandler lvSearchResults.DoubleClick, AddressOf lvSearchResults_DoubleClick
            cbAutoFillTitle.Checked = Sublight.Properties.Settings.Default.Search_AutoFillTitle
            AddHandler cbAutoFillTitle.CheckedChanged, AddressOf cbAutoFillTitle_CheckedChanged
            AddHandler txtEpisode.KeyDown, AddressOf txtEpisode_KeyDown
            AddHandler txtSeason.KeyDown, AddressOf txtSeason_KeyDown
            AddHandler txtYear.KeyDown, AddressOf txtYear_KeyDown
            AddHandler txtTitle.KeyDown, AddressOf txtTitle_KeyDown
            AddHandler txtTitle.KeyUp, AddressOf txtTitle_KeyUp
            AddHandler txtTitle.LostFocus, AddressOf txtTitle_LostFocus
            AddHandler txtFilterSender.KeyDown, AddressOf txtFilterSender_KeyDown
            AddHandler txtFilterMediaCount.KeyDown, AddressOf txtFilterMediaCount_KeyDown
            AddHandler btnSearchLinkedOpenFile.Click, AddressOf btnSearchLinkedOpenFile_Click
            AddHandler txtSearchLinkedFile.TextChanged, AddressOf txtSearchLinkedFile_TextChanged
            AddHandler txtSearchLinkedFile.KeyDown, AddressOf txtSearchLinkedFile_KeyDown
            FillFilterByRate()
            EnableDisableDetectedTitleButtons(False)
            itt = New Sublight.Controls.ImageToolTip(lvSearchResults)
            AddHandler lvSearchResults.MouseMove, AddressOf lvSearchResults_MouseMove
            AddHandler lvSearchResults.MouseLeave, AddressOf lvSearchResults_MouseLeave
            AddHandler lvSearchResults.MouseWheel, AddressOf lvSearchResults_MouseWheel
            mnuProperties.ShowShortcutKeys = True
            mnuProperties.ShortcutKeys = System.Windows.Forms.Keys.F4
            mnuNFO.ShowShortcutKeys = True
            mnuNFO.ShortcutKeys = System.Windows.Forms.Keys.RButton Or System.Windows.Forms.Keys.MButton Or System.Windows.Forms.Keys.Back Or System.Windows.Forms.Keys.Control
            mnuEdit.ShowShortcutKeys = True
            mnuEdit.ShortcutKeys = System.Windows.Forms.Keys.LButton Or System.Windows.Forms.Keys.MButton Or System.Windows.Forms.Keys.Control
            mnuSubtitlePreview.ShowShortcutKeys = True
            mnuSubtitlePreview.ShortcutKeys = System.Windows.Forms.Keys.F6
            AddHandler ParentBaseForm.KeyDown, AddressOf ParentBaseForm_KeyDown
            AddHandler ParentBaseForm.KeyUp, AddressOf ParentBaseForm_KeyUp
            mnuDelete.ShowShortcutKeys = True
            mnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
            If Sublight.Properties.Settings.Default.AskToLinkFile2 Then
                AddHandler parent.Move, AddressOf parent_Move
                AddHandler Sublight.Globals.Events.TabChanged, AddressOf Events_TabChanged
            End If
            AddHandler pbMovieInfo.Click, AddressOf pbMovieInfo_Click
            btnSearchLinked.AutoResize = True
            btnFeelingLucky.AutoResize = True
            AddHandler rtp.Paint, AddressOf rtp_Paint
        End Sub

        Private Sub _btnSearchSync_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Sublight.BaseForm.IsAnonymous Then
                ParentBaseForm.ShowInfo(Sublight.Translation.Common_Info_YouMustLogInToUseThisFeature, New object(0) {})
                Return
            End If
            If System.String.IsNullOrEmpty(txtSearchLinkedFile.Text) Then
                ParentBaseForm.ShowInfo(Sublight.Translation.Search_Info_VideoFileMustBeSelectedBeforePlay, New object(0) {})
                Return
            End If
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            Using frmSync1 As Sublight.FrmSync = New Sublight.FrmSync(Me, lvSearchResults, subtitle1, subtitle1.SubtitleID)
                frmSync1.ShowDialog(Me)
            End Using
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <RefreshMatchesCount>b__15()
            m_tssl.Text = System.String.Format(Sublight.Translation.Search_Status_NumberOfHits, lvSearchResults.Items.Count)
            If Not m_tssl.Visible Then
                m_tssl.Visible = True
            End If
        End Sub

        Private Function AreFiltersSet() As Boolean
            Dim flag1 As Boolean

            Dim i1 As Integer = 0
            Dim i2 As Integer = 0
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem1 In cmsFilterLanguage.Items
                If TypeOf toolStripMenuItem1.Tag Is Sublight.WS.SubtitleLanguage Then
                    i2 = i2 + 1
                End If
                If toolStripMenuItem1.Checked Then
                    i1 = i1 + 1
                End If
            Next
            If i1 <= 0 Then
                Return True
            End If
            If i1 < i2 Then
                Return True
            End If
            Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem2 In cmsRate.Items
                If toolStripMenuItem2.Checked Then
                    Dim i3 As Integer = DirectCast(toolStripMenuItem2.Tag, int)
                    If i3 >= 0 Then
                        Return True
                    End If
                End If
            Next
            If Not System.String.IsNullOrEmpty(txtFilterSender.Text) Then
                Return True
            End If
            If Not System.String.IsNullOrEmpty(txtFilterMediaCount.Text) Then
                Return True
            End If
            Return False
        End Function

        Private Sub AutoFillTitle(ByVal waitForTitleAutoCompletion As Boolean)
            txtDetectedTitle.Text = System.String.Empty
            If System.String.IsNullOrEmpty(txtSearchLinkedFile.Text) Then
                Return
            End If
            Dim flag1 As Boolean = False
            Try
                If Not System.IO.File.Exists(txtSearchLinkedFile.Text) Then
                    Return
                End If
                flag1 = True
            Catch e As System.Exception
                flag1 = False
                Return
            Finally
                EnableDisableDetectedTitleButtons(flag1)
            End Try
            ParentBaseForm.ShowLoader(Me)
            If cbAutoFillTitle.Checked Then
                ClearManualSearchFields()
            End If
            Dim s1 As String = Utility.Video.Checksum.Compute(txtSearchLinkedFile.Text)
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                If waitForTitleAutoCompletion Then
                    Dim <>c__DisplayClass18_1 As Sublight.Controls.PageSearch.<>c__DisplayClass18 = New Sublight.Controls.PageSearch.<>c__DisplayClass18
                    <>c__DisplayClass18_1.waitWS = True
                    Try
                        Dim <>c__DisplayClass1a1 As Sublight.Controls.PageSearch.<>c__DisplayClass1a = New Sublight.Controls.PageSearch.<>c__DisplayClass1a
                        <>c__DisplayClass1a1.CS$<>8__locals19 = <>c__DisplayClass18_1
                        <>c__DisplayClass1a1.imdb = Nothing
                        <>c__DisplayClass1a1.getDetailsByHashStatus = False
                        AddHandler sublight1.GetDetailsByHashCompleted, AddressOf <>c__DisplayClass1a1.<AutoFillTitle>b__17
                        sublight1.GetDetailsByHashAsync(Sublight.BaseForm.Session, s1)
                        While <>c__DisplayClass18_1.waitWS
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(50)
                        End While
                        If <>c__DisplayClass1a1.getDetailsByHashStatus AndAlso (Not (<>c__DisplayClass1a1.imdb) Is Nothing) Then
                            FillByImdb(<>c__DisplayClass1a1.imdb)
                        Else 
                            ClearAndDisableDetectedTitle()
                            FillByHeurestics()
                        End If
                    Catch 
                    Finally
                        ParentBaseForm.HideLoader(Me)
                    End Try
                End If
                AddHandler sublight1.GetDetailsByHashCompleted, AddressOf ws_GetDetailsByHashCompleted
                sublight1.GetDetailsByHashAsync(Sublight.BaseForm.Session, s1)
            label_1: _
            End Using
        End Sub

        Private Sub AutoFillTitle()
            AutoFillTitle(False)
        End Sub

        Private Sub BindRecentUnsuccessfulSearches()
            Dim flag1 As Boolean = False
            Dim s1 As String = Sublight.Properties.Settings.Default.Search_RecentUnsuccessfulSearches
            If Not System.String.IsNullOrEmpty(s1) Then
                Try
                    Dim chArr1 As Char() = New char() { "&"C }
                    Dim sArr1 As String() = s1.Split(chArr1)
                    If Not (sArr1) Is Nothing Then
                        Dim i1 As Integer = sArr1.Length - 1
                        While i1 >= 0
                            Dim s2 As String = sArr1(i1)
                            Dim searchElement1 As Sublight.Controls.PageSearch.SearchElement = Sublight.Controls.PageSearch.SearchElement.DeserializeFromString(s2)
                            If Not (searchElement1) Is Nothing Then
                                If Not flag1 Then
                                    flag1 = True
                                    cmsSuggestTitle.Items.Add(New Sublight.Controls.ToolStripSeparatorCaption(Sublight.Translation.Search_Context_RecentUnsuccessfulSearches))
                                End If
                                Dim myToolStripMenuItem1 As Sublight.Controls.MyToolStripMenuItem = New Sublight.Controls.MyToolStripMenuItem(searchElement1.ToString().Replace("&?", "&&?"))
                                myToolStripMenuItem1.Tag = searchElement1
                                myToolStripMenuItem1.ShortcutKeyDisplayString = "ENTER?"
                                AddHandler myToolStripMenuItem1.Click, AddressOf tsiUnsuccessfulSearchElement_Click
                                cmsSuggestTitle.Items.Add(myToolStripMenuItem1)
                            End If
                            i1 = i1 - 1
                        End While
                    End If
                Catch 
                End Try
            End If
            If flag1 Then
                Dim toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator
                cmsSuggestTitle.Items.Add(toolStripSeparator1)
                Dim toolStripItem1 As System.Windows.Forms.ToolStripItem = New Sublight.Controls.MyToolStripMenuItem(Sublight.Translation.Search_Context_ClearItems)
                AddHandler toolStripItem1.Click, AddressOf tsiClearRecentItems_Click
                cmsSuggestTitle.Items.Add(toolStripItem1)
            End If
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            txtDetectedTitle.Text = System.String.Empty
            txtSearchLinkedFile.Text = System.String.Empty
            ClearManualSearchFields()
            txtFilterSender.Text = System.String.Empty
            txtFilterMediaCount.Text = System.String.Empty
            _btnLinkAdd.Enabled = False
            _btnLinkInvalid.Enabled = False
            _btnLinkValid.Enabled = False
            _btnSearchDownload.Enabled = False
            _btnPlay.Enabled = False
            _btnReport.Enabled = False
            _btnRate.Enabled = False
            _btnSearchSync.Enabled = False
            btnFeelingLucky.Visible = False
            HideMovieInfo()
            Using ienumerator3 As System.Collections.Generic.IEnumerator(Of BinaryComponents.SuperList.Column) = lvSearchResults.Columns.GetEnumerator()
                While ienumerator3.MoveNext()
                    Dim column1 As BinaryComponents.SuperList.Column = ienumerator3.get_Current()
                    column1.SortOrder = System.Windows.Forms.SortOrder.None
                End While
            End Using
            HideSearchInfo()
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem1 In cmsRate.Items
                toolStripMenuItem1.Checked = False
            Next
            Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem2 In cmsRate.Items
                If DirectCast(toolStripMenuItem2.Tag, int) = -1 Then
                    toolStripMenuItem2.Checked = True
                    Exit While
                End If
            Next
            SetFilterByRateText()
            lvSearchResults.Items.Clear()
            lvSearchResults.Items.SynchroniseWithUINow()
            If lvSearchResults.Columns.get_Count() > 0 Then
                lvSearchResults.SizeColumnsToFit()
            End If
            SelectedItems_DataChanged(Me, Nothing)
            RefreshMatchesCount()
            If Not (itt) Is Nothing Then
                itt.Hide()
            End If
        End Sub

        Private Sub btnFeelingLucky_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If _doFeelingLuckySearch Then
                btnSearchLinked_Click(Me, Nothing)
            End If
            _doFeelingLuckySearch = True
            If lvSearchResults.Items.Count <= 0 Then
                Return
            End If
            lvSearchResults.SelectedItems.Add(lvSearchResults.Items(0))
            btnPlay_Click(Me, Nothing)
        End Sub

        Private Sub btnIMDB_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            ParentBaseForm.OpenInBrowser(subtitle1.IMDB)
        End Sub

        Private Sub btnLanguage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            cmsFilterLanguage.Show(btnLanguage, 0, btnLanguage.Height + 1)
        End Sub

        Private Sub btnPlay_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If ((lvSearchResults.SelectedItems) Is Nothing) OrElse (lvSearchResults.SelectedItems.Count <> 1) Then
                ParentBaseForm.ShowError(Sublight.Translation.Search_Error_SubtitleNotSelected, New object(0) {})
                Return
            End If
            If System.String.IsNullOrEmpty(txtSearchLinkedFile.Text) Then
                ParentBaseForm.ShowInfo(Sublight.Translation.Search_Info_VideoFileMustBeSelectedBeforePlay, New object(0) {})
                Return
            End If
            If Not System.IO.File.Exists(txtSearchLinkedFile.Text) Then
                ParentBaseForm.ShowWarning(Sublight.Translation.Search_Warning_VideoPathNotValid, New object(0) {})
                Return
            End If
            If Not Sublight.MyUtility.VideoApp.IsSet Then
                ParentBaseForm.ShowInfo(Sublight.Translation.Search_Info_VideoAppNotSet, New object(0) {})
                Return
            End If
            OnDownload(lvSearchResults, folderBrowserDialog1, txtSearchLinkedFile.Text, True)
        End Sub

        Private Sub btnRate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            cmsRate.Show(btnRate, 0, btnRate.Height + 1)
        End Sub

        Private Sub btnReportSubtitle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            Dim frmSubtitleReport1 As Sublight.FrmSubtitleReport = New Sublight.FrmSubtitleReport(subtitle1.SubtitleID)
            frmSubtitleReport1.ShowDialog(Me)
            frmSubtitleReport1.Dispose()
        End Sub

        Private Sub btnRibbonRate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim button1 As Elegant.Ui.Button = TryCast(sender, Elegant.Ui.Button)
            If (button1) Is Nothing Then
                Return
            End If
            If RateSubtitle(lvSearchResults, m_data, DirectCast(button1.Tag, int)) Then
                _btnRate.Enabled = False
            End If
        End Sub

        Private Sub btnSearchLinked_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i1 As Integer
            Dim nullable1 As System.Nullable(Of Integer)
            Dim nullable2 As System.Nullable(Of Byte)
            Dim nullable3 As System.Nullable(Of Integer)
            Dim nullable4 As System.Nullable(Of Single)
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage()

            Dim <>c__DisplayClass13_1 As Sublight.Controls.PageSearch.<>c__DisplayClass13 = New Sublight.Controls.PageSearch.<>c__DisplayClass13
            <>c__DisplayClass13_1.<>4__this = Me
            OnAutoDeleteHandler()
            _btnSearchDownload.Enabled = False
            _imdbEnabled = False
            _btnLinkInvalid.Enabled = False
            _btnLinkAdd.Enabled = False
            _btnLinkValid.Enabled = False
            _btnPlay.Enabled = False
            _btnReport.Enabled = False
            _btnRate.Enabled = False
            _btnSearchSync.Enabled = False
            If System.String.IsNullOrEmpty(txtSearchLinkedFile.Text) AndAlso System.String.IsNullOrEmpty(txtTitle.Text) Then
                parent.ShowWarning(Sublight.Translation.Search_Warning_NoSearchCriteria, New object(0) {})
                Return
            End If
            If _btnSearchFilter.Pressed Then
                Dim flag1 As Boolean = False
                Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem 
                For Each toolStripMenuItem1 In cmsFilterLanguage.Items
                    If toolStripMenuItem1.Checked Then
                        flag1 = True
                        Exit While
                    End If
                Next
                If Not flag1 Then
                    parent.ShowWarning(Sublight.Translation.Search_Warning_NoLanguageSelected, New object(0) {})
                    Return
                End If
            End If
            Dim s1 As String = Nothing
            If Not System.String.IsNullOrEmpty(txtSearchLinkedFile.Text) Then
                If Not System.IO.File.Exists(txtSearchLinkedFile.Text) Then
                    parent.ShowWarning(Sublight.Translation.Search_Warning_VideoPathNotValid, New object(0) {})
                    Return
                End If
                s1 = Utility.Video.Checksum.Compute(txtSearchLinkedFile.Text)
                If System.String.IsNullOrEmpty(s1) Then
                    parent.ShowError(Sublight.Translation.Search_Error_VideoHashCalculation, New object(0) {})
                    Return
                End If
                Dim s2 As String = Sublight.BaseForm.GetSetting("HashTranslator?")
                If Not (s2) Is Nothing Then
                    Dim version1 As System.Version = New System.Version(s2)
                    Dim version2 As System.Version = New System.Version(Sublight.BaseForm.AppVersion)
                    If version2 >= version1 Then
                        Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ParameterizedThreadStart(Sublight.Controls.PageSearch.HashThread))
                        Dim objArr1 As Object() = New object() { _
                                                                 txtSearchLinkedFile.Text, _
                                                                 s1 }
                        thread1.Start(objArr1)
                    End If
                End If
            End If
            nullable2 = New System.Nullable(Of Byte)[]
            nullable1 = New System.Nullable(Of Integer)[]
            nullable3 = New System.Nullable(Of Integer)[]
            If Not System.String.IsNullOrEmpty(txtTitle.Text) Then
                If Not System.String.IsNullOrEmpty(txtSeason.Text) Then
                    Try
                        nullable2 = New System.Nullable(Of Byte)(System.Byte.Parse(txtSeason.Text))
                    Catch 
                        Dim objArr2 As Object() = New object() { Sublight.Translation.Search_Field_Season }
                        ParentBaseForm.ShowError(Sublight.Translation.Common_Error_InputValueIsNotValid, objArr2)
                        GoTo label_1
                    End Try
                End If
                If Not System.String.IsNullOrEmpty(txtEpisode.Text) Then
                    Try
                        nullable1 = New System.Nullable(Of Integer)(System.Int32.Parse(txtEpisode.Text))
                    Catch 
                        Dim objArr3 As Object() = New object() { Sublight.Translation.Search_Field_Episode }
                        ParentBaseForm.ShowError(Sublight.Translation.Common_Error_InputValueIsNotValid, objArr3)
                        GoTo label_1
                    End Try
                End If
                Try
                    If Not System.String.IsNullOrEmpty(txtYear.Text) Then
                        nullable3 = New System.Nullable(Of Integer)(System.Int32.Parse(txtYear.Text))
                    End If
                Catch 
                    ParentBaseForm.ShowError(Sublight.Translation.Search_Error_ParsingYear, New object(0) {})
                    GoTo label_1
                End Try
            End If
            Dim s3 As String = IIf(Not _btnSearchFilter.Pressed OrElse System.String.IsNullOrEmpty(txtFilterSender.Text), Nothing, txtFilterSender.Text)
            If Not _btnSearchFilter.Pressed OrElse System.String.IsNullOrEmpty(txtFilterMediaCount.Text) Then
                i1 = -1
            ElseIf Not System.Int32.TryParse(txtFilterMediaCount.Text, ByRef i1) Then
                i1 = 0
            End If
            nullable4 = New System.Nullable(Of Single)[]
            If _btnSearchFilter.Pressed Then
                Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem 
                For Each toolStripMenuItem2 In cmsRate.Items
                    If toolStripMenuItem2.Checked Then
                        Dim i2 As Integer = DirectCast(toolStripMenuItem2.Tag, int)
                        If i2 >= 0 Then
                            nullable4 = New System.Nullable(Of Single)(CSng(i2))
                            Exit While
                        End If
                    End If
                Next
            End If
            If _btnSearchFilter.Pressed Then
                Dim list3 As System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage) = New System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage)
                Dim toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem 
                For Each toolStripMenuItem3 In cmsFilterLanguage.Items
                    If toolStripMenuItem3.Checked Then
                        list3.Add(DirectCast(toolStripMenuItem3.Tag, Sublight.WS.SubtitleLanguage))
                    End If
                Next
                subtitleLanguageArr1 = list3.ToArray()
            Else 
                subtitleLanguageArr1 = Sublight.MyUtility.LanguageUtil.GetSortedLanguages()
            End If
            If ((subtitleLanguageArr1) Is Nothing) OrElse (subtitleLanguageArr1.Length <= 0) Then
                parent.ShowWarning(Sublight.Translation.Search_Warning_NoLanguageSelected, New object(0) {})
            label_1: _
                Return
            End If
            Dim genreArr1 As Sublight.WS.Genre() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.Genre)), Sublight.WS.Genre[])
            Dim frmSearch1 As Sublight.FrmSearch = New Sublight.FrmSearch(s1, txtTitle.Text, nullable3, nullable2, nullable1, subtitleLanguageArr1, genreArr1, s3, nullable4, m_subtitlesWithoutReleaseInfo, i1)
            Dim flag2 As Boolean = False
            Dim secondarySubtitleProvider1 As Sublight.Types.SecondarySubtitleProvider = Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage
            If m_shiftPressed Then
                flag2 = True
                Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseAlways
                m_shiftPressed = False
            End If
            frmSearch1.ShowDialog(Me)
            If flag2 Then
                Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = secondarySubtitleProvider1
            End If
            <>c__DisplayClass13_1.frmSearchItems = frmSearch1.Items
            frmSearch1.Dispose()
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass13_1.<btnSearchLinked_Click>b__12)
            Sublight.BaseForm.DoCtrlInvoke(lvSearchResults, Me, methodInvoker1)
            If (Not (<>c__DisplayClass13_1.frmSearchItems) Is Nothing) AndAlso (<>c__DisplayClass13_1.frmSearchItems.Length >= Sublight.Globals.MAX_RESULTS) Then
                ShowSearchInfo(Sublight.Translation.Search_Info_SearchWasLimited)
            Else 
                HideSearchInfo()
            End If
            RefreshMatchesCount()
            If ((<>c__DisplayClass13_1.frmSearchItems) Is Nothing) OrElse (<>c__DisplayClass13_1.frmSearchItems.Length <= 0) Then
                If Not System.String.IsNullOrEmpty(txtSearchLinkedFile.Text) AndAlso System.String.IsNullOrEmpty(txtTitle.Text) Then
                    ParentBaseForm.ShowInfo(Sublight.Translation.Search_Info_NoLinkedSubtitles, New object(0) {})
                    Return
                End If
                Dim list1 As System.Collections.Generic.List(Of Sublight.Controls.PageSearch.SearchElement) = New System.Collections.Generic.List(Of Sublight.Controls.PageSearch.SearchElement)
                Dim s4 As String = Sublight.Properties.Settings.Default.Search_RecentUnsuccessfulSearches
                If Not System.String.IsNullOrEmpty(s4) Then
                    Try
                        Dim chArr1 As Char() = New char() { "&"C }
                        Dim sArr1 As String() = s4.Split(chArr1, System.StringSplitOptions.RemoveEmptyEntries)
                        If Not (sArr1) Is Nothing Then
                            Dim sArr2 As String() = sArr1
                            Dim i3 As Integer = 0
                            While i3 < sArr2.Length
                                Dim s5 As String = sArr2(i3)
                                Dim searchElement1 As Sublight.Controls.PageSearch.SearchElement = Sublight.Controls.PageSearch.SearchElement.DeserializeFromString(s5)
                                list1.Add(searchElement1)
                                i3 = i3 + 1
                            End While
                        End If
                    Catch 
                    End Try
                End If
                Try
                    Dim searchElement2 As Sublight.Controls.PageSearch.SearchElement = New Sublight.Controls.PageSearch.SearchElement(txtTitle.Text, nullable3, nullable2, nullable1)
                    Dim list2 As System.Collections.Generic.List(Of Sublight.Controls.PageSearch.SearchElement) = New System.Collections.Generic.List(Of Sublight.Controls.PageSearch.SearchElement)
                    Dim enumerator3 As System.Collections.Generic.List(Of Sublight.Controls.PageSearch.SearchElement).Enumerator = list1.GetEnumerator()
                    Try
                        While enumerator3.MoveNext()
                            Dim searchElement3 As Sublight.Controls.PageSearch.SearchElement = enumerator3.get_Current()
                            If System.String.Compare(searchElement2.ToString(), searchElement3.ToString(), True) = 0 Then
                                list2.Add(searchElement3)
                            End If
                        End While
                    Finally
                        enumerator3.Dispose()
                    End Try
                    Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Controls.PageSearch.SearchElement).Enumerator = list2.GetEnumerator()
                    Try
                        While enumerator1.MoveNext()
                            Dim searchElement4 As Sublight.Controls.PageSearch.SearchElement = enumerator1.get_Current()
                            list1.Remove(searchElement4)
                        End While
                    Finally
                        enumerator1.Dispose()
                    End Try
                    list1.Add(searchElement2)
                    While list1.get_Count() > 5
                        list1.RemoveAt(0)
                    End While
                    Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                    If list1.get_Count() > 0 Then
                        Dim enumerator2 As System.Collections.Generic.List(Of Sublight.Controls.PageSearch.SearchElement).Enumerator = list1.GetEnumerator()
                        Try
                            While enumerator2.MoveNext()
                                Dim searchElement5 As Sublight.Controls.PageSearch.SearchElement = enumerator2.get_Current()
                                stringBuilder1.AppendFormat("{0}&?", searchElement5.SerializeToString())
                            End While
                        Finally
                            enumerator2.Dispose()
                        End Try
                    End If
                    Sublight.Properties.Settings.Default.Search_RecentUnsuccessfulSearches = stringBuilder1.ToString()
                    Sublight.BaseForm.SaveUserSettingsSilent()
                Catch 
                End Try
                ParentBaseForm.ShowInfo(Sublight.Translation.Search_Info_NoMatchingSubtitles, New object(0) {})
            End If
        End Sub

        Private Sub btnSearchLinkedOpenFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            HideMovieInfo()
            HideSearchInfo()
            openFileDialog.FileName = System.String.Empty
            openFileDialog.Title = Sublight.Translation.Dialog_OpenVideo_Title
            openFileDialog.Filter = Sublight.Globals.OpenVideo_Filter
            If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                _doFeelingLuckySearch = True
                DoVideoInfoDetailed(openFileDialog.FileName)
                txtSearchLinkedFile.Text = openFileDialog.FileName
                txtSearchLinkedFile.SelectionStart = txtSearchLinkedFile.Text.Length
                AutoFillTitle()
            End If
        End Sub

        Private Sub btnShowFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowHideFilter()
            OnFilterChanged()
            If Sublight.Properties.Settings.Default.Search_ShowFilter <> _btnSearchFilter.Pressed Then
                Sublight.Properties.Settings.Default.Search_ShowFilter = _btnSearchFilter.Pressed
                Sublight.BaseForm.SaveUserSettingsSilent()
            End If
        End Sub

        Private Sub btnSuggest_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowTitleSuggest()
        End Sub

        Private Sub btnTitleNOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String = TryCast(txtDetectedTitle.Tag, string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            Dim chArr1 As Char() = New char() { ";"C }
            Dim sArr1 As String() = s1.Split(chArr1, System.StringSplitOptions.None)
            If sArr1.Length <> 3 Then
                Return
            End If
            If System.String.IsNullOrEmpty(sArr1(1)) AndAlso System.String.IsNullOrEmpty(sArr1(2)) Then
                VoteReportMovieHash(Sublight.WS.MovieHashVote.WrongMovie)
                Return
            End If
            If ParentBaseForm.ShowQuestion(Sublight.Translation.Search_Question_ReportMovieHashIsTitleCorrect, New object(0) {}) = System.Windows.Forms.DialogResult.Yes Then
                VoteReportMovieHash(Sublight.WS.MovieHashVote.WrongSeasonEpisode)
                Return
            End If
            VoteReportMovieHash(Sublight.WS.MovieHashVote.WrongMovie)
        End Sub

        Private Sub btnTitleOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            VoteReportMovieHash(Sublight.WS.MovieHashVote.OK)
        End Sub

        Private Sub cbAutoFillTitle_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Sublight.Properties.Settings.Default.Search_AutoFillTitle = cbAutoFillTitle.Checked
            ParentBaseForm.SaveUserSettings()
            If cbAutoFillTitle.Checked AndAlso System.String.IsNullOrEmpty(txtTitle.Text) Then
                AutoFillTitle()
            End If
        End Sub

        Private Sub ClearAndDisableDetectedTitle()
            If Not System.String.IsNullOrEmpty(txtDetectedTitle.Text) Then
                txtDetectedTitle.Text = System.String.Empty
            End If
            EnableDisableDetectedTitleButtons(False)
        End Sub

        Private Sub ClearManualSearchFields()
            txtYear.Text = System.String.Empty
            txtTitle.Text = System.String.Empty
            txtSeason.Text = System.String.Empty
            txtEpisode.Text = System.String.Empty
        End Sub

        Private Sub cmsSuggestTitle_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs)
            If _txtTitleAutoFocus Then
                _txtTitleAutoFocus = False
                TxtTitleFocus()
            End If
        End Sub

        Private Sub cmsSuggestTitle_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
            _txtTitleAutoFocus = False
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = TryCast(e.ClickedItem, System.Windows.Forms.ToolStripMenuItem)
            If (toolStripMenuItem1) Is Nothing Then
                Return
            End If
            Dim imdb1 As Sublight.WS.IMDB = TryCast(toolStripMenuItem1.Tag, Sublight.WS.IMDB)
            If (imdb1) Is Nothing Then
                Return
            End If
            If Not System.String.IsNullOrEmpty(imdb1.Title) Then
                txtTitle.Text = imdb1.Title
                Dim nullable2 As System.Nullable(Of Integer) = imdb1.Year
                If nullable2.get_HasValue() Then
                    Dim nullable1 As System.Nullable(Of Integer) = imdb1.Year
                    txtYear.Text = System.String.Format("{0}?", nullable1.get_Value())
                Else 
                    txtYear.Text = System.String.Empty
                End If
            End If
            TxtTitleFocus()
        End Sub

        Private Sub contextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            mnuPluginSubtitleActions.Visible = False
            If ((lvSearchResults.SelectedItems) Is Nothing) OrElse ((lvSearchResults.Items) Is Nothing) OrElse (lvSearchResults.SelectedItems.Count <= 0) OrElse (lvSearchResults.Items.Count <= 0) Then
                e.Cancel = True
                Return
            End If
            mnuDelete.Visible = False
            mnuEdit.Visible = False
            Dim i1 As Integer = 0
            While i1 < lvSearchResults.SelectedItems.Count
                Dim data1 As Sublight.Controls.SuperListItem.Data = CType(lvSearchResults.SelectedItems(i1).Items(0), Sublight.Controls.SuperListItem.Data)
                If Not (data1.SubtitleProvider) Is Nothing Then
                    mnuImportSubtitle.Visible = True
                    mnuImportSubtitle.Enabled = Not Sublight.BaseForm.IsAnonymous
                    If mnuImportSubtitle.Enabled AndAlso (data1.SubtitleProvider.DownloadType = Sublight.Plugins.SubtitleProvider.Types.SubtitleProviderDownloadType.Indirect) Then
                        mnuImportSubtitle.Enabled = False
                    End If
                    If mnuImportSubtitle.Enabled AndAlso (lvSearchResults.SelectedItems.Count > 1) Then
                        mnuImportSubtitle.Enabled = False
                    End If
                    mnuPluginInfo.Visible = True
                    mnuPrimarySubDbInfo.Visible = True
                    mnuPlay.Enabled = _btnPlay.Enabled
                    mnuDownload.Visible = _btnSearchDownload.Enabled
                    mnuAddRelease.Visible = False
                    mnuAddAlternativeTitle.Visible = False
                    mnuReportSubtitle.Visible = False
                    mnuRate.Visible = False
                    mnuAddLink.Visible = False
                    mnuValidLink.Visible = False
                    mnuInvalidLink.Visible = False
                    mnuIMDB.Visible = False
                    mnuSubtitlePreview.Visible = False
                    mnuProperties.Visible = False
                    mnuNFO.Visible = False
                    mnuSearchAllMovieSubtitles.Visible = False
                    mnuSearchAllSubtitlesForThisPublisher.Visible = False
                    toolStripSeparator3.Visible = True
                    toolStripSeparator4.Visible = False
                    toolStripSeparator5.Visible = False
                    toolStripSeparator7.Visible = False
                    toolStripSeparator8.Visible = False
                    mnuImportSubtitle.Text = Sublight.Translation.Search_Context_ImportSubtitle
                    mnuPrimarySubDbInfo.Text = Sublight.Translation.Search_Context_WhatIsPrimarySubtitleDatabase
                    mnuPluginInfo.Text = Sublight.Translation.Search_Context_PluginInfo
                    mnuSearchAllMovieSubtitles.Text = Sublight.Translation.Search_Context_SearchAllSubtitlesForThisMovie
                    mnuSearchAllSubtitlesForThisPublisher.Text = Sublight.Translation.Search_Context_SearchAllSubtitlesFromThisPublisher
                    mnuPlay.Text = Sublight.Translation.Search_Context_DownloadAndPlay
                    mnuDownload.Text = Sublight.Translation.Search_Context_DownloadSubtitle
                    Dim subtitleActionArr1 As Sublight.Plugins.SubtitleProvider.Types.SubtitleAction() = data1.SubtitleProvider.GetActions(data1.Subtitle.ExternalId)
                    If (Not (subtitleActionArr1) Is Nothing) AndAlso (subtitleActionArr1.Length > 0) Then
                        Dim i2 As Integer = 0
                        While i2 < mnuPluginSubtitleActions.DropDownItems.Count
                            mnuPluginSubtitleActions.DropDownItems(i2).Dispose()
                            i2 = i2 + 1
                        End While
                        mnuPluginSubtitleActions.DropDownItems.Clear()
                        Dim subtitleActionArr2 As Sublight.Plugins.SubtitleProvider.Types.SubtitleAction() = subtitleActionArr1
                        Dim i3 As Integer = 0
                        While i3 < subtitleActionArr2.Length
                            Dim subtitleAction1 As Sublight.Plugins.SubtitleProvider.Types.SubtitleAction = subtitleActionArr2(i3)
                            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem(subtitleAction1.Text)
                            toolStripMenuItem1.Name = subtitleAction1.Id
                            toolStripMenuItem1.Tag = subtitleAction1
                            If Not (subtitleAction1.Icon) Is Nothing Then
                                toolStripMenuItem1.Image = subtitleAction1.Icon
                                toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
                            End If
                            AddHandler toolStripMenuItem1.Click, AddressOf mnuSubtitleAction_Click
                            mnuPluginSubtitleActions.DropDownItems.Add(toolStripMenuItem1)
                            i3 = i3 + 1
                        End While
                        mnuPluginSubtitleActions.Text = Sublight.Translation.Search_Context_PluginSubtitleAction
                        mnuPluginSubtitleActions.Visible = True
                    End If
                    Return
                End If
                i1 = i1 + 1
            End While
            mnuImportSubtitle.Visible = False
            mnuPluginInfo.Visible = False
            mnuPrimarySubDbInfo.Visible = False
            toolStripSeparator3.Visible = True
            toolStripSeparator4.Visible = True
            toolStripSeparator5.Visible = True
            toolStripSeparator7.Visible = True
            mnuPlay.Enabled = _btnPlay.Enabled
            mnuDownload.Visible = _btnSearchDownload.Enabled
            mnuAddLink.Visible = _btnLinkAdd.Enabled
            mnuIMDB.Visible = _imdbEnabled
            mnuProperties.Visible = _imdbEnabled
            mnuSubtitlePreview.Visible = _imdbEnabled
            mnuNFO.Visible = _imdbEnabled
            toolStripSeparator7.Visible = True
            mnuValidLink.Visible = _btnLinkValid.Enabled
            mnuInvalidLink.Visible = _btnLinkInvalid.Enabled
            mnuAddRelease.Visible = Not Sublight.BaseForm.IsAnonymous
            mnuAddAlternativeTitle.Visible = False
            mnuPlay.Text = Sublight.Translation.Search_Context_DownloadAndPlay
            mnuDownload.Text = Sublight.Translation.Search_Context_DownloadSubtitle
            mnuAddRelease.Text = Sublight.Translation.Search_Context_AddRelease
            mnuAddLink.Text = Sublight.Translation.Search_Context_AddLink
            mnuRate.Text = Sublight.Translation.Search_Context_RateSubtitle
            mnuReportSubtitle.Text = Sublight.Translation.Search_Context_ReportSubtitle
            mnuIMDB.Text = Sublight.Translation.Search_Context_IMDB
            mnuRateVal1.Text = Sublight.Translation.Search_Context_RateSubtitle_1
            mnuRateVal2.Text = Sublight.Translation.Search_Context_RateSubtitle_2
            mnuRateVal3.Text = Sublight.Translation.Search_Context_RateSubtitle_3
            mnuRateVal4.Text = Sublight.Translation.Search_Context_RateSubtitle_4
            mnuRateVal5.Text = Sublight.Translation.Search_Context_RateSubtitle_5
            mnuValidLink.Text = Sublight.Translation.Search_Context_ValidLink
            mnuInvalidLink.Text = Sublight.Translation.Search_Context_InvalidLink
            mnuProperties.Text = Sublight.Translation.Common_Menu_Properties
            mnuSubtitlePreview.Text = Sublight.Translation.FrmDetails_Tab_SubtitlePreview
            mnuSearchAllMovieSubtitles.Text = Sublight.Translation.Search_Context_SearchAllSubtitlesForThisMovie
            mnuSearchAllSubtitlesForThisPublisher.Text = Sublight.Translation.Search_Context_SearchAllSubtitlesFromThisPublisher
            If Sublight.Controls.BasePageResults.AreMultipleItemsSelected(lvSearchResults) Then
                mnuDownload.Text = Sublight.Translation.Search_Context_DownloadSubtitles
                toolStripSeparator3.Visible = False
                toolStripSeparator4.Visible = False
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
                toolStripSeparator4.Visible = True
                toolStripSeparator5.Visible = True
                mnuRate.Visible = True
                mnuReportSubtitle.Visible = True
                mnuDownload.Text = Sublight.Translation.Search_Context_DownloadSubtitle
                toolStripSeparator8.Visible = True
                mnuSearchAllMovieSubtitles.Visible = True
                mnuSearchAllSubtitlesForThisPublisher.Visible = True
                Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
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
            End If
            Dim flag1 As Boolean = lvSearchResults.Items.Count > 0
            e.Cancel = Not flag1
        End Sub

        Private Sub DoVideoInfoDetailed(ByVal fileName As String)
            Dim videoInfoDetailed1 As Sublight.MyUtility.VideoInfoDetailed = New Sublight.MyUtility.VideoInfoDetailed(fileName)
            AddHandler videoInfoDetailed1.Result, AddressOf vid_Result
            videoInfoDetailed1.DoAsync()
        End Sub

        Private Sub EnableDisableDetectedTitleButtons(ByVal isEnabled As Boolean)
            btnTitleOK.Enabled = isEnabled
            btnTitleNOK.Enabled = isEnabled
            RepositionFeelingButton()
            btnFeelingLucky.Visible = isEnabled
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            TranslateSearchResults()
            RefreshMatchesCount()
            label4.LegendText = Sublight.Translation.Search_SearchResults_Legend_Linked
            label6.LegendText = Sublight.Translation.Search_SearchResults_Legend_NotLinked
            _btnPlay.Text = Sublight.Translation.Search_Toolbar_Play
            _btnPlay.ScreenTip.Text = Sublight.Translation.Search_Toolbar_Play_Tooltip
            _btnSearchDownload.Text = Sublight.Translation.Search_Toolbar_Download
            SetScreenTip(_btnSearchDownload, Sublight.Translation.Search_Toolbar_Download_Tooltip)
            _btnLinkAdd.Text = Sublight.Translation.Search_Toolbar_AddLink
            _btnLinkAdd.ScreenTip.Text = Sublight.Translation.Search_Toolbar_AddLink_Tooltip
            _btnLinkValid.Text = Sublight.Translation.Search_Toolbar_ValidLink
            _btnLinkValid.ScreenTip.Text = Sublight.Translation.Search_Toolbar_ValidLink_Tooltip
            _btnLinkInvalid.Text = Sublight.Translation.Search_Toolbar_InvalidLink
            _btnLinkInvalid.ScreenTip.Text = Sublight.Translation.Search_Toolbar_InvalidLink_Tooltip
            _btnClear.Text = Sublight.Translation.Common_Toolbar_ClearFields
            btnSearchLinked.Text = Sublight.Translation.Search_Button_Search
            btnFeelingLucky.Text = Sublight.Translation.Search_Button_FeelingLucky
            btnSearchLinkedOpenFile.Text = Sublight.Translation.Common_Button_ChooseFile
            btnSuggest.Text = Sublight.Translation.Search_Panel_ManualSearchCriteria_Button_Suggest
            _btnSearchFilter.Text = Sublight.Translation.Search_Toolbar_FilterResults
            _btnRate.Text = Sublight.Translation.Search_Toolbar_RateSubtitle
            _btnReport.Text = Sublight.Translation.Search_Toolbar_ReportSubtitle
            _btnSearchSync.Text = Sublight.Translation.Search_Toolbar_SynchronizeSubtitle
            groupBox1.Text = Sublight.Translation.Search_Panel_AutoSearchCriteria
            groupBox2.Text = Sublight.Translation.Search_Panel_ManualSearchCriteria
            groupBox3.Text = Sublight.Translation.Search_Panel_ResultsFiltering
            ttSearchByHash.Title = Sublight.Translation.Search_Panel_AutoSearchCriteria
            ttSearchByHash.Text = Sublight.Translation.Search_Panel_AutoSearchCriteria_Tooltip
            ttSearchManual.Title = Sublight.Translation.Search_Panel_ManualSearchCriteria
            ttSearchManual.Text = Sublight.Translation.Search_Panel_ManualSearchCriteria_Tooltip
            ttSearchResultsFilter.Title = Sublight.Translation.Search_Panel_ResultsFiltering
            ttSearchResultsFilter.Text = Sublight.Translation.Search_Panel_ResultsFiltering_Tooltip
            label5.Text = Sublight.Translation.Search_Panel_AutoSearchCriteria_VideoFile
            cbAutoFillTitle.Text = Sublight.Translation.Search_Panel_AutoSearchCriteria_AutoFillTitle
            label1.Text = Sublight.Translation.Search_Panel_ManualSearchCriteria_Title
            label2.Text = Sublight.Translation.Search_Panel_ManualSearchCriteria_Year
            lblSeason.Text = Sublight.Translation.Search_Panel_ManualSearchCriteria_Season
            lblEpisode.Text = Sublight.Translation.Search_Panel_ManualSearchCriteria_Episode
            label3.Text = Sublight.Translation.Search_Panel_ResultsFiltering_Language
            label10.Text = Sublight.Translation.Search_Panel_ResultsFiltering_Publisher
            label11.Text = Sublight.Translation.Search_Panel_ResultsFiltering_Rate
            label8.Text = Sublight.Translation.Search_Panel_ResultsFiltering_Discs
            txtSearchLinkedFile.PromptText = Sublight.Translation.Search_Panel_AutoSearchCriteria_VideoFile_CueBanner
            txtTitle.PromptText = Sublight.Translation.Search_Panel_ManualSearchCriteria_Title_CueBanner
            FillFilterLanguages()
            SetFilterLanguageText()
            TranslateFilterByRate()
            HideSearchInfo()
            lblDetectedTitle.Text = Sublight.Translation.Search_Panel_AutoSearchCriteria_DetectedTitle
            ttTitleOK.SetToolTip(btnTitleOK, Sublight.Translation.Search_Panel_AutoSearchCriteria_TooltipCorrectTitle)
            ttTitleNOK.SetToolTip(btnTitleNOK, Sublight.Translation.Search_Panel_AutoSearchCriteria_TooltipIncorrectTitle)
            mnuDelete.Text = Sublight.Translation.Common_Button_Delete
            mnuEdit.Text = Sublight.Translation.Common_Button_Edit
            label4.SetLineWidth(20)
            label6.SetLineWidth(20)
            If label4.Width > label6.Width Then
                label6.Width = label4.Width
            Else 
                label4.Width = label6.Width
            End If
            panel2.Width = lblSubtitleLinked.Width + label4.Width + 6
            If btnSearchLinked.TextWidth <= 0 Then
                btnSearchLinked.Width = 100
            Else 
                btnSearchLinked.Width = 30 + btnSearchLinked.TextWidth + 10
            End If
            tcSearchInfo.Left = btnSearchLinked.Right + 6
            RepositionFeelingButton()
        End Sub

        Private Sub Events_SettingsLoaded(ByVal sender As Object)
            If Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.AlwaysChosenByUser Then
                _btnSearchDownload.Text = Sublight.Translation.Search_Toolbar_DownloadToCustomFolder
            Else 
                _btnSearchDownload.Text = Sublight.Translation.Search_Toolbar_Download
            End If
            cbAutoFillTitle.Checked = Sublight.Properties.Settings.Default.Search_AutoFillTitle
            FillFilterLanguages()
            SetFilterLanguageText()
        End Sub

        Private Sub Events_TabChanged(ByVal sender As Object)
            TryCloseLinkTooltip()
        End Sub

        Private Sub Events_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            mnuEdit.Visible = Not isAnonymous
        End Sub

        Private Sub FillByHeurestics()
            Dim s4 As String, s6 As String

            If Not cbAutoFillTitle.Checked Then
                Return
            End If
            Dim s1 As String = Sublight.MyUtility.NfoUtility.GetNfoPath(txtSearchLinkedFile.Text)
            If Not System.String.IsNullOrEmpty(s1) Then
                Dim imdb1 As Sublight.WS.IMDB = Sublight.MyUtility.NfoUtility.GetImdbDetails(s1)
                If Not (imdb1) Is Nothing Then
                    txtTitle.Text = imdb1.Title
                    Dim nullable1 As System.Nullable(Of Integer) = imdb1.Year
                    If nullable1.get_HasValue() Then
                        Dim nullable2 As System.Nullable(Of Integer) = imdb1.Year
                        Dim i2 As Integer = nullable2.get_Value()
                        txtYear.Text = i2.ToString()
                    Else 
                        txtYear.Text = System.String.Empty
                    End If
                    Try
                        Dim s2 As String = Utility.Video.Checksum.Compute(txtSearchLinkedFile.Text)
                        Dim s3 As String = Sublight.MyUtility.MovieHasher.ComputeMovieHash(txtSearchLinkedFile.Text)
                        If Not System.String.IsNullOrEmpty(s2) AndAlso Not System.String.IsNullOrEmpty(s3) Then
                            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                                sublight1.MapHash(Sublight.BaseForm.Session, s2, s3, imdb1.Id, imdb1.Title, (New System.IO.FileInfo(txtSearchLinkedFile.Text)).Length, out s4)
                            End Using
                        End If
                    Catch 
                    End Try
                    Return
                End If
            End If
            Dim s5 As String = Sublight.Properties.Settings.Default.SemiAutomaticSearchIgnoreWords
            If Not (s5) Is Nothing Then
                Dim chArr1 As Char() = New char() { " "C }
                Dim sArr1 As String() = s5.Split(chArr1, System.StringSplitOptions.RemoveEmptyEntries)
                Try
                    s6 = System.IO.Path.GetFileName(txtSearchLinkedFile.Text)
                Catch 
                    s6 = txtSearchLinkedFile.Text
                End Try
                If System.String.IsNullOrEmpty(s6) Then
                    Return
                End If
                s6 = s6.Replace("."C, " "C)
                s6 = s6.Replace("["C, " "C)
                s6 = s6.Replace("]"C, " "C)
                s6 = s6.Replace("-"C, " "C)
                s6 = s6.Replace("("C, " "C)
                s6 = s6.Replace(")"C, " "C)
                s6 = s6.Replace("_"C, " "C)
                s6 = s6.Replace("'"C, " "C)
                Dim chArr2 As Char() = New char() { " "C }
                Dim sArr2 As String() = s6.Split(chArr2, System.StringSplitOptions.RemoveEmptyEntries)
                Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                Dim sArr3 As String() = sArr2
                Dim i3 As Integer = 0
                While i3 < sArr3.Length
                    Dim s7 As String = sArr3(i3)
                    Dim flag1 As Boolean = False
                    Dim sArr4 As String() = sArr1
                    Dim i4 As Integer = 0
                    While i4 < sArr4.Length
                        Dim s8 As String = sArr4(i4)
                        If System.String.Compare(s7, s8, True) = 0 Then
                            flag1 = True
                            Exit While
                        End If
                        i4 = i4 + 1
                    End While
                    If Not flag1 Then
                        list1.Add(s7)
                        i3 = i3 + 1
                    End If
                End While
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim i1 As Integer = 0
                While i1 < list1.get_Count()
                    Dim s9 As String = list1.get_Item(i1).Trim()
                    If Not System.Text.RegularExpressions.Regex.IsMatch(s9, "\b[1,2][9,0][0-9][0-9]\b?") AndAlso (s9.Length > 1) Then
                        stringBuilder1.Append(s9)
                        If i1 < (list1.get_Count() - 1) Then
                            stringBuilder1.Append(" "C)
                        End If
                    End If
                    i1 = i1 + 1
                End While
                txtTitle.Text = stringBuilder1.ToString()
            End If
            FillSeasonEpisode()
        End Sub

        Private Sub FillByImdb(ByVal imdbInfo As Sublight.WS.IMDB)
            If (imdbInfo) Is Nothing Then
                ClearAndDisableDetectedTitle()
                Return
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            If cbAutoFillTitle.Checked Then
                txtTitle.Text = imdbInfo.Title
            End If
            If Not System.String.IsNullOrEmpty(imdbInfo.Title) Then
                stringBuilder1.Append(imdbInfo.Title)
            End If
            Dim nullable10 As System.Nullable(Of Integer) = imdbInfo.Year
            If nullable10.get_HasValue() Then
                If cbAutoFillTitle.Checked Then
                    Dim nullable9 As System.Nullable(Of Integer) = imdbInfo.Season
                    If Not nullable9.get_HasValue() Then
                        Dim nullable8 As System.Nullable(Of Integer) = imdbInfo.Episode
                        If Not nullable8.get_HasValue() Then
                            Dim nullable13 As System.Nullable(Of Integer) = imdbInfo.Year
                            Dim i3 As Integer = nullable13.get_Value()
                            txtYear.Text = i3.ToString()
                        End If
                    End If
                End If
                If stringBuilder1.Length > 0 Then
                    Dim nullable12 As System.Nullable(Of Integer) = imdbInfo.Year
                    stringBuilder1.AppendFormat(" ({0})?", nullable12.get_Value())
                End If
            End If
            Dim nullable11 As System.Nullable(Of Integer) = imdbInfo.Season
            If nullable11.get_HasValue() AndAlso cbAutoFillTitle.Checked Then
                Dim nullable3 As System.Nullable(Of Integer) = imdbInfo.Season
                txtSeason.Text = nullable3.ToString()
            End If
            Dim nullable2 As System.Nullable(Of Integer) = imdbInfo.Episode
            If nullable2.get_HasValue() AndAlso cbAutoFillTitle.Checked Then
                Dim nullable1 As System.Nullable(Of Integer) = imdbInfo.Episode
                txtEpisode.Text = nullable1.ToString()
            End If
            Dim flag1 As Boolean = System.String.IsNullOrEmpty(txtSeason.Text)
            Dim flag2 As Boolean = System.String.IsNullOrEmpty(txtEpisode.Text)
            Dim nullable4 As System.Nullable(Of Integer) = imdbInfo.Season
            If nullable4.get_HasValue() Then
                Dim nullable7 As System.Nullable(Of Integer) = imdbInfo.Episode
                If nullable7.get_HasValue() AndAlso (stringBuilder1.Length > 0) Then
                    Dim nullable6 As System.Nullable(Of Integer) = imdbInfo.Season
                    Dim nullable5 As System.Nullable(Of Integer) = imdbInfo.Episode
                    stringBuilder1.AppendFormat(", S{0:00}E{1:00}?", nullable6.get_Value(), nullable5.get_Value())
                End If
            End If
            If imdbInfo.Tag <> "OST?" AndAlso (stringBuilder1.Length > 0) Then
                txtDetectedTitle.Text = stringBuilder1.ToString()
                txtDetectedTitle.Tag = System.String.Format("{0};{1};{2}?", imdbInfo.Id, imdbInfo.Season, imdbInfo.Episode)
                EnableDisableDetectedTitleButtons(True)
            Else 
                EnableDisableDetectedTitleButtons(False)
                ShowSearchInfo(Sublight.Translation.Search_Info_LinkMovieWithSubtitle)
                If Sublight.Properties.Settings.Default.AskToLinkFile2 Then
                    m_ttHelpUsLink = New Sublight.FrmBalloon
                    m_ttHelpUsLink.StartPosition = System.Windows.Forms.FormStartPosition.Manual
                    Dim control1 As System.Windows.Forms.Control = _btnLinkAdd
                    Dim i1 As Integer = 0
                    Dim i2 As Integer = 0
                    While Not (control1) Is Nothing
                        i1 = i1 + control1.Top
                        i2 = i2 + control1.Left
                        control1 = control1.Parent
                    End While
                    i1 = i1 + _btnLinkAdd.Height
                    i2 = i2 - (_btnLinkAdd.Width / 2)
                    m_ttHelpUsLink.Top = i1
                    m_ttHelpUsLink.Left = i2
                    m_ttHelpUsLink.Show(ParentBaseForm)
                End If
            End If
            FillSeasonEpisode((New System.IO.FileInfo(txtSearchLinkedFile.Text)).Name, False, False, flag1, flag2)
        End Sub

        Private Sub FillDropDownRate()
            Dim popupMenu1 As Elegant.Ui.PopupMenu = TryCast(_btnRate.Popup, Elegant.Ui.PopupMenu)
            If Not (popupMenu1) Is Nothing Then
                Dim control1 As System.Windows.Forms.Control 
                For Each control1 In popupMenu1.Items
                    control1.Dispose()
                Next
                popupMenu1.Items.Clear()
                popupMenu1.Dispose()
            End If
            popupMenu1 = New Elegant.Ui.PopupMenu(_btnRate)
            _btnRate.Popup = popupMenu1
            Dim i1 As Integer = 1
            While i1 <= 5
                Dim button1 As Elegant.Ui.Button = New Elegant.Ui.Button
                button1.Text = Sublight.Globals.GetString(System.String.Format("Search_Context_RateSubtitle_{0}?", i1))
                button1.Tag = i1
                AddHandler button1.Click, AddressOf btnRibbonRate_Click
                popupMenu1.Items.Add(button1)
                i1 = i1 + 1
            End While
        End Sub

        Private Sub FillFilterByRate()
            cmsRate.Items.Clear()
            Dim toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            toolStripMenuItem3.Checked = True
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = toolStripMenuItem3
            AddHandler toolStripMenuItem1.Click, AddressOf tsmi_FilterByRateClick
            toolStripMenuItem1.Text = Sublight.Translation.Common_Selection_ShowAll
            toolStripMenuItem1.CheckOnClick = False
            toolStripMenuItem1.Tag = -1
            cmsRate.Items.Add(toolStripMenuItem1)
            Dim i1 As Integer = 1
            While i1 < 5
                Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
                toolStripMenuItem2.Checked = False
                toolStripMenuItem1 = toolStripMenuItem2
                AddHandler toolStripMenuItem1.Click, AddressOf tsmi_FilterByRateClick
                toolStripMenuItem1.Text = System.String.Format(Sublight.Translation.Search_Panel_ResultsFiltering_RateGreaterThan, i1)
                toolStripMenuItem1.CheckOnClick = False
                toolStripMenuItem1.Tag = i1
                cmsRate.Items.Add(toolStripMenuItem1)
                i1 = i1 + 1
            End While
        End Sub

        Private Sub FillFilterLanguages()
            cmsFilterLanguage.Items.Clear()
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = Sublight.MyUtility.LanguageUtil.GetSortedLanguages()
            If (subtitleLanguageArr1) Is Nothing Then
                Return
            End If
            Dim subtitleLanguageArr2 As Sublight.WS.SubtitleLanguage() = subtitleLanguageArr1
            Dim i1 As Integer = 0
            While i1 < subtitleLanguageArr2.Length
                Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(subtitleLanguageArr2(i1), Sublight.WS.SubtitleLanguage)
                If subtitleLanguage1 <> Sublight.WS.SubtitleLanguage.Unknown Then
                    Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
                    toolStripMenuItem2.Checked = False
                    Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = toolStripMenuItem2
                    AddHandler toolStripMenuItem1.Click, AddressOf tsmi_FilterLanguageClick
                    toolStripMenuItem1.Text = Sublight.Globals.GetString(subtitleLanguage1)
                    toolStripMenuItem1.CheckOnClick = True
                    toolStripMenuItem1.Tag = subtitleLanguage1
                    If Not (Sublight.Properties.Settings.Default.Search_Filter_Language) Is Nothing Then
                        Dim enumerator1 As System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage).Enumerator = Sublight.Properties.Settings.Default.Search_Filter_Language.GetEnumerator()
                        Try
                            While enumerator1.MoveNext()
                                Dim subtitleLanguage2 As Sublight.WS.SubtitleLanguage = CType(enumerator1.get_Current(), Sublight.WS.SubtitleLanguage)
                                If subtitleLanguage2 = subtitleLanguage1 Then
                                    toolStripMenuItem1.Checked = True
                                    Exit While
                                End If
                            End While
                            GoTo label_1
                        Finally
                            enumerator1.Dispose()
                        End Try
                    End If
                    toolStripMenuItem1.Checked = True
                label_1: _
                    cmsFilterLanguage.Items.Add(toolStripMenuItem1)
                End If
                i1 = i1 + 1
            End While
            Dim toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            toolStripMenuItem4.Checked = False
            Dim toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem = toolStripMenuItem4
            AddHandler toolStripMenuItem3.Click, AddressOf tsmi_FilterLanguageClick
            toolStripMenuItem3.Text = Sublight.Translation.Common_Selection_SelectAll
            toolStripMenuItem3.CheckOnClick = False
            toolStripMenuItem3.Tag = 1
            cmsFilterLanguage.Items.Add(toolStripMenuItem3)
            Dim toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            toolStripMenuItem5.Checked = False
            toolStripMenuItem3 = toolStripMenuItem5
            AddHandler toolStripMenuItem3.Click, AddressOf tsmi_FilterLanguageClick
            toolStripMenuItem3.Text = Sublight.Translation.Common_Selection_RemoveAll
            toolStripMenuItem3.CheckOnClick = False
            toolStripMenuItem3.Tag = 2
            cmsFilterLanguage.Items.Add(toolStripMenuItem3)
        End Sub

        Private Sub FillSeasonEpisode()
            FillSeasonEpisode(txtTitle.Text, True)
        End Sub

        Private Function FillSeasonEpisode(ByVal match As System.Text.RegularExpressions.Match, ByVal setTitle As Boolean, ByVal setSeason As Boolean, ByVal setEpisode As Boolean) As Boolean
            Dim i1 As Integer, i2 As Integer

            If Not cbAutoFillTitle.Checked Then
                Return False
            End If
            If ((match) Is Nothing) OrElse Not match.Success Then
                Return False
            End If
            If Not System.Int32.TryParse(match.Groups("season?").Value, ByRef i1) Then
                Return False
            End If
            If Not System.Int32.TryParse(match.Groups("episode?").Value, ByRef i2) Then
                Return False
            End If
            If setTitle Then
                txtTitle.Text = txtTitle.Text.Substring(0, txtTitle.Text.IndexOf(match.Value)).Trim()
                txtTitle.Text = Sublight.Controls.PageSearch.DeleteDuplicatedWhiteSpace(txtTitle.Text)
            End If
            If setSeason Then
                txtSeason.Text = i1.ToString()
            End If
            If setEpisode Then
                txtEpisode.Text = i2.ToString()
            End If
            Return True
        End Function

        Private Sub FillSeasonEpisode(ByVal fileName As String, ByVal setTitle As Boolean, ByVal clearSE As Boolean, ByVal setSeason As Boolean, ByVal setEpisode As Boolean)
            If Not cbAutoFillTitle.Checked Then
                Return
            End If
            If clearSE Then
                txtSeason.Text = System.String.Empty
                txtEpisode.Text = System.String.Empty
            End If
            If setSeason Then
                txtSeason.Text = System.String.Empty
            End If
            If setEpisode Then
                txtEpisode.Text = System.String.Empty
            End If
            Try
                Dim match1 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(fileName, "\b(?<season>[0-9]*?)[xX]{1,1}(?<episode>[0-9]*?)\b?")
                If match1.Success AndAlso FillSeasonEpisode(match1, setTitle, setSeason, setEpisode) Then
                    Return
                End If
                match1 = System.Text.RegularExpressions.Regex.Match(fileName, "\b[sS]{1,1}(?<season>[0-9]*?)[eE]{1,1}(?<episode>[0-9]*?)\b?")
                If match1.Success AndAlso FillSeasonEpisode(match1, setTitle, setSeason, setEpisode) Then
                    Return
                End If
            Catch 
            End Try
        End Sub

        Private Sub FillSeasonEpisode(ByVal fileName As String, ByVal setTitle As Boolean)
            FillSeasonEpisode(fileName, setTitle, True, True, True)
        End Sub

        Private Sub HideMovieInfo()
            pbMovieInfo.Visible = False
            If Not (pbMovieInfo.Image) Is Nothing Then
                pbMovieInfo.Image.Dispose()
                pbMovieInfo.Image = Nothing
            End If
        End Sub

        Private Sub HideSearchInfo()
            If tcSearchInfo.Visible Then
                tcSearchInfo.HideCtrl()
            End If
        End Sub

        Private Sub HideSearchInfoThread(ByVal args As Object)
            Dim <>c__DisplayClass8_1 As Sublight.Controls.PageSearch.<>c__DisplayClass8 = New Sublight.Controls.PageSearch.<>c__DisplayClass8
            <>c__DisplayClass8_1.args = args
            <>c__DisplayClass8_1.<>4__this = Me
            System.Threading.Thread.Sleep(12000)
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<HideSearchInfoThread>b__7)
            If tcSearchInfo.InvokeRequired Then
                Dim objArr1 As Object() = New object(2) {}
                objArr1(0) = Me
                Dim objArr2 As Object() = New object(1) {}
                objArr1(1) = objArr2
                tcSearchInfo.BeginInvoke(methodInvoker1, objArr1)
                Return
            End If
            methodInvoker1.Invoke()
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            Dim mySectionFactory1 As Sublight.Controls.SuperListItem.MySectionFactory = New Sublight.Controls.SuperListItem.MySectionFactory
            panel1 = New Sublight.Controls.MyPanel
            btnFeelingLucky = New Sublight.Controls.Button.Button
            tcSearchInfo = New Sublight.Controls.TipCtrl
            panel2 = New Sublight.Controls.MyPanel
            label6 = New Sublight.Controls.LegendLabel
            lblSubtitleUnlinked = New System.Windows.Forms.Label
            label4 = New Sublight.Controls.LegendLabel
            lblSubtitleLinked = New System.Windows.Forms.Label
            panelSearchTop = New Sublight.Controls.Panel
            groupBox3 = New Sublight.Controls.MyGroupBox
            btnRate = New Sublight.Controls.Button.Button
            btnLanguage = New Sublight.Controls.Button.Button
            txtFilterMediaCount = New Sublight.Controls.MyTextBox
            label8 = New System.Windows.Forms.Label
            ttSearchResultsFilter = New Sublight.Controls.ToolTip
            pictureBox3 = New System.Windows.Forms.PictureBox
            label11 = New System.Windows.Forms.Label
            txtFilterSender = New Sublight.Controls.MyTextBox
            label10 = New System.Windows.Forms.Label
            label3 = New System.Windows.Forms.Label
            panelSearchCriteriaSearchFilterSeparator = New Sublight.Controls.MyPanel
            panelSearchTopCriteria = New Sublight.Controls.Panel
            groupBox2 = New Sublight.Controls.MyGroupBox
            lblTipSuggest = New System.Windows.Forms.Label
            btnSuggest = New Sublight.Controls.Button.Button
            cmsSuggestTitle = New System.Windows.Forms.ContextMenuStrip(components)
            ttSearchManual = New Sublight.Controls.ToolTip
            pictureBox2 = New System.Windows.Forms.PictureBox
            txtEpisode = New Sublight.Controls.MyTextBox
            txtSeason = New Sublight.Controls.MyTextBox
            lblEpisode = New System.Windows.Forms.Label
            lblSeason = New System.Windows.Forms.Label
            txtYear = New Sublight.Controls.MyTextBox
            label2 = New System.Windows.Forms.Label
            txtTitle = New Sublight.Controls.PromptedTextBox
            label1 = New System.Windows.Forms.Label
            panel4 = New Sublight.Controls.Panel
            groupBox1 = New Sublight.Controls.MyGroupBox
            pbMovieInfo = New System.Windows.Forms.PictureBox
            btnTitleNOK = New Sublight.Controls.Button.Button
            btnTitleOK = New Sublight.Controls.Button.Button
            lblDetectedTitle = New System.Windows.Forms.Label
            txtDetectedTitle = New Sublight.Controls.MyTextBox
            ttSearchByHash = New Sublight.Controls.ToolTip
            pictureBox1 = New System.Windows.Forms.PictureBox
            cbAutoFillTitle = New Sublight.Controls.MyCheckBox
            btnSearchLinkedOpenFile = New Sublight.Controls.Button.Button
            txtSearchLinkedFile = New Sublight.Controls.PromptedTextBox
            label5 = New System.Windows.Forms.Label
            btnSearchLinked = New Sublight.Controls.Button.Button
            folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
            lvSearchResults = New Sublight.Controls.MySuperList
            contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(components)
            mnuPlay = New System.Windows.Forms.ToolStripMenuItem
            mnuDownload = New System.Windows.Forms.ToolStripMenuItem
            mnuPluginSubtitleActions = New System.Windows.Forms.ToolStripMenuItem
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
            toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            mnuSearchAllMovieSubtitles = New System.Windows.Forms.ToolStripMenuItem
            mnuSearchAllSubtitlesForThisPublisher = New System.Windows.Forms.ToolStripMenuItem
            toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
            mnuAddLink = New System.Windows.Forms.ToolStripMenuItem
            mnuValidLink = New System.Windows.Forms.ToolStripMenuItem
            mnuInvalidLink = New System.Windows.Forms.ToolStripMenuItem
            toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
            mnuIMDB = New System.Windows.Forms.ToolStripMenuItem
            toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
            mnuSubtitlePreview = New System.Windows.Forms.ToolStripMenuItem
            mnuNFO = New System.Windows.Forms.ToolStripMenuItem
            mnuProperties = New System.Windows.Forms.ToolStripMenuItem
            mnuImportSubtitle = New System.Windows.Forms.ToolStripMenuItem
            mnuPrimarySubDbInfo = New System.Windows.Forms.ToolStripMenuItem
            mnuPluginInfo = New System.Windows.Forms.ToolStripMenuItem
            cmsFilterLanguage = New System.Windows.Forms.ContextMenuStrip(components)
            cmsFilterGenre = New System.Windows.Forms.ContextMenuStrip(components)
            cmsRate = New System.Windows.Forms.ContextMenuStrip(components)
            ttTitleOK = New System.Windows.Forms.ToolTip(components)
            ttTitleNOK = New System.Windows.Forms.ToolTip(components)
            cmsRibbonRate = New System.Windows.Forms.ContextMenuStrip(components)
            panel1.SuspendLayout()
            panel2.SuspendLayout()
            panelSearchTop.SuspendLayout()
            groupBox3.SuspendLayout()
            pictureBox3.BeginInit()
            panelSearchTopCriteria.SuspendLayout()
            groupBox2.SuspendLayout()
            pictureBox2.BeginInit()
            groupBox1.SuspendLayout()
            pbMovieInfo.BeginInit()
            pictureBox1.BeginInit()
            contextMenuStrip1.SuspendLayout()
            SuspendLayout()
            panel1.Controls.Add(btnFeelingLucky)
            panel1.Controls.Add(tcSearchInfo)
            panel1.Controls.Add(panel2)
            panel1.Controls.Add(panelSearchTop)
            panel1.Controls.Add(btnSearchLinked)
            panel1.Dock = System.Windows.Forms.DockStyle.Top
            panel1.Location = New System.Drawing.Point(0, 0)
            panel1.Name = "panel1?"
            panel1.Padding = New System.Windows.Forms.Padding(5, 5, 5, 0)
            panel1.Size = New System.Drawing.Size(1301, 218)
            panel1.TabIndex = 8
            btnFeelingLucky.AutoResize = False
            btnFeelingLucky.Id = "082c192a-28ac-4dcb-a308-264e955c60f8?"
            btnFeelingLucky.Image = Nothing
            btnFeelingLucky.Location = New System.Drawing.Point(111, 182)
            btnFeelingLucky.Name = "btnFeelingLucky?"
            btnFeelingLucky.Size = New System.Drawing.Size(100, 30)
            btnFeelingLucky.TabIndex = 135
            btnFeelingLucky.Text = "I'm Feeling Lucky?"
            btnFeelingLucky.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnFeelingLucky.UseVisualStyleBackColor = True
            btnFeelingLucky.Visible = False
            AddHandler btnFeelingLucky.Click, AddressOf btnFeelingLucky_Click
            tcSearchInfo.BackColor = System.Drawing.SystemColors.Control
            tcSearchInfo.Location = New System.Drawing.Point(300, 186)
            tcSearchInfo.Name = "tcSearchInfo?"
            tcSearchInfo.Padding = New System.Windows.Forms.Padding(3, 3, 10, 3)
            tcSearchInfo.Size = New System.Drawing.Size(225, 23)
            tcSearchInfo.TabIndex = 134
            tcSearchInfo.Visible = False
            panel2.Controls.Add(label6)
            panel2.Controls.Add(lblSubtitleUnlinked)
            panel2.Controls.Add(label4)
            panel2.Controls.Add(lblSubtitleLinked)
            panel2.Dock = System.Windows.Forms.DockStyle.Right
            panel2.Location = New System.Drawing.Point(1114, 179)
            panel2.Name = "panel2?"
            panel2.Size = New System.Drawing.Size(182, 39)
            panel2.TabIndex = 131
            label6.AutoSize = True
            label6.LegendText = "podnapis še ni povezan?"
            label6.Location = New System.Drawing.Point(45, 19)
            label6.Name = "label6?"
            label6.Size = New System.Drawing.Size(134, 13)
            label6.TabIndex = 3
            lblSubtitleUnlinked.BackColor = System.Drawing.Color.White
            lblSubtitleUnlinked.Location = New System.Drawing.Point(5, 19)
            lblSubtitleUnlinked.Name = "lblSubtitleUnlinked?"
            lblSubtitleUnlinked.Size = New System.Drawing.Size(37, 14)
            lblSubtitleUnlinked.TabIndex = 2
            label4.AutoSize = True
            label4.LegendText = "podnapis je povezan?"
            label4.Location = New System.Drawing.Point(45, 3)
            label4.Name = "label4?"
            label4.Size = New System.Drawing.Size(134, 13)
            label4.TabIndex = 1
            lblSubtitleLinked.BackColor = System.Drawing.Color.Green
            lblSubtitleLinked.Location = New System.Drawing.Point(5, 3)
            lblSubtitleLinked.Name = "lblSubtitleLinked?"
            lblSubtitleLinked.Size = New System.Drawing.Size(37, 14)
            lblSubtitleLinked.TabIndex = 0
            panelSearchTop.Controls.Add(groupBox3)
            panelSearchTop.Controls.Add(panelSearchCriteriaSearchFilterSeparator)
            panelSearchTop.Controls.Add(panelSearchTopCriteria)
            panelSearchTop.Dock = System.Windows.Forms.DockStyle.Top
            panelSearchTop.Location = New System.Drawing.Point(5, 5)
            panelSearchTop.Name = "panelSearchTop?"
            panelSearchTop.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
            panelSearchTop.Size = New System.Drawing.Size(1291, 174)
            panelSearchTop.TabIndex = 130
            groupBox3.Controls.Add(btnRate)
            groupBox3.Controls.Add(btnLanguage)
            groupBox3.Controls.Add(txtFilterMediaCount)
            groupBox3.Controls.Add(label8)
            groupBox3.Controls.Add(ttSearchResultsFilter)
            groupBox3.Controls.Add(pictureBox3)
            groupBox3.Controls.Add(label11)
            groupBox3.Controls.Add(txtFilterSender)
            groupBox3.Controls.Add(label10)
            groupBox3.Controls.Add(label3)
            groupBox3.Dock = System.Windows.Forms.DockStyle.Fill
            groupBox3.DrawTextBackground = True
            groupBox3.Location = New System.Drawing.Point(570, 0)
            groupBox3.Name = "groupBox3?"
            groupBox3.Size = New System.Drawing.Size(721, 172)
            groupBox3.TabIndex = 2
            groupBox3.TabStop = False
            groupBox3.Text = "Filtriranje zadetkov?"
            btnRate.AutoResize = False
            btnRate.Id = "00b7948f-c9bd-454f-9d27-ab2ec69c3558?"
            btnRate.Image = Sublight.Properties.Resources.BtnIconDropDown
            btnRate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            btnRate.Location = New System.Drawing.Point(125, 46)
            btnRate.Name = "btnRate?"
            btnRate.Padding = New System.Windows.Forms.Padding(6, 3, 3, 3)
            btnRate.Size = New System.Drawing.Size(150, 23)
            Dim controlImageArr1 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown) }
            btnRate.SmallImages.Images.AddRange(controlImageArr1)
            btnRate.TabIndex = 1002
            btnRate.Text = "Ocena?"
            btnRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnRate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
            btnRate.UseVisualStyleBackColor = True
            AddHandler btnRate.Click, AddressOf btnRate_Click
            btnLanguage.AutoResize = False
            btnLanguage.Id = "7fc8929d-c8cd-4e9f-8af7-eed2d0de6dbf?"
            btnLanguage.Image = Sublight.Properties.Resources.BtnIconDropDown
            btnLanguage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            btnLanguage.Location = New System.Drawing.Point(125, 19)
            btnLanguage.Name = "btnLanguage?"
            btnLanguage.Padding = New System.Windows.Forms.Padding(6, 3, 3, 3)
            btnLanguage.Size = New System.Drawing.Size(150, 23)
            Dim controlImageArr2 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown) }
            btnLanguage.SmallImages.Images.AddRange(controlImageArr2)
            btnLanguage.TabIndex = 1000
            btnLanguage.Text = "Jezik?"
            btnLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnLanguage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
            btnLanguage.UseVisualStyleBackColor = True
            AddHandler btnLanguage.Click, AddressOf btnLanguage_Click
            txtFilterMediaCount.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtFilterMediaCount.EnableDisableColor = True
            txtFilterMediaCount.Id = "f8e3f8a0-1add-4988-9962-e249fb540b9d?"
            txtFilterMediaCount.Location = New System.Drawing.Point(125, 100)
            txtFilterMediaCount.Name = "txtFilterMediaCount?"
            txtFilterMediaCount.Size = New System.Drawing.Size(30, 21)
            txtFilterMediaCount.TabIndex = 1004
            label8.AutoSize = True
            label8.Location = New System.Drawing.Point(47, 104)
            label8.Name = "label8?"
            label8.Size = New System.Drawing.Size(62, 13)
            label8.TabIndex = 138
            label8.Text = "Št. medijev:?"
            ttSearchResultsFilter.AutoPopDelay = 5000
            ttSearchResultsFilter.BackColor = System.Drawing.Color.Transparent
            ttSearchResultsFilter.Location = New System.Drawing.Point(300, 16)
            ttSearchResultsFilter.Name = "ttSearchResultsFilter?"
            ttSearchResultsFilter.Size = New System.Drawing.Size(13, 12)
            ttSearchResultsFilter.TabIndex = 134
            ttSearchResultsFilter.Title = Sublight.Translation.ContactUs_Message_PreferredLanguage
            pictureBox3.Image = Sublight.Properties.Resources.SearchFilter
            pictureBox3.Location = New System.Drawing.Point(9, 19)
            pictureBox3.Name = "pictureBox3?"
            pictureBox3.Size = New System.Drawing.Size(32, 32)
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox3.TabIndex = 133
            pictureBox3.TabStop = False
            label11.AutoSize = True
            label11.Location = New System.Drawing.Point(47, 51)
            label11.Name = "label11?"
            label11.Size = New System.Drawing.Size(42, 13)
            label11.TabIndex = 23
            label11.Text = "Ocena:?"
            txtFilterSender.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtFilterSender.EnableDisableColor = True
            txtFilterSender.Id = "bdcb662b-0a7e-4d0c-8b3a-e076b7f9c55d?"
            txtFilterSender.Location = New System.Drawing.Point(125, 73)
            txtFilterSender.Name = "txtFilterSender?"
            txtFilterSender.Size = New System.Drawing.Size(150, 21)
            txtFilterSender.TabIndex = 1003
            label10.AutoSize = True
            label10.Location = New System.Drawing.Point(47, 78)
            label10.Name = "label10?"
            label10.Size = New System.Drawing.Size(53, 13)
            label10.TabIndex = 21
            label10.Text = "Pošiljatelj:?"
            label3.AutoSize = True
            label3.Location = New System.Drawing.Point(47, 24)
            label3.Name = "label3?"
            label3.Size = New System.Drawing.Size(34, 13)
            label3.TabIndex = 0
            label3.Text = "Jezik:?"
            panelSearchCriteriaSearchFilterSeparator.Dock = System.Windows.Forms.DockStyle.Left
            panelSearchCriteriaSearchFilterSeparator.Location = New System.Drawing.Point(550, 0)
            panelSearchCriteriaSearchFilterSeparator.Name = "panelSearchCriteriaSearchFilterSeparator?"
            panelSearchCriteriaSearchFilterSeparator.Size = New System.Drawing.Size(20, 172)
            panelSearchCriteriaSearchFilterSeparator.TabIndex = 1
            panelSearchTopCriteria.Controls.Add(groupBox2)
            panelSearchTopCriteria.Controls.Add(panel4)
            panelSearchTopCriteria.Controls.Add(groupBox1)
            panelSearchTopCriteria.Dock = System.Windows.Forms.DockStyle.Left
            panelSearchTopCriteria.Location = New System.Drawing.Point(0, 0)
            panelSearchTopCriteria.Name = "panelSearchTopCriteria?"
            panelSearchTopCriteria.Size = New System.Drawing.Size(550, 172)
            panelSearchTopCriteria.TabIndex = 0
            groupBox2.Controls.Add(lblTipSuggest)
            groupBox2.Controls.Add(btnSuggest)
            groupBox2.Controls.Add(ttSearchManual)
            groupBox2.Controls.Add(pictureBox2)
            groupBox2.Controls.Add(txtEpisode)
            groupBox2.Controls.Add(txtSeason)
            groupBox2.Controls.Add(lblEpisode)
            groupBox2.Controls.Add(lblSeason)
            groupBox2.Controls.Add(txtYear)
            groupBox2.Controls.Add(label2)
            groupBox2.Controls.Add(txtTitle)
            groupBox2.Controls.Add(label1)
            groupBox2.Dock = System.Windows.Forms.DockStyle.Top
            groupBox2.DrawTextBackground = True
            groupBox2.Location = New System.Drawing.Point(0, 100)
            groupBox2.Name = "groupBox2?"
            groupBox2.Size = New System.Drawing.Size(550, 73)
            groupBox2.TabIndex = 129
            groupBox2.TabStop = False
            groupBox2.Text = "Kriteriji za rocno iskanje?"
            lblTipSuggest.AutoSize = True
            lblTipSuggest.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblTipSuggest.Location = New System.Drawing.Point(510, 23)
            lblTipSuggest.Name = "lblTipSuggest?"
            lblTipSuggest.Size = New System.Drawing.Size(65, 13)
            lblTipSuggest.TabIndex = 197
            lblTipSuggest.Text = "Ctrl + Space?"
            lblTipSuggest.Visible = False
            btnSuggest.AutoResize = False
            btnSuggest.ContextMenuStrip = cmsSuggestTitle
            btnSuggest.Id = "609ede1f-1e3d-4321-8784-45b9db172535?"
            btnSuggest.Image = Sublight.Properties.Resources.BtnIconDropDown
            btnSuggest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            btnSuggest.Location = New System.Drawing.Point(427, 18)
            btnSuggest.Name = "btnSuggest?"
            btnSuggest.Padding = New System.Windows.Forms.Padding(6, 3, 3, 3)
            btnSuggest.Size = New System.Drawing.Size(75, 23)
            Dim controlImageArr3 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.BtnIconDropDown) }
            btnSuggest.SmallImages.Images.AddRange(controlImageArr3)
            btnSuggest.TabIndex = 15
            btnSuggest.Text = "Predlagaj?"
            btnSuggest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnSuggest.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
            btnSuggest.UseVisualStyleBackColor = True
            AddHandler btnSuggest.Click, AddressOf btnSuggest_Click
            cmsSuggestTitle.Name = "cmsSuggestTitle?"
            cmsSuggestTitle.ShowImageMargin = False
            cmsSuggestTitle.Size = New System.Drawing.Size(36, 4)
            AddHandler cmsSuggestTitle.Closed, AddressOf cmsSuggestTitle_Closed
            AddHandler cmsSuggestTitle.ItemClicked, AddressOf cmsSuggestTitle_ItemClicked
            ttSearchManual.AutoPopDelay = 5000
            ttSearchManual.BackColor = System.Drawing.Color.Transparent
            ttSearchManual.Location = New System.Drawing.Point(534, 16)
            ttSearchManual.Name = "ttSearchManual?"
            ttSearchManual.Size = New System.Drawing.Size(13, 12)
            ttSearchManual.TabIndex = 133
            ttSearchManual.Title = Sublight.Translation.ContactUs_Message_PreferredLanguage
            pictureBox2.Image = Sublight.Properties.Resources.SearchManual
            pictureBox2.Location = New System.Drawing.Point(9, 19)
            pictureBox2.Name = "pictureBox2?"
            pictureBox2.Size = New System.Drawing.Size(32, 32)
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox2.TabIndex = 132
            pictureBox2.TabStop = False
            txtEpisode.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtEpisode.EnableDisableColor = True
            txtEpisode.Id = "4fe3fe8b-39df-4ff5-8a34-34fb8470c826?"
            txtEpisode.Location = New System.Drawing.Point(391, 43)
            txtEpisode.Name = "txtEpisode?"
            txtEpisode.Size = New System.Drawing.Size(30, 21)
            txtEpisode.TabIndex = 18
            txtSeason.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtSeason.EnableDisableColor = True
            txtSeason.Id = "136e3a50-fc5a-473b-96d5-2e0a0c1bfed3?"
            txtSeason.Location = New System.Drawing.Point(309, 42)
            txtSeason.Name = "txtSeason?"
            txtSeason.Size = New System.Drawing.Size(22, 21)
            txtSeason.TabIndex = 17
            lblEpisode.AutoSize = True
            lblEpisode.Location = New System.Drawing.Point(337, 46)
            lblEpisode.Name = "lblEpisode?"
            lblEpisode.Size = New System.Drawing.Size(48, 13)
            lblEpisode.TabIndex = 131
            lblEpisode.Text = "Epizoda:?"
            lblSeason.AutoSize = True
            lblSeason.Location = New System.Drawing.Point(245, 46)
            lblSeason.Name = "lblSeason?"
            lblSeason.Size = New System.Drawing.Size(46, 13)
            lblSeason.TabIndex = 130
            lblSeason.Text = "Sezona:?"
            txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtYear.EnableDisableColor = True
            txtYear.Id = "58487d28-0a22-4e9a-959b-b2d4416184f4?"
            txtYear.Location = New System.Drawing.Point(145, 43)
            txtYear.Name = "txtYear?"
            txtYear.Size = New System.Drawing.Size(49, 21)
            txtYear.TabIndex = 16
            label2.Location = New System.Drawing.Point(47, 41)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(92, 21)
            label2.TabIndex = 15
            label2.Text = "Leto:?"
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            txtTitle.BannerText = Sublight.Translation.ContactUs_Message_PreferredLanguage
            txtTitle.Id = "7267733c-1cd9-48d2-9ae3-895841258ce6?"
            txtTitle.Location = New System.Drawing.Point(145, 19)
            txtTitle.Name = "txtTitle?"
            txtTitle.PromptText = Sublight.Translation.ContactUs_Message_PreferredLanguage
            txtTitle.Size = New System.Drawing.Size(276, 21)
            txtTitle.TabIndex = 14
            AddHandler txtTitle.Enter, AddressOf txtTitle_Enter
            AddHandler txtTitle.Leave, AddressOf txtTitle_Leave
            label1.Location = New System.Drawing.Point(47, 18)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(92, 21)
            label1.TabIndex = 13
            label1.Text = "Naslov:?"
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            panel4.Dock = System.Windows.Forms.DockStyle.Top
            panel4.Location = New System.Drawing.Point(0, 100)
            panel4.Name = "panel4?"
            panel4.Size = New System.Drawing.Size(550, 0)
            panel4.TabIndex = 132
            panel4.Visible = False
            groupBox1.Controls.Add(pbMovieInfo)
            groupBox1.Controls.Add(btnTitleNOK)
            groupBox1.Controls.Add(btnTitleOK)
            groupBox1.Controls.Add(lblDetectedTitle)
            groupBox1.Controls.Add(txtDetectedTitle)
            groupBox1.Controls.Add(ttSearchByHash)
            groupBox1.Controls.Add(pictureBox1)
            groupBox1.Controls.Add(cbAutoFillTitle)
            groupBox1.Controls.Add(btnSearchLinkedOpenFile)
            groupBox1.Controls.Add(txtSearchLinkedFile)
            groupBox1.Controls.Add(label5)
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top
            groupBox1.DrawTextBackground = True
            groupBox1.Location = New System.Drawing.Point(0, 0)
            groupBox1.Name = "groupBox1?"
            groupBox1.Size = New System.Drawing.Size(550, 100)
            groupBox1.TabIndex = 127
            groupBox1.TabStop = False
            groupBox1.Text = "Kriteriji za samodejno iskanje?"
            pbMovieInfo.Location = New System.Drawing.Point(427, 71)
            pbMovieInfo.Name = "pbMovieInfo?"
            pbMovieInfo.Size = New System.Drawing.Size(46, 18)
            pbMovieInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pbMovieInfo.TabIndex = 23
            pbMovieInfo.TabStop = False
            pbMovieInfo.Visible = False
            btnTitleNOK.AutoResize = False
            btnTitleNOK.Id = "a149da43-4935-4093-82f5-488030fa0654?"
            btnTitleNOK.Image = Sublight.Properties.Resources.IconNOK
            btnTitleNOK.Location = New System.Drawing.Point(466, 42)
            btnTitleNOK.Name = "btnTitleNOK?"
            btnTitleNOK.Size = New System.Drawing.Size(36, 23)
            Dim controlImageArr4 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconNOK), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconNOK), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconNOK), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconNOK), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconNOK) }
            btnTitleNOK.SmallImages.Images.AddRange(controlImageArr4)
            btnTitleNOK.TabIndex = 22
            btnTitleNOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnTitleNOK.UseVisualStyleBackColor = True
            AddHandler btnTitleNOK.Click, AddressOf btnTitleNOK_Click
            btnTitleOK.AutoResize = False
            btnTitleOK.Id = "a3c378c2-d7a1-4e03-98fc-e0e505e4b146?"
            btnTitleOK.Image = Sublight.Properties.Resources.IconOK
            btnTitleOK.Location = New System.Drawing.Point(427, 42)
            btnTitleOK.Name = "btnTitleOK?"
            btnTitleOK.Size = New System.Drawing.Size(36, 23)
            Dim controlImageArr5 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconOK), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconOK), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconOK), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconOK), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconOK) }
            btnTitleOK.SmallImages.Images.AddRange(controlImageArr5)
            btnTitleOK.TabIndex = 21
            btnTitleOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnTitleOK.UseVisualStyleBackColor = True
            AddHandler btnTitleOK.Click, AddressOf btnTitleOK_Click
            lblDetectedTitle.Location = New System.Drawing.Point(47, 43)
            lblDetectedTitle.Name = "lblDetectedTitle?"
            lblDetectedTitle.Size = New System.Drawing.Size(92, 21)
            lblDetectedTitle.TabIndex = 20
            lblDetectedTitle.Text = "Zaznan naslov:?"
            lblDetectedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            txtDetectedTitle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtDetectedTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtDetectedTitle.EnableDisableColor = True
            txtDetectedTitle.Id = "2f10879b-4846-484b-9c2c-9eec088d81f7?"
            txtDetectedTitle.Location = New System.Drawing.Point(145, 43)
            txtDetectedTitle.Name = "txtDetectedTitle?"
            txtDetectedTitle.ReadOnly = True
            txtDetectedTitle.Size = New System.Drawing.Size(276, 21)
            txtDetectedTitle.TabIndex = 19
            ttSearchByHash.AutoPopDelay = 5000
            ttSearchByHash.BackColor = System.Drawing.Color.Transparent
            ttSearchByHash.Location = New System.Drawing.Point(534, 16)
            ttSearchByHash.Name = "ttSearchByHash?"
            ttSearchByHash.Size = New System.Drawing.Size(13, 12)
            ttSearchByHash.TabIndex = 18
            ttSearchByHash.Title = Sublight.Translation.ContactUs_Message_PreferredLanguage
            pictureBox1.Image = Sublight.Properties.Resources.SearchAuto
            pictureBox1.Location = New System.Drawing.Point(9, 19)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(32, 32)
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox1.TabIndex = 17
            pictureBox1.TabStop = False
            cbAutoFillTitle.Id = "6145a7ae-e120-42c6-b2bc-74088dce9ae8?"
            cbAutoFillTitle.Location = New System.Drawing.Point(145, 72)
            cbAutoFillTitle.Name = "cbAutoFillTitle?"
            cbAutoFillTitle.Size = New System.Drawing.Size(276, 26)
            cbAutoFillTitle.TabIndex = 16
            cbAutoFillTitle.Text = "Samodejno izpolni naslov za rocno iskanje?"
            cbAutoFillTitle.UseVisualStyleBackColor = True
            btnSearchLinkedOpenFile.AutoResize = False
            btnSearchLinkedOpenFile.Id = "bb960960-190f-48fe-bb1a-33ca6fbcf749?"
            btnSearchLinkedOpenFile.Image = Nothing
            btnSearchLinkedOpenFile.Location = New System.Drawing.Point(427, 18)
            btnSearchLinkedOpenFile.Name = "btnSearchLinkedOpenFile?"
            btnSearchLinkedOpenFile.Size = New System.Drawing.Size(75, 23)
            btnSearchLinkedOpenFile.TabIndex = 14
            btnSearchLinkedOpenFile.Text = "Izberi...?"
            btnSearchLinkedOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnSearchLinkedOpenFile.UseVisualStyleBackColor = True
            txtSearchLinkedFile.BannerText = Sublight.Translation.ContactUs_Message_PreferredLanguage
            txtSearchLinkedFile.Id = "5135c085-3ec3-42ec-bb37-dba2cc736088?"
            txtSearchLinkedFile.Location = New System.Drawing.Point(145, 19)
            txtSearchLinkedFile.Name = "txtSearchLinkedFile?"
            txtSearchLinkedFile.PromptText = Sublight.Translation.ContactUs_Message_PreferredLanguage
            txtSearchLinkedFile.Size = New System.Drawing.Size(276, 21)
            txtSearchLinkedFile.TabIndex = 13
            AddHandler txtSearchLinkedFile.Leave, AddressOf txtSearchLinkedFile_Leave
            label5.Location = New System.Drawing.Point(47, 19)
            label5.Name = "label5?"
            label5.Size = New System.Drawing.Size(92, 21)
            label5.TabIndex = 12
            label5.Text = "Video datoteka:?"
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnSearchLinked.AutoResize = False
            btnSearchLinked.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnSearchLinked.Id = "b6690fbb-3630-4739-91c8-3dcd07903386?"
            btnSearchLinked.Image = Sublight.Properties.Resources.ToolbarSearch
            btnSearchLinked.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnSearchLinked.Location = New System.Drawing.Point(5, 182)
            btnSearchLinked.Name = "btnSearchLinked?"
            btnSearchLinked.Size = New System.Drawing.Size(100, 30)
            Dim controlImageArr6 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.ToolbarSearch), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.ToolbarSearch), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.ToolbarSearch), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.ToolbarSearch), _
                                                                                                New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.ToolbarSearch) }
            btnSearchLinked.SmallImages.Images.AddRange(controlImageArr6)
            btnSearchLinked.TabIndex = 125
            btnSearchLinked.Text = "Išci?"
            btnSearchLinked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnSearchLinked.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnSearchLinked.UseVisualStyleBackColor = True
            AddHandler btnSearchLinked.Click, AddressOf btnSearchLinked_Click
            lvSearchResults.AllowDrop = True
            lvSearchResults.AllowRowDragDrop = False
            lvSearchResults.AllowSorting = True
            lvSearchResults.AlternatingRowColor = System.Drawing.Color.FromArgb(242, 248, 254)
            lvSearchResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            lvSearchResults.ContextMenuStrip = contextMenuStrip1
            lvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill
            lvSearchResults.FocusedItem = Nothing
            lvSearchResults.GroupSectionFont = Nothing
            lvSearchResults.GroupSectionForeColor = System.Drawing.SystemColors.WindowText
            lvSearchResults.GroupSectionTextPlural = "Items?"
            lvSearchResults.GroupSectionTextSingular = "Item?"
            lvSearchResults.GroupSectionVerticalAlignment = BinaryComponents.WinFormsUtility.Drawing.GdiPlusEx.VAlignment.Top
            lvSearchResults.IndentColor = System.Drawing.Color.LightGoldenrodYellow
            lvSearchResults.Location = New System.Drawing.Point(0, 218)
            lvSearchResults.MultiSelect = True
            lvSearchResults.Name = "lvSearchResults?"
            lvSearchResults.SectionFactory = mySectionFactory1
            lvSearchResults.SeparatorColor = System.Drawing.Color.FromArgb(123, 164, 224)
            lvSearchResults.ShowCustomizeSection = False
            lvSearchResults.ShowHeaderSection = True
            lvSearchResults.Size = New System.Drawing.Size(1301, 272)
            lvSearchResults.TabIndex = 9
            contextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
            Dim toolStripItemArr1 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       mnuPlay, _
                                                                                                                       mnuDownload, _
                                                                                                                       mnuPluginSubtitleActions, _
                                                                                                                       mnuAddRelease, _
                                                                                                                       mnuAddAlternativeTitle, _
                                                                                                                       mnuReportSubtitle, _
                                                                                                                       mnuEdit, _
                                                                                                                       mnuDelete, _
                                                                                                                       toolStripSeparator3, _
                                                                                                                       mnuRate, _
                                                                                                                       toolStripSeparator4, _
                                                                                                                       mnuSearchAllMovieSubtitles, _
                                                                                                                       mnuSearchAllSubtitlesForThisPublisher, _
                                                                                                                       toolStripSeparator8, _
                                                                                                                       mnuAddLink, _
                                                                                                                       mnuValidLink, _
                                                                                                                       mnuInvalidLink, _
                                                                                                                       toolStripSeparator5, _
                                                                                                                       mnuIMDB, _
                                                                                                                       toolStripSeparator7, _
                                                                                                                       mnuSubtitlePreview, _
                                                                                                                       mnuNFO, _
                                                                                                                       mnuProperties, _
                                                                                                                       mnuImportSubtitle, _
                                                                                                                       mnuPrimarySubDbInfo, _
                                                                                                                       mnuPluginInfo }
            contextMenuStrip1.Items.AddRange(toolStripItemArr1)
            contextMenuStrip1.Name = "contextMenuStrip1?"
            contextMenuStrip1.Size = New System.Drawing.Size(323, 580)
            AddHandler contextMenuStrip1.Opening, AddressOf contextMenuStrip1_Opening
            mnuPlay.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            mnuPlay.Image = Sublight.Properties.Resources.ToolbarPlaySmall
            mnuPlay.Name = "mnuPlay?"
            mnuPlay.Size = New System.Drawing.Size(322, 26)
            mnuPlay.Text = "Predvajaj?"
            AddHandler mnuPlay.Click, AddressOf mnuPlay_Click
            mnuDownload.Image = Sublight.Properties.Resources.ToolbarDownloadSmall
            mnuDownload.Name = "mnuDownload?"
            mnuDownload.Size = New System.Drawing.Size(322, 26)
            mnuDownload.Text = "Prenos?"
            AddHandler mnuDownload.Click, AddressOf mnuDownload_Click
            mnuPluginSubtitleActions.Name = "mnuPluginSubtitleActions?"
            mnuPluginSubtitleActions.Size = New System.Drawing.Size(322, 26)
            mnuPluginSubtitleActions.Text = "Vec?"
            mnuAddRelease.Name = "mnuAddRelease?"
            mnuAddRelease.Size = New System.Drawing.Size(322, 26)
            mnuAddRelease.Text = "Dodaj razlicico...?"
            AddHandler mnuAddRelease.Click, AddressOf mnuAddRelease_Click
            mnuAddAlternativeTitle.Name = "mnuAddAlternativeTitle?"
            mnuAddAlternativeTitle.Size = New System.Drawing.Size(322, 26)
            mnuAddAlternativeTitle.Text = "Dodaj alternativni naslov...?"
            mnuReportSubtitle.Image = Sublight.Properties.Resources.ToolbarReportSmall
            mnuReportSubtitle.Name = "mnuReportSubtitle?"
            mnuReportSubtitle.Size = New System.Drawing.Size(322, 26)
            mnuReportSubtitle.Text = "Prijava neustreznega podnapisa?"
            AddHandler mnuReportSubtitle.Click, AddressOf mnuReportSubtitle_Click
            mnuEdit.Image = Sublight.Properties.Resources.ToolbarEditSmall
            mnuEdit.Name = "mnuEdit?"
            mnuEdit.Size = New System.Drawing.Size(322, 26)
            mnuEdit.Text = "Edit...?"
            AddHandler mnuEdit.Click, AddressOf mnuEdit_Click
            mnuDelete.Image = Sublight.Properties.Resources.ToolbarDeleteSmall
            mnuDelete.Name = "mnuDelete?"
            mnuDelete.Size = New System.Drawing.Size(322, 26)
            mnuDelete.Text = "Izbriši?"
            AddHandler mnuDelete.Click, AddressOf mnuDelete_Click
            toolStripSeparator3.Name = "toolStripSeparator3?"
            toolStripSeparator3.Size = New System.Drawing.Size(319, 6)
            Dim toolStripItemArr2 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       mnuRateVal1, _
                                                                                                                       mnuRateVal2, _
                                                                                                                       mnuRateVal3, _
                                                                                                                       mnuRateVal4, _
                                                                                                                       mnuRateVal5 }
            mnuRate.DropDownItems.AddRange(toolStripItemArr2)
            mnuRate.Name = "mnuRate?"
            mnuRate.Size = New System.Drawing.Size(322, 26)
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
            toolStripSeparator4.Name = "toolStripSeparator4?"
            toolStripSeparator4.Size = New System.Drawing.Size(319, 6)
            mnuSearchAllMovieSubtitles.Name = "mnuSearchAllMovieSubtitles?"
            mnuSearchAllMovieSubtitles.Size = New System.Drawing.Size(322, 26)
            mnuSearchAllMovieSubtitles.Text = "Najdi vse podnapise za ta film?"
            AddHandler mnuSearchAllMovieSubtitles.Click, AddressOf mnuSearchAllMovieSubtitles_Click
            mnuSearchAllSubtitlesForThisPublisher.Name = "mnuSearchAllSubtitlesForThisPublisher?"
            mnuSearchAllSubtitlesForThisPublisher.Size = New System.Drawing.Size(322, 26)
            mnuSearchAllSubtitlesForThisPublisher.Text = "Najdi vse podnapise tega pošiljatelja?"
            AddHandler mnuSearchAllSubtitlesForThisPublisher.Click, AddressOf mnuSearchAllSubtitlesForThisPublisher_Click
            toolStripSeparator8.Name = "toolStripSeparator8?"
            toolStripSeparator8.Size = New System.Drawing.Size(319, 6)
            mnuAddLink.Image = Sublight.Properties.Resources.ToolbarAddLinkSmall
            mnuAddLink.Name = "mnuAddLink?"
            mnuAddLink.Size = New System.Drawing.Size(322, 26)
            mnuAddLink.Text = "Dodaj povezavo?"
            AddHandler mnuAddLink.Click, AddressOf mnuAddLink_Click
            mnuValidLink.Image = Sublight.Properties.Resources.ToolbarConfirmLinkSmall
            mnuValidLink.Name = "mnuValidLink?"
            mnuValidLink.Size = New System.Drawing.Size(322, 26)
            mnuValidLink.Text = "Veljavna povezava?"
            AddHandler mnuValidLink.Click, AddressOf mnuValidLink_Click
            mnuInvalidLink.Image = Sublight.Properties.Resources.ToolbarReportLinkSmall
            mnuInvalidLink.Name = "mnuInvalidLink?"
            mnuInvalidLink.Size = New System.Drawing.Size(322, 26)
            mnuInvalidLink.Text = "Napacna povezava?"
            AddHandler mnuInvalidLink.Click, AddressOf mnuInvalidLink_Click
            toolStripSeparator5.Name = "toolStripSeparator5?"
            toolStripSeparator5.Size = New System.Drawing.Size(319, 6)
            mnuIMDB.Image = Sublight.Properties.Resources.ToolbarIMDB
            mnuIMDB.Name = "mnuIMDB?"
            mnuIMDB.Size = New System.Drawing.Size(322, 26)
            mnuIMDB.Text = "IMDb?"
            AddHandler mnuIMDB.Click, AddressOf mnuIMDB_Click
            toolStripSeparator7.Name = "toolStripSeparator7?"
            toolStripSeparator7.Size = New System.Drawing.Size(319, 6)
            mnuSubtitlePreview.Image = Sublight.Properties.Resources.ToolbarSearch
            mnuSubtitlePreview.Name = "mnuSubtitlePreview?"
            mnuSubtitlePreview.Size = New System.Drawing.Size(322, 26)
            mnuSubtitlePreview.Text = "Predogled podnapisa?"
            AddHandler mnuSubtitlePreview.Click, AddressOf mnuSubtitlePreview_Click
            mnuNFO.Image = Sublight.Properties.Resources.ToolbarNFO
            mnuNFO.Name = "mnuNFO?"
            mnuNFO.Size = New System.Drawing.Size(322, 26)
            mnuNFO.Text = ".NFO?"
            AddHandler mnuNFO.Click, AddressOf mnuNFO_Click
            mnuProperties.Image = Sublight.Properties.Resources.ToolbarDetailsMedium
            mnuProperties.Name = "mnuProperties?"
            mnuProperties.Size = New System.Drawing.Size(322, 26)
            mnuProperties.Text = "Lastnosti?"
            AddHandler mnuProperties.Click, AddressOf mnuProperties_Click
            mnuImportSubtitle.Image = Sublight.Properties.Resources.ToolbarPublishSmall
            mnuImportSubtitle.Name = "mnuImportSubtitle?"
            mnuImportSubtitle.Size = New System.Drawing.Size(322, 26)
            mnuImportSubtitle.Text = "Uvozi podnapis v primarno bazo podnapisov...?"
            AddHandler mnuImportSubtitle.Click, AddressOf mnuImportSubtitle_Click
            mnuPrimarySubDbInfo.Image = Sublight.Properties.Resources.ToolbarQuestionSmall
            mnuPrimarySubDbInfo.Name = "mnuPrimarySubDbInfo?"
            mnuPrimarySubDbInfo.Size = New System.Drawing.Size(322, 26)
            mnuPrimarySubDbInfo.Text = "Kaj je primarna baza podnapisov??"
            AddHandler mnuPrimarySubDbInfo.Click, AddressOf mnuPrimarySubDbInfo_Click
            mnuPluginInfo.Image = Sublight.Properties.Resources.ToolbarPluginSmall
            mnuPluginInfo.Name = "mnuPluginInfo?"
            mnuPluginInfo.Size = New System.Drawing.Size(322, 26)
            mnuPluginInfo.Text = "Informacije o vticniku...?"
            AddHandler mnuPluginInfo.Click, AddressOf mnuPluginInfo_Click
            cmsFilterLanguage.Name = "cmsFilterLanguage?"
            cmsFilterLanguage.Size = New System.Drawing.Size(61, 4)
            cmsFilterGenre.Name = "cmsFilterLanguage?"
            cmsFilterGenre.Size = New System.Drawing.Size(61, 4)
            cmsRate.Name = "cmsFilterLanguage?"
            cmsRate.Size = New System.Drawing.Size(61, 4)
            cmsRibbonRate.Name = "cmsRibbonRate?"
            cmsRibbonRate.ShowImageMargin = False
            cmsRibbonRate.Size = New System.Drawing.Size(36, 4)
            AllowDrop = True
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.SystemColors.Control
            Controls.Add(lvSearchResults)
            Controls.Add(panel1)
            Name = "PageSearch?"
            Size = New System.Drawing.Size(1301, 490)
            AddHandler Load, AddressOf PageSearchLinked_Load
            AddHandler DragDrop, AddressOf PageSearch_DragDrop
            AddHandler DragEnter, AddressOf PageSearch_DragEnter
            panel1.ResumeLayout(False)
            panel2.ResumeLayout(False)
            panel2.PerformLayout()
            panelSearchTop.ResumeLayout(False)
            groupBox3.ResumeLayout(False)
            groupBox3.PerformLayout()
            pictureBox3.EndInit()
            panelSearchTopCriteria.ResumeLayout(False)
            groupBox2.ResumeLayout(False)
            groupBox2.PerformLayout()
            pictureBox2.EndInit()
            groupBox1.ResumeLayout(False)
            groupBox1.PerformLayout()
            pbMovieInfo.EndInit()
            pictureBox1.EndInit()
            contextMenuStrip1.ResumeLayout(False)
            ResumeLayout(False)
        End Sub

        Private Sub lblSubtitleLinked_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawRectangle(System.Drawing.SystemPens.ControlDarkDark, 0, 0, lblSubtitleLinked.Width - 1, lblSubtitleLinked.Height - 1)
        End Sub

        Private Sub lblSubtitleUnlinked_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawRectangle(System.Drawing.SystemPens.ControlDarkDark, 0, 0, lblSubtitleUnlinked.Width - 1, lblSubtitleUnlinked.Height - 1)
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Sublight.Globals.ColorSubtitleUnlinkedAlternateBg)
                Dim list1 As System.Collections.Generic.List(Of System.Drawing.Point) = New System.Collections.Generic.List(Of System.Drawing.Point)
                list1.Add(New System.Drawing.Point(lblSubtitleUnlinked.Width / 2, 1))
                list1.Add(New System.Drawing.Point(lblSubtitleUnlinked.Width / 2, lblSubtitleUnlinked.Height - 1))
                list1.Add(New System.Drawing.Point(lblSubtitleUnlinked.Width - 1, lblSubtitleUnlinked.Height - 1))
                list1.Add(New System.Drawing.Point(lblSubtitleUnlinked.Width - 1, 1))
                e.Graphics.FillPolygon(solidBrush1, list1.ToArray())
            End Using
            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.SystemColors.ControlDarkDark, 1.0F)
                Dim fArr1 As Single() = New float() { 1.0F, 1.0F }
                pen1.DashPattern = fArr1
                e.Graphics.DrawLine(pen1, lblSubtitleUnlinked.Width / 2, 0, lblSubtitleUnlinked.Width / 2, lblSubtitleUnlinked.Height)
            End Using
        End Sub

        Private Sub lvSearchResults_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Select Case Sublight.Properties.Settings.Default.Search_DblClickAction
                Case Sublight.Types.SubtitleDblClickAction.DownloadSubtitleAndPlay
                    If Not _btnPlay.Enabled Then
                        GoTo label_0
                    End If
                    btnPlay_Click(Me, Nothing)
                    Return

                Case Sublight.Types.SubtitleDblClickAction.DownloadSubtitle
                    If Not _btnSearchDownload.Enabled Then
                        GoTo label_0
                    End If
                    toolStripSearchLinkedDownload_Click(Me, Nothing)
                    Return

                Case Sublight.Types.SubtitleDblClickAction.SubtitleDetails
                    If Not _btnLinkAdd.Enabled AndAlso Not _btnLinkValid.Enabled AndAlso Not _btnLinkInvalid.Enabled Then
                        GoTo label_0
                    End If
                    mnuProperties_Click(Me, Nothing)
            End Select
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

        Private Sub mnuAddLink_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If _btnLinkAdd.Enabled Then
                toolStripSearchLinkedAddLink_Click(_btnLinkAdd, Nothing)
            End If
        End Sub

        Private Sub mnuAddRelease_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            Dim frmAddRelease1 As Sublight.FrmAddRelease = New Sublight.FrmAddRelease(subtitle1.SubtitleID)
            If (frmAddRelease1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) AndAlso frmAddRelease1.Status Then
                Dim data1 As Sublight.Controls.SuperListItem.Data = Sublight.Controls.BasePageResults.GetSelectedSubtitleData(lvSearchResults)
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
                    Sublight.Controls.BasePageResults.RebindSearchResults(lvSearchResults, m_data)
                End If
            End If
            frmAddRelease1.Dispose()
        End Sub

        Private Sub mnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
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
            If _btnSearchDownload.Enabled Then
                toolStripSearchLinkedDownload_Click(Me, Nothing)
            End If
        End Sub

        Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Sublight.BaseForm.IsAnonymous Then
                Return
            End If
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
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

        Private Sub mnuImportSubtitle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not (lvSearchResults.SelectedItems) Is Nothing Then
                Dim i1 As Integer = 0
                While i1 < lvSearchResults.SelectedItems.Count
                    Dim data1 As Sublight.Controls.SuperListItem.Data = CType(lvSearchResults.SelectedItems(i1).Items(0), Sublight.Controls.SuperListItem.Data)
                    If Not (data1.SubtitleProvider) Is Nothing Then
                        If ParentBaseForm.ShowQuestion(Sublight.Translation.MessageBox_ImportSubtitle, New object(0) {}) = System.Windows.Forms.DialogResult.No Then
                            ParentBaseForm.ShowInfo(Sublight.Translation.MessageBox_ImportSubtitleDenied, New object(0) {})
                            Return
                        End If
                        Sublight.Globals.MainForm.SwitchTab(Sublight.FrmMain.RibbonTab.Publish)
                        m_pagePublish.PublishExternalSubtitle(txtSearchLinkedFile.Text, data1.SubtitleProvider, data1.Subtitle)
                        Return
                    End If
                    i1 = i1 + 1
                End While
            End If
        End Sub

        Private Sub mnuInvalidLink_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If _btnLinkInvalid.Enabled Then
                toolStripSearchLinkedReportLink_Click(Me, Nothing)
            End If
        End Sub

        Private Sub mnuNFO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            itt.Hide()
            Dim frmDetails2_1 As Sublight.FrmDetails2 = New Sublight.FrmDetails2(subtitle1, Sublight.FrmDetails2.FirstTab.NFO)
            frmDetails2_1.ShowDialog(Me)
            frmDetails2_1.Dispose()
        End Sub

        Private Sub mnuPlay_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If _btnPlay.Enabled Then
                btnPlay_Click(Me, Nothing)
            End If
        End Sub

        Private Sub mnuPluginInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not (lvSearchResults.SelectedItems) Is Nothing Then
                Dim i1 As Integer = 0
                While i1 < lvSearchResults.SelectedItems.Count
                    Dim data1 As Sublight.Controls.SuperListItem.Data = CType(lvSearchResults.SelectedItems(i1).Items(0), Sublight.Controls.SuperListItem.Data)
                    If Not (data1.SubtitleProvider) Is Nothing Then
                        Dim objArr1 As Object() = New object() { _
                                                                 data1.SubtitleProvider.ShortName, _
                                                                 data1.SubtitleProvider.Version.ToString(3), _
                                                                 System.Environment.NewLine, _
                                                                 data1.SubtitleProvider.Info }
                        ParentBaseForm.ShowInfo("{0}, {1}{2}{2}{3}?", objArr1)
                        Return
                    End If
                    i1 = i1 + 1
                End While
            End If
        End Sub

        Private Sub mnuPrimarySubDbInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ParentBaseForm.ShowInfo(Sublight.Translation.Application_Info_WhatIsPrimaryDatabase, New object(0) {})
        End Sub

        Private Sub mnuProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            Dim frmDetails2_1 As Sublight.FrmDetails2 = New Sublight.FrmDetails2(subtitle1, Sublight.FrmDetails2.FirstTab.Details)
            itt.Hide()
            frmDetails2_1.ShowDialog(Me)
            frmDetails2_1.Dispose()
        End Sub

        Private Sub mnuRateVal1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvSearchResults, m_data, 1)
        End Sub

        Private Sub mnuRateVal2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvSearchResults, m_data, 2)
        End Sub

        Private Sub mnuRateVal3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvSearchResults, m_data, 3)
        End Sub

        Private Sub mnuRateVal4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvSearchResults, m_data, 4)
        End Sub

        Private Sub mnuRateVal5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            RateSubtitle(lvSearchResults, m_data, 5)
        End Sub

        Private Sub mnuReportSubtitle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            Dim frmSubtitleReport1 As Sublight.FrmSubtitleReport = New Sublight.FrmSubtitleReport(subtitle1.SubtitleID)
            frmSubtitleReport1.ShowDialog(Me)
            frmSubtitleReport1.Dispose()
        End Sub

        Private Sub mnuSearchAllMovieSubtitles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            PerformSearchByImdb(Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults))
        End Sub

        Private Sub mnuSearchAllSubtitlesForThisPublisher_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            PerformSearchByPublisher(Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults))
        End Sub

        Private Sub mnuSubtitleAction_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = TryCast(sender, System.Windows.Forms.ToolStripMenuItem)
            If (toolStripMenuItem1) Is Nothing Then
                Return
            End If
            Dim subtitleAction1 As Sublight.Plugins.SubtitleProvider.Types.SubtitleAction = TryCast(toolStripMenuItem1.Tag, Sublight.Plugins.SubtitleProvider.Types.SubtitleAction)
            If (subtitleAction1) Is Nothing Then
                Return
            End If
            If subtitleAction1.Action = Sublight.Plugins.SubtitleProvider.Types.SubtitleAction.ActionType.OpenUrlInBrowser Then
                Dim s1 As String = TryCast(subtitleAction1.Tag, string)
                If System.String.IsNullOrEmpty(s1) Then
                    Return
                End If
                If subtitleAction1.Id = "PodnapisiNetRateVote?" Then
                    Dim s2 As String = Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Username
                    Dim s3 As String = Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password
                    Dim s4 As String = Nothing
                    If System.String.IsNullOrEmpty(s2) OrElse System.String.IsNullOrEmpty(s3) Then
                        Using frmPodnapisiNetLogin1 As Sublight.FrmPodnapisiNetLogin = New Sublight.FrmPodnapisiNetLogin
                            Dim dialogResult1 As System.Windows.Forms.DialogResult = frmPodnapisiNetLogin1.ShowDialog(Me)
                            If dialogResult1 = System.Windows.Forms.DialogResult.Cancel Then
                                Return
                            End If
                            If (dialogResult1 = System.Windows.Forms.DialogResult.OK) AndAlso Not frmPodnapisiNetLogin1.LoginUsernamePasswordEmpty Then
                                s4 = Sublight.Controls.PageSearch.PodnapisiNetLogin(frmPodnapisiNetLogin1.LoginUsername, frmPodnapisiNetLogin1.LoginPassword)
                            End If
                            GoTo label_1
                        End Using
                    End If
                    If Not Sublight.MyUtility.Encryption.IsPasswordEncrypted(s3) Then
                        s3 = Sublight.MyUtility.Encryption.EncryptPassword(s3)
                        Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password = s3
                        Sublight.BaseForm.SaveUserSettingsSilent()
                    End If
                    s4 = Sublight.Controls.PageSearch.PodnapisiNetLogin(s2, Sublight.MyUtility.Encryption.DecryptPassword(s3))
                    If Not System.String.IsNullOrEmpty(s4) Then
                        s1 = System.String.Format("{0}/__ULCOOKIE/{1}?", s1, s4)
                    Else 
                        Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password = System.String.Empty
                        Sublight.BaseForm.SaveUserSettingsSilent()
                    End If
                End If
                ParentBaseForm.OpenInBrowser(s1)
                Return
            End If
            If subtitleAction1.Action = Sublight.Plugins.SubtitleProvider.Types.SubtitleAction.ActionType.PluginSpecific Then
                Dim s5 As String = TryCast(subtitleAction1.Tag, string)
                If s5 = "PodnapisiNet?" AndAlso subtitleAction1.Id = "ForgetMe?" Then
                    Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Username = System.String.Empty
                    Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password = System.String.Empty
                    Sublight.BaseForm.SaveUserSettingsSilent()
                End If
            End If
        End Sub

        Private Sub mnuSubtitlePreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            itt.Hide()
            Dim frmDetails2_1 As Sublight.FrmDetails2 = New Sublight.FrmDetails2(subtitle1, Sublight.FrmDetails2.FirstTab.Preview)
            frmDetails2_1.ShowDialog(Me)
            frmDetails2_1.Dispose()
        End Sub

        Private Sub mnuValidLink_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If _btnLinkValid.Enabled Then
                toolStripSearchLinkedAddLink_Click(_btnLinkValid, Nothing)
            End If
        End Sub

        Private Sub PageSearch_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
            Try
                Dim array1 As System.Array = CType(e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop), System.Array)
                If Not (array1) Is Nothing Then
                    Dim s1 As String = array1.GetValue(0).ToString()
                    If Not Sublight.Globals.IsVideoFileSupported(s1) Then
                        Return
                    End If
                    Dim objArr1 As Object() = New object() { s1 }
                    Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_BPR_PAGE_SEARCH_DRAG_DROP, ParentBaseForm, Me, objArr1)
                    webServiceHandler1.DisplayLoader = False
                    AddHandler webServiceHandler1.DoCall, AddressOf PageSearchDragDropWshDoCall
                    webServiceHandler1.RunWorkerAsync()
                End If
            Catch 
            End Try
        End Sub

        Private Sub PageSearch_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
            If e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop) Then
                Try
                    Dim array1 As System.Array = CType(e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop), System.Array)
                    If Not (array1) Is Nothing Then
                        Dim s1 As String = array1.GetValue(0).ToString()
                        If Not Sublight.Globals.IsVideoFileSupported(s1) Then
                            Return
                        End If
                        If System.IO.File.Exists(s1) Then
                            e.Effect = System.Windows.Forms.DragDropEffects.Move
                            Return
                        End If
                    End If
                Catch 
                End Try
            End If
            e.Effect = System.Windows.Forms.DragDropEffects.None
        End Sub

        Private Function PageSearchDragDropWshDoCall(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim flag1 As Boolean

            result = New object(0) {}
            Try
                If (Not (args) Is Nothing) AndAlso (args.Length > 0) Then
                    Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
                    Dim <>c__DisplayClass1e1 As Sublight.Controls.PageSearch.<>c__DisplayClass1e = New Sublight.Controls.PageSearch.<>c__DisplayClass1e
                    <>c__DisplayClass1e1.<>4__this = Me
                    <>c__DisplayClass1e1.videoFile = TryCast(args(0), string)
                    If Not System.String.IsNullOrEmpty(<>c__DisplayClass1e1.videoFile) Then
                        If (methodInvoker2) Is Nothing Then
                            methodInvoker2 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass1e1.<PageSearchDragDropWshDoCall>b__1c)
                        End If
                        Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                        If InvokeRequired Then
                            Dim objArr1 As Object() = New object(1) {}
                            BeginInvoke(methodInvoker1, objArr1).AsyncWaitHandle.WaitOne()
                        Else 
                            methodInvoker1.Invoke()
                        End If
                        Return True
                    End If
                End If
                flag1 = False
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

        Private Sub PageSearchLinked_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowSearchInfo(Sublight.Translation.Search_Info_ReadyForSearch, False)
        End Sub

        Private Sub panelSearchTop_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawLine(_lineBottom, 0, panelSearchTop.Height - 2, Width, panelSearchTop.Height - 2)
            e.Graphics.DrawLine(System.Drawing.Pens.White, 0, panelSearchTop.Height - 1, Width, panelSearchTop.Height - 1)
        End Sub

        Private Sub parent_Move(ByVal sender As Object, ByVal e As System.EventArgs)
            TryCloseLinkTooltip()
        End Sub

        Private Sub ParentBaseForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If IsActiveTab Then
                m_shiftPressed = e.Shift
                If e.Shift AndAlso (Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage <> Sublight.Types.SecondarySubtitleProvider.UseAlways) Then
                    ShowSearchInfo(Sublight.Translation.Search_Info_AlsoSearchOtherSources)
                End If
            End If
        End Sub

        Private Sub ParentBaseForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If IsActiveTab Then
                m_shiftPressed = e.Shift
                If Not e.Shift AndAlso (Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage <> Sublight.Types.SecondarySubtitleProvider.UseAlways) Then
                    HideSearchInfo()
                End If
            End If
        End Sub

        Private Sub pbMovieInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim timeSpan1 As System.TimeSpan

            If Not pbMovieInfo.Visible Then
                Return
            End If
            Dim dictionary1 As System.Collections.Generic.Dictionary(Of String,String) = TryCast(pbMovieInfo.Tag, System.Collections.Generic.Dictionary(Of String,String)[])
            If (dictionary1) Is Nothing Then
                Return
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Try
                timeSpan1 = System.TimeSpan.FromSeconds(System.Double.Parse(dictionary1.get_Item("Duration?")))
            Catch 
                timeSpan1 = System.TimeSpan.FromSeconds(0.0R)
            End Try
            stringBuilder1.AppendFormat("{0} {1}{2}?", Sublight.Translation.Common_MediaInfo_VideoCodec, dictionary1.get_Item("Codec?"), System.Environment.NewLine)
            stringBuilder1.AppendFormat("{0} {1}{2}?", Sublight.Translation.Common_MediaInfo_VideoCodecID, dictionary1.get_Item("CodecID?"), System.Environment.NewLine)
            stringBuilder1.AppendFormat("{0} {1}{2}?", Sublight.Translation.Common_MediaInfo_VideoFormat, dictionary1.get_Item("Format?"), System.Environment.NewLine)
            stringBuilder1.AppendFormat("{0} {1}{2}?", Sublight.Translation.Common_MediaInfo_AudioFormat, dictionary1.get_Item("AudioFormat?"), System.Environment.NewLine)
            stringBuilder1.AppendFormat("{0} {1} px{2}?", Sublight.Translation.Common_MediaInfo_FrameWidth, dictionary1.get_Item("Width?"), System.Environment.NewLine)
            stringBuilder1.AppendFormat("{0} {1} px{2}?", Sublight.Translation.Common_MediaInfo_FrameHeight, dictionary1.get_Item("Height?"), System.Environment.NewLine)
            stringBuilder1.AppendFormat("{0} {1}{2}?", Sublight.Translation.Common_MediaInfo_Size, dictionary1.get_Item("Size?"), System.Environment.NewLine)
            Dim objArr1 As Object() = New object() { _
                                                     Sublight.Translation.Common_MediaInfo_Runtime, _
                                                     timeSpan1.Hours, _
                                                     timeSpan1.Minutes, _
                                                     timeSpan1.Seconds, _
                                                     System.Environment.NewLine }
            stringBuilder1.AppendFormat("{0} {1:00}:{2:00}:{3:00}{4}?", objArr1)
            stringBuilder1.AppendFormat("{0} {1}?", Sublight.Translation.Common_MediaInfo_FrameRate, dictionary1.get_Item("FrameRate?"))
            ParentBaseForm.ShowInfo(stringBuilder1.ToString(), New object(0) {})
        End Sub

        Friend Sub PerformSearch(ByVal fileName As String, ByVal waitForTitleAutoCompletion As Boolean)
            btnClear_Click(Me, Nothing)
            DoVideoInfoDetailed(fileName)
            txtSearchLinkedFile.Text = fileName
            txtSearchLinkedFile.SelectionStart = txtSearchLinkedFile.Text.Length
            AutoFillTitle(waitForTitleAutoCompletion)
            btnSearchLinked_Click(Me, Nothing)
            _doFeelingLuckySearch = False
        End Sub

        Friend Sub PerformSearchByImdb(ByVal subtitle As Sublight.WS.Subtitle)
            Dim nullable5 As System.Nullable(Of Integer)

            If ((subtitle) Is Nothing) OrElse System.String.IsNullOrEmpty(subtitle.IMDB) Then
                Return
            End If
            Dim i1 As Integer = subtitle.IMDB.LastIndexOf("/"C)
            Dim s1 As String = IIf(i1 >= 0, subtitle.IMDB.Substring(i1 + 1), subtitle.IMDB)
            s1 = s1.Trim()
            btnClear_Click(Me, Nothing)
            txtTitle.Text = System.String.Format("imdb: {0}?", s1)
            Dim nullable4 As System.Nullable(Of Byte) = subtitle.Season
            If Not nullable4.get_HasValue() Then
                GoTo label_0
            End If
            nullable5 = New System.Nullable(Of Integer)[]
            Dim nullable6 As System.Nullable(Of Integer) = New System.Nullable(Of Integer)(nullable4.GetValueOrDefault())
            If nullable6.get_HasValue() Then
                Dim nullable1 As System.Nullable(Of Byte) = subtitle.Season
                txtSeason.Text = nullable1.ToString()
            End If
            Dim nullable2 As System.Nullable(Of Integer) = subtitle.Episode
            If nullable2.get_HasValue() Then
                Dim nullable3 As System.Nullable(Of Integer) = subtitle.Episode
                txtEpisode.Text = nullable3.ToString()
            End If
            btnSearchLinked_Click(Me, Nothing)
        End Sub

        Friend Sub PerformSearchByPublisher(ByVal subtitle As Sublight.WS.Subtitle)
            If ((subtitle) Is Nothing) OrElse System.String.IsNullOrEmpty(subtitle.Publisher) Then
                Return
            End If
            btnClear_Click(Me, Nothing)
            txtTitle.Text = System.String.Format("publisher: {0}?", subtitle.Publisher.Trim())
            btnSearchLinked_Click(Me, Nothing)
        End Sub

        Private Sub RefreshMatchesCount()
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            If IsActiveTab AndAlso (Not (m_tssl) Is Nothing) Then
                If (methodInvoker2) Is Nothing Then
                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<RefreshMatchesCount>b__15)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                Sublight.BaseForm.DoCtrlInvoke(m_tssl, Me, methodInvoker1)
            End If
        End Sub

        Private Sub RepositionFeelingButton()
            btnFeelingLucky.Left = btnSearchLinked.Right + 6
        End Sub

        Private Sub RepositionGroupBoxTooltipsIfNecessary()
            Dim i1 As Integer = groupBox1.Width - 18
            If ttSearchByHash.Left <> i1 Then
                ttSearchByHash.Left = i1
            End If
            i1 = groupBox2.Width - 18
            If ttSearchManual.Left <> i1 Then
                ttSearchManual.Left = i1
            End If
            i1 = groupBox3.Width - 18
            If ttSearchResultsFilter.Left <> i1 Then
                ttSearchResultsFilter.Left = i1
            End If
        End Sub

        Private Sub rtp_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            If ((RibbonTabPage) Is Nothing) OrElse RibbonTabPage.IsDisposed Then
                Return
            End If
            If _btnSearchFilter.Pressed OrElse Not AreFiltersSet() Then
                Return
            End If
            Dim s1 As String = Sublight.Translation.Search_Toolbar_NoticeFiltersAreSet
            Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString(s1, Font)
            e.Graphics.DrawString(s1, Font, System.Drawing.SystemBrushes.ControlText, CSng(RibbonTabPage.Width) - sizeF1.Width - 10.0F, (CSng(RibbonTabPage.Height) / 2.0F) - (sizeF1.Height / 2.0F))
        End Sub

        Private Sub SelectedItems_DataChanged(ByVal sender As Object, ByVal e As BinaryComponents.SuperList.SelectedItemsChangedEventArgs)
            Dim data1 As Sublight.Controls.SuperListItem.Data = Sublight.Controls.BasePageResults.GetSelectedSubtitleData(lvSearchResults)
            Dim flag1 As Boolean = Sublight.Controls.BasePageResults.AreMultipleItemsSelected(lvSearchResults)
            If (data1) Is Nothing Then
                If flag1 Then
                    _imdbEnabled = False
                    _btnSearchDownload.Enabled = True
                    _btnLinkInvalid.Enabled = False
                    _btnLinkValid.Enabled = False
                    _btnLinkAdd.Enabled = False
                    _btnPlay.Enabled = False
                    _btnReport.Enabled = False
                    _btnRate.Enabled = False
                    _btnSearchSync.Enabled = False
                End If
                Return
            End If
            Dim subtitle1 As Sublight.WS.Subtitle = data1.Subtitle
            If Not (subtitle1) Is Nothing Then
                _btnSearchDownload.Enabled = True
                _btnPlay.Enabled = True
                _btnReport.Enabled = True
                _btnSearchSync.Enabled = True
                _btnRate.Enabled = True
                If (data1.SubtitleProvider) Is Nothing Then
                    _imdbEnabled = True
                    _btnLinkInvalid.Enabled = subtitle1.IsLinked
                    _btnLinkValid.Enabled = subtitle1.IsLinked
                    _btnLinkAdd.Enabled = Not subtitle1.IsLinked
                    mnuProperties.ShortcutKeys = System.Windows.Forms.Keys.F4
                    If Sublight.MyUtility.SubtitleUtil.IsNonImdbMovie(subtitle1) Then
                        mnuNFO.ShortcutKeys = System.Windows.Forms.Keys.None
                    Else 
                        mnuNFO.ShortcutKeys = System.Windows.Forms.Keys.RButton Or System.Windows.Forms.Keys.MButton Or System.Windows.Forms.Keys.Back Or System.Windows.Forms.Keys.Control
                    End If
                    mnuSubtitlePreview.ShortcutKeys = System.Windows.Forms.Keys.F6
                    _btnPlay.Enabled = True
                    _btnReport.Enabled = True
                    _btnRate.Enabled = True
                    _btnSearchSync.Enabled = True
                    Return
                End If
                _btnLinkInvalid.Enabled = False
                _btnLinkValid.Enabled = False
                _btnLinkAdd.Enabled = False
                mnuProperties.ShortcutKeys = System.Windows.Forms.Keys.None
                mnuNFO.ShortcutKeys = System.Windows.Forms.Keys.None
                mnuSubtitlePreview.ShortcutKeys = System.Windows.Forms.Keys.None
                If flag1 Then
                    _btnPlay.Enabled = False
                    _btnReport.Enabled = False
                    _btnRate.Enabled = False
                    _btnSearchSync.Enabled = False
                    _imdbEnabled = False
                    Return
                End If
                _btnPlay.Enabled = data1.SubtitleProvider.DownloadType = Sublight.Plugins.SubtitleProvider.Types.SubtitleProviderDownloadType.Direct
                _imdbEnabled = Not System.String.IsNullOrEmpty(subtitle1.IMDB)
                _btnReport.Enabled = False
                _btnSearchSync.Enabled = False
                _btnRate.Enabled = False
            End If
        End Sub

        Private Sub SetFilterByRateText()
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem1 In cmsRate.Items
                If toolStripMenuItem1.Checked Then
                    btnRate.Text = toolStripMenuItem1.Text
                    Return
                End If
            Next
        End Sub

        Private Sub SetFilterLanguageText()
            Dim i1 As Integer = 0
            Dim i2 As Integer = 0
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem1 In cmsFilterLanguage.Items
                If TryCast(toolStripMenuItem1.Tag, Sublight.WS.SubtitleLanguage) Then
                    i2 = i2 + 1
                End If
                If toolStripMenuItem1.Checked Then
                    i1 = i1 + 1
                End If
            Next
            If i1 <= 0 Then
                btnLanguage.Text = Sublight.Translation.Common_Selection_NotSelected
            ElseIf i1 < i2 Then
                btnLanguage.Text = System.String.Format("{0} ... ({1})?", Sublight.Translation.Common_Selection_Custom, i1)
            Else 
                btnLanguage.Text = Sublight.Translation.Common_Selection_ShowAll
            End If
            OnFilterChanged()
        End Sub

        Private Sub SetScreenTip(ByVal ctrl As Elegant.Ui.Control, ByVal text As String)
            ctrl.ScreenTip.Text = text
        End Sub

        Private Sub ShowHideFilter()
            panelSearchTopCriteria.SuspendLayout()
            panelSearchCriteriaSearchFilterSeparator.SuspendLayout()
            groupBox3.SuspendLayout()
            groupBox3.Visible = _btnSearchFilter.Pressed
            lblTipSuggest.Visible = False
            If _btnSearchFilter.Pressed Then
                panelSearchTopCriteria.Dock = System.Windows.Forms.DockStyle.Left
                panelSearchCriteriaSearchFilterSeparator.Dock = System.Windows.Forms.DockStyle.Left
                groupBox3.Dock = System.Windows.Forms.DockStyle.Fill
            Else 
                panelSearchTopCriteria.Dock = System.Windows.Forms.DockStyle.Top
                panelSearchCriteriaSearchFilterSeparator.Dock = System.Windows.Forms.DockStyle.Fill
                groupBox3.Dock = System.Windows.Forms.DockStyle.None
            End If
            panelSearchTopCriteria.ResumeLayout()
            panelSearchCriteriaSearchFilterSeparator.ResumeLayout()
            groupBox3.ResumeLayout()
            RepositionGroupBoxTooltipsIfNecessary()
        End Sub

        Private Sub ShowSearchInfo(ByVal text As String, ByVal autoHide As Boolean)
            If Not tcSearchInfo.Visible OrElse (System.String.Compare(tcSearchInfo.Text, text) <> 0) Then
                If btnFeelingLucky.Visible Then
                    tcSearchInfo.Left = btnFeelingLucky.Right + 6
                Else 
                    tcSearchInfo.Left = btnSearchLinked.Right + 6
                End If
                If Not (tcSearchInfo.Parent) Is Nothing Then
                    tcSearchInfo.BackColor = tcSearchInfo.Parent.BackColor
                End If
                tcSearchInfo.Text = text
                tcSearchInfo.ShowCtrl()
            End If
            If autoHide Then
                tcSearchInfo.Tag = System.Guid.NewGuid()
                Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ParameterizedThreadStart(HideSearchInfoThread))
                thread1.Start(tcSearchInfo.Tag)
            End If
        End Sub

        Private Sub ShowSearchInfo(ByVal text As String)
            ShowSearchInfo(text, True)
        End Sub

        Private Sub ShowTitleSuggest()
            Dim s1 As String = txtTitle.Text
            Dim i1 As Integer = 0
            While i1 < cmsSuggestTitle.Items.Count
                Dim idisposable1 As System.IDisposable = cmsSuggestTitle.Items(i1)
                If Not (idisposable1) Is Nothing Then
                    idisposable1.Dispose()
                End If
                i1 = i1 + 1
            End While
            cmsSuggestTitle.Items.Clear()
            cmsSuggestTitle.Items.Add(New Sublight.Controls.ToolStripSeparatorCaption(Sublight.Translation.Search_Context_SuggestedTitles))
            If System.String.IsNullOrEmpty(s1) Then
                Dim myToolStripMenuItem1 As Sublight.Controls.MyToolStripMenuItem = New Sublight.Controls.MyToolStripMenuItem(System.String.Format("{0}?", Sublight.Translation.Search_Panel_ManualSearchCriteria_SuggestContextMenu_WaitingForEntry))
                myToolStripMenuItem1.Enabled = False
                cmsSuggestTitle.Items.Add(myToolStripMenuItem1)
                BindRecentUnsuccessfulSearches()
                cmsSuggestTitle.Show(btnSuggest, 0, btnSuggest.Height + 1)
                Return
            End If
            ParentBaseForm.ShowLoader(Me)
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.SuggestTitlesCompleted, AddressOf WS_SuggestTitlesCompleted
                sublight1.SuggestTitlesAsync(s1, 15, s1)
            End Using
        End Sub

        Private Sub toolStripSearchLinkedAddLink_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s2 As String

            Dim button1 As Elegant.Ui.Button = TryCast(sender, Elegant.Ui.Button)
            If (button1) Is Nothing Then
                Return
            End If
            If System.String.IsNullOrEmpty(txtSearchLinkedFile.Text) OrElse Not System.IO.File.Exists(txtSearchLinkedFile.Text) Then
                ParentBaseForm.ShowInfo(Sublight.Translation.Search_Info_VideoFileMustBeSelectedBeforePlay, New object(0) {})
                Return
            End If
            If ((lvSearchResults.SelectedItems) Is Nothing) OrElse (lvSearchResults.SelectedItems.Count <> 1) Then
                Return
            End If
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            Dim s1 As String = Utility.Video.Checksum.Compute(txtSearchLinkedFile.Text)
            If System.String.IsNullOrEmpty(s1) Then
                ParentBaseForm.ShowError(Sublight.Translation.Search_Error_VideoHashCalculation, New object(0) {})
                Return
            End If
            If Not ParentBaseForm.AddHashLink(Me, subtitle1.SubtitleID, s1, True, out s2) Then
                Dim objArr1 As Object() = New object() { s2 }
                ParentBaseForm.ShowError(Sublight.Translation.Search_Error_LinkingSubtitle, objArr1)
                Return
            End If
            subtitle1.IsLinked = True
            subtitle1.Link = "Common_SearchResults_Link_ReportedAsValid?"
            lvSearchResults.Refresh()
        End Sub

        Private Sub toolStripSearchLinkedDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            OnDownload(lvSearchResults, folderBrowserDialog1, txtSearchLinkedFile.Text, False)
        End Sub

        Private Sub toolStripSearchLinkedReportLink_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s2 As String

            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
            If (subtitle1) Is Nothing Then
                Return
            End If
            If Not System.IO.File.Exists(txtSearchLinkedFile.Text) Then
                parent.ShowWarning(Sublight.Translation.Search_Warning_VideoPathNotValid, New object(0) {})
                Return
            End If
            Dim s1 As String = Utility.Video.Checksum.Compute(txtSearchLinkedFile.Text)
            If System.String.IsNullOrEmpty(s1) Then
                parent.ShowError(Sublight.Translation.Search_Error_VideoHashCalculation, New object(0) {})
                Return
            End If
            If Not parent.ReportHashLink(Me, subtitle1.SubtitleID, s1, out s2) Then
                parent.ShowError(Sublight.Translation.Search_Error_ReportSubtitleLink, New object(0) {})
                Return
            End If
            subtitle1.Link = "Common_SearchResults_Link_ReportedAsInvalid?"
            lvSearchResults.Refresh()
        End Sub

        Private Sub TranslateFilterByRate()
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem1 In cmsRate.Items
                Dim i1 As Integer = DirectCast(toolStripMenuItem1.Tag, int)
                If i1 < 0 Then
                    toolStripMenuItem1.Text = Sublight.Translation.Common_Selection_ShowAll
                Else 
                    toolStripMenuItem1.Text = System.String.Format(Sublight.Translation.Search_Panel_ResultsFiltering_RateGreaterThan, i1)
                End If
            Next
            SetFilterByRateText()
        End Sub

        Private Sub TranslateSearchResults()
            lvSearchResults.Translate()
            lvSearchResults.Items.SynchroniseWithUINow()
            If lvSearchResults.Columns.get_Count() > 0 Then
                lvSearchResults.SizeColumnsToFit()
                Return
            End If
            lvSearchResults.Refresh()
        End Sub

        Private Sub TryCloseLinkTooltip()
            If (Not (m_ttHelpUsLink) Is Nothing) AndAlso Not m_ttHelpUsLink.IsDisposed Then
                m_ttHelpUsLink.Close()
                m_ttHelpUsLink.Dispose()
                m_ttHelpUsLink = Nothing
            End If
        End Sub

        Private Sub tsiClearRecentItems_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Sublight.Properties.Settings.Default.Search_RecentUnsuccessfulSearches = System.String.Empty
            Sublight.BaseForm.SaveUserSettingsSilent()
        End Sub

        Private Sub tsiUnsuccessfulSearchElement_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim toolStripItem1 As System.Windows.Forms.ToolStripItem = TryCast(sender, System.Windows.Forms.ToolStripItem)
            If (toolStripItem1) Is Nothing Then
                Return
            End If
            Dim searchElement1 As Sublight.Controls.PageSearch.SearchElement = TryCast(toolStripItem1.Tag, Sublight.Controls.PageSearch.SearchElement)
            If (searchElement1) Is Nothing Then
                Return
            End If
            txtTitle.Text = searchElement1.Title
            Dim nullable5 As System.Nullable(Of Integer) = searchElement1.Year
            Dim nullable6 As System.Nullable(Of Integer) = searchElement1.Year
            Dim i1 As Integer = nullable6.get_Value()
            txtYear.Text = IIf(nullable5.get_HasValue(), i1.ToString(), System.String.Empty)
            Dim nullable1 As System.Nullable(Of Integer) = searchElement1.Season
            Dim nullable2 As System.Nullable(Of Integer) = searchElement1.Season
            Dim i2 As Integer = nullable2.get_Value()
            txtSeason.Text = IIf(nullable1.get_HasValue(), i2.ToString(), System.String.Empty)
            Dim nullable3 As System.Nullable(Of Integer) = searchElement1.Episode
            Dim nullable4 As System.Nullable(Of Integer) = searchElement1.Episode
            Dim i3 As Integer = nullable4.get_Value()
            txtEpisode.Text = IIf(nullable3.get_HasValue(), i3.ToString(), System.String.Empty)
        End Sub

        Private Sub tsmi_FilterByRateClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = TryCast(sender, System.Windows.Forms.ToolStripMenuItem)
            If (toolStripMenuItem1) Is Nothing Then
                Return
            End If
            Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem2 In cmsRate.Items
                toolStripMenuItem2.Checked = False
            Next
            toolStripMenuItem1.Checked = True
            SetFilterByRateText()
        End Sub

        Private Sub tsmi_FilterLanguageClick(ByVal sender As Object, ByVal e As System.EventArgs)
            SetFilterLanguageText()
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = TryCast(sender, System.Windows.Forms.ToolStripMenuItem)
            If (toolStripMenuItem1) Is Nothing Then
                Return
            End If
            If TryCast(toolStripMenuItem1.Tag, int) Then
                Dim i1 As Integer = DirectCast(toolStripMenuItem1.Tag, int)
                If i1 = 1 Then
                    Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem 
                    For Each toolStripMenuItem2 In cmsFilterLanguage.Items
                        If TryCast(toolStripMenuItem2.Tag, Sublight.WS.SubtitleLanguage) Then
                            toolStripMenuItem2.Checked = True
                        End If
                    Next
                    SetFilterLanguageText()
                ElseIf i1 = 2 Then
                    Dim toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem 
                    For Each toolStripMenuItem3 In cmsFilterLanguage.Items
                        If TryCast(toolStripMenuItem3.Tag, Sublight.WS.SubtitleLanguage) Then
                            toolStripMenuItem3.Checked = False
                        End If
                    Next
                    SetFilterLanguageText()
                Else 
                    Throw New System.Exception("Mode not supported.?")
                End If
            End If
            Dim subtitleLanguageCollection1 As Sublight.Types.SubtitleLanguageCollection = New Sublight.Types.SubtitleLanguageCollection
            Dim toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem 
            For Each toolStripMenuItem4 In cmsFilterLanguage.Items
                If toolStripMenuItem4.Checked Then
                    Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = DirectCast(toolStripMenuItem4.Tag, Sublight.WS.SubtitleLanguage)
                    subtitleLanguageCollection1.Add(subtitleLanguage1)
                End If
            Next
            Sublight.Properties.Settings.Default.Search_Filter_Language = subtitleLanguageCollection1
            ParentBaseForm.SaveUserSettings()
        End Sub

        Private Sub txtEpisode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnSearchLinked_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtFilterMediaCount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnSearchLinked_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtFilterSender_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnSearchLinked_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtSearchLinkedFile_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnSearchLinked_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtSearchLinkedFile_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
            AutoFillTitle()
        End Sub

        Private Sub txtSearchLinkedFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            EnableDisableDetectedTitleButtons(False)
        End Sub

        Private Sub txtSeason_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnSearchLinked_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtTitle_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
            lblTipSuggest.Visible = Not groupBox3.Visible
        End Sub

        Private Sub txtTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode <> System.Windows.Forms.Keys.Space Then
                _txtTitleCtrl = False
            End If
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnSearchLinked_Click(Me, Nothing)
                Return
            End If
            If e.KeyCode = System.Windows.Forms.Keys.ControlKey Then
                _txtTitleCtrl = True
                Return
            End If
            If _txtTitleCtrl AndAlso (e.KeyCode = System.Windows.Forms.Keys.Space) Then
                e.SuppressKeyPress = True
                _txtTitleAutoFocus = True
                ShowTitleSuggest()
            End If
        End Sub

        Private Sub txtTitle_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.ControlKey Then
                _txtTitleCtrl = False
            End If
        End Sub

        Private Sub txtTitle_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
            lblTipSuggest.Visible = False
        End Sub

        Private Sub txtTitle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            _txtTitleCtrl = False
        End Sub

        Private Sub TxtTitleFocus()
            txtTitle.Focus()
            If txtTitle.Text.Length > 0 Then
                txtTitle.SelectionStart = txtTitle.Text.Length
            End If
        End Sub

        Private Sub txtYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnSearchLinked_Click(Me, Nothing)
            End If
        End Sub

        Private Sub vid_Result(ByVal sender As Object, ByVal info As System.Collections.Generic.Dictionary(Of String,String))
            Dim bitmap1 As System.Drawing.Bitmap
            Dim videoCodec1 As Sublight.Controls.PageSearch.VideoCodec

            Dim <>c__DisplayClass10_1 As Sublight.Controls.PageSearch.<>c__DisplayClass10 = New Sublight.Controls.PageSearch.<>c__DisplayClass10
            <>c__DisplayClass10_1.info = info
            <>c__DisplayClass10_1.<>4__this = Me
            If (<>c__DisplayClass10_1.info) Is Nothing Then
                Return
            End If
            Dim i1 As Integer = 0
            If <>c__DisplayClass10_1.info.ContainsKey("Width?") AndAlso Not System.Int32.TryParse(<>c__DisplayClass10_1.info.get_Item("Width?"), ByRef i1) Then
                i1 = 0
            End If
            Dim i2 As Integer = 0
            If <>c__DisplayClass10_1.info.ContainsKey("Height?") AndAlso Not System.Int32.TryParse(<>c__DisplayClass10_1.info.get_Item("Height?"), ByRef i2) Then
                i2 = 0
            End If
            Dim flag1 As Boolean = False
            If i2 >= 720 Then
                flag1 = True
            End If
            If i1 >= 1280 Then
                flag1 = True
            End If
            Dim s1 As String = IIf(<>c__DisplayClass10_1.info.ContainsKey("Format?"), <>c__DisplayClass10_1.info.get_Item("Format?").ToLower(), Nothing)
            Dim s2 As String = IIf(<>c__DisplayClass10_1.info.ContainsKey("CodecID?"), <>c__DisplayClass10_1.info.get_Item("CodecID?").ToLower(), Nothing)
            If (Not (s1) Is Nothing) AndAlso s1.Contains("avc?") Then
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.AVC
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("divx?") Then
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("div3?") Then
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("div4?") Then
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("div5?") Then
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("dx50?") Then
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("xvid?") Then
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.Xvid
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("wmv?") Then
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.WMV
            Else 
                videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.Unknown
            End If
            If (videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.Unknown) AndAlso Not flag1 Then
                Return
            End If
            Dim i3 As Integer = 0
            If (videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.AVC) AndAlso Not flag1 Then
                bitmap1 = Sublight.Properties.Resources.CodecAVC
            ElseIf (videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.AVC) AndAlso flag1 Then
                flag1 = False
                bitmap1 = Sublight.Properties.Resources.AVC_HD
            ElseIf videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.Xvid Then
                bitmap1 = Sublight.Properties.Resources.CodecXvid
            ElseIf videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.DivX Then
                bitmap1 = Sublight.Properties.Resources.CodecDivX
            ElseIf videoCodec1 = Sublight.Controls.PageSearch.VideoCodec.WMV Then
                flag1 = False
                bitmap1 = Sublight.Properties.Resources.CodecWMV
            Else 
                bitmap1 = Nothing
            End If
            <>c__DisplayClass10_1.info.Add("Codec?", System.Enum.GetName(GetType(Sublight.Controls.PageSearch.VideoCodec), videoCodec1))
            If Not (bitmap1) Is Nothing Then
                i3 = i3 + bitmap1.Width
            End If
            If flag1 Then
                If i3 > 0 Then
                    i3 = i3 + 3
                End If
                i3 = i3 + Sublight.Properties.Resources.HdLogo.Width
            End If
            <>c__DisplayClass10_1.bmp = New System.Drawing.Bitmap(i3, 18, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            Dim graphics1 As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(<>c__DisplayClass10_1.bmp)
            Dim i4 As Integer = 0
            If (videoCodec1 <> Sublight.Controls.PageSearch.VideoCodec.Unknown) AndAlso (Not (bitmap1) Is Nothing) Then
                graphics1.DrawImageUnscaled(bitmap1, i4, 0)
                i4 = i4 + bitmap1.Width
            End If
            If flag1 Then
                If i4 > 0 Then
                    i4 = i4 + 3
                End If
                graphics1.DrawImageUnscaled(Sublight.Properties.Resources.HdLogo, i4, 0)
            End If
            graphics1.Flush()
            graphics1.Dispose()
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass10_1.<vid_Result>b__f)
            Sublight.BaseForm.DoCtrlInvoke(pbMovieInfo, Me, methodInvoker1)
        End Sub

        Private Sub VoteReportMovieHash(ByVal voteType As Sublight.WS.MovieHashVote)
            Dim s1 As String
            Dim nullable1 As System.Nullable(Of Byte)
            Dim nullable2 As System.Nullable(Of Integer)

            Try
                s1 = Utility.Video.Checksum.Compute(txtSearchLinkedFile.Text)
                If System.String.IsNullOrEmpty(s1) Then
                    GoTo label_1
                End If
            Catch e As System.Exception
                GoTo label_1
            End Try
            Dim s2 As String = TryCast(txtDetectedTitle.Tag, string)
            If System.String.IsNullOrEmpty(s2) Then
            label_1: _
                Return
            End If
            Dim chArr1 As Char() = New char() { ";"C }
            Dim sArr1 As String() = s2.Split(chArr1, System.StringSplitOptions.None)
            If sArr1.Length <> 3 Then
                Return
            End If
            Dim s3 As String = sArr1(0)
            If System.String.IsNullOrEmpty(sArr1(1)) Then
                nullable1 = New System.Nullable(Of Byte)[]
            Else 
                nullable1 = New System.Nullable(Of Byte)(System.Byte.Parse(sArr1(1)))
            End If
            If System.String.IsNullOrEmpty(sArr1(2)) Then
                nullable2 = New System.Nullable(Of Integer)[]
            Else 
                nullable2 = New System.Nullable(Of Integer)(System.Int32.Parse(sArr1(2)))
            End If
            Dim flag1 As Boolean = btnFeelingLucky.Visible
            EnableDisableDetectedTitleButtons(False)
            btnFeelingLucky.Visible = flag1
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                sublight1.VoteMovieHashAsync(Sublight.BaseForm.Session, s3, nullable1, nullable2, s1, voteType)
            End Using
        End Sub

        Private Sub ws_DeleteSubtitleCompleted(ByVal sender As Object, ByVal e As Sublight.WS.DeleteSubtitleCompletedEventArgs)
            Try
                If Sublight.BaseForm.HandleWSErrors(ParentBaseForm, e) Then
                    Return
                End If
                Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(lvSearchResults)
                If Not (subtitle1) Is Nothing Then
                    subtitle1.Status = 128
                End If
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Sub ws_GetDetailsByHashCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetDetailsByHashCompletedEventArgs)
            Try
                If ((e.Error) Is Nothing) AndAlso e.Result AndAlso (Not (e.imdbInfo) Is Nothing) Then
                    FillByImdb(e.imdbInfo)
                    Return
                End If
                ClearAndDisableDetectedTitle()
                FillByHeurestics()
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Sub WS_SuggestTitlesCompleted(ByVal sender As Object, ByVal e As Sublight.WS.SuggestTitlesCompletedEventArgs)
            Dim s1 As String

            Try
                If Not e.Result Then
                    Dim objArr1 As Object() = New object() { e.error }
                    ParentBaseForm.ShowError(Sublight.Translation.Connect_ErrorOccured, objArr1)
                    Return
                End If
                If (e.titles) Is Nothing Then
                    Return
                End If
                Dim imdbArr1 As Sublight.WS.IMDB() = e.titles
                Dim i1 As Integer = 0
                While i1 < imdbArr1.Length
                    Dim imdb1 As Sublight.WS.IMDB = imdbArr1(i1)
                    Dim nullable2 As System.Nullable(Of Integer) = imdb1.Year
                    If nullable2.get_HasValue() Then
                        Dim nullable1 As System.Nullable(Of Integer) = imdb1.Year
                        s1 = System.String.Format("{0} ({1})?", imdb1.Title, nullable1.get_Value())
                    Else 
                        s1 = System.String.Format("{0}?", imdb1)
                    End If
                    Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
                    s1 = s1.Replace("&?", "&&?")
                    toolStripMenuItem1.Text = s1
                    toolStripMenuItem1.Tag = imdb1
                    toolStripMenuItem1.ShortcutKeyDisplayString = "ENTER?"
                    cmsSuggestTitle.Items.Add(toolStripMenuItem1)
                    i1 = i1 + 1
                End While
                If e.titles.Length <= 0 Then
                    Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem(System.String.Format("{0}?", Sublight.Translation.Search_Panel_ManualSearchCriteria_SuggestContextMenu_NoHits))
                    toolStripMenuItem2.Enabled = False
                    cmsSuggestTitle.Items.Add(toolStripMenuItem2)
                ElseIf cmsSuggestTitle.Items.Count > 0 Then
                    cmsSuggestTitle.Items(1).Select()
                End If
            Catch e1 As System.Exception
                ParentBaseForm.ShowError(e1.Message, New object(0) {})
            Finally
                ParentBaseForm.HideLoader(Me)
                cmsSuggestTitle.Show(btnSuggest, 0, btnSuggest.Height + 1)
                Dim s2 As String = TryCast(e.UserState, string)
                If Not System.String.IsNullOrEmpty(s2) Then
                    txtTitle.Text = s2
                    TxtTitleFocus()
                End If
                BindRecentUnsuccessfulSearches()
            End Try
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (_lineBottom) Is Nothing Then
                    _lineBottom.Dispose()
                    _lineBottom = Nothing
                End If
                If Not (itt) Is Nothing Then
                    itt.Dispose()
                    itt = Nothing
                End If
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Sub OnDisplayed()
            MyBase.OnDisplayed()
            RefreshMatchesCount()
        End Sub

        Protected Overridable Sub OnFilterChanged()
            If ((RibbonTabPage) Is Nothing) OrElse RibbonTabPage.IsDisposed Then
                Return
            End If
            RibbonTabPage.Invalidate()
        End Sub

        Protected Overrides Sub OnLayout(ByVal e As System.Windows.Forms.LayoutEventArgs)
            MyBase.OnLayout(e)
            RepositionGroupBoxTooltipsIfNecessary()
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            TranslateSearchResults()
        End Sub

        Private Shared Function DeleteDuplicatedWhiteSpace(ByVal val As String) As String
            Dim s2 As String

            If System.String.IsNullOrEmpty(val) Then
                Return val
            End If
            Try
                Dim s1 As String = val
                While True
                    Dim i1 As Integer = s1.IndexOf("  ?")
                    If i1 >= 0 Then
                        s1 = s1.Substring(0, i1) + s1.Substring(i1 + 1)
                    End If
                End While
                s2 = s1
            Catch 
                s2 = val
            End Try
            Return s2
        End Function

        Private Shared Function GetOsdbTitleImdb(ByVal file As String, ByRef length As Long, ByRef hash2 As String, ByRef title As String, ByRef imdb As String) As Boolean
            Dim flag1 As Boolean
            Dim i1 As Integer
            Dim s1 As String

            hash2 = Nothing
            title = Nothing
            imdb = Nothing
            length = CLng(0)
            Try
                hash2 = Sublight.MyUtility.MovieHasher.ComputeMovieHash(file)
                If System.String.IsNullOrEmpty(hash2) Then
                    Return False
                End If
                If System.String.IsNullOrEmpty(Sublight.Controls.PageSearch.m_loginToken) Then
                    s1 = "<?xml version='1.0'?>
<methodCall>
<methodName>LogIn</methodName>
<params>
<param>
<value><string></string></value>
</param>
<param>
<value><string></string></value>
</param>
<param>
<value><string>all</string></value>
</param>
<param>
<value><string>{0}</string></value>
</param>
</params>
</methodCall>?"
                    Sublight.Controls.PageSearch.m_loginToken = Sublight.Controls.PageSearch.GetXmlRpcResponseValue(Sublight.Controls.PageSearch.XmlRpcCall(System.String.Format(s1, Sublight.BaseForm.ClientInfo)), "token?")
                    If System.String.IsNullOrEmpty(Sublight.Controls.PageSearch.m_loginToken) Then
                        Return False
                    End If
                End If
                s1 = "<?xml version='1.0'?>
<methodCall>
<methodName>SearchSubtitles</methodName>
<params>
<param>
<value><string>{0}</string></value>
</param>
<param>
<value><array><data>
<value><struct>
<member>
<name>moviebytesize</name>
<value><string>{1}</string></value>
</member>
<member>
<name>sublanguageid</name>
<value><string></string></value>
</member>
<member>
<name>moviehash</name>
<value><string>{2}</string></value>
</member>
</struct></value>
</data></array></value>
</param>
</params>
</methodCall>?"
                length = (New System.IO.FileInfo(file)).Length
                Dim s2 As String = Sublight.Controls.PageSearch.XmlRpcCall(System.String.Format(s1, Sublight.Controls.PageSearch.m_loginToken, length, hash2))
                If Not System.String.IsNullOrEmpty(s2) Then
                    Dim matchCollection1 As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(s2, "&#195;&#(?<code>\d*?);?")
                    Dim match1 As System.Text.RegularExpressions.Match 
                    For Each match1 In matchCollection1
                        If match1.Success AndAlso match1.Groups("code?").Success AndAlso System.Int32.TryParse(match1.Groups("code?").Value, ByRef i1) Then
                            Dim i2 As Integer = i1 + 64
                            If i2 < 255 Then
                                s2 = s2.Replace(System.String.Format("&#195;&#{0};?", i1), System.String.Format("&#{0};?", i2))
                            End If
                        End If
                    Next
                    s2 = s2.Replace("&?", "&amp;?")
                    title = System.Web.HttpUtility.HtmlDecode(Sublight.Controls.PageSearch.GetXmlRpcResponseValue(s2, "MovieName?"))
                    imdb = Sublight.Controls.PageSearch.GetXmlRpcResponseValue(s2, "IDMovieImdb?")
                End If
                flag1 = True
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

        Private Shared Function GetXmlRpcResponseValue(ByVal response As String, ByVal name As String) As String
            Dim s3 As String

            Try
                Dim xmlDocument1 As System.Xml.XmlDocument = New System.Xml.XmlDocument
                xmlDocument1.LoadXml(response)
                Dim xmlNodeList1 As System.Xml.XmlNodeList = xmlDocument1.GetElementsByTagName("struct?")
                Dim xmlNode1 As System.Xml.XmlNode 
                For Each xmlNode1 In xmlNodeList1
                    Dim xmlNodeList2 As System.Xml.XmlNodeList = xmlNode1.SelectNodes("member?")
                    If Not (xmlNodeList2) Is Nothing Then
                        Dim xmlNode2 As System.Xml.XmlNode 
                        For Each xmlNode2 In xmlNodeList2
                            Dim s1 As String = xmlNode2.SelectSingleNode("name?").InnerText
                            If System.String.Compare(s1, name, True) = 0 Then
                                Dim s2 As String = xmlNode2.SelectSingleNode("value?").ChildNodes(0).InnerText
                                s3 = s2
                                Return s3
                            End If
                        Next
                    End If
                Next
                s3 = Nothing
            Catch e As System.Exception
                s3 = Nothing
            End Try
            Return s3
        End Function

        Private Shared Sub HashThread(ByVal arg As Object)
            Dim l1 As Long
            Dim s3 As String, s4 As String, s5 As String, s6 As String

            Try
                Dim objArr1 As Object() = TryCast(arg, Object[])
                If ((objArr1) Is Nothing) OrElse (objArr1.Length <> 2) Then
                    Return
                End If
                Dim s1 As String = TryCast(objArr1(0), string)
                Dim s2 As String = TryCast(objArr1(1), string)
                If System.String.IsNullOrEmpty(s1) OrElse System.String.IsNullOrEmpty(s2) Then
                    Return
                End If
                If Not Sublight.Controls.PageSearch.GetOsdbTitleImdb(s1, out l1, out s3, out s4, out s5) Then
                    Return
                End If
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    sublight1.MapHash(Sublight.BaseForm.Session, s2, s3, s5, s4, l1, out s6)
                End Using
            Catch e As System.Exception
            End Try
        End Sub

        Private Shared Function PodnapisiNetLogin(ByVal username As String, ByVal password As String) As String
            Dim s8 As String

            Try
                Dim s1 As String = "<?xml version='1.0'?>
<methodCall>
<methodName>initiate</methodName>
<params>
<param>
<value><string>{0}</string></value>
</param>
</params>
</methodCall>?"
                Dim s2 As String = Sublight.Controls.PageSearch.XmlRpcCall("http://ssp.podnapisi.net:8000/RPC2?", System.String.Format(s1, Sublight.BaseForm.ClientInfo))
                Dim s3 As String = Sublight.Controls.PageSearch.GetXmlRpcResponseValue(s2, "session?")
                Dim s4 As String = Sublight.Controls.PageSearch.GetXmlRpcResponseValue(s2, "nonce?")
                s1 = "<?xml version='1.0'?>
<methodCall>
<methodName>authenticate</methodName>
<params>
<param>
<value><string>{0}</string></value>
</param>
<param>
<value><string>{1}</string></value>
</param>
<param>
<value><string>{2}</string></value>
</param>
</params>
</methodCall>?"
                Dim s5 As String = password
                Dim md5_1 As System.Security.Cryptography.MD5 = New System.Security.Cryptography.MD5CryptoServiceProvider
                Dim encoding1 As System.Text.Encoding = System.Text.Encoding.GetEncoding(1250)
                Dim bArr1 As Byte() = md5_1.ComputeHash(encoding1.GetBytes(s5))
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim bArr2 As Byte() = bArr1
                Dim i1 As Integer = 0
                While i1 < bArr2.Length
                    Dim b1 As Byte = bArr2(i1)
                    stringBuilder1.Append(b1.ToString("x2?"))
                    i1 = i1 + 1
                End While
                s5 = stringBuilder1.ToString()
                s5 = s5 + s4
                Dim sha256_1 As System.Security.Cryptography.SHA256 = New System.Security.Cryptography.SHA256Managed
                bArr1 = sha256_1.ComputeHash(encoding1.GetBytes(s5))
                stringBuilder1 = New System.Text.StringBuilder
                Dim bArr3 As Byte() = bArr1
                Dim i2 As Integer = 0
                While i2 < bArr3.Length
                    Dim b2 As Byte = bArr3(i2)
                    stringBuilder1.Append(b2.ToString("x2?"))
                    i2 = i2 + 1
                End While
                s5 = stringBuilder1.ToString()
                s2 = Sublight.Controls.PageSearch.XmlRpcCall("http://ssp.podnapisi.net:8000/RPC2?", System.String.Format(s1, s3, username, s5))
                Dim s6 As String = Sublight.Controls.PageSearch.GetXmlRpcResponseValue(s2, "status?")
                If s6 <> "200?" Then
                    Return Nothing
                End If
                s1 = "<?xml version='1.0'?>
<methodCall>
<methodName>cookieLogin</methodName>
<params>
<param>
<value><string>{0}</string></value>
</param>
</params>
</methodCall>?"
                s2 = Sublight.Controls.PageSearch.XmlRpcCall("http://ssp.podnapisi.net:8000/RPC2?", System.String.Format(s1, s3))
                s6 = Sublight.Controls.PageSearch.GetXmlRpcResponseValue(s2, "status?")
                If s6 <> "200?" Then
                    Return Nothing
                End If
                Dim s7 As String = Sublight.Controls.PageSearch.GetXmlRpcResponseValue(s2, "cookie?")
                s8 = s7
            Catch 
                s8 = Nothing
            End Try
            Return s8
        End Function

        Private Shared Function XmlRpcCall(ByVal query As String) As String
            Return Sublight.Controls.PageSearch.XmlRpcCall(Nothing, query)
        End Function

        Private Shared Function XmlRpcCall(ByVal url As String, ByVal query As String) As String
            Dim s2 As String
            Dim encoding1 As System.Text.Encoding

            Dim stream1 As System.IO.Stream = Nothing
            Dim httpWebResponse1 As System.Net.HttpWebResponse = Nothing
            Dim stream2 As System.IO.Stream = Nothing
            Dim streamReader1 As System.IO.StreamReader = Nothing
            Try
                Try
                    Dim s1 As String = "aHR0cDovL3d3dy5vcGVuc3VidGl0bGVzLm9yZy94bWwtcnBj?"
                    If System.String.IsNullOrEmpty(url) Then
                        s1 = Sublight.MyUtility.StringUtil.FromBase64String(s1)
                    Else 
                        s1 = url
                    End If
                    Dim httpWebRequest1 As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(s1), System.Net.HttpWebRequest)
                    httpWebRequest1.Method = "POST?"
                    httpWebRequest1.ProtocolVersion = System.Net.HttpVersion.Version10
                    httpWebRequest1.UserAgent = Sublight.BaseForm.ClientInfo
                    httpWebRequest1.ContentType = "text/xml?"
                    Dim bArr1 As Byte() = System.Text.Encoding.UTF8.GetBytes(query)
                    httpWebRequest1.ContentLength = CLng(bArr1.Length)
                    stream1 = httpWebRequest1.GetRequestStream()
                    stream1.Write(bArr1, 0, bArr1.Length)
                    stream1.Close()
                    httpWebResponse1 = CType(httpWebRequest1.GetResponse(), System.Net.HttpWebResponse)
                    stream2 = httpWebResponse1.GetResponseStream()
                    Try
                        encoding1 = System.Text.Encoding.GetEncoding(httpWebResponse1.CharacterSet)
                    Catch e As System.Exception
                        encoding1 = System.Text.Encoding.UTF8
                    End Try
                    streamReader1 = New System.IO.StreamReader(stream2, encoding1)
                    s2 = streamReader1.ReadToEnd()
                    Return s2
                Catch e As System.Exception
                    s2 = Nothing
                End Try
            Finally
                If Not (stream1) Is Nothing Then
                    stream1.Dispose()
                End If
                If Not (streamReader1) Is Nothing Then
                    streamReader1.Close()
                    streamReader1.Dispose()
                End If
                If Not (stream2) Is Nothing Then
                    stream2.Close()
                    stream2.Dispose()
                End If
                If Not (httpWebResponse1) Is Nothing Then
                    httpWebResponse1.Close()
                End If
            End Try
            Return s2
        End Function

    End Class ' class PageSearch

End Namespace

