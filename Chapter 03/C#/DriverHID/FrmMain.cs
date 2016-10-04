using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace DriverHID
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Button btnTest;
      internal System.Windows.Forms.Button btnQuit;
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
         this.btnTest = new System.Windows.Forms.Button();
         this.btnQuit = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnTest
         // 
         this.btnTest.Location = new System.Drawing.Point(208, 40);
         this.btnTest.Name = "btnTest";
         this.btnTest.TabIndex = 3;
         this.btnTest.Text = "Test";
         this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
         // 
         // btnQuit
         // 
         this.btnQuit.Location = new System.Drawing.Point(208, 8);
         this.btnQuit.Name = "btnQuit";
         this.btnQuit.TabIndex = 2;
         this.btnQuit.Text = "Quit";
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         // 
         // frmMain
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.btnQuit);
         this.Name = "frmMain";
         this.Text = "Checking HIDs Using a Driver";
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

      // This function obtains the GUID of the top level HID devices.
      [DllImport("HID.DLL", CharSet=CharSet.Auto, SetLastError=true)]
      public static extern void HidD_GetHidGuid(out Guid HidGuid);

      private void btnTest_Click(object sender, System.EventArgs e)
      {
         Guid HidGuid;     // The top level GUID

         //Get the HID GUID and display it.
         HidD_GetHidGuid(out HidGuid);
         MessageBox.Show("The HID GUID is: " + HidGuid.ToString(), 
                         "Application Output", 
                         MessageBoxButtons.OK, 
                         MessageBoxIcon.Information);
      }
	}
}
