Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button

Namespace Sublight

    Public Class FrmLanguageSelector
        Inherits Sublight.BaseForm

        Private _ctrl As Sublight.Controls.WizardSettingsLangUI 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnOK As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private container As Sublight.Controls.MyPanel 
        Private lblHeader As System.Windows.Forms.Label 
        Private niceLine1 As Sublight.Controls.NiceLine 
        Private panelTop As Sublight.Controls.MyPanel 

        Public Sub New(ByVal frmMain As Sublight.FrmMain)
            InitializeComponent()
            SetText()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            _ctrl = New Sublight.Controls.WizardSettingsLangUI(frmMain)
            _ctrl.Dock = System.Windows.Forms.DockStyle.Fill
            container.SuspendLayout()
            container.Controls.Add(_ctrl)
            container.ResumeLayout(False)
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            DialogResult = System.Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            If Not _ctrl.Finalize(out s1) Then
                ShowError(s1, New object(0) {})
                Return
            End If
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            SetText()
        End Sub

        Private Sub InitializeComponent()
            btnOK = New Sublight.Controls.Button.Button
            btnCancel = New Sublight.Controls.Button.Button
            niceLine1 = New Sublight.Controls.NiceLine
            panelTop = New Sublight.Controls.MyPanel
            lblHeader = New System.Windows.Forms.Label
            container = New Sublight.Controls.MyPanel
            panelTop.SuspendLayout()
            SuspendLayout()
            btnOK.AutoResize = False
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            btnOK.Id = "3978edd4-c65f-4fba-a9d5-14c87c48cb75?"
            btnOK.Image = Nothing
            btnOK.Location = New System.Drawing.Point(309, 301)
            btnOK.Name = "btnOK?"
            btnOK.Size = New System.Drawing.Size(75, 23)
            btnOK.TabIndex = 7
            btnOK.Text = "V redu?"
            btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnOK.UseVisualStyleBackColor = True
            AddHandler btnOK.Click, AddressOf btnOK_Click
            btnCancel.AutoResize = False
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Id = "667e0eb2-cc41-4247-83d5-8647b0af2f55?"
            btnCancel.Image = Nothing
            btnCancel.Location = New System.Drawing.Point(390, 301)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 8
            btnCancel.Text = "Preklici?"
            btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnCancel.UseVisualStyleBackColor = True
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            niceLine1.Location = New System.Drawing.Point(3, 283)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(462, 15)
            niceLine1.TabIndex = 6
            panelTop.BackColor = System.Drawing.Color.White
            panelTop.Controls.Add(lblHeader)
            panelTop.Dock = System.Windows.Forms.DockStyle.Top
            panelTop.Location = New System.Drawing.Point(0, 0)
            panelTop.Name = "panelTop?"
            panelTop.Size = New System.Drawing.Size(474, 60)
            panelTop.TabIndex = 10
            lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblHeader.Location = New System.Drawing.Point(9, 9)
            lblHeader.Name = "lblHeader?"
            lblHeader.Size = New System.Drawing.Size(425, 48)
            lblHeader.TabIndex = 0
            lblHeader.Text = "label1?"
            container.Dock = System.Windows.Forms.DockStyle.Top
            container.Location = New System.Drawing.Point(0, 60)
            container.Name = "container?"
            container.Padding = New System.Windows.Forms.Padding(5)
            container.Size = New System.Drawing.Size(474, 224)
            container.TabIndex = 11
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            ClientSize = New System.Drawing.Size(474, 333)
            Controls.Add(container)
            Controls.Add(panelTop)
            Controls.Add(btnOK)
            Controls.Add(btnCancel)
            Controls.Add(niceLine1)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmLanguageSelector?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Change language?"
            panelTop.ResumeLayout(False)
            ResumeLayout(False)
        End Sub

        Private Sub SetText()
            Text = Sublight.Translation.FrmLanguageSelector_Title
            lblHeader.Text = Sublight.Translation.FrmLanguageSelector_Header
            btnOK.Text = Sublight.Translation.Common_Button_OK
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmLanguageSelector

End Namespace

