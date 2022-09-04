Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics

Namespace Sublight.WS

    <System.ComponentModel.DesignerCategory("code"), _
    System.CodeDom.Compiler.GeneratedCode("System.Web.Services", "2.0.50727.4927"), _
    System.Diagnostics.DebuggerStepThrough> _
    Public Class LogInAnonymous4CompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results As Object() 

        Public ReadOnly Property error As String
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(2), string)
            End Get
        End Property

        Public ReadOnly Property Result As System.Guid
            Get
                RaiseExceptionIfNecessary()
                Return DirectCast(results(0), System.Guid)
            End Get
        End Property

        Public ReadOnly Property settings As String()
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(1), String[])
            End Get
        End Property

        Friend Sub New(ByVal results As Object(), ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            Me.results = results
        End Sub

    End Class ' class LogInAnonymous4CompletedEventArgs

End Namespace

