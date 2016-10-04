using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ShowSounds
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Button btnQuit;
      private System.Windows.Forms.CheckBox cbSound;
      private System.Windows.Forms.CheckBox cbSoundGenerate;
      private System.Windows.Forms.CheckBox cbSoundDisplay;
      private System.Windows.Forms.ToolTip ToolTip;
      private PlaySound.PlaySound MySound;
      private System.ComponentModel.IContainer components;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
         this.btnTest = new System.Windows.Forms.Button();
         this.btnQuit = new System.Windows.Forms.Button();
         this.cbSound = new System.Windows.Forms.CheckBox();
         this.cbSoundGenerate = new System.Windows.Forms.CheckBox();
         this.cbSoundDisplay = new System.Windows.Forms.CheckBox();
         this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
         this.MySound = new PlaySound.PlaySound();
         this.SuspendLayout();
         // 
         // btnTest
         // 
         this.btnTest.AccessibleDescription = "This button starts the test function of the application.";
         this.btnTest.AccessibleName = "Application Test";
         this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnTest.Location = new System.Drawing.Point(208, 8);
         this.btnTest.Name = "btnTest";
         this.btnTest.TabIndex = 2;
         this.btnTest.Text = "&Test";
         this.ToolTip.SetToolTip(this.btnTest, "This button starts the test function of the application.");
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
         this.btnQuit.TabIndex = 3;
         this.btnQuit.Text = "&Quit";
         this.ToolTip.SetToolTip(this.btnQuit, "This button exits the application.");
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         // 
         // cbSound
         // 
         this.cbSound.AccessibleDescription = "Tells system to play a sound.";
         this.cbSound.AccessibleName = "Play Sound Selection";
         this.cbSound.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
         this.cbSound.Checked = true;
         this.cbSound.CheckState = System.Windows.Forms.CheckState.Checked;
         this.cbSound.Location = new System.Drawing.Point(8, 16);
         this.cbSound.Name = "cbSound";
         this.cbSound.Size = new System.Drawing.Size(170, 24);
         this.cbSound.TabIndex = 4;
         this.cbSound.Text = "&Play the Sound";
         this.ToolTip.SetToolTip(this.cbSound, "Tells system to play a sound.");
         // 
         // cbSoundGenerate
         // 
         this.cbSoundGenerate.AccessibleDescription = "Instruct the application to use the event handler for sound generation.";
         this.cbSoundGenerate.AccessibleName = "Select Sound Generate Event";
         this.cbSoundGenerate.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
         this.cbSoundGenerate.Location = new System.Drawing.Point(8, 40);
         this.cbSoundGenerate.Name = "cbSoundGenerate";
         this.cbSoundGenerate.Size = new System.Drawing.Size(170, 24);
         this.cbSoundGenerate.TabIndex = 5;
         this.cbSoundGenerate.Text = "Sound&Generate Event";
         this.ToolTip.SetToolTip(this.cbSoundGenerate, "Instruct the application to use the event handler for sound generation.");
         // 
         // cbSoundDisplay
         // 
         this.cbSoundDisplay.AccessibleDescription = "Instruct the application to use the event handler for sound description.";
         this.cbSoundDisplay.AccessibleName = "Select Sound Display Event";
         this.cbSoundDisplay.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
         this.cbSoundDisplay.Location = new System.Drawing.Point(8, 64);
         this.cbSoundDisplay.Name = "cbSoundDisplay";
         this.cbSoundDisplay.Size = new System.Drawing.Size(170, 24);
         this.cbSoundDisplay.TabIndex = 6;
         this.cbSoundDisplay.Text = "Sound&Display Event";
         this.ToolTip.SetToolTip(this.cbSoundDisplay, "Instruct the application to use the event handler for sound description.");
         // 
         // ToolTip
         // 
         this.ToolTip.AutomaticDelay = 300;
         this.ToolTip.AutoPopDelay = 7000;
         this.ToolTip.InitialDelay = 300;
         this.ToolTip.ReshowDelay = 60;
         // 
         // MySound
         // 
         this.MySound.AutomaticDelay = 300;
         this.MySound.AutoPopDelay = 7000;
         this.MySound.MakeSound = true;
         this.MySound.ShowSoundsDescription = "The system plays the sound of bells.";
         this.MySound.SoundFileName = "Bells.wav";
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnTest;
         this.AccessibleDescription = "This application provides support for the PlaySound component.";
         this.AccessibleName = "ShowSounds Demonstration";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnQuit;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.cbSoundDisplay);
         this.Controls.Add(this.cbSoundGenerate);
         this.Controls.Add(this.cbSound);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.btnQuit);
         this.Name = "frmMain";
         this.Text = "ShowSounds Demonstration";
         this.ToolTip.SetToolTip(this, "This application provides support for the PlaySound component.");
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

      private void btnTest_Click(object sender, System.EventArgs e)
      {
         // Check to see if the user wants to play a sound.
         if (cbSound.Checked)
            MySound.MakeSound = true;
         else
            MySound.MakeSound = false;

         // Check to see if the user wants the SoundDisplayed event.
         if (cbSoundDisplay.Checked)
            MySound.SoundDisplayed += 
               new EventHandler(playSound1_SoundDisplayed);
         else
            MySound.SoundDisplayed -= 
               new EventHandler(playSound1_SoundDisplayed);

         // Check to see if the user wans the SoundGenerated event.
         if (cbSoundGenerate.Checked)
            MySound.SoundGenerated +=
               new EventHandler(playSound1_SoundGenerated);
         else
            MySound.SoundGenerated -= 
               new EventHandler(playSound1_SoundGenerated);

         // Perform the sound related task.
         MySound.GenerateSound(btnTest);
      }

      private void playSound1_SoundDisplayed(object sender, System.EventArgs e)
      {
         // Display a message box.
         MessageBox.Show("Sound Displayed");
      }

      private void playSound1_SoundGenerated(object sender, System.EventArgs e)
      {
         // Display a message box.
         MessageBox.Show("Sound Generated");
      }
	}
}
