using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace ProfilerTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCycles;
		private System.Windows.Forms.TextBox txtSleep;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCurrent;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
			this.btnQuit = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCycles = new System.Windows.Forms.TextBox();
			this.txtSleep = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCurrent = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnQuit
			// 
			this.btnQuit.AccessibleDescription = "Click this button to exit the application.";
			this.btnQuit.AccessibleName = "Application Exit";
			this.btnQuit.Location = new System.Drawing.Point(208, 8);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "&Quit";
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// btnTest
			// 
			this.btnTest.AccessibleDescription = "Click this button to test the application.";
			this.btnTest.AccessibleName = "Application Test";
			this.btnTest.Location = new System.Drawing.Point(208, 40);
			this.btnTest.Name = "btnTest";
			this.btnTest.TabIndex = 1;
			this.btnTest.Text = "&Test";
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = "Number of times to run the loop within the application.";
			this.label1.AccessibleName = "Application Cycles";
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "&Number of Cycles:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "&Sleep Time (Milliseconds):";
			// 
			// txtCycles
			// 
			this.txtCycles.Location = new System.Drawing.Point(8, 24);
			this.txtCycles.Name = "txtCycles";
			this.txtCycles.TabIndex = 3;
			this.txtCycles.Text = "5";
			// 
			// txtSleep
			// 
			this.txtSleep.AccessibleDescription = "Amount of time the application should sleep for each cycle.";
			this.txtSleep.AccessibleName = "Application Sleep";
			this.txtSleep.Location = new System.Drawing.Point(8, 80);
			this.txtSleep.Name = "txtSleep";
			this.txtSleep.TabIndex = 5;
			this.txtSleep.Text = "1000";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 120);
			this.label3.Name = "label3";
			this.label3.TabIndex = 6;
			this.label3.Text = "Current Cycle:";
			// 
			// txtCurrent
			// 
			this.txtCurrent.AccessibleDescription = "Current application test cycle. Displays Done when complete.";
			this.txtCurrent.AccessibleName = "Application Test Cycle";
			this.txtCurrent.Location = new System.Drawing.Point(8, 136);
			this.txtCurrent.Name = "txtCurrent";
			this.txtCurrent.ReadOnly = true;
			this.txtCurrent.TabIndex = 7;
			this.txtCurrent.TabStop = false;
			this.txtCurrent.Text = "Not Run";
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtCurrent,
																		  this.label3,
																		  this.txtSleep,
																		  this.txtCycles,
																		  this.label2,
																		  this.label1,
																		  this.btnTest,
																		  this.btnQuit});
			this.Name = "frmMain";
			this.Text = "DevPartner Profiler Test";
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
			//Exit the application.
			Close();
		}

		private void btnTest_Click(object sender, System.EventArgs e)
		{
			// Loop a few times.
			for (int Counter = 1; Counter <= Int32.Parse(txtCycles.Text); Counter++)
			{
				// Display some text on screen.
				txtCurrent.Text = Counter.ToString();
				txtCurrent.Update();

				// Cause the application to sleep.
				System.Threading.Thread.Sleep(Int32.Parse(txtSleep.Text));
			}

			// Tell the user we're finished.
			txtCurrent.Text = "Done";
		}
	}
}
