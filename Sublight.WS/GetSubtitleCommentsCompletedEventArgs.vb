Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics

Namespace Sublight.WS

    <System.CodeDom.Compiler.GeneratedCode("System.Web.Services", "2.0.50727.4927"), _
    System.Diagnostics.DebuggerStepThrough, _
    System.ComponentModel.DesignerCategory("code")> _
    Public Class GetSubtitleCommentsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results As Object() 

        Public ReadOnly Property comments As Sublight.WS.SubtitleComment()
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(2), Sublight.WS.SubtitleComment[])
            End Get
        End Property

        Public ReadOnly Property error As String
            Get
                RaiseExceptionIfNecessary()
                Return CType(results(3), string)
            End Get
        End Property

        Public ReadOnly Property Result As Boolean
            Get
                RaiseExceptionIfNecessary()
                Return DirectCast(results(0), bool)
            End Get
        End Property

        Public ReadOnly Property totalComments As Integer
            Get
                RaiseExceptionIfNecessary()
                Return DirectCast(results(1), int)
            End Get
        End Property

        Friend Sub New(ByVal results As Object(), ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            Me.results = results
        End Sub

    End Class ' class GetSubtitleCommentsCompletedEventArgs

End Namespace

