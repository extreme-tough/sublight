Imports System.Drawing
Imports System.Windows.Forms

Namespace Sublight.Controls

    Friend Class ToolStripSeparatorCaption
        Inherits System.Windows.Forms.ToolStripMenuItem

        Private _bgBrush As System.Drawing.Brush 
        Private _caption As String 
        Private _font As System.Drawing.Font 
        Private _fontBrush As System.Drawing.Brush 

        Public Sub New(ByVal caption As String)
            _caption = caption
            Enabled = False
            _bgBrush = New System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#EBF2F7?"))
            _fontBrush = New System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#00156E?"))
            _font = New System.Drawing.Font(Font.FontFamily, Font.Size, System.Drawing.FontStyle.Bold)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
            If disposing Then
                If Not (_bgBrush) Is Nothing Then
                    _bgBrush.Dispose()
                    _bgBrush = Nothing
                End If
                If Not (_fontBrush) Is Nothing Then
                    _fontBrush.Dispose()
                    _fontBrush = Nothing
                End If
                If Not (_font) Is Nothing Then
                    _font.Dispose()
                    _font = Nothing
                End If
            End If
        End Sub

        Protected Overrides Sub OnLayout(ByVal e As System.Windows.Forms.LayoutEventArgs)
            MyBase.OnLayout(e)
            If Not (Parent) Is Nothing Then
                Width = Parent.Width
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.FillRectangle(_bgBrush, 0, 0, Width, Height)
            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#CFDBEB?"))
                e.Graphics.DrawLine(pen1, 0, 0, Width, 0)
                e.Graphics.DrawLine(pen1, 0, Height - 2, Width, Height - 2)
            End Using
            e.Graphics.DrawLine(System.Drawing.Pens.White, 0, 1, Width, 1)
            e.Graphics.DrawLine(System.Drawing.Pens.White, 0, Height - 1, Width, Height - 1)
            e.Graphics.DrawString(_caption, _font, _fontBrush, 5.0F, 2.0F)
        End Sub

    End Class ' class ToolStripSeparatorCaption

End Namespace

