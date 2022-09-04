Imports System
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
    Public Class HistoryItem

        Private changedField As System.DateTime 
        Private typeField As Sublight.WS.HistoryType 
        Private usernameField As String 

        Public Property Changed As System.DateTime
            Get
                Return changedField
            End Get
            Set
                changedField = value
            End Set
        End Property

        Public Property Type As Sublight.WS.HistoryType
            Get
                Return typeField
            End Get
            Set
                typeField = value
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

    End Class ' class HistoryItem

End Namespace

