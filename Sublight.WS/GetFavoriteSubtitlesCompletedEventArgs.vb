Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics

Namespace Sublight.WS

    <System.CodeDom.Compiler.GeneratedCode("System.Web.Services", "2.0.50727.4927"), _
    System.ComponentModel.DesignerCategory("code"), _
    System.Diagnostics.DebuggerStepThrough> _
    Public Class GetFavoriteSubtitlesCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results As Object() 

        Public ReadOnly Property actions As Sublight.WS.SubtitleActions()
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(3), Sublight.WS.SubtitleActions[])
            End Get
        End Property

        Public ReadOnly Property error As String
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(4), string)
            End Get
        End Property

        Public ReadOnly Property releases As Sublight.WS.Release()
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(2), Sublight.WS.Release[])
            End Get
        End Property

        Public ReadOnly Property Result As Boolean
            Get
                RaiseExceptionIfNecessary()
                Return DirectCast(results(0), bool)
            End Get
        End Property

        Public ReadOnly Property subtitles As Sublight.WS.Subtitle()
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(1), Sublight.WS.Subtitle[])
            End Get
        End Property

        Friend Sub New(ByVal results As Object(), ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            Me.results = results
        End Sub

    End Class ' class GetFavoriteSubtitlesCompletedEventArgs

End Namespace

