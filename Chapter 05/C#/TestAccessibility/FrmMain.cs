using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Accessibility;

namespace TestAccessibility
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button btnQuit;
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.ToolTip toolTipData;
      private System.ComponentModel.IContainer components;

		public frmMain()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// Set the AccessibleDefaultActionDescription property
         // values for this application.
         btnQuit.AccessibleDefaultActionDescription = 
            "Press to quit the application.";
         btnTest.AccessibleDefaultActionDescription =
            "Press to perform the application test function.";
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
         this.btnQuit = new System.Windows.Forms.Button();
         this.btnTest = new System.Windows.Forms.Button();
         this.toolTipData = new System.Windows.Forms.ToolTip(this.components);
         this.SuspendLayout();
         // 
         // btnQuit
         // 
         this.btnQuit.AccessibleDescription = "This button exits the application.";
         this.btnQuit.AccessibleName = "Application Quit";
         this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnQuit.Location = new System.Drawing.Point(208, 40);
         this.btnQuit.Name = "btnQuit";
         this.btnQuit.TabIndex = 1;
         this.btnQuit.Text = "&Quit";
         this.toolTipData.SetToolTip(this.btnQuit, "This button exits the application.");
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         this.btnQuit.Enter += new System.EventHandler(this.TestEnter);
         // 
         // btnTest
         // 
         this.btnTest.AccessibleDescription = "This button starts the test function of the application.";
         this.btnTest.AccessibleName = "Application Test";
         this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnTest.Location = new System.Drawing.Point(208, 8);
         this.btnTest.Name = "btnTest";
         this.btnTest.TabIndex = 0;
         this.btnTest.Text = "&Test";
         this.toolTipData.SetToolTip(this.btnTest, "This button starts the test function of the application.");
         this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
         this.btnTest.Enter += new System.EventHandler(this.TestEnter);
         // 
         // toolTipData
         // 
         this.toolTipData.AutomaticDelay = 300;
         this.toolTipData.AutoPopDelay = 5000;
         this.toolTipData.InitialDelay = 300;
         this.toolTipData.ReshowDelay = 60;
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnTest;
         this.AccessibleDescription = "This form contains controls that demonstration how to use the Accessibility names" +
            "pace.";
         this.AccessibleName = "Accessibility Test";
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnQuit;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.btnQuit);
         this.Name = "frmMain";
         this.Text = "Accessibility Namespace Test";
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

      private void btnTest_Click(object sender, System.EventArgs e)
      {
         // Display a message box.
         MessageBox.Show("This is a test message.",
                         "Test Message",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
      }

      private void btnQuit_Click(object sender, System.EventArgs e)
      {
         // Exit the application.
         Close();
      }

      private void TestEnter(object sender, System.EventArgs e)
      {
         Control  Ctrl; // Control sending information.

         // Show the current accessibility information.
         Ctrl = (Control)sender;
         MessageBox.Show("Name = " + Ctrl.AccessibleName +
                         "\r\nRole = " + Ctrl.AccessibleRole +
                         "\r\nDescription = " + Ctrl.AccessibleDescription +
                         "\r\nDefault Action = " + 
                         Ctrl.AccessibleDefaultActionDescription,
                         "Accessibility Information",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
      }
   }
}
