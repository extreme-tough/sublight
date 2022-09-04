Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Sublight
Imports Sublight.Controls.Button

Namespace Sublight.Controls

    Friend Class ProfileContactUs
        Inherits Sublight.Controls.ProfileBase

        Private btnClear As Sublight.Controls.Button.Button 
        Private btnSend As Sublight.Controls.Button.Button 
        Private components As System.ComponentModel.IContainer 
        Private lblEmail As System.Windows.Forms.Label 
        Private lblMessage As System.Windows.Forms.Label 
        Private lblOptionalEmail As System.Windows.Forms.Label 
        Private lblPreferredLanguage As System.Windows.Forms.Label 
        Private lblSubject As System.Windows.Forms.Label 
        Private myGroupBox1 As Sublight.Controls.MyGroupBox 
        Private ttHelp As Sublight.Controls.ToolTip 
        Private txtEmail As Sublight.Controls.MyTextBox 
        Private txtMessage As Sublight.Controls.MyTextBox 
        Private txtSubject As Sublight.Controls.MyTextBox 

        Public Sub New(ByVal baseForm As Sublight.BaseForm)
            InitializeComponent()
            AddHandler Sublight.Globals.Events.LanguageChanged, AddressOf Events_LanguageChanged
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            txtSubject.Text = System.String.Empty
            txtEmail.Text = System.String.Empty
            txtMessage.Text = System.String.Empty
        End Sub

        Private Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim s1 As String

            If System.String.IsNullOrEmpty(txtSubject.Text.Trim()) Then
                ParentBaseForm.ShowWarning(Sublight.Translation.ContactUs_Warning_SubjectEmpty, New object(0) {})
                Return
            End If
            If System.String.IsNullOrEmpty(txtMessage.Text.Trim()) Then
                ParentBaseForm.ShowWarning(Sublight.Translation.ContactUs_Warning_MessageEmpty, New object(0) {})
                Return
            End If
            If Not ParentBaseForm.SendComment(Me, txtSubject.Text, txtEmail.Text, txtMessage.Text, out s1) Then
                Dim objArr1 As Object() = New object() { s1 }
                ParentBaseForm.ShowError(Sublight.Translation.ContactUs_Error_ErrorSendingMessage, objArr1)
                Return
            End If
            ParentBaseForm.ShowInfo(Sublight.Translation.ContactUs_Info_MessageSuccessfullySent, New object(0) {})
        End Sub

        Private Sub Events_LanguageChanged(ByVal sender As Object, ByVal language As String)
            btnClear.Text = Sublight.Translation.Common_Button_Clear
            btnSend.Text = Sublight.Translation.Common_Button_Send
            Text = Sublight.Translation.Profile_Title
            lblSubject.Text = Sublight.Translation.ContactUs_Subject
            lblEmail.Text = Sublight.Translation.ContactUs_Email
            lblMessage.Text = Sublight.Translation.ContactUs_Message
            lblOptionalEmail.Text = Sublight.Translation.ContactUs_Email_OptionalField
            myGroupBox1.Text = Sublight.Translation.ContactUs_ContactForm
            lblPreferredLanguage.Text = Sublight.Translation.ContactUs_Message_PreferredLanguage
            ttHelp.Title = Sublight.Translation.ContactUs_ContactForm
            ttHelp.Text = Sublight.Translation.Search_Toolbar_ContactUs_Tooltip
        End Sub

        Private Sub InitializeComponent()
            myGroupBox1 = New Sublight.Controls.MyGroupBox
            lblPreferredLanguage = New System.Windows.Forms.Label
            ttHelp = New Sublight.Controls.ToolTip
            btnClear = New Sublight.Controls.Button.Button
            btnSend = New Sublight.Controls.Button.Button
            lblOptionalEmail = New System.Windows.Forms.Label
            txtEmail = New Sublight.Controls.MyTextBox
            lblEmail = New System.Windows.Forms.Label
            lblMessage = New System.Windows.Forms.Label
            txtMessage = New Sublight.Controls.MyTextBox
            txtSubject = New Sublight.Controls.MyTextBox
            lblSubject = New System.Windows.Forms.Label
            myGroupBox1.SuspendLayout()
            SuspendLayout()
            myGroupBox1.Controls.Add(lblPreferredLanguage)
            myGroupBox1.Controls.Add(ttHelp)
            myGroupBox1.Controls.Add(btnClear)
            myGroupBox1.Controls.Add(btnSend)
            myGroupBox1.Controls.Add(lblOptionalEmail)
            myGroupBox1.Controls.Add(txtEmail)
            myGroupBox1.Controls.Add(lblEmail)
            myGroupBox1.Controls.Add(lblMessage)
            myGroupBox1.Controls.Add(txtMessage)
            myGroupBox1.Controls.Add(txtSubject)
            myGroupBox1.Controls.Add(lblSubject)
            myGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
            myGroupBox1.DrawTextBackground = True
            myGroupBox1.Location = New System.Drawing.Point(0, 0)
            myGroupBox1.Name = "myGroupBox1?"
            myGroupBox1.Size = New System.Drawing.Size(910, 239)
            myGroupBox1.TabIndex = 145
            myGroupBox1.TabStop = False
            myGroupBox1.Text = "myGroupBox1?"
            lblPreferredLanguage.AutoSize = True
            lblPreferredLanguage.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblPreferredLanguage.Location = New System.Drawing.Point(518, 83)
            lblPreferredLanguage.Name = "lblPreferredLanguage?"
            lblPreferredLanguage.Size = New System.Drawing.Size(151, 13)
            lblPreferredLanguage.TabIndex = 155
            lblPreferredLanguage.Text = "prosimo, ce pišete v anglešcini?"
            ttHelp.AutoPopDelay = 5000
            ttHelp.BackColor = System.Drawing.Color.Transparent
            ttHelp.Location = New System.Drawing.Point(894, 16)
            ttHelp.Name = "ttHelp?"
            ttHelp.Size = New System.Drawing.Size(13, 12)
            ttHelp.TabIndex = 154
            btnClear.AutoResize = False
            btnClear.Location = New System.Drawing.Point(356, 205)
            btnClear.Name = "btnClear?"
            btnClear.Size = New System.Drawing.Size(75, 23)
            btnClear.TabIndex = 153
            btnClear.Text = "Pocisti?"
            btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnClear.UseVisualStyleBackColor = True
            AddHandler btnClear.Click, AddressOf btnClear_Click
            btnSend.AutoResize = False
            btnSend.Location = New System.Drawing.Point(437, 205)
            btnSend.Name = "btnSend?"
            btnSend.Size = New System.Drawing.Size(75, 23)
            btnSend.TabIndex = 152
            btnSend.Text = "Pošlji?"
            btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            btnSend.UseVisualStyleBackColor = True
            AddHandler btnSend.Click, AddressOf btnSend_Click
            lblOptionalEmail.AutoSize = True
            lblOptionalEmail.ForeColor = System.Drawing.Color.FromArgb(0, 21, 110)
            lblOptionalEmail.Location = New System.Drawing.Point(336, 55)
            lblOptionalEmail.Name = "lblOptionalEmail?"
            lblOptionalEmail.Size = New System.Drawing.Size(160, 13)
            lblOptionalEmail.TabIndex = 151
            lblOptionalEmail.Text = "izpolnite samo, ce želite odgovor?"
            txtEmail.EnableDisableColor = True
            txtEmail.Location = New System.Drawing.Point(143, 51)
            txtEmail.Name = "txtEmail?"
            txtEmail.Size = New System.Drawing.Size(187, 20)
            txtEmail.TabIndex = 147
            lblEmail.AutoSize = True
            lblEmail.Location = New System.Drawing.Point(6, 55)
            lblEmail.Name = "lblEmail?"
            lblEmail.Size = New System.Drawing.Size(95, 13)
            lblEmail.TabIndex = 150
            lblEmail.Text = "Elektronska pošta:?"
            lblMessage.AutoSize = True
            lblMessage.Location = New System.Drawing.Point(6, 83)
            lblMessage.Name = "lblMessage?"
            lblMessage.Size = New System.Drawing.Size(54, 13)
            lblMessage.TabIndex = 149
            lblMessage.Text = "Sporocilo:?"
            txtMessage.EnableDisableColor = True
            txtMessage.Location = New System.Drawing.Point(143, 83)
            txtMessage.Multiline = True
            txtMessage.Name = "txtMessage?"
            txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            txtMessage.Size = New System.Drawing.Size(369, 110)
            txtMessage.TabIndex = 148
            txtSubject.EnableDisableColor = True
            txtSubject.Location = New System.Drawing.Point(143, 19)
            txtSubject.Name = "txtSubject?"
            txtSubject.Size = New System.Drawing.Size(369, 20)
            txtSubject.TabIndex = 145
            lblSubject.AutoSize = True
            lblSubject.Location = New System.Drawing.Point(6, 23)
            lblSubject.Name = "lblSubject?"
            lblSubject.Size = New System.Drawing.Size(47, 13)
            lblSubject.TabIndex = 146
            lblSubject.Text = "Zadeva:?"
            AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(myGroupBox1)
            Name = "ProfileContactUs?"
            Size = New System.Drawing.Size(910, 371)
            AddHandler Load, AddressOf ProfileContactUs_Load
            myGroupBox1.ResumeLayout(False)
            myGroupBox1.PerformLayout()
            ResumeLayout(False)
        End Sub

        Private Sub ProfileContactUs_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub RepositionGroupBoxTooltipsIfNecessary()
            Dim i1 As Integer = Width - 18
            If ttHelp.Left <> i1 Then
                ttHelp.Left = i1
            End If
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not (components) Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnLayout(ByVal e As System.Windows.Forms.LayoutEventArgs)
            MyBase.OnLayout(e)
            RepositionGroupBoxTooltipsIfNecessary()
        End Sub

    End Class ' class ProfileContactUs

End Namespace

