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
   Friend WithEvents cbSoundDisplay As System.Windows.Forms.CheckBox
   Friend WithEvents cbSoundGenerate As System.Windows.Forms.CheckBox
   Friend WithEvents cbSound As System.Windows.Forms.CheckBox
   Friend WithEvents btnTest As System.Windows.Forms.Button
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   Friend WithEvents MySound As PlaySound.PlaySound.PlaySound
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me.cbSoundDisplay = New System.Windows.Forms.CheckBox
      Me.cbSoundGenerate = New System.Windows.Forms.CheckBox
      Me.cbSound = New System.Windows.Forms.CheckBox
      Me.btnTest = New System.Windows.Forms.Button
      Me.btnQuit = New System.Windows.Forms.Button
      Me.MySound = New PlaySound.PlaySound.PlaySound
      Me.SuspendLayout()
      '
      'ToolTip
      '
      Me.ToolTip.AutomaticDelay = 300
      Me.ToolTip.AutoPopDelay = 7000
      Me.ToolTip.InitialDelay = 300
      Me.ToolTip.ReshowDelay = 60
      '
      'cbSoundDisplay
      '
      Me.cbSoundDisplay.AccessibleDescription = "Instruct the application to use the event handler for sound description."
      Me.cbSoundDisplay.AccessibleName = "Select Sound Display Event"
      Me.cbSoundDisplay.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton
      Me.cbSoundDisplay.Location = New System.Drawing.Point(8, 64)
      Me.cbSoundDisplay.Name = "cbSoundDisplay"
      Me.cbSoundDisplay.Size = New System.Drawing.Size(170, 24)
      Me.cbSoundDisplay.TabIndex = 11
      Me.cbSoundDisplay.Text = "Sound&Display Event"
      Me.ToolTip.SetToolTip(Me.cbSoundDisplay, "Instruct the application to use the event handler for sound description.")
      '
      'cbSoundGenerate
      '
      Me.cbSoundGenerate.AccessibleDescription = "Instruct the application to use the event handler for sound generation."
      Me.cbSoundGenerate.AccessibleName = "Select Sound Generate Event"
      Me.cbSoundGenerate.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton
      Me.cbSoundGenerate.Location = New System.Drawing.Point(8, 40)
      Me.cbSoundGenerate.Name = "cbSoundGenerate"
      Me.cbSoundGenerate.Size = New System.Drawing.Size(170, 24)
      Me.cbSoundGenerate.TabIndex = 10
      Me.cbSoundGenerate.Text = "Sound&Generate Event"
      Me.ToolTip.SetToolTip(Me.cbSoundGenerate, "Instruct the application to use the event handler for sound generation.")
      '
      'cbSound
      '
      Me.cbSound.AccessibleDescription = "Tells system to play a sound."
      Me.cbSound.AccessibleName = "Play Sound Selection"
      Me.cbSound.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton
      Me.cbSound.Checked = True
      Me.cbSound.CheckState = System.Windows.Forms.CheckState.Checked
      Me.cbSound.Location = New System.Drawing.Point(8, 16)
      Me.cbSound.Name = "cbSound"
      Me.cbSound.Size = New System.Drawing.Size(170, 24)
      Me.cbSound.TabIndex = 9
      Me.cbSound.Text = "&Play the Sound"
      Me.ToolTip.SetToolTip(Me.cbSound, "Tells system to play a sound.")
      '
      'btnTest
      '
      Me.btnTest.AccessibleDescription = "This button starts the test function of the application."
      Me.btnTest.AccessibleName = "Application Test"
      Me.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnTest.Location = New System.Drawing.Point(208, 8)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 7
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
      Me.btnQuit.TabIndex = 8
      Me.btnQuit.Text = "&Quit"
      Me.ToolTip.SetToolTip(Me.btnQuit, "This button exits the application.")
      '
      'MySound
      '
      Me.MySound.AutomaticDelay = 300
      Me.MySound.AutoPopDelay = 7000
      Me.MySound.MakeSound = True
      Me.MySound.ShowSoundsDescription = "The system plays the sound of bells."
      Me.MySound.SoundFileName = "BELLS.WAV"
      '
      'frmMain
      '
      Me.AcceptButton = Me.btnTest
      Me.AccessibleDescription = "This application provides support for the PlaySound component."
      Me.AccessibleName = "ShowSounds Demonstration"
      Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btnQuit
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.cbSoundDisplay)
      Me.Controls.Add(Me.cbSoundGenerate)
      Me.Controls.Add(Me.cbSound)
      Me.Controls.Add(Me.btnTest)
      Me.Controls.Add(Me.btnQuit)
      Me.Name = "frmMain"
      Me.Text = "ShowSounds Demonstration"
      Me.ToolTip.SetToolTip(Me, "This application provides support for the PlaySound component.")
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      'Exit the application.
      End
   End Sub

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      ' Check to see if the user wants to play a sound.
      If (cbSound.Checked) Then
         MySound.MakeSound = True
      Else
         MySound.MakeSound = False
      End If

      ' Check to see if the user wants the SoundDisplayed event.
      If (cbSoundDisplay.Checked) Then
         AddHandler MySound.SoundDisplayed, AddressOf MySound_SoundDisplayed
      Else
         RemoveHandler MySound.SoundDisplayed, AddressOf MySound_SoundDisplayed
      End If

      ' Check to see if the user wans the SoundGenerated event.
      If (cbSoundGenerate.Checked) Then
         AddHandler MySound.SoundGenerated, AddressOf MySound_SoundGenerated
      Else
         RemoveHandler MySound.SoundGenerated, AddressOf MySound_SoundGenerated
      End If

      ' Perform the sound related task.
      MySound.GenerateSound(btnTest)
   End Sub

   Private Sub MySound_SoundDisplayed(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Display a message box.
      MessageBox.Show("Sound Displayed")
   End Sub

   Private Sub MySound_SoundGenerated(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Display a message box.
      MessageBox.Show("Sound Generated")
   End Sub
End Class
