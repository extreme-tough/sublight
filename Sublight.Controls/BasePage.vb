Imports System.Windows.Forms
Imports Elegant.Ui
Imports Sublight

Namespace Sublight.Controls

    Friend Class BasePage
        Inherits System.Windows.Forms.UserControl

        Private ReadOnly _rtp As Elegant.Ui.RibbonTabPage 
        Private ReadOnly m_ParentForm As Sublight.BaseForm 

        Protected ReadOnly Property IsActiveTab As Boolean
            Get
                If (Sublight.Globals.Ribbon) Is Nothing Then
                    Return False
                End If
                If Sublight.Globals.Ribbon.CurrentTabPage = RibbonTabPage Then
                    Return True
                End If
                Return False
            End Get
        End Property

        Protected ReadOnly Property ParentBaseForm As Sublight.BaseForm
            Get
                Return m_ParentForm
            End Get
        End Property

        Public ReadOnly Property RibbonTabPage As Elegant.Ui.RibbonTabPage
            Get
                Return _rtp
            End Get
        End Property

        Protected Sub New()
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
            UpdateStyles()
        End Sub

        Public Sub New(ByVal parent As Sublight.BaseForm, ByVal rtp As Elegant.Ui.RibbonTabPage)
            m_ParentForm = parent
            _rtp = rtp
        End Sub

        Protected Function GetTabControlByName(ByVal name As String) As Elegant.Ui.Control
            If (RibbonTabPage) Is Nothing Then
                Return Nothing
            End If
            Dim controlArr1 As System.Windows.Forms.Control() = RibbonTabPage.Controls.Find(name, True)
            If controlArr1.Length = 1 Then
                Return TryCast(controlArr1(0), Elegant.Ui.Control)
            End If
            Return Nothing
        End Function

        Public Overridable Sub OnDisplayed()
        End Sub

        Protected Shared Sub SetVisibility(ByVal tsi As System.Windows.Forms.ToolStripItem, ByVal visible As Boolean)
            If Not (tsi) Is Nothing Then
                tsi.Visible = visible
            End If
        End Sub

    End Class ' class BasePage

End Namespace

