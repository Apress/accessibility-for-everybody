Imports System.Text

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
   Friend WithEvents txtMessage As System.Windows.Forms.TextBox
   Friend WithEvents label1 As System.Windows.Forms.Label
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   Friend WithEvents btnTest As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.txtMessage = New System.Windows.Forms.TextBox
      Me.label1 = New System.Windows.Forms.Label
      Me.btnQuit = New System.Windows.Forms.Button
      Me.btnTest = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'txtMessage
      '
      Me.txtMessage.AccessibleDescription = "Contains the message you want to display during test."
      Me.txtMessage.AccessibleName = "Application Test Message"
      Me.txtMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
      Me.txtMessage.Location = New System.Drawing.Point(8, 32)
      Me.txtMessage.Name = "txtMessage"
      Me.txtMessage.Size = New System.Drawing.Size(176, 20)
      Me.txtMessage.TabIndex = 9
      Me.txtMessage.Text = "This is a test message box."
      '
      'label1
      '
      Me.label1.Location = New System.Drawing.Point(8, 8)
      Me.label1.Name = "label1"
      Me.label1.TabIndex = 8
      Me.label1.Text = "Test &Messsage"
      '
      'btnQuit
      '
      Me.btnQuit.AccessibleDescription = "This button lets you to exit the application."
      Me.btnQuit.AccessibleName = "Exit the Application"
      Me.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnQuit.Location = New System.Drawing.Point(208, 40)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 7
      Me.btnQuit.Text = "&Quit"
      '
      'btnTest
      '
      Me.btnTest.AccessibleDescription = "This button tests application functionality."
      Me.btnTest.AccessibleName = "Test the Application"
      Me.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnTest.Location = New System.Drawing.Point(208, 8)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 6
      Me.btnTest.Text = "&Test"
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.txtMessage)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me.btnQuit)
      Me.Controls.Add(Me.btnTest)
      Me.Name = "frmMain"
      Me.Text = "AccessibleObject Demonstration"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      'Exit the application.
      End
   End Sub

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      ' Display a message box.
      MessageBox.Show(txtMessage.Text, _
                      "Test Message", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub
   Private Sub SpecialTip(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim Ctrl As Control               ' The control in question.
      Dim AO As AccessibleObject        ' The accessibility information.
      Dim TT As ToolTip                 ' Special ToolTip
      Dim Output As StringBuilder       ' ToolTip Output String.

      ' Initialize the ToolTip.
      TT = New ToolTip
      TT.AutoPopDelay = 7000
      TT.AutomaticDelay = 300

      ' Get the sender information.
      Ctrl = sender

      ' Obtain access to the accessibility information.
      AO = Ctrl.AccessibilityObject

      ' Create the output string.
      Output = New StringBuilder
      Output.Append("Name: ")
      Output.Append(AO.Name)
      Output.Append(vbCrLf + "Role: ")
      Output.Append(AO.Role)
      Output.Append(vbCrLf + "Description: ")
      Output.Append(AO.Description)
      Output.Append(vbCrLf + "Default Action: ")
      If (AO.DefaultAction = Nothing) Then
         Output.Append("None")
      Else
         Output.Append(AO.DefaultAction)
         Output.Append(vbCrLf + "Keyboard Shortcut: ")
      End If
      If (AO.KeyboardShortcut = Nothing) Then
         Output.Append("None")
      Else
         Output.Append(AO.KeyboardShortcut)
         Output.Append(vbCrLf + "State: ")
         Output.Append(AO.State)
         Output.Append(vbCrLf + "Value: ")
      End If
      If (AO.Value = Nothing) Then
         Output.Append("None")
      Else
         Output.Append(AO.Value)
      End If

      ' Display the information on screen.
      TT.SetToolTip(Ctrl, Output.ToString())
      TT.Active = True
   End Sub

   Private Sub btnQuit_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuit.MouseHover
      SpecialTip(btnQuit, New System.EventArgs)
   End Sub

   Private Sub btnTest_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTest.MouseHover
      SpecialTip(btnTest, New System.EventArgs)
   End Sub

   Private Sub txtMessage_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMessage.MouseHover
      SpecialTip(txtMessage, New System.EventArgs)
   End Sub
End Class
