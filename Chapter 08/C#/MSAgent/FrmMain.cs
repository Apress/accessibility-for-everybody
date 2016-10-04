using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MSAgent
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Button btnQuit;
      private AxAgentObjects.AxAgent TestAgent;
      private System.Windows.Forms.ToolTip ApplicationTT;
      private System.ComponentModel.IContainer components;

		public frmMain()
		{
         IEnumerator AniList;    // List of animations.
         String      Voice;      // The current voice.
         String      WinFolder;  // Windows Folder

			// Required for Windows Form Designer support
			InitializeComponent();

         // Obtain the Windows folder location.
         WinFolder = 
            Environment.SystemDirectory.Substring(
               0, 
               Environment.SystemDirectory.IndexOf("System32"));

         // Try loading a character.
         TestAgent.Characters.Load(
            "Merlin", 
            @WinFolder + @"MSAgent\Chars\Merlin.acs");

         // Make the character the current speaker.
         CurrentSpeaker = TestAgent.Characters["Merlin"];

         // Get the animation list for this character.
         AniList = TestAgent.Characters["Merlin"].AnimationNames.GetEnumerator();

         // Load the animation list into the CurrentSpeaker command
         // list.
         while (AniList.MoveNext())
         {
            Voice = (String)AniList.Current;
            Voice = Voice.Replace("_", "underscore");
            CurrentSpeaker.Commands.Add((String)AniList.Current,
                                        AniList.Current,
                                        Voice,
                                        true,
                                        false);
         }
      }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.components = new System.ComponentModel.Container();
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
         this.btnTest = new System.Windows.Forms.Button();
         this.btnQuit = new System.Windows.Forms.Button();
         this.TestAgent = new AxAgentObjects.AxAgent();
         this.ApplicationTT = new System.Windows.Forms.ToolTip(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.TestAgent)).BeginInit();
         this.SuspendLayout();
         // 
         // btnTest
         // 
         this.btnTest.AccessibleDescription = "This button starts the test function of the application.";
         this.btnTest.AccessibleName = "Application Test";
         this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnTest.Location = new System.Drawing.Point(208, 8);
         this.btnTest.Name = "btnTest";
         this.btnTest.TabIndex = 3;
         this.btnTest.Text = "&Test";
         this.ApplicationTT.SetToolTip(this.btnTest, "This button starts the test function of the application.");
         this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
         // 
         // btnQuit
         // 
         this.btnQuit.AccessibleDescription = "This button exits the application.";
         this.btnQuit.AccessibleName = "Application Quit";
         this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnQuit.Location = new System.Drawing.Point(208, 40);
         this.btnQuit.Name = "btnQuit";
         this.btnQuit.TabIndex = 4;
         this.btnQuit.Text = "&Quit";
         this.ApplicationTT.SetToolTip(this.btnQuit, "This button exits the application.");
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         // 
         // TestAgent
         // 
         this.TestAgent.AccessibleDescription = "This is the Microsoft Agent control for this application.";
         this.TestAgent.AccessibleName = "Test Microsoft Agent";
         this.TestAgent.Enabled = true;
         this.TestAgent.Location = new System.Drawing.Point(248, 224);
         this.TestAgent.Name = "TestAgent";
         this.TestAgent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TestAgent.OcxState")));
         this.TestAgent.Size = new System.Drawing.Size(32, 32);
         this.TestAgent.TabIndex = 5;
         this.ApplicationTT.SetToolTip(this.TestAgent, "This is the Microsoft Agent control for this application.");
         // 
         // ApplicationTT
         // 
         this.ApplicationTT.AutomaticDelay = 300;
         this.ApplicationTT.AutoPopDelay = 7000;
         this.ApplicationTT.InitialDelay = 300;
         this.ApplicationTT.ReshowDelay = 60;
         // 
         // frmMain
         // 
         this.AccessibleDescription = "This application demonstrates the techniques needed to use Microsoft Agent.";
         this.AccessibleName = "Microsoft Agent Example";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.TestAgent);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.btnQuit);
         this.Name = "frmMain";
         this.Text = "Microsoft Agent Example";
         this.ApplicationTT.SetToolTip(this, "This application demonstrates the techniques needed to use Microsoft Agent.");
         ((System.ComponentModel.ISupportInitialize)(this.TestAgent)).EndInit();
         this.ResumeLayout(false);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

      private void btnQuit_Click(object sender, System.EventArgs e)
      {
         // Exit the application.
         Close();
      }

      // Create a speaker object for MS Agent.
      AgentObjects.IAgentCtlCharacter  CurrentSpeaker;

      private void btnTest_Click(object sender, System.EventArgs e)
      {
         // Display the speaker.
         CurrentSpeaker.Show(0);

         // Move to the center of the display.
         CurrentSpeaker.MoveTo(
            Convert.ToInt16(SystemInformation.WorkingArea.Width/2), 
            Convert.ToInt16(SystemInformation.WorkingArea.Height/2), 
            100);
   
         // Greet the user.
         CurrentSpeaker.Play("Announce");
         CurrentSpeaker.Play("RestPose");
         CurrentSpeaker.Speak("\\map=\"What you hear is not what you " +
                              "see!\"=\"Hello World\"\\", "");
         CurrentSpeaker.Play("Greet");

         // Tell the character to pull rabbit from hat.
         CurrentSpeaker.Play("RestPose");
         CurrentSpeaker.Speak("Want to see me pull a rabbit from my hat?",
                              "");
         CurrentSpeaker.Play("DoMagic1");
         CurrentSpeaker.Play("DoMagic2");

         // The the character to express surprise that the user doesn't
         // want to see the magic trick.
         CurrentSpeaker.Play("Surprised");
         CurrentSpeaker.Play("Confused");
         CurrentSpeaker.Play("RestPose");
         CurrentSpeaker.Speak("That trick never works!", "");
         CurrentSpeaker.Play("Sad");

         // Goodbye.
         CurrentSpeaker.Play("RestPose");
         CurrentSpeaker.Speak("Goodbye", "");
         CurrentSpeaker.Play("Wave");

         // Hide the character.
         CurrentSpeaker.Hide(0);
      }
	}
}
