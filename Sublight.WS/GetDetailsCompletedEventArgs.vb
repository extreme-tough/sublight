Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics

Namespace Sublight.WS

    <System.ComponentModel.DesignerCategory("code"), _
    System.CodeDom.Compiler.GeneratedCode("System.Web.Services", "2.0.50727.4927"), _
    System.Diagnostics.DebuggerStepThrough> _
    Public Class GetDetailsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results As Object() 

        Public ReadOnly Property alternativeTitles As Sublight.WS.AlternativeTitle()
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(2), Sublight.WS.AlternativeTitle[])
            End Get
        End Property

        Public ReadOnly Property error As String
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(3), string)
            End Get
        End Property

        Public ReadOnly Property imdbInfo As Sublight.WS.IMDB
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(1), Sublight.WS.IMDB)
            End Get
        End Property

        Public ReadOnly Property Result As Boolean
            Get
                RaiseExceptionIfNecessary()
                Return DirectCast(results(0), bool)
            End Get
        End Property

        Friend Sub New(ByVal results As Object(), ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            Me.results = results
        End Sub

    End Class ' class GetDetailsCompletedEventArgs

End Namespace

