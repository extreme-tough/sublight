Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Sublight

Namespace Sublight.MyUtility

    Friend NotInheritable Class SingleInstance

        Public MustInherit NotInheritable Class OpenWindowGetter

            Private Delegate Function EnumWindowsProc(ByVal hWnd As System.IntPtr, ByVal lParam As Integer) As Boolean

            <System.Runtime.CompilerServices.CompilerGenerated> _
            Private NotInheritable Class <>c__DisplayClass1

                Public lShellWindow As System.IntPtr 
                Public lWindows As System.Collections.Generic.Dictionary(Of System.IntPtr,String) 

                Public Sub New()
                End Sub

                Public Function <GetOpenWindows>b__0(ByVal hWnd As System.IntPtr, ByVal lParam As Integer) As Boolean
                    If hWnd = lShellWindow Then
                        Return True
                    End If
                    If Not Sublight.MyUtility.SingleInstance.OpenWindowGetter.IsWindowVisible(hWnd) Then
                        Return True
                    End If
                    Dim i1 As Integer = Sublight.MyUtility.SingleInstance.OpenWindowGetter.GetWindowTextLength(hWnd)
                    If i1 = 0 Then
                        Return True
                    End If
                    Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder(i1)
                    Sublight.MyUtility.SingleInstance.OpenWindowGetter.GetWindowText(hWnd, stringBuilder1, i1 + 1)
                    lWindows.set_Item(hWnd, stringBuilder1.ToString())
                    Return True
                End Function

            End Class ' class <>c__DisplayClass1

            Public Shared Function GetOpenWindows() As System.Collections.Generic.IDictionary(Of System.IntPtr,String)
                Dim <>c__DisplayClass1_1 As Sublight.MyUtility.SingleInstance.OpenWindowGetter.<>c__DisplayClass1 = New Sublight.MyUtility.SingleInstance.OpenWindowGetter.<>c__DisplayClass1
                <>c__DisplayClass1_1.lShellWindow = Sublight.MyUtility.SingleInstance.OpenWindowGetter.GetShellWindow()
                <>c__DisplayClass1_1.lWindows = New System.Collections.Generic.Dictionary(Of System.IntPtr,String)
                Sublight.MyUtility.SingleInstance.OpenWindowGetter.EnumWindows(New Sublight.MyUtility.SingleInstance.OpenWindowGetter.EnumWindowsProc(<>c__DisplayClass1_1.<GetOpenWindows>b__0), 0)
                Return <>c__DisplayClass1_1.lWindows
            End Function

            <System.Runtime.InteropServices.PreserveSig
            Private Declare Ansi Function EnumWindows Lib "USER32.DLL" (ByVal enumFunc As Sublight.MyUtility.SingleInstance.OpenWindowGetter.EnumWindowsProc, ByVal lParam As Integer) As Boolean

            <System.Runtime.InteropServices.PreserveSig
            Private Declare Ansi Function GetShellWindow Lib "USER32.DLL" () As System.IntPtr

            <System.Runtime.InteropServices.PreserveSig
            Private Declare Ansi Function GetWindowText Lib "USER32.DLL" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer

            <System.Runtime.InteropServices.PreserveSig
            Private Declare Ansi Function GetWindowTextLength Lib "USER32.DLL" (ByVal hWnd As System.IntPtr) As Integer

            <System.Runtime.InteropServices.PreserveSig
            Private Declare Ansi Function IsWindowVisible Lib "USER32.DLL" (ByVal hWnd As System.IntPtr) As Boolean

        End Class ' class OpenWindowGetter

        Private Const SW_RESTORE As Integer  = 9

        Private Shared mutex As System.Threading.Mutex 

        Public Sub New()
        End Sub

        Private Shared Function GetCurrentInstanceWindowHandle() As System.IntPtr
            Dim i1 As Integer
            Dim intPtr1 As System.IntPtr

            Dim process1 As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
            Using ienumerator1 As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of System.IntPtr,String)) = Sublight.MyUtility.SingleInstance.OpenWindowGetter.GetOpenWindows().GetEnumerator()
                While ienumerator1.MoveNext()
                    Dim keyValuePair1 As System.Collections.Generic.KeyValuePair(Of System.IntPtr,String) = ienumerator1.get_Current()
                    If Not System.String.IsNullOrEmpty(keyValuePair1.get_Value()) AndAlso keyValuePair1.get_Value().StartsWith("Sublight - ?") Then
                        Sublight.MyUtility.SingleInstance.GetWindowThreadProcessId(keyValuePair1.get_Key(), out i1)
                        Try
                            Dim process2 As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(i1)
                            If (process1.Id <> process2.Id) AndAlso (Not (process1.MainModule) Is Nothing) AndAlso (Not (process2.MainModule) Is Nothing) AndAlso process1.MainModule.FileName = process2.MainModule.FileName Then
                                intPtr1 = keyValuePair1.get_Key()
                                Return intPtr1
                            End If
                        Catch 
                        End Try
                    End If
                End While
            End Using
            Return System.IntPtr.Zero
        End Function

        Private Shared Function IsAlreadyRunning() As Boolean
            Dim flag1 As Boolean

            Dim s1 As String = System.Reflection.Assembly.GetExecutingAssembly().Location
            If Not (s1) Is Nothing Then
                Dim fileSystemInfo1 As System.IO.FileSystemInfo = New System.IO.FileInfo(s1)
                Dim s2 As String = fileSystemInfo1.Name
                Sublight.MyUtility.SingleInstance.mutex = New System.Threading.Mutex(True, "Global\?" + s2, flag1)
                If flag1 Then
                    Sublight.MyUtility.SingleInstance.mutex.ReleaseMutex()
                End If
                Return Not flag1
            End If
            Return False
        End Function

        Public Shared Function Run(ByVal frmMain As System.Windows.Forms.Form) As Boolean
            Dim flag1 As Boolean

            Try
                If Sublight.MyUtility.SingleInstance.IsAlreadyRunning() AndAlso Sublight.MyUtility.SingleInstance.SwitchToCurrentInstance() Then
                    Return False
                End If
                If (frmMain) Is Nothing Then
                    frmMain = Sublight.Program.CreateMainForm()
                End If
                System.Windows.Forms.Application.Run(frmMain)
                flag1 = True
            Catch 
                System.Windows.Forms.Application.Run(Sublight.Program.CreateMainForm())
                flag1 = True
            End Try
            Return flag1
        End Function

        Private Shared Function SwitchToCurrentInstance() As Boolean
            Dim copydatastruct1 As Sublight.MyUtility.Win32.COPYDATASTRUCT

            Dim intPtr1 As System.IntPtr = Sublight.MyUtility.SingleInstance.GetCurrentInstanceWindowHandle()
            If intPtr1 <> System.IntPtr.Zero Then
                Dim sArr1 As String() = System.Environment.GetCommandLineArgs()
                Dim s1 As String = Nothing
                If Not (sArr1) Is Nothing Then
                    Dim i1 As Integer = 0
                    While i1 < sArr1.Length
                        sArr1(i1) = sArr1(i1).Trim()
                        If sArr1(i1).StartsWith("file=?", System.StringComparison.InvariantCultureIgnoreCase) Then
                            s1 = sArr1(i1).Substring(sArr1(i1).IndexOf("="C) + 1)
                            Dim chArr1 As Char() = New char() { ""C }
                            s1 = s1.Trim(chArr1)
                        End If
                        i1 = i1 + 1
                    End While
                End If
                If Not (s1) Is Nothing Then
                    GoTo label_0
                End If
                Dim s2 As String = System.String.Empty
                copydatastruct1 = New Sublight.MyUtility.Win32.COPYDATASTRUCT
                Dim binaryFormatter1 As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream
                    binaryFormatter1.Serialize(memoryStream1, s2)
                    memoryStream1.Flush()
                    Dim i2 As Integer = CInt(memoryStream1.Length)
                    Dim bArr1 As Byte() = New byte(i2) {}
                    memoryStream1.Seek(CLng(0), System.IO.SeekOrigin.Begin)
                    memoryStream1.Read(bArr1, 0, i2)
                    memoryStream1.Close()
                    Dim intPtr2 As System.IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(i2)
                    System.Runtime.InteropServices.Marshal.Copy(bArr1, 0, intPtr2, i2)
                    copydatastruct1.cbData = i2
                    copydatastruct1.dwData = System.IntPtr.Zero
                    copydatastruct1.lpData = intPtr2
                End Using
                Sublight.MyUtility.SingleInstance.SendMessage(intPtr1, 74, System.IntPtr.Zero, ByRef copydatastruct1)
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(copydatastruct1.lpData)
                If Sublight.MyUtility.SingleInstance.IsIconic(intPtr1) <> 0 Then
                    Sublight.MyUtility.SingleInstance.ShowWindow(intPtr1, 9)
                End If
                Sublight.MyUtility.SingleInstance.SetForegroundWindow(intPtr1)
                Return True
            End If
            Return False
        End Function

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function GetWindowThreadProcessId Lib "USER32.DLL" (ByVal hWnd As System.IntPtr, ByRef lpdwProcessId As Integer) As Integer

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function IsIconic Lib "USER32.DLL" (ByVal hWnd As System.IntPtr) As Integer

        <System.Runtime.InteropServices.PreserveSig
        Public Declare Ansi Function SendMessage Lib "USER32.DLL" (ByVal hwnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As System.IntPtr, ByRef lParam As Sublight.MyUtility.Win32.COPYDATASTRUCT) As System.IntPtr

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function SetForegroundWindow Lib "USER32.DLL" (ByVal hWnd As System.IntPtr) As Integer

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function ShowWindow Lib "USER32.DLL" (ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Integer

    End Class ' class SingleInstance

End Namespace

