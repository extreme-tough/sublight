Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Xml.Serialization

Namespace Sublight.WS

    <System.Serializable, _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/"), _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927"), _
    System.Diagnostics.DebuggerStepThrough, _
    System.ComponentModel.DesignerCategory("code")> _
    Public Class SubtitleThank

        Private createdField As System.DateTime 
        Private usernameField As String 

        Public Property Created As System.DateTime
            Get
                Return createdField
            End Get
            Set
                createdField = value
            End Set
        End Property

        Public Property Username As String
            Get
                Return usernameField
            End Get
            Set
                usernameField = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class SubtitleThank

End Namespace

