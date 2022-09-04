Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Elegant.Ui

Namespace Sublight.Controls

    Public Class MyComboBox
        Inherits Elegant.Ui.ComboBox

        Private m_OriginalColor As System.Nullable(Of System.Drawing.Color) 

        Public Property DropDownStyle As System.Windows.Forms.ComboBoxStyle
            Get
                If Editable Then
                    Return System.Windows.Forms.ComboBoxStyle.DropDown
                End If
                Return System.Windows.Forms.ComboBoxStyle.DropDownList
            End Get
            Set
                If value = System.Windows.Forms.ComboBoxStyle.DropDown Then
                    Editable = True
                    Return
                End If
                If value = System.Windows.Forms.ComboBoxStyle.DropDownList Then
                    Editable = False
                    Return
                End If
                Throw New System.Exception("ComboBoxStyle not supported.?")
            End Set
        End Property

        Public Sub New()
            ItemHeight = 22
        End Sub

        Private Sub SetEnableDisableColor(ByVal isEnableProperty As Boolean)
            Dim color1 As System.Drawing.Color

            If Not m_OriginalColor.get_HasValue() Then
                m_OriginalColor = New System.Nullable(Of System.Drawing.Color)(BackColor)
            End If
            If Enabled Then
                color1 = m_OriginalColor.get_Value()
            Else 
                color1 = System.Drawing.Color.FromArgb(240, 240, 240)
            End If
            If BackColor <> color1 Then
                BackColor = color1
            End If
        End Sub

        Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
            OnEnabledChanged(e)
            SetEnableDisableColor(True)
        End Sub

    End Class ' class MyComboBox

End Namespace

