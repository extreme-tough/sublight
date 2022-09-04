Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight

    Public NotInheritable Class FrmAddRelease
        Inherits Sublight.BaseForm

        Private ReadOnly m_subtitleId As System.Guid 

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <Status>k__BackingField As Boolean 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private cbPublishFPS As Sublight.Controls.MyComboBox 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private label13 As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private txtRelease As Sublight.Controls.MyTextBox 

        Public ReadOnly Property Release As Sublight.WS.Release
            Get
                Dim release1 As Sublight.WS.Release = New Sublight.WS.Release
                release1.Name = txtRelease.Text
                Dim listItem1 As Sublight.Types.ListItem = TryCast(cbPublishFPS.SelectedItem, Sublight.Types.ListItem)
                If (Not (listItem1) Is Nothing) AndAlso Not Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                    release1.FPS = DirectCast(listItem1.Value, Sublight.WS.FPS)
                End If
                Return release1
            End Get
        End Property

        Public Property Status As Boolean
            Get
                Return <Status>k__BackingField
            End Get
            Set
                <Status>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal subtitleId As System.Guid)
            InitializeComponent()
            FillFPS()
            m_subtitleId = subtitleId
            Text = Sublight.Translation.AddRelease_Title
            btnOK.Text = Sublight.Translation.Common_Button_OK
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            label1.Text = Sublight.Translation.AddRelease_Release
            label13.Text = Sublight.Translation.AddRelease_FPS
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String = txtRelease.Text.Trim()
            If s1.EndsWith(".avi?") Then
                s1 = s1.Substring(0, s1.Length - 4)
            End If
            If System.String.IsNullOrEmpty(s1) Then
                ShowWarning(Sublight.Translation.AddRelease_Warning_NoReleaseInfo, New object(0) {})
                Return
            End If
            Dim listItem1 As Sublight.Types.ListItem = TryCast(cbPublishFPS.SelectedItem, Sublight.Types.ListItem)
            If ((listItem1) Is Nothing) OrElse Sublight.Types.ListItem.IsNotSelected(listItem1) Then
                ShowWarning(Sublight.Translation.AddRelease_Warning_NoFPS, New object(0) {})
                Return
            End If
            Status = AddRelease(Me, m_subtitleId, s1, DirectCast(listItem1.Value, Sublight.WS.FPS))
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub FillFPS()
            cbPublishFPS.Items.Clear()
            Dim fpsArr1 As Sublight.WS.FPS() = TryCast(System.Enum.GetValues(GetType(Sublight.WS.FPS)), Sublight.WS.FPS[])
            If (fpsArr1) Is Nothing Then
                Return
            End If
            Dim fpsArr2 As Sublight.WS.FPS() = fpsArr1
            Dim i1 As Integer = 0
            While i1 < fpsArr2.Length
                Dim fps1 As Sublight.WS.FPS = CType(fpsArr2(i1), Sublight.WS.FPS)
                If fps1 <> Sublight.WS.FPS.NotSet Then
                    cbPublishFPS.Items.Add(New Sublight.Types.ListItem(Sublight.Globals.GetString(System.String.Format("FPS_{0}?", System.Enum.GetName(GetType(Sublight.WS.FPS), fps1))), fps1))
                End If
                i1 = i1 + 1
            End While
            Sublight.Globals.BindNotSelected(cbPublishFPS, True)
        End Sub

        Private Sub FrmAddRelease_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub FrmAddRelease_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            txtRelease.Select()
        End Sub

        Private Sub InitializeComponent()
            btnCancel = New Sublight.Controls.Button.Button
            btnOK = New Sublight.Controls.Button.Button
            txtRelease = New Sublight.Controls.MyTextBox
            label1 = New System.Windows.Forms.Label
            cbPublishFPS = New Sublight.Controls.MyComboBox
            label13 = New System.Windows.Forms.Label
            niceLine1 = New Sublight.Controls.NiceLine
            SuspendLayout()
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(277, 80)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 7
            btnCancel.Text = "Preklici?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            btnOK.DialogResult = System.Windows.Forms.DialogResult.None
            btnOK.Location = New System.Drawing.Point(196, 80)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 6
            btnOK.Text = "V redu?"
            btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnOK.Click, AddressOf btnOK_Click
            txtRelease.Location = New System.Drawing.Point(76, 9)
            txtRelease.Name = "txtRelease?"
            txtRelease.Size = New System.Drawing.Size(276, 20)
            txtRelease.TabIndex = 132
            label1.Location = New System.Drawing.Point(12, 9)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(58, 21)
            label1.TabIndex = 134
            label1.Text = "Razlicica:?"
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            cbPublishFPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cbPublishFPS.FormattingEnabled = True
            cbPublishFPS.Location = New System.Drawing.Point(76, 35)
            cbPublishFPS.Name = "cbPublishFPS?"
            cbPublishFPS.Size = New System.Drawing.Size(276, 21)
            cbPublishFPS.TabIndex = 131
            label13.Location = New System.Drawing.Point(12, 35)
            label13.Name = "label13?"
            label13.Size = New System.Drawing.Size(58, 21)
            label13.TabIndex = 133
            label13.Text = "FPS:?"
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            niceLine1.Location = New System.Drawing.Point(12, 62)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(340, 15)
            niceLine1.TabIndex = 135
            AcceptButton = btnOK
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            CancelButton = btnCancel
            ClientSize = New System.Drawing.Size(367, 117)
            Controls.Add(niceLine1)
            Controls.Add(txtRelease)
            Controls.Add(label1)
            Controls.Add(cbPublishFPS)
            Controls.Add(label13)
            Controls.Add(btnCancel)
            Controls.Add(btnOK)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            KeyPreview = True
            Name = "FrmAddRelease?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Dodajanje razlicice?"
            AddHandler Load, AddressOf FrmAddRelease_Load
            AddHandler KeyUp, AddressOf FrmAddRelease_KeyUp
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmAddRelease

End Namespace

