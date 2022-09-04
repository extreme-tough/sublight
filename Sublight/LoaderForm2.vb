Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace Sublight

    Public NotInheritable Class LoaderForm2
        Inherits System.Windows.Forms.Form
        Implements Sublight.LoaderForm.ICanCancelActivation, Sublight.LoaderForm.ICanChangeText

        Private Const _penWidth As Integer  = 20
        Private Const m_paddingBottom As Integer  = 11
        Private Const m_paddingLeft As Integer  = 9
        Private Const m_paddingTop As Integer  = 11

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <CancelActivation>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <ParentLoaderForm>k__BackingField As Sublight.LoaderForm 
        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private m_BorderPen As System.Drawing.Pen 
        Private m_onShown As System.Windows.Forms.MethodInvoker 

        Private ReadOnly Property BorderPen As System.Drawing.Pen
            Get
                If (m_BorderPen) Is Nothing Then
                    m_BorderPen = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#99B4D1?"), 20.0F)
                End If
                Return m_BorderPen
            End Get
        End Property

        Public Property CancelActivation As Boolean
            Get
                Return <CancelActivation>k__BackingField
            End Get
            Set
                <CancelActivation>k__BackingField = value
            End Set
        End Property

        Public Property ParentLoaderForm As Sublight.LoaderForm
            Get
                Return <ParentLoaderForm>k__BackingField
            End Get
            Set
                <ParentLoaderForm>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal parentForm As Sublight.LoaderForm, ByVal onShown As System.Windows.Forms.MethodInvoker)
            Dim f1 As Single

            InitializeComponent()
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Dim sizeF1 As System.Drawing.SizeF = AutoScaleDimensions
            If sizeF1.Width > 0.0F Then
                Dim sizeF2 As System.Drawing.SizeF = AutoScaleDimensions
                f1 = 96.0F / sizeF2.Width
            Else 
                f1 = 1.0F
            End If
            label1.Font.Dispose()
            label1.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.75F * f1, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            DoubleBuffered = True
            TopMost = False
            ParentLoaderForm = parentForm
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            m_onShown = onShown
            Width = 0
            Height = 0
            Visible = False
            Left = -100
            Top = -100
        End Sub

        Private Sub InitializeComponent()
            label1 = New System.Windows.Forms.Label
            SuspendLayout()
            label1.AutoSize = True
            label1.Font = New System.Drawing.Font("Microsoft Sans Serif?", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            label1.Location = New System.Drawing.Point(82, 58)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(134, 17)
            label1.TabIndex = 0
            label1.Text = "Prosimo pocakajte...?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(284, 264)
            Controls.Add(label1)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Name = "LoaderForm2?"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Text = "LoaderForm2?"
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Public Sub SetLoaderText(ByVal text As String)
            label1.Text = text
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (m_BorderPen) Is Nothing) Then
                m_BorderPen.Dispose()
                m_BorderPen = Nothing
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
            Try
                MyBase.OnActivated(e)
                If Not CancelActivation AndAlso (Not (ParentLoaderForm) Is Nothing) AndAlso (Not (ParentLoaderForm.ParentBaseForm) Is Nothing) Then
                    ParentLoaderForm.ParentBaseForm.BringToFront()
                End If
            Catch 
            End Try
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.DrawRectangle(BorderPen, 0, 0, Width - 1, Height - 1)
        End Sub

        Protected Overrides Sub OnShown(ByVal e As System.EventArgs)
            MyBase.OnShown(e)
            label1.Text = Sublight.Translation.Common_Status_Loading
            Width = label1.Width + 18 + 20
            Height = label1.Height + 22 + 20
            label1.Left = 19
            label1.Top = 21
            If Not (m_onShown) Is Nothing Then
                m_onShown.Invoke()
                m_onShown = Nothing
            End If
        End Sub

    End Class ' class LoaderForm2

End Namespace

