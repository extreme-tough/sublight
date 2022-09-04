Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.Security
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Principal
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Windows.Forms
Imports System.Windows.Forms.Layout
Imports System.Xml
Imports System.Xml.Serialization
Imports Root
Imports BinaryComponents.SuperList
Imports BinaryComponents.SuperList.ItemLists
Imports BinaryComponents.SuperList.Sections
Imports BinaryComponents.Utility.Collections
Imports BinaryComponents.WinFormsUtility.Drawing
Imports Elegant.Ui
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Zip.Compression.Streams
Imports Microsoft.Win32
Imports Sublight
Imports Sublight.Common.Types
Imports Sublight.Common.Utility
Imports Sublight.Controls.Button
Imports Sublight.Controls.CommentsControl
Imports Sublight.Controls.Office2007Renderer
Imports Sublight.Lib.IMDB
Imports Sublight.Lib.Language
Imports Sublight.Lib.Subtitle
Imports Sublight.Lib.SubtitlesAPI
Imports Sublight.Lib.Types
Imports Sublight.MyUtility
Imports Sublight.MyUtility.Explorer
Imports Sublight.Plugins.Core
Imports Sublight.Plugins.SubtitleProvider
Imports Sublight.Plugins.SubtitleProvider.Types
Imports Sublight.Properties
Imports Sublight.SubtitleEditor
Imports Sublight.Types
Imports Sublight.WS
Imports Sublight.WS_SublightClient
Imports Utility
Imports Utility.Video
Imports VistaStyleProgressBar

Namespace Sublight.Controls

    <System.ComponentModel.DefaultProperty("Caption"), _
    System.Drawing.ToolboxBitmap(GetType(System.Windows.Forms.GroupBox))> _
    Public Class NiceLine
        Inherits System.Windows.Forms.UserControl

        Private _Caption As String 
        Private _CaptionMarginSpace As Integer 
        Private _CaptionOrizontalAlign As Sublight.Controls.CaptionOrizontalAlign 
        Private _CaptionPadding As Integer 
        Private _LineVerticalAlign As Sublight.Controls.LineVerticalAlign 
        Private components As System.ComponentModel.Container 

        <System.ComponentModel.Description("The caption text displayed on the line. If the caption is """" (the default) the line is not broken"), _
        System.ComponentModel.Category("Appearance"), _
        System.ComponentModel.DefaultValue("")> _
        Public Property Caption As String
            Get
                Return _Caption
            End Get
            Set
                _Caption = value
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.Description("The distance in pixels form the control margin to caption text"), _
        System.ComponentModel.Category("Appearance"), _
        System.ComponentModel.DefaultValue(16)> _
        Public Property CaptionMarginSpace As Integer
            Get
                Return _CaptionMarginSpace
            End Get
            Set
                _CaptionMarginSpace = value
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.Category("Appearance"), _
        System.ComponentModel.Description("Tell where the text caption is aligned in the control"), _
        System.ComponentModel.DefaultValue(Sublight.Controls.CaptionOrizontalAlign.Left)> _
        Public Property CaptionOrizontalAlign As Sublight.Controls.CaptionOrizontalAlign
            Get
                Return _CaptionOrizontalAlign
            End Get
            Set
                _CaptionOrizontalAlign = value
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.DefaultValue(2), _
        System.ComponentModel.Description("The space in pixels arrownd text caption"), _
        System.ComponentModel.Category("Appearance")> _
        Public Property CaptionPadding As Integer
            Get
                Return _CaptionPadding
            End Get
            Set
                _CaptionPadding = value
                Invalidate()
            End Set
        End Property

        <System.ComponentModel.DefaultValue(Sublight.Controls.LineVerticalAlign.Middle), _
        System.ComponentModel.Description("The vertical alignement of the line within the space of the control"), _
        System.ComponentModel.Category("Appearance")> _
        Public Property LineVerticalAlign As Sublight.Controls.LineVerticalAlign
            Get
                Return _LineVerticalAlign
            End Get
            Set
                _LineVerticalAlign = value
                Invalidate()
            End Set
        End Property

        Public Sub New()
            _Caption = "?"
            _CaptionMarginSpace = 16
            _CaptionPadding = 2
            _LineVerticalAlign = Sublight.Controls.LineVerticalAlign.Middle
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Name = "NiceLine?"
            Size = New System.Drawing.Size(100, Font.Height)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            MyBase.OnFontChanged(e)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim i1 As Integer, i3 As Integer, i4 As Integer

            MyBase.OnPaint(e)
            Select Case LineVerticalAlign
                Case Sublight.Controls.LineVerticalAlign.Top
                    i1 = 0

                Case Sublight.Controls.LineVerticalAlign.Middle
                    Dim size1 As System.Drawing.Size = Size
                    i1 = System.Convert.ToInt32(System.Math.Ceiling(CDbl(size1.Height) / 2.0R)) - 1

                Case Sublight.Controls.LineVerticalAlign.Bottom
                    Dim size2 As System.Drawing.Size = Size
                    i1 = size2.Height - 2

                Case Else
                    i1 = 0
            End Select
            Dim sizeF1 As System.Drawing.SizeF = e.Graphics.MeasureString(Caption, Font, Width - (CaptionMarginSpace * 2), System.Drawing.StringFormat.GenericDefault)
            Dim i2 As Integer = System.Convert.ToInt32(sizeF1.Width)
            If Caption = "?" Then
                i3 = CaptionMarginSpace
                i4 = CaptionMarginSpace
            Else 
                Select Case CaptionOrizontalAlign
                    Case Sublight.Controls.CaptionOrizontalAlign.Left
                        i3 = CaptionMarginSpace
                        i4 = CaptionMarginSpace + (CaptionPadding * 2) + i2

                    Case Sublight.Controls.CaptionOrizontalAlign.Center
                        i3 = ((Width - i2) / 2) - CaptionPadding
                        i4 = ((Width - i2) / 2) + i2 + CaptionPadding

                    Case Sublight.Controls.CaptionOrizontalAlign.Right
                        i3 = Width - (CaptionMarginSpace * 2) - i2
                        i4 = Width - CaptionMarginSpace

                    Case Else
                        i3 = CaptionMarginSpace
                        i4 = CaptionMarginSpace
                End Select
            End If
            Dim pen1 As System.Drawing.Pen = New System.Drawing.Pen(Sublight.Globals.ColorSeparator)
            Dim pen2 As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.White)
            Dim solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(ForeColor)
            Dim pointArr1 As System.Drawing.Point() = New System.Drawing.Point(3) {}
            pointArr1(0) = New System.Drawing.Point(0, i1 + 1)
            pointArr1(1) = New System.Drawing.Point(0, i1)
            pointArr1(2) = New System.Drawing.Point(i3, i1)
            e.Graphics.DrawLines(pen1, pointArr1)
            Dim pointArr2 As System.Drawing.Point() = New System.Drawing.Point(2) {}
            pointArr2(0) = New System.Drawing.Point(i4, i1)
            pointArr2(1) = New System.Drawing.Point(Width, i1)
            e.Graphics.DrawLines(pen1, pointArr2)
            Dim pointArr3 As System.Drawing.Point() = New System.Drawing.Point(2) {}
            pointArr3(0) = New System.Drawing.Point(0, i1 + 1)
            pointArr3(1) = New System.Drawing.Point(i3, i1 + 1)
            e.Graphics.DrawLines(pen2, pointArr3)
            Dim pointArr4 As System.Drawing.Point() = New System.Drawing.Point(3) {}
            pointArr4(0) = New System.Drawing.Point(i4, i1 + 1)
            pointArr4(1) = New System.Drawing.Point(Width, i1 + 1)
            pointArr4(2) = New System.Drawing.Point(Width, i1)
            e.Graphics.DrawLines(pen2, pointArr4)
            If Caption <> "?" Then
                e.Graphics.DrawString(Caption, Font, solidBrush1, CSng((i3 + CaptionPadding)), 1.0F)
            End If
            pen1.Dispose()
            pen2.Dispose()
            solidBrush1.Dispose()
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            Height = Font.Height + 2
            Invalidate()
        End Sub

    End Class ' class NiceLine

End Namespace

