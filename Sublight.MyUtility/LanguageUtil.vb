Imports System
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices
Imports Sublight
Imports Sublight.Properties
Imports Sublight.WS

Namespace Sublight.MyUtility

    Friend MustInherit Class LanguageUtil

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate1 As System.Comparison(Of Sublight.WS.SubtitleLanguage) 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate3 As System.Comparison(Of Sublight.WS.SubtitleLanguage) 

        Protected Sub New()
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <GetSortedAllLanguages>b__2(ByVal lang1 As Sublight.WS.SubtitleLanguage, ByVal lang2 As Sublight.WS.SubtitleLanguage) As Integer
            Return System.String.Compare(Sublight.Globals.GetString(lang1), Sublight.Globals.GetString(lang2))
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <GetSortedLanguages>b__0(ByVal lang1 As Sublight.WS.SubtitleLanguage, ByVal lang2 As Sublight.WS.SubtitleLanguage) As Integer
            Return System.String.Compare(Sublight.Globals.GetString(lang1), Sublight.Globals.GetString(lang2))
        End Function

        Public Shared Function GetSortedAllLanguages() As Sublight.WS.SubtitleLanguage()
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.SubtitleLanguage)), Sublight.WS.SubtitleLanguage[])
            If (subtitleLanguageArr1) Is Nothing Then
                Return Nothing
            End If
            Dim list1 As System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage) = New System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage)(subtitleLanguageArr1)
            If (Sublight.MyUtility.LanguageUtil.CS$<>9__CachedAnonymousMethodDelegate3) Is Nothing Then
                Sublight.MyUtility.LanguageUtil.CS$<>9__CachedAnonymousMethodDelegate3 = New System.Comparison(Of Sublight.WS.SubtitleLanguage)(Nothing, Sublight.MyUtility.LanguageUtil.<GetSortedAllLanguages>b__2)
            End If
            list1.Sort(Sublight.MyUtility.LanguageUtil.CS$<>9__CachedAnonymousMethodDelegate3)
            Return list1.ToArray()
        End Function

        Public Shared Function GetSortedLanguages() As Sublight.WS.SubtitleLanguage()
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage()

            If Not (Sublight.Properties.Settings.Default.Application_Filter_Language) Is Nothing Then
                subtitleLanguageArr1 = Sublight.Properties.Settings.Default.Application_Filter_Language.ToArray()
            Else 
                subtitleLanguageArr1 = TryCast(System.Enum.GetValues(GetType(Sublight.WS.SubtitleLanguage)), Sublight.WS.SubtitleLanguage[])
            End If
            If (subtitleLanguageArr1) Is Nothing Then
                Return Nothing
            End If
            Dim list1 As System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage) = New System.Collections.Generic.List(Of Sublight.WS.SubtitleLanguage)(subtitleLanguageArr1)
            If (Sublight.MyUtility.LanguageUtil.CS$<>9__CachedAnonymousMethodDelegate1) Is Nothing Then
                Sublight.MyUtility.LanguageUtil.CS$<>9__CachedAnonymousMethodDelegate1 = New System.Comparison(Of Sublight.WS.SubtitleLanguage)(Nothing, Sublight.MyUtility.LanguageUtil.<GetSortedLanguages>b__0)
            End If
            list1.Sort(Sublight.MyUtility.LanguageUtil.CS$<>9__CachedAnonymousMethodDelegate1)
            Return list1.ToArray()
        End Function

    End Class ' class LanguageUtil

End Namespace

