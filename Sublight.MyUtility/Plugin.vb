Imports System
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Plugins.SubtitleProvider
Imports Sublight.Properties
Imports Sublight.WS

Namespace Sublight.MyUtility

    Friend Class Plugin

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass2

            Public ctrl As System.Windows.Forms.Control 
            Public password As String 
            Public username As String 

            Public Sub New()
            End Sub

            Public Sub <GetPodnapisiNetDownloadIdWithCredentials>b__0()
                Using frmPodnapisiNetLogin1 As Sublight.FrmPodnapisiNetLogin = New Sublight.FrmPodnapisiNetLogin(Sublight.FrmPodnapisiNetLogin.ActionType.SubtitleDownload)
                    Dim dialogResult1 As System.Windows.Forms.DialogResult = frmPodnapisiNetLogin1.ShowDialog(ctrl)
                    If (dialogResult1 = System.Windows.Forms.DialogResult.OK) AndAlso Not frmPodnapisiNetLogin1.LoginUsernamePasswordEmpty Then
                        username = frmPodnapisiNetLogin1.LoginUsername
                        password = frmPodnapisiNetLogin1.LoginPassword
                    Else 
                        username = System.String.Empty
                        password = System.String.Empty
                    End If
                End Using
            End Sub

        End Class ' class <>c__DisplayClass2

        Public Sub New()
        End Sub

        Friend Shared Function DownloadSubtitleById(ByVal ctrl As System.Windows.Forms.Control, ByVal subtitleProvider As Sublight.Plugins.SubtitleProvider.ISubtitleProvider, ByVal subtitle As Sublight.WS.Subtitle) As Byte()
            Return subtitleProvider.DownloadById(Sublight.MyUtility.Plugin.GetDownloadId(ctrl, subtitleProvider, subtitle))
        End Function

        Friend Shared Function GetDownloadId(ByVal ctrl As System.Windows.Forms.Control, ByVal subtitleProvider As Sublight.Plugins.SubtitleProvider.ISubtitleProvider, ByVal subtitle As Sublight.WS.Subtitle) As String
            If subtitleProvider.ShortName = "Podnapisi.NET?" Then
                Return Sublight.MyUtility.Plugin.GetPodnapisiNetDownloadIdWithCredentials(ctrl, subtitle.ExternalId)
            End If
            Return subtitle.ExternalId
        End Function

        Friend Shared Function GetPodnapisiNetDownloadIdWithCredentials(ByVal ctrl As System.Windows.Forms.Control, ByVal downloadId As String) As String
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            Dim <>c__DisplayClass2_1 As Sublight.MyUtility.Plugin.<>c__DisplayClass2 = New Sublight.MyUtility.Plugin.<>c__DisplayClass2
            <>c__DisplayClass2_1.ctrl = ctrl
            <>c__DisplayClass2_1.username = Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Username
            <>c__DisplayClass2_1.password = Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password
            If System.String.IsNullOrEmpty(<>c__DisplayClass2_1.username) OrElse System.String.IsNullOrEmpty(<>c__DisplayClass2_1.password) Then
                If (methodInvoker2) Is Nothing Then
                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass2_1.<GetPodnapisiNetDownloadIdWithCredentials>b__0)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                If <>c__DisplayClass2_1.ctrl.InvokeRequired Then
                    Dim objArr1 As Object() = New object(2) {}
                    objArr1(0) = <>c__DisplayClass2_1.ctrl
                    Dim objArr2 As Object() = New object(1) {}
                    objArr1(1) = objArr2
                    Dim iasyncResult1 As System.IAsyncResult = <>c__DisplayClass2_1.ctrl.BeginInvoke(methodInvoker1, objArr1)
                    iasyncResult1.AsyncWaitHandle.WaitOne()
                Else 
                    methodInvoker1.Invoke()
                End If
            End If
            If Sublight.MyUtility.Encryption.IsPasswordEncrypted(<>c__DisplayClass2_1.password) Then
                <>c__DisplayClass2_1.password = Sublight.MyUtility.Encryption.DecryptPassword(<>c__DisplayClass2_1.password)
            End If
            downloadId = System.String.Format("{0};{1};{2}?", downloadId, <>c__DisplayClass2_1.username, <>c__DisplayClass2_1.password)
            Return downloadId
        End Function

    End Class ' class Plugin

End Namespace

