Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Properties

Namespace Sublight.Controls.CommentsControl

    Public Class CommentItem
        Inherits System.Windows.Forms.UserControl

        Private Shared ReadOnly m_BackHeaderColor As System.Drawing.Color 

        Friend btnAdminDelete As System.Windows.Forms.Button 
        Friend btnReport As System.Windows.Forms.Button 
        Friend btnVote As System.Windows.Forms.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblHeader As System.Windows.Forms.Label 
        Private lblPoints As System.Windows.Forms.Label 
        Private m_AdminMode As Boolean 
        Private m_BackBrush As System.Drawing.Brush 
        Private m_BackHeaderPen As System.Drawing.Pen 
        Private m_BorderColor As System.Drawing.Color 
        Private m_BorderPen As System.Drawing.Pen 
        Private m_BorderPenOver As System.Drawing.Pen 
        Private m_CanVote As Boolean 
        Private m_ForeTextBrush As System.Drawing.Brush 
        Private m_IsClicked As Boolean 
        Private m_mouseOver As Boolean 
        Private m_Points As Integer 
        Private m_stringSize As System.Drawing.SizeF 
        Private m_Text As String 
        Private panelHeader As System.Windows.Forms.Panel 
        Private panelHeaderToolbar As System.Windows.Forms.Panel 
        Private pbIcon As System.Windows.Forms.PictureBox 

        Public Property BorderColor As System.Drawing.Color
            Get
                Return m_BorderColor
            End Get
            Set
                m_BorderColor = value
                If Not (m_BorderPen) Is Nothing Then
                    m_BorderPen.Dispose()
                    m_BorderPen = Nothing
                End If
            End Set
        End Property

        Protected ReadOnly Property BorderPen As System.Drawing.Pen
            Get
                If (m_BorderPen) Is Nothing Then
                    m_BorderPen = New System.Drawing.Pen(BorderColor, 1.0F)
                End If
                Return m_BorderPen
            End Get
        End Property

        Public Property CanDelete As Boolean
            Get
                Return m_AdminMode
            End Get
            Set
                m_AdminMode = value
                btnAdminDelete.Visible = value
                btnVote.Visible = Not value
                btnReport.Visible = Not value
            End Set
        End Property

        Public Property CanVote As Boolean
            Get
                Return m_CanVote
            End Get
            Set
                m_CanVote = value
                btnReport.Enabled = value
                btnVote.Enabled = value
            End Set
        End Property

        Public Property HeaderText As String
            Get
                Return lblHeader.Text
            End Get
            Set
                lblHeader.Text = value
            End Set
        End Property

        Public ReadOnly Property IsClicked As Boolean
            Get
                Return m_IsClicked
            End Get
        End Property

        Public Property Points As Integer
            Get
                Return m_Points
            End Get
            Set
                Dim s1 As String

                m_Points = value
                If value > 0 Then
                    s1 = "+?"
                ElseIf value < 0 Then
                    s1 = "-?"
                Else 
                    s1 = System.String.Empty
                End If
                lblPoints.Text = System.String.Format("({0}{1})?", s1, System.Math.Abs(value))
            End Set
        End Property

        Public Shadows Property Text As String
            Get
                Return m_Text
            End Get
            Set
                m_stringSize = System.Drawing.SizeF.Empty
                If Not (value) Is Nothing Then
                    m_Text = value
                Else 
                    m_Text = System.String.Empty
                End If
                Invalidate()
            End Set
        End Property

        Public Sub New()
            m_stringSize = System.Drawing.SizeF.Empty
            m_ForeTextBrush = New System.Drawing.SolidBrush(System.Drawing.SystemColors.ControlText)
            m_BackBrush = New System.Drawing.SolidBrush(System.Drawing.SystemColors.Window)
            m_BackHeaderPen = New System.Drawing.Pen(Sublight.Controls.CommentsControl.CommentItem.m_BackHeaderColor)
            m_BorderPenOver = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#3399FF?"), 1.0F)
            InitializeComponent()
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.DoubleBuffer Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
            CanVote = True
            Padding = New System.Windows.Forms.Padding(2)
            BorderColor = System.Drawing.ColorTranslator.FromHtml("#E9ECFA?")
            AddHandler panelHeader.MouseMove, AddressOf OnMouseMove
            AddHandler lblHeader.MouseMove, AddressOf OnMouseMove
            AddHandler panelHeaderToolbar.MouseMove, AddressOf OnMouseMove
            AddHandler lblPoints.MouseMove, AddressOf OnMouseMove
            AddHandler btnVote.MouseMove, AddressOf OnMouseMove
            AddHandler btnReport.MouseMove, AddressOf OnMouseMove
            AddHandler panelHeader.MouseLeave, AddressOf OnMouseLeave
            AddHandler lblHeader.MouseLeave, AddressOf OnMouseLeave
            AddHandler panelHeaderToolbar.MouseLeave, AddressOf OnMouseLeave
            AddHandler lblPoints.MouseLeave, AddressOf OnMouseLeave
            AddHandler btnVote.MouseLeave, AddressOf OnMouseLeave
            AddHandler btnReport.MouseLeave, AddressOf OnMouseLeave
            AddHandler panelHeader.Click, AddressOf OnClick
            AddHandler lblHeader.Click, AddressOf OnClick
            AddHandler lblPoints.Click, AddressOf OnClick
            AddHandler panelHeader.Paint, AddressOf panelHeader_Paint
            Points = 0
            Text = System.String.Empty
            btnReport.Tag = Me
            btnAdminDelete.Tag = Me
            btnVote.Tag = Me
        End Sub

        Shared Sub New()
            Sublight.Controls.CommentsControl.CommentItem.m_BackHeaderColor = System.Drawing.ColorTranslator.FromHtml("#E1EEFF?")
        End Sub

        Public Sub Clear()
            m_IsClicked = False
            Invalidate()
        End Sub

        Private Sub InitializeComponent()
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.Controls.CommentsControl.CommentItem))
            panelHeader = New System.Windows.Forms.Panel
            lblHeader = New System.Windows.Forms.Label
            pbIcon = New System.Windows.Forms.PictureBox
            panelHeaderToolbar = New System.Windows.Forms.Panel
            btnAdminDelete = New System.Windows.Forms.Button
            lblPoints = New System.Windows.Forms.Label
            btnVote = New System.Windows.Forms.Button
            btnReport = New System.Windows.Forms.Button
            panelHeader.SuspendLayout()
            pbIcon.BeginInit()
            panelHeaderToolbar.SuspendLayout()
            SuspendLayout()
            panelHeader.Controls.Add(lblHeader)
            panelHeader.Controls.Add(pbIcon)
            panelHeader.Controls.Add(panelHeaderToolbar)
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top
            panelHeader.Location = New System.Drawing.Point(0, 0)
            panelHeader.Name = "panelHeader?"
            panelHeader.Padding = New System.Windows.Forms.Padding(1)
            panelHeader.Size = New System.Drawing.Size(500, 22)
            panelHeader.TabIndex = 0
            lblHeader.BackColor = System.Drawing.SystemColors.Window
            lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
            lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblHeader.Location = New System.Drawing.Point(17, 1)
            lblHeader.Name = "lblHeader?"
            lblHeader.Padding = New System.Windows.Forms.Padding(1)
            lblHeader.Size = New System.Drawing.Size(373, 20)
            lblHeader.TabIndex = 3
            lblHeader.Text = "1. macofaco, 25.7.2008 10:30?"
            lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            pbIcon.Dock = System.Windows.Forms.DockStyle.Left
            pbIcon.Image = Sublight.Properties.Resources.IconComment
            pbIcon.Location = New System.Drawing.Point(1, 1)
            pbIcon.Name = "pbIcon?"
            pbIcon.Padding = New System.Windows.Forms.Padding(2, 4, 0, 0)
            pbIcon.Size = New System.Drawing.Size(16, 20)
            pbIcon.TabIndex = 2
            pbIcon.TabStop = False
            panelHeaderToolbar.Controls.Add(btnAdminDelete)
            panelHeaderToolbar.Controls.Add(lblPoints)
            panelHeaderToolbar.Controls.Add(btnVote)
            panelHeaderToolbar.Controls.Add(btnReport)
            panelHeaderToolbar.Dock = System.Windows.Forms.DockStyle.Right
            panelHeaderToolbar.Location = New System.Drawing.Point(390, 1)
            panelHeaderToolbar.Name = "panelHeaderToolbar?"
            panelHeaderToolbar.Size = New System.Drawing.Size(109, 20)
            panelHeaderToolbar.TabIndex = 0
            btnAdminDelete.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F)
            btnAdminDelete.Image = CType(componentResourceManager1.GetObject("btnAdminDelete.Image?"), System.Drawing.Image)
            btnAdminDelete.Location = New System.Drawing.Point(89, 0)
            btnAdminDelete.Name = "btnAdminDelete?"
            btnAdminDelete.Size = New System.Drawing.Size(20, 20)
            btnAdminDelete.TabIndex = 3
            btnAdminDelete.TabStop = False
            btnAdminDelete.UseVisualStyleBackColor = True
            btnAdminDelete.Visible = False
            lblPoints.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblPoints.Location = New System.Drawing.Point(3, 1)
            lblPoints.Name = "lblPoints?"
            lblPoints.Size = New System.Drawing.Size(60, 16)
            lblPoints.TabIndex = 2
            lblPoints.Text = "(+5000)?"
            lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            btnVote.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F)
            btnVote.Image = Sublight.Properties.Resources.BtnCommentVote
            btnVote.Location = New System.Drawing.Point(66, 0)
            btnVote.Name = "btnVote?"
            btnVote.Size = New System.Drawing.Size(20, 20)
            btnVote.TabIndex = 1
            btnVote.TabStop = False
            btnVote.UseVisualStyleBackColor = True
            btnReport.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F)
            btnReport.Image = Sublight.Properties.Resources.BtnCommentReport
            btnReport.Location = New System.Drawing.Point(89, 0)
            btnReport.Name = "btnReport?"
            btnReport.Size = New System.Drawing.Size(20, 20)
            btnReport.TabIndex = 0
            btnReport.TabStop = False
            btnReport.UseVisualStyleBackColor = True
            AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.SystemColors.Window
            Controls.Add(panelHeader)
            Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            Margin = New System.Windows.Forms.Padding(1, 2, 1, 0)
            Name = "CommentItem?"
            Size = New System.Drawing.Size(500, 114)
            panelHeader.ResumeLayout(False)
            pbIcon.EndInit()
            panelHeaderToolbar.ResumeLayout(False)
            ResumeLayout(False)
        End Sub

        Private Sub OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
            MyBase.OnClick(e)
            m_IsClicked = True
            panelHeader.Invalidate()
            Invalidate()
        End Sub

        Protected Sub OnMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not m_mouseOver Then
                Return
            End If
            m_mouseOver = False
            panelHeader.Invalidate()
            Invalidate()
        End Sub

        Private Sub OnMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If m_mouseOver Then
                Return
            End If
            m_mouseOver = True
            panelHeader.Invalidate()
            Invalidate()
        End Sub

        Private Sub panelHeader_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            If Not m_IsClicked Then
                e.Graphics.DrawLine(m_BackHeaderPen, panelHeader.Width - 1, 1, panelHeader.Width - 1, panelHeader.Height - 2)
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (m_BorderPenOver) Is Nothing Then
                    m_BorderPenOver.Dispose()
                    m_BorderPenOver = Nothing
                End If
                If Not (m_BorderPen) Is Nothing Then
                    m_BorderPen.Dispose()
                    m_BorderPen = Nothing
                End If
                If Not (m_ForeTextBrush) Is Nothing Then
                    m_ForeTextBrush.Dispose()
                    m_ForeTextBrush = Nothing
                End If
                If Not (m_BackHeaderPen) Is Nothing Then
                    m_BackHeaderPen.Dispose()
                    m_BackHeaderPen = Nothing
                End If
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
            OnClick(Me, e)
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            MyBase.OnMouseLeave(e)
            OnMouseLeave(Me, e)
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            OnMouseMove(Me, e)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim pen1 As System.Drawing.Pen

            MyBase.OnPaint(e)
            If m_stringSize = System.Drawing.SizeF.Empty Then
                m_stringSize = e.Graphics.MeasureString(Text, Font, Width)
                Height = panelHeader.Height + System.Convert.ToInt32(System.Math.Ceiling(CDbl(m_stringSize.Height)) + 5.0R)
            End If
            e.Graphics.FillRectangle(m_BackBrush, 0, 0, Width, panelHeader.Height)
            e.Graphics.FillRectangle(m_BackBrush, 0, panelHeader.Height, Width, Height - panelHeader.Height)
            Dim color1 As System.Drawing.Color = Sublight.Controls.CommentsControl.CommentItem.m_BackHeaderColor
            lblHeader.BackColor = color1
            panelHeaderToolbar.BackColor = color1
            pbIcon.BackColor = color1
            lblHeader.ForeColor = System.Drawing.SystemColors.ControlText
            lblPoints.ForeColor = lblHeader.ForeColor
            If m_mouseOver OrElse m_IsClicked Then
                pen1 = m_BorderPenOver
            Else 
                pen1 = BorderPen
            End If
            e.Graphics.DrawRectangle(pen1, 1, 1, Width - 2, Height - 3)
            e.Graphics.DrawString(Text, Font, m_ForeTextBrush, New System.Drawing.RectangleF(3.0F, CSng((panelHeader.Height + 3)), CSng((Width - 3)), CSng(Height)))
        End Sub

    End Class ' class CommentItem

End Namespace

