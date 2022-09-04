Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics

Namespace Sublight.WS_SublightClient

    <System.CodeDom.Compiler.GeneratedCode("System.Web.Services", "2.0.50727.4927"), _
    System.Diagnostics.DebuggerStepThrough, _
    System.ComponentModel.DesignerCategory("code")> _
    Public Class GetPaymentsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results As Object() 

        Public ReadOnly Property ds As System.Data.DataSet
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(1), System.Data.DataSet)
            End Get
        End Property

        Public ReadOnly Property error As String
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(2), string)
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

    End Class ' class GetPaymentsCompletedEventArgs

End Namespace

