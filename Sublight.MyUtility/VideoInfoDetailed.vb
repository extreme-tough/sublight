Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Threading

Namespace Sublight.MyUtility

    Friend Class VideoInfoDetailed

        Public Delegate Sub ResultHandler(ByVal sender As Object, ByVal info As System.Collections.Generic.Dictionary(Of String,String))

        Private ReadOnly m_Info As System.Collections.Generic.Dictionary(Of String,String) 
        Private ReadOnly m_videoPath As String 

        Public Event Result As Sublight.MyUtility.VideoInfoDetailed.ResultHandler

        Public Sub New(ByVal videoPath As String)
            m_Info = New System.Collections.Generic.Dictionary(Of String,String)
            m_videoPath = videoPath
        End Sub

        Public Sub DoAsync()
            If (ResultEvent) Is Nothing Then
                Return
            End If
            Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ParameterizedThreadStart(Sublight.MyUtility.VideoInfoDetailed.WorkerThread))
            Dim objArr1 As Object() = New object() { _
                                                     m_videoPath, _
                                                     m_Info, _
                                                     Result }
            thread1.Start(objArr1)
        End Sub

        Private Shared Sub WorkerThread(ByVal args As Object)
            Dim objArr1 As Object() = TryCast(args, Object[])
            If ((objArr1) Is Nothing) OrElse (objArr1.Length <> 3) Then
                Return
            End If
            Dim s1 As String = TryCast(objArr1(0), string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            Try
                If Not System.IO.File.Exists(s1) Then
                    GoTo label_1
                End If
            Catch 
                GoTo label_1
            End Try
            Dim dictionary1 As System.Collections.Generic.Dictionary(Of String,String) = TryCast(objArr1(1), System.Collections.Generic.Dictionary(Of String,String)[])
            If (dictionary1) Is Nothing Then
            label_1: _
                Return
            End If
            Dim resultHandler1 As Sublight.MyUtility.VideoInfoDetailed.ResultHandler = TryCast(objArr1(2), Sublight.MyUtility.VideoInfoDetailed.ResultHandler)
            If (resultHandler1) Is Nothing Then
                Return
            End If
            Dim processModule1 As System.Diagnostics.ProcessModule = System.Diagnostics.Process.GetCurrentProcess().MainModule
            If Not (processModule1) Is Nothing Then
                Dim directoryInfo1 As System.IO.DirectoryInfo = (New System.IO.FileInfo(processModule1.FileName)).Directory
                If Not (directoryInfo1) Is Nothing Then
                    Dim s2 As String = System.IO.Path.Combine(directoryInfo1.FullName, "MediaInfoCmd.exe?")
                    If Not System.IO.File.Exists(s2) Then
                        Return
                    End If
                End If
            End If
            Dim processStartInfo1 As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo("MediaInfoCmd.exe?", System.String.Format("DetailedInfo ""{0}""?", s1))
            processStartInfo1.CreateNoWindow = True
            processStartInfo1.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            processStartInfo1.UseShellExecute = False
            processStartInfo1.RedirectStandardOutput = True
            Dim process1 As System.Diagnostics.Process = System.Diagnostics.Process.Start(processStartInfo1)
            If Not (process1) Is Nothing Then
                Dim s3 As String = process1.StandardOutput.ReadToEnd()
                If System.String.IsNullOrEmpty(s3) Then
                    Return
                End If
                Using stringReader1 As System.IO.StringReader = New System.IO.StringReader(s3)
                label_2: _
                    While True
                        Dim s4 As String = stringReader1.ReadLine()
                        If Not (s4) Is Nothing Then
                            Dim i1 As Integer = s4.IndexOf(":"C)
                            If i1 < 0 Then
                                GoTo label_2
                            End If
                            Dim s5 As String = s4.Substring(0, i1)
                            Dim s6 As String = s4.Substring(i1 + 1).Trim()
                            If System.String.IsNullOrEmpty(s5) Then
                                GoTo label_2
                            End If
                            dictionary1.set_Item(s5, s6)
                        End If
                    End While
                End Using
                RaiseEvent resultHandler1(Nothing, dictionary1)
            End If
        End Sub

    End Class ' class VideoInfoDetailed

End Namespace

