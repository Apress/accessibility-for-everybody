Public Class frmMain
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents ControlHelp As System.Windows.Forms.HelpProvider
   Friend WithEvents ControlToolTip As System.Windows.Forms.ToolTip
   Friend WithEvents txtMessage As System.Windows.Forms.TextBox
   Friend WithEvents label1 As System.Windows.Forms.Label
   Friend WithEvents btnTest As System.Windows.Forms.Button
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.ControlHelp = New System.Windows.Forms.HelpProvider
      Me.ControlToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me.txtMessage = New System.Windows.Forms.TextBox
      Me.label1 = New System.Windows.Forms.Label
      Me.btnTest = New System.Windows.Forms.Button
      Me.btnQuit = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'ControlHelp
      '
      Me.ControlHelp.HelpNamespace = "D:\0125 - Source Code\Chapter 07\HelpFiles\ContextHelp.chm"
      '
      'txtMessage
      '
      Me.txtMessage.AccessibleDescription = "Contains the test message that you want to display."
      Me.txtMessage.AccessibleName = "Test Message Entry"
      Me.txtMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
      Me.ControlHelp.SetHelpKeyword(Me.txtMessage, "Test Message Field")
      Me.ControlHelp.SetHelpNavigator(Me.txtMessage, System.Windows.Forms.HelpNavigator.Index)
      Me.ControlHelp.SetHelpString(Me.txtMessage, "This is the Test Message data field. It contains the test message displayed when " & _
      "you click the Test button.")
      Me.txtMessage.Location = New System.Drawing.Point(8, 32)
      Me.txtMessage.Name = "txtMessage"
      Me.ControlHelp.SetShowHelp(Me.txtMessage, True)
      Me.txtMessage.Size = New System.Drawing.Size(168, 20)
      Me.txtMessage.TabIndex = 4
      Me.txtMessage.Text = "This is a test message."
      Me.ControlToolTip.SetToolTip(Me.txtMessage, "Contains the test message that you want to display.")
      '
      'label1
      '
      Me.label1.Location = New System.Drawing.Point(8, 8)
      Me.label1.Name = "label1"
      Me.label1.TabIndex = 3
      Me.label1.Text = "Test &Message"
      '
      'btnTest
      '
      Me.btnTest.AccessibleDescription = "This button starts the test function of the application."
      Me.btnTest.AccessibleName = "Application Test"
      Me.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.ControlHelp.SetHelpKeyword(Me.btnTest, "Test Button")
      Me.ControlHelp.SetHelpNavigator(Me.btnTest, System.Windows.Forms.HelpNavigator.Index)
      Me.ControlHelp.SetHelpString(Me.btnTest, "This is the Test button. You use it to test the application. Modify the Test Mess" & _
      "age data field to change the message.")
      Me.btnTest.Location = New System.Drawing.Point(208, 8)
      Me.btnTest.Name = "btnTest"
      Me.ControlHelp.SetShowHelp(Me.btnTest, True)
      Me.btnTest.TabIndex = 5
      Me.btnTest.Text = "&Test"
      Me.ControlToolTip.SetToolTip(Me.btnTest, "This button starts the test function of the application.")
      '
      'btnQuit
      '
      Me.btnQuit.AccessibleDescription = "This button exits the application."
      Me.btnQuit.AccessibleName = "Application Quit"
      Me.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.ControlHelp.SetHelpKeyword(Me.btnQuit, "Quit Button")
      Me.ControlHelp.SetHelpNavigator(Me.btnQuit, System.Windows.Forms.HelpNavigator.Index)
      Me.ControlHelp.SetHelpString(Me.btnQuit, "This is the Quit button. You use it to exit the application.")
      Me.btnQuit.Location = New System.Drawing.Point(208, 40)
      Me.btnQuit.Name = "btnQuit"
      Me.ControlHelp.SetShowHelp(Me.btnQuit, True)
      Me.btnQuit.TabIndex = 6
      Me.btnQuit.Text = "&Quit"
      Me.ControlToolTip.SetToolTip(Me.btnQuit, "This button exits the application.")
      '
      'frmMain
      '
      Me.AcceptButton = Me.btnTest
      Me.AccessibleDescription = "This application demonstrates the use of context sensitive help."
      Me.AccessibleName = "Context Sensitive Help Demonstration"
      Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btnQuit
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.txtMessage)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me.btnTest)
      Me.Controls.Add(Me.btnQuit)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.HelpButton = True
      Me.ControlHelp.SetHelpKeyword(Me, "Overview")
      Me.ControlHelp.SetHelpString(Me, "Overview")
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmMain"
      Me.ControlHelp.SetShowHelp(Me, True)
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      ' Exit the application.
      End
   End Sub

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      ' Display the message box.
      MessageBox.Show(txtMessage.Text, _
                      "Test Message", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub
End Class
