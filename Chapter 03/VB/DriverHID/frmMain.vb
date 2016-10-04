Imports System.Runtime.InteropServices

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
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   Friend WithEvents btnTest As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.btnQuit = New System.Windows.Forms.Button()
      Me.btnTest = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'btnQuit
      '
      Me.btnQuit.Location = New System.Drawing.Point(208, 8)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 0
      Me.btnQuit.Text = "Quit"
      '
      'btnTest
      '
      Me.btnTest.Location = New System.Drawing.Point(208, 40)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 1
      Me.btnTest.Text = "Test"
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnTest, Me.btnQuit})
      Me.Name = "frmMain"
      Me.Text = "Checking HIDs Using a Driver"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      'Exit the application
      End
   End Sub

   'This function obtains the GUID of the top level HID devices.
   <DllImport("HID.DLL", CharSet:=CharSet.Auto, SetLastError:=True)> _
   Public Shared Sub HidD_GetHidGuid(<Out()> ByRef HidGuid As Guid)
   End Sub

   Private Sub btnTest_Click(ByVal sender As System.Object, _
                             ByVal e As System.EventArgs) Handles btnTest.Click
      Dim HidGuid As Guid  'The top level GUID

      'Get the HID GUID and display it.
      HidD_GetHidGuid(HidGuid)
      MessageBox.Show("The HID GUID is: " + HidGuid.ToString(), _
                      "Application Output", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub
End Class
