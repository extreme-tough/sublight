Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Sublight.Properties

Namespace Sublight.Controls

    Public Class Loading
        Inherits System.Windows.Forms.UserControl

        Private ReadOnly m_paddingLeft As Integer 
        Private ReadOnly m_paddingTop As Integer 

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <DrawFrame>k__BackingField As Boolean 
        Private components As System.ComponentModel.IContainer 
        Private lblText As System.Windows.Forms.Label 
        Private m_animation As System.Drawing.Image 
        Private m_BorderPen As System.Drawing.Pen 
        Private m_BorderPenDark As System.Drawing.Pen 
        Private m_currentlyAnimating As Boolean 

        Protected ReadOnly Property BorderPen As System.Drawing.Pen
            Get
                If (m_BorderPen) Is Nothing Then
                    m_BorderPen = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#6593CF?"), 1.0F)
                End If
                Return m_BorderPen
            End Get
        End Property

        Protected ReadOnly Property BorderPenDark As System.Drawing.Pen
            Get
                If (m_BorderPenDark) Is Nothing Then
                    m_BorderPenDark = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#15428B?"), 1.0F)
                End If
                Return m_BorderPenDark
            End Get
        End Property

        Public Property DrawFrame As Boolean
            Get
                Return <DrawFrame>k__BackingField
            End Get
            Set
                <DrawFrame>k__BackingField = value
            End Set
        End Property

        Public Overrides Property Text As String
            Get
                Return lblText.Text
            End Get
            Set
                lblText.Text = value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal paddingLeft As Integer, ByVal paddingTop As Integer, ByVal font As System.Drawing.Font)
            InitializeComponent()
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.DoubleBuffer Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
            m_animation = Sublight.Properties.Resources.Loading
            DrawFrame = False
            m_paddingLeft = paddingLeft
            m_paddingTop = paddingTop
            If Not (font) Is Nothing Then
                lblText.Font = font
            End If
            lblText.Visible = False
            lblText.Text = System.String.Empty
            lblText.Top = paddingTop
        End Sub

        Private Sub InitializeComponent()
            lblText = New System.Windows.Forms.Label
            SuspendLayout()
            lblText.AutoSize = True
            lblText.Location = New System.Drawing.Point(34, 3)
            lblText.Name = "lblText?"
            lblText.Size = New System.Drawing.Size(28, 13)
            lblText.TabIndex = 12
            lblText.Text = "Text?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(lblText)
            Name = "Loading?"
            Size = New System.Drawing.Size(75, 16)
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub OnFrameChanged(ByVal o As Object, ByVal e As System.EventArgs)
            Invalidate()
            System.Windows.Forms.Application.DoEvents()
        End Sub

        Public Sub Start()
            System.Drawing.ImageAnimator.Animate(m_animation, New System.EventHandler(OnFrameChanged))
            m_currentlyAnimating = True
            lblText.Left = m_paddingLeft + 22
            lblText.Visible = True
        End Sub

        Public Sub Stop()
            lblText.Left = 0
            m_currentlyAnimating = False
            System.Drawing.ImageAnimator.StopAnimate(m_animation, New System.EventHandler(OnFrameChanged))
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (m_BorderPenDark) Is Nothing Then
                    m_BorderPenDark.Dispose()
                    m_BorderPenDark = Nothing
                End If
                If Not (m_BorderPen) Is Nothing Then
                    m_BorderPen.Dispose()
                    m_BorderPen = Nothing
                End If
                If Not (m_animation) Is Nothing Then
                    m_animation.Dispose()
                    m_animation = Nothing
                End If
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            Try
                MyBase.Dispose(disposing)
            Catch 
            End Try
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            If DrawFrame Then
                e.Graphics.DrawRectangle(BorderPen, 0, 0, Width - 2, Height - 2)
                e.Graphics.DrawLine(BorderPenDark, 1, Height - 1, Width - 1, Height - 1)
                e.Graphics.DrawLine(BorderPenDark, Width - 1, 1, Width - 1, Height - 1)
            End If
            If m_currentlyAnimating Then
                System.Drawing.ImageAnimator.UpdateFrames(m_animation)
                e.Graphics.DrawImage(m_animation, m_paddingLeft, m_paddingTop)
            End If
        End Sub

    End Class ' class Loading

End Namespace

