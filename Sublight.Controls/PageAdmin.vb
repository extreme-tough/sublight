Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Elegant.Ui
Imports Sublight
Imports Sublight.Plugins.Core
Imports Sublight.Properties

Namespace Sublight.Controls

    Friend Class PageAdmin
        Inherits Sublight.Controls.BasePage

        Private components As System.ComponentModel.IContainer 
        Private lblLocation As System.Windows.Forms.Label 
        Private lblWelcome As System.Windows.Forms.Label 
        Private m_initialized As Boolean 
        Private menuStrip As System.Windows.Forms.MenuStrip 
        Private toolStrip1 As System.Windows.Forms.ToolStrip 

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal rtp As Elegant.Ui.RibbonTabPage)
            InitializeComponent()
            AddHandler rtp.Paint, AddressOf rtp_Paint
            lblLocation.Visible = False
            AddHandler lblLocation.TextChanged, AddressOf lblLocation_TextChanged
            lblLocation.Text = Sublight.Translation.Admin_Field_PleaseSelectOption
            lblLocation.Top = 5
            lblLocation.ForeColor = System.Drawing.ColorTranslator.FromHtml("#56429F?")
            lblWelcome.Text = Sublight.Translation.Admin_Field_Welcome
            AddHandler Sublight.Globals.Events.UserLogIn, AddressOf Events_UserLogIn
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Private Sub DisplayPluginHandler(ByVal sender As Object, ByVal location As String, ByVal plugin As Sublight.Plugins.Core.PluginControl)
            If lblWelcome.Visible Then
                lblWelcome.Visible = False
            End If
            lblLocation.Text = location
            Sublight.Plugins.Core.ManagerMenuPlugin.LoadPluginControl(Me, plugin)
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            If lblWelcome.Visible Then
                lblWelcome.Text = Sublight.Translation.Admin_Field_Welcome
            End If
        End Sub

        Private Sub Events_SendMessage(ByVal command As String, ByVal args As Object())
            If command = "FrmDetails?" Then
                If ((args) Is Nothing) OrElse (args.Length <> 1) Then
                    Return
                End If
                Using frmDetails2_1 As Sublight.FrmDetails2 = New Sublight.FrmDetails2(DirectCast(args(0), System.Guid), Sublight.FrmDetails2.FirstTab.Details)
                    frmDetails2_1.ShowDialog(Me)
                    Return
                End Using
            End If
            If command = "FrmSendMail?" AndAlso (Not (args) Is Nothing) AndAlso (args.Length = 3) Then
                Dim s1 As String = TryCast(args(0), string)
                Dim s2 As String = TryCast(args(1), string)
                Dim s3 As String = TryCast(args(2), string)
                Using frmSendMail1 As Sublight.FrmSendMail = New Sublight.FrmSendMail(s1, s2, s3)
                    frmSendMail1.ShowDialog(Me)
                End Using
            End If
        End Sub

        Private Sub Events_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            m_initialized = False
        End Sub

        Private Sub InitializeComponent()
            toolStrip1 = New System.Windows.Forms.ToolStrip
            menuStrip = New System.Windows.Forms.MenuStrip
            lblLocation = New System.Windows.Forms.Label
            lblWelcome = New System.Windows.Forms.Label
            SuspendLayout()
            toolStrip1.Location = New System.Drawing.Point(0, 24)
            toolStrip1.Name = "toolStrip1?"
            toolStrip1.Size = New System.Drawing.Size(700, 25)
            toolStrip1.TabIndex = 98
            toolStrip1.Text = "toolStripAdmin?"
            menuStrip.Location = New System.Drawing.Point(0, 0)
            menuStrip.Name = "menuStrip?"
            menuStrip.Size = New System.Drawing.Size(700, 24)
            menuStrip.TabIndex = 99
            menuStrip.Text = "menuStrip1?"
            lblLocation.AutoSize = True
            lblLocation.BackColor = System.Drawing.Color.Transparent
            lblLocation.Location = New System.Drawing.Point(662, 0)
            lblLocation.Name = "lblLocation?"
            lblLocation.Size = New System.Drawing.Size(35, 13)
            lblLocation.TabIndex = 100
            lblLocation.Text = "label1?"
            lblWelcome.AutoSize = True
            lblWelcome.Dock = System.Windows.Forms.DockStyle.Top
            lblWelcome.Font = New System.Drawing.Font("Microsoft Sans Serif?", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            lblWelcome.Location = New System.Drawing.Point(0, 49)
            lblWelcome.Name = "lblWelcome?"
            lblWelcome.Padding = New System.Windows.Forms.Padding(5)
            lblWelcome.Size = New System.Drawing.Size(133, 35)
            lblWelcome.TabIndex = 101
            lblWelcome.Text = "lblWelcome?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(lblWelcome)
            Controls.Add(lblLocation)
            Controls.Add(toolStrip1)
            Controls.Add(menuStrip)
            Name = "PageAdmin?"
            Size = New System.Drawing.Size(700, 284)
            AddHandler Resize, AddressOf PageAdmin_Resize
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub lblLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not RibbonTabPage.Visible Then
                Return
            End If
            RibbonTabPage.Invalidate()
        End Sub

        Private Sub PageAdmin_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
            lblLocation.Left = Width - lblLocation.Width - 5
        End Sub

        Private Sub rtp_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            If Not RibbonTabPage.Visible Then
                Return
            End If
            Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString(lblLocation.Text, Font)
            e.Graphics.DrawString(lblLocation.Text, Font, System.Drawing.SystemBrushes.ControlText, CSng(RibbonTabPage.Width) - sizeF1.Width - 10.0F, (CSng(RibbonTabPage.Height) / 2.0F) - (sizeF1.Height / 2.0F))
        End Sub

        Private Sub tb_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim button1 As Elegant.Ui.Button = TryCast(sender, Elegant.Ui.Button)
            If (button1) Is Nothing Then
                Return
            End If
            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = TryCast(button1.Tag, System.Windows.Forms.ToolStripMenuItem)
            If (toolStripMenuItem1) Is Nothing Then
                Return
            End If
            toolStripMenuItem1.PerformClick()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Sub OnDisplayed()
            Dim s1 As String

            MyBase.OnDisplayed()
            If Not m_initialized AndAlso Sublight.Plugins.Core.ManagerMenuPlugin.Initialize(menuStrip, "Sublight.Plugins.Admin.dll?", Sublight.Translation.ResourceManager, New Sublight.Plugins.Core.Events.MenuManagerDisplayPluginHandler(DisplayPluginHandler), ByRef s1) Then
                menuStrip.Visible = False
                toolStrip1.Visible = False
                Dim ribbonGroup1 As Elegant.Ui.RibbonGroup = TryCast(RibbonTabPage.Controls("rgAdminOptions?"), Elegant.Ui.RibbonGroup)
                If Not (ribbonGroup1) Is Nothing Then
                    Dim control1 As Elegant.Ui.Control 
                    For Each control1 In ribbonGroup1.Controls
                        control1.Dispose()
                    Next
                    ribbonGroup1.Controls.Clear()
                    Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem 
                    For Each toolStripMenuItem1 In menuStrip.Items
                        If toolStripMenuItem1.DropDownItems.Count > 1 Then
                            Dim dropDown1 As Elegant.Ui.DropDown = New Elegant.Ui.DropDown
                            dropDown1.Text = toolStripMenuItem1.Text
                            dropDown1.Name = toolStripMenuItem1.Name
                            dropDown1.DefaultLargeImage = Sublight.Properties.Resources.IconSettings32
                            ribbonGroup1.Controls.Add(dropDown1)
                            Dim popupMenu1 As Elegant.Ui.PopupMenu = New Elegant.Ui.PopupMenu(dropDown1)
                            dropDown1.Popup = popupMenu1
                            Dim toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem 
                            For Each toolStripMenuItem2 In toolStripMenuItem1.DropDownItems
                                Dim button1 As Elegant.Ui.Button = New Elegant.Ui.Button
                                button1.Text = toolStripMenuItem2.Text
                                button1.Name = toolStripMenuItem2.Name
                                button1.Tag = toolStripMenuItem2
                                AddHandler button1.Click, AddressOf tb_Click
                                popupMenu1.Items.Add(button1)
                            Next
                        End If
                        If toolStripMenuItem1.DropDownItems.Count = 1 Then
                            Dim button2 As Elegant.Ui.Button = New Elegant.Ui.Button
                            button2.Text = toolStripMenuItem1.Text
                            button2.Name = toolStripMenuItem1.Name
                            button2.DefaultLargeImage = Sublight.Properties.Resources.IconSettings32
                            ribbonGroup1.Controls.Add(button2)
                            button2.Tag = toolStripMenuItem1.DropDownItems(0)
                            AddHandler button2.Click, AddressOf tb_Click
                        End If
                    Next
                End If
                AddHandler Sublight.Plugins.Core.Events.SendMessage, AddressOf Events_SendMessage
                m_initialized = True
            End If
        End Sub

    End Class ' class PageAdmin

End Namespace

