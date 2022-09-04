Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight

Namespace Sublight.Controls

    Public Class MyGroupBox
        Inherits System.Windows.Forms.GroupBox

        Private brushBg As System.Drawing.Brush 
        Private brushLight As System.Drawing.Brush 
        Private brushLight2 As System.Drawing.Brush 
        Private m_DrawTextBackground As Boolean 
        Private m_Font As System.Drawing.Font 
        Private m_FontBrush As System.Drawing.Brush 
        Private penLight As System.Drawing.Pen 

        Private Shared m_LightBackground As System.Drawing.Color 

        Public Property DrawTextBackground As Boolean
            Get
                Return m_DrawTextBackground
            End Get
            Set
                m_DrawTextBackground = value
            End Set
        End Property

        Public Sub New()
            penLight = New System.Drawing.Pen(Sublight.Globals.ColorGroupBoxLine)
            m_Font = New System.Drawing.Font("Segoe UI?", 9.0F, System.Drawing.FontStyle.Bold)
            m_FontBrush = New System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#00156E?"))
            brushBg = New System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#BFDBFF?"))
            brushLight = New System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#6593CF?"))
            brushLight2 = New System.Drawing.SolidBrush(Sublight.Controls.MyGroupBox.m_LightBackground)
            m_DrawTextBackground = True
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.DoubleBuffer Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
        End Sub

        Shared Sub New()
            Sublight.Controls.MyGroupBox.m_LightBackground = System.Drawing.ColorTranslator.FromHtml("#E1EEFF?")
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
            If disposing Then
                If Not (m_Font) Is Nothing Then
                    m_Font.Dispose()
                    m_Font = Nothing
                End If
                If Not (penLight) Is Nothing Then
                    penLight.Dispose()
                    penLight = Nothing
                End If
                If Not (m_FontBrush) Is Nothing Then
                    m_FontBrush.Dispose()
                    m_FontBrush = Nothing
                End If
                If Not (brushBg) Is Nothing Then
                    brushBg.Dispose()
                    brushBg = Nothing
                End If
                If Not (brushLight) Is Nothing Then
                    brushLight.Dispose()
                    brushLight = Nothing
                End If
                If Not (brushLight2) Is Nothing Then
                    brushLight2.Dispose()
                    brushLight2 = Nothing
                End If
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim graphics1 As System.Drawing.Graphics = e.Graphics
            Dim size1 As System.Drawing.Size = System.Drawing.Size.Ceiling(graphics1.MeasureString(Text, m_Font))
            Dim i1 As Integer = size1.Width
            Dim i2 As Integer = Width
            Dim i3 As Integer = size1.Height / 2
            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#CFDBEB?"))
                e.Graphics.DrawLine(pen1, i1, i3, i2, i3)
            End Using
            e.Graphics.DrawLine(System.Drawing.Pens.White, i1, i3 + 1, i2, i3 + 1)
            Dim i4 As Integer = 0
            graphics1.DrawString(Text, m_Font, m_FontBrush, CSng(i4), 0.0F)
        End Sub

    End Class ' class MyGroupBox

End Namespace

