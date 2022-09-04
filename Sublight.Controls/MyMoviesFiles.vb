Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Elegant.Ui
Imports Sublight
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.Types
Imports Utility.Video

Namespace Sublight.Controls

    Friend Class MyMoviesFiles
        Inherits Sublight.Controls.BasePage

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass8

            Public <>4__this As Sublight.Controls.MyMoviesFiles 
            Public info As System.Collections.Generic.Dictionary(Of String,String) 
            Public ts As System.TimeSpan 
            Public videoCodec As Sublight.Controls.PageSearch.VideoCodec 

            Public Sub New()
            End Sub

            Public Sub <vid_Result>b__0()
                <>4__this.txtVideoCodec.Text = System.Enum.GetName(GetType(Sublight.Controls.PageSearch.VideoCodec), videoCodec)
            End Sub

            Public Sub <vid_Result>b__1()
                <>4__this.txtVideoCodecID.Text = info.get_Item("CodecID?")
            End Sub

            Public Sub <vid_Result>b__2()
                <>4__this.txtVideoFormat.Text = info.get_Item("Format?")
            End Sub

            Public Sub <vid_Result>b__3()
                <>4__this.txtFrameRate.Text = info.get_Item("FrameRate?")
            End Sub

            Public Sub <vid_Result>b__4()
                <>4__this.txtFrameWidth.Text = info.get_Item("Width?")
            End Sub

            Public Sub <vid_Result>b__5()
                <>4__this.txtFrameHeight.Text = info.get_Item("Height?")
            End Sub

            Public Sub <vid_Result>b__6()
                <>4__this.txtAudioFormat.Text = info.get_Item("AudioFormat?")
            End Sub

            Public Sub <vid_Result>b__7()
                <>4__this.txtRuntime.Text = System.String.Format("{0:00}:{1:00}:{2:00}?", ts.Hours, ts.Minutes, ts.Seconds)
            End Sub

        End Class ' class <>c__DisplayClass8

        Private Const COLUMN_SubtitleAvailable As String  = "SubtitleAvailable"

        Private ReadOnly lvwColumnSorter As Sublight.MyUtility.ListViewColumnSorter 
        Private ReadOnly m_searchPage As Sublight.Controls.PageSearch 

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <MyMoviesFolderCtrl>k__BackingField As Sublight.Controls.MyMoviesFolder 
        Private backgroundWorker1 As System.ComponentModel.BackgroundWorker 
        Private btnClear As System.Windows.Forms.ToolStripButton 
        Private btnFileDetails As System.Windows.Forms.ToolStripButton 
        Private btnScanFiles As System.Windows.Forms.ToolStripButton 
        Private btnScanFilesFull As System.Windows.Forms.ToolStripButton 
        Private colCreated As System.Windows.Forms.ColumnHeader 
        Private colFile As System.Windows.Forms.ColumnHeader 
        Private colFolder As System.Windows.Forms.ColumnHeader 
        Private colHash As System.Windows.Forms.ColumnHeader 
        Private colSize As System.Windows.Forms.ColumnHeader 
        Private colSubtitle As System.Windows.Forms.ColumnHeader 
        Private components As System.ComponentModel.IContainer 
        Private imageList1 As System.Windows.Forms.ImageList 
        Private lblAudioFormat As System.Windows.Forms.Label 
        Private lblFrameHeight As System.Windows.Forms.Label 
        Private lblFrameRate As System.Windows.Forms.Label 
        Private lblFrameWidth As System.Windows.Forms.Label 
        Private lblHits As System.Windows.Forms.ToolStripLabel 
        Private lblRuntime As System.Windows.Forms.Label 
        Private lblVideoCodec As System.Windows.Forms.Label 
        Private lblVideoCodecID As System.Windows.Forms.Label 
        Private lblVideoFormat As System.Windows.Forms.Label 
        Private lvResults As Sublight.Controls.MyListView 
        Private m_CachedFilesPath As String 
        Private m_DsMyMovies As System.Data.DataSet 
        Private m_initialized As Boolean 
        Private mnuAction As System.Windows.Forms.ToolStripSplitButton 
        Private mnuActionOpenInExplorer As System.Windows.Forms.ToolStripMenuItem 
        Private mnuActionRenameFile As System.Windows.Forms.ToolStripMenuItem 
        Private mnuActionSearchSubtitles As System.Windows.Forms.ToolStripMenuItem 
        Private mnuActionSublightCmd As System.Windows.Forms.ToolStripMenuItem 
        Private mnuActionSublightCmdHelp As System.Windows.Forms.ToolStripMenuItem 
        Private mnuActionSublightCmdNFO As System.Windows.Forms.ToolStripMenuItem 
        Private mnuActionSublightCmdSynopsis As System.Windows.Forms.ToolStripMenuItem 
        Private mnuFileActions As System.Windows.Forms.ContextMenuStrip 
        Private myGroupBox1 As Sublight.Controls.MyGroupBox 
        Private splitContainer1 As Sublight.Controls.MySplitContainer 
        Private toolStrip2 As Sublight.Controls.SecondaryToolStrip 
        Private txtAudioFormat As Sublight.Controls.MyTextBox 
        Private txtFrameHeight As Sublight.Controls.MyTextBox 
        Private txtFrameRate As Sublight.Controls.MyTextBox 
        Private txtFrameWidth As Sublight.Controls.MyTextBox 
        Private txtRuntime As Sublight.Controls.MyTextBox 
        Private txtVideoCodec As Sublight.Controls.MyTextBox 
        Private txtVideoCodecID As Sublight.Controls.MyTextBox 
        Private txtVideoFormat As Sublight.Controls.MyTextBox 

        Protected ReadOnly Property CachedFilesPath As String
            Get
                If (m_CachedFilesPath) Is Nothing Then
                    m_CachedFilesPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
                    m_CachedFilesPath = System.IO.Path.Combine(m_CachedFilesPath, "SublightCache\MyMovies.xml?")
                End If
                Return m_CachedFilesPath
            End Get
        End Property

        Protected ReadOnly Property DsMyMovies As System.Data.DataSet
            Get
                If (m_DsMyMovies) Is Nothing Then
                    Try
                        If System.IO.File.Exists(CachedFilesPath) Then
                            m_DsMyMovies = New System.Data.DataSet
                            m_DsMyMovies.ReadXml(CachedFilesPath, System.Data.XmlReadMode.ReadSchema)
                        Else 
                            m_DsMyMovies = Sublight.Controls.MyMoviesFiles.CreateNewDataSet()
                        End If
                    Catch 
                        m_DsMyMovies = Sublight.Controls.MyMoviesFiles.CreateNewDataSet()
                    End Try
                End If
                Return m_DsMyMovies
            End Get
        End Property

        Protected ReadOnly Property DtMyMovies As System.Data.DataTable
            Get
                Dim dataSet1 As System.Data.DataSet = DsMyMovies
                If (dataSet1) Is Nothing Then
                    Return Nothing
                End If
                If dataSet1.Tables.Contains("MyMovies?") Then
                    Dim dataTable1 As System.Data.DataTable = dataSet1.Tables("MyMovies?")
                    If Not dataTable1.Columns.Contains("SubtitleAvailable?") Then
                        dataTable1.Columns.Add("SubtitleAvailable?", GetType(bool))
                    End If
                    Return dataTable1
                End If
                Return Nothing
            End Get
        End Property

        Protected ReadOnly Property IsFileSelected As Boolean
            Get
                If (Not (lvResults.SelectedItems) Is Nothing) AndAlso (lvResults.SelectedItems.Count = 1) Then
                    Return True
                End If
                Return False
            End Get
        End Property

        Public Property MyMoviesFolderCtrl As Sublight.Controls.MyMoviesFolder
            Get
                Return <MyMoviesFolderCtrl>k__BackingField
            End Get
            Set
                <MyMoviesFolderCtrl>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal searchPage As Sublight.Controls.PageSearch, ByVal rtp As Elegant.Ui.RibbonTabPage)
            InitializeComponent()
            m_searchPage = searchPage
            backgroundWorker1.WorkerReportsProgress = True
            Dim list1 As System.Collections.Generic.List(Of Sublight.Controls.MyTextBox) = New System.Collections.Generic.List(Of Sublight.Controls.MyTextBox)
            list1.Add(txtVideoCodec)
            list1.Add(txtVideoCodecID)
            list1.Add(txtVideoFormat)
            list1.Add(txtFrameRate)
            list1.Add(txtFrameWidth)
            list1.Add(txtFrameHeight)
            list1.Add(txtAudioFormat)
            list1.Add(txtRuntime)
            mnuActionSublightCmdSynopsis.Text = "SublightCmd synopsis?"
            mnuActionSublightCmdNFO.Text = "SublightCmd nfo?"
            mnuActionSublightCmdHelp.Text = "SublightCmd help?"
            Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Controls.MyTextBox).Enumerator = list1.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim myTextBox1 As Sublight.Controls.MyTextBox = enumerator1.get_Current()
                    myTextBox1.EnableDisableColor = False
                    myTextBox1.BackColor = Sublight.Globals.ColorBackgroundLight1
                End While
            Finally
                enumerator1.Dispose()
            End Try
            btnFileDetails.Checked = Sublight.Properties.Settings.Default.MyMovies_Files_ShowFileDetails
            splitContainer1.Panel2Collapsed = Not Sublight.Properties.Settings.Default.MyMovies_Files_ShowFileDetails
            EnableDisableFileActions()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            lvwColumnSorter = New Sublight.MyUtility.ListViewColumnSorter
            lvResults.ListViewItemSorter = lvwColumnSorter
        End Sub

        Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
            Dim flag1 As Boolean = DirectCast(e.Argument, bool)
            If flag1 Then
                DtMyMovies.Clear()
            End If
            Dim sArr1 As String() = FindAllFiles()
            If ((sArr1) Is Nothing) OrElse (sArr1.Length <= 0) Then
                DtMyMovies.Clear()
                Return
            End If
            Dim dictionary1 As System.Collections.Generic.Dictionary(Of String,Boolean) = New System.Collections.Generic.Dictionary(Of String,Boolean)
            Dim i1 As Integer = 0
            While i1 < sArr1.Length
                Dim s1 As String = sArr1(i1)
                Dim i2 As Integer = System.Convert.ToInt32(CDbl(i1) / System.Convert.ToDouble(sArr1.Length) * 100.0R)
                backgroundWorker1.ReportProgress(i2)
                Dim s2 As String = s1.ToLower()
                dictionary1.Add(s2, 1)
                Dim dataRow1 As System.Data.DataRow = DtMyMovies.Rows.Find(s2)
                If Not (dataRow1) Is Nothing Then
                    dataRow1("SubtitleAvailable?") = Sublight.MyUtility.SubtitleUtil.IsSubtitleAvailable(s1)
                Else 
                    Try
                        Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(s1)
                        Dim s3 As String = Utility.Video.Checksum.Compute(s1)
                        If System.String.IsNullOrEmpty(s3) Then
                            GoTo label_1
                        End If
                        Dim objArr1 As Object() = New object() { _
                                                                 s2, _
                                                                 s1, _
                                                                 fileInfo1.CreationTime, _
                                                                 fileInfo1.Length, _
                                                                 s3, _
                                                                 Sublight.MyUtility.SubtitleUtil.IsSubtitleAvailable(s1) }
                        DtMyMovies.Rows.Add(objArr1)
                    Catch 
                    End Try
                End If
            label_1: _
                i1 = i1 + 1
            End While
            Dim list1 As System.Collections.Generic.List(Of System.Data.DataRow) = New System.Collections.Generic.List(Of System.Data.DataRow)
            Dim dataRow2 As System.Data.DataRow 
            For Each dataRow2 In DtMyMovies.Rows
                Dim s4 As String = TryCast(dataRow2("Path?"), string)
                If System.String.IsNullOrEmpty(s4) Then
                    list1.Add(dataRow2)
                Else 
                    s4 = s4.ToLower()
                    If Not dictionary1.ContainsKey(s4) Then
                        list1.Add(dataRow2)
                    End If
                End If
            Next
            Dim enumerator1 As System.Collections.Generic.List(Of System.Data.DataRow).Enumerator = list1.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim dataRow3 As System.Data.DataRow = enumerator1.get_Current()
                    DtMyMovies.Rows.Remove(dataRow3)
                End While
            Finally
                enumerator1.Dispose()
            End Try
            Try
                Dim fileInfo2 As System.IO.FileInfo = New System.IO.FileInfo(CachedFilesPath)
                If Not (fileInfo2.Directory) Is Nothing Then
                    Dim s5 As String = fileInfo2.Directory.FullName
                    If Not System.IO.Directory.Exists(s5) Then
                        System.IO.Directory.CreateDirectory(s5)
                    End If
                    DsMyMovies.WriteXml(CachedFilesPath, System.Data.XmlWriteMode.WriteSchema)
                End If
            Catch 
            End Try
        End Sub

        Private Sub backgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
            Dim s1 As String = TryCast(e.UserState, string)
            If (Not (s1) Is Nothing) AndAlso (System.String.Compare(s1, "Ping?", True) = 0) Then
                ParentBaseForm.PingLoaderForm()
                Return
            End If
            Try
                ParentBaseForm.SetLoaderFormText(System.String.Format(Sublight.Translation.MyMovies_FileScan_Status_Done, e.ProgressPercentage))
            Catch e1 As System.Exception
                Throw New System.Exception(System.String.Format("Ex (lang = '{1}'): {0}?", e1.Message, Sublight.Properties.Settings.Default.AppLanguage))
            End Try
        End Sub

        Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
            LoadFileList()
            ParentBaseForm.HideLoader(Me)
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                DtMyMovies.Clear()
                Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(CachedFilesPath)
                If Not (fileInfo1.Directory) Is Nothing Then
                    Dim s1 As String = fileInfo1.Directory.FullName
                    If Not System.IO.Directory.Exists(s1) Then
                        System.IO.Directory.CreateDirectory(s1)
                    End If
                    DsMyMovies.WriteXml(CachedFilesPath, System.Data.XmlWriteMode.WriteSchema)
                End If
            Catch 
            Finally
                LoadFileList()
            End Try
        End Sub

        Private Sub btnFileDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Sublight.Properties.Settings.Default.MyMovies_Files_ShowFileDetails = btnFileDetails.Checked
            ParentBaseForm.SaveUserSettings()
            If btnFileDetails.Checked Then
                splitContainer1.Panel2Collapsed = False
                DoFileDetails()
                Return
            End If
            splitContainer1.Panel2Collapsed = True
        End Sub

        Private Sub btnScanFiles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not EnsureFolders() Then
                Return
            End If
            ParentBaseForm.ShowLoader(Me)
            ParentBaseForm.SetLoaderFormText(Sublight.Translation.MyMovies_FileScan_Status_SearchingFiles)
            backgroundWorker1.RunWorkerAsync(0)
        End Sub

        Private Sub btnScanFilesFull_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not EnsureFolders() Then
                Return
            End If
            ParentBaseForm.ShowLoader(Me)
            ParentBaseForm.SetLoaderFormText(Sublight.Translation.MyMovies_FileScan_Status_SearchingFiles)
            backgroundWorker1.RunWorkerAsync(1)
        End Sub

        Private Sub ClearFileDetails()
            txtVideoCodec.Text = System.String.Empty
            txtVideoCodecID.Text = System.String.Empty
            txtVideoFormat.Text = System.String.Empty
            txtFrameRate.Text = System.String.Empty
            txtFrameWidth.Text = System.String.Empty
            txtFrameHeight.Text = System.String.Empty
            txtAudioFormat.Text = System.String.Empty
            txtRuntime.Text = System.String.Empty
        End Sub

        Private Sub DoFileDetails()
            If Not IsFileSelected Then
                ClearFileDetails()
                Return
            End If
            Dim listViewItem1 As System.Windows.Forms.ListViewItem = lvResults.SelectedItems(0)
            Dim dataRow1 As System.Data.DataRow = TryCast(listViewItem1.Tag, System.Data.DataRow)
            If (dataRow1) Is Nothing Then
                Return
            End If
            Dim s1 As String = TryCast(dataRow1("Path?"), string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            If btnFileDetails.Checked Then
                Dim videoInfoDetailed1 As Sublight.MyUtility.VideoInfoDetailed = New Sublight.MyUtility.VideoInfoDetailed(s1)
                AddHandler videoInfoDetailed1.Result, AddressOf vid_Result
                videoInfoDetailed1.DoAsync()
            End If
        End Sub

        Private Sub EnableDisableFileActions()
            myGroupBox1.Enabled = IsFileSelected
            mnuAction.Enabled = IsFileSelected
        End Sub

        Private Function EnsureFolders() As Boolean
            If Sublight.Controls.MyMoviesFolder.NumberOfFolders <= 0 Then
                ParentBaseForm.ShowInfo(Sublight.Translation.MyMovies_FileScan_Info_NoVideoFolders, New object(0) {})
                Return False
            End If
            Return True
        End Function

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            btnScanFiles.Text = Sublight.Translation.MyMovies_FileScan_Button_ScanFilesNewOnly
            btnScanFilesFull.Text = Sublight.Translation.MyMovies_FileScan_Button_ScanFilesFull
            mnuAction.Text = Sublight.Translation.MyMovies_FileScan_Button_FileActions
            btnFileDetails.Text = Sublight.Translation.MyMovies_FileScan_Button_ShowFileDetails
            btnClear.Text = Sublight.Translation.MyMovies_FileScan_Button_ClearList
            colFile.Text = Sublight.Translation.MyMovies_FileScan_Column_Name
            colFolder.Text = Sublight.Translation.MyMovies_FileScan_Column_Folder
            colCreated.Text = Sublight.Translation.MyMovies_FileScan_Column_Created
            colSize.Text = Sublight.Translation.MyMovies_FileScan_Column_Size
            colHash.Text = Sublight.Translation.MyMovies_FileScan_Column_Hash
            colSubtitle.Text = Sublight.Translation.MyMovies_FileScan_Column_Subtitle
            myGroupBox1.Text = Sublight.Translation.MyMovies_FileScan_GroupBox_FileDetails
            mnuActionSearchSubtitles.Text = Sublight.Translation.MyMovies_FileScan_ContextMenu_FileActions_SearchSubtitles
            mnuActionOpenInExplorer.Text = Sublight.Translation.MyMovies_FileScan_ContextMenu_FileActions_OpenInExplorer
            mnuActionSublightCmd.Text = Sublight.Translation.MyMovies_FileScan_ContextMenu_FileActions_RunSublightCmd
            lblVideoCodec.Text = Sublight.Translation.Common_MediaInfo_VideoCodec
            lblVideoCodecID.Text = Sublight.Translation.Common_MediaInfo_VideoCodecID
            lblVideoFormat.Text = Sublight.Translation.Common_MediaInfo_VideoFormat
            lblFrameRate.Text = Sublight.Translation.Common_MediaInfo_FrameRate
            lblFrameWidth.Text = Sublight.Translation.Common_MediaInfo_FrameWidth
            lblFrameHeight.Text = Sublight.Translation.Common_MediaInfo_FrameHeight
            lblAudioFormat.Text = Sublight.Translation.Common_MediaInfo_AudioFormat
            lblRuntime.Text = Sublight.Translation.Common_MediaInfo_Runtime
        End Sub

        Private Function FindAllFiles() As String()
            Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
            If Not (Sublight.Properties.Settings.Default.MyMovies_Folders) Is Nothing Then
                Dim dictionary1 As System.Collections.Generic.Dictionary(Of String,Boolean) = New System.Collections.Generic.Dictionary(Of String,Boolean)
                Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Types.MovieFolder).Enumerator = Sublight.Properties.Settings.Default.MyMovies_Folders.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim movieFolder1 As Sublight.Types.MovieFolder = enumerator1.get_Current()
                        Try
                            If Not System.IO.Directory.Exists(movieFolder1.Path) Then
                                Continue
                            End If
                            Dim chArr1 As Char() = New char() { ";"C }
                            Dim sArr1 As String() = movieFolder1.Pattern.Split(chArr1, System.StringSplitOptions.RemoveEmptyEntries)
                            If (sArr1) Is Nothing Then
                                Continue
                            End If
                            Dim list2 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                            Dim sArr3 As String() = sArr1
                            Dim i1 As Integer = 0
                            While i1 < sArr3.Length
                                Dim s1 As String = sArr3(i1)
                                Dim sArr2 As String() = System.IO.Directory.GetFiles(movieFolder1.Path, s1.Trim(), IIf(movieFolder1.SearchSubfolders, System.IO.SearchOption.AllDirectories, System.IO.SearchOption.TopDirectoryOnly))
                                If (Not (sArr2) Is Nothing) AndAlso (sArr2.Length > 0) Then
                                    list2.AddRange(sArr2)
                                End If
                                i1 = i1 + 1
                            End While
                            backgroundWorker1.ReportProgress(0, "Ping?")
                            Dim enumerator2 As System.Collections.Generic.List(Of String).Enumerator = list2.GetEnumerator()
                            Try
                                While enumerator2.MoveNext()
                                    Dim s2 As String = enumerator2.get_Current()
                                    Dim s3 As String = s2.ToLower()
                                    If Not dictionary1.ContainsKey(s3) Then
                                        list1.Add(s2)
                                        dictionary1.Add(s3, 1)
                                    End If
                                End While
                            Finally
                                enumerator2.Dispose()
                            End Try
                        Catch 
                        End Try
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
            End If
            Return list1.ToArray()
        End Function

        Public Sub Init()
            If m_initialized Then
                Return
            End If
            m_initialized = True
            Try
                ParentBaseForm.ShowLoader(Me)
                LoadFileList()
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.Controls.MyMoviesFiles))
            toolStrip2 = New Sublight.Controls.SecondaryToolStrip
            btnScanFiles = New System.Windows.Forms.ToolStripButton
            btnScanFilesFull = New System.Windows.Forms.ToolStripButton
            lblHits = New System.Windows.Forms.ToolStripLabel
            mnuAction = New System.Windows.Forms.ToolStripSplitButton
            mnuFileActions = New System.Windows.Forms.ContextMenuStrip(components)
            mnuActionSearchSubtitles = New System.Windows.Forms.ToolStripMenuItem
            mnuActionOpenInExplorer = New System.Windows.Forms.ToolStripMenuItem
            mnuActionSublightCmd = New System.Windows.Forms.ToolStripMenuItem
            mnuActionSublightCmdNFO = New System.Windows.Forms.ToolStripMenuItem
            mnuActionSublightCmdSynopsis = New System.Windows.Forms.ToolStripMenuItem
            mnuActionSublightCmdHelp = New System.Windows.Forms.ToolStripMenuItem
            mnuActionRenameFile = New System.Windows.Forms.ToolStripMenuItem
            btnClear = New System.Windows.Forms.ToolStripButton
            btnFileDetails = New System.Windows.Forms.ToolStripButton
            splitContainer1 = New Sublight.Controls.MySplitContainer
            lvResults = New Sublight.Controls.MyListView
            colFile = New System.Windows.Forms.ColumnHeader
            colFolder = New System.Windows.Forms.ColumnHeader
            colCreated = New System.Windows.Forms.ColumnHeader
            colSize = New System.Windows.Forms.ColumnHeader
            colSubtitle = New System.Windows.Forms.ColumnHeader
            colHash = New System.Windows.Forms.ColumnHeader
            imageList1 = New System.Windows.Forms.ImageList(components)
            myGroupBox1 = New Sublight.Controls.MyGroupBox
            txtFrameHeight = New Sublight.Controls.MyTextBox
            lblFrameHeight = New System.Windows.Forms.Label
            txtRuntime = New Sublight.Controls.MyTextBox
            lblRuntime = New System.Windows.Forms.Label
            txtAudioFormat = New Sublight.Controls.MyTextBox
            lblAudioFormat = New System.Windows.Forms.Label
            txtFrameWidth = New Sublight.Controls.MyTextBox
            lblFrameWidth = New System.Windows.Forms.Label
            txtFrameRate = New Sublight.Controls.MyTextBox
            lblFrameRate = New System.Windows.Forms.Label
            txtVideoFormat = New Sublight.Controls.MyTextBox
            lblVideoFormat = New System.Windows.Forms.Label
            txtVideoCodecID = New Sublight.Controls.MyTextBox
            lblVideoCodecID = New System.Windows.Forms.Label
            txtVideoCodec = New Sublight.Controls.MyTextBox
            lblVideoCodec = New System.Windows.Forms.Label
            backgroundWorker1 = New System.ComponentModel.BackgroundWorker
            toolStrip2.SuspendLayout()
            mnuFileActions.SuspendLayout()
            splitContainer1.Panel1.SuspendLayout()
            splitContainer1.Panel2.SuspendLayout()
            splitContainer1.SuspendLayout()
            myGroupBox1.SuspendLayout()
            SuspendLayout()
            Dim toolStripItemArr1 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       btnScanFiles, _
                                                                                                                       btnScanFilesFull, _
                                                                                                                       lblHits, _
                                                                                                                       mnuAction, _
                                                                                                                       btnClear, _
                                                                                                                       btnFileDetails }
            toolStrip2.Items.AddRange(toolStripItemArr1)
            toolStrip2.Location = New System.Drawing.Point(0, 0)
            toolStrip2.Name = "toolStrip2?"
            toolStrip2.Size = New System.Drawing.Size(846, 27)
            toolStrip2.TabIndex = 134
            toolStrip2.Text = "toolStrip2?"
            btnScanFiles.Image = Sublight.Properties.Resources.ToolbarSearch
            btnScanFiles.ImageTransparentColor = System.Drawing.Color.Magenta
            btnScanFiles.Name = "btnScanFiles?"
            btnScanFiles.Size = New System.Drawing.Size(135, 24)
            btnScanFiles.Text = "Scan files (only new)?"
            AddHandler btnScanFiles.Click, AddressOf btnScanFiles_Click
            btnScanFilesFull.Image = Sublight.Properties.Resources.ToolbarSearch
            btnScanFilesFull.ImageTransparentColor = System.Drawing.Color.Magenta
            btnScanFilesFull.Name = "btnScanFilesFull?"
            btnScanFilesFull.Size = New System.Drawing.Size(104, 24)
            btnScanFilesFull.Text = "Scan files (full)?"
            AddHandler btnScanFilesFull.Click, AddressOf btnScanFilesFull_Click
            lblHits.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            lblHits.Name = "lblHits?"
            lblHits.Size = New System.Drawing.Size(57, 24)
            lblHits.Text = "X datotek?"
            lblHits.Visible = False
            mnuAction.DropDown = mnuFileActions
            mnuAction.Image = Sublight.Properties.Resources.ToolbarLightningSmall
            mnuAction.ImageTransparentColor = System.Drawing.Color.Magenta
            mnuAction.Name = "mnuAction?"
            mnuAction.Size = New System.Drawing.Size(98, 24)
            mnuAction.Text = "File actions?"
            AddHandler mnuAction.ButtonClick, AddressOf mnuAction_ButtonClick
            Dim toolStripItemArr2 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       mnuActionSearchSubtitles, _
                                                                                                                       mnuActionOpenInExplorer, _
                                                                                                                       mnuActionSublightCmd, _
                                                                                                                       mnuActionRenameFile }
            mnuFileActions.Items.AddRange(toolStripItemArr2)
            mnuFileActions.Name = "mnuFileActions?"
            mnuFileActions.OwnerItem = mnuAction
            mnuFileActions.Size = New System.Drawing.Size(176, 114)
            AddHandler mnuFileActions.Opening, AddressOf mnuFileActions_Opening
            mnuActionSearchSubtitles.Name = "mnuActionSearchSubtitles?"
            mnuActionSearchSubtitles.Size = New System.Drawing.Size(175, 22)
            mnuActionSearchSubtitles.Text = "Search subtitles?"
            AddHandler mnuActionSearchSubtitles.Click, AddressOf mnuActionSearchSubtitles_Click
            mnuActionOpenInExplorer.Name = "mnuActionOpenInExplorer?"
            mnuActionOpenInExplorer.Size = New System.Drawing.Size(175, 22)
            mnuActionOpenInExplorer.Text = "Open in Explorer?"
            AddHandler mnuActionOpenInExplorer.Click, AddressOf mnuActionOpenInExplorer_Click
            Dim toolStripItemArr3 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       mnuActionSublightCmdNFO, _
                                                                                                                       mnuActionSublightCmdSynopsis, _
                                                                                                                       mnuActionSublightCmdHelp }
            mnuActionSublightCmd.DropDownItems.AddRange(toolStripItemArr3)
            mnuActionSublightCmd.Name = "mnuActionSublightCmd?"
            mnuActionSublightCmd.Size = New System.Drawing.Size(175, 22)
            mnuActionSublightCmd.Text = "Run SublightCmd?"
            mnuActionSublightCmdNFO.Name = "mnuActionSublightCmdNFO?"
            mnuActionSublightCmdNFO.Size = New System.Drawing.Size(120, 22)
            mnuActionSublightCmdNFO.Text = ".NFO?"
            AddHandler mnuActionSublightCmdNFO.Click, AddressOf mnuActionSublightCmdNFO_Click
            mnuActionSublightCmdSynopsis.Name = "mnuActionSublightCmdSynopsis?"
            mnuActionSublightCmdSynopsis.Size = New System.Drawing.Size(120, 22)
            mnuActionSublightCmdSynopsis.Text = "Synopsis?"
            AddHandler mnuActionSublightCmdSynopsis.Click, AddressOf mnuActionSublightCmdSynopsis_Click
            mnuActionSublightCmdHelp.Name = "mnuActionSublightCmdHelp?"
            mnuActionSublightCmdHelp.Size = New System.Drawing.Size(120, 22)
            mnuActionSublightCmdHelp.Text = "Help?"
            AddHandler mnuActionSublightCmdHelp.Click, AddressOf mnuActionSublightCmdHelp_Click
            mnuActionRenameFile.Name = "mnuActionRenameFile?"
            mnuActionRenameFile.Size = New System.Drawing.Size(175, 22)
            mnuActionRenameFile.Text = "Rename file to 'xyz'?"
            mnuActionRenameFile.Visible = False
            btnClear.ForeColor = System.Drawing.SystemColors.ControlText
            btnClear.Image = Sublight.Properties.Resources.ToolbarClearFormFields
            btnClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
            btnClear.Name = "btnClear?"
            btnClear.Size = New System.Drawing.Size(76, 24)
            btnClear.Text = "Clear list?"
            AddHandler btnClear.Click, AddressOf btnClear_Click
            btnFileDetails.Checked = True
            btnFileDetails.CheckOnClick = True
            btnFileDetails.CheckState = System.Windows.Forms.CheckState.Checked
            btnFileDetails.Image = Sublight.Properties.Resources.ToolbarDetailsSmall
            btnFileDetails.ImageTransparentColor = System.Drawing.Color.Magenta
            btnFileDetails.Name = "btnFileDetails?"
            btnFileDetails.Size = New System.Drawing.Size(112, 24)
            btnFileDetails.Text = "Show file details?"
            AddHandler btnFileDetails.Click, AddressOf btnFileDetails_Click
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
            splitContainer1.IsSplitterFixed = True
            splitContainer1.Location = New System.Drawing.Point(0, 27)
            splitContainer1.Name = "splitContainer1?"
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
            splitContainer1.Panel1.Controls.Add(lvResults)
            splitContainer1.Panel2.Controls.Add(myGroupBox1)
            splitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(8, 0, 8, 8)
            splitContainer1.Size = New System.Drawing.Size(846, 400)
            splitContainer1.SplitterDistance = 238
            splitContainer1.TabIndex = 136
            Dim columnHeaderArr1 As System.Windows.Forms.ColumnHeader() = New System.Windows.Forms.ColumnHeader() { _
                                                                                                                    colFile, _
                                                                                                                    colFolder, _
                                                                                                                    colCreated, _
                                                                                                                    colSize, _
                                                                                                                    colSubtitle, _
                                                                                                                    colHash }
            lvResults.Columns.AddRange(columnHeaderArr1)
            lvResults.ContextMenuStrip = mnuFileActions
            lvResults.Dock = System.Windows.Forms.DockStyle.Fill
            lvResults.FullRowSelect = True
            lvResults.HideSelection = False
            lvResults.Location = New System.Drawing.Point(0, 0)
            lvResults.MultiSelect = False
            lvResults.Name = "lvResults?"
            lvResults.Size = New System.Drawing.Size(846, 238)
            lvResults.SmallImageList = imageList1
            lvResults.TabIndex = 137
            lvResults.UseCompatibleStateImageBehavior = False
            lvResults.View = System.Windows.Forms.View.Details
            AddHandler lvResults.MouseClick, AddressOf lvResults_MouseClick
            AddHandler lvResults.SelectedIndexChanged, AddressOf lvResults_SelectedIndexChanged
            AddHandler lvResults.DoubleClick, AddressOf lvResults_DoubleClick
            AddHandler lvResults.ColumnClick, AddressOf lvResults_ColumnClick
            colFile.Text = "Name?"
            colFile.Width = 300
            colFolder.Text = "Folder?"
            colFolder.Width = 172
            colCreated.Text = "Created?"
            colCreated.Width = 102
            colSize.Text = "Size?"
            colSize.Width = 90
            colSubtitle.Text = "Subtitle?"
            colHash.Text = "Hash?"
            colHash.Width = 169
            imageList1.ImageStream = CType(componentResourceManager1.GetObject("imageList1.ImageStream?"), System.Windows.Forms.ImageListStreamer)
            imageList1.TransparentColor = System.Drawing.Color.Transparent
            imageList1.Images.SetKeyName(0, "OperationSuccess.gif?")
            imageList1.Images.SetKeyName(1, "IconVideoFile.gif?")
            myGroupBox1.Controls.Add(txtFrameHeight)
            myGroupBox1.Controls.Add(lblFrameHeight)
            myGroupBox1.Controls.Add(txtRuntime)
            myGroupBox1.Controls.Add(lblRuntime)
            myGroupBox1.Controls.Add(txtAudioFormat)
            myGroupBox1.Controls.Add(lblAudioFormat)
            myGroupBox1.Controls.Add(txtFrameWidth)
            myGroupBox1.Controls.Add(lblFrameWidth)
            myGroupBox1.Controls.Add(txtFrameRate)
            myGroupBox1.Controls.Add(lblFrameRate)
            myGroupBox1.Controls.Add(txtVideoFormat)
            myGroupBox1.Controls.Add(lblVideoFormat)
            myGroupBox1.Controls.Add(txtVideoCodecID)
            myGroupBox1.Controls.Add(lblVideoCodecID)
            myGroupBox1.Controls.Add(txtVideoCodec)
            myGroupBox1.Controls.Add(lblVideoCodec)
            myGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            myGroupBox1.DrawTextBackground = True
            myGroupBox1.Location = New System.Drawing.Point(8, 0)
            myGroupBox1.Name = "myGroupBox1?"
            myGroupBox1.Size = New System.Drawing.Size(830, 150)
            myGroupBox1.TabIndex = 2
            myGroupBox1.TabStop = False
            myGroupBox1.Text = "File details?"
            txtFrameHeight.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtFrameHeight.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtFrameHeight.EnableDisableColor = True
            txtFrameHeight.Id = "0053d000-85d3-443e-a7ae-3db8710c1c83?"
            txtFrameHeight.LabelText = "?"
            txtFrameHeight.Location = New System.Drawing.Point(540, 60)
            txtFrameHeight.Name = "txtFrameHeight?"
            txtFrameHeight.ReadOnly = True
            txtFrameHeight.Size = New System.Drawing.Size(171, 21)
            txtFrameHeight.TabIndex = 6
            lblFrameHeight.AutoSize = True
            lblFrameHeight.Location = New System.Drawing.Point(420, 60)
            lblFrameHeight.Name = "lblFrameHeight?"
            lblFrameHeight.Size = New System.Drawing.Size(71, 13)
            lblFrameHeight.TabIndex = 14
            lblFrameHeight.Text = "Frame height:?"
            txtRuntime.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtRuntime.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtRuntime.EnableDisableColor = True
            txtRuntime.Id = "0518cffb-0a9b-482b-8595-4c5f8734e058?"
            txtRuntime.LabelText = "?"
            txtRuntime.Location = New System.Drawing.Point(540, 112)
            txtRuntime.Name = "txtRuntime?"
            txtRuntime.ReadOnly = True
            txtRuntime.Size = New System.Drawing.Size(171, 21)
            txtRuntime.TabIndex = 8
            lblRuntime.AutoSize = True
            lblRuntime.Location = New System.Drawing.Point(420, 112)
            lblRuntime.Name = "lblRuntime?"
            lblRuntime.Size = New System.Drawing.Size(49, 13)
            lblRuntime.TabIndex = 12
            lblRuntime.Text = "Runtime:?"
            txtAudioFormat.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtAudioFormat.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtAudioFormat.EnableDisableColor = True
            txtAudioFormat.Id = "59544e93-fec2-484b-94e7-284e45a9f462?"
            txtAudioFormat.LabelText = "?"
            txtAudioFormat.Location = New System.Drawing.Point(540, 86)
            txtAudioFormat.Name = "txtAudioFormat?"
            txtAudioFormat.ReadOnly = True
            txtAudioFormat.Size = New System.Drawing.Size(171, 21)
            txtAudioFormat.TabIndex = 7
            lblAudioFormat.AutoSize = True
            lblAudioFormat.Location = New System.Drawing.Point(420, 86)
            lblAudioFormat.Name = "lblAudioFormat?"
            lblAudioFormat.Size = New System.Drawing.Size(69, 13)
            lblAudioFormat.TabIndex = 10
            lblAudioFormat.Text = "Audio format:?"
            txtFrameWidth.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtFrameWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtFrameWidth.EnableDisableColor = True
            txtFrameWidth.Id = "3cf512c8-7ea4-47ee-a3ff-28079d552ae5?"
            txtFrameWidth.LabelText = "?"
            txtFrameWidth.Location = New System.Drawing.Point(540, 32)
            txtFrameWidth.Name = "txtFrameWidth?"
            txtFrameWidth.ReadOnly = True
            txtFrameWidth.Size = New System.Drawing.Size(171, 21)
            txtFrameWidth.TabIndex = 5
            lblFrameWidth.AutoSize = True
            lblFrameWidth.Location = New System.Drawing.Point(420, 32)
            lblFrameWidth.Name = "lblFrameWidth?"
            lblFrameWidth.Size = New System.Drawing.Size(67, 13)
            lblFrameWidth.TabIndex = 8
            lblFrameWidth.Text = "Frame width:?"
            txtFrameRate.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtFrameRate.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtFrameRate.EnableDisableColor = True
            txtFrameRate.Id = "3e798f2f-ba6d-4ce1-804f-d768f8b6b169?"
            txtFrameRate.LabelText = "?"
            txtFrameRate.Location = New System.Drawing.Point(135, 112)
            txtFrameRate.Name = "txtFrameRate?"
            txtFrameRate.ReadOnly = True
            txtFrameRate.Size = New System.Drawing.Size(171, 21)
            txtFrameRate.TabIndex = 4
            lblFrameRate.AutoSize = True
            lblFrameRate.Location = New System.Drawing.Point(15, 112)
            lblFrameRate.Name = "lblFrameRate?"
            lblFrameRate.Size = New System.Drawing.Size(60, 13)
            lblFrameRate.TabIndex = 6
            lblFrameRate.Text = "Frame rate:?"
            txtVideoFormat.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtVideoFormat.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtVideoFormat.EnableDisableColor = True
            txtVideoFormat.Id = "28ca5d9c-4388-49b0-a9c0-5364ba8ac228?"
            txtVideoFormat.LabelText = "?"
            txtVideoFormat.Location = New System.Drawing.Point(135, 86)
            txtVideoFormat.Name = "txtVideoFormat?"
            txtVideoFormat.ReadOnly = True
            txtVideoFormat.Size = New System.Drawing.Size(171, 21)
            txtVideoFormat.TabIndex = 3
            lblVideoFormat.AutoSize = True
            lblVideoFormat.Location = New System.Drawing.Point(15, 86)
            lblVideoFormat.Name = "lblVideoFormat?"
            lblVideoFormat.Size = New System.Drawing.Size(69, 13)
            lblVideoFormat.TabIndex = 4
            lblVideoFormat.Text = "Video format:?"
            txtVideoCodecID.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtVideoCodecID.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtVideoCodecID.EnableDisableColor = True
            txtVideoCodecID.Id = "c1d3daee-b576-4dd6-958a-e0e9519018e1?"
            txtVideoCodecID.LabelText = "?"
            txtVideoCodecID.Location = New System.Drawing.Point(135, 60)
            txtVideoCodecID.Name = "txtVideoCodecID?"
            txtVideoCodecID.ReadOnly = True
            txtVideoCodecID.Size = New System.Drawing.Size(171, 21)
            txtVideoCodecID.TabIndex = 2
            lblVideoCodecID.AutoSize = True
            lblVideoCodecID.Location = New System.Drawing.Point(15, 60)
            lblVideoCodecID.Name = "lblVideoCodecID?"
            lblVideoCodecID.Size = New System.Drawing.Size(84, 13)
            lblVideoCodecID.TabIndex = 2
            lblVideoCodecID.Text = "Video codec ID:?"
            txtVideoCodec.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            txtVideoCodec.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtVideoCodec.EnableDisableColor = True
            txtVideoCodec.Id = "a81bf4de-e4b4-4fe5-977c-376a31ff6fc4?"
            txtVideoCodec.LabelText = "?"
            txtVideoCodec.Location = New System.Drawing.Point(135, 32)
            txtVideoCodec.Name = "txtVideoCodec?"
            txtVideoCodec.ReadOnly = True
            txtVideoCodec.Size = New System.Drawing.Size(171, 21)
            txtVideoCodec.TabIndex = 1
            lblVideoCodec.AutoSize = True
            lblVideoCodec.Location = New System.Drawing.Point(15, 32)
            lblVideoCodec.Name = "lblVideoCodec?"
            lblVideoCodec.Size = New System.Drawing.Size(70, 13)
            lblVideoCodec.TabIndex = 0
            lblVideoCodec.Text = "Video codec:?"
            AddHandler backgroundWorker1.DoWork, AddressOf backgroundWorker1_DoWork
            AddHandler backgroundWorker1.RunWorkerCompleted, AddressOf backgroundWorker1_RunWorkerCompleted
            AddHandler backgroundWorker1.ProgressChanged, AddressOf backgroundWorker1_ProgressChanged
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(splitContainer1)
            Controls.Add(toolStrip2)
            Name = "MyMoviesFiles?"
            Size = New System.Drawing.Size(846, 427)
            toolStrip2.ResumeLayout(False)
            toolStrip2.PerformLayout()
            mnuFileActions.ResumeLayout(False)
            splitContainer1.Panel1.ResumeLayout(False)
            splitContainer1.Panel2.ResumeLayout(False)
            splitContainer1.ResumeLayout(False)
            myGroupBox1.ResumeLayout(False)
            myGroupBox1.PerformLayout()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub LoadFileList()
            Dim d1 As Double
            Dim s2 As String
            Dim lv_ITEM1 As Sublight.Controls.MyListView.LV_ITEM

            lvResults.BeginUpdate()
            lvResults.Items.Clear()
            If Not (DtMyMovies) Is Nothing Then
                Dim dataRow1 As System.Data.DataRow 
                For Each dataRow1 In DtMyMovies.Rows
                    Dim s1 As String = TryCast(dataRow1("PathOrg?"), string)
                    If Not System.String.IsNullOrEmpty(s1) Then
                        Try
                            Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(s1)
                            Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
                            listViewItem1.ImageIndex = 1
                            listViewItem1.Text = fileInfo1.Name
                            listViewItem1.ToolTipText = s1
                            listViewItem1.Tag = dataRow1
                            listViewItem1.SubItems(listViewItem1.SubItems.Count - 1).Tag = fileInfo1.Name
                            If Not (fileInfo1.Directory) Is Nothing Then
                                listViewItem1.SubItems.Add(fileInfo1.Directory.FullName)
                            Else 
                                listViewItem1.SubItems.Add(System.String.Empty)
                            End If
                            Dim dateTime1 As System.DateTime = fileInfo1.CreationTime
                            Dim dateTime2 As System.DateTime = fileInfo1.CreationTime
                            listViewItem1.SubItems.Add(System.String.Format("{0} {1}?", dateTime1.ToShortDateString(), dateTime2.ToShortTimeString()))
                            listViewItem1.SubItems(listViewItem1.SubItems.Count - 1).Tag = fileInfo1.CreationTime
                            Dim l1 As Long = fileInfo1.Length
                            If CInt(l1) > 1073741824 Then
                                d1 = CDbl(l1) / 1073741824.0R
                                s2 = "GB?"
                            Else 
                                d1 = CDbl(l1) / 1048576.0R
                                s2 = "MB?"
                            End If
                            listViewItem1.SubItems.Add(System.String.Format("{0:0.00} {1}?", d1, s2))
                            listViewItem1.SubItems(listViewItem1.SubItems.Count - 1).Tag = fileInfo1.Length
                            listViewItem1.SubItems.Add(System.String.Empty)
                            Dim s3 As String = TryCast(dataRow1("Hash?"), string)
                            If (s3) Is Nothing Then
                                s3 = System.String.Empty
                            End If
                            listViewItem1.SubItems.Add(s3)
                            lvResults.Items.Add(listViewItem1)
                        Catch 
                        End Try
                        If (DtMyMovies.Rows.IndexOf(dataRow1) Mod 10) = 0 Then
                            System.Windows.Forms.Application.DoEvents()
                        End If
                    End If
                Next
            End If
            Dim i1 As Integer = 0
            Dim sortOrder1 As System.Windows.Forms.SortOrder = System.Windows.Forms.SortOrder.None
            If (Sublight.Properties.Settings.Default.MyMovies_Files_SortColumn >= 0) AndAlso Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.MyMovies_Files_SortOrder) AndAlso (Sublight.Properties.Settings.Default.MyMovies_Files_SortColumn < lvResults.Columns.Count) Then
                If System.String.Compare(Sublight.Properties.Settings.Default.MyMovies_Files_SortOrder, "ASC?", True) = 0 Then
                    i1 = Sublight.Properties.Settings.Default.MyMovies_Files_SortColumn
                    sortOrder1 = System.Windows.Forms.SortOrder.Ascending
                ElseIf System.String.Compare(Sublight.Properties.Settings.Default.MyMovies_Files_SortOrder, "DESC?", True) = 0 Then
                    i1 = Sublight.Properties.Settings.Default.MyMovies_Files_SortColumn
                    sortOrder1 = System.Windows.Forms.SortOrder.Descending
                Else 
                    i1 = 0
                    sortOrder1 = System.Windows.Forms.SortOrder.None
                End If
            End If
            lvwColumnSorter.Order = sortOrder1
            lvwColumnSorter.SortColumn = i1
            lvResults.Sort()
            If Not (DtMyMovies) Is Nothing Then
                Dim listViewItem2 As System.Windows.Forms.ListViewItem 
                For Each listViewItem2 In lvResults.Items
                    Dim dataRow2 As System.Data.DataRow = TryCast(listViewItem2.Tag, System.Data.DataRow)
                    If Not (dataRow2) Is Nothing Then
                        lv_ITEM1 = New Sublight.Controls.MyListView.LV_ITEM
                        lv_ITEM1.iItem = lvResults.Items.IndexOf(listViewItem2)
                        lv_ITEM1.iSubItem = 4
                        lv_ITEM1.pszText = System.String.Empty
                        lv_ITEM1.mask = 2
                        If DtMyMovies.Columns.Contains("SubtitleAvailable?") AndAlso Not dataRow2.IsNull("SubtitleAvailable?") AndAlso DirectCast(dataRow2("SubtitleAvailable?"), bool) Then
                            lv_ITEM1.iImage = 0
                            listViewItem2.SubItems(4).Tag = 1
                        Else 
                            lv_ITEM1.iImage = -1
                            listViewItem2.SubItems(4).Tag = 0
                        End If
                        Sublight.Controls.MyListView.SendMessage(lvResults.Handle, 4102, 0, ByRef lv_ITEM1)
                    End If
                Next
            End If
            lvResults.EndUpdate()
            EnableDisableFileActions()
        End Sub

        Private Sub lvResults_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
            If e.Column = lvwColumnSorter.SortColumn Then
                If lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending Then
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending
                Else 
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending
                End If
            Else 
                lvwColumnSorter.SortColumn = e.Column
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending
            End If
            lvResults.Sort()
            Try
                Sublight.Properties.Settings.Default.MyMovies_Files_SortColumn = lvwColumnSorter.SortColumn
                Sublight.Properties.Settings.Default.MyMovies_Files_SortOrder = IIf(lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending, "ASC?", "DESC?")
                Sublight.BaseForm.SaveUserSettingsSilent()
            Catch 
            End Try
        End Sub

        Private Sub lvResults_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
            PerformSearch()
        End Sub

        Private Sub lvResults_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                mnuFileActions.Left = e.X
                mnuFileActions.Top = e.Y
            End If
        End Sub

        Private Sub lvResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            EnableDisableFileActions()
            DoFileDetails()
        End Sub

        Private Sub mnuAction_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
            mnuAction.ShowDropDown()
        End Sub

        Private Sub mnuActionOpenInExplorer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not IsFileSelected Then
                Return
            End If
            Dim listViewItem1 As System.Windows.Forms.ListViewItem = lvResults.SelectedItems(0)
            Dim dataRow1 As System.Data.DataRow = TryCast(listViewItem1.Tag, System.Data.DataRow)
            If (dataRow1) Is Nothing Then
                Return
            End If
            Dim s1 As String = TryCast(dataRow1("Path?"), string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            System.Diagnostics.Process.Start("explorer.exe?", System.String.Format("/select,""{0}""?", s1))
        End Sub

        Private Sub mnuActionSearchSubtitles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            PerformSearch()
        End Sub

        Private Sub mnuActionSublightCmdHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not IsFileSelected Then
                Return
            End If
            RunSublightCmd("help?")
        End Sub

        Private Sub mnuActionSublightCmdNFO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not IsFileSelected Then
                Return
            End If
            Dim listViewItem1 As System.Windows.Forms.ListViewItem = lvResults.SelectedItems(0)
            Dim dataRow1 As System.Data.DataRow = TryCast(listViewItem1.Tag, System.Data.DataRow)
            If (dataRow1) Is Nothing Then
                Return
            End If
            Dim s1 As String = TryCast(dataRow1("Path?"), string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            RunSublightCmd(System.String.Format("nfo /video:""{0}""?", s1))
        End Sub

        Private Sub mnuActionSublightCmdSynopsis_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not IsFileSelected Then
                Return
            End If
            Dim listViewItem1 As System.Windows.Forms.ListViewItem = lvResults.SelectedItems(0)
            Dim dataRow1 As System.Data.DataRow = TryCast(listViewItem1.Tag, System.Data.DataRow)
            If (dataRow1) Is Nothing Then
                Return
            End If
            Dim s1 As String = TryCast(dataRow1("Path?"), string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            RunSublightCmd(System.String.Format("synopsis /video:""{0}""?", s1))
        End Sub

        Private Sub mnuFileActions_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            If Not IsFileSelected Then
                e.Cancel = True
            End If
        End Sub

        Private Sub PerformSearch()
            If Not IsFileSelected Then
                Return
            End If
            Dim listViewItem1 As System.Windows.Forms.ListViewItem = lvResults.SelectedItems(0)
            Dim dataRow1 As System.Data.DataRow = TryCast(listViewItem1.Tag, System.Data.DataRow)
            If (dataRow1) Is Nothing Then
                Return
            End If
            Dim s1 As String = TryCast(dataRow1("PathOrg?"), string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            Sublight.Globals.MainForm.SwitchTab(Sublight.FrmMain.RibbonTab.Search)
            m_searchPage.PerformSearch(s1, True)
        End Sub

        Private Sub RunSublightCmd(ByVal args As String)
            Dim processModule1 As System.Diagnostics.ProcessModule = System.Diagnostics.Process.GetCurrentProcess().MainModule
            If (processModule1) Is Nothing Then
                Return
            End If
            If (processModule1.FileName) Is Nothing Then
                Return
            End If
            If ((lvResults.SelectedItems) Is Nothing) OrElse (lvResults.SelectedItems.Count <> 1) Then
                Return
            End If
            Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(processModule1.FileName)
            If (fileInfo1.Directory) Is Nothing Then
                Return
            End If
            Dim s1 As String = System.IO.Path.Combine(fileInfo1.Directory.FullName, "SublightCmd.exe?")
            Dim s2 As String = Nothing
            Try
                Dim listViewItem1 As System.Windows.Forms.ListViewItem = lvResults.SelectedItems(0)
                Dim dataRow1 As System.Data.DataRow = TryCast(listViewItem1.Tag, System.Data.DataRow)
                If Not (dataRow1) Is Nothing Then
                    Dim s3 As String = TryCast(dataRow1("Path?"), string)
                    If System.String.IsNullOrEmpty(s3) Then
                        Return
                    End If
                    Dim fileInfo2 As System.IO.FileInfo = New System.IO.FileInfo(s3)
                    If Not (fileInfo2.Directory) Is Nothing Then
                        s2 = fileInfo2.Directory.FullName
                    End If
                End If
            Catch e As System.Exception
                s2 = Nothing
            End Try
            If System.String.IsNullOrEmpty(s2) Then
                s2 = fileInfo1.Directory.FullName
            End If
            Try
                Dim processStartInfo1 As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo("cmd.exe?", System.String.Format("/k echo ""{1}"" {2} && ""{1}"" {2} && set path=%path%;{0}?", fileInfo1.Directory.FullName, s1, args))
                processStartInfo1.WorkingDirectory = s2
                System.Diagnostics.Process.Start(processStartInfo1)
            Catch e As System.Exception
                ParentBaseForm.ShowError(System.String.Format("{0}?", e.Message), New object(0) {})
            End Try
        End Sub

        Private Sub vid_Result(ByVal sender As Object, ByVal info As System.Collections.Generic.Dictionary(Of String,String))
            Dim <>c__DisplayClass8_1 As Sublight.Controls.MyMoviesFiles.<>c__DisplayClass8 = New Sublight.Controls.MyMoviesFiles.<>c__DisplayClass8
            <>c__DisplayClass8_1.info = info
            <>c__DisplayClass8_1.<>4__this = Me
            If (<>c__DisplayClass8_1.info) Is Nothing Then
                Return
            End If
            Dim s1 As String = IIf(<>c__DisplayClass8_1.info.ContainsKey("Format?"), <>c__DisplayClass8_1.info.get_Item("Format?").ToLower(), Nothing)
            Dim s2 As String = IIf(<>c__DisplayClass8_1.info.ContainsKey("CodecID?"), <>c__DisplayClass8_1.info.get_Item("CodecID?").ToLower(), Nothing)
            If (Not (s1) Is Nothing) AndAlso s1.Contains("avc?") Then
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.AVC
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("divx?") Then
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("div3?") Then
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("div4?") Then
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("div5?") Then
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("dx50?") Then
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.DivX
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("xvid?") Then
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.Xvid
            ElseIf (Not (s2) Is Nothing) AndAlso s2.Contains("wmv?") Then
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.WMV
            Else 
                <>c__DisplayClass8_1.videoCodec = Sublight.Controls.PageSearch.VideoCodec.Unknown
            End If
            Sublight.BaseForm.DoCtrlInvoke(txtVideoCodec, Me, New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<vid_Result>b__0))
            Sublight.BaseForm.DoCtrlInvoke(txtVideoCodecID, Me, New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<vid_Result>b__1))
            Sublight.BaseForm.DoCtrlInvoke(txtVideoFormat, Me, New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<vid_Result>b__2))
            Sublight.BaseForm.DoCtrlInvoke(txtFrameRate, Me, New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<vid_Result>b__3))
            Sublight.BaseForm.DoCtrlInvoke(txtFrameWidth, Me, New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<vid_Result>b__4))
            Sublight.BaseForm.DoCtrlInvoke(txtFrameHeight, Me, New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<vid_Result>b__5))
            Sublight.BaseForm.DoCtrlInvoke(txtAudioFormat, Me, New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<vid_Result>b__6))
            <>c__DisplayClass8_1.ts = System.TimeSpan.FromSeconds(System.Double.Parse(<>c__DisplayClass8_1.info.get_Item("Duration?")))
            Sublight.BaseForm.DoCtrlInvoke(txtRuntime, Me, New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<vid_Result>b__7))
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Shared Function CreateNewDataSet() As System.Data.DataSet
            Dim dataSet1 As System.Data.DataSet = New System.Data.DataSet
            Dim dataTable1 As System.Data.DataTable = dataSet1.Tables.Add("MyMovies?")
            dataTable1.Columns.Add("Path?", GetType(string))
            dataTable1.Columns.Add("PathOrg?", GetType(string))
            dataTable1.Columns.Add("Created?", GetType(System.DateTime))
            dataTable1.Columns.Add("Size?", GetType(long))
            dataTable1.Columns.Add("Hash?", GetType(string))
            dataTable1.Columns.Add("SubtitleAvailable?", GetType(bool))
            Dim dataColumnArr1 As System.Data.DataColumn() = New System.Data.DataColumn() { dataTable1.Columns("Path?") }
            dataTable1.PrimaryKey = dataColumnArr1
            Return dataSet1
        End Function

    End Class ' class MyMoviesFiles

End Namespace

