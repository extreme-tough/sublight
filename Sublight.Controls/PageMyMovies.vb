Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Elegant.Ui
Imports Sublight

Namespace Sublight.Controls

    Friend Class PageMyMovies
        Inherits Sublight.Controls.BasePage

        Friend Class ListViewColumnSorter
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
                ColumnToSort = 0
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

        Private _btnBatchDownload As Elegant.Ui.Button 
        Private _btnFiles As Elegant.Ui.ToggleButton 
        Private _btnFolders As Elegant.Ui.ToggleButton 
        Private components As System.ComponentModel.IContainer 
        Private ctrlFiles As Sublight.Controls.MyMoviesFiles 
        Private ctrlFolders As Sublight.Controls.MyMoviesFolder 
        Private m_displayed As Boolean 

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal searchPage As Sublight.Controls.PageSearch, ByVal rtp As Elegant.Ui.RibbonTabPage)
            InitializeComponent()
            Init(parent, searchPage)
            ctrlFiles.MyMoviesFolderCtrl = ctrlFolders
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            AddHandler Sublight.Globals.Events.UserLogIn, AddressOf Events_UserLogIn
            ctrlFiles.Dock = System.Windows.Forms.DockStyle.Fill
            ctrlFolders.Dock = System.Windows.Forms.DockStyle.Fill
        End Sub

        Private Sub btnBatchDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim frmBatchDownload1 As Sublight.FrmBatchDownload = New Sublight.FrmBatchDownload
            frmBatchDownload1.ShowDialog(Me)
            frmBatchDownload1.Dispose()
        End Sub

        Private Sub btnFiles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            UncheckAll()
            HideAll()
            _btnFiles.Pressed = True
            ctrlFiles.Visible = True
            ctrlFiles.Init()
        End Sub

        Private Sub btnFolders_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            UncheckAll()
            HideAll()
            _btnFolders.Pressed = True
            ctrlFolders.Visible = True
            ctrlFolders.Init()
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            _btnFiles.Text = Sublight.Translation.MyMovies_Button_VideoFiles
            _btnFolders.Text = Sublight.Translation.MyMovies_Button_VideoFolders
            _btnBatchDownload.Text = Sublight.Translation.MyMovies_Button_BatchDownload
        End Sub

        Private Sub Events_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            _btnBatchDownload.Enabled = Not isAnonymous
        End Sub

        Private Sub HideAll()
            ctrlFiles.Visible = False
            ctrlFolders.Visible = False
        End Sub

        Private Sub Init(ByVal parent As Sublight.BaseForm, ByVal searchPage As Sublight.Controls.PageSearch)
            SuspendLayout()
            _btnFiles = TryCast(GetTabControlByName("tgMyMoviesFiles?"), Elegant.Ui.ToggleButton)
            If (_btnFiles) Is Nothing Then
                Throw New System.NullReferenceException("tgMyMoviesFiles?")
            End If
            _btnFiles.Pressed = True
            AddHandler _btnFiles.Click, AddressOf btnFiles_Click
            _btnFolders = TryCast(GetTabControlByName("tgMyMoviesFolders?"), Elegant.Ui.ToggleButton)
            If (_btnFolders) Is Nothing Then
                Throw New System.NullReferenceException("tgMyMoviesFolders?")
            End If
            AddHandler _btnFolders.Click, AddressOf btnFolders_Click
            _btnBatchDownload = TryCast(GetTabControlByName("btnMyMoviesBatchDownload?"), Elegant.Ui.Button)
            If (_btnBatchDownload) Is Nothing Then
                Throw New System.NullReferenceException("btnMyMoviesBatchDownload?")
            End If
            AddHandler _btnBatchDownload.Click, AddressOf btnBatchDownload_Click
            ctrlFiles = New Sublight.Controls.MyMoviesFiles(parent, searchPage, RibbonTabPage)
            ctrlFolders = New Sublight.Controls.MyMoviesFolder(parent, RibbonTabPage)
            ctrlFiles.Location = New System.Drawing.Point(3, 30)
            ctrlFiles.Name = "ctrlFiles?"
            ctrlFiles.Size = New System.Drawing.Size(716, 232)
            ctrlFiles.TabIndex = 101
            ctrlFolders.Location = New System.Drawing.Point(3, 268)
            ctrlFolders.Name = "ctrlFolders?"
            ctrlFolders.Size = New System.Drawing.Size(729, 179)
            ctrlFolders.TabIndex = 102
            Controls.Add(ctrlFolders)
            Controls.Add(ctrlFiles)
            ResumeLayout()
        End Sub

        Private Sub InitializeComponent()
            SuspendLayout()
            AllowDrop = True
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Name = "PageMyMovies?"
            Size = New System.Drawing.Size(811, 447)
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub UncheckAll()
            _btnFiles.Pressed = False
            _btnFolders.Pressed = False
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Sub OnDisplayed()
            MyBase.OnDisplayed()
            If Not m_displayed Then
                m_displayed = True
                btnFiles_Click(Me, Nothing)
            End If
        End Sub

    End Class ' class PageMyMovies

End Namespace

