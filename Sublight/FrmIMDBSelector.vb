Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Properties
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmIMDBSelector
        Inherits Sublight.BaseForm

        Private Structure DLLVERSIONINFO

            Public cbSize As Integer 
            Public dwBuildNumber As Integer 
            Public dwMajorVersion As Integer 
            Public dwMinorVersion As Integer 
            Public dwPlatformID As Integer 

        End Structure

        Private Structure HDITEM

            Public cchTextMax As Integer 
            Public cxy As Integer 
            Public fmt As Integer 
            Public hbm As System.IntPtr 
            Public iImage As Integer 
            Public iOrder As Integer 
            Public lParam As Integer 
            Public mask As Integer 
            <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)> _
            Public pszText As String 

        End Structure

        Public Class ListViewColumnSorter
            Implements System.Collections.IComparer

            Private ReadOnly ObjectCompare As System.Collections.CaseInsensitiveComparer 

            Private ColumnToSort As Integer 
            Private OrderOfSort As System.Windows.Forms.SortOrder 

            Public Property Order As System.Windows.Forms.SortOrder
                Get
                    Return OrderOfSort
                End Get
                Set
                    OrderOfSort = value
                End Set
            End Property

            Public Property SortColumn As Integer
                Get
                    Return ColumnToSort
                End Get
                Set
                    ColumnToSort = value
                End Set
            End Property

            Public Sub New()
                OrderOfSort = System.Windows.Forms.SortOrder.None
                ObjectCompare = New System.Collections.CaseInsensitiveComparer
            End Sub

            Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer
                Dim listViewItem1 As System.Windows.Forms.ListViewItem = CType(x, System.Windows.Forms.ListViewItem)
                Dim listViewItem2 As System.Windows.Forms.ListViewItem = CType(y, System.Windows.Forms.ListViewItem)
                Dim i1 As Integer = ObjectCompare.Compare(listViewItem1.SubItems(ColumnToSort).Tag, listViewItem2.SubItems(ColumnToSort).Tag)
                If OrderOfSort = System.Windows.Forms.SortOrder.Ascending Then
                    Return i1
                End If
                If OrderOfSort = System.Windows.Forms.SortOrder.Descending Then
                    Return -i1
                End If
                Return 0
            End Function

        End Class ' class ListViewColumnSorter

        Private Const HDF_BITMAP_ON_RIGHT As Integer  = 4096
        Private Const HDF_CENTER As Integer  = 2
        Private Const HDF_IMAGE As Integer  = 2048
        Private Const HDF_LEFT As Integer  = 0
        Private Const HDF_RIGHT As Integer  = 1
        Private Const HDF_SORTDOWN As Integer  = 512
        Private Const HDF_SORTUP As Integer  = 1024
        Private Const HDF_STRING As Integer  = 16384
        Private Const HDI_FORMAT As Integer  = 4
        Private Const HDI_IMAGE As Integer  = 32
        Private Const HDM_FIRST As Integer  = 4608
        Private Const HDM_SETITEM As Integer  = 4620
        Private Const LVM_FIRST As Integer  = 4096
        Private Const LVM_GETHEADER As Integer  = 4127

        Private ReadOnly lvwColumnSorter As Sublight.FrmIMDBSelector.ListViewColumnSorter 
        Private ReadOnly s_useNativeArrows As Boolean 

        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnFind As Sublight.Controls.Button.Button 
        Private btnIMDB As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private colImdb As System.Windows.Forms.ColumnHeader 
        Private colTitle As System.Windows.Forms.ColumnHeader 
        Private colYear As System.Windows.Forms.ColumnHeader 
        Private components As System.ComponentModel.IContainer 
        Private groupBox1 As System.Windows.Forms.GroupBox 
        Private label1 As System.Windows.Forms.Label 
        Private label17 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 
        Private lblTipEnterToConfirm As System.Windows.Forms.Label 
        Private legendRequiredField1 As Sublight.Controls.LegendRequiredField 
        Private lvResult As System.Windows.Forms.ListView 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private txtTitle As Sublight.Controls.MyTextBox 
        Private txtYear As Sublight.Controls.MyTextBox 

        Public ReadOnly Property IMDB As String
            Get
                If lvResult.SelectedItems.Count <> 1 Then
                    Return Nothing
                End If
                Dim s1 As String = TryCast(lvResult.SelectedItems(0).Tag, string)
                If System.String.IsNullOrEmpty(s1) Then
                    Return Nothing
                End If
                Return System.String.Format("http://www.imdb.com/title/{0}?", s1)
            End Get
        End Property

        Public ReadOnly Property ImdbId As String
            Get
                If lvResult.SelectedItems.Count <> 1 Then
                    Return Nothing
                End If
                Dim s1 As String = TryCast(lvResult.SelectedItems(0).Tag, string)
                If System.String.IsNullOrEmpty(s1) Then
                    Return Nothing
                End If
                Return System.String.Format("{0}?", s1)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            lvwColumnSorter = New Sublight.FrmIMDBSelector.ListViewColumnSorter
            lvResult.ListViewItemSorter = lvwColumnSorter
            s_useNativeArrows = Sublight.FrmIMDBSelector.ComCtlDllSupportsArrows()
            legendRequiredField1.Translate()
            btnFind.Text = Sublight.Translation.Common_Button_Find
            btnOK.Text = Sublight.Translation.Common_Button_OK
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            Text = Sublight.Translation.SelectIMDB_Title
            groupBox1.Text = Sublight.Translation.SelectIMDB_Panel_SearchCriteria
            label1.Text = Sublight.Translation.SelectIMDB_Panel_SearchCriteria_Title
            label2.Text = Sublight.Translation.SelectIMDB_Panel_SearchCriteria_Year
            lblTipEnterToConfirm.Text = Sublight.Translation.SelectIMDB_Tip_ConfirmSelection
            btnIMDB.Enabled = False
            colTitle.Text = Sublight.Translation.Common_SearchResults_Column_Title
            colYear.Text = Sublight.Translation.Common_SearchResults_Column_Year
            lblTipEnterToConfirm.Visible = False
            Dim i1 As Integer = btnCancel.Right
            Dim buttonArr1 As Sublight.Controls.Button.Button() = New Sublight.Controls.Button.Button() { btnIMDB }
            Sublight.Controls.Button.Button.MakeSameWidth(buttonArr1, btnCancel.Width, 0)
            btnIMDB.Left = i1 - btnIMDB.Width
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim nullable1 As System.Nullable(Of Integer)

            btnOK.Enabled = False
            btnIMDB.Enabled = False
            lblTipEnterToConfirm.Visible = False
            lvResult.Items.Clear()
            lvwColumnSorter.Order = System.Windows.Forms.SortOrder.None
            lvwColumnSorter.SortColumn = 0
            lvResult.Sort()
            nullable1 = New System.Nullable(Of Integer)[]
            If Not System.String.IsNullOrEmpty(txtYear.Text) Then
                Try
                    nullable1 = New System.Nullable(Of Integer)(System.Int32.Parse(txtYear.Text))
                Catch 
                    ShowError(Sublight.Translation.SelectIMDB_ParsingYear, New object(0) {})
                    Return
                End Try
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                AddHandler sublight1.FindIMDBCompleted, AddressOf ws_FindIMDBCompleted
                ShowLoader(Me)
                sublight1.FindIMDBAsync(txtTitle.Text, nullable1)
            End Using
        End Sub

        Private Sub btnIMDB_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If lvResult.SelectedItems.Count <> 1 Then
                Return
            End If
            OpenInBrowser(IMDB)
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.OK
        End Sub

        Private Sub FrmIMDBSelector_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub FrmIMDBSelector_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub FrmIMDBSelector_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            txtTitle.Select()
        End Sub

        Private Sub InitializeComponent()
            niceLine1 = New Sublight.Controls.NiceLine
            btnCancel = New Sublight.Controls.Button.Button
            btnOK = New Sublight.Controls.Button.Button
            groupBox1 = New System.Windows.Forms.GroupBox
            pictureBox1 = New System.Windows.Forms.PictureBox
            btnFind = New Sublight.Controls.Button.Button
            label17 = New System.Windows.Forms.Label
            txtYear = New Sublight.Controls.MyTextBox
            label2 = New System.Windows.Forms.Label
            txtTitle = New Sublight.Controls.MyTextBox
            label1 = New System.Windows.Forms.Label
            legendRequiredField1 = New Sublight.Controls.LegendRequiredField
            lvResult = New System.Windows.Forms.ListView
            colTitle = New System.Windows.Forms.ColumnHeader
            colYear = New System.Windows.Forms.ColumnHeader
            colImdb = New System.Windows.Forms.ColumnHeader
            btnIMDB = New Sublight.Controls.Button.Button
            lblTipEnterToConfirm = New System.Windows.Forms.Label
            groupBox1.SuspendLayout()
            pictureBox1.BeginInit()
            SuspendLayout()
            niceLine1.Location = New System.Drawing.Point(3, 305)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(430, 15)
            niceLine1.TabIndex = 0
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(357, 323)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 5
            btnCancel.Text = "Preklici?"
            btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnCancel.UseVisualStyleBackColor = True
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnOK.AutoResize = False
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            btnOK.Enabled = False
            btnOK.Location = New System.Drawing.Point(276, 323)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 4
            btnOK.Text = "V redu?"
            btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnOK.UseVisualStyleBackColor = True
            AddHandler btnOK.Click, AddressOf btnOK_Click
            groupBox1.Controls.Add(pictureBox1)
            groupBox1.Controls.Add(btnFind)
            groupBox1.Controls.Add(label17)
            groupBox1.Controls.Add(txtYear)
            groupBox1.Controls.Add(label2)
            groupBox1.Controls.Add(txtTitle)
            groupBox1.Controls.Add(label1)
            groupBox1.Location = New System.Drawing.Point(3, 3)
            groupBox1.Name = "groupBox1?"
            groupBox1.Size = New System.Drawing.Size(429, 77)
            groupBox1.TabIndex = 121
            groupBox1.TabStop = False
            groupBox1.Text = "Iskalni kriteriji?"
            pictureBox1.BackColor = System.Drawing.Color.Transparent
            pictureBox1.Image = Sublight.Properties.Resources.SearchImdb
            pictureBox1.Location = New System.Drawing.Point(376, 17)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(46, 46)
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox1.TabIndex = 123
            pictureBox1.TabStop = False
            btnFind.AutoResize = False
            btnFind.Location = New System.Drawing.Point(273, 43)
            btnFind.Name = "btnFind?"
            btnFind.Size = New System.Drawing.Size(75, 23)
            btnFind.TabIndex = 2
            btnFind.Text = "Najdi?"
            btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnFind.UseVisualStyleBackColor = True
            AddHandler btnFind.Click, AddressOf btnFind_Click
            label17.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            label17.ForeColor = System.Drawing.Color.Red
            label17.Location = New System.Drawing.Point(354, 17)
            label17.Name = "label17?"
            label17.Size = New System.Drawing.Size(16, 20)
            label17.TabIndex = 122
            label17.Text = "*?"
            txtYear.EnableDisableColor = True
            txtYear.Location = New System.Drawing.Point(58, 43)
            txtYear.Name = "txtYear?"
            txtYear.Size = New System.Drawing.Size(49, 20)
            txtYear.TabIndex = 1
            AddHandler txtYear.KeyDown, AddressOf txtYear_KeyDown
            label2.AutoSize = True
            label2.Location = New System.Drawing.Point(9, 46)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(31, 13)
            label2.TabIndex = 120
            label2.Text = "Leto:?"
            txtTitle.EnableDisableColor = True
            txtTitle.Location = New System.Drawing.Point(58, 19)
            txtTitle.Name = "txtTitle?"
            txtTitle.Size = New System.Drawing.Size(290, 20)
            txtTitle.TabIndex = 0
            AddHandler txtTitle.KeyDown, AddressOf txtTitle_KeyDown
            label1.AutoSize = True
            label1.Location = New System.Drawing.Point(9, 22)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(43, 13)
            label1.TabIndex = 118
            label1.Text = "Naslov:?"
            legendRequiredField1.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            legendRequiredField1.ForeColor = System.Drawing.Color.Red
            legendRequiredField1.Location = New System.Drawing.Point(2, 323)
            legendRequiredField1.Name = "legendRequiredField1?"
            legendRequiredField1.Size = New System.Drawing.Size(136, 22)
            legendRequiredField1.TabIndex = 122
            Dim columnHeaderArr1 As System.Windows.Forms.ColumnHeader() = New System.Windows.Forms.ColumnHeader() { _
                                                                                                                    colTitle, _
                                                                                                                    colYear, _
                                                                                                                    colImdb }
            lvResult.Columns.AddRange(columnHeaderArr1)
            lvResult.FullRowSelect = True
            lvResult.GridLines = True
            lvResult.Location = New System.Drawing.Point(3, 86)
            lvResult.MultiSelect = False
            lvResult.Name = "lvResult?"
            lvResult.Size = New System.Drawing.Size(429, 173)
            lvResult.TabIndex = 124
            lvResult.UseCompatibleStateImageBehavior = False
            lvResult.View = System.Windows.Forms.View.Details
            AddHandler lvResult.MouseDoubleClick, AddressOf lvResult_MouseDoubleClick
            AddHandler lvResult.SelectedIndexChanged, AddressOf lvResult_SelectedIndexChanged
            AddHandler lvResult.ColumnClick, AddressOf lvResult_ColumnClick
            AddHandler lvResult.KeyDown, AddressOf lvResult_KeyDown
            colTitle.Text = "Naslov?"
            colYear.Text = "Leto?"
            colYear.Width = 95
            colImdb.Text = "IMDb?"
            colImdb.Width = 235
            btnIMDB.AutoResize = False
            btnIMDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnIMDB.Location = New System.Drawing.Point(333, 272)
            btnIMDB.Name = "btnIMDB?"
            btnIMDB.Size = New System.Drawing.Size(99, 23)
            btnIMDB.TabIndex = 125
            btnIMDB.Text = "IMDb...?"
            btnIMDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnIMDB.UseVisualStyleBackColor = True
            AddHandler btnIMDB.Click, AddressOf btnIMDB_Click
            lblTipEnterToConfirm.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblTipEnterToConfirm.Location = New System.Drawing.Point(3, 272)
            lblTipEnterToConfirm.Name = "lblTipEnterToConfirm?"
            lblTipEnterToConfirm.Size = New System.Drawing.Size(324, 30)
            lblTipEnterToConfirm.TabIndex = 152
            lblTipEnterToConfirm.Text = "Tip: you can press ENTER to confirm selection?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            CancelButton = btnCancel
            ClientSize = New System.Drawing.Size(437, 358)
            Controls.Add(lblTipEnterToConfirm)
            Controls.Add(btnIMDB)
            Controls.Add(lvResult)
            Controls.Add(legendRequiredField1)
            Controls.Add(groupBox1)
            Controls.Add(btnOK)
            Controls.Add(btnCancel)
            Controls.Add(niceLine1)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            KeyPreview = True
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmIMDBSelector?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Iskanje IMDb?"
            AddHandler Load, AddressOf FrmIMDBSelector_Load
            AddHandler KeyUp, AddressOf FrmIMDBSelector_KeyUp
            AddHandler KeyDown, AddressOf FrmIMDBSelector_KeyDown
            groupBox1.ResumeLayout(False)
            groupBox1.PerformLayout()
            pictureBox1.EndInit()
            ResumeLayout(False)
        End Sub

        Private Sub LoaderEnd()
            Cursor = System.Windows.Forms.Cursors.Default
        End Sub

        Private Sub LoaderStart()
            Cursor = System.Windows.Forms.Cursors.WaitCursor
        End Sub

        Private Sub lvResult_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
            If e.Column = lvwColumnSorter.SortColumn Then
                If lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending Then
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending
                Else 
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending
                End If
            Else 
                lvwColumnSorter.SortColumn = e.Column
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending
            End If
            lvResult.Sort()
            UpdateListViewResultsHeaderIcon()
        End Sub

        Private Sub lvResult_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        End Sub

        Private Sub lvResult_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            DialogResult = System.Windows.Forms.DialogResult.OK
        End Sub

        Private Sub lvResult_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            btnOK.Enabled = lvResult.SelectedItems.Count > 0
            btnIMDB.Enabled = lvResult.SelectedItems.Count > 0
            lblTipEnterToConfirm.Visible = lvResult.SelectedItems.Count > 0
        End Sub

        Private Sub ShowHeaderIcon(ByVal list As System.Windows.Forms.ListView, ByVal columnIndex As Integer, ByVal sortOrder As System.Windows.Forms.SortOrder)
            Dim hditem3 As Sublight.FrmIMDBSelector.HDITEM

            If (columnIndex < 0) OrElse (columnIndex >= list.Columns.Count) Then
                Return
            End If
            Dim intPtr1 As System.IntPtr = Sublight.FrmIMDBSelector.SendMessage(list.Handle, 4127, System.IntPtr.Zero, System.IntPtr.Zero)
            Dim columnHeader1 As System.Windows.Forms.ColumnHeader = list.Columns(columnIndex)
            hditem3 = New Sublight.FrmIMDBSelector.HDITEM
            Dim hditem2 As Sublight.FrmIMDBSelector.HDITEM = hditem3
            hditem2.mask = 4
            Dim hditem1 As Sublight.FrmIMDBSelector.HDITEM = hditem2
            Dim horizontalAlignment1 As System.Windows.Forms.HorizontalAlignment = columnHeader1.TextAlign
            If horizontalAlignment1 = System.Windows.Forms.HorizontalAlignment.Left Then
                hditem1.fmt = 20480
            ElseIf horizontalAlignment1 = System.Windows.Forms.HorizontalAlignment.Center Then
                hditem1.fmt = 20482
            Else 
                hditem1.fmt = 16385
            End If
            If s_useNativeArrows Then
                If sortOrder = System.Windows.Forms.SortOrder.Ascending Then
                    hditem1.fmt = hditem1.fmt Or 1024
                ElseIf sortOrder = System.Windows.Forms.SortOrder.Descending Then
                    hditem1.fmt = hditem1.fmt Or 512
                End If
            Else 
                hditem1.mask = hditem1.mask Or 32
                If sortOrder <> System.Windows.Forms.SortOrder.None Then
                    hditem1.fmt = hditem1.fmt Or 2048
                End If
                hditem1.iImage = CInt(sortOrder) - 1
            End If
            Sublight.FrmIMDBSelector.SendMessage2(intPtr1, 4620, New System.IntPtr(columnIndex), ByRef hditem1)
        End Sub

        Private Sub txtTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnFind_Click(Me, Nothing)
            End If
        End Sub

        Private Sub txtYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                btnFind_Click(Me, Nothing)
            End If
        End Sub

        Private Sub UpdateListViewResultsHeaderIcon()
            Try
                Dim i1 As Integer = 0
                While i1 < lvResult.Columns.Count
                    If i1 <> lvwColumnSorter.SortColumn Then
                        ShowHeaderIcon(lvResult, i1, System.Windows.Forms.SortOrder.None)
                    End If
                    i1 = i1 + 1
                End While
                ShowHeaderIcon(lvResult, lvwColumnSorter.SortColumn, lvwColumnSorter.Order)
            Catch 
            End Try
        End Sub

        Private Sub ws_FindIMDBCompleted(ByVal sender As Object, ByVal e As Sublight.WS.FindIMDBCompletedEventArgs)
            Try
                lvResult.BeginUpdate()
                If (Not (e.Error) Is Nothing) OrElse Not e.Result OrElse ((e.result) Is Nothing) Then
                    Return
                End If
                lvResult.ShowItemToolTips = True
                Dim imdbArr1 As Sublight.WS.IMDB() = e.result
                Dim i3 As Integer = 0
                While i3 < imdbArr1.Length
                    Dim imdb1 As Sublight.WS.IMDB = imdbArr1(i3)
                    Dim sArr1 As String() = New string(3) {}
                    sArr1(0) = IIf((Not (imdb1.Title) Is Nothing) AndAlso (imdb1.Title.Length > 40), imdb1.Title.Substring(0, 40) + "...?", imdb1.Title)
                    Dim nullable1 As System.Nullable(Of Integer) = imdb1.Year
                    Dim nullable2 As System.Nullable(Of Integer) = imdb1.Year
                    sArr1(1) = IIf(nullable1.get_HasValue(), nullable2.ToString(), System.String.Empty)
                    sArr1(2) = IIf((Not (imdb1.Id) Is Nothing) AndAlso imdb1.Id.ToLower().StartsWith("nn?"), System.String.Empty, imdb1.Id)
                    Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(sArr1)
                    listViewItem1.Tag = imdb1.Id
                    listViewItem1.ToolTipText = imdb1.Title
                    listViewItem1.SubItems(0).Tag = imdb1.Title
                    listViewItem1.SubItems(1).Tag = imdb1.Year
                    listViewItem1.SubItems(2).Tag = imdb1.Id
                    lvResult.Items.Add(listViewItem1)
                    i3 = i3 + 1
                End While
                Dim columnHeader1 As System.Windows.Forms.ColumnHeader 
                For Each columnHeader1 In lvResult.Columns
                    lvResult.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent)
                    Dim i1 As Integer = columnHeader1.Width
                    lvResult.AutoResizeColumn(columnHeader1.Index, System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize)
                    Dim i2 As Integer = columnHeader1.Width
                    If i1 > i2 Then
                        columnHeader1.Width = i1
                    Else 
                        columnHeader1.Width = i2
                    End If
                Next
                If lvResult.Items.Count > 0 Then
                    lvResult.Items(0).Selected = True
                    lvResult.Select()
                    lvResult.Focus()
                    btnIMDB.Enabled = True
                Else 
                    btnIMDB.Enabled = False
                    ShowInfo(Sublight.Translation.SelectIMDB_Info_NoImdbInfo, New object(0) {})
                End If
            Finally
                lvResult.EndUpdate()
                UpdateListViewResultsHeaderIcon()
                HideLoader(Me)
            End Try
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Shared Function ComCtlDllSupportsArrows() As Boolean
            Dim flag1 As Boolean
            Dim dllversioninfo3 As Sublight.FrmIMDBSelector.DLLVERSIONINFO

            Dim intPtr1 As System.IntPtr = System.IntPtr.Zero
            Try
                intPtr1 = Sublight.FrmIMDBSelector.LoadLibrary("comctl32.dll?")
                If intPtr1 <> System.IntPtr.Zero Then
                    Dim uintPtr1 As System.UIntPtr = Sublight.FrmIMDBSelector.GetProcAddress(intPtr1, "DllGetVersion?")
                    If uintPtr1 = System.UIntPtr.Zero Then
                        Return False
                    End If
                End If
                dllversioninfo3 = New Sublight.FrmIMDBSelector.DLLVERSIONINFO
                Dim dllversioninfo2 As Sublight.FrmIMDBSelector.DLLVERSIONINFO = dllversioninfo3
                dllversioninfo2.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(GetType(Sublight.FrmIMDBSelector.DLLVERSIONINFO))
                Dim dllversioninfo1 As Sublight.FrmIMDBSelector.DLLVERSIONINFO = dllversioninfo2
                Sublight.FrmIMDBSelector.DllGetVersion(ByRef dllversioninfo1)
                flag1 = dllversioninfo1.dwMajorVersion >= 6
            Finally
                If intPtr1 <> System.IntPtr.Zero Then
                    Sublight.FrmIMDBSelector.FreeLibrary(intPtr1)
                End If
            End Try
            Return flag1
        End Function

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function DllGetVersion Lib "comctl32.dll" (ByRef pdvi As Sublight.FrmIMDBSelector.DLLVERSIONINFO) As Integer

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function FreeLibrary Lib "kernel32.dll" (ByVal hModule As System.IntPtr) As Boolean

        <System.Runtime.InteropServices.PreserveSig
        Public Declare Ansi Function GetProcAddress Lib "kernel32.dll" (ByVal hModule As System.IntPtr, ByVal procName As String) As System.UIntPtr

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function LoadLibrary Lib "kernel32.dll" (ByVal fileName As String) As System.IntPtr

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function SendMessage Lib "user32" (ByVal Handle As System.IntPtr, ByVal msg As Integer, ByVal wParam As System.IntPtr, ByVal lParam As System.IntPtr) As System.IntPtr

        <System.Runtime.InteropServices.PreserveSig
        Private Declare Ansi Function SendMessage2 Lib "user32" (ByVal Handle As System.IntPtr, ByVal msg As Integer, ByVal wParam As System.IntPtr, ByRef lParam As Sublight.FrmIMDBSelector.HDITEM) As System.IntPtr

    End Class ' class FrmIMDBSelector

End Namespace

