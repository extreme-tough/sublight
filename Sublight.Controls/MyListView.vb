Imports System
Imports System.Windows.Forms

Namespace Sublight.Controls

    Public Class MyListView
        Inherits System.Windows.Forms.ListView

        Public Structure LV_ITEM

            Public cchTextMax As Integer 
            Public iImage As Integer 
            Public iItem As Integer 
            Public iSubItem As Integer 
            Public lParam As System.IntPtr 
            Public mask As UInteger 
            Public pszText As String 
            Public state As UInteger 
            Public stateMask As UInteger 

        End Structure

        Public Const LVIF_IMAGE As Integer  = 2
        Public Const LVIF_TEXT As Integer  = 1
        Public Const LVM_FIRST As Integer  = 4096
        Public Const LVM_GETEXTENDEDLISTVIEWSTYLE As Integer  = 4150
        Public Const LVM_GETITEM As Integer  = 4101
        Public Const LVM_SETITEM As Integer  = 4102
        Public Const LVS_EX_CHECKBOXES As Integer  = 4
        Public Const LVS_EX_FULLROWSELECT As Integer  = 32
        Public Const LVS_EX_GRIDLINES As Integer  = 1
        Public Const LVS_EX_HEADERDRAGDROP As Integer  = 16
        Public Const LVS_EX_ONECLICKACTIVATE As Integer  = 64
        Public Const LVS_EX_SUBITEMIMAGES As Integer  = 2
        Public Const LVS_EX_TRACKSELECT As Integer  = 8
        Public Const LVW_FIRST As Integer  = 4096

        Public Sub New()
            Dim message1 As System.Windows.Forms.Message

            message1 = New System.Windows.Forms.Message
            message1.HWnd = Handle
            message1.Msg = 4150
            message1.LParam = CType(47, System.IntPtr)
            message1.WParam = System.IntPtr.Zero
            WndProc(ByRef message1)
        End Sub

        Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
            Dim message1 As System.Windows.Forms.Message

            MyBase.OnHandleCreated(e)
            message1 = New System.Windows.Forms.Message
            message1.HWnd = Handle
            message1.Msg = 4150
            message1.LParam = CType(47, System.IntPtr)
            message1.WParam = System.IntPtr.Zero
            WndProc(ByRef message1)
        End Sub

        <System.Runtime.InteropServices.PreserveSig
        Public Declare Ansi Function SendMessage Lib "user32.dll" (ByVal hWnd As System.IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByRef lParam As Sublight.Controls.MyListView.LV_ITEM) As Boolean

        <System.Runtime.InteropServices.PreserveSig
        Public Declare Ansi Function SendMessage Lib "user32.dll" (ByVal hWnd As System.IntPtr, ByVal Msg As Integer, ByVal wParam As System.IntPtr, ByVal lParam As System.IntPtr) As Integer

    End Class ' class MyListView

End Namespace

