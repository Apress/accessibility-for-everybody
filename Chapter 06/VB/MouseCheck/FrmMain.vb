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
   Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
   Friend WithEvents btnTest As System.Windows.Forms.Button
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnTest = New System.Windows.Forms.Button
      Me.btnQuit = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'ToolTip
      '
      Me.ToolTip.AutomaticDelay = 300
      Me.ToolTip.AutoPopDelay = 7000
      Me.ToolTip.InitialDelay = 300
      Me.ToolTip.ReshowDelay = 60
      '
      'btnTest
      '
      Me.btnTest.AccessibleDescription = "This button starts the test function of the application."
      Me.btnTest.AccessibleName = "Application Test"
      Me.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnTest.Location = New System.Drawing.Point(208, 8)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 6
      Me.btnTest.Text = "&Test"
      Me.ToolTip.SetToolTip(Me.btnTest, "This button starts the test function of the application.")
      '
      'btnQuit
      '
      Me.btnQuit.AccessibleDescription = "This button exits the application."
      Me.btnQuit.AccessibleName = "Application Quit"
      Me.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnQuit.Location = New System.Drawing.Point(208, 40)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 7
      Me.btnQuit.Text = "&Quit"
      Me.ToolTip.SetToolTip(Me.btnQuit, "This button exits the application.")
      '
      'frmMain
      '
      Me.AcceptButton = Me.btnTest
      Me.AccessibleDescription = "This application demonstrates techniques for obtaining mouse information."
      Me.AccessibleName = "Mouse Data Demonstration"
      Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btnQuit
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.btnTest)
      Me.Controls.Add(Me.btnQuit)
      Me.Name = "frmMain"
      Me.Text = "Mouse Data Demonstration"
      Me.ToolTip.SetToolTip(Me, "This application demonstrates techniques for obtaining mouse information.")
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      ' Exit the application.
      End
   End Sub

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      Dim MouseData As StringBuilder    ' The mouse setup information.

      ' Initialize the StringBuilder.
      MouseData = New StringBuilder

      ' Check for the presence of a mouse.
      If (SystemInformation.MousePresent) Then
         ' Begin building the MouseData string.
         MouseData.Append("System includes a mouse with the " + _
                          "following characteristics:" + vbCrLf)

         ' Get the clicking information.
         MouseData.Append(vbCrLf + "Double Click Area (pixels): ")
         MouseData.Append( _
               SystemInformation.DoubleClickSize.ToString())
         MouseData.Append(vbCrLf + "Double Click Time (ms): ")
         MouseData.Append( _
            SystemInformation.DoubleClickTime.ToString())

         ' Get the mouse specific information.
         MouseData.Append(vbCrLf + vbCrLf + "Number of Mouse Buttons: ")
         MouseData.Append( _
            SystemInformation.MouseButtons.ToString())
         MouseData.Append(vbCrLf + "Are the buttons swapped? ")
         MouseData.Append( _
            SystemInformation.MouseButtonsSwapped.ToString())
         MouseData.Append(vbCrLf + vbCrLf + "Is a mouse wheel available? ")
         MouseData.Append( _
            SystemInformation.MouseWheelPresent.ToString())

         ' Display this information only for systems with
         ' mouse wheel support.
         If (SystemInformation.MouseWheelPresent) Then
            MouseData.Append(vbCrLf + "Mouse wheel scroll lines: ")
            MouseData.Append( _
               SystemInformation.MouseWheelScrollLines.ToString())
            MouseData.Append(vbCrLf + "Native mouse wheel support? ")
            MouseData.Append( _
                  SystemInformation.NativeMouseWheelSupport.ToString())
         End If

         ' Display the results.
         MessageBox.Show(MouseData.ToString(), _
                         "Mouse Access Information", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Information)

         ' If no mouse is present, display a message and exit.
      Else
         MessageBox.Show("There is no mouse connected to this system.", _
                         "No Mouse Access", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Exclamation)
      End If
   End Sub
End Class
