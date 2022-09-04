Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button
Imports Sublight.MyUtility.Explorer
Imports Sublight.Properties

Namespace Sublight.Controls

    Public Class SettingsSystemIntegration
        Inherits Sublight.Controls.BaseSettings

        Friend Const ShellKeyName As String  = "Sublight"

        Private _batchDownloadChanged As Boolean 
        Private _explorerExtensionChanged As Boolean 
        Private btnDeselectAll As Sublight.Controls.Button.Button 
        Private btnSelectAll As Sublight.Controls.Button.Button 
        Private cbBatchDownload As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.IContainer 
        Private lblContextMenu As System.Windows.Forms.Label 
        Private myPanel2 As Sublight.Controls.MyPanel 
        Private pictureBox2 As System.Windows.Forms.PictureBox 

        Public Overrides ReadOnly Property Title As String
            Get
                Return Sublight.Translation.Settings_Panel_ExplorerIntegration
            End Get
        End Property

        Public Sub New(ByVal parent As Sublight.BaseForm)
            InitializeComponent()
            CreateControls()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Private Sub btnDeselectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In Controls
                Dim myCheckBox1 As Sublight.Controls.MyCheckBox = TryCast(control1, Sublight.Controls.MyCheckBox)
                If Not (myCheckBox1) Is Nothing Then
                    myCheckBox1.Checked = False
                End If
            Next
        End Sub

        Private Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In Controls
                Dim myCheckBox1 As Sublight.Controls.MyCheckBox = TryCast(control1, Sublight.Controls.MyCheckBox)
                If Not (myCheckBox1) Is Nothing Then
                    myCheckBox1.Checked = True
                End If
            Next
        End Sub

        Private Sub cb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            _explorerExtensionChanged = True
        End Sub

        Private Sub cbBatchDownload_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            _batchDownloadChanged = True
        End Sub

        Private Sub CreateControls()
            If (Sublight.Globals.VideoExtensions) Is Nothing Then
                Return
            End If
            Dim i1 As Integer = lblContextMenu.Bottom
            Dim sArr1 As String() = Sublight.Globals.VideoExtensions
            Dim i2 As Integer = 0
            While i2 < sArr1.Length
                Dim s1 As String = sArr1(i2)
                Dim myCheckBox1 As Sublight.Controls.MyCheckBox = New Sublight.Controls.MyCheckBox
                myCheckBox1.Tag = s1
                myCheckBox1.AutoSize = True
                myCheckBox1.Text = System.String.Format(".{0}?", s1)
                myCheckBox1.Top = i1 + 5
                myCheckBox1.Left = 20
                AddHandler myCheckBox1.CheckedChanged, AddressOf cb_CheckedChanged
                Controls.Add(myCheckBox1)
                i1 = i1 + myCheckBox1.Height
                i2 = i2 + 1
            End While
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            MyBase.Translate()
        End Sub

        Private Sub InitializeComponent()
            myPanel2 = New Sublight.Controls.MyPanel
            pictureBox2 = New System.Windows.Forms.PictureBox
            lblContextMenu = New System.Windows.Forms.Label
            btnDeselectAll = New Sublight.Controls.Button.Button
            btnSelectAll = New Sublight.Controls.Button.Button
            cbBatchDownload = New Sublight.Controls.MyCheckBox
            myPanel2.SuspendLayout()
            pictureBox2.BeginInit()
            SuspendLayout()
            myPanel2.Controls.Add(pictureBox2)
            myPanel2.Dock = System.Windows.Forms.DockStyle.Right
            myPanel2.Location = New System.Drawing.Point(485, 0)
            myPanel2.Name = "myPanel2?"
            myPanel2.Size = New System.Drawing.Size(38, 277)
            myPanel2.TabIndex = 138
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pictureBox2.Image = Sublight.Properties.Resources.SettingsExplorer
            pictureBox2.Location = New System.Drawing.Point(0, 0)
            pictureBox2.Name = "pictureBox2?"
            pictureBox2.Size = New System.Drawing.Size(37, 39)
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            pictureBox2.TabIndex = 24
            pictureBox2.TabStop = False
            lblContextMenu.AutoSize = True
            lblContextMenu.Location = New System.Drawing.Point(3, 44)
            lblContextMenu.Name = "lblContextMenu?"
            lblContextMenu.Size = New System.Drawing.Size(261, 13)
            lblContextMenu.TabIndex = 139
            lblContextMenu.Text = "Prikaži bližnjico za prenos podnapisov v Raziskovalcu?"
            btnDeselectAll.AutoResize = False
            btnDeselectAll.BackColor = System.Drawing.Color.Transparent
            btnDeselectAll.DialogResult = System.Windows.Forms.DialogResult.None
            btnDeselectAll.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnDeselectAll.Location = New System.Drawing.Point(192, 102)
            btnDeselectAll.Name = "btnDeselectAll?"
            btnDeselectAll.Size = New System.Drawing.Size(105, 23)
            btnDeselectAll.TabIndex = 141
            btnDeselectAll.Text = "Odstrani vse?"
            btnDeselectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnDeselectAll.Click, AddressOf btnDeselectAll_Click
            btnSelectAll.AutoResize = False
            btnSelectAll.BackColor = System.Drawing.Color.Transparent
            btnSelectAll.DialogResult = System.Windows.Forms.DialogResult.None
            btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            btnSelectAll.Location = New System.Drawing.Point(192, 72)
            btnSelectAll.Name = "btnSelectAll?"
            btnSelectAll.Size = New System.Drawing.Size(105, 23)
            btnSelectAll.TabIndex = 140
            btnSelectAll.Text = "Izberi vse?"
            btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnSelectAll.Click, AddressOf btnSelectAll_Click
            cbBatchDownload.AutoSize = True
            cbBatchDownload.Location = New System.Drawing.Point(6, 13)
            cbBatchDownload.Name = "cbBatchDownload?"
            cbBatchDownload.Size = New System.Drawing.Size(167, 17)
            cbBatchDownload.TabIndex = 142
            cbBatchDownload.Text = "Omogoci ""Batch download...""?"
            cbBatchDownload.UseVisualStyleBackColor = True
            AddHandler cbBatchDownload.CheckedChanged, AddressOf cbBatchDownload_CheckedChanged
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(cbBatchDownload)
            Controls.Add(btnDeselectAll)
            Controls.Add(btnSelectAll)
            Controls.Add(lblContextMenu)
            Controls.Add(myPanel2)
            Name = "SettingsSystemIntegration?"
            Size = New System.Drawing.Size(523, 277)
            myPanel2.ResumeLayout(False)
            myPanel2.PerformLayout()
            pictureBox2.EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Function LoadSettings(ByRef error As String) As Boolean
            Dim flag1 As Boolean

            Try
                Try
                    cbBatchDownload.Checked = Sublight.MyUtility.Explorer.ContextMenu.IsRegisteredFolder("Sublight?")
                    Dim control1 As System.Windows.Forms.Control 
                    For Each control1 In Controls
                        Dim myCheckBox1 As Sublight.Controls.MyCheckBox = TryCast(control1, Sublight.Controls.MyCheckBox)
                        If Not (myCheckBox1) Is Nothing Then
                            Dim s1 As String = TryCast(myCheckBox1.Tag, string)
                            If Not System.String.IsNullOrEmpty(s1) Then
                                Try
                                    If Sublight.MyUtility.Explorer.ContextMenu.IsRegistered(System.String.Format(".{0}?", s1), "Sublight?") Then
                                        myCheckBox1.Checked = True
                                    Else 
                                        myCheckBox1.Checked = False
                                    End If
                                Catch 
                                    myCheckBox1.Checked = False
                                End Try
                            End If
                        End If
                    Next
                    error = Nothing
                    flag1 = True
                    Return flag1
                Catch e As System.Exception
                    error = e.Message
                    flag1 = False
                End Try
            Finally
                _batchDownloadChanged = False
                _explorerExtensionChanged = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub OnBeforeReset()
            Dim s1 As String

            MyBase.OnBeforeReset()
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In Controls
                Dim myCheckBox1 As Sublight.Controls.MyCheckBox = TryCast(control1, Sublight.Controls.MyCheckBox)
                If Not (myCheckBox1) Is Nothing Then
                    myCheckBox1.Checked = False
                End If
            Next
            MyBase.SaveSettings(True, out s1)
        End Sub

        Public Overrides Function SaveSettings(ByVal quietMode As Boolean, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            If Not _batchDownloadChanged AndAlso Not _explorerExtensionChanged Then
                error = Nothing
                Return True
            End If
            Try
                If (System.Diagnostics.Process.GetCurrentProcess().MainModule) Is Nothing Then
                    Throw New System.Exception("Could not get instance of MainModule.?")
                End If
                Dim s1 As String = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
                If Not (Sublight.Globals.VideoExtensions) Is Nothing Then
                    Dim sArr1 As String() = Sublight.Globals.VideoExtensions
                    Dim i1 As Integer = 0
                    While i1 < sArr1.Length
                        Dim s2 As String = sArr1(i1)
                        Try
                            Sublight.MyUtility.Explorer.ContextMenu.Unregister(System.String.Format(".{0}?", s2), "SubtitlesClient?")
                        Catch e As System.Exception
                        End Try
                        i1 = i1 + 1
                    End While
                End If
                If cbBatchDownload.Checked Then
                    Sublight.MyUtility.Explorer.ContextMenu.RegisterFolder("Sublight?", Sublight.Translation.WindowsExplorer_ContextMenu_BatchDownload, System.String.Format("""{0}"" /batch folder=""%L""?", s1))
                Else 
                    Sublight.MyUtility.Explorer.ContextMenu.UnregisterFolder("Sublight?")
                End If
                _batchDownloadChanged = False
                Dim control1 As System.Windows.Forms.Control 
                For Each control1 In Controls
                    Dim myCheckBox1 As Sublight.Controls.MyCheckBox = TryCast(control1, Sublight.Controls.MyCheckBox)
                    If Not (myCheckBox1) Is Nothing Then
                        Dim s3 As String = TryCast(myCheckBox1.Tag, string)
                        If Not System.String.IsNullOrEmpty(s3) Then
                            If myCheckBox1.Checked Then
                                Sublight.MyUtility.Explorer.ContextMenu.Register(System.String.Format(".{0}?", s3), "Sublight?", Sublight.Translation.WindowsExplorer_ContextMenu_FindSubtitles, System.String.Format("""{0}"" file=""%L""?", s1))
                                Continue
                            End If
                            Sublight.MyUtility.Explorer.ContextMenu.Unregister(System.String.Format(".{0}?", s3), "Sublight?")
                        End If
                    End If
                Next
                _explorerExtensionChanged = False
                flag1 = MyBase.LoadSettings(out error)
            Catch e As System.Exception
                If Not quietMode Then
                    Dim objArr1 As Object() = New object() { e.Message }
                    ParentBaseForm.ShowError(Sublight.Translation.MessageBox_Error_RegisteringWindowsExplorerContextMenuSimple, objArr1)
                End If
                error = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Public Overrides Sub Translate()
            MyBase.Translate()
            lblContextMenu.Text = Sublight.Translation.Settings_Panel_ExplorerIntegration_ContextMenu
            cbBatchDownload.Text = Sublight.Translation.Settings_Panel_ExplorerIntegration_BatchDownload
            btnSelectAll.Text = Sublight.Translation.Common_Button_SelectAll
            btnDeselectAll.Text = Sublight.Translation.Common_Button_RemoveAll
            Dim buttonArr1 As Sublight.Controls.Button.Button() = New Sublight.Controls.Button.Button() { _
                                                                                                          btnSelectAll, _
                                                                                                          btnDeselectAll }
            Sublight.Controls.Button.Button.MakeSameWidth(buttonArr1)
        End Sub

    End Class ' class SettingsSystemIntegration

End Namespace

