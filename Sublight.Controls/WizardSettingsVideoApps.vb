Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.MyUtility
Imports Sublight.Properties

Namespace Sublight.Controls

    Public Class WizardSettingsVideoApps
        Inherits Sublight.Controls.BaseWizard

        Private _rbNone As Sublight.Controls.MyRadioButton 
        Private components As System.ComponentModel.IContainer 
        Private flp As System.Windows.Forms.FlowLayoutPanel 

        Public Overrides ReadOnly Property HeaderText As String
            Get
                Return Sublight.Translation.Settings_Wizard_VideoApp_Title
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        End Sub

        Private Sub InitializeComponent()
            flp = New System.Windows.Forms.FlowLayoutPanel
            SuspendLayout()
            flp.AutoScroll = True
            flp.BackColor = System.Drawing.SystemColors.Control
            flp.Dock = System.Windows.Forms.DockStyle.Fill
            flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            flp.Location = New System.Drawing.Point(0, 0)
            flp.Name = "flp?"
            flp.Size = New System.Drawing.Size(431, 198)
            flp.TabIndex = 10
            flp.WrapContents = False
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(flp)
            Name = "WizardSettingsVideoApps?"
            Size = New System.Drawing.Size(431, 198)
            ResumeLayout(False)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Function Finalize(ByRef msg As String) As Boolean
            Dim flag2 As Boolean

            Try
                Dim flag1 As Boolean = False
                Dim myRadioButton1 As Sublight.Controls.MyRadioButton 
                For Each myRadioButton1 In flp.Controls
                    Dim s1 As String = TryCast(myRadioButton1.Tag, string)
                    If Not System.String.IsNullOrEmpty(s1) AndAlso myRadioButton1.Checked Then
                        flag1 = True
                        Sublight.Properties.Settings.Default.VideoApp = s1
                        Sublight.Properties.Settings.Default.VideoApp_Params = Sublight.MyUtility.VideoApp.GetParameters(s1)
                        Exit While
                    End If
                Next
                If Not flag1 Then
                    Sublight.Properties.Settings.Default.VideoApp = System.String.Empty
                    Sublight.Properties.Settings.Default.VideoApp_Params = System.String.Empty
                End If
                msg = Nothing
                flag2 = True
            Catch e As System.Exception
                msg = e.Message
                flag2 = False
            End Try
            Return flag2
        End Function

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            _rbNone = New Sublight.Controls.MyRadioButton
            _rbNone.AutoSize = True
            _rbNone.Text = Sublight.Translation.Settings_Wizard_VideoApp_None
            flp.Controls.Add(_rbNone)
            Dim sArr1 As String() = Sublight.MyUtility.VideoApp.GetDetectedApps()
            If Not (sArr1) Is Nothing Then
                Dim sArr2 As String() = sArr1
                Dim i1 As Integer = 0
                While i1 < sArr2.Length
                    Dim s1 As String = sArr2(i1)
                    Dim myRadioButton1 As Sublight.Controls.MyRadioButton = New Sublight.Controls.MyRadioButton
                    myRadioButton1.Name = System.String.Format("rb_{0}?", s1)
                    myRadioButton1.Checked = False
                    myRadioButton1.Text = Sublight.MyUtility.VideoApp.GetName(s1)
                    myRadioButton1.Tag = s1
                    myRadioButton1.AutoSize = True
                    flp.Controls.Add(myRadioButton1)
                    i1 = i1 + 1
                End While
            End If
            Dim flag1 As Boolean = False
            Dim myRadioButton2 As Sublight.Controls.MyRadioButton 
            For Each myRadioButton2 In flp.Controls
                Dim s2 As String = TryCast(myRadioButton2.Tag, string)
                If System.String.Compare(s2, Sublight.Properties.Settings.Default.VideoApp, True) = 0 Then
                    flag1 = True
                    myRadioButton2.Checked = True
                    Exit While
                End If
            Next
            If Not flag1 Then
                _rbNone.Checked = True
            End If
        End Sub

        Public Overrides Sub Translate()
            MyBase.Translate()
            If Not (_rbNone) Is Nothing Then
                _rbNone.Text = Sublight.Translation.Settings_Wizard_VideoApp_None
            End If
        End Sub

    End Class ' class WizardSettingsVideoApps

End Namespace

