Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button
Imports Sublight.Types

Namespace Sublight

    Public Class FrmWizardSettings
        Inherits Sublight.BaseForm

        Private ReadOnly _maxSelect As Boolean 
        Private ReadOnly _parent As Sublight.FrmMain 

        Private _currentStep As Integer 
        Private _steps As System.Collections.Generic.List(Of Sublight.Controls.BaseWizard) 
        Private btnBack As Sublight.Controls.Button.Button 
        Private btnCancel As Sublight.Controls.Button.Button 
        Private btnNext As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblHeader As System.Windows.Forms.Label 
        Private lblStep As System.Windows.Forms.Label 
        Private panelBottom As Sublight.Controls.MyPanel 
        Private panelContent As Sublight.Controls.MyPanel 
        Private panelTop As Sublight.Controls.MyPanel 

        Protected ReadOnly Property CurrentStepControl As Sublight.Controls.BaseWizard
            Get
                If (_currentStep < 0) OrElse (_currentStep >= _steps.get_Count()) Then
                    Return Nothing
                End If
                Return _steps.get_Item(_currentStep)
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.FrmMain, ByVal maxSelect As Boolean)
            _parent = parent
            _maxSelect = maxSelect
            InitializeComponent()
            InitWizard()
            Translate()
        End Sub

        Private Sub AddStep(ByVal wiz As Sublight.Controls.BaseWizard)
            wiz.Dock = System.Windows.Forms.DockStyle.Fill
            _steps.Add(wiz)
            panelContent.Controls.Add(wiz)
        End Sub

        Private Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            _currentStep = _currentStep - 1
            If _currentStep < 0 Then
                _currentStep = 0
            End If
            DisplayCurrentStep()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            If (Not (CurrentStepControl) Is Nothing) AndAlso Not CurrentStepControl.IsStepValid(out s1) Then
                System.Windows.Forms.MessageBox.Show(s1, Sublight.Translation.MessageBox_Error)
                Return
            End If
            If TryCast(btnNext.Tag, string) = "Finish?" Then
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim flag1 As Boolean = False
                Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Controls.BaseWizard).Enumerator = _steps.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim baseWizard1 As Sublight.Controls.BaseWizard = enumerator1.get_Current()
                        If Not baseWizard1.Finalize(out s1) Then
                            flag1 = True
                            If System.String.IsNullOrEmpty(s1) Then
                                s1 = "NA?"
                            End If
                            Dim s2 As String = baseWizard1.GetType().Name
                            s2 = s2.Replace("WizardSettings?", System.String.Empty)
                            stringBuilder1.AppendLine(System.String.Format("{0}: {1}?", s2, s1))
                        End If
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
                If flag1 Then
                    System.Windows.Forms.MessageBox.Show(stringBuilder1.ToString(), Sublight.Translation.MessageBox_Error)
                Else 
                    SaveUserSettings()
                    Sublight.Globals.Events.OnSettingsLoaded()
                End If
                Close()
                Return
            End If
            _currentStep = _currentStep + 1
            If _currentStep >= _steps.get_Count() Then
                _currentStep = _steps.get_Count() - 1
            End If
            DisplayCurrentStep()
        End Sub

        Private Sub DisplayCurrentStep()
            Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Controls.BaseWizard).Enumerator = _steps.GetEnumerator()
            Try
                While enumerator1.MoveNext()
                    Dim baseWizard1 As Sublight.Controls.BaseWizard = enumerator1.get_Current()
                    baseWizard1.Visible = False
                End While
            Finally
                enumerator1.Dispose()
            End Try
            lblStep.Text = System.String.Format("{0}/{1}?", _currentStep + 1, _steps.get_Count())
            Dim baseWizard2 As Sublight.Controls.BaseWizard = _steps.get_Item(_currentStep)
            lblHeader.Text = baseWizard2.HeaderText
            baseWizard2.Visible = True
            If _currentStep <= 0 Then
                btnBack.Enabled = False
            Else 
                btnBack.Enabled = True
            End If
            If _currentStep >= (_steps.get_Count() - 1) Then
                btnNext.Text = Sublight.Translation.Common_Button_Finish
                btnNext.Tag = "Finish?"
                Return
            End If
            btnNext.Text = Sublight.Translation.Common_Button_Next
            btnNext.Tag = "Next?"
        End Sub

        Private Sub InitializeComponent()
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.FrmWizardSettings))
            panelContent = New Sublight.Controls.MyPanel
            panelBottom = New Sublight.Controls.MyPanel
            btnBack = New Sublight.Controls.Button.Button
            btnNext = New Sublight.Controls.Button.Button
            btnCancel = New Sublight.Controls.Button.Button
            panelTop = New Sublight.Controls.MyPanel
            lblStep = New System.Windows.Forms.Label
            lblHeader = New System.Windows.Forms.Label
            panelBottom.SuspendLayout()
            panelTop.SuspendLayout()
            SuspendLayout()
            panelContent.Dock = System.Windows.Forms.DockStyle.Fill
            panelContent.Location = New System.Drawing.Point(0, 60)
            panelContent.Name = "panelContent?"
            panelContent.Size = New System.Drawing.Size(478, 217)
            panelContent.TabIndex = 2
            panelBottom.Controls.Add(btnBack)
            panelBottom.Controls.Add(btnNext)
            panelBottom.Controls.Add(btnCancel)
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            panelBottom.Location = New System.Drawing.Point(0, 277)
            panelBottom.Name = "panelBottom?"
            panelBottom.Size = New System.Drawing.Size(478, 60)
            panelBottom.TabIndex = 1
            AddHandler panelBottom.Paint, AddressOf panelBottom_Paint
            btnBack.DialogResult = System.Windows.Forms.DialogResult.None
            btnBack.Location = New System.Drawing.Point(223, 22)
            btnBack.Name = "btnBack?"
            btnBack.Size = New System.Drawing.Size(75, 23)
            btnBack.TabIndex = 4
            btnBack.Text = "< Back?"
            btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnBack.Click, AddressOf btnBack_Click
            btnNext.DialogResult = System.Windows.Forms.DialogResult.None
            btnNext.Location = New System.Drawing.Point(304, 22)
            btnNext.Name = "btnNext?"
            btnNext.Size = New System.Drawing.Size(75, 23)
            btnNext.TabIndex = 3
            btnNext.Text = "Next >?"
            btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnNext.Click, AddressOf btnNext_Click
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            btnCancel.Location = New System.Drawing.Point(395, 22)
            btnCancel.Name = "btnCancel?"
            btnCancel.Size = New System.Drawing.Size(75, 23)
            btnCancel.TabIndex = 2
            btnCancel.Text = "Cancel?"
            btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            panelTop.BackColor = System.Drawing.Color.White
            panelTop.Controls.Add(lblStep)
            panelTop.Controls.Add(lblHeader)
            panelTop.Dock = System.Windows.Forms.DockStyle.Top
            panelTop.Location = New System.Drawing.Point(0, 0)
            panelTop.Name = "panelTop?"
            panelTop.Size = New System.Drawing.Size(478, 60)
            panelTop.TabIndex = 0
            AddHandler panelTop.Paint, AddressOf panelTop_Paint
            lblStep.Location = New System.Drawing.Point(440, 9)
            lblStep.Name = "lblStep?"
            lblStep.Size = New System.Drawing.Size(35, 23)
            lblStep.TabIndex = 1
            lblStep.Text = "1/4?"
            lblStep.TextAlign = System.Drawing.ContentAlignment.TopRight
            lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            lblHeader.Location = New System.Drawing.Point(9, 9)
            lblHeader.Name = "lblHeader?"
            lblHeader.Size = New System.Drawing.Size(425, 48)
            lblHeader.TabIndex = 0
            lblHeader.Text = "label1?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.SystemColors.Control
            ClientSize = New System.Drawing.Size(478, 337)
            ControlBox = False
            Controls.Add(panelContent)
            Controls.Add(panelBottom)
            Controls.Add(panelTop)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Icon = CType(componentResourceManager1.GetObject("$this.Icon?"), System.Drawing.Icon)
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmWizardSettings?"
            ShowIcon = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Text = "Sublight settings wizard?"
            panelBottom.ResumeLayout(False)
            panelTop.ResumeLayout(False)
            ResumeLayout(False)
        End Sub

        Private Sub InitWizard()
            _steps = New System.Collections.Generic.List(Of Sublight.Controls.BaseWizard)
            SuspendLayout()
            panelContent.SuspendLayout()
            Dim wizardSettingsLangUI1 As Sublight.Controls.WizardSettingsLangUI = New Sublight.Controls.WizardSettingsLangUI(_parent)
            AddHandler wizardSettingsLangUI1.LanguageChanged, AddressOf langUI_LanguageChanged
            AddStep(wizardSettingsLangUI1)
            AddStep(New Sublight.Controls.WizardSettingsLangSubtitle)
            AddStep(New Sublight.Controls.WizardSettingsVideoApps)
            If Sublight.Globals.EditionType = Sublight.Types.SpecialEdition.Regular Then
                AddStep(New Sublight.Controls.WizardSettingsSubtitlePlugins(_maxSelect))
            End If
            AddStep(New Sublight.Controls.WizardSettingsSystemIntegration)
            panelContent.ResumeLayout(False)
            ResumeLayout(False)
        End Sub

        Private Sub langUI_LanguageChanged(ByVal langId As String)
            Dim cultureInfo1 As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(langId)
            Sublight.Translation.Culture = cultureInfo1
            System.Windows.Forms.Application.CurrentCulture = cultureInfo1
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo1
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo1
            Translate()
        End Sub

        Private Sub panelBottom_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.FillRectangle(System.Drawing.Brushes.White, 0, 0, Width, 2)
            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Globals.ColorSeparator)
                e.Graphics.DrawLine(pen1, 0, 0, Width - 2, 0)
            End Using
        End Sub

        Private Sub panelTop_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Globals.ColorSeparator)
                e.Graphics.DrawLine(pen1, 0, panelTop.Height - 1, Width - 2, panelTop.Height - 1)
            End Using
        End Sub

        Private Sub Translate()
            btnBack.Text = Sublight.Translation.Common_Button_Back
            btnCancel.Text = Sublight.Translation.Common_Button_Cancel
            If TryCast(btnNext.Tag, string) = "Finish?" Then
                btnNext.Text = Sublight.Translation.Common_Button_Finish
            Else 
                btnNext.Text = Sublight.Translation.Common_Button_Next
            End If
            Text = Sublight.Translation.Settings_Wizard_Title
            Dim baseWizard1 As Sublight.Controls.BaseWizard = _steps.get_Item(_currentStep)
            lblHeader.Text = baseWizard1.HeaderText
            If Not (_steps) Is Nothing Then
                Dim enumerator1 As System.Collections.Generic.List(Of Sublight.Controls.BaseWizard).Enumerator = _steps.GetEnumerator()
                Try
                    While enumerator1.MoveNext()
                        Dim baseWizard2 As Sublight.Controls.BaseWizard = enumerator1.get_Current()
                        baseWizard2.Translate()
                    End While
                Finally
                    enumerator1.Dispose()
                End Try
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            DisplayCurrentStep()
        End Sub

    End Class ' class FrmWizardSettings

End Namespace

