Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Plugins.SubtitleProvider
Imports Sublight.Plugins.SubtitleProvider.Types
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmSearch
        Inherits Sublight.BaseForm

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClassd

            Public <>4__this As Sublight.FrmSearch 
            Public start As System.DateTime 

            Public Sub New()
            End Sub

            Public Sub <RunPlugins>b__9()
                Dim timeSpan1 As System.TimeSpan = System.DateTime.Now - start
                Dim i1 As Integer = System.Convert.ToInt32(System.Math.Ceiling(CDbl((System.Convert.ToSingle(15000.0R - timeSpan1.TotalMilliseconds) / 1000.0F))))
                Dim s1 As String = System.String.Format(Sublight.Translation.FrmSearch_PluginWaitingForResponse, i1)
                If <>4__this.lblFontNormal.Text <> s1 Then
                    <>4__this.lblFontNormal.Text = s1
                    If Not <>4__this.lblFontNormal.Visible Then
                        <>4__this.lblFontNormal.Visible = True
                    End If
                End If
            End Sub

        End Class ' class <>c__DisplayClassd

        Private _isSearchAborted As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <Items>k__BackingField As Sublight.Controls.SuperListItem.Data() 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblFontBold As System.Windows.Forms.Label 
        Private lblFontNormal As System.Windows.Forms.Label 
        Private lblPrimary As System.Windows.Forms.Label 
        Private lblSecondary As System.Windows.Forms.Label 
        Private lstPlugins As System.Collections.Generic.List(Of System.Type) 
        Private m_discs As Integer 
        Private m_episode As System.Nullable(Of Integer) 
        Private m_genres As Sublight.WS.Genre() 
        Private m_languages As Sublight.WS.SubtitleLanguage() 
        Private m_lstItemsPrimary As System.Collections.Generic.List(Of Sublight.Controls.SuperListItem.Data) 
        Private m_lstItemsSecondary As System.Collections.Generic.List(Of Sublight.Controls.SuperListItem.Data) 
        Private m_publisher As String 
        Private m_rateGreaterThan As System.Nullable(Of Single) 
        Private m_season As System.Nullable(Of Byte) 
        Private m_subtitlesWithoutReleaseInfo As System.Collections.Generic.List(Of System.Guid) 
        Private m_title As String 
        Private m_videoHash As String 
        Private m_year As System.Nullable(Of Integer) 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private pbPrimary As System.Windows.Forms.PictureBox 
        Private pbSecondary As System.Windows.Forms.PictureBox 

        Private Property IsSearchAborted As Boolean
            Get
                Return _isSearchAborted
            End Get
            Set
                _isSearchAborted = value
            End Set
        End Property

        Friend Property Items As Sublight.Controls.SuperListItem.Data()
            Get
                Return <Items>k__BackingField
            End Get
            Set
                <Items>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal videoHash As String, ByVal title As String, ByVal year As System.Nullable(Of Integer), ByVal season As System.Nullable(Of Byte), ByVal episode As System.Nullable(Of Integer), ByVal languages As Sublight.WS.SubtitleLanguage(), ByVal genres As Sublight.WS.Genre(), ByVal publisher As String, ByVal rateGreaterThan As System.Nullable(Of Single), ByRef subtitlesWithoutReleaseInfo As System.Collections.Generic.List(Of System.Guid), ByVal discs As Integer)
            InitializeComponent()
            m_videoHash = videoHash
            m_title = title
            m_year = year
            m_season = season
            m_episode = episode
            m_languages = languages
            m_genres = genres
            m_publisher = publisher
            m_rateGreaterThan = rateGreaterThan
            Text = Sublight.Translation.FrmSearch_Title
            m_discs = discs
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            btnCancel.Enabled = False
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <PrimaryDbSearch>b__0()
            pbPrimary.Image = Sublight.Properties.Resources.OperationSuccess
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <PrimaryDbSearch>b__1()
            Dim i1 As Integer = 0
            If Not (m_lstItemsPrimary) Is Nothing Then
                i1 = m_lstItemsPrimary.get_Count()
            End If
            lblPrimary.Text = System.String.Format(Sublight.Translation.FrmSearch_SearchingPrimarySourceDone, i1)
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <PrimaryDbSearch>b__2()
            btnCancel.Enabled = True
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <RunPlugins>b__a()
            pbSecondary.Image = Sublight.Properties.Resources.OperationSuccess
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <RunPlugins>b__b()
            lblFontNormal.Visible = False
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <SecondaryDbSearch>b__7()
            Dim i1 As Integer = 0
            If Not (m_lstItemsSecondary) Is Nothing Then
                i1 = m_lstItemsSecondary.get_Count()
            End If
            lblSecondary.Text = System.String.Format(Sublight.Translation.FrmSearch_SearchingSecondarySourceProgress, i1)
        End Sub

        Private Sub AddSecondaryResults(ByVal lst As System.Collections.Generic.IEnumerable(Of Sublight.Controls.SuperListItem.Data))
            m_lstItemsSecondary.AddRange(lst)
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            CancelSearch()
        End Sub

        Private Sub CancelSearch()
            IsSearchAborted = True
            Close()
        End Sub

        Private Sub FrmSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                CancelSearch()
            End If
        End Sub

        Private Sub InitializeComponent()
            niceLine1 = New Sublight.Controls.NiceLine
            btnCancel = New Sublight.Controls.Button.Button
            lblPrimary = New System.Windows.Forms.Label
            lblSecondary = New System.Windows.Forms.Label
            lblFontNormal = New System.Windows.Forms.Label
            lblFontBold = New System.Windows.Forms.Label
            pbPrimary = New System.Windows.Forms.PictureBox
            pbSecondary = New System.Windows.Forms.PictureBox
            pbPrimary.BeginInit()
            pbSecondary.BeginInit()
            SuspendLayout()
            niceLine1.Location = New System.Drawing.Point(12, 78)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(326, 15)
            niceLine1.TabIndex = 9
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(263, 96)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 8
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            lblPrimary.AutoSize = True
            lblPrimary.Location = New System.Drawing.Point(34, 20)
            lblPrimary.Name = "lblPrimary?"
            lblPrimary.Size = New System.Drawing.Size(194, 13)
            lblPrimary.TabIndex = 10
            lblPrimary.Text = "Iskanje podnapisov na primarnem viru...?"
            lblSecondary.AutoSize = True
            lblSecondary.Location = New System.Drawing.Point(34, 47)
            lblSecondary.Name = "lblSecondary?"
            lblSecondary.Size = New System.Drawing.Size(236, 13)
            lblSecondary.TabIndex = 11
            lblSecondary.Text = "Iskanje podnapisov na sekundarnem viru (0/1)...?"
            lblFontNormal.AutoSize = True
            lblFontNormal.Location = New System.Drawing.Point(13, 101)
            lblFontNormal.Name = "lblFontNormal?"
            lblFontNormal.Size = New System.Drawing.Size(35, 13)
            lblFontNormal.TabIndex = 12
            lblFontNormal.Text = "label1?"
            lblFontNormal.Visible = False
            lblFontBold.AutoSize = True
            lblFontBold.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblFontBold.Location = New System.Drawing.Point(54, 96)
            lblFontBold.Name = "lblFontBold?"
            lblFontBold.Size = New System.Drawing.Size(41, 13)
            lblFontBold.TabIndex = 13
            lblFontBold.Text = "label1?"
            lblFontBold.Visible = False
            pbPrimary.Image = Sublight.Properties.Resources.OperationWaiting
            pbPrimary.Location = New System.Drawing.Point(12, 18)
            pbPrimary.Name = "pbPrimary?"
            pbPrimary.Size = New System.Drawing.Size(16, 16)
            pbPrimary.TabIndex = 14
            pbPrimary.TabStop = False
            pbSecondary.Image = Sublight.Properties.Resources.OperationWaiting
            pbSecondary.Location = New System.Drawing.Point(12, 45)
            pbSecondary.Name = "pbSecondary?"
            pbSecondary.Size = New System.Drawing.Size(16, 16)
            pbSecondary.TabIndex = 15
            pbSecondary.TabStop = False
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(350, 131)
            Controls.Add(pbSecondary)
            Controls.Add(pbPrimary)
            Controls.Add(lblFontBold)
            Controls.Add(lblFontNormal)
            Controls.Add(lblSecondary)
            Controls.Add(lblPrimary)
            Controls.Add(niceLine1)
            Controls.Add(btnCancel)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            KeyPreview = True
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmSearch?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Poteka iskanje podnapisov...?"
            AddHandler KeyUp, AddressOf FrmSearch_KeyUp
            pbPrimary.EndInit()
            pbSecondary.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub InitPlugins()
            Dim typeArr1 As System.Type()

            lstPlugins = New System.Collections.Generic.List(Of System.Type)
            If Sublight.Globals.EditionType = Sublight.Types.SpecialEdition.PodnapisiNET Then
                typeArr1 = Sublight.Plugins.SubtitleProvider.PluginManager.GetPlugins(Sublight.Properties.Settings.Default.PluginDir, "PodnapisiNet?")
            Else 
                typeArr1 = Sublight.Plugins.SubtitleProvider.PluginManager.GetPlugins(Sublight.Properties.Settings.Default.PluginDir, Sublight.Properties.Settings.Default.Plugins_SubtitleProviderOrder)
            End If
            If Not (typeArr1) Is Nothing Then
                lstPlugins.AddRange(typeArr1)
            End If
        End Sub

        Private Sub PrimaryDbSearch()
            Dim flag1 As Boolean
            Dim s1 As String
            Dim sArr1 As String()
            Dim list1 As System.Collections.Generic.List(Of String)
            Dim releaseArr1 As Sublight.WS.Release()
            Dim subtitleArr1 As Sublight.WS.Subtitle()

            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = Nothing
            Dim methodInvoker4 As System.Windows.Forms.MethodInvoker = Nothing
            Try
                If Sublight.Globals.EditionType = Sublight.Types.SpecialEdition.PodnapisiNET Then
                    Return
                End If
                Dim i1 As Integer = 0
                While i1 < Sublight.Globals.WS_NumberOfRetries
                    Try
                        Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                            If sublight1.SearchSubtitles3(Sublight.BaseForm.Session, m_videoHash, m_title, m_year, m_season, m_episode, m_languages, m_genres, m_publisher, m_rateGreaterThan, out subtitleArr1, out releaseArr1, out flag1, out s1) Then
                                m_subtitlesWithoutReleaseInfo = New System.Collections.Generic.List(Of System.Guid)
                                Dim dictionary1 As System.Collections.Generic.Dictionary(Of System.Guid,System.Collections.Generic.List(Of String)) = New System.Collections.Generic.Dictionary(Of System.Guid,System.Collections.Generic.List(Of String))
                                If Not (releaseArr1) Is Nothing Then
                                    Dim i2 As Integer = 0
                                    While i2 < releaseArr1.Length
                                        Dim release1 As Sublight.WS.Release = releaseArr1(i2)
                                        If Not dictionary1.ContainsKey(release1.SubtitleID) Then
                                            list1 = New System.Collections.Generic.List(Of String)
                                            dictionary1.Add(release1.SubtitleID, list1)
                                        Else 
                                            list1 = dictionary1.get_Item(release1.SubtitleID)
                                        End If
                                        If list1.get_Count() < 3 Then
                                            list1.Add(Sublight.Controls.BasePageResults.ReleaseToString(release1))
                                        ElseIf list1.get_Count() = 3 Then
                                            list1.Add("...?")
                                        End If
                                        i2 = i2 + 1
                                    End While
                                End If
                                Dim i3 As Integer = 0
                                While i3 < subtitleArr1.Length
                                    If Not dictionary1.ContainsKey(subtitleArr1(i3).SubtitleID) Then
                                        m_subtitlesWithoutReleaseInfo.Add(subtitleArr1(i3).SubtitleID)
                                        Dim list2 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
                                        list2.Add(Sublight.Translation.Common_SearchResults_NoReleaseInfo)
                                        dictionary1.Add(subtitleArr1(i3).SubtitleID, list2)
                                    End If
                                    i3 = i3 + 1
                                End While
                                Dim i4 As Integer = 0
                                While i4 < subtitleArr1.Length
                                    If dictionary1.ContainsKey(subtitleArr1(i4).SubtitleID) Then
                                        sArr1 = dictionary1.get_Item(subtitleArr1(i4).SubtitleID).ToArray()
                                        If (Not (sArr1) Is Nothing) AndAlso (sArr1.Length <= 0) Then
                                            sArr1 = Nothing
                                        End If
                                    Else 
                                        sArr1 = Nothing
                                    End If
                                    If (m_discs < 0) OrElse (subtitleArr1(i4).NumberOfDiscs = CByte(m_discs)) Then
                                        m_lstItemsPrimary.Add(New Sublight.Controls.SuperListItem.Data(subtitleArr1(i4), sArr1, Nothing))
                                    End If
                                    i4 = i4 + 1
                                End While
                            End If
                        End Using
                        Return
                    Catch 
                    End Try
                    System.Threading.Thread.Sleep(Sublight.Globals.WS_SleepIntervalOnError)
                    i1 = i1 + 1
                End While
            Finally
                If (methodInvoker2) Is Nothing Then
                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<PrimaryDbSearch>b__0)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                Sublight.BaseForm.DoCtrlInvoke(pbPrimary, Me, methodInvoker1)
                If (methodInvoker3) Is Nothing Then
                    methodInvoker3 = New System.Windows.Forms.MethodInvoker(<PrimaryDbSearch>b__1)
                End If
                methodInvoker1 = methodInvoker3
                Sublight.BaseForm.DoCtrlInvoke(lblPrimary, Me, methodInvoker1)
                If (methodInvoker4) Is Nothing Then
                    methodInvoker4 = New System.Windows.Forms.MethodInvoker(<PrimaryDbSearch>b__2)
                End If
                methodInvoker1 = methodInvoker4
                Sublight.BaseForm.DoCtrlInvoke(btnCancel, Me, methodInvoker1)
            End Try
        End Sub

        Private Sub RunPlugins()
            Dim nullable1 As System.Nullable(Of Integer)
            Dim timeSpan1 As System.TimeSpan

            Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = Nothing
            Dim <>c__DisplayClassd1 As Sublight.FrmSearch.<>c__DisplayClassd = New Sublight.FrmSearch.<>c__DisplayClassd
            <>c__DisplayClassd1.<>4__this = Me
            If (lstPlugins) Is Nothing Then
                Return
            End If
            If Sublight.Globals.EditionType <> Sublight.Types.SpecialEdition.PodnapisiNET Then
                If Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseNewer Then
                    Return
                End If
                If (Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage = Sublight.Types.SecondarySubtitleProvider.UseWhenNoHitsOnPrimaryProvider) AndAlso (m_lstItemsSecondary.get_Count() > 0) Then
                    Return
                End If
            End If
            If (Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage <> Sublight.Types.SecondarySubtitleProvider.UseAlways) AndAlso (Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage <> Sublight.Types.SecondarySubtitleProvider.UseNewer) AndAlso (Sublight.Properties.Settings.Default.Plugins_SubtitleProviderUsage <> Sublight.Types.SecondarySubtitleProvider.UseWhenNoHitsOnPrimaryProvider) Then
                Throw New System.Exception("Unknown Plugins_SubtitleProviderUsage.?")
            End If
            Dim list1 As System.Collections.Generic.List(Of Sublight.Plugins.SubtitleProvider.Types.SearchFilter) = New System.Collections.Generic.List(Of Sublight.Plugins.SubtitleProvider.Types.SearchFilter)
            list1.Add(New Sublight.Plugins.SubtitleProvider.Types.SubtitleFilterMaxResults(Sublight.Globals.MAX_RESULTS))
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = m_languages
            Dim i4 As Integer = 0
            While i4 < subtitleLanguageArr1.Length
                Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(subtitleLanguageArr1(i4), Sublight.WS.SubtitleLanguage)
                Try
                    Dim s1 As String = System.Enum.GetName(GetType(Sublight.WS.SubtitleLanguage), subtitleLanguage1)
                    list1.Add(New Sublight.Plugins.SubtitleProvider.Types.SearchFilterLanguage(DirectCast(System.Enum.Parse(GetType(Sublight.Plugins.SubtitleProvider.Types.Language), s1), Sublight.Plugins.SubtitleProvider.Types.Language)))
                Catch 
                End Try
                i4 = i4 + 1
            End While
            If m_year.get_HasValue() Then
                list1.Add(New Sublight.Plugins.SubtitleProvider.Types.SearchFilterYear(m_year.get_Value()))
            End If
            Dim nullable3 As System.Nullable(Of Byte) = m_season
            If Not nullable3.get_HasValue() Then
                GoTo label_0
            End If
            nullable1 = New System.Nullable(Of Integer)[]
            Dim nullable2 As System.Nullable(Of Integer) = New System.Nullable(Of Integer)(nullable3.GetValueOrDefault())
            If nullable2.get_HasValue() Then
                list1.Add(New Sublight.Plugins.SubtitleProvider.Types.SearchFilterSeason(m_season.get_Value()))
            End If
            If m_episode.get_HasValue() Then
                list1.Add(New Sublight.Plugins.SubtitleProvider.Types.SearchFilterEpisode(m_episode.get_Value()))
            End If
            If m_discs >= 0 Then
                list1.Add(New Sublight.Plugins.SubtitleProvider.Types.SearchFilterDiscs(m_discs))
            End If
            Dim list2 As System.Collections.Generic.List(Of System.Threading.Thread) = New System.Collections.Generic.List(Of System.Threading.Thread)
            Dim i1 As Integer = 0
            While i1 < lstPlugins.get_Count()
                Try
                    Dim type1 As System.Type = lstPlugins.get_Item(i1)
                    Dim isubtitleProvider1 As Sublight.Plugins.SubtitleProvider.ISubtitleProvider = TryCast(type1.Assembly.CreateInstance(type1.FullName), Sublight.Plugins.SubtitleProvider.ISubtitleProvider)
                    If Not (isubtitleProvider1) Is Nothing Then
                        If Not System.String.IsNullOrEmpty(isubtitleProvider1.ShortName) Then
                            GoTo label_1
                        End If
                        GoTo label_2
                    End If
                    GoTo label_2
                label_1: _
                    System.Enum.GetValues(GetType(Sublight.WS.Genre)).Length
                    If (Not (m_publisher) Is Nothing) OrElse m_rateGreaterThan.get_HasValue() Then
                        GoTo label_2
                    End If
                    Dim s2 As String = System.String.Format("Plugins_SubtitleProvider_{0}_{1}?", isubtitleProvider1.GetType().Assembly.GetName().Name, isubtitleProvider1.GetType().Name)
                    Dim s3 As String = Sublight.BaseForm.GetSetting(s2)
                    If Not (s3) Is Nothing Then
                        Dim version1 As System.Version = New System.Version(s3)
                        If version1 > isubtitleProvider1.Version Then
                            GoTo label_2
                        End If
                    End If
                    Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ParameterizedThreadStart(SecondaryDbSearch))
                    thread1.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture
                    thread1.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture
                    Dim objArr1 As Object() = New object() { _
                                                             isubtitleProvider1, _
                                                             m_title, _
                                                             IIf(list1.get_Count() > 0, list1.ToArray(), Nothing) }
                    thread1.Start(objArr1)
                    list2.Add(thread1)
                Catch 
                End Try
            label_2: _
                i1 = i1 + 1
            End While
            <>c__DisplayClassd1.start = System.DateTime.Now
            While timeSpan1.TotalMilliseconds < 15000.0R
                System.Threading.Thread.Sleep(100)
                System.Windows.Forms.Application.DoEvents()
                Dim flag1 As Boolean = False
                Dim enumerator1 As System.Collections.Generic.List(Of System.Threading.Thread).Enumerator = list2.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim thread2 As System.Threading.Thread = enumerator1.get_Current()
                        If thread2.ThreadState <> System.Threading.ThreadState.Stopped Then
                            flag1 = True
                            Exit While
                        End If
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
                If flag1 Then
                    Dim i2 As Integer = IIf(Not (m_lstItemsPrimary) Is Nothing, m_lstItemsPrimary.get_Count(), 0)
                    Dim i3 As Integer = IIf(Not (m_lstItemsSecondary) Is Nothing, m_lstItemsSecondary.get_Count(), 0)
                    If (i2 + i3) <= Sublight.Globals.MAX_RESULTS Then
                        If (methodInvoker3) Is Nothing Then
                            methodInvoker3 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClassd1.<RunPlugins>b__9)
                        End If
                        Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker3
                        Sublight.BaseForm.DoCtrlInvoke(lblFontNormal, Me, methodInvoker1)
                        If Not IsSearchAborted Then
                            timeSpan1 = System.DateTime.Now - <>c__DisplayClassd1.start
                        End If
                    End If
                End If
            End While
            Dim enumerator2 As System.Collections.Generic.List(Of System.Threading.Thread).Enumerator = list2.GetEnumerator()
            Try
                While enumerator2.MoveNext()
                    Dim thread3 As System.Threading.Thread = enumerator2.get_Current()
                    If thread3.ThreadState <> System.Threading.ThreadState.Stopped Then
                        Try
                            thread3.Abort()
                        Catch 
                        End Try
                    End If
                End While
            Finally
                enumerator2.Dispose()
            End Try
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<RunPlugins>b__a)
            Sublight.BaseForm.DoCtrlInvoke(pbSecondary, Me, methodInvoker2)
            methodInvoker2 = New System.Windows.Forms.MethodInvoker(<RunPlugins>b__b)
            Sublight.BaseForm.DoCtrlInvoke(lblFontNormal, Me, methodInvoker2)
        End Sub

        Private Sub SecondaryDbSearch(ByVal a As Object)
            Dim s1 As String
            Dim subtitle1 As Sublight.WS.Subtitle
            Dim subtitleBasicInfoArr1 As Sublight.Plugins.SubtitleProvider.Types.SubtitleBasicInfo()

            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            If (a) Is Nothing Then
                Return
            End If
            Dim objArr1 As Object() = TryCast(a, Object[])
            If (objArr1) Is Nothing Then
                Return
            End If
            Dim isubtitleProvider1 As Sublight.Plugins.SubtitleProvider.ISubtitleProvider = TryCast(objArr1(0), Sublight.Plugins.SubtitleProvider.ISubtitleProvider)
            If (isubtitleProvider1) Is Nothing Then
                Return
            End If
            Dim searchFilterArr1 As Sublight.Plugins.SubtitleProvider.Types.SearchFilter() = TryCast(objArr1(2), Sublight.Plugins.SubtitleProvider.Types.SearchFilter[])
            Try
                subtitleBasicInfoArr1 = isubtitleProvider1.Search(TryCast(objArr1(1), string), searchFilterArr1, ByRef s1)
                If Not System.String.IsNullOrEmpty(s1) Then
                    If Not IsSearchAborted Then
                        Dim objArr2 As Object() = New object() { _
                                                                 isubtitleProvider1.ShortName, _
                                                                 s1 }
                        ShowError(Sublight.Translation.Plugin_SubtitleProvider_SearchError, objArr2)
                    End If
                    Return
                End If
            Catch e As System.Threading.ThreadAbortException
                Return
            Catch e As System.Exception
                If Not IsSearchAborted Then
                    Dim objArr3 As Object() = New object() { _
                                                             isubtitleProvider1.ShortName, _
                                                             e.Message }
                    ShowError(Sublight.Translation.Plugin_SubtitleProvider_SearchError, objArr3)
                End If
                Return
            End Try
            If Not (subtitleBasicInfoArr1) Is Nothing Then
                Dim list1 As System.Collections.Generic.List(Of Sublight.Controls.SuperListItem.Data) = New System.Collections.Generic.List(Of Sublight.Controls.SuperListItem.Data)
                Dim subtitleBasicInfoArr2 As Sublight.Plugins.SubtitleProvider.Types.SubtitleBasicInfo() = subtitleBasicInfoArr1
                Dim i1 As Integer = 0
                While i1 < subtitleBasicInfoArr2.Length
                    Dim subtitleBasicInfo1 As Sublight.Plugins.SubtitleProvider.Types.SubtitleBasicInfo = subtitleBasicInfoArr2(i1)
                    If Sublight.Plugins.SubtitleProvider.BaseSubtitleProvider.DoesMatchFilter(subtitleBasicInfo1, searchFilterArr1) Then
                        Dim subtitleInfo1 As Sublight.Plugins.SubtitleProvider.Types.SubtitleInfo = TryCast(subtitleBasicInfo1, Sublight.Plugins.SubtitleProvider.Types.SubtitleInfo)
                        If Not (subtitleInfo1) Is Nothing Then
                            subtitle1 = Sublight.FrmSearch.MapSubtitleInfo(subtitleInfo1)
                        Else 
                            subtitle1 = Sublight.FrmSearch.MapSubtitleBasicInfo(subtitleBasicInfo1)
                        End If
                        If Not (subtitle1) Is Nothing Then
                            Dim release1 As Sublight.WS.Release = New Sublight.WS.Release
                            release1.Name = subtitle1.Release
                            release1.FPS = subtitle1.FPS
                            Dim s2 As String = Sublight.Controls.BasePageResults.ReleaseToString(release1)
                            Dim sArr1 As String() = New string() { s2 }
                            list1.Add(New Sublight.Controls.SuperListItem.Data(subtitle1, sArr1, isubtitleProvider1))
                        End If
                    End If
                    i1 = i1 + 1
                End While
                If list1.get_Count() > 0 Then
                    AddSecondaryResults(list1)
                    If (methodInvoker2) Is Nothing Then
                        methodInvoker2 = New System.Windows.Forms.MethodInvoker(<SecondaryDbSearch>b__7)
                    End If
                    Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                    Sublight.BaseForm.DoCtrlInvoke(lblSecondary, Me, methodInvoker1)
                End If
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
            MyBase.OnClosing(e)
            If Not btnCancel.Enabled Then
                e.Cancel = True
                Return
            End If
            IsSearchAborted = True
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            Visible = True
            BringToFront()
            Select()
            m_lstItemsPrimary = New System.Collections.Generic.List(Of Sublight.Controls.SuperListItem.Data)
            m_lstItemsSecondary = New System.Collections.Generic.List(Of Sublight.Controls.SuperListItem.Data)
            lblPrimary.Text = Sublight.Translation.FrmSearch_SearchingPrimarySource
            lblSecondary.Text = Sublight.Translation.FrmSearch_SearchingSecondarySource
            pbPrimary.Image = Sublight.Properties.Resources.OperationWaiting
            pbSecondary.Image = Sublight.Properties.Resources.OperationWaiting
            InitPlugins()
            Dim thread1 As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(PrimaryDbSearch))
            thread1.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture
            thread1.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture
            thread1.Start()
            RunPlugins()
            While thread1.IsAlive
                System.Threading.Thread.Sleep(100)
                System.Windows.Forms.Application.DoEvents()
            End While
            Dim list1 As System.Collections.Generic.List(Of Sublight.Controls.SuperListItem.Data) = New System.Collections.Generic.List(Of Sublight.Controls.SuperListItem.Data)
            If m_lstItemsPrimary.get_Count() > 0 Then
                list1.AddRange(m_lstItemsPrimary)
            End If
            If m_lstItemsSecondary.get_Count() > 0 Then
                list1.AddRange(m_lstItemsSecondary)
            End If
            If list1.get_Count() > Sublight.Globals.MAX_RESULTS Then
                Items = list1.GetRange(0, Sublight.Globals.MAX_RESULTS).ToArray()
            Else 
                Items = list1.ToArray()
            End If
            Dim i1 As Integer = 0
            While i1 < 10
                System.Threading.Thread.Sleep(100)
                System.Windows.Forms.Application.DoEvents()
                i1 = i1 + 1
            End While
            Close()
        End Sub

        Private Shared Function MapSubtitleBasicInfo(ByVal sbi As Sublight.Plugins.SubtitleProvider.Types.SubtitleBasicInfo) As Sublight.WS.Subtitle
            Dim subtitle2 As Sublight.WS.Subtitle

            Try
                Dim subtitle1 As Sublight.WS.Subtitle = New Sublight.WS.Subtitle
                subtitle1.ExternalId = sbi.Id
                subtitle1.Language = DirectCast(System.Enum.Parse(GetType(Sublight.WS.SubtitleLanguage), System.Enum.GetName(GetType(Sublight.Plugins.SubtitleProvider.Types.Language), sbi.Language)), Sublight.WS.SubtitleLanguage)
                subtitle1.Title = sbi.Title
                subtitle1.FPS = Sublight.WS.FPS.NotAvailable
                subtitle2 = subtitle1
            Catch 
                subtitle2 = Nothing
            End Try
            Return subtitle2
        End Function

        Private Shared Function MapSubtitleInfo(ByVal si As Sublight.Plugins.SubtitleProvider.Types.SubtitleInfo) As Sublight.WS.Subtitle
            Dim subtitle2 As Sublight.WS.Subtitle

            Try
                Dim subtitle1 As Sublight.WS.Subtitle = New Sublight.WS.Subtitle
                subtitle1.ExternalId = si.Id
                subtitle1.Language = DirectCast(System.Enum.Parse(GetType(Sublight.WS.SubtitleLanguage), System.Enum.GetName(GetType(Sublight.Plugins.SubtitleProvider.Types.Language), si.Language)), Sublight.WS.SubtitleLanguage)
                subtitle1.Title = si.Title
                subtitle1.Genre = DirectCast(System.Enum.Parse(GetType(Sublight.WS.Genre), System.Enum.GetName(GetType(Sublight.WS.Genre), si.MovieType)), Sublight.WS.Genre)
                subtitle1.MediaType = DirectCast(System.Enum.Parse(GetType(Sublight.WS.MediaType), System.Enum.GetName(GetType(Sublight.WS.MediaType), si.MediaFormat)), Sublight.WS.MediaType)
                subtitle1.Release = IIf(Not (si.Release) Is Nothing, si.Release.Trim(), Nothing)
                subtitle1.FPS = DirectCast(System.Enum.Parse(GetType(Sublight.Plugins.SubtitleProvider.Types.FPS), System.Enum.GetName(GetType(Sublight.Plugins.SubtitleProvider.Types.FPS), si.FPS)), Sublight.WS.FPS)
                subtitle1.IMDB = si.Imdb
                If si.IsSeasonSet Then
                    subtitle1.Season = New System.Nullable(Of Byte)(System.Convert.ToByte(si.Season))
                End If
                If si.IsEpisodeSet Then
                    subtitle1.Episode = New System.Nullable(Of Integer)(si.Episode)
                End If
                If si.IsMediaCountSet Then
                    subtitle1.NumberOfDiscs = si.MediaCount
                End If
                If si.IsPublishDateSet Then
                    subtitle1.Created = si.PublishDate
                End If
                If si.IsDownloadSizeSet Then
                    subtitle1.Size = si.DownloadSize
                End If
                If si.IsYearSet Then
                    subtitle1.Year = New System.Nullable(Of Integer)(si.Year)
                End If
                If si.IsPublisherSet Then
                    subtitle1.Publisher = si.Publisher
                    If (Not (subtitle1.Publisher) Is Nothing) AndAlso (subtitle1.Publisher.Length > 10) Then
                        subtitle1.Publisher = System.String.Format("{0}...?", subtitle1.Publisher.Substring(0, 10))
                    End If
                End If
                If (Not (subtitle1.Title) Is Nothing) AndAlso (subtitle1.Title.Length > 100) Then
                    subtitle1.Title = System.String.Format("{0}...?", subtitle1.Title.Substring(0, 100))
                End If
                subtitle2 = subtitle1
            Catch 
                subtitle2 = Nothing
            End Try
            Return subtitle2
        End Function

    End Class ' class FrmSearch

End Namespace

