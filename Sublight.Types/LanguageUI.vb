Namespace Sublight.Types

    Friend Class LanguageUI

        Private m_Id As String 
        Private m_Name As String 

        Public ReadOnly Property Id As String
            Get
                Return m_Id
            End Get
        End Property

        Public Sub New(ByVal name As String, ByVal id As String)
            m_Name = name
            m_Id = id
        End Sub

        Public Overrides Function ToString() As String
            Return m_Name
        End Function

    End Class ' class LanguageUI

End Namespace

