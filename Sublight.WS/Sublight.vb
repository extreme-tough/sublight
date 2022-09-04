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

Namespace Sublight.WS

    <System.ComponentModel.DesignerCategory("code"), _
    System.CodeDom.Compiler.GeneratedCode("System.Web.Services", "2.0.50727.4927"), _
    System.Web.Services.WebServiceBinding(Name = "SublightSoap", Namespace = "http://www.sublight.si/"), _
    System.Diagnostics.DebuggerStepThrough> _
    Public Class Sublight
        Inherits Sublight.MyUtility.SublightSoap

        Private AddAlternativeTitleOperationCompleted As System.Threading.SendOrPostCallback 

        Private AddHashLink3OperationCompleted As System.Threading.SendOrPostCallback 

        Private AddHashLinkAutomatic3OperationCompleted As System.Threading.SendOrPostCallback 

        Private AddHashLinkSemiAutomatic3OperationCompleted As System.Threading.SendOrPostCallback 

        Private AddReleaseOperationCompleted As System.Threading.SendOrPostCallback 

        Private AddSubtitleCommentOperationCompleted As System.Threading.SendOrPostCallback 

        Private AddSubtitleThankOperationCompleted As System.Threading.SendOrPostCallback 

        Private ChangePasswordOperationCompleted As System.Threading.SendOrPostCallback 

        Private CheckSubtitle3OperationCompleted As System.Threading.SendOrPostCallback 

        Private DeleteSubtitleOperationCompleted As System.Threading.SendOrPostCallback 

        Private DownloadByID4OperationCompleted As System.Threading.SendOrPostCallback 

        Private FindIMDBOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetDetailsByHashOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetDetailsOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetDownloadTicket2OperationCompleted As System.Threading.SendOrPostCallback 

        Private GetDownloadTicketOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetFavoriteSubtitlesOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetHistoryOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetMyDownloadsOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetMyUploadsOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetNewSubtitlesOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetPosterOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetPosterUrlOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetReleasesOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetStatisticsOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetSubtitleByIdOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetSubtitleCommentsOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetSubtitleThanksOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetUserBySessionOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetUserInfoOperationCompleted As System.Threading.SendOrPostCallback 

        Private GetUserLog2OperationCompleted As System.Threading.SendOrPostCallback 

        Private LogIn6OperationCompleted As System.Threading.SendOrPostCallback 

        Private LogInAnonymous4OperationCompleted As System.Threading.SendOrPostCallback 

        Private LogInSecureOperationCompleted As System.Threading.SendOrPostCallback 

        Private LogOutOperationCompleted As System.Threading.SendOrPostCallback 

        Private MapHashOperationCompleted As System.Threading.SendOrPostCallback 

        Private PublishEditedSubtitle2OperationCompleted As System.Threading.SendOrPostCallback 

        Private PublishSubtitle2OperationCompleted As System.Threading.SendOrPostCallback 

        Private PublishSubtitleOperationCompleted As System.Threading.SendOrPostCallback 

        Private RateSubtitleOperationCompleted As System.Threading.SendOrPostCallback 

        Private RegisterOperationCompleted As System.Threading.SendOrPostCallback 

        Private ReportHashLinkOperationCompleted As System.Threading.SendOrPostCallback 

        Private ReportSubtitle2OperationCompleted As System.Threading.SendOrPostCallback 

        Private ReportSubtitleOperationCompleted As System.Threading.SendOrPostCallback 

        Private RequestPasswordResetOperationCompleted As System.Threading.SendOrPostCallback 

        Private SearchSubtitles3OperationCompleted As System.Threading.SendOrPostCallback 

        Private SendCommentOperationCompleted As System.Threading.SendOrPostCallback 

        Private SubtitleCommentDeleteOperationCompleted As System.Threading.SendOrPostCallback 

        Private SubtitleCommentVoteOperationCompleted As System.Threading.SendOrPostCallback 

        Private SubtitlePreviewOperationCompleted As System.Threading.SendOrPostCallback 

        Private SuggestTitlesOperationCompleted As System.Threading.SendOrPostCallback 

        Private SynchronizeSubtitleOperationCompleted As System.Threading.SendOrPostCallback 

        Private UpdateEmailOperationCompleted As System.Threading.SendOrPostCallback 

        Private UpdatePoster2OperationCompleted As System.Threading.SendOrPostCallback 

        Private UpdatePosterUrlOperationCompleted As System.Threading.SendOrPostCallback 

        Private UpdateSubtitleOperationCompleted As System.Threading.SendOrPostCallback 

        Private UpdateUserRatingOperationCompleted As System.Threading.SendOrPostCallback 
        Private useDefaultCredentialsSetExplicitly As Boolean 

        Private VoteMovieHashOperationCompleted As System.Threading.SendOrPostCallback 

        Public Event AddAlternativeTitleCompleted As Sublight.WS.AddAlternativeTitleCompletedEventHandler
        Public Event AddHashLink3Completed As Sublight.WS.AddHashLink3CompletedEventHandler
        Public Event AddHashLinkAutomatic3Completed As Sublight.WS.AddHashLinkAutomatic3CompletedEventHandler
        Public Event AddHashLinkSemiAutomatic3Completed As Sublight.WS.AddHashLinkSemiAutomatic3CompletedEventHandler
        Public Event AddReleaseCompleted As Sublight.WS.AddReleaseCompletedEventHandler
        Public Event AddSubtitleCommentCompleted As Sublight.WS.AddSubtitleCommentCompletedEventHandler
        Public Event AddSubtitleThankCompleted As Sublight.WS.AddSubtitleThankCompletedEventHandler
        Public Event ChangePasswordCompleted As Sublight.WS.ChangePasswordCompletedEventHandler
        Public Event CheckSubtitle3Completed As Sublight.WS.CheckSubtitle3CompletedEventHandler
        Public Event DeleteSubtitleCompleted As Sublight.WS.DeleteSubtitleCompletedEventHandler
        Public Event DownloadByID4Completed As Sublight.WS.DownloadByID4CompletedEventHandler
        Public Event FindIMDBCompleted As Sublight.WS.FindIMDBCompletedEventHandler
        Public Event GetDetailsByHashCompleted As Sublight.WS.GetDetailsByHashCompletedEventHandler
        Public Event GetDetailsCompleted As Sublight.WS.GetDetailsCompletedEventHandler
        Public Event GetDownloadTicket2Completed As Sublight.WS.GetDownloadTicket2CompletedEventHandler
        Public Event GetDownloadTicketCompleted As Sublight.WS.GetDownloadTicketCompletedEventHandler
        Public Event GetFavoriteSubtitlesCompleted As Sublight.WS.GetFavoriteSubtitlesCompletedEventHandler
        Public Event GetHistoryCompleted As Sublight.WS.GetHistoryCompletedEventHandler
        Public Event GetMyDownloadsCompleted As Sublight.WS.GetMyDownloadsCompletedEventHandler
        Public Event GetMyUploadsCompleted As Sublight.WS.GetMyUploadsCompletedEventHandler
        Public Event GetNewSubtitlesCompleted As Sublight.WS.GetNewSubtitlesCompletedEventHandler
        Public Event GetPosterCompleted As Sublight.WS.GetPosterCompletedEventHandler
        Public Event GetPosterUrlCompleted As Sublight.WS.GetPosterUrlCompletedEventHandler
        Public Event GetReleasesCompleted As Sublight.WS.GetReleasesCompletedEventHandler
        Public Event GetStatisticsCompleted As Sublight.WS.GetStatisticsCompletedEventHandler
        Public Event GetSubtitleByIdCompleted As Sublight.WS.GetSubtitleByIdCompletedEventHandler
        Public Event GetSubtitleCommentsCompleted As Sublight.WS.GetSubtitleCommentsCompletedEventHandler
        Public Event GetSubtitleThanksCompleted As Sublight.WS.GetSubtitleThanksCompletedEventHandler
        Public Event GetUserBySessionCompleted As Sublight.WS.GetUserBySessionCompletedEventHandler
        Public Event GetUserInfoCompleted As Sublight.WS.GetUserInfoCompletedEventHandler
        Public Event GetUserLog2Completed As Sublight.WS.GetUserLog2CompletedEventHandler
        Public Event LogIn6Completed As Sublight.WS.LogIn6CompletedEventHandler
        Public Event LogInAnonymous4Completed As Sublight.WS.LogInAnonymous4CompletedEventHandler
        Public Event LogInSecureCompleted As Sublight.WS.LogInSecureCompletedEventHandler
        Public Event LogOutCompleted As Sublight.WS.LogOutCompletedEventHandler
        Public Event MapHashCompleted As Sublight.WS.MapHashCompletedEventHandler
        Public Event PublishEditedSubtitle2Completed As Sublight.WS.PublishEditedSubtitle2CompletedEventHandler
        Public Event PublishSubtitle2Completed As Sublight.WS.PublishSubtitle2CompletedEventHandler
        Public Event PublishSubtitleCompleted As Sublight.WS.PublishSubtitleCompletedEventHandler
        Public Event RateSubtitleCompleted As Sublight.WS.RateSubtitleCompletedEventHandler
        Public Event RegisterCompleted As Sublight.WS.RegisterCompletedEventHandler
        Public Event ReportHashLinkCompleted As Sublight.WS.ReportHashLinkCompletedEventHandler
        Public Event ReportSubtitle2Completed As Sublight.WS.ReportSubtitle2CompletedEventHandler
        Public Event ReportSubtitleCompleted As Sublight.WS.ReportSubtitleCompletedEventHandler
        Public Event RequestPasswordResetCompleted As Sublight.WS.RequestPasswordResetCompletedEventHandler
        Public Event SearchSubtitles3Completed As Sublight.WS.SearchSubtitles3CompletedEventHandler
        Public Event SendCommentCompleted As Sublight.WS.SendCommentCompletedEventHandler
        Public Event SubtitleCommentDeleteCompleted As Sublight.WS.SubtitleCommentDeleteCompletedEventHandler
        Public Event SubtitleCommentVoteCompleted As Sublight.WS.SubtitleCommentVoteCompletedEventHandler
        Public Event SubtitlePreviewCompleted As Sublight.WS.SubtitlePreviewCompletedEventHandler
        Public Event SuggestTitlesCompleted As Sublight.WS.SuggestTitlesCompletedEventHandler
        Public Event SynchronizeSubtitleCompleted As Sublight.WS.SynchronizeSubtitleCompletedEventHandler
        Public Event UpdateEmailCompleted As Sublight.WS.UpdateEmailCompletedEventHandler
        Public Event UpdatePoster2Completed As Sublight.WS.UpdatePoster2CompletedEventHandler
        Public Event UpdatePosterUrlCompleted As Sublight.WS.UpdatePosterUrlCompletedEventHandler
        Public Event UpdateSubtitleCompleted As Sublight.WS.UpdateSubtitleCompletedEventHandler
        Public Event UpdateUserRatingCompleted As Sublight.WS.UpdateUserRatingCompletedEventHandler
        Public Event VoteMovieHashCompleted As Sublight.WS.VoteMovieHashCompletedEventHandler

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
            Url = Sublight.Properties.Settings.Default.Sublight_WS_Sublight
            If IsLocalFileSystemWebService(Url) Then
                UseDefaultCredentials = True
                useDefaultCredentialsSetExplicitly = False
                Return
            End If
            useDefaultCredentialsSetExplicitly = True
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/AddAlternativeTitle", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function AddAlternativeTitle(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal title As String, ByVal language As Sublight.WS.SubtitleLanguage, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     title, _
                                                     language }
            Dim objArr1 As Object() = Invoke("AddAlternativeTitle?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub AddAlternativeTitleAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal title As String, ByVal language As Sublight.WS.SubtitleLanguage, ByVal userState As Object)
            If (AddAlternativeTitleOperationCompleted) Is Nothing Then
                AddAlternativeTitleOperationCompleted = New System.Threading.SendOrPostCallback(OnAddAlternativeTitleOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     title, _
                                                     language }
            InvokeAsync("AddAlternativeTitle?", objArr1, AddAlternativeTitleOperationCompleted, userState)
        End Sub

        Public Sub AddAlternativeTitleAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal title As String, ByVal language As Sublight.WS.SubtitleLanguage)
            AddAlternativeTitleAsync(session, subtitleID, title, language, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/AddHashLink3", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function AddHashLink3(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String, <System.Xml.Serialization.XmlElement(IsNullable = True)> ByRef points As System.Nullable(Of Double), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     videoHash }
            Dim objArr1 As Object() = Invoke("AddHashLink3?", objArr2)
            points = DirectCast(objArr1(1), System.Nullable(Of Double))
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub AddHashLink3Async(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String)
            AddHashLink3Async(session, subtitleID, videoHash, Nothing)
        End Sub

        Public Sub AddHashLink3Async(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String, ByVal userState As Object)
            If (AddHashLink3OperationCompleted) Is Nothing Then
                AddHashLink3OperationCompleted = New System.Threading.SendOrPostCallback(OnAddHashLink3OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     videoHash }
            InvokeAsync("AddHashLink3?", objArr1, AddHashLink3OperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/AddHashLinkAutomatic3", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function AddHashLinkAutomatic3(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String, <System.Xml.Serialization.XmlElement(IsNullable = True)> ByRef points As System.Nullable(Of Double), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     videoHash }
            Dim objArr1 As Object() = Invoke("AddHashLinkAutomatic3?", objArr2)
            points = DirectCast(objArr1(1), System.Nullable(Of Double))
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub AddHashLinkAutomatic3Async(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String, ByVal userState As Object)
            If (AddHashLinkAutomatic3OperationCompleted) Is Nothing Then
                AddHashLinkAutomatic3OperationCompleted = New System.Threading.SendOrPostCallback(OnAddHashLinkAutomatic3OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     videoHash }
            InvokeAsync("AddHashLinkAutomatic3?", objArr1, AddHashLinkAutomatic3OperationCompleted, userState)
        End Sub

        Public Sub AddHashLinkAutomatic3Async(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String)
            AddHashLinkAutomatic3Async(session, subtitleID, videoHash, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/AddHashLinkSemiAutomatic3", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function AddHashLinkSemiAutomatic3(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String, <System.Xml.Serialization.XmlElement(IsNullable = True)> ByRef points As System.Nullable(Of Double), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     videoHash }
            Dim objArr1 As Object() = Invoke("AddHashLinkSemiAutomatic3?", objArr2)
            points = DirectCast(objArr1(1), System.Nullable(Of Double))
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub AddHashLinkSemiAutomatic3Async(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String)
            AddHashLinkSemiAutomatic3Async(session, subtitleID, videoHash, Nothing)
        End Sub

        Public Sub AddHashLinkSemiAutomatic3Async(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String, ByVal userState As Object)
            If (AddHashLinkSemiAutomatic3OperationCompleted) Is Nothing Then
                AddHashLinkSemiAutomatic3OperationCompleted = New System.Threading.SendOrPostCallback(OnAddHashLinkSemiAutomatic3OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     videoHash }
            InvokeAsync("AddHashLinkSemiAutomatic3?", objArr1, AddHashLinkSemiAutomatic3OperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/AddRelease", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function AddRelease(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal release As String, ByVal fps As Sublight.WS.FPS) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId, _
                                                     release, _
                                                     fps }
            Dim objArr1 As Object() = Invoke("AddRelease?", objArr2)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub AddReleaseAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal release As String, ByVal fps As Sublight.WS.FPS, ByVal userState As Object)
            If (AddReleaseOperationCompleted) Is Nothing Then
                AddReleaseOperationCompleted = New System.Threading.SendOrPostCallback(OnAddReleaseOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId, _
                                                     release, _
                                                     fps }
            InvokeAsync("AddRelease?", objArr1, AddReleaseOperationCompleted, userState)
        End Sub

        Public Sub AddReleaseAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal release As String, ByVal fps As Sublight.WS.FPS)
            AddReleaseAsync(session, subtitleId, release, fps, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/AddSubtitleComment", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function AddSubtitleComment(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal language As Sublight.WS.SubtitleLanguage, ByVal message As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     language, _
                                                     message }
            Dim objArr1 As Object() = Invoke("AddSubtitleComment?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub AddSubtitleCommentAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal language As Sublight.WS.SubtitleLanguage, ByVal message As String)
            AddSubtitleCommentAsync(session, subtitleID, language, message, Nothing)
        End Sub

        Public Sub AddSubtitleCommentAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal language As Sublight.WS.SubtitleLanguage, ByVal message As String, ByVal userState As Object)
            If (AddSubtitleCommentOperationCompleted) Is Nothing Then
                AddSubtitleCommentOperationCompleted = New System.Threading.SendOrPostCallback(OnAddSubtitleCommentOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     language, _
                                                     message }
            InvokeAsync("AddSubtitleComment?", objArr1, AddSubtitleCommentOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/AddSubtitleThank", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function AddSubtitleThank(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            Dim objArr1 As Object() = Invoke("AddSubtitleThank?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub AddSubtitleThankAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid)
            AddSubtitleThankAsync(session, subtitleId, Nothing)
        End Sub

        Public Sub AddSubtitleThankAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal userState As Object)
            If (AddSubtitleThankOperationCompleted) Is Nothing Then
                AddSubtitleThankOperationCompleted = New System.Threading.SendOrPostCallback(OnAddSubtitleThankOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            InvokeAsync("AddSubtitleThank?", objArr1, AddSubtitleThankOperationCompleted, userState)
        End Sub

        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/ChangePassword", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function ChangePassword(ByVal session As System.Guid, ByVal oldPassword As String, ByVal newPassword As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     oldPassword, _
                                                     newPassword }
            Dim objArr1 As Object() = Invoke("ChangePassword?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub ChangePasswordAsync(ByVal session As System.Guid, ByVal oldPassword As String, ByVal newPassword As String)
            ChangePasswordAsync(session, oldPassword, newPassword, Nothing)
        End Sub

        Public Sub ChangePasswordAsync(ByVal session As System.Guid, ByVal oldPassword As String, ByVal newPassword As String, ByVal userState As Object)
            If (ChangePasswordOperationCompleted) Is Nothing Then
                ChangePasswordOperationCompleted = New System.Threading.SendOrPostCallback(OnChangePasswordOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     oldPassword, _
                                                     newPassword }
            InvokeAsync("ChangePassword?", objArr1, ChangePasswordOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/CheckSubtitle3", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function CheckSubtitle3(ByVal session As System.Guid, ByVal ticket As String, ByVal plugin As String, ByVal subtitleId As String, ByVal imdb As String, ByVal title As String, ByVal language As String, ByVal subtitleXml As String, ByVal data As String, ByRef subtitleType As Sublight.WS.SubtitleType, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     ticket, _
                                                     plugin, _
                                                     subtitleId, _
                                                     imdb, _
                                                     title, _
                                                     language, _
                                                     subtitleXml, _
                                                     data }
            Dim objArr1 As Object() = Invoke("CheckSubtitle3?", objArr2)
            subtitleType = DirectCast(objArr1(1), Sublight.WS.SubtitleType)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub CheckSubtitle3Async(ByVal session As System.Guid, ByVal ticket As String, ByVal plugin As String, ByVal subtitleId As String, ByVal imdb As String, ByVal title As String, ByVal language As String, ByVal subtitleXml As String, ByVal data As String)
            CheckSubtitle3Async(session, ticket, plugin, subtitleId, imdb, title, language, subtitleXml, data, Nothing)
        End Sub

        Public Sub CheckSubtitle3Async(ByVal session As System.Guid, ByVal ticket As String, ByVal plugin As String, ByVal subtitleId As String, ByVal imdb As String, ByVal title As String, ByVal language As String, ByVal subtitleXml As String, ByVal data As String, ByVal userState As Object)
            If (CheckSubtitle3OperationCompleted) Is Nothing Then
                CheckSubtitle3OperationCompleted = New System.Threading.SendOrPostCallback(OnCheckSubtitle3OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     ticket, _
                                                     plugin, _
                                                     subtitleId, _
                                                     imdb, _
                                                     title, _
                                                     language, _
                                                     subtitleXml, _
                                                     data }
            InvokeAsync("CheckSubtitle3?", objArr1, CheckSubtitle3OperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/DeleteSubtitle", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function DeleteSubtitle(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            Dim objArr1 As Object() = Invoke("DeleteSubtitle?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub DeleteSubtitleAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal userState As Object)
            If (DeleteSubtitleOperationCompleted) Is Nothing Then
                DeleteSubtitleOperationCompleted = New System.Threading.SendOrPostCallback(OnDeleteSubtitleOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            InvokeAsync("DeleteSubtitle?", objArr1, DeleteSubtitleOperationCompleted, userState)
        End Sub

        Public Sub DeleteSubtitleAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid)
            DeleteSubtitleAsync(session, subtitleId, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/DownloadByID4", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function DownloadByID4(ByVal sessionID As System.Guid, ByVal subtitleID As System.Guid, ByVal codePage As Integer, ByVal removeFormatting As Boolean, ByVal ticket As String, ByRef data As String, ByRef points As Double, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     sessionID, _
                                                     subtitleID, _
                                                     codePage, _
                                                     removeFormatting, _
                                                     ticket }
            Dim objArr1 As Object() = Invoke("DownloadByID4?", objArr2)
            data = CType(objArr1(1), string)
            points = DirectCast(objArr1(2), double)
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub DownloadByID4Async(ByVal sessionID As System.Guid, ByVal subtitleID As System.Guid, ByVal codePage As Integer, ByVal removeFormatting As Boolean, ByVal ticket As String)
            DownloadByID4Async(sessionID, subtitleID, codePage, removeFormatting, ticket, Nothing)
        End Sub

        Public Sub DownloadByID4Async(ByVal sessionID As System.Guid, ByVal subtitleID As System.Guid, ByVal codePage As Integer, ByVal removeFormatting As Boolean, ByVal ticket As String, ByVal userState As Object)
            If (DownloadByID4OperationCompleted) Is Nothing Then
                DownloadByID4OperationCompleted = New System.Threading.SendOrPostCallback(OnDownloadByID4OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     sessionID, _
                                                     subtitleID, _
                                                     codePage, _
                                                     removeFormatting, _
                                                     ticket }
            InvokeAsync("DownloadByID4?", objArr1, DownloadByID4OperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/FindIMDB", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function FindIMDB(ByVal keyword As String, <System.Xml.Serialization.XmlElement(IsNullable = True)> ByVal year As System.Nullable(Of Integer), ByRef result As Sublight.WS.IMDB(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     keyword, _
                                                     year }
            Dim objArr1 As Object() = Invoke("FindIMDB?", objArr2)
            result = CType(objArr1(1), Sublight.WS.IMDB[])
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub FindIMDBAsync(ByVal keyword As String, ByVal year As System.Nullable(Of Integer))
            FindIMDBAsync(keyword, year, Nothing)
        End Sub

        Public Sub FindIMDBAsync(ByVal keyword As String, ByVal year As System.Nullable(Of Integer), ByVal userState As Object)
            If (FindIMDBOperationCompleted) Is Nothing Then
                FindIMDBOperationCompleted = New System.Threading.SendOrPostCallback(OnFindIMDBOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     keyword, _
                                                     year }
            InvokeAsync("FindIMDB?", objArr1, FindIMDBOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetDetails", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetDetails(ByVal session As System.Guid, ByVal imdb As String, ByRef imdbInfo As Sublight.WS.IMDB, ByRef alternativeTitles As Sublight.WS.AlternativeTitle(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     imdb }
            Dim objArr1 As Object() = Invoke("GetDetails?", objArr2)
            imdbInfo = CType(objArr1(1), Sublight.WS.IMDB)
            alternativeTitles = CType(objArr1(2), Sublight.WS.AlternativeTitle[])
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetDetailsAsync(ByVal session As System.Guid, ByVal imdb As String, ByVal userState As Object)
            If (GetDetailsOperationCompleted) Is Nothing Then
                GetDetailsOperationCompleted = New System.Threading.SendOrPostCallback(OnGetDetailsOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     imdb }
            InvokeAsync("GetDetails?", objArr1, GetDetailsOperationCompleted, userState)
        End Sub

        Public Sub GetDetailsAsync(ByVal session As System.Guid, ByVal imdb As String)
            GetDetailsAsync(session, imdb, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetDetailsByHash", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetDetailsByHash(ByVal session As System.Guid, ByVal hash As String, ByRef imdbInfo As Sublight.WS.IMDB, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     hash }
            Dim objArr1 As Object() = Invoke("GetDetailsByHash?", objArr2)
            imdbInfo = CType(objArr1(1), Sublight.WS.IMDB)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetDetailsByHashAsync(ByVal session As System.Guid, ByVal hash As String)
            GetDetailsByHashAsync(session, hash, Nothing)
        End Sub

        Public Sub GetDetailsByHashAsync(ByVal session As System.Guid, ByVal hash As String, ByVal userState As Object)
            If (GetDetailsByHashOperationCompleted) Is Nothing Then
                GetDetailsByHashOperationCompleted = New System.Threading.SendOrPostCallback(OnGetDetailsByHashOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     hash }
            InvokeAsync("GetDetailsByHash?", objArr1, GetDetailsByHashOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetDownloadTicket", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetDownloadTicket(ByVal session As System.Guid, ByVal plugin As String, ByVal id As String, ByRef ticket As String, ByRef que As Short, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     plugin, _
                                                     id }
            Dim objArr1 As Object() = Invoke("GetDownloadTicket?", objArr2)
            ticket = CType(objArr1(1), string)
            que = DirectCast(objArr1(2), short)
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetDownloadTicket2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetDownloadTicket2(ByVal session As System.Guid, ByVal plugin As String, ByVal id As String, ByRef ticket As String, ByRef que As Short, ByRef points As Double, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     plugin, _
                                                     id }
            Dim objArr1 As Object() = Invoke("GetDownloadTicket2?", objArr2)
            ticket = CType(objArr1(1), string)
            que = DirectCast(objArr1(2), short)
            points = DirectCast(objArr1(3), double)
            error = CType(objArr1(4), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetDownloadTicket2Async(ByVal session As System.Guid, ByVal plugin As String, ByVal id As String)
            GetDownloadTicket2Async(session, plugin, id, Nothing)
        End Sub

        Public Sub GetDownloadTicket2Async(ByVal session As System.Guid, ByVal plugin As String, ByVal id As String, ByVal userState As Object)
            If (GetDownloadTicket2OperationCompleted) Is Nothing Then
                GetDownloadTicket2OperationCompleted = New System.Threading.SendOrPostCallback(OnGetDownloadTicket2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     plugin, _
                                                     id }
            InvokeAsync("GetDownloadTicket2?", objArr1, GetDownloadTicket2OperationCompleted, userState)
        End Sub

        Public Sub GetDownloadTicketAsync(ByVal session As System.Guid, ByVal plugin As String, ByVal id As String, ByVal userState As Object)
            If (GetDownloadTicketOperationCompleted) Is Nothing Then
                GetDownloadTicketOperationCompleted = New System.Threading.SendOrPostCallback(OnGetDownloadTicketOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     plugin, _
                                                     id }
            InvokeAsync("GetDownloadTicket?", objArr1, GetDownloadTicketOperationCompleted, userState)
        End Sub

        Public Sub GetDownloadTicketAsync(ByVal session As System.Guid, ByVal plugin As String, ByVal id As String)
            GetDownloadTicketAsync(session, plugin, id, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetFavoriteSubtitles", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetFavoriteSubtitles(ByVal session As System.Guid, <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef subtitles As Sublight.WS.Subtitle(), <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef releases As Sublight.WS.Release(), ByRef actions As Sublight.WS.SubtitleActions(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetFavoriteSubtitles?", objArr2)
            subtitles = CType(objArr1(1), Sublight.WS.Subtitle[])
            releases = CType(objArr1(2), Sublight.WS.Release[])
            actions = CType(objArr1(3), Sublight.WS.SubtitleActions[])
            error = CType(objArr1(4), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetFavoriteSubtitlesAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (GetFavoriteSubtitlesOperationCompleted) Is Nothing Then
                GetFavoriteSubtitlesOperationCompleted = New System.Threading.SendOrPostCallback(OnGetFavoriteSubtitlesOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetFavoriteSubtitles?", objArr1, GetFavoriteSubtitlesOperationCompleted, userState)
        End Sub

        Public Sub GetFavoriteSubtitlesAsync(ByVal session As System.Guid)
            GetFavoriteSubtitlesAsync(session, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetHistory", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetHistory(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByRef items As Sublight.WS.HistoryItem(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleID }
            Dim objArr1 As Object() = Invoke("GetHistory?", objArr2)
            items = CType(objArr1(1), Sublight.WS.HistoryItem[])
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetHistoryAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal userState As Object)
            If (GetHistoryOperationCompleted) Is Nothing Then
                GetHistoryOperationCompleted = New System.Threading.SendOrPostCallback(OnGetHistoryOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleID }
            InvokeAsync("GetHistory?", objArr1, GetHistoryOperationCompleted, userState)
        End Sub

        Public Sub GetHistoryAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid)
            GetHistoryAsync(session, subtitleID, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetMyDownloads", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetMyDownloads(ByVal session As System.Guid, ByVal guids As System.Guid(), <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef subtitles As Sublight.WS.Subtitle(), <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef releases As Sublight.WS.Release(), ByRef actions As Sublight.WS.SubtitleActions(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     guids }
            Dim objArr1 As Object() = Invoke("GetMyDownloads?", objArr2)
            subtitles = CType(objArr1(1), Sublight.WS.Subtitle[])
            releases = CType(objArr1(2), Sublight.WS.Release[])
            actions = CType(objArr1(3), Sublight.WS.SubtitleActions[])
            error = CType(objArr1(4), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetMyDownloadsAsync(ByVal session As System.Guid, ByVal guids As System.Guid())
            GetMyDownloadsAsync(session, guids, Nothing)
        End Sub

        Public Sub GetMyDownloadsAsync(ByVal session As System.Guid, ByVal guids As System.Guid(), ByVal userState As Object)
            If (GetMyDownloadsOperationCompleted) Is Nothing Then
                GetMyDownloadsOperationCompleted = New System.Threading.SendOrPostCallback(OnGetMyDownloadsOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     guids }
            InvokeAsync("GetMyDownloads?", objArr1, GetMyDownloadsOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetMyUploads", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetMyUploads(ByVal session As System.Guid, <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef subtitles As Sublight.WS.Subtitle(), <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef releases As Sublight.WS.Release(), ByRef actions As Sublight.WS.SubtitleActions(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetMyUploads?", objArr2)
            subtitles = CType(objArr1(1), Sublight.WS.Subtitle[])
            releases = CType(objArr1(2), Sublight.WS.Release[])
            actions = CType(objArr1(3), Sublight.WS.SubtitleActions[])
            error = CType(objArr1(4), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetMyUploadsAsync(ByVal session As System.Guid)
            GetMyUploadsAsync(session, Nothing)
        End Sub

        Public Sub GetMyUploadsAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (GetMyUploadsOperationCompleted) Is Nothing Then
                GetMyUploadsOperationCompleted = New System.Threading.SendOrPostCallback(OnGetMyUploadsOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetMyUploads?", objArr1, GetMyUploadsOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetNewSubtitles", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetNewSubtitles(ByVal session As System.Guid, <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef subtitles As Sublight.WS.Subtitle(), <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef releases As Sublight.WS.Release(), ByRef actions As Sublight.WS.SubtitleActions(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetNewSubtitles?", objArr2)
            subtitles = CType(objArr1(1), Sublight.WS.Subtitle[])
            releases = CType(objArr1(2), Sublight.WS.Release[])
            actions = CType(objArr1(3), Sublight.WS.SubtitleActions[])
            error = CType(objArr1(4), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetNewSubtitlesAsync(ByVal session As System.Guid)
            GetNewSubtitlesAsync(session, Nothing)
        End Sub

        Public Sub GetNewSubtitlesAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (GetNewSubtitlesOperationCompleted) Is Nothing Then
                GetNewSubtitlesOperationCompleted = New System.Threading.SendOrPostCallback(OnGetNewSubtitlesOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetNewSubtitles?", objArr1, GetNewSubtitlesOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetPoster", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetPoster(ByVal session As System.Guid, ByVal imdb As String, ByRef data As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     imdb }
            Dim objArr1 As Object() = Invoke("GetPoster?", objArr2)
            data = CType(objArr1(1), string)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetPosterAsync(ByVal session As System.Guid, ByVal imdb As String, ByVal userState As Object)
            If (GetPosterOperationCompleted) Is Nothing Then
                GetPosterOperationCompleted = New System.Threading.SendOrPostCallback(OnGetPosterOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     imdb }
            InvokeAsync("GetPoster?", objArr1, GetPosterOperationCompleted, userState)
        End Sub

        Public Sub GetPosterAsync(ByVal session As System.Guid, ByVal imdb As String)
            GetPosterAsync(session, imdb, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetPosterUrl", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetPosterUrl(ByVal session As System.Guid, ByVal posterUrl As String, ByRef newPosterUrl As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     posterUrl }
            Dim objArr1 As Object() = Invoke("GetPosterUrl?", objArr2)
            newPosterUrl = CType(objArr1(1), string)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetPosterUrlAsync(ByVal session As System.Guid, ByVal posterUrl As String, ByVal userState As Object)
            If (GetPosterUrlOperationCompleted) Is Nothing Then
                GetPosterUrlOperationCompleted = New System.Threading.SendOrPostCallback(OnGetPosterUrlOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     posterUrl }
            InvokeAsync("GetPosterUrl?", objArr1, GetPosterUrlOperationCompleted, userState)
        End Sub

        Public Sub GetPosterUrlAsync(ByVal session As System.Guid, ByVal posterUrl As String)
            GetPosterUrlAsync(session, posterUrl, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetReleases", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetReleases(ByVal subtitleIds As System.Guid(), <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef releases As Sublight.WS.Release(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { subtitleIds }
            Dim objArr1 As Object() = Invoke("GetReleases?", objArr2)
            releases = CType(objArr1(1), Sublight.WS.Release[])
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetReleasesAsync(ByVal subtitleIds As System.Guid())
            GetReleasesAsync(subtitleIds, Nothing)
        End Sub

        Public Sub GetReleasesAsync(ByVal subtitleIds As System.Guid(), ByVal userState As Object)
            If (GetReleasesOperationCompleted) Is Nothing Then
                GetReleasesOperationCompleted = New System.Threading.SendOrPostCallback(OnGetReleasesOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { subtitleIds }
            InvokeAsync("GetReleases?", objArr1, GetReleasesOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetStatistics", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetStatistics(ByVal session As System.Guid, ByVal type As Sublight.WS.StatisticsType, ByVal language As String, ByRef ds As System.Data.DataSet, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     type, _
                                                     language }
            Dim objArr1 As Object() = Invoke("GetStatistics?", objArr2)
            ds = CType(objArr1(1), System.Data.DataSet)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetStatisticsAsync(ByVal session As System.Guid, ByVal type As Sublight.WS.StatisticsType, ByVal language As String, ByVal userState As Object)
            If (GetStatisticsOperationCompleted) Is Nothing Then
                GetStatisticsOperationCompleted = New System.Threading.SendOrPostCallback(OnGetStatisticsOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     type, _
                                                     language }
            InvokeAsync("GetStatistics?", objArr1, GetStatisticsOperationCompleted, userState)
        End Sub

        Public Sub GetStatisticsAsync(ByVal session As System.Guid, ByVal type As Sublight.WS.StatisticsType, ByVal language As String)
            GetStatisticsAsync(session, type, language, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetSubtitleById", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetSubtitleById(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByRef subtitle As Sublight.WS.Subtitle, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            Dim objArr1 As Object() = Invoke("GetSubtitleById?", objArr2)
            subtitle = CType(objArr1(1), Sublight.WS.Subtitle)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetSubtitleByIdAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid)
            GetSubtitleByIdAsync(session, subtitleId, Nothing)
        End Sub

        Public Sub GetSubtitleByIdAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal userState As Object)
            If (GetSubtitleByIdOperationCompleted) Is Nothing Then
                GetSubtitleByIdOperationCompleted = New System.Threading.SendOrPostCallback(OnGetSubtitleByIdOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            InvokeAsync("GetSubtitleById?", objArr1, GetSubtitleByIdOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetSubtitleComments", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetSubtitleComments(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal language As Sublight.WS.SubtitleLanguage, ByVal elementIndexStart As Integer, ByVal elementIndexEnd As Integer, ByRef totalComments As Integer, ByRef comments As Sublight.WS.SubtitleComment(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     language, _
                                                     elementIndexStart, _
                                                     elementIndexEnd }
            Dim objArr1 As Object() = Invoke("GetSubtitleComments?", objArr2)
            totalComments = DirectCast(objArr1(1), int)
            comments = CType(objArr1(2), Sublight.WS.SubtitleComment[])
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetSubtitleCommentsAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal language As Sublight.WS.SubtitleLanguage, ByVal elementIndexStart As Integer, ByVal elementIndexEnd As Integer, ByVal userState As Object)
            If (GetSubtitleCommentsOperationCompleted) Is Nothing Then
                GetSubtitleCommentsOperationCompleted = New System.Threading.SendOrPostCallback(OnGetSubtitleCommentsOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     language, _
                                                     elementIndexStart, _
                                                     elementIndexEnd }
            InvokeAsync("GetSubtitleComments?", objArr1, GetSubtitleCommentsOperationCompleted, userState)
        End Sub

        Public Sub GetSubtitleCommentsAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal language As Sublight.WS.SubtitleLanguage, ByVal elementIndexStart As Integer, ByVal elementIndexEnd As Integer)
            GetSubtitleCommentsAsync(session, subtitleID, language, elementIndexStart, elementIndexEnd, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetSubtitleThanks", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetSubtitleThanks(ByVal session As System.Guid, ByVal subtitleId As System.Guid, <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef users As Sublight.WS.SubtitleThank(), ByRef allowThanks As Boolean, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            Dim objArr1 As Object() = Invoke("GetSubtitleThanks?", objArr2)
            users = CType(objArr1(1), Sublight.WS.SubtitleThank[])
            allowThanks = DirectCast(objArr1(2), bool)
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetSubtitleThanksAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal userState As Object)
            If (GetSubtitleThanksOperationCompleted) Is Nothing Then
                GetSubtitleThanksOperationCompleted = New System.Threading.SendOrPostCallback(OnGetSubtitleThanksOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            InvokeAsync("GetSubtitleThanks?", objArr1, GetSubtitleThanksOperationCompleted, userState)
        End Sub

        Public Sub GetSubtitleThanksAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid)
            GetSubtitleThanksAsync(session, subtitleId, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetUserBySession", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetUserBySession(ByVal session As System.Guid, ByRef user As Sublight.WS.User, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetUserBySession?", objArr2)
            user = CType(objArr1(1), Sublight.WS.User)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetUserBySessionAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (GetUserBySessionOperationCompleted) Is Nothing Then
                GetUserBySessionOperationCompleted = New System.Threading.SendOrPostCallback(OnGetUserBySessionOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetUserBySession?", objArr1, GetUserBySessionOperationCompleted, userState)
        End Sub

        Public Sub GetUserBySessionAsync(ByVal session As System.Guid)
            GetUserBySessionAsync(session, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetUserInfo", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetUserInfo(ByVal session As System.Guid, ByRef userInfo As Sublight.WS.UserInfo, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetUserInfo?", objArr2)
            userInfo = CType(objArr1(1), Sublight.WS.UserInfo)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetUserInfoAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (GetUserInfoOperationCompleted) Is Nothing Then
                GetUserInfoOperationCompleted = New System.Threading.SendOrPostCallback(OnGetUserInfoOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetUserInfo?", objArr1, GetUserInfoOperationCompleted, userState)
        End Sub

        Public Sub GetUserInfoAsync(ByVal session As System.Guid)
            GetUserInfoAsync(session, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/GetUserLog2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function GetUserLog2(ByVal session As System.Guid, ByRef ds As System.Data.DataSet, ByRef points As Double, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("GetUserLog2?", objArr2)
            ds = CType(objArr1(1), System.Data.DataSet)
            points = DirectCast(objArr1(2), double)
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub GetUserLog2Async(ByVal session As System.Guid, ByVal userState As Object)
            If (GetUserLog2OperationCompleted) Is Nothing Then
                GetUserLog2OperationCompleted = New System.Threading.SendOrPostCallback(OnGetUserLog2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("GetUserLog2?", objArr1, GetUserLog2OperationCompleted, userState)
        End Sub

        Public Sub GetUserLog2Async(ByVal session As System.Guid)
            GetUserLog2Async(session, Nothing)
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

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/LogIn6", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function LogIn6(ByVal username As String, ByVal passwordHash As String, ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String(), ByRef userId As System.Guid, ByRef roles As String(), ByRef primaryLanguages As Sublight.WS.SubtitleLanguage(), ByRef settings As String(), ByRef error As String) As System.Guid
            Dim objArr2 As Object() = New object() { _
                                                     username, _
                                                     passwordHash, _
                                                     clientInfo, _
                                                     args }
            Dim objArr1 As Object() = Invoke("LogIn6?", objArr2)
            userId = DirectCast(objArr1(1), System.Guid)
            roles = CType(objArr1(2), String[])
            primaryLanguages = CType(objArr1(3), Sublight.WS.SubtitleLanguage[])
            settings = CType(objArr1(4), String[])
            error = CType(objArr1(5), string)
            Return DirectCast(objArr1(0), System.Guid)
        End Function

        Public Sub LogIn6Async(ByVal username As String, ByVal passwordHash As String, ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String(), ByVal userState As Object)
            If (LogIn6OperationCompleted) Is Nothing Then
                LogIn6OperationCompleted = New System.Threading.SendOrPostCallback(OnLogIn6OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     username, _
                                                     passwordHash, _
                                                     clientInfo, _
                                                     args }
            InvokeAsync("LogIn6?", objArr1, LogIn6OperationCompleted, userState)
        End Sub

        Public Sub LogIn6Async(ByVal username As String, ByVal passwordHash As String, ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String())
            LogIn6Async(username, passwordHash, clientInfo, args, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/LogInAnonymous4", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function LogInAnonymous4(ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String(), ByRef settings As String(), ByRef error As String) As System.Guid
            Dim objArr2 As Object() = New object() { _
                                                     clientInfo, _
                                                     args }
            Dim objArr1 As Object() = Invoke("LogInAnonymous4?", objArr2)
            settings = CType(objArr1(1), String[])
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), System.Guid)
        End Function

        Public Sub LogInAnonymous4Async(ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String(), ByVal userState As Object)
            If (LogInAnonymous4OperationCompleted) Is Nothing Then
                LogInAnonymous4OperationCompleted = New System.Threading.SendOrPostCallback(OnLogInAnonymous4OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     clientInfo, _
                                                     args }
            InvokeAsync("LogInAnonymous4?", objArr1, LogInAnonymous4OperationCompleted, userState)
        End Sub

        Public Sub LogInAnonymous4Async(ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String())
            LogInAnonymous4Async(clientInfo, args, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/LogInSecure", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function LogInSecure(ByVal username As String, ByVal passwordHash As String, ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String(), ByRef userId As System.Guid, ByRef roles As String(), ByRef primaryLanguages As Sublight.WS.SubtitleLanguage(), ByRef settings As String(), ByRef error As String) As System.Guid
            Dim objArr2 As Object() = New object() { _
                                                     username, _
                                                     passwordHash, _
                                                     clientInfo, _
                                                     args }
            Dim objArr1 As Object() = Invoke("LogInSecure?", objArr2)
            userId = DirectCast(objArr1(1), System.Guid)
            roles = CType(objArr1(2), String[])
            primaryLanguages = CType(objArr1(3), Sublight.WS.SubtitleLanguage[])
            settings = CType(objArr1(4), String[])
            error = CType(objArr1(5), string)
            Return DirectCast(objArr1(0), System.Guid)
        End Function

        Public Sub LogInSecureAsync(ByVal username As String, ByVal passwordHash As String, ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String(), ByVal userState As Object)
            If (LogInSecureOperationCompleted) Is Nothing Then
                LogInSecureOperationCompleted = New System.Threading.SendOrPostCallback(OnLogInSecureOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     username, _
                                                     passwordHash, _
                                                     clientInfo, _
                                                     args }
            InvokeAsync("LogInSecure?", objArr1, LogInSecureOperationCompleted, userState)
        End Sub

        Public Sub LogInSecureAsync(ByVal username As String, ByVal passwordHash As String, ByVal clientInfo As Sublight.WS.ClientInfo, ByVal args As String())
            LogInSecureAsync(username, passwordHash, clientInfo, args, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/LogOut", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function LogOut(ByVal session As System.Guid, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { session }
            Dim objArr1 As Object() = Invoke("LogOut?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub LogOutAsync(ByVal session As System.Guid, ByVal userState As Object)
            If (LogOutOperationCompleted) Is Nothing Then
                LogOutOperationCompleted = New System.Threading.SendOrPostCallback(OnLogOutOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { session }
            InvokeAsync("LogOut?", objArr1, LogOutOperationCompleted, userState)
        End Sub

        Public Sub LogOutAsync(ByVal session As System.Guid)
            LogOutAsync(session, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/MapHash", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function MapHash(ByVal session As System.Guid, ByVal hash1 As String, ByVal hash2 As String, ByVal imdb As String, ByVal title As String, ByVal size As Long, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     hash1, _
                                                     hash2, _
                                                     imdb, _
                                                     title, _
                                                     size }
            Dim objArr1 As Object() = Invoke("MapHash?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub MapHashAsync(ByVal session As System.Guid, ByVal hash1 As String, ByVal hash2 As String, ByVal imdb As String, ByVal title As String, ByVal size As Long)
            MapHashAsync(session, hash1, hash2, imdb, title, size, Nothing)
        End Sub

        Public Sub MapHashAsync(ByVal session As System.Guid, ByVal hash1 As String, ByVal hash2 As String, ByVal imdb As String, ByVal title As String, ByVal size As Long, ByVal userState As Object)
            If (MapHashOperationCompleted) Is Nothing Then
                MapHashOperationCompleted = New System.Threading.SendOrPostCallback(OnMapHashOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     hash1, _
                                                     hash2, _
                                                     imdb, _
                                                     title, _
                                                     size }
            InvokeAsync("MapHash?", objArr1, MapHashOperationCompleted, userState)
        End Sub

        Private Sub OnAddAlternativeTitleOperationCompleted(ByVal arg As Object)
            If Not (AddAlternativeTitleCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddAlternativeTitleCompleted(Me, New Sublight.WS.AddAlternativeTitleCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnAddHashLink3OperationCompleted(ByVal arg As Object)
            If Not (AddHashLink3CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddHashLink3Completed(Me, New Sublight.WS.AddHashLink3CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnAddHashLinkAutomatic3OperationCompleted(ByVal arg As Object)
            If Not (AddHashLinkAutomatic3CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddHashLinkAutomatic3Completed(Me, New Sublight.WS.AddHashLinkAutomatic3CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnAddHashLinkSemiAutomatic3OperationCompleted(ByVal arg As Object)
            If Not (AddHashLinkSemiAutomatic3CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddHashLinkSemiAutomatic3Completed(Me, New Sublight.WS.AddHashLinkSemiAutomatic3CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnAddReleaseOperationCompleted(ByVal arg As Object)
            If Not (AddReleaseCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddReleaseCompleted(Me, New Sublight.WS.AddReleaseCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnAddSubtitleCommentOperationCompleted(ByVal arg As Object)
            If Not (AddSubtitleCommentCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddSubtitleCommentCompleted(Me, New Sublight.WS.AddSubtitleCommentCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnAddSubtitleThankOperationCompleted(ByVal arg As Object)
            If Not (AddSubtitleThankCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent AddSubtitleThankCompleted(Me, New Sublight.WS.AddSubtitleThankCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnChangePasswordOperationCompleted(ByVal arg As Object)
            If Not (ChangePasswordCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ChangePasswordCompleted(Me, New Sublight.WS.ChangePasswordCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnCheckSubtitle3OperationCompleted(ByVal arg As Object)
            If Not (CheckSubtitle3CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CheckSubtitle3Completed(Me, New Sublight.WS.CheckSubtitle3CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnDeleteSubtitleOperationCompleted(ByVal arg As Object)
            If Not (DeleteSubtitleCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent DeleteSubtitleCompleted(Me, New Sublight.WS.DeleteSubtitleCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnDownloadByID4OperationCompleted(ByVal arg As Object)
            If Not (DownloadByID4CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent DownloadByID4Completed(Me, New Sublight.WS.DownloadByID4CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnFindIMDBOperationCompleted(ByVal arg As Object)
            If Not (FindIMDBCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FindIMDBCompleted(Me, New Sublight.WS.FindIMDBCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetDetailsByHashOperationCompleted(ByVal arg As Object)
            If Not (GetDetailsByHashCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDetailsByHashCompleted(Me, New Sublight.WS.GetDetailsByHashCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetDetailsOperationCompleted(ByVal arg As Object)
            If Not (GetDetailsCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDetailsCompleted(Me, New Sublight.WS.GetDetailsCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetDownloadTicket2OperationCompleted(ByVal arg As Object)
            If Not (GetDownloadTicket2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDownloadTicket2Completed(Me, New Sublight.WS.GetDownloadTicket2CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetDownloadTicketOperationCompleted(ByVal arg As Object)
            If Not (GetDownloadTicketCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDownloadTicketCompleted(Me, New Sublight.WS.GetDownloadTicketCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetFavoriteSubtitlesOperationCompleted(ByVal arg As Object)
            If Not (GetFavoriteSubtitlesCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetFavoriteSubtitlesCompleted(Me, New Sublight.WS.GetFavoriteSubtitlesCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetHistoryOperationCompleted(ByVal arg As Object)
            If Not (GetHistoryCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetHistoryCompleted(Me, New Sublight.WS.GetHistoryCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetMyDownloadsOperationCompleted(ByVal arg As Object)
            If Not (GetMyDownloadsCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetMyDownloadsCompleted(Me, New Sublight.WS.GetMyDownloadsCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetMyUploadsOperationCompleted(ByVal arg As Object)
            If Not (GetMyUploadsCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetMyUploadsCompleted(Me, New Sublight.WS.GetMyUploadsCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetNewSubtitlesOperationCompleted(ByVal arg As Object)
            If Not (GetNewSubtitlesCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetNewSubtitlesCompleted(Me, New Sublight.WS.GetNewSubtitlesCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetPosterOperationCompleted(ByVal arg As Object)
            If Not (GetPosterCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetPosterCompleted(Me, New Sublight.WS.GetPosterCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetPosterUrlOperationCompleted(ByVal arg As Object)
            If Not (GetPosterUrlCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetPosterUrlCompleted(Me, New Sublight.WS.GetPosterUrlCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetReleasesOperationCompleted(ByVal arg As Object)
            If Not (GetReleasesCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetReleasesCompleted(Me, New Sublight.WS.GetReleasesCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetStatisticsOperationCompleted(ByVal arg As Object)
            If Not (GetStatisticsCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetStatisticsCompleted(Me, New Sublight.WS.GetStatisticsCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetSubtitleByIdOperationCompleted(ByVal arg As Object)
            If Not (GetSubtitleByIdCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetSubtitleByIdCompleted(Me, New Sublight.WS.GetSubtitleByIdCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetSubtitleCommentsOperationCompleted(ByVal arg As Object)
            If Not (GetSubtitleCommentsCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetSubtitleCommentsCompleted(Me, New Sublight.WS.GetSubtitleCommentsCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetSubtitleThanksOperationCompleted(ByVal arg As Object)
            If Not (GetSubtitleThanksCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetSubtitleThanksCompleted(Me, New Sublight.WS.GetSubtitleThanksCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetUserBySessionOperationCompleted(ByVal arg As Object)
            If Not (GetUserBySessionCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetUserBySessionCompleted(Me, New Sublight.WS.GetUserBySessionCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetUserInfoOperationCompleted(ByVal arg As Object)
            If Not (GetUserInfoCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetUserInfoCompleted(Me, New Sublight.WS.GetUserInfoCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnGetUserLog2OperationCompleted(ByVal arg As Object)
            If Not (GetUserLog2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetUserLog2Completed(Me, New Sublight.WS.GetUserLog2CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnLogIn6OperationCompleted(ByVal arg As Object)
            If Not (LogIn6CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent LogIn6Completed(Me, New Sublight.WS.LogIn6CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnLogInAnonymous4OperationCompleted(ByVal arg As Object)
            If Not (LogInAnonymous4CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent LogInAnonymous4Completed(Me, New Sublight.WS.LogInAnonymous4CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnLogInSecureOperationCompleted(ByVal arg As Object)
            If Not (LogInSecureCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent LogInSecureCompleted(Me, New Sublight.WS.LogInSecureCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnLogOutOperationCompleted(ByVal arg As Object)
            If Not (LogOutCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent LogOutCompleted(Me, New Sublight.WS.LogOutCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnMapHashOperationCompleted(ByVal arg As Object)
            If Not (MapHashCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent MapHashCompleted(Me, New Sublight.WS.MapHashCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnPublishEditedSubtitle2OperationCompleted(ByVal arg As Object)
            If Not (PublishEditedSubtitle2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent PublishEditedSubtitle2Completed(Me, New Sublight.WS.PublishEditedSubtitle2CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnPublishSubtitle2OperationCompleted(ByVal arg As Object)
            If Not (PublishSubtitle2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent PublishSubtitle2Completed(Me, New Sublight.WS.PublishSubtitle2CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnPublishSubtitleOperationCompleted(ByVal arg As Object)
            If Not (PublishSubtitleCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent PublishSubtitleCompleted(Me, New Sublight.WS.PublishSubtitleCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnRateSubtitleOperationCompleted(ByVal arg As Object)
            If Not (RateSubtitleCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent RateSubtitleCompleted(Me, New Sublight.WS.RateSubtitleCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnRegisterOperationCompleted(ByVal arg As Object)
            If Not (RegisterCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent RegisterCompleted(Me, New Sublight.WS.RegisterCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnReportHashLinkOperationCompleted(ByVal arg As Object)
            If Not (ReportHashLinkCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ReportHashLinkCompleted(Me, New Sublight.WS.ReportHashLinkCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnReportSubtitle2OperationCompleted(ByVal arg As Object)
            If Not (ReportSubtitle2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ReportSubtitle2Completed(Me, New Sublight.WS.ReportSubtitle2CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnReportSubtitleOperationCompleted(ByVal arg As Object)
            If Not (ReportSubtitleCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ReportSubtitleCompleted(Me, New Sublight.WS.ReportSubtitleCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnRequestPasswordResetOperationCompleted(ByVal arg As Object)
            If Not (RequestPasswordResetCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent RequestPasswordResetCompleted(Me, New Sublight.WS.RequestPasswordResetCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSearchSubtitles3OperationCompleted(ByVal arg As Object)
            If Not (SearchSubtitles3CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SearchSubtitles3Completed(Me, New Sublight.WS.SearchSubtitles3CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSendCommentOperationCompleted(ByVal arg As Object)
            If Not (SendCommentCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SendCommentCompleted(Me, New Sublight.WS.SendCommentCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSubtitleCommentDeleteOperationCompleted(ByVal arg As Object)
            If Not (SubtitleCommentDeleteCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SubtitleCommentDeleteCompleted(Me, New Sublight.WS.SubtitleCommentDeleteCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSubtitleCommentVoteOperationCompleted(ByVal arg As Object)
            If Not (SubtitleCommentVoteCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SubtitleCommentVoteCompleted(Me, New Sublight.WS.SubtitleCommentVoteCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSubtitlePreviewOperationCompleted(ByVal arg As Object)
            If Not (SubtitlePreviewCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SubtitlePreviewCompleted(Me, New Sublight.WS.SubtitlePreviewCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSuggestTitlesOperationCompleted(ByVal arg As Object)
            If Not (SuggestTitlesCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SuggestTitlesCompleted(Me, New Sublight.WS.SuggestTitlesCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnSynchronizeSubtitleOperationCompleted(ByVal arg As Object)
            If Not (SynchronizeSubtitleCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SynchronizeSubtitleCompleted(Me, New Sublight.WS.SynchronizeSubtitleCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnUpdateEmailOperationCompleted(ByVal arg As Object)
            If Not (UpdateEmailCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent UpdateEmailCompleted(Me, New Sublight.WS.UpdateEmailCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnUpdatePoster2OperationCompleted(ByVal arg As Object)
            If Not (UpdatePoster2CompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent UpdatePoster2Completed(Me, New Sublight.WS.UpdatePoster2CompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnUpdatePosterUrlOperationCompleted(ByVal arg As Object)
            If Not (UpdatePosterUrlCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent UpdatePosterUrlCompleted(Me, New Sublight.WS.UpdatePosterUrlCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnUpdateSubtitleOperationCompleted(ByVal arg As Object)
            If Not (UpdateSubtitleCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent UpdateSubtitleCompleted(Me, New Sublight.WS.UpdateSubtitleCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnUpdateUserRatingOperationCompleted(ByVal arg As Object)
            If Not (UpdateUserRatingCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent UpdateUserRatingCompleted(Me, New Sublight.WS.UpdateUserRatingCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        Private Sub OnVoteMovieHashOperationCompleted(ByVal arg As Object)
            If Not (VoteMovieHashCompletedEvent) Is Nothing Then
                Dim invokeCompletedEventArgs1 As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent VoteMovieHashCompleted(Me, New Sublight.WS.VoteMovieHashCompletedEventArgs(invokeCompletedEventArgs1.Results, invokeCompletedEventArgs1.Error, invokeCompletedEventArgs1.Cancelled, invokeCompletedEventArgs1.UserState))
            End If
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/PublishEditedSubtitle2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function PublishEditedSubtitle2(ByVal session As System.Guid, ByVal originalSubtitleId As System.Guid, ByVal comment As String, ByVal data As String, ByRef ID As System.Guid, ByRef points As Double, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     originalSubtitleId, _
                                                     comment, _
                                                     data }
            Dim objArr1 As Object() = Invoke("PublishEditedSubtitle2?", objArr2)
            ID = DirectCast(objArr1(1), System.Guid)
            points = DirectCast(objArr1(2), double)
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub PublishEditedSubtitle2Async(ByVal session As System.Guid, ByVal originalSubtitleId As System.Guid, ByVal comment As String, ByVal data As String)
            PublishEditedSubtitle2Async(session, originalSubtitleId, comment, data, Nothing)
        End Sub

        Public Sub PublishEditedSubtitle2Async(ByVal session As System.Guid, ByVal originalSubtitleId As System.Guid, ByVal comment As String, ByVal data As String, ByVal userState As Object)
            If (PublishEditedSubtitle2OperationCompleted) Is Nothing Then
                PublishEditedSubtitle2OperationCompleted = New System.Threading.SendOrPostCallback(OnPublishEditedSubtitle2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     originalSubtitleId, _
                                                     comment, _
                                                     data }
            InvokeAsync("PublishEditedSubtitle2?", objArr1, PublishEditedSubtitle2OperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/PublishSubtitle", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function PublishSubtitle(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle, ByVal data As String, ByRef ID As System.Guid, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitle, _
                                                     data }
            Dim objArr1 As Object() = Invoke("PublishSubtitle?", objArr2)
            ID = DirectCast(objArr1(1), System.Guid)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/PublishSubtitle2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function PublishSubtitle2(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle, ByVal data As String, ByRef ID As System.Guid, ByRef points As Double, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitle, _
                                                     data }
            Dim objArr1 As Object() = Invoke("PublishSubtitle2?", objArr2)
            ID = DirectCast(objArr1(1), System.Guid)
            points = DirectCast(objArr1(2), double)
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub PublishSubtitle2Async(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle, ByVal data As String)
            PublishSubtitle2Async(session, subtitle, data, Nothing)
        End Sub

        Public Sub PublishSubtitle2Async(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle, ByVal data As String, ByVal userState As Object)
            If (PublishSubtitle2OperationCompleted) Is Nothing Then
                PublishSubtitle2OperationCompleted = New System.Threading.SendOrPostCallback(OnPublishSubtitle2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitle, _
                                                     data }
            InvokeAsync("PublishSubtitle2?", objArr1, PublishSubtitle2OperationCompleted, userState)
        End Sub

        Public Sub PublishSubtitleAsync(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle, ByVal data As String)
            PublishSubtitleAsync(session, subtitle, data, Nothing)
        End Sub

        Public Sub PublishSubtitleAsync(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle, ByVal data As String, ByVal userState As Object)
            If (PublishSubtitleOperationCompleted) Is Nothing Then
                PublishSubtitleOperationCompleted = New System.Threading.SendOrPostCallback(OnPublishSubtitleOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitle, _
                                                     data }
            InvokeAsync("PublishSubtitle?", objArr1, PublishSubtitleOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/RateSubtitle", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function RateSubtitle(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal rate As Integer, ByRef newVotes As Long, ByRef newRate As Double) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId, _
                                                     rate }
            Dim objArr1 As Object() = Invoke("RateSubtitle?", objArr2)
            newVotes = DirectCast(objArr1(1), long)
            newRate = DirectCast(objArr1(2), double)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub RateSubtitleAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal rate As Integer)
            RateSubtitleAsync(session, subtitleId, rate, Nothing)
        End Sub

        Public Sub RateSubtitleAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal rate As Integer, ByVal userState As Object)
            If (RateSubtitleOperationCompleted) Is Nothing Then
                RateSubtitleOperationCompleted = New System.Threading.SendOrPostCallback(OnRateSubtitleOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId, _
                                                     rate }
            InvokeAsync("RateSubtitle?", objArr1, RateSubtitleOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/Register", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function Register(ByVal username As String, ByVal password As String, ByVal email As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     username, _
                                                     password, _
                                                     email }
            Dim objArr1 As Object() = Invoke("Register?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub RegisterAsync(ByVal username As String, ByVal password As String, ByVal email As String, ByVal userState As Object)
            If (RegisterOperationCompleted) Is Nothing Then
                RegisterOperationCompleted = New System.Threading.SendOrPostCallback(OnRegisterOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     username, _
                                                     password, _
                                                     email }
            InvokeAsync("Register?", objArr1, RegisterOperationCompleted, userState)
        End Sub

        Public Sub RegisterAsync(ByVal username As String, ByVal password As String, ByVal email As String)
            RegisterAsync(username, password, email, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/ReportHashLink", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function ReportHashLink(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     videoHash }
            Dim objArr1 As Object() = Invoke("ReportHashLink?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub ReportHashLinkAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String, ByVal userState As Object)
            If (ReportHashLinkOperationCompleted) Is Nothing Then
                ReportHashLinkOperationCompleted = New System.Threading.SendOrPostCallback(OnReportHashLinkOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleID, _
                                                     videoHash }
            InvokeAsync("ReportHashLink?", objArr1, ReportHashLinkOperationCompleted, userState)
        End Sub

        Public Sub ReportHashLinkAsync(ByVal session As System.Guid, ByVal subtitleID As System.Guid, ByVal videoHash As String)
            ReportHashLinkAsync(session, subtitleID, videoHash, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/ReportSubtitle", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function ReportSubtitle(ByVal session As System.Guid, ByVal subtitleId As System.Guid) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            Dim objArr1 As Object() = Invoke("ReportSubtitle?", objArr2)
            Return DirectCast(objArr1(0), bool)
        End Function

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/ReportSubtitle2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function ReportSubtitle2(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal reason As Sublight.WS.ReportReason, ByVal comment As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId, _
                                                     reason, _
                                                     comment }
            Dim objArr1 As Object() = Invoke("ReportSubtitle2?", objArr2)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub ReportSubtitle2Async(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal reason As Sublight.WS.ReportReason, ByVal comment As String, ByVal userState As Object)
            If (ReportSubtitle2OperationCompleted) Is Nothing Then
                ReportSubtitle2OperationCompleted = New System.Threading.SendOrPostCallback(OnReportSubtitle2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId, _
                                                     reason, _
                                                     comment }
            InvokeAsync("ReportSubtitle2?", objArr1, ReportSubtitle2OperationCompleted, userState)
        End Sub

        Public Sub ReportSubtitle2Async(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal reason As Sublight.WS.ReportReason, ByVal comment As String)
            ReportSubtitle2Async(session, subtitleId, reason, comment, Nothing)
        End Sub

        Public Sub ReportSubtitleAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid)
            ReportSubtitleAsync(session, subtitleId, Nothing)
        End Sub

        Public Sub ReportSubtitleAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal userState As Object)
            If (ReportSubtitleOperationCompleted) Is Nothing Then
                ReportSubtitleOperationCompleted = New System.Threading.SendOrPostCallback(OnReportSubtitleOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            InvokeAsync("ReportSubtitle?", objArr1, ReportSubtitleOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/RequestPasswordReset", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function RequestPasswordReset(ByVal session As System.Guid, ByVal username As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     username }
            Dim objArr1 As Object() = Invoke("RequestPasswordReset?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub RequestPasswordResetAsync(ByVal session As System.Guid, ByVal username As String, ByVal userState As Object)
            If (RequestPasswordResetOperationCompleted) Is Nothing Then
                RequestPasswordResetOperationCompleted = New System.Threading.SendOrPostCallback(OnRequestPasswordResetOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     username }
            InvokeAsync("RequestPasswordReset?", objArr1, RequestPasswordResetOperationCompleted, userState)
        End Sub

        Public Sub RequestPasswordResetAsync(ByVal session As System.Guid, ByVal username As String)
            RequestPasswordResetAsync(session, username, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SearchSubtitles3", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SearchSubtitles3(ByVal session As System.Guid, ByVal videoHash As String, ByVal title As String, <System.Xml.Serialization.XmlElement(IsNullable = True)> ByVal year As System.Nullable(Of Integer), <System.Xml.Serialization.XmlElement(IsNullable = True)> ByVal season As System.Nullable(Of Byte), <System.Xml.Serialization.XmlElement(IsNullable = True)> ByVal episode As System.Nullable(Of Integer), ByVal languages As Sublight.WS.SubtitleLanguage(), ByVal genres As Sublight.WS.Genre(), ByVal sender As String, <System.Xml.Serialization.XmlElement(IsNullable = True)> ByVal rateGreaterThan As System.Nullable(Of Single), <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef subtitles As Sublight.WS.Subtitle(), <System.Xml.Serialization.XmlArrayItem(IsNullable = False)> ByRef releases As Sublight.WS.Release(), ByRef isLimited As Boolean, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     videoHash, _
                                                     title, _
                                                     year, _
                                                     season, _
                                                     episode, _
                                                     languages, _
                                                     genres, _
                                                     sender, _
                                                     rateGreaterThan }
            Dim objArr1 As Object() = Invoke("SearchSubtitles3?", objArr2)
            subtitles = CType(objArr1(1), Sublight.WS.Subtitle[])
            releases = CType(objArr1(2), Sublight.WS.Release[])
            isLimited = DirectCast(objArr1(3), bool)
            error = CType(objArr1(4), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SearchSubtitles3Async(ByVal session As System.Guid, ByVal videoHash As String, ByVal title As String, ByVal year As System.Nullable(Of Integer), ByVal season As System.Nullable(Of Byte), ByVal episode As System.Nullable(Of Integer), ByVal languages As Sublight.WS.SubtitleLanguage(), ByVal genres As Sublight.WS.Genre(), ByVal sender As String, ByVal rateGreaterThan As System.Nullable(Of Single), ByVal userState As Object)
            If (SearchSubtitles3OperationCompleted) Is Nothing Then
                SearchSubtitles3OperationCompleted = New System.Threading.SendOrPostCallback(OnSearchSubtitles3OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     videoHash, _
                                                     title, _
                                                     year, _
                                                     season, _
                                                     episode, _
                                                     languages, _
                                                     genres, _
                                                     sender, _
                                                     rateGreaterThan }
            InvokeAsync("SearchSubtitles3?", objArr1, SearchSubtitles3OperationCompleted, userState)
        End Sub

        Public Sub SearchSubtitles3Async(ByVal session As System.Guid, ByVal videoHash As String, ByVal title As String, ByVal year As System.Nullable(Of Integer), ByVal season As System.Nullable(Of Byte), ByVal episode As System.Nullable(Of Integer), ByVal languages As Sublight.WS.SubtitleLanguage(), ByVal genres As Sublight.WS.Genre(), ByVal sender As String, ByVal rateGreaterThan As System.Nullable(Of Single))
            SearchSubtitles3Async(session, videoHash, title, year, season, episode, languages, genres, sender, rateGreaterThan, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SendComment", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SendComment(ByVal session As System.Guid, ByVal subject As String, ByVal senderEmail As String, ByVal message As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subject, _
                                                     senderEmail, _
                                                     message }
            Dim objArr1 As Object() = Invoke("SendComment?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SendCommentAsync(ByVal session As System.Guid, ByVal subject As String, ByVal senderEmail As String, ByVal message As String)
            SendCommentAsync(session, subject, senderEmail, message, Nothing)
        End Sub

        Public Sub SendCommentAsync(ByVal session As System.Guid, ByVal subject As String, ByVal senderEmail As String, ByVal message As String, ByVal userState As Object)
            If (SendCommentOperationCompleted) Is Nothing Then
                SendCommentOperationCompleted = New System.Threading.SendOrPostCallback(OnSendCommentOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subject, _
                                                     senderEmail, _
                                                     message }
            InvokeAsync("SendComment?", objArr1, SendCommentOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SubtitleCommentDelete", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SubtitleCommentDelete(ByVal session As System.Guid, ByVal subtitleCommentID As System.Guid, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleCommentID }
            Dim objArr1 As Object() = Invoke("SubtitleCommentDelete?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SubtitleCommentDeleteAsync(ByVal session As System.Guid, ByVal subtitleCommentID As System.Guid, ByVal userState As Object)
            If (SubtitleCommentDeleteOperationCompleted) Is Nothing Then
                SubtitleCommentDeleteOperationCompleted = New System.Threading.SendOrPostCallback(OnSubtitleCommentDeleteOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleCommentID }
            InvokeAsync("SubtitleCommentDelete?", objArr1, SubtitleCommentDeleteOperationCompleted, userState)
        End Sub

        Public Sub SubtitleCommentDeleteAsync(ByVal session As System.Guid, ByVal subtitleCommentID As System.Guid)
            SubtitleCommentDeleteAsync(session, subtitleCommentID, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SubtitleCommentVote", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SubtitleCommentVote(ByVal session As System.Guid, ByVal subtitleCommentID As System.Guid, ByVal rate As Integer, ByRef newRate As Integer, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleCommentID, _
                                                     rate }
            Dim objArr1 As Object() = Invoke("SubtitleCommentVote?", objArr2)
            newRate = DirectCast(objArr1(1), int)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SubtitleCommentVoteAsync(ByVal session As System.Guid, ByVal subtitleCommentID As System.Guid, ByVal rate As Integer, ByVal userState As Object)
            If (SubtitleCommentVoteOperationCompleted) Is Nothing Then
                SubtitleCommentVoteOperationCompleted = New System.Threading.SendOrPostCallback(OnSubtitleCommentVoteOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleCommentID, _
                                                     rate }
            InvokeAsync("SubtitleCommentVote?", objArr1, SubtitleCommentVoteOperationCompleted, userState)
        End Sub

        Public Sub SubtitleCommentVoteAsync(ByVal session As System.Guid, ByVal subtitleCommentID As System.Guid, ByVal rate As Integer)
            SubtitleCommentVoteAsync(session, subtitleCommentID, rate, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SubtitlePreview", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SubtitlePreview(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByRef data As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            Dim objArr1 As Object() = Invoke("SubtitlePreview?", objArr2)
            data = CType(objArr1(1), string)
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SubtitlePreviewAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid, ByVal userState As Object)
            If (SubtitlePreviewOperationCompleted) Is Nothing Then
                SubtitlePreviewOperationCompleted = New System.Threading.SendOrPostCallback(OnSubtitlePreviewOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitleId }
            InvokeAsync("SubtitlePreview?", objArr1, SubtitlePreviewOperationCompleted, userState)
        End Sub

        Public Sub SubtitlePreviewAsync(ByVal session As System.Guid, ByVal subtitleId As System.Guid)
            SubtitlePreviewAsync(session, subtitleId, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SuggestTitles", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SuggestTitles(ByVal keyword As String, ByVal itemsCount As Integer, ByRef titles As Sublight.WS.IMDB(), ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     keyword, _
                                                     itemsCount }
            Dim objArr1 As Object() = Invoke("SuggestTitles?", objArr2)
            titles = CType(objArr1(1), Sublight.WS.IMDB[])
            error = CType(objArr1(2), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SuggestTitlesAsync(ByVal keyword As String, ByVal itemsCount As Integer, ByVal userState As Object)
            If (SuggestTitlesOperationCompleted) Is Nothing Then
                SuggestTitlesOperationCompleted = New System.Threading.SendOrPostCallback(OnSuggestTitlesOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     keyword, _
                                                     itemsCount }
            InvokeAsync("SuggestTitles?", objArr1, SuggestTitlesOperationCompleted, userState)
        End Sub

        Public Sub SuggestTitlesAsync(ByVal keyword As String, ByVal itemsCount As Integer)
            SuggestTitlesAsync(keyword, itemsCount, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/SynchronizeSubtitle", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function SynchronizeSubtitle(ByVal sessionID As System.Guid, ByVal subtitleID As System.Guid, ByVal codePage As Integer, ByVal videoFrameRate As Single, ByVal delay As Single, ByVal ticket As String, ByRef data As String, ByRef points As Double, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     sessionID, _
                                                     subtitleID, _
                                                     codePage, _
                                                     videoFrameRate, _
                                                     delay, _
                                                     ticket }
            Dim objArr1 As Object() = Invoke("SynchronizeSubtitle?", objArr2)
            data = CType(objArr1(1), string)
            points = DirectCast(objArr1(2), double)
            error = CType(objArr1(3), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub SynchronizeSubtitleAsync(ByVal sessionID As System.Guid, ByVal subtitleID As System.Guid, ByVal codePage As Integer, ByVal videoFrameRate As Single, ByVal delay As Single, ByVal ticket As String, ByVal userState As Object)
            If (SynchronizeSubtitleOperationCompleted) Is Nothing Then
                SynchronizeSubtitleOperationCompleted = New System.Threading.SendOrPostCallback(OnSynchronizeSubtitleOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     sessionID, _
                                                     subtitleID, _
                                                     codePage, _
                                                     videoFrameRate, _
                                                     delay, _
                                                     ticket }
            InvokeAsync("SynchronizeSubtitle?", objArr1, SynchronizeSubtitleOperationCompleted, userState)
        End Sub

        Public Sub SynchronizeSubtitleAsync(ByVal sessionID As System.Guid, ByVal subtitleID As System.Guid, ByVal codePage As Integer, ByVal videoFrameRate As Single, ByVal delay As Single, ByVal ticket As String)
            SynchronizeSubtitleAsync(sessionID, subtitleID, codePage, videoFrameRate, delay, ticket, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/UpdateEmail", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function UpdateEmail(ByVal session As System.Guid, ByVal newEmail As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     newEmail }
            Dim objArr1 As Object() = Invoke("UpdateEmail?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub UpdateEmailAsync(ByVal session As System.Guid, ByVal newEmail As String)
            UpdateEmailAsync(session, newEmail, Nothing)
        End Sub

        Public Sub UpdateEmailAsync(ByVal session As System.Guid, ByVal newEmail As String, ByVal userState As Object)
            If (UpdateEmailOperationCompleted) Is Nothing Then
                UpdateEmailOperationCompleted = New System.Threading.SendOrPostCallback(OnUpdateEmailOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     newEmail }
            InvokeAsync("UpdateEmail?", objArr1, UpdateEmailOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/UpdatePoster2", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function UpdatePoster2(ByVal session As System.Guid, ByVal imdb As String, ByVal posterUrl As String, ByVal data As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     imdb, _
                                                     posterUrl, _
                                                     data }
            Dim objArr1 As Object() = Invoke("UpdatePoster2?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub UpdatePoster2Async(ByVal session As System.Guid, ByVal imdb As String, ByVal posterUrl As String, ByVal data As String, ByVal userState As Object)
            If (UpdatePoster2OperationCompleted) Is Nothing Then
                UpdatePoster2OperationCompleted = New System.Threading.SendOrPostCallback(OnUpdatePoster2OperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     imdb, _
                                                     posterUrl, _
                                                     data }
            InvokeAsync("UpdatePoster2?", objArr1, UpdatePoster2OperationCompleted, userState)
        End Sub

        Public Sub UpdatePoster2Async(ByVal session As System.Guid, ByVal imdb As String, ByVal posterUrl As String, ByVal data As String)
            UpdatePoster2Async(session, imdb, posterUrl, data, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/UpdatePosterUrl", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function UpdatePosterUrl(ByVal session As System.Guid, ByVal imdb As String, ByVal posterUrl As String, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     imdb, _
                                                     posterUrl }
            Dim objArr1 As Object() = Invoke("UpdatePosterUrl?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub UpdatePosterUrlAsync(ByVal session As System.Guid, ByVal imdb As String, ByVal posterUrl As String)
            UpdatePosterUrlAsync(session, imdb, posterUrl, Nothing)
        End Sub

        Public Sub UpdatePosterUrlAsync(ByVal session As System.Guid, ByVal imdb As String, ByVal posterUrl As String, ByVal userState As Object)
            If (UpdatePosterUrlOperationCompleted) Is Nothing Then
                UpdatePosterUrlOperationCompleted = New System.Threading.SendOrPostCallback(OnUpdatePosterUrlOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     imdb, _
                                                     posterUrl }
            InvokeAsync("UpdatePosterUrl?", objArr1, UpdatePosterUrlOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/UpdateSubtitle", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function UpdateSubtitle(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     subtitle }
            Dim objArr1 As Object() = Invoke("UpdateSubtitle?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub UpdateSubtitleAsync(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle)
            UpdateSubtitleAsync(session, subtitle, Nothing)
        End Sub

        Public Sub UpdateSubtitleAsync(ByVal session As System.Guid, ByVal subtitle As Sublight.WS.Subtitle, ByVal userState As Object)
            If (UpdateSubtitleOperationCompleted) Is Nothing Then
                UpdateSubtitleOperationCompleted = New System.Threading.SendOrPostCallback(OnUpdateSubtitleOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     subtitle }
            InvokeAsync("UpdateSubtitle?", objArr1, UpdateSubtitleOperationCompleted, userState)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/UpdateUserRating", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function UpdateUserRating(ByVal session As System.Guid, ByVal imdb As String, ByVal rate As Single, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     imdb, _
                                                     rate }
            Dim objArr1 As Object() = Invoke("UpdateUserRating?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub UpdateUserRatingAsync(ByVal session As System.Guid, ByVal imdb As String, ByVal rate As Single, ByVal userState As Object)
            If (UpdateUserRatingOperationCompleted) Is Nothing Then
                UpdateUserRatingOperationCompleted = New System.Threading.SendOrPostCallback(OnUpdateUserRatingOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     imdb, _
                                                     rate }
            InvokeAsync("UpdateUserRating?", objArr1, UpdateUserRatingOperationCompleted, userState)
        End Sub

        Public Sub UpdateUserRatingAsync(ByVal session As System.Guid, ByVal imdb As String, ByVal rate As Single)
            UpdateUserRatingAsync(session, imdb, rate, Nothing)
        End Sub

        <System.Web.Services.Protocols.SoapDocumentMethod("http://www.sublight.si/VoteMovieHash", RequestNamespace = "http://www.sublight.si/", ResponseNamespace = "http://www.sublight.si/", Use = (System.Web.Services.Description.SoapBindingUse)2, ParameterStyle = (System.Web.Services.Protocols.SoapParameterStyle)2)> _
        Public Function VoteMovieHash(ByVal session As System.Guid, ByVal imdb As String, <System.Xml.Serialization.XmlElement(IsNullable = True)> ByVal season As System.Nullable(Of Byte), <System.Xml.Serialization.XmlElement(IsNullable = True)> ByVal episode As System.Nullable(Of Integer), ByVal videoHash As String, ByVal type As Sublight.WS.MovieHashVote, ByRef error As String) As Boolean
            Dim objArr2 As Object() = New object() { _
                                                     session, _
                                                     imdb, _
                                                     season, _
                                                     episode, _
                                                     videoHash, _
                                                     type }
            Dim objArr1 As Object() = Invoke("VoteMovieHash?", objArr2)
            error = CType(objArr1(1), string)
            Return DirectCast(objArr1(0), bool)
        End Function

        Public Sub VoteMovieHashAsync(ByVal session As System.Guid, ByVal imdb As String, ByVal season As System.Nullable(Of Byte), ByVal episode As System.Nullable(Of Integer), ByVal videoHash As String, ByVal type As Sublight.WS.MovieHashVote)
            VoteMovieHashAsync(session, imdb, season, episode, videoHash, type, Nothing)
        End Sub

        Public Sub VoteMovieHashAsync(ByVal session As System.Guid, ByVal imdb As String, ByVal season As System.Nullable(Of Byte), ByVal episode As System.Nullable(Of Integer), ByVal videoHash As String, ByVal type As Sublight.WS.MovieHashVote, ByVal userState As Object)
            If (VoteMovieHashOperationCompleted) Is Nothing Then
                VoteMovieHashOperationCompleted = New System.Threading.SendOrPostCallback(OnVoteMovieHashOperationCompleted)
            End If
            Dim objArr1 As Object() = New object() { _
                                                     session, _
                                                     imdb, _
                                                     season, _
                                                     episode, _
                                                     videoHash, _
                                                     type }
            InvokeAsync("VoteMovieHash?", objArr1, VoteMovieHashOperationCompleted, userState)
        End Sub

    End Class ' class Sublight

End Namespace

