Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace Sublight.Controls.Office2007Renderer

    Public Class UseAntiAlias
        Implements System.IDisposable

        Private ReadOnly _g As System.Drawing.Graphics 
        Private ReadOnly _old As System.Drawing.Drawing2D.SmoothingMode 

        Public Sub New(ByVal g As System.Drawing.Graphics)
            _g = g
            _old = _g.SmoothingMode
            _g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        End Sub

        Public Sub Dispose()
            _g.SmoothingMode = _old
        End Sub

    End Class ' class UseAntiAlias

End Namespace

