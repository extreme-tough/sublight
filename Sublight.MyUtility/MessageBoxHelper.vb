Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace Sublight.MyUtility

    Friend MustInherit NotInheritable Class MessageBoxHelper

        Private Class MessageBoxCenterHelper

            Private _messageHook As Integer 
            Private _parentFormHandle As System.IntPtr 

            Public Sub New()
            End Sub

            Private Function CenterMessageCallBack(ByVal message As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
                Dim rect1 As Sublight.MyUtility.MessageBoxHelper.NativeMethods.RECT, rect2 As Sublight.MyUtility.MessageBoxHelper.NativeMethods.RECT

                If message = 5 Then
                    Sublight.MyUtility.MessageBoxHelper.NativeMethods.GetWindowRect(_parentFormHandle, out rect1)
                    Sublight.MyUtility.MessageBoxHelper.NativeMethods.GetWindowRect(New System.IntPtr(wParam), out rect2)
                    Dim i1 As Integer = rect1.Left + ((rect1.Right - rect1.Left) / 2) - ((rect2.Right - rect2.Left) / 2)
                    Dim i2 As Integer = rect1.Top + ((rect1.Bottom - rect1.Top) / 2) - ((rect2.Bottom - rect2.Top) / 2)
                    Sublight.MyUtility.MessageBoxHelper.NativeMethods.SetWindowPos(wParam, 0, i1, i2, 0, 0, 21)
                    Sublight.MyUtility.MessageBoxHelper.NativeMethods.UnhookWindowsHookEx(_messageHook)
                End If
                Return 0
            End Function

            Public Sub Prep(ByVal form As System.Windows.Forms.IWin32Window)
                Dim centerMessageCallBackDelegate1 As Sublight.MyUtility.MessageBoxHelper.NativeMethods.CenterMessageCallBackDelegate = New Sublight.MyUtility.MessageBoxHelper.NativeMethods.CenterMessageCallBackDelegate(CenterMessageCallBack)
                System.Runtime.InteropServices.GCHandle.Alloc(centerMessageCallBackDelegate1)
                _parentFormHandle = form.Handle
                Dim intPtr1 As System.IntPtr = Sublight.MyUtility.MessageBoxHelper.NativeMethods.SetWindowsHookEx(5, centerMessageCallBackDelegate1, New System.IntPtr(Sublight.MyUtility.MessageBoxHelper.NativeMethods.GetWindowLong(_parentFormHandle, -6)), Sublight.MyUtility.MessageBoxHelper.NativeMethods.GetCurrentThreadId())
                _messageHook = intPtr1.ToInt32()
            End Sub

        End Class ' class MessageBoxCenterHelper

        Private MustInherit NotInheritable Class NativeMethods

            Friend Delegate Function CenterMessageCallBackDelegate(ByVal message As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

            Friend Structure RECT

                Public Bottom As Integer 
                Public Left As Integer 
                Public Right As Integer 
                Public Top As Integer 

            End Structure

            <System.Runtime.InteropServices.PreserveSig
            Friend Declare Ansi Function GetCurrentThreadId Lib "kernel32.dll" () As Integer

            <System.Runtime.InteropServices.PreserveSig
            Friend Declare Ansi Function GetWindowLong Lib "user32.dll" (ByVal hWnd As System.IntPtr, ByVal nIndex As Integer) As Integer

            <System.Runtime.InteropServices.PreserveSig
            <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
            Friend Declare Ansi Function GetWindowRect Lib "user32.dll" (ByVal hWnd As System.IntPtr, ByRef lpRect As Sublight.MyUtility.MessageBoxHelper.NativeMethods.RECT) As Boolean

            <System.Runtime.InteropServices.PreserveSig
            <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
            Friend Declare Ansi Function SetWindowPos Lib "user32.dll" (ByVal hWnd As Integer, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Integer) As Boolean

            <System.Runtime.InteropServices.PreserveSig
            Friend Declare Ansi Function SetWindowsHookEx Lib "user32.dll" (ByVal hook As Integer, ByVal callback As Sublight.MyUtility.MessageBoxHelper.NativeMethods.CenterMessageCallBackDelegate, ByVal hMod As System.IntPtr, ByVal dwThreadId As Integer) As System.IntPtr

            <System.Runtime.InteropServices.PreserveSig
            <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
            Friend Declare Ansi Function UnhookWindowsHookEx Lib "user32.dll" (ByVal hhk As Integer) As Boolean

        End Class ' class NativeMethods

        Friend Shared Sub PrepToCenterMessageBoxOnForm(ByVal form As System.Windows.Forms.Form)
            If ((form) Is Nothing) OrElse form.IsDisposed Then
                Return
            End If
            Dim messageBoxCenterHelper1 As Sublight.MyUtility.MessageBoxHelper.MessageBoxCenterHelper = New Sublight.MyUtility.MessageBoxHelper.MessageBoxCenterHelper
            messageBoxCenterHelper1.Prep(form)
        End Sub

    End Class ' class MessageBoxHelper

End Namespace

