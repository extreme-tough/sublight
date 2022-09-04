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
    Public Class User

        Private createdField As System.DateTime 
        Private displayNameField As String 
        Private emailField As String 
        Private externalSubtitleDownloadsField As Integer 
        Private idField As System.Guid 
        Private isBuiltInField As Boolean 
        Private passwordField As String 
        Private subtitleDownloadsField As Integer 
        Private usernameField As String 

        Public Property Created As System.DateTime
            Get
                Return createdField
            End Get
            Set
                createdField = value
            End Set
        End Property

        Public Property DisplayName As String
            Get
                Return displayNameField
            End Get
            Set
                displayNameField = value
            End Set
        End Property

        Public Property Email As String
            Get
                Return emailField
            End Get
            Set
                emailField = value
            End Set
        End Property

        Public Property ExternalSubtitleDownloads As Integer
            Get
                Return externalSubtitleDownloadsField
            End Get
            Set
                externalSubtitleDownloadsField = value
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

        Public Property IsBuiltIn As Boolean
            Get
                Return isBuiltInField
            End Get
            Set
                isBuiltInField = value
            End Set
        End Property

        Public Property Password As String
            Get
                Return passwordField
            End Get
            Set
                passwordField = value
            End Set
        End Property

        Public Property SubtitleDownloads As Integer
            Get
                Return subtitleDownloadsField
            End Get
            Set
                subtitleDownloadsField = value
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

    End Class ' class User

End Namespace

