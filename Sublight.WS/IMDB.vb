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
    Public Class IMDB

        Private episodeField As System.Nullable(Of Integer) 
        Private genreField As System.Nullable(Of Sublight.WS.Genre) 
        Private idField As String 
        Private posterUrlField As String 
        Private seasonField As System.Nullable(Of Integer) 
        Private syncDateField As System.Nullable(Of System.DateTime) 
        Private tagField As String 
        Private titleField As String 
        Private userRatingField As System.Nullable(Of Single) 
        Private yearField As System.Nullable(Of Integer) 
        Private yearToField As System.Nullable(Of Integer) 

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property Episode As System.Nullable(Of Integer)
            Get
                Return episodeField
            End Get
            Set
                episodeField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property Genre As System.Nullable(Of Sublight.WS.Genre)
            Get
                Return genreField
            End Get
            Set
                genreField = value
            End Set
        End Property

        Public Property Id As String
            Get
                Return idField
            End Get
            Set
                idField = value
            End Set
        End Property

        Public Property PosterUrl As String
            Get
                Return posterUrlField
            End Get
            Set
                posterUrlField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property Season As System.Nullable(Of Integer)
            Get
                Return seasonField
            End Get
            Set
                seasonField = value
            End Set
        End Property

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property SyncDate As System.Nullable(Of System.DateTime)
            Get
                Return syncDateField
            End Get
            Set
                syncDateField = value
            End Set
        End Property

        Public Property Tag As String
            Get
                Return tagField
            End Get
            Set
                tagField = value
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

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property UserRating As System.Nullable(Of Single)
            Get
                Return userRatingField
            End Get
            Set
                userRatingField = value
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

        <System.Xml.Serialization.XmlElement(IsNullable = True)> _
        Public Property YearTo As System.Nullable(Of Integer)
            Get
                Return yearToField
            End Get
            Set
                yearToField = value
            End Set
        End Property

        Public Sub New()
        End Sub

    End Class ' class IMDB

End Namespace

