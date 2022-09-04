Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace VistaStyleProgressBar

    <System.ComponentModel.DefaultEvent("ValueChanged")> _
    Public Class ProgressBar
        Inherits System.Windows.Forms.UserControl

        Public Delegate Sub MaxChangedHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Delegate Sub MinChangedHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Delegate Sub ValueChangedHandler(ByVal sender As Object, ByVal e As System.EventArgs)

        Private _font As System.Drawing.Font 
        Private _textBrush As System.Drawing.Brush 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <Text>k__BackingField As String 
        Private components As System.ComponentModel.Container 
        Private mAnimate As Boolean 

        Private mBackgroundColor As System.Drawing.Color 
        Private mEndColor As System.Drawing.Color 
        Private mGlowAnimation As System.Windows.Forms.Timer 
        Private mGlowColor As System.Drawing.Color 
        Private mGlowPosition As Integer 
        Private mHighlightColor As System.Drawing.Color 

        Private mMaxValue As Integer 
        Private mMinValue As Integer 
        Private mStartColor As System.Drawing.Color 
        Private mValue As Integer 

        Public Event MaxChanged As VistaStyleProgressBar.ProgressBar.MaxChangedHandler
        Public Event MinChanged As VistaStyleProgressBar.ProgressBar.MinChangedHandler
        Public Event ValueChanged As VistaStyleProgressBar.ProgressBar.ValueChangedHandler

        <System.ComponentModel.Description("Whether the glow is animated or not."), _
        System.ComponentModel.Category("Highlights and Glows"), _
        System.ComponentModel.DefaultValue(GetType(System.Boolean), "true")> _
        Public Property Animate As Boolean
            Get
                Return mAnimate
            End Get
            Set
                mAnimate = value
                If value Then
                    mGlowAnimation.Start()
                Else 
                    mGlowAnimation.Stop()
                End If
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.DefaultValue(GetType(System.Drawing.Color), "201,201,201"), _
        System.ComponentModel.Description("The color of the background."), _
        System.ComponentModel.Category("Highlights and Glows")> _
        Public Property BackgroundColor As System.Drawing.Color
            Get
                Return mBackgroundColor
            End Get
            Set
                mBackgroundColor = value
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.Description("The end color for the progress bar.210, 000, 000 = Red
210, 202, 000 = Yellow
000, 163, 211 = Blue
000, 211, 040 = Green
"), _
        System.ComponentModel.Category("Bar"), _
        System.ComponentModel.DefaultValue(GetType(System.Drawing.Color), "0, 211, 40")> _
        Public Property EndColor As System.Drawing.Color
            Get
                Return mEndColor
            End Get
            Set
                mEndColor = value
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.Description("The color of the glow."), _
        System.ComponentModel.DefaultValue(GetType(System.Drawing.Color), "150, 255, 255, 255"), _
        System.ComponentModel.Category("Highlights and Glows")> _
        Public Property GlowColor As System.Drawing.Color
            Get
                Return mGlowColor
            End Get
            Set
                mGlowColor = value
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.Category("Highlights and Glows"), _
        System.ComponentModel.DefaultValue(GetType(System.Drawing.Color), "White"), _
        System.ComponentModel.Description("The color of the highlights.")> _
        Public Property HighlightColor As System.Drawing.Color
            Get
                Return mHighlightColor
            End Get
            Set
                mHighlightColor = value
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.Description("The maximum value for the Value property."), _
        System.ComponentModel.Category("Value"), _
        System.ComponentModel.DefaultValue(100)> _
        Public Property MaxValue As Integer
            Get
                Return mMaxValue
            End Get
            Set
                mMaxValue = value
                If value > MaxValue Then
                    Value = MaxValue
                End If
                If Value < MaxValue Then
                    mGlowAnimation.Start()
                End If
                Dim maxChangedHandler1 As VistaStyleProgressBar.ProgressBar.MaxChangedHandler = MaxChanged
                If Not (maxChangedHandler1) Is Nothing Then
                    RaiseEvent maxChangedHandler1(Me, New System.EventArgs)
                End If
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.Description("The minimum value for the Value property."), _
        System.ComponentModel.Category("Value"), _
        System.ComponentModel.DefaultValue(0)> _
        Public Property MinValue As Integer
            Get
                Return mMinValue
            End Get
            Set
                mMinValue = value
                If value < MinValue Then
                    Value = MinValue
                End If
                Dim minChangedHandler1 As VistaStyleProgressBar.ProgressBar.MinChangedHandler = MinChanged
                If Not (minChangedHandler1) Is Nothing Then
                    RaiseEvent minChangedHandler1(Me, New System.EventArgs)
                End If
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.Category("Bar"), _
        System.ComponentModel.Description("The start color for the progress bar.210, 000, 000 = Red
210, 202, 000 = Yellow
000, 163, 211 = Blue
000, 211, 040 = Green
"), _
        System.ComponentModel.DefaultValue(GetType(System.Drawing.Color), "210, 0, 0")> _
        Public Property StartColor As System.Drawing.Color
            Get
                Return mStartColor
            End Get
            Set
                mStartColor = value
                Invalidate()
            End Set
        End Property

        Public Shadows Property Text As String
            Get
                Return <Text>k__BackingField
            End Get
            Set
                <Text>k__BackingField = value
            End Set
        End Property

        <System.ComponentModel.Category("Value"), _
        System.ComponentModel.Description("The value that is displayed on the progress bar."), _
        System.ComponentModel.DefaultValue(0)> _
        Public Property Value As Integer
            Get
                Return mValue
            End Get
            Set
                If (value > MaxValue) OrElse (value < MinValue) Then
                    Return
                End If
                mValue = value
                If value < MaxValue Then
                    mGlowAnimation.Start()
                End If
                If value = MaxValue Then
                    mGlowAnimation.Stop()
                End If
                Dim valueChangedHandler1 As VistaStyleProgressBar.ProgressBar.ValueChangedHandler = ValueChanged
                If Not (valueChangedHandler1) Is Nothing Then
                    RaiseEvent valueChangedHandler1(Me, New System.EventArgs)
                End If
                Invalidate()
            End Set
        End Property

        Public Sub New()
            mGlowPosition = -325
            mGlowAnimation = New System.Windows.Forms.Timer
            mMaxValue = 100
            mStartColor = System.Drawing.Color.FromArgb(210, 0, 0)
            mEndColor = System.Drawing.Color.FromArgb(0, 211, 40)
            mHighlightColor = System.Drawing.Color.White
            mBackgroundColor = System.Drawing.Color.FromArgb(201, 201, 201)
            mAnimate = True
            mGlowColor = System.Drawing.Color.FromArgb(150, 255, 255, 255)
            _font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            _textBrush = New System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#0F1628?"))
            InitializeComponent()
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, True)
            SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, True)
            SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, True)
            SetStyle(System.Windows.Forms.ControlStyles.Selectable, True)
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, True)
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint, True)
            BackColor = System.Drawing.Color.Transparent
            If Not VistaStyleProgressBar.ProgressBar.InDesignMode() Then
                AddHandler mGlowAnimation.Tick, AddressOf mGlowAnimation_Tick
                mGlowAnimation.Interval = 15
                If Value < MaxValue Then
                    mGlowAnimation.Start()
                End If
            End If
        End Sub

        Private Sub DrawBackground(ByVal g As System.Drawing.Graphics)
            Dim rectangle1 As System.Drawing.Rectangle = ClientRectangle
            rectangle1.Width = rectangle1.Width - 1
            rectangle1.Height = rectangle1.Height - 1
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = VistaStyleProgressBar.ProgressBar.RoundRect(rectangle1, 2.0F, 2.0F, 2.0F, 2.0F)
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(BackgroundColor)
                g.FillPath(solidBrush1, graphicsPath1)
            End Using
            graphicsPath1.Dispose()
        End Sub

        Private Sub DrawBackgroundShadows(ByVal g As System.Drawing.Graphics)
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(2, 2, 10, Height - 5)
            Dim linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle1, System.Drawing.Color.FromArgb(30, 0, 0, 0), System.Drawing.Color.Transparent, System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            rectangle1.X = rectangle1.X - 1
            g.FillRectangle(linearGradientBrush1, rectangle1)
            linearGradientBrush1.Dispose()
            Dim rectangle2 As System.Drawing.Rectangle = New System.Drawing.Rectangle(Width - 12, 2, 10, Height - 5)
            Dim linearGradientBrush2 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle2, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(20, 0, 0, 0), System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            g.FillRectangle(linearGradientBrush2, rectangle2)
            linearGradientBrush2.Dispose()
        End Sub

        Private Sub DrawBar(ByVal g As System.Drawing.Graphics)
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(1, 2, Width - 3, Height - 3)
            rectangle1.Width = CInt((CSng(Value) * 1.0F / CSng((MaxValue - MinValue)) * CSng(Width)))
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(GetIntermediateColor())
                g.FillRectangle(solidBrush1, rectangle1)
            End Using
        End Sub

        Private Sub DrawBarShadows(ByVal g As System.Drawing.Graphics)
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(1, 2, 15, Height - 3)
            Dim linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle1, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Dim colorBlend1 As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend(3)
            Dim colorArr1 As System.Drawing.Color() = New System.Drawing.Color(3) {}
            colorArr1(0) = System.Drawing.Color.Transparent
            colorArr1(1) = System.Drawing.Color.FromArgb(40, 0, 0, 0)
            colorArr1(2) = System.Drawing.Color.Transparent
            colorBlend1.Colors = colorArr1
            Dim fArr1 As Single() = New float(3) {}
            fArr1(1) = 0.2F
            fArr1(2) = 1.0F
            colorBlend1.Positions = fArr1
            linearGradientBrush1.InterpolationColors = colorBlend1
            rectangle1.X = rectangle1.X - 1
            g.FillRectangle(linearGradientBrush1, rectangle1)
            linearGradientBrush1.Dispose()
            Dim rectangle2 As System.Drawing.Rectangle = New System.Drawing.Rectangle(Width - 3, 2, 15, Height - 3)
            rectangle2.X = CInt((CSng(Value) * 1.0F / CSng((MaxValue - MinValue)) * CSng(Width))) - 14
            Dim linearGradientBrush2 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle2, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Dim colorBlend2 As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend(3)
            Dim colorArr2 As System.Drawing.Color() = New System.Drawing.Color(3) {}
            colorArr2(0) = System.Drawing.Color.Transparent
            colorArr2(1) = System.Drawing.Color.FromArgb(40, 0, 0, 0)
            colorArr2(2) = System.Drawing.Color.Transparent
            colorBlend2.Colors = colorArr2
            Dim fArr2 As Single() = New float(3) {}
            fArr2(1) = 0.8F
            fArr2(2) = 1.0F
            colorBlend2.Positions = fArr2
            linearGradientBrush2.InterpolationColors = colorBlend2
            g.FillRectangle(linearGradientBrush2, rectangle2)
            linearGradientBrush2.Dispose()
        End Sub

        Private Sub DrawGlow(ByVal g As System.Drawing.Graphics)
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(mGlowPosition, 0, 60, Height)
            Dim linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle1, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Dim colorBlend1 As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend(4)
            Dim colorArr1 As System.Drawing.Color() = New System.Drawing.Color(4) {}
            colorArr1(0) = System.Drawing.Color.Transparent
            colorArr1(1) = GlowColor
            colorArr1(2) = GlowColor
            colorArr1(3) = System.Drawing.Color.Transparent
            colorBlend1.Colors = colorArr1
            colorBlend1.Positions = New float() { 0.0F, 0.5F, 0.6F, 1.0F }
            linearGradientBrush1.InterpolationColors = colorBlend1
            Dim rectangle2 As System.Drawing.Rectangle = New System.Drawing.Rectangle(1, 2, Width - 3, Height - 3)
            rectangle2.Width = CInt((CSng(Value) * 1.0F / CSng((MaxValue - MinValue)) * CSng(Width)))
            g.SetClip(rectangle2)
            g.FillRectangle(linearGradientBrush1, rectangle1)
            g.ResetClip()
            linearGradientBrush1.Dispose()
        End Sub

        Private Sub DrawHighlight(ByVal g As System.Drawing.Graphics)
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(1, 1, Width - 1, 6)
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = VistaStyleProgressBar.ProgressBar.RoundRect(rectangle1, 2.0F, 2.0F, 0.0F, 0.0F)
            g.SetClip(graphicsPath1)
            Dim linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle1, System.Drawing.Color.White, System.Drawing.Color.FromArgb(128, System.Drawing.Color.White), System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            g.FillPath(linearGradientBrush1, graphicsPath1)
            linearGradientBrush1.Dispose()
            g.ResetClip()
            Dim rectangle2 As System.Drawing.Rectangle = New System.Drawing.Rectangle(1, Height - 8, Width - 1, 6)
            Dim graphicsPath2 As System.Drawing.Drawing2D.GraphicsPath = VistaStyleProgressBar.ProgressBar.RoundRect(rectangle2, 0.0F, 0.0F, 2.0F, 2.0F)
            g.SetClip(graphicsPath2)
            Dim linearGradientBrush2 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle2, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(100, HighlightColor), System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            g.FillPath(linearGradientBrush2, graphicsPath2)
            g.ResetClip()
            graphicsPath2.Dispose()
            linearGradientBrush2.Dispose()
            graphicsPath1.Dispose()
            graphicsPath2.Dispose()
        End Sub

        Private Sub DrawInnerStroke(ByVal g As System.Drawing.Graphics)
            Dim rectangle1 As System.Drawing.Rectangle = ClientRectangle
            rectangle1.X = rectangle1.X + 1
            rectangle1.Y = rectangle1.Y + 1
            rectangle1.Width = rectangle1.Width - 3
            rectangle1.Height = rectangle1.Height - 3
            Using graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = VistaStyleProgressBar.ProgressBar.RoundRect(rectangle1, 2.0F, 2.0F, 2.0F, 2.0F)
                Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.FromArgb(100, System.Drawing.Color.White))
                    g.DrawPath(pen1, graphicsPath1)
                End Using
            End Using
        End Sub

        Private Sub DrawOuterStroke(ByVal g As System.Drawing.Graphics)
            Dim rectangle1 As System.Drawing.Rectangle = ClientRectangle
            rectangle1.Width = rectangle1.Width - 1
            rectangle1.Height = rectangle1.Height - 1
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = VistaStyleProgressBar.ProgressBar.RoundRect(rectangle1, 2.0F, 2.0F, 2.0F, 2.0F)
            Dim pen1 As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.FromArgb(178, 178, 178))
            g.DrawPath(pen1, graphicsPath1)
            graphicsPath1.Dispose()
            pen1.Dispose()
        End Sub

        Private Sub DrawText(ByVal g As System.Drawing.Graphics)
        End Sub

        Private Function GetIntermediateColor() As System.Drawing.Color
            Dim color1 As System.Drawing.Color = StartColor
            Dim color2 As System.Drawing.Color = EndColor
            Dim f1 As Single = CSng(Value) * 1.0F / CSng((MaxValue - MinValue))
            Dim i1 As Integer = color1.A
            Dim i2 As Integer = color1.R
            Dim i3 As Integer = color1.G
            Dim i4 As Integer = color1.B
            Dim i5 As Integer = color2.A
            Dim i6 As Integer = color2.R
            Dim i7 As Integer = color2.G
            Dim i8 As Integer = color2.B
            Dim i9 As Integer = CInt(System.Math.Abs(CSng(i1) + (CSng((i1 - i5)) * f1)))
            Dim i10 As Integer = CInt(System.Math.Abs(CSng(i2) - (CSng((i2 - i6)) * f1)))
            Dim i11 As Integer = CInt(System.Math.Abs(CSng(i3) - (CSng((i3 - i7)) * f1)))
            Dim i12 As Integer = CInt(System.Math.Abs(CSng(i4) - (CSng((i4 - i8)) * f1)))
            If i9 > 255 Then
                i9 = 255
            End If
            If i10 > 255 Then
                i10 = 255
            End If
            If i11 > 255 Then
                i11 = 255
            End If
            If i12 > 255 Then
                i12 = 255
            End If
            Return System.Drawing.Color.FromArgb(i9, i10, i11, i12)
        End Function

        Private Sub InitializeComponent()
            Name = "ProgressBar?"
            Size = New System.Drawing.Size(264, 32)
        End Sub

        Private Sub mGlowAnimation_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            If Animate Then
                mGlowPosition = mGlowPosition + 4
                If mGlowPosition > Width Then
                    mGlowPosition = -300
                End If
                Invalidate()
                Return
            End If
            mGlowAnimation.Stop()
            mGlowPosition = -320
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components) Is Nothing Then
                    components.Dispose()
                End If
                If Not (_font) Is Nothing Then
                    _font.Dispose()
                    _font = Nothing
                End If
                If Not (_textBrush) Is Nothing Then
                    _textBrush.Dispose()
                    _textBrush = Nothing
                End If
            End If
            If Not (mGlowAnimation) Is Nothing Then
                mGlowAnimation.Stop()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            DrawBackground(e.Graphics)
            DrawBackgroundShadows(e.Graphics)
            DrawBar(e.Graphics)
            DrawBarShadows(e.Graphics)
            DrawHighlight(e.Graphics)
            DrawInnerStroke(e.Graphics)
            DrawGlow(e.Graphics)
            DrawOuterStroke(e.Graphics)
            DrawText(e.Graphics)
        End Sub

        Private Shared Function InDesignMode() As Boolean
            Return System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime
        End Function

        Private Shared Function RoundRect(ByVal r As System.Drawing.RectangleF, ByVal r1 As Single, ByVal r2 As Single, ByVal r3 As Single, ByVal r4 As Single) As System.Drawing.Drawing2D.GraphicsPath
            Dim f1 As Single = r.X
            Dim f2 As Single = r.Y
            Dim f3 As Single = r.Width
            Dim f4 As Single = r.Height
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
            graphicsPath1.AddBezier(f1, f2 + r1, f1, f2, f1 + r1, f2, f1 + r1, f2)
            graphicsPath1.AddLine(f1 + r1, f2, f1 + f3 - r2, f2)
            graphicsPath1.AddBezier(f1 + f3 - r2, f2, f1 + f3, f2, f1 + f3, f2 + r2, f1 + f3, f2 + r2)
            graphicsPath1.AddLine(f1 + f3, f2 + r2, f1 + f3, f2 + f4 - r3)
            graphicsPath1.AddBezier(f1 + f3, f2 + f4 - r3, f1 + f3, f2 + f4, f1 + f3 - r3, f2 + f4, f1 + f3 - r3, f2 + f4)
            graphicsPath1.AddLine(f1 + f3 - r3, f2 + f4, f1 + r4, f2 + f4)
            graphicsPath1.AddBezier(f1 + r4, f2 + f4, f1, f2 + f4, f1, f2 + f4 - r4, f1, f2 + f4 - r4)
            graphicsPath1.AddLine(f1, f2 + f4 - r4, f1, f2 + r1)
            Return graphicsPath1
        End Function

    End Class ' class ProgressBar

End Namespace

