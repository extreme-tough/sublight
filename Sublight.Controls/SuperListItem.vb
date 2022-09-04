Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports BinaryComponents.SuperList
Imports BinaryComponents.SuperList.Sections
Imports Sublight
Imports Sublight.Plugins.SubtitleProvider
Imports Sublight.WS

Namespace Sublight.Controls

    Friend Class SuperListItem
        Implements System.IDisposable

        Public Class Data
            Implements System.IComparable

            <System.Runtime.CompilerServices.CompilerGenerated> _
            Private <Releases>k__BackingField As String() 
            <System.Runtime.CompilerServices.CompilerGenerated> _
            Private <Subtitle>k__BackingField As Sublight.WS.Subtitle 
            <System.Runtime.CompilerServices.CompilerGenerated> _
            Private <SubtitleProvider>k__BackingField As Sublight.Plugins.SubtitleProvider.ISubtitleProvider 

            Public Property Releases As String()
                Get
                    Return <Releases>k__BackingField
                End Get
                Set
                    <Releases>k__BackingField = value
                End Set
            End Property

            Public Property Subtitle As Sublight.WS.Subtitle
                Get
                    Return <Subtitle>k__BackingField
                End Get
                Set
                    <Subtitle>k__BackingField = value
                End Set
            End Property

            Public Property SubtitleProvider As Sublight.Plugins.SubtitleProvider.ISubtitleProvider
                Get
                    Return <SubtitleProvider>k__BackingField
                End Get
                Set
                    <SubtitleProvider>k__BackingField = value
                End Set
            End Property

            Public Sub New(ByVal subtitle As Sublight.WS.Subtitle, ByVal releases As String(), ByVal subtitleProvider As Sublight.Plugins.SubtitleProvider.ISubtitleProvider)
                Subtitle = subtitle
                Releases = releases
                SubtitleProvider = subtitleProvider
            End Sub

            Public Function CompareTo(ByVal obj As Object) As Integer
                Return 0
            End Function

        End Class ' class Data

        Private Class MyRowSection
            Inherits BinaryComponents.SuperList.Sections.RowSection

            Private Const _separatorLineHeight As Integer  = 1
            Private Const m_ReleaseBottomPadding As Integer  = 5
            Private Const m_ReleaseTopPadding As Integer  = 5

            Private _seperatorColor As System.Drawing.Color 

            Private Shared _statusBrushAuthorized As System.Drawing.Brush 
            Private Shared _statusBrushDeleted As System.Drawing.Brush 
            Private Shared _statusBrushExternal As System.Drawing.Brush 
            Private Shared _statusBrushPAuthorized As System.Drawing.Brush 
            Private Shared m_ReleaseLineHighlightText As System.Drawing.Pen 
            Private Shared m_ReleaseLineText As System.Drawing.Pen 
            Private Shared m_SeparatorLine As System.Drawing.Pen 

            Public Sub New(ByVal listControl As BinaryComponents.SuperList.ListControl, ByVal rowIdentifier As BinaryComponents.SuperList.RowIdentifier, ByVal headerSection As BinaryComponents.SuperList.Sections.HeaderSection, ByVal position As Integer)
                _seperatorColor = System.Drawing.Color.FromArgb(123, 164, 224)
                If (Sublight.Controls.SuperListItem.MyRowSection.m_ReleaseLineText) Is Nothing Then
                    Sublight.Controls.SuperListItem.MyRowSection.m_ReleaseLineText = New System.Drawing.Pen(System.Drawing.SystemColors.MenuText)
                    Dim fArr1 As Single() = New float() { 1.0F, 1.0F }
                    Sublight.Controls.SuperListItem.MyRowSection.m_ReleaseLineText.DashPattern = fArr1
                End If
                If (Sublight.Controls.SuperListItem.MyRowSection.m_ReleaseLineHighlightText) Is Nothing Then
                    Sublight.Controls.SuperListItem.MyRowSection.m_ReleaseLineHighlightText = New System.Drawing.Pen(System.Drawing.SystemColors.HighlightText)
                    Dim fArr2 As Single() = New float() { 1.0F, 1.0F }
                    Sublight.Controls.SuperListItem.MyRowSection.m_ReleaseLineHighlightText.DashPattern = fArr2
                End If
                If (Sublight.Controls.SuperListItem.MyRowSection._statusBrushExternal) Is Nothing Then
                    Sublight.Controls.SuperListItem.MyRowSection._statusBrushExternal = New System.Drawing.SolidBrush(Sublight.Controls.SuperListItem._statusSecondaryDb)
                End If
                If (Sublight.Controls.SuperListItem.MyRowSection._statusBrushDeleted) Is Nothing Then
                    Sublight.Controls.SuperListItem.MyRowSection._statusBrushDeleted = New System.Drawing.SolidBrush(System.Drawing.Color.Red)
                End If
                If (Sublight.Controls.SuperListItem.MyRowSection._statusBrushAuthorized) Is Nothing Then
                    Sublight.Controls.SuperListItem.MyRowSection._statusBrushAuthorized = New System.Drawing.SolidBrush(Sublight.Controls.SuperListItem._statusAuthorised)
                End If
                If (Sublight.Controls.SuperListItem.MyRowSection._statusBrushPAuthorized) Is Nothing Then
                    Sublight.Controls.SuperListItem.MyRowSection._statusBrushPAuthorized = New System.Drawing.SolidBrush(Sublight.Controls.SuperListItem._statusPartiallyAuthorised)
                End If
            End Sub

            Private Function MeasureInitialItemHeight(ByVal gs As BinaryComponents.SuperList.Sections.Section.GraphicsSettings) As Single
                Dim sizeF1 As System.Drawing.SizeF = gs.Graphics.MeasureString("ABC?", ListControl.Font)
                Dim f1 As Single = sizeF1.Height
                Return f1 + 4.0F
            End Function

            Public Overrides Sub Layout(ByVal gs As BinaryComponents.SuperList.Sections.Section.GraphicsSettings, ByVal maximumSize As System.Drawing.Size)
                Dim f1 As Single

                Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(MyBase(), Sublight.Controls.SuperListItem.Data)
                If (Not (data1) Is Nothing) AndAlso (Not (data1.Releases) Is Nothing) AndAlso (data1.Releases.Length > 0) Then
                    f1 = MeasureInitialItemHeight(gs)
                    f1 = f1 + 10.0F
                    Dim i1 As Integer = 0
                    While i1 < data1.Releases.Length
                        Dim sizeF1 As System.Drawing.SizeF = gs.Graphics.MeasureString(data1.Releases(i1), ListControl.Font)
                        f1 = f1 + sizeF1.Height
                        i1 = i1 + 1
                    End While
                Else 
                    f1 = MeasureInitialItemHeight(gs)
                    f1 = f1 + 5.0F
                End If
                MinimumHeight = System.Convert.ToInt32(System.Math.Ceiling(CDbl(f1)))
                MyBase.Layout(gs, maximumSize)
            End Sub

            Public Overrides Sub Paint(ByVal gs As BinaryComponents.SuperList.Sections.Section.GraphicsSettings, ByVal clipRect As System.Drawing.Rectangle)
                Dim brush1 As System.Drawing.Brush, brush2 As System.Drawing.Brush
                Dim pen1 As System.Drawing.Pen

                MyBase.Paint(gs, clipRect)
                If (Host.FocusedSection = ListSection) AndAlso IsSelected Then
                    brush1 = System.Drawing.SystemBrushes.HighlightText
                    pen1 = Sublight.Controls.SuperListItem.MyRowSection.m_ReleaseLineHighlightText
                Else 
                    brush1 = System.Drawing.SystemBrushes.MenuText
                    pen1 = Sublight.Controls.SuperListItem.MyRowSection.m_ReleaseLineText
                End If
                Dim flag1 As Boolean = True
                If (Not (pen1.DashPattern) Is Nothing) AndAlso (pen1.DashPattern.Length = 2) AndAlso (pen1.DashPattern(0) = 1.0F) AndAlso (pen1.DashPattern(1) = 1.0F) Then
                    flag1 = False
                End If
                If flag1 Then
                    Dim fArr1 As Single() = New float() { 1.0F, 1.0F }
                    pen1.DashPattern = fArr1
                End If
                Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(MyBase(), Sublight.Controls.SuperListItem.Data)
                If (Not (data1) Is Nothing) AndAlso (Not (data1.Releases) Is Nothing) AndAlso (data1.Releases.Length > 0) Then
                    Dim f1 As Single = MeasureInitialItemHeight(gs)
                    f1 = f1 + 5.0F
                    Dim i1 As Integer = 0
                    While i1 < data1.Releases.Length
                        Dim sizeF1 As System.Drawing.SizeF = gs.Graphics.MeasureString(data1.Releases(i1), ListControl.Font)
                        Dim f2 As Single = sizeF1.Height
                        Dim rectangle1 As System.Drawing.Rectangle = HostBasedRectangle
                        Dim rectangle2 As System.Drawing.Rectangle = Rectangle
                        Dim rectangle3 As System.Drawing.Rectangle = Rectangle
                        gs.Graphics.DrawString(data1.Releases(i1), ListControl.Font, brush1, CSng((rectangle1.Left + rectangle2.X + 33)), CSng(rectangle3.Y) + f1)
                        Dim rectangle4 As System.Drawing.Rectangle = HostBasedRectangle
                        Dim rectangle5 As System.Drawing.Rectangle = Rectangle
                        Dim rectangle6 As System.Drawing.Rectangle = Rectangle
                        gs.Graphics.FillRectangle(brush1, CSng((rectangle4.Left + rectangle5.X + 23)), CSng(rectangle6.Y) + f1 + (f2 / 3.0F), 5.0F, 5.0F)
                        If i1 = 0 Then
                            Dim rectangle7 As System.Drawing.Rectangle = HostBasedRectangle
                            Dim rectangle8 As System.Drawing.Rectangle = Rectangle
                            Dim f3 As Single = CSng((rectangle7.Left + rectangle8.X + 16))
                            Dim rectangle9 As System.Drawing.Rectangle = Rectangle
                            Dim f4 As Single = CSng(rectangle9.Y) + f1 + (f2 / 3.0F) + 2.5F
                            Dim rectangle10 As System.Drawing.Rectangle = Rectangle
                            gs.Graphics.DrawLine(pen1, f3, CSng(rectangle10.Y) + f1 - 5.0F, f3, f4)
                            gs.Graphics.DrawLine(pen1, f3, f4, f3 + 5.0F, f4)
                        End If
                        If i1 < (data1.Releases.Length - 1) Then
                            Dim rectangle11 As System.Drawing.Rectangle = HostBasedRectangle
                            Dim rectangle12 As System.Drawing.Rectangle = Rectangle
                            Dim f5 As Single = CSng((rectangle11.Left + rectangle12.X + 23)) + 2.5F
                            Dim rectangle13 As System.Drawing.Rectangle = Rectangle
                            Dim f6 As Single = CSng(rectangle13.Y) + f1 + (f2 / 3.0F) + 2.5F
                            gs.Graphics.DrawLine(pen1, f5, f6, f5, f6 + f2)
                        End If
                        f1 = f1 + f2
                        i1 = i1 + 1
                    End While
                End If
                If (Not (ListControl) Is Nothing) AndAlso (Not (data1) Is Nothing) AndAlso (Not (data1.Subtitle) Is Nothing) AndAlso System.String.IsNullOrEmpty(data1.Subtitle.ExternalId) Then
                    Dim rectangle14 As System.Drawing.Rectangle = HostBasedRectangle
                    Dim rectangle15 As System.Drawing.Rectangle = Rectangle
                    Dim i2 As Integer = rectangle14.Left + rectangle15.X
                    Using ienumerator1 As System.Collections.Generic.IEnumerator(Of BinaryComponents.SuperList.Column) = ListControl.Columns.GetEnumerator()
                        While ienumerator1.MoveNext()
                            Dim column1 As BinaryComponents.SuperList.Column = ienumerator1.get_Current()
                            If column1.Name <> "Publisher?" Then
                                i2 = i2 + column1.Width
                            End If
                        End While
                    End Using
                    i2 = i2 + 2
                    Dim rectangle16 As System.Drawing.Rectangle = Rectangle
                    Dim f7 As Single = CSng(rectangle16.Y) + MeasureInitialItemHeight(gs)
                    f7 = f7 + 5.0F
                    If (Host.FocusedSection = ListSection) AndAlso IsSelected Then
                        brush2 = System.Drawing.SystemBrushes.HighlightText
                    Else 
                        brush2 = System.Drawing.Brushes.Gray
                    End If
                    gs.Graphics.DrawString(System.String.Format(Sublight.Translation.Common_SearchResults_UserSubtitleCount, data1.Subtitle.SubCount), ListControl.Font, brush2, CSng(i2), f7)
                    If data1.Subtitle.Votes > 0 Then
                        Dim rectangle17 As System.Drawing.Rectangle = HostBasedRectangle
                        Dim rectangle18 As System.Drawing.Rectangle = Rectangle
                        i2 = rectangle17.Left + rectangle18.X
                        Using ienumerator2 As System.Collections.Generic.IEnumerator(Of BinaryComponents.SuperList.Column) = ListControl.Columns.GetEnumerator()
                            While ienumerator2.MoveNext()
                                Dim column2 As BinaryComponents.SuperList.Column = ienumerator2.get_Current()
                                If column2.Name <> "Votes?" Then
                                    i2 = i2 + column2.Width
                                End If
                            End While
                        End Using
                        i2 = i2 + 2
                        gs.Graphics.DrawString(System.String.Format(Sublight.Translation.Common_SearchResults_SubtitleAverageRate, data1.Subtitle.Rate, 5), ListControl.Font, brush2, CSng(i2), f7)
                    End If
                End If
                If (Not (data1) Is Nothing) AndAlso (Not (data1.Subtitle) Is Nothing) Then
                    Dim flag2 As Boolean = True
                    Dim brush3 As System.Drawing.Brush = Nothing
                    If Not (data1.SubtitleProvider) Is Nothing Then
                        brush3 = Sublight.Controls.SuperListItem.MyRowSection._statusBrushExternal
                    ElseIf data1.Subtitle.Status = System.Convert.ToByte(32) Then
                        brush3 = Sublight.Controls.SuperListItem.MyRowSection._statusBrushAuthorized
                    ElseIf (data1.Subtitle.Status = System.Convert.ToByte(0)) OrElse (data1.Subtitle.Status = System.Convert.ToByte(1)) Then
                        brush3 = Sublight.Controls.SuperListItem.MyRowSection._statusBrushPAuthorized
                    ElseIf data1.Subtitle.Status = System.Convert.ToByte(128) Then
                        brush3 = Sublight.Controls.SuperListItem.MyRowSection._statusBrushDeleted
                    Else 
                        flag2 = False
                    End If
                    Dim rectangle19 As System.Drawing.Rectangle = HostBasedRectangle
                    Dim rectangle20 As System.Drawing.Rectangle = Rectangle
                    Dim f8 As Single = CSng((rectangle19.Left + rectangle20.X))
                    If flag2 Then
                        If Not (brush3) Is Nothing Then
                            Dim rectangle21 As System.Drawing.Rectangle = Rectangle
                            Dim rectangle22 As System.Drawing.Rectangle = Rectangle
                            gs.Graphics.FillRectangle(brush3, f8 + 1.0F, CSng((rectangle21.Y + 1)), f8 + 6.0F, CSng((rectangle22.Height - 3)))
                        End If
                        If data1.Subtitle.Status = System.Convert.ToByte(1) Then
                            Dim rectangle23 As System.Drawing.Rectangle = Rectangle
                            Dim rectangle24 As System.Drawing.Rectangle = Rectangle
                            gs.Graphics.FillRectangle(System.Drawing.Brushes.Red, f8 + 2.0F, CSng((rectangle23.Y + rectangle24.Height - 7)), f8 + 4.0F, 4.0F)
                        End If
                    End If
                    Dim rectangle25 As System.Drawing.Rectangle = Rectangle
                    Dim rectangle26 As System.Drawing.Rectangle = Rectangle
                    gs.Graphics.FillRectangle(System.Drawing.Brushes.White, f8 + 7.0F, CSng((rectangle25.Y + 1)), f8 + 1.0F, CSng((rectangle26.Height - 3)))
                End If
            End Sub

            Public Overrides Sub PaintBackground(ByVal gs As BinaryComponents.SuperList.Sections.Section.GraphicsSettings, ByVal clipRect As System.Drawing.Rectangle)
                MyBase.PaintBackground(gs, clipRect)
                If Not IsSelected Then
                    Dim data1 As Sublight.Controls.SuperListItem.Data = TryCast(MyBase(), Sublight.Controls.SuperListItem.Data)
                    If (Not (data1) Is Nothing) AndAlso (Not (data1.Subtitle) Is Nothing) AndAlso data1.Subtitle.IsLinked Then
                        gs.Graphics.FillRectangle(Sublight.Globals.BrushSubtitleLinkedBg, Rectangle)
                    End If
                End If
            End Sub

            Protected Overrides Sub PaintSeparatorLine(ByVal g As System.Drawing.Graphics, ByVal rc As System.Drawing.Rectangle)
                If (Sublight.Controls.SuperListItem.MyRowSection.m_SeparatorLine) Is Nothing Then
                    Sublight.Controls.SuperListItem.MyRowSection.m_SeparatorLine = New System.Drawing.Pen(System.Drawing.Color.FromArgb(70, _seperatorColor.R, _seperatorColor.G, _seperatorColor.B), 1.0F)
                End If
                g.DrawLine(Sublight.Controls.SuperListItem.MyRowSection.m_SeparatorLine, New System.Drawing.Point(rc.Left, rc.Bottom - 1), New System.Drawing.Point(rc.Right, rc.Bottom - 1))
            End Sub

        End Class ' class MyRowSection

        Friend Class MySectionFactory
            Inherits BinaryComponents.SuperList.Sections.SectionFactory

            Public Sub New()
            End Sub

            Public Overrides Function CreateRowSection(ByVal listControl As BinaryComponents.SuperList.ListControl, ByVal rowIdenifier As BinaryComponents.SuperList.RowIdentifier, ByVal headerSection As BinaryComponents.SuperList.Sections.HeaderSection, ByVal position As Integer) As BinaryComponents.SuperList.Sections.RowSection
                Return New Sublight.Controls.SuperListItem.MyRowSection(listControl, rowIdenifier, headerSection, position)
            End Function

        End Class ' class MySectionFactory

        Private ReadOnly _listControl As BinaryComponents.SuperList.ListControl 
        Private ReadOnly _oldFactory As BinaryComponents.SuperList.Sections.SectionFactory 
        Private Shared ReadOnly _statusAuthorised As System.Drawing.Color 
        Private Shared ReadOnly _statusPartiallyAuthorised As System.Drawing.Color 
        Private Shared ReadOnly _statusSecondaryDb As System.Drawing.Color 

        Public Sub New(ByVal listControl As BinaryComponents.SuperList.ListControl)
            _oldFactory = listControl.SectionFactory
            _listControl = listControl
            listControl.SectionFactory = New Sublight.Controls.SuperListItem.MySectionFactory
            _listControl.LayoutSections()
        End Sub

        Shared Sub New()
            Sublight.Controls.SuperListItem._statusSecondaryDb = System.Drawing.ColorTranslator.FromHtml("#B0CBEF?")
            Sublight.Controls.SuperListItem._statusAuthorised = System.Drawing.ColorTranslator.FromHtml("#28D117?")
            Sublight.Controls.SuperListItem._statusPartiallyAuthorised = System.Drawing.ColorTranslator.FromHtml("#F3E417?")
        End Sub

        Public Sub Dispose()
            If Not (_oldFactory) Is Nothing Then
                _listControl.SectionFactory = _oldFactory
                _listControl.LayoutSections()
            End If
        End Sub

    End Class ' class SuperListItem

End Namespace

