Imports System
Imports System.Text

Namespace Sublight.MyUtility

    Friend MustInherit Class StringUtil

        Protected Sub New()
        End Sub

        Public Shared Function ComputeLevenshteinDistance(ByVal s As String, ByVal t As String) As Integer
            Dim i1 As Integer = s.Length
            Dim i2 As Integer = t.Length
            Dim iArr1 As Integer(,) = New Integer((i1 + 1), (i2 + 1)) {}
            If i1 = 0 Then
                Return i2
            End If
            If i2 = 0 Then
                Return i1
            End If
            Dim i3 As Integer = 0
            While i3 <= i1
                iArr1(i3, 0) = i3++
            End While
            Dim i4 As Integer = 0
            While i4 <= i2
                iArr1(0, i4) = i4++
            End While
            Dim i5 As Integer = 1
            While i5 <= i1
                Dim i6 As Integer = 1
                While i6 <= i2
                    Dim i7 As Integer = IIf(t(i6 - 1) = s(i5 - 1), 0, 1)
                    iArr1(i5, i6) = System.Math.Min(System.Math.Min(iArr1(i5 - 1, i6) + 1, iArr1(i5, i6 - 1) + 1), iArr1(i5 - 1, i6 - 1) + i7)
                    i6 = i6 + 1
                End While
                i5 = i5 + 1
            End While
            Return iArr1(i1, i2)
        End Function

        Public Shared Function FromBase64String(ByVal text As String) As String
            If (text) Is Nothing Then
                Return Nothing
            End If
            Dim bArr1 As Byte() = System.Convert.FromBase64String(text)
            Return System.Text.Encoding.UTF8.GetString(bArr1)
        End Function

    End Class ' class StringUtil

End Namespace

