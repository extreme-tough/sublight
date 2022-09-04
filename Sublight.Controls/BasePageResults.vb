Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.Serialization
Imports Elegant.Ui
Imports ICSharpCode.SharpZipLib.Zip
Imports Sublight
Imports Sublight.MyUtility
Imports Sublight.Plugins.SubtitleProvider
Imports Sublight.Plugins.SubtitleProvider.Types
Imports Sublight.Properties
Imports Sublight.SubtitleEditor
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight.Controls

    Friend Class BasePageResults
        Inherits Sublight.Controls.BasePage

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass1

            Public <>4__this As Sublight.Controls.BasePageResults 
            Public que As Short 

            Public Sub New()
            End Sub

        End Class ' class <>c__DisplayClass1

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass3

            Public dr As System.Windows.Forms.DialogResult 

            Public Sub New()
            End Sub

        End Class ' class <>c__DisplayClass3

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass5

            Public CS$<>8__locals2 As Sublight.Controls.BasePageResults.<>c__DisplayClass1 
            Public CS$<>8__locals4 As Sublight.Controls.BasePageResults.<>c__DisplayClass3 
            Public d As Double 

            Public Sub New()
            End Sub

            Public Sub <wsh_DoCall>b__0()
                Using frmDownload1 As Sublight.FrmDownload = New Sublight.FrmDownload(CS$<>8__locals2.que, d)
                    CS$<>8__locals4.dr = frmDownload1.ShowDialog(CS$<>8__locals2.<>4__this)
                End Using
            End Sub

        End Class ' class <>c__DisplayClass5

        Private Const ERR_DOWNLOAD_DENIED As String  = "Download denied"

        Private ReadOnly parent As Sublight.BaseForm 

        Private m_downloadedFiles As System.Collections.Generic.List(Of String) 
        Private m_EditSubtitle As Sublight.WS.Subtitle 

        Protected ReadOnly Property DisplayImageTooltips As Boolean
            Get
                Return False
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal rtp As Elegant.Ui.RibbonTabPage)
            Me.parent = parent
        End Sub

        Private Sub New()
        End Sub

        Protected Sub AddForDeletion(ByVal subtitlesPaths As String())
            If (m_downloadedFiles) Is Nothing Then
                m_downloadedFiles = New System.Collections.Generic.List(Of String)
            End If
            If (Not (subtitlesPaths) Is Nothing) AndAlso (subtitlesPaths.Length > 0) Then
                m_downloadedFiles.AddRange(subtitlesPaths)
            End If
        End Sub

        Protected Sub DeleteDownloadedSubtitles()
            If Not (m_downloadedFiles) Is Nothing Then
                Dim enumerator1 As System.Collections.Generic.List(Of String).Enumerator = m_downloadedFiles.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim s1 As String = enumerator1.get_Current()
                        If System.IO.File.Exists(s1) Then
                            Try
                                System.IO.File.Delete(s1)
                            Catch 
                            End Try
                        End If
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
                m_downloadedFiles.Clear()
                Return
            End If
            m_downloadedFiles = New System.Collections.Generic.List(Of String)
        End Sub

        Private Sub DisplayError(ByVal error As String, ByVal subtitlesPaths As String())
            Sublight.BaseForm.ReportError("Sublight.Controls.BasePageResults.OnDownload?", error)
            AddForDeletion(subtitlesPaths)
            If System.String.IsNullOrEmpty(error) Then
                ParentBaseForm.ShowError(Sublight.Translation.Search_Error_DownloadDecompressSave_ErrorDownloading, New object(0) {})
                Return
            End If
            ParentBaseForm.ShowError(System.String.Format(Sublight.Translation.Search_Error_DownloadDecompressSave_ErrorDownloadingDetails, error), New object(0) {})
        End Sub

        Protected Function DownloadDecompressSave(ByVal list As Sublight.Controls.MySuperList, ByVal subtitleProvider As Sublight.Plugins.SubtitleProvider.ISubtitleProvider, ByVal playVideo As Boolean, ByVal videoPath As String, ByVal subtitle As Sublight.WS.Subtitle, ByVal outputPath2 As String, ByVal videoFile As String, ByVal languageGroupIndex As Integer, ByVal isVideoFileMandatory As Boolean, ByVal multipleDownloads As Boolean, ByVal async As Boolean, ByRef firstSubtitlePath As String, ByRef subtitlesPaths As String(), ByRef writeFailed As Boolean, ByRef error As String) As Boolean
            Dim i1 As Integer

            error = Nothing
            firstSubtitlePath = Nothing
            subtitlesPaths = Nothing
            writeFailed = False
            If (subtitle) Is Nothing Then
                Return False
            End If
            If (((subtitleProvider) Is Nothing) OrElse (subtitleProvider.DownloadType <> Sublight.Plugins.SubtitleProvider.Types.SubtitleProviderDownloadType.Indirect)) AndAlso (((outputPath2) Is Nothing) OrElse Not System.IO.Directory.Exists(outputPath2)) Then
                Return False
            End If
            If Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.ANSI Then
                i1 = System.Text.Encoding.Default.CodePage
            ElseIf Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.UTF8 Then
                i1 = System.Text.Encoding.UTF8.CodePage
            ElseIf Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.Unicode Then
                i1 = System.Text.Encoding.Unicode.CodePage
            ElseIf Sublight.Properties.Settings.Default.SubtitleEncoding = Sublight.Types.Encoding.CustomCodePage Then
                i1 = Sublight.Properties.Settings.Default.SubtitleEncoding_Custom
            Else 
                i1 = -1
            End If
            Dim objArr1 As Object() = New object(15) {}
            objArr1(0) = subtitle.SubtitleID
            objArr1(1) = i1
            objArr1(2) = videoFile
            objArr1(3) = isVideoFileMandatory
            objArr1(4) = subtitlesPaths
            objArr1(6) = subtitle
            objArr1(8) = multipleDownloads
            objArr1(9) = languageGroupIndex
            objArr1(10) = outputPath2
            objArr1(11) = list
            objArr1(12) = playVideo
            objArr1(13) = videoPath
            objArr1(14) = subtitleProvider
            Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_BPR_DOWNLOADDECOMPRESSSAVE, ParentBaseForm, Me, objArr1)
            AddHandler webServiceHandler1.OnException, AddressOf wsh_OnException
            AddHandler webServiceHandler1.DoCall, AddressOf wsh_DoCall
            AddHandler webServiceHandler1.OnResult, AddressOf wsh_OnResult
            webServiceHandler1.RunWorkerAsync()
            If Not async Then
                While webServiceHandler1.IsBusy
                    System.Threading.Thread.Sleep(50)
                    System.Windows.Forms.Application.DoEvents()
                End While
            End If
            Return True
        End Function

        Protected Function DownloadDecompressSave(ByVal list As Sublight.Controls.MySuperList, ByVal subtitleProvider As Sublight.Plugins.SubtitleProvider.ISubtitleProvider, ByVal playVideo As Boolean, ByVal videoPath As String, ByVal subtitle As Sublight.WS.Subtitle, ByVal outputPath2 As String, ByVal videoFile As String, ByVal languageGroupIndex As Integer, ByVal isVideoFileMandatory As Boolean, ByVal multipleDownloads As Boolean, ByRef firstSubtitlePath As String, ByRef subtitlesPaths As String(), ByRef writeFailed As Boolean, ByRef error As String) As Boolean
            Return DownloadDecompressSave(list, subtitleProvider, playVideo, videoPath, subtitle, outputPath2, videoFile, languageGroupIndex, isVideoFileMandatory, multipleDownloads, True, out firstSubtitlePath, out subtitlesPaths, out writeFailed, out error)
        End Function

        Protected Sub EditSubtitle(ByVal subtitle As Sublight.WS.Subtitle)
            m_EditSubtitle = Nothing
            If (subtitle) Is Nothing Then
                Return
            End If
            m_EditSubtitle = subtitle
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                ParentBaseForm.ShowLoader(Me)
                AddHandler sublight1.GetDownloadTicket2Completed, AddressOf ws_GetDownloadTicketCompleted
                Dim guid1 As System.Guid = m_EditSubtitle.SubtitleID
                sublight1.GetDownloadTicket2Async(Sublight.BaseForm.Session, Nothing, guid1.ToString("N?"))
            End Using
        End Sub

        Private Sub frm_PublishSubtitle(ByVal sender As Object, ByVal e As Sublight.SubtitleEditor.FrmMain.PublishSubtitleEventArgs)
            Dim s1 As String

            Dim frmMain1 As Sublight.SubtitleEditor.FrmMain = TryCast(sender, Sublight.SubtitleEditor.FrmMain)
            If (frmMain1) Is Nothing Then
                Return
            End If
            Try
                Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream
                    Using zipOutputStream1 As ICSharpCode.SharpZipLib.Zip.ZipOutputStream = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(memoryStream1)
                        zipOutputStream1.SetLevel(9)
                        If Not (frmMain1.Subtitles) Is Nothing Then
                            Dim i1 As Integer = 0
                            While i1 < frmMain1.Subtitles.Length
                                Dim s2 As String = System.String.Format("disc_{0}.txt?", i1 + 1)
                                Dim zipEntry1 As ICSharpCode.SharpZipLib.Zip.ZipEntry = New ICSharpCode.SharpZipLib.Zip.ZipEntry(s2)
                                zipEntry1.DateTime = System.DateTime.Now
                                zipOutputStream1.PutNextEntry(zipEntry1)
                                Dim bArr1 As Byte() = System.Text.Encoding.UTF8.GetBytes(frmMain1.Subtitles(i1))
                                zipOutputStream1.Write(bArr1, 0, bArr1.Length)
                                i1 = i1 + 1
                            End While
                        End If
                        zipOutputStream1.Finish()
                        zipOutputStream1.Flush()
                        s1 = System.Convert.ToBase64String(memoryStream1.ToArray())
                        zipOutputStream1.Close()
                        zipOutputStream1.Dispose()
                    End Using
                End Using
            Catch 
                ParentBaseForm.ShowError(Sublight.Translation.Common_Error_SubtitleCompression, New object(0) {})
                Return
            End Try
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                ParentBaseForm.ShowLoader(Me)
                AddHandler sublight1.PublishEditedSubtitle2Completed, AddressOf ws_PublishEditedSubtitle2Completed
                sublight1.PublishEditedSubtitle2Async(Sublight.BaseForm.Session, frmMain1.SubtitleID, e.Comment, s1, frmMain1)
            End Using
        End Sub

        Protected Sub OnAutoDeleteHandler()
            If Sublight.Properties.Settings.Default.AutoDelete Then
                If (m_downloadedFiles) Is Nothing Then
                    m_downloadedFiles = New System.Collections.Generic.List(Of String)
                    Return
                End If
                If (m_downloadedFiles.get_Count() <= 0) OrElse (Sublight.Properties.Settings.Default.AutoDeleteOnNewSearch = Sublight.Types.AutoDeleteOnNewSearch.AskForAction) Then
                    If ParentBaseForm.ShowQuestion(Sublight.Translation.Search_Question_DeleteDownloadedSubtitles, New object(0) {}) = System.Windows.Forms.DialogResult.Yes Then
                        DeleteDownloadedSubtitles()
                    End If
                ElseIf Sublight.Properties.Settings.Default.AutoDeleteOnNewSearch = Sublight.Types.AutoDeleteOnNewSearch.Automatic Then
                    DeleteDownloadedSubtitles()
                End If
                m_downloadedFiles.Clear()
            End If
        End Sub

        Protected Sub OnDownload(ByVal list As Sublight.Controls.MySuperList, ByVal folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog, ByVal videoPath As String, ByVal playVideo As Boolean)
            Dim flag3 As Boolean, flag4 As Boolean, flag6 As Boolean
            Dim i4 As Integer
            Dim s3 As String, s5 As String, s6 As String, s8 As String
            Dim sArr1 As String()

            If ((list.SelectedItems) Is Nothing) OrElse (list.SelectedItems.Count <= 0) Then
                Return
            End If
            Dim flag1 As Boolean = list.SelectedItems.Count > 1
            Dim flag2 As Boolean = False
            Dim dictionary1 As System.Collections.Generic.Dictionary(Of String,Integer) = New System.Collections.Generic.Dictionary(Of String,Integer)
            Dim i1 As Integer = 0
            While i1 < list.SelectedItems.Count
                Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(list.SelectedItems(i1).Items(0), Sublight.Controls.SuperListItem.Data)
                If Not (data1) Is Nothing Then
                    Dim subtitle1 As Sublight.WS.Subtitle = data1.Subtitle
                    If Not (subtitle1) Is Nothing Then
                        If (data1.SubtitleProvider) Is Nothing Then
                            flag2 = True
                        ElseIf data1.SubtitleProvider.DownloadType = Sublight.Plugins.SubtitleProvider.Types.SubtitleProviderDownloadType.Direct Then
                            flag2 = True
                        End If
                        Dim s1 As String = Sublight.Globals.LanguageToShortString(subtitle1.Language)
                        If dictionary1.ContainsKey(s1) Then
                            Dim i2 As Integer = dictionary1.get_Item(s1)
                            dictionary1.set_Item(s1, i2 + 1)
                        Else 
                            dictionary1.Add(s1, 1)
                        End If
                    End If
                End If
                i1 = i1 + 1
            End While
            Dim dictionary2 As System.Collections.Generic.Dictionary(Of String,Integer) = New System.Collections.Generic.Dictionary(Of String,Integer)
            Dim enumerator1 As System.Collections.Generic.Dictionary(Of String,Integer).KeyCollection.Enumerator = dictionary1.get_Keys().GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim s2 As String = enumerator1.get_Current()
                    dictionary2.Add(s2, 0)
                End While
            Finally
                enumerator1.Dispose()
            End Try
            If Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.CustomFolder Then
                s3 = Sublight.Properties.Settings.Default.CustomDownloadLocation
            ElseIf Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.Auto Then
                s3 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Sublight.Globals.AutoDownloadLocation)
                If Not System.IO.Directory.Exists(s3) Then
                    System.IO.Directory.CreateDirectory(s3)
                End If
            ElseIf (Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.VideoFolder) AndAlso Not System.String.IsNullOrEmpty(videoPath) AndAlso System.IO.File.Exists(videoPath) Then
                s3 = System.IO.Path.GetDirectoryName(videoPath)
            ElseIf flag2 Then
                folderBrowserDialog1.Description = Sublight.Translation.Dialog_SaveSubtitleToFolder_Description
                If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    s3 = folderBrowserDialog1.SelectedPath
                Else 
                    s3 = Nothing
                End If
            Else 
                s3 = Nothing
            End If
            If flag2 AndAlso System.String.IsNullOrEmpty(s3) Then
                Return
            End If
            Dim s4 As String = s3
            Sublight.Controls.BasePageResults.CheckRights(s3, out flag3, out flag4)
            Dim flag5 As Boolean = False
            If Not flag3 AndAlso Not flag4 Then
                flag5 = True
                If Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.CustomFolder Then
                    s3 = Sublight.Properties.Settings.Default.CustomDownloadLocationS
                ElseIf Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.Auto Then
                    s3 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Sublight.Globals.AutoDownloadLocation)
                    If Not System.IO.Directory.Exists(s3) Then
                        System.IO.Directory.CreateDirectory(s3)
                    End If
                ElseIf (Sublight.Properties.Settings.Default.DownloadTypeS = Sublight.Types.DownloadLocation.VideoFolder) AndAlso Not System.String.IsNullOrEmpty(videoPath) AndAlso System.IO.File.Exists(videoPath) Then
                    s3 = System.IO.Path.GetDirectoryName(videoPath)
                Else 
                    folderBrowserDialog1.Description = Sublight.Translation.Dialog_SaveSubtitleToFolder_Description
                    If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        s3 = folderBrowserDialog1.SelectedPath
                    Else 
                        s3 = Nothing
                    End If
                End If
            End If
            If flag2 AndAlso System.String.IsNullOrEmpty(s3) Then
                ParentBaseForm.ShowWarning(Sublight.Translation.Search_Warning_SavingWasCanceledBecauseFolderIsNotSet, New object(0) {})
                Return
            End If
            If flag5 Then
                Sublight.Controls.BasePageResults.CheckRights(s3, out flag3, out flag4)
            End If
            If Not flag3 AndAlso Not flag4 Then
                Dim objArr1 As Object() = New object() { s4 }
                ParentBaseForm.ShowWarning(Sublight.Translation.Search_Error_DownloadDecompressSave_NoReadWriteRightsForPath, objArr1)
                Return
            End If
            If flag5 Then
                Dim objArr2 As Object() = New object() { s3 }
                ParentBaseForm.ShowInfo(Sublight.Translation.Search_Info_DownloadDecompressSave_SubtitleWasSavedToSecondaryLocation, objArr2)
            End If
            Dim i3 As Integer = 0
            While i3 < list.SelectedItems.Count
                Dim data2 As Sublight.Controls.SuperListItem.Data = TryCast(list.SelectedItems(i3).Items(0), Sublight.Controls.SuperListItem.Data)
                If Not (data2) Is Nothing Then
                    Dim subtitle2 As Sublight.WS.Subtitle = data2.Subtitle
                    If Not (subtitle2) Is Nothing Then
                        Dim s7 As String = Sublight.Globals.LanguageToShortString(subtitle2.Language)
                        If dictionary1.get_Item(s7) > 1 Then
                            Dim i5 As Integer = dictionary2.get_Item(s7)
                            i5 = i5 + 1
                            dictionary2.set_Item(s7, i5)
                            i4 = i5
                        Else 
                            i4 = -1
                        End If
                        If Not System.String.IsNullOrEmpty(videoPath) AndAlso System.IO.File.Exists(videoPath) Then
                            s8 = videoPath
                        Else 
                            s8 = Nothing
                        End If
                        If Not DownloadDecompressSave(list, data2.SubtitleProvider, playVideo, videoPath, subtitle2, s3, s8, i4, False, flag1, out s5, out sArr1, out flag6, out s6) Then
                            DisplayError(s6, sArr1)
                        ElseIf (Not (sArr1) Is Nothing) AndAlso (sArr1.Length > 0) Then
                            AddForDeletion(sArr1)
                        End If
                    End If
                End If
                i3 = i3 + 1
            End While
        End Sub

        Protected Function RateSubtitle(ByVal list As Sublight.Controls.MySuperList, ByVal d As Sublight.Controls.SuperListItem.Data(), ByVal rate As Integer) As Boolean
            Dim l1 As Long
            Dim d1 As Double

            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(list)
            If (subtitle1) Is Nothing Then
                Return False
            End If
            If parent.RateSubtitle(Me, subtitle1.SubtitleID, rate, out l1, out d1) Then
                subtitle1.Rate = System.Convert.ToSingle(d1)
                subtitle1.Votes = System.Convert.ToInt32(l1)
                Sublight.Controls.BasePageResults.RebindSearchResults(list, d)
                Return True
            End If
            Return False
        End Function

        Private Sub ws_DownloadByID4Completed(ByVal sender As Object, ByVal e As Sublight.WS.DownloadByID4CompletedEventArgs)
            Try
                If Sublight.BaseForm.HandleWSErrors(ParentBaseForm, e) OrElse ((m_EditSubtitle) Is Nothing) Then
                    Return
                End If
                Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                Try
                    If e.Result Then
                        Sublight.Globals.UpdateUserPoints(e.points)
                    End If
                    Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream(System.Convert.FromBase64String(e.data))
                        Dim zipFile1 As ICSharpCode.SharpZipLib.Zip.ZipFile = New ICSharpCode.SharpZipLib.Zip.ZipFile(memoryStream1)
                        Dim i1 As Integer = 0
                        Dim ienumerator1 As System.Collections.IEnumerator = zipFile1.GetEnumerator()
                        Try
                            While ienumerator1.MoveNext()
                                i1 = i1 + 1
                            End While
                        Finally
                            Dim idisposable1 As System.IDisposable = TryCast(ienumerator1, System.IDisposable)
                            If Not (idisposable1) Is Nothing Then
                                idisposable1.Dispose()
                            End If
                        End Try
                        memoryStream1.Seek(CLng(0), System.IO.SeekOrigin.Begin)
                        Dim i2 As Integer = 0
                        While i2 < i1
                            Dim zipEntry1 As ICSharpCode.SharpZipLib.Zip.ZipEntry = zipFile1.get_EntryByIndex(i2)
                            Dim stream1 As System.IO.Stream = zipFile1.GetInputStream(zipEntry1)
                            Dim bArr1 As Byte() = New byte(zipEntry1.Size) {}
                            Dim i3 As Integer = 0
                            While i3 < bArr1.Length
                                Dim i4 As Integer = stream1.ReadByte()
                                If i4 >= 0 Then
                                    bArr1(i3) = System.Convert.ToByte(i4)
                                    i3 = i3 + 1
                                End If
                            End While
                            Dim memoryStream2 As System.IO.MemoryStream = New System.IO.MemoryStream(bArr1)
                            Dim streamReader1 As System.IO.StreamReader = New System.IO.StreamReader(memoryStream2, System.Text.Encoding.UTF8)
                            list1.Add(streamReader1.ReadToEnd())
                            streamReader1.Dispose()
                            memoryStream2.Dispose()
                            i2 = i2 + 1
                        End While
                    End Using
                Catch e As System.Exception
                    Return
                End Try
                Dim frmMain1 As Sublight.SubtitleEditor.FrmMain = New Sublight.SubtitleEditor.FrmMain(Sublight.Translation.ResourceManager)
                AddHandler frmMain1.PublishSubtitle, AddressOf frm_PublishSubtitle
                frmMain1.Show(Me)
                frmMain1.LoadSubtitle(m_EditSubtitle.SubtitleID, System.String.Format("{0} ({1})?", m_EditSubtitle.Title, m_EditSubtitle.Year), list1.ToArray())
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Sub ws_GetDownloadTicketCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetDownloadTicket2CompletedEventArgs)
            Dim flag1 As Boolean = False
            Try
                If Sublight.BaseForm.HandleWSErrors(ParentBaseForm, e) OrElse ((m_EditSubtitle) Is Nothing) Then
                    flag1 = True
                    Return
                End If
                If e.que > 0 Then
                    System.Threading.Thread.Sleep(e.que * 1000)
                End If
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    AddHandler sublight1.DownloadByID4Completed, AddressOf ws_DownloadByID4Completed
                    sublight1.DownloadByID4Async(Sublight.BaseForm.Session, m_EditSubtitle.SubtitleID, -1, False, e.ticket)
                End Using
            Finally
                If flag1 Then
                    ParentBaseForm.HideLoader(Me)
                End If
            End Try
        End Sub

        Private Sub ws_PublishEditedSubtitle2Completed(ByVal sender As Object, ByVal e As Sublight.WS.PublishEditedSubtitle2CompletedEventArgs)
            Try
                If Sublight.BaseForm.HandleWSErrors(ParentBaseForm, e) Then
                    Return
                End If
                Dim frmMain1 As Sublight.SubtitleEditor.FrmMain = TryCast(e.UserState, Sublight.SubtitleEditor.FrmMain)
                If Not (frmMain1) Is Nothing Then
                    frmMain1.AcceptChanges()
                End If
                ParentBaseForm.ShowInfo(Sublight.Translation.Publish_Info_SuccessfullyPublished, New object(0) {})
                If e.Result Then
                    Sublight.Globals.UpdateUserPoints(e.points)
                End If
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Function wsh_DoCall(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim flag1 As Boolean
            Dim d1 As Double
            Dim s1 As String, s2 As String, s3 As String
            Dim subtitleType1 As Sublight.WS.SubtitleType

            Dim <>c__DisplayClass1_1 As Sublight.Controls.BasePageResults.<>c__DisplayClass1 = New Sublight.Controls.BasePageResults.<>c__DisplayClass1
            <>c__DisplayClass1_1.<>4__this = Me
            result = Nothing
            If (args) Is Nothing Then
                Return False
            End If
            Dim isubtitleProvider1 As Sublight.Plugins.SubtitleProvider.ISubtitleProvider = CType(args(14), Sublight.Plugins.SubtitleProvider.ISubtitleProvider)
            Dim subtitle1 As Sublight.WS.Subtitle = CType(args(6), Sublight.WS.Subtitle)
            If (subtitle1) Is Nothing Then
                Throw New System.Exception("no subtitle instance?")
            End If
            If Not (isubtitleProvider1) Is Nothing Then
                GoTo label_0
            End If
            Dim guid1 As System.Guid = subtitle1.SubtitleID
            If Not Sublight.BaseForm.Session.GetDownloadTicket2(IIf(Not (isubtitleProvider1) Is Nothing, isubtitleProvider1.GetType().Name, Nothing), guid1.ToString("N?"), subtitle1.ExternalId, out s3, out <>c__DisplayClass1_1.que, out d1, out s2) Then
                Throw New System.Exception(System.String.Format("could not get ticket: {0}?", s2))
            End If
            If <>c__DisplayClass1_1.que > 0 Then
                Dim <>c__DisplayClass3_1 As Sublight.Controls.BasePageResults.<>c__DisplayClass3 = New Sublight.Controls.BasePageResults.<>c__DisplayClass3
                <>c__DisplayClass3_1.dr = System.Windows.Forms.DialogResult.Cancel
                Try
                    Dim <>c__DisplayClass5_1 As Sublight.Controls.BasePageResults.<>c__DisplayClass5 = New Sublight.Controls.BasePageResults.<>c__DisplayClass5
                    <>c__DisplayClass5_1.CS$<>8__locals4 = <>c__DisplayClass3_1
                    <>c__DisplayClass5_1.CS$<>8__locals2 = <>c__DisplayClass1_1
                    <>c__DisplayClass5_1.d = d1
                    Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass5_1.<wsh_DoCall>b__0)
                    Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1, True)
                Catch 
                    <>c__DisplayClass3_1.dr = System.Windows.Forms.DialogResult.Cancel
                End Try
                If <>c__DisplayClass3_1.dr <> System.Windows.Forms.DialogResult.OK Then
                    wsh.CancelRetry = True
                    Throw New Sublight.Types.DownloadCanceledException
                End If
            End If
            If Not (isubtitleProvider1) Is Nothing Then
                Try
                    If isubtitleProvider1.DownloadType = Sublight.Plugins.SubtitleProvider.Types.SubtitleProviderDownloadType.Indirect Then
                        If Not (parent) Is Nothing Then
                            parent.OpenInBrowser(isubtitleProvider1.GetDownloadUrl(subtitle1.ExternalId))
                        End If
                        flag1 = True
                        Return flag1
                    End If
                    Dim bArr1 As Byte() = Nothing
                    Dim exception1 As System.Exception = Nothing
                    Dim i1 As Integer = 0
                    While i1 < Sublight.Globals.SubtitleProvider_NumberOfRetries
                        Try
                            bArr1 = Sublight.MyUtility.Plugin.DownloadSubtitleById(Me, isubtitleProvider1, subtitle1)
                            If ((bArr1) Is Nothing) OrElse (bArr1.Length <= 0) Then
                                System.Threading.Thread.Sleep(250)
                                GoTo label_1
                            End If
                            GoTo label_2
                        Catch e As Sublight.Plugins.SubtitleProvider.Types.CredentialsRequired
                            If Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password) Then
                                Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password = System.String.Empty
                                Sublight.BaseForm.SaveUserSettingsSilent()
                            End If
                            wsh.CancelRetry = True
                            Throw New System.Exception("credentials required (you must enter your Podnapisi.NET username/password)

?")
                        Catch e As Sublight.Plugins.SubtitleProvider.Types.CredentialsInvalid
                            If Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password) Then
                                Sublight.Properties.Settings.Default.Plugins_SubtitleProvider_PodnapisiNet_Password = System.String.Empty
                                Sublight.BaseForm.SaveUserSettingsSilent()
                            End If
                            wsh.CancelRetry = True
                            Throw New System.Exception("invalid credentials (download subtitle again and retype your Podnapisi.NET username/password)

?")
                        Catch e1 As System.Exception
                            bArr1 = Nothing
                            exception1 = e1
                        End Try
                        System.Threading.Thread.Sleep(250)
                    label_1: _
                        i1 = i1 + 1
                    End While
                label_2: _
                    If Not (exception1) Is Nothing Then
                        Throw New System.Exception(System.String.Format("Subtitle provider '{0}' returned exception.?", isubtitleProvider1.GetType().Name), exception1)
                    End If
                    If ((bArr1) Is Nothing) OrElse (bArr1.Length <= 0) Then
                        Throw New System.Exception("empty file?")
                    End If
                    s1 = System.Convert.ToBase64String(bArr1)
                    Dim xmlSerializer1 As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(subtitle1.GetType())
                    Dim stringWriter1 As System.IO.StringWriter = New System.IO.StringWriter
                    xmlSerializer1.Serialize(stringWriter1, subtitle1)
                    stringWriter1.Flush()
                    Dim xmlDocument1 As System.Xml.XmlDocument = New System.Xml.XmlDocument
                    xmlDocument1.LoadXml(stringWriter1.ToString())
                    stringWriter1.Dispose()
                    Dim xmlDocument2 As System.Xml.XmlDocument = New System.Xml.XmlDocument
                    Try
                        Dim xmlNodeList1 As System.Xml.XmlNodeList = xmlDocument1.SelectNodes(System.String.Format("/{0}/*?", "Subtitle?"))
                        Dim xmlNode1 As System.Xml.XmlNode = xmlDocument2.CreateElement("Subtitle?")
                        xmlDocument2.AppendChild(xmlNode1)
                        If Not (xmlNodeList1) Is Nothing Then
                            Dim xmlElement1 As System.Xml.XmlElement 
                            For Each xmlElement1 In xmlNodeList1
                                Dim xmlElement2 As System.Xml.XmlElement = xmlDocument2.CreateElement(xmlElement1.Name)
                                xmlElement2.InnerText = xmlElement1.InnerText
                                xmlNode1.AppendChild(xmlElement2)
                            Next
                        End If
                    Catch e2 As System.Exception
                        Dim xmlElement3 As System.Xml.XmlElement = xmlDocument2.CreateElement("Error?")
                        xmlElement3.InnerText = e2.Message
                        xmlDocument2.AppendChild(xmlElement3)
                    End Try
                    If Not ws.CheckSubtitle3(Sublight.BaseForm.Session, s3, isubtitleProvider1.GetType().Name, subtitle1.ExternalId, subtitle1.IMDB, subtitle1.Title, System.Enum.GetName(GetType(Sublight.WS.SubtitleLanguage), subtitle1.Language), xmlDocument2.InnerXml, s1, out subtitleType1, out s2) Then
                        If System.String.Compare(s2, "ZipException?", False) = 0 Then
                            ParentBaseForm.ShowError(Sublight.Translation.Search_Error_DownloadDecompressSave_ErrorDownloading_ZipException, New object(0) {})
                            flag1 = True
                            Return flag1
                        End If
                        subtitle1.SubtitleType = Sublight.WS.SubtitleType.Unknown
                    Else 
                        subtitle1.SubtitleType = subtitleType1
                    End If
                    If (subtitle1.SubtitleType = Sublight.WS.SubtitleType.Unknown) AndAlso (Sublight.BaseForm.ShowQuestion(Nothing, Sublight.Translation.Search_Question_DownloadDecompressSave_UnknownSubtitleType, New object(0) {}) = System.Windows.Forms.DialogResult.No) Then
                        flag1 = True
                        Return flag1
                    End If
                    Dim objArr1 As Object() = New object() { _
                                                             args(0), _
                                                             args(1), _
                                                             args(2), _
                                                             args(3), _
                                                             args(4), _
                                                             s2, _
                                                             subtitle1, _
                                                             s1, _
                                                             args(8), _
                                                             args(9), _
                                                             args(10), _
                                                             args(11), _
                                                             args(12), _
                                                             args(13), _
                                                             isubtitleProvider1 }
                    result = objArr1
                    flag1 = True
                    Return flag1
                Catch e3 As System.Exception
                    Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                    stringBuilder1.Append("Provider=?")
                    If (Not (isubtitleProvider1) Is Nothing) AndAlso Not System.String.IsNullOrEmpty(isubtitleProvider1.ShortName) Then
                        stringBuilder1.Append(isubtitleProvider1.ShortName)
                    Else 
                        stringBuilder1.Append("N/A?")
                    End If
                    stringBuilder1.Append("; ExternalId=?")
                    If (Not (subtitle1) Is Nothing) AndAlso Not System.String.IsNullOrEmpty(subtitle1.ExternalId) Then
                        stringBuilder1.Append(subtitle1.ExternalId)
                    Else 
                        stringBuilder1.Append("N/A?")
                    End If
                    Throw New Sublight.Types.ErrorDownloadingExternalSubtitle(System.String.Format("Error downloading external subtitle: {0} ({1})?", e3.Message, stringBuilder1))
                End Try
            End If
            If ws.DownloadByID4(Sublight.BaseForm.Session, DirectCast(args(0), System.Guid), DirectCast(args(1), int), Sublight.Properties.Settings.Default.SubtitleFormatting_Remove, s3, out s1, out d1, out s2) Then
                Sublight.Globals.UpdateUserPoints(d1)
                Dim objArr2 As Object() = New object() { _
                                                         args(0), _
                                                         args(1), _
                                                         args(2), _
                                                         args(3), _
                                                         args(4), _
                                                         s2, _
                                                         args(6), _
                                                         s1, _
                                                         args(8), _
                                                         args(9), _
                                                         args(10), _
                                                         args(11), _
                                                         args(12), _
                                                         args(13), _
                                                         isubtitleProvider1 }
                result = objArr2
                Return True
            End If
            If (Not (s2) Is Nothing) AndAlso s2.StartsWith("Download denied?") Then
                wsh.CancelRetry = True
                Throw New Sublight.Types.DownloadDeniedException(s2)
            End If
            Throw New Sublight.Types.WSHException(IIf(System.String.IsNullOrEmpty(s2), "Error downloading subtitle.?", System.String.Format("Error downloading subtitle: {0}?", s2)), True)
        End Function

        Private Sub wsh_OnException(ByVal ex As System.Exception)
            If TryCast(ex, Sublight.Types.DownloadCanceledException) Then
                Return
            End If
            If TryCast(ex, Sublight.Types.DownloadDeniedException) Then
                Dim objArr1 As Object() = New object() { ex.Message }
                If Sublight.BaseForm.ShowQuestion(ParentBaseForm, Sublight.Translation.Search_Error_DownloadDecompressSave_DownloadDenied, System.Windows.Forms.MessageBoxIcon.Exclamation, objArr1) <> System.Windows.Forms.DialogResult.Yes Then
                    Return
                End If
                ParentBaseForm.OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl("Article/24/Subtitle-download-restrictions.aspx?"))
                Return
            End If
            If TryCast(ex, ICSharpCode.SharpZipLib.Zip.ZipException) Then
                ParentBaseForm.ShowError(Sublight.Translation.Search_Error_DownloadDecompressSave_ErrorDownloading_ZipException, New object(0) {})
                Return
            End If
            Dim objArr2 As Object() = New object() { ex.Message }
            ParentBaseForm.ShowError(Sublight.Translation.Search_Error_DownloadDecompressSave_ErrorDownloadingDetails, objArr2)
        End Sub

        Friend Sub wsh_OnResult(ByVal result As Object(), ByVal enableAutoLink As Boolean, ByRef subtitles As String())
            Dim flag1 As Boolean, flag2 As Boolean, flag3 As Boolean
            Dim i1 As Integer, i12 As Integer
            Dim s11 As String, s12 As String
            Dim sArr7 As String()

            subtitles = Nothing
            If ((result) Is Nothing) OrElse (result.Length <= 0) Then
                Return
            End If
            Dim s1 As String = CType(result(2), string)
            If (result(3)) Is Nothing Then
                flag1 = False
            Else 
                flag1 = DirectCast(result(3), bool)
            End If
            Dim sArr1 As String() = CType(result(4), String[])
            Dim s2 As String = CType(result(5), string)
            Dim subtitle1 As Sublight.WS.Subtitle = CType(result(6), Sublight.WS.Subtitle)
            Dim s3 As String = CType(result(7), string)
            If (result(8)) Is Nothing Then
                flag2 = False
            Else 
                flag2 = DirectCast(result(8), bool)
            End If
            If (result(9)) Is Nothing Then
                i1 = -1
            Else 
                i1 = DirectCast(result(9), int)
            End If
            Dim s4 As String = CType(result(10), string)
            Dim mySuperList1 As Sublight.Controls.MySuperList = CType(result(11), Sublight.Controls.MySuperList)
            If (result(12)) Is Nothing Then
                flag3 = False
            Else 
                flag3 = DirectCast(result(12), bool)
            End If
            Dim s5 As String = CType(result(13), string)
            Dim isubtitleProvider1 As Sublight.Plugins.SubtitleProvider.ISubtitleProvider = CType(result(14), Sublight.Plugins.SubtitleProvider.ISubtitleProvider)
            Dim s6 As String = Nothing
            Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
            If System.String.IsNullOrEmpty(s3) Then
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                stringBuilder1.AppendFormat("data is null or empty: SubtitleID = {0}?", IIf(Not (subtitle1) Is Nothing, subtitle1.SubtitleID, System.Guid.Empty))
                stringBuilder1.AppendLine()
                If Not (subtitle1) Is Nothing Then
                    stringBuilder1.AppendFormat("subtitle.ExternalId: {0}?", subtitle1.ExternalId)
                End If
                Sublight.BaseForm.ReportError("Sublight.Controls.BasePageResults.wsh_OnResult?", stringBuilder1.ToString())
                Dim objArr1 As Object() = New object() { "no data?" }
                ParentBaseForm.ShowError(Sublight.Translation.Search_Error_DownloadDecompressSave_ErrorDownloadingDetails, objArr1)
                Return
            End If
            If System.String.IsNullOrEmpty(s1) OrElse Not System.IO.File.Exists(s1) Then
                If flag1 Then
                    DisplayError(s2, sArr1)
                    Return
                End If
                Dim sArr2 As String() = Sublight.Controls.BasePageResults.GetVideoFiles(s4)
                If (Not (sArr2) Is Nothing) AndAlso (sArr2.Length = 1) Then
                    s1 = sArr2(0)
                    s5 = sArr2(0)
                End If
            End If
            Dim stringBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
            If (Not (subtitle1) Is Nothing) AndAlso (Not (subtitle1.Title) Is Nothing) Then
                Dim chArr1 As Char() = System.IO.Path.GetInvalidFileNameChars()
                Dim i2 As Integer = 0
                While i2 < subtitle1.Title.Length
                    Dim flag4 As Boolean = True
                    If Not (chArr1) Is Nothing Then
                        Dim i3 As Integer = 0
                        While i3 < chArr1.Length
                            If System.Char.ToUpper(subtitle1.Title(i2)) = System.Char.ToUpper(chArr1(i3)) Then
                                flag4 = False
                                Exit While
                            End If
                            i3 = i3 + 1
                        End While
                    End If
                    If flag4 Then
                        stringBuilder2.Append(subtitle1.Title(i2))
                    End If
                    i2 = i2 + 1
                End While
            End If
            Dim s7 As String = stringBuilder2.ToString().Trim()
            If System.String.IsNullOrEmpty(s7) Then
                Dim guid1 As System.Guid = System.Guid.NewGuid()
                s7 = guid1.ToString("N?")
            End If
            Try
                Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream(System.Convert.FromBase64String(s3))
                    Dim zipFile1 As ICSharpCode.SharpZipLib.Zip.ZipFile = New ICSharpCode.SharpZipLib.Zip.ZipFile(memoryStream1)
                    Dim i4 As Integer = 0
                    Dim zipEntry1 As ICSharpCode.SharpZipLib.Zip.ZipEntry 
                    For Each zipEntry1 In zipFile1
                        If zipEntry1.IsFile Then
                            i4 = i4 + 1
                        End If
                    Next
                    If (Not (subtitle1) Is Nothing) AndAlso (subtitle1.NumberOfDiscs > 0) Then
                        i4 = System.Math.Min(i4, subtitle1.NumberOfDiscs)
                    End If
                    If i4 <= 0 Then
                        DisplayError(s2, sArr1)
                        Return
                    End If
                    Dim list3 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                    If (i4 > 1) AndAlso Not System.String.IsNullOrEmpty(s1) Then
                        Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(s1)
                        Dim flag5 As Boolean = False
                        If Not (fileInfo1.Directory) Is Nothing Then
                            Dim chArr2 As Char() = New char() { "."C }
                            Dim sArr3 As String() = Sublight.Controls.BasePageResults.GetVideoFiles(fileInfo1.Directory.FullName, System.String.Format("*.{0}?", fileInfo1.Extension.Trim(chArr2)))
                            If sArr3.Length = i4 Then
                                flag5 = True
                                Dim i5 As Integer = 1
                                While i5 < sArr3.Length
                                    If System.String.Compare(sArr3(i5), s5, True) <> 0 Then
                                        list3.Add(sArr3(i5))
                                    End If
                                    i5 = i5 + 1
                                End While
                            ElseIf sArr3.Length > i4 Then
                                Dim list4 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                                sArr7 = sArr3
                                i12 = 0
                                While i12 < sArr7.Length
                                    Dim s8 As String = sArr7(i12)
                                    Dim fileInfo2 As System.IO.FileInfo = New System.IO.FileInfo(s8)
                                    If (fileInfo2.Name.Length = fileInfo1.Name.Length) AndAlso (Sublight.MyUtility.StringUtil.ComputeLevenshteinDistance(fileInfo1.Name, fileInfo2.Name) <= 1) Then
                                        list4.Add(s8)
                                    End If
                                    i12 = i12 + 1
                                End While
                                If list4.get_Count() = i4 Then
                                    list4.Sort()
                                    flag5 = True
                                    Dim i6 As Integer = 1
                                    While i6 < list4.get_Count()
                                        If System.String.Compare(list4.get_Item(i6), s5, True) <> 0 Then
                                            list3.Add(list4.get_Item(i6))
                                        End If
                                        i6 = i6 + 1
                                    End While
                                End If
                            End If
                            If Not flag5 AndAlso (Not (fileInfo1.Directory.Parent) Is Nothing) Then
                                sArr3 = System.IO.Directory.GetDirectories(fileInfo1.Directory.Parent.FullName)
                                If sArr3.Length >= i4 Then
                                    flag5 = True
                                    sArr7 = sArr3
                                    i12 = 0
                                    While i12 < sArr7.Length
                                        Dim s9 As String = sArr7(i12)
                                        chArr2 = New char() { "."C }
                                        Dim sArr4 As String() = Sublight.Controls.BasePageResults.GetVideoFiles(s9, System.String.Format("*.{0}?", fileInfo1.Extension.Trim(chArr2)))
                                        If (sArr4.Length = 1) AndAlso (System.String.Compare(sArr4(0), s5, True) <> 0) Then
                                            list3.Add(sArr4(0))
                                        End If
                                        i12 = i12 + 1
                                    End While
                                End If
                            End If
                            If Not flag5 AndAlso (Not (fileInfo1.Directory.Parent) Is Nothing) AndAlso (Not (fileInfo1.Directory.Parent.Parent) Is Nothing) Then
                                sArr3 = System.IO.Directory.GetDirectories(fileInfo1.Directory.Parent.Parent.FullName)
                                If sArr3.Length = i4 Then
                                    flag5 = True
                                    sArr7 = sArr3
                                    i12 = 0
                                    While i12 < sArr7.Length
                                        Dim s10 As String = sArr7(i12)
                                        Dim sArr5 As String() = System.IO.Directory.GetDirectories(s10)
                                        If sArr5.Length = 1 Then
                                            chArr2 = New char() { "."C }
                                            Dim sArr6 As String() = Sublight.Controls.BasePageResults.GetVideoFiles(sArr5(0), System.String.Format("*.{0}?", fileInfo1.Extension.Trim(chArr2)))
                                            If (sArr6.Length = 1) AndAlso (System.String.Compare(sArr6(0), s5, True) <> 0) Then
                                                list3.Add(sArr6(0))
                                            End If
                                        End If
                                        i12 = i12 + 1
                                    End While
                                End If
                            End If
                        End If
                    End If
                    If list3.get_Count() <> (i4 - 1) Then
                        list3.Clear()
                    End If
                    memoryStream1.Seek(CLng(0), System.IO.SeekOrigin.Begin)
                    Dim i7 As Integer = 0
                    While i7 < i4
                        Dim zipEntry2 As ICSharpCode.SharpZipLib.Zip.ZipEntry = zipFile1.get_EntryByIndex(i7)
                        If zipEntry2.IsFile Then
                            Dim stream1 As System.IO.Stream = zipFile1.GetInputStream(zipEntry2)
                            Dim bArr1 As Byte() = New byte(zipEntry2.Size) {}
                            Dim i8 As Integer = 0
                            While i8 < bArr1.Length
                                Dim i9 As Integer = stream1.ReadByte()
                                If i9 >= 0 Then
                                    bArr1(i8) = System.Convert.ToByte(i9)
                                    i8 = i8 + 1
                                End If
                            End While
                            Dim l1 As Long = zipEntry2.ZipFileIndex + CLng(1)
                            If ((i4 = 1) AndAlso Not System.String.IsNullOrEmpty(s5)) OrElse ((i4 > 1) AndAlso (list3.get_Count() > 0)) Then
                                If i7 = 0 Then
                                    s11 = System.IO.Path.GetFileNameWithoutExtension(s1)
                                Else 
                                    s11 = System.IO.Path.GetFileNameWithoutExtension(list3.get_Item(i7 - 1))
                                End If
                            Else 
                                s11 = s7
                            End If
                            If flag2 OrElse Sublight.Properties.Settings.Default.SubtitleFileNaming_AppendLangId Then
                                s12 = System.String.Format("{0}.{1}?", s11, Sublight.Globals.LanguageToShortString(subtitle1.Language))
                            Else 
                                s12 = s11
                            End If
                            If i1 >= 0 Then
                                s12 = System.String.Format("{0}.{1}?", s12, i1)
                            End If
                            Dim s13 As String = s4
                            If i4 > 1 Then
                                If System.String.IsNullOrEmpty(s1) OrElse (Sublight.Properties.Settings.Default.DownloadType <> Sublight.Types.DownloadLocation.VideoFolder) Then
                                    s12 = System.String.Format("{0}_{1}?", s12, l1)
                                ElseIf i7 = 0 Then
                                    s12 = System.String.Format("{0}?", s12)
                                ElseIf list3.get_Count() > 0 Then
                                    s13 = (New System.IO.FileInfo(list3.get_Item(i7 - 1))).Directory.FullName
                                    s12 = System.String.Format("{0}?", s12)
                                Else 
                                    s12 = System.String.Format("{0}_{1}?", s12, l1)
                                End If
                            End If
                            If subtitle1.SubtitleType = Sublight.WS.SubtitleType.Srt Then
                                s12 = s12 + ".srt?"
                            ElseIf subtitle1.SubtitleType = Sublight.WS.SubtitleType.Sub Then
                                s12 = s12 + ".sub?"
                            ElseIf subtitle1.SubtitleType = Sublight.WS.SubtitleType.SubViewer2 Then
                                s12 = s12 + ".sub?"
                            ElseIf subtitle1.SubtitleType = Sublight.WS.SubtitleType.SAMI Then
                                s12 = s12 + ".smi?"
                            Else 
                                s12 = s12 + ".txt?"
                            End If
                            Dim s14 As String = Nothing
                            Try
                                s14 = System.IO.Path.Combine(s13, s12)
                                If Not Sublight.Properties.Settings.Default.OverwriteSubtitleIfExists Then
                                    Dim i10 As Integer = 1
                                    While True
                                        If System.IO.File.Exists(s14) Then
                                            Dim s15 As String = s12
                                            Dim i11 As Integer = s15.LastIndexOf("."C)
                                            If i11 >= 0 Then
                                                s15 = System.String.Format("{0}.{1}.{2}?", s15.Substring(0, i11), i10, s15.Substring(i11 + 1))
                                                s14 = System.IO.Path.Combine(s13, s15)
                                                i10 = i10 + 1
                                            End If
                                        End If
                                    End While
                                End If
                                If (s6) Is Nothing Then
                                    s6 = s14
                                End If
                                System.IO.File.WriteAllBytes(s14, bArr1)
                                list1.Add(s14)
                            Catch 
                                DisplayError(System.String.Format(Sublight.Translation.Search_Error_DownloadDecompressSave_ErrorWritingFile, s14), sArr1)
                                Return
                            End Try
                            stream1.Dispose()
                        End If
                        i7 = i7 + 1
                    End While
                    Dim list2 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                    If list1.get_Count() > 0 Then
                        sArr1 = list1.ToArray()
                        list2.AddRange(sArr1)
                    Else 
                        sArr1 = Nothing
                        If Not System.String.IsNullOrEmpty(s6) Then
                            list2.Add(s6)
                        End If
                    End If
                    subtitles = list2.ToArray()
                    Sublight.Globals.Events.OnSubtitleDownloaded(subtitle1.SubtitleID)
                    If Not flag3 OrElse (mySuperList1.SelectedItems.Count <> 1) OrElse ((sArr1) Is Nothing) OrElse (sArr1.Length = 1) Then
                        If Not Sublight.MyUtility.VideoApp.Play(s5, s6, subtitle1.SubtitleType, True, subtitle1, enableAutoLink, out s2) Then
                            ParentBaseForm.ShowError(s2, New object(0) {})
                        End If
                    Else 
                        Dim frmPlay1 As Sublight.FrmPlay = New Sublight.FrmPlay(ParentBaseForm, s5, list3.ToArray(), s6, sArr1, subtitle1, subtitle1.SubtitleType)
                        frmPlay1.Show(Me)
                    End If
                End Using
            Catch e As ICSharpCode.SharpZipLib.Zip.ZipException
                Dim stringBuilder3 As System.Text.StringBuilder = New System.Text.StringBuilder
                stringBuilder3.AppendFormat("ZipException: SubtitleID = {0}?", IIf(Not (subtitle1) Is Nothing, subtitle1.SubtitleID, System.Guid.Empty))
                stringBuilder3.AppendLine()
                If Not (subtitle1) Is Nothing Then
                    stringBuilder3.Append("provider = ?")
                    If Not (isubtitleProvider1) Is Nothing Then
                        stringBuilder3.Append(isubtitleProvider1.GetType().Name)
                    Else 
                        stringBuilder3.Append("N/A?")
                    End If
                    stringBuilder3.Append(", ?")
                    stringBuilder3.AppendFormat("subtitle.ExternalId: {0}?", subtitle1.ExternalId)
                End If
                stringBuilder2.AppendLine()
                stringBuilder3.Append(e.Message)
                Sublight.BaseForm.ReportError("Sublight.Controls.BasePageResults.wsh_OnResult?", stringBuilder3.ToString())
                Throw e
            End Try
        End Sub

        Friend Sub wsh_OnResult(ByVal result As Object())
            Dim sArr1 As String()

            wsh_OnResult(result, True, out sArr1)
        End Sub

        Protected Shared Function AreMultipleItemsSelected(ByVal list As Sublight.Controls.MySuperList) As Boolean
            If (list.SelectedItems) Is Nothing Then
                Return False
            End If
            Return list.SelectedItems.Count > 1
        End Function

        Private Shared Sub CheckRights(ByVal path As String, ByRef hasReadRights As Boolean, ByRef hasWriteRights As Boolean)
            If System.String.IsNullOrEmpty(path) Then
                hasReadRights = True
                hasWriteRights = True
                Return
            End If
            hasReadRights = False
            hasWriteRights = False
            Dim guid1 As System.Guid = System.Guid.NewGuid()
            Dim s1 As String = System.IO.Path.Combine(path, System.String.Format("{0}.tmp?", guid1.ToString("N?")))
            Try
                System.IO.File.WriteAllText(s1, "TEST?")
                hasWriteRights = True
                If System.String.Compare(System.IO.File.ReadAllText(s1).Trim(), "TEST?") = 0 Then
                    hasReadRights = True
                End If
            Catch 
            Finally
                Try
                    If System.IO.File.Exists(s1) Then
                        System.IO.File.Delete(s1)
                    End If
                Catch 
                End Try
            End Try
        End Sub

        Protected Shared Function GetSelectedSubtitle(ByVal list As Sublight.Controls.MySuperList) As Sublight.WS.Subtitle
            Dim data1 As Sublight.Controls.SuperListItem.Data = Sublight.Controls.BasePageResults.GetSelectedSubtitleData(list)
            If (data1) Is Nothing Then
                Return Nothing
            End If
            Return data1.Subtitle
        End Function

        Protected Shared Function GetSelectedSubtitleData(ByVal list As Sublight.Controls.MySuperList) As Sublight.Controls.SuperListItem.Data
            If (list) Is Nothing Then
                Return Nothing
            End If
            If ((list.SelectedItems) Is Nothing) OrElse (list.SelectedItems.Count <> 1) Then
                Return Nothing
            End If
            If list.SelectedItems(0).Items.Length <> 1 Then
                Return Nothing
            End If
            Return TryCast(list.SelectedItems(0).Items(0), Sublight.Controls.SuperListItem.Data)
        End Function

        Private Shared Function GetVideoFiles(ByVal folder As String) As String()
            Return Sublight.Controls.BasePageResults.GetVideoFiles(folder, Nothing)
        End Function

        Private Shared Function GetVideoFiles(ByVal folder As String, ByVal videoExtension As String) As String()
            Dim sArr3 As String()

            Try
                If (videoExtension) Is Nothing Then
                    videoExtension = Sublight.Globals.VideoExtensionsFilter
                End If
                Dim chArr1 As Char() = New char() { ";"C }
                Dim sArr1 As String() = videoExtension.Split(chArr1, System.StringSplitOptions.RemoveEmptyEntries)
                Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                Dim sArr4 As String() = sArr1
                Dim i1 As Integer = 0
                While i1 < sArr4.Length
                    Dim s1 As String = sArr4(i1)
                    Dim sArr2 As String() = System.IO.Directory.GetFiles(folder, s1, System.IO.SearchOption.TopDirectoryOnly)
                    If (Not (sArr2) Is Nothing) AndAlso (sArr2.Length > 0) Then
                        list1.AddRange(sArr2)
                    End If
                    i1 = i1 + 1
                End While
                sArr3 = list1.ToArray()
            Catch 
                sArr3 = New string(0) {}
            End Try
            Return sArr3
        End Function

        Protected Shared Sub RebindSearchResults(ByVal list As Sublight.Controls.MySuperList, ByVal d As Sublight.Controls.SuperListItem.Data())
            Dim subtitle1 As Sublight.WS.Subtitle = Sublight.Controls.BasePageResults.GetSelectedSubtitle(list)
            list.Items.Clear()
            list.Items.AddRange(d)
            list.Items.SynchroniseWithUINow()
            If list.Columns.get_Count() > 0 Then
                list.SizeColumnsToFit()
            End If
            If Not (subtitle1) Is Nothing Then
                Dim i1 As Integer = 0
                While i1 < list.Items.Count
                    Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(list.Items(i1), Sublight.Controls.SuperListItem.Data)
                    If (Not (data1) Is Nothing) AndAlso data1.Subtitle.SubtitleID = subtitle1.SubtitleID Then
                        list.SelectedItems.Add(data1)
                        list.FocusedItem = data1
                        Return
                    End If
                    i1 = i1 + 1
                End While
            End If
        End Sub

        Friend Shared Function ReleaseToString(ByVal release As Sublight.WS.Release) As String
            Dim s1 As String

            If (release.FPS <> Sublight.WS.FPS.NotSet) AndAlso (release.FPS <> Sublight.WS.FPS.NotAvailable) Then
                If Not System.String.IsNullOrEmpty(release.Name) Then
                    s1 = System.String.Format("{1} ({0} FPS)?", Sublight.Globals.GetString(System.String.Format("FPS_{0}?", release.FPS)), release.Name)
                Else 
                    s1 = System.String.Format("({0} FPS)?", Sublight.Globals.GetString(System.String.Format("FPS_{0}?", release.FPS)))
                End If
            ElseIf Not System.String.IsNullOrEmpty(release.Name) Then
                s1 = System.String.Format("{1} ({0})?", Sublight.Globals.GetString(System.String.Format("FPS_{0}?", 3)), release.Name)
            Else 
                s1 = Sublight.Translation.Common_SearchResults_NoReleaseInfo
            End If
            If s1.Length > 68 Then
                s1 = s1.Substring(0, 68) + "...?"
            End If
            Return s1
        End Function

    End Class ' class BasePageResults

End Namespace

