Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports Elegant.Ui
Imports ICSharpCode.SharpZipLib.Zip
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS
Imports Utility.Video

Namespace Sublight

    Friend Class FrmSync
        Inherits Sublight.BaseForm

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass1

            Public <>4__this As Sublight.FrmSync 
            Public e As Sublight.WS.GetDownloadTicket2CompletedEventArgs 

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

            Public CS$<>8__locals2 As Sublight.FrmSync.<>c__DisplayClass1 
            Public CS$<>8__locals4 As Sublight.FrmSync.<>c__DisplayClass3 
            Public d As Double 

            Public Sub New()
            End Sub

            Public Sub <ws_GetDownloadTicket2Completed>b__0()
                Using frmDownload1 As Sublight.FrmDownload = New Sublight.FrmDownload(CS$<>8__locals2.e.que, d)
                    CS$<>8__locals4.dr = frmDownload1.ShowDialog(CS$<>8__locals2.<>4__this)
                End Using
            End Sub

        End Class ' class <>c__DisplayClass5

        Private _list As Sublight.Controls.MySuperList 
        Private _pageSearch As Sublight.Controls.PageSearch 
        Private _subtitle As Sublight.WS.Subtitle 
        Private _subtitleId As System.Guid 
        Private _subtitles As String() 
        Private _subtitleTested As Boolean 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private btnTest As Sublight.Controls.Button.Button 
        Private cbDelay As Sublight.Controls.MyComboBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private label3 As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private numUpDown As Elegant.Ui.NumericUpDown 
        Private uolItem1 As Sublight.Controls.UOLItem 

        Public Sub New(ByVal pageSearch As Sublight.Controls.PageSearch, ByVal list As Sublight.Controls.MySuperList, ByVal subtitle As Sublight.WS.Subtitle, ByVal subtitleId As System.Guid)
            _subtitleId = subtitleId
            _subtitle = subtitle
            _pageSearch = pageSearch
            _list = list
            InitializeComponent()
            btnTest.Enabled = False
            uolItem1.Visible = False
            SetSubtitleNotTested()
            Text = Sublight.Translation.FrmSynchronize_Title
            label2.Text = Sublight.Translation.FrmSynchronize_Header
            label3.Text = Sublight.Translation.FrmSynchronize_Label_SetDelay
            label1.Text = Sublight.Translation.FrmSynchronize_Label_DelayUnit_Seconds
            btnTest.Text = Sublight.Translation.FrmSynchronize_Button_TestSubtitle
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            btnOK.Text = Sublight.Translation.FrmSynchronize_Button_Publish
            Dim i1 As Integer = btnTest.Right
            Sublight.Controls.Button.Button.MakeSameWidth(btnTest)
            btnTest.Left = i1 - btnTest.Width
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <EnableForm>b__7()
            Enabled = True
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            If ((_subtitles) Is Nothing) OrElse (_subtitles.Length <= 0) Then
                Return
            End If
            Enabled = False
            Try
                Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream
                    Using zipOutputStream1 As ICSharpCode.SharpZipLib.Zip.ZipOutputStream = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(memoryStream1)
                        zipOutputStream1.SetLevel(9)
                        If Not (_subtitles) Is Nothing Then
                            Dim i1 As Integer = 0
                            While i1 < _subtitles.Length
                                Dim s2 As String = System.String.Format("disc_{0}.txt?", i1 + 1)
                                Dim zipEntry1 As ICSharpCode.SharpZipLib.Zip.ZipEntry = New ICSharpCode.SharpZipLib.Zip.ZipEntry(s2)
                                zipEntry1.DateTime = System.DateTime.Now
                                zipOutputStream1.PutNextEntry(zipEntry1)
                                Dim bArr1 As Byte() = System.IO.File.ReadAllBytes(_subtitles(i1))
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
                ShowError(Sublight.Translation.Common_Error_SubtitleCompression, New object(0) {})
                Enabled = True
                Return
            End Try
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.PublishEditedSubtitle2Completed, AddressOf ws_PublishEditedSubtitle2Completed
                sublight1.PublishEditedSubtitle2Async(Sublight.BaseForm.Session, _subtitleId, "Subtitle synchronization.?", s1)
            End Using
        End Sub

        Private Sub btnTest_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            _subtitles = Nothing
            Enabled = False
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.GetDownloadTicket2Completed, AddressOf ws_GetDownloadTicket2Completed
                sublight1.GetDownloadTicket2Async(Sublight.BaseForm.Session, Nothing, _subtitleId.ToString("N?"))
            End Using
        End Sub

        Private Sub cbDelay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            SetSubtitleNotTested()
        End Sub

        Private Sub EnableForm()
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<EnableForm>b__7)
            Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
        End Sub

        Private Sub FrmSync_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub InitializeComponent()
            label2 = New System.Windows.Forms.Label
            niceLine1 = New Sublight.Controls.NiceLine
            btnOK = New Sublight.Controls.Button.Button
            btnCancel = New Sublight.Controls.Button.Button
            uolItem1 = New Sublight.Controls.UOLItem
            btnTest = New Sublight.Controls.Button.Button
            label1 = New System.Windows.Forms.Label
            cbDelay = New Sublight.Controls.MyComboBox
            numUpDown = New Elegant.Ui.NumericUpDown
            label3 = New System.Windows.Forms.Label
            numUpDown.BeginInit()
            SuspendLayout()
            label2.BackColor = System.Drawing.Color.White
            label2.Dock = System.Windows.Forms.DockStyle.Top
            label2.Location = New System.Drawing.Point(0, 0)
            label2.Name = "label2?"
            label2.Padding = New System.Windows.Forms.Padding(5)
            label2.Size = New System.Drawing.Size(431, 57)
            label2.TabIndex = 8
            label2.Text = "Here you can synchronize subtitle with your video. After you test subtitle you can share synchronized version of subtitle with other users. You will also receive bonus points for your contribution.?"
            niceLine1.Location = New System.Drawing.Point(-20, 130)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(460, 15)
            niceLine1.TabIndex = 10
            btnOK.AutoResize = False
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            btnOK.Enabled = False
            btnOK.Id = "5d1f59f5-bf74-4f3a-aa42-34d6131171bd?"
            btnOK.Image = Nothing
            btnOK.Location = New System.Drawing.Point(269, 148)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 11
            btnOK.Text = "Publish?"
            btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnOK.UseVisualStyleBackColor = True
            AddHandler btnOK.Click, AddressOf btnOK_Click
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Id = "fcc421bb-62b7-4781-af07-48b46c5b328d?"
            btnCancel.Image = Nothing
            btnCancel.Location = New System.Drawing.Point(350, 148)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 12
            btnCancel.Text = "Cancel?"
            btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnCancel.UseVisualStyleBackColor = True
            uolItem1.BackColor = System.Drawing.Color.FromArgb(255, 255, 225)
            uolItem1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            uolItem1.Items = Nothing
            uolItem1.Location = New System.Drawing.Point(12, 195)
            uolItem1.Name = "uolItem1?"
            uolItem1.Padding = New System.Windows.Forms.Padding(5)
            uolItem1.Size = New System.Drawing.Size(407, 99)
            uolItem1.TabIndex = 201
            btnTest.AutoResize = False
            btnTest.Id = "a21ca257-51df-49f3-8fd2-35a6c7e705d8?"
            btnTest.Image = Nothing
            btnTest.Location = New System.Drawing.Point(350, 93)
            btnTest.Name = "btnTest?"
            btnTest.Size = New System.Drawing.Size(75, 23)
            btnTest.TabIndex = 205
            btnTest.Text = "Test subtitle?"
            btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnTest.UseVisualStyleBackColor = True
            AddHandler btnTest.Click, AddressOf btnTest_Click
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(155, 98)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(47, 13)
            label1.TabIndex = 204
            label1.Text = "seconds?"
            cbDelay.DrawMode = System.Windows.Forms.DrawMode.Normal
            cbDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbDelay.DroppedDown = False
            cbDelay.Editable = False
            cbDelay.FormatInfo = Nothing
            cbDelay.FormatString = "dummy?"
            cbDelay.FormattingEnabled = False
            cbDelay.Id = "1fc398ad-900f-4978-8401-ced4470418a7?"
            cbDelay.ItemHeight = 22
            Dim objArr1 As Object() = New object() { _
                                                     "+?", _
                                                     "-?" }
            cbDelay.Items.AddRange(objArr1)
            cbDelay.LabelText = "dummy?"
            cbDelay.Location = New System.Drawing.Point(31, 94)
            cbDelay.Name = "cbDelay?"
            cbDelay.Size = New System.Drawing.Size(35, 21)
            cbDelay.Sorted = False
            cbDelay.TabIndex = 203
            cbDelay.Text = "+?"
            cbDelay.TextEditorWidth = 16
            AddHandler cbDelay.SelectedIndexChanged, AddressOf cbDelay_SelectedIndexChanged
            numUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular
            numUpDown.DecimalPlaces = 3
            numUpDown.EditorImage = Nothing
            numUpDown.Id = "e47cf7ed-24a2-4cba-b5e9-95752b359aaa?"
            Dim iArr1 As Integer() = New int(4) {}
            iArr1(0) = 1
            iArr1(3) = 65536
            numUpDown.Increment = New System.Decimal(iArr1)
            numUpDown.LabelText = "dummy?"
            numUpDown.Location = New System.Drawing.Point(72, 94)
            numUpDown.Name = "numUpDown?"
            numUpDown.Size = New System.Drawing.Size(75, 21)
            numUpDown.TabIndex = 202
            AddHandler numUpDown.ValueChanged, AddressOf numUpDown_ValueChanged
            label3.AutoSize = True
            label3.Location = New System.Drawing.Point(12, 70)
            label3.Name = "label3?"
            label3.Size = New System.Drawing.Size(54, 13)
            label3.TabIndex = 206
            label3.Text = "Set delay:?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            ClientSize = New System.Drawing.Size(431, 182)
            Controls.Add(label3)
            Controls.Add(btnTest)
            Controls.Add(label1)
            Controls.Add(cbDelay)
            Controls.Add(numUpDown)
            Controls.Add(uolItem1)
            Controls.Add(btnOK)
            Controls.Add(btnCancel)
            Controls.Add(niceLine1)
            Controls.Add(label2)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmSync?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Synchronize subtitle?"
            AddHandler Load, AddressOf FrmSync_Load
            numUpDown.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub numUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If numUpDown.Value = (0D) Then
                btnTest.Enabled = False
            Else 
                btnTest.Enabled = True
            End If
            SetSubtitleNotTested()
        End Sub

        Private Sub SetSubtitleNotTested()
            _subtitleTested = False
            btnOK.Enabled = _subtitleTested
        End Sub

        Private Sub SetSubtitleTested()
            If numUpDown.Value <= (0D) Then
                Return
            End If
            _subtitleTested = True
            btnOK.Enabled = _subtitleTested
        End Sub

        Private Sub ws_GetDownloadTicket2Completed(ByVal sender As Object, ByVal e As Sublight.WS.GetDownloadTicket2CompletedEventArgs)
            Dim i1 As Integer

            Dim <>c__DisplayClass1_1 As Sublight.FrmSync.<>c__DisplayClass1 = New Sublight.FrmSync.<>c__DisplayClass1
            <>c__DisplayClass1_1.e = e
            <>c__DisplayClass1_1.<>4__this = Me
            If Sublight.BaseForm.HandleWSErrors(Me, <>c__DisplayClass1_1.e) Then
                EnableForm()
                Return
            End If
            If <>c__DisplayClass1_1.e.que > 0 Then
                Dim <>c__DisplayClass3_1 As Sublight.FrmSync.<>c__DisplayClass3 = New Sublight.FrmSync.<>c__DisplayClass3
                <>c__DisplayClass3_1.dr = System.Windows.Forms.DialogResult.Cancel
                Try
                    Dim <>c__DisplayClass5_1 As Sublight.FrmSync.<>c__DisplayClass5 = New Sublight.FrmSync.<>c__DisplayClass5
                    <>c__DisplayClass5_1.CS$<>8__locals4 = <>c__DisplayClass3_1
                    <>c__DisplayClass5_1.CS$<>8__locals2 = <>c__DisplayClass1_1
                    <>c__DisplayClass5_1.d = <>c__DisplayClass1_1.e.points
                    Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass5_1.<ws_GetDownloadTicket2Completed>b__0)
                    Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1, True)
                Catch 
                    <>c__DisplayClass3_1.dr = System.Windows.Forms.DialogResult.Cancel
                End Try
                If <>c__DisplayClass3_1.dr <> System.Windows.Forms.DialogResult.OK Then
                    EnableForm()
                    Return
                End If
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
            Dim s1 As String = TryCast(<>c__DisplayClass1_1.e.UserState, string)
            Dim f1 As Single = -1.0F
            If Not System.String.IsNullOrEmpty(s1) Then
                Try
                    f1 = System.Single.Parse(s1, System.Globalization.CultureInfo.InvariantCulture)
                Catch 
                    f1 = -1.0F
                End Try
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.SynchronizeSubtitleCompleted, AddressOf ws_SynchronizeSubtitleCompleted
                Dim f2 As Single = System.Convert.ToSingle(numUpDown.Value)
                If cbDelay.SelectedIndex = 1 Then
                    f2 = -f2
                End If
                sublight1.SynchronizeSubtitleAsync(Sublight.BaseForm.Session, _subtitleId, i1, f1, f2, <>c__DisplayClass1_1.e.ticket)
            End Using
        End Sub

        Private Sub ws_PublishEditedSubtitle2Completed(ByVal sender As Object, ByVal e As Sublight.WS.PublishEditedSubtitle2CompletedEventArgs)
            Try
                If Sublight.BaseForm.HandleWSErrors(Me, e) Then
                    Return
                End If
                Dim s1 As String = Utility.Video.Checksum.Compute(_pageSearch.SelectedVideo)
                If Not System.String.IsNullOrEmpty(s1) Then
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        sublight1.AddHashLinkAutomatic3Async(Sublight.BaseForm.Session, e.ID, s1)
                    End Using
                End If
                ShowInfo(Sublight.Translation.Publish_Info_SuccessfullyPublished, New object(0) {})
                If e.Result Then
                    Sublight.Globals.UpdateUserPoints(e.points)
                End If
            Finally
                Enabled = True
            End Try
        End Sub

        Private Sub ws_SynchronizeSubtitleCompleted(ByVal sender As Object, ByVal e As Sublight.WS.SynchronizeSubtitleCompletedEventArgs)
            Dim s2 As String
            Dim sArr1 As String()

            If Sublight.BaseForm.HandleWSErrors(Me, e) Then
                EnableForm()
                Return
            End If
            Sublight.Globals.UpdateUserPoints(e.points)
            Dim s1 As String = _pageSearch.SelectedVideo
            If Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.CustomFolder Then
                s2 = Sublight.Properties.Settings.Default.CustomDownloadLocation
            ElseIf Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.Auto Then
                s2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), Sublight.Globals.AutoDownloadLocation)
                If Not System.IO.Directory.Exists(s2) Then
                    System.IO.Directory.CreateDirectory(s2)
                End If
            ElseIf (Sublight.Properties.Settings.Default.DownloadType = Sublight.Types.DownloadLocation.VideoFolder) AndAlso Not System.String.IsNullOrEmpty(s1) AndAlso System.IO.File.Exists(s1) Then
                s2 = System.IO.Path.GetDirectoryName(s1)
            Else 
                Dim folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
                folderBrowserDialog1.Description = Sublight.Translation.Dialog_SaveSubtitleToFolder_Description
                If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    s2 = folderBrowserDialog1.SelectedPath
                Else 
                    s2 = Nothing
                End If
            End If
            Dim list1 As System.Collections.Generic.List(Of Object) = New System.Collections.Generic.List(Of Object)
            list1.Add(Nothing)
            list1.Add(Nothing)
            list1.Add(s1)
            list1.Add(1)
            list1.Add(Nothing)
            list1.Add(Nothing)
            list1.Add(_subtitle)
            list1.Add(e.data)
            list1.Add(0)
            list1.Add(-1)
            list1.Add(s2)
            list1.Add(_list)
            list1.Add(1)
            list1.Add(s1)
            list1.Add(Nothing)
            _pageSearch.wsh_OnResult(list1.ToArray(), False, out sArr1)
            If (Not (sArr1) Is Nothing) AndAlso (sArr1.Length > 0) Then
                SetSubtitleTested()
                _subtitles = sArr1
            End If
            EnableForm()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Globals.ColorSeparator)
                e.Graphics.DrawLine(pen1, 0, label2.Height, Width - 2, label2.Height)
            End Using
        End Sub

    End Class ' class FrmSync

End Namespace

