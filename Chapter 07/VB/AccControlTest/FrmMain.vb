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
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   Friend WithEvents btnStart As System.Windows.Forms.Button
   Friend WithEvents btnTimer As AccControl.AccControl.TimerButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.btnTimer = New AccControl.AccControl.TimerButton
      Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnQuit = New System.Windows.Forms.Button
      Me.btnStart = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'btnTimer
      '
      Me.btnTimer.AccessibleDescription = "This button tests the TimerButton control."
      Me.btnTimer.AccessibleName = "TimerButton Test"
      Me.btnTimer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnTimer.CountdownEnabled = True
      Me.btnTimer.Location = New System.Drawing.Point(208, 40)
      Me.btnTimer.Name = "btnTimer"
      Me.btnTimer.NoMoreTimeMenu = False
      Me.btnTimer.TabIndex = 1
      Me.btnTimer.Text = "&Test"
      Me.btnTimer.TimerInterval = 15
      Me.ToolTip.SetToolTip(Me.btnTimer, "This button tests the TimerButton control.")
      '
      'ToolTip
      '
      Me.ToolTip.AutoPopDelay = 7000
      Me.ToolTip.InitialDelay = 500
      Me.ToolTip.ReshowDelay = 100
      '
      'btnQuit
      '
      Me.btnQuit.AccessibleDescription = "This button exits the application."
      Me.btnQuit.AccessibleName = "Application Exit"
      Me.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnQuit.Location = New System.Drawing.Point(208, 72)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 2
      Me.btnQuit.Text = "&Quit"
      Me.ToolTip.SetToolTip(Me.btnQuit, "This button exits the application.")
      '
      'btnStart
      '
      Me.btnStart.AccessibleDescription = "This button starts the timer."
      Me.btnStart.AccessibleName = "Timer Start"
      Me.btnStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnStart.Location = New System.Drawing.Point(208, 8)
      Me.btnStart.Name = "btnStart"
      Me.btnStart.TabIndex = 0
      Me.btnStart.Text = "&Start Timer"
      Me.ToolTip.SetToolTip(Me.btnStart, "This button starts the timer.")
      '
      'frmMain
      '
      Me.AcceptButton = Me.btnStart
      Me.AccessibleDescription = "This application tests the functionality of the TimerButton control."
      Me.AccessibleName = "Accessible Control Test"
      Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btnQuit
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.btnQuit)
      Me.Controls.Add(Me.btnStart)
      Me.Controls.Add(Me.btnTimer)
      Me.Name = "frmMain"
      Me.Text = "Accessible Control Test"
      Me.ToolTip.SetToolTip(Me, "This application tests the functionality of the TimerButton control.")
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      ' Exit the application.
      End
   End Sub

   Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
      btnTimer.TimerStart(True)
   End Sub

   Private Sub btnTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimer.Click
      ' Turn the timer off.
      If (btnTimer.TimerStarted) Then
         btnTimer.TimerStart(False)

         ' Display a message box.
         If (btnTimer.AutoClick) Then
            MessageBox.Show("The button automatically clicked", _
                            "Click Event", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
         Else
            MessageBox.Show("The user clicked the button.", _
                            "Click Event", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
         End If
      End If

      ' Reset the AutoClick property.
      btnTimer.AutoClickReset()
   End Sub
End Class
