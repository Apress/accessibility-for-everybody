using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AccControlTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button btnStart;
      private System.Windows.Forms.Button btnQuit;
      private AccControl.TimerButton btnTimer;
      private System.Windows.Forms.ToolTip ToolTip;
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
         this.btnStart = new System.Windows.Forms.Button();
         this.btnQuit = new System.Windows.Forms.Button();
         this.btnTimer = new AccControl.TimerButton();
         this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
         this.SuspendLayout();
         // 
         // btnStart
         // 
         this.btnStart.AccessibleDescription = "This button starts the timer.";
         this.btnStart.AccessibleName = "Timer Start";
         this.btnStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnStart.Location = new System.Drawing.Point(208, 8);
         this.btnStart.Name = "btnStart";
         this.btnStart.TabIndex = 0;
         this.btnStart.Text = "&Start Timer";
         this.ToolTip.SetToolTip(this.btnStart, "This button starts the timer.");
         this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
         // 
         // btnQuit
         // 
         this.btnQuit.AccessibleDescription = "This button exits the application.";
         this.btnQuit.AccessibleName = "Application Exit";
         this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnQuit.Location = new System.Drawing.Point(208, 72);
         this.btnQuit.Name = "btnQuit";
         this.btnQuit.TabIndex = 2;
         this.btnQuit.Text = "&Quit";
         this.ToolTip.SetToolTip(this.btnQuit, "This button exits the application.");
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         // 
         // btnTimer
         // 
         this.btnTimer.AccessibleDescription = "This button tests the TimerButton control.";
         this.btnTimer.AccessibleName = "TimerButton Test";
         this.btnTimer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnTimer.CountdownEnabled = true;
         this.btnTimer.Location = new System.Drawing.Point(208, 40);
         this.btnTimer.Name = "btnTimer";
         this.btnTimer.NoMoreTimeMenu = false;
         this.btnTimer.TabIndex = 1;
         this.btnTimer.Text = "&Test";
         this.btnTimer.TimerInterval = 15;
         this.ToolTip.SetToolTip(this.btnTimer, "This button tests the TimerButton control.");
         this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
         // 
         // ToolTip
         // 
         this.ToolTip.AutoPopDelay = 7000;
         this.ToolTip.InitialDelay = 500;
         this.ToolTip.ReshowDelay = 100;
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnStart;
         this.AccessibleDescription = "This application tests the functionality of the TimerButton control.";
         this.AccessibleName = "Accessible Control Test";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnQuit;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.btnTimer);
         this.Controls.Add(this.btnQuit);
         this.Controls.Add(this.btnStart);
         this.Name = "frmMain";
         this.Text = "Accessible Control Test";
         this.ToolTip.SetToolTip(this, "This application tests the functionality of the TimerButton control.");
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

      private void btnStart_Click(object sender, System.EventArgs e)
      {
         // Start the TimerButton countdown.
         btnTimer.TimerStart(true);
      }

      private void btnTimer_Click(object sender, System.EventArgs e)
      {
         // Turn the timer off.
         if (btnTimer.TimerStarted)
            btnTimer.TimerStart(false);

         // Display a message box.
         if (btnTimer.AutoClick)
            MessageBox.Show("The button automatically clicked",
                            "Click Event",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
         else
            MessageBox.Show("The user clicked the button.",
                            "Click Event",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

         // Reset the AutoClick property.
         btnTimer.AutoClickReset();
      }
	}
}
