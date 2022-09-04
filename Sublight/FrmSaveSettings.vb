Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.Controls.Button

Namespace Sublight

    Public NotInheritable Class FrmSaveSettings
        Inherits Sublight.BaseForm

        Public Class ListElement

            Private m_Description As String 
            Private m_IsError As Boolean 
            Private m_Type As String 

            Public ReadOnly Property Description As String
                Get
                    Return m_Description
                End Get
            End Property

            Public ReadOnly Property IsError As Boolean
                Get
                    Return m_IsError
                End Get
            End Property

            Public ReadOnly Property Type As String
                Get
                    Return m_Type
                End Get
            End Property

            Public Sub New(ByVal type As String, ByVal description As String, ByVal isError As Boolean)
                m_Type = type
                m_Description = description
                m_IsError = isError
            End Sub

        End Class ' class ListElement

        Private ReadOnly m_Elements As Sublight.FrmSaveSettings.ListElement() 

        Private btnClose As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private imageList1 As System.Windows.Forms.ImageList 
        Private lvResult As System.Windows.Forms.ListView 
        Private niceLine1 As Sublight.Controls.NiceLine 

        Public Sub New(ByVal elements As Sublight.FrmSaveSettings.ListElement())
            InitializeComponent()
            m_Elements = elements
            lvResult.Columns.Add("Icon?", System.String.Empty)
            lvResult.Columns.Add("Description?", Sublight.Translation.FrmSaveSettings_Column_Description)
            lvResult.Columns.Add("Status?", Sublight.Translation.FrmSaveSettings_Column_Status)
            btnClose.Text = Sublight.Translation.Common_Button_Close
            Text = Sublight.Translation.FrmSaveSettings_Title
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub FrmSaveSettings_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                Close()
            End If
        End Sub

        Private Sub FrmSaveSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not (m_Elements) Is Nothing Then
                Dim listElementArr1 As Sublight.FrmSaveSettings.ListElement() = m_Elements
                Dim i1 As Integer = 0
                While i1 < listElementArr1.Length
                    Dim listElement1 As Sublight.FrmSaveSettings.ListElement = listElementArr1(i1)
                    Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
                    listViewItem1.SubItems.Add(listElement1.Type)
                    listViewItem1.SubItems.Add(listElement1.Description)
                    listViewItem1.ImageIndex = IIf(listElement1.IsError, 1, 0)
                    lvResult.Items.Add(listViewItem1)
                    i1 = i1 + 1
                End While
            End If
            lvResult.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent)
            lvResult.Columns(0).Width = 25
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.FrmSaveSettings))
            btnClose = New Sublight.Controls.Button.Button
            niceLine1 = New Sublight.Controls.NiceLine
            lvResult = New System.Windows.Forms.ListView
            imageList1 = New System.Windows.Forms.ImageList(components)
            SuspendLayout()
            btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
            btnClose.Location = New System.Drawing.Point(368, 210)
            btnClose.Name = "btnClose?"
            btnClose.Size = New System.Drawing.Size(75, 23)
            btnClose.TabIndex = 6
            btnClose.Text = "Zapri?"
            btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnClose.Click, AddressOf btnClose_Click
            niceLine1.Location = New System.Drawing.Point(12, 192)
            niceLine1.Name = "niceLine1?"
            niceLine1.Size = New System.Drawing.Size(431, 15)
            niceLine1.TabIndex = 5
            lvResult.FullRowSelect = True
            lvResult.GridLines = True
            lvResult.Location = New System.Drawing.Point(12, 12)
            lvResult.MultiSelect = False
            lvResult.Name = "lvResult?"
            lvResult.ShowItemToolTips = True
            lvResult.Size = New System.Drawing.Size(431, 174)
            lvResult.SmallImageList = imageList1
            lvResult.TabIndex = 7
            lvResult.UseCompatibleStateImageBehavior = False
            lvResult.View = System.Windows.Forms.View.Details
            imageList1.ImageStream = CType(componentResourceManager1.GetObject("imageList1.ImageStream?"), System.Windows.Forms.ImageListStreamer)
            imageList1.TransparentColor = System.Drawing.Color.Transparent
            imageList1.Images.SetKeyName(0, "IconSuccessSmall.gif?")
            imageList1.Images.SetKeyName(1, "IconWarningSmall.gif?")
            AcceptButton = btnClose
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            CancelButton = btnClose
            ClientSize = New System.Drawing.Size(455, 246)
            Controls.Add(lvResult)
            Controls.Add(btnClose)
            Controls.Add(niceLine1)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            KeyPreview = True
            MaximizeBox = False
            MinimizeBox = False
            Name = "FrmSaveSettings?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Napaka pri shranjevanju?"
            AddHandler Load, AddressOf FrmSaveSettings_Load
            AddHandler KeyUp, AddressOf FrmSaveSettings_KeyUp
            ResumeLayout(False)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmSaveSettings

End Namespace

