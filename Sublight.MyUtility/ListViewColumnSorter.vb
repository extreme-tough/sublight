Imports System.Collections
Imports System.Windows.Forms

Namespace Sublight.MyUtility

    Public NotInheritable Class ListViewColumnSorter
        Implements System.Collections.IComparer

        Private ReadOnly ObjectCompare As System.Collections.CaseInsensitiveComparer 

        Private ColumnToSort As Integer 
        Private OrderOfSort As System.Windows.Forms.SortOrder 

        Public Property Order As System.Windows.Forms.SortOrder
            Get
                Return OrderOfSort
            End Get
            Set
                OrderOfSort = value
            End Set
        End Property

        Public Property SortColumn As Integer
            Get
                Return ColumnToSort
            End Get
            Set
                ColumnToSort = value
            End Set
        End Property

        Public Sub New()
            OrderOfSort = System.Windows.Forms.SortOrder.None
            ObjectCompare = New System.Collections.CaseInsensitiveComparer
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer
            Dim i1 As Integer

            Dim listViewItem1 As System.Windows.Forms.ListViewItem = CType(x, System.Windows.Forms.ListViewItem)
            Dim listViewItem2 As System.Windows.Forms.ListViewItem = CType(y, System.Windows.Forms.ListViewItem)
            If (Not (listViewItem1.SubItems(ColumnToSort).Tag) Is Nothing) OrElse (Not (listViewItem2.SubItems(ColumnToSort).Tag) Is Nothing) Then
                i1 = ObjectCompare.Compare(listViewItem1.SubItems(ColumnToSort).Tag, listViewItem2.SubItems(ColumnToSort).Tag)
            Else 
                i1 = ObjectCompare.Compare(listViewItem1.SubItems(ColumnToSort).Text, listViewItem2.SubItems(ColumnToSort).Text)
            End If
            If OrderOfSort = System.Windows.Forms.SortOrder.Ascending Then
                Return i1
            End If
            If OrderOfSort = System.Windows.Forms.SortOrder.Descending Then
                Return -i1
            End If
            Return 0
        End Function

    End Class ' class ListViewColumnSorter

End Namespace

