Imports System
Imports System.Collections.Generic
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight

    Public Class AppEvents

        Public Delegate Sub LanguageChangedDelegate(ByVal sender As Object, ByVal language As String)
        Public Delegate Sub SettingsLoadedDelegate(ByVal sender As Object)
        Public Delegate Sub SubtitleDownloadedDelegate(ByVal sender As Object, ByVal subtitleId As System.Guid)
        Public Delegate Sub TabChangedDelegate(ByVal sender As Object)
        Public Delegate Sub UserLogInDelegate(ByVal sender As Object, ByVal isAnonymous As Boolean)
        Public Delegate Sub UserLogOffDelegate(ByVal sender As Object)

        Public Event LanguageChanged As Sublight.AppEvents.LanguageChangedDelegate
        Public Event SettingsLoaded As Sublight.AppEvents.SettingsLoadedDelegate
        Public Event SubtitleDownloaded As Sublight.AppEvents.SubtitleDownloadedDelegate
        Public Event TabChanged As Sublight.AppEvents.TabChangedDelegate
        Public Event UserLogIn As Sublight.AppEvents.UserLogInDelegate
        Public Event UserLogOff As Sublight.AppEvents.UserLogOffDelegate

        Public Sub New()
        End Sub

        Public Sub OnLanguageChanged(ByVal language As String)
            If Not (LanguageChangedEvent) Is Nothing Then
                RaiseEvent LanguageChanged(Me, language)
            End If
        End Sub

        Public Sub OnSettingsLoaded()
            If Not (SettingsLoadedEvent) Is Nothing Then
                RaiseEvent SettingsLoaded(Me)
            End If
        End Sub

        Public Sub OnSubtitleDownloaded(ByVal subtitleId As System.Guid)
            If (Sublight.Properties.Settings.Default.View_MyDownloads) Is Nothing Then
                Sublight.Properties.Settings.Default.View_MyDownloads = New Sublight.Types.DownloadedSubtitleCollection
            End If
            If Not Sublight.Properties.Settings.Default.View_MyDownloads.Contains(subtitleId) Then
                If Sublight.Properties.Settings.Default.View_MyDownloads.get_Count() >= 50 Then
                    Sublight.Properties.Settings.Default.View_MyDownloads.Dequeue()
                End If
                Sublight.Properties.Settings.Default.View_MyDownloads.Enqueue(subtitleId)
            Else 
                Dim list1 As System.Collections.Generic.List(Of System.Guid) = New System.Collections.Generic.List(Of System.Guid)(Sublight.Properties.Settings.Default.View_MyDownloads.get_Count())
                list1.AddRange(Sublight.Properties.Settings.Default.View_MyDownloads.ToArray())
                list1.Remove(subtitleId)
                list1.Add(subtitleId)
                Sublight.Properties.Settings.Default.View_MyDownloads = New Sublight.Types.DownloadedSubtitleCollection
                Dim enumerator1 As System.Collections.Generic.List(Of System.Guid).Enumerator = list1.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim guid1 As System.Guid = enumerator1.get_Current()
                        Sublight.Properties.Settings.Default.View_MyDownloads.Enqueue(guid1)
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
            End If
            Sublight.BaseForm.SaveUserSettingsSilent()
            If Not (SubtitleDownloadedEvent) Is Nothing Then
                RaiseEvent SubtitleDownloaded(Me, subtitleId)
            End If
        End Sub

        Public Sub OnTabChanged()
            If Not (TabChangedEvent) Is Nothing Then
                RaiseEvent TabChanged(Me)
            End If
        End Sub

        Public Sub OnUserLogIn(ByVal isAnonymous As Boolean)
            If Not (UserLogInEvent) Is Nothing Then
                RaiseEvent UserLogIn(Me, isAnonymous)
            End If
        End Sub

        Public Sub OnUserLogOff()
            If Not (UserLogOffEvent) Is Nothing Then
                RaiseEvent UserLogOff(Me)
            End If
        End Sub

    End Class ' class AppEvents

End Namespace

