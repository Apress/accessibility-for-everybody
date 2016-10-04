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
      Me.btnQuit = New System.Windows.Forms.Button
      Me.btnTest = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'btnQuit
      '
      Me.btnQuit.AccessibleDescription = "Use this button to exit the application."
      Me.btnQuit.AccessibleName = "Quit Pushbutton"
      Me.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnQuit.Location = New System.Drawing.Point(208, 40)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 3
      Me.btnQuit.Text = "&Quit"
      '
      'btnTest
      '
      Me.btnTest.AccessibleDescription = "This button displays the test information."
      Me.btnTest.AccessibleName = "Test Pushbutton"
      Me.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnTest.Location = New System.Drawing.Point(208, 8)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 2
      Me.btnTest.Text = "&Test"
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.btnQuit)
      Me.Controls.Add(Me.btnTest)
      Me.Name = "frmMain"
      Me.Text = "Colors and Fonts Demonstration"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      'Exit the application.
      End
   End Sub

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      Dim DefFont As Font   ' Current font requirement.
      Dim BtnSize As Size   ' Current button size.
      Dim DlgSize As Size   ' Current dialog size.
      Dim TestLoc As Point  ' Current Test button location.
      Dim QuitLoc As Point  ' Current Quit button location.

      ' Obtain the default font for our example.
      ' Begin by determining the screen state.
      If (SystemInformation.HighContrast) Then
         DefFont = SystemInformation.MenuFont
         BtnSize = New Size(135, 42)
         DlgSize = New Size(540, 540)
         TestLoc = New Point(374, 14)
         QuitLoc = New Point(374, 72)
         ' Use the default sizes.
      Else
         DefFont = Me.Font
         BtnSize = New Size(75, 23)
         DlgSize = New Size(300, 300)
         TestLoc = New Point(208, 8)
         QuitLoc = New Point(208, 40)
      End If

      ' Modify the display fonts.
      btnTest.Font = DefFont
      btnQuit.Font = DefFont

      ' Modify the sizes.
      btnTest.Size = BtnSize
      btnQuit.Size = BtnSize
      frmMain.ActiveForm.Size = DlgSize

      ' Modify the positions.
      btnTest.Location = TestLoc
      btnQuit.Location = QuitLoc

      ' Display the information.
      MessageBox.Show("Name: " + DefFont.Name + vbCrLf + _
                      "Size: " + DefFont.SizeInPoints.ToString(), _
                      "Font Information", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub
End Class
