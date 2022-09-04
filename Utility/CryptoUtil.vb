Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace Utility

    Public Class CryptoUtil
        Implements System.IDisposable

        Private m_Decryptor As System.Security.Cryptography.ICryptoTransform 
        Private m_DecryptorSecretKey As System.Security.Cryptography.PasswordDeriveBytes 
        Private m_Encryptor As System.Security.Cryptography.ICryptoTransform 
        Private m_EncryptorSecretKey As System.Security.Cryptography.PasswordDeriveBytes 
        Private m_Password As String 
        Private m_RijndaelCipher As System.Security.Cryptography.RijndaelManaged 
        Private m_Salt As Byte() 

        Protected ReadOnly Property Decryptor As System.Security.Cryptography.ICryptoTransform
            Get
                If (m_Decryptor) Is Nothing Then
                    m_Decryptor = RijndaelCipher.CreateDecryptor(DecryptorSecretKey.GetBytes(32), DecryptorSecretKey.GetBytes(16))
                End If
                Return m_Decryptor
            End Get
        End Property

        Protected ReadOnly Property DecryptorSecretKey As System.Security.Cryptography.PasswordDeriveBytes
            Get
                If (m_DecryptorSecretKey) Is Nothing Then
                    m_DecryptorSecretKey = New System.Security.Cryptography.PasswordDeriveBytes(Password, Salt)
                End If
                Return m_DecryptorSecretKey
            End Get
        End Property

        Protected ReadOnly Property Encryptor As System.Security.Cryptography.ICryptoTransform
            Get
                If (m_Encryptor) Is Nothing Then
                    m_Encryptor = RijndaelCipher.CreateEncryptor(EncryptorSecretKey.GetBytes(32), EncryptorSecretKey.GetBytes(16))
                End If
                Return m_Encryptor
            End Get
        End Property

        Protected ReadOnly Property EncryptorSecretKey As System.Security.Cryptography.PasswordDeriveBytes
            Get
                If (m_EncryptorSecretKey) Is Nothing Then
                    m_EncryptorSecretKey = New System.Security.Cryptography.PasswordDeriveBytes(Password, Salt)
                End If
                Return m_EncryptorSecretKey
            End Get
        End Property

        Protected ReadOnly Property Password As String
            Get
                Return m_Password
            End Get
        End Property

        Protected ReadOnly Property RijndaelCipher As System.Security.Cryptography.RijndaelManaged
            Get
                If (m_RijndaelCipher) Is Nothing Then
                    m_RijndaelCipher = New System.Security.Cryptography.RijndaelManaged
                End If
                Return m_RijndaelCipher
            End Get
        End Property

        Protected ReadOnly Property Salt As Byte()
            Get
                If (m_Salt) Is Nothing Then
                    Dim i1 As Integer = Password.Length
                    m_Salt = System.Text.Encoding.ASCII.GetBytes(i1.ToString())
                End If
                Return m_Salt
            End Get
        End Property

        Public Sub New(ByVal password As String)
            m_Password = password
        End Sub

        Public Function Decrypt(ByVal input As String) As String
            Dim s1 As String

            Dim memoryStream1 As System.IO.MemoryStream = Nothing
            Dim cryptoStream1 As System.Security.Cryptography.CryptoStream = Nothing
            Try
                Dim bArr1 As Byte() = System.Convert.FromBase64String(input)
                memoryStream1 = New System.IO.MemoryStream(bArr1)
                cryptoStream1 = New System.Security.Cryptography.CryptoStream(memoryStream1, Decryptor, System.Security.Cryptography.CryptoStreamMode.Read)
                Dim bArr2 As Byte() = New byte(bArr1.Length) {}
                Dim i1 As Integer = cryptoStream1.Read(bArr2, 0, bArr2.Length)
                memoryStream1.Close()
                cryptoStream1.Close()
                s1 = System.Text.Encoding.Unicode.GetString(bArr2, 0, i1)
            Finally
                If Not (cryptoStream1) Is Nothing Then
                    cryptoStream1.Dispose()
                    cryptoStream1 = Nothing
                End If
                If Not (memoryStream1) Is Nothing Then
                    memoryStream1.Dispose()
                    memoryStream1 = Nothing
                End If
            End Try
            Return s1
        End Function

        Sub Dispose() Implements System.IDisposable
            If Not (m_Encryptor) Is Nothing Then
                m_Encryptor.Dispose()
                m_Encryptor = Nothing
            End If
            If Not (m_Decryptor) Is Nothing Then
                m_Decryptor.Dispose()
                m_Decryptor = Nothing
            End If
        End Sub

        Public Function Encrypt(ByVal input As String) As String
            Dim s1 As String

            Dim memoryStream1 As System.IO.MemoryStream = Nothing
            Dim cryptoStream1 As System.Security.Cryptography.CryptoStream = Nothing
            Try
                Dim bArr1 As Byte() = System.Text.Encoding.Unicode.GetBytes(input)
                memoryStream1 = New System.IO.MemoryStream
                cryptoStream1 = New System.Security.Cryptography.CryptoStream(memoryStream1, Encryptor, System.Security.Cryptography.CryptoStreamMode.Write)
                cryptoStream1.Write(bArr1, 0, bArr1.Length)
                cryptoStream1.FlushFinalBlock()
                Dim bArr2 As Byte() = memoryStream1.ToArray()
                memoryStream1.Close()
                cryptoStream1.Close()
                s1 = System.Convert.ToBase64String(bArr2)
            Finally
                If Not (cryptoStream1) Is Nothing Then
                    cryptoStream1.Dispose()
                End If
                If Not (memoryStream1) Is Nothing Then
                    memoryStream1.Dispose()
                End If
            End Try
            Return s1
        End Function

    End Class ' class CryptoUtil

End Namespace

