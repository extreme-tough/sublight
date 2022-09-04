Imports System
Imports System.IO
Imports System.Text

Namespace Sublight.MyUtility

    Public NotInheritable Class MovieHasher

        Public Sub New()
        End Sub

        Private Shared Function ComputeMovieHash(ByVal input As System.IO.Stream) As Byte()
            Dim l1 As Long = input.Length
            Dim l2 As Long = l1
            Dim l3 As Long = CLng(0)
            Dim bArr1 As Byte() = New byte(8) {}
            While (CInt(l3) < 8192) AndAlso (input.Read(bArr1, 0, 8) > 0)
                l3 = l3 + CLng(1)
                l2 = l2 + System.BitConverter.ToInt64(bArr1, 0)
            End While
            input.Position = System.Math.Max(CLng(0), l1 - CLng(65536))
            l3 = CLng(0)
            While (CInt(l3) < 8192) AndAlso (input.Read(bArr1, 0, 8) > 0)
                l3 = l3 + CLng(1)
                l2 = l2 + System.BitConverter.ToInt64(bArr1, 0)
            End While
            input.Close()
            Dim bArr2 As Byte() = System.BitConverter.GetBytes(l2)
            System.Array.Reverse(bArr2)
            Return bArr2
        End Function

        Public Shared Function ComputeMovieHash(ByVal filename As String) As String
            Dim s1 As String

            If System.String.IsNullOrEmpty(filename) Then
                Return Nothing
            End If
            Try
                s1 = Sublight.MyUtility.MovieHasher.ToHexadecimal(Sublight.MyUtility.MovieHasher.ComputeMovieHashBytes(filename))
            Catch e As System.Exception
                s1 = Nothing
            End Try
            Return s1
        End Function

        Private Shared Function ComputeMovieHashBytes(ByVal filename As String) As Byte()
            Dim bArr1 As Byte()

            Using stream1 As System.IO.Stream = System.IO.File.OpenRead(filename)
                bArr1 = Sublight.MyUtility.MovieHasher.ComputeMovieHash(stream1)
            End Using
            Return bArr1
        End Function

        Private Shared Function ToHexadecimal(ByVal bytes As Byte()) As String
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim i1 As Integer = 0
            While i1 < bytes.Length
                stringBuilder1.Append(bytes(i1).ToString("x2?"))
                i1 = i1 + 1
            End While
            Return stringBuilder1.ToString()
        End Function

    End Class ' class MovieHasher

End Namespace

