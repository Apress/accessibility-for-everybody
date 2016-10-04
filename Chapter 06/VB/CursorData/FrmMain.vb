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
   Friend WithEvents btnGetCursor As System.Windows.Forms.Button
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnGetCursor = New System.Windows.Forms.Button
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
      'btnGetCursor
      '
      Me.btnGetCursor.AccessibleDescription = "This button tests the Get Cursor feature of the application."
      Me.btnGetCursor.AccessibleName = "Get Cursor Test Button"
      Me.btnGetCursor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnGetCursor.Location = New System.Drawing.Point(208, 8)
      Me.btnGetCursor.Name = "btnGetCursor"
      Me.btnGetCursor.TabIndex = 8
      Me.btnGetCursor.Text = "&Get Cursor"
      Me.ToolTip.SetToolTip(Me.btnGetCursor, "This button tests the Get Cursor feature of the application.")
      '
      'btnQuit
      '
      Me.btnQuit.AccessibleDescription = "This button exits the application."
      Me.btnQuit.AccessibleName = "Application Quit"
      Me.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnQuit.Location = New System.Drawing.Point(208, 40)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 9
      Me.btnQuit.Text = "&Quit"
      Me.ToolTip.SetToolTip(Me.btnQuit, "This button exits the application.")
      '
      'frmMain
      '
      Me.AcceptButton = Me.btnGetCursor
      Me.AccessibleDescription = "This application shows how to obtain cursor information."
      Me.AccessibleName = "Cursor Statistics Demonstration"
      Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btnQuit
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.btnGetCursor)
      Me.Controls.Add(Me.btnQuit)
      Me.Name = "frmMain"
      Me.Text = "Cursor Statistics Demonstration"
      Me.ToolTip.SetToolTip(Me, "This application shows how to obtain cursor information.")
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      ' Exit the application.
      End
   End Sub

   Private Sub btnGetCursor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCursor.Click
      Dim CursorData As StringBuilder ' Cursor information.

      ' Initialize the StringBuilder
      CursorData = New StringBuilder

      ' Get the cursor information.
      CursorData.Append("The current cursor size is:" + vbCrLf + vbCrLf + "Height: ")
      CursorData.Append(SystemInformation.CursorSize.Height.ToString())
      CursorData.Append(vbCrLf + "Width: ")
      CursorData.Append(SystemInformation.CursorSize.Width.ToString())

      ' Display the information.
      MessageBox.Show(CursorData.ToString(), _
                      "Cursor Data", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)

   End Sub
End Class
