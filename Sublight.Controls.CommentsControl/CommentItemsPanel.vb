Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Sublight.Controls.CommentsControl

    Public Class CommentItemsPanel
        Inherits System.Windows.Forms.FlowLayoutPanel

        Public Sub New()
            AutoScroll = True
            BackColor = System.Drawing.SystemColors.Window
            BorderStyle = System.Windows.Forms.BorderStyle.None
            FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Margin = New System.Windows.Forms.Padding(0)
            WrapContents = False
        End Sub

        Public Sub ControlsAdded()
            AutoScrollPosition = New System.Drawing.Point(0, 0)
            ResumeLayout(False)
        End Sub

        Private Sub item_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In Controls
                Dim commentItem1 As Sublight.Controls.CommentsControl.CommentItem = TryCast(control1, Sublight.Controls.CommentsControl.CommentItem)
                If (Not (commentItem1) Is Nothing) AndAlso commentItem1.IsClicked Then
                    commentItem1.Clear()
                End If
            Next
        End Sub

        Protected Overrides Sub OnClientSizeChanged(ByVal e As System.EventArgs)
            MyBase.OnClientSizeChanged(e)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In Controls
                Dim size1 As System.Drawing.Size = ClientSize
                Dim padding1 As System.Windows.Forms.Padding = control1.Margin
                Dim padding2 As System.Windows.Forms.Padding = control1.Margin
                control1.Width = size1.Width - (padding1.Left + padding2.Right)
            Next
        End Sub

        Protected Overrides Sub OnControlAdded(ByVal e As System.Windows.Forms.ControlEventArgs)
            MyBase.OnControlAdded(e)
            Dim commentItem1 As Sublight.Controls.CommentsControl.CommentItem = TryCast(e.Control, Sublight.Controls.CommentsControl.CommentItem)
            If Not (commentItem1) Is Nothing Then
                AddHandler commentItem1.Click, AddressOf item_Click
            End If
        End Sub

    End Class ' class CommentItemsPanel

End Namespace

