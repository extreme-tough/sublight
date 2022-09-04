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
    Public Class AlternativeTitle

        Private idField As System.Guid 
        Private languageField As String 
        Private titleField As String 

        Public Property ID As System.Guid
            Get
                Return idField
            End Get
            Set
                idField = value
            End Set
        End Property

        Public Property Language As String
            Get
                Return languageField
            End Get
            Set
                languageField = value
            End Set
        End Property

        Public Property Title As String
            Get
                Return titleField
            End Get
            Set
                titleField = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class AlternativeTitle

End Namespace

