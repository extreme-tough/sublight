Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Sublight.Types

Namespace Sublight.Controls

    Public Class MyCheckedListBox
        Inherits System.Windows.Forms.UserControl
        Implements System.IDisposable

        Public Class ObjectCollection

            Private _parent As System.Windows.Forms.Control 

            Public Sub New(ByVal parent As System.Windows.Forms.Control)
                _parent = parent
            End Sub

            Public Sub Add(ByVal text As String, ByVal isChecked As Boolean)
                Dim listItem1 As Sublight.Types.ListItem = New Sublight.Types.ListItem(text, text)
                Add(listItem1, isChecked)
            End Sub

            Public Sub Add(ByVal li As Sublight.Types.ListItem, ByVal isChecked As Boolean)
                Add(li)
                If Not (_parent) Is Nothing Then
                    Dim myCheckBox1 As Sublight.Controls.MyCheckBox = New Sublight.Controls.MyCheckBox
                    myCheckBox1.Text = li.Text
                    myCheckBox1.Tag = li
                    myCheckBox1.Checked = isChecked
                    myCheckBox1.AutoSize = True
                    _parent.Controls.Add(myCheckBox1)
                End If
            End Sub

            Public Shadows Sub Add(ByVal li As Sublight.Types.ListItem)
                Add(li, False)
            End Sub

        End Class ' class ObjectCollection

        Private _items As Sublight.Controls.MyCheckedListBox.ObjectCollection 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <FormattingEnabled>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <IntegralHeight>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <SelectedIndex>k__BackingField As Integer 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <SelectedItem>k__BackingField As Object 
        Private components As System.ComponentModel.IContainer 
        Private flp As System.Windows.Forms.FlowLayoutPanel 

        Public Property FormattingEnabled As Boolean
            Get
                Return <FormattingEnabled>k__BackingField
            End Get
            Set
                <FormattingEnabled>k__BackingField = value
            End Set
        End Property

        Public Property IntegralHeight As Boolean
            Get
                Return <IntegralHeight>k__BackingField
            End Get
            Set
                <IntegralHeight>k__BackingField = value
            End Set
        End Property

        Public ReadOnly Property Items As Sublight.Controls.MyCheckedListBox.ObjectCollection
            Get
                If (_items) Is Nothing Then
                    _items = New Sublight.Controls.MyCheckedListBox.ObjectCollection(flp)
                End If
                Return _items
            End Get
        End Property

        Public Property SelectedIndex As Integer
            Get
                Return <SelectedIndex>k__BackingField
            End Get
            Set
                <SelectedIndex>k__BackingField = value
            End Set
        End Property

        Public Property SelectedItem As Object
            Get
                Return <SelectedItem>k__BackingField
            End Get
            Set
                <SelectedItem>k__BackingField = value
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Sub Dispose() Implements System.IDisposable
        End Sub

        Public Function GetItemChecked(ByVal i As Integer) As Boolean
            If flp.Controls.Count >= i Then
                Dim myCheckBox1 As Sublight.Controls.MyCheckBox = TryCast(flp.Controls(i), Sublight.Controls.MyCheckBox)
                If Not (myCheckBox1) Is Nothing Then
                    Return myCheckBox1.Checked
                End If
            End If
            Return False
        End Function

        Private Sub InitializeComponent()
            flp = New System.Windows.Forms.FlowLayoutPanel
            SuspendLayout()
            flp.AutoScroll = True
            flp.BackColor = System.Drawing.SystemColors.Window
            flp.Dock = System.Windows.Forms.DockStyle.Fill
            flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            flp.Location = New System.Drawing.Point(3, 0)
            flp.Name = "flp?"
            flp.Size = New System.Drawing.Size(370, 146)
            flp.TabIndex = 0
            flp.WrapContents = False
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.SystemColors.Window
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Controls.Add(flp)
            Name = "MyCheckedListBox?"
            Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
            Size = New System.Drawing.Size(373, 146)
            ResumeLayout(False)
        End Sub

        Public Sub SetItemChecked(ByVal i As Integer, ByVal isChecked As Boolean)
            If flp.Controls.Count >= i Then
                Dim myCheckBox1 As Sublight.Controls.MyCheckBox = TryCast(flp.Controls(i), Sublight.Controls.MyCheckBox)
                If Not (myCheckBox1) Is Nothing Then
                    myCheckBox1.Checked = isChecked
                End If
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class MyCheckedListBox

End Namespace

