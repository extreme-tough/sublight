Imports System.Runtime.CompilerServices
Imports Elegant.Ui

Namespace Sublight.Controls

    Friend Class MyRadioButton
        Inherits Elegant.Ui.RadioButton

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <UseVisualStyleBackColor>k__BackingField As Boolean 

        Public Property UseVisualStyleBackColor As Boolean
            Get
                Return <UseVisualStyleBackColor>k__BackingField
            End Get
            Set
                <UseVisualStyleBackColor>k__BackingField = value
            End Set
        End Property

        Public Sub New()
            RadioGroupName = "rgn1?"
        End Sub

    End Class ' class MyRadioButton

End Namespace

