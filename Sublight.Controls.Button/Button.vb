Imports System
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Elegant.Ui

Namespace Sublight.Controls.Button

    Public Class Button
        Inherits Elegant.Ui.Button

        Private _TextWidth As Integer 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <AutoResize>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <UseVisualStyleBackColor>k__BackingField As Boolean 

        Public Property AutoResize As Boolean
            Get
                Return <AutoResize>k__BackingField
            End Get
            Set
                <AutoResize>k__BackingField = value
            End Set
        End Property

        Public Property Image As System.Drawing.Image
            Get
                Return DefaultSmallImage
            End Get
            Set
                DefaultSmallImage = value
            End Set
        End Property

        Public ReadOnly Property TextWidth As Integer
            Get
                If AutoResize AndAlso (_TextWidth = -1) Then
                    Try
                        Using graphics1 As System.Drawing.Graphics = CreateGraphics()
                            Dim sizeF1 As System.Drawing.SizeF = graphics1.MeasureString(MyBase.Text, Font)
                            _TextWidth = System.Convert.ToInt32(System.Math.Ceiling(CDbl(sizeF1.Width)))
                        End Using
                    Catch 
                        _TextWidth = -2
                    End Try
                End If
                Return _TextWidth
            End Get
        End Property

        Public Property UseVisualStyleBackColor As Boolean
            Get
                Return <UseVisualStyleBackColor>k__BackingField
            End Get
            Set
                <UseVisualStyleBackColor>k__BackingField = value
            End Set
        End Property

        Public Overrides Property BackColor As System.Drawing.Color
            Get
                Return MyBase.BackColor
            End Get
            Set
                If value = System.Drawing.Color.Transparent Then
                    MyBase.BackColor = System.Drawing.SystemColors.Control
                    Return
                End If
                MyBase.BackColor = value
            End Set
        End Property

        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set
                _TextWidth = -1
                MyBase.Text = value
            End Set
        End Property

        Public Shared ReadOnly Property ThemedRendering As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub New()
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            UseVisualStyleBackColor = True
            TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        End Sub

        Public Shared Sub MakeSameWidth(ByVal buttons As Sublight.Controls.Button.Button(), ByVal minWidth As Integer, ByVal padding As Integer)
            Dim i3 As Integer

            If ((buttons) Is Nothing) OrElse (buttons.Length = 0) Then
                Return
            End If
            Dim i1 As Integer = -1
            Dim buttonArr1 As Sublight.Controls.Button.Button() = buttons
            Dim i4 As Integer = 0
            While i4 < buttonArr1.Length
                Dim button1 As Sublight.Controls.Button.Button = buttonArr1(i4)
                button1.AutoResize = True
                button1._TextWidth = -1
                Dim i2 As Integer = button1.TextWidth
                If i2 > i1 Then
                    i1 = i2
                End If
                i4 = i4 + 1
            End While
            i1 = i1 + (2 * padding)
            If i1 > minWidth Then
                i3 = i1
            Else 
                i3 = minWidth
            End If
            If i3 < 0 Then
                i3 = 75
            End If
            Dim buttonArr2 As Sublight.Controls.Button.Button() = buttons
            Dim i5 As Integer = 0
            While i5 < buttonArr2.Length
                Dim button2 As Sublight.Controls.Button.Button = buttonArr2(i5)
                button2.Width = i3
                i5 = i5 + 1
            End While
        End Sub

        Public Shared Sub MakeSameWidth(ByVal buttons As Sublight.Controls.Button.Button())
            Sublight.Controls.Button.Button.MakeSameWidth(buttons, 75, 5)
        End Sub

        Public Shared Sub MakeSameWidth(ByVal button As Sublight.Controls.Button.Button)
            Dim buttonArr1 As Sublight.Controls.Button.Button() = New Sublight.Controls.Button.Button() { button }
            Sublight.Controls.Button.Button.MakeSameWidth(buttonArr1)
        End Sub

    End Class ' class Button

End Namespace

