Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Xml.Serialization

Namespace Sublight.WS

    <System.Serializable, _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927"), _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/"), _
    System.Diagnostics.DebuggerStepThrough, _
    System.ComponentModel.DesignerCategory("code")> _
    Public Class Subtitle

        Private canDeleteField As Boolean 
        Private commentField As String 
        Private createdField As System.DateTime 
        Private downloadsField As Integer 
        Private episodeField As System.Nullable(Of Integer) 
        Private externalIdField As String 
        Private fPSField As Sublight.WS.FPS 
        Private genreField As Sublight.WS.Genre 
        Private iMDBField As String 
        Private isLinkedField As Boolean 
        Private languageField As Sublight.WS.SubtitleLanguage 
        Private linkField As String 
        Private mediaTypeField As Sublight.WS.MediaType 
        Private nonImdbTitleField As String 
        Private numberOfDiscsField As Byte 
        Private parentSubtitleIDField As System.Guid 
        Private publisherField As String 
        Private publisherIDField As System.Guid 
        Private rateField As Single 
        Private releaseField As String 
        Private reportsField As Integer 
        Private seasonField As System.Nullable(Of Byte) 
        Private sizeField As Integer 
        Private statusField As Byte 
        Private subCountField As Integer 
        Private subtitleIDField As System.Guid 
        Private subtitleTypeField As Sublight.WS.SubtitleType 
        Private titleField As String 
        Private votesField As Integer 
        Private yearField As System.Nullable(Of Integer) 

        Public Property CanDelete As Boolean
            Get
                Return canDeleteField
            End Get
            Set
                canDeleteField = value
            End Set
        End Property

        Public Property Comment As String
            Get
                Return commentField
            End Get
            Set
                commentField = value
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

        Public Property Downloads As Integer
            Get
                Return downloadsField
            End Get
            Set
                downloadsField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property Episode As System.Nullable(Of Integer)
            Get
                Return episodeField
            End Get
            Set
                episodeField = value
            End Set
        End Property

        Public Property ExternalId As String
            Get
                Return externalIdField
            End Get
            Set
                externalIdField = value
            End Set
        End Property

        Public Property FPS As Sublight.WS.FPS
            Get
                Return fPSField
            End Get
            Set
                fPSField = value
            End Set
        End Property

        Public Property Genre As Sublight.WS.Genre
            Get
                Return genreField
            End Get
            Set
                genreField = value
            End Set
        End Property

        Public Property IMDB As String
            Get
                Return iMDBField
            End Get
            Set
                iMDBField = value
            End Set
        End Property

        Public Property IsLinked As Boolean
            Get
                Return isLinkedField
            End Get
            Set
                isLinkedField = value
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

        Public Property Link As String
            Get
                Return linkField
            End Get
            Set
                linkField = value
            End Set
        End Property

        Public Property MediaType As Sublight.WS.MediaType
            Get
                Return mediaTypeField
            End Get
            Set
                mediaTypeField = value
            End Set
        End Property

        Public Property NonImdbTitle As String
            Get
                Return nonImdbTitleField
            End Get
            Set
                nonImdbTitleField = value
            End Set
        End Property

        Public Property NumberOfDiscs As Byte
            Get
                Return numberOfDiscsField
            End Get
            Set
                numberOfDiscsField = value
            End Set
        End Property

        Public Property ParentSubtitleID As System.Guid
            Get
                Return parentSubtitleIDField
            End Get
            Set
                parentSubtitleIDField = value
            End Set
        End Property

        Public Property Publisher As String
            Get
                Return publisherField
            End Get
            Set
                publisherField = value
            End Set
        End Property

        Public Property PublisherID As System.Guid
            Get
                Return publisherIDField
            End Get
            Set
                publisherIDField = value
            End Set
        End Property

        Public Property Rate As Single
            Get
                Return rateField
            End Get
            Set
                rateField = value
            End Set
        End Property

        Public Property Release As String
            Get
                Return releaseField
            End Get
            Set
                releaseField = value
            End Set
        End Property

        Public Property Reports As Integer
            Get
                Return reportsField
            End Get
            Set
                reportsField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property Season As System.Nullable(Of Byte)
            Get
                Return seasonField
            End Get
            Set
                seasonField = value
            End Set
        End Property

        Public Property Size As Integer
            Get
                Return sizeField
            End Get
            Set
                sizeField = value
            End Set
        End Property

        Public Property Status As Byte
            Get
                Return statusField
            End Get
            Set
                statusField = value
            End Set
        End Property

        Public Property SubCount As Integer
            Get
                Return subCountField
            End Get
            Set
                subCountField = value
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

        Public Property SubtitleType As Sublight.WS.SubtitleType
            Get
                Return subtitleTypeField
            End Get
            Set
                subtitleTypeField = value
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

        Public Property Votes As Integer
            Get
                Return votesField
            End Get
            Set
                votesField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property Year As System.Nullable(Of Integer)
            Get
                Return yearField
            End Get
            Set
                yearField = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class Subtitle

End Namespace

