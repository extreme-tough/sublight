Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Windows.Forms

Namespace Sublight.MyUtility

    Friend MustInherit Class Browser

        Private Enum ExecutePrivilege
            AsInvokerOrAsManifest
            RequireAdmin
            RequireNonAdminIfPossible
        End Enum

        Private Enum ExecuteWaitType
            ReturnImmediately
            WaitForExit
        End Enum

        <System.Flags> _
        Private Enum KF_DEFINITION_FLAGS
        End Enum

        Private Enum SECURITY_IMPERSONATION_LEVEL
            Impersonation = 2
        End Enum

        Private Enum TOKEN_TYPE
            Primary = 1
        End Enum

        Private Delegate Function ExecuteHandOff(ByVal parent As System.Windows.Forms.IWin32Window, ByVal exePath As String, ByVal args As String, ByRef hProcess As System.IntPtr) As Integer

        Private Structure PROCESS_INFORMATION

            Public dwProcessId As UInteger 
            Public dwThreadId As UInteger 
            Public hProcess As System.IntPtr 
            Public hThread As System.IntPtr 

        End Structure

        Private Structure SHELLEXECUTEINFO

            Friend cbSize As UInteger 
            Friend dwHotKey As UInteger 
            Friend fMask As UInteger 
            Friend hIcon_or_hMonitor As System.IntPtr 
            Friend hInstApp As System.IntPtr 
            Friend hkeyClass As System.IntPtr 
            Friend hProcess As System.IntPtr 
            Friend hwnd As System.IntPtr 
            <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
            Friend lpClass As String 
            <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
            Friend lpDirectory As String 
            <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
            Friend lpFile As String 
            Friend lpIDList As System.IntPtr 
            <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
            Friend lpParameters As String 
            <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
            Friend lpVerb As String 
            Friend nShow As Integer 

        End Structure

        Private Const ERROR_CANCELLED As Integer  = 1223
        Private Const ERROR_SUCCESS As Integer  = 0
        Private Const ERROR_TIMEOUT As Integer  = 1460
        Private Const FILE_NOT_FOUND As Integer  = 2
        Private Const INFINITE As UInteger  = 4294967295UI
        Private Const MAXIMUM_ALLOWED As UInteger  = 33554432UI
        Private Const PROCESS_QUERY_INFORMATION As UInteger  = 1024UI
        Private Const SEE_MASK_FLAG_DDEWAIT As UInteger  = 256UI
        Private Const SEE_MASK_NO_CONSOLE As UInteger  = 32768UI
        Private Const SEE_MASK_NOCLOSEPROCESS As UInteger  = 64UI
        Private Const SW_SHOWNORMAL As Integer  = 1
        Private Const TOKEN_ASSIGN_PRIMARY As UInteger  = 1UI
        Private Const TOKEN_DUPLICATE As UInteger  = 2UI
        Private Const TOKEN_QUERY As UInteger  = 8UI

        Protected Sub New()
        End Sub

        Private Shared Function ExecAsInvokerOrAsManifest(ByVal parent As System.Windows.Forms.IWin32Window, ByVal exePath As String, ByVal args As String, ByRef hProcess As System.IntPtr) As Integer
            Return Sublight.MyUtility.Browser.ExecShellExecuteEx(parent, exePath, args, Nothing, out hProcess)
        End Function

        Private Shared Function ExecRequireAdmin(ByVal parent As System.Windows.Forms.IWin32Window, ByVal exePath As String, ByVal args As String, ByRef hProcess As System.IntPtr) As Integer
            Dim s1 As String = IIf(Sublight.MyUtility.Security.IsAdministrator, Nothing, "runas?")
            Return Sublight.MyUtility.Browser.ExecShellExecuteEx(parent, exePath, args, s1, out hProcess)
        End Function

        Private Shared Function ExecRequireNonAdmin(ByVal parent As System.Windows.Forms.IWin32Window, ByVal exePath As String, ByVal args As String, ByRef hProcess As System.IntPtr) As Integer
            Dim i1 As Integer
            Dim ui1 As UInteger
            Dim s2 As String
            Dim process_INFORMATION1 As Sublight.MyUtility.Browser.PROCESS_INFORMATION

            Dim s1 As String = """?" + exePath + """?" + IIf((args) Is Nothing, "?", " ?" + args)
            Try
                s2 = System.IO.Path.GetDirectoryName(exePath)
            Catch e As System.Exception
                s2 = Nothing
            End Try
            Dim intPtr1 As System.IntPtr = System.IntPtr.Zero
            Dim intPtr2 As System.IntPtr = System.IntPtr.Zero
            Dim intPtr3 As System.IntPtr = System.IntPtr.Zero
            Dim intPtr4 As System.IntPtr = System.IntPtr.Zero
            Dim intPtr5 As System.IntPtr = System.IntPtr.Zero
            Dim intPtr6 As System.IntPtr = System.IntPtr.Zero
            process_INFORMATION1 = New Sublight.MyUtility.Browser.PROCESS_INFORMATION
            Try
                Dim intPtr7 As System.IntPtr = Sublight.MyUtility.Browser.FindWindowW("Progman?", Nothing)
                If intPtr7 = System.IntPtr.Zero Then
                    Sublight.MyUtility.Browser.ThrowOnWin32Error("FindWindowW() returned NULL?")
                End If
                Sublight.MyUtility.Browser.GetWindowThreadProcessId(intPtr7, out ui1)
                If CInt(ui1) = 0 Then
                    Sublight.MyUtility.Browser.ThrowOnWin32Error("GetWindowThreadProcessId returned 0?", 2)
                End If
                intPtr1 = Sublight.MyUtility.Browser.OpenProcess(1024, False, ui1)
                If System.IntPtr.Zero = intPtr1 Then
                    Sublight.MyUtility.Browser.ThrowOnWin32Error("OpenProcess() returned NULL?")
                End If
                Dim flag1 As Boolean = Sublight.MyUtility.Browser.OpenProcessToken(intPtr1, 11, out intPtr2)
                If Not flag1 Then
                    Sublight.MyUtility.Browser.ThrowOnWin32Error("OpenProcessToken() returned FALSE?")
                End If
                Dim flag2 As Boolean = Sublight.MyUtility.Browser.DuplicateTokenEx(intPtr2, 33554432, System.IntPtr.Zero, Sublight.MyUtility.Browser.SECURITY_IMPERSONATION_LEVEL.Impersonation, Sublight.MyUtility.Browser.TOKEN_TYPE.Primary, out intPtr3)
                If Not flag2 Then
                    Sublight.MyUtility.Browser.ThrowOnWin32Error("DuplicateTokenEx() returned FALSE?")
                End If
                intPtr4 = System.Runtime.InteropServices.Marshal.StringToBSTR(exePath)
                intPtr5 = System.Runtime.InteropServices.Marshal.StringToBSTR(s1)
                intPtr6 = System.Runtime.InteropServices.Marshal.StringToBSTR(s2)
                Dim flag3 As Boolean = Sublight.MyUtility.Browser.CreateProcessWithTokenW(intPtr3, 0, intPtr4, intPtr5, 0, System.IntPtr.Zero, intPtr6, System.IntPtr.Zero, out process_INFORMATION1)
                If flag3 Then
                    hProcess = process_INFORMATION1.hProcess
                    process_INFORMATION1.hProcess = System.IntPtr.Zero
                    i1 = 0
                Else 
                    hProcess = System.IntPtr.Zero
                    i1 = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
                End If
            Catch e As System.ComponentModel.Win32Exception
                i1 = e.ErrorCode
                hProcess = System.IntPtr.Zero
            Finally
                If intPtr4 <> System.IntPtr.Zero Then
                    System.Runtime.InteropServices.Marshal.FreeBSTR(intPtr4)
                End If
                If intPtr5 <> System.IntPtr.Zero Then
                    System.Runtime.InteropServices.Marshal.FreeBSTR(intPtr5)
                End If
                If intPtr6 <> System.IntPtr.Zero Then
                    System.Runtime.InteropServices.Marshal.FreeBSTR(intPtr6)
                End If
                If intPtr1 <> System.IntPtr.Zero Then
                    Sublight.MyUtility.Browser.CloseHandle(intPtr1)
                End If
                If intPtr2 <> System.IntPtr.Zero Then
                    Sublight.MyUtility.Browser.CloseHandle(intPtr2)
                End If
                If intPtr3 <> System.IntPtr.Zero Then
                    Sublight.MyUtility.Browser.CloseHandle(intPtr3)
                End If
                If process_INFORMATION1.hThread <> System.IntPtr.Zero Then
                    Sublight.MyUtility.Browser.CloseHandle(process_INFORMATION1.hThread)
                    process_INFORMATION1.hThread = System.IntPtr.Zero
                End If
                If process_INFORMATION1.hProcess <> System.IntPtr.Zero Then
                    Sublight.MyUtility.Browser.CloseHandle(process_INFORMATION1.hProcess)
                    process_INFORMATION1.hProcess = System.IntPtr.Zero
                End If
            End Try
            Return i1
        End Function

        Private Shared Function ExecShellExecuteEx(ByVal parent As System.Windows.Forms.IWin32Window, ByVal exePath As String, ByVal args As String, ByVal verb As String, ByRef hProcess As System.IntPtr) As Integer
            Dim s1 As String
            Dim shellexecuteinfo3 As Sublight.MyUtility.Browser.SHELLEXECUTEINFO

            Try
                s1 = System.IO.Path.GetDirectoryName(exePath)
            Catch e As System.Exception
                s1 = Nothing
            End Try
            shellexecuteinfo3 = New Sublight.MyUtility.Browser.SHELLEXECUTEINFO
            Dim shellexecuteinfo2 As Sublight.MyUtility.Browser.SHELLEXECUTEINFO = shellexecuteinfo3
            shellexecuteinfo2.cbSize = CUInt(System.Runtime.InteropServices.Marshal.SizeOf(GetType(Sublight.MyUtility.Browser.SHELLEXECUTEINFO)))
            shellexecuteinfo2.fMask = 33088
            shellexecuteinfo2.lpVerb = verb
            shellexecuteinfo2.lpDirectory = s1
            shellexecuteinfo2.lpFile = exePath
            shellexecuteinfo2.lpParameters = args
            shellexecuteinfo2.nShow = 1
            Dim shellexecuteinfo1 As Sublight.MyUtility.Browser.SHELLEXECUTEINFO = shellexecuteinfo2
            If Not (parent) Is Nothing Then
                shellexecuteinfo1.hwnd = parent.Handle
            End If
            Dim flag1 As Boolean = Sublight.MyUtility.Browser.ShellExecuteExW(ByRef shellexecuteinfo1)
            hProcess = shellexecuteinfo1.hProcess
            shellexecuteinfo1.hProcess = System.IntPtr.Zero
            Dim i1 As Integer = 0
            If Not flag1 Then
                i1 = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
            End If
            Return i1
        End Function

        Private Shared Sub Execute(ByVal parent As System.Windows.Forms.IWin32Window, ByVal exePath As String, ByVal args As String, ByVal execPrivilege As Sublight.MyUtility.Browser.ExecutePrivilege, ByVal execWaitType As Sublight.MyUtility.Browser.ExecuteWaitType)
            Dim intPtr1 As System.IntPtr
            Dim executeHandOff1 As Sublight.MyUtility.Browser.ExecuteHandOff

            If (exePath) Is Nothing Then
                Throw New System.ArgumentNullException("exePath?")
            End If
            If (execPrivilege = Sublight.MyUtility.Browser.ExecutePrivilege.RequireAdmin) AndAlso ((parent) Is Nothing) Then
                Throw New System.ArgumentNullException("parent?")
            End If
            If (execPrivilege = Sublight.MyUtility.Browser.ExecutePrivilege.RequireAdmin) AndAlso Not Sublight.MyUtility.Security.IsAdministrator AndAlso Not Sublight.MyUtility.Security.CanElevateToAdministrator Then
                Throw New System.Security.SecurityException("Administrator rights required.?")
            End If
            Select Case execPrivilege
                Case Sublight.MyUtility.Browser.ExecutePrivilege.AsInvokerOrAsManifest
                    executeHandOff1 = New Sublight.MyUtility.Browser.ExecuteHandOff(Sublight.MyUtility.Browser.ExecAsInvokerOrAsManifest)

                Case Sublight.MyUtility.Browser.ExecutePrivilege.RequireAdmin
                    executeHandOff1 = New Sublight.MyUtility.Browser.ExecuteHandOff(Sublight.MyUtility.Browser.ExecRequireAdmin)

                Case Sublight.MyUtility.Browser.ExecutePrivilege.RequireNonAdminIfPossible
                    If Sublight.MyUtility.Security.CanLaunchNonAdminProcess Then
                        executeHandOff1 = New Sublight.MyUtility.Browser.ExecuteHandOff(Sublight.MyUtility.Browser.ExecRequireNonAdmin)
                    Else 
                        executeHandOff1 = New Sublight.MyUtility.Browser.ExecuteHandOff(Sublight.MyUtility.Browser.ExecAsInvokerOrAsManifest)
                    End If

                Case Else
                    Throw New System.ComponentModel.InvalidEnumArgumentException("ExecutePrivilege?")
            End Select
            Dim i1 As Integer = RaiseEvent executeHandOff1(parent, exePath, args, intPtr1)
            If i1 = 0 Then
                If execWaitType = Sublight.MyUtility.Browser.ExecuteWaitType.WaitForExit Then
                    Sublight.MyUtility.Browser.WaitForSingleObject(intPtr1, -1)
                End If
                If intPtr1 = System.IntPtr.Zero Then
                    Return
                End If
                Sublight.MyUtility.Browser.CloseHandle(intPtr1)
                Return
            End If
            If i1 <> 1223 Then
                If i1 = 1460 Then
                    Return
                End If
                Sublight.MyUtility.Browser.ThrowOnWin32Error("Execute failed?", i1)
            End If
        End Sub

        Public Shared Function OpenUrl(ByVal owner As System.Windows.Forms.IWin32Window, ByVal url As String) As Boolean
            Dim flag1 As Boolean

            Try
                If Not (owner) Is Nothing Then
                    Dim form1 As System.Windows.Forms.Form = TryCast(owner, System.Windows.Forms.Form)
                    If Not (form1) Is Nothing Then
                        If form1.IsDisposed Then
                            owner = Nothing
                        ElseIf form1.InvokeRequired Then
                            owner = Nothing
                        End If
                    End If
                End If
                flag1 = Sublight.MyUtility.Browser.OpenUrlUnsafe(owner, url)
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

        Private Shared Function OpenUrlUnsafe(ByVal owner As System.Windows.Forms.IWin32Window, ByVal url As String) As Boolean
            Dim executePrivilege1 As Sublight.MyUtility.Browser.ExecutePrivilege

            If (url) Is Nothing Then
                Throw New System.NullReferenceException("url?")
            End If
            If url.Length > 512 Then
                Throw New System.ArgumentOutOfRangeException("url Length must be <= 512?")
            End If
            Dim flag1 As Boolean = False
            Dim s1 As String = """?" + url + """?"
            If Not Sublight.MyUtility.Security.IsAdministrator OrElse (Sublight.MyUtility.Security.IsAdministrator AndAlso Not Sublight.MyUtility.Security.CanLaunchNonAdminProcess) Then
                executePrivilege1 = Sublight.MyUtility.Browser.ExecutePrivilege.AsInvokerOrAsManifest
            Else 
                executePrivilege1 = Sublight.MyUtility.Browser.ExecutePrivilege.RequireNonAdminIfPossible
            End If
            If executePrivilege1 <> Sublight.MyUtility.Browser.ExecutePrivilege.RequireNonAdminIfPossible Then
                Try
                    Sublight.MyUtility.Browser.Execute(owner, s1, Nothing, executePrivilege1, Sublight.MyUtility.Browser.ExecuteWaitType.ReturnImmediately)
                    flag1 = True
                Catch e As System.Exception
                    flag1 = False
                End Try
            End If
            If Not flag1 Then
                Try
                    Dim s2 As String = System.Environment.ExpandEnvironmentVariables("%WINDIR%\explorer.exe?")
                    Sublight.MyUtility.Browser.Execute(owner, s2, s1, executePrivilege1, Sublight.MyUtility.Browser.ExecuteWaitType.ReturnImmediately)
                    flag1 = True
                Catch e As System.Exception
                    flag1 = False
                End Try
            End If
            Return flag1
        End Function

        Private Shared Sub ThrowOnWin32Error(ByVal message As String, ByVal lastWin32Error As Integer)
            If lastWin32Error <> 0 Then
                Dim s1 As String = System.String.Format("{0} ({1})?", message, lastWin32Error)
                Throw New System.ComponentModel.Win32Exception(lastWin32Error, s1)
            End If
        End Sub

        Private Shared Sub ThrowOnWin32Error(ByVal message As String)
            Dim i1 As Integer = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
            Sublight.MyUtility.Browser.ThrowOnWin32Error(message, i1)
        End Sub

        <System.Runtime.InteropServices.PreserveSig
        <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
        Private Declare Ansi Function CloseHandle Lib "kernel32.dll" (ByVal hObject As System.IntPtr) As Boolean

        <System.Runtime.InteropServices.PreserveSig
        <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
        Private Declare Unicode Function CreateProcessWithTokenW Lib "advapi32.dll" (ByVal hToken As System.IntPtr, ByVal dwLogonFlags As UInteger, ByVal lpApplicationName As System.IntPtr, ByVal lpCommandLine As System.IntPtr, ByVal dwCreationFlags As UInteger, ByVal lpEnvironment As System.IntPtr, ByVal lpCurrentDirectory As System.IntPtr, ByVal lpStartupInfo As System.IntPtr, ByRef lpProcessInfo As Sublight.MyUtility.Browser.PROCESS_INFORMATION) As Boolean

        <System.Runtime.InteropServices.PreserveSig
        <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
        Private Declare Ansi Function DuplicateTokenEx Lib "advapi32.dll" (ByVal hExistingToken As System.IntPtr, ByVal dwDesiredAccess As UInteger, ByVal lpTokenAttributes As System.IntPtr, ByVal ImpersonationLevel As Sublight.MyUtility.Browser.SECURITY_IMPERSONATION_LEVEL, ByVal TokenType As Sublight.MyUtility.Browser.TOKEN_TYPE, ByRef phNewToken As System.IntPtr) As Boolean

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Unicode Function FindWindowW Lib "user32.dll" (<System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal lpClassName As String, <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)> ByVal lpWindowName As String) As System.IntPtr

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hWnd As System.IntPtr, ByRef lpdwProcessId As UInteger) As UInteger

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAccess As UInteger, <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> ByVal bInheritHandle As Boolean, ByVal dwProcessId As UInteger) As System.IntPtr

        <System.Runtime.InteropServices.PreserveSig
        <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
        Private Declare Ansi Function OpenProcessToken Lib "advapi32.dll" (ByVal ProcessHandle As System.IntPtr, ByVal DesiredAccess As UInteger, ByRef TokenHandle As System.IntPtr) As Boolean

        <System.Runtime.InteropServices.PreserveSig
        <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
        Private Declare Unicode Function ShellExecuteExW Lib "shell32.dll" (ByRef lpExecInfo As Sublight.MyUtility.Browser.SHELLEXECUTEINFO) As Boolean

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function WaitForSingleObject Lib "kernel32.dll" (ByVal hHandle As System.IntPtr, ByVal dwMilliseconds As UInteger) As UInteger

    End Class ' class Browser

End Namespace

