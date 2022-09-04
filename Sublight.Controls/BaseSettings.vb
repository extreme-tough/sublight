Imports System.ComponentModel
Imports System.Windows.Forms
Imports Sublight

Namespace Sublight.Controls

    Public Class BaseSettings
        Inherits System.Windows.Forms.UserControl

        Private components As System.ComponentModel.IContainer 
        Private m_ParentForm As Sublight.BaseForm 

        Protected ReadOnly Property ParentBaseForm As Sublight.BaseForm
            Get
                Return m_ParentForm
            End Get
        End Property

        Public Overridable ReadOnly Property Title As String
            Get
                Return Nothing
            End Get
        End Property

        Public Sub New(ByVal parentForm As Sublight.BaseForm)
            InitializeComponent()
            m_ParentForm = parentForm
        End Sub

        Friend Sub New()
            Visible = False
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Overridable Function LoadSettings(ByRef error As String) As Boolean
            error = Nothing
            Return True
        End Function

        Public Overridable Sub OnAfterReset()
        End Sub

        Public Overridable Sub OnBeforeReset()
        End Sub

        Public Overridable Sub OnDisplayed()
        End Sub

        Public Overridable Function SaveSettings(ByVal quietMode As Boolean, ByRef error As String) As Boolean
            error = Nothing
            Return True
        End Function

        Public Overridable Sub Translate()
        End Sub

    End Class ' class BaseSettings

End Namespace

