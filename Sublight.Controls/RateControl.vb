Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace Sublight.Controls

    Public Class RateControl
        Inherits System.Windows.Forms.UserControl

        Public Delegate Sub RateClickedHandler(ByVal sender As Object, ByVal e As Sublight.Controls.RateControl.RateArgs)

        Public Class RateArgs
            Inherits System.EventArgs

            Private ReadOnly m_Rate As Double 

            Public ReadOnly Property Rate As Double
                Get
                    Return m_Rate
                End Get
            End Property

            Friend Sub New(ByVal rate As Double)
                m_Rate = rate
            End Sub

        End Class ' class RateArgs

        Private ReadOnly m_StarOutOff As System.Drawing.Bitmap 
        Private ReadOnly m_StarOutOn As System.Drawing.Bitmap 
        Private ReadOnly m_StarOverOff As System.Drawing.Bitmap 
        Private ReadOnly m_StarOverOn As System.Drawing.Bitmap 

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <DescriptionString>k__BackingField As String 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <EnableRating>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <RateNA>k__BackingField As String 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private m_CurrentX As Integer 
        Private m_Rate As Double 

        Public Event RateClicked As Sublight.Controls.RateControl.RateClickedHandler

        Private Property DescriptionString As String
            Get
                Return <DescriptionString>k__BackingField
            End Get
            Set
                <DescriptionString>k__BackingField = value
            End Set
        End Property

        Public Property EnableRating As Boolean
            Get
                Return <EnableRating>k__BackingField
            End Get
            Set
                <EnableRating>k__BackingField = value
            End Set
        End Property

        Public Property Rate As Double
            Get
                Return m_Rate
            End Get
            Set
                m_Rate = value
                SetDescription()
            End Set
        End Property

        Public Property RateNA As String
            Get
                Return <RateNA>k__BackingField
            End Get
            Set
                <RateNA>k__BackingField = value
            End Set
        End Property

        Private ReadOnly Property UserRate As Integer
            Get
                If m_CurrentX >= 0 Then
                    Return System.Convert.ToInt32(System.Math.Floor(CDbl(((CSng(m_CurrentX) / 13.0F) + 1.0F))))
                End If
                Return -1
            End Get
        End Property

        Public Sub New()
            m_CurrentX = -1
            InitializeComponent()
            EnableRating = True
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.DoubleBuffer Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
            Dim resourceManager1 As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Sublight.Controls.RateControl).FullName, GetType(Sublight.Controls.RateControl).Assembly)
            m_StarOutOn = TryCast(resourceManager1.GetObject("StarOutOn?"), System.Drawing.Bitmap)
            m_StarOutOff = TryCast(resourceManager1.GetObject("StarOutOff?"), System.Drawing.Bitmap)
            m_StarOverOn = TryCast(resourceManager1.GetObject("StarOverOn?"), System.Drawing.Bitmap)
            m_StarOverOff = TryCast(resourceManager1.GetObject("StarOverOff?"), System.Drawing.Bitmap)
            DescriptionString = "({0})?"
            label1.Top = System.Convert.ToInt32((CSng(m_StarOutOn.Height) / 2.0F) - (CSng(label1.Height) / 2.0F))
            SetDescription()
        End Sub

        Private Sub InitializeComponent()
            label1 = New System.Windows.Forms.Label
            SuspendLayout()
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(70, 0)
            label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(35, 13)
            label1.TabIndex = 0
            label1.Text = "label1?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(label1)
            Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F)
            Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Name = "RateControl?"
            Size = New System.Drawing.Size(165, 11)
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub SetDescription()
            If UserRate >= 0 Then
                GoTo label_0
            End If
            Dim d1 As Double = Rate
            Dim i1 As Integer = UserRate
            DescriptionString.Text = System.String.Format(d1.ToString("N2?"), IIf(Rate > 0.0R, i1.ToString("N2?"), RateNA))
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            MyBase.OnMouseLeave(e)
            If EnableRating Then
                m_CurrentX = -1
                SetDescription()
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            If EnableRating Then
                If (e.Y < 13) AndAlso (e.X < 65) Then
                    m_CurrentX = e.X
                    SetDescription()
                Else 
                    m_CurrentX = -1
                    SetDescription()
                End If
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)
            If EnableRating AndAlso (e.Y < 13) AndAlso (e.X < 65) Then
                Dim i1 As Integer = System.Convert.ToInt32(System.Math.Floor(CDbl(((CSng(m_CurrentX) / 13.0F) + 1.0F))))
                OnRateClicked(New Sublight.Controls.RateControl.RateArgs(CDbl(i1)))
                m_CurrentX = -1
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim i1 As Integer
            Dim bitmap1 As System.Drawing.Bitmap, bitmap2 As System.Drawing.Bitmap

            MyBase.OnPaint(e)
            If UserRate < 0 Then
                i1 = System.Convert.ToInt32(System.Math.Round(m_Rate, 0, System.MidpointRounding.AwayFromZero))
            Else 
                i1 = UserRate
            End If
            If i1 < 0 Then
                i1 = 0
            ElseIf i1 > 5 Then
                i1 = 5
            End If
            Dim i2 As Integer = 1
            While i2 <= i1
                If m_CurrentX < 0 Then
                    bitmap1 = m_StarOutOn
                Else 
                    bitmap1 = m_StarOverOn
                End If
                e.Graphics.DrawImageUnscaled(bitmap1, (i2 - 1) * bitmap1.Width, 0)
                i2 = i2 + 1
            End While
            Dim i3 As Integer = i1 + 1
            While i3 <= 5
                If m_CurrentX < 0 Then
                    bitmap2 = m_StarOutOff
                Else 
                    bitmap2 = m_StarOverOff
                End If
                e.Graphics.DrawImageUnscaled(bitmap2, (i3 - 1) * bitmap2.Width, 0)
                i3 = i3 + 1
            End While
        End Sub

        Protected Overridable Sub OnRateClicked(ByVal e As Sublight.Controls.RateControl.RateArgs)
            If Not (RateClickedEvent) Is Nothing Then
                RaiseEvent RateClicked(Me, e)
            End If
        End Sub

    End Class ' class RateControl

End Namespace

