Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Elegant.Ui
Imports Sublight

Namespace Sublight.Controls

    Friend Class PageProfile
        Inherits Sublight.Controls.BasePage

        Private ReadOnly m_profileContactUs As Sublight.Controls.ProfileContactUs 
        Private ReadOnly m_profileUserInfo As Sublight.Controls.ProfileUserInfo 

        Private _btnContact As Elegant.Ui.ToggleButton 
        Private _btnUserInfo As Elegant.Ui.ToggleButton 
        Private components As System.ComponentModel.IContainer 
        Private myPanel1 As Sublight.Controls.MyPanel 

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal rtp As Elegant.Ui.RibbonTabPage)
            InitializeComponent()
            _btnUserInfo = TryCast(GetTabControlByName("tbProfileUserInfo?"), Elegant.Ui.ToggleButton)
            If (_btnUserInfo) Is Nothing Then
                Throw New System.NullReferenceException("tbProfileUserInfo?")
            End If
            _btnUserInfo.Pressed = True
            AddHandler _btnUserInfo.Click, AddressOf btnUserInfo_Click
            _btnContact = TryCast(GetTabControlByName("tbProfileContactForm?"), Elegant.Ui.ToggleButton)
            If (_btnContact) Is Nothing Then
                Throw New System.NullReferenceException("tbProfileContactForm?")
            End If
            _btnContact.Pressed = False
            AddHandler _btnContact.Click, AddressOf btnContactForm_Click
            myPanel1.SuspendLayout()
            m_profileUserInfo = New Sublight.Controls.ProfileUserInfo(parent)
            m_profileUserInfo.SuspendLayout()
            m_profileUserInfo.Name = "ProfileUserInfo?"
            m_profileUserInfo.Visible = True
            m_profileUserInfo.Dock = System.Windows.Forms.DockStyle.Fill
            myPanel1.Controls.Add(m_profileUserInfo)
            m_profileContactUs = New Sublight.Controls.ProfileContactUs(parent)
            m_profileContactUs.SuspendLayout()
            m_profileContactUs.Name = "ProfileContactUs?"
            m_profileContactUs.Visible = False
            m_profileContactUs.Dock = System.Windows.Forms.DockStyle.Fill
            myPanel1.Controls.Add(m_profileContactUs)
            m_profileUserInfo.ResumeLayout()
            m_profileContactUs.ResumeLayout()
            myPanel1.ResumeLayout()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
            AddHandler Sublight.Globals.Events.UserLogIn, AddressOf Events_UserLogIn
        End Sub

        Private Sub btnContactForm_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            HideAllControls()
            _btnContact.Pressed = True
            m_profileContactUs.Visible = True
        End Sub

        Private Sub btnUserInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            HideAllControls()
            _btnUserInfo.Pressed = True
            m_profileUserInfo.EnsureData()
            m_profileUserInfo.Visible = True
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            _btnContact.Text = Sublight.Translation.ContactUs_ContactForm
            _btnUserInfo.Text = Sublight.Translation.Profile_UserInfo
        End Sub

        Private Sub Events_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            m_profileUserInfo.ClearUserInfo()
            _btnUserInfo.Enabled = Not isAnonymous
            If isAnonymous Then
                btnContactForm_Click(Me, Nothing)
                Return
            End If
            If _btnUserInfo.Pressed Then
                m_profileContactUs.Visible = False
                m_profileUserInfo.Visible = True
                Return
            End If
            m_profileContactUs.Visible = True
            m_profileUserInfo.Visible = False
        End Sub

        Private Sub HideAllControls()
            m_profileContactUs.Visible = False
            m_profileUserInfo.Visible = False
            _btnContact.Pressed = False
            _btnUserInfo.Pressed = False
        End Sub

        Private Sub InitializeComponent()
            myPanel1 = New Sublight.Controls.MyPanel
            SuspendLayout()
            myPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            myPanel1.Location = New System.Drawing.Point(0, 39)
            myPanel1.Name = "myPanel1?"
            myPanel1.Padding = New System.Windows.Forms.Padding(5)
            myPanel1.Size = New System.Drawing.Size(713, 300)
            myPanel1.TabIndex = 100
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(myPanel1)
            Name = "PageProfile?"
            Size = New System.Drawing.Size(713, 339)
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Friend Sub ShowMyContributions()
            Sublight.Globals.MainForm.SwitchTab(Sublight.FrmMain.RibbonTab.Profile)
            btnUserInfo_Click(Me, Nothing)
            If (Not (m_profileUserInfo) Is Nothing) AndAlso Not m_profileUserInfo.IsDisposed Then
                m_profileUserInfo.ShowMyContributions()
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overrides Sub OnDisplayed()
            MyBase.OnDisplayed()
            If m_profileUserInfo.Visible Then
                m_profileUserInfo.OnDisplayed()
            End If
        End Sub

    End Class ' class PageProfile

End Namespace

