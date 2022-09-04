Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Sublight.Controls

    Friend Class UOLItem
        Inherits System.Windows.Forms.UserControl

        Private _items As String() 

        Public Property Items As String()
            Get
                Return _items
            End Get
            Set
                _items = value
            End Set
        End Property

        Public Sub New()
        End Sub

        Private Sub InitializeComponent()
            SuspendLayout()
            BackColor = System.Drawing.Color.FromArgb(255, 255, 225)
            Name = "UOLItem?"
            Size = New System.Drawing.Size(426, 150)
            ResumeLayout(False)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            If (_items) Is Nothing Then
                Return
            End If
            Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString("ABC?", Font)
            Dim padding1 As System.Windows.Forms.Padding = Padding
            Dim i1 As Integer = padding1.Top
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(ForeColor)
                Dim i2 As Integer = 0
                While i2 < _items.Length
                    Dim s1 As String = _items(i2)
                    Dim sizeF2 As System.Drawing.SizeF = e.Graphics.MeasureString(s1, Font, Width - 10)
                    If i2 > 0 Then
                        Dim padding2 As System.Windows.Forms.Padding = Padding
                        e.Graphics.FillRectangle(solidBrush1, CSng((padding2.Left + 5 + 5)), CSng(i1) + (sizeF1.Height / 2.0F) - CSng(System.Convert.ToInt32(2)), 5.0F, 5.0F)
                        Dim padding3 As System.Windows.Forms.Padding = Padding
                        Dim padding4 As System.Windows.Forms.Padding = Padding
                        Dim padding5 As System.Windows.Forms.Padding = Padding
                        e.Graphics.DrawString(s1, Font, solidBrush1, New System.Drawing.RectangleF(CSng((padding3.Left + 5 + 10 + 5)), CSng(i1), CSng((Width - (20 + padding4.Left + padding5.Right))), sizeF2.Height))
                    Else 
                        Dim padding6 As System.Windows.Forms.Padding = Padding
                        Dim padding7 As System.Windows.Forms.Padding = Padding
                        Dim padding8 As System.Windows.Forms.Padding = Padding
                        e.Graphics.DrawString(s1, Font, solidBrush1, New System.Drawing.RectangleF(CSng(padding6.Left), CSng(i1), CSng((Width - padding7.Left - padding8.Right)), sizeF2.Height))
                    End If
                    i1 = System.Convert.ToInt32(System.Math.Ceiling(CDbl((CSng(i1) + sizeF2.Height)))) + 3
                    i2 = i2 + 1
                End While
                Dim padding9 As System.Windows.Forms.Padding = Padding
                i1 = i1 + padding9.Bottom
                If Height <> i1 Then
                    Height = i1
                End If
            End Using
            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(ForeColor)
                e.Graphics.DrawRectangle(pen1, 0, 0, Width - 1, Height - 1)
            End Using
        End Sub

    End Class ' class UOLItem

End Namespace

