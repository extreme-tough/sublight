Imports System.Windows.Forms

Namespace Sublight.Controls

    Public Class MyPanel
        Inherits System.Windows.Forms.Panel

        Public Sub New()
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.DoubleBuffer Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
        End Sub

    End Class ' class MyPanel

End Namespace

