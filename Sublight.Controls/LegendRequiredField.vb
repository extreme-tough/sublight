Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight

Namespace Sublight.Controls

    Public Class LegendRequiredField
        Inherits System.Windows.Forms.UserControl

        Private components As System.ComponentModel.IContainer 
        Private label1 As System.Windows.Forms.Label 
        Private label2 As System.Windows.Forms.Label 

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            label1 = New System.Windows.Forms.Label
            label2 = New System.Windows.Forms.Label
            SuspendLayout()
            label1.Dock = System.Windows.Forms.DockStyle.Left
            label1.Font = New System.Drawing.Font("Microsoft Sans Serif?", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            label1.Location = New System.Drawing.Point(0, 0)
            label1.Name = "label1?"
            label1.Size = New System.Drawing.Size(15, 22)
            label1.TabIndex = 0
            label1.Text = "*?"
            label2.Dock = System.Windows.Forms.DockStyle.Fill
            label2.Location = New System.Drawing.Point(15, 0)
            label2.Name = "label2?"
            label2.Size = New System.Drawing.Size(135, 22)
            label2.TabIndex = 2
            label2.Text = "- obvezno polje?"
            Controls.Add(label2)
            Controls.Add(label1)
            Font = New System.Drawing.Font("Microsoft Sans Serif?", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238)
            ForeColor = System.Drawing.Color.Red
            Name = "LegendRequiredField?"
            Size = New System.Drawing.Size(150, 22)
            ResumeLayout(False)
        End Sub

        Public Sub Translate()
            label2.Text = System.String.Format("- {0}?", Sublight.Translation.Common_RequiredField)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class ' class LegendRequiredField

End Namespace

