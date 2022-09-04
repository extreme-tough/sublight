Imports System
Imports Sublight
Imports Sublight.Controls
Imports Sublight.WS

Namespace Sublight.Types

    Public Class ListItem

        Private m_Text As String 
        Private m_Value As Object 

        Private Shared m_NotSelected As System.Guid 

        Public Property Text As String
            Get
                Return m_Text
            End Get
            Set
                m_Text = value
            End Set
        End Property

        Public Property Value As Object
            Get
                Return m_Value
            End Get
            Set
                m_Value = value
            End Set
        End Property

        Public Sub New(ByVal text As String, ByVal value As Object)
            m_Text = text
            m_Value = value
        End Sub

        Shared Sub New()
            Sublight.Types.ListItem.m_NotSelected = New System.Guid("{A45C04F8-7D53-4c8c-A3E1-1116E0D11390}?")
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Shared Function CreateNotSelected() As Sublight.Types.ListItem
            Return New Sublight.Types.ListItem(Sublight.Translation.Common_Selection_NotSelected, Sublight.Types.ListItem.m_NotSelected)
        End Function

        Public Shared Function IsNotSelected(ByVal item As Sublight.Types.ListItem) As Boolean
            If (item) Is Nothing Then
                Return False
            End If
            If TypeOf item.Value Is System.Guid Then
                Return False
            End If
            Return DirectCast(item.Value, System.Guid) = Sublight.Types.ListItem.m_NotSelected
        End Function

        Private Shared Function IsNumber(ByVal obj As Object) As Boolean
            If TryCast(obj, byte) OrElse TryCast(obj, short) OrElse TryCast(obj, int) OrElse TryCast(obj, long) Then
                Return True
            End If
            Return False
        End Function

        Public Shared Function Select(ByVal cb As Sublight.Controls.MyComboBox, ByVal val As Object) As Boolean
            If (cb) Is Nothing Then
                Return False
            End If
            If TryCast(val, Sublight.WS.MediaType) AndAlso (DirectCast(val, Sublight.WS.MediaType) = Sublight.WS.MediaType.BlueRay) Then
                val = 4
            End If
            Dim i1 As Integer = 0
            While i1 < cb.Items.Count
                Dim listItem1 As Sublight.Types.ListItem = TryCast(cb.Items(i1), Sublight.Types.ListItem)
                If (Not (listItem1) Is Nothing) AndAlso (Not (listItem1.Value) Is Nothing) Then
                    If Sublight.Types.ListItem.IsNumber(listItem1.Value) AndAlso Sublight.Types.ListItem.IsNumber(val) AndAlso (System.Convert.ToInt64(listItem1.Value) = System.Convert.ToInt64(val)) Then
                        cb.SelectedIndex = i1
                        Return True
                    End If
                    If listItem1.Value.Equals(val) Then
                        cb.SelectedIndex = i1
                        Return True
                    End If
                End If
                i1 = i1 + 1
            End While
            Return False
        End Function

    End Class ' class ListItem

End Namespace

