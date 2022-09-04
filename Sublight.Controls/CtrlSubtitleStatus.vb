Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight.Common.Types
Imports Sublight.Common.Utility
Imports Sublight.Controls.Button
Imports Sublight.Types
Imports Sublight.WS

Namespace Sublight.Controls

    Public Class CtrlSubtitleStatus
        Inherits System.Windows.Forms.UserControl
        Implements Sublight.Types.ITranslateControl

        Public Delegate Sub StatusClickHandler(ByVal sender As Object, ByVal newStatus As Sublight.Common.Types.SubtitleStatus)

        Private components As System.ComponentModel.IContainer 
        Private m_subtitle As Sublight.WS.Subtitle 

        Public Event StatusClick As Sublight.Controls.CtrlSubtitleStatus.StatusClickHandler

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim button1 As Sublight.Controls.Button.Button = TryCast(sender, Sublight.Controls.Button.Button)
            If (button1) Is Nothing Then
                Return
            End If
            OnStatusClick(DirectCast(button1.Tag, Sublight.Common.Types.SubtitleStatus))
        End Sub

        Private Sub InitializeComponent()
            SuspendLayout()
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Name = "CtrlSubtitleStatus?"
            Size = New System.Drawing.Size(161, 26)
            ResumeLayout(False)
        End Sub

        Public Sub InitStatuses(ByVal subtitle As Sublight.WS.Subtitle)
            Dim control1 As System.Windows.Forms.Control 
            For Each control1 In Controls
                control1.Dispose()
            Next
            Controls.Clear()
            m_subtitle = subtitle
            Dim subtitleStatusArr1 As Sublight.Common.Types.SubtitleStatus() = Nothing
            If Not (m_subtitle) Is Nothing Then
                subtitleStatusArr1 = Sublight.Common.Utility.SubtitleStatusValidator.GetNext(m_subtitle.Status)
            End If
            If Not (subtitleStatusArr1) Is Nothing Then
                Dim i1 As Integer = 0
                Dim subtitleStatusArr2 As Sublight.Common.Types.SubtitleStatus() = subtitleStatusArr1
                Dim i2 As Integer = 0
                While i2 < subtitleStatusArr2.Length
                    Dim subtitleStatus1 As Sublight.Common.Types.SubtitleStatus = CType(subtitleStatusArr2(i2), Sublight.Common.Types.SubtitleStatus)
                    If m_subtitle.Status <> System.Convert.ToByte(subtitleStatus1) Then
                        Dim button1 As Sublight.Controls.Button.Button = New Sublight.Controls.Button.Button
                        button1.Name = System.Enum.GetName(GetType(Sublight.Common.Types.SubtitleStatus), subtitleStatus1)
                        button1.Size = New System.Drawing.Size(75, 23)
                        button1.Left = i1
                        button1.Top = 0
                        button1.Tag = subtitleStatus1
                        AddHandler button1.Click, AddressOf button_Click
                        Controls.Add(button1)
                        i1 = i1 + (button1.Width + 5)
                    End If
                    i2 = i2 + 1
                End While
            End If
            Translate()
        End Sub

        Protected Sub OnStatusClick(ByVal newStatus As Sublight.Common.Types.SubtitleStatus)
            If Not (StatusClickEvent) Is Nothing Then
                RaiseEvent StatusClick(Me, newStatus)
            End If
        End Sub

        Public Sub Translate()
            Dim button1 As Sublight.Controls.Button.Button 
            For Each button1 In Controls
                Dim subtitleStatus1 As Sublight.Common.Types.SubtitleStatus = DirectCast(button1.Tag, Sublight.Common.Types.SubtitleStatus)
                If subtitleStatus1 = Sublight.Common.Types.SubtitleStatus.Authorised Then
                    button1.Text = "Authorize?"
                Else 
                    If subtitleStatus1 = Sublight.Common.Types.SubtitleStatus.Deleted Then
                        button1.Text = "Delete?"
                        Continue
                    End If
                    If subtitleStatus1 = Sublight.Common.Types.SubtitleStatus.PartiallyAuthorised Then
                        button1.Text = "Part. auth.?"
                        Continue
                    End If
                    If subtitleStatus1 = Sublight.Common.Types.SubtitleStatus.PartiallyAuthorisedWarning Then
                        button1.Text = "Part. auth. warn?"
                    End If
                End If
            Next
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class CtrlSubtitleStatus

End Namespace

