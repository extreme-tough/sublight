Imports System
Imports System.Text

Namespace Sublight.MyUtility

    Friend MustInherit Class ExceptionUtil

        Protected Sub New()
        End Sub

        Public Shared Function ToString(ByVal ex As System.Exception) As String
            If (ex) Is Nothing Then
                Return Nothing
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim exception1 As System.Exception = ex
            While Not (exception1) Is Nothing
                stringBuilder1.AppendLine(exception1.Message)
                exception1 = exception1.InnerException
                If Not (exception1) Is Nothing Then
                    stringBuilder1.AppendLine()
                End If
            End While
            Return stringBuilder1.ToString()
        End Function

    End Class ' class ExceptionUtil

End Namespace

