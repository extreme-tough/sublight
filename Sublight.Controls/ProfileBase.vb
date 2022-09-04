Imports System.Windows.Forms
Imports Sublight

Namespace Sublight.Controls

    Public Class ProfileBase
        Inherits System.Windows.Forms.UserControl

        Private ReadOnly m_ParentBaseForm As Sublight.BaseForm 

        Protected ReadOnly Property ParentBaseForm As Sublight.BaseForm
            Get
                Return m_ParentBaseForm
            End Get
        End Property

        Private Sub New()
        End Sub

        Public Sub New(ByVal baseForm As Sublight.BaseForm)
            m_ParentBaseForm = baseForm
        End Sub

    End Class ' class ProfileBase

End Namespace

