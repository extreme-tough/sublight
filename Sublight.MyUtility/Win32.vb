Namespace Sublight.MyUtility

    Friend MustInherit Class Win32

        Public Structure COPYDATASTRUCT

            Public cbData As Integer 
            Public dwData As System.IntPtr 
            Public lpData As System.IntPtr 

        End Structure

        Public Structure FLASHWINFO

            Public cbSize As UInteger 
            Public dwFlags As UInteger 
            Public dwTimeout As UInteger 
            Public hwnd As System.IntPtr 
            Public uCount As UInteger 

        End Structure

        Public Const FLASHW_ALL As UInteger  = 3UI
        Public Const FLASHW_TIMERNOFG As UInteger  = 12UI
        Public Const WM_COPYDATA As Integer  = 74

        Protected Sub New()
        End Sub

        <System.Runtime.InteropServices.PreserveSig
        <return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)> _
        Friend Declare Ansi Function FlashWindowEx Lib "user32.dll" (ByRef pwfi As Sublight.MyUtility.Win32.FLASHWINFO) As Boolean

    End Class ' class Win32

End Namespace

