Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Sublight.Controls

    Public Class LGBarItem
        Inherits System.Windows.Forms.UserControl

        Private _isSelected As Boolean 
        Private _selectedColor As System.Drawing.Color 
        Private _unselectedColor As System.Drawing.Color 
        Private components As System.ComponentModel.IContainer 
        Private lblDescription As System.Windows.Forms.Label 
        Private lgBar As Sublight.Controls.LGBar 

        Public Property IsSelected As Boolean
            Get
                Return _isSelected
            End Get
            Set
                _isSelected = value
                If _isSelected Then
                    BackColor = SelectedColor
                    lblDescription.ForeColor = System.Drawing.SystemColors.HighlightText
                Else 
                    BackColor = UnselectedColor
                    lblDescription.ForeColor = System.Drawing.SystemColors.ControlText
                End If
                lgBar.IsHighlighted = value
            End Set
        End Property

        Public Property Percentage As Single
            Get
                If (lgBar) Is Nothing Then
                    Return 0.0F
                End If
                Return lgBar.Percentage
            End Get
            Set
                If Not (lgBar) Is Nothing Then
                    lgBar.Percentage = value
                End If
            End Set
        End Property

        Protected Property SelectedColor As System.Drawing.Color
            Get
                Return _selectedColor
            End Get
            Set
                _selectedColor = value
            End Set
        End Property

        Protected Property UnselectedColor As System.Drawing.Color
            Get
                Return _unselectedColor
            End Get
            Set
                _unselectedColor = value
            End Set
        End Property

        Public Overrides Property Text As String
            Get
                If (lblDescription) Is Nothing Then
                    Return System.String.Empty
                End If
                Return lblDescription.Text
            End Get
            Set
                If Not (lblDescription) Is Nothing Then
                    lblDescription.Text = value
                End If
            End Set
        End Property

        Public Sub New()
            _selectedColor = System.Drawing.ColorTranslator.FromHtml("#0066CC?")
            _unselectedColor = System.Drawing.Color.Transparent
            InitializeComponent()
            lgBar.BackColor = System.Drawing.SystemColors.HighlightText
        End Sub

        Private Sub InitializeComponent()
            lblDescription = New System.Windows.Forms.Label
            lgBar = New Sublight.Controls.LGBar
            SuspendLayout()
            lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom
            lblDescription.Location = New System.Drawing.Point(5, 27)
            lblDescription.Name = "lblDescription?"
            lblDescription.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            lblDescription.Size = New System.Drawing.Size(366, 19)
            lblDescription.TabIndex = 0
            lblDescription.Text = "label1?"
            lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            lblDescription.UseMnemonic = False
            AddHandler lblDescription.Click, AddressOf lblDescription_Click
            lgBar.Dock = System.Windows.Forms.DockStyle.Fill
            lgBar.IsHighlighted = False
            lgBar.Location = New System.Drawing.Point(5, 5)
            lgBar.Name = "lgBar?"
            lgBar.Percentage = 0.0F
            lgBar.Size = New System.Drawing.Size(366, 22)
            lgBar.TabIndex = 1
            AddHandler lgBar.Click, AddressOf lgBar_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(lgBar)
            Controls.Add(lblDescription)
            Name = "LGBarItem?"
            Padding = New System.Windows.Forms.Padding(5)
            Size = New System.Drawing.Size(376, 51)
            ResumeLayout(False)
        End Sub

        Private Sub lblDescription_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            OnClick(e)
        End Sub

        Private Sub lgBar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            OnClick(e)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class LGBarItem

End Namespace

