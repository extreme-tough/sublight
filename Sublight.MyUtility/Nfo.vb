Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Web

Namespace Sublight.MyUtility

    Public NotInheritable Class Nfo

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <IMDB>k__BackingField As String 

        Private Property IMDB As String
            Get
                Return <IMDB>k__BackingField
            End Get
            Set
                <IMDB>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal imdb As String)
            IMDB = imdb
        End Sub

        Public Function GetInfo() As String
            Dim s19 As String

            If System.String.IsNullOrEmpty(IMDB) Then
                Return Nothing
            End If
            Using webClient1 As System.Net.WebClient = New System.Net.WebClient
                Dim i1 As Integer = 0
                While i1 < 3
                    Dim s1 As String = IMDB
                    Try
                        Dim s2 As String = webClient1.DownloadString(s1)
                        s2 = System.Web.HttpUtility.HtmlDecode(s2)
                        Dim dictionary2 As System.Collections.Generic.Dictionary(Of String,String) = New System.Collections.Generic.Dictionary(Of String,String)
                        Dim match1 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s2, "<title>(?<title>.*?)\((?<year>[0-9]*?)[^0-9]*?\)</title>?")
                        If match1.Groups("title?").Success Then
                            dictionary2.set_Item("Title?", match1.Groups("title?").Value.Trim())
                        End If
                        If match1.Groups("year?").Success Then
                            dictionary2.set_Item("Year?", match1.Groups("year?").Value.Trim())
                        End If
                        match1 = System.Text.RegularExpressions.Regex.Match(s2, "<div class=""info"">.*?Runtime:.*?>(?<runtime>.*?)</div>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                        If match1.Groups("runtime?").Success Then
                            dictionary2.set_Item("Runtime?", match1.Groups("runtime?").Value.Trim())
                        End If
                        match1 = System.Text.RegularExpressions.Regex.Match(s2, "<div class=""info"">.*?Language:.*?<a.*?>(?<language>.*?)</a>.*?</div>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                        If match1.Groups("language?").Success Then
                            dictionary2.set_Item("Language?", match1.Groups("language?").Value.Trim())
                        End If
                        match1 = System.Text.RegularExpressions.Regex.Match(s2, "<div class=""info"">.*?Genre:.*?>(?<genres>.*?)</div>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                        If match1.Groups("genres?").Success Then
                            Dim matchCollection1 As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(match1.Groups("genres?").Value, "<a.*?>(?<genre>.*?)</a>?")
                            If matchCollection1.Count > 0 Then
                                Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                                Dim match2 As System.Text.RegularExpressions.Match 
                                For Each match2 In matchCollection1
                                    Dim s3 As String = match2.Groups("genre?").Value.Trim()
                                    If Not System.String.IsNullOrEmpty(s3) AndAlso (System.String.Compare(s3, "more?", True) <> 0) Then
                                        list1.Add(s3)
                                    End If
                                Next
                                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                                Dim i2 As Integer = 0
                                While i2 < list1.get_Count()
                                    stringBuilder1.Append(list1.get_Item(i2))
                                    If i2 < (list1.get_Count() - 1) Then
                                        stringBuilder1.Append(" | ?")
                                    End If
                                    i2 = i2 + 1
                                End While
                                If stringBuilder1.Length > 0 Then
                                    dictionary2.set_Item("Genre?", stringBuilder1.ToString())
                                End If
                            End If
                        End If
                        dictionary2.set_Item("IMDb Link?", s1)
                        match1 = System.Text.RegularExpressions.Regex.Match(s2, "<div class=""info"">.*?User Rating:.*?<div class=""meta"">(?<rating>.*?)</div>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                        If match1.Success Then
                            Dim s4 As String = match1.Groups("rating?").Value
                            match1 = System.Text.RegularExpressions.Regex.Match(s4, "<b>(?<rate>.*?)</b>.*?<a href=""ratings"".*?>(?<votes>.*?)</a>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                            Dim s5 As String = Nothing
                            Dim s6 As String = Nothing
                            If match1.Groups("rate?").Success Then
                                s5 = match1.Groups("rate?").Value.Trim()
                            End If
                            If match1.Groups("votes?").Success Then
                                s6 = match1.Groups("votes?").Value.Trim()
                            End If
                            If Not System.String.IsNullOrEmpty(s5) AndAlso Not System.String.IsNullOrEmpty(s6) Then
                                dictionary2.set_Item("User Rating?", System.String.Format("{0} ({1})?", s5, s6))
                            End If
                        End If
                        match1 = System.Text.RegularExpressions.Regex.Match(s2, "<div class=""info"">.*?Plot:</h5>(?<plot>.*?)</div>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                        Dim s7 As String = Nothing
                        If match1.Groups("plot?").Success Then
                            s7 = match1.Groups("plot?").Value.Trim()
                            Dim i3 As Integer = s7.IndexOf("<a ?")
                            If i3 >= 0 Then
                                s7 = s7.Substring(0, i3).Trim()
                                Dim chArr1 As Char() = New char() { " "C, "|"C }
                                s7 = s7.TrimEnd(chArr1)
                            End If
                        End If
                        Dim dictionary1 As System.Collections.Generic.Dictionary(Of String,String) = New System.Collections.Generic.Dictionary(Of String,String)
                        match1 = System.Text.RegularExpressions.Regex.Match(s2, "<h3>Cast</h3>.*?<div class=""info"">(?<cast>.*?)</div>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                        If match1.Groups("cast?").Success Then
                            Dim s8 As String = match1.Groups("cast?").Value
                            Dim matchCollection2 As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(s8, "<td class=""nm"">(?<actor>.*?)</td>.*?<td class=""char"">(?<character>.*?)</td>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                            Dim match3 As System.Text.RegularExpressions.Match 
                            For Each match3 In matchCollection2
                                Dim s9 As String = match3.Groups("actor?").Value.Trim()
                                If System.Text.RegularExpressions.Regex.IsMatch(s9, "<a.*?>.*?</a>?") Then
                                    match1 = System.Text.RegularExpressions.Regex.Match(s9, "<a.*?>(?<actor>.*?)</a>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                                    If match1.Groups("actor?").Success Then
                                        s9 = match1.Groups("actor?").Value.Trim()
                                    End If
                                End If
                                Dim s10 As String = match3.Groups("character?").Value.Trim()
                                If System.Text.RegularExpressions.Regex.IsMatch(s10, "<a.*?>.*?</a>?") Then
                                    match1 = System.Text.RegularExpressions.Regex.Match(s10, "<a.*?>(?<character>.*?)</a>?", System.Text.RegularExpressions.RegexOptions.Singleline)
                                    If match1.Groups("character?").Success Then
                                        s10 = match1.Groups("character?").Value.Trim()
                                    End If
                                End If
                                dictionary1.set_Item(s9, s10)
                            Next
                        End If
                        Dim i4 As Integer = -1
                        Dim enumerator1 As System.Collections.Generic.Dictionary(Of String,String).KeyCollection.Enumerator = dictionary2.get_Keys().GetEnumerator()
                        Try
                            While enumerator1.MoveNext()
                                Dim s11 As String = enumerator1.get_Current()
                                If s11.Length > i4 Then
                                    i4 = s11.Length
                                End If
                            End While
                        Finally
                            enumerator1.Dispose()
                        End Try
                        Dim stringBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                        stringBuilder2.AppendLine()
                        If i4 > 0 Then
                            stringBuilder2.AppendLine(" O V E R V I E W?")
                            Dim i5 As Integer = i4 + 3
                            If i5 < 19 Then
                                i5 = 19
                            End If
                            Dim enumerator2 As System.Collections.Generic.Dictionary(Of String,String).KeyCollection.Enumerator = dictionary2.get_Keys().GetEnumerator()
                            Try
                                While enumerator2.MoveNext()
                                    Dim s12 As String = enumerator2.get_Current()
                                    stringBuilder2.AppendFormat(" {0}?", s12)
                                    Dim s13 As String = New System.String("."C, i5 - s12.Length)
                                    stringBuilder2.AppendFormat("{0}: {1}?", s13, dictionary2.get_Item(s12))
                                    stringBuilder2.AppendLine()
                                End While
                            Finally
                                enumerator2.Dispose()
                            End Try
                        End If
                        stringBuilder2.AppendLine()
                        i4 = -1
                        Dim enumerator4 As System.Collections.Generic.Dictionary(Of String,String).KeyCollection.Enumerator = dictionary1.get_Keys().GetEnumerator()
                        Try
                            While enumerator4.MoveNext()
                                Dim s14 As String = enumerator4.get_Current()
                                If s14.Length > i4 Then
                                    i4 = s14.Length
                                End If
                            End While
                        Finally
                            enumerator4.Dispose()
                        End Try
                        If i4 > 0 Then
                            stringBuilder2.AppendLine(" C A S T?")
                            Dim i6 As Integer = i4 + 3
                            If i6 < 24 Then
                                i6 = 24
                            End If
                            Dim enumerator3 As System.Collections.Generic.Dictionary(Of String,String).KeyCollection.Enumerator = dictionary1.get_Keys().GetEnumerator()
                            Try
                                While enumerator3.MoveNext()
                                    Dim s15 As String = enumerator3.get_Current()
                                    stringBuilder2.AppendFormat(" {0}?", s15)
                                    Dim s16 As String = New System.String("."C, i6 - s15.Length)
                                    stringBuilder2.AppendFormat("{0} {1}?", s16, dictionary1.get_Item(s15))
                                    stringBuilder2.AppendLine()
                                End While
                            Finally
                                enumerator3.Dispose()
                            End Try
                        End If
                        stringBuilder2.AppendLine()
                        If Not System.String.IsNullOrEmpty(s7) Then
                            stringBuilder2.AppendLine(" P L O T?")
                            Dim chArr2 As Char() = New char() { " "C }
                            Dim sArr1 As String() = s7.Split(chArr2, System.StringSplitOptions.RemoveEmptyEntries)
                            Dim s17 As String = System.String.Empty
                            Dim i7 As Integer = 0
                            While i7 < sArr1.Length
                                Dim s18 As String = System.String.Format("{0} {1}?", s17, sArr1(i7)).Trim()
                                If s18.Length > 60 Then
                                    stringBuilder2.AppendFormat(" {0}?", s17)
                                    stringBuilder2.AppendLine()
                                    s17 = sArr1(i7)
                                Else 
                                    s17 = s18
                                End If
                                i7 = i7 + 1
                            End While
                            If s17.Length > 0 Then
                                stringBuilder2.AppendFormat(" {0}?", s17)
                            End If
                        End If
                        Return stringBuilder2.ToString()
                    Catch 
                        System.Threading.Thread.Sleep(100)
                    End Try
                    i1 = i1 + 1
                End While
                s19 = Nothing
            End Using
            Return s19
        End Function

    End Class ' class Nfo

End Namespace

