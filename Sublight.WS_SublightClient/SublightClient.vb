Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Threading
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
Imports Sublight.MyUtility
Imports Sublight.Properties

Namespace Sublight.WS_SublightClient

    <System.Web.Services.WebServiceBinding(Name = "SublightClientSoap", Namespace = "http://www.sublight.si/"), _
    System.Diagnostics.DebuggerStepThrough, _
    System.ComponentModel.DesignerCategory("code"), _
    System.CodeDom.Compiler.GeneratedCode("System.Web.Services", "2.0.50727.4927")> _
    Public Class SublightClient
        Inherits Sublight.MyUtility.SublightSoap

        Private AddPaymentOperationCompleted As System.Threading.SendOrPostCallback 

        Private CalculatePointsOperationCompleted As System.Threading.SendOrPostCallback 

        Private CheckForUpdatesOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetAdOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetContributions2OperationCompleted As System.Threading.SendOrPostCallback 

        Private GetHistory2OperationCompleted As System.Threading.SendOrPostCallback 

        Private GetHistoryOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetOnlineSublightUsersOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetPaymentsOperationCompleted As System.Threading.SendOrPostCallback 

        Private PingOperationCompleted As System.Threading.SendOrPostCallback 

        Private ReportError2OperationCompleted As System.Threading.SendOrPostCallback 

        Private ReportErrorOperationCompleted As System.Threading.SendOrPostCallback 

        Private ReportInfoOperationCompleted As System.Threading.SendOrPostCallback 

        Private SendCommentResponseOperationCompleted As System.Threading.SendOrPostCallback 

        Private SendMailOperationCompleted As System.Threading.SendOrPostCallback 

        Private UpdateAdStatisticOperationCompleted As System.Threading.SendOrPostCallback 
        Private useDefaultCredentialsSetExplicitly As Boolean 

        Public Event AddPaymentCompleted As Sublight.WS_SublightClient.AddPaymentCompletedEventHandler
        Public Event CalculatePointsCompleted As Sublight.WS_SublightClient.CalculatePointsCompletedEventHandler
        Public Event CheckForUpdatesCompleted As Sublight.WS_SublightClient.CheckForUpdatesCompletedEventHandler
        Public Event GetAdCompleted As Sublight.WS_SublightClient.GetAdCompletedEventHandler
        Public Event GetContributions2Completed As Sublight.WS_SublightClient.GetContributions2CompletedEventHandler
        Public Event GetHistory2Completed As Sublight.WS_SublightClient.GetHistory2CompletedEventHandler
        Public Event GetHistoryCompleted As Sublight.WS_SublightClient.GetHistoryCompletedEventHandler
        Public Event GetOnlineSublightUsersCompleted As Sublight.WS_SublightClient.GetOnlineSublightUsersCompletedEventHandler
        Public Event GetPaymentsCompleted As Sublight.WS_SublightClient.GetPaymentsCompletedEventHandler
        Public Event PingCompleted As Sublight.WS_SublightClient.PingCompletedEventHandler
        Public Event ReportError2Completed As Sublight.WS_SublightClient.ReportError2CompletedEventHandler
        Public Event ReportErrorCompleted As Sublight.WS_SublightClient.ReportErrorCompletedEventHandler
        Public Event ReportInfoCompleted As Sublight.WS_SublightClient.ReportInfoCompletedEventHandler
        Public Event SendCommentResponseCompleted As Sublight.WS_SublightClient.SendCommentResponseCompletedEventHandler
        Public Event SendMailCompleted As Sublight.WS_SublightClient.SendMailCompletedEventHandler
        Public Event UpdateAdStatisticCompleted As Sublight.WS_SublightClient.UpdateAdStatisticCompletedEventHandler

        Public Shadows Property Url As String
            Get
                Return MyBase.Url
            End Get
            Set
                If IsLocalFileSystemWebService(MyBase.Url) AndAlso Not useDefaultCredentialsSetExplicitly AndAlso Not IsLocalFileSystemWebService(value) Then
                    MyBase.UseDefaultCredentials = False
                End If
                MyBase.Url = value
            End Set
        End Property

        Public Shadows Property UseDefaultCredentials As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                useDefaultCredentialsSetExplicitly = True
            End Set
        End Property

        Public Sub New()
            Url = Sublight.Properties.Settings.Default.Sublight_WS_SublightClient
            If IsLocalFileSystemWebService(Url) Then
                UseDefaultCredentials = True
                useDefaultCredentialsSetExplicitly = False
                Return
            End If
            useDefaultCredentialsSetExplicitly = True
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/AddPayment", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function AddPayment(ByVal session As System.Guid, ByVal type As Sublight.WS_SublightClient.PaymentType, ByVal uiLang As String, ByVal args As String(), ByVal comment As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     type, _
                                                     uiLang, _
                                                     args, _
                                                     comment }
            Dim objArr1 As Object() = Invoke("AddPayment?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub AddPaymentAsync(ByVal session As System.Guid, ByVal type As Sublight.WS_SublightClient.PaymentType, ByVal uiLang As String, ByVal args As String(), ByVal comment As String)
            AddPaymentAsync(session, type, uiLang, args, comment, Nothing)
        End Sub

        Public Sub AddPaymentAsync(ByVal session As System.Guid, ByVal type As Sublight.WS_SublightClient.PaymentType, ByVal uiLang As String, ByVal args As String(), ByVal comment As String, ByVal userState As Object)
            If (AddPaymentOperationCompleted) Is Nothing Then
                AddPaymentOperationCompleted = New System.Threading.SendOrPostCallback(OnAddPaymentOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     type, _
                                                     uiLang, _
                                                     args, _
                                                     comment }
            InvokeAsync("AddPayment?", objArr1, AddPaymentOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/CalculatePoints", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function CalculatePoints(ByVal session As System.Guid, ByVal donationAmount As Decimal (), ByRef points As Integer(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     donationAmount }
            Dim objArr1 As Object() = Invoke("CalculatePoints?", objArr2)
            points = CType(objArr1(1), Integer[])
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub CalculatePointsAsync(ByVal session As System.Guid, ByVal donationAmount As Decimal ())
            CalculatePointsAsync(session, donationAmount, Nothing)
        End Sub

        Public Sub CalculatePointsAsync(ByVal session As System.Guid, ByVal donationAmount As Decimal (), ByVal userState As Object)
            If (CalculatePointsOperationCompleted) Is Nothing Then
                CalculatePointsOperationCompleted = New System.Threading.SendOrPostCallback(OnCalculatePointsOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     donationAmount }
            InvokeAsync("CalculatePoints?", objArr1, CalculatePointsOperationCompleted, userState)
        End Sub

        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/CheckForUpdates", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function CheckForUpdates(ByVal currentVersion As String, ByRef newVersion As Sublight.WS_SublightClient.VersionInfo, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { currentVersion }
            Dim objArr1 As Object() = Invoke("CheckForUpdates?", objArr2)
            newVersion = CType(objArr1(1), Sublight.WS_SublightClient.VersionInfo)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub CheckForUpdatesAsync(ByVal currentVersion As String)
            CheckForUpdatesAsync(currentVersion, Nothing)
        End Sub

        Public Sub CheckForUpdatesAsync(ByVal currentVersion As String, ByVal userState As Object)
            If (CheckForUpdatesOperationCompleted) Is Nothing Then
                CheckForUpdatesOperationCompleted = New System.Threading.SendOrPostCallback(OnCheckForUpdatesOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { currentVersion }
            InvokeAsync("CheckForUpdates?", objArr1, CheckForUpdatesOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetAd", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetAd(ByVal session As System.Guid, ByRef id As System.Guid, ByRef banner As String, ByRef target As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetAd?", objArr2)
            id = DirectCast(objArr1(1), System.Guid)
            banner = CType(objArr1(2), string)
            target = CType(objArr1(3), string)
            error = CType(objArr1(4), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetAdAsync(ByVal session As System.Guid)
            GetAdAsync(session, Nothing)
        End Sub

        Public Sub GetAdAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (GetAdOperationCompleted) Is Nothing Then
                GetAdOperationCompleted = New System.Threading.SendOrPostCallback(OnGetAdOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetAd?", objArr1, GetAdOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetContributions2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetContributions2(ByVal session As System.Guid, ByRef ds As System.Data.DataSet, ByRef effectivePoints As Double, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetContributions2?", objArr2)
            ds = CType(objArr1(1), System.Data.DataSet)
            effectivePoints = DirectCast(objArr1(2), double)
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetContributions2Async(ByVal session As System.Guid)
            GetContributions2Async(session, Nothing)
        End Sub

        Public Sub GetContributions2Async(ByVal session As System.Guid, ByVal userState As Object)
            If (GetContributions2OperationCompleted) Is Nothing Then
                GetContributions2OperationCompleted = New System.Threading.SendOrPostCallback(OnGetContributions2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetContributions2?", objArr1, GetContributions2OperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetHistory", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetHistory(ByRef versions As Sublight.WS_SublightClient.VersionInfo(), ByRef error As String) As Boolean
            Dim objArr1 As Object() = Invoke("GetHistory?", New object(0) {})
            versions = CType(objArr1(1), Sublight.WS_SublightClient.VersionInfo[])
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetHistory2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetHistory2(ByVal appVersion As String, ByRef versions As Sublight.WS_SublightClient.VersionInfo(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { appVersion }
            Dim objArr1 As Object() = Invoke("GetHistory2?", objArr2)
            versions = CType(objArr1(1), Sublight.WS_SublightClient.VersionInfo[])
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetHistory2Async(ByVal appVersion As String, ByVal userState As Object)
            If (GetHistory2OperationCompleted) Is Nothing Then
                GetHistory2OperationCompleted = New System.Threading.SendOrPostCallback(OnGetHistory2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { appVersion }
            InvokeAsync("GetHistory2?", objArr1, GetHistory2OperationCompleted, userState)
        End Sub

        Public Sub GetHistory2Async(ByVal appVersion As String)
            GetHistory2Async(appVersion, Nothing)
        End Sub

        Public Sub GetHistoryAsync(ByVal userState As Object)
            If (GetHistoryOperationCompleted) Is Nothing Then
                GetHistoryOperationCompleted = New System.Threading.SendOrPostCallback(OnGetHistoryOperationCompleted)
            End If
            InvokeAsync("GetHistory?", New object(0) {}, GetHistoryOperationCompleted, userState)
        End Sub

        Public Sub GetHistoryAsync()
            GetHistoryAsync(Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetOnlineSublightUsers", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetOnlineSublightUsers(ByVal session As System.Guid, ByRef numberOfUsers As Integer, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetOnlineSublightUsers?", objArr2)
            numberOfUsers = DirectCast(objArr1(1), int)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetOnlineSublightUsersAsync(ByVal session As System.Guid)
            GetOnlineSublightUsersAsync(session, Nothing)
        End Sub

        Public Sub GetOnlineSublightUsersAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (GetOnlineSublightUsersOperationCompleted) Is Nothing Then
                GetOnlineSublightUsersOperationCompleted = New System.Threading.SendOrPostCallback(OnGetOnlineSublightUsersOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetOnlineSublightUsers?", objArr1, GetOnlineSublightUsersOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetPayments", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetPayments(ByVal session As System.Guid, ByRef ds As System.Data.DataSet, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetPayments?", objArr2)
            ds = CType(objArr1(1), System.Data.DataSet)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetPaymentsAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (GetPaymentsOperationCompleted) Is Nothing Then
                GetPaymentsOperationCompleted = New System.Threading.SendOrPostCallback(OnGetPaymentsOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetPayments?", objArr1, GetPaymentsOperationCompleted, userState)
        End Sub

        Public Sub GetPaymentsAsync(ByVal session As System.Guid)
            GetPaymentsAsync(session, Nothing)
        End Sub

        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url) Is Nothing) OrElse url = System.String.Empty Then
                Return False
            End If
            Dim uri1 As System.Uri = New System.Uri(url)
            If (uri1.Port >= 1024) AndAlso (System.String.Compare(uri1.Host, "localHost?", System.StringComparison.OrdinalIgnoreCase) = 0) Then
                Return True
            End If
            Return False
        End Function

        Private Sub OnAddPaymentOperationCompleted(ByVal arg As Object)
            If Not (AddPaymentCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddPaymentCompleted(Me, New Sublight.WS_SublightClient.AddPaymentCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnCalculatePointsOperationCompleted(ByVal arg As Object)
            If Not (CalculatePointsCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CalculatePointsCompleted(Me, New Sublight.WS_SublightClient.CalculatePointsCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnCheckForUpdatesOperationCompleted(ByVal arg As Object)
            If Not (CheckForUpdatesCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CheckForUpdatesCompleted(Me, New Sublight.WS_SublightClient.CheckForUpdatesCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetAdOperationCompleted(ByVal arg As Object)
            If Not (GetAdCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetAdCompleted(Me, New Sublight.WS_SublightClient.GetAdCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetContributions2OperationCompleted(ByVal arg As Object)
            If Not (GetContributions2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetContributions2Completed(Me, New Sublight.WS_SublightClient.GetContributions2CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetHistory2OperationCompleted(ByVal arg As Object)
            If Not (GetHistory2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetHistory2Completed(Me, New Sublight.WS_SublightClient.GetHistory2CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetHistoryOperationCompleted(ByVal arg As Object)
            If Not (GetHistoryCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetHistoryCompleted(Me, New Sublight.WS_SublightClient.GetHistoryCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetOnlineSublightUsersOperationCompleted(ByVal arg As Object)
            If Not (GetOnlineSublightUsersCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetOnlineSublightUsersCompleted(Me, New Sublight.WS_SublightClient.GetOnlineSublightUsersCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetPaymentsOperationCompleted(ByVal arg As Object)
            If Not (GetPaymentsCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetPaymentsCompleted(Me, New Sublight.WS_SublightClient.GetPaymentsCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnPingOperationCompleted(ByVal arg As Object)
            If Not (PingCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent PingCompleted(Me, New Sublight.WS_SublightClient.PingCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnReportError2OperationCompleted(ByVal arg As Object)
            If Not (ReportError2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ReportError2Completed(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnReportErrorOperationCompleted(ByVal arg As Object)
            If Not (ReportErrorCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ReportErrorCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnReportInfoOperationCompleted(ByVal arg As Object)
            If Not (ReportInfoCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ReportInfoCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSendCommentResponseOperationCompleted(ByVal arg As Object)
            If Not (SendCommentResponseCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SendCommentResponseCompleted(Me, New Sublight.WS_SublightClient.SendCommentResponseCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSendMailOperationCompleted(ByVal arg As Object)
            If Not (SendMailCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SendMailCompleted(Me, New Sublight.WS_SublightClient.SendMailCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnUpdateAdStatisticOperationCompleted(ByVal arg As Object)
            If Not (UpdateAdStatisticCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent UpdateAdStatisticCompleted(Me, New Sublight.WS_SublightClient.UpdateAdStatisticCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/Ping", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function Ping() As String
            Dim objArr1 As Object() = Invoke("Ping?", New object(0) {})
            Return CType(objArr1(0), string)
        End Function

        Public Sub PingAsync(ByVal userState As Object)
            If (PingOperationCompleted) Is Nothing Then
                PingOperationCompleted = New System.Threading.SendOrPostCallback(OnPingOperationCompleted)
            End If
            InvokeAsync("Ping?", New object(0) {}, PingOperationCompleted, userState)
        End Sub

        Public Sub PingAsync()
            PingAsync(Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/ReportError", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Sub ReportError(ByVal id As System.Guid, ByVal session As System.Guid, ByVal clientInfo As String, ByVal error As String)
            Dim objArr1 As Object() = New object() { _
                                                     id, _
                                                     session, _
                                                     clientInfo, _
                                                     error }
            Invoke("ReportError?", objArr1)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/ReportError2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Sub ReportError2(ByVal id As System.Guid, ByVal session As System.Guid, ByVal code As String, ByVal clientInfo As String, ByVal userComment As String, <System.Xml.Serialization.XmlElement(IsNullable = True)> ByVal isErrorNoticable As System.Nullable(Of Boolean), ByVal error As String)
            Dim objArr1 As Object() = New object() { _
                                                     id, _
                                                     session, _
                                                     code, _
                                                     clientInfo, _
                                                     userComment, _
                                                     isErrorNoticable, _
                                                     error }
            Invoke("ReportError2?", objArr1)
        End Sub

        Public Sub ReportError2Async(ByVal id As System.Guid, ByVal session As System.Guid, ByVal code As String, ByVal clientInfo As String, ByVal userComment As String, ByVal isErrorNoticable As System.Nullable(Of Boolean), ByVal error As String, ByVal userState As Object)
            If (ReportError2OperationCompleted) Is Nothing Then
                ReportError2OperationCompleted = New System.Threading.SendOrPostCallback(OnReportError2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     id, _
                                                     session, _
                                                     code, _
                                                     clientInfo, _
                                                     userComment, _
                                                     isErrorNoticable, _
                                                     error }
            InvokeAsync("ReportError2?", objArr1, ReportError2OperationCompleted, userState)
        End Sub

        Public Sub ReportError2Async(ByVal id As System.Guid, ByVal session As System.Guid, ByVal code As String, ByVal clientInfo As String, ByVal userComment As String, ByVal isErrorNoticable As System.Nullable(Of Boolean), ByVal error As String)
            ReportError2Async(id, session, code, clientInfo, userComment, isErrorNoticable, error, Nothing)
        End Sub

        Public Sub ReportErrorAsync(ByVal id As System.Guid, ByVal session As System.Guid, ByVal clientInfo As String, ByVal error As String)
            ReportErrorAsync(id, session, clientInfo, error, Nothing)
        End Sub

        Public Sub ReportErrorAsync(ByVal id As System.Guid, ByVal session As System.Guid, ByVal clientInfo As String, ByVal error As String, ByVal userState As Object)
            If (ReportErrorOperationCompleted) Is Nothing Then
                ReportErrorOperationCompleted = New System.Threading.SendOrPostCallback(OnReportErrorOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     id, _
                                                     session, _
                                                     clientInfo, _
                                                     error }
            InvokeAsync("ReportError?", objArr1, ReportErrorOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/ReportInfo", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Sub ReportInfo(ByVal id As System.Guid, ByVal session As System.Guid, ByVal clientInfo As String, ByVal message As String)
            Dim objArr1 As Object() = New object() { _
                                                     id, _
                                                     session, _
                                                     clientInfo, _
                                                     message }
            Invoke("ReportInfo?", objArr1)
        End Sub

        Public Sub ReportInfoAsync(ByVal id As System.Guid, ByVal session As System.Guid, ByVal clientInfo As String, ByVal message As String, ByVal userState As Object)
            If (ReportInfoOperationCompleted) Is Nothing Then
                ReportInfoOperationCompleted = New System.Threading.SendOrPostCallback(OnReportInfoOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     id, _
                                                     session, _
                                                     clientInfo, _
                                                     message }
            InvokeAsync("ReportInfo?", objArr1, ReportInfoOperationCompleted, userState)
        End Sub

        Public Sub ReportInfoAsync(ByVal id As System.Guid, ByVal session As System.Guid, ByVal clientInfo As String, ByVal message As String)
            ReportInfoAsync(id, session, clientInfo, message, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SendCommentResponse", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SendCommentResponse(ByVal session As System.Guid, ByVal to As String, ByVal from As String, ByVal subject As String, ByVal message As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     to, _
                                                     from, _
                                                     subject, _
                                                     message }
            Dim objArr1 As Object() = Invoke("SendCommentResponse?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SendCommentResponseAsync(ByVal session As System.Guid, ByVal to As String, ByVal from As String, ByVal subject As String, ByVal message As String, ByVal userState As Object)
            If (SendCommentResponseOperationCompleted) Is Nothing Then
                SendCommentResponseOperationCompleted = New System.Threading.SendOrPostCallback(OnSendCommentResponseOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     to, _
                                                     from, _
                                                     subject, _
                                                     message }
            InvokeAsync("SendCommentResponse?", objArr1, SendCommentResponseOperationCompleted, userState)
        End Sub

        Public Sub SendCommentResponseAsync(ByVal session As System.Guid, ByVal to As String, ByVal from As String, ByVal subject As String, ByVal message As String)
            SendCommentResponseAsync(session, to, from, subject, message, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SendMail", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SendMail(ByVal session As System.Guid, ByVal userId As System.Guid, ByVal from As String, ByVal subject As String, ByVal message As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     userId, _
                                                     from, _
                                                     subject, _
                                                     message }
            Dim objArr1 As Object() = Invoke("SendMail?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SendMailAsync(ByVal session As System.Guid, ByVal userId As System.Guid, ByVal from As String, ByVal subject As String, ByVal message As String, ByVal userState As Object)
            If (SendMailOperationCompleted) Is Nothing Then
                SendMailOperationCompleted = New System.Threading.SendOrPostCallback(OnSendMailOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     userId, _
                                                     from, _
                                                     subject, _
                                                     message }
            InvokeAsync("SendMail?", objArr1, SendMailOperationCompleted, userState)
        End Sub

        Public Sub SendMailAsync(ByVal session As System.Guid, ByVal userId As System.Guid, ByVal from As String, ByVal subject As String, ByVal message As String)
            SendMailAsync(session, userId, from, subject, message, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/UpdateAdStatistic", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function UpdateAdStatistic(ByVal session As System.Guid, ByVal id As System.Guid, ByVal url As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     id, _
                                                     url }
            Dim objArr1 As Object() = Invoke("UpdateAdStatistic?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub UpdateAdStatisticAsync(ByVal session As System.Guid, ByVal id As System.Guid, ByVal url As String)
            UpdateAdStatisticAsync(session, id, url, Nothing)
        End Sub

        Public Sub UpdateAdStatisticAsync(ByVal session As System.Guid, ByVal id As System.Guid, ByVal url As String, ByVal userState As Object)
            If (UpdateAdStatisticOperationCompleted) Is Nothing Then
                UpdateAdStatisticOperationCompleted = New System.Threading.SendOrPostCallback(OnUpdateAdStatisticOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     id, _
                                                     url }
            InvokeAsync("UpdateAdStatistic?", objArr1, UpdateAdStatisticOperationCompleted, userState)
        End Sub

    End Class ' class SublightClient

End Namespace

