Imports System
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ICSharpCode.SharpZipLib.Zip
Imports Sublight
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight.MyUtility

    Friend NotInheritable Class WebServiceHandler

        Public Delegate Function DoCallEventHandler(ByVal wsh As Sublight.MyUtility.WebServiceHandler, ByVal ws As Sublight.WS.Sublight, ByVal args As Object(), ByRef result As Object()) As Boolean
        Public Delegate Sub OnExceptionHandler(ByVal ex As System.Exception)
        Public Delegate Sub OnResultHandler(ByVal result As Object())

        Private ReadOnly m_args As Object() 
        Private ReadOnly m_context As String 
        Private ReadOnly m_ctrl As System.Windows.Forms.Control 
        Private ReadOnly m_form As Sublight.BaseForm 

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <CancelRetry>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <DisplayLoader>k__BackingField As Boolean 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <IsBusy>k__BackingField As Boolean 

        Public Event DoCall As Sublight.MyUtility.WebServiceHandler.DoCallEventHandler
        Public Event OnCompleted As System.EventHandler
        Public Event OnException As Sublight.MyUtility.WebServiceHandler.OnExceptionHandler
        Public Event OnResult As Sublight.MyUtility.WebServiceHandler.OnResultHandler

        Public Property CancelRetry As Boolean
            Get
                Return <CancelRetry>k__BackingField
            End Get
            Set
                <CancelRetry>k__BackingField = value
            End Set
        End Property

        Public Property DisplayLoader As Boolean
            Get
                Return <DisplayLoader>k__BackingField
            End Get
            Set
                <DisplayLoader>k__BackingField = value
            End Set
        End Property

        Public Property IsBusy As Boolean
            Get
                Return <IsBusy>k__BackingField
            End Get
            Set
                <IsBusy>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal context As String, ByVal form As Sublight.BaseForm, ByVal ctrl As System.Windows.Forms.Control, ByVal args As Object())
            If (args) Is Nothing Then
                Throw New System.ArgumentException("args?")
            End If
            m_form = form
            m_ctrl = ctrl
            m_args = args
            m_context = context
            DisplayLoader = True
        End Sub

        Private Sub bw_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
            Dim objArr1 As Object()

            If (DoCallEvent) Is Nothing Then
                Return
            End If
            Using sublight1 As Sublight.WS.Sublight = New Sublight.WS.Sublight
                Dim exception1 As System.Exception = Nothing
                Try
                    If TryCast(e.Argument, Object[]) Then
                        GoTo label_0
                    End If
                    Dim objArr2 As Object() = New object() { }
                    If RaiseEvent DoCall(Me, sublight1, objArr2, objArr1) Then
                        e.Result = objArr1
                        Return
                    End If
                Catch e1 As System.Exception
                    exception1 = e1
                End Try
                e.Result = Nothing
                If Not (exception1) Is Nothing Then
                    Throw exception1
                End If
                Throw New System.Exception("General exception.?")
            End Using
        End Sub

        Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
            Try
                If Not (e.Error) Is Nothing Then
                    If TypeOf e.Error Is Sublight.Types.ErrorDownloadingExternalSubtitle AndAlso (TypeOf e.Error Is Sublight.Types.WSHException OrElse CType(e.Error, Sublight.Types.WSHException).Report) Then
                        Sublight.BaseForm.ReportException(System.String.Format("WinUI.MyUtility.WebServiceHandler.bw_RunWorkerCompleted ({0})?", m_context), e.Error)
                    End If
                    If Not (OnExceptionEvent) Is Nothing Then
                        RaiseEvent OnException(e.Error)
                    End If
                    IsBusy = False
                    Return
                End If
                If (Not (OnResultEvent) Is Nothing) AndAlso (TypeOf e.Result Is Object[]) Then
                    GoTo label_0
                End If
                Dim objArr1 As Object() = New object() { }
                RaiseEvent OnResult(objArr1)
                IsBusy = False
            Catch e1 As ICSharpCode.SharpZipLib.Zip.ZipException
                Sublight.BaseForm.ReportException("WinUI.MyUtility.WebServiceHandler.bw_RunWorkerCompleted (ZipException)?", e1)
                If Not (OnExceptionEvent) Is Nothing Then
                    RaiseEvent OnException(e1)
                End If
            Catch e2 As System.Exception
                Sublight.BaseForm.ReportException("WinUI.MyUtility.WebServiceHandler.bw_RunWorkerCompleted?", e2)
                If Not (OnExceptionEvent) Is Nothing Then
                    RaiseEvent OnException(e2)
                End If
            Finally
                If (Not (m_form) Is Nothing) AndAlso Not m_form.IsDisposed AndAlso DisplayLoader Then
                    m_form.HideLoader(m_ctrl)
                End If
                If Not (OnCompletedEvent) Is Nothing Then
                    RaiseEvent OnCompleted(Me, Nothing)
                End If
            End Try
        End Sub

        Public Sub RunWorkerAsync()
            If (Not (m_form) Is Nothing) AndAlso Not m_form.IsDisposed AndAlso DisplayLoader Then
                m_form.ShowLoader(m_ctrl)
            End If
            Using backgroundWorker1 As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
                IsBusy = True
                AddHandler backgroundWorker1.DoWork, AddressOf bw_DoWork
                AddHandler backgroundWorker1.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
                backgroundWorker1.RunWorkerAsync(m_args)
            End Using
        End Sub

    End Class ' class WebServiceHandler

End Namespace

