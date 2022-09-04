Imports Elegant.Ui

Namespace Sublight.Controls

    Public Class PromptedTextBox
        Inherits Elegant.Ui.TextBox

        Public Property PromptText As String
            Get
                Return BannerText
            End Get
            Set
                BannerText = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class PromptedTextBox

End Namespace

