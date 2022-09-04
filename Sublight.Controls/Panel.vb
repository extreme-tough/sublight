Imports System.Windows.Forms

Namespace Sublight.Controls

    Public Class Panel
        Inherits System.Windows.Forms.Panel

        Public Sub New()
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
        End Sub

    End Class ' class Panel

End Namespace

