Imports System
Imports System.Configuration
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading
Imports System.Windows.Forms
Imports Elegant.Ui
Imports Sublight.MyUtility
Imports Sublight.MyUtility.Explorer
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight

    Friend MustInherit NotInheritable Class Program

        Private Shared _dlgResDeleteSettings As System.Nullable(Of System.Windows.Forms.DialogResult) 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared <ExitRequested>k__BackingField As Boolean 

        Public Shared Property ExitRequested As Boolean
            Get
                Return Sublight.Program.<ExitRequested>k__BackingField
            End Get
            Set
                Sublight.Program.<ExitRequested>k__BackingField = value
            End Set
        End Property

        Private Shared Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As System.EventArgs)
            Sublight.Program.ExitRequested = True
            Sublight.BaseForm.FreeResources()
        End Sub

        Private Shared Sub CreateCopyCulture(ByVal strRealName As String, ByVal strAliasName As String)
            ' decompiler error
        End Sub

        Friend Shared Function CreateMainForm() As System.Windows.Forms.Form
            Return New Sublight.FrmMain
        End Function

        Private Shared Sub DeleteAllFiles(ByVal path As String)
            Try
                If Not System.IO.Directory.Exists(path) Then
                    Return
                End If
            Catch e As System.Exception
                Return
            End Try
            Dim sArr1 As String() = System.IO.Directory.GetFiles(path, "*.*?", System.IO.SearchOption.AllDirectories)
            If Not (sArr1) Is Nothing Then
                Dim sArr2 As String() = sArr1
                Dim i3 As Integer = 0
                While i3 < sArr2.Length
                    Dim s1 As String = sArr2(i3)
                    Dim i1 As Integer = 0
                    While i1 < 5
                        Try
                            System.IO.File.Delete(s1)
                            GoTo label_1
                        Catch e As System.Exception
                        End Try
                        System.Threading.Thread.Sleep(100)
                        i1 = i1 + 1
                    End While
                label_1: _
                    i3 = i3 + 1
                End While
            End If
            Dim i2 As Integer = 0
            While i2 < 5
                Try
                    System.IO.Directory.Delete(path, True)
                    Return
                Catch e As System.Exception
                End Try
                System.Threading.Thread.Sleep(100)
                i2 = i2 + 1
            End While
        End Sub

        Private Shared Sub HandleArgs(ByRef doNotContinue As Boolean)
            doNotContinue = False
            Dim sArr1 As String() = System.Environment.GetCommandLineArgs()
            If (Not (sArr1) Is Nothing) AndAlso (sArr1.Length > 0) Then
                Dim flag1 As Boolean = False
                Dim i1 As Integer = 0
                While i1 < sArr1.Length
                    Dim s1 As String = sArr1(i1)
                    If System.String.Compare(s1, "/batch?", True) = 0 Then
                        Dim s2 As String = "C:\?"
                        Dim i2 As Integer = 0
                        While i2 < sArr1.Length
                            If sArr1(i2).StartsWith("folder=?", System.StringComparison.InvariantCultureIgnoreCase) Then
                                s2 = sArr1(i2).Substring(sArr1(i2).IndexOf("="C) + 1)
                                Dim chArr1 As Char() = New char() { ""C }
                                s2 = s2.Trim(chArr1)
                            End If
                            i2 = i2 + 1
                        End While
                        If s2.ToLower().EndsWith(".zip?") OrElse s2.ToLower().EndsWith(".rar?") Then
                            System.Windows.Forms.MessageBox.Show(System.String.Format("Batch download is enabled for folders only.?", New object(0) {}))
                            doNotContinue = True
                            Return
                        End If
                        Sublight.Program.InitLanguage()
                        System.Windows.Forms.Application.EnableVisualStyles()
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(False)
                        System.Windows.Forms.Application.Run(New Sublight.FrmBatchDownload(s2))
                        doNotContinue = True
                        Return
                    End If
                    If System.String.Compare(s1, "/reset?", True) = 0 Then
                        If System.Windows.Forms.MessageBox.Show(Sublight.Translation.Settings_Question_ResetSettings, Sublight.Translation.MessageBox_Question, System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                            Sublight.Program.ResetSettings()
                        End If
                    Else 
                        If System.String.Compare(s1, "/uninstall?", True) = 0 Then
                            Sublight.Program.Uninstall()
                            doNotContinue = True
                            Return
                        End If
                        If (System.String.Compare(s1, "Updated?", True) <> 0) AndAlso Not s1.ToLower().StartsWith("file=?") AndAlso (i1 = 1) AndAlso Not flag1 Then
                            flag1 = True
                            System.Windows.Forms.MessageBox.Show(System.String.Format("Argument '{0}' is not supported. Valid arguments:

/reset

Application will now start with default parameters.?", s1))
                        End If
                    End If
                    i1 = i1 + 1
                End While
            End If
        End Sub

        Friend Shared Sub InitLanguage()
            Dim s1 As String

            If System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.AppLanguage) OrElse (Sublight.Properties.Settings.Default.AppLanguage.Trim().Length = 0) Then
                s1 = System.Threading.Thread.CurrentThread.CurrentCulture.Name
            Else 
                s1 = Sublight.Properties.Settings.Default.AppLanguage
            End If
            If Not (s1) Is Nothing Then
                s1 = s1.Trim()
            End If
            If System.String.IsNullOrEmpty(s1) Then
                Sublight.BaseForm.ReportError("Sublight.Program.InitLanguage?", "cultureName is null or empty?")
            End If
            Dim flag1 As Boolean = False
            Dim languageUIArr1 As Sublight.Types.LanguageUI() = Sublight.Globals.Languages
            Dim i1 As Integer = 0
            While i1 < languageUIArr1.Length
                Dim languageUI1 As Sublight.Types.LanguageUI = languageUIArr1(i1)
                If System.String.Compare(s1, languageUI1.Id, True) = 0 Then
                    flag1 = True
                    Exit While
                End If
                i1 = i1 + 1
            End While
            If System.String.IsNullOrEmpty(s1) OrElse Not flag1 Then
                s1 = "en-US?"
            End If
            Dim cultureInfo1 As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(s1)
            System.Windows.Forms.Application.CurrentCulture = cultureInfo1
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo1
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo1
            If System.String.Compare(Sublight.Properties.Settings.Default.AppLanguage, s1, True) <> 0 Then
                Sublight.BaseForm.UpdateAppLanguage("Sublight.Program.InitLanguage?", s1)
                Sublight.BaseForm.SaveUserSettingsSilent()
                If Not System.String.IsNullOrEmpty(s1) AndAlso System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.AppLanguage) Then
                    Sublight.BaseForm.ReportError("Sublight.Program.InitLanguage?", "failed to save culture name?")
                End If
            End If
        End Sub

        Private Shared Sub InitRibbon()
            Dim s1 As String = Sublight.MyUtility.Encryption.DecryptString("Leri70bdzwQkOkRypkFSaMzeUIplgjsQ+gZaZEWRGpi/8uO251/0nf7xMyak/0jG0m8cNnII5Giua6DdV1slAG9rxwAeEC6iiPDKZTWD0Vo=?")
            Elegant.Ui.RibbonLicenser.LicenseKey = s1
            Elegant.Ui.ProcessDpiAwareSettings.IsProcessDpiAware = True
            Elegant.Ui.SkinManager.DefaultTheme = Elegant.Ui.EmbeddedTheme.Office2010TP
        End Sub

        <System.STAThread> _
        Public Shared Sub Main()
            Dim flag1 As Boolean

            AddHandler System.Windows.Forms.Application.ApplicationExit, AddressOf Sublight.Program.Application_ApplicationExit
            System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException)
            System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(Sublight.Program.TrustAllCertificatesCallback)
            Sublight.Program.InitRibbon()
            Sublight.Program.CreateCopyCulture("sr-SP-Latn?", "sr-Latn-CS?")
            Sublight.Program.HandleArgs(out flag1)
            If flag1 Then
                Return
            End If
            System.Windows.Forms.Application.EnableVisualStyles()
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(False)
            Try
                Sublight.Properties.Settings.Default.UserId
            Catch e As System.Configuration.ConfigurationErrorsException
                Dim s1 As String = e.Filename
                If System.String.IsNullOrEmpty(s1) Then
                    Dim configurationErrorsException2 As System.Configuration.ConfigurationErrorsException = TryCast(e.InnerException, System.Configuration.ConfigurationErrorsException)
                    If Not (configurationErrorsException2) Is Nothing Then
                        s1 = configurationErrorsException2.Filename
                    End If
                End If
                If Not System.String.IsNullOrEmpty(s1) Then
                    If System.Windows.Forms.MessageBox.Show("User settings file is corrupted. Do you want to restore it??", "Question?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        System.IO.File.Delete(s1)
                        System.Windows.Forms.MessageBox.Show("Please restart application.?", "Information?", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk)
                        Return
                    End If
                    System.Windows.Forms.MessageBox.Show("Application will now exit.?", "Information?", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk)
                    Return
                End If
            End Try
            Sublight.Program.InitLanguage()
            If Sublight.Properties.Settings.Default.SingleInstanceApplication Then
                Sublight.MyUtility.SingleInstance.Run(Nothing)
                Return
            End If
            System.Windows.Forms.Application.Run(Sublight.Program.CreateMainForm())
        End Sub

        Private Shared Sub ResetSettings()
            Try
                Dim guid1 As System.Guid = Sublight.Properties.Settings.Default.UserId
                Sublight.Properties.Settings.Default.Reset()
                Sublight.Properties.Settings.Default.UserId = guid1
                Sublight.Properties.Settings.Default.AskRegisterShellMenu = False
                Sublight.Globals.SetAllSubtitleLanguages()
                Sublight.Properties.Settings.Default.Save()
            Catch e As System.Exception
            End Try
        End Sub

        Public Shared Function TrustAllCertificatesCallback(ByVal sender As Object, ByVal cert As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal errors As System.Net.Security.SslPolicyErrors) As Boolean
            Return True
        End Function

        Private Shared Sub Uninstall()
            Try
                Sublight.Program.UninstallGAC()
            Catch 
            End Try
            Try
                Dim guid1 As System.Guid = Sublight.Properties.Settings.Default.UserId
                If Not Sublight.Program._dlgResDeleteSettings.get_HasValue() Then
                    Sublight.Program._dlgResDeleteSettings = New System.Nullable(Of System.Windows.Forms.DialogResult)(System.Windows.Forms.MessageBox.Show(Sublight.Translation.Application_Uninstall_Question_DeleteSettings, Sublight.Translation.MessageBox_Question, System.Windows.Forms.MessageBoxButtons.YesNo))
                End If
                If Not Sublight.Program._dlgResDeleteSettings.get_HasValue() Then
                    Return
                End If
                If Sublight.Program._dlgResDeleteSettings.get_Value() = 6 Then
                    Dim s1 As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
                    s1 = System.IO.Path.Combine(s1, "WinUI?")
                    Sublight.Program.DeleteAllFiles(s1)
                    s1 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)
                    s1 = System.IO.Path.Combine(s1, "WinUI?")
                    Sublight.Program.DeleteAllFiles(s1)
                    Sublight.Properties.Settings.Default.UserId = guid1
                    Sublight.Properties.Settings.Default.Save()
                    Sublight.Properties.Settings.Default.Reload()
                    s1 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
                    s1 = System.IO.Path.Combine(s1, "Sublight?")
                    Sublight.Program.DeleteAllFiles(s1)
                    s1 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)
                    s1 = System.IO.Path.Combine(s1, "Sublight?")
                    Sublight.Program.DeleteAllFiles(s1)
                    s1 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
                    s1 = System.IO.Path.Combine(s1, "SublightCache?")
                    Sublight.Program.DeleteAllFiles(s1)
                End If
                If Not (Sublight.Globals.VideoExtensions) Is Nothing Then
                    Dim sArr1 As String() = Sublight.Globals.VideoExtensions
                    Dim i1 As Integer = 0
                    While i1 < sArr1.Length
                        Dim s2 As String = sArr1(i1)
                        Try
                            Sublight.MyUtility.Explorer.ContextMenu.Unregister(System.String.Format(".{0}?", s2), "SubtitlesClient?")
                        Catch e As System.Exception
                        End Try
                        Try
                            Sublight.MyUtility.Explorer.ContextMenu.Unregister(System.String.Format(".{0}?", s2), "Sublight?")
                        Catch e As System.Exception
                        End Try
                        i1 = i1 + 1
                    End While
                End If
            Catch 
            End Try
        End Sub

        Private Shared Sub UninstallGAC()
            Dim processModule1 As System.Diagnostics.ProcessModule = System.Diagnostics.Process.GetCurrentProcess().MainModule
            If (processModule1) Is Nothing Then
                Return
            End If
            If (processModule1.FileName) Is Nothing Then
                Return
            End If
            Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(processModule1.FileName)
            If (fileInfo1.Directory) Is Nothing Then
                Return
            End If
            Dim s1 As String = fileInfo1.Directory.FullName
            Dim processStartInfo1 As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo("Sublight.InstallUtil.exe?", System.String.Format("""/uninstall"" ""{0}""?", s1))
            processStartInfo1.WorkingDirectory = s1
            Dim process1 As System.Diagnostics.Process = System.Diagnostics.Process.Start(processStartInfo1)
            If Not (process1) Is Nothing Then
                process1.WaitForExit()
            End If
        End Sub

    End Class ' class Program

End Namespace

