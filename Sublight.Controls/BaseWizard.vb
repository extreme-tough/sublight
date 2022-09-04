Imports System
Imports System.Windows.Forms

Namespace Sublight.Controls

    Public Class BaseWizard
        Inherits System.Windows.Forms.UserControl

        Public Overridable ReadOnly Property HeaderText As String
            Get
                Return Nothing
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Overridable Function Finalize(ByRef msg As String) As Boolean
            msg = Nothing
            Return True
        End Function

        Public Overridable Function IsStepValid(ByRef msg As String) As Boolean
            msg = Nothing
            Return True
        End Function

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        End Sub

        Public Overridable Sub Translate()
        End Sub

    End Class ' class BaseWizard

End Namespace

