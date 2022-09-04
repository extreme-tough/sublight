Imports System
Imports System.ComponentModel
Imports System.Net
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Sublight
Imports Sublight.Properties
Imports Sublight.WS
Imports Sublight.WS_SublightClient

Namespace Sublight.MyUtility

    <System.Web.Services.WebServiceBinding> _
    Public Class SublightSoap
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private Class WsInfo

            Public Callback As System.Threading.SendOrPostCallback 
            Public MethodName As String 
            Public Parameters As Object() 
            Public UserState As Object 

            Public Sub New()
            End Sub

        End Class ' class WsInfo

        Private Class WsResult

            Public Callback As System.Threading.SendOrPostCallback 
            Public Result As Object() 
            Public UserState As Object 

            Public Sub New()
            End Sub

        End Class ' class WsResult

        Private Const _alternativeUrl As String  = "http://193.95.243.56"

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <UseSecureConnection>k__BackingField As Boolean 

        Private Shared _CustomProxy As System.Net.IWebProxy 
        Private Shared _LastStatusCode As System.Net.HttpStatusCode 
        Private Shared _webServiceUriSublightClient As System.Uri 
        Private Shared _webServiceUriSublightServer As System.Uri 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared <SublightUserAgent>k__BackingField As String 

        Public Property UseSecureConnection As Boolean
            Get
                Return <UseSecureConnection>k__BackingField
            End Get
            Set
                <UseSecureConnection>k__BackingField = value
            End Set
        End Property

        Protected Shared ReadOnly Property CustomProxy As System.Net.IWebProxy
            Get
                Return Sublight.MyUtility.SublightSoap._CustomProxy
            End Get
        End Property

        Protected Shared ReadOnly Property LastStatusCode As System.Net.HttpStatusCode
            Get
                Return Sublight.MyUtility.SublightSoap._LastStatusCode
            End Get
        End Property

        Public Shared Property SublightUserAgent As String
            Get
                Return Sublight.MyUtility.SublightSoap.<SublightUserAgent>k__BackingField
            End Get
            Set
                Sublight.MyUtility.SublightSoap.<SublightUserAgent>k__BackingField = value
            End Set
        End Property

        Friend Shared ReadOnly Property WebServiceUriSublightClient As System.Uri
            Get
                Return Sublight.MyUtility.SublightSoap._webServiceUriSublightClient
            End Get
        End Property

        Friend Shared ReadOnly Property WebServiceUriSublightServer As System.Uri
            Get
                Return Sublight.MyUtility.SublightSoap._webServiceUriSublightServer
            End Get
        End Property

        Public Sub New()
            EnableDecompression = True
        End Sub

        Shared Sub New()
            Sublight.MyUtility.SublightSoap._LastStatusCode = System.Net.HttpStatusCode.OK
        End Sub

        Private Sub bw_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
            Dim wsInfo1 As Sublight.MyUtility.SublightSoap.WsInfo = TryCast(e.Argument, Sublight.MyUtility.SublightSoap.WsInfo)
            If (wsInfo1) Is Nothing Then
                Return
            End If
            Dim wsResult1 As Sublight.MyUtility.SublightSoap.WsResult = New Sublight.MyUtility.SublightSoap.WsResult
            wsResult1.Callback = wsInfo1.Callback
            wsResult1.Result = Invoke(wsInfo1.MethodName, wsInfo1.Parameters)
            wsResult1.UserState = wsInfo1.UserState
            e.Result = wsResult1
        End Sub

        Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
            Dim backgroundWorker1 As System.ComponentModel.BackgroundWorker = TryCast(sender, System.ComponentModel.BackgroundWorker)
            If (backgroundWorker1) Is Nothing Then
                Return
            End If
            Dim wsResult1 As Sublight.MyUtility.SublightSoap.WsResult = TryCast(e.Result, Sublight.MyUtility.SublightSoap.WsResult)
            If (wsResult1) Is Nothing Then
                Return
            End If
            If Not (wsResult1.Callback) Is Nothing Then
                Dim objArr1 As Object() = New object() { _
                                                         wsResult1.Result, _
                                                         e.Error, _
                                                         e.Cancelled, _
                                                         wsResult1.UserState }
                Dim obj1 As Object = GetType(System.Web.Services.Protocols.InvokeCompletedEventArgs).Assembly.CreateInstance(GetType(System.Web.Services.Protocols.InvokeCompletedEventArgs).FullName, False, System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic, Nothing, objArr1, Nothing, Nothing)
                wsResult1.Callback.Invoke(obj1)
            End If
        End Sub

        Protected Shadows Function Invoke(ByVal methodName As String, ByVal parameters As Object()) As Object()
            Dim objArr2 As Object()

            Dim exception1 As System.Exception = Nothing
            Dim i1 As Integer = 0
            While i1 < Sublight.Globals.WS_NumberOfRetries
                Try
                    Dim objArr3 As Object() = New object() { methodName }
                    Sublight.Globals.DebugWriteLine("Calling method ""{0}""...?", objArr3)
                    Dim dateTime1 As System.DateTime = System.DateTime.UtcNow
                    Dim objArr1 As Object() = MyBase.Invoke(methodName, parameters)
                    Dim timeSpan1 As System.TimeSpan = System.DateTime.UtcNow - dateTime1
                    Dim objArr4 As Object() = New object() { _
                                                             methodName, _
                                                             timeSpan1.TotalMilliseconds }
                    Sublight.Globals.DebugWriteLine("Calling method ""{0}"" took {1:#,0} miliseconds.?", objArr4)
                    Return objArr1
                Catch e As System.Exception
                    exception1 = e
                    Sublight.Globals.DebugWriteLine(System.String.Format("Retrying web service call ({1})... ({0})?", i1 + 1, methodName), New object(0) {})
                    System.Threading.Thread.Sleep(Sublight.Globals.WS_SleepIntervalOnError)
                End Try
                i1 = i1 + 1
            End While
            If Not (exception1) Is Nothing Then
                Throw exception1
            End If
            Throw New System.Exception("Error calling web service.?")
        End Function

        Protected Shadows Sub InvokeAsync(ByVal methodName As String, ByVal parameters As Object(), ByVal callback As System.Threading.SendOrPostCallback, ByVal userState As Object)
            Using backgroundWorker1 As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
                Dim wsInfo1 As Sublight.MyUtility.SublightSoap.WsInfo = New Sublight.MyUtility.SublightSoap.WsInfo
                wsInfo1.MethodName = methodName
                wsInfo1.Parameters = parameters
                wsInfo1.UserState = userState
                wsInfo1.Callback = callback
                AddHandler backgroundWorker1.DoWork, AddressOf bw_DoWork
                AddHandler backgroundWorker1.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
                backgroundWorker1.RunWorkerAsync(wsInfo1)
            End Using
        End Sub

        Protected Overrides Function GetWebRequest(ByVal uri As System.Uri) As System.Net.WebRequest
            Dim httpWebRequest1 As System.Net.HttpWebRequest

            If TypeOf Me Is Sublight.WS.Sublight Then
                If UseSecureConnection Then
                    Dim s1 As String = Sublight.MyUtility.SublightSoap._webServiceUriSublightServer.ToString()
                    If Not System.Text.RegularExpressions.Regex.IsMatch(s1, "http://localhost:?", System.Text.RegularExpressions.RegexOptions.IgnoreCase) Then
                        s1 = System.Text.RegularExpressions.Regex.Replace(s1, "http://?", "https://?", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                        httpWebRequest1 = TryCast(MyBase.GetWebRequest(New System.Uri(s1)), System.Net.HttpWebRequest)
                    Else 
                        httpWebRequest1 = TryCast(MyBase.GetWebRequest(Sublight.MyUtility.SublightSoap._webServiceUriSublightServer), System.Net.HttpWebRequest)
                    End If
                Else 
                    httpWebRequest1 = TryCast(MyBase.GetWebRequest(Sublight.MyUtility.SublightSoap._webServiceUriSublightServer), System.Net.HttpWebRequest)
                End If
            ElseIf TypeOf Me Is Sublight.WS_SublightClient.SublightClient Then
                httpWebRequest1 = TryCast(MyBase.GetWebRequest(Sublight.MyUtility.SublightSoap._webServiceUriSublightClient), System.Net.HttpWebRequest)
            Else 
                Throw New System.Exception("Unknown web service.?")
            End If
            If Not (httpWebRequest1) Is Nothing Then
                If Not System.String.IsNullOrEmpty(Sublight.MyUtility.SublightSoap.SublightUserAgent) Then
                    httpWebRequest1.UserAgent = Sublight.MyUtility.SublightSoap.SublightUserAgent
                End If
                If (Not (Sublight.MyUtility.SublightSoap._CustomProxy) Is Nothing) AndAlso (httpWebRequest1.Proxy <> Sublight.MyUtility.SublightSoap._CustomProxy) Then
                    httpWebRequest1.Proxy = Sublight.MyUtility.SublightSoap._CustomProxy
                End If
                httpWebRequest1.KeepAlive = False
                httpWebRequest1.ProtocolVersion = System.Net.HttpVersion.Version11
            End If
            SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
            Return httpWebRequest1
        End Function

        Protected Overrides Function GetWebResponse(ByVal request As System.Net.WebRequest) As System.Net.WebResponse
            Dim webResponse1 As System.Net.WebResponse = MyBase.GetWebResponse(request)
            Dim httpWebResponse1 As System.Net.HttpWebResponse = TryCast(webResponse1, System.Net.HttpWebResponse)
            If Not (httpWebResponse1) Is Nothing Then
                Sublight.MyUtility.SublightSoap._LastStatusCode = httpWebResponse1.StatusCode
            Else 
                Sublight.MyUtility.SublightSoap._LastStatusCode = System.Net.HttpStatusCode.OK
            End If
            Return webResponse1
        End Function

        Public Shared Sub DiscoverUrl()
            Try
                System.Net.ServicePointManager.Expect100Continue = False
                Using sublightClient1 As Sublight.WS_SublightClient.SublightClient = New Sublight.WS_SublightClient.SublightClient
                    Sublight.MyUtility.SublightSoap._webServiceUriSublightClient = New System.Uri(Sublight.Properties.Settings.Default.Sublight_WS_SublightClient)
                    Sublight.MyUtility.SublightSoap._webServiceUriSublightServer = New System.Uri(Sublight.Properties.Settings.Default.Sublight_WS_Sublight)
                    Dim s1 As String = sublightClient1.Ping()
                    If System.String.Compare(s1, "PONG?", True) <> 0 Then
                        Throw New System.Exception("Unexpected result.?")
                    End If
                End Using
            Catch 
                Sublight.MyUtility.SublightSoap._webServiceUriSublightClient = New System.Uri(System.String.Format("{0}/API/WS/SublightClient.asmx?", "http://193.95.243.56?"))
                Sublight.MyUtility.SublightSoap._webServiceUriSublightServer = New System.Uri(System.String.Format("{0}/API/WS/Sublight.asmx?", "http://193.95.243.56?"))
            End Try
        End Sub

    End Class ' class SublightSoap

End Namespace

