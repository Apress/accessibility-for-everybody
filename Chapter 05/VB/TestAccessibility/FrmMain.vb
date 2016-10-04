Imports Accessibility

Public Class frmMain
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Set the AccessibleDefaultActionDescription property
      ' values for this application.
      btnQuit.AccessibleDefaultActionDescription = _
         "Press to quit the application."
      btnTest.AccessibleDefaultActionDescription = _
         "Press to perform the application test function."
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
   Friend WithEvents toolTipData As System.Windows.Forms.ToolTip
   Friend WithEvents btnTest As System.Windows.Forms.Button
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.toolTipData = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnTest = New System.Windows.Forms.Button
      Me.btnQuit = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'toolTipData
      '
      Me.toolTipData.AutomaticDelay = 300
      Me.toolTipData.AutoPopDelay = 5000
      Me.toolTipData.InitialDelay = 300
      Me.toolTipData.ReshowDelay = 60
      '
      'btnTest
      '
      Me.btnTest.AccessibleDescription = "This button starts the test function of the application."
      Me.btnTest.AccessibleName = "Application Test"
      Me.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnTest.Location = New System.Drawing.Point(208, 8)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 2
      Me.btnTest.Text = "&Test"
      Me.toolTipData.SetToolTip(Me.btnTest, "This button starts the test function of the application.")
      '
      'btnQuit
      '
      Me.btnQuit.AccessibleDescription = "This button exits the application."
      Me.btnQuit.AccessibleName = "Application Quit"
      Me.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnQuit.Location = New System.Drawing.Point(208, 40)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 3
      Me.btnQuit.Text = "&Quit"
      Me.toolTipData.SetToolTip(Me.btnQuit, "This button exits the application.")
      '
      'frmMain
      '
      Me.AcceptButton = Me.btnTest
      Me.AccessibleDescription = "This form contains controls that demonstration how to use the Accessibility names" & _
      "pace."
      Me.AccessibleName = "Accessibility Test"
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btnQuit
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.btnTest)
      Me.Controls.Add(Me.btnQuit)
      Me.Name = "frmMain"
      Me.Text = "Accessibility Namespace Test"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      'Exit the application.
      End
   End Sub

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      ' Display a message box.
      MessageBox.Show("This is a test message.", _
                      "Test Message", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub

   Private Sub btnTest_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTest.Enter
      Dim Ctrl As Control ' Control sending information.

      ' Show the current accessibility information.
      Ctrl = sender
      MessageBox.Show("Name = " + Ctrl.AccessibleName + _
                      vbCrLf + "Role = " + Ctrl.AccessibleRole.ToString() + _
                      vbCrLf + "Description = " + Ctrl.AccessibleDescription + _
                      vbCrLf + "Default Action = " + _
                      Ctrl.AccessibleDefaultActionDescription, _
                      "Accessibility Information", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub

   Private Sub btnQuit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuit.Enter
      Dim Ctrl As Control ' Control sending information.

      ' Show the current accessibility information.
      Ctrl = sender
      MessageBox.Show("Name = " + Ctrl.AccessibleName + _
                      vbCrLf + "Role = " + Ctrl.AccessibleRole.ToString() + _
                      vbCrLf + "Description = " + Ctrl.AccessibleDescription + _
                      vbCrLf + "Default Action = " + _
                      Ctrl.AccessibleDefaultActionDescription, _
                      "Accessibility Information", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub
End Class
