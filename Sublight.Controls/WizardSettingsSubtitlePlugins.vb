Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Plugins.SubtitleProvider
Imports Sublight.Properties

Namespace Sublight.Controls

    Public Class WizardSettingsSubtitlePlugins
        Inherits Sublight.Controls.BaseWizard

        Private ReadOnly _maxSelect As Boolean 

        Private _cbPrimaryDb As Sublight.Controls.MyCheckBox 
        Private components As System.ComponentModel.IContainer 
        Private flp As System.Windows.Forms.FlowLayoutPanel 

        Public Overrides ReadOnly Property HeaderText As String
            Get
                Return Sublight.Translation.Settings_Wizard_SubtitlePlugins_Title
            End Get
        End Property

        Public Sub New(ByVal maxSelect As Boolean)
            _maxSelect = maxSelect
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
            flp.Size = New System.Drawing.Size(466, 150)
            flp.TabIndex = 11
            flp.WrapContents = False
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(flp)
            Name = "WizardSettingsSubtitlePlugins?"
            Size = New System.Drawing.Size(466, 150)
            ResumeLayout(False)
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
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim i1 As Integer = 0
                While i1 < flp.Controls.Count
                    Dim myCheckBox1 As Sublight.Controls.MyCheckBox = TryCast(flp.Controls(i1), Sublight.Controls.MyCheckBox)
                    If (Not (myCheckBox1) Is Nothing) AndAlso myCheckBox1.Checked Then
                        Dim type1 As System.Type = TryCast(myCheckBox1.Tag, System.Type)
                        If Not (type1) Is Nothing Then
                            stringBuilder1.AppendFormat("{0}; ?", type1.Name)
                        End If
                    End If
                    i1 = i1 + 1
                End While
                Sublight.Properties.Settings.Default.Plugins_SubtitleProviderOrder = stringBuilder1.ToString().Trim()
                msg = Nothing
                flag1 = True
            Catch e As System.Exception
                msg = e.Message
                flag1 = False
            End Try
            Return flag1
        End Function

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            _cbPrimaryDb = New Sublight.Controls.MyCheckBox
            _cbPrimaryDb.Name = "cbPrimaryDb?"
            _cbPrimaryDb.Enabled = False
            _cbPrimaryDb.Checked = True
            _cbPrimaryDb.AutoSize = True
            _cbPrimaryDb.Text = Sublight.Translation.FrmSubtitleProviderSelector_Plugin_PrimaryDatabase
            flp.Controls.Add(_cbPrimaryDb)
            Dim typeArr1 As System.Type() = Sublight.Plugins.SubtitleProvider.PluginManager.GetPlugins(Sublight.Properties.Settings.Default.PluginDir, Sublight.Properties.Settings.Default.Plugins_SubtitleProviderOrder)
            Dim typeArr2 As System.Type() = Sublight.Plugins.SubtitleProvider.PluginManager.GetAllPlugins(Sublight.Properties.Settings.Default.PluginDir)
            If Not (typeArr2) Is Nothing Then
                Dim typeArr3 As System.Type() = typeArr2
                Dim i1 As Integer = 0
                While i1 < typeArr3.Length
                    Dim type1 As System.Type = typeArr3(i1)
                    Dim isubtitleProvider1 As Sublight.Plugins.SubtitleProvider.ISubtitleProvider = Sublight.Plugins.SubtitleProvider.PluginManager.CreateInstance(Sublight.Properties.Settings.Default.PluginDir, type1.Name)
                    If Not (isubtitleProvider1) Is Nothing Then
                        Dim myCheckBox1 As Sublight.Controls.MyCheckBox = New Sublight.Controls.MyCheckBox
                        myCheckBox1.Name = type1.Name
                        myCheckBox1.Tag = type1
                        myCheckBox1.Text = System.String.Format("{0} ({1})?", isubtitleProvider1.ShortName, isubtitleProvider1.Info)
                        myCheckBox1.AutoSize = True
                        If _maxSelect Then
                            myCheckBox1.Checked = True
                        Else 
                            Dim flag1 As Boolean = False
                            If Not (typeArr1) Is Nothing Then
                                Dim typeArr4 As System.Type() = typeArr1
                                Dim i2 As Integer = 0
                                While i2 < typeArr4.Length
                                    Dim type2 As System.Type = typeArr4(i2)
                                    If type2 = type1 Then
                                        flag1 = True
                                        Exit While
                                    End If
                                    i2 = i2 + 1
                                End While
                            End If
                            myCheckBox1.Checked = flag1
                        End If
                        flp.Controls.Add(myCheckBox1)
                    End If
                    i1 = i1 + 1
                End While
            End If
        End Sub

        Public Overrides Sub Translate()
            MyBase.Translate()
            If Not (_cbPrimaryDb) Is Nothing Then
                _cbPrimaryDb.Text = Sublight.Translation.FrmSubtitleProviderSelector_Plugin_PrimaryDatabase
            End If
        End Sub

    End Class ' class WizardSettingsSubtitlePlugins

End Namespace

