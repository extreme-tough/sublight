Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Properties
Imports Sublight.WS

Namespace Sublight.Controls

    Public Class VideoPlayer
        Inherits System.Windows.Forms.UserControl

        Private ReadOnly m_Parent As Sublight.BaseForm 

        Private _subtitleDetails As Sublight.WS.Subtitle 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <InitialDirectory>k__BackingField As String 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <SubtitleFile>k__BackingField As String 
        Private btnPlay As Sublight.Controls.Button.Button 
        Private btnSelectFile As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblDiscNum As System.Windows.Forms.Label 
        Private m_NumDisc As Integer 
        Private m_Type As Sublight.WS.SubtitleType 
        Private openFileDialog As System.Windows.Forms.OpenFileDialog 
        Private pictureBox1 As System.Windows.Forms.PictureBox 
        Private txtVideoFile As Sublight.Controls.PromptedTextBox 

        Public ReadOnly Property BtnPlayLeft As Integer
            Get
                Return btnPlay.Left
            End Get
        End Property

        Public ReadOnly Property BtnPlayWidth As Integer
            Get
                Return btnPlay.Width
            End Get
        End Property

        Public Property InitialDirectory As String
            Get
                Return <InitialDirectory>k__BackingField
            End Get
            Set
                <InitialDirectory>k__BackingField = value
            End Set
        End Property

        Public Property NumDisc As Integer
            Get
                Return m_NumDisc
            End Get
            Set
                m_NumDisc = value
                lblDiscNum.Text = System.String.Format(Sublight.Translation.Ctrl_VideoPlayer_DiscN, value)
                txtVideoFile.PromptText = System.String.Format(Sublight.Translation.Ctrl_VideoPlayer_VideoFile_CueBanner, value)
            End Set
        End Property

        Public Property SubtitleFile As String
            Get
                Return <SubtitleFile>k__BackingField
            End Get
            Set
                <SubtitleFile>k__BackingField = value
            End Set
        End Property

        Public Property VideoFile As String
            Get
                Return txtVideoFile.Text
            End Get
            Set
                txtVideoFile.Text = value
                EnableDisablePlay()
                If txtVideoFile.Text.Length > 0 Then
                    txtVideoFile.SelectionStart = txtVideoFile.Text.Length - 1
                End If
            End Set
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal subtitleDetails As Sublight.WS.Subtitle, ByVal type As Sublight.WS.SubtitleType)
            InitializeComponent()
            m_Parent = parent
            btnSelectFile.Text = Sublight.Translation.Common_Button_ChooseFile
            btnPlay.Text = Sublight.Translation.Ctrl_VideoPlayer_Button_Play
            m_Type = type
            _subtitleDetails = subtitleDetails
        End Sub

        Private Sub btnPlay_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            If Not Sublight.MyUtility.VideoApp.Play(VideoFile, SubtitleFile, m_Type, NumDisc = 1, _subtitleDetails, True, out s1) AndAlso (Not (m_Parent) Is Nothing) Then
                m_Parent.ShowError(s1, New object(0) {})
            End If
        End Sub

        Private Sub btnSelectFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            openFileDialog.Title = Sublight.Translation.Dialog_OpenVideo_Title
            openFileDialog.Filter = Sublight.Globals.OpenVideo_Filter
            openFileDialog.InitialDirectory = InitialDirectory
            If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                txtVideoFile.Text = openFileDialog.FileName
                EnableDisablePlay()
            End If
        End Sub

        Private Sub EnableDisablePlay()
            Try
                If System.String.IsNullOrEmpty(txtVideoFile.Text) Then
                    btnPlay.Enabled = False
                    Return
                End If
                If System.IO.File.Exists(txtVideoFile.Text) Then
                    btnPlay.Enabled = True
                Else 
                    btnPlay.Enabled = False
                End If
            Catch 
                btnPlay.Enabled = False
            End Try
        End Sub

        Private Sub InitializeComponent()
            lblDiscNum = New System.Windows.Forms.Label
            openFileDialog = New System.Windows.Forms.OpenFileDialog
            txtVideoFile = New Sublight.Controls.PromptedTextBox
            pictureBox1 = New System.Windows.Forms.PictureBox
            btnPlay = New Sublight.Controls.Button.Button
            btnSelectFile = New Sublight.Controls.Button.Button
            pictureBox1.BeginInit()
            SuspendLayout()
            lblDiscNum.AutoSize = True
            lblDiscNum.Location = New System.Drawing.Point(40, 7)
            lblDiscNum.Name = "lblDiscNum?"
            lblDiscNum.Size = New System.Drawing.Size(40, 13)
            lblDiscNum.TabIndex = 139
            lblDiscNum.Text = "Disk 1:?"
            txtVideoFile.Location = New System.Drawing.Point(95, 3)
            txtVideoFile.Name = "txtVideoFile?"
            txtVideoFile.PromptText = "?"
            txtVideoFile.Size = New System.Drawing.Size(276, 20)
            txtVideoFile.TabIndex = 136
            pictureBox1.Image = Sublight.Properties.Resources.Disc
            pictureBox1.Location = New System.Drawing.Point(3, 0)
            pictureBox1.Name = "pictureBox1?"
            pictureBox1.Size = New System.Drawing.Size(31, 31)
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox1.TabIndex = 141
            pictureBox1.TabStop = False
            btnPlay.DialogResult = System.Windows.Forms.DialogResult.None
            btnPlay.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            btnPlay.Image = Sublight.Properties.Resources.ToolbarPlay
            btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnPlay.Location = New System.Drawing.Point(480, 2)
            btnPlay.Name = "btnPlay?"
            btnPlay.Size = New System.Drawing.Size(97, 23)
            btnPlay.TabIndex = 140
            btnPlay.Text = "Predvajaj?"
            btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnPlay.Click, AddressOf btnPlay_Click
            btnSelectFile.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelectFile.Image = Sublight.Properties.Resources.ToolbarExplorer
            btnSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnSelectFile.Location = New System.Drawing.Point(377, 2)
            btnSelectFile.Name = "btnSelectFile?"
            btnSelectFile.Size = New System.Drawing.Size(97, 23)
            btnSelectFile.TabIndex = 137
            btnSelectFile.Text = "Izberi...?"
            btnSelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelectFile.Click, AddressOf btnSelectFile_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(pictureBox1)
            Controls.Add(btnPlay)
            Controls.Add(lblDiscNum)
            Controls.Add(btnSelectFile)
            Controls.Add(txtVideoFile)
            Name = "VideoPlayer?"
            Size = New System.Drawing.Size(585, 30)
            AddHandler Load, AddressOf VideoPlayer_Load
            pictureBox1.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub VideoPlayer_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            btnPlay.Select()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class VideoPlayer

End Namespace

