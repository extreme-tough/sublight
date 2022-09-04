Imports System
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Properties
Imports Sublight.WS_SublightClient

Namespace Sublight.MyUtility

    Friend Class UpdateChecker

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass2

            Public frm As Sublight.FrmNewVersion 

            Public Sub New()
            End Sub

            Public Sub <CheckThread>b__0()
                frm.ShowDialog(Sublight.Globals.MainForm)
            End Sub

        End Class ' class <>c__DisplayClass2

        Public Sub New()
        End Sub

        Private Shared Sub CheckThread()
            Dim s1 As String
            Dim versionInfo1 As Sublight.WS_SublightClient.VersionInfo

            Try
                System.Threading.Thread.Sleep(5000)
                Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                    If sublightClient1.CheckForUpdates(Sublight.BaseForm.AppVersion, out versionInfo1, out s1) AndAlso (Not (versionInfo1) Is Nothing) Then
                        If versionInfo1.NewVersion = Sublight.Properties.Settings.Default.AutoUpdate_Notification_Ignore Then
                            Return
                        End If
                        Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
                        Dim <>c__DisplayClass2_1 As Sublight.MyUtility.UpdateChecker.<>c__DisplayClass2 = New Sublight.MyUtility.UpdateChecker.<>c__DisplayClass2
                        <>c__DisplayClass2_1.frm = New Sublight.FrmNewVersion(versionInfo1.NewVersion, versionInfo1)
                        Try
                            If (Not (Sublight.Globals.MainForm) Is Nothing) AndAlso Not Sublight.Globals.MainForm.IsDisposed Then
                                If (methodInvoker2) Is Nothing Then
                                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass2_1.<CheckThread>b__0)
                                End If
                                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                                If Sublight.Globals.MainForm.InvokeRequired Then
                                    Sublight.Globals.MainForm.BeginInvoke(methodInvoker1).AsyncWaitHandle.WaitOne()
                                Else 
                                    methodInvoker1.Invoke()
                                End If
                            Else 
                                <>c__DisplayClass2_1.frm.ShowDialog()
                            End If
                        Finally
                            If Not (<>c__DisplayClass2_1.frm) Is Nothing Then
                                <>c__DisplayClass2_1.frm.Dispose()
                            End If
                        End Try
                    End If
                End Using
            Catch e As System.Exception
            End Try
        End Sub

        Public Shared Sub OpenInBrowser(ByVal baseForm As Sublight.BaseForm)
            If (Not (baseForm) Is Nothing) AndAlso Not baseForm.IsDisposed Then
                baseForm.OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl("GetSublight.aspx?"))
            End If
        End Sub

        Public Shared Sub Start()
            Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sublight.MyUtility.UpdateChecker.CheckThread))
            thread1.Start()
        End Sub

    End Class ' class UpdateChecker

End Namespace

