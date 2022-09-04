Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace Sublight

    Public NotInheritable Class LoaderForm
        Inherits System.Windows.Forms.Form

        Friend Interface ICanCancelActivation

            Property CancelActivation As Boolean

        End 

        Friend Interface ICanChangeText

            Sub SetLoaderText(ByVal text As String)

        End 

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <CancelActivation>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <ParentBaseForm>k__BackingField As Sublight.BaseForm 
        Private components As System.ComponentModel.IContainer 
        Private loaderForm As Sublight.LoaderForm2 
        Private tmrAutoHide As System.Windows.Forms.Timer 

        Private Property CancelActivation As Boolean
            Get
                Return <CancelActivation>k__BackingField
            End Get
            Set
                <CancelActivation>k__BackingField = value
            End Set
        End Property

        Public Property ParentBaseForm As Sublight.BaseForm
            Get
                Return <ParentBaseForm>k__BackingField
            End Get
            Set
                <ParentBaseForm>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal parentForm As Sublight.BaseForm)
            InitializeComponent()
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            DoubleBuffered = True
            TopMost = False
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            ParentBaseForm = parentForm
        End Sub

        Public Sub BringLoaderToFront()
            SyncLock Me
                Try
                    CancelActivation = True
                    If Not (loaderForm) Is Nothing Then
                        loaderForm.CancelActivation = True
                    End If
                    BringToFront()
                    If Not (loaderForm) Is Nothing Then
                        loaderForm.BringToFront()
                    End If
                Catch 
                Finally
                    If Not (loaderForm) Is Nothing Then
                        loaderForm.CancelActivation = False
                    End If
                    CancelActivation = False
                End Try
            End SyncLock
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            tmrAutoHide = New System.Windows.Forms.Timer(components)
            SuspendLayout()
            tmrAutoHide.Interval = 30000
            AddHandler tmrAutoHide.Tick, AddressOf tmrAutoHide_Tick
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            ClientSize = New System.Drawing.Size(284, 264)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Name = "LoaderForm?"
            Opacity = 0.5R
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Text = "LoaderForm?"
            ResumeLayout(False)
        End Sub

        Private Sub OnLoaderAnimationShown()
            If ((loaderForm) Is Nothing) OrElse loaderForm.IsDisposed Then
                Return
            End If
            loaderForm.Left = Left + (Width / 2) - (loaderForm.Width / 2)
            loaderForm.Top = Top + (Height / 2) - (loaderForm.Height / 2)
            If Not loaderForm.Visible Then
                loaderForm.Visible = True
            End If
            loaderForm.BringToFront()
        End Sub

        Public Sub PingLoader()
            tmrAutoHide.Stop()
            tmrAutoHide.Start()
        End Sub

        Public Sub SetLoaderText(ByVal text As String)
            tmrAutoHide.Stop()
            tmrAutoHide.Start()
            loaderForm.SetLoaderText(text)
        End Sub

        Private Sub tmrAutoHide_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            tmrAutoHide.Stop()
            Close()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (loaderForm) Is Nothing) Then
                loaderForm.Dispose()
                loaderForm = Nothing
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
            Try
                MyBase.OnActivated(e)
                If Not CancelActivation AndAlso (Not (ParentBaseForm) Is Nothing) Then
                    ParentBaseForm.BringToFront()
                End If
            Catch 
            End Try
        End Sub

        Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
            MyBase.OnClosed(e)
            If (Not (loaderForm) Is Nothing) AndAlso Not loaderForm.IsDisposed Then
                Try
                    loaderForm.Close()
                Catch 
                End Try
            End If
            If Not (tmrAutoHide) Is Nothing Then
                tmrAutoHide.Stop()
            End If
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            loaderForm = New Sublight.LoaderForm2(Me, New System.Windows.Forms.MethodInvoker(OnLoaderAnimationShown))
            loaderForm.Show()
            tmrAutoHide.Start()
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(3, 4, Width - 6, Height - 8))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(4, 0, Width - 8, 1))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(2, 1, Width - 4, 1))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(1, 2, Width - 2, 1))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(1, 3, Width - 2, 1))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(2, 4, 1, Height - 8))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(1, 4, 1, Height - 8))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(0, 4, 1, Height - 8))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(Width - 3, 4, 1, Height - 8))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(Width - 2, 4, 1, Height - 8))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(Width - 1, 4, 1, Height - 8))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(4, Height - 1, Width - 8, 1))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(2, Height - 2, Width - 4, 1))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(1, Height - 3, Width - 2, 1))
            graphicsPath1.AddRectangle(New System.Drawing.Rectangle(1, Height - 4, Width - 2, 1))
            Region = New System.Drawing.Region(graphicsPath1)
            graphicsPath1.Dispose()
        End Sub

    End Class ' class LoaderForm

End Namespace

