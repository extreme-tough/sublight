Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Xml.Serialization

Namespace Sublight.WS

    <System.Serializable, _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927"), _
    System.ComponentModel.DesignerCategory("code"), _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/"), _
    System.Diagnostics.DebuggerStepThrough> _
    Public Class ClientInfo

        Private apiKeyField As String 
        Private clientIdField As String 

        Public Property ApiKey As String
            Get
                Return apiKeyField
            End Get
            Set
                apiKeyField = value
            End Set
        End Property

        Public Property ClientId As String
            Get
                Return clientIdField
            End Get
            Set
                clientIdField = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class ClientInfo

End Namespace

