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
    Public Class Release

        Private fPSField As Sublight.WS.FPS 
        Private nameField As String 
        Private releaseIDField As System.Guid 
        Private subtitleIDField As System.Guid 

        Public Property FPS As Sublight.WS.FPS
            Get
                Return fPSField
            End Get
            Set
                fPSField = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return nameField
            End Get
            Set
                nameField = value
            End Set
        End Property

        Public Property ReleaseID As System.Guid
            Get
                Return releaseIDField
            End Get
            Set
                releaseIDField = value
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

        Public Sub New()
        End Sub

    End Class ' class Release

End Namespace

