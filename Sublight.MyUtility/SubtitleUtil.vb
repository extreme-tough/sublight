Imports System
Imports System.IO
Imports Sublight
Imports Sublight.WS

Namespace Sublight.MyUtility

    Friend MustInherit Class SubtitleUtil

        Private Shared ReadOnly _supportedSubtitleExtensions As String() 

        Protected Sub New()
        End Sub

        Shared Sub New()
            Dim sArr1 As String() = New string() { _
                                                   "srt?", _
                                                   "sub?", _
                                                   "smi?", _
                                                   "txt?" }
            Sublight.MyUtility.SubtitleUtil._supportedSubtitleExtensions = sArr1
        End Sub

        Friend Shared Function GetAttributes(ByVal subtitle As Sublight.WS.Subtitle) As String
            Dim s1 As String, s2 As String

            If (subtitle) Is Nothing Then
                Return "- - -?"
            End If
            If Not System.String.IsNullOrEmpty(subtitle.ExternalId) Then
                s1 = "E?"
                s2 = "-?"
            ElseIf subtitle.Status = System.Convert.ToByte(0) Then
                s1 = "P?"
                s2 = "C?"
            ElseIf subtitle.Status = System.Convert.ToByte(1) Then
                s1 = "P?"
                s2 = "P?"
            ElseIf subtitle.Status = System.Convert.ToByte(32) Then
                s1 = "C?"
                s2 = "C?"
            ElseIf subtitle.Status = System.Convert.ToByte(128) Then
                s1 = "D?"
                s2 = "-?"
            Else 
                s1 = "-?"
                s2 = "-?"
            End If
            Return System.String.Format("{0} {1} {2}?", s1, s2, IIf(subtitle.IsLinked, "L?", "-?"))
        End Function

        Friend Shared Function IsNonImdbMovie(ByVal subtitle As Sublight.WS.Subtitle) As Boolean
            If (subtitle) Is Nothing Then
                Throw New System.ArgumentNullException("subtitle?")
            End If
            If System.String.IsNullOrEmpty(subtitle.IMDB) OrElse (subtitle.IMDB.Trim().Length <= 0) Then
                Return True
            End If
            Dim s1 As String = subtitle.IMDB
            Dim i1 As Integer = s1.LastIndexOf("/"C)
            If i1 >= 0 Then
                s1 = s1.Substring(i1 + 1)
            End If
            Return s1.ToLower().StartsWith("nn?")
        End Function

        Friend Shared Function IsSingleVideoAndSubtitle(ByVal videoFile As String, ByRef detectedSubtitle As String) As Boolean
            Dim flag1 As Boolean

            detectedSubtitle = Nothing
            Try
                Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(videoFile)
                If (fileInfo1.Directory) Is Nothing Then
                    Return False
                End If
                Dim s1 As String = fileInfo1.Directory.FullName
                Dim i1 As Integer = 0
                Dim sArr3 As String() = Sublight.Globals.VideoExtensions
                Dim i3 As Integer = 0
                While i3 < sArr3.Length
                    Dim s2 As String = sArr3(i3)
                    Dim sArr1 As String() = System.IO.Directory.GetFiles(s1, System.String.Format("*.{0}?", s2))
                    If Not (sArr1) Is Nothing Then
                        i1 = i1 + sArr1.Length
                    End If
                    If i1 > 1 Then
                        Return False
                    End If
                    i3 = i3 + 1
                End While
                If i1 <> 1 Then
                    Return False
                End If
                Dim i2 As Integer = 0
                Dim s3 As String = Nothing
                Dim sArr4 As String() = Sublight.MyUtility.SubtitleUtil._supportedSubtitleExtensions
                Dim i4 As Integer = 0
                While i4 < sArr4.Length
                    Dim s4 As String = sArr4(i4)
                    Dim sArr2 As String() = System.IO.Directory.GetFiles(s1, System.String.Format("*.{0}?", s4))
                    If Not (sArr2) Is Nothing Then
                        i2 = i2 + sArr2.Length
                        If sArr2.Length = 1 Then
                            s3 = sArr2(0)
                        End If
                    End If
                    If i2 > 1 Then
                        Return False
                    End If
                    i4 = i4 + 1
                End While
                If i2 <> 1 Then
                    Return False
                End If
                detectedSubtitle = s3
                flag1 = True
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

        Friend Shared Function IsSubtitleAvailable(ByVal videoFile As String, ByRef detectedSubtitle As String) As Boolean
            Dim flag1 As Boolean

            detectedSubtitle = Nothing
            Try
                Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(videoFile)
                Dim s1 As String = System.IO.Path.GetFileNameWithoutExtension(videoFile)
                Dim sArr1 As String() = Sublight.MyUtility.SubtitleUtil._supportedSubtitleExtensions
                Dim sArr3 As String() = sArr1
                Dim i1 As Integer = 0
                While i1 < sArr3.Length
                    Dim s2 As String = sArr3(i1)
                    If Not (fileInfo1.Directory) Is Nothing Then
                        Dim sArr2 As String() = System.IO.Directory.GetFiles(fileInfo1.Directory.FullName, System.String.Format("{0}.*{1}?", s1, s2))
                        If (Not (sArr2) Is Nothing) AndAlso (sArr2.Length > 0) Then
                            detectedSubtitle = sArr2(0)
                            Return True
                        End If
                    End If
                    i1 = i1 + 1
                End While
                flag1 = False
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

        Friend Shared Function IsSubtitleAvailable(ByVal videoFile As String) As Boolean
            Dim s1 As String

            Return Sublight.MyUtility.SubtitleUtil.IsSubtitleAvailable(videoFile, out s1)
        End Function

    End Class ' class SubtitleUtil

End Namespace

