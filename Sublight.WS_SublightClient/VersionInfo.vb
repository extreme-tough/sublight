Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Xml.Serialization

Namespace Sublight.WS_SublightClient

    <System.Serializable, _
    System.ComponentModel.DesignerCategory("code"), _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927"), _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/"), _
    System.Diagnostics.DebuggerStepThrough> _
    Public Class VersionInfo

        Private changesField As String() 
        Private isUpgradeMandatoryField As Boolean 
        Private newVersionField As String 
        Private publishedField As System.DateTime 

        Public Property Changes As String()
            Get
                Return changesField
            End Get
            Set
                changesField = value
            End Set
        End Property

        Public Property IsUpgradeMandatory As Boolean
            Get
                Return isUpgradeMandatoryField
            End Get
            Set
                isUpgradeMandatoryField = value
            End Set
        End Property

        Public Property NewVersion As String
            Get
                Return newVersionField
            End Get
            Set
                newVersionField = value
            End Set
        End Property

        Public Property Published As System.DateTime
            Get
                Return publishedField
            End Get
            Set
                publishedField = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class VersionInfo

End Namespace

