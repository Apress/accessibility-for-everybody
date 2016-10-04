Public Class frmMain
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      Dim AniList As IEnumerator   ' List of animations.
      Dim Voice As String          ' The current voice.
      Dim WinFolder As String      ' Windows Folder

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Obtain the Windows folder location.
      WinFolder = _
         Environment.SystemDirectory.Substring( _
            0, _
            Environment.SystemDirectory.IndexOf("System32"))

      ' Try loading a character.
      TestAgent.Characters.Load( _
         "Merlin", _
         WinFolder + "MSAgent\Chars\Merlin.acs")

      ' Make the character the current speaker.
      CurrentSpeaker = TestAgent.Characters("Merlin")

      ' Get the animation list for this character.
      AniList = TestAgent.Characters("Merlin").AnimationNames.GetEnumerator()

      ' Load the animation list into the CurrentSpeaker command
      ' list.
      While (AniList.MoveNext())
         Voice = AniList.Current
         Voice = Voice.Replace("_", "underscore")
         CurrentSpeaker.Commands.Add(AniList.Current, _
                                     AniList.Current, _
                                     Voice, _
                                     True, _
                                     False)
      End While
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
   Friend WithEvents ApplicationTT As System.Windows.Forms.ToolTip
   Friend WithEvents btnTest As System.Windows.Forms.Button
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   Friend WithEvents TestAgent As AxAgentObjects.AxAgent
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
      Me.ApplicationTT = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnTest = New System.Windows.Forms.Button
      Me.btnQuit = New System.Windows.Forms.Button
      Me.TestAgent = New AxAgentObjects.AxAgent
      CType(Me.TestAgent, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ApplicationTT
      '
      Me.ApplicationTT.AutomaticDelay = 300
      Me.ApplicationTT.AutoPopDelay = 7000
      Me.ApplicationTT.InitialDelay = 300
      Me.ApplicationTT.ReshowDelay = 60
      '
      'btnTest
      '
      Me.btnTest.AccessibleDescription = "This button starts the test function of the application."
      Me.btnTest.AccessibleName = "Application Test"
      Me.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnTest.Location = New System.Drawing.Point(208, 8)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 5
      Me.btnTest.Text = "&Test"
      Me.ApplicationTT.SetToolTip(Me.btnTest, "This button starts the test function of the application.")
      '
      'btnQuit
      '
      Me.btnQuit.AccessibleDescription = "This button exits the application."
      Me.btnQuit.AccessibleName = "Application Quit"
      Me.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnQuit.Location = New System.Drawing.Point(208, 40)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 6
      Me.btnQuit.Text = "&Quit"
      Me.ApplicationTT.SetToolTip(Me.btnQuit, "This button exits the application.")
      '
      'TestAgent
      '
      Me.TestAgent.AccessibleDescription = "This is the Microsoft Agent control for this application."
      Me.TestAgent.AccessibleName = "Test Microsoft Agent"
      Me.TestAgent.Enabled = True
      Me.TestAgent.Location = New System.Drawing.Point(256, 224)
      Me.TestAgent.Name = "TestAgent"
      Me.TestAgent.OcxState = CType(resources.GetObject("TestAgent.OcxState"), System.Windows.Forms.AxHost.State)
      Me.TestAgent.Size = New System.Drawing.Size(32, 32)
      Me.TestAgent.TabIndex = 8
      Me.ApplicationTT.SetToolTip(Me.TestAgent, "This is the Microsoft Agent control for this application.")
      '
      'frmMain
      '
      Me.AcceptButton = Me.btnTest
      Me.AccessibleDescription = "This application demonstrates the techniques needed to use Microsoft Agent."
      Me.AccessibleName = "Microsoft Agent Example"
      Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btnQuit
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.TestAgent)
      Me.Controls.Add(Me.btnTest)
      Me.Controls.Add(Me.btnQuit)
      Me.Name = "frmMain"
      Me.Text = "Microsoft Agent Example"
      Me.ApplicationTT.SetToolTip(Me, "This application demonstrates the techniques needed to use Microsoft Agent.")
      CType(Me.TestAgent, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      'Exit the application.
      End
   End Sub

   ' Create a speaker object for MS Agent.
   Private CurrentSpeaker As AgentObjects.IAgentCtlCharacter

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      ' Display the speaker.
      CurrentSpeaker.Show(0)

      ' Move to the center of the display.
      CurrentSpeaker.MoveTo( _
         Convert.ToInt16(SystemInformation.WorkingArea.Width / 2), _
         Convert.ToInt16(SystemInformation.WorkingArea.Height / 2), _
         100)

      ' Greet the user.
      CurrentSpeaker.Play("Announce")
      CurrentSpeaker.Play("RestPose")
      CurrentSpeaker.Speak("\map=" + Chr(34) + _
                           "What you hear is not what you see!" + Chr(34) + _
                           "=" + Chr(34) + "Hello World" + Chr(34) + "\", "")
      CurrentSpeaker.Play("Greet")

      ' Tell the character to pull rabbit from hat.
      CurrentSpeaker.Play("RestPose")
      CurrentSpeaker.Speak("Want to see me pull a rabbit from my hat?", _
                              "")
      CurrentSpeaker.Play("DoMagic1")
      CurrentSpeaker.Play("DoMagic2")

      ' The the character to express surprise that the user doesn't
      ' want to see the magic trick.
      CurrentSpeaker.Play("Surprised")
      CurrentSpeaker.Play("Confused")
      CurrentSpeaker.Play("RestPose")
      CurrentSpeaker.Speak("That trick never works!", "")
      CurrentSpeaker.Play("Sad")

      ' Goodbye.
      CurrentSpeaker.Play("RestPose")
      CurrentSpeaker.Speak("Goodbye", "")
      CurrentSpeaker.Play("Wave")

      ' Hide the character.
      CurrentSpeaker.Hide(0)
   End Sub
End Class
