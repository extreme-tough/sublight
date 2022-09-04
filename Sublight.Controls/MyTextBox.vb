Imports System
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Elegant.Ui

Namespace Sublight.Controls

    Public Class MyTextBox
        Inherits Elegant.Ui.TextBox

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <BorderStyle>k__BackingField As System.Windows.Forms.BorderStyle 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <EnableDisableColor>k__BackingField As Boolean 
        Private m_OriginalColor As System.Nullable(Of System.Drawing.Color) 

        Public Property BorderStyle As System.Windows.Forms.BorderStyle
            Get
                Return <BorderStyle>k__BackingField
            End Get
            Set
                <BorderStyle>k__BackingField = value
            End Set
        End Property

        Public Property EnableDisableColor As Boolean
            Get
                Return <EnableDisableColor>k__BackingField
            End Get
            Set
                <EnableDisableColor>k__BackingField = value
            End Set
        End Property

        Public Sub New()
            EnableDisableColor = True
        End Sub

        Private Sub SetEnableDisableColor(ByVal isEnableProperty As Boolean)
            If Not EnableDisableColor Then
                Return
            End If
            If Not m_OriginalColor.get_HasValue() Then
                m_OriginalColor = New System.Nullable(Of System.Drawing.Color)(BackColor)
            End If
            If Not Enabled OrElse ReadOnly Then
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
                Return
            End If
            BackColor = System.Drawing.SystemColors.Window
        End Sub

        Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
            OnEnabledChanged(e)
            SetEnableDisableColor(True)
        End Sub

        Protected Overrides Sub OnReadOnlyChanged(ByVal e As System.EventArgs)
            MyBase.OnReadOnlyChanged(e)
            SetEnableDisableColor(False)
        End Sub

    End Class ' class MyTextBox

End Namespace

