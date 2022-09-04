Imports System
Imports System.CodeDom.Compiler
Imports System.Configuration
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports Sublight.Types

Namespace Sublight.Properties

    <System.Runtime.CompilerServices.CompilerGenerated, _
    System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")> _
    Friend NotInheritable Class Settings
        Inherits System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As Sublight.Properties.Settings 

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("False"), _
        System.Configuration.UserScopedSetting> _
        Public Property App_AllowErrorReporting As Boolean
            Get
                Return DirectCast(MyBase("App_AllowErrorReporting?"), bool)
            End Get
            Set
                MyBase("App_AllowErrorReporting?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("True"), _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property App_AnimateButton As Boolean
            Get
                Return DirectCast(MyBase("App_AnimateButton?"), bool)
            End Get
            Set
                MyBase("App_AnimateButton?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("True"), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property App_AskErrorReporting As Boolean
            Get
                Return DirectCast(MyBase("App_AskErrorReporting?"), bool)
            End Get
            Set
                MyBase("App_AskErrorReporting?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("DisplayDialog")> _
        Public Property App_ErrorHandling As Sublight.Types.ErrorHandling
            Get
                Return DirectCast(MyBase("App_ErrorHandling?"), Sublight.Types.ErrorHandling)
            End Get
            Set
                MyBase("App_ErrorHandling?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue(""), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property App_ErrorHandling_LastError As String
            Get
                Return CType(MyBase("App_ErrorHandling_LastError?"), string)
            End Get
            Set
                MyBase("App_ErrorHandling_LastError?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("False")> _
        Public Property App_MinimizeToTray As Boolean
            Get
                Return DirectCast(MyBase("App_MinimizeToTray?"), bool)
            End Get
            Set
                MyBase("App_MinimizeToTray?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("False")> _
        Public Property App_RibbonMinimized As Boolean
            Get
                Return DirectCast(MyBase("App_RibbonMinimized?"), bool)
            End Get
            Set
                MyBase("App_RibbonMinimized?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("")> _
        Public Property App_WindowState As String
            Get
                Return CType(MyBase("App_WindowState?"), string)
            End Get
            Set
                MyBase("App_WindowState?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue(""), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property AppLanguage As String
            Get
                Return CType(MyBase("AppLanguage?"), string)
            End Get
            Set
                MyBase("AppLanguage?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property Application_Filter_Language As Sublight.Types.SubtitleLanguageCollection
            Get
                Return CType(MyBase("Application_Filter_Language?"), Sublight.Types.SubtitleLanguageCollection)
            End Get
            Set
                MyBase("Application_Filter_Language?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("True"), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property AskRegisterShellMenu As Boolean
            Get
                Return DirectCast(MyBase("AskRegisterShellMenu?"), bool)
            End Get
            Set
                MyBase("AskRegisterShellMenu?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("True")> _
        Public Property AskToLinkFile As Boolean
            Get
                Return DirectCast(MyBase("AskToLinkFile?"), bool)
            End Get
            Set
                MyBase("AskToLinkFile?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("True")> _
        Public Property AskToLinkFile2 As Boolean
            Get
                Return DirectCast(MyBase("AskToLinkFile2?"), bool)
            End Get
            Set
                MyBase("AskToLinkFile2?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("True"), _
        System.Configuration.UserScopedSetting> _
        Public Property AutoDelete As Boolean
            Get
                Return DirectCast(MyBase("AutoDelete?"), bool)
            End Get
            Set
                MyBase("AutoDelete?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("DoNotDelete")> _
        Public Property AutoDeleteOnNewSearch As Sublight.Types.AutoDeleteOnNewSearch
            Get
                Return DirectCast(MyBase("AutoDeleteOnNewSearch?"), Sublight.Types.AutoDeleteOnNewSearch)
            End Get
            Set
                MyBase("AutoDeleteOnNewSearch?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("")> _
        Public Property AutoUpdate_Notification_Ignore As String
            Get
                Return CType(MyBase("AutoUpdate_Notification_Ignore?"), string)
            End Get
            Set
                MyBase("AutoUpdate_Notification_Ignore?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("True")> _
        Public Property CheckForOldSettings As Boolean
            Get
                Return DirectCast(MyBase("CheckForOldSettings?"), bool)
            End Get
            Set
                MyBase("CheckForOldSettings?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue(""), _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property CustomDownloadLocation As String
            Get
                Return CType(MyBase("CustomDownloadLocation?"), string)
            End Get
            Set
                MyBase("CustomDownloadLocation?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("")> _
        Public Property CustomDownloadLocationS As String
            Get
                Return CType(MyBase("CustomDownloadLocationS?"), string)
            End Get
            Set
                MyBase("CustomDownloadLocationS?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("VideoFolder"), _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property DownloadType As Sublight.Types.DownloadLocation
            Get
                Return DirectCast(MyBase("DownloadType?"), Sublight.Types.DownloadLocation)
            End Get
            Set
                MyBase("DownloadType?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("Auto"), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property DownloadTypeS As Sublight.Types.DownloadLocation
            Get
                Return DirectCast(MyBase("DownloadTypeS?"), Sublight.Types.DownloadLocation)
            End Get
            Set
                MyBase("DownloadTypeS?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("True"), _
        System.Configuration.UserScopedSetting> _
        Public Property List_DisplayTooltips As Boolean
            Get
                Return DirectCast(MyBase("List_DisplayTooltips?"), bool)
            End Get
            Set
                MyBase("List_DisplayTooltips?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue(""), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property LogIn_Password As String
            Get
                Return CType(MyBase("LogIn_Password?"), string)
            End Get
            Set
                MyBase("LogIn_Password?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("True"), _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property LogIn_RememberMe As Boolean
            Get
                Return DirectCast(MyBase("LogIn_RememberMe?"), bool)
            End Get
            Set
                MyBase("LogIn_RememberMe?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue(""), _
        System.Configuration.UserScopedSetting> _
        Public Property LogIn_Username As String
            Get
                Return CType(MyBase("LogIn_Username?"), string)
            End Get
            Set
                MyBase("LogIn_Username?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("True")> _
        Public Property MyMovies_Files_ShowFileDetails As Boolean
            Get
                Return DirectCast(MyBase("MyMovies_Files_ShowFileDetails?"), bool)
            End Get
            Set
                MyBase("MyMovies_Files_ShowFileDetails?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("-1"), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property MyMovies_Files_SortColumn As Integer
            Get
                Return DirectCast(MyBase("MyMovies_Files_SortColumn?"), int)
            End Get
            Set
                MyBase("MyMovies_Files_SortColumn?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue(""), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property MyMovies_Files_SortOrder As String
            Get
                Return CType(MyBase("MyMovies_Files_SortOrder?"), string)
            End Get
            Set
                MyBase("MyMovies_Files_SortOrder?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property MyMovies_Folders As Sublight.Types.MovieFolderCollection
            Get
                Return CType(MyBase("MyMovies_Folders?"), Sublight.Types.MovieFolderCollection)
            End Get
            Set
                MyBase("MyMovies_Folders?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("True"), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property OverwriteSubtitleIfExists As Boolean
            Get
                Return DirectCast(MyBase("OverwriteSubtitleIfExists?"), bool)
            End Get
            Set
                MyBase("OverwriteSubtitleIfExists?") = value
            End Set
        End Property

        <System.Configuration.ApplicationScopedSetting, _
        System.Configuration.DefaultSettingValue("Plugins"), _
        System.Diagnostics.DebuggerNonUserCode> _
        Public ReadOnly Property PluginDir As String
            Get
                Return CType(MyBase("PluginDir?"), string)
            End Get
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue(""), _
        System.Configuration.UserScopedSetting> _
        Public Property Plugins_SubtitleProvider_PodnapisiNet_Password As String
            Get
                Return CType(MyBase("Plugins_SubtitleProvider_PodnapisiNet_Password?"), string)
            End Get
            Set
                MyBase("Plugins_SubtitleProvider_PodnapisiNet_Password?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue(""), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property Plugins_SubtitleProvider_PodnapisiNet_Username As String
            Get
                Return CType(MyBase("Plugins_SubtitleProvider_PodnapisiNet_Username?"), string)
            End Get
            Set
                MyBase("Plugins_SubtitleProvider_PodnapisiNet_Username?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("False")> _
        Public Property Plugins_SubtitleProviderInitialized As Boolean
            Get
                Return DirectCast(MyBase("Plugins_SubtitleProviderInitialized?"), bool)
            End Get
            Set
                MyBase("Plugins_SubtitleProviderInitialized?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("PodnapisiNet; DivxTitlovi; OpenSubtitles;"), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property Plugins_SubtitleProviderOrder As String
            Get
                Return CType(MyBase("Plugins_SubtitleProviderOrder?"), string)
            End Get
            Set
                MyBase("Plugins_SubtitleProviderOrder?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("UseAlways"), _
        System.Configuration.UserScopedSetting> _
        Public Property Plugins_SubtitleProviderUsage As Sublight.Types.SecondarySubtitleProvider
            Get
                Return DirectCast(MyBase("Plugins_SubtitleProviderUsage?"), Sublight.Types.SecondarySubtitleProvider)
            End Get
            Set
                MyBase("Plugins_SubtitleProviderUsage?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("True"), _
        System.Configuration.UserScopedSetting> _
        Public Property Search_AutoFillTitle As Boolean
            Get
                Return DirectCast(MyBase("Search_AutoFillTitle?"), bool)
            End Get
            Set
                MyBase("Search_AutoFillTitle?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("DownloadSubtitleAndPlay"), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property Search_DblClickAction As Sublight.Types.SubtitleDblClickAction
            Get
                Return DirectCast(MyBase("Search_DblClickAction?"), Sublight.Types.SubtitleDblClickAction)
            End Get
            Set
                MyBase("Search_DblClickAction?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property Search_Filter_Genre As Sublight.Types.GenreCollection
            Get
                Return CType(MyBase("Search_Filter_Genre?"), Sublight.Types.GenreCollection)
            End Get
            Set
                MyBase("Search_Filter_Genre?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property Search_Filter_Language As Sublight.Types.SubtitleLanguageCollection
            Get
                Return CType(MyBase("Search_Filter_Language?"), Sublight.Types.SubtitleLanguageCollection)
            End Get
            Set
                MyBase("Search_Filter_Language?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("")> _
        Public Property Search_RecentUnsuccessfulSearches As String
            Get
                Return CType(MyBase("Search_RecentUnsuccessfulSearches?"), string)
            End Get
            Set
                MyBase("Search_RecentUnsuccessfulSearches?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue(""), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property Search_RSS_LastNews As String
            Get
                Return CType(MyBase("Search_RSS_LastNews?"), string)
            End Get
            Set
                MyBase("Search_RSS_LastNews?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("False"), _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property Search_ShowFilter As Boolean
            Get
                Return DirectCast(MyBase("Search_ShowFilter?"), bool)
            End Get
            Set
                MyBase("Search_ShowFilter?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("True")> _
        Public Property SemiAutomaticHashingEnabled As Boolean
            Get
                Return DirectCast(MyBase("SemiAutomaticHashingEnabled?"), bool)
            End Get
            Set
                MyBase("SemiAutomaticHashingEnabled?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("HDTV DVD XOR AXXO XVID DIVX WS CAPH SEASON EPISODE ENG DVDRIP WS DSR NOTV DIMENSION PROPER R5 PUKKA AC3 MP3 AVI CAM TS DVDSCR SCREENER INTERNAL DIAMOND CD1 CD2 FXM FXG REPACK 720p RIP 720i 1080i 1080p HD MP4 BLU DISC MKV WMA WMV"), _
        System.Configuration.UserScopedSetting> _
        Public Property SemiAutomaticSearchIgnoreWords As String
            Get
                Return CType(MyBase("SemiAutomaticSearchIgnoreWords?"), string)
            End Get
            Set
                MyBase("SemiAutomaticSearchIgnoreWords?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("True"), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property SingleInstanceApplication As Boolean
            Get
                Return DirectCast(MyBase("SingleInstanceApplication?"), bool)
            End Get
            Set
                MyBase("SingleInstanceApplication?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("http://www.sublight.si/API/WS/Sublight.asmx"), _
        System.Configuration.ApplicationScopedSetting, _
        System.Configuration.SpecialSetting(System.Configuration.SpecialSetting.WebServiceUrl)> _
        Public ReadOnly Property Sublight_WS_Sublight As String
            Get
                Return CType(MyBase("Sublight_WS_Sublight?"), string)
            End Get
        End Property

        <System.Configuration.SpecialSetting(System.Configuration.SpecialSetting.WebServiceUrl), _
        System.Configuration.DefaultSettingValue("http://localhost:2183/API/WS/SublightClient.asmx"), _
        System.Configuration.ApplicationScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public ReadOnly Property Sublight_WS_SublightClient As String
            Get
                Return CType(MyBase("Sublight_WS_SublightClient?"), string)
            End Get
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue("-1")> _
        Public Property SubtitleCommentLanguage As Short
            Get
                Return DirectCast(MyBase("SubtitleCommentLanguage?"), short)
            End Get
            Set
                MyBase("SubtitleCommentLanguage?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("ANSI"), _
        System.Configuration.UserScopedSetting> _
        Public Property SubtitleEncoding As Sublight.Types.Encoding
            Get
                Return DirectCast(MyBase("SubtitleEncoding?"), Sublight.Types.Encoding)
            End Get
            Set
                MyBase("SubtitleEncoding?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("1250"), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property SubtitleEncoding_Custom As Integer
            Get
                Return DirectCast(MyBase("SubtitleEncoding_Custom?"), int)
            End Get
            Set
                MyBase("SubtitleEncoding_Custom?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("False"), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property SubtitleFileNaming_AppendLangId As Boolean
            Get
                Return DirectCast(MyBase("SubtitleFileNaming_AppendLangId?"), bool)
            End Get
            Set
                MyBase("SubtitleFileNaming_AppendLangId?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("False"), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property SubtitleFormatting_Remove As Boolean
            Get
                Return DirectCast(MyBase("SubtitleFormatting_Remove?"), bool)
            End Get
            Set
                MyBase("SubtitleFormatting_Remove?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.DefaultSettingValue("0")> _
        Public Property SyncSetting As Long
            Get
                Return DirectCast(MyBase("SyncSetting?"), long)
            End Get
            Set
                MyBase("SyncSetting?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("00000000-0000-0000-0000-000000000000"), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property UserId As System.Guid
            Get
                Return DirectCast(MyBase("UserId?"), System.Guid)
            End Get
            Set
                MyBase("UserId?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue(""), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property VideoApp As String
            Get
                Return CType(MyBase("VideoApp?"), string)
            End Get
            Set
                MyBase("VideoApp?") = value
            End Set
        End Property

        <System.Configuration.UserScopedSetting, _
        System.Configuration.DefaultSettingValue(""), _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property VideoApp_Params As String
            Get
                Return CType(MyBase("VideoApp_Params?"), string)
            End Get
            Set
                MyBase("VideoApp_Params?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue(""), _
        System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property VideoApp_Path As String
            Get
                Return CType(MyBase("VideoApp_Path?"), string)
            End Get
            Set
                MyBase("VideoApp_Path?") = value
            End Set
        End Property

        <System.Configuration.DefaultSettingValue("SubtitleDetails"), _
        System.Configuration.UserScopedSetting, _
        System.Diagnostics.DebuggerNonUserCode> _
        Public Property View_DblClickAction As Sublight.Types.SubtitleDblClickAction
            Get
                Return DirectCast(MyBase("View_DblClickAction?"), Sublight.Types.SubtitleDblClickAction)
            End Get
            Set
                MyBase("View_DblClickAction?") = value
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode, _
        System.Configuration.UserScopedSetting> _
        Public Property View_MyDownloads As Sublight.Types.DownloadedSubtitleCollection
            Get
                Return CType(MyBase("View_MyDownloads?"), Sublight.Types.DownloadedSubtitleCollection)
            End Get
            Set
                MyBase("View_MyDownloads?") = value
            End Set
        End Property

        Public Shared ReadOnly Property Default As Sublight.Properties.Settings
            Get
                Return Sublight.Properties.Settings.defaultInstance
            End Get
        End Property

        Public Sub New()
        End Sub

        Shared Sub New()
            Sublight.Properties.Settings.defaultInstance = CType(System.Configuration.SettingsBase.Synchronized(New Sublight.Properties.Settings), Sublight.Properties.Settings)
        End Sub

    End Class ' class Settings

End Namespace

