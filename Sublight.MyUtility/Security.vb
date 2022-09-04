Imports System
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Text
Imports System.Threading
Imports Microsoft.Win32

Namespace Sublight.MyUtility

    Friend MustInherit NotInheritable Class Security

        Private MustInherit NotInheritable Class OsUtility

            Public Shared ReadOnly Property IsVistaOrNewer As Boolean
                Get
                    Return System.Environment.OSVersion.Version.Major >= 6
                End Get
            End Property

            Public Shared ReadOnly Property VistaVersion As System.Version
                Get
                    Return New System.Version(6, 0)
                End Get
            End Property

        End Class ' class OsUtility

        Private Shared ReadOnly isAdmin As Boolean 

        Public Shared ReadOnly Property CanElevateToAdministrator As Boolean
            Get
                If Sublight.MyUtility.Security.OsUtility.IsVistaOrNewer AndAlso Not Sublight.MyUtility.Security.IsAdministrator Then
                    Return Sublight.MyUtility.Security.IsUacEnabled
                End If
                Return False
            End Get
        End Property

        Public Shared ReadOnly Property CanLaunchNonAdminProcess As Boolean
            Get
                If Not Sublight.MyUtility.Security.IsAdministrator Then
                    Return True
                End If
                If Sublight.MyUtility.Security.OsUtility.IsVistaOrNewer Then
                    Return Sublight.MyUtility.Security.IsUacEnabled
                End If
                Return False
            End Get
        End Property

        Public Shared ReadOnly Property IsAdministrator As Boolean
            Get
                Return Sublight.MyUtility.Security.isAdmin
            End Get
        End Property

        Private Shared ReadOnly Property IsUacEnabled As Boolean
            Get
                Dim flag1 As Boolean = False
                Try
                    If System.Environment.OSVersion.Version >= Sublight.MyUtility.Security.OsUtility.VistaVersion Then
                        Using registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System?", False)
                            If Not (registryKey1) Is Nothing Then
                                Dim registryValueKind1 As Microsoft.Win32.RegistryValueKind = registryKey1.GetValueKind("EnableLUA?")
                                If registryValueKind1 = Microsoft.Win32.RegistryValueKind.DWord Then
                                    Dim i1 As Integer = DirectCast(registryKey1.GetValue("EnableLUA?"), int)
                                    flag1 = i1 = 1
                                End If
                            End If
                        End Using
                    End If
                Catch e As System.Exception
                    flag1 = False
                End Try
                Return flag1
            End Get
        End Property

        Shared Sub New()
            Sublight.MyUtility.Security.isAdmin = Sublight.MyUtility.Security.IsUserAdministrator()
        End Sub

        Friend Shared Function GetApiKey() As String
            Dim guid1 As System.Guid = System.Guid.NewGuid()
            Dim s1 As String = guid1.ToString("N?")
            Dim s2 As String = "Sublight?" + s1
            Return Sublight.MyUtility.Security.ToHash(s2) + s1
        End Function

        Private Shared Function IsUserAdministrator() As Boolean
            Dim appDomain1 As System.AppDomain = System.Threading.Thread.GetDomain()
            appDomain1.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal)
            Dim windowsPrincipal1 As System.Security.Principal.WindowsPrincipal = CType(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
            Return windowsPrincipal1.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator)
        End Function

        Friend Shared Function ToHash(ByVal input As String) As String
            If (input) Is Nothing Then
                Return Nothing
            End If
            Dim md5_1 As System.Security.Cryptography.MD5 = New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim bArr1 As Byte() = md5_1.ComputeHash(System.Text.Encoding.Unicode.GetBytes(input))
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim bArr2 As Byte() = bArr1
            Dim i1 As Integer = 0
            While i1 < bArr2.Length
                Dim b1 As Byte = bArr2(i1)
                stringBuilder1.Append(b1.ToString("x2?"))
                i1 = i1 + 1
            End While
            Return stringBuilder1.ToString()
        End Function

    End Class ' class Security

End Namespace

