Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Net
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight.Controls

    Friend Class PageViewStatistics
        Inherits System.Windows.Forms.UserControl

        Private ReadOnly ParentBaseForm As Sublight.BaseForm 

        Private _pageView As Sublight.Controls.PageView 
        Private btnRefresh As System.Windows.Forms.ToolStripButton 
        Private cbChart As System.Windows.Forms.ToolStripComboBox 
        Private components As System.ComponentModel.IContainer 
        Private flp As System.Windows.Forms.FlowLayoutPanel 
        Private lblChart As System.Windows.Forms.ToolStripLabel 
        Private lblViewTitle As System.Windows.Forms.ToolStripLabel 
        Private m_bind As Boolean 
        Private panelDetails As System.Windows.Forms.Panel 
        Private toolStrip2 As Sublight.Controls.SecondaryToolStrip 
        Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator 
        Private webBrowser As System.Windows.Forms.WebBrowser 

        Public Sub New(ByVal parentBaseForm As Sublight.BaseForm, ByVal pageView As Sublight.Controls.PageView)
            InitializeComponent()
            ParentBaseForm = parentBaseForm
            _pageView = pageView
            cbChart.Visible = False
            lblChart.Visible = False
            toolStripSeparator1.Visible = False
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            AddHandler ParentBaseForm.KeyUp, AddressOf ParentBaseForm_KeyUp
            webBrowser.ScriptErrorsSuppressed = True
            Events_LanguageChanged(Me, Nothing)
        End Sub

        Public Sub BindControl()
            If m_bind Then
                Return
            End If
            ParentBaseForm.HideLoader(Me)
            Dim objArr1 As Object() = New object() { Sublight.BaseForm.Session }
            Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_BPR_PAGE_VIEW_STATISTICS_BIND, ParentBaseForm, Me, objArr1)
            AddHandler webServiceHandler1.OnException, AddressOf wshNewSubtitles_OnException
            AddHandler webServiceHandler1.DoCall, AddressOf Sublight.Controls.PageViewStatistics.wshNewSubtitles_DoCall
            AddHandler webServiceHandler1.OnResult, AddressOf wshNewSubtitles_OnResult
            AddHandler webServiceHandler1.OnCompleted, AddressOf wshNewSubtitles_OnCompleted
            webServiceHandler1.RunWorkerAsync()
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            m_bind = False
            BindControl()
        End Sub

        Private Sub cbChart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub DrawPieChart(ByVal dt As System.Data.DataTable, ByVal title As String)
            Dim s1 As String

            If (dt) Is Nothing Then
                Return
            End If
            Dim list1 As System.Collections.Generic.List(Of System.Windows.Forms.Control) = New System.Collections.Generic.List(Of System.Windows.Forms.Control)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In flp.Controls
                If TryCast(control1, Sublight.Controls.LGBarItem) Then
                    list1.Add(control1)
                End If
            Next
            Dim enumerator1 As System.Collections.Generic.List(Of System.Windows.Forms.Control).Enumerator = list1.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim control2 As System.Windows.Forms.Control = enumerator1.get_Current()
                    flp.Controls.Remove(control2)
                    control2.Dispose()
                End While
            Finally
                enumerator1.Dispose()
            End Try
            list1.Clear()
            flp.SuspendLayout()
            Dim dataRow1 As System.Data.DataRow 
            For Each dataRow1 In dt.Rows
                Dim f1 As Single = System.Convert.ToSingle(dataRow1("Count?"))
                Dim i1 As Integer = dt.Rows.IndexOf(dataRow1)
                If dataRow1.IsNull("Year?") Then
                    s1 = System.String.Format("{0} - {1:N2}%?", dataRow1("Title?"), dataRow1("Count?"))
                Else 
                    Dim objArr1 As Object() = New object() { _
                                                             i1 + 1, _
                                                             dataRow1("Title?"), _
                                                             dataRow1("Year?"), _
                                                             dataRow1("Count?") }
                    s1 = System.String.Format("{0}. {1} ({2}) - {3:N2}%?", objArr1)
                End If
                Dim lgbarItem1 As Sublight.Controls.LGBarItem = New Sublight.Controls.LGBarItem
                Dim padding1 As System.Windows.Forms.Padding = lgbarItem1.Padding
                Dim padding2 As System.Windows.Forms.Padding = lgbarItem1.Padding
                lgbarItem1.Width = flp.Width - (padding1.Left + padding2.Right)
                lgbarItem1.Text = s1
                lgbarItem1.Percentage = f1 / 100.0F
                AddHandler lgbarItem1.Click, AddressOf lgBarItem_Click
                lgbarItem1.Tag = dataRow1("IMDB?")
                If i1 = 0 Then
                    lgBarItem_Click(lgbarItem1, Nothing)
                End If
                flp.Controls.Add(lgbarItem1)
            Next
            flp.ResumeLayout()
            If flp.VerticalScroll.Visible Then
                flp.Width = flp.Width + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth
            End If
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            btnRefresh.Text = Sublight.Translation.View_Toolbar_Refresh + " (F5)?"
            lblViewTitle.Text = Sublight.Translation.View_Toolbar_Statistics_FavoritesMovies
            lblChart.Text = Sublight.Translation.View_Statistics_DisplayGraph
            If m_bind Then
                m_bind = False
                BindControl()
            End If
        End Sub

        Private Sub InitializeComponent()
            toolStrip2 = New Sublight.Controls.SecondaryToolStrip
            lblViewTitle = New System.Windows.Forms.ToolStripLabel
            lblChart = New System.Windows.Forms.ToolStripLabel
            cbChart = New System.Windows.Forms.ToolStripComboBox
            toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            btnRefresh = New System.Windows.Forms.ToolStripButton
            flp = New System.Windows.Forms.FlowLayoutPanel
            panelDetails = New System.Windows.Forms.Panel
            webBrowser = New System.Windows.Forms.WebBrowser
            toolStrip2.SuspendLayout()
            panelDetails.SuspendLayout()
            SuspendLayout()
            Dim toolStripItemArr1 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       lblViewTitle, _
                                                                                                                       lblChart, _
                                                                                                                       cbChart, _
                                                                                                                       toolStripSeparator1, _
                                                                                                                       btnRefresh }
            toolStrip2.Items.AddRange(toolStripItemArr1)
            toolStrip2.Location = New System.Drawing.Point(0, 0)
            toolStrip2.Name = "toolStrip2?"
            toolStrip2.Size = New System.Drawing.Size(873, 26)
            toolStrip2.TabIndex = 103
            toolStrip2.Text = "toolStrip2?"
            lblViewTitle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            lblViewTitle.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblViewTitle.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblViewTitle.Name = "lblViewTitle?"
            lblViewTitle.Size = New System.Drawing.Size(137, 23)
            lblViewTitle.Text = "najbolj priljubljeni filmi?"
            lblChart.Name = "lblChart?"
            lblChart.Size = New System.Drawing.Size(68, 23)
            lblChart.Text = "Prikaži graf:?"
            cbChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbChart.DropDownWidth = 400
            cbChart.Name = "cbChart?"
            cbChart.Size = New System.Drawing.Size(121, 26)
            AddHandler cbChart.SelectedIndexChanged, AddressOf cbChart_SelectedIndexChanged
            toolStripSeparator1.Name = "toolStripSeparator1?"
            toolStripSeparator1.Size = New System.Drawing.Size(6, 26)
            btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText
            btnRefresh.Image = Sublight.Properties.Resources.ToolbarReloadSmall
            btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
            btnRefresh.Name = "btnRefresh?"
            btnRefresh.Size = New System.Drawing.Size(64, 23)
            btnRefresh.Text = "Osveži?"
            AddHandler btnRefresh.Click, AddressOf btnRefresh_Click
            flp.AutoScroll = True
            flp.BackColor = System.Drawing.Color.White
            flp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            flp.Dock = System.Windows.Forms.DockStyle.Left
            flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            flp.Location = New System.Drawing.Point(0, 26)
            flp.Name = "flp?"
            flp.Size = New System.Drawing.Size(350, 493)
            flp.TabIndex = 104
            flp.WrapContents = False
            panelDetails.BackColor = System.Drawing.Color.White
            panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            panelDetails.Controls.Add(webBrowser)
            panelDetails.Dock = System.Windows.Forms.DockStyle.Fill
            panelDetails.Location = New System.Drawing.Point(350, 26)
            panelDetails.Name = "panelDetails?"
            panelDetails.Size = New System.Drawing.Size(523, 493)
            panelDetails.TabIndex = 105
            webBrowser.Dock = System.Windows.Forms.DockStyle.Fill
            webBrowser.Location = New System.Drawing.Point(0, 0)
            webBrowser.MinimumSize = New System.Drawing.Size(20, 20)
            webBrowser.Name = "webBrowser?"
            webBrowser.Size = New System.Drawing.Size(519, 489)
            webBrowser.TabIndex = 107
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(panelDetails)
            Controls.Add(flp)
            Controls.Add(toolStrip2)
            Name = "PageViewStatistics?"
            Size = New System.Drawing.Size(873, 519)
            toolStrip2.ResumeLayout(False)
            toolStrip2.PerformLayout()
            panelDetails.ResumeLayout(False)
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub lgBarItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In flp.Controls
                Dim lgbarItem1 As Sublight.Controls.LGBarItem = TryCast(control1, Sublight.Controls.LGBarItem)
                If Not (lgbarItem1) Is Nothing Then
                    lgbarItem1.IsSelected = False
                End If
            Next
            Dim lgbarItem2 As Sublight.Controls.LGBarItem = TryCast(sender, Sublight.Controls.LGBarItem)
            If Not (lgbarItem2) Is Nothing Then
                lgbarItem2.IsSelected = True
                Dim s1 As String = TryCast(lgbarItem2.Tag, string)
                If Not System.String.IsNullOrEmpty(s1) Then
                    ParentBaseForm.ShowLoader(Me)
                    Dim webClient1 As System.Net.WebClient = New System.Net.WebClient
                    AddHandler webClient1.DownloadStringCompleted, AddressOf wc_DownloadStringCompleted
                    webClient1.DownloadStringAsync(New System.Uri(System.String.Format("http://www.imdb.com/title/{0}?", s1)))
                End If
            End If
        End Sub

        Private Sub ParentBaseForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If _pageView.IsActiveTab AndAlso _pageView.BtnStatistics.Pressed AndAlso (e.KeyCode = System.Windows.Forms.Keys.F5) Then
                btnRefresh_Click(Me, Nothing)
            End If
        End Sub

        Private Sub wc_DownloadStringCompleted(ByVal sender As Object, ByVal e As System.Net.DownloadStringCompletedEventArgs)
            Try
                Dim s1 As String = e.Result
                webBrowser.DocumentText = s1
            Finally
                ParentBaseForm.HideLoader(Me)
            End Try
        End Sub

        Private Sub wshNewSubtitles_OnCompleted(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim flag1 As Boolean = btnRefresh.Enabled
            btnRefresh.Enabled = Not flag1
            btnRefresh.Enabled = flag1
        End Sub

        Private Sub wshNewSubtitles_OnException(ByVal ex As System.Exception)
            Dim objArr1 As Object() = New object() { ex.Message }
            ParentBaseForm.ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
        End Sub

        Private Sub wshNewSubtitles_OnResult(ByVal result As Object())
            If ((result) Is Nothing) OrElse (result.Length < 2) Then
                Return
            End If
            Dim dataSet1 As System.Data.DataSet = TryCast(result(0), System.Data.DataSet)
            If (Not (dataSet1) Is Nothing) AndAlso (dataSet1.Tables.Count > 0) Then
                m_bind = True
                cbChart.Items.Clear()
                If dataSet1.Tables.Count > 0 Then
                    cbChart.Items.Add(New Sublight.Types.ListItem(dataSet1.Tables(0).TableName, "Left?"))
                    DrawPieChart(dataSet1.Tables(0), dataSet1.Tables(0).TableName)
                End If
                If dataSet1.Tables.Count > 1 Then
                    cbChart.Items.Add(New Sublight.Types.ListItem(dataSet1.Tables(1).TableName, "Right?"))
                    DrawPieChart(dataSet1.Tables(1), dataSet1.Tables(1).TableName)
                End If
                If dataSet1.Tables.Count > 1 Then
                    cbChart.Items.Add(New Sublight.Types.ListItem(Sublight.Translation.Common_Selection_ShowAll, "ShowAll?"))
                End If
                If cbChart.Items.Count > 0 Then
                    cbChart.SelectedIndex = cbChart.Items.Count - 1
                End If
                If cbChart.Items.Count > 1 Then
                    cbChart.Visible = True
                    lblChart.Visible = True
                    toolStripSeparator1.Visible = True
                Else 
                    cbChart.Visible = False
                    lblChart.Visible = False
                    toolStripSeparator1.Visible = False
                End If
            End If
            If Not (dataSet1) Is Nothing Then
                dataSet1.Dispose()
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Shared Function wshNewSubtitles_DoCall(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim s1 As String
            Dim dataSet1 As System.Data.DataSet

            If ws.GetStatistics(Sublight.BaseForm.Session, Sublight.WS.StatisticsType.TopMovies, Sublight.Properties.Settings.Default.AppLanguage, out dataSet1, out s1) Then
                Dim objArr1 As Object() = New object() { _
                                                         dataSet1, _
                                                         s1 }
                result = objArr1
                Return True
            End If
            result = Nothing
            Return False
        End Function

    End Class ' class PageViewStatistics

End Namespace

