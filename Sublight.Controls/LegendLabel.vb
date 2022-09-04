Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Sublight.Controls

    Public Class LegendLabel
        Inherits System.Windows.Forms.UserControl

        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private m_dottedLine As System.Drawing.Pen 
        Private pictureBox1 As System.Windows.Forms.PictureBox 

        Public Property LegendText As String
            Get
                Return Text
            End Get
            Set
                Text = value
                label1.Text = value
            End Set
        End Property

        Public Overrides Property AutoSize As Boolean
            Get
                Return MyBase.AutoSize
            End Get
            Set
                MyBase.AutoSize = value
                label1.AutoSize = value
                If value Then
                    Height = label1.Height
                End If
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            m_dottedLine = New System.Drawing.Pen(System.Drawing.Brushes.Black, 1.0F)
            Dim fArr1 As Single() = New float() { 1.0F, 1.0F }
            m_dottedLine.DashPattern = fArr1
        End Sub

        Private Sub InitializeComponent()
            label1 = New System.Windows.Forms.Label
            pictureBox1 = New System.Windows.Forms.PictureBox
            pictureBox1.BeginInit()
            SuspendLayout()
            label1.AutoSize = True
            label1.Dock = System.Windows.Forms.DockStyle.Right
            label1.Location = New System.Drawing.Point(115, 0)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(35, 13)
            label1.TabIndex = 0
            label1.Text = "label1?"
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
            pictureBox1.Location = New System.Drawing.Point(0, 0)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(115, 73)
            pictureBox1.TabIndex = 1
            pictureBox1.TabStop = False
            AddHandler pictureBox1.Paint, AddressOf pictureBox1_Paint
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(pictureBox1)
            Controls.Add(label1)
            Name = "LegendLabel?"
            Size = New System.Drawing.Size(150, 73)
            pictureBox1.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub pictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawLine(m_dottedLine, 0, label1.Height - 1, pictureBox1.Width, label1.Height - 1)
        End Sub

        Public Sub SetLineWidth(ByVal width As Integer)
            Width = width + label1.Width
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (m_dottedLine) Is Nothing) Then
                m_dottedLine.Dispose()
                m_dottedLine = Nothing
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub Finalize()
            If Not (m_dottedLine) Is Nothing Then
                m_dottedLine.Dispose()
            End If
        End Sub

    End Class ' class LegendLabel

End Namespace

