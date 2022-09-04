Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Xml.Serialization

Namespace Sublight.WS

    <System.Serializable, _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927"), _
    System.Diagnostics.DebuggerStepThrough, _
    System.ComponentModel.DesignerCategory("code"), _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/")> _
    Public Class SubtitleActions

        Private enableReportingField As Boolean 
        Private enableVotingField As Boolean 
        Private idField As System.Guid 

        Public Property EnableReporting As Boolean
            Get
                Return enableReportingField
            End Get
            Set
                enableReportingField = value
            End Set
        End Property

        Public Property EnableVoting As Boolean
            Get
                Return enableVotingField
            End Get
            Set
                enableVotingField = value
            End Set
        End Property

        Public Property ID As System.Guid
            Get
                Return idField
            End Get
            Set
                idField = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class SubtitleActions

End Namespace

