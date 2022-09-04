Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics

Namespace Sublight.WS

    <System.CodeDom.Compiler.GeneratedCode("System.Web.Services", "2.0.50727.4927"), _
    System.ComponentModel.DesignerCategory("code"), _
    System.Diagnostics.DebuggerStepThrough> _
    Public Class GetHistoryCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results As Object() 

        Public ReadOnly Property error As String
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(2), string)
            End Get
        End Property

        Public ReadOnly Property items As Sublight.WS.HistoryItem()
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(1), Sublight.WS.HistoryItem[])
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

    End Class ' class GetHistoryCompletedEventArgs

End Namespace

