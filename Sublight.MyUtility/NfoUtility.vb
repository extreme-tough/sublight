Imports System
Imports System.IO
Imports System.Text.RegularExpressions
Imports Sublight
Imports Sublight.Lib.IMDB
Imports Sublight.WS

Namespace Sublight.MyUtility

    Friend NotInheritable Class NfoUtility

        Public Sub New()
        End Sub

        Public Shared Function GetImdb(ByVal filePath As String) As String
            Dim s4 As String

            Try
                Dim s1 As String = System.IO.File.ReadAllText(filePath)
                Dim matchCollection1 As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(s1, "http://(www.){0,1}imdb.com/title/(?<id>.*?)(\s|$$)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If matchCollection1.Count <= 0 Then
                    Return Nothing
                End If
                Dim s2 As String = Nothing
                Dim match1 As System.Text.RegularExpressions.Match 
                For Each match1 In matchCollection1
                    If match1.Success Then
                        Dim s3 As String = match1.Groups("id?").Value
                        If Not System.String.IsNullOrEmpty(s3) Then
                            Dim chArr1 As Char() = New char() { "/"C, " "C }
                            s3 = s3.Trim(chArr1)
                            If (s2) Is Nothing Then
                                s2 = s3
                                Continue
                            End If
                            If s2 <> s3 Then
                                Return Nothing
                            End If
                        End If
                    End If
                Next
                If Not System.String.IsNullOrEmpty(s2) Then
                    Return s2
                End If
                s4 = Nothing
            Catch 
                s4 = Nothing
            End Try
            Return s4
        End Function

        Public Shared Function GetImdbDetails(ByVal filePath As String) As Sublight.WS.IMDB
            Dim s4 As String
            Dim alternativeTitleArr1 As Sublight.WS.AlternativeTitle()
            Dim imdb1 As Sublight.WS.IMDB, imdb2 As Sublight.WS.IMDB

            Try
                Dim s1 As String = System.IO.File.ReadAllText(filePath)
                Dim matchCollection1 As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(s1, "http://(www.){0,1}imdb.com/title/(?<id>.*?)(\s|$$)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If matchCollection1.Count <= 0 Then
                    Return Nothing
                End If
                Dim s2 As String = Nothing
                Dim match1 As System.Text.RegularExpressions.Match 
                For Each match1 In matchCollection1
                    If match1.Success Then
                        Dim s3 As String = match1.Groups("id?").Value
                        If Not System.String.IsNullOrEmpty(s3) Then
                            Dim chArr1 As Char() = New char() { "/"C, " "C }
                            s3 = s3.Trim(chArr1)
                            If (s2) Is Nothing Then
                                s2 = s3
                                Continue
                            End If
                            If s2 <> s3 Then
                                Return Nothing
                            End If
                        End If
                    End If
                Next
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    If sublight1.GetDetails(Sublight.BaseForm.Session, s2, out imdb1, out alternativeTitleArr1, out s4) AndAlso (Not (imdb1) Is Nothing) Then
                        Return imdb1
                    End If
                    Dim s5 As String = Sublight.Lib.IMDB.Nfo.GetTitle(System.String.Format("http://www.imdb.com/title/{0}?", s2))
                    If Not System.String.IsNullOrEmpty(s5) Then
                        imdb1 = New Sublight.WS.IMDB
                        imdb1.Id = s2
                        imdb1.Title = s5
                        Return imdb1
                    End If
                    Return Nothing
                End Using
            Catch e As System.Exception
                imdb2 = Nothing
            End Try
            Return imdb2
        End Function

        Public Shared Function GetNfoPath(ByVal videoPath As String) As String
            Dim s1 As String

            Try
                If Not System.IO.File.Exists(videoPath) Then
                    Return Nothing
                End If
                Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(videoPath)
                If (fileInfo1.Directory) Is Nothing Then
                    Return Nothing
                End If
                Dim sArr1 As String() = System.IO.Directory.GetFiles(fileInfo1.Directory.FullName, "*.nfo?", System.IO.SearchOption.TopDirectoryOnly)
                If ((sArr1) Is Nothing) OrElse (sArr1.Length <> 1) Then
                    Return Nothing
                End If
                s1 = sArr1(0)
            Catch 
                s1 = Nothing
            End Try
            Return s1
        End Function

    End Class ' class NfoUtility

End Namespace

