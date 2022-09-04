Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Elegant.Ui
Imports Sublight
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Friend Class MyMoviesFolder
        Inherits Sublight.Controls.BasePage

        Private btnAddFolder As System.Windows.Forms.ToolStripButton 
        Private btnRemoveFolder As System.Windows.Forms.ToolStripButton 
        Private colFileTypes As System.Windows.Forms.ColumnHeader 
        Private colPath As System.Windows.Forms.ColumnHeader 
        Private colRecursive As System.Windows.Forms.ColumnHeader 
        Private components As System.ComponentModel.IContainer 
        Private lvFolders As System.Windows.Forms.ListView 
        Private m_initialized As Boolean 
        Private toolStrip2 As Sublight.Controls.SecondaryToolStrip 

        Public Shared ReadOnly Property NumberOfFolders As Integer
            Get
                If (Sublight.Properties.Settings.Default.MyMovies_Folders) Is Nothing Then
                    Return 0
                End If
                Return Sublight.Properties.Settings.Default.MyMovies_Folders.get_Count()
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal rtp As Elegant.Ui.RibbonTabPage)
            InitializeComponent()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Private Sub btnAddFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim frmAddMyMovieFolder1 As Sublight.FrmAddMyMovieFolder = New Sublight.FrmAddMyMovieFolder
            If frmAddMyMovieFolder1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                LoadMovieFoldersList()
            End If
            EnableDisableListViewFoldersButtons()
        End Sub

        Private Sub btnRemoveFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If ((lvFolders.SelectedItems) Is Nothing) OrElse (lvFolders.SelectedItems.Count <= 0) Then
                Return
            End If
            Dim list1 As System.Collections.Generic.List(Of Sublight.Types.MovieFolder) = New System.Collections.Generic.List(Of Sublight.Types.MovieFolder)
            Dim listViewItem1 As System.Windows.Forms.ListViewItem 
            For Each listViewItem1 In lvFolders.SelectedItems
                list1.Add(Sublight.Properties.Settings.Default.MyMovies_Folders.get_Item(listViewItem1.Index))
            Next
            Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Types.MovieFolder).Enumerator = list1.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim movieFolder1 As Sublight.Types.MovieFolder = enumerator1.get_Current()
                    Sublight.Properties.Settings.Default.MyMovies_Folders.Remove(movieFolder1)
                End While
            Finally
                enumerator1.Dispose()
            End Try
            ParentBaseForm.SaveUserSettings()
            LoadMovieFoldersList()
            EnableDisableListViewFoldersButtons()
        End Sub

        Private Sub EnableDisableListViewFoldersButtons()
            If ((lvFolders.SelectedItems) Is Nothing) OrElse (lvFolders.SelectedItems.Count <= 0) Then
                btnRemoveFolder.Enabled = False
            Else 
                btnRemoveFolder.Enabled = True
            End If
            If ((lvFolders.SelectedItems) Is Nothing) OrElse (lvFolders.SelectedItems.Count <> 1) Then
                btnRemoveFolder.Enabled = False
                Return
            End If
            btnRemoveFolder.Enabled = True
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            btnAddFolder.Text = Sublight.Translation.MyMovies_Folders_Button_AddFolder
            btnRemoveFolder.Text = Sublight.Translation.MyMovies_Folders_Button_RemoveFolder
            colPath.Text = Sublight.Translation.MyMovies_Folders_Column_Folder
            colFileTypes.Text = Sublight.Translation.MyMovies_Folders_Column_FileTypes
            colRecursive.Text = Sublight.Translation.MyMovies_Folders_Column_SearchSubfolders
        End Sub

        Public Sub Init()
            If m_initialized Then
                Return
            End If
            m_initialized = True
            LoadMovieFoldersList()
            EnableDisableListViewFoldersButtons()
        End Sub

        Private Sub InitializeComponent()
            Dim sArr1 As String() = New string() { _
                                                   "D:\MojiFilmi?", _
                                                   "avi, divx?", _
                                                   "Da?" }
            Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(sArr1, -1)
            lvFolders = New System.Windows.Forms.ListView
            colPath = New System.Windows.Forms.ColumnHeader
            colFileTypes = New System.Windows.Forms.ColumnHeader
            colRecursive = New System.Windows.Forms.ColumnHeader
            toolStrip2 = New Sublight.Controls.SecondaryToolStrip
            btnAddFolder = New System.Windows.Forms.ToolStripButton
            btnRemoveFolder = New System.Windows.Forms.ToolStripButton
            toolStrip2.SuspendLayout()
            SuspendLayout()
            Dim columnHeaderArr1 As System.Windows.Forms.ColumnHeader() = New System.Windows.Forms.ColumnHeader() { _
                                                                                                                    colPath, _
                                                                                                                    colFileTypes, _
                                                                                                                    colRecursive }
            lvFolders.Columns.AddRange(columnHeaderArr1)
            lvFolders.Dock = System.Windows.Forms.DockStyle.Fill
            lvFolders.FullRowSelect = True
            lvFolders.HideSelection = False
            Dim listViewItemArr1 As System.Windows.Forms.ListViewItem() = New System.Windows.Forms.ListViewItem() { listViewItem1 }
            lvFolders.Items.AddRange(listViewItemArr1)
            lvFolders.Location = New System.Drawing.Point(0, 25)
            lvFolders.Name = "lvFolders?"
            lvFolders.Size = New System.Drawing.Size(656, 346)
            lvFolders.TabIndex = 134
            lvFolders.UseCompatibleStateImageBehavior = False
            lvFolders.View = System.Windows.Forms.View.Details
            AddHandler lvFolders.SelectedIndexChanged, AddressOf lvFolders_SelectedIndexChanged
            colPath.Text = "Folder?"
            colPath.Width = 387
            colFileTypes.Text = "File types?"
            colFileTypes.Width = 99
            colRecursive.Text = "Search subfolders?"
            colRecursive.Width = 123
            Dim toolStripItemArr1 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       btnAddFolder, _
                                                                                                                       btnRemoveFolder }
            toolStrip2.Items.AddRange(toolStripItemArr1)
            toolStrip2.Location = New System.Drawing.Point(0, 0)
            toolStrip2.Name = "toolStrip2?"
            toolStrip2.Size = New System.Drawing.Size(656, 25)
            toolStrip2.TabIndex = 133
            toolStrip2.Text = "toolStrip2?"
            btnAddFolder.Image = Sublight.Properties.Resources.ToolbarExplorer
            btnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta
            btnAddFolder.Name = "btnAddFolder?"
            btnAddFolder.Size = New System.Drawing.Size(92, 22)
            btnAddFolder.Text = "Add folder...?"
            AddHandler btnAddFolder.Click, AddressOf btnAddFolder_Click
            btnRemoveFolder.Image = Sublight.Properties.Resources.ToolbarExplorerOffline
            btnRemoveFolder.ImageTransparentColor = System.Drawing.Color.Magenta
            btnRemoveFolder.Name = "btnRemoveFolder?"
            btnRemoveFolder.Size = New System.Drawing.Size(104, 22)
            btnRemoveFolder.Text = "Remove folder?"
            AddHandler btnRemoveFolder.Click, AddressOf btnRemoveFolder_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(lvFolders)
            Controls.Add(toolStrip2)
            Name = "MyMoviesFolder?"
            Size = New System.Drawing.Size(656, 371)
            toolStrip2.ResumeLayout(False)
            toolStrip2.PerformLayout()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub LoadMovieFoldersList()
            lvFolders.Items.Clear()
            If (Sublight.Properties.Settings.Default.MyMovies_Folders) Is Nothing Then
                Sublight.Properties.Settings.Default.MyMovies_Folders = New Sublight.Types.MovieFolderCollection
                ParentBaseForm.SaveUserSettings()
            End If
            Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Types.MovieFolder).Enumerator = Sublight.Properties.Settings.Default.MyMovies_Folders.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim movieFolder1 As Sublight.Types.MovieFolder = enumerator1.get_Current()
                    Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
                    If System.IO.Directory.Exists(movieFolder1.Path) Then
                        listViewItem1.ImageIndex = 2
                    Else 
                        listViewItem1.ImageIndex = 4
                    End If
                    listViewItem1.Tag = movieFolder1
                    listViewItem1.Text = movieFolder1.Path
                    listViewItem1.SubItems.Add(movieFolder1.Pattern)
                    listViewItem1.SubItems.Add(IIf(movieFolder1.SearchSubfolders, Sublight.Translation.Common_Yes, Sublight.Translation.Common_No))
                    lvFolders.Items.Add(listViewItem1)
                End While
            Finally
                enumerator1.Dispose()
            End Try
            Dim i1 As Integer = 0
            While i1 < lvFolders.Columns.Count
                lvFolders.AutoResizeColumn(i1, System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent)
                Dim i2 As Integer = lvFolders.Columns(i1).Width
                lvFolders.AutoResizeColumn(i1, System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize)
                Dim i3 As Integer = lvFolders.Columns(i1).Width
                lvFolders.Columns(i1).Width = System.Math.Max(i2, i3)
                i1 = i1 + 1
            End While
        End Sub

        Private Sub lvFolders_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            EnableDisableListViewFoldersButtons()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class MyMoviesFolder

End Namespace

