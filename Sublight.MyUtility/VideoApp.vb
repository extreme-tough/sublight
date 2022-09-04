Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports Sublight
Imports Sublight.Lib.Subtitle
Imports Sublight.Lib.Types
Imports Sublight.Properties
Imports Sublight.WS
Imports Utility.Video

Namespace Sublight.MyUtility

    Public NotInheritable Class VideoApp

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass2

            Public vpd As Sublight.MyUtility.VideoApp.VideoPlayerDetails 

            Public Sub New()
            End Sub

            Public Sub <PlayerThread>b__0()
                Dim s2 As String
                Dim nullable1 As System.Nullable(Of Double)

                Sublight.BaseForm.FlashWindow(Sublight.Globals.MainForm)
                If Sublight.BaseForm.ShowQuestion(IIf((Not (Sublight.Globals.MainForm) Is Nothing) AndAlso Not Sublight.Globals.MainForm.IsDisposed, Sublight.Globals.MainForm, Nothing), Sublight.Translation.VideoPlayer_Question_IsSubtitleSynchronizedWithVideo, New object(0) {}) = System.Windows.Forms.DialogResult.Yes Then
                    Dim s1 As String = Utility.Video.Checksum.Compute(vpd.VideoPath)
                    If System.String.IsNullOrEmpty(s1) Then
                        Return
                    End If
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        If sublight1.AddHashLinkSemiAutomatic3(Sublight.BaseForm.Session, vpd.SubtitleDetails.SubtitleID, s1, out nullable1, out s2) AndAlso nullable1.get_HasValue() Then
                            Sublight.Globals.UpdateUserPoints(nullable1.get_Value())
                        End If
                    End Using
                End If
            End Sub

        End Class ' class <>c__DisplayClass2

        Private Class VideoPlayerDetails

            Public Process As System.Diagnostics.Process 
            Public SubtitleDetails As Sublight.WS.Subtitle 
            Public VideoPath As String 

            Public Sub New(ByVal process As System.Diagnostics.Process, ByVal subtitleDetails As Sublight.WS.Subtitle, ByVal videoPath As String)
                Process = process
                SubtitleDetails = subtitleDetails
                VideoPath = videoPath
            End Sub

        End Class ' class VideoPlayerDetails

        Private Const APP_BSPlayer As String  = "BSPlayer"
        Private Const APP_CUSTOM As String  = "Custom"
        Private Const APP_GOMPlayer As String  = "GOMPlayer"
        Private Const APP_KMPlayer As String  = "KMPlayer"
        Private Const APP_MPC As String  = "MPC"
        Private Const APP_VLC As String  = "VLC"
        Private Const APP_WMP As String  = "WMP"
        Private Const APP_ZOOMPlayer As String  = "ZoomPlayer"
        Private Const VLC_PARAMS_PRE_1_0_0 As String  = "file://""{0}"" :sub-file=""{1}"""

        Public Shared ReadOnly Property IsSet As Boolean
            Get
                Return Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.VideoApp)
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Shared Function FixParametersIfNecessary() As Boolean
            If (System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "VLC?", True) = 0) AndAlso Sublight.Properties.Settings.Default.VideoApp_Params = "file://""{0}"" :sub-file=""{1}""?" Then
                Dim s1 As String = Sublight.MyUtility.VideoApp.GetParameters("VLC?")
                If Sublight.Properties.Settings.Default.VideoApp_Params <> s1 Then
                    Sublight.Properties.Settings.Default.VideoApp_Params = s1
                    Return True
                End If
            End If
            Return False
        End Function

        Private Shared Function GetBSPlayerPath() As String
            Dim s1 As String

            Try
                Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\BST\bsplayerv1?", False)
                If (registryKey1) Is Nothing Then
                    registryKey1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Wow6432Node\BST\bsplayerv1?", False)
                End If
                If (registryKey1) Is Nothing Then
                    registryKey1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Wow6432Node\BST\bsplayerv1?", False)
                End If
                If (registryKey1) Is Nothing Then
                    registryKey1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\BST\bsplayerv1?", False)
                End If
                If (registryKey1) Is Nothing Then
                    Return Nothing
                End If
                s1 = TryCast(registryKey1.GetValue("AppPath?"), string)
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

        Public Shared Function GetDetectedApps() As String()
            Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
            Dim sArr1 As String() = Sublight.MyUtility.VideoApp.GetSupportedApps()
            Dim sArr2 As String() = sArr1
            Dim i1 As Integer = 0
            While i1 < sArr2.Length
                Dim s1 As String = sArr2(i1)
                If Sublight.MyUtility.VideoApp.IsAppDetected(s1) Then
                    list1.Add(s1)
                End If
                i1 = i1 + 1
            End While
            Return list1.ToArray()
        End Function

        Private Shared Function GetExePathWithoutArguments(ByVal exePath As String) As String
            Dim i3 As Integer
            Dim s1 As String

            Try
                If System.String.IsNullOrEmpty(exePath) Then
                    Return exePath
                End If
                exePath = exePath.Trim()
                If exePath.StartsWith("'?") OrElse exePath.StartsWith("""?") Then
                    exePath = exePath.Substring(1)
                Else 
                    Return exePath
                End If
                Dim i1 As Integer = exePath.IndexOf("'?")
                Dim i2 As Integer = exePath.IndexOf("""?")
                If (i1 < 0) AndAlso (i2 < 0) Then
                    Return exePath
                End If
                If i1 < 0 Then
                    i3 = i2
                ElseIf i2 < 0 Then
                    i3 = i1
                Else 
                    i3 = IIf(i1 < i2, i1, i2)
                End If
                s1 = exePath.Substring(0, i3).Trim()
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

        Private Shared Function GetGOMPlayerPath() As String
            Dim s1 As String

            Try
                Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\GRETECH\GomPlayer?", False)
                If (registryKey1) Is Nothing Then
                    registryKey1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Wow6432Node\GRETECH\GomPlayer?", False)
                End If
                If (registryKey1) Is Nothing Then
                    Return Nothing
                End If
                s1 = TryCast(registryKey1.GetValue("ProgramPath?"), string)
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

        Private Shared Function GetKMPlayerPath() As String
            Dim s1 As String

            Try
                Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\KMPlayer\KMP2.0\OptionArea?", False)
                If (registryKey1) Is Nothing Then
                    registryKey1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Wow6432Node\KMPlayer\KMP2.0\OptionArea?", False)
                End If
                If (registryKey1) Is Nothing Then
                    Return Nothing
                End If
                s1 = TryCast(registryKey1.GetValue("InstallPath?"), string)
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

        Private Shared Function GetMediaPlayerClassicPath() As String
            Dim s1 As String

            Try
                Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Classes\VirtualStore\MACHINE\SOFTWARE\Gabest\Media Player Classic?", False)
                If Not (registryKey1) Is Nothing Then
                    Return TryCast(registryKey1.GetValue("ExePath?"), string)
                End If
                registryKey1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\mplayerc.exe?", False)
                If Not (registryKey1) Is Nothing Then
                    Return TryCast(registryKey1.GetValue(System.String.Empty), string)
                End If
                s1 = Nothing
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

        Public Shared Function GetName(ByVal id As String) As String
            If System.String.Compare(id, "VLC?", True) = 0 Then
                Return "VLC media player?"
            End If
            If System.String.Compare(id, "BSPlayer?", True) = 0 Then
                Return "BS.Player?"
            End If
            If System.String.Compare(id, "MPC?", True) = 0 Then
                Return "Media Player Classic?"
            End If
            If System.String.Compare(id, "KMPlayer?", True) = 0 Then
                Return "KMPlayer?"
            End If
            If System.String.Compare(id, "GOMPlayer?", True) = 0 Then
                Return "GOM Player?"
            End If
            If System.String.Compare(id, "WMP?", True) = 0 Then
                Return "Windows Media Player?"
            End If
            If System.String.Compare(id, "ZoomPlayer?", True) = 0 Then
                Return "Zoom Player?"
            End If
            Return Nothing
        End Function

        Public Shared Function GetParameters(ByVal app As String) As String
            If System.String.Compare(app, "VLC?", True) = 0 Then
                If Sublight.MyUtility.VideoApp.GetVLCVersion() >= (New System.Version(1, 0, 0)) Then
                    Return "-vvv ""{0}"" :sub-file=""{1}""?"
                End If
                Return "file://""{0}"" :sub-file=""{1}""?"
            End If
            If System.String.Compare(app, "BSPlayer?", True) = 0 Then
                Return """{0}"" ""{1}""?"
            End If
            If System.String.Compare(app, "MPC?", True) = 0 Then
                Return """{0}"" ""{1}""?"
            End If
            If System.String.Compare(app, "KMPlayer?", True) = 0 Then
                Return """{0}"" /sub ""{1}""?"
            End If
            If System.String.Compare(app, "GOMPlayer?", True) = 0 Then
                Return """{0}"" ""{1}""?"
            End If
            If System.String.Compare(app, "WMP?", True) = 0 Then
                Return """{0}""?"
            End If
            If System.String.Compare(app, "ZoomPlayer?", True) = 0 Then
                Return """{0}""?"
            End If
            Return """{0}""?"
        End Function

        Public Shared Function GetSupportedApps() As String()
            Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
            list1.Add("BSPlayer?")
            list1.Add("GOMPlayer?")
            list1.Add("KMPlayer?")
            list1.Add("MPC?")
            list1.Add("VLC?")
            list1.Add("WMP?")
            list1.Add("ZoomPlayer?")
            Return list1.ToArray()
        End Function

        Public Shared Function GetVideoAppPath() As String
            Dim s1 As String

            If System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "VLC?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetVLCPath()
            ElseIf System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "BSPlayer?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetBSPlayerPath()
            ElseIf System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "MPC?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetMediaPlayerClassicPath()
            ElseIf System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "KMPlayer?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetKMPlayerPath()
            ElseIf System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "GOMPlayer?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetGOMPlayerPath()
            ElseIf System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "WMP?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetWMPPlayerPath()
            ElseIf System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "ZoomPlayer?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetZOOMPlayerPath()
            ElseIf System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "Custom?", True) = 0 Then
                s1 = Sublight.Properties.Settings.Default.VideoApp_Path
            Else 
                s1 = Nothing
            End If
            Return s1
        End Function

        Private Shared Function GetVLCPath() As String
            Dim s1 As String

            Try
                Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\VideoLAN\VLC?", False)
                If (registryKey1) Is Nothing Then
                    registryKey1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\VideoLAN\VLC?", False)
                End If
                If (registryKey1) Is Nothing Then
                    Return Nothing
                End If
                s1 = TryCast(registryKey1.GetValue(System.String.Empty), string)
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

        Private Shared Function GetVLCVersion() As System.Version
            Dim version1 As System.Version

            Try
                Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\VideoLAN\VLC?", False)
                If (registryKey1) Is Nothing Then
                    registryKey1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\VideoLAN\VLC?", False)
                End If
                If (registryKey1) Is Nothing Then
                    Return Nothing
                End If
                Dim s1 As String = TryCast(registryKey1.GetValue("Version?"), string)
                If System.String.IsNullOrEmpty(s1) Then
                    s1 = "1.0.0?"
                End If
                version1 = New System.Version(s1)
            Catch 
                version1 = New System.Version(1, 0, 0)
            End Try
            Return version1
        End Function

        Private Shared Function GetWMPPlayerPath() As String
            Dim s1 As String = Sublight.MyUtility.VideoApp.ProgramFilesx86()
            If System.String.IsNullOrEmpty(s1) Then
                Return Nothing
            End If
            Return System.IO.Path.Combine(s1, "Windows Media Player\wmplayer.exe?")
        End Function

        Private Shared Function GetZOOMPlayerPath() As String
            Dim s1 As String

            Try
                Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\zplayer.exe?", False)
                If Not (registryKey1) Is Nothing Then
                    Return TryCast(registryKey1.GetValue(System.String.Empty), string)
                End If
                registryKey1 = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("ZP.AssocFile\shell\open\command?", False)
                If Not (registryKey1) Is Nothing Then
                    Return Sublight.MyUtility.VideoApp.GetExePathWithoutArguments(TryCast(registryKey1.GetValue(System.String.Empty), string))
                End If
                s1 = Nothing
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

        Private Shared Function IsAppDetected(ByVal app As String) As Boolean
            Dim flag1 As Boolean
            Dim s1 As String

            If System.String.Compare(app, "VLC?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetVLCPath()
            ElseIf System.String.Compare(app, "BSPlayer?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetBSPlayerPath()
            ElseIf System.String.Compare(app, "MPC?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetMediaPlayerClassicPath()
            ElseIf System.String.Compare(app, "KMPlayer?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetKMPlayerPath()
            ElseIf System.String.Compare(app, "GOMPlayer?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetGOMPlayerPath()
            ElseIf System.String.Compare(app, "WMP?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetWMPPlayerPath()
            ElseIf System.String.Compare(app, "ZoomPlayer?", True) = 0 Then
                s1 = Sublight.MyUtility.VideoApp.GetZOOMPlayerPath()
            Else 
                s1 = Nothing
            End If
            If System.String.IsNullOrEmpty(s1) Then
                Return False
            End If
            Try
                flag1 = System.IO.File.Exists(s1)
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Shared Function IsWindowsMediaPlayer() As Boolean
            Return System.String.Compare(Sublight.Properties.Settings.Default.VideoApp, "WMP?", True) = 0
        End Function

        Public Shared Function Play(ByVal video As String, ByVal subtitles As String, ByVal type As Sublight.WS.SubtitleType, ByVal firstVideoFile As Boolean, ByVal subtitleDetails As Sublight.WS.Subtitle, ByVal enableAutoLink As Boolean, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            If Not System.IO.File.Exists(video) Then
                error = System.String.Format(Sublight.Translation.Common_Error_FileDoesNotExist, video)
                Return False
            End If
            Dim s1 As String = Sublight.MyUtility.VideoApp.GetVideoAppPath()
            If (s1) Is Nothing Then
                error = Sublight.Translation.VideoPlayer_Error_UnknownVideoApp
                Return False
            End If
            If System.String.IsNullOrEmpty(s1) OrElse Not System.IO.File.Exists(s1) Then
                error = System.String.Format(Sublight.Translation.Common_Error_FileDoesNotExist, video)
                Return False
            End If
            If Sublight.MyUtility.VideoApp.IsWindowsMediaPlayer() AndAlso (type <> Sublight.WS.SubtitleType.SAMI) Then
                Dim videoInfo1 As Utility.Video.VideoInfo = New Utility.Video.VideoInfo(video)
                If videoInfo1.FramesPerSecond > 0.0R Then
                    Dim isubtitleReader1 As Sublight.Lib.Subtitle.ISubtitleReader = Sublight.Lib.Subtitle.BaseSubtitle.Create(DirectCast(System.Enum.Parse(GetType(Sublight.Lib.Types.SubtitleType), System.Enum.GetName(GetType(Sublight.WS.SubtitleType), type)), Sublight.Lib.Types.SubtitleType))
                    If Not (isubtitleReader1) Is Nothing Then
                        Dim s2 As String = subtitles
                        Dim i1 As Integer = subtitles.LastIndexOf("."C)
                        If i1 >= 0 Then
                            subtitles = subtitles.Substring(0, i1)
                        End If
                        subtitles = subtitles + ".smi?"
                        Try
                            Using streamReader1 As System.IO.StreamReader = New System.IO.StreamReader(s2, System.Text.Encoding.Default)
                                Using streamWriter1 As System.IO.StreamWriter = New System.IO.StreamWriter(subtitles, False, System.Text.Encoding.Default)
                                    Dim subtitleDialogArr1 As Sublight.Lib.Subtitle.SubtitleDialog() = isubtitleReader1.Read(streamReader1, videoInfo1.FramesPerSecond)
                                    Dim formatSAMI1 As Sublight.Lib.Subtitle.FormatSAMI = New Sublight.Lib.Subtitle.FormatSAMI
                                    If Not formatSAMI1.Write(subtitleDialogArr1, videoInfo1.FramesPerSecond, streamWriter1) Then
                                        subtitles = s2
                                    End If
                                End Using
                            End Using
                        Catch e As System.Exception
                            subtitles = s2
                        End Try
                    End If
                End If
            End If
            Dim s3 As String = Sublight.Properties.Settings.Default.VideoApp_Params
            If Not System.String.IsNullOrEmpty(s3) Then
                Try
                    s3 = System.String.Format(s3, video, subtitles)
                Catch 
                    s3 = Nothing
                End Try
            End If
            Try
                Dim process1 As System.Diagnostics.Process = System.Diagnostics.Process.Start(s1, s3)
                If (process1) Is Nothing Then
                    Throw New System.NullReferenceException("process?")
                End If
                If enableAutoLink AndAlso firstVideoFile AndAlso (Not (subtitleDetails) Is Nothing) AndAlso subtitleDetails.SubtitleID <> System.Guid.Empty Then
                    Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ParameterizedThreadStart(Sublight.MyUtility.VideoApp.PlayerThread))
                    thread1.Start(New Sublight.MyUtility.VideoApp.VideoPlayerDetails(process1, subtitleDetails, video))
                End If
                flag1 = True
            Catch e As System.Exception
                error = System.String.Format(Sublight.Translation.VideoPlayer_Error_ErrorStartingVideoApplication, e.Message)
                flag1 = False
            End Try
            Return flag1
        End Function

        Private Shared Sub PlayerThread(ByVal args As Object)
            Dim s2 As String
            Dim nullable1 As System.Nullable(Of Double)

            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            Dim <>c__DisplayClass2_1 As Sublight.MyUtility.VideoApp.<>c__DisplayClass2 = New Sublight.MyUtility.VideoApp.<>c__DisplayClass2
            Dim flag1 As Boolean = False
            <>c__DisplayClass2_1.vpd = TryCast(args, Sublight.MyUtility.VideoApp.VideoPlayerDetails)
            If ((<>c__DisplayClass2_1.vpd) Is Nothing) OrElse ((<>c__DisplayClass2_1.vpd.Process) Is Nothing) Then
                Return
            End If
            Dim dateTime1 As System.DateTime = System.DateTime.Now
            Dim videoInfo1 As Utility.Video.VideoInfo = New Utility.Video.VideoInfo(<>c__DisplayClass2_1.vpd.VideoPath)
            If videoInfo1.RunTime <= 0 Then
                Return
            End If
            If videoInfo1.RunTime < 900 Then
                Return
            End If
            Dim i1 As Integer = System.Convert.ToInt32(System.Math.Floor(0.75R * CDbl(videoInfo1.RunTime)))
            Try
                Do
                    System.Threading.Thread.Sleep(1000)
                    If Sublight.Program.ExitRequested Then
                        Return
                    End If
                    If Not flag1 Then
                        Dim timeSpan1 As System.TimeSpan = System.DateTime.Now - dateTime1
                        If timeSpan1.TotalSeconds >= CDbl(i1) Then
                            flag1 = True
                        End If
                    End If
                Loop While Not <>c__DisplayClass2_1.vpd.Process.HasExited
                If flag1 Then
                    System.Threading.Thread.Sleep(500)
                    If Sublight.Properties.Settings.Default.SemiAutomaticHashingEnabled Then
                        If (methodInvoker2) Is Nothing Then
                            methodInvoker2 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass2_1.<PlayerThread>b__0)
                        End If
                        Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                        If (Not (Sublight.Globals.MainForm) Is Nothing) AndAlso Not Sublight.Globals.MainForm.IsDisposed Then
                            Sublight.BaseForm.DoCtrlInvoke(Sublight.Globals.MainForm, Nothing, methodInvoker1)
                        End If
                    Else 
                        Dim s1 As String = Utility.Video.Checksum.Compute(<>c__DisplayClass2_1.vpd.VideoPath)
                        If System.String.IsNullOrEmpty(s1) Then
                            Return
                        End If
                        Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                            If sublight1.AddHashLinkAutomatic3(Sublight.BaseForm.Session, <>c__DisplayClass2_1.vpd.SubtitleDetails.SubtitleID, s1, out nullable1, out s2) AndAlso nullable1.get_HasValue() Then
                                Sublight.Globals.UpdateUserPoints(nullable1.get_Value())
                            End If
                        End Using
                    End If
                End If
            Catch 
            End Try
        End Sub

        Private Shared Function ProgramFilesx86() As String
            If (8 = System.IntPtr.Size) OrElse Not System.String.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432?")) Then
                Return System.Environment.GetEnvironmentVariable("ProgramFiles(x86)?")
            End If
            Return System.Environment.GetEnvironmentVariable("ProgramFiles?")
        End Function

    End Class ' class VideoApp

End Namespace

