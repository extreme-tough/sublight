Imports System
Imports System.Drawing
Imports System.Drawing.Text

Namespace Sublight.Controls.Office2007Renderer

    Public Class UseClearTypeGridFit
        Implements System.IDisposable

        Private ReadOnly _g As System.Drawing.Graphics 
        Private ReadOnly _old As System.Drawing.Text.TextRenderingHint 

        Public Sub New(ByVal g As System.Drawing.Graphics)
            _g = g
            _old = _g.TextRenderingHint
            _g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        End Sub

        Public Sub Dispose()
            _g.TextRenderingHint = _old
        End Sub

    End Class ' class UseClearTypeGridFit

End Namespace

