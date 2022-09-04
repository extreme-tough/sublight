Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Sublight

    Public NotInheritable Class FrmBrowser
        Inherits Sublight.BaseForm

        Private components As System.ComponentModel.IContainer 
        Private webBrowser1 As System.Windows.Forms.WebBrowser 

        Public Sub New(ByVal url As String)
            InitializeComponent()
            Text = System.String.Format("Sublight (IMDb): {0}?", url)
            AddHandler webBrowser1.Navigated, AddressOf webBrowser1_Navigated
            webBrowser1.Navigate(url)
        End Sub

        Private Sub InitializeComponent()
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.FrmBrowser))
            webBrowser1 = New System.Windows.Forms.WebBrowser
            SuspendLayout()
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
            webBrowser1.Location = New System.Drawing.Point(0, 0)
            webBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
            webBrowser1.Name = "webBrowser1?"
            webBrowser1.Size = New System.Drawing.Size(934, 664)
            webBrowser1.TabIndex = 1
            AddHandler webBrowser1.NewWindow, AddressOf webBrowser1_NewWindow
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            ClientSize = New System.Drawing.Size(934, 664)
            Controls.Add(webBrowser1)
            Icon = CType(componentResourceManager1.GetObject("$this.Icon?"), System.Drawing.Icon)
            Name = "FrmBrowser?"
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "FrmBrowser?"
            Controls.SetChildIndex(webBrowser1, 0)
            ResumeLayout(False)
        End Sub

        Private Sub webBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs)
            Text = System.String.Format("Sublight (IMDb): {0}?", webBrowser1.DocumentTitle)
        End Sub

        Private Sub webBrowser1_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            e.Cancel = True
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class FrmBrowser

End Namespace

