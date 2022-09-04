Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Web
Imports System.Windows.Forms
Imports Sublight.Controls
Imports Sublight.MyUtility
Imports Sublight.Plugins.Core
Imports Sublight.Properties
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight

    Public Class BaseForm
        Inherits System.Windows.Forms.Form

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass1

            Public settings As String() 
            Public wsCompleted As Boolean 
            Public wsErr As String 

            Public Sub New()
            End Sub

            Public Sub <LogInAnonymous>b__0(ByVal sender As Object, ByVal e As Sublight.WS.LogInAnonymous4CompletedEventArgs)
                Try
                    Sublight.BaseForm.session = e.Result
                    settings = e.settings
                    wsErr = e.error
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.LogInAnonymous?", e1)
                Finally
                    wsCompleted = True
                End Try
            End Sub

        End Class ' class <>c__DisplayClass1

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass11

            Public waitWS As Boolean 
            Public wsCompleted As Boolean 
            Public wsErr As String 

            Public Sub New()
            End Sub

            Public Sub <ReportHashLink>b__10(ByVal sender As Object, ByVal e As Sublight.WS.ReportHashLinkCompletedEventArgs)
                Try
                    wsErr = e.error
                    wsCompleted = e.Result
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.ReportHashLink?", e1)
                Finally
                    waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClass11

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass15

            Public <>4__this As Sublight.BaseForm 
            Public args As Object() 
            Public format As String 

            Public Sub New()
            End Sub

            Public Sub <ShowError>b__13()
                Dim baseForm1 As Sublight.BaseForm = <>4__this
                If baseForm1.IsDisposed Then
                    baseForm1 = Nothing
                Else 
                    Sublight.BaseForm.FlashWindow(baseForm1)
                End If
                If Sublight.BaseForm.EnableMessageBoxWorkAround Then
                    Sublight.MyUtility.MessageBoxHelper.PrepToCenterMessageBoxOnForm(baseForm1)
                End If
                System.Windows.Forms.MessageBox.Show(baseForm1, Sublight.BaseForm.FormatMessage(format, args), Sublight.BaseForm.FormatMessageBoxCaption(Sublight.Translation.MessageBox_Error), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand)
            End Sub

        End Class ' class <>c__DisplayClass15

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass19

            Public <>4__this As Sublight.BaseForm 
            Public args As Object() 
            Public format As String 

            Public Sub New()
            End Sub

            Public Sub <ShowInfo>b__17()
                Dim baseForm1 As Sublight.BaseForm = <>4__this
                If baseForm1.IsDisposed Then
                    baseForm1 = Nothing
                Else 
                    Sublight.BaseForm.FlashWindow(baseForm1)
                End If
                If Sublight.BaseForm.EnableMessageBoxWorkAround Then
                    Sublight.MyUtility.MessageBoxHelper.PrepToCenterMessageBoxOnForm(baseForm1)
                End If
                System.Windows.Forms.MessageBox.Show(baseForm1, Sublight.BaseForm.FormatMessage(format, args), Sublight.BaseForm.FormatMessageBoxCaption(Sublight.Translation.MessageBox_Info), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk)
            End Sub

        End Class ' class <>c__DisplayClass19

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass1e

            Public newSession As System.Guid 
            Public settings As String() 
            Public wsCompleted As Boolean 
            Public wsErr As String 

            Public Sub New()
            End Sub

            Public Sub <LogIn>b__1b(ByVal sender As Object, ByVal e As Sublight.WS.LogInSecureCompletedEventArgs)
                Try
                    newSession = e.Result
                    Sublight.BaseForm.m_roles = e.roles
                    wsErr = e.error
                    Sublight.BaseForm.m_UserId = e.userId
                    Sublight.BaseForm.m_PrimaryLanguages = e.primaryLanguages
                    settings = e.settings
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.LogIn (LogIn5)?", e1)
                Finally
                    wsCompleted = True
                End Try
            End Sub

            Public Sub <LogIn>b__1c(ByVal sender As Object, ByVal e As Sublight.WS.LogOutCompletedEventArgs)
                Try
                    wsErr = e.error
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.LogIn (LogOut)?", e1)
                Finally
                    wsCompleted = True
                End Try
            End Sub

        End Class ' class <>c__DisplayClass1e

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass21

            Public waitWS As Boolean 
            Public wsCompleted As Boolean 
            Public wsErr As String 
            Public wsResult As Sublight.WS.IMDB() 

            Public Sub New()
            End Sub

            Public Sub <FindIMDB>b__20(ByVal sender As Object, ByVal e As Sublight.WS.FindIMDBCompletedEventArgs)
                Try
                    wsErr = e.error
                    wsResult = e.result
                    wsCompleted = e.Result
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.FindIMDB?", e1)
                Finally
                    waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClass21

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass24

            Public waitWS As Boolean 
            Public wsCompleted As Boolean 
            Public wsErr As String 

            Public Sub New()
            End Sub

            Public Sub <SendComment>b__23(ByVal sender As Object, ByVal e As Sublight.WS.SendCommentCompletedEventArgs)
                Try
                    wsErr = e.error
                    wsCompleted = e.Result
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.SendComment?", e1)
                Finally
                    waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClass24

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass27

            Public waitWS As Boolean 
            Public wsCompleted As Boolean 

            Public Sub New()
            End Sub

            Public Sub <AddRelease>b__26(ByVal sender As Object, ByVal e As Sublight.WS.AddReleaseCompletedEventArgs)
                Try
                    wsCompleted = e.Result
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.AddRelease?", e1)
                Finally
                    waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClass27

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass2a

            Public waitWS As Boolean 
            Public wsCompleted As Boolean 
            Public wsNewRate As Double 
            Public wsNewVotes As Long 

            Public Sub New()
            End Sub

            Public Sub <RateSubtitle>b__29(ByVal sender As Object, ByVal e As Sublight.WS.RateSubtitleCompletedEventArgs)
                Try
                    wsCompleted = e.Result
                    wsNewVotes = e.newVotes
                    wsNewRate = e.newRate
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.RateSubtitle?", e1)
                Finally
                    waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClass2a

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass2d

            Public waitWS As Boolean 
            Public wsCompleted As Boolean 
            Public wsError As String 

            Public Sub New()
            End Sub

            Public Sub <Register>b__2c(ByVal sender As Object, ByVal e As Sublight.WS.RegisterCompletedEventArgs)
                Try
                    wsCompleted = e.Result
                    wsError = e.error
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException("WinUI.BaseForm.Register?", e1)
                Finally
                    waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClass2d

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass5

            Public <>4__this As Sublight.BaseForm 
            Public page As System.Windows.Forms.Control 

            Public Sub New()
            End Sub

            Public Sub <SetWaitCursor>b__4()
                If <>4__this.GetType() <> GetType(Sublight.FrmSplash) Then
                    If Not (page) Is Nothing Then
                        page.Enabled = False
                    End If
                    System.Windows.Forms.Application.DoEvents()
                End If
                <>4__this.Cursor = System.Windows.Forms.Cursors.WaitCursor
            End Sub

        End Class ' class <>c__DisplayClass5

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClass8

            Public <>4__this As Sublight.BaseForm 
            Public page As System.Windows.Forms.Control 

            Public Sub New()
            End Sub

            Public Sub <SetDefaultCursor>b__7()
                <>4__this.Cursor = System.Windows.Forms.Cursors.Default
                If (<>4__this.GetType() <> GetType(Sublight.FrmSplash)) AndAlso (Not (page) Is Nothing) Then
                    page.Enabled = True
                End If
            End Sub

        End Class ' class <>c__DisplayClass8

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private NotInheritable Class <>c__DisplayClasse

            Public points As System.Nullable(Of Double) 
            Public waitWS As Boolean 
            Public wsCompleted As Boolean 
            Public wsErr As String 

            Public Sub New()
            End Sub

            Public Sub <AddHashLink>b__c(ByVal sender As Object, ByVal e As Sublight.WS.AddHashLink3CompletedEventArgs)
                Try
                    wsErr = e.error
                    wsCompleted = e.Result
                    points = e.points
                Catch e1 As System.Exception
                    Sublight.BaseForm.ReportException(System.String.Format("WinUI.BaseForm.AddHashLink (iteration: {0})?", DirectCast(e.UserState, int)), e1)
                Finally
                    waitWS = False
                End Try
            End Sub

        End Class ' class <>c__DisplayClasse

        Private m_isActive As Boolean 
        Private m_LoaderForm As Sublight.LoaderForm 
        Private m_loaderRequests As Integer 

        Private Shared _enableMessageBoxWorkAround As System.Nullable(Of Boolean) 
        Private Shared isAnonymous As Boolean 
        Private Shared m_AppVersion As String 
        Friend Shared m_donationRndNum As Integer 
        Private Shared m_ExceptionHandlerInitialized As Boolean 
        Private Shared m_LoaderEnabled As Boolean 
        Private Shared m_PrimaryLanguages As Sublight.WS.SubtitleLanguage() 
        Private Shared m_roles As String() 
        Private Shared m_settings As System.Collections.Generic.Dictionary(Of String,String) 
        Private Shared m_UserId As System.Guid 
        Private Shared m_username As String 
        Private Shared session As System.Guid 

        Friend ReadOnly Property IsActive As Boolean
            Get
                Return m_isActive
            End Get
        End Property

        Friend Shared ReadOnly Property AppVersion As String
            Get
                If (Sublight.BaseForm.m_AppVersion) Is Nothing Then
                    Dim version1 As System.Version = New System.Version(System.Windows.Forms.Application.ProductVersion)
                    Sublight.BaseForm.m_AppVersion = System.String.Format("{0}.{1}.{2}?", version1.Major, version1.Minor, version1.Build)
                End If
                Return Sublight.BaseForm.m_AppVersion
            End Get
        End Property

        Friend Shared ReadOnly Property ClientInfo As String
            Get
                If Sublight.Globals.EditionType = Sublight.Types.SpecialEdition.Regular Then
                    Return System.String.Format("Sublight;{0}?", Sublight.BaseForm.AppVersion)
                End If
                If Sublight.Globals.EditionType = Sublight.Types.SpecialEdition.PodnapisiNET Then
                    Return System.String.Format("Sublight-PN;{0}?", Sublight.BaseForm.AppVersion)
                End If
                Throw New System.Exception(System.String.Format("EditionType not supported: {0}?", System.Enum.GetName(GetType(Sublight.Types.SpecialEdition), Sublight.Globals.EditionType)))
            End Get
        End Property

        Protected Shared ReadOnly Property EnableMessageBoxWorkAround As Boolean
            Get
                If Not Sublight.BaseForm._enableMessageBoxWorkAround.get_HasValue() Then
                    Sublight.BaseForm._enableMessageBoxWorkAround = New System.Nullable(Of Boolean)(Sublight.BaseForm.GetSetting("EnableMessageBoxWorkAround?", "0?") = "1?")
                End If
                Return Sublight.BaseForm._enableMessageBoxWorkAround.get_Value()
            End Get
        End Property

        Public Shared ReadOnly Property IsAnonymous As Boolean
            Get
                Return Sublight.BaseForm.isAnonymous
            End Get
        End Property

        Protected Shared Property LoaderFormEnabled As Boolean
            Get
                Return Sublight.BaseForm.m_LoaderEnabled
            End Get
            Set
                Sublight.BaseForm.m_LoaderEnabled = value
            End Set
        End Property

        Friend Shared ReadOnly Property PrimaryLanguages As Sublight.WS.SubtitleLanguage()
            Get
                Return Sublight.BaseForm.m_PrimaryLanguages
            End Get
        End Property

        Friend Shared ReadOnly Property Roles As String()
            Get
                Return Sublight.BaseForm.m_roles
            End Get
        End Property

        Friend Shared ReadOnly Property Session As System.Guid
            Get
                Return Sublight.BaseForm.session
            End Get
        End Property

        Friend Shared ReadOnly Property UserId As System.Guid
            Get
                Return Sublight.BaseForm.m_UserId
            End Get
        End Property

        Friend Shared ReadOnly Property Username As String
            Get
                Return Sublight.BaseForm.m_username
            End Get
        End Property

        Public Sub New()
            If Not Sublight.BaseForm.m_ExceptionHandlerInitialized Then
                Sublight.BaseForm.m_ExceptionHandlerInitialized = True
                AddHandler System.Windows.Forms.Application.ThreadException, AddressOf Application_ThreadException
                AddHandler System.AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
            End If
            InitializeComponent()
            BackColor = Sublight.Globals.ColorBackgroundLight1
            DoubleBuffered = True
        End Sub

        Shared Sub New()
            Sublight.BaseForm.m_donationRndNum = -1
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Sub <HideLoader>b__a()
            If Not (m_LoaderForm) Is Nothing Then
                m_LoaderForm.Visible = False
                m_LoaderForm.Close()
                m_LoaderForm.Dispose()
            End If
            m_LoaderForm = Nothing
        End Sub

        Friend Function AddHashLink(ByVal page As System.Windows.Forms.Control, ByVal subtitleID As System.Guid, ByVal videoHash As String, ByVal showLoader As Boolean, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                Try
                    Dim addHashLink3CompletedEventHandler1 As Sublight.WS.AddHashLink3CompletedEventHandler = Nothing
                    Dim <>c__DisplayClasse1 As Sublight.BaseForm.<>c__DisplayClasse = New Sublight.BaseForm.<>c__DisplayClasse
                    If showLoader Then
                        ShowLoader(page)
                    End If
                    <>c__DisplayClasse1.wsCompleted = False
                    <>c__DisplayClasse1.wsErr = Nothing
                    <>c__DisplayClasse1.waitWS = True
                    <>c__DisplayClasse1.points = New System.Nullable(Of Double)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        If (addHashLink3CompletedEventHandler1) Is Nothing Then
                            addHashLink3CompletedEventHandler1 = New Sublight.WS.AddHashLink3CompletedEventHandler(<>c__DisplayClasse1.<AddHashLink>b__c)
                        End If
                        AddHandler sublight1.AddHashLink3Completed, AddressOf addHashLink3CompletedEventHandler1
                        Dim i1 As Integer = 0
                        While i1 < 5
                            <>c__DisplayClasse1.wsCompleted = False
                            <>c__DisplayClasse1.wsErr = Nothing
                            <>c__DisplayClasse1.waitWS = True
                            sublight1.AddHashLink3Async(Sublight.BaseForm.Session, subtitleID, videoHash, i1 + 1)
                            While <>c__DisplayClasse1.waitWS
                                System.Windows.Forms.Application.DoEvents()
                                System.Threading.Thread.Sleep(100)
                            End While
                            If Not <>c__DisplayClasse1.wsCompleted Then
                                i1 = i1 + 1
                            End If
                        End While
                        error = <>c__DisplayClasse1.wsErr
                        If <>c__DisplayClasse1.wsCompleted AndAlso <>c__DisplayClasse1.points.get_HasValue() Then
                            Sublight.Globals.UpdateUserPoints(<>c__DisplayClasse1.points.get_Value())
                        End If
                        flag1 = <>c__DisplayClasse1.wsCompleted
                        Return flag1
                    End Using
                Catch e As System.Exception
                    error = e.Message
                    flag1 = False
                End Try
            Finally
                If showLoader Then
                    HideLoader(page)
                End If
            End Try
            Return flag1
        End Function

        Friend Function AddRelease(ByVal page As System.Windows.Forms.Control, ByVal subtitleId As System.Guid, ByVal release As String, ByVal fps As Sublight.WS.FPS) As Boolean
            Dim flag1 As Boolean

            Try
                Try
                    ShowLoader(page)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim <>c__DisplayClass27_1 As Sublight.BaseForm.<>c__DisplayClass27 = New Sublight.BaseForm.<>c__DisplayClass27
                        <>c__DisplayClass27_1.wsCompleted = False
                        <>c__DisplayClass27_1.waitWS = True
                        AddHandler sublight1.AddReleaseCompleted, AddressOf <>c__DisplayClass27_1.<AddRelease>b__26
                        sublight1.AddReleaseAsync(Sublight.BaseForm.Session, subtitleId, release, fps)
                        While <>c__DisplayClass27_1.waitWS
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(100)
                        End While
                        flag1 = <>c__DisplayClass27_1.wsCompleted
                        Return flag1
                    End Using
                Catch 
                    flag1 = False
                End Try
            Finally
                HideLoader(page)
            End Try
            Return flag1
        End Function

        Private Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
            ExceptionHandler(e.Exception)
        End Sub

        Protected Sub ApplyRightToLeft()
        End Sub

        Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As System.UnhandledExceptionEventArgs)
            ExceptionHandler(CType(e.ExceptionObject, System.Exception))
        End Sub

        Private Sub ExceptionHandler(ByVal e As System.Exception)
            If (e) Is Nothing Then
                Return
            End If
            If Sublight.BaseForm.HandleConnectionDifficulties(e) Then
                Return
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim flag1 As Boolean = False
            stringBuilder1.AppendFormat("<b>OS:</b> {0}<br />?", System.Environment.OSVersion)
            stringBuilder1.AppendLine()
            stringBuilder1.AppendFormat("<b>CLR version:</b> {0}<br />?", System.Environment.Version)
            stringBuilder1.AppendLine()
            stringBuilder1.AppendFormat("<b>CPUs:</b> {0}<br />?", System.Environment.ProcessorCount)
            stringBuilder1.AppendLine()
            stringBuilder1.Append(Sublight.BaseForm.ExceptionToString("Exception?", e))
            If Not (e.InnerException) Is Nothing Then
                stringBuilder1.AppendLine()
                stringBuilder1.Append(Sublight.BaseForm.ExceptionToString("InnerException?", e.InnerException))
            End If
            Try
                Dim stringBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim s1 As String = Nothing
                If ((TypeOf e Is System.IO.IOException) OrElse (TypeOf e Is System.Configuration.ConfigurationException)) AndAlso e.Message.ToLower().Contains("\user.config?") Then
                    stringBuilder2.AppendFormat(Sublight.Translation.Application_Error_ErrorSavingSettings, e.Message)
                End If
                If TypeOf e Is System.IO.FileNotFoundException Then
                    Dim fileNotFoundException1 As System.IO.FileNotFoundException = TryCast(e, System.IO.FileNotFoundException)
                    If Not (fileNotFoundException1.FileName) Is Nothing Then
                        If fileNotFoundException1.FileName.ToLower().Contains("ICSharpCode.SharpZipLib?".ToLower()) Then
                            flag1 = True
                        ElseIf fileNotFoundException1.FileName.ToLower().Contains("BinaryComponents.SuperList?".ToLower()) Then
                            flag1 = True
                        ElseIf fileNotFoundException1.FileName.ToLower().Contains("Sublight.Common?".ToLower()) Then
                            flag1 = True
                        ElseIf fileNotFoundException1.FileName.ToLower().Contains("Sublight.Plugins.Core?".ToLower()) Then
                            flag1 = True
                        End If
                    End If
                    If flag1 Then
                        s1 = System.String.Format(Sublight.Translation.Application_Error_AppFileMissing, e.Message)
                        stringBuilder2.Append(".?")
                        stringBuilder1.AppendFormat("<b>Message displayed:</b> {0}<br />?", "yes?")
                        stringBuilder1.AppendLine()
                    End If
                End If
                Dim flag2 As Boolean = stringBuilder2.Length <= 0
                If flag2 Then
                    stringBuilder2.Append(Sublight.Translation.Application_Error)
                End If
                stringBuilder1.AppendFormat("<b>Is generic error:</b> {0}<br />?", IIf(flag2, "yes?", "no?"))
                stringBuilder1.AppendLine()
                Sublight.BaseForm.ReportError(stringBuilder1.ToString())
                If Not System.String.IsNullOrEmpty(s1) Then
                    ShowError(s1, New object(0) {})
                End If
            Catch 
                ShowError(Sublight.Translation.Application_Error, New object(0) {})
            Finally
                If flag1 Then
                    System.Environment.Exit(1)
                End If
            End Try
        End Sub

        Friend Sub ExceptionHandlerUI(ByVal ex As System.Exception)
            If (ex) Is Nothing Then
                Return
            End If
            If TryCast(ex, System.Net.WebException) Then
                Dim objArr1 As Object() = New object() { ex.Message }
                ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                Return
            End If
            If Not (ex.InnerException) Is Nothing Then
                ExceptionHandlerUI(ex.InnerException)
            End If
        End Sub

        Protected Function FindIMDB(ByVal page As System.Windows.Forms.Control, ByVal keyword As String, ByVal year As System.Nullable(Of Integer), ByRef result As Sublight.WS.IMDB(), ByRef error As String) As Boolean
            Dim flag1 As Boolean

            result = Nothing
            error = Nothing
            Try
                Try
                    ShowLoader(page)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim <>c__DisplayClass21_1 As Sublight.BaseForm.<>c__DisplayClass21 = New Sublight.BaseForm.<>c__DisplayClass21
                        <>c__DisplayClass21_1.wsCompleted = False
                        <>c__DisplayClass21_1.wsErr = Nothing
                        <>c__DisplayClass21_1.wsResult = Nothing
                        <>c__DisplayClass21_1.waitWS = True
                        AddHandler sublight1.FindIMDBCompleted, AddressOf <>c__DisplayClass21_1.<FindIMDB>b__20
                        sublight1.FindIMDBAsync(keyword, year)
                        While <>c__DisplayClass21_1.waitWS
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(100)
                        End While
                        error = <>c__DisplayClass21_1.wsErr
                        result = <>c__DisplayClass21_1.wsResult
                        flag1 = <>c__DisplayClass21_1.wsCompleted
                        Return flag1
                    End Using
                Catch e As System.Exception
                    error = e.Message
                    flag1 = False
                End Try
            Finally
                HideLoader(page)
            End Try
            Return flag1
        End Function

        Friend Sub HideLoader(ByVal page As System.Windows.Forms.Control)
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            Try
                If (Not (m_LoaderForm) Is Nothing) AndAlso Not m_LoaderForm.IsDisposed Then
                    m_loaderRequests = m_loaderRequests - 1
                    If m_loaderRequests <= 0 Then
                        If (methodInvoker2) Is Nothing Then
                            methodInvoker2 = New System.Windows.Forms.MethodInvoker(<HideLoader>b__a)
                        End If
                        Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                        Sublight.BaseForm.DoCtrlInvoke(m_LoaderForm, Me, methodInvoker1, True)
                        m_loaderRequests = 0
                    End If
                    If Not IsDisposed Then
                        Sublight.BaseForm.DoCtrlInvoke(Me, Me, New System.Windows.Forms.MethodInvoker(Activate))
                    End If
                Else 
                    m_loaderRequests = 0
                End If
                If m_loaderRequests <= 0 Then
                    Dim formCollection1 As System.Windows.Forms.FormCollection = System.Windows.Forms.Application.OpenForms
                    If Not (formCollection1) Is Nothing Then
                        Dim i1 As Integer = 0
                        While i1 < formCollection1.Count
                            Try
                                Dim loaderForm2_1 As Sublight.LoaderForm2 = TryCast(System.Windows.Forms.Application.OpenForms(i1), Sublight.LoaderForm2)
                                If (Not (loaderForm2_1) Is Nothing) AndAlso Not loaderForm2_1.IsDisposed Then
                                    loaderForm2_1.Close()
                                    loaderForm2_1.Dispose()
                                    GoTo label_1
                                End If
                                Dim loaderForm1 As Sublight.LoaderForm = TryCast(System.Windows.Forms.Application.OpenForms(i1), Sublight.LoaderForm)
                                If (Not (loaderForm1) Is Nothing) AndAlso Not loaderForm1.IsDisposed Then
                                    loaderForm1.Close()
                                    loaderForm1.Dispose()
                                    GoTo label_1
                                End If
                            Catch e As System.Exception
                            End Try
                        label_1: _
                            i1 = i1 + 1
                        End While
                    End If
                End If
                SetDefaultCursor(page)
            Catch e As System.Exception
                Sublight.BaseForm.ReportException("WinUI.BaseForm.HideLoader?", e)
            End Try
        End Sub

        Friend Sub HideLoader()
            HideLoader(Nothing)
        End Sub

        Private Sub InitializeComponent()
            Name = "BaseForm?"
        End Sub

        Protected Sub InitSession(ByVal username As String, ByVal isUserAnonymous As Boolean, ByVal userSession As System.Guid, ByVal userId As System.Guid, ByVal roles As String(), ByVal primaryLanguages As Sublight.WS.SubtitleLanguage(), ByVal settings As String())
            Dim i2 As Integer

            Sublight.BaseForm.isAnonymous = isUserAnonymous
            Sublight.BaseForm.session = userSession
            Sublight.BaseForm.m_roles = roles
            Sublight.BaseForm.m_UserId = userId
            Sublight.BaseForm.m_PrimaryLanguages = primaryLanguages
            Sublight.BaseForm.m_username = username
            Sublight.BaseForm.m_settings = New System.Collections.Generic.Dictionary(Of String,String)
            If Not (settings) Is Nothing Then
                Dim sArr1 As String() = settings
                Dim i3 As Integer = 0
                While i3 < sArr1.Length
                    Dim s1 As String = sArr1(i3)
                    Dim i1 As Integer = s1.IndexOf("="C)
                    If i1 >= 0 Then
                        Dim s2 As String = s1.Substring(0, i1)
                        Dim s3 As String = s1.Substring(i1 + 1)
                        Sublight.BaseForm.m_settings.set_Item(s2, s3)
                    End If
                    i3 = i3 + 1
                End While
            End If
            If Sublight.BaseForm.m_donationRndNum < 0 Then
                Sublight.BaseForm.m_donationRndNum = (New System.Random).Next(0, 11)
            End If
            Dim s4 As String = Sublight.BaseForm.GetSetting("Config?")
            If (Not (s4) Is Nothing) AndAlso System.Int32.TryParse(s4, ByRef i2) AndAlso ((i2 And 1) > 0) Then
                Sublight.BaseForm.m_donationRndNum = 7
            End If
            If (Sublight.BaseForm.m_donationRndNum = 5) AndAlso Sublight.FrmMain.FormLoaded Then
                Sublight.BaseForm.m_donationRndNum = 6
                ShowPurchasePoints()
            End If
            If Sublight.Globals.EditionType <> Sublight.Types.SpecialEdition.Regular Then
                Dim s5 As String = System.String.Format("SpecialEdition_Disable_{0}?", System.Enum.GetName(GetType(Sublight.Types.SpecialEdition), Sublight.Globals.EditionType))
                If Sublight.BaseForm.m_settings.ContainsKey(s5) Then
                    Try
                        Dim s6 As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
                        s6 = System.IO.Path.Combine(s6, System.String.Format("SublightCache\{0}.setting?", System.Enum.GetName(GetType(Sublight.Types.SpecialEdition), Sublight.Globals.EditionType)))
                        System.IO.File.Delete(s6)
                    Catch 
                    End Try
                    System.Windows.Forms.MessageBox.Show("Application restart is required.?")
                    System.Diagnostics.Process.GetCurrentProcess().Kill()
                    Return
                End If
            End If
            Sublight.Plugins.Core.Globals.OnUserLogIn(userSession, roles)
        End Sub

        Protected Function LogIn(ByVal username As String, ByVal passwordHash As String, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                Try
                    ShowLoader()
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim logOutCompletedEventHandler1 As Sublight.WS.LogOutCompletedEventHandler = Nothing
                        Dim <>c__DisplayClass1e1 As Sublight.BaseForm.<>c__DisplayClass1e = New Sublight.BaseForm.<>c__DisplayClass1e
                        <>c__DisplayClass1e1.wsCompleted = False
                        <>c__DisplayClass1e1.newSession = System.Guid.Empty
                        Sublight.BaseForm.m_UserId = System.Guid.Empty
                        <>c__DisplayClass1e1.wsErr = Nothing
                        <>c__DisplayClass1e1.settings = Nothing
                        AddHandler sublight1.LogInSecureCompleted, AddressOf <>c__DisplayClass1e1.<LogIn>b__1b
                        Dim clientInfo1 As Sublight.WS.ClientInfo = New Sublight.WS.ClientInfo
                        clientInfo1.ClientId = Sublight.BaseForm.ClientInfo
                        clientInfo1.ApiKey = Sublight.MyUtility.Security.GetApiKey()
                        sublight1.UseSecureConnection = True
                        sublight1.LogInSecureAsync(username, passwordHash, clientInfo1, Sublight.BaseForm.GetArgs())
                        While Not <>c__DisplayClass1e1.wsCompleted
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(100)
                        End While
                        error = <>c__DisplayClass1e1.wsErr
                        If <>c__DisplayClass1e1.newSession <> System.Guid.Empty Then
                            <>c__DisplayClass1e1.wsCompleted = False
                            <>c__DisplayClass1e1.wsErr = Nothing
                            If (logOutCompletedEventHandler1) Is Nothing Then
                                logOutCompletedEventHandler1 = New Sublight.WS.LogOutCompletedEventHandler(<>c__DisplayClass1e1.<LogIn>b__1c)
                            End If
                            AddHandler sublight1.LogOutCompleted, AddressOf logOutCompletedEventHandler1
                            sublight1.LogOutAsync(Sublight.BaseForm.session)
                            While Not <>c__DisplayClass1e1.wsCompleted
                                System.Windows.Forms.Application.DoEvents()
                                System.Threading.Thread.Sleep(100)
                            End While
                            error = <>c__DisplayClass1e1.wsErr
                            InitSession(username, False, <>c__DisplayClass1e1.newSession, Sublight.BaseForm.m_UserId, Sublight.BaseForm.m_roles, Sublight.BaseForm.m_PrimaryLanguages, <>c__DisplayClass1e1.settings)
                            flag1 = True
                            Return flag1
                        End If
                        Sublight.BaseForm.isAnonymous = True
                        Sublight.BaseForm.m_UserId = System.Guid.Empty
                        flag1 = False
                        Return flag1
                    End Using
                Catch 
                    Sublight.BaseForm.isAnonymous = True
                    Sublight.BaseForm.m_UserId = System.Guid.Empty
                    flag1 = False
                End Try
            Finally
                HideLoader()
            End Try
            Return flag1
        End Function

        Protected Function LogInAnonymous(ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Sublight.BaseForm.isAnonymous = True
            Sublight.BaseForm.m_roles = Nothing
            Try
                Try
                    ShowLoader()
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim <>c__DisplayClass1_1 As Sublight.BaseForm.<>c__DisplayClass1 = New Sublight.BaseForm.<>c__DisplayClass1
                        <>c__DisplayClass1_1.wsCompleted = False
                        <>c__DisplayClass1_1.wsErr = Nothing
                        <>c__DisplayClass1_1.settings = Nothing
                        AddHandler sublight1.LogInAnonymous4Completed, AddressOf <>c__DisplayClass1_1.<LogInAnonymous>b__0
                        Dim clientInfo1 As Sublight.WS.ClientInfo = New Sublight.WS.ClientInfo
                        clientInfo1.ClientId = Sublight.BaseForm.ClientInfo
                        clientInfo1.ApiKey = Sublight.MyUtility.Security.GetApiKey()
                        sublight1.LogInAnonymous4Async(clientInfo1, Sublight.BaseForm.GetArgs())
                        While Not <>c__DisplayClass1_1.wsCompleted
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(100)
                        End While
                        error = <>c__DisplayClass1_1.wsErr
                        InitSession(Nothing, True, Sublight.BaseForm.session, System.Guid.Empty, Nothing, Nothing, <>c__DisplayClass1_1.settings)
                        flag1 = Sublight.BaseForm.session <> System.Guid.Empty
                        Return flag1
                    End Using
                Catch e As System.Exception
                    Sublight.BaseForm.session = System.Guid.Empty
                    ExceptionHandlerUI(e)
                    flag1 = False
                End Try
            Finally
                HideLoader()
            End Try
            Return flag1
        End Function

        Friend Sub OpenInBrowser(ByVal url As String)
            If Not Sublight.MyUtility.Browser.OpenUrl(IIf(IsDisposed, Nothing, Me), url) Then
                Dim frmBrowser1 As Sublight.FrmBrowser = New Sublight.FrmBrowser(url)
                frmBrowser1.Show(IIf(IsDisposed, Nothing, Me))
            End If
        End Sub

        Friend Sub PingLoaderForm()
            If ((m_LoaderForm) Is Nothing) OrElse m_LoaderForm.IsDisposed Then
                Return
            End If
            Try
                m_LoaderForm.PingLoader()
            Catch e As System.Exception
            End Try
        End Sub

        Friend Function RateSubtitle(ByVal page As Sublight.Controls.BasePage, ByVal subtitleId As System.Guid, ByVal rate As Integer, ByRef newVotes As Long, ByRef newRate As Double) As Boolean
            Dim flag1 As Boolean

            Try
                Try
                    ShowLoader(page)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim <>c__DisplayClass2a1 As Sublight.BaseForm.<>c__DisplayClass2a = New Sublight.BaseForm.<>c__DisplayClass2a
                        <>c__DisplayClass2a1.wsCompleted = False
                        <>c__DisplayClass2a1.wsNewVotes = CLng(0)
                        <>c__DisplayClass2a1.wsNewRate = 0.0R
                        <>c__DisplayClass2a1.waitWS = True
                        AddHandler sublight1.RateSubtitleCompleted, AddressOf <>c__DisplayClass2a1.<RateSubtitle>b__29
                        sublight1.RateSubtitleAsync(Sublight.BaseForm.Session, subtitleId, rate)
                        While <>c__DisplayClass2a1.waitWS
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(100)
                        End While
                        newVotes = <>c__DisplayClass2a1.wsNewVotes
                        newRate = <>c__DisplayClass2a1.wsNewRate
                        flag1 = <>c__DisplayClass2a1.wsCompleted
                        Return flag1
                    End Using
                Catch 
                    newVotes = CLng(0)
                    newRate = 0.0R
                    flag1 = False
                End Try
            Finally
                HideLoader(page)
            End Try
            Return flag1
        End Function

        Friend Function Register(ByVal page As System.Windows.Forms.Control, ByVal username As String, ByVal passwordHash As String, ByVal email As String, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            Try
                Try
                    ShowLoader(page)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim <>c__DisplayClass2d1 As Sublight.BaseForm.<>c__DisplayClass2d = New Sublight.BaseForm.<>c__DisplayClass2d
                        <>c__DisplayClass2d1.wsCompleted = False
                        <>c__DisplayClass2d1.wsError = Nothing
                        <>c__DisplayClass2d1.waitWS = True
                        AddHandler sublight1.RegisterCompleted, AddressOf <>c__DisplayClass2d1.<Register>b__2c
                        sublight1.RegisterAsync(username, passwordHash, email)
                        While <>c__DisplayClass2d1.waitWS
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(100)
                        End While
                        error = <>c__DisplayClass2d1.wsError
                        flag1 = <>c__DisplayClass2d1.wsCompleted
                        Return flag1
                    End Using
                Catch e As System.Exception
                    error = e.Message
                    flag1 = False
                End Try
            Finally
                HideLoader(page)
            End Try
            Return flag1
        End Function

        Friend Function ReportHashLink(ByVal page As Sublight.Controls.BasePage, ByVal subtitleID As System.Guid, ByVal videoHash As String, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                Try
                    ShowLoader(page)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim <>c__DisplayClass11_1 As Sublight.BaseForm.<>c__DisplayClass11 = New Sublight.BaseForm.<>c__DisplayClass11
                        <>c__DisplayClass11_1.wsCompleted = False
                        <>c__DisplayClass11_1.wsErr = Nothing
                        <>c__DisplayClass11_1.waitWS = True
                        AddHandler sublight1.ReportHashLinkCompleted, AddressOf <>c__DisplayClass11_1.<ReportHashLink>b__10
                        sublight1.ReportHashLinkAsync(Sublight.BaseForm.Session, subtitleID, videoHash)
                        While <>c__DisplayClass11_1.waitWS
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(100)
                        End While
                        error = <>c__DisplayClass11_1.wsErr
                        flag1 = <>c__DisplayClass11_1.wsCompleted
                        Return flag1
                    End Using
                Catch e As System.Exception
                    error = e.Message
                    flag1 = False
                End Try
            Finally
                HideLoader(page)
            End Try
            Return flag1
        End Function

        Friend Function SaveUserSettings() As Boolean
            Dim flag2 As Boolean

            Try
                Dim flag1 As Boolean = False
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim exception1 As System.Exception = Nothing
                Sublight.BaseForm.SaveUserSettingsHelper()
                Dim i1 As Integer = 0
                While i1 < 5
                    Try
                        Sublight.Properties.Settings.Default.Save()
                        flag1 = True
                        GoTo label_1
                    Catch e1 As System.IO.IOException
                        exception1 = e1
                        stringBuilder1.Append("IOException; ?")
                        System.Threading.Thread.Sleep(100)
                    Catch e2 As System.Configuration.ConfigurationException
                        exception1 = e2
                        stringBuilder1.Append("ConfigurationException; ?")
                        System.Threading.Thread.Sleep(100)
                    End Try
                    i1 = i1 + 1
                End While
            label_1: _
                If Not flag1 Then
                    Dim objArr1 As Object() = New object() { Sublight.MyUtility.ExceptionUtil.ToString(exception1) }
                    ShowError(Sublight.Translation.Application_Error_ErrorSavingUserSettings, objArr1)
                End If
                flag2 = flag1
            Catch e3 As System.ArgumentException
                Sublight.BaseForm.ReportException("WinUI.BaseForm.SaveUserSettings?", e3)
                Dim objArr2 As Object() = New object() { Sublight.MyUtility.ExceptionUtil.ToString(e3) }
                ShowError(Sublight.Translation.Application_Error_ErrorSavingUserSettings, objArr2)
                flag2 = False
            Catch e4 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.BaseForm.SaveUserSettings?", e4)
                Dim objArr3 As Object() = New object() { Sublight.MyUtility.ExceptionUtil.ToString(e4) }
                ShowError(Sublight.Translation.Application_Error_ErrorSavingUserSettings, objArr3)
                flag2 = False
            End Try
            Return flag2
        End Function

        Friend Function SendComment(ByVal page As System.Windows.Forms.Control, ByVal subject As String, ByVal senderEmail As String, ByVal message As String, ByRef error As String) As Boolean
            Dim flag1 As Boolean

            error = Nothing
            Try
                Try
                    ShowLoader(page)
                    Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                        Dim <>c__DisplayClass24_1 As Sublight.BaseForm.<>c__DisplayClass24 = New Sublight.BaseForm.<>c__DisplayClass24
                        <>c__DisplayClass24_1.wsCompleted = False
                        <>c__DisplayClass24_1.wsErr = Nothing
                        <>c__DisplayClass24_1.waitWS = True
                        AddHandler sublight1.SendCommentCompleted, AddressOf <>c__DisplayClass24_1.<SendComment>b__23
                        sublight1.SendCommentAsync(Sublight.BaseForm.Session, subject, senderEmail, message)
                        While <>c__DisplayClass24_1.waitWS
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(100)
                        End While
                        error = <>c__DisplayClass24_1.wsErr
                        flag1 = <>c__DisplayClass24_1.wsCompleted
                        Return flag1
                    End Using
                Catch e As System.Exception
                    error = e.Message
                    flag1 = False
                End Try
            Finally
                HideLoader(page)
            End Try
            Return flag1
        End Function

        Private Sub SetDefaultCursor(ByVal page As System.Windows.Forms.Control)
            Dim <>c__DisplayClass8_1 As Sublight.BaseForm.<>c__DisplayClass8 = New Sublight.BaseForm.<>c__DisplayClass8
            <>c__DisplayClass8_1.page = page
            <>c__DisplayClass8_1.<>4__this = Me
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass8_1.<SetDefaultCursor>b__7)
            Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
        End Sub

        Friend Sub SetLoaderFormText(ByVal text As String)
            If ((m_LoaderForm) Is Nothing) OrElse m_LoaderForm.IsDisposed Then
                Return
            End If
            Try
                m_LoaderForm.SetLoaderText(text)
            Catch e As System.Exception
            End Try
        End Sub

        Private Sub SetWaitCursor(ByVal page As System.Windows.Forms.Control)
            Dim <>c__DisplayClass5_1 As Sublight.BaseForm.<>c__DisplayClass5 = New Sublight.BaseForm.<>c__DisplayClass5
            <>c__DisplayClass5_1.page = page
            <>c__DisplayClass5_1.<>4__this = Me
            Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass5_1.<SetWaitCursor>b__4)
            Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
        End Sub

        Friend Sub ShowError(ByVal format As String, <System.ParamArray> ByVal args As Object())
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            Dim <>c__DisplayClass15_1 As Sublight.BaseForm.<>c__DisplayClass15 = New Sublight.BaseForm.<>c__DisplayClass15
            <>c__DisplayClass15_1.format = format
            <>c__DisplayClass15_1.args = args
            <>c__DisplayClass15_1.<>4__this = Me
            HideLoader()
            If (<>c__DisplayClass15_1.format) Is Nothing Then
                <>c__DisplayClass15_1.format = Sublight.Translation.MessageBox_Error_Unknown
            End If
            Try
                If (methodInvoker2) Is Nothing Then
                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass15_1.<ShowError>b__13)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
            Catch e As System.Exception
                Sublight.BaseForm.ReportException("WinUI.BaseForm.ShowError?", e)
            End Try
        End Sub

        Friend Sub ShowInfo(ByVal format As String, <System.ParamArray> ByVal args As Object())
            Dim methodInvoker2 As System.Windows.Forms.MethodInvoker = Nothing
            Dim <>c__DisplayClass19_1 As Sublight.BaseForm.<>c__DisplayClass19 = New Sublight.BaseForm.<>c__DisplayClass19
            <>c__DisplayClass19_1.format = format
            <>c__DisplayClass19_1.args = args
            <>c__DisplayClass19_1.<>4__this = Me
            HideLoader()
            Try
                If (methodInvoker2) Is Nothing Then
                    methodInvoker2 = New System.Windows.Forms.MethodInvoker(<>c__DisplayClass19_1.<ShowInfo>b__17)
                End If
                Dim methodInvoker1 As System.Windows.Forms.MethodInvoker = methodInvoker2
                Sublight.BaseForm.DoCtrlInvoke(Me, Me, methodInvoker1)
            Catch e As System.Exception
                Sublight.BaseForm.ReportException("WinUI.BaseForm.ShowInfo?", e)
            End Try
        End Sub

        Friend Sub ShowLoader(ByVal page As System.Windows.Forms.Control)
            If (Not (m_LoaderForm) Is Nothing) AndAlso Not m_LoaderForm.IsDisposed Then
                m_LoaderForm.Dispose()
                m_LoaderForm = Nothing
            End If
            Dim type1 As System.Type = GetType()
            If Sublight.BaseForm.LoaderFormEnabled AndAlso ((type1 = GetType(Sublight.FrmMain)) OrElse (type1 = GetType(Sublight.FrmDetails2)) OrElse (type1 = GetType(Sublight.FrmAbout))) Then
                If (m_LoaderForm) Is Nothing Then
                    m_loaderRequests = 0
                End If
                m_loaderRequests = m_loaderRequests + 1
                If m_loaderRequests = 1 Then
                    Dim loaderForm1 As Sublight.LoaderForm = New Sublight.LoaderForm(Me)
                    loaderForm1.Left = Left
                    loaderForm1.Top = Top
                    loaderForm1.Width = Width
                    loaderForm1.Height = Height
                    loaderForm1.Visible = True
                    m_LoaderForm = loaderForm1
                    m_LoaderForm.BringLoaderToFront()
                End If
            End If
            SetWaitCursor(page)
        End Sub

        Private Sub ShowLoader()
            Try
                ShowLoader(Nothing)
            Catch 
            End Try
        End Sub

        Friend Sub ShowPurchasePoints()
            Dim s1 As String

            If Sublight.BaseForm.IsAnonymous Then
                s1 = System.String.Format("PurchasePoints.aspx?language={0}?", System.Web.HttpUtility.UrlEncode(Sublight.Properties.Settings.Default.AppLanguage))
            Else 
                s1 = System.String.Format("PurchasePoints.aspx?username={0}&language={1}?", System.Web.HttpUtility.UrlEncode(Sublight.BaseForm.Username), System.Web.HttpUtility.UrlEncode(Sublight.Properties.Settings.Default.AppLanguage))
            End If
            OpenInBrowser(Sublight.Globals.GetHomePageAbsoluteUrl(s1))
        End Sub

        Friend Function ShowQuestion(ByVal format As String, <System.ParamArray> ByVal args As Object()) As System.Windows.Forms.DialogResult
            HideLoader()
            Return Sublight.BaseForm.ShowQuestion(Me, format, args)
        End Function

        Friend Sub ShowWarning(ByVal format As String, <System.ParamArray> ByVal args As Object())
            HideLoader()
            Sublight.BaseForm.ShowWarning(Me, format, args)
        End Sub

        Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
            MyBase.OnActivated(e)
            m_isActive = True
            If (Not (m_LoaderForm) Is Nothing) AndAlso Not m_LoaderForm.IsDisposed Then
                Try
                    m_LoaderForm.BringLoaderToFront()
                Catch 
                End Try
            End If
        End Sub

        Protected Overrides Sub OnDeactivate(ByVal e As System.EventArgs)
            MyBase.OnDeactivate(e)
            m_isActive = False
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        End Sub

        Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)
            MyBase.OnLocationChanged(e)
            If (Not (m_LoaderForm) Is Nothing) AndAlso Not m_LoaderForm.IsDisposed AndAlso m_LoaderForm.Visible Then
                m_LoaderForm.Left = Left
                m_LoaderForm.Top = Top
                m_LoaderForm.Width = Width
                m_LoaderForm.Height = Height
            End If
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            If (Not (m_LoaderForm) Is Nothing) AndAlso Not m_LoaderForm.IsDisposed AndAlso m_LoaderForm.Visible Then
                m_LoaderForm.Left = Left
                m_LoaderForm.Top = Top
                m_LoaderForm.Width = Width
                m_LoaderForm.Height = Height
            End If
        End Sub

        Friend Shared Sub AddTrace(ByVal trace As String, ByVal test As Integer)
        End Sub

        Protected Shared Sub ApplyLanguage()
        End Sub

        Friend Shared Function CanSubtitlePublisherEdit(ByVal subtitle As Sublight.WS.Subtitle) As Boolean
            If subtitle.PublisherID = Sublight.BaseForm.UserId AndAlso (subtitle.Status = 0) Then
                Return True
            End If
            Return False
        End Function

        Friend Shared Sub DoCtrlInvoke(ByVal ctrl As System.Windows.Forms.Control, ByVal sender As Object, ByVal mi As System.Windows.Forms.MethodInvoker, ByVal wait As Boolean)
            If (ctrl) Is Nothing Then
                Return
            End If
            Dim s1 As String = ctrl.Name
            Dim control1 As System.Windows.Forms.Control = ctrl.Parent
            While Not (control1) Is Nothing
                s1 = System.String.Format("{0}.{1}?", control1.Name, s1)
                control1 = control1.Parent
            End While
            If ctrl.InvokeRequired Then
                Dim objArr1 As Object() = New object(2) {}
                objArr1(0) = sender
                Dim objArr2 As Object() = New object(1) {}
                objArr1(1) = objArr2
                Dim iasyncResult1 As System.IAsyncResult = ctrl.BeginInvoke(mi, objArr1)
                If Not wait Then
                    Return
                End If
                iasyncResult1.AsyncWaitHandle.WaitOne()
                Return
            End If
            mi.Invoke()
        End Sub

        Friend Shared Sub DoCtrlInvoke(ByVal ctrl As System.Windows.Forms.Control, ByVal sender As Object, ByVal mi As System.Windows.Forms.MethodInvoker)
            Sublight.BaseForm.DoCtrlInvoke(ctrl, sender, mi, False)
        End Sub

        Private Shared Function ExceptionToString(ByVal prefix As String, ByVal e As System.Exception) As String
            If (e) Is Nothing Then
                Return Nothing
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            stringBuilder1.AppendFormat("<b>{0}.Name:</b> {1} ({2})<br />?", prefix, e.GetType().Name, e.GetType().Namespace)
            stringBuilder1.AppendLine()
            stringBuilder1.AppendFormat("<b>{0}.Message:</b> {1}<br />?", prefix, e.Message)
            stringBuilder1.AppendLine()
            stringBuilder1.AppendFormat("<b>{0}.Source:</b> {1}<br />?", prefix, e.Source)
            stringBuilder1.AppendLine()
            stringBuilder1.AppendFormat("<b>{0}.StackTrace:</b> {1}<br />?", prefix, e.StackTrace)
            Return stringBuilder1.ToString()
        End Function

        Friend Shared Sub FlashWindow(ByVal form As System.Windows.Forms.Form)
            Dim flashwinfo1 As Sublight.MyUtility.Win32.FLASHWINFO

            If ((form) Is Nothing) OrElse form.IsDisposed Then
                Return
            End If
            flashwinfo1 = New Sublight.MyUtility.Win32.FLASHWINFO
            flashwinfo1.cbSize = System.Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(flashwinfo1))
            flashwinfo1.hwnd = form.Handle
            flashwinfo1.dwFlags = 15
            flashwinfo1.uCount = -1
            flashwinfo1.dwTimeout = 0
            Sublight.MyUtility.Win32.FlashWindowEx(ByRef flashwinfo1)
        End Sub

        Friend Shared Function FormatMessage(ByVal format As String, <System.ParamArray> ByVal args As Object()) As String
            If (format) Is Nothing Then
                Return Nothing
            End If
            Dim s1 As String = System.String.Format(format, args)
            If s1.EndsWith("..?") OrElse s1.EndsWith("!!?") OrElse s1.EndsWith("???") Then
                s1 = s1.Substring(0, s1.Length - 1)
            End If
            Return s1
        End Function

        Private Shared Function FormatMessageBoxCaption(ByVal caption As String) As String
            If System.String.IsNullOrEmpty(caption) Then
                Return "Sublight?"
            End If
            Return System.String.Format("Sublight - {0}?", caption)
        End Function

        Public Shared Sub FreeResources()
            If Sublight.BaseForm.Session <> System.Guid.Empty Then
                Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                    Try
                        sublight1.LogOutAsync(Sublight.BaseForm.Session)
                    Catch e As System.Exception
                        Sublight.BaseForm.ReportException("Sublight.BaseForm.FreeResources?", e)
                    End Try
                    Sublight.BaseForm.session = System.Guid.Empty
                End Using
            End If
        End Sub

        Private Shared Function GetAllControls(ByVal ctrls As System.Collections.IList) As System.Collections.Generic.List(Of System.Windows.Forms.Control)
            Dim list1 As System.Collections.Generic.List(Of System.Windows.Forms.Control) = New System.Collections.Generic.List(Of System.Windows.Forms.Control)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In ctrls
                list1.Add(control1)
                Dim list2 As System.Collections.Generic.List(Of System.Windows.Forms.Control) = Sublight.BaseForm.GetAllControls(control1.Controls)
                list1.AddRange(list2)
            Next
            Return list1
        End Function

        Protected Shared Function GetArgs() As String()
            Return New string() { _
                                  System.String.Format("IID={0}?", Sublight.Properties.Settings.Default.UserId), _
                                  System.String.Format("AppLanguage={0}?", Sublight.Properties.Settings.Default.AppLanguage) }
        End Function

        Friend Shared Function GetSetting(ByVal name As String, ByVal defaultValue As String) As String
            If (Sublight.BaseForm.m_settings) Is Nothing Then
                Return defaultValue
            End If
            If Sublight.BaseForm.m_settings.ContainsKey(name) Then
                Return Sublight.BaseForm.m_settings.get_Item(name)
            End If
            Return defaultValue
        End Function

        Friend Shared Function GetSetting(ByVal name As String) As String
            Return Sublight.BaseForm.GetSetting(name, Nothing)
        End Function

        Private Shared Function HandleConnectionDifficulties(ByVal ex As System.Exception) As Boolean
            Dim flag1 As Boolean = False
            Dim s1 As String = Nothing
            If TryCast(ex, System.Net.Sockets.SocketException) Then
                flag1 = True
                Dim socketException1 As System.Net.Sockets.SocketException = TryCast(ex, System.Net.Sockets.SocketException)
                s1 = System.String.Format("SocketException.ErrorCode={0}?", socketException1.ErrorCode)
            ElseIf TryCast(ex, System.Net.WebException) Then
                Dim webException1 As System.Net.WebException = TryCast(ex, System.Net.WebException)
                If (webException1.Status = System.Net.WebExceptionStatus.NameResolutionFailure) OrElse (webException1.Status = System.Net.WebExceptionStatus.ConnectFailure) OrElse (webException1.Status = System.Net.WebExceptionStatus.ConnectionClosed) Then
                    flag1 = True
                    s1 = System.String.Format("WebException.Status={0}?", webException1.Status)
                End If
            End If
            If flag1 Then
                Dim objArr1 As Object() = New object() { _
                                                         s1, _
                                                         System.Environment.NewLine }
                System.Windows.Forms.MessageBox.Show(Sublight.Globals.MainForm, Sublight.BaseForm.FormatMessage("There are some network difficulties. Please check your network connection and try again. {1}{1}[{0}]?", objArr1), Sublight.BaseForm.FormatMessageBoxCaption(Sublight.Translation.MessageBox_Error), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand)
            End If
            Return flag1
        End Function

        Friend Shared Function HandleWSErrors(ByVal form As Sublight.BaseForm, ByVal asyncResultCompletedEventArgs As Object) As Boolean
            Dim flag2 As Boolean

            Try
                If (form) Is Nothing Then
                    Return False
                End If
                If (asyncResultCompletedEventArgs) Is Nothing Then
                    Return False
                End If
                Dim propertyInfo1 As System.Reflection.PropertyInfo = asyncResultCompletedEventArgs.GetType().GetProperty("Error?")
                If Not (propertyInfo1) Is Nothing Then
                    Dim exception1 As System.Exception = TryCast(propertyInfo1.GetValue(asyncResultCompletedEventArgs, Nothing), System.Exception)
                    If Not (exception1) Is Nothing Then
                        Dim objArr1 As Object() = New object() { exception1.Message }
                        form.ShowError(Sublight.Translation.Application_Error_WebException, objArr1)
                        Return True
                    End If
                End If
                propertyInfo1 = asyncResultCompletedEventArgs.GetType().GetProperty("Result?")
                If Not (propertyInfo1) Is Nothing Then
                    Dim flag1 As Boolean = DirectCast(propertyInfo1.GetValue(asyncResultCompletedEventArgs, Nothing), bool)
                    If Not flag1 Then
                        Dim s1 As String = Nothing
                        propertyInfo1 = asyncResultCompletedEventArgs.GetType().GetProperty("error?")
                        If Not (propertyInfo1) Is Nothing Then
                            s1 = TryCast(propertyInfo1.GetValue(asyncResultCompletedEventArgs, Nothing), string)
                        End If
                        If System.String.IsNullOrEmpty(s1) Then
                            s1 = "N/A?"
                        End If
                        Dim objArr2 As Object() = New object() { s1 }
                        form.ShowError(Sublight.Translation.Application_WS_Error, objArr2)
                        Return True
                    End If
                End If
                flag2 = False
            Catch 
                flag2 = False
            End Try
            Return flag2
        End Function

        Friend Shared Function IsAdministrator() As Boolean
            Return Sublight.BaseForm.IsInRole(Sublight.Plugins.Core.Role.Administrator)
        End Function

        Protected Shared Function IsInRole(ByVal name As String) As Boolean
            Dim flag1 As Boolean

            If (Sublight.BaseForm.m_roles) Is Nothing Then
                Return False
            End If
            Dim sArr1 As String() = Sublight.BaseForm.m_roles
            Dim i1 As Integer = 0
            While i1 < sArr1.Length
                Dim s1 As String = sArr1(i1)
                If System.String.Compare(s1, name, True) = 0 Then
                    Return True
                End If
                i1 = i1 + 1
            End While
            Return False
        End Function

        Friend Shared Function IsSubtitleEditor(ByVal subtitle As Sublight.WS.Subtitle) As Boolean
            Dim flag1 As Boolean

            If Sublight.BaseForm.IsInRole(Sublight.Plugins.Core.Role.SubtitleEditor) Then
                If Not (Sublight.BaseForm.PrimaryLanguages) Is Nothing Then
                    Dim subtitleLanguageArr1 As Sublight.WS.SubtitleLanguage() = Sublight.BaseForm.PrimaryLanguages
                    Dim i1 As Integer = 0
                    While i1 < subtitleLanguageArr1.Length
                        Dim subtitleLanguage1 As Sublight.WS.SubtitleLanguage = CType(subtitleLanguageArr1(i1), Sublight.WS.SubtitleLanguage)
                        If subtitleLanguage1 = subtitle.Language Then
                            Return True
                        End If
                        i1 = i1 + 1
                    End While
                End If
                Return False
            End If
            Return False
        End Function

        Private Shared Sub ReportError(ByVal message As String)
            If Sublight.BaseForm.GetSetting("EnableErrorReporting?", "1?") <> "1?" Then
                Return
            End If
            If Sublight.Properties.Settings.Default.App_ErrorHandling = Sublight.Types.ErrorHandling.DoNotDisplayDialog Then
                Return
            End If
            If (Sublight.Properties.Settings.Default.App_ErrorHandling = Sublight.Types.ErrorHandling.DisplayDialogAfterOneDay) AndAlso Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.App_ErrorHandling_LastError) Then
                Try
                    Dim dateTime1 As System.DateTime = System.DateTime.ParseExact(Sublight.Properties.Settings.Default.App_ErrorHandling_LastError, "yyyyMMddhhmmss?", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Dim timeSpan1 As System.TimeSpan = System.DateTime.UtcNow - dateTime1
                    If timeSpan1.TotalDays < 1.0R Then
                        Return
                    End If
                Catch 
                End Try
            End If
            If (Sublight.Properties.Settings.Default.App_ErrorHandling = Sublight.Types.ErrorHandling.DisplayDialogAfterOneWeek) AndAlso Not System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.App_ErrorHandling_LastError) Then
                Try
                    Dim dateTime2 As System.DateTime = System.DateTime.ParseExact(Sublight.Properties.Settings.Default.App_ErrorHandling_LastError, "yyyyMMddhhmmss?", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Dim timeSpan2 As System.TimeSpan = System.DateTime.UtcNow - dateTime2
                    If timeSpan2.TotalDays < 7.0R Then
                        Return
                    End If
                Catch 
                End Try
            End If
            Sublight.Properties.Settings.Default.App_ErrorHandling = Sublight.Types.ErrorHandling.DisplayDialog
            Dim dateTime3 As System.DateTime = System.DateTime.UtcNow
            Sublight.Properties.Settings.Default.App_ErrorHandling_LastError = dateTime3.ToString("yyyyMMddhhmmss?")
            Sublight.BaseForm.SaveUserSettingsSilent()
            If System.String.IsNullOrEmpty(message) Then
                message = "message not available?"
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            stringBuilder1.AppendLine(System.String.Format("Version: {0}?", Sublight.BaseForm.ClientInfo))
            stringBuilder1.AppendLine(System.String.Format("Code: ERR{0}?", message.GetHashCode()))
            stringBuilder1.AppendLine(System.String.Format("Details: {0}?", message))
            stringBuilder1.AppendLine(System.String.Format("Session: {0}?", Sublight.BaseForm.Session))
            stringBuilder1 = stringBuilder1.Replace("<br />?", System.String.Empty)
            stringBuilder1 = stringBuilder1.Replace("<b>?", System.String.Empty)
            stringBuilder1 = stringBuilder1.Replace("</b>?", System.String.Empty)
            Using frmAppFeedback1 As Sublight.FrmAppFeedback = New Sublight.FrmAppFeedback(message, stringBuilder1.ToString())
                frmAppFeedback1.ShowDialog(Sublight.Globals.MainForm)
            End Using
        End Sub

        Friend Shared Sub ReportError(ByVal source As String, ByVal message As String)
            Try
                If System.String.IsNullOrEmpty(source) Then
                    source = "N/A?"
                End If
                If System.String.IsNullOrEmpty(message) Then
                    message = "N/A?"
                End If
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                stringBuilder1.AppendFormat("<b>{0} (ReportError):</b><br />?", source)
                stringBuilder1.AppendLine()
                stringBuilder1.Append(message)
                Sublight.BaseForm.ReportError(stringBuilder1.ToString())
            Catch 
            End Try
        End Sub

        Friend Shared Sub ReportException(ByVal source As String, ByVal exception As System.Exception)
            If (exception) Is Nothing Then
                Return
            End If
            If Sublight.BaseForm.HandleConnectionDifficulties(exception) Then
                Return
            End If
            Try
                If System.String.IsNullOrEmpty(source) Then
                    source = "N/A?"
                End If
                Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
                stringBuilder1.AppendFormat("<b>{0} (ReportException):</b><br />?", source)
                stringBuilder1.AppendLine()
                stringBuilder1.Append(Sublight.BaseForm.ExceptionToString("Exception?", exception))
                If Not (exception.InnerException) Is Nothing Then
                    stringBuilder1.AppendLine()
                    stringBuilder1.Append(Sublight.BaseForm.ExceptionToString("InnerException?", exception.InnerException))
                End If
                Sublight.BaseForm.ReportError(stringBuilder1.ToString())
            Catch 
            End Try
        End Sub

        Private Shared Sub SaveUserSettingsHelper()
            If (Sublight.Properties.Settings.Default.MyMovies_Folders) Is Nothing Then
                Sublight.Properties.Settings.Default.MyMovies_Folders = New Sublight.Types.MovieFolderCollection
            End If
            If (Sublight.Properties.Settings.Default.View_MyDownloads) Is Nothing Then
                Sublight.Properties.Settings.Default.View_MyDownloads = New Sublight.Types.DownloadedSubtitleCollection
            End If
            If (Sublight.Properties.Settings.Default.Search_Filter_Language) Is Nothing Then
                Sublight.Properties.Settings.Default.Search_Filter_Language = New Sublight.Types.SubtitleLanguageCollection
            End If
            If (Sublight.Properties.Settings.Default.Search_Filter_Genre) Is Nothing Then
                Sublight.Properties.Settings.Default.Search_Filter_Genre = New Sublight.Types.GenreCollection
            End If
            If (Sublight.Properties.Settings.Default.Application_Filter_Language) Is Nothing Then
                Sublight.Properties.Settings.Default.Application_Filter_Language = New Sublight.Types.SubtitleLanguageCollection
            End If
        End Sub

        Friend Shared Sub SaveUserSettingsSilent()
            Dim exception1 As System.Exception = Nothing
            Dim i1 As Integer = 0
            While i1 < 5
                Try
                    Sublight.BaseForm.SaveUserSettingsHelper()
                    Sublight.Properties.Settings.Default.Save()
                    Return
                Catch e As System.Exception
                    exception1 = e
                End Try
                System.Threading.Thread.Sleep(100)
                i1 = i1 + 1
            End While
            If Not (exception1) Is Nothing Then
                Sublight.BaseForm.ReportException("WinUI.BaseForm.SaveUserSettingsSilent?", exception1)
                Return
            End If
            Sublight.BaseForm.ReportError("WinUI.BaseForm.SaveUserSettingsSilent: exception = null?")
        End Sub

        Friend Shared Function ShowQuestion(ByVal owner As System.Windows.Forms.IWin32Window, ByVal format As String, <System.ParamArray> ByVal args As Object()) As System.Windows.Forms.DialogResult
            Return Sublight.BaseForm.ShowQuestion(owner, format, System.Windows.Forms.MessageBoxIcon.Question, args)
        End Function

        Friend Shared Function ShowQuestion(ByVal owner As System.Windows.Forms.IWin32Window, ByVal format As String, ByVal icon As System.Windows.Forms.MessageBoxIcon, <System.ParamArray> ByVal args As Object()) As System.Windows.Forms.DialogResult
            Dim dialogResult1 As System.Windows.Forms.DialogResult

            Try
                Dim form1 As System.Windows.Forms.Form = TryCast(owner, System.Windows.Forms.Form)
                If ((form1) Is Nothing) OrElse form1.IsDisposed Then
                    form1 = Nothing
                Else 
                    Sublight.BaseForm.FlashWindow(form1)
                End If
                If Sublight.BaseForm.EnableMessageBoxWorkAround Then
                    Sublight.MyUtility.MessageBoxHelper.PrepToCenterMessageBoxOnForm(form1)
                End If
                dialogResult1 = System.Windows.Forms.MessageBox.Show(form1, Sublight.BaseForm.FormatMessage(format, args), Sublight.BaseForm.FormatMessageBoxCaption(Sublight.Translation.MessageBox_Question), System.Windows.Forms.MessageBoxButtons.YesNo, icon)
            Catch e As System.Exception
                Sublight.BaseForm.ReportException("WinUI.BaseForm.ShowQuestion?", e)
                dialogResult1 = System.Windows.Forms.DialogResult.None
            End Try
            Return dialogResult1
        End Function

        Friend Shared Sub ShowWarning(ByVal owner As System.Windows.Forms.IWin32Window, ByVal format As String, <System.ParamArray> ByVal args As Object())
            Try
                Dim form1 As System.Windows.Forms.Form = TryCast(owner, System.Windows.Forms.Form)
                If ((form1) Is Nothing) OrElse form1.IsDisposed Then
                    form1 = Nothing
                Else 
                    Sublight.BaseForm.FlashWindow(form1)
                End If
                If Sublight.BaseForm.EnableMessageBoxWorkAround Then
                    Sublight.MyUtility.MessageBoxHelper.PrepToCenterMessageBoxOnForm(form1)
                End If
                System.Windows.Forms.MessageBox.Show(form1, Sublight.BaseForm.FormatMessage(format, args), Sublight.BaseForm.FormatMessageBoxCaption(Sublight.Translation.MessageBox_Warning), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
            Catch e As System.Exception
                Sublight.BaseForm.ReportException("WinUI.BaseForm.ShowWarning?", e)
            End Try
        End Sub

        Protected Shared Function ToHash(ByVal input As String) As String
            If (input) Is Nothing Then
                Return Nothing
            End If
            Dim md5_1 As System.Security.Cryptography.MD5 = New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim bArr1 As Byte() = md5_1.ComputeHash(System.Text.Encoding.Unicode.GetBytes(input))
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim bArr2 As Byte() = bArr1
            Dim i1 As Integer = 0
            While i1 < bArr2.Length
                Dim b1 As Byte = bArr2(i1)
                stringBuilder1.Append(b1.ToString("x2?"))
                i1 = i1 + 1
            End While
            Return stringBuilder1.ToString()
        End Function

        Friend Shared Sub UpdateAppLanguage(ByVal source As String, ByVal language As String)
            Dim flag1 As Boolean = False
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            If System.String.IsNullOrEmpty(language) OrElse (language.Trim().Length <= 0) Then
                flag1 = True
                stringBuilder1.AppendLine("UpdateAppLanguage.language is not set<br />?")
            End If
            Sublight.Properties.Settings.Default.AppLanguage = language
            If System.String.IsNullOrEmpty(Sublight.Properties.Settings.Default.AppLanguage) OrElse (Sublight.Properties.Settings.Default.AppLanguage.Trim().Length <= 0) Then
                flag1 = True
                stringBuilder1.AppendLine("Settings.Default.AppLanguage is not set<br />?")
            End If
            If flag1 Then
                Sublight.BaseForm.ReportError(source, stringBuilder1.ToString())
            End If
        End Sub

    End Class ' class BaseForm

End Namespace

