Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Sublight.Controls.Office2007Renderer

    Public Class Office2007Renderer
        Inherits System.Windows.Forms.ToolStripProfessionalRenderer

        Private Class GradientItemColors

            Public Border1 As System.Drawing.Color 
            Public Border2 As System.Drawing.Color 
            Public FillBottom1 As System.Drawing.Color 
            Public FillBottom2 As System.Drawing.Color 
            Public FillTop1 As System.Drawing.Color 
            Public FillTop2 As System.Drawing.Color 
            Public InsideBottom1 As System.Drawing.Color 
            Public InsideBottom2 As System.Drawing.Color 
            Public InsideTop1 As System.Drawing.Color 
            Public InsideTop2 As System.Drawing.Color 

            Public Sub New(ByVal insideTop1 As System.Drawing.Color, ByVal insideTop2 As System.Drawing.Color, ByVal insideBottom1 As System.Drawing.Color, ByVal insideBottom2 As System.Drawing.Color, ByVal fillTop1 As System.Drawing.Color, ByVal fillTop2 As System.Drawing.Color, ByVal fillBottom1 As System.Drawing.Color, ByVal fillBottom2 As System.Drawing.Color, ByVal border1 As System.Drawing.Color, ByVal border2 As System.Drawing.Color)
                InsideTop1 = insideTop1
                InsideTop2 = insideTop2
                InsideBottom1 = insideBottom1
                InsideBottom2 = insideBottom2
                FillTop1 = fillTop1
                FillTop2 = fillTop2
                FillBottom1 = fillBottom1
                FillBottom2 = fillBottom2
                Border1 = border1
                Border2 = border2
            End Sub

        End Class ' class GradientItemColors

        Private Shared _arrowDark As System.Drawing.Color 
        Private Shared _arrowDisabled As System.Drawing.Color 
        Private Shared _arrowLight As System.Drawing.Color 
        Private Shared _c1 As System.Drawing.Color 
        Private Shared _c2 As System.Drawing.Color 
        Private Shared _c4 As System.Drawing.Color 
        Private Shared _c5 As System.Drawing.Color 
        Private Shared _c6 As System.Drawing.Color 
        Private Shared _checkInset As Integer 
        Private Shared _contextCheckBorder As System.Drawing.Color 
        Private Shared _contextCheckTick As System.Drawing.Color 
        Private Shared _contextCheckTickThickness As Single 
        Private Shared _contextMenuBack As System.Drawing.Color 
        Private Shared _cutContextMenu As Single 
        Private Shared _cutMenuItemBack As Single 
        Private Shared _cutToolItemMenu As Single 
        Private Shared _itemContextItemEnabledColors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors 
        Private Shared _itemDisabledColors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors 
        Private Shared _itemToolItemCheckedColors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors 
        Private Shared _itemToolItemCheckPressColors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors 
        Private Shared _itemToolItemPressedColors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors 
        Private Shared _itemToolItemSelectedColors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors 
        Private Shared _marginInset As Integer 
        Private Shared _r1 As System.Drawing.Color 
        Private Shared _r2 As System.Drawing.Color 
        Private Shared _r3 As System.Drawing.Color 
        Private Shared _r4 As System.Drawing.Color 
        Private Shared _r5 As System.Drawing.Color 
        Private Shared _r6 As System.Drawing.Color 
        Private Shared _r7 As System.Drawing.Color 
        Private Shared _r8 As System.Drawing.Color 
        Private Shared _r9 As System.Drawing.Color 
        Private Shared _rA As System.Drawing.Color 
        Private Shared _rD As System.Drawing.Color 
        Private Shared _rE As System.Drawing.Color 
        Private Shared _rF As System.Drawing.Color 
        Private Shared _rG As System.Drawing.Color 
        Private Shared _rH As System.Drawing.Color 
        Private Shared _rI As System.Drawing.Color 
        Private Shared _rJ As System.Drawing.Color 
        Private Shared _rK As System.Drawing.Color 
        Private Shared _rL As System.Drawing.Color 
        Private Shared _rM As System.Drawing.Color 
        Private Shared _rN As System.Drawing.Color 
        Private Shared _rO As System.Drawing.Color 
        Private Shared _rP As System.Drawing.Color 
        Private Shared _rQ As System.Drawing.Color 
        Private Shared _rR As System.Drawing.Color 
        Private Shared _rS As System.Drawing.Color 
        Private Shared _rT As System.Drawing.Color 
        Private Shared _rU As System.Drawing.Color 
        Private Shared _rV As System.Drawing.Color 
        Private Shared _rW As System.Drawing.Color 
        Private Shared _rX As System.Drawing.Color 
        Private Shared _rY As System.Drawing.Color 
        Private Shared _rZ As System.Drawing.Color 
        Private Shared _separatorInset As Integer 
        Private Shared _separatorMenuDark As System.Drawing.Color 
        Private Shared _separatorMenuLight As System.Drawing.Color 
        Private Shared _statusStripBlend As System.Drawing.Drawing2D.Blend 
        Private Shared _textContextMenuItem As System.Drawing.Color 
        Private Shared _textDisabled As System.Drawing.Color 
        Private Shared _textMenuStripItem As System.Drawing.Color 
        Private Shared _textStatusStripItem As System.Drawing.Color 

        Shared Sub New()
            Sublight.Controls.Office2007Renderer.Office2007Renderer._checkInset = 1
            Sublight.Controls.Office2007Renderer.Office2007Renderer._marginInset = 2
            Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorInset = 31
            Sublight.Controls.Office2007Renderer.Office2007Renderer._cutToolItemMenu = 1.0F
            Sublight.Controls.Office2007Renderer.Office2007Renderer._cutMenuItemBack = 1.2F
            Sublight.Controls.Office2007Renderer.Office2007Renderer._contextCheckTickThickness = 1.6F
            Sublight.Controls.Office2007Renderer.Office2007Renderer._c1 = System.Drawing.Color.FromArgb(167, 167, 167)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._c2 = System.Drawing.Color.FromArgb(21, 66, 139)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._c4 = System.Drawing.Color.FromArgb(250, 250, 250)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._c5 = System.Drawing.Color.FromArgb(248, 248, 248)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._c6 = System.Drawing.Color.FromArgb(243, 243, 243)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r1 = System.Drawing.Color.FromArgb(255, 255, 251)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r2 = System.Drawing.Color.FromArgb(255, 249, 227)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r3 = System.Drawing.Color.FromArgb(255, 242, 201)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r4 = System.Drawing.Color.FromArgb(255, 248, 181)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r5 = System.Drawing.Color.FromArgb(255, 252, 229)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r6 = System.Drawing.Color.FromArgb(255, 235, 166)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r7 = System.Drawing.Color.FromArgb(255, 213, 103)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r8 = System.Drawing.Color.FromArgb(255, 228, 145)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._r9 = System.Drawing.Color.FromArgb(160, 188, 228)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rA = System.Drawing.Color.FromArgb(121, 153, 194)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rD = System.Drawing.Color.FromArgb(233, 168, 97)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rE = System.Drawing.Color.FromArgb(247, 164, 39)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rF = System.Drawing.Color.FromArgb(246, 156, 24)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rG = System.Drawing.Color.FromArgb(253, 173, 17)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rH = System.Drawing.Color.FromArgb(254, 185, 108)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rI = System.Drawing.Color.FromArgb(253, 164, 97)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rJ = System.Drawing.Color.FromArgb(252, 143, 61)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rK = System.Drawing.Color.FromArgb(255, 208, 134)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rL = System.Drawing.Color.FromArgb(249, 192, 103)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rM = System.Drawing.Color.FromArgb(250, 195, 93)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rN = System.Drawing.Color.FromArgb(248, 190, 81)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rO = System.Drawing.Color.FromArgb(255, 208, 49)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rP = System.Drawing.Color.FromArgb(254, 214, 168)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rQ = System.Drawing.Color.FromArgb(252, 180, 100)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rR = System.Drawing.Color.FromArgb(252, 161, 54)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rS = System.Drawing.Color.FromArgb(254, 238, 170)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rT = System.Drawing.Color.FromArgb(249, 202, 113)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rU = System.Drawing.Color.FromArgb(250, 205, 103)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rV = System.Drawing.Color.FromArgb(248, 200, 91)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rW = System.Drawing.Color.FromArgb(255, 218, 59)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rX = System.Drawing.Color.FromArgb(254, 185, 108)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rY = System.Drawing.Color.FromArgb(252, 161, 54)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._rZ = System.Drawing.Color.FromArgb(254, 238, 170)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._textDisabled = Sublight.Controls.Office2007Renderer.Office2007Renderer._c1
            Sublight.Controls.Office2007Renderer.Office2007Renderer._textMenuStripItem = Sublight.Controls.Office2007Renderer.Office2007Renderer._c2
            Sublight.Controls.Office2007Renderer.Office2007Renderer._textStatusStripItem = Sublight.Controls.Office2007Renderer.Office2007Renderer._c2
            Sublight.Controls.Office2007Renderer.Office2007Renderer._textContextMenuItem = Sublight.Controls.Office2007Renderer.Office2007Renderer._c2
            Sublight.Controls.Office2007Renderer.Office2007Renderer._arrowDisabled = Sublight.Controls.Office2007Renderer.Office2007Renderer._c1
            Sublight.Controls.Office2007Renderer.Office2007Renderer._arrowLight = System.Drawing.Color.FromArgb(106, 126, 197)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._arrowDark = System.Drawing.Color.FromArgb(64, 70, 90)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorMenuLight = System.Drawing.Color.FromArgb(245, 245, 245)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorMenuDark = System.Drawing.Color.FromArgb(197, 197, 197)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._contextMenuBack = Sublight.Controls.Office2007Renderer.Office2007Renderer._c4
            Sublight.Controls.Office2007Renderer.Office2007Renderer._contextCheckBorder = System.Drawing.Color.FromArgb(242, 149, 54)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._contextCheckTick = System.Drawing.Color.FromArgb(66, 75, 138)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._itemContextItemEnabledColors = New Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors(Sublight.Controls.Office2007Renderer.Office2007Renderer._r1, Sublight.Controls.Office2007Renderer.Office2007Renderer._r2, Sublight.Controls.Office2007Renderer.Office2007Renderer._r3, Sublight.Controls.Office2007Renderer.Office2007Renderer._r4, Sublight.Controls.Office2007Renderer.Office2007Renderer._r5, Sublight.Controls.Office2007Renderer.Office2007Renderer._r6, Sublight.Controls.Office2007Renderer.Office2007Renderer._r7, Sublight.Controls.Office2007Renderer.Office2007Renderer._r8, System.Drawing.Color.FromArgb(217, 203, 150), System.Drawing.Color.FromArgb(192, 167, 118))
            Sublight.Controls.Office2007Renderer.Office2007Renderer._itemDisabledColors = New Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors(Sublight.Controls.Office2007Renderer.Office2007Renderer._c4, Sublight.Controls.Office2007Renderer.Office2007Renderer._c6, System.Drawing.Color.FromArgb(236, 236, 236), System.Drawing.Color.FromArgb(230, 230, 230), Sublight.Controls.Office2007Renderer.Office2007Renderer._c6, System.Drawing.Color.FromArgb(224, 224, 224), System.Drawing.Color.FromArgb(200, 200, 200), System.Drawing.Color.FromArgb(210, 210, 210), System.Drawing.Color.FromArgb(212, 212, 212), System.Drawing.Color.FromArgb(195, 195, 195))
            Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemSelectedColors = New Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors(Sublight.Controls.Office2007Renderer.Office2007Renderer._r1, Sublight.Controls.Office2007Renderer.Office2007Renderer._r2, Sublight.Controls.Office2007Renderer.Office2007Renderer._r3, Sublight.Controls.Office2007Renderer.Office2007Renderer._r4, Sublight.Controls.Office2007Renderer.Office2007Renderer._r5, Sublight.Controls.Office2007Renderer.Office2007Renderer._r6, Sublight.Controls.Office2007Renderer.Office2007Renderer._r7, Sublight.Controls.Office2007Renderer.Office2007Renderer._r8, Sublight.Controls.Office2007Renderer.Office2007Renderer._r9, Sublight.Controls.Office2007Renderer.Office2007Renderer._rA)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemPressedColors = New Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors(Sublight.Controls.Office2007Renderer.Office2007Renderer._rD, Sublight.Controls.Office2007Renderer.Office2007Renderer._rE, Sublight.Controls.Office2007Renderer.Office2007Renderer._rF, Sublight.Controls.Office2007Renderer.Office2007Renderer._rG, Sublight.Controls.Office2007Renderer.Office2007Renderer._rH, Sublight.Controls.Office2007Renderer.Office2007Renderer._rI, Sublight.Controls.Office2007Renderer.Office2007Renderer._rJ, Sublight.Controls.Office2007Renderer.Office2007Renderer._rK, Sublight.Controls.Office2007Renderer.Office2007Renderer._r9, Sublight.Controls.Office2007Renderer.Office2007Renderer._rA)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemCheckedColors = New Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors(Sublight.Controls.Office2007Renderer.Office2007Renderer._rL, Sublight.Controls.Office2007Renderer.Office2007Renderer._rM, Sublight.Controls.Office2007Renderer.Office2007Renderer._rN, Sublight.Controls.Office2007Renderer.Office2007Renderer._rO, Sublight.Controls.Office2007Renderer.Office2007Renderer._rP, Sublight.Controls.Office2007Renderer.Office2007Renderer._rQ, Sublight.Controls.Office2007Renderer.Office2007Renderer._rR, Sublight.Controls.Office2007Renderer.Office2007Renderer._rS, Sublight.Controls.Office2007Renderer.Office2007Renderer._r9, Sublight.Controls.Office2007Renderer.Office2007Renderer._rA)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemCheckPressColors = New Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors(Sublight.Controls.Office2007Renderer.Office2007Renderer._rT, Sublight.Controls.Office2007Renderer.Office2007Renderer._rU, Sublight.Controls.Office2007Renderer.Office2007Renderer._rV, Sublight.Controls.Office2007Renderer.Office2007Renderer._rW, Sublight.Controls.Office2007Renderer.Office2007Renderer._rX, Sublight.Controls.Office2007Renderer.Office2007Renderer._rI, Sublight.Controls.Office2007Renderer.Office2007Renderer._rY, Sublight.Controls.Office2007Renderer.Office2007Renderer._rZ, Sublight.Controls.Office2007Renderer.Office2007Renderer._r9, Sublight.Controls.Office2007Renderer.Office2007Renderer._rA)
            Sublight.Controls.Office2007Renderer.Office2007Renderer._statusStripBlend = New System.Drawing.Drawing2D.Blend
            Sublight.Controls.Office2007Renderer.Office2007Renderer._statusStripBlend.Positions = New float() { 0.0F, 0.25F, 0.25F, 0.57F, 0.86F, 1.0F }
            Sublight.Controls.Office2007Renderer.Office2007Renderer._statusStripBlend.Factors = New float() { 0.1F, 0.6F, 1.0F, 0.4F, 0.0F, 0.95F }
        End Sub

        Public Sub New()
        End Sub

        Private Sub DrawContextMenuHeader(ByVal g As System.Drawing.Graphics, ByVal item As System.Windows.Forms.ToolStripItem)
            Dim rectangle2 As System.Drawing.Rectangle = item.Bounds
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(System.Drawing.Point.Empty, rectangle2.Size)
            Using graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(rectangle1, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutToolItemMenu)
                Using graphicsPath2 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateInsideBorderPath(rectangle1, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutToolItemMenu)
                    Using graphicsPath3 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateClipBorderPath(rectangle1, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutToolItemMenu)
                        Using useClipping1 As Sublight.Controls.Office2007Renderer.UseClipping = New Sublight.Controls.Office2007Renderer.UseClipping(g, graphicsPath3)
                            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorMenuLight)
                                g.FillPath(solidBrush1, graphicsPath1)
                            End Using
                            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(ColorTable.MenuBorder)
                                g.DrawPath(pen1, graphicsPath1)
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Sub RenderToolDropButtonBackground(ByVal g As System.Drawing.Graphics, ByVal item As System.Windows.Forms.ToolStripItem, ByVal toolstrip As System.Windows.Forms.ToolStrip)
            If item.Selected OrElse item.Pressed Then
                If item.Enabled Then
                    If item.Pressed Then
                        DrawContextMenuHeader(g, item)
                        Return
                    End If
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, item, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemSelectedColors)
                    Return
                End If
                Dim point1 As System.Drawing.Point = toolstrip.PointToClient(System.Windows.Forms.Control.MousePosition)
                Dim rectangle1 As System.Drawing.Rectangle = item.Bounds
                If Not rectangle1.Contains(point1) Then
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, item, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemDisabledColors)
                End If
            End If
        End Sub

        Private Sub RenderToolSplitButtonBackground(ByVal g As System.Drawing.Graphics, ByVal splitButton As System.Windows.Forms.ToolStripSplitButton, ByVal toolstrip As System.Windows.Forms.ToolStrip)
            If splitButton.Selected OrElse splitButton.Pressed Then
                If splitButton.Enabled Then
                    If Not splitButton.Pressed AndAlso splitButton.ButtonPressed Then
                        Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolSplitItem(g, splitButton, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemPressedColors, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemSelectedColors, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemContextItemEnabledColors)
                        Return
                    End If
                    If splitButton.Pressed AndAlso Not splitButton.ButtonPressed Then
                        DrawContextMenuHeader(g, splitButton)
                        Return
                    End If
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolSplitItem(g, splitButton, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemSelectedColors, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemSelectedColors, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemContextItemEnabledColors)
                    Return
                End If
                Dim point1 As System.Drawing.Point = toolstrip.PointToClient(System.Windows.Forms.Control.MousePosition)
                Dim rectangle1 As System.Drawing.Rectangle = splitButton.Bounds
                If Not rectangle1.Contains(point1) Then
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, splitButton, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemDisabledColors)
                End If
            End If
        End Sub

        Protected Overrides Sub OnRenderArrow(ByVal e As System.Windows.Forms.ToolStripArrowRenderEventArgs)
            Dim rectangle1 As System.Drawing.Rectangle = e.ArrowRectangle
            If rectangle1.Width > 0 Then
                Dim rectangle2 As System.Drawing.Rectangle = e.ArrowRectangle
                If rectangle2.Height > 0 Then
                    Using graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateArrowPath(e(), e.ArrowRectangle, e.Direction)
                        Dim rectangleF1 As System.Drawing.RectangleF = graphicsPath1.GetBounds()
                        rectangleF1.Inflate(1.0F, 1.0F)
                        Dim color1 As System.Drawing.Color = IIf(e().Enabled, Sublight.Controls.Office2007Renderer.Office2007Renderer._arrowLight, Sublight.Controls.Office2007Renderer.Office2007Renderer._arrowDisabled)
                        Dim color2 As System.Drawing.Color = IIf(e().Enabled, Sublight.Controls.Office2007Renderer.Office2007Renderer._arrowDark, Sublight.Controls.Office2007Renderer.Office2007Renderer._arrowDisabled)
                        Dim f1 As Single = 0.0F
                        Dim arrowDirection1 As System.Windows.Forms.ArrowDirection = e.Direction
                        Select Case arrowDirection1
                            Case System.Windows.Forms.ArrowDirection.Right
                                f1 = 0.0F

                            Case System.Windows.Forms.ArrowDirection.Left
                                f1 = 180.0F

                            Case System.Windows.Forms.ArrowDirection.Down
                                f1 = 90.0F

                            Case System.Windows.Forms.ArrowDirection.Up
                                f1 = 270.0F
                        End Select
                        Using linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangleF1, color1, color2, f1)
                            e.Graphics.FillPath(linearGradientBrush1, graphicsPath1)
                        End Using
                    End Using
                End If
            End If
        End Sub

        Protected Overrides Sub OnRenderButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            Dim toolStripButton1 As System.Windows.Forms.ToolStripButton = CType(e(), System.Windows.Forms.ToolStripButton)
            If toolStripButton1.Selected OrElse toolStripButton1.Pressed OrElse toolStripButton1.Checked Then
                Sublight.Controls.Office2007Renderer.Office2007Renderer.RenderToolButtonBackground(e.Graphics, toolStripButton1, e.ToolStrip)
            End If
        End Sub

        Protected Overrides Sub OnRenderDropDownButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            If e().Selected OrElse e().Pressed Then
                RenderToolDropButtonBackground(e.Graphics, e(), e.ToolStrip)
            End If
        End Sub

        Protected Overrides Sub OnRenderImageMargin(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            If (TypeOf e.ToolStrip Is System.Windows.Forms.ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is System.Windows.Forms.ToolStripDropDownMenu) Then
                Dim rectangle1 As System.Drawing.Rectangle = e.AffectedBounds
                Dim flag1 As Boolean = e.ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes
                rectangle1.Y = rectangle1.Y + Sublight.Controls.Office2007Renderer.Office2007Renderer._marginInset
                rectangle1.Height = rectangle1.Height - (Sublight.Controls.Office2007Renderer.Office2007Renderer._marginInset * 2)
                If Not flag1 Then
                    rectangle1.X = rectangle1.X + Sublight.Controls.Office2007Renderer.Office2007Renderer._marginInset
                Else 
                    rectangle1.X = rectangle1.X + (Sublight.Controls.Office2007Renderer.Office2007Renderer._marginInset / 2)
                End If
                Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorTable.ImageMarginGradientBegin)
                    e.Graphics.FillRectangle(solidBrush1, rectangle1)
                End Using
                Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorMenuLight)
                    Using pen2 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorMenuDark)
                        If Not flag1 Then
                            e.Graphics.DrawLine(pen1, rectangle1.Right, rectangle1.Top, rectangle1.Right, rectangle1.Bottom)
                            e.Graphics.DrawLine(pen2, rectangle1.Right - 1, rectangle1.Top, rectangle1.Right - 1, rectangle1.Bottom)
                        Else 
                            e.Graphics.DrawLine(pen1, rectangle1.Left - 1, rectangle1.Top, rectangle1.Left - 1, rectangle1.Bottom)
                            e.Graphics.DrawLine(pen2, rectangle1.Left, rectangle1.Top, rectangle1.Left, rectangle1.Bottom)
                        End If
                    End Using
                    Return
                End Using
            End If
            MyBase.OnRenderImageMargin(e)
        End Sub

        Protected Overrides Sub OnRenderItemCheck(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
            Dim rectangle1 As System.Drawing.Rectangle = e.ImageRectangle
            rectangle1.Inflate(1, 1)
            If rectangle1.Top > Sublight.Controls.Office2007Renderer.Office2007Renderer._checkInset Then
                Dim i1 As Integer = rectangle1.Top - Sublight.Controls.Office2007Renderer.Office2007Renderer._checkInset
                rectangle1.Y = rectangle1.Y - i1
                rectangle1.Height = rectangle1.Height + i1
            End If
            Dim rectangle2 As System.Drawing.Rectangle = e().Bounds
            If rectangle1.Height <= (rectangle2.Height - (Sublight.Controls.Office2007Renderer.Office2007Renderer._checkInset * 2)) Then
                Dim rectangle3 As System.Drawing.Rectangle = e().Bounds
                Dim i2 As Integer = rectangle3.Height - (Sublight.Controls.Office2007Renderer.Office2007Renderer._checkInset * 2) - rectangle1.Height
                rectangle1.Height = rectangle1.Height + i2
            End If
            Using useAntiAlias1 As Sublight.Controls.Office2007Renderer.UseAntiAlias = New Sublight.Controls.Office2007Renderer.UseAntiAlias(e.Graphics)
                Using graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(rectangle1, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutMenuItemBack)
                    Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(ColorTable.CheckBackground)
                        e.Graphics.FillPath(solidBrush1, graphicsPath1)
                    End Using
                    Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Controls.Office2007Renderer.Office2007Renderer._contextCheckBorder)
                        e.Graphics.DrawPath(pen1, graphicsPath1)
                    End Using
                    If Not (e.Image) Is Nothing Then
                        Dim checkState1 As System.Windows.Forms.CheckState = System.Windows.Forms.CheckState.Unchecked
                        If TryCast(e(), System.Windows.Forms.ToolStripMenuItem) Then
                            Dim toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem = CType(e(), System.Windows.Forms.ToolStripMenuItem)
                            checkState1 = toolStripMenuItem1.CheckState
                        End If
                        Dim checkState2 As System.Windows.Forms.CheckState = checkState1
                        Select Case checkState2
                            Case System.Windows.Forms.CheckState.Checked
                                Using graphicsPath2 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateTickPath(rectangle1)
                                    Using pen2 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Controls.Office2007Renderer.Office2007Renderer._contextCheckTick, Sublight.Controls.Office2007Renderer.Office2007Renderer._contextCheckTickThickness)
                                        e.Graphics.DrawPath(pen2, graphicsPath2)
                                    End Using
                                    GoTo label_1
                                End Using

                            Case System.Windows.Forms.CheckState.Indeterminate
                                Using graphicsPath3 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateIndeterminatePath(rectangle1)
                                    Using solidBrush2 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Sublight.Controls.Office2007Renderer.Office2007Renderer._contextCheckTick)
                                        e.Graphics.FillPath(solidBrush2, graphicsPath3)
                                    End Using
                                End Using
                        End Select
                    End If
                label_1: _
                End Using
            End Using
        End Sub

        Protected Overrides Sub OnRenderItemImage(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
            If (TryCast(e.ToolStrip, System.Windows.Forms.ContextMenuStrip) OrElse TryCast(e.ToolStrip, System.Windows.Forms.ToolStripDropDownMenu)) AndAlso (Not (e.Image) Is Nothing) Then
                If e().Enabled Then
                    e.Graphics.DrawImage(e.Image, e.ImageRectangle)
                    Return
                End If
                Dim rectangle1 As System.Drawing.Rectangle = e.ImageRectangle
                Dim rectangle2 As System.Drawing.Rectangle = e.ImageRectangle
                System.Windows.Forms.ControlPaint.DrawImageDisabled(e.Graphics, e.Image, rectangle1.X, rectangle2.Y, System.Drawing.Color.Transparent)
                Return
                MyBase.OnRenderItemImage(e)
            End If
        End Sub

        Protected Overrides Sub OnRenderItemText(ByVal e As System.Windows.Forms.ToolStripItemTextRenderEventArgs)
            If (TypeOf e.ToolStrip Is System.Windows.Forms.MenuStrip) OrElse (Not (e.ToolStrip) Is Nothing) OrElse (TypeOf e.ToolStrip Is System.Windows.Forms.ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is System.Windows.Forms.ToolStripDropDownMenu) Then
                If Not e().Enabled Then
                    e.TextColor = Sublight.Controls.Office2007Renderer.Office2007Renderer._textDisabled
                ElseIf (TypeOf e.ToolStrip Is System.Windows.Forms.MenuStrip) AndAlso Not e().Pressed AndAlso Not e().Selected Then
                    e.TextColor = Sublight.Controls.Office2007Renderer.Office2007Renderer._textMenuStripItem
                ElseIf (TypeOf e.ToolStrip Is System.Windows.Forms.StatusStrip) AndAlso Not e().Pressed AndAlso Not e().Selected Then
                    e.TextColor = Sublight.Controls.Office2007Renderer.Office2007Renderer._textStatusStripItem
                Else 
                    e.TextColor = Sublight.Controls.Office2007Renderer.Office2007Renderer._textContextMenuItem
                End If
                Using useClearTypeGridFit1 As Sublight.Controls.Office2007Renderer.UseClearTypeGridFit = New Sublight.Controls.Office2007Renderer.UseClearTypeGridFit(e.Graphics)
                    MyBase.OnRenderItemText(e)
                    Return
                End Using
            End If
            MyBase.OnRenderItemText(e)
        End Sub

        Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            If (TypeOf e.ToolStrip Is System.Windows.Forms.MenuStrip) OrElse (TypeOf e.ToolStrip Is System.Windows.Forms.ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is System.Windows.Forms.ToolStripDropDownMenu) Then
                If e().Pressed AndAlso (TypeOf e.ToolStrip Is System.Windows.Forms.MenuStrip) Then
                    DrawContextMenuHeader(e.Graphics, e())
                    Return
                End If
                If Not e().Selected Then
                    Return
                End If
                If e().Enabled Then
                    If TypeOf e.ToolStrip Is System.Windows.Forms.MenuStrip Then
                        Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(e.Graphics, e(), Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemSelectedColors)
                        Return
                    End If
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientContextMenuItem(e.Graphics, e(), Sublight.Controls.Office2007Renderer.Office2007Renderer._itemContextItemEnabledColors)
                    Return
                End If
                Dim point1 As System.Drawing.Point = e.ToolStrip.PointToClient(System.Windows.Forms.Control.MousePosition)
                Dim rectangle1 As System.Drawing.Rectangle = e().Bounds
                If rectangle1.Contains(point1) Then
                    Return
                End If
                If TypeOf e.ToolStrip Is System.Windows.Forms.MenuStrip Then
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(e.Graphics, e(), Sublight.Controls.Office2007Renderer.Office2007Renderer._itemDisabledColors)
                    Return
                End If
                Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientContextMenuItem(e.Graphics, e(), Sublight.Controls.Office2007Renderer.Office2007Renderer._itemDisabledColors)
                Return
            End If
            MyBase.OnRenderMenuItemBackground(e)
        End Sub

        Protected Overrides Sub OnRenderSeparator(ByVal e As System.Windows.Forms.ToolStripSeparatorRenderEventArgs)
            If TryCast(e.ToolStrip, System.Windows.Forms.ContextMenuStrip) OrElse TryCast(e.ToolStrip, System.Windows.Forms.ToolStripDropDownMenu) Then
                Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorMenuLight)
                    Using pen2 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorMenuDark)
                        Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawSeparator(e.Graphics, e.Vertical, e().Bounds, pen1, pen2, Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorInset, e.ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes)
                    End Using
                    Return
                End Using
            End If
            MyBase.OnRenderSeparator(e)
        End Sub

        Protected Overrides Sub OnRenderSplitButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            If e().Selected OrElse e().Pressed Then
                Dim toolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton = CType(e(), System.Windows.Forms.ToolStripSplitButton)
                RenderToolSplitButtonBackground(e.Graphics, toolStripSplitButton1, e.ToolStrip)
                Dim rectangle1 As System.Drawing.Rectangle = toolStripSplitButton1.DropDownButtonBounds
                MyBase.OnRenderArrow(New System.Windows.Forms.ToolStripArrowRenderEventArgs(e.Graphics, toolStripSplitButton1, rectangle1, System.Drawing.SystemColors.ControlText, System.Windows.Forms.ArrowDirection.Down))
                Return
            End If
            MyBase.OnRenderSplitButtonBackground(e)
        End Sub

        Protected Overrides Sub OnRenderToolStripBackground(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            If TryCast(e.ToolStrip, System.Windows.Forms.ContextMenuStrip) OrElse TryCast(e.ToolStrip, System.Windows.Forms.ToolStripDropDownMenu) Then
                Using graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(e.AffectedBounds, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutContextMenu)
                    Using graphicsPath2 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateClipBorderPath(e.AffectedBounds, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutContextMenu)
                        Using useClipping1 As Sublight.Controls.Office2007Renderer.UseClipping = New Sublight.Controls.Office2007Renderer.UseClipping(e.Graphics, graphicsPath2)
                            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Sublight.Controls.Office2007Renderer.Office2007Renderer._contextMenuBack)
                                e.Graphics.FillPath(solidBrush1, graphicsPath1)
                            End Using
                        End Using
                    End Using
                    Return
                End Using
            End If
            MyBase.OnRenderToolStripBackground(e)
        End Sub

        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            If (TypeOf e.ToolStrip Is System.Windows.Forms.ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is System.Windows.Forms.ToolStripDropDownMenu) Then
                Dim rectangle1 As System.Drawing.Rectangle = e.ConnectedArea
                If Not rectangle1.IsEmpty Then
                    Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Sublight.Controls.Office2007Renderer.Office2007Renderer._contextMenuBack)
                        e.Graphics.FillRectangle(solidBrush1, e.ConnectedArea)
                    End Using
                End If
                Using graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(e.AffectedBounds, e.ConnectedArea, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutContextMenu)
                    Using graphicsPath2 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateInsideBorderPath(e.AffectedBounds, e.ConnectedArea, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutContextMenu)
                        Using graphicsPath3 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateClipBorderPath(e.AffectedBounds, e.ConnectedArea, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutContextMenu)
                            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(ColorTable.MenuBorder)
                                Using pen2 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Controls.Office2007Renderer.Office2007Renderer._separatorMenuLight)
                                    Using useClipping1 As Sublight.Controls.Office2007Renderer.UseClipping = New Sublight.Controls.Office2007Renderer.UseClipping(e.Graphics, graphicsPath3)
                                        Using useAntiAlias1 As Sublight.Controls.Office2007Renderer.UseAntiAlias = New Sublight.Controls.Office2007Renderer.UseAntiAlias(e.Graphics)
                                            e.Graphics.DrawPath(pen2, graphicsPath2)
                                            e.Graphics.DrawPath(pen1, graphicsPath1)
                                        End Using
                                        Dim rectangle2 As System.Drawing.Rectangle = e.AffectedBounds
                                        Dim rectangle3 As System.Drawing.Rectangle = e.AffectedBounds
                                        Dim rectangle4 As System.Drawing.Rectangle = e.AffectedBounds
                                        Dim rectangle5 As System.Drawing.Rectangle = e.AffectedBounds
                                        e.Graphics.DrawLine(pen1, rectangle2.Right, rectangle3.Bottom, rectangle4.Right - 1, rectangle5.Bottom - 1)
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                    Return
                End Using
            End If
            MyBase.OnRenderToolStripBorder(e)
        End Sub

        Protected Overrides Sub OnRenderToolStripContentPanelBackground(ByVal e As System.Windows.Forms.ToolStripContentPanelRenderEventArgs)
            MyBase.OnRenderToolStripContentPanelBackground(e)
        End Sub

        Private Shared Function CreateArrowPath(ByVal item As System.Windows.Forms.ToolStripItem, ByVal rect As System.Drawing.Rectangle, ByVal direction As System.Windows.Forms.ArrowDirection) As System.Drawing.Drawing2D.GraphicsPath
            Dim i1 As Integer, i2 As Integer

            If (direction = System.Windows.Forms.ArrowDirection.Left) OrElse (direction = System.Windows.Forms.ArrowDirection.Right) Then
                i1 = rect.Right - ((rect.Width - 4) / 2)
                i2 = rect.Y + (rect.Height / 2)
            Else 
                i1 = rect.X + (rect.Width / 2)
                i2 = rect.Bottom - ((rect.Height - 3) / 2)
                If TryCast(item, System.Windows.Forms.ToolStripDropDownButton) AndAlso (item.RightToLeft = System.Windows.Forms.RightToLeft.Yes) Then
                    i1 = i1 + 1
                End If
            End If
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
            Select Case direction
                Case System.Windows.Forms.ArrowDirection.Right
                    graphicsPath1.AddLine(i1, i2, i1 - 4, i2 - 4)
                    graphicsPath1.AddLine(i1 - 4, i2 - 4, i1 - 4, i2 + 4)
                    graphicsPath1.AddLine(i1 - 4, i2 + 4, i1, i2)

                Case System.Windows.Forms.ArrowDirection.Left
                    graphicsPath1.AddLine(i1 - 4, i2, i1, i2 - 4)
                    graphicsPath1.AddLine(i1, i2 - 4, i1, i2 + 4)
                    graphicsPath1.AddLine(i1, i2 + 4, i1 - 4, i2)

                Case System.Windows.Forms.ArrowDirection.Down
                    graphicsPath1.AddLine(CSng(i1) + 3.0F, CSng(i2) - 3.0F, CSng(i1) - 2.0F, CSng(i2) - 3.0F)
                    graphicsPath1.AddLine(CSng(i1) - 2.0F, CSng(i2) - 3.0F, CSng(i1), CSng(i2))
                    graphicsPath1.AddLine(CSng(i1), CSng(i2), CSng(i1) + 3.0F, CSng(i2) - 3.0F)

                Case System.Windows.Forms.ArrowDirection.Up
                    graphicsPath1.AddLine(CSng(i1) + 3.0F, CSng(i2), CSng(i1) - 3.0F, CSng(i2))
                    graphicsPath1.AddLine(CSng(i1) - 3.0F, CSng(i2), CSng(i1), CSng(i2) - 4.0F)
                    graphicsPath1.AddLine(CSng(i1), CSng(i2) - 4.0F, CSng(i1) + 3.0F, CSng(i2))
            End Select
            Return graphicsPath1
        End Function

        Private Shared Function CreateBorderPath(ByVal rect As System.Drawing.Rectangle, ByVal exclude As System.Drawing.Rectangle, ByVal cut As Single) As System.Drawing.Drawing2D.GraphicsPath
            If exclude.IsEmpty Then
                Return Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(rect, cut)
            End If
            rect.Width = rect.Width - 1
            rect.Height = rect.Height - 1
            Dim list1 As System.Collections.Generic.List(Of System.Drawing.PointF) = New System.Collections.Generic.List(Of System.Drawing.PointF)
            Dim f1 As Single = CSng(rect.X)
            Dim f2 As Single = CSng(rect.Y)
            Dim f3 As Single = CSng(rect.Right)
            Dim f4 As Single = CSng(rect.Bottom)
            Dim f5 As Single = CSng(rect.X) + cut
            Dim f6 As Single = CSng(rect.Right) - cut
            Dim f7 As Single = CSng(rect.Y) + cut
            Dim f8 As Single = CSng(rect.Bottom) - cut
            Dim f9 As Single = IIf(cut = 0.0F, 1.0F, cut)
            If (rect.Y >= exclude.Top) AndAlso (rect.Y <= exclude.Bottom) Then
                Dim f10 As Single = CSng((exclude.X - 1)) - cut
                Dim f11 As Single = CSng(exclude.Right) + cut
                If f5 <= f10 Then
                    list1.Add(New System.Drawing.PointF(f5, f2))
                    list1.Add(New System.Drawing.PointF(f10, f2))
                    list1.Add(New System.Drawing.PointF(f10 + cut, f2 - f9))
                Else 
                    f10 = CSng((exclude.X - 1))
                    list1.Add(New System.Drawing.PointF(f10, f2))
                    list1.Add(New System.Drawing.PointF(f10, f2 - f9))
                End If
                If f6 > f11 Then
                    list1.Add(New System.Drawing.PointF(f11 - cut, f2 - f9))
                    list1.Add(New System.Drawing.PointF(f11, f2))
                    list1.Add(New System.Drawing.PointF(f6, f2))
                Else 
                    f11 = CSng(exclude.Right)
                    list1.Add(New System.Drawing.PointF(f11, f2 - f9))
                    list1.Add(New System.Drawing.PointF(f11, f2))
                End If
            Else 
                list1.Add(New System.Drawing.PointF(f5, f2))
                list1.Add(New System.Drawing.PointF(f6, f2))
            End If
            list1.Add(New System.Drawing.PointF(f3, f7))
            list1.Add(New System.Drawing.PointF(f3, f8))
            list1.Add(New System.Drawing.PointF(f6, f4))
            list1.Add(New System.Drawing.PointF(f5, f4))
            list1.Add(New System.Drawing.PointF(f1, f8))
            list1.Add(New System.Drawing.PointF(f1, f7))
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
            Dim i1 As Integer = 1
            While i1 < list1.get_Count()
                graphicsPath1.AddLine(list1.get_Item(i1 - 1), list1.get_Item(i1))
                i1 = i1 + 1
            End While
            graphicsPath1.AddLine(list1.get_Item(list1.get_Count() - 1), list1.get_Item(0))
            Return graphicsPath1
        End Function

        Private Shared Function CreateBorderPath(ByVal rect As System.Drawing.Rectangle, ByVal cut As Single) As System.Drawing.Drawing2D.GraphicsPath
            rect.Width = rect.Width - 1
            rect.Height = rect.Height - 1
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
            graphicsPath1.AddLine(CSng(rect.Left) + cut, CSng(rect.Top), CSng(rect.Right) - cut, CSng(rect.Top))
            graphicsPath1.AddLine(CSng(rect.Right) - cut, CSng(rect.Top), CSng(rect.Right), CSng(rect.Top) + cut)
            graphicsPath1.AddLine(CSng(rect.Right), CSng(rect.Top) + cut, CSng(rect.Right), CSng(rect.Bottom) - cut)
            graphicsPath1.AddLine(CSng(rect.Right), CSng(rect.Bottom) - cut, CSng(rect.Right) - cut, CSng(rect.Bottom))
            graphicsPath1.AddLine(CSng(rect.Right) - cut, CSng(rect.Bottom), CSng(rect.Left) + cut, CSng(rect.Bottom))
            graphicsPath1.AddLine(CSng(rect.Left) + cut, CSng(rect.Bottom), CSng(rect.Left), CSng(rect.Bottom) - cut)
            graphicsPath1.AddLine(CSng(rect.Left), CSng(rect.Bottom) - cut, CSng(rect.Left), CSng(rect.Top) + cut)
            graphicsPath1.AddLine(CSng(rect.Left), CSng(rect.Top) + cut, CSng(rect.Left) + cut, CSng(rect.Top))
            Return graphicsPath1
        End Function

        Private Shared Function CreateClipBorderPath(ByVal rect As System.Drawing.Rectangle, ByVal exclude As System.Drawing.Rectangle, ByVal cut As Single) As System.Drawing.Drawing2D.GraphicsPath
            rect.Width = rect.Width + 1
            rect.Height = rect.Height + 1
            Return Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(rect, exclude, cut)
        End Function

        Private Shared Function CreateClipBorderPath(ByVal rect As System.Drawing.Rectangle, ByVal cut As Single) As System.Drawing.Drawing2D.GraphicsPath
            rect.Width = rect.Width + 1
            rect.Height = rect.Height + 1
            Return Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(rect, cut)
        End Function

        Private Shared Function CreateIndeterminatePath(ByVal rect As System.Drawing.Rectangle) As System.Drawing.Drawing2D.GraphicsPath
            Dim i1 As Integer = rect.X + (rect.Width / 2)
            Dim i2 As Integer = rect.Y + (rect.Height / 2)
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
            graphicsPath1.AddLine(i1 - 3, i2, i1, i2 - 3)
            graphicsPath1.AddLine(i1, i2 - 3, i1 + 3, i2)
            graphicsPath1.AddLine(i1 + 3, i2, i1, i2 + 3)
            graphicsPath1.AddLine(i1, i2 + 3, i1 - 3, i2)
            Return graphicsPath1
        End Function

        Private Shared Function CreateInsideBorderPath(ByVal rect As System.Drawing.Rectangle, ByVal cut As Single) As System.Drawing.Drawing2D.GraphicsPath
            rect.Inflate(-1, -1)
            Return Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(rect, cut)
        End Function

        Private Shared Function CreateInsideBorderPath(ByVal rect As System.Drawing.Rectangle, ByVal exclude As System.Drawing.Rectangle, ByVal cut As Single) As System.Drawing.Drawing2D.GraphicsPath
            rect.Inflate(-1, -1)
            Return Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(rect, exclude, cut)
        End Function

        Private Shared Function CreateTickPath(ByVal rect As System.Drawing.Rectangle) As System.Drawing.Drawing2D.GraphicsPath
            Dim i1 As Integer = rect.X + (rect.Width / 2)
            Dim i2 As Integer = rect.Y + (rect.Height / 2)
            Dim graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath
            graphicsPath1.AddLine(i1 - 4, i2, i1 - 2, i2 + 4)
            graphicsPath1.AddLine(i1 - 2, i2 + 4, i1 + 3, i2 - 5)
            Return graphicsPath1
        End Function

        Private Shared Sub DrawGradientBack(ByVal g As System.Drawing.Graphics, ByVal backRect As System.Drawing.Rectangle, ByVal colors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors)
            backRect.Inflate(-1, -1)
            Dim i1 As Integer = backRect.Height / 2
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(backRect.X, backRect.Y, backRect.Width, i1)
            Dim rectangle2 As System.Drawing.Rectangle = New System.Drawing.Rectangle(backRect.X, backRect.Y + i1, backRect.Width, backRect.Height - i1)
            Dim rectangle3 As System.Drawing.Rectangle = rectangle1
            Dim rectangle4 As System.Drawing.Rectangle = rectangle2
            rectangle3.Inflate(1, 1)
            rectangle4.Inflate(1, 1)
            Using linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle3, colors.InsideTop1, colors.InsideTop2, 90.0F)
                Using linearGradientBrush2 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle4, colors.InsideBottom1, colors.InsideBottom2, 90.0F)
                    g.FillRectangle(linearGradientBrush1, rectangle1)
                    g.FillRectangle(linearGradientBrush2, rectangle2)
                End Using
            End Using
            i1 = backRect.Height / 2
            rectangle1 = New System.Drawing.Rectangle(backRect.X, backRect.Y, backRect.Width, i1)
            rectangle2 = New System.Drawing.Rectangle(backRect.X, backRect.Y + i1, backRect.Width, backRect.Height - i1)
            rectangle3 = rectangle1
            rectangle4 = rectangle2
            rectangle3.Inflate(1, 1)
            rectangle4.Inflate(1, 1)
            Using linearGradientBrush3 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle3, colors.FillTop1, colors.FillTop2, 90.0F)
                Using linearGradientBrush4 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle4, colors.FillBottom1, colors.FillBottom2, 90.0F)
                    backRect.Inflate(-1, -1)
                    i1 = backRect.Height / 2
                    rectangle1 = New System.Drawing.Rectangle(backRect.X, backRect.Y, backRect.Width, i1)
                    rectangle2 = New System.Drawing.Rectangle(backRect.X, backRect.Y + i1, backRect.Width, backRect.Height - i1)
                    g.FillRectangle(linearGradientBrush3, rectangle1)
                    g.FillRectangle(linearGradientBrush4, rectangle2)
                End Using
            End Using
        End Sub

        Private Shared Sub DrawGradientBorder(ByVal g As System.Drawing.Graphics, ByVal backRect As System.Drawing.Rectangle, ByVal colors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors)
            Using useAntiAlias1 As Sublight.Controls.Office2007Renderer.UseAntiAlias = New Sublight.Controls.Office2007Renderer.UseAntiAlias(g)
                Dim rectangle1 As System.Drawing.Rectangle = backRect
                rectangle1.Inflate(1, 1)
                Using linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rectangle1, colors.Border1, colors.Border2, 90.0F)
                    linearGradientBrush1.SetSigmaBellShape(0.5F)
                    Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(linearGradientBrush1)
                        Using graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(backRect, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutMenuItemBack)
                            g.DrawPath(pen1, graphicsPath1)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Shared Sub DrawGradientContextMenuItem(ByVal g As System.Drawing.Graphics, ByVal item As System.Windows.Forms.ToolStripItem, ByVal colors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors)
            Dim rectangle2 As System.Drawing.Rectangle = item.Bounds
            Dim rectangle3 As System.Drawing.Rectangle = item.Bounds
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(2, 0, rectangle2.Width - 3, rectangle3.Height)
            Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientItem(g, rectangle1, colors)
        End Sub

        Private Shared Sub DrawGradientItem(ByVal g As System.Drawing.Graphics, ByVal backRect As System.Drawing.Rectangle, ByVal colors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors)
            If (backRect.Width > 0) AndAlso (backRect.Height > 0) Then
                Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientBack(g, backRect, colors)
                Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientBorder(g, backRect, colors)
            End If
        End Sub

        Private Shared Sub DrawGradientToolItem(ByVal g As System.Drawing.Graphics, ByVal item As System.Windows.Forms.ToolStripItem, ByVal colors As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors)
            Dim rectangle1 As System.Drawing.Rectangle = item.Bounds
            Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientItem(g, New System.Drawing.Rectangle(System.Drawing.Point.Empty, rectangle1.Size), colors)
        End Sub

        Private Shared Sub DrawGradientToolSplitItem(ByVal g As System.Drawing.Graphics, ByVal splitButton As System.Windows.Forms.ToolStripSplitButton, ByVal colorsButton As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors, ByVal colorsDrop As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors, ByVal colorsSplit As Sublight.Controls.Office2007Renderer.Office2007Renderer.GradientItemColors)
            Dim i1 As Integer

            Dim rectangle4 As System.Drawing.Rectangle = splitButton.Bounds
            Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(System.Drawing.Point.Empty, rectangle4.Size)
            Dim rectangle2 As System.Drawing.Rectangle = splitButton.DropDownButtonBounds
            If (rectangle1.Width > 0) AndAlso (rectangle2.Width > 0) AndAlso (rectangle1.Height > 0) AndAlso (rectangle2.Height > 0) Then
                Dim rectangle3 As System.Drawing.Rectangle = rectangle1
                If rectangle2.X > 0 Then
                    rectangle3.Width = rectangle2.Left
                    rectangle2.X = rectangle2.X - 1
                    rectangle2.Width = rectangle2.Width + 1
                    i1 = rectangle2.X
                Else 
                    rectangle3.Width = rectangle3.Width - (rectangle2.Width - 2)
                    rectangle3.X = rectangle2.Right - 1
                    rectangle2.Width = rectangle2.Width + 1
                    i1 = rectangle2.Right - 1
                End If
                Using graphicsPath1 As System.Drawing.Drawing2D.GraphicsPath = Sublight.Controls.Office2007Renderer.Office2007Renderer.CreateBorderPath(rectangle1, Sublight.Controls.Office2007Renderer.Office2007Renderer._cutMenuItemBack)
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientBack(g, rectangle3, colorsButton)
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientBack(g, rectangle2, colorsDrop)
                    Using linearGradientBrush1 As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New System.Drawing.Rectangle(rectangle1.X + i1, rectangle1.Top, 1, rectangle1.Height + 1), colorsSplit.Border1, colorsSplit.Border2, 90.0F)
                        linearGradientBrush1.SetSigmaBellShape(0.5F)
                        Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(linearGradientBrush1)
                            g.DrawLine(pen1, rectangle1.X + i1, rectangle1.Top + 1, rectangle1.X + i1, rectangle1.Bottom - 1)
                        End Using
                    End Using
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientBorder(g, rectangle1, colorsButton)
                End Using
            End If
        End Sub

        Private Shared Sub DrawSeparator(ByVal g As System.Drawing.Graphics, ByVal vertical As Boolean, ByVal rect As System.Drawing.Rectangle, ByVal lightPen As System.Drawing.Pen, ByVal darkPen As System.Drawing.Pen, ByVal horizontalInset As Integer, ByVal rtl As Boolean)
            If vertical Then
                Dim i1 As Integer = rect.Width / 2
                Dim i2 As Integer = rect.Y
                Dim i3 As Integer = rect.Bottom
                g.DrawLine(darkPen, i1, i2, i1, i3)
                g.DrawLine(lightPen, i1 + 1, i2, i1 + 1, i3)
                Return
            End If
            Dim i4 As Integer = rect.Height / 2
            Dim i5 As Integer = rect.X + IIf(rtl, 0, horizontalInset)
            Dim i6 As Integer = rect.Right - IIf(rtl, horizontalInset, 0)
            g.DrawLine(darkPen, i5, i4, i6, i4)
            g.DrawLine(lightPen, i5, i4 + 1, i6, i4 + 1)
        End Sub

        Private Shared Sub RenderToolButtonBackground(ByVal g As System.Drawing.Graphics, ByVal button As System.Windows.Forms.ToolStripButton, ByVal toolstrip As System.Windows.Forms.ToolStrip)
            If button.Enabled Then
                If button.Checked Then
                    If button.Pressed Then
                        Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, button, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemPressedColors)
                        Return
                    End If
                    If button.Selected Then
                        Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, button, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemCheckPressColors)
                        Return
                    End If
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, button, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemCheckedColors)
                    Return
                End If
                If button.Pressed Then
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, button, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemPressedColors)
                    Return
                End If
                If Not button.Selected Then
                    Return
                End If
                Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, button, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemToolItemSelectedColors)
                Return
            End If
            If button.Selected Then
                Dim point1 As System.Drawing.Point = toolstrip.PointToClient(System.Windows.Forms.Control.MousePosition)
                Dim rectangle1 As System.Drawing.Rectangle = button.Bounds
                If Not rectangle1.Contains(point1) Then
                    Sublight.Controls.Office2007Renderer.Office2007Renderer.DrawGradientToolItem(g, button, Sublight.Controls.Office2007Renderer.Office2007Renderer._itemDisabledColors)
                End If
            End If
        End Sub

    End Class ' class Office2007Renderer

End Namespace

