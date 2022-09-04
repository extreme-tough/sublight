Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BinaryComponents.SuperList.Sections
Imports Sublight

Namespace Sublight.Controls

    Friend Class ImageToolTip
        Inherits System.ComponentModel.Component

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private <InitialDelay>k__BackingField As Integer 
        Private components As System.ComponentModel.IContainer 
        Private m_Control As Sublight.Controls.MySuperList 
        Private m_PreviousToolTipLocation As System.Drawing.Point 
        Private m_PreviusData As Sublight.Controls.SuperListItem.Data 
        Private timer1 As System.Windows.Forms.Timer 
        Private tt As Sublight.FrmTooltip 

        Public Property InitialDelay As Integer
            Get
                Return <InitialDelay>k__BackingField
            End Get
            Set
                <InitialDelay>k__BackingField = value
            End Set
        End Property

        Public Sub New(ByVal control As Sublight.Controls.MySuperList)
            tt = New Sublight.FrmTooltip
            InitializeComponent()
            InitialDelay = 2000
            m_Control = control
            AddHandler timer1.Tick, AddressOf timer1_Tick
        End Sub

        Public Sub Hide()
            timer1.Stop()
            tt.HideTip()
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            timer1 = New System.Windows.Forms.Timer(components)
        End Sub

        Public Sub Show(ByVal e As System.Windows.Forms.MouseEventArgs)
            If m_PreviousToolTipLocation = e.Location Then
                Return
            End If
            Dim section1 As BinaryComponents.SuperList.Sections.Section = m_Control.SectionFromPoint(e.Location)
            If (section1) Is Nothing Then
                Return
            End If
            Dim rowSection1 As BinaryComponents.SuperList.Sections.RowSection = TryCast(section1, BinaryComponents.SuperList.Sections.RowSection)
            Dim data1 As Sublight.Controls.SuperListItem.Data = Nothing
            If (rowSection1) Is Nothing Then
                Dim cellSection1 As BinaryComponents.SuperList.Sections.CellSection = TryCast(section1, BinaryComponents.SuperList.Sections.CellSection)
                If (cellSection1) Is Nothing Then
                    Return
                End If
                data1 = TryCast(cellSection1(), Sublight.Controls.SuperListItem.Data)
            Else 
                data1 = TryCast(rowSection1(), Sublight.Controls.SuperListItem.Data)
            End If
            If (data1) Is Nothing Then
                Return
            End If
            m_PreviousToolTipLocation = e.Location
            m_PreviusData = data1
            If (Not (tt) Is Nothing) AndAlso Not tt.IsDisposed AndAlso tt.Visible Then
                tt.HideTip()
            End If
            timer1.Interval = InitialDelay
            timer1.Stop()
            timer1.Start()
        End Sub

        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            timer1.Stop()
            If (Not (m_PreviusData) Is Nothing) AndAlso (Not (m_Control) Is Nothing) AndAlso (Not (m_Control.ParentForm) Is Nothing) Then
                Dim i1 As Integer = m_Control.ParentForm.Left + m_Control.Left + m_PreviousToolTipLocation.X
                Dim i2 As Integer = m_Control.ParentForm.Top + m_Control.Top + m_PreviousToolTipLocation.Y
                tt.Location = New System.Drawing.Point(i1, i2)
                Dim baseForm1 As Sublight.BaseForm = TryCast(m_Control.ParentForm, Sublight.BaseForm)
                If (Not (baseForm1) Is Nothing) AndAlso Not baseForm1.IsDisposed AndAlso baseForm1.IsActive Then
                    If Not (tt) Is Nothing Then
                        If tt.IsDisposed Then
                            tt = New Sublight.FrmTooltip
                        End If
                    Else 
                        tt = New Sublight.FrmTooltip
                    End If
                    tt.Show(baseForm1, m_PreviusData.Subtitle.IMDB, m_PreviusData.Subtitle.Title, m_PreviusData.Subtitle.Year)
                End If
            End If
        End Sub

    End Class ' class ImageToolTip

End Namespace

