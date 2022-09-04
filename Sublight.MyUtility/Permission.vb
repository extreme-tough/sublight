Imports Sublight
Imports Sublight.WS

Namespace Sublight.MyUtility

    Friend MustInherit Class Permission

        Protected Sub New()
        End Sub

        Friend Shared Function CanAddRelease(ByVal subtitle As Sublight.WS.Subtitle) As Boolean
            Dim flag1 As Boolean

            Try
                flag1 = Not Sublight.BaseForm.IsAnonymous
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

        Friend Shared Function CanEditSubtitle(ByVal subtitle As Sublight.WS.Subtitle) As Boolean
            Dim flag1 As Boolean

            Try
                If Sublight.BaseForm.IsAdministrator() Then
                    Return True
                End If
                If Sublight.BaseForm.IsSubtitleEditor(subtitle) Then
                    Return True
                End If
                If Sublight.BaseForm.CanSubtitlePublisherEdit(subtitle) Then
                    Return True
                End If
                flag1 = False
            Catch 
                flag1 = False
            End Try
            Return flag1
        End Function

    End Class ' class Permission

End Namespace

