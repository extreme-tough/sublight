Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports Elegant.Ui
Imports ICSharpCode.SharpZipLib.Zip
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.Lib.IMDB
Imports Sublight.MyUtility
Imports Sublight.Plugins.SubtitleProvider
Imports Sublight.Types
Imports Sublight.WS
Imports Utility.Video

Namespace Sublight.Controls

    Friend Class PagePublish
        Inherits Sublight.Controls.BasePage

        Private Delegate Sub EnableControlsDelegate(ByVal enabled As Boolean)

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass1

            Public <>4__this As Sublight.Controls.PagePublish 
            Public isAnonymous As Boolean 

            Public Sub New()
            End Sub

            Public Sub <AppEvents_UserLogIn>b__0()
                <>4__this.EnableControls(Not isAnonymous)
                If Sublight.BaseForm.GetSetting("Publish.EnableNonImdbSubtitles?") = "1?" Then
                    <>4__this.cbImdbNotAvailable.Enabled = True
                    Return
                End If
                <>4__this.cbImdbNotAvailable.Enabled = False
            End Sub

        End Class ' class <>c__DisplayClass1

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass11

            Public CS$<>8__localsf As Sublight.Controls.PagePublish.<>c__DisplayClasse 
            Public imdbInfo As Sublight.WS.IMDB 
            Public sbDetectedTitle As System.Text.StringBuilder 

            Public Sub New()
            End Sub

            Public Sub <AutoSetImdbByVideoThread>b__b()
                CS$<>8__localsf.<>4__this.lblTipIMDb.Text = sbDetectedTitle.ToString()
                CS$<>8__localsf.<>4__this.lblTipIMDb.Visible = True
            End Sub

            Public Sub <AutoSetImdbByVideoThread>b__c()
                Sublight.Types.ListItem.Select(CS$<>8__localsf.<>4__this.cbPublishType, imdbInfo.Genre)
            End Sub

        End Class ' class <>c__DisplayClass11

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass4

            Public points As Double 
            Public waitWS As Boolean 
            Public wsCompleted As Boolean 
            Public wsErr As String 
            Public wsId As System.Guid 

            Public Sub New()
            End Sub

            Public Sub <PublishSubtitle>b__3(ByVal sender As Object, ByVal e As Sublight.WS.PublishSubtitle2CompletedEventArgs)
                Try
                    wsErr = e.error
                    wsCompleted = e.Result
                    wsId = e.ID
                    points = e.points
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.PagePublish.PublishSubtitle?", e1)
                Finally
                    waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClass4

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass8

            Public <>4__this As Sublight.Controls.PagePublish 
            Public e As Sublight.WS.GetDetailsCompletedEventArgs 

            Public Sub New()
            End Sub

            Public Sub <ws_GetDetailsCompleted>b__6()
                Sublight.Types.ListItem.Select(<>4__this.cbPublishType, e.imdbInfo.Genre)
            End Sub

        End Class ' class <>c__DisplayClass8

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClasse

            Public <>4__this As Sublight.Controls.PagePublish 
            Public imdb As String 

            Public Sub New()
            End Sub

            Public Sub <AutoSetImdbByVideoThread>b__a()
                <>4__this.txtPublishIMDB.Text = System.String.Format("http://www.imdb.com/title/{0}?", imdb)
            End Sub

        End Class ' class <>c__DisplayClasse

        Private Class SubtitlePath

            <System.Runtime.CompilerServices.CompilerGenerated> _
            Private <File>k__BackingField As String 

            Public Property File As String
                Get
                    Return <File>k__BackingField
                End Get
                Set
                    <File>k__BackingField = value
                End Set
            End Property

            Public Sub New(ByVal file As String)
                File = file
            End Sub

        End Class ' class SubtitlePath

        Private Const m_myGroupBox1height As Integer  = 405
        Private Const m_panel1Top As Integer  = 148

        Private ReadOnly fntReqClear As System.Drawing.Font 
        Private ReadOnly fntReqError As System.Drawing.Font 

        Private _btnClear As Elegant.Ui.Button 
        Private _btnPublish As Elegant.Ui.Button 
        Private _disableImdbSet As Boolean 
        Private _displayTip As System.Windows.Forms.Timer 
        Private btnFindIMDB As Sublight.Controls.Button.Button 
        Private btnPublishOpenSubtitles As Sublight.Controls.Button.Button 
        Private btnRemove As Sublight.Controls.Button.Button 
        Private btnUseFolderName As Sublight.Controls.Button.Button 
        Private btnVideoFileSelect As Sublight.Controls.Button.Button 
        Private cbImdbNotAvailable As Sublight.Controls.MyCheckBox 
        Private cbLanguage As Sublight.Controls.MyComboBox 
        Private cbPublishDiscs As Sublight.Controls.MyComboBox 
        Private cbPublishFPS As Sublight.Controls.MyComboBox 
        Private cbPublishMedium As Sublight.Controls.MyComboBox 
        Private cbPublishMultipleSubtitles As Sublight.Controls.MyCheckBox 
        Private cbPublishType As Sublight.Controls.MyComboBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private label10 As System.Windows.Forms.Label 
        Private label11 As System.Windows.Forms.Label 
        Private label12 As System.Windows.Forms.Label 
        Private label13 As System.Windows.Forms.Label 
        Private label15 As System.Windows.Forms.Label 
        Private label5 As System.Windows.Forms.Label 
        Private label7 As System.Windows.Forms.Label 
        Private label8 As System.Windows.Forms.Label 
        Private label9 As System.Windows.Forms.Label 
        Private lblEpisode As System.Windows.Forms.Label 
        Private lblPublishDisclaimer As System.Windows.Forms.Label 
        Private lblReqDiscs As System.Windows.Forms.Label 
        Private lblReqFPS As System.Windows.Forms.Label 
        Private lblReqIMDB As System.Windows.Forms.Label 
        Private lblReqLanguage As System.Windows.Forms.Label 
        Private lblReqMedia As System.Windows.Forms.Label 
        Private lblReqSubtitle As System.Windows.Forms.Label 
        Private lblReqType As System.Windows.Forms.Label 
        Private lblSeason As System.Windows.Forms.Label 
        Private lblTipIMDb As System.Windows.Forms.Label 
        Private lblTipVideo As System.Windows.Forms.Label 
        Private legendRequiredField1 As Sublight.Controls.LegendRequiredField 
        Private m_externalSubtitle As Sublight.WS.Subtitle 
        Private m_SelectedSubtitles As System.Collections.Generic.List(Of Sublight.Controls.PromptedTextBox) 
        Private m_subtitleProvider As Sublight.Plugins.SubtitleProvider.ISubtitleProvider 
        Private myGroupBox1 As Sublight.Controls.MyGroupBox 
        Private myPanel1 As Sublight.Controls.MyPanel 
        Private openFileDialog1 As System.Windows.Forms.OpenFileDialog 
        Private panel1 As Sublight.Controls.MyPanel 
        Private panel2 As Sublight.Controls.Panel 
        Private txtComment As Sublight.Controls.MyTextBox 
        Private txtEpisode As Sublight.Controls.MyTextBox 
        Private txtPublishIMDB As Sublight.Controls.PromptedTextBox 
        Private txtPublishSubtitles As Sublight.Controls.PromptedTextBox 
        Private txtRelease As Sublight.Controls.MyTextBox 
        Private txtSeason As Sublight.Controls.MyTextBox 
        Private txtVideoFile As Sublight.Controls.PromptedTextBox 

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal rtp As Elegant.Ui.RibbonTabPage)
            fntReqClear = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            fntReqError = New System.Drawing.Font("Microsoft Sans Serif?", 22.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            m_SelectedSubtitles = New System.Collections.Generic.List(Of Sublight.Controls.PromptedTextBox)
            InitializeComponent()
            _btnPublish = TryCast(GetTabControlByName("btnPublish?"), Elegant.Ui.Button)
            If (_btnPublish) Is Nothing Then
                Throw New System.NullReferenceException("btnPublish?")
            End If
            AddHandler _btnPublish.Click, AddressOf btnPublish_Click
            _btnClear = TryCast(GetTabControlByName("btnPublishClear?"), Elegant.Ui.Button)
            If (_btnClear) Is Nothing Then
                Throw New System.NullReferenceException("btnPublishClear?")
            End If
            AddHandler _btnClear.Click, AddressOf btnClear_Click
            btnUseFolderName.Visible = False
            btnUseFolderName.AutoResize = True
            lblReqIMDB.Font.Dispose()
            lblReqSubtitle.Font.Dispose()
            lblReqLanguage.Font.Dispose()
            lblReqType.Font.Dispose()
            lblReqMedia.Font.Dispose()
            lblReqDiscs.Font.Dispose()
            lblReqFPS.Font.Dispose()
            EnableControls(False)
            HideTip()
            _displayTip = New System.Windows.Forms.Timer
            _displayTip.Interval = 100
            AddHandler _displayTip.Tick, AddressOf _displayTip_Tick
            AddHandler Sublight.Globals.Events.UserLogIn, AddressOf AppEvents_UserLogIn
            AddHandler Sublight.Globals.Events.UserLogOff, AddressOf AppEvents_UserLogOff
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            AddHandler Sublight.Globals.Events.SettingsLoaded, AddressOf Events_SettingsLoaded
        End Sub

        Private Sub _displayTip_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            _displayTip.Stop()
            DisplayTip()
        End Sub

        Private Sub AddHashLinkIfNecessary(ByVal subtitleId As System.Guid)
            Dim s2 As String

            If Not System.String.IsNullOrEmpty(txtVideoFile.Text) Then
                Dim s1 As String = Utility.Video.Checksum.Compute(txtVideoFile.Text)
                If System.String.IsNullOrEmpty(s1) Then
                    ParentBaseForm.ShowError(Sublight.Translation.Publish_Error_VideoHashCalculation, New object(0) {})
                    Return
                End If
                ParentBaseForm.AddHashLink(Me, subtitleId, s1, False, out s2)
            End If
        End Sub

        Private Sub AppEvents_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            Dim <>c__DisplayClass1_1 As Sublight.Controls.PagePublish.<>c__DisplayClass1 = New Sublight.Controls.PagePublish.<>c__DisplayClass1
            <>c__DisplayClass1_1.isAnonymous = isAnonymous
            <>c__DisplayClass1_1.<>4__this = Me
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass1_1.<AppEvents_UserLogIn>b__0)
            Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
            If IsActiveTab Then
                RibbonTabPage.Invalidate()
            End If
        End Sub

        Private Sub AppEvents_UserLogOff(ByVal sender As Object)
            If InvokeRequired Then
                Dim objArr1 As Object() = New object() { 0 }
                MyBase.BeginInvoke(New Sublight.Controls.PagePublish.EnableControlsDelegate(EnableControls), objArr1)
                Return
            End If
            EnableControls(False)
        End Sub

        Private Sub AutoSetImdbByVideoThread(ByVal arg As Object)
            Dim s2 As String
            Dim alternativeTitleArr1 As Sublight.WS.AlternativeTitle()

            If _disableImdbSet Then
                Return
            End If
            Dim s1 As String = TryCast(arg, string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            Try
                Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = Nothing
                Dim <>c__DisplayClasse1 As Sublight.Controls.PagePublish.<>c__DisplayClasse = New Sublight.Controls.PagePublish.<>c__DisplayClasse
                <>c__DisplayClasse1.<>4__this = Me
                <>c__DisplayClasse1.imdb = Sublight.Lib.IMDB.Util.FindImdbByVideo(s1)
                If Not System.String.IsNullOrEmpty(<>c__DisplayClasse1.imdb) AndAlso Not _disableImdbSet Then
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
                        Dim <>c__DisplayClass11_1 As Sublight.Controls.PagePublish.<>c__DisplayClass11 = New Sublight.Controls.PagePublish.<>c__DisplayClass11
                        <>c__DisplayClass11_1.CS$<>8__localsf = <>c__DisplayClasse1
                        If Not sublight1.GetDetails(Sublight.BaseForm.Session, <>c__DisplayClasse1.imdb, out <>c__DisplayClass11_1.imdbInfo, out alternativeTitleArr1, out s2) OrElse ((<>c__DisplayClass11_1.imdbInfo) Is Nothing) OrElse System.String.IsNullOrEmpty(<>c__DisplayClass11_1.imdbInfo.Title) Then
                            Return
                        End If
                        <>c__DisplayClass11_1.sbDetectedTitle = New System.Text.StringBuilder
                        If Not System.String.IsNullOrEmpty(<>c__DisplayClass11_1.imdbInfo.Title) Then
                            <>c__DisplayClass11_1.sbDetectedTitle.Append(<>c__DisplayClass11_1.imdbInfo.Title)
                        End If
                        Dim nullable5 As System.Nullable(Of Integer) = <>c__DisplayClass11_1.imdbInfo.Year
                        If nullable5.get_HasValue() AndAlso (<>c__DisplayClass11_1.sbDetectedTitle.Length > 0) Then
                            Dim nullable6 As System.Nullable(Of Integer) = <>c__DisplayClass11_1.imdbInfo.Year
                            <>c__DisplayClass11_1.sbDetectedTitle.AppendFormat(" ({0})?", nullable6.get_Value())
                        End If
                        Dim nullable7 As System.Nullable(Of Integer) = <>c__DisplayClass11_1.imdbInfo.Season
                        If nullable7.get_HasValue() Then
                            Dim nullable2 As System.Nullable(Of Integer) = <>c__DisplayClass11_1.imdbInfo.Episode
                            If nullable2.get_HasValue() AndAlso (<>c__DisplayClass11_1.sbDetectedTitle.Length > 0) Then
                                Dim nullable1 As System.Nullable(Of Integer) = <>c__DisplayClass11_1.imdbInfo.Season
                                Dim nullable4 As System.Nullable(Of Integer) = <>c__DisplayClass11_1.imdbInfo.Episode
                                <>c__DisplayClass11_1.sbDetectedTitle.AppendFormat(", S{0:00}E{1:00}?", nullable1.get_Value(), nullable4.get_Value())
                            End If
                        End If
                        If (methodInvoker3) Is Nothing Then
                            methodInvoker3 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClasse1.<AutoSetImdbByVideoThread>b__a)
                        End If
                        Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker3
                        Sublight.BaseForm.DoCtrlInvoke(txtPublishIMDB, Me, methodInvoker1)
                        methodInvoker1 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass11_1.<AutoSetImdbByVideoThread>b__b)
                        Sublight.BaseForm.DoCtrlInvoke(lblTipIMDb, Me, methodInvoker1)
                        If Not (<>c__DisplayClass11_1.imdbInfo) Is Nothing Then
                            Dim nullable3 As System.Nullable(Of Sublight.WS.Genre) = <>c__DisplayClass11_1.imdbInfo.Genre
                            If nullable3.get_HasValue() Then
                                If (methodInvoker2) Is Nothing Then
                                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass11_1.<AutoSetImdbByVideoThread>b__c)
                                End If
                                methodInvoker1 = methodInvoker2
                            End If
                        End If
                        Sublight.BaseForm.DoCtrlInvoke(cbPublishType, Me, methodInvoker1)
                    End Using
                End If
            Catch 
            End Try
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ClearFields()
        End Sub

        Private Sub btnFindIMDB_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            _disableImdbSet = True
            lblTipIMDb.Visible = False
            lblTipIMDb.Text = System.String.Empty
            Dim frmIMDBSelector1 As Sublight.FrmIMDBSelector = New Sublight.FrmIMDBSelector
            If frmIMDBSelector1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                txtPublishIMDB.Text = frmIMDBSelector1.IMDB
                TryGuessGenreAsync(frmIMDBSelector1.ImdbId)
            End If
            frmIMDBSelector1.Dispose()
        End Sub

        Private Sub btnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s4 As String
            Dim guid1 As System.Guid

            Try
                ParentBaseForm.ShowLoader(Me)
                Dim flag1 As Boolean = False
                ShowRequiredFields(False)
                ClearRequiredFieldsErrors()
                If System.String.IsNullOrEmpty(txtPublishIMDB.Text) Then
                    flag1 = True
                    SetError(lblReqIMDB)
                End If
                If (Not (txtPublishIMDB.Text) Is Nothing) AndAlso cbImdbNotAvailable.Checked AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtPublishIMDB.Text, ".*?tt\d{5,}?.*??", System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                    flag1 = True
                    SetError(lblReqIMDB)
                End If
                If (((m_subtitleProvider) Is Nothing) OrElse System.String.IsNullOrEmpty(m_externalSubtitle.ExternalId)) AndAlso (System.String.IsNullOrEmpty(txtPublishSubtitles.Text) OrElse Not System.IO.File.Exists(txtPublishSubtitles.Text)) Then
                    SetError(lblReqSubtitle)
                    flag1 = True
                End If
                Dim s1 As String = Nothing
                If (txtPublishSubtitles.Text) Is Nothing Then
                    Return
                End If
                If Not System.String.IsNullOrEmpty(txtPublishSubtitles.Text) AndAlso System.IO.File.Exists(txtPublishSubtitles.Text) AndAlso (CInt((New System.IO.FileInfo(txtPublishSubtitles.Text)).Length) > 512000) Then
                    SetError(lblReqSubtitle)
                    ParentBaseForm.ShowError(Sublight.Translation.Publish_Error_FileTooBig, New object(0) {})
                    Return
                End If
                If txtPublishSubtitles.Text.EndsWith(".rar?", System.StringComparison.InvariantCultureIgnoreCase) Then
                    s1 = System.Convert.ToBase64String(Sublight.Plugins.SubtitleProvider.Compression.Utility.RarToZip(System.IO.File.ReadAllBytes(txtPublishSubtitles.Text)))
                ElseIf Not txtPublishSubtitles.Text.EndsWith(".zip?", System.StringComparison.InvariantCultureIgnoreCase) Then
                    Dim i1 As Integer = 0
                    While i1 < (m_SelectedSubtitles.get_Count() - 1)
                        Dim promptedTextBox1 As Sublight.Controls.PromptedTextBox = m_SelectedSubtitles.get_Item(i1)
                        If System.IO.Path.GetExtension(txtPublishSubtitles.Text).ToLower() <> System.IO.Path.GetExtension(promptedTextBox1.Text).ToLower() Then
                            SetError(lblReqSubtitle)
                            flag1 = True
                            Exit While
                        End If
                        i1 = i1 + 1
                    End While
                    If ((m_subtitleProvider) Is Nothing) OrElse System.String.IsNullOrEmpty(m_externalSubtitle.ExternalId) OrElse Not flag1 Then
                        Try
                            s1 = System.Convert.ToBase64String(Sublight.MyUtility.Plugin.DownloadSubtitleById(Me, m_subtitleProvider, m_externalSubtitle))
                            GoTo label_1
                        Catch e1 As System.Exception
                            Dim objArr1 As Object() = New object() { e1.Message }
                            ParentBaseForm.ShowError(Sublight.Translation.Plugin_SubtitleProvider_ErrorDownloading, objArr1)
                            Return
                        End Try
                        If Not flag1 Then
                            Dim i2 As Integer = 0
                            While i2 < (m_SelectedSubtitles.get_Count() - 1)
                                Dim promptedTextBox2 As Sublight.Controls.PromptedTextBox = m_SelectedSubtitles.get_Item(i2)
                                If System.String.IsNullOrEmpty(promptedTextBox2.Text) OrElse Not System.IO.File.Exists(promptedTextBox2.Text) Then
                                    SetError(lblReqSubtitle)
                                    flag1 = True
                                    Exit While
                                End If
                                i2 = i2 + 1
                            End While
                        End If
                        If Not flag1 Then
                            Try
                                Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream
                                    Using zipOutputStream1 As ICSharpCode.SharpZipLib.Zip.ZipOutputStream = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(memoryStream1)
                                        zipOutputStream1.SetLevel(9)
                                        Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                                        list1.Add(txtPublishSubtitles.Text)
                                        Dim i3 As Integer = 0
                                        While i3 < (m_SelectedSubtitles.get_Count() - 1)
                                            Dim promptedTextBox3 As Sublight.Controls.PromptedTextBox = m_SelectedSubtitles.get_Item(i3)
                                            list1.Add(promptedTextBox3.Text)
                                            i3 = i3 + 1
                                        End While
                                        Dim enumerator1 As System.Collections.Generic.List(Of String).Enumerator = list1.GetEnumerator()
                                        Try
                                            While enumerator1.MoveNext()
                                                Dim s2 As String = enumerator1.get_Current()
                                                Dim s3 As String = System.IO.Path.GetFileName(s2)
                                                Dim zipEntry1 As ICSharpCode.SharpZipLib.Zip.ZipEntry = New ICSharpCode.SharpZipLib.Zip.ZipEntry(s3)
                                                zipEntry1.DateTime = System.DateTime.Now
                                                zipOutputStream1.PutNextEntry(zipEntry1)
                                                Dim bArr1 As Byte() = System.IO.File.ReadAllBytes(s2)
                                                zipOutputStream1.Write(bArr1, 0, bArr1.Length)
                                            End While
                                        Finally
                                            enumerator1.Dispose()
                                        End Try
                                        zipOutputStream1.Finish()
                                        zipOutputStream1.Flush()
                                        s1 = System.Convert.ToBase64String(memoryStream1.ToArray())
                                        zipOutputStream1.Close()
                                        zipOutputStream1.Dispose()
                                    End Using
                                End Using
                            Catch e2 As System.Exception
                                Sublight.BaseForm.ReportException("Sublight.Controls.PagePublish.btnPublish_Click?", e2)
                                Dim objArr2 As Object() = New object() { e2.Message }
                                ParentBaseForm.ShowError(Sublight.Translation.Publish_Error_Publishing, objArr2)
                                Return
                            End Try
                        End If
                    End If
                End If
            label_1: _
                If Not System.String.IsNullOrEmpty(txtVideoFile.Text) AndAlso Not System.IO.File.Exists(txtVideoFile.Text) Then
                    ParentBaseForm.ShowWarning(Sublight.Translation.Publish_Warning_VideoFileDoesNotExist, New object(0) {})
                    Return
                End If
                Dim subtitle1 As Sublight.WS.Subtitle = New Sublight.WS.Subtitle
                subtitle1.IMDB = txtPublishIMDB.Text
                If Sublight.Types.ListItem.IsNotSelected(TryCast(cbLanguage.SelectedItem, Sublight.Types.ListItem)) Then
                    SetError(lblReqLanguage)
                    flag1 = True
                Else 
                    Dim listItem1 As Sublight.Types.ListItem = TryCast(cbLanguage.SelectedItem, Sublight.Types.ListItem)
                    If Not (listItem1) Is Nothing Then
                        subtitle1.Language = DirectCast(listItem1.Value, Sublight.WS.SubtitleLanguage)
                    End If
                End If
                If Sublight.Types.ListItem.IsNotSelected(TryCast(cbPublishType.SelectedItem, Sublight.Types.ListItem)) Then
                    SetError(lblReqType)
                    flag1 = True
                Else 
                    Dim listItem2 As Sublight.Types.ListItem = TryCast(cbPublishType.SelectedItem, Sublight.Types.ListItem)
                    If Not (listItem2) Is Nothing Then
                        subtitle1.Genre = DirectCast(listItem2.Value, Sublight.WS.Genre)
                    End If
                End If
                If Sublight.Types.ListItem.IsNotSelected(TryCast(cbPublishMedium.SelectedItem, Sublight.Types.ListItem)) Then
                    SetError(lblReqMedia)
                    flag1 = True
                Else 
                    Dim listItem3 As Sublight.Types.ListItem = TryCast(cbPublishMedium.SelectedItem, Sublight.Types.ListItem)
                    If Not (listItem3) Is Nothing Then
                        subtitle1.MediaType = DirectCast(listItem3.Value, Sublight.WS.MediaType)
                    End If
                End If
                If Sublight.Types.ListItem.IsNotSelected(TryCast(cbPublishDiscs.SelectedItem, Sublight.Types.ListItem)) Then
                    SetError(lblReqDiscs)
                    flag1 = True
                Else 
                    Dim listItem4 As Sublight.Types.ListItem = TryCast(cbPublishDiscs.SelectedItem, Sublight.Types.ListItem)
                    If Not (listItem4) Is Nothing Then
                        subtitle1.NumberOfDiscs = System.Convert.ToByte(listItem4.Value)
                    End If
                End If
                If Sublight.Types.ListItem.IsNotSelected(TryCast(cbPublishFPS.SelectedItem, Sublight.Types.ListItem)) Then
                    SetError(lblReqFPS)
                    flag1 = True
                Else 
                    Dim listItem5 As Sublight.Types.ListItem = TryCast(cbPublishFPS.SelectedItem, Sublight.Types.ListItem)
                    If Not (listItem5) Is Nothing Then
                        subtitle1.FPS = DirectCast(listItem5.Value, Sublight.WS.FPS)
                    End If
                End If
                If System.String.IsNullOrEmpty(txtComment.Text) Then
                    subtitle1.Comment = Nothing
                Else 
                    subtitle1.Comment = txtComment.Text
                End If
                If txtSeason.Visible AndAlso Not System.String.IsNullOrEmpty(txtSeason.Text) Then
                    Try
                        subtitle1.Season = New System.Nullable(Of Byte)(System.Byte.Parse(txtSeason.Text))
                    Catch 
                        ParentBaseForm.ShowError(Sublight.Translation.Publish_Error_ParsingSeason, New object(0) {})
                        Return
                    End Try
                End If
                If txtEpisode.Visible AndAlso Not System.String.IsNullOrEmpty(txtEpisode.Text) Then
                    Try
                        subtitle1.Episode = New System.Nullable(Of Integer)(System.Int32.Parse(txtEpisode.Text))
                    Catch 
                        ParentBaseForm.ShowError(Sublight.Translation.Publish_Error_ParsingEpisode, New object(0) {})
                        Return
                    End Try
                End If
                If System.String.IsNullOrEmpty(txtRelease.Text) Then
                    subtitle1.Release = Nothing
                Else 
                    subtitle1.Release = txtRelease.Text
                End If
                If flag1 Then
                    ParentBaseForm.ShowError(Sublight.Translation.Publish_Error_RequiredFields, New object(0) {})
                    Return
                End If
                ClearRequiredFieldsErrors()
                ShowRequiredFields(True)
                If System.String.IsNullOrEmpty(s1) Then
                    s1 = System.Convert.ToBase64String(System.IO.File.ReadAllBytes(txtPublishSubtitles.Text))
                End If
                If cbImdbNotAvailable.Checked Then
                    subtitle1.IMDB = "nn?"
                    subtitle1.NonImdbTitle = txtPublishIMDB.Text
                Else 
                    subtitle1.NonImdbTitle = Nothing
                End If
                If Not PublishSubtitle(Me, subtitle1, s1, out guid1, out s4) Then
                    If System.String.Compare(s4, "SubtitlesNotValid?", True) = 0 Then
                        ParentBaseForm.ShowError(Sublight.Translation.Publish_Error_Publishing_SubtitlesNotValid, New object(0) {})
                    ElseIf System.String.Compare(s4, "SubtitleAlreadyExists?", True) = 0 Then
                        AddHashLinkIfNecessary(guid1)
                        ParentBaseForm.ShowWarning(Sublight.Translation.Publish_Info_Publishing_SubtitleAlreadyExists, New object(0) {})
                    Else 
                        Dim objArr3 As Object() = New object() { s4 }
                        ParentBaseForm.ShowError(Sublight.Translation.Publish_Error_Publishing, objArr3)
                    End If
                    Return
                End If
                AddHashLinkIfNecessary(guid1)
                ParentBaseForm.ShowInfo(Sublight.Translation.Publish_Info_SuccessfullyPublished, New object(0) {})
                If cbPublishMultipleSubtitles.Checked Then
                    ClearDynamicTextboxes()
                    btnPublishOpenSubtitles_Click(Me, Nothing)
                End If
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Sub btnPublishOpenSubtitles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            openFileDialog1.FileName = System.String.Empty
            openFileDialog1.Title = Sublight.Translation.Dialog_OpenSubtitleArchive_Title
            Dim flag1 As Boolean = False
            If TypeOf sender Is Sublight.Controls.PagePublish.SubtitlePath Then
                Dim subtitlePath1 As Sublight.Controls.PagePublish.SubtitlePath = TryCast(sender, Sublight.Controls.PagePublish.SubtitlePath)
                openFileDialog1.FileName = subtitlePath1.File
                flag1 = True
            ElseIf sender = btnPublishOpenSubtitles Then
                openFileDialog1.Filter = Sublight.Translation.Dialog_OpenSubtitleArchive_Filter
            Else 
                Dim s1 As String = System.IO.Path.GetExtension(txtPublishSubtitles.Text)
                If System.String.Compare(s1, ".sub?", True) = 0 Then
                    openFileDialog1.Filter = System.String.Format(Sublight.Translation.Dialog_OpenSubtitle_Filter, "sub?")
                ElseIf System.String.Compare(s1, ".srt?", True) = 0 Then
                    openFileDialog1.Filter = System.String.Format(Sublight.Translation.Dialog_OpenSubtitle_Filter, "srt?")
                ElseIf System.String.Compare(s1, ".sami?", True) = 0 Then
                    openFileDialog1.Filter = System.String.Format(Sublight.Translation.Dialog_OpenSubtitle_Filter, "sami?")
                Else 
                    Return
                End If
            End If
            If flag1 OrElse (openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                m_externalSubtitle = Nothing
                m_subtitleProvider = Nothing
                Dim promptedTextBox1 As Sublight.Controls.PromptedTextBox = Nothing
                If flag1 OrElse (sender = btnPublishOpenSubtitles) Then
                    ClearDynamicTextboxes()
                    promptedTextBox1 = txtPublishSubtitles
                Else 
                    If System.String.Compare(txtPublishSubtitles.Text, openFileDialog1.FileName, True) = 0 Then
                        ParentBaseForm.ShowWarning(Sublight.Translation.Publish_Warning_SameSubtitleIsAlreadySelected, New object(0) {})
                        Return
                    End If
                    Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Controls.PromptedTextBox).Enumerator = m_SelectedSubtitles.GetEnumerator()
                    Try
                        While enumerator1.MoveNext()
                            Dim promptedTextBox2 As Sublight.Controls.PromptedTextBox = enumerator1.get_Current()
                            If System.String.Compare(promptedTextBox2.Text, openFileDialog1.FileName, True) = 0 Then
                                ParentBaseForm.ShowWarning(Sublight.Translation.Publish_Warning_SameSubtitleIsAlreadySelected, New object(0) {})
                                GoTo label_1
                            End If
                        End While
                    Finally
                        enumerator1.Dispose()
                    End Try
                    Dim control1 As System.Windows.Forms.Control = TryCast(sender, System.Windows.Forms.Control)
                    If Not (control1) Is Nothing Then
                        promptedTextBox1 = TryCast(control1.Tag, Sublight.Controls.PromptedTextBox)
                    End If
                End If
                If (promptedTextBox1) Is Nothing Then
                label_1: _
                    Return
                End If
                promptedTextBox1.Text = openFileDialog1.FileName
                promptedTextBox1.SelectionStart = promptedTextBox1.Text.Length
                If promptedTextBox1 = txtPublishSubtitles Then
                    Dim s2 As String = txtPublishSubtitles.Text
                    Try
                        Dim match1 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s2, "\b(?<season>[0-9]*?)[xX]{1,1}(?<episode>[0-9]*?)\b?")
                        If match1.Success Then
                            FillSeasonEpisode(match1)
                        Else 
                            match1 = System.Text.RegularExpressions.Regex.Match(s2, "\b[sS]{1,1}(?<season>[0-9]*?)[eE]{1,1}(?<episode>[0-9]*?)\b?")
                            If match1.Success Then
                                FillSeasonEpisode(match1)
                            End If
                        End If
                    Catch 
                    End Try
                End If
                Dim flag2 As Boolean = False
                If promptedTextBox1 = txtPublishSubtitles Then
                    If (Not promptedTextBox1.Text.EndsWith(".sub?", System.StringComparison.InvariantCultureIgnoreCase) AndAlso Not promptedTextBox1.Text.EndsWith(".srt?", System.StringComparison.InvariantCultureIgnoreCase)) OrElse (m_SelectedSubtitles.get_Count() <= 0) Then
                        flag2 = True
                    End If
                ElseIf m_SelectedSubtitles.Contains(promptedTextBox1) Then
                    Dim i1 As Integer = m_SelectedSubtitles.IndexOf(promptedTextBox1)
                    If i1 = (m_SelectedSubtitles.get_Count() - 1) Then
                        flag2 = True
                    End If
                End If
                If flag2 Then
                    Dim promptedTextBox3 As Sublight.Controls.PromptedTextBox = New Sublight.Controls.PromptedTextBox
                    Dim guid1 As System.Guid = System.Guid.NewGuid()
                    promptedTextBox3.Name = System.String.Format("nextSubtitle_{0}?", guid1.ToString("N?"))
                    Dim guid2 As System.Guid = System.Guid.NewGuid()
                    promptedTextBox3.Id = guid2.ToString("N?")
                    promptedTextBox3.Width = promptedTextBox1.Width
                    promptedTextBox3.Height = promptedTextBox1.Height
                    promptedTextBox3.Left = promptedTextBox1.Left
                    promptedTextBox3.Top = promptedTextBox1.Top + promptedTextBox1.Height + 7
                    promptedTextBox3.ReadOnly = True
                    promptedTextBox3.PromptText = Sublight.Translation.Publish_Panel_SubtitleDetails_Subtitle_AddNextSubtitle
                    m_SelectedSubtitles.Add(promptedTextBox3)
                    Dim button1 As Sublight.Controls.Button.Button = New Sublight.Controls.Button.Button
                    button1.Width = btnPublishOpenSubtitles.Width
                    button1.Height = btnPublishOpenSubtitles.Height
                    button1.Name = System.String.Format("btnSelectSubtitle_{0}?", promptedTextBox3.Name)
                    button1.Tag = promptedTextBox3
                    button1.Text = Sublight.Translation.Common_Button_ChooseFile
                    button1.Left = btnPublishOpenSubtitles.Left
                    button1.Top = promptedTextBox3.Top - 1
                    AddHandler button1.Click, AddressOf btnPublishOpenSubtitles_Click
                    btnRemove.Left = btnPublishOpenSubtitles.Left + btnPublishOpenSubtitles.Width + 7
                    btnRemove.Top = promptedTextBox1.Top - 1
                    btnRemove.Visible = m_SelectedSubtitles.get_Count() > 1
                    btnRemove.Tag = promptedTextBox1
                    myGroupBox1.Controls.Add(promptedTextBox3)
                    myGroupBox1.Controls.Add(button1)
                    myPanel1.Top = 148 + (m_SelectedSubtitles.get_Count() * (promptedTextBox3.Height + 7))
                    myGroupBox1.Height = 405 + (m_SelectedSubtitles.get_Count() * (promptedTextBox3.Height + 7))
                End If
            End If
            If txtPublishSubtitles.Text.EndsWith(".zip?", System.StringComparison.InvariantCultureIgnoreCase) Then
                Try
                    Dim zipFile1 As ICSharpCode.SharpZipLib.Zip.ZipFile = New ICSharpCode.SharpZipLib.Zip.ZipFile(txtPublishSubtitles.Text)
                    If CInt(zipFile1.Count) > 0 Then
                        Dim ienumerator1 As System.Collections.IEnumerator = zipFile1.GetEnumerator()
                        Dim i2 As Integer = 0
                        While ienumerator1.MoveNext()
                            Dim zipEntry1 As ICSharpCode.SharpZipLib.Zip.ZipEntry = TryCast(ienumerator1.Current, ICSharpCode.SharpZipLib.Zip.ZipEntry)
                            If (Not (zipEntry1) Is Nothing) AndAlso zipEntry1.IsFile Then
                                i2 = i2 + 1
                            End If
                        End While
                        Dim i3 As Integer = 0
                        While i3 < cbPublishDiscs.Items.Count
                            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbPublishDiscs.Items(i3), Sublight.Types.ListItem)
                            If (Not (listItem1) Is Nothing) AndAlso (TypeOf listItem1.Value Is int) AndAlso (DirectCast(listItem1.Value, int) = i2) Then
                                cbPublishDiscs.SelectedIndex = i3
                                Exit While
                            End If
                            i3 = i3 + 1
                        End While
                    End If
                    Return
                Catch 
                    Return
                End Try
            End If
            If txtPublishSubtitles.Text.EndsWith(".rar?", System.StringComparison.InvariantCultureIgnoreCase) Then
                Return
            End If
            Dim i4 As Integer = m_SelectedSubtitles.get_Count()
            Dim i5 As Integer = 0
            While i5 < cbPublishDiscs.Items.Count
                Dim listItem2 As Sublight.Types.ListItem = TryCast(cbPublishDiscs.Items(i5), Sublight.Types.ListItem)
                If (Not (listItem2) Is Nothing) AndAlso (TypeOf listItem2.Value Is int) AndAlso (DirectCast(listItem2.Value, int) = i4) Then
                    cbPublishDiscs.SelectedIndex = i5
                    Return
                End If
                i5 = i5 + 1
            End While
        End Sub

        Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim promptedTextBox1 As Sublight.Controls.PromptedTextBox = TryCast(btnRemove.Tag, Sublight.Controls.PromptedTextBox)
            If (promptedTextBox1) Is Nothing Then
                Return
            End If
            If Not m_SelectedSubtitles.Contains(promptedTextBox1) Then
                Return
            End If
            m_SelectedSubtitles.Remove(promptedTextBox1)
            If myGroupBox1.Controls.Contains(promptedTextBox1) Then
                myGroupBox1.Controls.Remove(promptedTextBox1)
            End If
            Dim s1 As String = System.String.Format("btnSelectSubtitle_{0}?", promptedTextBox1.Name)
            Dim controlArr1 As System.Windows.Forms.Control() = myGroupBox1.Controls.Find(s1, False)
            If (Not (controlArr1) Is Nothing) AndAlso (controlArr1.Length = 1) Then
                myGroupBox1.Controls.Remove(controlArr1(0))
                controlArr1(0).Dispose()
            End If
            btnRemove.Left = btnPublishOpenSubtitles.Left + btnPublishOpenSubtitles.Width + 7
            If m_SelectedSubtitles.get_Count() > 0 Then
                m_SelectedSubtitles.get_Item(m_SelectedSubtitles.get_Count() - 1).Top = promptedTextBox1.Top
                s1 = System.String.Format("btnSelectSubtitle_{0}?", m_SelectedSubtitles.get_Item(m_SelectedSubtitles.get_Count() - 1).Name)
                controlArr1 = myGroupBox1.Controls.Find(s1, False)
                If (Not (controlArr1) Is Nothing) AndAlso (controlArr1.Length = 1) Then
                    controlArr1(0).Top = m_SelectedSubtitles.get_Item(m_SelectedSubtitles.get_Count() - 1).Top - 1
                End If
            End If
            If m_SelectedSubtitles.get_Count() > 1 Then
                btnRemove.Top = m_SelectedSubtitles.get_Item(m_SelectedSubtitles.get_Count() - 2).Top - 1
                btnRemove.Tag = m_SelectedSubtitles.get_Item(m_SelectedSubtitles.get_Count() - 2)
                btnRemove.Visible = True
            Else 
                btnRemove.Visible = False
            End If
            myPanel1.Top = 148 + (m_SelectedSubtitles.get_Count() * (promptedTextBox1.Height + 7))
            myGroupBox1.Height = 405 + (m_SelectedSubtitles.get_Count() * (promptedTextBox1.Height + 7))
            promptedTextBox1.Dispose()
            Dim i1 As Integer = m_SelectedSubtitles.get_Count()
            Dim i2 As Integer = 0
            While i2 < cbPublishDiscs.Items.Count
                Dim listItem1 As Sublight.Types.ListItem = TryCast(cbPublishDiscs.Items(i2), Sublight.Types.ListItem)
                If (Not (listItem1) Is Nothing) AndAlso TryCast(listItem1.Value, int) AndAlso (DirectCast(listItem1.Value, int) = i1) Then
                    cbPublishDiscs.SelectedIndex = i2
                    Return
                End If
                i2 = i2 + 1
            End While
        End Sub

        Private Sub btnUseFolderName_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            txtRelease.Text = System.String.Empty
            If System.String.IsNullOrEmpty(txtVideoFile.Text) Then
                Return
            End If
            Try
                If System.IO.File.Exists(txtVideoFile.Text) Then
                    Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(txtVideoFile.Text)
                    If Not (fileInfo1.Directory) Is Nothing Then
                        txtRelease.Text = fileInfo1.Directory.Name
                        If txtRelease.Text.Length > 0 Then
                            txtRelease.SelectionStart = txtRelease.Text.Length - 1
                        End If
                    End If
                End If
            Catch 
            End Try
        End Sub

        Private Sub btnVideoFileSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            openFileDialog1.FileName = System.String.Empty
            openFileDialog1.Title = Sublight.Translation.Dialog_OpenVideo_Title
            openFileDialog1.Filter = Sublight.Globals.OpenVideo_Filter
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                txtVideoFile.Text = openFileDialog1.FileName
                btnUseFolderName.Visible = True
                If txtVideoFile.Text.Length > 0 Then
                    txtVideoFile.SelectionStart = txtVideoFile.Text.Length - 1
                End If
                txtRelease.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName)
                TrySetMediaType()
                TrySetFramerate()
                TrySetImdb()
                TrySetSubtitle()
            End If
        End Sub

        Private Sub cbImdbNotAvailable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If cbImdbNotAvailable.Checked Then
                label7.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_MovieTitle
                btnFindIMDB.Visible = False
                txtPublishIMDB.PromptText = Sublight.Translation.Publish_Panel_SubtitleDetails_NonIMDB_Example
                Return
            End If
            label7.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_IMDB
            btnFindIMDB.Visible = True
            txtPublishIMDB.PromptText = Sublight.Translation.Publish_Panel_SubtitleDetails_IMDB_Example
        End Sub

        Private Sub cbPublishType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim flag1 As Boolean

            If Sublight.Types.ListItem.IsNotSelected(TryCast(cbPublishType.SelectedItem, Sublight.Types.ListItem)) Then
                flag1 = False
            Else 
                Dim listItem1 As Sublight.Types.ListItem = TryCast(cbPublishType.SelectedItem, Sublight.Types.ListItem)
                If Not (listItem1) Is Nothing Then
                    Dim genre1 As Sublight.WS.Genre = DirectCast(listItem1.Value, Sublight.WS.Genre)
                    flag1 = genre1 <> Sublight.WS.Genre.Movie
                Else 
                    flag1 = False
                End If
            End If
            ShowHideSeasonEpisode(flag1)
        End Sub

        Private Sub ClearDynamicTextboxes()
            Dim i1 As Integer = 0
            While i1 < m_SelectedSubtitles.get_Count()
                Dim promptedTextBox1 As Sublight.Controls.PromptedTextBox = m_SelectedSubtitles.get_Item(i1)
                Dim s1 As String = System.String.Format("btnSelectSubtitle_{0}?", promptedTextBox1.Name)
                Dim controlArr1 As System.Windows.Forms.Control() = myGroupBox1.Controls.Find(s1, False)
                If (Not (controlArr1) Is Nothing) AndAlso (controlArr1.Length = 1) Then
                    myGroupBox1.Controls.Remove(controlArr1(0))
                    controlArr1(0).Dispose()
                End If
                If myGroupBox1.Controls.Contains(promptedTextBox1) Then
                    myGroupBox1.Controls.Remove(promptedTextBox1)
                End If
                promptedTextBox1.Dispose()
                i1 = i1 + 1
            End While
            m_SelectedSubtitles.Clear()
            btnRemove.Visible = m_SelectedSubtitles.get_Count() > 1
            myPanel1.Top = 148 + (m_SelectedSubtitles.get_Count() * (txtPublishSubtitles.Height + 7))
            myGroupBox1.Height = 405 + (m_SelectedSubtitles.get_Count() * (txtPublishSubtitles.Height + 7))
        End Sub

        Private Sub ClearFields()
            m_externalSubtitle = Nothing
            m_subtitleProvider = Nothing
            txtVideoFile.Text = System.String.Empty
            txtPublishIMDB.Text = System.String.Empty
            txtPublishSubtitles.Text = System.String.Empty
            Sublight.Globals.SelectNotSelected(cbLanguage)
            Sublight.Globals.SelectNotSelected(cbPublishType)
            Sublight.Globals.SelectNotSelected(cbPublishMedium)
            Sublight.Globals.SelectNotSelected(cbPublishDiscs)
            Sublight.Globals.SelectNotSelected(cbPublishFPS)
            txtComment.Text = System.String.Empty
            txtSeason.Text = System.String.Empty
            txtEpisode.Text = System.String.Empty
            txtRelease.Text = System.String.Empty
            cbImdbNotAvailable.Checked = False
            ClearRequiredFieldsErrors()
            ShowRequiredFields(True)
            ClearDynamicTextboxes()
            openFileDialog1.InitialDirectory = Nothing
            btnUseFolderName.Visible = False
            _disableImdbSet = False
            lblTipIMDb.Visible = False
        End Sub

        Private Sub ClearRequiredFieldsErrors()
            lblReqIMDB.Font = fntReqClear
            lblReqSubtitle.Font = fntReqClear
            lblReqLanguage.Font = fntReqClear
            lblReqType.Font = fntReqClear
            lblReqMedia.Font = fntReqClear
            lblReqDiscs.Font = fntReqClear
            lblReqFPS.Font = fntReqClear
        End Sub

        Private Sub DisplayTip()
            If txtPublishIMDB.Focused Then
                lblTipIMDb.Text = Sublight.Translation.Common_Tip_EnterOpensDialog
                lblTipIMDb.Visible = True
                Return
            End If
            If txtVideoFile.Focused Then
                lblTipVideo.Visible = True
            End If
        End Sub

        Private Sub EnableControls(ByVal enabled As Boolean)
            panel1.Enabled = enabled
            _btnPublish.Enabled = enabled
            _btnClear.Enabled = enabled
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            _btnClear.Text = Sublight.Translation.Common_Toolbar_ClearFields
            _btnPublish.Text = Sublight.Translation.Publish_Toolbar_PublishSubtitle
            legendRequiredField1.Translate()
            btnVideoFileSelect.Text = Sublight.Translation.Common_Button_ChooseFile
            btnFindIMDB.Text = Sublight.Translation.Common_Button_FindDialog
            btnPublishOpenSubtitles.Text = Sublight.Translation.Common_Button_ChooseFile
            myGroupBox1.Text = Sublight.Translation.Publish_Panel_SubtitleDetails
            label5.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_VideoFile
            label7.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_IMDB
            label8.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_SubtitleArchive
            label9.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_Language
            label10.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_Genre
            label11.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_MediaType
            label12.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_Discs
            label13.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_FPS
            label1.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_Release
            label15.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_Comment
            lblSeason.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_Season
            lblEpisode.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_Episode
            cbImdbNotAvailable.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_ImdbNotAvailable
            cbPublishMultipleSubtitles.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_PublishMultipleSubtitles
            lblTipIMDb.Text = Sublight.Translation.Common_Tip_EnterOpensDialog
            lblTipVideo.Text = Sublight.Translation.Common_Tip_EnterOpensDialog
            btnUseFolderName.Text = Sublight.Translation.Publish_Panel_SubtitleDetails_Button_UseFolderNameForReleaseName
            Dim buttonArr1 As Sublight.Controls.Button.Button() = New Sublight.Controls.Button.Button() { btnUseFolderName }
            Sublight.Controls.Button.Button.MakeSameWidth(buttonArr1)
            label7.Text = IIf(cbImdbNotAvailable.Checked, Sublight.Translation.Publish_Panel_SubtitleDetails_MovieTitle, Sublight.Translation.Publish_Panel_SubtitleDetails_IMDB)
            btnRemove.Text = Sublight.Translation.Common_Button_Remove
            lblPublishDisclaimer.Text = Sublight.Translation.Publish_Note_Disclaimer
            FillMediaType()
            FillDiscsCount()
            FillFPS()
            FillLanguages(False)
            FillGenres()
            txtPublishIMDB.PromptText = IIf(cbImdbNotAvailable.Checked, Sublight.Translation.Publish_Panel_SubtitleDetails_NonIMDB_Example, Sublight.Translation.Publish_Panel_SubtitleDetails_IMDB_Example)
            txtVideoFile.PromptText = Sublight.Translation.Publish_Panel_SubtitleDetails_VideoFile_CueBanner
        End Sub

        Private Sub Events_SettingsLoaded(ByVal sender As Object)
            FillLanguages(True)
        End Sub

        Private Sub FillDiscsCount()
            Dim i1 As Integer = cbPublishDiscs.SelectedIndex
            cbPublishDiscs.Items.Clear()
            Dim i2 As Integer = 1
            While i2 <= 5
                cbPublishDiscs.Items.Add(New Sublight.Types.ListItem(System.String.Format("{0}?", i2), i2))
                i2 = i2 + 1
            End While
            Sublight.Globals.BindNotSelected(cbPublishDiscs, True)
            If i1 >= 0 Then
                cbPublishDiscs.SelectedIndex = i1
            End If
        End Sub

        Private Sub FillFPS()
            Dim i1 As Integer = cbPublishFPS.SelectedIndex
            cbPublishFPS.Items.Clear()
            Dim fpsArr1 As Sublight.WS.FPS() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.FPS)), Sublight.WS.FPS[])
            If (fpsArr1) Is Nothing Then
                Return
            End If
            Dim fpsArr2 As Sublight.WS.FPS() = fpsArr1
            Dim i2 As Integer = 0
            While i2 < fpsArr2.Length
                Dim fps1 As Sublight.WS.FPS = CType(fpsArr2(i2), Sublight.WS.FPS)
                If fps1 <> Sublight.WS.FPS.NotSet Then
                    cbPublishFPS.Items.Add(New Sublight.Types.ListItem(Sublight.Globals.GetString(System.String.Format("FPS_{0}?", System.Enum.GetName(GetType(Sublight.WS.FPS), fps1))), fps1))
                End If
                i2 = i2 + 1
            End While
            Sublight.Globals.BindNotSelected(cbPublishFPS, True)
            If i1 >= 0 Then
                cbPublishFPS.SelectedIndex = i1
            End If
        End Sub

        Private Sub FillGenres()
            Dim i1 As Integer = cbPublishType.SelectedIndex
            cbPublishType.Items.Clear()
            Dim genreArr1 As Sublight.WS.Genre() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.Genre)), Sublight.WS.Genre[])
            If (genreArr1) Is Nothing Then
                Return
            End If
            Dim genreArr2 As Sublight.WS.Genre() = genreArr1
            Dim i2 As Integer = 0
            While i2 < genreArr2.Length
                Dim genre1 As Sublight.WS.Genre = CType(genreArr2(i2), Sublight.WS.Genre)
                If genre1 <> Sublight.WS.Genre.Unknown Then
                    cbPublishType.Items.Add(New Sublight.Types.ListItem(Sublight.Globals.GetString(System.String.Format("Genre_{0}?", System.Enum.GetName(GetType(Sublight.WS.Genre), genre1))), genre1))
                End If
                i2 = i2 + 1
            End While
            Sublight.Globals.BindNotSelected(cbPublishType, True)
            If i1 >= 0 Then
                cbPublishType.SelectedIndex = i1
            End If
        End Sub

        Private Sub FillLanguages(ByVal selectNotSelected As Boolean)
            Dim i1 As Integer = cbLanguage.SelectedIndex
            cbLanguage.Items.Clear()
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = Sublight.MyUtility.LanguageUtil.GetSortedLanguages()
            Dim subtitleLanguageArr2 As Sublight.WS.SubtitleLanguage() = subtitleLanguageArr1
            Dim i2 As Integer = 0
            While i2 < subtitleLanguageArr2.Length
                Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(subtitleLanguageArr2(i2), Sublight.WS.SubtitleLanguage)
                If subtitleLanguage1 <> Sublight.WS.SubtitleLanguage.Unknown Then
                    Dim s1 As String = Sublight.Globals.GetString(subtitleLanguage1)
                    If Not System.String.IsNullOrEmpty(s1) Then
                        cbLanguage.Items.Add(New Sublight.Types.ListItem(s1, subtitleLanguage1))
                    End If
                End If
                i2 = i2 + 1
            End While
            Sublight.Globals.BindNotSelected(cbLanguage, True)
            If selectNotSelected Then
                Sublight.Globals.SelectNotSelected(cbLanguage)
                Return
            End If
            If (i1 >= 0) AndAlso (i1 < cbLanguage.Items.Count) Then
                cbLanguage.SelectedIndex = i1
            End If
        End Sub

        Private Sub FillMediaType()
            Dim i1 As Integer = cbPublishMedium.SelectedIndex
            cbPublishMedium.Items.Clear()
            Dim mediaTypeArr1 As Sublight.WS.MediaType() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.MediaType)), Sublight.WS.MediaType[])
            If (mediaTypeArr1) Is Nothing Then
                Return
            End If
            Dim mediaTypeArr2 As Sublight.WS.MediaType() = mediaTypeArr1
            Dim i2 As Integer = 0
            While i2 < mediaTypeArr2.Length
                Dim mediaType1 As Sublight.WS.MediaType = CType(mediaTypeArr2(i2), Sublight.WS.MediaType)
                If (mediaType1 <> Sublight.WS.MediaType.Unknown) AndAlso (mediaType1 <> Sublight.WS.MediaType.BlueRay) Then
                    cbPublishMedium.Items.Add(New Sublight.Types.ListItem(Sublight.Globals.GetString(mediaType1), mediaType1))
                End If
                i2 = i2 + 1
            End While
            Sublight.Globals.BindNotSelected(cbPublishMedium, True)
            If i1 >= 0 Then
                cbPublishMedium.SelectedIndex = i1
            End If
        End Sub

        Private Sub FillSeasonEpisode(ByVal match As System.Text.RegularExpressions.Match)
            Dim i1 As Integer = System.Int32.Parse(match.Groups("season?").Value)
            txtSeason.Text = i1.ToString()
            Dim i2 As Integer = System.Int32.Parse(match.Groups("episode?").Value)
            txtEpisode.Text = i2.ToString()
            Sublight.Types.ListItem.Select(cbPublishType, 2)
            ShowHideSeasonEpisode(True)
        End Sub

        Private Sub HideTip()
            lblTipVideo.Visible = False
            lblTipIMDb.Visible = False
        End Sub

        Private Sub InitializeComponent()
            panel1 = New Sublight.Controls.MyPanel
            panel2 = New Sublight.Controls.Panel
            lblPublishDisclaimer = New System.Windows.Forms.Label
            myGroupBox1 = New Sublight.Controls.MyGroupBox
            lblTipVideo = New System.Windows.Forms.Label
            lblTipIMDb = New System.Windows.Forms.Label
            cbPublishMultipleSubtitles = New Sublight.Controls.MyCheckBox
            cbImdbNotAvailable = New Sublight.Controls.MyCheckBox
            btnRemove = New Sublight.Controls.Button.Button
            myPanel1 = New Sublight.Controls.MyPanel
            btnUseFolderName = New Sublight.Controls.Button.Button
            txtRelease = New Sublight.Controls.MyTextBox
            label1 = New System.Windows.Forms.Label
            legendRequiredField1 = New Sublight.Controls.LegendRequiredField
            txtEpisode = New Sublight.Controls.MyTextBox
            txtSeason = New Sublight.Controls.MyTextBox
            lblEpisode = New System.Windows.Forms.Label
            lblSeason = New System.Windows.Forms.Label
            lblReqFPS = New System.Windows.Forms.Label
            lblReqDiscs = New System.Windows.Forms.Label
            lblReqMedia = New System.Windows.Forms.Label
            lblReqType = New System.Windows.Forms.Label
            lblReqLanguage = New System.Windows.Forms.Label
            txtComment = New Sublight.Controls.MyTextBox
            label15 = New System.Windows.Forms.Label
            cbPublishFPS = New Sublight.Controls.MyComboBox
            label13 = New System.Windows.Forms.Label
            cbPublishDiscs = New Sublight.Controls.MyComboBox
            label12 = New System.Windows.Forms.Label
            cbPublishMedium = New Sublight.Controls.MyComboBox
            label11 = New System.Windows.Forms.Label
            cbPublishType = New Sublight.Controls.MyComboBox
            label10 = New System.Windows.Forms.Label
            cbLanguage = New Sublight.Controls.MyComboBox
            label9 = New System.Windows.Forms.Label
            label5 = New System.Windows.Forms.Label
            btnVideoFileSelect = New Sublight.Controls.Button.Button
            txtVideoFile = New Sublight.Controls.PromptedTextBox
            lblReqSubtitle = New System.Windows.Forms.Label
            lblReqIMDB = New System.Windows.Forms.Label
            btnPublishOpenSubtitles = New Sublight.Controls.Button.Button
            txtPublishSubtitles = New Sublight.Controls.PromptedTextBox
            label8 = New System.Windows.Forms.Label
            btnFindIMDB = New Sublight.Controls.Button.Button
            txtPublishIMDB = New Sublight.Controls.PromptedTextBox
            label7 = New System.Windows.Forms.Label
            openFileDialog1 = New System.Windows.Forms.OpenFileDialog
            panel1.SuspendLayout()
            panel2.SuspendLayout()
            myGroupBox1.SuspendLayout()
            myPanel1.SuspendLayout()
            SuspendLayout()
            panel1.Controls.Add(panel2)
            panel1.Dock = System.Windows.Forms.DockStyle.Fill
            panel1.Location = New System.Drawing.Point(0, 0)
            panel1.Name = "panel1?"
            panel1.Size = New System.Drawing.Size(743, 573)
            panel1.TabIndex = 98
            panel2.Controls.Add(lblPublishDisclaimer)
            panel2.Controls.Add(myGroupBox1)
            panel2.Dock = System.Windows.Forms.DockStyle.Fill
            panel2.Location = New System.Drawing.Point(0, 0)
            panel2.Name = "panel2?"
            panel2.Padding = New System.Windows.Forms.Padding(5)
            panel2.Size = New System.Drawing.Size(743, 573)
            panel2.TabIndex = 0
            lblPublishDisclaimer.Dock = System.Windows.Forms.DockStyle.Top
            lblPublishDisclaimer.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblPublishDisclaimer.Location = New System.Drawing.Point(5, 410)
            lblPublishDisclaimer.Name = "lblPublishDisclaimer?"
            lblPublishDisclaimer.Size = New System.Drawing.Size(733, 87)
            lblPublishDisclaimer.TabIndex = 197
            lblPublishDisclaimer.Text = "Note: to publish subtitle you must be its author or have permission from its author. We reserve right to change or delete published subtitle without further notice.?"
            myGroupBox1.Controls.Add(lblTipVideo)
            myGroupBox1.Controls.Add(lblTipIMDb)
            myGroupBox1.Controls.Add(cbPublishMultipleSubtitles)
            myGroupBox1.Controls.Add(cbImdbNotAvailable)
            myGroupBox1.Controls.Add(btnRemove)
            myGroupBox1.Controls.Add(myPanel1)
            myGroupBox1.Controls.Add(label5)
            myGroupBox1.Controls.Add(btnVideoFileSelect)
            myGroupBox1.Controls.Add(txtVideoFile)
            myGroupBox1.Controls.Add(lblReqSubtitle)
            myGroupBox1.Controls.Add(lblReqIMDB)
            myGroupBox1.Controls.Add(btnPublishOpenSubtitles)
            myGroupBox1.Controls.Add(txtPublishSubtitles)
            myGroupBox1.Controls.Add(label8)
            myGroupBox1.Controls.Add(btnFindIMDB)
            myGroupBox1.Controls.Add(txtPublishIMDB)
            myGroupBox1.Controls.Add(label7)
            myGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
            myGroupBox1.DrawTextBackground = True
            myGroupBox1.Location = New System.Drawing.Point(5, 5)
            myGroupBox1.Name = "myGroupBox1?"
            myGroupBox1.Size = New System.Drawing.Size(733, 405)
            myGroupBox1.TabIndex = 132
            myGroupBox1.TabStop = False
            myGroupBox1.Text = "Podatki za objavo?"
            lblTipVideo.AutoSize = True
            lblTipVideo.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblTipVideo.Location = New System.Drawing.Point(548, 24)
            lblTipVideo.Name = "lblTipVideo?"
            lblTipVideo.Size = New System.Drawing.Size(185, 13)
            lblTipVideo.TabIndex = 195
            lblTipVideo.Text = "You can press ENTER to open dialog?"
            lblTipIMDb.AutoSize = True
            lblTipIMDb.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblTipIMDb.Location = New System.Drawing.Point(548, 51)
            lblTipIMDb.Name = "lblTipIMDb?"
            lblTipIMDb.Size = New System.Drawing.Size(185, 13)
            lblTipIMDb.TabIndex = 194
            lblTipIMDb.Text = "You can press ENTER to open dialog?"
            cbPublishMultipleSubtitles.Id = "2f7a8522-5446-49e0-b1f0-945ea666fbd1?"
            cbPublishMultipleSubtitles.Location = New System.Drawing.Point(118, 96)
            cbPublishMultipleSubtitles.Name = "cbPublishMultipleSubtitles?"
            cbPublishMultipleSubtitles.Size = New System.Drawing.Size(607, 26)
            cbPublishMultipleSubtitles.TabIndex = 193
            cbPublishMultipleSubtitles.Text = "???Objaviti želim vec podnapisov za ta film/nadaljevanko?"
            cbPublishMultipleSubtitles.UseVisualStyleBackColor = True
            cbImdbNotAvailable.Id = "e988e9c6-816a-4ef3-abec-e654d7272ebb?"
            cbImdbNotAvailable.Location = New System.Drawing.Point(118, 73)
            cbImdbNotAvailable.Name = "cbImdbNotAvailable?"
            cbImdbNotAvailable.Size = New System.Drawing.Size(607, 26)
            cbImdbNotAvailable.TabIndex = 168
            cbImdbNotAvailable.Text = "???IMDb ni na voljo (izberite samo, ce filma ni v IMDb bazi)?"
            cbImdbNotAvailable.UseVisualStyleBackColor = True
            AddHandler cbImdbNotAvailable.CheckedChanged, AddressOf cbImdbNotAvailable_CheckedChanged
            btnRemove.AutoResize = False
            btnRemove.BackColor = System.Drawing.SystemColors.Control
            btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnRemove.Id = "a332bda8-570d-4d27-816a-8ce22698ed98?"
            btnRemove.Image = Nothing
            btnRemove.Location = New System.Drawing.Point(548, 121)
            btnRemove.Name = "btnRemove?"
            btnRemove.Size = New System.Drawing.Size(75, 23)
            btnRemove.TabIndex = 167
            btnRemove.Text = "Odstrani?"
            btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnRemove.UseVisualStyleBackColor = False
            btnRemove.Visible = False
            AddHandler btnRemove.Click, AddressOf btnRemove_Click
            myPanel1.Controls.Add(btnUseFolderName)
            myPanel1.Controls.Add(txtRelease)
            myPanel1.Controls.Add(label1)
            myPanel1.Controls.Add(legendRequiredField1)
            myPanel1.Controls.Add(txtEpisode)
            myPanel1.Controls.Add(txtSeason)
            myPanel1.Controls.Add(lblEpisode)
            myPanel1.Controls.Add(lblSeason)
            myPanel1.Controls.Add(lblReqFPS)
            myPanel1.Controls.Add(lblReqDiscs)
            myPanel1.Controls.Add(lblReqMedia)
            myPanel1.Controls.Add(lblReqType)
            myPanel1.Controls.Add(lblReqLanguage)
            myPanel1.Controls.Add(txtComment)
            myPanel1.Controls.Add(label15)
            myPanel1.Controls.Add(cbPublishFPS)
            myPanel1.Controls.Add(label13)
            myPanel1.Controls.Add(cbPublishDiscs)
            myPanel1.Controls.Add(label12)
            myPanel1.Controls.Add(cbPublishMedium)
            myPanel1.Controls.Add(label11)
            myPanel1.Controls.Add(cbPublishType)
            myPanel1.Controls.Add(label10)
            myPanel1.Controls.Add(cbLanguage)
            myPanel1.Controls.Add(label9)
            myPanel1.Location = New System.Drawing.Point(6, 148)
            myPanel1.Name = "myPanel1?"
            myPanel1.Size = New System.Drawing.Size(719, 251)
            myPanel1.TabIndex = 166
            btnUseFolderName.AutoResize = False
            btnUseFolderName.BackColor = System.Drawing.SystemColors.Control
            btnUseFolderName.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnUseFolderName.Id = "18399919-a7db-4a72-9cbf-2c4abb678330?"
            btnUseFolderName.Image = Nothing
            btnUseFolderName.Location = New System.Drawing.Point(461, 137)
            btnUseFolderName.Name = "btnUseFolderName?"
            btnUseFolderName.Size = New System.Drawing.Size(99, 23)
            btnUseFolderName.TabIndex = 190
            btnUseFolderName.Text = "Uporabi ime mape?"
            btnUseFolderName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnUseFolderName.UseVisualStyleBackColor = False
            AddHandler btnUseFolderName.Click, AddressOf btnUseFolderName_Click
            txtRelease.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtRelease.EnableDisableColor = True
            txtRelease.Id = "3b70b10b-0cc9-4679-a9c1-4b382bf819d8?"
            txtRelease.LabelText = "?"
            txtRelease.Location = New System.Drawing.Point(112, 138)
            txtRelease.Name = "txtRelease?"
            txtRelease.Size = New System.Drawing.Size(321, 21)
            txtRelease.TabIndex = 173
            label1.Location = New System.Drawing.Point(4, 138)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(102, 21)
            label1.TabIndex = 189
            label1.Text = "Razlicica:?"
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            legendRequiredField1.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            legendRequiredField1.ForeColor = System.Drawing.Color.Red
            legendRequiredField1.Location = New System.Drawing.Point(7, 220)
            legendRequiredField1.Name = "legendRequiredField1?"
            legendRequiredField1.Size = New System.Drawing.Size(150, 22)
            legendRequiredField1.TabIndex = 188
            txtEpisode.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtEpisode.EnableDisableColor = True
            txtEpisode.Id = "41a94dd8-f550-458a-9a48-7fe4d97cac35?"
            txtEpisode.LabelText = "?"
            txtEpisode.Location = New System.Drawing.Point(626, 30)
            txtEpisode.Name = "txtEpisode?"
            txtEpisode.Size = New System.Drawing.Size(45, 21)
            txtEpisode.TabIndex = 169
            txtSeason.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtSeason.EnableDisableColor = True
            txtSeason.Id = "43b2af9b-4033-40ad-b48a-e851157cce1d?"
            txtSeason.LabelText = "?"
            txtSeason.Location = New System.Drawing.Point(521, 30)
            txtSeason.Name = "txtSeason?"
            txtSeason.Size = New System.Drawing.Size(45, 21)
            txtSeason.TabIndex = 168
            lblEpisode.AutoSize = True
            lblEpisode.Location = New System.Drawing.Point(572, 34)
            lblEpisode.Name = "lblEpisode?"
            lblEpisode.Size = New System.Drawing.Size(48, 13)
            lblEpisode.TabIndex = 187
            lblEpisode.Text = "Epizoda:?"
            lblSeason.AutoSize = True
            lblSeason.Location = New System.Drawing.Point(461, 34)
            lblSeason.Name = "lblSeason?"
            lblSeason.Size = New System.Drawing.Size(46, 13)
            lblSeason.TabIndex = 186
            lblSeason.Text = "Sezona:?"
            lblReqFPS.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblReqFPS.ForeColor = System.Drawing.Color.Red
            lblReqFPS.Location = New System.Drawing.Point(439, 111)
            lblReqFPS.Name = "lblReqFPS?"
            lblReqFPS.Size = New System.Drawing.Size(16, 20)
            lblReqFPS.TabIndex = 185
            lblReqFPS.Text = "*?"
            lblReqFPS.TextAlign = System.Drawing.ContentAlignment.TopCenter
            lblReqDiscs.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblReqDiscs.ForeColor = System.Drawing.Color.Red
            lblReqDiscs.Location = New System.Drawing.Point(439, 84)
            lblReqDiscs.Name = "lblReqDiscs?"
            lblReqDiscs.Size = New System.Drawing.Size(16, 20)
            lblReqDiscs.TabIndex = 184
            lblReqDiscs.Text = "*?"
            lblReqDiscs.TextAlign = System.Drawing.ContentAlignment.TopCenter
            lblReqMedia.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblReqMedia.ForeColor = System.Drawing.Color.Red
            lblReqMedia.Location = New System.Drawing.Point(439, 57)
            lblReqMedia.Name = "lblReqMedia?"
            lblReqMedia.Size = New System.Drawing.Size(16, 20)
            lblReqMedia.TabIndex = 183
            lblReqMedia.Text = "*?"
            lblReqMedia.TextAlign = System.Drawing.ContentAlignment.TopCenter
            lblReqType.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblReqType.ForeColor = System.Drawing.Color.Red
            lblReqType.Location = New System.Drawing.Point(439, 30)
            lblReqType.Name = "lblReqType?"
            lblReqType.Size = New System.Drawing.Size(16, 20)
            lblReqType.TabIndex = 182
            lblReqType.Text = "*?"
            lblReqType.TextAlign = System.Drawing.ContentAlignment.TopCenter
            lblReqLanguage.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblReqLanguage.ForeColor = System.Drawing.Color.Red
            lblReqLanguage.Location = New System.Drawing.Point(439, 3)
            lblReqLanguage.Name = "lblReqLanguage?"
            lblReqLanguage.Size = New System.Drawing.Size(16, 20)
            lblReqLanguage.TabIndex = 181
            lblReqLanguage.Text = "*?"
            lblReqLanguage.TextAlign = System.Drawing.ContentAlignment.TopCenter
            txtComment.BorderStyle = System.Windows.Forms.BorderStyle.None
            txtComment.EnableDisableColor = True
            txtComment.Id = "81e5b188-8fe4-49e1-9315-8c0815d3e447?"
            txtComment.LabelText = "?"
            txtComment.Location = New System.Drawing.Point(112, 164)
            txtComment.Multiline = True
            txtComment.Name = "txtComment?"
            txtComment.Size = New System.Drawing.Size(321, 50)
            txtComment.TabIndex = 174
            label15.Location = New System.Drawing.Point(4, 164)
            label15.Name = "label15?"
            label15.Size = New System.Drawing.Size(102, 21)
            label15.TabIndex = 180
            label15.Text = "Komentar:?"
            label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            cbPublishFPS.DrawMode = System.Windows.Forms.DrawMode.Normal
            cbPublishFPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbPublishFPS.DroppedDown = False
            cbPublishFPS.Editable = False
            cbPublishFPS.FormatInfo = Nothing
            cbPublishFPS.FormatString = "?"
            cbPublishFPS.FormattingEnabled = True
            cbPublishFPS.Id = "2798f2ae-11e5-4807-8d68-8bc098a55cab?"
            cbPublishFPS.ItemHeight = 22
            cbPublishFPS.LabelText = "?"
            cbPublishFPS.Location = New System.Drawing.Point(112, 111)
            cbPublishFPS.Name = "cbPublishFPS?"
            cbPublishFPS.Size = New System.Drawing.Size(321, 21)
            cbPublishFPS.Sorted = False
            cbPublishFPS.TabIndex = 172
            label13.Location = New System.Drawing.Point(4, 111)
            label13.Name = "label13?"
            label13.Size = New System.Drawing.Size(102, 21)
            label13.TabIndex = 179
            label13.Text = "FPS:?"
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            cbPublishDiscs.DrawMode = System.Windows.Forms.DrawMode.Normal
            cbPublishDiscs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbPublishDiscs.DroppedDown = False
            cbPublishDiscs.Editable = False
            cbPublishDiscs.FormatInfo = Nothing
            cbPublishDiscs.FormatString = "?"
            cbPublishDiscs.FormattingEnabled = True
            cbPublishDiscs.Id = "d1f5ab85-35a8-40ff-87cf-9dd454e318a1?"
            cbPublishDiscs.ItemHeight = 22
            cbPublishDiscs.LabelText = "?"
            cbPublishDiscs.Location = New System.Drawing.Point(112, 84)
            cbPublishDiscs.Name = "cbPublishDiscs?"
            cbPublishDiscs.Size = New System.Drawing.Size(321, 21)
            cbPublishDiscs.Sorted = False
            cbPublishDiscs.TabIndex = 171
            label12.Location = New System.Drawing.Point(4, 84)
            label12.Name = "label12?"
            label12.Size = New System.Drawing.Size(102, 21)
            label12.TabIndex = 178
            label12.Text = "Št. medijev:?"
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            cbPublishMedium.DrawMode = System.Windows.Forms.DrawMode.Normal
            cbPublishMedium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbPublishMedium.DroppedDown = False
            cbPublishMedium.Editable = False
            cbPublishMedium.FormatInfo = Nothing
            cbPublishMedium.FormatString = "?"
            cbPublishMedium.FormattingEnabled = True
            cbPublishMedium.Id = "0300fa0e-b786-4bf7-9806-8632b055a9bf?"
            cbPublishMedium.ItemHeight = 22
            cbPublishMedium.LabelText = "?"
            cbPublishMedium.Location = New System.Drawing.Point(112, 57)
            cbPublishMedium.Name = "cbPublishMedium?"
            cbPublishMedium.Size = New System.Drawing.Size(321, 21)
            cbPublishMedium.Sorted = False
            cbPublishMedium.TabIndex = 170
            label11.Location = New System.Drawing.Point(4, 57)
            label11.Name = "label11?"
            label11.Size = New System.Drawing.Size(102, 21)
            label11.TabIndex = 177
            label11.Text = "Medij:?"
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            cbPublishType.DrawMode = System.Windows.Forms.DrawMode.Normal
            cbPublishType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbPublishType.DroppedDown = False
            cbPublishType.Editable = False
            cbPublishType.FormatInfo = Nothing
            cbPublishType.FormatString = "?"
            cbPublishType.FormattingEnabled = True
            cbPublishType.Id = "47454e30-36b5-4ca0-b8af-e76f8f698fce?"
            cbPublishType.ItemHeight = 22
            cbPublishType.LabelText = "?"
            cbPublishType.Location = New System.Drawing.Point(112, 30)
            cbPublishType.Name = "cbPublishType?"
            cbPublishType.Size = New System.Drawing.Size(321, 21)
            cbPublishType.Sorted = False
            cbPublishType.TabIndex = 167
            AddHandler cbPublishType.SelectedIndexChanged, AddressOf cbPublishType_SelectedIndexChanged
            label10.Location = New System.Drawing.Point(4, 30)
            label10.Name = "label10?"
            label10.Size = New System.Drawing.Size(102, 21)
            label10.TabIndex = 176
            label10.Text = "Tip:?"
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            cbLanguage.DrawMode = System.Windows.Forms.DrawMode.Normal
            cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbLanguage.DroppedDown = False
            cbLanguage.Editable = False
            cbLanguage.FormatInfo = Nothing
            cbLanguage.FormatString = "?"
            cbLanguage.FormattingEnabled = True
            cbLanguage.Id = "65bc6761-1a75-4f7d-a0bf-128545bd0e81?"
            cbLanguage.ItemHeight = 22
            cbLanguage.LabelText = "?"
            cbLanguage.Location = New System.Drawing.Point(112, 3)
            cbLanguage.Name = "cbLanguage?"
            cbLanguage.Size = New System.Drawing.Size(321, 21)
            cbLanguage.Sorted = False
            cbLanguage.TabIndex = 166
            label9.Location = New System.Drawing.Point(4, 3)
            label9.Name = "label9?"
            label9.Size = New System.Drawing.Size(102, 21)
            label9.TabIndex = 175
            label9.Text = "Jezik podnapisov:?"
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label5.Location = New System.Drawing.Point(10, 20)
            label5.Name = "label5?"
            label5.Size = New System.Drawing.Size(102, 21)
            label5.TabIndex = 161
            label5.Text = "Video datoteka:?"
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnVideoFileSelect.AutoResize = False
            btnVideoFileSelect.BackColor = System.Drawing.SystemColors.Control
            btnVideoFileSelect.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnVideoFileSelect.Id = "c2a8cb1f-6ff3-4834-8a43-c7eb3400f4f2?"
            btnVideoFileSelect.Image = Nothing
            btnVideoFileSelect.Location = New System.Drawing.Point(467, 19)
            btnVideoFileSelect.Name = "btnVideoFileSelect?"
            btnVideoFileSelect.Size = New System.Drawing.Size(75, 23)
            btnVideoFileSelect.TabIndex = 132
            btnVideoFileSelect.Text = "Izberi...?"
            btnVideoFileSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnVideoFileSelect.UseVisualStyleBackColor = False
            AddHandler btnVideoFileSelect.Click, AddressOf btnVideoFileSelect_Click
            txtVideoFile.Id = "b69f7ef1-a109-4f0f-9e2d-9bf68b8cfa10?"
            txtVideoFile.LabelText = "?"
            txtVideoFile.Location = New System.Drawing.Point(118, 21)
            txtVideoFile.Name = "txtVideoFile?"
            txtVideoFile.PromptText = "?"
            txtVideoFile.Size = New System.Drawing.Size(321, 21)
            txtVideoFile.TabIndex = 131
            AddHandler txtVideoFile.Enter, AddressOf txtVideoFile_Enter
            AddHandler txtVideoFile.Leave, AddressOf txtVideoFile_Leave
            AddHandler txtVideoFile.KeyDown, AddressOf txtVideoFile_KeyDown
            lblReqSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblReqSubtitle.ForeColor = System.Drawing.Color.Red
            lblReqSubtitle.Location = New System.Drawing.Point(445, 119)
            lblReqSubtitle.Name = "lblReqSubtitle?"
            lblReqSubtitle.Size = New System.Drawing.Size(16, 20)
            lblReqSubtitle.TabIndex = 155
            lblReqSubtitle.Text = "*?"
            lblReqSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
            lblReqIMDB.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblReqIMDB.ForeColor = System.Drawing.Color.Red
            lblReqIMDB.Location = New System.Drawing.Point(445, 47)
            lblReqIMDB.Name = "lblReqIMDB?"
            lblReqIMDB.Size = New System.Drawing.Size(16, 20)
            lblReqIMDB.TabIndex = 154
            lblReqIMDB.Text = "*?"
            lblReqIMDB.TextAlign = System.Drawing.ContentAlignment.TopCenter
            btnPublishOpenSubtitles.AutoResize = False
            btnPublishOpenSubtitles.BackColor = System.Drawing.SystemColors.Control
            btnPublishOpenSubtitles.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnPublishOpenSubtitles.Id = "a647b07e-4a87-4379-8fa8-30de4d69357e?"
            btnPublishOpenSubtitles.Image = Nothing
            btnPublishOpenSubtitles.Location = New System.Drawing.Point(467, 121)
            btnPublishOpenSubtitles.Name = "btnPublishOpenSubtitles?"
            btnPublishOpenSubtitles.Size = New System.Drawing.Size(75, 23)
            btnPublishOpenSubtitles.TabIndex = 136
            btnPublishOpenSubtitles.Text = "Izberi...?"
            btnPublishOpenSubtitles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnPublishOpenSubtitles.UseVisualStyleBackColor = False
            AddHandler btnPublishOpenSubtitles.Click, AddressOf btnPublishOpenSubtitles_Click
            txtPublishSubtitles.Id = "a5a33d28-60da-4672-b524-25467b0c0ff6?"
            txtPublishSubtitles.LabelText = "?"
            txtPublishSubtitles.Location = New System.Drawing.Point(118, 122)
            txtPublishSubtitles.Name = "txtPublishSubtitles?"
            txtPublishSubtitles.PromptText = "?"
            txtPublishSubtitles.ReadOnly = True
            txtPublishSubtitles.Size = New System.Drawing.Size(321, 21)
            txtPublishSubtitles.TabIndex = 135
            label8.Location = New System.Drawing.Point(10, 122)
            label8.Name = "label8?"
            label8.Size = New System.Drawing.Size(102, 21)
            label8.TabIndex = 147
            label8.Text = "Podnapisi:?"
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnFindIMDB.AutoResize = False
            btnFindIMDB.BackColor = System.Drawing.SystemColors.Control
            btnFindIMDB.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnFindIMDB.Id = "fc71fe5d-85de-43f9-a462-5048dcb7a5e6?"
            btnFindIMDB.Image = Nothing
            btnFindIMDB.Location = New System.Drawing.Point(467, 46)
            btnFindIMDB.Name = "btnFindIMDB?"
            btnFindIMDB.Size = New System.Drawing.Size(75, 23)
            btnFindIMDB.TabIndex = 134
            btnFindIMDB.Text = "Najdi...?"
            btnFindIMDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnFindIMDB.UseVisualStyleBackColor = False
            AddHandler btnFindIMDB.Click, AddressOf btnFindIMDB_Click
            txtPublishIMDB.Id = "352677c6-c828-4902-876d-fffd07e01218?"
            txtPublishIMDB.LabelText = "?"
            txtPublishIMDB.Location = New System.Drawing.Point(118, 47)
            txtPublishIMDB.Name = "txtPublishIMDB?"
            txtPublishIMDB.PromptText = "?"
            txtPublishIMDB.Size = New System.Drawing.Size(321, 21)
            txtPublishIMDB.TabIndex = 133
            AddHandler txtPublishIMDB.Enter, AddressOf txtPublishIMDB_Enter
            AddHandler txtPublishIMDB.Leave, AddressOf txtPublishIMDB_Leave
            AddHandler txtPublishIMDB.KeyDown, AddressOf txtPublishIMDB_KeyDown
            label7.Location = New System.Drawing.Point(10, 47)
            label7.Name = "label7?"
            label7.Size = New System.Drawing.Size(102, 21)
            label7.TabIndex = 146
            label7.Text = "IMDb:?"
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            openFileDialog1.FileName = "openFileDialog1?"
            AllowDrop = True
            Controls.Add(panel1)
            Name = "PagePublish?"
            Size = New System.Drawing.Size(743, 573)
            AddHandler DragDrop, AddressOf PagePublish_DragDrop
            AddHandler DragEnter, AddressOf PagePublish_DragEnter
            panel1.ResumeLayout(False)
            panel2.ResumeLayout(False)
            myGroupBox1.ResumeLayout(False)
            myGroupBox1.PerformLayout()
            myPanel1.ResumeLayout(False)
            myPanel1.PerformLayout()
            ResumeLayout(False)
        End Sub

        Private Sub PagePublish_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
            Try
                Dim array1 As System.Array = CType(e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop), System.Array)
                If Not (array1) Is Nothing Then
                    Dim s1 As String = array1.GetValue(0).ToString()
                    If Not Sublight.Globals.IsVideoFileSupported(s1) Then
                        Return
                    End If
                    txtVideoFile.Text = s1
                    btnUseFolderName.Visible = True
                    If txtVideoFile.Text.Length > 0 Then
                        txtVideoFile.SelectionStart = txtVideoFile.Text.Length - 1
                    End If
                    Try
                        Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(s1)
                        If Not (fileInfo1.Directory) Is Nothing Then
                            openFileDialog1.InitialDirectory = fileInfo1.Directory.FullName
                        Else 
                            openFileDialog1.InitialDirectory = Nothing
                        End If
                    Catch e As System.Exception
                        openFileDialog1.InitialDirectory = Nothing
                    End Try
                    txtRelease.Text = System.IO.Path.GetFileNameWithoutExtension(s1)
                    TrySetMediaType()
                    TrySetFramerate()
                    TrySetImdb()
                    TrySetSubtitle()
                End If
            Catch 
            End Try
        End Sub

        Private Sub PagePublish_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
            If e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop) Then
                Try
                    Dim array1 As System.Array = CType(e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop), System.Array)
                    If Not (array1) Is Nothing Then
                        Dim s1 As String = array1.GetValue(0).ToString()
                        If Not Sublight.Globals.IsVideoFileSupported(s1) Then
                            Return
                        End If
                        If System.IO.File.Exists(s1) Then
                            e.Effect = System.Windows.Forms.DragDropEffects.Move
                            Return
                        End If
                    End If
                Catch 
                End Try
            End If
            e.Effect = System.Windows.Forms.DragDropEffects.None
        End Sub

        Friend Sub PublishExternalSubtitle(ByVal videoPath As String, ByVal subtitleProvider As Sublight.Plugins.SubtitleProvider.ISubtitleProvider, ByVal subtitle As Sublight.WS.Subtitle)
            Dim nullable4 As System.Nullable(Of Integer)

            ClearFields()
            If ((subtitleProvider) Is Nothing) OrElse ((subtitle) Is Nothing) OrElse System.String.IsNullOrEmpty(subtitle.ExternalId) Then
                Return
            End If
            m_externalSubtitle = subtitle
            m_subtitleProvider = subtitleProvider
            txtPublishSubtitles.Text = System.String.Format("plugin:///{0}?id={1}?", subtitleProvider.GetType().Name, m_externalSubtitle.ExternalId)
            If m_externalSubtitle.Language <> Sublight.WS.SubtitleLanguage.Unknown Then
                Sublight.Types.ListItem.Select(cbLanguage, m_externalSubtitle.Language)
            End If
            If Not System.String.IsNullOrEmpty(m_externalSubtitle.IMDB) Then
                txtPublishIMDB.Text = m_externalSubtitle.IMDB
            End If
            If m_externalSubtitle.Genre <> Sublight.WS.Genre.Unknown Then
                Sublight.Types.ListItem.Select(cbPublishType, m_externalSubtitle.Genre)
            End If
            If m_externalSubtitle.MediaType <> Sublight.WS.MediaType.Unknown Then
                Sublight.Types.ListItem.Select(cbPublishMedium, m_externalSubtitle.MediaType)
            End If
            If m_externalSubtitle.NumberOfDiscs > 0 Then
                Sublight.Types.ListItem.Select(cbPublishDiscs, m_externalSubtitle.NumberOfDiscs)
            End If
            If m_externalSubtitle.FPS <> Sublight.WS.FPS.NotSet Then
                Sublight.Types.ListItem.Select(cbPublishFPS, m_externalSubtitle.FPS)
            End If
            If Not (m_externalSubtitle.Release) Is Nothing Then
                txtRelease.Text = m_externalSubtitle.Release.Trim()
            Else 
                txtRelease.Text = System.String.Empty
            End If
            Dim flag1 As Boolean = False
            Dim nullable5 As System.Nullable(Of Byte) = m_externalSubtitle.Season
            If Not nullable5.get_HasValue() Then
                GoTo label_0
            End If
            nullable4 = New System.Nullable(Of Integer)[]
            Dim nullable6 As System.Nullable(Of Integer) = New System.Nullable(Of Integer)(nullable5.GetValueOrDefault())
            If nullable6.get_HasValue() Then
                Dim nullable8 As System.Nullable(Of Byte) = m_externalSubtitle.Season
                If nullable8.get_Value() <= 0 Then
                    GoTo label_1
                End If
                Dim nullable7 As System.Nullable(Of Byte) = m_externalSubtitle.Season
                Dim b1 As Byte = nullable7.get_Value()
                txtSeason.Text = b1.ToString()
                flag1 = True
            Else 
            label_1: _
                txtSeason.Text = System.String.Empty
            End If
            Dim nullable1 As System.Nullable(Of Integer) = m_externalSubtitle.Episode
            If nullable1.get_HasValue() Then
                Dim nullable3 As System.Nullable(Of Integer) = m_externalSubtitle.Episode
                If nullable3.get_Value() < 0 Then
                    GoTo label_2
                End If
                Dim nullable2 As System.Nullable(Of Integer) = m_externalSubtitle.Episode
                Dim i1 As Integer = nullable2.get_Value()
                txtEpisode.Text = i1.ToString()
                flag1 = True
            Else 
            label_2: _
                txtEpisode.Text = System.String.Empty
            End If
            If flag1 Then
                ShowHideSeasonEpisode(True)
            End If
            Try
                If System.IO.File.Exists(videoPath) Then
                    txtVideoFile.Text = videoPath
                    btnUseFolderName.Visible = True
                    TrySetMediaType()
                    TrySetFramerate()
                    TrySetImdb()
                    If System.String.IsNullOrEmpty(txtRelease.Text) Then
                        txtRelease.Text = System.IO.Path.GetFileNameWithoutExtension(videoPath)
                    End If
                End If
            Catch e As System.Exception
            End Try
        End Sub

        Private Function PublishSubtitle(ByVal page As Sublight.Controls.BasePage, ByVal subtitle As Sublight.WS.Subtitle, ByVal data As String, ByRef ID As System.Guid, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            ID = System.Guid.Empty
            error = Nothing
            Try
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    Dim <>c__DisplayClass4_1 As Sublight.Controls.PagePublish.<>c__DisplayClass4 = New Sublight.Controls.PagePublish.<>c__DisplayClass4
                    <>c__DisplayClass4_1.points = 0.0R
                    <>c__DisplayClass4_1.wsCompleted = False
                    <>c__DisplayClass4_1.wsErr = Nothing
                    <>c__DisplayClass4_1.wsId = System.Guid.Empty
                    <>c__DisplayClass4_1.waitWS = True
                    AddHandler sublight1.PublishSubtitle2Completed, AddressOf <>c__DisplayClass4_1.<PublishSubtitle>b__3
                    sublight1.PublishSubtitle2Async(Sublight.BaseForm.Session, subtitle, data)
                    While <>c__DisplayClass4_1.waitWS
                        System.Windows.Forms.Application.DoEvents()
                        System.Threading.Thread.Sleep(50)
                    End While
                    ID = <>c__DisplayClass4_1.wsId
                    error = <>c__DisplayClass4_1.wsErr
                    If <>c__DisplayClass4_1.wsCompleted Then
                        Sublight.Globals.UpdateUserPoints(<>c__DisplayClass4_1.points)
                    End If
                    flag1 = <>c__DisplayClass4_1.wsCompleted
                    Return flag1
                End Using
            Catch e As System.Exception
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Private Sub SelectFPS(ByVal fps As Sublight.WS.FPS)
            Dim listItem1 As Sublight.Types.ListItem 
            For Each listItem1 In cbPublishFPS.Items
                If DirectCast(listItem1.Value, Sublight.WS.FPS) = fps Then
                    cbPublishFPS.SelectedItem = listItem1
                    Return
                End If
            Next
        End Sub

        Private Sub SelectMediaType(ByVal mediatype As Sublight.WS.MediaType)
            Dim listItem1 As Sublight.Types.ListItem 
            For Each listItem1 In cbPublishMedium.Items
                If DirectCast(listItem1.Value, Sublight.WS.MediaType) = mediatype Then
                    cbPublishMedium.SelectedItem = listItem1
                    Return
                End If
            Next
        End Sub

        Private Sub SetError(ByVal label As System.Windows.Forms.Label)
            label.Font = fntReqError
            label.Visible = True
        End Sub

        Private Sub ShowHideSeasonEpisode(ByVal show As Boolean)
            lblSeason.Visible = show
            txtSeason.Visible = show
            lblEpisode.Visible = show
            txtEpisode.Visible = show
        End Sub

        Private Sub ShowRequiredFields(ByVal visible As Boolean)
            lblReqIMDB.Visible = visible
            lblReqSubtitle.Visible = visible
            lblReqLanguage.Visible = visible
            lblReqType.Visible = visible
            lblReqMedia.Visible = visible
            lblReqDiscs.Visible = visible
            lblReqFPS.Visible = visible
        End Sub

        Private Sub TryGuessGenreAsync(ByVal imdb As String)
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.GetDetailsCompleted, AddressOf ws_GetDetailsCompleted
                sublight1.GetDetailsAsync(Sublight.BaseForm.Session, imdb)
            End Using
        End Sub

        Private Sub TrySetFramerate()
            If System.IO.File.Exists(txtVideoFile.Text) Then
                Sublight.Globals.SelectNotSelected(cbPublishFPS)
                Try
                    Dim videoInfo1 As Utility.Video.VideoInfo = New Utility.Video.VideoInfo(txtVideoFile.Text)
                    Dim i1 As Integer = System.Convert.ToInt32(System.Math.Floor(videoInfo1.FramesPerSecond))
                    If i1 = 23 Then
                        SelectFPS(Sublight.WS.FPS.FPS_23_976)
                    ElseIf i1 = 25 Then
                        SelectFPS(Sublight.WS.FPS.FPS_25)
                    ElseIf i1 = 29 Then
                        SelectFPS(Sublight.WS.FPS.FPS_29_97)
                    End If
                Catch 
                End Try
            End If
        End Sub

        Private Sub TrySetImdb()
            txtPublishIMDB.Text = System.String.Empty
            Dim s1 As String = Sublight.MyUtility.NfoUtility.GetNfoPath(txtVideoFile.Text)
            If Not System.String.IsNullOrEmpty(s1) Then
                Dim s2 As String = Sublight.MyUtility.NfoUtility.GetImdb(s1)
                If System.String.IsNullOrEmpty(s2) Then
                    txtPublishIMDB.Text = System.String.Empty
                Else 
                    txtPublishIMDB.Text = System.String.Format("http://www.imdb.com/title/{0}?", s2)
                End If
                TryGuessGenreAsync(s2)
                Return
            End If
            Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ParameterizedThreadStart(AutoSetImdbByVideoThread))
            thread1.Start(txtVideoFile.Text)
        End Sub

        Private Sub TrySetMediaType()
            If System.IO.File.Exists(txtVideoFile.Text) Then
                Sublight.Globals.SelectNotSelected(cbPublishMedium)
                Try
                    Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(txtVideoFile.Text)
                    If CInt(fileInfo1.Length) <= 840957664 Then
                        SelectMediaType(Sublight.WS.MediaType.CD)
                    ElseIf CDbl(fileInfo1.Length) <= 4707284156.416R Then
                        SelectMediaType(Sublight.WS.MediaType.DVD)
                    Else 
                        SelectMediaType(Sublight.WS.MediaType.BluRay)
                    End If
                Catch 
                End Try
            End If
        End Sub

        Private Sub TrySetSubtitle()
            Dim s1 As String

            Try
                If System.String.IsNullOrEmpty(txtVideoFile.Text) Then
                    Return
                End If
                If Not System.IO.File.Exists(txtVideoFile.Text) Then
                    Return
                End If
                If Sublight.MyUtility.SubtitleUtil.IsSubtitleAvailable(txtVideoFile.Text, out s1) Then
                    Dim subtitlePath1 As Sublight.Controls.PagePublish.SubtitlePath = New Sublight.Controls.PagePublish.SubtitlePath(s1)
                    btnPublishOpenSubtitles_Click(subtitlePath1, Nothing)
                    Return
                End If
                If Sublight.MyUtility.SubtitleUtil.IsSingleVideoAndSubtitle(txtVideoFile.Text, out s1) Then
                    Dim subtitlePath2 As Sublight.Controls.PagePublish.SubtitlePath = New Sublight.Controls.PagePublish.SubtitlePath(s1)
                    btnPublishOpenSubtitles_Click(subtitlePath2, Nothing)
                    Return
                End If
            Catch 
            End Try
        End Sub

        Private Sub txtPublishIMDB_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
            HideTip()
            _displayTip.Start()
        End Sub

        Private Sub txtPublishIMDB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnFindIMDB_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtPublishIMDB_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
            HideTip()
        End Sub

        Private Sub txtVideoFile_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
            HideTip()
            _displayTip.Start()
        End Sub

        Private Sub txtVideoFile_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnVideoFileSelect_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtVideoFile_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
            HideTip()
        End Sub

        Private Sub ws_GetDetailsCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetDetailsCompletedEventArgs)
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            Dim <>c__DisplayClass8_1 As Sublight.Controls.PagePublish.<>c__DisplayClass8 = New Sublight.Controls.PagePublish.<>c__DisplayClass8
            <>c__DisplayClass8_1.e = e
            <>c__DisplayClass8_1.<>4__this = Me
            If (Not (<>c__DisplayClass8_1.e.Error) Is Nothing) OrElse Not <>c__DisplayClass8_1.e.Result OrElse ((<>c__DisplayClass8_1.e.imdbInfo) Is Nothing) Then
                Return
            End If
            Dim nullable1 As System.Nullable(Of Sublight.WS.Genre) = <>c__DisplayClass8_1.e.imdbInfo.Genre
            If nullable1.get_HasValue() Then
                If (methodInvoker2) Is Nothing Then
                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<ws_GetDetailsCompleted>b__6)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                Sublight.BaseForm.DoCtrlInvoke(cbPublishType, Me, methodInvoker1)
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class PagePublish

End Namespace

