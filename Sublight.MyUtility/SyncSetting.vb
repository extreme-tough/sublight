Imports System
Imports System.Configuration
Imports Sublight
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.MyUtility

    Friend MustInherit Class SyncSetting

        Protected Sub New()
        End Sub

        Public Shared Sub Do()
            Dim flag1 As Boolean = False
            If CInt(Sublight.Properties.Settings.Default.SyncSetting) < 1 Then
                Sublight.Properties.Settings.Default.SyncSetting = CLng(1)
                flag1 = True
                Dim s1 As String = Sublight.MyUtility.SyncSetting.GetValue("SemiAutomaticSearchIgnoreWords?")
                If s1 <> Sublight.Properties.Settings.Default.SemiAutomaticSearchIgnoreWords Then
                    Sublight.Properties.Settings.Default.SemiAutomaticSearchIgnoreWords = s1
                End If
                If Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage <> Sublight.Types.SecondarySubtitleProvider.UseNewer Then
                    Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseAlways
                End If
            End If
            If flag1 Then
                Sublight.BaseForm.SaveUserSettingsSilent()
            End If
        End Sub

        Private Shared Function GetValue(ByVal name As String) As String
            Dim s1 As String

            Try
                If System.String.IsNullOrEmpty(name) Then
                    Return Nothing
                End If
                Dim configuration1 As System.Configuration.Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None)
                Dim userSettingsGroup1 As System.Configuration.UserSettingsGroup = TryCast(configuration1.GetSectionGroup("userSettings?"), System.Configuration.UserSettingsGroup)
                If (userSettingsGroup1) Is Nothing Then
                    Return Nothing
                End If
                Dim configurationSection1 As System.Configuration.ConfigurationSection = userSettingsGroup1.Sections("WinUI.Properties.Settings?")
                If (configurationSection1) Is Nothing Then
                    Return Nothing
                End If
                Dim propertyInformation1 As System.Configuration.PropertyInformation 
                For Each propertyInformation1 In configurationSection1.ElementInformation.Properties
                    If propertyInformation1.Name = System.String.Empty Then
                        Dim settingElementCollection1 As System.Configuration.SettingElementCollection = TryCast(propertyInformation1.Value, System.Configuration.SettingElementCollection)
                        If Not (settingElementCollection1) Is Nothing Then
                            Dim settingElement1 As System.Configuration.SettingElement = settingElementCollection1.Get(name)
                            If (settingElement1) Is Nothing Then
                                Return Nothing
                            End If
                            If (settingElement1.Value) Is Nothing Then
                                Return Nothing
                            End If
                            If (settingElement1.Value.ValueXml) Is Nothing Then
                                Return Nothing
                            End If
                            Return settingElement1.Value.ValueXml.InnerText
                        End If
                    End If
                Next
                s1 = Nothing
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

    End Class ' class SyncSetting

End Namespace

