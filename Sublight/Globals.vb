Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Web
Imports System.Xml
Imports Elegant.Ui
Imports Sublight.Controls
Imports Sublight.Lib.Language
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight

    Public MustInherit Class Globals

        Private Const LANGUAGE_UNKNOWN As String  = "Language_UNKNOWN"

        Private Shared ReadOnly m_VideoExtensions As String() 

        Private Shared _consoleInitialized As Boolean 
        Private Shared _editionType As System.Nullable(Of Sublight.Types.SpecialEdition) 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared <Exiting>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared <MainForm>k__BackingField As Sublight.FrmMain 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared <Ribbon>k__BackingField As Elegant.Ui.Ribbon 
        Public Shared AutoDownloadLocation As String 
        Public Shared BrushSubtitleLinkedBg As System.Drawing.SolidBrush 
        Public Shared BrushSubtitleUnlinkedBg As System.Drawing.SolidBrush 
        Public Shared ColorBackgroundControl As System.Drawing.Color 
        Public Shared ColorBackgroundDarker1 As System.Drawing.Color 
        Public Shared ColorBackgroundLight1 As System.Drawing.Color 
        Public Shared ColorBackgroundLight2 As System.Drawing.Color 
        Public Shared ColorGroupBoxLine As System.Drawing.Color 
        Public Shared ColorSeparator As System.Drawing.Color 
        Public Shared ColorSubtitleLinkedBg As System.Drawing.Color 
        Public Shared ColorSubtitleLinkedFg As System.Drawing.Color 
        Public Shared ColorSubtitleUnlinkedAlternateBg As System.Drawing.Color 
        Public Shared ColorSubtitleUnlinkedBg As System.Drawing.Color 
        Public Shared ColorSubtitleUnlinkedFg As System.Drawing.Color 
        Friend Shared DebugMode As Boolean 
        Private Shared m_DonationID As System.Guid 
        Private Shared m_Events As Sublight.AppEvents 
        Private Shared m_Languages As Sublight.Types.LanguageUI() 
        Private Shared m_VideoExtensionsFilter As String 
        Public Shared MAX_RESULTS As Integer 
        Public Shared SubtitleProvider_NumberOfRetries As Integer 
        Private Shared URL_DONATIONS As String 
        Private Shared URL_DONATIONS_ANON As String 
        Public Shared WS_NumberOfRetries As Integer 
        Public Shared WS_SleepIntervalOnError As Integer 
        Friend Shared WSH_CONTEXT_BPR_DOWNLOADDECOMPRESSSAVE As String 
        Friend Shared WSH_CONTEXT_BPR_PAGE_SEARCH_DRAG_DROP As String 
        Friend Shared WSH_CONTEXT_BPR_PAGE_VIEW_DOWNLOADDBYME As String 
        Friend Shared WSH_CONTEXT_BPR_PAGE_VIEW_FAVORITE As String 
        Friend Shared WSH_CONTEXT_BPR_PAGE_VIEW_NEW As String 
        Friend Shared WSH_CONTEXT_BPR_PAGE_VIEW_PUBLISHEDBYME As String 
        Friend Shared WSH_CONTEXT_BPR_PAGE_VIEW_STATISTICS_BIND As String 
        Friend Shared WSH_CONTEXT_FRM_CONNECT_LOAD As String 
        Friend Shared WSH_CONTEXT_FRM_CONNECT_RETRY_ANON As String 

        Friend Shared ReadOnly Property AnonDonationURL As String
            Get
                Return Sublight.Globals.URL_DONATIONS_ANON
            End Get
        End Property

        Friend Shared ReadOnly Property DonationID As System.Guid
            Get
                If Sublight.Globals.m_DonationID = System.Guid.Empty Then
                    Sublight.Globals.m_DonationID = System.Guid.NewGuid()
                End If
                Return Sublight.Globals.m_DonationID
            End Get
        End Property

        Friend Shared ReadOnly Property DonationURL As String
            Get
                Dim guid1 As System.Guid = Sublight.Globals.DonationID
                Return System.String.Format(Sublight.Globals.URL_DONATIONS, System.Web.HttpUtility.UrlEncode(guid1.ToString("N?").ToUpper()))
            End Get
        End Property

        Friend Shared ReadOnly Property EditionType As Sublight.Types.SpecialEdition
            Get
                If Not Sublight.Globals._editionType.get_HasValue() Then
                    Sublight.Globals._editionType = New System.Nullable(Of Sublight.Types.SpecialEdition)(Sublight.Globals.GetPersistedEditionType())
                End If
                If Not Sublight.Globals._editionType.get_HasValue() Then
                    Return Sublight.Types.SpecialEdition.Regular
                End If
                Return CType(Sublight.Globals._editionType.get_Value(), Sublight.Types.SpecialEdition)
            End Get
        End Property

        Public Shared ReadOnly Property Events As Sublight.AppEvents
            Get
                If (Sublight.Globals.m_Events) Is Nothing Then
                    Sublight.Globals.m_Events = New Sublight.AppEvents
                End If
                Return Sublight.Globals.m_Events
            End Get
        End Property

        Public Shared Property Exiting As Boolean
            Get
                Return Sublight.Globals.<Exiting>k__BackingField
            End Get
            Set
                Sublight.Globals.<Exiting>k__BackingField = value
            End Set
        End Property

        Public Shared ReadOnly Property IsMainFormActive As Boolean
            Get
                If ((Sublight.Globals.MainForm) Is Nothing) OrElse Sublight.Globals.MainForm.IsDisposed Then
                    Return False
                End If
                Return Sublight.Globals.MainForm.IsActive
            End Get
        End Property

        Friend Shared ReadOnly Property Languages As Sublight.Types.LanguageUI()
            Get
                If (Sublight.Globals.m_Languages) Is Nothing Then
                    Dim list1 As System.Collections.Generic.List(Of Sublight.Types.LanguageUI) = New System.Collections.Generic.List(Of Sublight.Types.LanguageUI)
                    Dim xmlDocument1 As System.Xml.XmlDocument = New System.Xml.XmlDocument
                    Try
                        Dim s1 As String = Nothing
                        Dim processModule1 As System.Diagnostics.ProcessModule = System.Diagnostics.Process.GetCurrentProcess().MainModule
                        If Not (processModule1) Is Nothing Then
                            Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(processModule1.FileName)
                            If Not (fileInfo1.Directory) Is Nothing Then
                                s1 = System.IO.Path.Combine(fileInfo1.Directory.FullName, "Translations.xml?")
                            End If
                        End If
                        If (s1) Is Nothing Then
                            s1 = "Translations.xml?"
                        End If
                        xmlDocument1.Load(s1)
                        Dim xmlNodeList1 As System.Xml.XmlNodeList = xmlDocument1.SelectNodes("/Translations/Translation?")
                        If Not (xmlNodeList1) Is Nothing Then
                            Dim xmlNode1 As System.Xml.XmlNode 
                            For Each xmlNode1 In xmlNodeList1
                                Try
                                    Dim s2 As String = xmlNode1.Attributes("Name?").InnerXml
                                    Dim s3 As String = xmlNode1.Attributes("Code?").InnerXml
                                    If System.String.IsNullOrEmpty(s2) OrElse (s2.Trim().Length <= 0) Then
                                        Continue
                                    End If
                                    If System.String.IsNullOrEmpty(s3) OrElse (s3.Trim().Length <= 0) Then
                                        Continue
                                    End If
                                    list1.Add(New Sublight.Types.LanguageUI(s2, s3))
                                Catch 
                                End Try
                            Next
                        End If
                    Catch 
                    End Try
                    If list1.get_Count() <= 0 Then
                        list1.Add(New Sublight.Types.LanguageUI("English?", "en-US?"))
                    End If
                    Sublight.Globals.m_Languages = list1.ToArray()
                End If
                If (Sublight.Globals.m_Languages) Is Nothing Then
                    Return New Sublight.Types.LanguageUI(0) {}
                End If
                Return Sublight.Globals.m_Languages
            End Get
        End Property

        Public Shared Property MainForm As Sublight.FrmMain
            Get
                Return Sublight.Globals.<MainForm>k__BackingField
            End Get
            Set
                Sublight.Globals.<MainForm>k__BackingField = value
            End Set
        End Property

        Friend Shared ReadOnly Property OpenVideo_Filter As String
            Get
                Return System.String.Format(Sublight.Translation.Dialog_OpenVideo_Filter, Sublight.Globals.VideoExtensionsFilter)
            End Get
        End Property

        Friend Shared Property Ribbon As Elegant.Ui.Ribbon
            Get
                Return Sublight.Globals.<Ribbon>k__BackingField
            End Get
            Set
                Sublight.Globals.<Ribbon>k__BackingField = value
            End Set
        End Property

        Friend Shared ReadOnly Property VideoExtensions As String()
            Get
                Return Sublight.Globals.m_VideoExtensions
            End Get
        End Property

        Friend Shared ReadOnly Property VideoExtensionsFilter As String
            Get
                If (Sublight.Globals.m_VideoExtensionsFilter) Is Nothing Then
                    If Not (Sublight.Globals.VideoExtensions) Is Nothing Then
                        Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                        Dim sArr1 As String() = Sublight.Globals.VideoExtensions
                        Dim i1 As Integer = 0
                        While i1 < sArr1.Length
                            Dim s1 As String = sArr1(i1)
                            Dim chArr1 As Char() = New char() { "."C }
                            stringBuilder1.AppendFormat("*.{0};?", s1.Trim(chArr1))
                            i1 = i1 + 1
                        End While
                        Dim chArr2 As Char() = New char() { ";"C }
                        Sublight.Globals.m_VideoExtensionsFilter = stringBuilder1.ToString().TrimEnd(chArr2)
                    Else 
                        Sublight.Globals.m_VideoExtensionsFilter = System.String.Empty
                    End If
                End If
                Return Sublight.Globals.m_VideoExtensionsFilter
            End Get
        End Property

        Protected Sub New()
        End Sub

        Shared Sub New()
            Dim sArr1 As String() = New string() { _
                                                   "avi?", _
                                                   "mkv?", _
                                                   "wmv?", _
                                                   "mp4?", _
                                                   "divx?", _
                                                   "xvid?", _
                                                   "mov?", _
                                                   "mpg?", _
                                                   "mpeg?", _
                                                   "flv?" }
            Sublight.Globals.m_VideoExtensions = sArr1
            Sublight.Globals.ColorSubtitleLinkedBg = System.Drawing.Color.FromArgb(255, 222, 129)
            Sublight.Globals.ColorSubtitleLinkedFg = System.Drawing.Color.White
            Sublight.Globals.ColorSubtitleUnlinkedBg = System.Drawing.Color.White
            Sublight.Globals.ColorSubtitleUnlinkedAlternateBg = System.Drawing.ColorTranslator.FromHtml("#F2F8FE?")
            Sublight.Globals.ColorSubtitleUnlinkedFg = System.Drawing.Color.Black
            Sublight.Globals.ColorGroupBoxLine = System.Drawing.ColorTranslator.FromHtml("#D5DFE5?")
            Sublight.Globals.ColorBackgroundLight1 = System.Drawing.ColorTranslator.FromHtml("#F0F0F0?")
            Sublight.Globals.ColorBackgroundDarker1 = System.Drawing.ColorTranslator.FromHtml("#BFDBFF?")
            Sublight.Globals.ColorSeparator = System.Drawing.ColorTranslator.FromHtml("#CFDBEB?")
            Sublight.Globals.ColorBackgroundLight2 = System.Drawing.ColorTranslator.FromHtml("#DFE9F5?")
            Sublight.Globals.ColorBackgroundControl = System.Drawing.ColorTranslator.FromHtml("#F1EDED?")
            Sublight.Globals.BrushSubtitleLinkedBg = New System.Drawing.SolidBrush(Sublight.Globals.ColorSubtitleLinkedBg)
            Sublight.Globals.BrushSubtitleUnlinkedBg = New System.Drawing.SolidBrush(Sublight.Globals.ColorSubtitleUnlinkedBg)
            Sublight.Globals.AutoDownloadLocation = "Sublight\Downloads?"
            Sublight.Globals.WS_NumberOfRetries = 5
            Sublight.Globals.SubtitleProvider_NumberOfRetries = 3
            Sublight.Globals.WS_SleepIntervalOnError = 250
            Sublight.Globals.MAX_RESULTS = 50
            Sublight.Globals.URL_DONATIONS = "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=M8VX78BJGD62U&lc=SI&item_name=Sublight%20donation&no_note=1&no_shipping=1&currency_code=EUR&bn=PP%2dDonationsBF%3apaypal%2egif%3aNonHosted&custom={0}?"
            Sublight.Globals.URL_DONATIONS_ANON = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=4634716?"
            Sublight.Globals.WSH_CONTEXT_FRM_CONNECT_LOAD = "WinUI.FrmConnect.FrmConnect_Load?"
            Sublight.Globals.WSH_CONTEXT_FRM_CONNECT_RETRY_ANON = "WinUI.FrmConnect.RetryWithAnonymousLogin?"
            Sublight.Globals.WSH_CONTEXT_BPR_DOWNLOADDECOMPRESSSAVE = "Sublight.Controls.BasePageResults.DownloadDecompressSave?"
            Sublight.Globals.WSH_CONTEXT_BPR_PAGE_SEARCH_DRAG_DROP = "Sublight.Controls.PageSearch.PageSearch_DragDrop?"
            Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_NEW = "Sublight.Controls.PageView.btnNew_Click?"
            Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_FAVORITE = "Sublight.Controls.PageView.btnFavorites_Click?"
            Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_PUBLISHEDBYME = "Sublight.Controls.PageView.btnPublishedByMe_Click?"
            Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_DOWNLOADDBYME = "Sublight.Controls.PageView.btnDownloadedByMe_Click?"
            Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_STATISTICS_BIND = "Sublight.Controls.PageViewStatistics.BindControl?"
        End Sub

        Public Shared Sub BindNotSelected(ByVal control As Sublight.Controls.MyComboBox, ByVal select As Boolean)
            Dim i1 As Integer = control.Items.Add(Sublight.Types.ListItem.CreateNotSelected())
            If select Then
                control.SelectedIndex = i1
            End If
        End Sub

        Friend Shared Function CloneImage(ByVal image As System.Drawing.Image) As System.Drawing.Image
            Dim image1 As System.Drawing.Image

            Try
                If Not (image) Is Nothing Then
                    Return TryCast(image.Clone(), System.Drawing.Image)
                End If
                image1 = Nothing
            Catch e As System.Exception
                image1 = Nothing
            End Try
            Return image1
        End Function

        Friend Shared Sub DebugWriteLine(ByVal format As String, <System.ParamArray> ByVal args As Object())
            Try
                If Not Sublight.Globals.DebugMode Then
                    If Sublight.Globals._consoleInitialized Then
                        Sublight.Globals._consoleInitialized = False
                        Sublight.Globals.FreeConsole()
                    End If
                    Return
                End If
                If Not Sublight.Globals._consoleInitialized Then
                    Sublight.Globals._consoleInitialized = True
                    Sublight.Globals.AllocConsole()
                End If
                System.Console.WriteLine(format, args)
            Catch 
            End Try
        End Sub

        Friend Shared Function GetHomePageAbsoluteUrl() As String
            Return Sublight.Globals.GetHomePageAbsoluteUrl(System.String.Empty)
        End Function

        Friend Shared Function GetHomePageAbsoluteUrl(ByVal relativeUrl As String) As String
            Dim chArr1 As Char() = New char() { "/"C, " "C }
            relativeUrl = relativeUrl.Trim(chArr1)
            Return System.String.Format("http://www.sublight.si/{0}?", relativeUrl)
        End Function

        Private Shared Function GetPersistedEditionType() As Sublight.Types.SpecialEdition
            Dim specialEdition3 As Sublight.Types.SpecialEdition

            Dim specialEdition1 As Sublight.Types.SpecialEdition = Sublight.Types.SpecialEdition.Regular
            Dim s1 As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
            s1 = System.IO.Path.Combine(s1, System.String.Format("SublightCache\{0}.setting?", System.Enum.GetName(GetType(Sublight.Types.SpecialEdition), specialEdition1)))
            If specialEdition1 <> Sublight.Types.SpecialEdition.Regular Then
                If Not System.IO.File.Exists(s1) Then
                    Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(s1)
                    If Not (fileInfo1.Directory) Is Nothing Then
                        Dim s2 As String = fileInfo1.Directory.FullName
                        If Not System.IO.Directory.Exists(s2) Then
                            System.IO.Directory.CreateDirectory(s2)
                        End If
                        Using fileStream1 As System.IO.FileStream = System.IO.File.Create(s1)
                        End Using
                    End If
                End If
                Return specialEdition1
            End If
            Dim specialEditionArr1 As Sublight.Types.SpecialEdition() = TryCast(System.Enum.GetValues(GetType(Sublight.Types.SpecialEdition)), Sublight.Types.SpecialEdition[])
            If Not (specialEditionArr1) Is Nothing Then
                Dim specialEditionArr2 As Sublight.Types.SpecialEdition() = specialEditionArr1
                Dim i1 As Integer = 0
                While i1 < specialEditionArr2.Length
                    Dim specialEdition2 As Sublight.Types.SpecialEdition = CType(specialEditionArr2(i1), Sublight.Types.SpecialEdition)
                    If specialEdition2 <> Sublight.Types.SpecialEdition.Regular Then
                        s1 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
                        s1 = System.IO.Path.Combine(s1, System.String.Format("SublightCache\{0}.setting?", System.Enum.GetName(GetType(Sublight.Types.SpecialEdition), specialEdition2)))
                        If System.IO.File.Exists(s1) Then
                            Return specialEdition2
                        End If
                    End If
                    i1 = i1 + 1
                End While
            End If
            Return Sublight.Types.SpecialEdition.Regular
        End Function

        Public Shared Function GetString(ByVal key As String) As String
            Return Sublight.Translation.ResourceManager.GetString(key)
        End Function

        Public Shared Function GetString(ByVal mediaType As Sublight.WS.MediaType) As String
            If (mediaType = Sublight.WS.MediaType.BluRay) OrElse (mediaType = Sublight.WS.MediaType.BlueRay) Then
                Return "Blu-ray?"
            End If
            If mediaType = Sublight.WS.MediaType.HD_DVD Then
                Return "HD DVD?"
            End If
            Return System.Enum.GetName(GetType(Sublight.WS.MediaType), mediaType)
        End Function

        Public Shared Function GetString(ByVal language As Sublight.WS.SubtitleLanguage) As String
            If language = Sublight.WS.SubtitleLanguage.Unknown Then
                Return Sublight.Globals.GetString("Language_UNKNOWN?")
            End If
            Dim s1 As String = Sublight.Lib.Language.Util.GetCodeByLanguage(System.Enum.GetName(GetType(Sublight.WS.SubtitleLanguage), language))
            If (s1) Is Nothing Then
                Return System.String.Format("??? {0}?", System.Enum.GetName(GetType(Sublight.WS.SubtitleLanguage), language))
            End If
            s1 = s1.Replace("-"C, "_"C).ToUpper()
            Dim s2 As String = Sublight.Globals.GetString(System.String.Format("Language_{0}?", s1))
            If System.String.IsNullOrEmpty(s2) Then
                Return System.String.Format("??? {0}?", System.Enum.GetName(GetType(Sublight.WS.SubtitleLanguage), language))
            End If
            Return s2
        End Function

        Public Shared Function IsSpecialSearch(ByVal searchText As String) As Boolean
            If System.String.IsNullOrEmpty(searchText) Then
                Return False
            End If
            Dim s1 As String = searchText.Trim().ToLower()
            If s1.StartsWith("imdb:?") Then
                Return True
            End If
            If s1.StartsWith("publisher:?") Then
                Return True
            End If
            Return False
        End Function

        Friend Shared Function IsVideoFileSupported(ByVal videoFile As String) As Boolean
            Dim flag1 As Boolean

            If System.String.IsNullOrEmpty(videoFile) OrElse ((Sublight.Globals.VideoExtensions) Is Nothing) Then
                Return False
            End If
            Dim sArr1 As String() = Sublight.Globals.VideoExtensions
            Dim i1 As Integer = 0
            While i1 < sArr1.Length
                Dim s1 As String = sArr1(i1)
                If videoFile.EndsWith(s1, System.StringComparison.InvariantCultureIgnoreCase) Then
                    Return True
                End If
                i1 = i1 + 1
            End While
            Return False
        End Function

        Public Shared Function LanguageToShortString(ByVal language As Sublight.WS.SubtitleLanguage) As String
            Dim s1 As String = Sublight.Lib.Language.Util.GetCodeByLanguage(System.Enum.GetName(GetType(Sublight.WS.SubtitleLanguage), language))
            If (s1) Is Nothing Then
                s1 = "na?"
            End If
            Return s1
        End Function

        Public Shared Sub SelectNotSelected(ByVal control As Sublight.Controls.MyComboBox)
            If (control) Is Nothing Then
                Return
            End If
            Dim i1 As Integer = 0
            While i1 < control.Items.Count
                Dim listItem1 As Sublight.Types.ListItem = TryCast(control.Items(i1), Sublight.Types.ListItem)
                If (Not (listItem1) Is Nothing) AndAlso Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                    control.SelectedIndex = i1
                    Return
                End If
                i1 = i1 + 1
            End While
        End Sub

        Friend Shared Sub SetAllSubtitleLanguages()
            Try
                Sublight.Properties.Settings.Default.Search_Filter_Language = New Sublight.Types.SubtitleLanguageCollection
                Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = Sublight.MyUtility.LanguageUtil.GetSortedAllLanguages()
                If Not (subtitleLanguageArr1) Is Nothing Then
                    Sublight.Properties.Settings.Default.Application_Filter_Language.AddRange(subtitleLanguageArr1)
                    Sublight.Properties.Settings.Default.Search_Filter_Language.AddRange(subtitleLanguageArr1)
                End If
                Sublight.BaseForm.SaveUserSettingsSilent()
            Catch e As System.Exception
            End Try
        End Sub

        Public Shared Function UpdateUserPoints(ByVal userPoints As Double) As Boolean
            Dim flag1 As Boolean

            Try
                Dim frmMain1 As Sublight.FrmMain = Sublight.Globals.MainForm
                If ((frmMain1) Is Nothing) OrElse frmMain1.IsDisposed Then
                    Return False
                End If
                frmMain1.UpdatePoints(userPoints)
                flag1 = True
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function AllocConsole Lib "kernel32.dll" () As Boolean

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function FreeConsole Lib "kernel32.dll" () As Boolean

    End Class ' class Globals

End Namespace

