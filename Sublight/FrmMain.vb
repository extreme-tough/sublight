Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports Elegant.Ui
Imports Sublight.Controls
Imports Sublight.Controls.Office2007Renderer
Imports Sublight.MyUtility
Imports Sublight.Plugins.Core
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS
Imports Sublight.WS_SublightClient

Namespace Sublight

    Public Class FrmMain
        Inherits Sublight.BaseForm

        Friend Enum RibbonTab
            Publish
            Profile
            Search
        End Enum

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass30

            Public <>4__this As Sublight.FrmMain 
            Public points As System.Nullable(Of Double) 
            Public text As String 

            Public Sub New()
            End Sub

            Public Sub <SetStatusMessage>b__2f()
                Dim s1 As String = text
                If points.get_HasValue() Then
                    s1 = s1 + System.String.Format(" ({0})?", System.String.Format(Sublight.Translation.Common_UserPoints, points.get_Value()))
                End If
                <>4__this.lblStatusUser.Text = s1
                If points.get_HasValue() AndAlso (points.get_Value() < 0.0R) Then
                    <>4__this.lblStatusUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
                    <>4__this.lblStatusUser.DefaultSmallImage = Sublight.Properties.Resources.ToolbarWarningSmall
                    <>4__this.lblStatusUser.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
                    <>4__this.lblStatusUser.Tag = "NegativePoints?"
                    <>4__this.lblStatusUser.Enabled = True
                    Return
                End If
                <>4__this.lblStatusUser.DefaultSmallImage = Nothing
                <>4__this.lblStatusUser.Padding = New System.Windows.Forms.Padding(0, 0, 0, 0)
                If points.get_HasValue() Then
                    <>4__this.lblStatusUser.Tag = "PositivePoints?"
                    <>4__this.lblStatusUser.Enabled = True
                    Return
                End If
                <>4__this.lblStatusUser.Tag = System.String.Empty
                <>4__this.lblStatusUser.Enabled = True
            End Sub

        End Class ' class <>c__DisplayClass30

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass38

            Public <>4__this As Sublight.FrmMain 
            Public existingControls As System.Collections.Generic.List(Of System.Windows.Forms.Control) 
            Public nodes As System.Collections.Generic.List(Of System.Xml.XmlNode) 

            Public Sub New()
            End Sub

            Public Sub <LoadRssThread>b__34()
                Dim control1 As System.Windows.Forms.Control 
                For Each control1 In <>4__this.rgArticlesLinks.Controls
                    existingControls.Add(control1)
                Next
                <>4__this.rgArticlesLinks.Controls.Clear()
            End Sub

            Public Sub <LoadRssThread>b__35()
                Dim i1 As Integer = 0
                While i1 < nodes.get_Count()
                    Try
                        Dim xmlNode1 As System.Xml.XmlNode = nodes.get_Item(i1)
                        Dim s1 As String = xmlNode1.SelectSingleNode("title?").InnerText
                        Dim s2 As String = xmlNode1.SelectSingleNode("link?").InnerText
                        Dim button1 As Elegant.Ui.Button = New Elegant.Ui.Button
                        button1.Text = s1
                        button1.Tag = s2
                        If i1 < 2 Then
                            button1.InformativenessMaximumLevel = "Elegant.Ui.RibbonGroupButtonInformativenessLevel:LargeImageWithText?"
                            button1.DefaultLargeImage = Sublight.Properties.Resources.IconRss32
                        Else 
                            button1.InformativenessMaximumLevel = "Elegant.Ui.RibbonGroupButtonInformativenessLevel:SmallImageWithText?"
                            button1.DefaultSmallImage = Sublight.Properties.Resources.IconRss16
                        End If
                        Dim s3 As String = xmlNode1.SelectSingleNode("pubDate?").InnerText
                        s3 = s3.Replace("GMT?", System.String.Empty).Trim()
                        Dim dateTime1 As System.DateTime = System.DateTime.ParseExact(s3, "ddd, dd MMM yyyy HH:mm:ss?", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None)
                        button1.ScreenTip.Caption = s1
                        button1.ScreenTip.Text = System.String.Format(Sublight.Translation.RecentArticles_ArticleHint, dateTime1, xmlNode1.SelectSingleNode("author?").InnerText)
                        AddHandler button1.Click, AddressOf <>4__this.btnArticle_Click
                        <>4__this.rgArticlesLinks.Controls.Add(button1)
                    Catch 
                    End Try
                    i1 = i1 + 1
                End While
                <>4__this.rgArticlesLinks.Controls.AddRange(existingControls.ToArray())
            End Sub

        End Class ' class <>c__DisplayClass38

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass44

            Public <>4__this As Sublight.FrmMain 
            Public text As String 

            Public Sub New()
            End Sub

            Public Sub <sc_GetOnlineSublightUsersCompleted>b__3e()
                <>4__this.lblStatusOnlineUsers.Text = text
            End Sub

        End Class ' class <>c__DisplayClass44

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass4a

            Public <>4__this As Sublight.FrmMain 
            Public displaySearchPage As Boolean 
            Public isAnonymous As Boolean 

            Public Sub New()
            End Sub

            Public Sub <Events_UserLogIn>b__46()
                If isAnonymous Then
                    <>4__this.SetStatusAnonymousUser()
                    Return
                End If
                <>4__this.SetStatusRegisteredUser()
            End Sub

            Public Sub <Events_UserLogIn>b__47()
                If Sublight.BaseForm.IsInRole(Sublight.Plugins.Core.Role.SubtitleEditor) OrElse Sublight.BaseForm.IsAdministrator() Then
                    <>4__this.rtAdmin.Visible = True
                    Return
                End If
                If <>4__this.ribbon.CurrentTabPage = <>4__this.rtAdmin Then
                    displaySearchPage = True
                End If
                <>4__this.rtAdmin.Visible = True
                <>4__this.rtAdmin.Visible = False
            End Sub

        End Class ' class <>c__DisplayClass4a

        Private Class AppMenuRight
            Inherits Elegant.Ui.Label

            Public Sub New()
            End Sub

            Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
                If (Height <= 0) OrElse (Width <= 0) Then
                    Return
                End If
                Using linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, System.Drawing.ColorTranslator.FromHtml("#FDFDFD?"), System.Drawing.ColorTranslator.FromHtml("#E5E9EE?"), System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                    pevent.Graphics.FillRectangle(linearGradientBrush1, ClientRectangle)
                End Using
            End Sub

        End Class ' class AppMenuRight

        Private Class AppWindowState

            Private _form As System.Windows.Forms.Form 
            Private _height As Integer 
            Private _left As Integer 
            Private _top As Integer 
            Private _width As Integer 
            Private _windowState As System.Windows.Forms.FormWindowState 

            Private Sub New(ByVal form As System.Windows.Forms.Form, ByVal loadFromSettings As Boolean)
                Dim flag1 As Boolean

                If ((form) Is Nothing) OrElse form.IsDisposed Then
                    Return
                End If
                _form = form
                If loadFromSettings Then
                    flag1 = SetFromSettings()
                Else 
                    flag1 = SetFromForm()
                End If
                If flag1 Then
                    EnsureValidValues()
                    Return
                End If
                SetDefaults()
            End Sub

            Public Sub ApplyToForm()
                If (Not (_form) Is Nothing) AndAlso Not _form.IsDisposed Then
                    _form.SuspendLayout()
                    _form.Location = New System.Drawing.Point(_left, _top)
                    _form.Size = New System.Drawing.Size(_width, _height)
                    _form.Visible = True
                    _form.WindowState = _windowState
                    _form.ResumeLayout(False)
                    _form.PerformLayout()
                End If
            End Sub

            Private Sub EnsureValidValues()
                Dim size1 As System.Drawing.Size = _form.MinimumSize
                If _width < size1.Width Then
                    Dim size2 As System.Drawing.Size = _form.MinimumSize
                    _width = size2.Width
                End If
                Dim size3 As System.Drawing.Size = _form.MinimumSize
                If _height < size3.Height Then
                    Dim size4 As System.Drawing.Size = _form.MinimumSize
                    _height = size4.Height
                End If
                If _top < 0 Then
                    _top = 0
                End If
                If _left < 0 Then
                    _left = 0
                End If
                Dim rectangle1 As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                If _width > rectangle1.Width Then
                    Dim rectangle2 As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                    _width = rectangle2.Width
                End If
                Dim rectangle3 As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                If _height > rectangle3.Height Then
                    Dim rectangle4 As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                    _height = rectangle4.Height
                End If
                Dim rectangle5 As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                If (_left + _width) > rectangle5.Width Then
                    Dim rectangle6 As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                    _left = rectangle6.Width - _width
                End If
                Dim rectangle7 As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                If (_top + _height) > rectangle7.Height Then
                    Dim rectangle8 As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                    _top = rectangle8.Height - _height
                End If
                If _windowState = System.Windows.Forms.FormWindowState.Minimized Then
                    _windowState = System.Windows.Forms.FormWindowState.Normal
                End If
            End Sub

            Private Sub SaveToSettings()
                Try
                    If Not (_form) Is Nothing Then
                        Dim objArr1 As Object() = New object() { _
                                                                 _width, _
                                                                 _height, _
                                                                 _left, _
                                                                 _top, _
                                                                 System.Enum.GetName(GetType(System.Windows.Forms.FormWindowState), _windowState) }
                        Sublight.Properties.Settings.Default.App_WindowState = System.String.Format("{0};{1};{2};{3};{4}?", objArr1)
                    Else 
                        Sublight.Properties.Settings.Default.App_WindowState = System.String.Empty
                    End If
                Catch 
                    Sublight.Properties.Settings.Default.App_WindowState = System.String.Empty
                End Try
                Sublight.BaseForm.SaveUserSettingsSilent()
            End Sub

            Private Function SetDefaults() As Boolean
                Dim flag1 As Boolean

                Try
                    If ((_form) Is Nothing) OrElse _form.IsDisposed Then
                        Return False
                    End If
                    Dim rectangle1 As System.Drawing.Rectangle = System.Windows.Forms.Screen.GetWorkingArea(_form)
                    Dim size1 As System.Drawing.Size = _form.MinimumSize
                    _width = size1.Width
                    Dim size2 As System.Drawing.Size = _form.MinimumSize
                    _height = size2.Height
                    _top = System.Convert.ToInt32((CDbl(rectangle1.Height) / 2.0R) - (CDbl(_height) / 2.0R))
                    _left = System.Convert.ToInt32((CDbl(rectangle1.Width) / 2.0R) - (CDbl(_width) / 2.0R))
                    _windowState = System.Windows.Forms.FormWindowState.Normal
                    flag1 = True
                Catch 
                    flag1 = False
                End Try
                Return flag1
            End Function

            Private Function SetFromForm() As Boolean
                Dim flag1 As Boolean

                If ((_form) Is Nothing) OrElse _form.IsDisposed Then
                    Return False
                End If
                Try
                    _width = _form.Width
                    _height = _form.Height
                    _left = _form.Left
                    _top = _form.Top
                    _windowState = _form.WindowState
                    flag1 = True
                Catch 
                    flag1 = False
                End Try
                Return flag1
            End Function

            Private Function SetFromSettings() As Boolean
                Dim flag1 As Boolean

                Try
                    If ((_form) Is Nothing) OrElse System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.App_WindowState) OrElse (Sublight.Properties.Settings.Default.App_WindowState.Trim().Length <= 0) Then
                        Return False
                    End If
                    Dim chArr1 As Char() = New char() { ";"C }
                    Dim sArr1 As String() = Sublight.Properties.Settings.Default.App_WindowState.Split(chArr1, System.StringSplitOptions.RemoveEmptyEntries)
                    If ((sArr1) Is Nothing) OrElse (sArr1.Length <> 5) Then
                        Return False
                    End If
                    _width = System.Int32.Parse(sArr1(0))
                    _height = System.Int32.Parse(sArr1(1))
                    _left = System.Int32.Parse(sArr1(2))
                    _top = System.Int32.Parse(sArr1(3))
                    _windowState = DirectCast(System.Enum.Parse(GetType(System.Windows.Forms.FormWindowState), sArr1(4)), System.Windows.Forms.FormWindowState)
                    flag1 = True
                Catch 
                    flag1 = False
                End Try
                Return flag1
            End Function

            Public Shared Sub ApplyToForm(ByVal form As System.Windows.Forms.Form)
                Dim appWindowState1 As Sublight.FrmMain.AppWindowState = New Sublight.FrmMain.AppWindowState(form, True)
                appWindowState1.ApplyToForm()
            End Sub

            Public Shared Sub SaveToSettings(ByVal form As System.Windows.Forms.Form)
                Dim appWindowState1 As Sublight.FrmMain.AppWindowState = New Sublight.FrmMain.AppWindowState(form, False)
                appWindowState1.SaveToSettings()
            End Sub

        End Class ' class AppWindowState

        Private Const _TAG_NEGATIVE_POINTS As String  = "NegativePoints"
        Private Const _TAG_POSITIVE_POINTS As String  = "PositivePoints"
        Private Const ONLINE_USERS_NA As String  = "???"
        Private Const TAG_LOGIN As String  = "LogIn"
        Private Const TAG_LOGOFF As String  = "LogOff"
        Private Const UNKNOWN_USERNAME As String  = "???"

        Private _currentPage As Sublight.Controls.BasePage 
        Private _currentUserDisplayName As String 
        Private _lblAppMenuRight As Sublight.FrmMain.AppMenuRight 
        Private _onlineUsers As Integer 
        Private _pageAdmin As Sublight.Controls.PageAdmin 
        Private _pageMyMovies As Sublight.Controls.PageMyMovies 
        Private _pageProfile As Sublight.Controls.PageProfile 
        Private _pagePublish As Sublight.Controls.PagePublish 
        Private _pageSearch As Sublight.Controls.PageSearch 
        Private _pageSettings As Sublight.Controls.PageSettings 
        Private _pageView As Sublight.Controls.PageView 
        Private _stopRssAnimation As Boolean 
        Private appMenu As Elegant.Ui.ApplicationMenu 
        Private btnAppAbout As Elegant.Ui.Button 
        Private btnAppDonation As Elegant.Ui.Button 
        Private btnAppLogin As Elegant.Ui.Button 
        Private btnAppRegister As Elegant.Ui.Button 
        Private btnArticlesClose As Elegant.Ui.Button 
        Private btnArticlesHome As Elegant.Ui.Button 
        Private btnMyMoviesBatchDownload As Elegant.Ui.Button 
        Private btnPublish As Elegant.Ui.Button 
        Private btnPublishClear As Elegant.Ui.Button 
        Private btnSearchAddLink As Elegant.Ui.Button 
        Private btnSearchClear As Elegant.Ui.Button 
        Private btnSearchDownload As Elegant.Ui.Button 
        Private btnSearchFilter As Elegant.Ui.ToggleButton 
        Private btnSearchInvalidLink As Elegant.Ui.Button 
        Private btnSearchPlay As Elegant.Ui.Button 
        Private btnSearchRate As Elegant.Ui.DropDown 
        Private btnSearchReport As Elegant.Ui.Button 
        Private btnSearchSync As Elegant.Ui.Button 
        Private btnSearchValidLink As Elegant.Ui.Button 
        Private btnSelectlanguage As Elegant.Ui.Button 
        Private btnSettingsReload As Elegant.Ui.Button 
        Private btnSettingsReset As Elegant.Ui.Button 
        Private btnSettingsSave As Elegant.Ui.Button 
        Private btnSettingsWizard As Elegant.Ui.Button 
        Private btnSublightCmd As Elegant.Ui.Button 
        Private btnWebPage As Elegant.Ui.Button 
        Private cmsNC As System.Windows.Forms.ContextMenuStrip 
        Private cmsNC_About As System.Windows.Forms.ToolStripMenuItem 
        Private cmsNC_Exit As System.Windows.Forms.ToolStripMenuItem 
        Private cmsNC_Show As System.Windows.Forms.ToolStripMenuItem 
        Private components As System.ComponentModel.IContainer 
        Private contextMenuExtenderProvider1 As Elegant.Ui.ContextMenuExtenderProvider 
        Private ctNews As Elegant.Ui.RibbonContextualTabGroup 
        Private ctOptions As Elegant.Ui.RibbonContextualTabGroup 
        Private formFrameSkinner As Elegant.Ui.FormFrameSkinner 
        Private lblStatusMatchesCount As Elegant.Ui.Label 
        Private lblStatusOnlineUsers As Elegant.Ui.Label 
        Private lblStatusUser As Elegant.Ui.Button 
        Private m_userLoggedIn As Boolean 
        Private mainPanel As Elegant.Ui.Panel 
        Private nc As System.Windows.Forms.NotifyIcon 
        Private openFileDialog As System.Windows.Forms.OpenFileDialog 
        Private rgAdminOptions As Elegant.Ui.RibbonGroup 
        Private rgArticlesClose As Elegant.Ui.RibbonGroup 
        Private rgArticlesLinks As Elegant.Ui.RibbonGroup 
        Private rgMyMoviesOptions As Elegant.Ui.RibbonGroup 
        Private rgProfile As Elegant.Ui.RibbonGroup 
        Private rgPublishOptions As Elegant.Ui.RibbonGroup 
        Private rgSearchDownload As Elegant.Ui.RibbonGroup 
        Private rgSearchFeedback As Elegant.Ui.RibbonGroup 
        Private rgSearchLinking As Elegant.Ui.RibbonGroup 
        Private rgSearchOptions As Elegant.Ui.RibbonGroup 
        Private rgSettingsOptions As Elegant.Ui.RibbonGroup 
        Private rgViewViews As Elegant.Ui.RibbonGroup 
        Private ribbon As Elegant.Ui.Ribbon 
        Private rtAdmin As Elegant.Ui.RibbonTabPage 
        Private rtArticles As Elegant.Ui.RibbonTabPage 
        Private rtMyMovies As Elegant.Ui.RibbonTabPage 
        Private rtProfile As Elegant.Ui.RibbonTabPage 
        Private rtPublish As Elegant.Ui.RibbonTabPage 
        Private rtSearch As Elegant.Ui.RibbonTabPage 
        Private rtSettings As Elegant.Ui.RibbonTabPage 
        Private rtView As Elegant.Ui.RibbonTabPage 
        Private saveFileDialog As System.Windows.Forms.SaveFileDialog 
        Private separator1 As Elegant.Ui.Separator 
        Private separator2 As Elegant.Ui.Separator 
        Private separator3 As Elegant.Ui.Separator 
        Private separator4 As Elegant.Ui.Separator 
        Private separator5 As Elegant.Ui.Separator 
        Private separator6 As Elegant.Ui.Separator 
        Private statusBar As Elegant.Ui.StatusBar 
        Private statusBarControlsArea1 As Elegant.Ui.StatusBarControlsArea 
        Private statusBarNotificationsArea1 As Elegant.Ui.StatusBarNotificationsArea 
        Private statusBarPane1 As Elegant.Ui.StatusBarPane 
        Private statusBarPane2 As Elegant.Ui.StatusBarPane 
        Private statusBarPane3 As Elegant.Ui.StatusBarPane 
        Private statusBarPane4 As Elegant.Ui.StatusBarPane 
        Private statusBarPane5 As Elegant.Ui.StatusBarPane 
        Private statusBarPane6 As Elegant.Ui.StatusBarPane 
        Private tbProfileContactForm As Elegant.Ui.ToggleButton 
        Private tbProfileUserInfo As Elegant.Ui.ToggleButton 
        Private tbViewDownloaded As Elegant.Ui.ToggleButton 
        Private tbViewFavorite As Elegant.Ui.ToggleButton 
        Private tbViewNew As Elegant.Ui.ToggleButton 
        Private tbViewPublished As Elegant.Ui.ToggleButton 
        Private tbViewStatistics As Elegant.Ui.ToggleButton 
        Private tgMyMoviesFiles As Elegant.Ui.ToggleButton 
        Private tgMyMoviesFolders As Elegant.Ui.ToggleButton 
        Private timerOnlineUsers As System.Windows.Forms.Timer 
        Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator 

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared <FormLoaded>k__BackingField As Boolean 

        Friend Shared Property FormLoaded As Boolean
            Get
                Return Sublight.FrmMain.<FormLoaded>k__BackingField
            End Get
            Set
                Sublight.FrmMain.<FormLoaded>k__BackingField = value
            End Set
        End Property

        Public Sub New()
            _onlineUsers = -1
            InitializeComponent()
            Visible = False
            InitForm()
            InitRibbon()
            InitializePages()
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <AnimateAppButtonThread>b__3a()
            If ribbon.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Default Then
                ribbon.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Office2010Orange
                Return
            End If
            ribbon.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Default
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <AnimateAppButtonThread>b__3b()
            ribbon.ApplicationButtonAnimationEnabled = True
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <Events_UserLogIn>b__48()
            ribbon.CurrentTabPage = rtSearch
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <LoadRssThread>b__36()
            ctNews.Visible = True
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <NewsNotifyUserThread>b__32()
            If ctNews.Color = Elegant.Ui.RibbonContextualTabGroupColor.Green Then
                ctNews.Color = Elegant.Ui.RibbonContextualTabGroupColor.Red
                Return
            End If
            ctNews.Color = Elegant.Ui.RibbonContextualTabGroupColor.Green
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <NewsNotifyUserThread>b__33()
            ctNews.Color = Elegant.Ui.RibbonContextualTabGroupColor.Green
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <sc_GetOnlineSublightUsersCompleted>b__3d()
            lblStatusOnlineUsers.Text = System.String.Format(Sublight.Translation.Common_Status_OnlineUsers, "????")
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <sc_GetOnlineSublightUsersCompleted>b__3f()
            lblStatusOnlineUsers.Text = System.String.Format(Sublight.Translation.Common_Status_OnlineUsers, "????")
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <sc_GetOnlineSublightUsersCompleted>b__40()
            lblStatusOnlineUsers.DefaultSmallImage = Nothing
            If Not lblStatusOnlineUsers.Visible Then
                lblStatusOnlineUsers.Visible = True
            End If
        End Sub

        Private Sub AnimateAppButtonIfNecessary()
            If Sublight.Properties.Settings.Default.App_AnimateButton Then
                System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AnimateAppButtonThread))
            End If
        End Sub

        Private Sub AnimateAppButtonThread(ByVal stateInfo As Object)
            Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = Nothing
            System.Threading.Thread.Sleep(1000)
            Dim i1 As Integer = 0
            While i1 < 6
                If (methodInvoker3) Is Nothing Then
                    methodInvoker3 = New System.Windows.Forms.MethodInvoker(<AnimateAppButtonThread>b__3a)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker3
                If ribbon.InvokeRequired Then
                    ribbon.Invoke(methodInvoker1)
                Else 
                    methodInvoker1.Invoke()
                End If
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(150)
                i1 = i1 + 1
            End While
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<AnimateAppButtonThread>b__3b)
            If ribbon.InvokeRequired Then
                ribbon.Invoke(methodInvoker2)
                Return
            End If
            methodInvoker2.Invoke()
        End Sub

        Private Sub appMenu_ExitButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub appMenu_Showing(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not (_lblAppMenuRight) Is Nothing Then
                _lblAppMenuRight.Text = System.String.Empty
            End If
            If Sublight.Properties.Settings.Default.App_AnimateButton Then
                Sublight.Properties.Settings.Default.App_AnimateButton = False
                Sublight.BaseForm.SaveUserSettingsSilent()
            End If
        End Sub

        Private Sub appMenuItem_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim s1 As String

            If (_lblAppMenuRight) Is Nothing Then
                Return
            End If
            Dim control1 As Elegant.Ui.Control = TryCast(sender, Elegant.Ui.Control)
            If (control1) Is Nothing Then
                Return
            End If
            If control1.Name = btnAppLogin.Name Then
                If Sublight.BaseForm.IsAnonymous Then
                    s1 = "Login?"
                Else 
                    s1 = "Logoff?"
                End If
            ElseIf control1.Name = btnAppDonation.Name Then
                s1 = "PurchasePoints?"
            ElseIf control1.Name = btnAppAbout.Name Then
                s1 = "About?"
            ElseIf control1.Name = btnAppRegister.Name Then
                s1 = "RegisterUser?"
            Else 
                s1 = System.String.Empty
            End If
            Dim s2 As String = IIf(System.String.IsNullOrEmpty(s1), System.String.Empty, Sublight.Globals.GetString(System.String.Format("Application_Menu_Hint_{0}?", s1)))
            If _lblAppMenuRight.Text <> s2 Then
                _lblAppMenuRight.Text = s2
            End If
        End Sub

        Private Sub btnAppAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowAboutBox()
        End Sub

        Private Sub btnAppDonation_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowPurchasePoints()
        End Sub

        Private Sub btnAppLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            If TryCast(btnAppLogin.Tag, string) = "LogOff?" Then
                Try
                    btnAppLogin.Enabled = False
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        sublight1.LogOut(Sublight.BaseForm.Session, out s1)
                    End Using
                    Sublight.Globals.Events.OnUserLogOff()
                    Dim flag1 As Boolean = LogInAnonymous(out s1)
                    If Not flag1 Then
                        ShowError(Sublight.Translation.Main_Error_Login, New object(0) {})
                        System.Windows.Forms.Application.Exit()
                    Else 
                        FillLogoutName()
                        Sublight.Globals.Events.OnUserLogIn(Sublight.BaseForm.IsAnonymous)
                    End If
                    Return
                Finally
                    btnAppLogin.Enabled = True
                End Try
            End If
            Dim frmLogIn1 As Sublight.FrmLogIn = New Sublight.FrmLogIn
            If (frmLogIn1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) AndAlso Sublight.BaseForm.Session <> System.Guid.Empty Then
                FillLogoutName()
            End If
        End Sub

        Private Sub btnAppRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim frmLogIn1 As Sublight.FrmLogIn = New Sublight.FrmLogIn(True)
            If (frmLogIn1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) AndAlso Sublight.BaseForm.Session <> System.Guid.Empty Then
                FillLogoutName()
            End If
        End Sub

        Private Sub btnArticle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim button1 As Elegant.Ui.Button = TryCast(sender, Elegant.Ui.Button)
            If (button1) Is Nothing Then
                Return
            End If
            Dim s1 As String = TryCast(button1.Tag, string)
            If System.String.IsNullOrEmpty(s1) Then
                Return
            End If
            OpenInBrowser(s1)
        End Sub

        Private Sub btnArticlesClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If (Not (_currentPage) Is Nothing) AndAlso (Not (_currentPage.RibbonTabPage) Is Nothing) Then
                ribbon.CurrentTabPage = _currentPage.RibbonTabPage
            End If
        End Sub

        Private Sub btnArticlesHome_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl())
        End Sub

        Private Sub btnSelectlanguage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Using frmLanguageSelector1 As Sublight.FrmLanguageSelector = New Sublight.FrmLanguageSelector(Me)
                If frmLanguageSelector1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                    ApplyRightToLeft()
                    Sublight.BaseForm.ApplyLanguage()
                End If
            End Using
        End Sub

        Private Sub btnSublightCmd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String = Nothing
            If ribbon.CurrentTabPage = rtSearch Then
                s1 = _pageSearch.SelectedImdb
            ElseIf ribbon.CurrentTabPage = rtView Then
                s1 = _pageView.SelectedImdb
            End If
            If Not System.String.IsNullOrEmpty(s1) Then
                Dim chArr1 As Char() = New char() { "/"C }
                s1 = s1.Trim(chArr1)
                Dim i1 As Integer = s1.LastIndexOf("/"C)
                If i1 >= 0 Then
                    s1 = s1.Substring(i1 + 1)
                End If
            End If
            RunSublightCmd(IIf(System.String.IsNullOrEmpty(s1), "help?", System.String.Format("nfo /imdb:{0}?", s1)))
        End Sub

        Private Sub btnWebPage_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl())
        End Sub

        Private Sub cmsNC_About_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            NC_Show()
            Dim frmAbout1 As Sublight.FrmAbout = New Sublight.FrmAbout
            frmAbout1.ShowDialog(Me)
        End Sub

        Private Sub cmsNC_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub cmsNC_Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            NC_Show()
        End Sub

        Private Sub DisplayTabControl()
            If ribbon.CurrentTabPage = rtArticles Then
                _stopRssAnimation = True
                If rgArticlesLinks.Controls.Count > 0 Then
                    Dim button1 As Elegant.Ui.Button = TryCast(rgArticlesLinks.Controls(0), Elegant.Ui.Button)
                    If (Not (button1) Is Nothing) AndAlso (button1 <> btnArticlesHome) AndAlso (button1 <> btnArticlesClose) Then
                        Dim s1 As String = TryCast(button1.Tag, string)
                        Sublight.Properties.Settings.Default.Search_RSS_LastNews = s1
                        Sublight.BaseForm.SaveUserSettingsSilent()
                    End If
                End If
                Return
            End If
            HideAllTabControls()
            If ribbon.CurrentTabPage = rtSearch Then
                _currentPage = _pageSearch
            ElseIf ribbon.CurrentTabPage = rtView Then
                _currentPage = _pageView
            ElseIf ribbon.CurrentTabPage = rtSettings Then
                _currentPage = _pageSettings
            ElseIf ribbon.CurrentTabPage = rtProfile Then
                _currentPage = _pageProfile
            ElseIf ribbon.CurrentTabPage = rtMyMovies Then
                _currentPage = _pageMyMovies
            ElseIf ribbon.CurrentTabPage = rtPublish Then
                _currentPage = _pagePublish
            ElseIf ribbon.CurrentTabPage = rtAdmin Then
                _currentPage = _pageAdmin
            Else 
                _currentPage = Nothing
            End If
            If Not (_currentPage) Is Nothing Then
                _currentPage.Visible = True
                _currentPage.OnDisplayed()
            End If
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            Sublight.Plugins.Core.ManagerMenuPlugin.OnLanguageChanged(Me, language)
            cmsNC_Show.Text = Sublight.Translation.Application_Tray_Show
            cmsNC_About.Text = Sublight.Translation.Application_Tray_About
            cmsNC_Exit.Text = Sublight.Translation.Application_Tray_Exit
            ribbon.HelpButtonScreenTip.Text = Sublight.Translation.Application_Menu_About
            btnAppAbout.Text = Sublight.Translation.Application_Menu_About
            appMenu.ExitButtonText = Sublight.Translation.Application_Menu_Exit
            btnAppDonation.Text = Sublight.Translation.Application_Menu_PurchasePoints
            btnAppRegister.Text = Sublight.Translation.Application_Menu_RegisterUser
        End Sub

        Private Sub Events_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            Dim methodInvoker4 As System.Windows.Forms.MethodInvoker = Nothing
            Dim <>c__DisplayClass4a1 As Sublight.FrmMain.<>c__DisplayClass4a = New Sublight.FrmMain.<>c__DisplayClass4a
            <>c__DisplayClass4a1.isAnonymous = isAnonymous
            <>c__DisplayClass4a1.<>4__this = Me
            m_userLoggedIn = True
            Sublight.Plugins.Core.Globals.OnUserLogIn(Sublight.BaseForm.Session, Sublight.BaseForm.Roles)
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass4a1.<Events_UserLogIn>b__46)
            Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
            <>c__DisplayClass4a1.displaySearchPage = False
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass4a1.<Events_UserLogIn>b__47)
            Sublight.BaseForm.DoCtrlInvoke(rtAdmin, Me, methodInvoker2)
            If <>c__DisplayClass4a1.displaySearchPage Then
                If (methodInvoker4) Is Nothing Then
                    methodInvoker4 = New System.Windows.Forms.MethodInvoker(<Events_UserLogIn>b__48)
                End If
                Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = methodInvoker4
                Sublight.BaseForm.DoCtrlInvoke(ribbon, Me, methodInvoker3)
            End If
            If Sublight.BaseForm.IsAdministrator() Then
                Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                    sublightClient1.ReportInfoAsync(Sublight.Properties.Settings.Default.UserId, Sublight.BaseForm.Session, Sublight.BaseForm.ClientInfo, "User logged in as administrator.?")
                End Using
            End If
            Try
                btnAppRegister.Visible = <>c__DisplayClass4a1.isAnonymous
            Catch 
            End Try
        End Sub

        Private Sub Events_UserLogOff(ByVal sender As Object)
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(SetStatusAnonymousUser)
            Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
        End Sub

        Private Sub FillLogoutName()
            If Not Sublight.BaseForm.IsAnonymous Then
                btnAppLogin.Tag = "LogOff?"
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    AddHandler sublight1.GetUserBySessionCompleted, AddressOf ws_GetUserBySessionCompleted
                    sublight1.GetUserBySessionAsync(Sublight.BaseForm.Session)
                    Return
                End Using
            End If
            btnAppLogin.Tag = "LogIn?"
            SetLogoutText()
        End Sub

        Private Sub FrmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            Sublight.FrmMain.AppWindowState.SaveToSettings(Me)
        End Sub

        Private Sub FrmMain_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs)
            ShowQuickHelp()
        End Sub

        Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            LoadAppWithSplash()
            InitLanguage()
            HandleExplorerSearch()
            AnimateAppButtonIfNecessary()
            LoadRss()
            Sublight.BaseForm.LoaderFormEnabled = True
            Sublight.FrmMain.AppWindowState.ApplyToForm(Me)
        End Sub

        Private Sub HandleExplorerSearch()
            Dim sArr1 As String() = System.Environment.GetCommandLineArgs()
            If Not (sArr1) Is Nothing Then
                Dim i1 As Integer = 0
                While i1 < sArr1.Length
                    sArr1(i1) = sArr1(i1).Trim()
                    If sArr1(i1).StartsWith("file=?", System.StringComparison.InvariantCultureIgnoreCase) Then
                        Dim s1 As String = sArr1(i1).Substring(sArr1(i1).IndexOf("="C) + 1)
                        Dim chArr1 As Char() = New char() { ""C }
                        s1 = s1.Trim(chArr1)
                        If Not (_pageSearch) Is Nothing Then
                            _pageSearch.PerformSearch(s1, True)
                        End If
                    End If
                    i1 = i1 + 1
                End While
            End If
        End Sub

        Private Sub HideAllTabControls()
            If Not (_pageSearch) Is Nothing Then
                _pageSearch.Visible = False
            End If
            If Not (_pageView) Is Nothing Then
                _pageView.Visible = False
            End If
            If Not (_pageSettings) Is Nothing Then
                _pageSettings.Visible = False
            End If
            If Not (_pageProfile) Is Nothing Then
                _pageProfile.Visible = False
            End If
            If Not (_pageMyMovies) Is Nothing Then
                _pageMyMovies.Visible = False
            End If
            If Not (_pagePublish) Is Nothing Then
                _pagePublish.Visible = False
            End If
            If Not (_pageAdmin) Is Nothing Then
                _pageAdmin.Visible = False
            End If
        End Sub

        Private Sub InitForm()
            Sublight.Globals.MainForm = Me
            AddHandler Closing, AddressOf FrmMain_Closing
            lblStatusMatchesCount.Visible = False
            lblStatusOnlineUsers.Visible = False
            lblStatusUser.Text = System.String.Empty
            KeyPreview = True
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            Dim componentResourceManager1 As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sublight.FrmMain))
            rtSearch = New Elegant.Ui.RibbonTabPage
            rgSearchDownload = New Elegant.Ui.RibbonGroup
            btnSearchPlay = New Elegant.Ui.Button
            btnSearchDownload = New Elegant.Ui.Button
            rgSearchFeedback = New Elegant.Ui.RibbonGroup
            btnSearchRate = New Elegant.Ui.DropDown
            btnSearchReport = New Elegant.Ui.Button
            rgSearchLinking = New Elegant.Ui.RibbonGroup
            btnSearchAddLink = New Elegant.Ui.Button
            btnSearchValidLink = New Elegant.Ui.Button
            btnSearchInvalidLink = New Elegant.Ui.Button
            rgSearchOptions = New Elegant.Ui.RibbonGroup
            btnSearchSync = New Elegant.Ui.Button
            btnSearchFilter = New Elegant.Ui.ToggleButton
            btnSearchClear = New Elegant.Ui.Button
            rtView = New Elegant.Ui.RibbonTabPage
            rgViewViews = New Elegant.Ui.RibbonGroup
            tbViewNew = New Elegant.Ui.ToggleButton
            tbViewFavorite = New Elegant.Ui.ToggleButton
            tbViewPublished = New Elegant.Ui.ToggleButton
            tbViewDownloaded = New Elegant.Ui.ToggleButton
            separator2 = New Elegant.Ui.Separator
            tbViewStatistics = New Elegant.Ui.ToggleButton
            rtPublish = New Elegant.Ui.RibbonTabPage
            rgPublishOptions = New Elegant.Ui.RibbonGroup
            btnPublish = New Elegant.Ui.Button
            separator6 = New Elegant.Ui.Separator
            btnPublishClear = New Elegant.Ui.Button
            formFrameSkinner = New Elegant.Ui.FormFrameSkinner
            statusBar = New Elegant.Ui.StatusBar
            statusBarNotificationsArea1 = New Elegant.Ui.StatusBarNotificationsArea
            statusBarPane2 = New Elegant.Ui.StatusBarPane
            lblStatusUser = New Elegant.Ui.Button
            statusBarPane3 = New Elegant.Ui.StatusBarPane
            lblStatusMatchesCount = New Elegant.Ui.Label
            statusBarPane4 = New Elegant.Ui.StatusBarPane
            lblStatusOnlineUsers = New Elegant.Ui.Label
            statusBarControlsArea1 = New Elegant.Ui.StatusBarControlsArea
            statusBarPane6 = New Elegant.Ui.StatusBarPane
            btnSelectlanguage = New Elegant.Ui.Button
            statusBarPane1 = New Elegant.Ui.StatusBarPane
            btnSublightCmd = New Elegant.Ui.Button
            statusBarPane5 = New Elegant.Ui.StatusBarPane
            btnWebPage = New Elegant.Ui.Button
            openFileDialog = New System.Windows.Forms.OpenFileDialog
            saveFileDialog = New System.Windows.Forms.SaveFileDialog
            mainPanel = New Elegant.Ui.Panel
            timerOnlineUsers = New System.Windows.Forms.Timer(components)
            nc = New System.Windows.Forms.NotifyIcon(components)
            cmsNC = New System.Windows.Forms.ContextMenuStrip(components)
            cmsNC_Show = New System.Windows.Forms.ToolStripMenuItem
            cmsNC_About = New System.Windows.Forms.ToolStripMenuItem
            toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            cmsNC_Exit = New System.Windows.Forms.ToolStripMenuItem
            contextMenuExtenderProvider1 = New Elegant.Ui.ContextMenuExtenderProvider
            ribbon = New Elegant.Ui.Ribbon
            appMenu = New Elegant.Ui.ApplicationMenu
            btnAppLogin = New Elegant.Ui.Button
            btnAppRegister = New Elegant.Ui.Button
            btnAppDonation = New Elegant.Ui.Button
            separator1 = New Elegant.Ui.Separator
            btnAppAbout = New Elegant.Ui.Button
            ctOptions = New Elegant.Ui.RibbonContextualTabGroup
            rtProfile = New Elegant.Ui.RibbonTabPage
            rgProfile = New Elegant.Ui.RibbonGroup
            tbProfileUserInfo = New Elegant.Ui.ToggleButton
            tbProfileContactForm = New Elegant.Ui.ToggleButton
            rtSettings = New Elegant.Ui.RibbonTabPage
            rgSettingsOptions = New Elegant.Ui.RibbonGroup
            btnSettingsSave = New Elegant.Ui.Button
            btnSettingsReload = New Elegant.Ui.Button
            btnSettingsReset = New Elegant.Ui.Button
            separator3 = New Elegant.Ui.Separator
            btnSettingsWizard = New Elegant.Ui.Button
            rtAdmin = New Elegant.Ui.RibbonTabPage
            rgAdminOptions = New Elegant.Ui.RibbonGroup
            ctNews = New Elegant.Ui.RibbonContextualTabGroup
            rtArticles = New Elegant.Ui.RibbonTabPage
            rgArticlesLinks = New Elegant.Ui.RibbonGroup
            separator4 = New Elegant.Ui.Separator
            btnArticlesHome = New Elegant.Ui.Button
            rgArticlesClose = New Elegant.Ui.RibbonGroup
            btnArticlesClose = New Elegant.Ui.Button
            rtMyMovies = New Elegant.Ui.RibbonTabPage
            rgMyMoviesOptions = New Elegant.Ui.RibbonGroup
            tgMyMoviesFiles = New Elegant.Ui.ToggleButton
            tgMyMoviesFolders = New Elegant.Ui.ToggleButton
            separator5 = New Elegant.Ui.Separator
            btnMyMoviesBatchDownload = New Elegant.Ui.Button
            rtSearch.BeginInit()
            rtSearch.SuspendLayout()
            rgSearchDownload.BeginInit()
            rgSearchDownload.SuspendLayout()
            rgSearchFeedback.BeginInit()
            rgSearchFeedback.SuspendLayout()
            rgSearchLinking.BeginInit()
            rgSearchLinking.SuspendLayout()
            rgSearchOptions.BeginInit()
            rgSearchOptions.SuspendLayout()
            rtView.BeginInit()
            rtView.SuspendLayout()
            rgViewViews.BeginInit()
            rgViewViews.SuspendLayout()
            rtPublish.BeginInit()
            rtPublish.SuspendLayout()
            rgPublishOptions.BeginInit()
            rgPublishOptions.SuspendLayout()
            statusBar.SuspendLayout()
            statusBarNotificationsArea1.SuspendLayout()
            statusBarPane2.SuspendLayout()
            statusBarPane3.SuspendLayout()
            statusBarPane4.SuspendLayout()
            statusBarControlsArea1.SuspendLayout()
            statusBarPane6.SuspendLayout()
            statusBarPane1.SuspendLayout()
            statusBarPane5.SuspendLayout()
            cmsNC.SuspendLayout()
            ribbon.BeginInit()
            appMenu.BeginInit()
            rtProfile.BeginInit()
            rtProfile.SuspendLayout()
            rgProfile.BeginInit()
            rgProfile.SuspendLayout()
            rtSettings.BeginInit()
            rtSettings.SuspendLayout()
            rgSettingsOptions.BeginInit()
            rgSettingsOptions.SuspendLayout()
            rtAdmin.BeginInit()
            rtAdmin.SuspendLayout()
            rgAdminOptions.BeginInit()
            rtArticles.BeginInit()
            rtArticles.SuspendLayout()
            rgArticlesLinks.BeginInit()
            rgArticlesLinks.SuspendLayout()
            rgArticlesClose.BeginInit()
            rgArticlesClose.SuspendLayout()
            rtMyMovies.BeginInit()
            rtMyMovies.SuspendLayout()
            rgMyMoviesOptions.BeginInit()
            rgMyMoviesOptions.SuspendLayout()
            SuspendLayout()
            rtSearch.Controls.Add(rgSearchDownload)
            rtSearch.Controls.Add(rgSearchFeedback)
            rtSearch.Controls.Add(rgSearchLinking)
            rtSearch.Controls.Add(rgSearchOptions)
            rtSearch.Dock = System.Windows.Forms.DockStyle.Fill
            rtSearch.Id = "42074558-1676-4703-96c0-d23e652c5e58?"
            rtSearch.KeyTip = "S?"
            rtSearch.Location = New System.Drawing.Point(0, 0)
            rtSearch.Name = "rtSearch?"
            rtSearch.Size = New System.Drawing.Size(984, 101)
            rtSearch.TabIndex = 0
            rtSearch.Text = "Search Subtitles?"
            rgSearchDownload.Controls.Add(btnSearchPlay)
            rgSearchDownload.Controls.Add(btnSearchDownload)
            rgSearchDownload.DialogLauncherButtonEnabled = False
            rgSearchDownload.DialogLauncherButtonVisible = False
            rgSearchDownload.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgSearchDownload.Id = "2997bcf4-7c25-49a7-a3c1-a28c99d9380e?"
            rgSearchDownload.Location = New System.Drawing.Point(4, 3)
            rgSearchDownload.Name = "rgSearchDownload?"
            rgSearchDownload.Size = New System.Drawing.Size(127, 94)
            rgSearchDownload.TabIndex = 0
            rgSearchDownload.Text = "Download?"
            btnSearchPlay.Enabled = False
            btnSearchPlay.Id = "6c7373db-44ab-41b9-a0c3-e59080829463?"
            Dim controlImageArr1 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconPlay32) }
            btnSearchPlay.LargeImages.Images.AddRange(controlImageArr1)
            btnSearchPlay.Location = New System.Drawing.Point(4, 2)
            btnSearchPlay.Name = "btnSearchPlay?"
            btnSearchPlay.Size = New System.Drawing.Size(58, 72)
            btnSearchPlay.TabIndex = 0
            btnSearchPlay.Text = "Download and Play?"
            btnSearchDownload.Enabled = False
            btnSearchDownload.Id = "af04c0bd-b592-4eef-9cdb-5f0f5f71a045?"
            Dim controlImageArr2 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconArrowDown32) }
            btnSearchDownload.LargeImages.Images.AddRange(controlImageArr2)
            btnSearchDownload.Location = New System.Drawing.Point(64, 2)
            btnSearchDownload.Name = "btnSearchDownload?"
            btnSearchDownload.Size = New System.Drawing.Size(58, 72)
            btnSearchDownload.TabIndex = 1
            btnSearchDownload.Text = "Download?"
            rgSearchFeedback.Controls.Add(btnSearchRate)
            rgSearchFeedback.Controls.Add(btnSearchReport)
            rgSearchFeedback.DialogLauncherButtonEnabled = False
            rgSearchFeedback.DialogLauncherButtonVisible = False
            rgSearchFeedback.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgSearchFeedback.Id = "b4df06bf-2e1a-4010-a527-9e28e529bd5f?"
            rgSearchFeedback.Location = New System.Drawing.Point(133, 3)
            rgSearchFeedback.Name = "rgSearchFeedback?"
            rgSearchFeedback.Size = New System.Drawing.Size(101, 94)
            rgSearchFeedback.TabIndex = 1
            rgSearchFeedback.Text = "Feedback?"
            btnSearchRate.Enabled = False
            btnSearchRate.Id = "6969beac-cda9-4026-bae4-54dd93914afe?"
            Dim controlImageArr3 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconStar32) }
            btnSearchRate.LargeImages.Images.AddRange(controlImageArr3)
            btnSearchRate.Location = New System.Drawing.Point(4, 2)
            btnSearchRate.Name = "btnSearchRate?"
            btnSearchRate.Size = New System.Drawing.Size(42, 72)
            btnSearchRate.TabIndex = 1
            btnSearchRate.Text = "Rate?"
            btnSearchReport.Enabled = False
            btnSearchReport.Id = "9f76abfc-ed4c-4b20-b058-db870cf6efca?"
            Dim controlImageArr4 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconThumbDown32) }
            btnSearchReport.LargeImages.Images.AddRange(controlImageArr4)
            btnSearchReport.Location = New System.Drawing.Point(48, 2)
            btnSearchReport.Name = "btnSearchReport?"
            btnSearchReport.Size = New System.Drawing.Size(48, 72)
            btnSearchReport.TabIndex = 2
            btnSearchReport.Text = "Report...?"
            rgSearchLinking.Controls.Add(btnSearchAddLink)
            rgSearchLinking.Controls.Add(btnSearchValidLink)
            rgSearchLinking.Controls.Add(btnSearchInvalidLink)
            rgSearchLinking.DialogLauncherButtonEnabled = False
            rgSearchLinking.DialogLauncherButtonVisible = False
            rgSearchLinking.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgSearchLinking.Id = "f5b3189c-1e2a-4ac5-a9f0-365a6d000328?"
            rgSearchLinking.Location = New System.Drawing.Point(236, 3)
            rgSearchLinking.Name = "rgSearchLinking?"
            rgSearchLinking.Size = New System.Drawing.Size(139, 94)
            rgSearchLinking.TabIndex = 2
            rgSearchLinking.Text = "Linking?"
            btnSearchAddLink.Enabled = False
            btnSearchAddLink.Id = "0c69a081-1084-4909-a308-76356a830d6b?"
            Dim controlImageArr5 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconLinkAdd32) }
            btnSearchAddLink.LargeImages.Images.AddRange(controlImageArr5)
            btnSearchAddLink.Location = New System.Drawing.Point(4, 2)
            btnSearchAddLink.Name = "btnSearchAddLink?"
            btnSearchAddLink.Size = New System.Drawing.Size(42, 72)
            btnSearchAddLink.TabIndex = 0
            btnSearchAddLink.Text = "Add Link?"
            btnSearchValidLink.Enabled = False
            btnSearchValidLink.Id = "b02af2fd-3da9-414f-807d-1be06a68dca3?"
            Dim controlImageArr6 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconLinkTick32) }
            btnSearchValidLink.LargeImages.Images.AddRange(controlImageArr6)
            btnSearchValidLink.Location = New System.Drawing.Point(48, 2)
            btnSearchValidLink.Name = "btnSearchValidLink?"
            btnSearchValidLink.Size = New System.Drawing.Size(42, 72)
            btnSearchValidLink.TabIndex = 1
            btnSearchValidLink.Text = "Valid Link?"
            btnSearchInvalidLink.Enabled = False
            btnSearchInvalidLink.Id = "167609d4-6792-4752-a558-ef9a576340f6?"
            Dim controlImageArr7 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconLinkCross32) }
            btnSearchInvalidLink.LargeImages.Images.AddRange(controlImageArr7)
            btnSearchInvalidLink.Location = New System.Drawing.Point(92, 2)
            btnSearchInvalidLink.Name = "btnSearchInvalidLink?"
            btnSearchInvalidLink.Size = New System.Drawing.Size(42, 72)
            btnSearchInvalidLink.TabIndex = 2
            btnSearchInvalidLink.Text = "Invalid Link?"
            rgSearchOptions.Controls.Add(btnSearchSync)
            rgSearchOptions.Controls.Add(btnSearchFilter)
            rgSearchOptions.Controls.Add(btnSearchClear)
            rgSearchOptions.DialogLauncherButtonEnabled = False
            rgSearchOptions.DialogLauncherButtonVisible = False
            rgSearchOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgSearchOptions.Id = "9f3accec-b038-4b49-9ee2-f34c5e8fda1b?"
            rgSearchOptions.Location = New System.Drawing.Point(377, 3)
            rgSearchOptions.Name = "rgSearchOptions?"
            rgSearchOptions.Size = New System.Drawing.Size(165, 94)
            rgSearchOptions.TabIndex = 3
            rgSearchOptions.Text = "Options?"
            btnSearchSync.Enabled = False
            btnSearchSync.Id = "cd8d4a73-c2f5-4ff9-8c59-fd0818c1ac0f?"
            Dim controlImageArr8 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconTimeOK) }
            btnSearchSync.LargeImages.Images.AddRange(controlImageArr8)
            btnSearchSync.Location = New System.Drawing.Point(4, 2)
            btnSearchSync.Name = "btnSearchSync?"
            btnSearchSync.Size = New System.Drawing.Size(68, 72)
            btnSearchSync.TabIndex = 3
            btnSearchSync.Text = "Synchronize subtitle?"
            btnSearchFilter.Id = "b04a1200-ef58-46b8-bc71-e942402b0ffc?"
            Dim controlImageArr9 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.SearchFilter) }
            btnSearchFilter.LargeImages.Images.AddRange(controlImageArr9)
            btnSearchFilter.Location = New System.Drawing.Point(74, 2)
            btnSearchFilter.Name = "btnSearchFilter?"
            btnSearchFilter.Size = New System.Drawing.Size(42, 72)
            btnSearchFilter.TabIndex = 1
            btnSearchFilter.Text = "Filter results?"
            btnSearchClear.Id = "a6485782-f6ca-4506-9327-33fc099f34bd?"
            Dim controlImageArr10 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconErase32) }
            btnSearchClear.LargeImages.Images.AddRange(controlImageArr10)
            btnSearchClear.Location = New System.Drawing.Point(118, 2)
            btnSearchClear.Name = "btnSearchClear?"
            btnSearchClear.Size = New System.Drawing.Size(42, 72)
            btnSearchClear.TabIndex = 2
            btnSearchClear.Text = "Clear fields?"
            rtView.Controls.Add(rgViewViews)
            rtView.Dock = System.Windows.Forms.DockStyle.Fill
            rtView.Id = "1ab50136-4855-4b7e-a482-aa0e7372e724?"
            rtView.KeyTip = "V?"
            rtView.Location = New System.Drawing.Point(0, 0)
            rtView.Name = "rtView?"
            rtView.Size = New System.Drawing.Size(984, 101)
            rtView.TabIndex = 0
            rtView.Text = "View?"
            rgViewViews.Controls.Add(tbViewNew)
            rgViewViews.Controls.Add(tbViewFavorite)
            rgViewViews.Controls.Add(tbViewPublished)
            rgViewViews.Controls.Add(tbViewDownloaded)
            rgViewViews.Controls.Add(separator2)
            rgViewViews.Controls.Add(tbViewStatistics)
            rgViewViews.DialogLauncherButtonVisible = False
            rgViewViews.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgViewViews.Id = "16dd9407-2386-46e7-9c1b-7defee782814?"
            Dim controlImageArr11 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconStarClock32) }
            rgViewViews.LargeImages.Images.AddRange(controlImageArr11)
            rgViewViews.Location = New System.Drawing.Point(4, 3)
            rgViewViews.Name = "rgViewViews?"
            rgViewViews.Size = New System.Drawing.Size(269, 0)
            rgViewViews.TabIndex = 0
            rgViewViews.Text = "Views?"
            tbViewNew.Id = "d14c9945-3c4e-4aed-bfa4-272be8e994f4?"
            Dim controlImageArr12 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconStarClock32) }
            tbViewNew.LargeImages.Images.AddRange(controlImageArr12)
            tbViewNew.Location = New System.Drawing.Point(4, 2)
            tbViewNew.Name = "tbViewNew?"
            tbViewNew.Size = New System.Drawing.Size(72, 0)
            tbViewNew.TabIndex = 0
            tbViewNew.Text = "New subtitles?"
            tbViewNew.UserInteractionEnabled = False
            tbViewFavorite.Id = "7db89b75-84ad-4eb0-82b1-31bcba9a9d3b?"
            Dim controlImageArr13 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconStar32) }
            tbViewFavorite.LargeImages.Images.AddRange(controlImageArr13)
            tbViewFavorite.Location = New System.Drawing.Point(78, 2)
            tbViewFavorite.Name = "tbViewFavorite?"
            tbViewFavorite.Size = New System.Drawing.Size(88, 0)
            tbViewFavorite.TabIndex = 1
            tbViewFavorite.Text = "Favorite subtitles?"
            tbViewFavorite.UserInteractionEnabled = False
            tbViewPublished.Id = "347c6e1d-9b90-451f-9058-f09978cd2bcf?"
            Dim controlImageArr14 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconArrowUp32) }
            tbViewPublished.LargeImages.Images.AddRange(controlImageArr14)
            tbViewPublished.Location = New System.Drawing.Point(168, 2)
            tbViewPublished.Name = "tbViewPublished?"
            tbViewPublished.Size = New System.Drawing.Size(86, 0)
            tbViewPublished.TabIndex = 2
            tbViewPublished.Text = "Published by me?"
            tbViewPublished.UserInteractionEnabled = False
            tbViewDownloaded.Id = "48e7af6f-3832-46ca-8680-c029fe08550b?"
            Dim controlImageArr15 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconArrowDown32) }
            tbViewDownloaded.LargeImages.Images.AddRange(controlImageArr15)
            tbViewDownloaded.Location = New System.Drawing.Point(256, 2)
            tbViewDownloaded.Name = "tbViewDownloaded?"
            tbViewDownloaded.Size = New System.Drawing.Size(100, 0)
            tbViewDownloaded.TabIndex = 3
            tbViewDownloaded.Text = "Downloaded by me?"
            tbViewDownloaded.UserInteractionEnabled = False
            separator2.Id = "bd256c2f-1212-4d8b-a989-eb24188c9902?"
            separator2.Location = New System.Drawing.Point(258, 7)
            separator2.Name = "separator2?"
            separator2.Size = New System.Drawing.Size(2, -34)
            separator2.TabIndex = 6
            separator2.Text = "separator2?"
            tbViewStatistics.Id = "9c2e00d0-0758-4773-964c-2cb6c379ac0f?"
            Dim controlImageArr16 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconGraph32) }
            tbViewStatistics.LargeImages.Images.AddRange(controlImageArr16)
            tbViewStatistics.Location = New System.Drawing.Point(256, -20)
            tbViewStatistics.Name = "tbViewStatistics?"
            tbViewStatistics.Size = New System.Drawing.Size(51, 0)
            tbViewStatistics.TabIndex = 7
            tbViewStatistics.Text = "Statistics?"
            tbViewStatistics.UserInteractionEnabled = False
            rtPublish.Controls.Add(rgPublishOptions)
            rtPublish.Dock = System.Windows.Forms.DockStyle.Fill
            rtPublish.Id = "336383fc-b064-4e1c-a6ef-1ce72740a6a2?"
            rtPublish.KeyTip = "P?"
            rtPublish.Location = New System.Drawing.Point(0, 0)
            rtPublish.Name = "rtPublish?"
            rtPublish.Size = New System.Drawing.Size(984, 101)
            rtPublish.TabIndex = 0
            rtPublish.Text = "Publish Subtitle?"
            AddHandler rtPublish.Paint, AddressOf rtPublish_Paint
            rgPublishOptions.Controls.Add(btnPublish)
            rgPublishOptions.Controls.Add(separator6)
            rgPublishOptions.Controls.Add(btnPublishClear)
            rgPublishOptions.DialogLauncherButtonVisible = False
            rgPublishOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgPublishOptions.Id = "73d9ae8b-eeba-4bee-88b4-b42320e99d29?"
            rgPublishOptions.Location = New System.Drawing.Point(4, 3)
            rgPublishOptions.Name = "rgPublishOptions?"
            rgPublishOptions.Size = New System.Drawing.Size(103, 0)
            rgPublishOptions.TabIndex = 0
            rgPublishOptions.Text = "Options?"
            btnPublish.Id = "9d6ec77c-b922-4b84-8395-d737e1443e40?"
            Dim controlImageArr17 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconArrowUp32) }
            btnPublish.LargeImages.Images.AddRange(controlImageArr17)
            btnPublish.Location = New System.Drawing.Point(11, 2)
            btnPublish.Name = "btnPublish?"
            btnPublish.Size = New System.Drawing.Size(79, 0)
            btnPublish.TabIndex = 0
            btnPublish.Text = "Publish subtitle?"
            separator6.Id = "41567a59-2ade-4d83-9ae7-54d889c20a89?"
            separator6.Location = New System.Drawing.Point(13, 7)
            separator6.Name = "separator6?"
            separator6.Size = New System.Drawing.Size(2, -34)
            separator6.TabIndex = 1
            separator6.Text = "separator6?"
            btnPublishClear.Id = "139012db-47ea-4177-b081-d634351151ad?"
            Dim controlImageArr18 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconErase32) }
            btnPublishClear.LargeImages.Images.AddRange(controlImageArr18)
            btnPublishClear.Location = New System.Drawing.Point(11, -20)
            btnPublishClear.Name = "btnPublishClear?"
            btnPublishClear.Size = New System.Drawing.Size(60, 0)
            btnPublishClear.TabIndex = 2
            btnPublishClear.Text = "Clear fields?"
            formFrameSkinner.Form = Me
            statusBar.Controls.Add(statusBarNotificationsArea1)
            statusBar.Controls.Add(statusBarControlsArea1)
            statusBar.ControlsArea = statusBarControlsArea1
            statusBar.Dock = System.Windows.Forms.DockStyle.Bottom
            statusBar.Id = "688d451f-4944-4563-a6b9-572081a28fd6?"
            statusBar.Location = New System.Drawing.Point(0, 1017)
            statusBar.Name = "statusBar?"
            statusBar.NotificationsArea = statusBarNotificationsArea1
            statusBar.Size = New System.Drawing.Size(984, 22)
            statusBar.TabIndex = 1
            statusBar.Text = "statusBar1?"
            statusBarNotificationsArea1.AutoSize = True
            statusBarNotificationsArea1.Controls.Add(statusBarPane2)
            statusBarNotificationsArea1.Controls.Add(statusBarPane3)
            statusBarNotificationsArea1.Controls.Add(statusBarPane4)
            statusBarNotificationsArea1.Dock = System.Windows.Forms.DockStyle.Fill
            statusBarNotificationsArea1.Id = "975ae05c-bb19-4bd3-afda-d97ca5280a46?"
            statusBarNotificationsArea1.Location = New System.Drawing.Point(0, 0)
            statusBarNotificationsArea1.MaximumSize = New System.Drawing.Size(0, 22)
            statusBarNotificationsArea1.MinimumSize = New System.Drawing.Size(0, 22)
            statusBarNotificationsArea1.Name = "statusBarNotificationsArea1?"
            statusBarNotificationsArea1.Size = New System.Drawing.Size(549, 22)
            statusBarNotificationsArea1.TabIndex = 1
            statusBarPane2.AutoSize = True
            statusBarPane2.Controls.Add(lblStatusUser)
            statusBarPane2.Id = "72c52697-fb08-40ae-a23c-f11c710119f8?"
            statusBarPane2.Location = New System.Drawing.Point(0, 0)
            statusBarPane2.MaximumSize = New System.Drawing.Size(0, 22)
            statusBarPane2.MinimumSize = New System.Drawing.Size(0, 22)
            statusBarPane2.Name = "statusBarPane2?"
            statusBarPane2.Size = New System.Drawing.Size(102, 22)
            statusBarPane2.TabIndex = 0
            lblStatusUser.AutoSize = True
            lblStatusUser.Id = "fd74e948-a49c-492a-b654-676e2f50f2dd?"
            lblStatusUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            lblStatusUser.Location = New System.Drawing.Point(3, 2)
            lblStatusUser.Name = "lblStatusUser?"
            lblStatusUser.Size = New System.Drawing.Size(78, 19)
            lblStatusUser.TabIndex = 1
            lblStatusUser.Text = "lblStatusUser?"
            lblStatusUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            AddHandler lblStatusUser.Click, AddressOf lblStatusUser_Click
            statusBarPane3.AutoSize = True
            statusBarPane3.Controls.Add(lblStatusMatchesCount)
            statusBarPane3.Id = "d5eabda0-c822-4af3-85c5-d83eb9c663f3?"
            statusBarPane3.Location = New System.Drawing.Point(102, 0)
            statusBarPane3.MaximumSize = New System.Drawing.Size(0, 22)
            statusBarPane3.MinimumSize = New System.Drawing.Size(0, 22)
            statusBarPane3.Name = "statusBarPane3?"
            statusBarPane3.Size = New System.Drawing.Size(151, 22)
            statusBarPane3.TabIndex = 1
            lblStatusMatchesCount.Id = "288d5976-f045-48d5-b803-3d517173107e?"
            lblStatusMatchesCount.Location = New System.Drawing.Point(5, 2)
            lblStatusMatchesCount.Name = "lblStatusMatchesCount?"
            lblStatusMatchesCount.Size = New System.Drawing.Size(123, 19)
            lblStatusMatchesCount.TabIndex = 1
            lblStatusMatchesCount.Text = "lblStatusMatchesCount?"
            statusBarPane4.AutoSize = True
            statusBarPane4.Controls.Add(lblStatusOnlineUsers)
            statusBarPane4.Id = "32bd3fde-acd3-4d38-b837-642e9f806536?"
            statusBarPane4.Location = New System.Drawing.Point(253, 0)
            statusBarPane4.MaximumSize = New System.Drawing.Size(0, 22)
            statusBarPane4.MinimumSize = New System.Drawing.Size(0, 22)
            statusBarPane4.Name = "statusBarPane4?"
            statusBarPane4.Size = New System.Drawing.Size(136, 22)
            statusBarPane4.TabIndex = 2
            lblStatusOnlineUsers.Id = "a4572d19-9d64-4be2-8f60-5f4bdd2d8930?"
            lblStatusOnlineUsers.Location = New System.Drawing.Point(5, 2)
            lblStatusOnlineUsers.Name = "lblStatusOnlineUsers?"
            lblStatusOnlineUsers.Size = New System.Drawing.Size(108, 19)
            lblStatusOnlineUsers.TabIndex = 2
            lblStatusOnlineUsers.Text = "lblStatusOnlineUsers?"
            statusBarControlsArea1.AutoSize = True
            statusBarControlsArea1.Controls.Add(statusBarPane6)
            statusBarControlsArea1.Controls.Add(statusBarPane1)
            statusBarControlsArea1.Controls.Add(statusBarPane5)
            statusBarControlsArea1.Dock = System.Windows.Forms.DockStyle.Right
            statusBarControlsArea1.Id = "eed46662-78aa-4c1f-9fcb-54b9aa35960e?"
            statusBarControlsArea1.Location = New System.Drawing.Point(549, 0)
            statusBarControlsArea1.MaximumSize = New System.Drawing.Size(0, 22)
            statusBarControlsArea1.MinimumSize = New System.Drawing.Size(0, 22)
            statusBarControlsArea1.Name = "statusBarControlsArea1?"
            statusBarControlsArea1.Size = New System.Drawing.Size(435, 22)
            statusBarControlsArea1.TabIndex = 0
            statusBarPane6.AutoSize = True
            statusBarPane6.Controls.Add(btnSelectlanguage)
            statusBarPane6.Id = "0cd0a29c-646f-4fbf-9925-9e7e9b165525?"
            statusBarPane6.Location = New System.Drawing.Point(0, 0)
            statusBarPane6.MaximumSize = New System.Drawing.Size(0, 22)
            statusBarPane6.MinimumSize = New System.Drawing.Size(0, 22)
            statusBarPane6.Name = "statusBarPane6?"
            statusBarPane6.Size = New System.Drawing.Size(151, 22)
            statusBarPane6.TabIndex = 2
            btnSelectlanguage.AutoSize = True
            btnSelectlanguage.Id = "8d711b54-cf38-4e60-84da-1392fd4643fe?"
            btnSelectlanguage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnSelectlanguage.Location = New System.Drawing.Point(3, 2)
            btnSelectlanguage.Name = "btnSelectlanguage?"
            btnSelectlanguage.Size = New System.Drawing.Size(125, 19)
            Dim controlImageArr19 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.ToolbarLanguage) }
            btnSelectlanguage.SmallImages.Images.AddRange(controlImageArr19)
            btnSelectlanguage.TabIndex = 0
            btnSelectlanguage.Text = "Language: English?"
            btnSelectlanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            AddHandler btnSelectlanguage.Click, AddressOf btnSelectlanguage_Click
            statusBarPane1.AutoSize = True
            statusBarPane1.Controls.Add(btnSublightCmd)
            statusBarPane1.Id = "8fe67bcc-7848-4fa7-917b-c1b9977641c8?"
            statusBarPane1.Location = New System.Drawing.Point(151, 0)
            statusBarPane1.MaximumSize = New System.Drawing.Size(0, 22)
            statusBarPane1.MinimumSize = New System.Drawing.Size(0, 22)
            statusBarPane1.Name = "statusBarPane1?"
            statusBarPane1.Size = New System.Drawing.Size(125, 22)
            statusBarPane1.TabIndex = 0
            btnSublightCmd.AutoSize = True
            btnSublightCmd.Id = "25a5240e-a6e2-48b5-a4ad-5849b2029f74?"
            btnSublightCmd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnSublightCmd.Location = New System.Drawing.Point(3, 2)
            btnSublightCmd.Name = "btnSublightCmd?"
            btnSublightCmd.Size = New System.Drawing.Size(99, 19)
            Dim controlImageArr20 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.CmdLine) }
            btnSublightCmd.SmallImages.Images.AddRange(controlImageArr20)
            btnSublightCmd.TabIndex = 0
            btnSublightCmd.Text = "SublightCmd?"
            btnSublightCmd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            AddHandler btnSublightCmd.Click, AddressOf btnSublightCmd_Click
            statusBarPane5.AutoSize = True
            statusBarPane5.Controls.Add(btnWebPage)
            statusBarPane5.Id = "a5e0ebcc-1750-4026-b229-7c4cecd02bce?"
            statusBarPane5.Location = New System.Drawing.Point(276, 0)
            statusBarPane5.MaximumSize = New System.Drawing.Size(0, 22)
            statusBarPane5.MinimumSize = New System.Drawing.Size(0, 22)
            statusBarPane5.Name = "statusBarPane5?"
            statusBarPane5.Size = New System.Drawing.Size(123, 22)
            statusBarPane5.TabIndex = 1
            btnWebPage.AutoSize = True
            btnWebPage.Id = "c0512c4c-e404-4606-a2cb-657d192b3b02?"
            btnWebPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            btnWebPage.Location = New System.Drawing.Point(3, 2)
            btnWebPage.Name = "btnWebPage?"
            btnWebPage.Size = New System.Drawing.Size(97, 19)
            Dim controlImageArr21 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.ToolbarWebPage) }
            btnWebPage.SmallImages.Images.AddRange(controlImageArr21)
            btnWebPage.TabIndex = 0
            btnWebPage.Text = "btnWebPage?"
            btnWebPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            btnWebPage.Visible = False
            AddHandler btnWebPage.Click, AddressOf btnWebPage_Click
            mainPanel.Dock = System.Windows.Forms.DockStyle.Fill
            mainPanel.Id = "659fef47-2941-41b4-b9ea-e6bdc042b172?"
            mainPanel.Location = New System.Drawing.Point(0, 153)
            mainPanel.Name = "mainPanel?"
            mainPanel.Size = New System.Drawing.Size(984, 864)
            mainPanel.TabIndex = 2
            mainPanel.Text = "panel1?"
            nc.ContextMenuStrip = cmsNC
            nc.Icon = CType(componentResourceManager1.GetObject("nc.Icon?"), System.Drawing.Icon)
            nc.Text = "Sublight?"
            AddHandler nc.DoubleClick, AddressOf nc_DoubleClick
            contextMenuExtenderProvider1.SetContextPopupMenu(cmsNC, Nothing)
            Dim toolStripItemArr1 As System.Windows.Forms.ToolStripItem() = New System.Windows.Forms.ToolStripItem() { _
                                                                                                                       cmsNC_Show, _
                                                                                                                       cmsNC_About, _
                                                                                                                       toolStripSeparator4, _
                                                                                                                       cmsNC_Exit }
            cmsNC.Items.AddRange(toolStripItemArr1)
            cmsNC.Name = "cmsNC?"
            cmsNC.Size = New System.Drawing.Size(149, 76)
            cmsNC_Show.Name = "cmsNC_Show?"
            cmsNC_Show.Size = New System.Drawing.Size(148, 22)
            cmsNC_Show.Text = "Prikaži?"
            AddHandler cmsNC_Show.Click, AddressOf cmsNC_Show_Click
            cmsNC_About.Name = "cmsNC_About?"
            cmsNC_About.Size = New System.Drawing.Size(148, 22)
            cmsNC_About.Text = "O programu...?"
            AddHandler cmsNC_About.Click, AddressOf cmsNC_About_Click
            toolStripSeparator4.Name = "toolStripSeparator4?"
            toolStripSeparator4.Size = New System.Drawing.Size(145, 6)
            cmsNC_Exit.Name = "cmsNC_Exit?"
            cmsNC_Exit.Size = New System.Drawing.Size(148, 22)
            cmsNC_Exit.Text = "Izhod?"
            AddHandler cmsNC_Exit.Click, AddressOf cmsNC_Exit_Click
            ribbon.ApplicationButtonAccessibleDescription = Nothing
            ribbon.ApplicationButtonAccessibleName = Nothing
            ribbon.ApplicationButtonAnimationEnabled = False
            ribbon.ApplicationButtonPopup = appMenu
            ribbon.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Default
            ribbon.ApplicationButtonText = "File?"
            Dim ribbonContextualTabGroupArr1 As Elegant.Ui.RibbonContextualTabGroup() = New Elegant.Ui.RibbonContextualTabGroup() { _
                                                                                                                                    ctOptions, _
                                                                                                                                    ctNews }
            ribbon.ContextualTabGroups.AddRange(ribbonContextualTabGroupArr1)
            ribbon.CurrentTabPage = rtSearch
            ribbon.Dock = System.Windows.Forms.DockStyle.Top
            ribbon.HelpButtonAccessibleDescription = Nothing
            ribbon.HelpButtonAccessibleName = Nothing
            Dim controlImageArr22 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.HelpButton) }
            ribbon.HelpButtonImages.Images.AddRange(controlImageArr22)
            ribbon.HelpButtonVisible = True
            ribbon.Id = "8734919a-f9ad-49d9-9aac-698212b7fca5?"
            ribbon.Location = New System.Drawing.Point(0, 0)
            ribbon.MinimizeButtonAccessibleDescription = Nothing
            ribbon.MinimizeButtonAccessibleName = Nothing
            ribbon.Name = "ribbon?"
            ribbon.QuickAccessToolbarCustomizationDialogEnabled = False
            ribbon.QuickAccessToolbarCustomizationEnabled = False
            ribbon.QuickAccessToolbarPlacementMode = Elegant.Ui.QuickAccessToolbarPlacementMode.AboveRibbon
            ribbon.Size = New System.Drawing.Size(984, 153)
            ribbon.TabIndex = 0
            Dim ribbonTabPageArr1 As Elegant.Ui.RibbonTabPage() = New Elegant.Ui.RibbonTabPage() { _
                                                                                                   rtSearch, _
                                                                                                   rtView, _
                                                                                                   rtMyMovies, _
                                                                                                   rtPublish }
            ribbon.TabPages.AddRange(ribbonTabPageArr1)
            ribbon.Text = "ribbon?"
            AddHandler ribbon.HelpButtonClick, AddressOf ribbon_HelpButtonClick
            AddHandler ribbon.MinimizedChanged, AddressOf ribbon_MinimizedChanged
            appMenu.ContentMinimumHeight = 0
            appMenu.ExitButtonAccessibleDescription = Nothing
            appMenu.ExitButtonAccessibleName = Nothing
            appMenu.ExitButtonCommandName = Nothing
            appMenu.ExitButtonText = "Exit Sublight?"
            Dim controlArr1 As System.Windows.Forms.Control() = New System.Windows.Forms.Control() { _
                                                                                                     btnAppLogin, _
                                                                                                     btnAppRegister, _
                                                                                                     btnAppDonation, _
                                                                                                     separator1, _
                                                                                                     btnAppAbout }
            appMenu.Items.AddRange(controlArr1)
            appMenu.OptionsButtonAccessibleDescription = Nothing
            appMenu.OptionsButtonAccessibleName = Nothing
            appMenu.OptionsButtonCommandName = Nothing
            appMenu.OptionsButtonVisible = False
            appMenu.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
            appMenu.Size = New System.Drawing.Size(100, 100)
            AddHandler appMenu.ExitButtonClick, AddressOf appMenu_ExitButtonClick
            btnAppLogin.Id = "c6b3ac83-eaf8-4933-ae4e-fcd8293d2442?"
            Dim controlImageArr23 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconKey32) }
            btnAppLogin.LargeImages.Images.AddRange(controlImageArr23)
            btnAppLogin.Location = New System.Drawing.Point(0, 0)
            btnAppLogin.Name = "btnAppLogin?"
            btnAppLogin.Size = New System.Drawing.Size(201, 38)
            btnAppLogin.TabIndex = 16
            btnAppLogin.Text = "Login...?"
            AddHandler btnAppLogin.Click, AddressOf btnAppLogin_Click
            btnAppRegister.Id = "66e995ea-0b98-4c8a-8a3e-42d8204afec7?"
            Dim controlImageArr24 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconKeyStar32) }
            btnAppRegister.LargeImages.Images.AddRange(controlImageArr24)
            btnAppRegister.Location = New System.Drawing.Point(0, 38)
            btnAppRegister.Name = "btnAppRegister?"
            btnAppRegister.Size = New System.Drawing.Size(201, 38)
            btnAppRegister.TabIndex = 22
            btnAppRegister.Text = "Register new username...?"
            AddHandler btnAppRegister.Click, AddressOf btnAppRegister_Click
            btnAppDonation.Id = "4ee313bf-6bc1-4598-a96b-25e9f91c4da0?"
            Dim controlImageArr25 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconVisitWeb32) }
            btnAppDonation.LargeImages.Images.AddRange(controlImageArr25)
            btnAppDonation.Location = New System.Drawing.Point(0, 76)
            btnAppDonation.Name = "btnAppDonation?"
            btnAppDonation.Size = New System.Drawing.Size(201, 38)
            btnAppDonation.TabIndex = 3
            btnAppDonation.Text = "Donation?"
            AddHandler btnAppDonation.Click, AddressOf btnAppDonation_Click
            separator1.Id = "0f3e151b-9349-470c-b560-0df8f49da9cf?"
            separator1.Location = New System.Drawing.Point(0, 114)
            separator1.Name = "separator1?"
            separator1.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
            separator1.Size = New System.Drawing.Size(201, 5)
            separator1.TabIndex = 14
            separator1.Text = "separator1?"
            btnAppAbout.Id = "7c1457ca-c607-4505-8321-e4e4f7458758?"
            Dim controlImageArr26 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.AboutBig) }
            btnAppAbout.LargeImages.Images.AddRange(controlImageArr26)
            btnAppAbout.Location = New System.Drawing.Point(0, 119)
            btnAppAbout.Name = "btnAppAbout?"
            btnAppAbout.Size = New System.Drawing.Size(201, 38)
            btnAppAbout.TabIndex = 6
            btnAppAbout.Text = "About Sublight?"
            AddHandler btnAppAbout.Click, AddressOf btnAppAbout_Click
            ctOptions.Caption = "Options?"
            ctOptions.Color = Elegant.Ui.RibbonContextualTabGroupColor.Orange
            Dim ribbonTabPageArr2 As Elegant.Ui.RibbonTabPage() = New Elegant.Ui.RibbonTabPage() { _
                                                                                                   rtProfile, _
                                                                                                   rtSettings, _
                                                                                                   rtAdmin }
            ctOptions.TabPages.AddRange(ribbonTabPageArr2)
            rtProfile.Controls.Add(rgProfile)
            rtProfile.Dock = System.Windows.Forms.DockStyle.Fill
            rtProfile.Id = "5a874b8a-d1c4-4c17-9ac5-e0d8ff9a0a57?"
            rtProfile.KeyTip = Nothing
            rtProfile.Location = New System.Drawing.Point(0, 0)
            rtProfile.Name = "rtProfile?"
            rtProfile.Size = New System.Drawing.Size(984, 101)
            rtProfile.TabIndex = 0
            rtProfile.Text = "Profile?"
            rgProfile.Controls.Add(tbProfileUserInfo)
            rgProfile.Controls.Add(tbProfileContactForm)
            rgProfile.DialogLauncherButtonVisible = False
            rgProfile.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgProfile.Id = "1f2ef92e-036b-4444-aa52-c8502ca24e54?"
            rgProfile.Location = New System.Drawing.Point(4, 3)
            rgProfile.Name = "rgProfile?"
            rgProfile.Size = New System.Drawing.Size(95, 0)
            rgProfile.TabIndex = 0
            rgProfile.Text = "Options?"
            tbProfileUserInfo.Id = "59e4eb2a-fce5-4722-9d3c-7225a2b3f08f?"
            Dim controlImageArr27 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconUserDetails32) }
            tbProfileUserInfo.LargeImages.Images.AddRange(controlImageArr27)
            tbProfileUserInfo.Location = New System.Drawing.Point(4, 2)
            tbProfileUserInfo.Name = "tbProfileUserInfo?"
            tbProfileUserInfo.Size = New System.Drawing.Size(51, 0)
            tbProfileUserInfo.TabIndex = 0
            tbProfileUserInfo.Text = "User info?"
            tbProfileUserInfo.UserInteractionEnabled = False
            tbProfileContactForm.Id = "1bd8993f-869d-4ed9-9934-d0bcb56a39c9?"
            Dim controlImageArr28 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconMail32) }
            tbProfileContactForm.LargeImages.Images.AddRange(controlImageArr28)
            tbProfileContactForm.Location = New System.Drawing.Point(57, 2)
            tbProfileContactForm.Name = "tbProfileContactForm?"
            tbProfileContactForm.Size = New System.Drawing.Size(69, 0)
            tbProfileContactForm.TabIndex = 1
            tbProfileContactForm.Text = "Contact form?"
            tbProfileContactForm.UserInteractionEnabled = False
            rtSettings.Controls.Add(rgSettingsOptions)
            rtSettings.Dock = System.Windows.Forms.DockStyle.Fill
            rtSettings.Id = "4d557301-f6a1-43bb-9c17-9d1163c8310c?"
            rtSettings.KeyTip = Nothing
            rtSettings.Location = New System.Drawing.Point(0, 0)
            rtSettings.Name = "rtSettings?"
            rtSettings.Size = New System.Drawing.Size(984, 101)
            rtSettings.TabIndex = 0
            rtSettings.Text = "Settings?"
            rgSettingsOptions.Controls.Add(btnSettingsSave)
            rgSettingsOptions.Controls.Add(btnSettingsReload)
            rgSettingsOptions.Controls.Add(btnSettingsReset)
            rgSettingsOptions.Controls.Add(separator3)
            rgSettingsOptions.Controls.Add(btnSettingsWizard)
            rgSettingsOptions.DialogLauncherButtonVisible = False
            rgSettingsOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgSettingsOptions.Id = "7624c630-f025-46f3-9fd5-644d42aa0d95?"
            rgSettingsOptions.Location = New System.Drawing.Point(4, 3)
            rgSettingsOptions.Name = "rgSettingsOptions?"
            rgSettingsOptions.Size = New System.Drawing.Size(237, 0)
            rgSettingsOptions.TabIndex = 0
            rgSettingsOptions.Text = "Options?"
            btnSettingsSave.Id = "183ab5c4-bf72-4a78-8f68-af58f0d66364?"
            Dim controlImageArr29 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconSave32) }
            btnSettingsSave.LargeImages.Images.AddRange(controlImageArr29)
            btnSettingsSave.Location = New System.Drawing.Point(4, 2)
            btnSettingsSave.Name = "btnSettingsSave?"
            btnSettingsSave.Size = New System.Drawing.Size(128, 0)
            btnSettingsSave.TabIndex = 0
            btnSettingsSave.Text = "Save and Apply changes?"
            btnSettingsReload.Id = "7bf6debf-e028-4444-aea2-7b924a20639b?"
            Dim controlImageArr30 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconReload32) }
            btnSettingsReload.LargeImages.Images.AddRange(controlImageArr30)
            btnSettingsReload.Location = New System.Drawing.Point(134, 2)
            btnSettingsReload.Name = "btnSettingsReload?"
            btnSettingsReload.Size = New System.Drawing.Size(82, 0)
            btnSettingsReload.TabIndex = 1
            btnSettingsReload.Text = "Reload settings?"
            btnSettingsReset.Id = "b6073e09-8d82-474d-897c-adceaf59d760?"
            Dim controlImageArr31 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconCross32) }
            btnSettingsReset.LargeImages.Images.AddRange(controlImageArr31)
            btnSettingsReset.Location = New System.Drawing.Point(218, 2)
            btnSettingsReset.Name = "btnSettingsReset?"
            btnSettingsReset.Size = New System.Drawing.Size(99, 0)
            btnSettingsReset.TabIndex = 2
            btnSettingsReset.Text = "Reset user settings?"
            separator3.Id = "cc462f24-a5d3-4d9e-b611-46ecb48af3ef?"
            separator3.Location = New System.Drawing.Point(220, 7)
            separator3.Name = "separator3?"
            separator3.Size = New System.Drawing.Size(2, -34)
            separator3.TabIndex = 4
            separator3.Text = "separator3?"
            btnSettingsWizard.Id = "5fa81bc0-8d09-463a-871c-c81f35c0177b?"
            Dim controlImageArr32 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconWizard32) }
            btnSettingsWizard.LargeImages.Images.AddRange(controlImageArr32)
            btnSettingsWizard.Location = New System.Drawing.Point(218, -20)
            btnSettingsWizard.Name = "btnSettingsWizard?"
            btnSettingsWizard.Size = New System.Drawing.Size(89, 0)
            btnSettingsWizard.TabIndex = 3
            btnSettingsWizard.Text = "Settings wizard...?"
            rtAdmin.Controls.Add(rgAdminOptions)
            rtAdmin.Dock = System.Windows.Forms.DockStyle.Fill
            rtAdmin.Id = "96f78f20-6d58-4006-9fc5-0f26aa0d96bf?"
            rtAdmin.KeyTip = Nothing
            rtAdmin.Location = New System.Drawing.Point(0, 0)
            rtAdmin.Name = "rtAdmin?"
            rtAdmin.Size = New System.Drawing.Size(984, 101)
            rtAdmin.TabIndex = 0
            rtAdmin.Text = "Admin?"
            rgAdminOptions.DialogLauncherButtonVisible = False
            rgAdminOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgAdminOptions.Id = "21e9be06-6d49-407c-b767-9debfbf44480?"
            rgAdminOptions.Location = New System.Drawing.Point(4, 3)
            rgAdminOptions.Name = "rgAdminOptions?"
            rgAdminOptions.Size = New System.Drawing.Size(56, 0)
            rgAdminOptions.TabIndex = 0
            rgAdminOptions.Text = "Options?"
            ctNews.Caption = "News?"
            ctNews.Color = Elegant.Ui.RibbonContextualTabGroupColor.Green
            Dim ribbonTabPageArr3 As Elegant.Ui.RibbonTabPage() = New Elegant.Ui.RibbonTabPage() { rtArticles }
            ctNews.TabPages.AddRange(ribbonTabPageArr3)
            rtArticles.Controls.Add(rgArticlesLinks)
            rtArticles.Controls.Add(rgArticlesClose)
            rtArticles.Dock = System.Windows.Forms.DockStyle.Fill
            rtArticles.Id = "0f9fd03b-764c-4b53-8827-9a689927670b?"
            rtArticles.KeyTip = Nothing
            rtArticles.Location = New System.Drawing.Point(0, 0)
            rtArticles.Name = "rtArticles?"
            rtArticles.Size = New System.Drawing.Size(984, 101)
            rtArticles.TabIndex = 0
            rtArticles.Text = "Recent Articles?"
            rgArticlesLinks.Controls.Add(separator4)
            rgArticlesLinks.Controls.Add(btnArticlesHome)
            rgArticlesLinks.DialogLauncherButtonVisible = False
            rgArticlesLinks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgArticlesLinks.Id = "761d82f5-dd3b-4419-bf3c-59b9bfc3efa2?"
            rgArticlesLinks.Location = New System.Drawing.Point(4, 3)
            rgArticlesLinks.Name = "rgArticlesLinks?"
            rgArticlesLinks.Size = New System.Drawing.Size(71, 0)
            rgArticlesLinks.TabIndex = 1
            rgArticlesLinks.Text = "Links?"
            separator4.Id = "33ef12aa-ea00-48ac-a996-8cedf7775b0c?"
            separator4.Location = New System.Drawing.Point(6, 7)
            separator4.Name = "separator4?"
            separator4.Size = New System.Drawing.Size(2, -34)
            separator4.TabIndex = 5
            separator4.Text = "separator4?"
            btnArticlesHome.Id = "f261682e-385f-4fe9-bddf-807e98d37464?"
            Dim controlImageArr33 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconHome32) }
            btnArticlesHome.LargeImages.Images.AddRange(controlImageArr33)
            btnArticlesHome.Location = New System.Drawing.Point(4, -20)
            btnArticlesHome.Name = "btnArticlesHome?"
            btnArticlesHome.Size = New System.Drawing.Size(86, 0)
            btnArticlesHome.TabIndex = 6
            btnArticlesHome.Text = "Visit Home page?"
            AddHandler btnArticlesHome.Click, AddressOf btnArticlesHome_Click
            rgArticlesClose.Controls.Add(btnArticlesClose)
            rgArticlesClose.DialogLauncherButtonVisible = False
            rgArticlesClose.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgArticlesClose.Id = "35f5be2e-7a4c-4aee-8b05-956a63be2918?"
            rgArticlesClose.Location = New System.Drawing.Point(77, 3)
            rgArticlesClose.Name = "rgArticlesClose?"
            rgArticlesClose.Size = New System.Drawing.Size(54, 0)
            rgArticlesClose.TabIndex = 2
            rgArticlesClose.Text = "Close?"
            btnArticlesClose.Id = "666897f6-20c6-4d34-8867-3da5c97fe8e7?"
            Dim controlImageArr34 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconClose32) }
            btnArticlesClose.LargeImages.Images.AddRange(controlImageArr34)
            btnArticlesClose.Location = New System.Drawing.Point(4, 2)
            btnArticlesClose.Name = "btnArticlesClose?"
            btnArticlesClose.Size = New System.Drawing.Size(79, 0)
            btnArticlesClose.TabIndex = 7
            btnArticlesClose.Text = "Close this view?"
            AddHandler btnArticlesClose.Click, AddressOf btnArticlesClose_Click
            rtMyMovies.Controls.Add(rgMyMoviesOptions)
            rtMyMovies.Dock = System.Windows.Forms.DockStyle.Fill
            rtMyMovies.Id = "7aaf184a-3edb-4816-afc2-3171a83295b9?"
            rtMyMovies.KeyTip = "M?"
            rtMyMovies.Location = New System.Drawing.Point(0, 0)
            rtMyMovies.Name = "rtMyMovies?"
            rtMyMovies.Size = New System.Drawing.Size(984, 101)
            rtMyMovies.TabIndex = 0
            rtMyMovies.Text = "My Movies?"
            rgMyMoviesOptions.Controls.Add(tgMyMoviesFiles)
            rgMyMoviesOptions.Controls.Add(tgMyMoviesFolders)
            rgMyMoviesOptions.Controls.Add(separator5)
            rgMyMoviesOptions.Controls.Add(btnMyMoviesBatchDownload)
            rgMyMoviesOptions.DialogLauncherButtonVisible = False
            rgMyMoviesOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            rgMyMoviesOptions.Id = "df624166-fd1b-4e15-9119-59adb8d5227f?"
            rgMyMoviesOptions.Location = New System.Drawing.Point(4, 3)
            rgMyMoviesOptions.Name = "rgMyMoviesOptions?"
            rgMyMoviesOptions.Size = New System.Drawing.Size(173, 0)
            rgMyMoviesOptions.TabIndex = 0
            rgMyMoviesOptions.Text = "Options?"
            tgMyMoviesFiles.Id = "f58aff9e-ecbb-4b8b-a2c7-6360c187e4af?"
            Dim controlImageArr35 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconFolderMultimedia32) }
            tgMyMoviesFiles.LargeImages.Images.AddRange(controlImageArr35)
            tgMyMoviesFiles.Location = New System.Drawing.Point(4, 2)
            tgMyMoviesFiles.Name = "tgMyMoviesFiles?"
            tgMyMoviesFiles.Pressed = True
            tgMyMoviesFiles.Size = New System.Drawing.Size(57, 0)
            tgMyMoviesFiles.TabIndex = 0
            tgMyMoviesFiles.Text = "Video files?"
            tgMyMoviesFiles.UserInteractionEnabled = False
            tgMyMoviesFolders.Id = "91bf1e3e-b284-42cb-8ad1-d70881ba742c?"
            Dim controlImageArr36 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconFolder32) }
            tgMyMoviesFolders.LargeImages.Images.AddRange(controlImageArr36)
            tgMyMoviesFolders.Location = New System.Drawing.Point(63, 2)
            tgMyMoviesFolders.Name = "tgMyMoviesFolders?"
            tgMyMoviesFolders.Size = New System.Drawing.Size(70, 0)
            tgMyMoviesFolders.TabIndex = 1
            tgMyMoviesFolders.Text = "Video folders?"
            tgMyMoviesFolders.UserInteractionEnabled = False
            separator5.Id = "410ad992-4360-4bac-98f1-90e5a77b70f7?"
            separator5.Location = New System.Drawing.Point(65, 7)
            separator5.Name = "separator5?"
            separator5.Size = New System.Drawing.Size(2, -34)
            separator5.TabIndex = 2
            separator5.Text = "separator5?"
            btnMyMoviesBatchDownload.Id = "bbf625b1-e36c-447c-b016-4f4d969aac29?"
            Dim controlImageArr37 As Elegant.Ui.ControlImage() = New Elegant.Ui.ControlImage() { New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.IconTwoArrowsDown32) }
            btnMyMoviesBatchDownload.LargeImages.Images.AddRange(controlImageArr37)
            btnMyMoviesBatchDownload.Location = New System.Drawing.Point(63, -20)
            btnMyMoviesBatchDownload.Name = "btnMyMoviesBatchDownload?"
            btnMyMoviesBatchDownload.Size = New System.Drawing.Size(131, 0)
            btnMyMoviesBatchDownload.TabIndex = 3
            btnMyMoviesBatchDownload.Text = "Batch subtitle download...?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            ClientSize = New System.Drawing.Size(984, 1039)
            contextMenuExtenderProvider1.SetContextPopupMenu(Me, Nothing)
            Controls.Add(mainPanel)
            Controls.Add(statusBar)
            Controls.Add(ribbon)
            Icon = CType(componentResourceManager1.GetObject("$this.Icon?"), System.Drawing.Icon)
            MinimumSize = New System.Drawing.Size(1000, 650)
            Name = "FrmMain?"
            StartPosition = System.Windows.Forms.FormStartPosition.Manual
            AddHandler Load, AddressOf FrmMain_Load
            AddHandler HelpRequested, AddressOf FrmMain_HelpRequested
            rtSearch.EndInit()
            rtSearch.ResumeLayout(False)
            rtSearch.PerformLayout()
            rgSearchDownload.EndInit()
            rgSearchDownload.ResumeLayout(False)
            rgSearchDownload.PerformLayout()
            rgSearchFeedback.EndInit()
            rgSearchFeedback.ResumeLayout(False)
            rgSearchFeedback.PerformLayout()
            rgSearchLinking.EndInit()
            rgSearchLinking.ResumeLayout(False)
            rgSearchLinking.PerformLayout()
            rgSearchOptions.EndInit()
            rgSearchOptions.ResumeLayout(False)
            rgSearchOptions.PerformLayout()
            rtView.EndInit()
            rtView.ResumeLayout(False)
            rtView.PerformLayout()
            rgViewViews.EndInit()
            rgViewViews.ResumeLayout(False)
            rgViewViews.PerformLayout()
            rtPublish.EndInit()
            rtPublish.ResumeLayout(False)
            rtPublish.PerformLayout()
            rgPublishOptions.EndInit()
            rgPublishOptions.ResumeLayout(False)
            rgPublishOptions.PerformLayout()
            statusBar.ResumeLayout(False)
            statusBar.PerformLayout()
            statusBarNotificationsArea1.ResumeLayout(False)
            statusBarNotificationsArea1.PerformLayout()
            statusBarPane2.ResumeLayout(False)
            statusBarPane2.PerformLayout()
            statusBarPane3.ResumeLayout(False)
            statusBarPane3.PerformLayout()
            statusBarPane4.ResumeLayout(False)
            statusBarPane4.PerformLayout()
            statusBarControlsArea1.ResumeLayout(False)
            statusBarControlsArea1.PerformLayout()
            statusBarPane6.ResumeLayout(False)
            statusBarPane6.PerformLayout()
            statusBarPane1.ResumeLayout(False)
            statusBarPane1.PerformLayout()
            statusBarPane5.ResumeLayout(False)
            statusBarPane5.PerformLayout()
            cmsNC.ResumeLayout(False)
            ribbon.EndInit()
            appMenu.EndInit()
            rtProfile.EndInit()
            rtProfile.ResumeLayout(False)
            rtProfile.PerformLayout()
            rgProfile.EndInit()
            rgProfile.ResumeLayout(False)
            rgProfile.PerformLayout()
            rtSettings.EndInit()
            rtSettings.ResumeLayout(False)
            rtSettings.PerformLayout()
            rgSettingsOptions.EndInit()
            rgSettingsOptions.ResumeLayout(False)
            rgSettingsOptions.PerformLayout()
            rtAdmin.EndInit()
            rtAdmin.ResumeLayout(False)
            rtAdmin.PerformLayout()
            rgAdminOptions.EndInit()
            rtArticles.EndInit()
            rtArticles.ResumeLayout(False)
            rtArticles.PerformLayout()
            rgArticlesLinks.EndInit()
            rgArticlesLinks.ResumeLayout(False)
            rgArticlesLinks.PerformLayout()
            rgArticlesClose.EndInit()
            rgArticlesClose.ResumeLayout(False)
            rgArticlesClose.PerformLayout()
            rtMyMovies.EndInit()
            rtMyMovies.ResumeLayout(False)
            rtMyMovies.PerformLayout()
            rgMyMoviesOptions.EndInit()
            rgMyMoviesOptions.ResumeLayout(False)
            rgMyMoviesOptions.PerformLayout()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private Sub InitializePages()
            _pagePublish = New Sublight.Controls.PagePublish(Me, rtPublish)
            Sublight.FrmMain.InitPage(_pagePublish)
            _pageSearch = New Sublight.Controls.PageSearch(Me, openFileDialog, saveFileDialog, lblStatusMatchesCount, rtSearch, _pagePublish)
            Sublight.FrmMain.InitPage(_pageSearch)
            _pageView = New Sublight.Controls.PageView(Me, lblStatusMatchesCount, _pageSearch, rtView)
            Sublight.FrmMain.InitPage(_pageView)
            _pageSettings = New Sublight.Controls.PageSettings(Me, rtSettings)
            Sublight.FrmMain.InitPage(_pageSettings)
            _pageProfile = New Sublight.Controls.PageProfile(Me, rtProfile)
            Sublight.FrmMain.InitPage(_pageProfile)
            _pageMyMovies = New Sublight.Controls.PageMyMovies(Me, _pageSearch, rtMyMovies)
            Sublight.FrmMain.InitPage(_pageMyMovies)
            _pageAdmin = New Sublight.Controls.PageAdmin(Me, rtAdmin)
            Sublight.FrmMain.InitPage(_pageAdmin)
            mainPanel.SuspendLayout()
            SuspendLayout()
            mainPanel.Controls.Add(_pageSearch)
            mainPanel.Controls.Add(_pageView)
            mainPanel.Controls.Add(_pageMyMovies)
            mainPanel.Controls.Add(_pagePublish)
            mainPanel.Controls.Add(_pageSettings)
            mainPanel.Controls.Add(_pageProfile)
            mainPanel.Controls.Add(_pageAdmin)
            mainPanel.ResumeLayout(False)
            mainPanel.PerformLayout()
            ResumeLayout(False)
            PerformLayout()
            DisplayTabControl()
        End Sub

        Private Sub InitLanguage()
            Dim flag1 As Boolean = False
            Dim languageUIArr1 As Sublight.Types.LanguageUI() = Sublight.Globals.Languages
            Dim i1 As Integer = 0
            While i1 < languageUIArr1.Length
                Dim languageUI1 As Sublight.Types.LanguageUI = languageUIArr1(i1)
                If System.String.Compare(languageUI1.Id, Sublight.Properties.Settings.Default.AppLanguage, True) = 0 Then
                    flag1 = True
                    btnSelectlanguage.Text = System.String.Format("{0} {1}?", Sublight.Translation.Common_Language, languageUI1)
                    Exit While
                End If
                i1 = i1 + 1
            End While
            If Not flag1 Then
                Dim languageUIArr2 As Sublight.Types.LanguageUI() = Sublight.Globals.Languages
                Dim i2 As Integer = 0
                While i2 < languageUIArr2.Length
                    Dim languageUI2 As Sublight.Types.LanguageUI = languageUIArr2(i2)
                    If System.String.Compare(languageUI2.Id, "en-US?", True) = 0 Then
                        SelectLanguage(languageUI2)
                        Exit While
                    End If
                    i2 = i2 + 1
                End While
            End If
            Translate()
            Sublight.Globals.Events.OnLanguageChanged(Sublight.Properties.Settings.Default.AppLanguage)
        End Sub

        Private Sub InitRibbon()
            Sublight.Globals.Ribbon = ribbon
            ribbon.ApplicationButtonText = System.String.Empty
            ribbon.ApplicationButtonImages.Images.Add(New Elegant.Ui.ControlImage("Normal?", Sublight.Properties.Resources.AppButton))
            rtAdmin.Visible = False
            ctNews.Visible = False
            ribbon.CurrentTabPage = rtSearch
            ribbon.QuickAccessToolbarPlacementMode = Elegant.Ui.QuickAccessToolbarPlacementMode.Hidden
            ribbon.Minimized = Sublight.Properties.Settings.Default.App_RibbonMinimized
            _lblAppMenuRight = New Sublight.FrmMain.AppMenuRight
            _lblAppMenuRight.Padding = New System.Windows.Forms.Padding(5)
            _lblAppMenuRight.Text = System.String.Empty
            _lblAppMenuRight.UseVisualThemeForBackground = False
            appMenu.RightPaneControl = _lblAppMenuRight
            Dim control1 As Elegant.Ui.Control 
            For Each control1 In appMenu.Items
                AddHandler control1.MouseMove, AddressOf appMenuItem_MouseMove
            Next
            AddHandler appMenu.Showing, AddressOf appMenu_Showing
            AddHandler ribbon.CurrentTabPageChanged, AddressOf ribbon_CurrentTabPageChanged
        End Sub

        Private Sub lblStatusUser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Sublight.BaseForm.IsAnonymous Then
                Dim frmLogIn1 As Sublight.FrmLogIn = New Sublight.FrmLogIn
                If (frmLogIn1.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK) OrElse Sublight.BaseForm.Session = System.Guid.Empty Then
                    Return
                End If
                FillLogoutName()
                Return
            End If
            _pageProfile.ShowMyContributions()
        End Sub

        Private Sub LoadAppWithSplash()
            Dim flag3 As Boolean

            Using frmSplash1 As Sublight.FrmSplash = Nothing
                Visible = False
                AddHandler Sublight.Globals.Events.UserLogIn, AddressOf Events_UserLogIn
                AddHandler Sublight.Globals.Events.UserLogOff, AddressOf Events_UserLogOff
                AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
                Dim flag1 As Boolean = False
                Dim flag2 As Boolean = False
                If Sublight.Properties.Settings.Default.CheckForOldSettings Then
                    Try
                        Dim obj1 As Object = Sublight.Properties.Settings.Default.GetPreviousVersion("AskRegisterShellMenu?")
                        flag3 = Not (obj1) Is Nothing
                    Catch 
                        flag3 = False
                    End Try
                    If flag3 AndAlso (ShowQuestion(Sublight.Translation.MessageBox_Question_UseSettingsFromPreviousVersion, New object(0) {}) = System.Windows.Forms.DialogResult.Yes) Then
                        Sublight.Properties.Settings.Default.Upgrade()
                    Else 
                        flag1 = True
                    End If
                    Sublight.Properties.Settings.Default.CheckForOldSettings = False
                    flag2 = True
                End If
                If Sublight.Properties.Settings.Default.UserId = System.Guid.Empty Then
                    Sublight.Properties.Settings.Default.UserId = System.Guid.NewGuid()
                    flag2 = True
                End If
                If Not Sublight.MyUtility.Encryption.IsPasswordEncrypted(Sublight.Properties.Settings.Default.LogIn_Password) Then
                    Sublight.Properties.Settings.Default.LogIn_Password = Sublight.MyUtility.Encryption.EncryptPassword(Sublight.Properties.Settings.Default.LogIn_Password)
                    flag2 = True
                End If
                If flag2 Then
                    SaveUserSettings()
                End If
                frmSplash1 = New Sublight.FrmSplash
                frmSplash1.Show(Me)
                While Not frmSplash1.IsDone
                    System.Threading.Thread.Sleep(50)
                    System.Windows.Forms.Application.DoEvents()
                End While
                If Sublight.BaseForm.Session = System.Guid.Empty Then
                    System.Windows.Forms.Application.Exit()
                    Return
                End If
                FillLogoutName()
                System.Windows.Forms.ToolStripManager.Renderer = New Sublight.Controls.Office2007Renderer.Office2007Renderer
                frmSplash1.SetPercentage(100)
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(250)
                frmSplash1.Close()
                If flag1 Then
                    Dim frmWizardSettings1 As Sublight.FrmWizardSettings = New Sublight.FrmWizardSettings(Me, True)
                    frmWizardSettings1.ShowDialog(Me)
                    frmWizardSettings1.Dispose()
                    If ShowQuestion(Sublight.Translation.Application_Question_DisplayQuickHelp, New object(0) {}) = System.Windows.Forms.DialogResult.Yes Then
                        ShowQuickHelp()
                    End If
                End If
                timerOnlineUsers.Interval = 600000
                timerOnlineUsers_Tick(Me, Nothing)
                AddHandler timerOnlineUsers.Tick, AddressOf timerOnlineUsers_Tick
                timerOnlineUsers.Start()
            End Using
        End Sub

        Private Sub LoadRss()
            System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(LoadRssThread))
        End Sub

        Private Sub LoadRssThread(ByVal stateInfo As Object)
            Dim methodInvoker4 As System.Windows.Forms.MethodInvoker = Nothing
            Try
                Dim s1 As String = Sublight.Globals.GetHomePageAbsoluteUrl("Home.aspx?feed=RSS&Type=Recent?")
                Sublight.Program.InitLanguage()
                Using webClient1 As System.Net.WebClient = New System.Net.WebClient
                    Dim s2 As String = webClient1.DownloadString(s1)
                    Dim xmlDocument1 As System.Xml.XmlDocument = New System.Xml.XmlDocument
                    xmlDocument1.LoadXml(s2)
                    Dim xmlNodeList1 As System.Xml.XmlNodeList = xmlDocument1.SelectNodes("/rss/channel/item?")
                    If Not (xmlNodeList1) Is Nothing Then
                        Dim <>c__DisplayClass38_1 As Sublight.FrmMain.<>c__DisplayClass38 = New Sublight.FrmMain.<>c__DisplayClass38
                        <>c__DisplayClass38_1.<>4__this = Me
                        Dim i1 As Integer = xmlNodeList1.Count
                        If i1 > 5 Then
                            i1 = 5
                        End If
                        <>c__DisplayClass38_1.nodes = New System.Collections.Generic.List(Of System.Xml.XmlNode)
                        Dim i2 As Integer = 0
                        While i2 < i1
                            Dim xmlNode1 As System.Xml.XmlNode = xmlNodeList1(i2)
                            <>c__DisplayClass38_1.nodes.Add(xmlNode1)
                            i2 = i2 + 1
                        End While
                        <>c__DisplayClass38_1.existingControls = New System.Collections.Generic.List(Of System.Windows.Forms.Control)
                        Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass38_1.<LoadRssThread>b__34)
                        Sublight.BaseForm.DoCtrlInvoke(rgArticlesLinks, Me, methodInvoker1, True)
                        Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass38_1.<LoadRssThread>b__35)
                        Sublight.BaseForm.DoCtrlInvoke(rgArticlesLinks, Me, methodInvoker2, True)
                        If <>c__DisplayClass38_1.nodes.get_Count() > 0 Then
                            If (methodInvoker4) Is Nothing Then
                                methodInvoker4 = New System.Windows.Forms.MethodInvoker(<LoadRssThread>b__36)
                            End If
                            Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = methodInvoker4
                            Sublight.BaseForm.DoCtrlInvoke(ribbon, Me, methodInvoker3)
                            Dim s3 As String = <>c__DisplayClass38_1.nodes.get_Item(0).SelectSingleNode("link?").InnerText
                            If Sublight.Properties.Settings.Default.Search_RSS_LastNews <> s3 Then
                                NewsNotifyUser()
                            End If
                        End If
                    End If
                End Using
            Catch 
            End Try
        End Sub

        Private Sub nc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
            NC_Show()
        End Sub

        Private Sub NC_Show()
            Show()
            WindowState = System.Windows.Forms.FormWindowState.Normal
        End Sub

        Private Sub NewsNotifyUser()
            System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(NewsNotifyUserThread))
        End Sub

        Private Sub NewsNotifyUserThread(ByVal stateInfo As Object)
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<NewsNotifyUserThread>b__32)
            While Not Sublight.Globals.Exiting AndAlso Not _stopRssAnimation
                System.Threading.Thread.Sleep(750)
                Sublight.BaseForm.DoCtrlInvoke(ribbon, Me, methodInvoker1)
            End While
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<NewsNotifyUserThread>b__33)
            Sublight.BaseForm.DoCtrlInvoke(ribbon, Me, methodInvoker2)
        End Sub

        Private Sub ribbon_CurrentTabPageChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            DisplayTabControl()
        End Sub

        Private Sub ribbon_HelpButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowAboutBox()
        End Sub

        Private Sub ribbon_MinimizedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Sublight.Properties.Settings.Default.App_RibbonMinimized = ribbon.Minimized
            Sublight.BaseForm.SaveUserSettingsSilent()
        End Sub

        Private Sub rtPublish_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            If Not Sublight.BaseForm.IsAnonymous Then
                Return
            End If
            Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString(Sublight.Translation.Publish_Toolbar_NoticeNotLoggedId, Font)
            e.Graphics.DrawString(Sublight.Translation.Publish_Toolbar_NoticeNotLoggedId, Font, System.Drawing.SystemBrushes.ControlText, CSng(rtPublish.Width) - sizeF1.Width - 10.0F, (CSng(rtPublish.Height) / 2.0F) - (sizeF1.Height / 2.0F))
        End Sub

        Private Sub RunSublightCmd(ByVal args As String)
            Sublight.FrmMain.RunSublightCmd(Me, args, _pageSearch)
        End Sub

        Private Sub sc_GetOnlineSublightUsersCompleted(ByVal sender As Object, ByVal e As Sublight.WS_SublightClient.GetOnlineSublightUsersCompletedEventArgs)
            Dim methodInvoker5 As System.Windows.Forms.MethodInvoker = Nothing
            Dim methodInvoker6 As System.Windows.Forms.MethodInvoker = Nothing
            Dim methodInvoker7 As System.Windows.Forms.MethodInvoker = Nothing
            Try
                Dim <>c__DisplayClass44_1 As Sublight.FrmMain.<>c__DisplayClass44 = New Sublight.FrmMain.<>c__DisplayClass44
                <>c__DisplayClass44_1.<>4__this = Me
                If (Not (e.Error) Is Nothing) OrElse Not e.Result Then
                    If (methodInvoker5) Is Nothing Then
                        methodInvoker5 = New System.Windows.Forms.MethodInvoker(<sc_GetOnlineSublightUsersCompleted>b__3d)
                    End If
                    Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker5
                    Sublight.BaseForm.DoCtrlInvoke(lblStatusOnlineUsers, Me, methodInvoker1)
                    Return
                End If
                _onlineUsers = e.numberOfUsers
                If _onlineUsers >= 0 Then
                    <>c__DisplayClass44_1.text = System.String.Format(Sublight.Translation.Common_Status_OnlineUsers, _onlineUsers)
                Else 
                    <>c__DisplayClass44_1.text = System.String.Format(Sublight.Translation.Common_Status_OnlineUsers, "????")
                End If
                Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass44_1.<sc_GetOnlineSublightUsersCompleted>b__3e)
                Sublight.BaseForm.DoCtrlInvoke(lblStatusOnlineUsers, Me, methodInvoker2)
            Catch 
                If (methodInvoker6) Is Nothing Then
                    methodInvoker6 = New System.Windows.Forms.MethodInvoker(<sc_GetOnlineSublightUsersCompleted>b__3f)
                End If
                Dim methodInvoker3 As System.Windows.Forms.MethodInvoker = methodInvoker6
                Sublight.BaseForm.DoCtrlInvoke(lblStatusOnlineUsers, Me, methodInvoker3)
            Finally
                timerOnlineUsers.Enabled = True
                If (methodInvoker7) Is Nothing Then
                    methodInvoker7 = New System.Windows.Forms.MethodInvoker(<sc_GetOnlineSublightUsersCompleted>b__40)
                End If
                Dim methodInvoker4 As System.Windows.Forms.MethodInvoker = methodInvoker7
                Sublight.BaseForm.DoCtrlInvoke(lblStatusOnlineUsers, Me, methodInvoker4)
            End Try
        End Sub

        Friend Sub SelectLanguage(ByVal language As Sublight.Types.LanguageUI)
            Try
                ShowLoader(Me)
                Dim cultureInfo1 As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(language.Id)
                Dim cultureInfo2 As System.Globalization.CultureInfo = cultureInfo1
                Sublight.Translation.Culture = cultureInfo1
                System.Windows.Forms.Application.CurrentCulture = cultureInfo1
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo2
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo1
                ApplyRightToLeft()
                Sublight.BaseForm.ApplyLanguage()
                Translate()
                Sublight.Globals.Events.OnLanguageChanged(cultureInfo1.Name)
                ResumeLayout(False)
                If System.String.Compare(Sublight.Properties.Settings.Default.AppLanguage, cultureInfo1.Name, True) <> 0 Then
                    Sublight.BaseForm.UpdateAppLanguage("Sublight.FrmMain.SelectLanguage?", cultureInfo1.Name)
                    SaveUserSettings()
                End If
                btnSelectlanguage.Text = System.String.Format("{0} {1}?", Sublight.Translation.Common_Language, language)
            Finally
                HideLoader(Me)
            End Try
        End Sub

        Private Sub SetLogoutText()
            Dim s1 As String = TryCast(btnAppLogin.Tag, string)
            If s1 = "LogIn?" Then
                btnAppLogin.Text = Sublight.Translation.Common_Login
                Return
            End If
            If s1 = "LogOff?" Then
                btnAppLogin.Text = System.String.Format(Sublight.Translation.Common_Logoff, _currentUserDisplayName)
            End If
        End Sub

        Private Sub SetStatusAnonymousUser()
            Dim nullable1 As System.Nullable(Of Double)

            nullable1 = New System.Nullable(Of Double)[]
            SetStatusMessage(Sublight.Translation.Common_Status_AnonymousUser, nullable1)
        End Sub

        Private Sub SetStatusMessage(ByVal text As String, ByVal points As System.Nullable(Of Double))
            Dim <>c__DisplayClass30_1 As Sublight.FrmMain.<>c__DisplayClass30 = New Sublight.FrmMain.<>c__DisplayClass30
            <>c__DisplayClass30_1.text = text
            <>c__DisplayClass30_1.points = points
            <>c__DisplayClass30_1.<>4__this = Me
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass30_1.<SetStatusMessage>b__2f)
            Sublight.BaseForm.DoCtrlInvoke(lblStatusUser, Me, methodInvoker1)
        End Sub

        Private Sub SetStatusRegisteredUser()
            Dim d1 As Double
            Dim nullable1 As System.Nullable(Of Double)

            Dim s1 As String = IIf(System.String.IsNullOrEmpty(Sublight.BaseForm.Username), "????", Sublight.BaseForm.Username)
            Dim s2 As String = System.String.Format(Sublight.Translation.Common_Status_RegisteredUser, s1)
            Dim s3 As String = Sublight.BaseForm.GetSetting("UserPoints?")
            nullable1 = New System.Nullable(Of Double)[]
            If Not System.String.IsNullOrEmpty(s3) Then
                Dim cultureInfo1 As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US?")
                If System.Double.TryParse(s3, System.Globalization.NumberStyles.Number, cultureInfo1, ByRef d1) Then
                    nullable1 = New System.Nullable(Of Double)(d1)
                End If
            End If
            SetStatusMessage(s2, nullable1)
        End Sub

        Private Sub ShowAboutBox()
            Dim frmAbout1 As Sublight.FrmAbout = New Sublight.FrmAbout
            frmAbout1.ShowDialog(Me)
            frmAbout1.Dispose()
        End Sub

        Private Sub ShowQuickHelp()
            OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl("wiki/Help-Sublight.ashx?"))
        End Sub

        Friend Sub SwitchTab(ByVal tab As Sublight.FrmMain.RibbonTab)
            If tab = Sublight.FrmMain.RibbonTab.Publish Then
                ribbon.CurrentTabPage = rtPublish
                Return
            End If
            If tab = Sublight.FrmMain.RibbonTab.Profile Then
                ribbon.CurrentTabPage = rtProfile
                Return
            End If
            If tab = Sublight.FrmMain.RibbonTab.Search Then
                ribbon.CurrentTabPage = rtSearch
            End If
        End Sub

        Private Sub timerOnlineUsers_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            If IsDisposed Then
                Return
            End If
            timerOnlineUsers.Enabled = False
            lblStatusOnlineUsers.DefaultSmallImage = Sublight.Properties.Resources.Loading
            System.Windows.Forms.Application.DoEvents()
            Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                AddHandler sublightClient1.GetOnlineSublightUsersCompleted, AddressOf sc_GetOnlineSublightUsersCompleted
                sublightClient1.GetOnlineSublightUsersAsync(Sublight.BaseForm.Session)
            End Using
        End Sub

        Private Sub Translate()
            SetLogoutText()
            ribbon.HelpButtonScreenTip.Text = Sublight.Translation.Common_Help
            btnWebPage.Text = Sublight.Translation.Common_Status_WebSite
            lblStatusOnlineUsers.Text = System.String.Format(Sublight.Translation.Common_Status_OnlineUsers, _onlineUsers)
            rtSearch.Text = Sublight.Translation.Search_Title
            rtView.Text = Sublight.Translation.View_Title
            rtMyMovies.Text = Sublight.Translation.MyMovies_Title
            rtProfile.Text = Sublight.Translation.Profile_Title
            rtSettings.Text = Sublight.Translation.Settings_Title
            rtPublish.Text = Sublight.Translation.Publish_Title
            rtArticles.Text = Sublight.Translation.RecentArticles_Title
            ctOptions.Caption = Sublight.Translation.ContextTab_Options_Title
            ctNews.Caption = Sublight.Translation.ContextTab_News_Title
            rgSearchDownload.Text = Sublight.Translation.Search_Group_Download_Title
            rgSearchFeedback.Text = Sublight.Translation.Search_Group_Feedback_Title
            rgSearchLinking.Text = Sublight.Translation.Search_Group_Linking_Title
            rgSearchOptions.Text = Sublight.Translation.Common_Group_Options_Title
            rgViewViews.Text = Sublight.Translation.View_Group_Views_Title
            rgMyMoviesOptions.Text = Sublight.Translation.Common_Group_Options_Title
            rgPublishOptions.Text = Sublight.Translation.Common_Group_Options_Title
            rgProfile.Text = Sublight.Translation.Common_Group_Options_Title
            rgSettingsOptions.Text = Sublight.Translation.Common_Group_Options_Title
            rgAdminOptions.Text = Sublight.Translation.Common_Group_Options_Title
            rgArticlesLinks.Text = Sublight.Translation.RecentArticles_Group_Links_Title
            rgArticlesClose.Text = Sublight.Translation.RecentArticles_Group_Close_Title
            btnArticlesHome.Text = Sublight.Translation.RecentArticles_Button_HomePage
            btnArticlesClose.Text = Sublight.Translation.RecentArticles_Button_Close
            If Sublight.BaseForm.IsAnonymous Then
                SetStatusAnonymousUser()
            Else 
                SetStatusRegisteredUser()
            End If
            Text = System.String.Format(Sublight.Translation.Common_Title, "2?")
            If Sublight.Globals.EditionType = Sublight.Types.SpecialEdition.PodnapisiNET Then
                Text = Text + System.String.Format(" // Podnapisi.NET?", New object(0) {})
            End If
            nc.Text = Text
        End Sub

        Friend Sub UpdatePoints(ByVal dblUserPoints As Double)
            If Sublight.BaseForm.IsAnonymous Then
                Return
            End If
            Dim s1 As String = IIf(System.String.IsNullOrEmpty(Sublight.BaseForm.Username), "????", Sublight.BaseForm.Username)
            Dim s2 As String = System.String.Format(Sublight.Translation.Common_Status_RegisteredUser, s1)
            SetStatusMessage(s2, New System.Nullable(Of Double)(dblUserPoints))
        End Sub

        Private Sub ws_GetUserBySessionCompleted(ByVal sender As Object, ByVal e As Sublight.WS.GetUserBySessionCompletedEventArgs)
            Try
                If e.Result Then
                    _currentUserDisplayName = e.user.DisplayName
                    SetLogoutText()
                Else 
                    _currentUserDisplayName = Nothing
                    SetLogoutText()
                End If
            Catch 
                _currentUserDisplayName = Nothing
                SetLogoutText()
            End Try
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
            MyBase.OnClosing(e)
            Sublight.Globals.Exiting = True
        End Sub

        Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            MyBase.OnKeyDown(e)
            If e.Alt AndAlso (e.KeyCode = System.Windows.Forms.Keys.Home) Then
                OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl())
                Return
            End If
            If e.Control AndAlso e.Shift AndAlso (e.KeyCode = System.Windows.Forms.Keys.D) Then
                Sublight.Globals.DebugMode = Not Sublight.Globals.DebugMode
                If Sublight.Globals.DebugMode Then
                    Sublight.Globals.DebugWriteLine("Sublight debug console?", New object(0) {})
                    Sublight.Globals.DebugWriteLine("(click on Sublight and press Ctrl + Shift + D to close this window)?", New object(0) {})
                    Sublight.Globals.DebugWriteLine(System.String.Empty, New object(0) {})
                    Return
                End If
                Sublight.Globals.DebugWriteLine(System.String.Empty, New object(0) {})
            End If
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            If Not (nc) Is Nothing Then
                If (WindowState = System.Windows.Forms.FormWindowState.Minimized) AndAlso Sublight.Properties.Settings.Default.App_MinimizeToTray Then
                    nc.Visible = True
                    Hide()
                    Return
                End If
                If nc.Visible Then
                    nc.Visible = False
                End If
            End If
        End Sub

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            MyBase.WndProc(ByRef m)
            If (m.Msg = 74) AndAlso Sublight.Properties.Settings.Default.SingleInstanceApplication Then
                Try
                    Dim copydatastruct1 As Sublight.MyUtility.Win32.COPYDATASTRUCT = DirectCast(System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, GetType(Sublight.MyUtility.Win32.COPYDATASTRUCT)), Sublight.MyUtility.Win32.COPYDATASTRUCT)
                    Dim bArr1 As Byte() = New byte(System.Convert.ToInt32(copydatastruct1.cbData)) {}
                    System.Runtime.InteropServices.Marshal.Copy(copydatastruct1.lpData, bArr1, 0, System.Convert.ToInt32(copydatastruct1.cbData))
                    Using memoryStream1 As System.IO.MemoryStream = New System.IO.MemoryStream(bArr1)
                        Dim binaryFormatter1 As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                        Dim s1 As String = CType(binaryFormatter1.Deserialize(memoryStream1), string)
                        If Not (s1) Is Nothing Then
                            s1 = s1.Trim()
                            If (Not (_pageSearch) Is Nothing) AndAlso (s1.Length > 0) Then
                                SwitchTab(Sublight.FrmMain.RibbonTab.Search)
                                Refresh()
                                System.Windows.Forms.Application.DoEvents()
                                _pageSearch.PerformSearch(s1, True)
                            End If
                        End If
                    End Using
                Catch 
                End Try
            End If
        End Sub

        Private Shared Sub InitPage(ByVal page As Sublight.Controls.BasePage)
            page.Dock = System.Windows.Forms.DockStyle.Fill
            page.Visible = False
        End Sub

        Friend Shared Sub RunSublightCmd(ByVal form As Sublight.BaseForm, ByVal args As String, ByVal ctrlSearch As Sublight.Controls.BasePage)
            Dim processModule1 As System.Diagnostics.ProcessModule = System.Diagnostics.Process.GetCurrentProcess().MainModule
            If (processModule1) Is Nothing Then
                Return
            End If
            If (processModule1.FileName) Is Nothing Then
                Return
            End If
            Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(processModule1.FileName)
            If (fileInfo1.Directory) Is Nothing Then
                Return
            End If
            Dim s1 As String = System.IO.Path.Combine(fileInfo1.Directory.FullName, "SublightCmd.exe?")
            Dim s2 As String = Nothing
            Try
                If (Not (ctrlSearch) Is Nothing) AndAlso Not ctrlSearch.IsDisposed AndAlso ctrlSearch.Visible Then
                    Dim pageSearch1 As Sublight.Controls.PageSearch = TryCast(ctrlSearch, Sublight.Controls.PageSearch)
                    If (Not (pageSearch1) Is Nothing) AndAlso Not System.String.IsNullOrEmpty(pageSearch1.SelectedVideo) AndAlso System.IO.File.Exists(pageSearch1.SelectedVideo) Then
                        Dim fileInfo2 As System.IO.FileInfo = New System.IO.FileInfo(pageSearch1.SelectedVideo)
                        If Not (fileInfo2.Directory) Is Nothing Then
                            s2 = fileInfo2.Directory.FullName
                        End If
                    End If
                End If
            Catch e As System.Exception
                s2 = Nothing
            End Try
            If System.String.IsNullOrEmpty(s2) Then
                s2 = fileInfo1.Directory.FullName
            End If
            Try
                Dim processStartInfo1 As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo("cmd.exe?", System.String.Format("/k echo ""{1}"" {2} && ""{1}"" {2} && set path=%path%;{0}?", fileInfo1.Directory.FullName, s1, args))
                processStartInfo1.WorkingDirectory = s2
                System.Diagnostics.Process.Start(processStartInfo1)
            Catch e As System.Exception
                If (Not (form) Is Nothing) AndAlso Not form.IsDisposed Then
                    form.ShowError(System.String.Format("{0}?", e.Message), New object(0) {})
                End If
            End Try
        End Sub

    End Class ' class FrmMain

End Namespace

