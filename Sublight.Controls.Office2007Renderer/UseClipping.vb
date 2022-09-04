Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace Sublight.Controls.Office2007Renderer

    Public Class UseClipping
        Implements System.IDisposable

        Private ReadOnly _g As System.Drawing.Graphics 
        Private ReadOnly _old As System.Drawing.Region 

        Public Sub New(ByVal g As System.Drawing.Graphics, ByVal path As System.Drawing.Drawing2D.GraphicsPath)
            _g = g
            _old = g.Clip
            Dim region1 As System.Drawing.Region = _old.Clone()
            region1.Intersect(path)
            _g.Clip = region1
        End Sub

        Public Sub New(ByVal g As System.Drawing.Graphics, ByVal region As System.Drawing.Region)
            _g = g
            _old = g.Clip
            Dim region1 As System.Drawing.Region = _old.Clone()
            region1.Intersect(region)
            _g.Clip = region1
        End Sub

        Public Sub Dispose()
            _g.Clip = _old
        End Sub

    End Class ' class UseClipping

End Namespace

