Imports System
Imports System.Runtime.CompilerServices
Imports System.Text
Imports BinaryComponents.SuperList
Imports Sublight
Imports Sublight.MyUtility
Imports Sublight.WS

Namespace Sublight.Controls

    Friend Class MySuperList
        Inherits BinaryComponents.SuperList.ListControl

        Private Class DownloadsColumn
            Implements System.IComparable

            Private ReadOnly _data As Sublight.Controls.SuperListItem.Data 

            Public Sub New(ByVal data As Object)
                _data = TryCast(data, Sublight.Controls.SuperListItem.Data)
            End Sub

            Public Function CompareTo(ByVal obj As Object) As Integer
                Dim downloadsColumn1 As Sublight.Controls.MySuperList.DownloadsColumn = TryCast(obj, Sublight.Controls.MySuperList.DownloadsColumn)
                If (downloadsColumn1) Is Nothing Then
                    Return 1
                End If
                If ((downloadsColumn1._data) Is Nothing) OrElse ((downloadsColumn1._data.Subtitle) Is Nothing) Then
                    Return 1
                End If
                If ((_data) Is Nothing) OrElse ((_data.Subtitle) Is Nothing) Then
                    Return -1
                End If
                Return get_Default().Compare(downloadsColumn1._data.Subtitle.Downloads, _data.Subtitle.Downloads)
            End Function

            Public Overrides Function ToString() As String
                If (_data) Is Nothing Then
                    Return System.String.Empty
                End If
                If Not (_data.SubtitleProvider) Is Nothing Then
                    Return System.String.Empty
                End If
                Dim i1 As Integer = _data.Subtitle.Downloads
                Return i1.ToString()
            End Function

        End Class ' class DownloadsColumn

        Private Class PublishColumn
            Implements System.IComparable

            Private m_dt As System.Nullable(Of System.DateTime) 

            Public ReadOnly Property Dt As System.Nullable(Of System.DateTime)
                Get
                    Return m_dt
                End Get
            End Property

            Public Sub New(ByVal dt As System.Nullable(Of System.DateTime))
                m_dt = dt
            End Sub

            Public Function CompareTo(ByVal obj As Object) As Integer
                Dim publishColumn1 As Sublight.Controls.MySuperList.PublishColumn = TryCast(obj, Sublight.Controls.MySuperList.PublishColumn)
                If (publishColumn1) Is Nothing Then
                    Return 1
                End If
                Dim nullable5 As System.Nullable(Of System.DateTime) = publishColumn1.Dt
                If Not nullable5.get_HasValue() AndAlso Not m_dt.get_HasValue() Then
                    Return 0
                End If
                Dim nullable6 As System.Nullable(Of System.DateTime) = publishColumn1.Dt
                If Not nullable6.get_HasValue() AndAlso m_dt.get_HasValue() Then
                    Return 1
                End If
                Dim nullable4 As System.Nullable(Of System.DateTime) = publishColumn1.Dt
                If nullable4.get_HasValue() AndAlso Not m_dt.get_HasValue() Then
                    Return -1
                End If
                Dim nullable1 As System.Nullable(Of System.DateTime) = publishColumn1.Dt
                If nullable1.get_HasValue() AndAlso m_dt.get_HasValue() Then
                    Dim nullable2 As System.Nullable(Of System.DateTime) = publishColumn1.Dt
                    If nullable2.get_Value() > m_dt.get_Value() Then
                        Return 1
                    End If
                    Dim nullable3 As System.Nullable(Of System.DateTime) = publishColumn1.Dt
                    If nullable3.get_Value() < m_dt.get_Value() Then
                        Return -1
                    End If
                End If
                Return 0
            End Function

            Public Overrides Function ToString() As String
                If Not m_dt.get_HasValue() Then
                    Return System.String.Empty
                End If
                Dim dateTime1 As System.DateTime = m_dt.get_Value()
                Return dateTime1.ToShortDateString()
            End Function

        End Class ' class PublishColumn

        Private Class SizeColumn
            Implements System.IComparable

            Private ReadOnly _data As Sublight.Controls.SuperListItem.Data 

            Public Sub New(ByVal data As Object)
                _data = TryCast(data, Sublight.Controls.SuperListItem.Data)
            End Sub

            Public Function CompareTo(ByVal obj As Object) As Integer
                Dim sizeColumn1 As Sublight.Controls.MySuperList.SizeColumn = TryCast(obj, Sublight.Controls.MySuperList.SizeColumn)
                If (sizeColumn1) Is Nothing Then
                    Return 1
                End If
                If ((sizeColumn1._data) Is Nothing) OrElse ((sizeColumn1._data.Subtitle) Is Nothing) Then
                    Return 1
                End If
                If ((_data) Is Nothing) OrElse ((_data.Subtitle) Is Nothing) Then
                    Return -1
                End If
                Return get_Default().Compare(sizeColumn1._data.Subtitle.Size, _data.Subtitle.Size)
            End Function

            Public Overrides Function ToString() As String
                If ((_data) Is Nothing) OrElse ((_data.Subtitle) Is Nothing) Then
                    Return System.String.Empty
                End If
                If _data.Subtitle.Size <= 0 Then
                    Return System.String.Empty
                End If
                Return System.String.Format("{0} KB?", System.Convert.ToInt32(CDbl(_data.Subtitle.Size) / 1024.0R))
            End Function

        End Class ' class SizeColumn

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate10 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate11 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate12 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate13 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate14 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate15 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate16 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate17 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate18 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegate19 As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegated As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegatee As BinaryComponents.SuperList.ColumnItemValueAccessor 
        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared CS$<>9__CachedAnonymousMethodDelegatef As BinaryComponents.SuperList.ColumnItemValueAccessor 

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Name = "MySuperList?"
            AddHandler Load, AddressOf MySuperList_Load
        End Sub

        Private Sub MySuperList_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            MultiSelect = False
            AllowDrop = False
            ShowCustomizeSection = False
            AlternatingRowColor = Sublight.Globals.ColorSubtitleUnlinkedAlternateBg
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegated) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegated = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__0)
            End If
            Dim column1 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Title?", "Naslov?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegated)
            Columns.Add(column1)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegatee) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegatee = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__1)
            End If
            Dim column2 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Year?", "Leto?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegatee)
            Columns.Add(column2)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegatef) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegatef = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__2)
            End If
            Dim column3 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("MediaType?", "Medij?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegatef)
            Columns.Add(column3)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate10) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate10 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__3)
            End If
            Dim column4 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Language?", "Jezik?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate10)
            Columns.Add(column4)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate11) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate11 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__4)
            End If
            Dim column5 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("SubtitleType?", "Tip?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate11)
            Columns.Add(column5)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate12) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate12 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__5)
            End If
            Dim column6 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Size?", "Velikost?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate12)
            Columns.Add(column6)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate13) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate13 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__6)
            End If
            Dim column7 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Downloads?", "Prenosi?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate13)
            Columns.Add(column7)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate14) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate14 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__7)
            End If
            Dim column8 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Votes?", "Glasovi?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate14)
            Columns.Add(column8)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate15) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate15 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__8)
            End If
            Dim column9 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Reports?", "Prijave?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate15)
            Columns.Add(column9)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate16) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate16 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__9)
            End If
            Dim column10 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Publisher?", "Pošiljatelj?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate16)
            Columns.Add(column10)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate17) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate17 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__a)
            End If
            Dim column11 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Created?", "Poslano?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate17)
            Columns.Add(column11)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate18) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate18 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__b)
            End If
            Dim column12 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Episode?", "Epizoda?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate18)
            Columns.Add(column12)
            If (Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate19) Is Nothing Then
                Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate19 = New BinaryComponents.SuperList.ColumnItemValueAccessor(Sublight.Controls.MySuperList.<MySuperList_Load>b__c)
            End If
            Dim column13 As BinaryComponents.SuperList.Column = New BinaryComponents.SuperList.Column("Attributes?", "Attributes?", 0, Sublight.Controls.MySuperList.CS$<>9__CachedAnonymousMethodDelegate19)
            Columns.Add(column13)
            SizeColumnsToFit()
        End Sub

        Private Function SetText(ByVal name As String, ByVal text As String) As Boolean
            Dim i1 As Integer = 0
            While i1 < Columns.get_Count()
                If Columns.get_Item(i1).Name = name Then
                    Columns.get_Item(i1).Caption = text
                    Return True
                End If
                i1 = i1 + 1
            End While
            Return False
        End Function

        Public Sub Translate()
            SetText("Title?", Sublight.Translation.Common_SearchResults_Column_Title)
            SetText("Year?", Sublight.Translation.Common_SearchResults_Column_Year)
            SetText("MediaType?", Sublight.Translation.Common_SearchResults_Column_MediaType)
            SetText("Language?", Sublight.Translation.Common_SearchResults_Column_Language)
            SetText("SubtitleType?", Sublight.Translation.Common_SearchResults_Column_SubtitleType)
            SetText("Size?", Sublight.Translation.Common_SearchResults_Column_Size)
            SetText("Downloads?", Sublight.Translation.Common_SearchResults_Column_Downloads)
            SetText("Votes?", Sublight.Translation.Common_SearchResults_Column_Votes)
            SetText("Reports?", Sublight.Translation.Common_SearchResults_Column_Reports)
            SetText("Publisher?", Sublight.Translation.Common_SearchResults_Column_Publisher)
            SetText("Created?", Sublight.Translation.Common_SearchResults_Column_Created)
            SetText("Episode?", Sublight.Translation.Common_SearchResults_Column_Episode)
            SetText("Attributes?", Sublight.Translation.Common_SearchResults_Column_Attributes)
        End Sub

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__0(ByVal item As Object) As Object
            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            Return data1.Subtitle.Title
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__1(ByVal item As Object) As Object
            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            Dim nullable2 As System.Nullable(Of Integer) = data1.Subtitle.Year
            If Not nullable2.get_HasValue() Then
                Return System.String.Empty
            End If
            Dim nullable1 As System.Nullable(Of Integer) = data1.Subtitle.Year
            Return nullable1.get_Value()
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__2(ByVal item As Object) As Object
            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            If data1.Subtitle.NumberOfDiscs <= 0 Then
                Return System.String.Empty
            End If
            If data1.Subtitle.MediaType = Sublight.WS.MediaType.Unknown Then
                Return System.String.Empty
            End If
            Return System.String.Format("{0} × {1}?", data1.Subtitle.NumberOfDiscs, Sublight.Globals.GetString(data1.Subtitle.MediaType))
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__3(ByVal item As Object) As Object
            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            Return Sublight.Globals.GetString(data1.Subtitle.Language)
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__4(ByVal item As Object) As Object
            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            Dim s1 As String = data1.Subtitle.SubtitleType.ToString().ToLower()
            If s1 = "sub?" Then
                Return "MicroDVD?"
            End If
            If s1 = "srt?" Then
                Return "SubRip?"
            End If
            If s1 = "subviewer2?" Then
                Return "SubViewer 2.0?"
            End If
            If s1 = "sami?" Then
                Return "SAMI 1.0?"
            End If
            If (data1.SubtitleProvider) Is Nothing Then
                Return s1
            End If
            Return "AutoDetect?"
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__5(ByVal item As Object) As Object
            Return New Sublight.Controls.MySuperList.SizeColumn(item)
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__6(ByVal item As Object) As Object
            Return New Sublight.Controls.MySuperList.DownloadsColumn(item)
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__7(ByVal item As Object) As Object
            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            If Not (data1.SubtitleProvider) Is Nothing Then
                Return System.String.Empty
            End If
            Return System.String.Format("{0}?", data1.Subtitle.Votes)
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__8(ByVal item As Object) As Object
            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            If Not (data1.SubtitleProvider) Is Nothing Then
                Return System.String.Empty
            End If
            Dim i1 As Integer = data1.Subtitle.Reports
            Return i1.ToString()
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__9(ByVal item As Object) As Object
            Dim s1 As String

            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            If Not (data1.SubtitleProvider) Is Nothing Then
                If Not System.String.IsNullOrEmpty(data1.Subtitle.Publisher) Then
                    s1 = data1.Subtitle.Publisher
                Else 
                    s1 = System.String.Empty
                End If
                Return System.String.Format("[{1}] {0}?", s1, data1.SubtitleProvider.ShortName).Trim()
            End If
            Return data1.Subtitle.Publisher
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__a(ByVal item As Object) As Object
            Dim nullable1 As System.Nullable(Of System.DateTime)
            Dim nullable2 As System.Nullable(Of System.DateTime)

            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                nullable2 = New System.Nullable(Of System.DateTime)[]
                Return New Sublight.Controls.MySuperList.PublishColumn(nullable2)
            End If
            If data1.Subtitle.Created = System.DateTime.MinValue Then
                nullable1 = New System.Nullable(Of System.DateTime)[]
                Return New Sublight.Controls.MySuperList.PublishColumn(nullable1)
            End If
            Return New Sublight.Controls.MySuperList.PublishColumn(New System.Nullable(Of System.DateTime)(data1.Subtitle.Created))
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__b(ByVal item As Object) As Object
            Dim nullable3 As System.Nullable(Of Integer)

            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim nullable4 As System.Nullable(Of Byte) = data1.Subtitle.Season
            If Not nullable4.get_HasValue() Then
                GoTo label_0
            End If
            nullable3 = New System.Nullable(Of Integer)[]
            Dim nullable1 As System.Nullable(Of Integer) = New System.Nullable(Of Integer)(nullable4.GetValueOrDefault())
            If nullable1.get_HasValue() Then
                stringBuilder1.AppendFormat("S{0:00}?", data1.Subtitle.Season)
            End If
            Dim nullable2 As System.Nullable(Of Integer) = data1.Subtitle.Episode
            If nullable2.get_HasValue() Then
                stringBuilder1.AppendFormat("E{0:00}?", data1.Subtitle.Episode)
            End If
            Return stringBuilder1.ToString()
        End Function

        <System.Runtime.CompilerServices.CompilerGenerated> _
        Private Shared Function <MySuperList_Load>b__c(ByVal item As Object) As Object
            Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(item, Sublight.Controls.SuperListItem.Data)
            If (data1) Is Nothing Then
                Return System.String.Empty
            End If
            Return Sublight.MyUtility.SubtitleUtil.GetAttributes(data1.Subtitle)
        End Function

    End Class ' class MySuperList

End Namespace

