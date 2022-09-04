Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Properties

Namespace Sublight.Controls

    Public Class ToolTip
        Inherits System.Windows.Forms.UserControl

        Private components As System.ComponentModel.IContainer 
        Private pbToolTip As System.Windows.Forms.PictureBox 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private toolTip1 As System.Windows.Forms.ToolTip 

        Public Property AutoPopDelay As Integer
            Get
                If Not (toolTip1) Is Nothing Then
                    Return toolTip1.AutoPopDelay
                End If
                Return -1
            End Get
            Set
                If Not (toolTip1) Is Nothing Then
                    toolTip1.AutoPopDelay = value
                End If
            End Set
        End Property

        Public Property Title As String
            Get
                If (toolTip1) Is Nothing Then
                    InitializeComponent()
                End If
                If Not (toolTip1) Is Nothing Then
                    Return toolTip1.ToolTipTitle
                End If
                Return System.String.Empty
            End Get
            Set
                If (toolTip1) Is Nothing Then
                    InitializeComponent()
                End If
                If Not (toolTip1) Is Nothing Then
                    toolTip1.ToolTipTitle = value
                End If
            End Set
        End Property

        Public Overrides Property Text As String
            Get
                If (toolTip1) Is Nothing Then
                    InitializeComponent()
                End If
                If Not (toolTip1) Is Nothing Then
                    Return toolTip1.GetToolTip(pbToolTip)
                End If
                Return System.String.Empty
            End Get
            Set
                If (toolTip1) Is Nothing Then
                    InitializeComponent()
                End If
                If Not (toolTip1) Is Nothing Then
                    toolTip1.SetToolTip(pbToolTip, value)
                End If
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, True)
            BackColor = System.Drawing.Color.Transparent
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            pbToolTip = New System.Windows.Forms.PictureBox
            pictureBox1 = New System.Windows.Forms.PictureBox
            toolTip1 = New System.Windows.Forms.ToolTip(components)
            pbToolTip.BeginInit()
            pictureBox1.BeginInit()
            SuspendLayout()
            pbToolTip.Image = Sublight.Properties.Resources.ToolTipIcon
            pbToolTip.Location = New System.Drawing.Point(0, 0)
            pbToolTip.Name = "pbToolTip?"
            pbToolTip.Size = New System.Drawing.Size(13, 13)
            pbToolTip.TabIndex = 0
            pbToolTip.TabStop = False
            pictureBox1.Location = New System.Drawing.Point(0, 0)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(100, 50)
            pictureBox1.TabIndex = 0
            pictureBox1.TabStop = False
            toolTip1.IsBalloon = True
            Controls.Add(pbToolTip)
            Name = "ToolTip?"
            Size = New System.Drawing.Size(13, 13)
            pbToolTip.EndInit()
            pictureBox1.EndInit()
            ResumeLayout(False)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class ToolTip

End Namespace

