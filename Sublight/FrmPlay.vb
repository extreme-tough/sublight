Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Properties
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmPlay
        Inherits Sublight.BaseForm

        Private ReadOnly m_videoPaths As String() 

        Private _subtitleDetails As Sublight.WS.Subtitle 
        Private btnClose As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblInfo As System.Windows.Forms.Label 
        Private m_Type As Sublight.WS.SubtitleType 
        Private pictureBox3 As System.Windows.Forms.PictureBox 

        Public Sub New(ByVal parent As System.Windows.Forms.Control, ByVal firstVideoFile As String, ByVal videoPaths As String(), ByVal firstSubtitlePath As String, ByVal subtitles As System.Collections.Generic.ICollection(Of String), ByVal subtitleDetails As Sublight.WS.Subtitle, ByVal type As Sublight.WS.SubtitleType)
            InitializeComponent()
            m_videoPaths = videoPaths
            m_Type = type
            _subtitleDetails = subtitleDetails
            If ((subtitles) Is Nothing) OrElse (subtitles.get_Count() <= 0) Then
                Close()
                Return
            End If
            SuspendLayout()
            pictureBox3.Image = New System.Drawing.Bitmap(System.Drawing.SystemIcons.Information.ToBitmap())
            Width = 613
            Dim size1 As System.Drawing.Size = ClientSize
            Dim i1 As Integer = Height - size1.Height
            Dim list1 As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)
            Using ienumerator1 As System.Collections.Generic.IEnumerator(Of String) = subtitles.GetEnumerator()
                While ienumerator1.MoveNext()
                    Dim s1 As String = ienumerator1.get_Current()
                    If System.String.Compare(s1, firstSubtitlePath, True) <> 0 Then
                        list1.Add(s1)
                    End If
                End While
            End Using
            list1.Insert(0, firstSubtitlePath)
            Dim s2 As String = (New System.IO.FileInfo(firstVideoFile)).DirectoryName
            Dim i2 As Integer = 60
            Dim i3 As Integer = 0
            While i3 < list1.get_Count()
                Dim videoPlayer1 As Sublight.Controls.VideoPlayer = New Sublight.Controls.VideoPlayer(Me, _subtitleDetails, m_Type)
                videoPlayer1.Name = System.String.Format("vp_{0}?", i3)
                videoPlayer1.Left = 20
                videoPlayer1.Width = 585
                videoPlayer1.Height = 30
                videoPlayer1.NumDisc = i3 + 1
                videoPlayer1.InitialDirectory = s2
                If i3 = 0 Then
                    Dim niceLine1 As Sublight.Controls.NiceLine = New Sublight.Controls.NiceLine
                    niceLine1.Top = i2
                    niceLine1.Left = 10
                    Dim size2 As System.Drawing.Size = ClientSize
                    niceLine1.Width = size2.Width - (2 * niceLine1.Left)
                    Controls.Add(niceLine1)
                    i2 = i2 + 15
                    videoPlayer1.VideoFile = firstVideoFile
                    btnClose.Left = videoPlayer1.Left + videoPlayer1.BtnPlayLeft
                    btnClose.Width = videoPlayer1.BtnPlayWidth
                ElseIf (Not (m_videoPaths) Is Nothing) AndAlso (m_videoPaths.Length = (subtitles.get_Count() - 1)) Then
                    videoPlayer1.VideoFile = m_videoPaths(i3 - 1)
                Else 
                    videoPlayer1.VideoFile = Nothing
                End If
                videoPlayer1.SubtitleFile = list1.get_Item(i3)
                videoPlayer1.Top = i2
                i2 = i2 + videoPlayer1.Height
                Controls.Add(videoPlayer1)
                Dim niceLine2 As Sublight.Controls.NiceLine = New Sublight.Controls.NiceLine
                niceLine2.Top = i2
                niceLine2.Left = 10
                Dim size3 As System.Drawing.Size = ClientSize
                niceLine2.Width = size3.Width - (2 * niceLine2.Left)
                Controls.Add(niceLine2)
                i2 = i2 + 15
                i3 = i3 + 1
            End While
            btnClose.Top = i2
            i2 = i2 + btnClose.Height
            i2 = i2 + 5
            Height = i2 + i1
            Left = parent.Left + (parent.Width / 2) - (Width / 2)
            Top = parent.Top + (parent.Height / 2) - (Height / 2)
            Text = Sublight.Translation.FrmPlayer_Title
            btnClose.Text = Sublight.Translation.Common_Button_Close
            lblInfo.Text = Sublight.Translation.FrmPlayer_Overview
            ResumeLayout()
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub FrmPlay_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub InitializeComponent()
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.FrmPlay))
            pictureBox3 = New System.Windows.Forms.PictureBox
            lblInfo = New System.Windows.Forms.Label
            btnClose = New Sublight.Controls.Button.Button
            pictureBox3.BeginInit()
            SuspendLayout()
            pictureBox3.Image = Sublight.Properties.Resources.SettingsPlay
            pictureBox3.Location = New System.Drawing.Point(12, 12)
            pictureBox3.Name = "pictureBox3?"
            pictureBox3.Size = New System.Drawing.Size(35, 37)
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox3.TabIndex = 130
            pictureBox3.TabStop = False
            lblInfo.Location = New System.Drawing.Point(53, 12)
            lblInfo.Name = "lblInfo?"
            lblInfo.Size = New System.Drawing.Size(514, 37)
            lblInfo.TabIndex = 132
            lblInfo.Text = "label1?"
            btnClose.DialogResult = System.Windows.Forms.DialogResult.None
            btnClose.Location = New System.Drawing.Point(422, 201)
            btnClose.Name = "btnClose?"
            btnClose.Size = New System.Drawing.Size(75, 23)
            btnClose.TabIndex = 133
            btnClose.Text = "Zapri?"
            btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnClose.Click, AddressOf btnClose_Click
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(579, 236)
            Controls.Add(btnClose)
            Controls.Add(lblInfo)
            Controls.Add(pictureBox3)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Icon = CType(componentResourceManager1.GetObject("$this.Icon?"), System.Drawing.Icon)
            KeyPreview = True
            MaximizeBox = False
            Name = "FrmPlay?"
            ShowIcon = False
            StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Text = "Predvajalnik?"
            AddHandler KeyUp, AddressOf FrmPlay_KeyUp
            pictureBox3.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmPlay

End Namespace

