Imports System
Imports System.Runtime.CompilerServices

Namespace Sublight.Types

    Friend Class WSHException
        Inherits System.Exception

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <Report>k__BackingField As Boolean 

        Public Property Report As Boolean
            Get
                Return <Report>k__BackingField
            End Get
            Set
                <Report>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal message As String, ByVal report As Boolean)
            Report = report
        End Sub

    End Class ' class WSHException

End Namespace

