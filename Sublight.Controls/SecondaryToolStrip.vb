Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Sublight.Controls

    Friend Class SecondaryToolStrip
        Inherits System.Windows.Forms.ToolStrip

        Public Sub New()
        End Sub

        Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
            If (Height <= 0) OrElse (Width <= 0) Then
                Return
            End If
            Using linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, System.Drawing.ColorTranslator.FromHtml("#FDFDFD?"), System.Drawing.ColorTranslator.FromHtml("#E5E9EE?"), System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(linearGradientBrush1, 0, 0, Width, Height)
            End Using
        End Sub

    End Class ' class SecondaryToolStrip

End Namespace

