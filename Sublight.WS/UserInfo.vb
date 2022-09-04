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
    Public Class UserInfo

        Private averageRateField As Double 
        Private createdField As System.DateTime 
        Private emailField As String 
        Private mySubtitleDownloadsField As Integer 
        Private pointsField As Double 
        Private subtitleDownloadsField As Integer 
        Private subtitlesDeletedField As Integer 
        Private subtitlesPublishedField As Integer 
        Private subtitleThanksField As Integer 
        Private totalSubtitleDownloadsField As Integer 
        Private usernameField As String 

        Public Property AverageRate As Double
            Get
                Return averageRateField
            End Get
            Set
                averageRateField = value
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

        Public Property Email As String
            Get
                Return emailField
            End Get
            Set
                emailField = value
            End Set
        End Property

        Public Property MySubtitleDownloads As Integer
            Get
                Return mySubtitleDownloadsField
            End Get
            Set
                mySubtitleDownloadsField = value
            End Set
        End Property

        Public Property Points As Double
            Get
                Return pointsField
            End Get
            Set
                pointsField = value
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

        Public Property SubtitlesDeleted As Integer
            Get
                Return subtitlesDeletedField
            End Get
            Set
                subtitlesDeletedField = value
            End Set
        End Property

        Public Property SubtitlesPublished As Integer
            Get
                Return subtitlesPublishedField
            End Get
            Set
                subtitlesPublishedField = value
            End Set
        End Property

        Public Property SubtitleThanks As Integer
            Get
                Return subtitleThanksField
            End Get
            Set
                subtitleThanksField = value
            End Set
        End Property

        Public Property TotalSubtitleDownloads As Integer
            Get
                Return totalSubtitleDownloadsField
            End Get
            Set
                totalSubtitleDownloadsField = value
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

    End Class ' class UserInfo

End Namespace

