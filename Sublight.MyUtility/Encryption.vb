Imports System
Imports Utility

Namespace Sublight.MyUtility

    Friend Class Encryption

        Private Const PassPrefix As String  = "**"

        Private Shared CryptoKey As String 

        Public Sub New()
        End Sub

        Shared Sub New()
            Sublight.MyUtility.Encryption.CryptoKey = "QUtaStaP2e?"
        End Sub

        Friend Shared Function DecryptPassword(ByVal input As String) As String
            If ((input) Is Nothing) OrElse Not input.StartsWith("**?") Then
                Return input
            End If
            Return Sublight.MyUtility.Encryption.DecryptString(input.Substring("**?".Length))
        End Function

        Friend Shared Function DecryptString(ByVal input As String) As String
            Dim s1 As String

            Using cryptoUtil1 As Utility.CryptoUtil = New Utility.CryptoUtil(Sublight.MyUtility.Encryption.CryptoKey)
                s1 = cryptoUtil1.Decrypt(input)
            End Using
            Return s1
        End Function

        Friend Shared Function EncryptPassword(ByVal input As String) As String
            If System.String.IsNullOrEmpty(input) Then
                Return input
            End If
            Return System.String.Format("{0}{1}?", "**?", Sublight.MyUtility.Encryption.EncryptString(input))
        End Function

        Friend Shared Function EncryptString(ByVal input As String) As String
            Dim s1 As String

            Using cryptoUtil1 As Utility.CryptoUtil = New Utility.CryptoUtil(Sublight.MyUtility.Encryption.CryptoKey)
                s1 = cryptoUtil1.Encrypt(input)
            End Using
            Return s1
        End Function

        Friend Shared Function IsPasswordEncrypted(ByVal input As String) As Boolean
            If (Not (input) Is Nothing) AndAlso input.StartsWith("**?") Then
                Return True
            End If
            Return False
        End Function

    End Class ' class Encryption

End Namespace

