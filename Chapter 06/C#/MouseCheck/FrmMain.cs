using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace MouseCheck
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Button btnQuit;
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
         this.btnTest = new System.Windows.Forms.Button();
         this.btnQuit = new System.Windows.Forms.Button();
         this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
         this.SuspendLayout();
         // 
         // btnTest
         // 
         this.btnTest.AccessibleDescription = "This button starts the test function of the application.";
         this.btnTest.AccessibleName = "Application Test";
         this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnTest.Location = new System.Drawing.Point(208, 8);
         this.btnTest.Name = "btnTest";
         this.btnTest.TabIndex = 4;
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
         this.btnQuit.TabIndex = 5;
         this.btnQuit.Text = "&Quit";
         this.ToolTip.SetToolTip(this.btnQuit, "This button exits the application.");
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         // 
         // ToolTip
         // 
         this.ToolTip.AutomaticDelay = 300;
         this.ToolTip.AutoPopDelay = 7000;
         this.ToolTip.InitialDelay = 300;
         this.ToolTip.ReshowDelay = 60;
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnTest;
         this.AccessibleDescription = "This application demonstrates techniques for obtaining mouse information.";
         this.AccessibleName = "Mouse Data Demonstration";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnQuit;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.btnQuit);
         this.Name = "frmMain";
         this.Text = "Mouse Data Demonstration";
         this.ToolTip.SetToolTip(this, "This application demonstrates techniques for obtaining mouse information.");
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
         StringBuilder  MouseData;  // The mouse setup information.

         // Initialize the StringBuilder.
         MouseData = new StringBuilder();

         // Check for the presence of a mouse.
         if (SystemInformation.MousePresent)
         {
            // Begin building the MouseData string.
            MouseData.Append("System includes a mouse with the " +
                             "following characteristics:\r\n");

            // Get the clicking information.
            MouseData.Append("\r\nDouble Click Area (pixels): ");
            MouseData.Append(
               SystemInformation.DoubleClickSize.ToString());
            MouseData.Append("\r\nDouble Click Time (ms): ");
            MouseData.Append(
               SystemInformation.DoubleClickTime.ToString());

            // Get the mouse specific information.
            MouseData.Append("\r\n\r\nNumber of Mouse Buttons: ");
            MouseData.Append(
               SystemInformation.MouseButtons.ToString());
            MouseData.Append("\r\nAre the buttons swapped? ");
            MouseData.Append(
               SystemInformation.MouseButtonsSwapped.ToString());
            MouseData.Append("\r\n\r\nIs a mouse wheel available? ");
            MouseData.Append(
               SystemInformation.MouseWheelPresent.ToString());

            // Display this information only for systems with
            // mouse wheel support.
            if (SystemInformation.MouseWheelPresent)
            {
               MouseData.Append("\r\nMouse wheel scroll lines: ");
               MouseData.Append(
                  SystemInformation.MouseWheelScrollLines.ToString());
               MouseData.Append("\r\nNative mouse wheel support? ");
               MouseData.Append(
                  SystemInformation.NativeMouseWheelSupport.ToString());
            }

            // Display the results.
            MessageBox.Show(MouseData.ToString(),
                            "Mouse Access Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
         }

         // If no mouse is present, display a message and exit.
         else
            MessageBox.Show("There is no mouse connected to this system.",
                            "No Mouse Access",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
      }
	}
}
