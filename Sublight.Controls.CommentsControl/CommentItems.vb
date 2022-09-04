Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button

Namespace Sublight.Controls.CommentsControl

    Public Class CommentItems
        Inherits System.Windows.Forms.UserControl

        Public Delegate Sub AdminDeleteClickedHandler(ByVal sender As Object, ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)
        Public Delegate Sub LoadFirstPageHandler(ByVal sender As Object, ByVal page As Integer, ByVal elementIndexStart As Integer, ByVal elementIndexEnd As Integer, ByVal cip As Sublight.Controls.CommentsControl.CommentItemsPanel)
        Public Delegate Sub PageChangedHandler(ByVal sender As Object, ByVal page As Integer, ByVal elementIndexStart As Integer, ByVal elementIndexEnd As Integer, ByVal cip As Sublight.Controls.CommentsControl.CommentItemsPanel)
        Public Delegate Sub ReportClickedHandler(ByVal sender As Object, ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)
        Public Delegate Sub VoteClickedHandler(ByVal sender As Object, ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)

        Private btnNext As Sublight.Controls.Button.Button 
        Private btnPrev As Sublight.Controls.Button.Button 
        Private cbPage As System.Windows.Forms.ComboBox 
        Private cip As Sublight.Controls.CommentsControl.CommentItemsPanel 
        Private components As System.ComponentModel.IContainer 
        Private lblPage As System.Windows.Forms.Label 

        Private m_cancelOnPageChanged As Boolean 
        Private m_ItemsCount As Integer 
        Private m_ItemsPerPage As Integer 
        Private m_Pages As Integer 

        Private panelFooter As System.Windows.Forms.Panel 
        Private panelFooterRight As System.Windows.Forms.Panel 

        Public Event AdminDeleteClicked As Sublight.Controls.CommentsControl.CommentItems.AdminDeleteClickedHandler
        Public Event LoadFirstPage As Sublight.Controls.CommentsControl.CommentItems.LoadFirstPageHandler
        Public Event PageChanged As Sublight.Controls.CommentsControl.CommentItems.PageChangedHandler
        Public Event ReportClicked As Sublight.Controls.CommentsControl.CommentItems.ReportClickedHandler
        Public Event VoteClicked As Sublight.Controls.CommentsControl.CommentItems.VoteClickedHandler

        Public Property ItemsCount As Integer
            Get
                Return m_ItemsCount
            End Get
            Set
                If value >= 0 Then
                    m_ItemsCount = value
                    Pages = System.Convert.ToInt32(System.Math.Ceiling(System.Convert.ToDouble(m_ItemsCount) / System.Convert.ToDouble(ItemsPerPage)))
                    If Pages <= 0 Then
                        Pages = 1
                    End If
                End If
            End Set
        End Property

        Public Property ItemsPerPage As Integer
            Get
                Return m_ItemsPerPage
            End Get
            Set
                If value > 0 Then
                    m_ItemsPerPage = value
                End If
            End Set
        End Property

        Protected Property Pages As Integer
            Get
                Return m_Pages
            End Get
            Set
                m_Pages = value
                cbPage.Items.Clear()
                Dim i1 As Integer = 1
                While i1 <= value
                    cbPage.Items.Add(i1)
                    i1 = i1 + 1
                End While
            End Set
        End Property

        Public ReadOnly Property SelectedPage As Integer
            Get
                If ((cbPage) Is Nothing) OrElse ((cbPage.SelectedItem) Is Nothing) Then
                    Return 1
                End If
                Return DirectCast(cbPage.SelectedItem, int)
            End Get
        End Property

        Public Sub New()
            m_ItemsPerPage = 10
            InitializeComponent()
            lblPage.Text = Sublight.Translation.Ctrl_Comments_DisplayPage
        End Sub

        Protected Sub AddItem(ByVal ci As Sublight.Controls.CommentsControl.CommentItem)
            cip.Controls.Add(ci)
        End Sub

        Private Sub btnAdminDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim control1 As System.Windows.Forms.Control = TryCast(sender, System.Windows.Forms.Control)
            If Not (control1) Is Nothing Then
                OnAdminDeleteClicked(TryCast(control1.Tag, Sublight.Controls.CommentsControl.CommentItem))
            End If
        End Sub

        Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Dim i1 As Integer = DirectCast(cbPage.SelectedItem, int)
                cbPage.SelectedItem = i1 + 1
            Catch 
            End Try
        End Sub

        Private Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Dim i1 As Integer = SelectedPage
                cbPage.SelectedItem = i1 - 1
            Catch 
            End Try
        End Sub

        Private Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim control1 As System.Windows.Forms.Control = TryCast(sender, System.Windows.Forms.Control)
            If Not (control1) Is Nothing Then
                OnReportClicked(TryCast(control1.Tag, Sublight.Controls.CommentsControl.CommentItem))
            End If
        End Sub

        Private Sub btnVote_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim control1 As System.Windows.Forms.Control = TryCast(sender, System.Windows.Forms.Control)
            If Not (control1) Is Nothing Then
                OnVoteClicked(TryCast(control1.Tag, Sublight.Controls.CommentsControl.CommentItem))
            End If
        End Sub

        Private Sub cbPage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Dim i1 As Integer = SelectedPage
                btnPrev.Enabled = i1 > 1
                btnNext.Enabled = i1 < m_Pages
                If Not m_cancelOnPageChanged Then
                    OnPageChanged(i1, cip)
                End If
            Catch 
            End Try
        End Sub

        Private Sub cip_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs)
            Dim commentItem1 As Sublight.Controls.CommentsControl.CommentItem = TryCast(e.Control, Sublight.Controls.CommentsControl.CommentItem)
            If (commentItem1) Is Nothing Then
                Return
            End If
            AddHandler commentItem1.btnAdminDelete.Click, AddressOf btnAdminDelete_Click
            AddHandler commentItem1.btnVote.Click, AddressOf btnVote_Click
            AddHandler commentItem1.btnReport.Click, AddressOf btnReport_Click
        End Sub

        Public Sub DisplayFirstPage()
            OnLoadFirstPage(1, cip)
        End Sub

        Private Sub FillItems(ByVal page As Integer, ByVal commentItemsPanel As Sublight.Controls.CommentsControl.CommentItemsPanel, ByVal lfph As Sublight.Controls.CommentsControl.CommentItems.LoadFirstPageHandler, ByVal pch As Sublight.Controls.CommentsControl.CommentItems.PageChangedHandler)
            Dim list1 As System.Collections.Generic.List(Of Sublight.Controls.CommentsControl.CommentItem) = New System.Collections.Generic.List(Of Sublight.Controls.CommentsControl.CommentItem)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In cip.Controls
                Dim commentItem1 As Sublight.Controls.CommentsControl.CommentItem = TryCast(control1, Sublight.Controls.CommentsControl.CommentItem)
                If Not (commentItem1) Is Nothing Then
                    list1.Add(commentItem1)
                End If
            Next
            cip.SuspendLayout()
            cip.Controls.Clear()
            Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Controls.CommentsControl.CommentItem).Enumerator = list1.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim commentItem2 As Sublight.Controls.CommentsControl.CommentItem = enumerator1.get_Current()
                    commentItem2.Dispose()
                End While
            Finally
                enumerator1.Dispose()
            End Try
            If Not (pch) Is Nothing Then
                Dim i1 As Integer = (SelectedPage - 1) * ItemsPerPage
                Dim i2 As Integer = i1 + ItemsPerPage - 1
                RaiseEvent pch(Me, page, i1, i2, commentItemsPanel)
                Return
            End If
            If Not (lfph) Is Nothing Then
                RaiseEvent lfph(Me, page, 0, ItemsPerPage - 1, commentItemsPanel)
                Return
            End If
            cip.ControlsAdded()
        End Sub

        Private Sub InitializeComponent()
            panelFooter = New System.Windows.Forms.Panel
            panelFooterRight = New System.Windows.Forms.Panel
            btnPrev = New Sublight.Controls.Button.Button
            btnNext = New Sublight.Controls.Button.Button
            lblPage = New System.Windows.Forms.Label
            cbPage = New System.Windows.Forms.ComboBox
            cip = New Sublight.Controls.CommentsControl.CommentItemsPanel
            panelFooter.SuspendLayout()
            panelFooterRight.SuspendLayout()
            SuspendLayout()
            panelFooter.Controls.Add(panelFooterRight)
            panelFooter.Controls.Add(lblPage)
            panelFooter.Controls.Add(cbPage)
            panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            panelFooter.Location = New System.Drawing.Point(0, 218)
            panelFooter.Name = "panelFooter?"
            panelFooter.Size = New System.Drawing.Size(514, 35)
            panelFooter.TabIndex = 1
            AddHandler panelFooter.Paint, AddressOf panelFooter_Paint
            panelFooterRight.Controls.Add(btnPrev)
            panelFooterRight.Controls.Add(btnNext)
            panelFooterRight.Dock = System.Windows.Forms.DockStyle.Right
            panelFooterRight.Location = New System.Drawing.Point(349, 0)
            panelFooterRight.Name = "panelFooterRight?"
            panelFooterRight.Size = New System.Drawing.Size(165, 35)
            panelFooterRight.TabIndex = 4
            btnPrev.Location = New System.Drawing.Point(3, 6)
            btnPrev.Name = "btnPrev?"
            btnPrev.Size = New System.Drawing.Size(75, 23)
            btnPrev.TabIndex = 5
            btnPrev.Text = "<<?"
            AddHandler btnPrev.Click, AddressOf btnPrev_Click
            btnNext.Location = New System.Drawing.Point(84, 6)
            btnNext.Name = "btnNext?"
            btnNext.Size = New System.Drawing.Size(75, 23)
            btnNext.TabIndex = 4
            btnNext.Text = ">>?"
            AddHandler btnNext.Click, AddressOf btnNext_Click
            lblPage.AutoSize = True
            lblPage.Location = New System.Drawing.Point(6, 12)
            lblPage.Name = "lblPage?"
            lblPage.Size = New System.Drawing.Size(35, 13)
            lblPage.TabIndex = 1
            lblPage.Text = "Stran:?"
            cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbPage.FormattingEnabled = True
            cbPage.Location = New System.Drawing.Point(47, 8)
            cbPage.Name = "cbPage?"
            cbPage.Size = New System.Drawing.Size(63, 21)
            cbPage.TabIndex = 0
            AddHandler cbPage.SelectedIndexChanged, AddressOf cbPage_SelectedIndexChanged
            cip.AutoScroll = True
            cip.BackColor = System.Drawing.SystemColors.Window
            cip.Dock = System.Windows.Forms.DockStyle.Fill
            cip.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            cip.Location = New System.Drawing.Point(0, 0)
            cip.Margin = New System.Windows.Forms.Padding(0)
            cip.Name = "cip?"
            cip.Size = New System.Drawing.Size(514, 218)
            cip.TabIndex = 2
            cip.WrapContents = False
            AddHandler cip.ControlAdded, AddressOf cip_ControlAdded
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Controls.Add(cip)
            Controls.Add(panelFooter)
            Name = "CommentItems?"
            Size = New System.Drawing.Size(514, 253)
            panelFooter.ResumeLayout(False)
            panelFooter.PerformLayout()
            panelFooterRight.ResumeLayout(False)
            ResumeLayout(False)
        End Sub

        Private Sub panelFooter_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawLine(System.Drawing.SystemPens.ButtonShadow, 0, 0, Width, 0)
        End Sub

        Public Sub SelectFirstPage()
            Try
                m_cancelOnPageChanged = True
                If cbPage.Items.Count > 0 Then
                    cbPage.SelectedIndex = 0
                End If
            Finally
                m_cancelOnPageChanged = False
            End Try
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overridable Sub OnAdminDeleteClicked(ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)
            If Not (AdminDeleteClickedEvent) Is Nothing Then
                RaiseEvent AdminDeleteClicked(Me, commentItem)
            End If
        End Sub

        Protected Overridable Sub OnLoadFirstPage(ByVal page As Integer, ByVal commentItemsPanel As Sublight.Controls.CommentsControl.CommentItemsPanel)
            FillItems(page, commentItemsPanel, LoadFirstPage, Nothing)
        End Sub

        Protected Overridable Sub OnPageChanged(ByVal page As Integer, ByVal commentItemsPanel As Sublight.Controls.CommentsControl.CommentItemsPanel)
            FillItems(page, commentItemsPanel, Nothing, PageChanged)
        End Sub

        Protected Overridable Sub OnReportClicked(ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)
            If Not (ReportClickedEvent) Is Nothing Then
                RaiseEvent ReportClicked(Me, commentItem)
            End If
        End Sub

        Protected Overridable Sub OnVoteClicked(ByVal commentItem As Sublight.Controls.CommentsControl.CommentItem)
            If Not (VoteClickedEvent) Is Nothing Then
                RaiseEvent VoteClicked(Me, commentItem)
            End If
        End Sub

    End Class ' class CommentItems

End Namespace

