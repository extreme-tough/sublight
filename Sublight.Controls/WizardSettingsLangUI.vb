Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Properties
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class WizardSettingsLangUI
        Inherits Sublight.Controls.BaseWizard

        Public Delegate Sub LanguageChangedHandler(ByVal langId As String)

        Private ReadOnly _parent As Sublight.FrmMain 

        Private components As System.ComponentModel.IContainer 
        Private flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel 

        Public Event LanguageChanged As Sublight.Controls.WizardSettingsLangUI.LanguageChangedHandler

        Public Overrides ReadOnly Property HeaderText As String
            Get
                Return Sublight.Translation.Settings_Wizard_LanguageUI_Title
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.FrmMain)
            _parent = parent
            InitializeComponent()
            Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        End Sub

        Private Sub InitializeComponent()
            flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
            SuspendLayout()
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            flowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            flowLayoutPanel1.Name = "flowLayoutPanel1?"
            flowLayoutPanel1.Size = New System.Drawing.Size(439, 248)
            flowLayoutPanel1.TabIndex = 0
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(flowLayoutPanel1)
            Name = "WizardSettingsLangUI?"
            Size = New System.Drawing.Size(439, 248)
            ResumeLayout(False)
        End Sub

        Private Sub rbLang_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim myRadioButton1 As Sublight.Controls.MyRadioButton = TryCast(sender, Sublight.Controls.MyRadioButton)
            If (myRadioButton1) Is Nothing Then
                Return
            End If
            If Not myRadioButton1.Checked Then
                Return
            End If
            Dim languageUI1 As Sublight.Types.LanguageUI = TryCast(myRadioButton1.Tag, Sublight.Types.LanguageUI)
            If (Not (LanguageChangedEvent) Is Nothing) AndAlso (Not (languageUI1) Is Nothing) Then
                RaiseEvent LanguageChanged(languageUI1.Id)
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Function Finalize(ByRef msg As String) As Boolean
            Dim flag1 As Boolean

            Try
                Dim myRadioButton1 As Sublight.Controls.MyRadioButton 
                For Each myRadioButton1 In flowLayoutPanel1.Controls
                    If myRadioButton1.Checked Then
                        Dim languageUI1 As Sublight.Types.LanguageUI = CType(myRadioButton1.Tag, Sublight.Types.LanguageUI)
                        Dim cultureInfo1 As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(languageUI1.Id)
                        Sublight.Translation.Culture = cultureInfo1
                        System.Windows.Forms.Application.CurrentCulture = cultureInfo1
                        System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo1
                        System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo1
                        Sublight.BaseForm.UpdateAppLanguage("Sublight.Controls.WizardSettingsLanguUI.Finalize?", cultureInfo1.Name)
                        If Not (_parent) Is Nothing Then
                            _parent.SelectLanguage(languageUI1)
                        Else 
                            Sublight.Globals.Events.OnLanguageChanged(cultureInfo1.Name)
                        End If
                        msg = Nothing
                        Return True
                    End If
                Next
                Throw New System.Exception("UI language not selected.?")
            Catch e As System.Exception
                msg = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Function IsStepValid(ByRef msg As String) As Boolean
            Dim flag1 As Boolean

            msg = Nothing
            Dim myRadioButton1 As Sublight.Controls.MyRadioButton 
            For Each myRadioButton1 In flowLayoutPanel1.Controls
                If myRadioButton1.Checked Then
                    Return True
                End If
            Next
            msg = Sublight.Translation.Settings_Wizard_LanguageUI_Warning_NoLanguageSelected
            Return False
        End Function

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            Dim flag1 As Boolean = False
            Dim languageUIArr1 As Sublight.Types.LanguageUI() = Sublight.Globals.Languages
            Dim i1 As Integer = 0
            While i1 < languageUIArr1.Length
                Dim languageUI1 As Sublight.Types.LanguageUI = languageUIArr1(i1)
                Dim myRadioButton1 As Sublight.Controls.MyRadioButton = New Sublight.Controls.MyRadioButton
                myRadioButton1.AutoSize = True
                myRadioButton1.Tag = languageUI1
                myRadioButton1.Text = languageUI1.ToString()
                If System.String.Compare(Sublight.Properties.Settings.Default.AppLanguage, languageUI1.Id, True) = 0 Then
                    flag1 = True
                    myRadioButton1.Checked = True
                End If
                AddHandler myRadioButton1.CheckedChanged, AddressOf rbLang_CheckedChanged
                flowLayoutPanel1.Controls.Add(myRadioButton1)
                i1 = i1 + 1
            End While
            If Not flag1 Then
                Dim myRadioButton2 As Sublight.Controls.MyRadioButton 
                For Each myRadioButton2 In flowLayoutPanel1.Controls
                    Dim languageUI2 As Sublight.Types.LanguageUI = CType(myRadioButton2.Tag, Sublight.Types.LanguageUI)
                    If System.String.Compare(languageUI2.Id, "en-US?", True) = 0 Then
                        myRadioButton2.Checked = True
                        Exit While
                    End If
                Next
            End If
        End Sub

    End Class ' class WizardSettingsLangUI

End Namespace

