Imports System
Imports Microsoft.Win32

Namespace Sublight.MyUtility.Explorer

    Public NotInheritable Class ContextMenu

        Public Sub New()
        End Sub

        Private Shared Function GetSystemChoice(ByVal fileType As String) As String
            Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(fileType)
            If Not (registryKey1) Is Nothing Then
                Dim s1 As String = TryCast(registryKey1.GetValue(Nothing), string)
                registryKey1.Close()
                Return s1
            End If
            Return Nothing
        End Function

        Private Shared Function GetUserChoice(ByVal fileType As String) As String
            Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(System.String.Format("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\{0}\UserChoice?", fileType))
            If (registryKey1) Is Nothing Then
                Return Nothing
            End If
            Dim s1 As String = TryCast(registryKey1.GetValue("Progid?"), string)
            registryKey1.Close()
            Return s1
        End Function

        Public Shared Function IsRegistered(ByVal fileType As String, ByVal shellKeyName As String) As Boolean
            Dim s1 As String = Sublight.MyUtility.Explorer.ContextMenu.GetUserChoice(fileType)
            If Not System.String.IsNullOrEmpty(s1) Then
                Return Sublight.MyUtility.Explorer.ContextMenu.IsShellCommandRegistered(s1, shellKeyName)
            End If
            s1 = Sublight.MyUtility.Explorer.ContextMenu.GetSystemChoice(fileType)
            If System.String.IsNullOrEmpty(s1) Then
                Return False
            End If
            Return Sublight.MyUtility.Explorer.ContextMenu.IsShellCommandRegistered(s1, shellKeyName)
        End Function

        Public Shared Function IsRegisteredFolder(ByVal shellKeyName As String) As Boolean
            Return Sublight.MyUtility.Explorer.ContextMenu.IsShellCommandRegistered("Folder?", shellKeyName)
        End Function

        Private Shared Function IsShellCommandRegistered(ByVal prodId As String, ByVal shellKeyName As String) As Boolean
            Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(System.String.Format("{0}\shell\{1}?", prodId, shellKeyName))
            If Not (registryKey1) Is Nothing Then
                registryKey1.Close()
                Return True
            End If
            Return False
        End Function

        Public Shared Sub Register(ByVal fileType As String, ByVal shellKeyName As String, ByVal menuText As String, ByVal menuCommand As String)
            Dim s1 As String = Sublight.MyUtility.Explorer.ContextMenu.GetUserChoice(fileType)
            If Not System.String.IsNullOrEmpty(s1) Then
                Sublight.MyUtility.Explorer.ContextMenu.RegisterShellCommand(s1, shellKeyName, menuText, menuCommand)
            End If
            s1 = Sublight.MyUtility.Explorer.ContextMenu.GetSystemChoice(fileType)
            If Not System.String.IsNullOrEmpty(s1) Then
                Sublight.MyUtility.Explorer.ContextMenu.RegisterShellCommand(s1, shellKeyName, menuText, menuCommand)
            End If
        End Sub

        Public Shared Sub RegisterFolder(ByVal shellKeyName As String, ByVal menuText As String, ByVal menuCommand As String)
            Sublight.MyUtility.Explorer.ContextMenu.RegisterShellCommand("Folder?", shellKeyName, menuText, menuCommand)
        End Sub

        Private Shared Sub RegisterShellCommand(ByVal prodId As String, ByVal shellKeyName As String, ByVal menuText As String, ByVal menuCommand As String)
            Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(System.String.Format("{0}\shell\{1}?", prodId, shellKeyName))
            If Not (registryKey1) Is Nothing Then
                registryKey1.SetValue(Nothing, menuText)
                Dim registryKey2 As Microsoft.Win32.RegistryKey = registryKey1.CreateSubKey("command?")
                If Not (registryKey2) Is Nothing Then
                    registryKey2.SetValue(Nothing, menuCommand)
                    registryKey2.Close()
                End If
                registryKey1.Close()
            End If
        End Sub

        Public Shared Sub Unregister(ByVal fileType As String, ByVal shellKeyName As String)
            Dim s1 As String = Sublight.MyUtility.Explorer.ContextMenu.GetUserChoice(fileType)
            If Not System.String.IsNullOrEmpty(s1) Then
                Sublight.MyUtility.Explorer.ContextMenu.UnregisterShellCommand(s1, shellKeyName)
            End If
            s1 = Sublight.MyUtility.Explorer.ContextMenu.GetSystemChoice(fileType)
            If Not System.String.IsNullOrEmpty(s1) Then
                Sublight.MyUtility.Explorer.ContextMenu.UnregisterShellCommand(s1, shellKeyName)
            End If
        End Sub

        Public Shared Sub UnregisterFolder(ByVal shellKeyName As String)
            Sublight.MyUtility.Explorer.ContextMenu.UnregisterShellCommand("Folder?", shellKeyName)
        End Sub

        Private Shared Sub UnregisterShellCommand(ByVal progId As String, ByVal shellKeyName As String)
            Dim registryKey1 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(System.String.Format("{0}\shell\{1}?", progId, shellKeyName))
            If (registryKey1) Is Nothing Then
                Return
            End If
            registryKey1.Close()
            Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(System.String.Format("{0}\shell\{1}?", progId, shellKeyName))
        End Sub

    End Class ' class ContextMenu

End Namespace

