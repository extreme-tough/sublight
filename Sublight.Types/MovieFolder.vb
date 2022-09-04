Namespace Sublight.Types

    <System.Serializable> _
    Public Structure MovieFolder

        Public Path As String 
        Public Pattern As String 
        Public SearchSubfolders As Boolean 

        Public Sub New(ByVal path As String, ByVal pattern As String, ByVal searchSubfolders As Boolean)
            Path = path
            Pattern = pattern
            SearchSubfolders = searchSubfolders
        End Sub

    End Structure

End Namespace

