Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Properties

Namespace Sublight.Controls

    Public Class TipCtrl
        Inherits System.Windows.Forms.UserControl

        Private _transparency As Integer 
        Private components As System.ComponentModel.IContainer 
        Private lblSearchInfo As System.Windows.Forms.Label 
        Private m_BackgroundBrush As System.Drawing.Brush 
        Private m_BorderPen As System.Drawing.Pen 
        Private pbSearchInfo As System.Windows.Forms.PictureBox 
        Private timerHide As System.Windows.Forms.Timer 
        Private timerShow As System.Windows.Forms.Timer 

        Private Property Transparency As Integer
            Get
                Return _transparency
            End Get
            Set
                If value > 100 Then
                    _transparency = 100
                ElseIf value < 0 Then
                    _transparency = 0
                Else 
                    _transparency = value
                End If
                Invalidate()
            End Set
        End Property

        Public Overrides Property Text As String
            Get
                Return lblSearchInfo.Text
            End Get
            Set
                lblSearchInfo.Text = value
                Invalidate()
            End Set
        End Property

        Public Sub New()
            m_BorderPen = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#799DB6?"))
            m_BackgroundBrush = New System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#FFFFE1?"))
            InitializeComponent()
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.DoubleBuffer Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
            pbSearchInfo.Top = System.Convert.ToInt32((CDbl(Height) / 2.0R) - (CDbl(pbSearchInfo.Height) / 2.0R))
            lblSearchInfo.Top = System.Convert.ToInt32((CDbl(Height) / 2.0R) - (CDbl(lblSearchInfo.Height) / 2.0R))
        End Sub

        Public Sub HideCtrl()
            timerShow.Stop()
            timerHide.Stop()
            timerHide.Start()
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            lblSearchInfo = New System.Windows.Forms.Label
            pbSearchInfo = New System.Windows.Forms.PictureBox
            timerHide = New System.Windows.Forms.Timer(components)
            timerShow = New System.Windows.Forms.Timer(components)
            pbSearchInfo.BeginInit()
            SuspendLayout()
            lblSearchInfo.AutoSize = True
            lblSearchInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            lblSearchInfo.Location = New System.Drawing.Point(20, 4)
            lblSearchInfo.Name = "lblSearchInfo?"
            lblSearchInfo.Size = New System.Drawing.Size(69, 13)
            lblSearchInfo.TabIndex = 137
            lblSearchInfo.Text = "lblSearchInfo?"
            lblSearchInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            lblSearchInfo.Visible = False
            pbSearchInfo.Image = Sublight.Properties.Resources.ToolTipIcon2
            pbSearchInfo.Location = New System.Drawing.Point(2, 2)
            pbSearchInfo.Name = "pbSearchInfo?"
            pbSearchInfo.Size = New System.Drawing.Size(16, 16)
            pbSearchInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pbSearchInfo.TabIndex = 134
            pbSearchInfo.TabStop = False
            pbSearchInfo.Visible = False
            timerHide.Interval = 50
            AddHandler timerHide.Tick, AddressOf timerHide_Tick
            timerShow.Interval = 50
            AddHandler timerShow.Tick, AddressOf timerShow_Tick
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.Transparent
            Controls.Add(lblSearchInfo)
            Controls.Add(pbSearchInfo)
            Name = "TipCtrl?"
            Padding = New System.Windows.Forms.Padding(2)
            Size = New System.Drawing.Size(150, 20)
            pbSearchInfo.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Public Sub ShowCtrl()
            If Visible Then
                Return
            End If
            Transparency = 100
            Visible = True
            Invalidate()
            timerShow.Stop()
            timerHide.Stop()
            timerShow.Start()
        End Sub

        Private Sub timerHide_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            If Transparency >= 100 Then
                timerHide.Stop()
                Visible = False
                Return
            End If
            Transparency = Transparency + 5
        End Sub

        Private Sub timerShow_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            If Transparency <= 0 Then
                timerShow.Stop()
                Return
            End If
            Transparency = Transparency - 5
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (m_BorderPen) Is Nothing Then
                    m_BorderPen.Dispose()
                    m_BorderPen = Nothing
                End If
                If Not (m_BackgroundBrush) Is Nothing Then
                    m_BackgroundBrush.Dispose()
                    m_BackgroundBrush = Nothing
                End If
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.Clear(BackColor)
            e.Graphics.DrawImageUnscaled(Sublight.Properties.Resources.ToolTipIcon2, pbSearchInfo.Left, pbSearchInfo.Top)
            Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString(lblSearchInfo.Text, lblSearchInfo.Font)
            Dim padding1 As System.Windows.Forms.Padding = Padding
            Dim i1 As Integer = System.Convert.ToInt32(sizeF1.Width) + lblSearchInfo.Left + padding1.Right
            If Width < i1 Then
                Width = i1
            End If
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(lblSearchInfo.ForeColor)
                e.Graphics.DrawString(lblSearchInfo.Text, lblSearchInfo.Font, solidBrush1, CSng(lblSearchInfo.Left), CSng(lblSearchInfo.Top))
            End Using
            Dim color1 As System.Drawing.Color = System.Drawing.Color.FromArgb(System.Convert.ToInt32(255.0R * (CDbl(Transparency) / 100.0R)), BackColor)
            Using solidBrush2 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(color1)
                e.Graphics.FillRectangle(solidBrush2, 0, 0, Width, Height)
            End Using
        End Sub

    End Class ' class TipCtrl

End Namespace

