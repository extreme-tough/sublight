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
    Public Class SubtitleComment

        Private canDeleteField As Boolean 
        Private createdField As System.DateTime 
        Private idField As System.Guid 
        Private languageField As Sublight.WS.SubtitleLanguage 
        Private languageIDField As System.Guid 
        Private messageField As String 
        Private rateField As Integer 
        Private statusField As Sublight.WS.SubtitleCommentStatus 
        Private subtitleIDField As System.Guid 
        Private userField As String 
        Private userIDField As System.Guid 

        Public Property CanDelete As Boolean
            Get
                Return canDeleteField
            End Get
            Set
                canDeleteField = value
            End Set
        End Property

        Public Property Created As System.DateTime
            Get
                Return createdField
            End Get
            Set
                createdField = value
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

        Public Property Language As Sublight.WS.SubtitleLanguage
            Get
                Return languageField
            End Get
            Set
                languageField = value
            End Set
        End Property

        Public Property LanguageID As System.Guid
            Get
                Return languageIDField
            End Get
            Set
                languageIDField = value
            End Set
        End Property

        Public Property Message As String
            Get
                Return messageField
            End Get
            Set
                messageField = value
            End Set
        End Property

        Public Property Rate As Integer
            Get
                Return rateField
            End Get
            Set
                rateField = value
            End Set
        End Property

        Public Property Status As Sublight.WS.SubtitleCommentStatus
            Get
                Return statusField
            End Get
            Set
                statusField = value
            End Set
        End Property

        Public Property SubtitleID As System.Guid
            Get
                Return subtitleIDField
            End Get
            Set
                subtitleIDField = value
            End Set
        End Property

        Public Property User As String
            Get
                Return userField
            End Get
            Set
                userField = value
            End Set
        End Property

        Public Property UserID As System.Guid
            Get
                Return userIDField
            End Get
            Set
                userIDField = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class SubtitleComment

End Namespace

