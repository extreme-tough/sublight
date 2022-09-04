Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Properties

Namespace Sublight.Controls

    Public Class TV_Control
        Inherits System.Windows.Forms.UserControl

        Private _frame As Integer 
        Private _subtitleBrush As System.Drawing.Brush 
        Private _subtitleFont As System.Drawing.Font 
        Private _subtitles As String() 
        Private _subtitleText As String 
        Private components As System.ComponentModel.IContainer 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private timer1 As System.Windows.Forms.Timer 

        Public Sub New()
            _subtitleBrush = New System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#FFFFFF?"))
            _subtitleFont = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            pictureBox1 = New System.Windows.Forms.PictureBox
            timer1 = New System.Windows.Forms.Timer(components)
            pictureBox1.BeginInit()
            SuspendLayout()
            pictureBox1.Image = Sublight.Properties.Resources.LCD_TV_SMALL
            pictureBox1.Location = New System.Drawing.Point(0, 0)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(114, 82)
            pictureBox1.TabIndex = 0
            pictureBox1.TabStop = False
            AddHandler pictureBox1.Paint, AddressOf pictureBox1_Paint
            timer1.Interval = 1000
            AddHandler timer1.Tick, AddressOf timer1_Tick
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(pictureBox1)
            Name = "TV_Control?"
            Size = New System.Drawing.Size(114, 82)
            pictureBox1.EndInit()
            ResumeLayout(False)
        End Sub

        Public Sub LoadSubtitles(ByVal subtitles As String())
            _subtitles = subtitles
            Reset()
        End Sub

        Private Sub pictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString(_subtitleText, _subtitleFont)
            e.Graphics.DrawString(_subtitleText, _subtitleFont, _subtitleBrush, (CSng(pictureBox1.Width) / 2.0F) - (sizeF1.Width / 2.0F), CSng(pictureBox1.Height) - sizeF1.Height - 18.0F)
        End Sub

        Private Sub Reset()
            timer1.Stop()
            _frame = 0
            timer1.Interval = 2500
            timer1_Tick(Me, Nothing)
            timer1.Start()
        End Sub

        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            If ((_subtitles) Is Nothing) OrElse (_subtitles.Length <= 0) Then
                Return
            End If
            _subtitleText = _subtitles(_frame)
            _frame = _frame + 1
            If _frame >= _subtitles.Length Then
                _frame = 0
            End If
            pictureBox1.Invalidate()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (_subtitleBrush) Is Nothing Then
                    _subtitleBrush.Dispose()
                    _subtitleBrush = Nothing
                End If
                If Not (_subtitleFont) Is Nothing Then
                    _subtitleFont.Dispose()
                    _subtitleFont = Nothing
                End If
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            Reset()
        End Sub

    End Class ' class TV_Control

End Namespace

