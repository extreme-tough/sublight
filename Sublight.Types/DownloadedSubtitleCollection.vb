Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Configuration
Imports System.Globalization
Imports System.Text

Namespace Sublight.Types

    <System.Serializable, _
    System.Configuration.SettingsSerializeAs(System.Configuration.SettingsSerializeAs.String), _
    System.ComponentModel.TypeConverter(GetType(Sublight.Types.DownloadedSubtitleCollection.MySettingTypeConverter))> _
    Public Class DownloadedSubtitleCollection

        Public Class MySettingTypeConverter
            Inherits System.ComponentModel.TypeConverter

            Public Sub New()
            End Sub

            Public Overrides Function CanConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal sourceType As System.Type) As Boolean
                If sourceType = GetType(string) Then
                    Return True
                End If
                Return MyBase.CanConvertFrom(context, sourceType)
            End Function

            Public Overrides Function ConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
                If value.GetType() = GetType(string) Then
                    Dim s1 As String = TryCast(value, string)
                    If System.String.IsNullOrEmpty(s1) Then
                        Return Nothing
                    End If
                    Dim chArr1 As Char() = New char() { ";"C }
                    Dim sArr1 As String() = s1.Split(chArr1, System.StringSplitOptions.RemoveEmptyEntries)
                    If (sArr1) Is Nothing Then
                        Return Nothing
                    End If
                    Dim downloadedSubtitleCollection1 As Sublight.Types.DownloadedSubtitleCollection = New Sublight.Types.DownloadedSubtitleCollection
                    Dim sArr2 As String() = sArr1
                    Dim i1 As Integer = 0
                    While i1 < sArr2.Length
                        Dim s2 As String = sArr2(i1)
                        downloadedSubtitleCollection1.Enqueue(New System.Guid(s2))
                        i1 = i1 + 1
                    End While
                    Return downloadedSubtitleCollection1
                End If
                Return MyBase.ConvertFrom(context, culture, value)
            End Function

            Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
                If destinationType = GetType(string) Then
                    Dim downloadedSubtitleCollection1 As Sublight.Types.DownloadedSubtitleCollection = TryCast(value, Sublight.Types.DownloadedSubtitleCollection)
                    If (downloadedSubtitleCollection1) Is Nothing Then
                        Return Nothing
                    End If
                    Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                    Dim enumerator1 As System.Collections.Generic.Queue(Of System.Guid).Enumerator = downloadedSubtitleCollection1.GetEnumerator()
                    Try
                        While enumerator1.MoveNext()
                            Dim guid1 As System.Guid = enumerator1.get_Current()
                            stringBuilder1.AppendFormat("{0};?", guid1)
                        End While
                    Finally
                        enumerator1.Dispose()
                    End Try
                    Return stringBuilder1.ToString()
                End If
                Return MyBase.ConvertTo(context, culture, value, destinationType)
            End Function

        End Class ' class MySettingTypeConverter

        Public Sub New()
        End Sub

    End Class ' class DownloadedSubtitleCollection

End Namespace

