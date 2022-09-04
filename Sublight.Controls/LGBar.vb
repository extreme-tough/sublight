Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace Sublight.Controls

    Public Class LGBar
        Inherits System.Windows.Forms.UserControl

        Private _brush1 As System.Drawing.Brush 
        Private _brush2 As System.Drawing.Brush 
        Private _IsHighlighted As Boolean 
        Private _penBorder As System.Drawing.Pen 
        Private _penBorderHighlight As System.Drawing.Pen 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <Percentage>k__BackingField As Single 
        Private components As System.ComponentModel.IContainer 

        Public Property IsHighlighted As Boolean
            Get
                Return _IsHighlighted
            End Get
            Set
                _IsHighlighted = value
                Invalidate()
            End Set
        End Property

        Public Property Percentage As Single
            Get
                Return <Percentage>k__BackingField
            End Get
            Set
                <Percentage>k__BackingField = value
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            _penBorder = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#32639B?"), 1.0F)
            _penBorderHighlight = New System.Drawing.Pen(System.Drawing.SystemColors.HighlightText)
            InitBrushes()
        End Sub

        Private Sub InitBrushes()
            If Not (_brush1) Is Nothing Then
                _brush1.Dispose()
            End If
            _brush1 = New System.Drawing.Drawing2D.LinearGradientBrush(New System.Drawing.Rectangle(0, 0, 1, Height / 2), System.Drawing.ColorTranslator.FromHtml("#BAC8D5?"), System.Drawing.ColorTranslator.FromHtml("#7B9EC6?"), 90.0F)
            If Not (_brush2) Is Nothing Then
                _brush2.Dispose()
            End If
            _brush2 = New System.Drawing.Drawing2D.LinearGradientBrush(New System.Drawing.Rectangle(0, Height / 2, 1, Height), System.Drawing.ColorTranslator.FromHtml("#6791C1?"), System.Drawing.ColorTranslator.FromHtml("#8DBFF4?"), 90.0F)
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (_brush1) Is Nothing Then
                    _brush1.Dispose()
                    _brush1 = Nothing
                End If
                If Not (_brush2) Is Nothing Then
                    _brush2.Dispose()
                    _brush2 = Nothing
                End If
                If Not (_penBorder) Is Nothing Then
                    _penBorder.Dispose()
                    _penBorder = Nothing
                End If
                If Not (_penBorderHighlight) Is Nothing Then
                    _penBorderHighlight.Dispose()
                    _penBorderHighlight = Nothing
                End If
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Dim i1 As Integer = System.Convert.ToInt32(System.Math.Floor(CDbl((Percentage * CSng((Width - 1))))))
            e.Graphics.Clear(BackColor)
            e.Graphics.FillRectangle(_brush1, 0, 0, i1, Height / 2)
            e.Graphics.FillRectangle(_brush2, 0, Height / 2, i1, Height)
            e.Graphics.DrawRectangle(IIf(IsHighlighted, _penBorderHighlight, _penBorder), 0, 0, i1, Height - 1)
            e.Graphics.DrawRectangle(IIf(IsHighlighted, _penBorderHighlight, _penBorder), 0, 0, Width - 1, Height - 1)
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            InitBrushes()
        End Sub

    End Class ' class LGBar

End Namespace

