Imports System.Drawing
Imports System.Windows.Forms

Namespace Sublight.Controls.Office2007Renderer

    Public Class Office2007ColorTable
        Inherits System.Windows.Forms.ProfessionalColorTable

        Private Shared ReadOnly _buttonBorder As System.Drawing.Color 
        Private Shared ReadOnly _buttonPressedBegin As System.Drawing.Color 
        Private Shared ReadOnly _buttonPressedEnd As System.Drawing.Color 
        Private Shared ReadOnly _buttonPressedMiddle As System.Drawing.Color 
        Private Shared ReadOnly _buttonSelectedBegin As System.Drawing.Color 
        Private Shared ReadOnly _buttonSelectedEnd As System.Drawing.Color 
        Private Shared ReadOnly _buttonSelectedMiddle As System.Drawing.Color 
        Private Shared ReadOnly _checkBack As System.Drawing.Color 
        Private Shared ReadOnly _contextMenuBack As System.Drawing.Color 
        Private Shared ReadOnly _gripDark As System.Drawing.Color 
        Private Shared ReadOnly _gripLight As System.Drawing.Color 
        Private Shared ReadOnly _imageMargin As System.Drawing.Color 
        Private Shared ReadOnly _menuBorder As System.Drawing.Color 
        Private Shared ReadOnly _menuItemSelectedBegin As System.Drawing.Color 
        Private Shared ReadOnly _menuItemSelectedEnd As System.Drawing.Color 
        Private Shared ReadOnly _menuToolBack As System.Drawing.Color 
        Private Shared ReadOnly _overflowBegin As System.Drawing.Color 
        Private Shared ReadOnly _overflowEnd As System.Drawing.Color 
        Private Shared ReadOnly _overflowMiddle As System.Drawing.Color 
        Private Shared ReadOnly _separatorDark As System.Drawing.Color 
        Private Shared ReadOnly _separatorLight As System.Drawing.Color 
        Private Shared ReadOnly _statusStripDark As System.Drawing.Color 
        Private Shared ReadOnly _statusStripLight As System.Drawing.Color 
        Private Shared ReadOnly _toolStripBegin As System.Drawing.Color 
        Private Shared ReadOnly _toolStripBorder As System.Drawing.Color 
        Private Shared ReadOnly _toolStripContentEnd As System.Drawing.Color 
        Private Shared ReadOnly _toolStripEnd As System.Drawing.Color 
        Private Shared ReadOnly _toolStripMiddle As System.Drawing.Color 

        Public Overrides ReadOnly Property ButtonPressedGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonPressedBegin
            End Get
        End Property

        Public Overrides ReadOnly Property ButtonPressedGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonPressedEnd
            End Get
        End Property

        Public Overrides ReadOnly Property ButtonPressedGradientMiddle As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonPressedMiddle
            End Get
        End Property

        Public Overrides ReadOnly Property ButtonSelectedGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonSelectedBegin
            End Get
        End Property

        Public Overrides ReadOnly Property ButtonSelectedGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonSelectedEnd
            End Get
        End Property

        Public Overrides ReadOnly Property ButtonSelectedGradientMiddle As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonSelectedMiddle
            End Get
        End Property

        Public Overrides ReadOnly Property ButtonSelectedHighlightBorder As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonBorder
            End Get
        End Property

        Public Overrides ReadOnly Property CheckBackground As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._checkBack
            End Get
        End Property

        Public Overrides ReadOnly Property GripDark As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._gripDark
            End Get
        End Property

        Public Overrides ReadOnly Property GripLight As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._gripLight
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMarginGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._imageMargin
            End Get
        End Property

        Public Overrides ReadOnly Property MenuBorder As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuBorder
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemPressedGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripBegin
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemPressedGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripEnd
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemPressedGradientMiddle As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripMiddle
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuItemSelectedBegin
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuItemSelectedEnd
            End Get
        End Property

        Public Overrides ReadOnly Property MenuStripGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuToolBack
            End Get
        End Property

        Public Overrides ReadOnly Property MenuStripGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuToolBack
            End Get
        End Property

        Public Overrides ReadOnly Property OverflowButtonGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._overflowBegin
            End Get
        End Property

        Public Overrides ReadOnly Property OverflowButtonGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._overflowEnd
            End Get
        End Property

        Public Overrides ReadOnly Property OverflowButtonGradientMiddle As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._overflowMiddle
            End Get
        End Property

        Public Overrides ReadOnly Property RaftingContainerGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuToolBack
            End Get
        End Property

        Public Overrides ReadOnly Property RaftingContainerGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuToolBack
            End Get
        End Property

        Public Overrides ReadOnly Property SeparatorDark As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._separatorDark
            End Get
        End Property

        Public Overrides ReadOnly Property SeparatorLight As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._separatorLight
            End Get
        End Property

        Public Overrides ReadOnly Property StatusStripGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._statusStripLight
            End Get
        End Property

        Public Overrides ReadOnly Property StatusStripGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._statusStripDark
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripBorder As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripBorder
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripContentPanelGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripContentEnd
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripContentPanelGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuToolBack
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripDropDownBackground As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._contextMenuBack
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripBegin
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripEnd
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripGradientMiddle As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripMiddle
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripPanelGradientBegin As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuToolBack
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripPanelGradientEnd As System.Drawing.Color
            Get
                Return Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuToolBack
            End Get
        End Property

        Public Sub New()
        End Sub

        Shared Sub New()
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._contextMenuBack = System.Drawing.Color.FromArgb(250, 250, 250)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonPressedBegin = System.Drawing.Color.FromArgb(248, 181, 106)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonPressedEnd = System.Drawing.Color.FromArgb(255, 208, 134)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonPressedMiddle = System.Drawing.Color.FromArgb(251, 140, 60)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonSelectedBegin = System.Drawing.Color.FromArgb(255, 255, 222)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonSelectedEnd = System.Drawing.Color.FromArgb(255, 203, 136)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonSelectedMiddle = System.Drawing.Color.FromArgb(255, 225, 172)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuItemSelectedBegin = System.Drawing.Color.FromArgb(255, 213, 103)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuItemSelectedEnd = System.Drawing.Color.FromArgb(255, 228, 145)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._checkBack = System.Drawing.Color.FromArgb(255, 227, 149)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._gripDark = System.Drawing.Color.FromArgb(111, 157, 217)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._gripLight = System.Drawing.Color.FromArgb(255, 255, 255)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._imageMargin = System.Drawing.Color.FromArgb(233, 238, 238)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuBorder = System.Drawing.Color.FromArgb(134, 134, 134)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._overflowBegin = System.Drawing.Color.FromArgb(167, 204, 251)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._overflowEnd = System.Drawing.Color.FromArgb(101, 147, 207)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._overflowMiddle = System.Drawing.Color.FromArgb(167, 204, 251)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._menuToolBack = System.Drawing.Color.FromArgb(191, 219, 255)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._separatorDark = System.Drawing.Color.FromArgb(154, 198, 255)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._separatorLight = System.Drawing.Color.FromArgb(255, 255, 255)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._statusStripLight = System.Drawing.Color.FromArgb(215, 229, 247)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._statusStripDark = System.Drawing.Color.FromArgb(172, 201, 238)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripBorder = System.Drawing.Color.FromArgb(111, 157, 217)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripContentEnd = System.Drawing.Color.FromArgb(164, 195, 235)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripBegin = System.Drawing.Color.FromArgb(227, 239, 255)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripEnd = System.Drawing.Color.FromArgb(152, 186, 230)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._toolStripMiddle = System.Drawing.Color.FromArgb(222, 236, 255)
            Sublight.Controls.Office2007Renderer.Office2007ColorTable._buttonBorder = System.Drawing.Color.FromArgb(121, 153, 194)
        End Sub

    End Class ' class Office2007ColorTable

End Namespace

