Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Sublight.Controls.Button
Imports Sublight.MyUtility
Imports Sublight.Plugins.Core
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS
Imports Sublight.WS_SublightClient
Imports VistaStyleProgressBar

Namespace Sublight

    Public NotInheritable Class FrmSplash
        Inherits Sublight.BaseForm

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass2

            Public <>4__this As Sublight.FrmSplash 
            Public percentage As Integer 

            Public Sub New()
            End Sub

            Public Sub <SetPercentage>b__1()
                <>4__this.progressBar1.Value = percentage
            End Sub

        End Class ' class <>c__DisplayClass2

        Private Shared ReadOnly m_BackColor As System.Drawing.Color 
        Private Shared ReadOnly m_BorderColor As System.Drawing.Color 

        Private _currentAction As String 
        Private _fontHeight As Integer 
        Private _fontVersion As System.Drawing.Font 
        Private _version As String 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <IsDone>k__BackingField As Boolean 
        Private btnClose As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private m_BorderPen As System.Drawing.Pen 
        Private m_LinePen As System.Drawing.Pen 
        Private progressBar1 As VistaStyleProgressBar.ProgressBar 

        Private Shared m_username As String 

        Public Property IsDone As Boolean
            Get
                Return <IsDone>k__BackingField
            End Get
            Set
                <IsDone>k__BackingField = value
            End Set
        End Property

        Public Sub New()
            _fontHeight = -1
            m_BorderPen = New System.Drawing.Pen(Sublight.FrmSplash.m_BorderColor, 2.0F)
            m_LinePen = New System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml("#869FEC?"))
            _fontVersion = New System.Drawing.Font("Microsoft Sans Serif?", 10.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238)
            InitializeComponent()
            _version = Sublight.BaseForm.AppVersion
            Width = Sublight.Properties.Resources.Splash.Width
            Height = Sublight.Properties.Resources.Splash.Height
            progressBar1.Top = 190
            progressBar1.Left = 15
            progressBar1.Width = Width - (2 * progressBar1.Left)
            progressBar1.Height = Height - progressBar1.Top - 9
            btnClose.Left = Width - btnClose.Width - 10
            btnClose.Top = Height - btnClose.Height - 10
            progressBar1.Value = 0
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.DoubleBuffer, True)
            UpdateStyles()
            ApplyRightToLeft()
            Sublight.BaseForm.ApplyLanguage()
            btnClose.Visible = False
            btnClose.Text = Sublight.Translation.Common_Button_Close
            AddHandler Sublight.Globals.Events.UserLogIn, AddressOf Sublight.FrmSplash.Events_UserLogIn
            Visible = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        End Sub

        Shared Sub New()
            Sublight.FrmSplash.m_BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FC?")
            Sublight.FrmSplash.m_BorderColor = System.Drawing.ColorTranslator.FromHtml("#1D234E?")
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <UpdateCurrentAction>b__0()
            Invalidate()
        End Sub

        Private Sub AnonymousLoginFailed(ByVal error As String)
            UpdateCurrentAction(Sublight.Translation.Connect_Error_AnonymousLoginFailed)
            btnClose.Enabled = True
            btnClose.Visible = True
            progressBar1.Visible = False
            ShowErrorDescription(error)
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            IsDone = True
        End Sub

        Private Sub FrmConnect_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            System.Windows.Forms.Application.DoEvents()
            ApplyRightToLeft()
            Sublight.BaseForm.ApplyLanguage()
            Sublight.FrmSplash.InitWebService()
            progressBar1.Value = 10
            Sublight.Plugins.Core.Globals.OnInit(Sublight.Globals.GetHomePageAbsoluteUrl("SubtitlesClient.asmx?"))
            If Sublight.Properties.Settings.Default.LogIn_RememberMe AndAlso Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.LogIn_Username) AndAlso Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.LogIn_Password) Then
                UpdateCurrentAction(System.String.Format(Sublight.Translation.Connect_AutoLogin, Sublight.Properties.Settings.Default.LogIn_Username))
                Dim objArr1 As Object() = New object() { _
                                                         Sublight.Properties.Settings.Default.LogIn_Username, _
                                                         Sublight.BaseForm.ToHash(Sublight.MyUtility.Encryption.DecryptPassword(Sublight.Properties.Settings.Default.LogIn_Password)), _
                                                         Sublight.BaseForm.ClientInfo }
                Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_FRM_CONNECT_LOAD, Me, Me, objArr1)
                webServiceHandler1.DisplayLoader = False
                AddHandler webServiceHandler1.DoCall, AddressOf Sublight.FrmSplash.wsh_DoCallLogIn
                AddHandler webServiceHandler1.OnResult, AddressOf wsh_OnResultLogIn
                AddHandler webServiceHandler1.OnException, AddressOf wsh_OnException
                webServiceHandler1.RunWorkerAsync()
                Return
            End If
            UpdateCurrentAction(Sublight.Translation.Connect_AnonymousLogin)
            Dim objArr2 As Object() = New object() { Sublight.BaseForm.ClientInfo }
            Dim webServiceHandler2 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_FRM_CONNECT_LOAD, Me, Me, objArr2)
            webServiceHandler2.DisplayLoader = False
            AddHandler webServiceHandler2.DoCall, AddressOf Sublight.FrmSplash.wsh_DoCallLogInAnonymous
            AddHandler webServiceHandler2.OnResult, AddressOf wsh_OnResultLogInAnonymous
            AddHandler webServiceHandler2.OnException, AddressOf wsh_OnException
            webServiceHandler2.RunWorkerAsync()
        End Sub

        Private Sub InitializeComponent()
            btnClose = New Sublight.Controls.Button.Button
            progressBar1 = New VistaStyleProgressBar.ProgressBar
            SuspendLayout()
            btnClose.AutoResize = False
            btnClose.DialogResult = System.Windows.Forms.DialogResult.None
            btnClose.Enabled = False
            btnClose.Location = New System.Drawing.Point(256, 146)
            btnClose.Name = "btnClose?"
            btnClose.Size = New System.Drawing.Size(75, 23)
            btnClose.TabIndex = 0
            btnClose.Text = "Zapri?"
            btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            AddHandler btnClose.Click, AddressOf btnClose_Click
            progressBar1.BackColor = System.Drawing.Color.Transparent
            progressBar1.EndColor = System.Drawing.Color.FromArgb(0, 163, 211)
            progressBar1.Location = New System.Drawing.Point(8, 148)
            progressBar1.Name = "progressBar1?"
            progressBar1.Size = New System.Drawing.Size(323, 23)
            progressBar1.StartColor = System.Drawing.Color.FromArgb(0, 163, 211)
            progressBar1.TabIndex = 22
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.White
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            ClientSize = New System.Drawing.Size(339, 178)
            ControlBox = False
            Controls.Add(progressBar1)
            Controls.Add(btnClose)
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Name = "FrmConnect?"
            ShowInTaskbar = False
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            AddHandler Load, AddressOf FrmConnect_Load
            ResumeLayout(False)
        End Sub

        Private Function IsNewVersionRequired(ByVal error As String) As Boolean
            If error = Sublight.Types.WS_Errors.NewVersionRequired Then
                ShowInfo(Sublight.Translation.Connect_Info_NewVersionIsRequired, New object(0) {})
                Return True
            End If
            Return False
        End Function

        Private Sub LogInAnonymousHandler(ByVal session As System.Guid, ByVal settings As String(), ByVal error As String)
            If session <> System.Guid.Empty Then
                InitSession(Nothing, True, session, System.Guid.Empty, Nothing, Nothing, settings)
                Sublight.Globals.Events.OnUserLogIn(Sublight.BaseForm.IsAnonymous)
                OnSuccessfulLogin()
                Return
            End If
            AnonymousLoginFailed(error)
        End Sub

        Private Sub LogInFailed(ByVal error As String)
            UpdateCurrentAction(Sublight.Translation.Connect_Error_AutoLoginFailed)
            btnClose.Enabled = True
            btnClose.Visible = True
            progressBar1.Visible = False
            ShowErrorDescription(error)
        End Sub

        Private Sub OnSuccessfulLogin()
            progressBar1.Value = 50
            UpdateCurrentAction(Sublight.Translation.Connect_LoadingMainForm)
            IsDone = True
        End Sub

        Private Sub RetryWithAnonymousLogin()
            If ShowQuestion(Sublight.Translation.Connect_Question_TryAnonymousLogin, New object(0) {}) = System.Windows.Forms.DialogResult.Yes Then
                UpdateCurrentAction(Sublight.Translation.Connect_AnonymousLogin)
                Dim objArr1 As Object() = New object() { Sublight.BaseForm.ClientInfo }
                Dim webServiceHandler1 As Sublight.MyUtility.WebServiceHandler = New Sublight.MyUtility.WebServiceHandler(Sublight.Globals.WSH_CONTEXT_FRM_CONNECT_RETRY_ANON, Me, Me, objArr1)
                webServiceHandler1.DisplayLoader = False
                AddHandler webServiceHandler1.DoCall, AddressOf Sublight.FrmSplash.wsh_DoCallLogInAnonymous
                AddHandler webServiceHandler1.OnResult, AddressOf wsh_OnResultLogInAnonymous
                AddHandler webServiceHandler1.OnException, AddressOf wsh_OnException
                webServiceHandler1.RunWorkerAsync()
                Return
            End If
            LogInFailed(Nothing)
        End Sub

        Public Sub SetPercentage(ByVal percentage As Integer)
            SetPercentage(percentage, Nothing)
        End Sub

        Public Sub SetPercentage(ByVal percentage As Integer, ByVal text As String)
            Dim <>c__DisplayClass2_1 As Sublight.FrmSplash.<>c__DisplayClass2 = New Sublight.FrmSplash.<>c__DisplayClass2
            <>c__DisplayClass2_1.percentage = percentage
            <>c__DisplayClass2_1.<>4__this = Me
            If (<>c__DisplayClass2_1.percentage < 0) OrElse (<>c__DisplayClass2_1.percentage > 100) Then
                Return
            End If
            If Not System.String.IsNullOrEmpty(text) Then
                UpdateCurrentAction(text)
                System.Windows.Forms.Application.DoEvents()
            End If
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass2_1.<SetPercentage>b__1)
            Sublight.BaseForm.DoCtrlInvoke(progressBar1, Me, methodInvoker1)
        End Sub

        Private Sub ShowErrorDescription(ByVal error As String)
            If System.String.IsNullOrEmpty(error) Then
                Return
            End If
            If error = Sublight.Types.WS_Errors.NewVersionRequired Then
                ShowInfo(Sublight.Translation.Connect_Info_NewVersionIsRequired, New object(0) {})
                Return
            End If
            Dim objArr1 As Object() = New object() { error }
            ShowError(Sublight.Translation.Connect_ErrorOccured, objArr1)
        End Sub

        Private Sub UpdateCurrentAction(ByVal text As String)
            _currentAction = text
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<UpdateCurrentAction>b__0)
            Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
        End Sub

        Private Sub wsh_OnException(ByVal ex As System.Exception)
            Dim s1 As String = Sublight.FrmSplash.GetServerMessage()
            If System.String.IsNullOrEmpty(s1) Then
                Dim objArr1 As Object() = New object() { ex.Message }
                ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
            Else 
                Dim objArr2 As Object() = New object() { s1 }
                ShowError(Sublight.Translation.Application_Error_WebException, objArr2)
            End If
            IsDone = True
        End Sub

        Private Sub wsh_OnResultLogIn(ByVal result As Object())
            Try
                If ((result) Is Nothing) OrElse (result.Length <= 0) Then
                    Return
                End If
                Dim guid1 As System.Guid = DirectCast(result(0), System.Guid)
                Dim s1 As String = CType(result(5), string)
                If IsNewVersionRequired(s1) Then
                    IsDone = True
                    Return
                End If
                If guid1 = System.Guid.Empty Then
                    If s1 = "WrongUsernameOrPassword?" Then
                        Sublight.Properties.Settings.Default.LogIn_Password = System.String.Empty
                        Sublight.BaseForm.SaveUserSettingsSilent()
                    End If
                    UpdateCurrentAction(System.String.Format(Sublight.Translation.Connect_Error_AutoLoginFailed, IIf(System.String.IsNullOrEmpty(s1), "Error?", s1)))
                    RetryWithAnonymousLogin()
                Else 
                    Dim guid2 As System.Guid = DirectCast(result(1), System.Guid)
                    Dim sArr1 As String() = CType(result(2), String[])
                    Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = CType(result(3), Sublight.WS.SubtitleLanguage[])
                    Dim sArr2 As String() = CType(result(4), String[])
                    InitSession(Sublight.FrmSplash.m_username, False, guid1, guid2, sArr1, subtitleLanguageArr1, sArr2)
                    Sublight.Globals.Events.OnUserLogIn(Sublight.BaseForm.IsAnonymous)
                    OnSuccessfulLogin()
                End If
            Catch e As System.Exception
                Sublight.BaseForm.ReportException("WinUI.FrmConnect.wsh_OnResultLogIn?", e)
                If Sublight.FrmSplash.IsWebException(e) Then
                    RetryWithAnonymousLogin()
                ElseIf Not (e.InnerException) Is Nothing Then
                    LogInFailed(e.InnerException.Message)
                Else 
                    LogInFailed(e.Message)
                End If
            End Try
        End Sub

        Private Sub wsh_OnResultLogInAnonymous(ByVal result As Object())
            If ((result) Is Nothing) OrElse (result.Length < 3) Then
                Return
            End If
            Dim guid1 As System.Guid = DirectCast(result(0), System.Guid)
            Dim sArr1 As String() = CType(result(1), String[])
            Dim s1 As String = CType(result(2), string)
            If IsNewVersionRequired(s1) Then
                IsDone = True
                Return
            End If
            LogInAnonymousHandler(guid1, sArr1, s1)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (m_BorderPen) Is Nothing Then
                    m_BorderPen.Dispose()
                    m_BorderPen = Nothing
                End If
                If Not (_fontVersion) Is Nothing Then
                    _fontVersion.Dispose()
                    _fontVersion = Nothing
                End If
            End If
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            If _fontHeight < 0 Then
                Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString("ABCDEFGHIJKLMNOPRSTUVZ?", _fontVersion)
                _fontHeight = System.Convert.ToInt32(sizeF1.Height)
            End If
            If Not (_version) Is Nothing Then
                e.Graphics.DrawString(_version, _fontVersion, System.Drawing.Brushes.WhiteSmoke, 330.0F, CSng((187 - _fontHeight)))
            End If
            If Not (_currentAction) Is Nothing Then
                e.Graphics.DrawString(_currentAction, _fontVersion, System.Drawing.Brushes.WhiteSmoke, 15.0F, CSng((190 - _fontHeight)))
            End If
        End Sub

        Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawImage(Sublight.Properties.Resources.Splash, 0, 0, Width, Height)
        End Sub

        Private Shared Sub Events_UserLogIn(ByVal sender As Object, ByVal isAnonymous As Boolean)
            RemoveHandler Sublight.Globals.Events.UserLogIn, AddressOf Sublight.FrmSplash.Events_UserLogIn
            Sublight.Plugins.Core.Globals.OnUserLogIn(Sublight.BaseForm.Session, Sublight.BaseForm.Roles)
            If Sublight.BaseForm.IsAdministrator() Then
                Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                    sublightClient1.ReportInfoAsync(Sublight.Properties.Settings.Default.UserId, Sublight.BaseForm.Session, Sublight.BaseForm.ClientInfo, "User logged in as administrator.?")
                End Using
            End If
        End Sub

        Private Shared Function GetServerMessage() As String
            Dim s3 As String

            Try
                Using webClient1 As System.Net.WebClient = New System.Net.WebClient
                    Dim s1 As String = webClient1.DownloadString("https://sites.google.com/a/sublight.si/status/?")
                    Dim match1 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s1, "<span.*?id=""sites-page-title"".*?>(?<message>.*?)</span>?", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline)
                    If (Not (match1) Is Nothing) AndAlso match1.Success AndAlso match1.Groups("message?").Success Then
                        Dim s2 As String = match1.Groups("message?").Value.Trim()
                        If System.String.Compare(s2, "NULL?", True) = 0 Then
                            s3 = Nothing
                            Return s3
                        End If
                        s3 = s2
                        Return s3
                    End If
                    s3 = Nothing
                    Return s3
                End Using
            Catch 
                s3 = Nothing
            End Try
            Return s3
        End Function

        Private Shared Sub InitWebService()
            Sublight.MyUtility.SublightSoap.SublightUserAgent = Sublight.BaseForm.ClientInfo
            Sublight.MyUtility.SublightSoap.SublightUserAgent = Sublight.BaseForm.ClientInfo
            Sublight.MyUtility.SublightSoap.DiscoverUrl()
        End Sub

        Private Shared Function IsWebException(ByVal exception As System.Exception) As Boolean
            If (exception) Is Nothing Then
                Return False
            End If
            Dim exception1 As System.Exception = exception
            While Not (exception1) Is Nothing
                If TryCast(exception1, System.Net.WebException) Then
                    Return True
                End If
                exception1 = exception1.InnerException
            End While
            Return False
        End Function

        Private Shared Function wsh_DoCallLogIn(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim s1 As String
            Dim sArr1 As String(), sArr2 As String()
            Dim guid1 As System.Guid
            Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage()

            Sublight.FrmSplash.m_username = CType(args(0), string)
            Dim clientInfo1 As Sublight.WS.ClientInfo = New Sublight.WS.ClientInfo
            clientInfo1.ClientId = CType(args(2), string)
            clientInfo1.ApiKey = Sublight.MyUtility.Security.GetApiKey()
            ws.UseSecureConnection = True
            Dim guid2 As System.Guid = ws.LogInSecure(CType(args(0), string), CType(args(1), string), clientInfo1, Sublight.BaseForm.GetArgs(), out guid1, out sArr1, out subtitleLanguageArr1, out sArr2, out s1)
            Dim objArr1 As Object() = New object() { _
                                                     guid2, _
                                                     guid1, _
                                                     sArr1, _
                                                     subtitleLanguageArr1, _
                                                     sArr2, _
                                                     s1 }
            result = objArr1
            Return True
        End Function

        Private Shared Function wsh_DoCallLogInAnonymous(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
            Dim s1 As String
            Dim sArr1 As String()

            Dim clientInfo1 As Sublight.WS.ClientInfo = New Sublight.WS.ClientInfo
            clientInfo1.ClientId = CType(args(0), string)
            clientInfo1.ApiKey = Sublight.MyUtility.Security.GetApiKey()
            Dim guid1 As System.Guid = ws.LogInAnonymous4(clientInfo1, Sublight.BaseForm.GetArgs(), out sArr1, out s1)
            Dim objArr1 As Object() = New object() { _
                                                     guid1, _
                                                     sArr1, _
                                                     s1 }
            result = objArr1
            Return True
        End Function

    End Class ' class FrmSplash

End Namespace

