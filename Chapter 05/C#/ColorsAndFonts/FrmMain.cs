using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace ColorsAndFonts
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Button btnQuit;
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
         this.btnTest.AccessibleDescription = "This button displays the test information.";
         this.btnTest.AccessibleName = "Test Pushbutton";
         this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnTest.Location = new System.Drawing.Point(208, 8);
         this.btnTest.Name = "btnTest";
         this.btnTest.TabIndex = 0;
         this.btnTest.Text = "&Test";
         this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
         // 
         // btnQuit
         // 
         this.btnQuit.AccessibleDescription = "Use this button to exit the application.";
         this.btnQuit.AccessibleName = "Quit Pushbutton";
         this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnQuit.Location = new System.Drawing.Point(208, 40);
         this.btnQuit.Name = "btnQuit";
         this.btnQuit.TabIndex = 1;
         this.btnQuit.Text = "&Quit";
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnTest;
         this.AccessibleDescription = "This application helps you understand the use of colors and fonts in an applicati" +
            "on.";
         this.AccessibleName = "Colors and Fonts Demonstration.";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnQuit;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.btnQuit);
         this.Controls.Add(this.btnTest);
         this.Name = "frmMain";
         this.Text = "Colors and Fonts Demonstration";
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
         Font  DefFont; // Current font requirement.
         Size  BtnSize; // Current button size.
         Size  DlgSize; // Current dialog size.
         Point TestLoc; // Current Test button location.
         Point QuitLoc; // Current Quit button location.

         // Obtain the default font for our example.
         // Begin by determining the screen state.
         if (SystemInformation.HighContrast)
         {
            DefFont = SystemInformation.MenuFont;
            BtnSize = new Size(135, 42);
            DlgSize = new Size(540, 540);
            TestLoc = new Point(374, 14);
            QuitLoc = new Point(374, 72);
         }
         // Use the default sizes.
         else
         {
            DefFont = this.Font;
            BtnSize = new Size(75, 23);
            DlgSize = new Size(300, 300);
            TestLoc = new Point(208, 8);
            QuitLoc = new Point(208, 40);
         }

         // Modify the display fonts.
         btnTest.Font = DefFont;
         btnQuit.Font = DefFont;

         // Modify the sizes.
         btnTest.Size = BtnSize;
         btnQuit.Size = BtnSize;
         frmMain.ActiveForm.Size = DlgSize;

         // Modify the positions.
         btnTest.Location = TestLoc;
         btnQuit.Location = QuitLoc;

         // Display the information.
         MessageBox.Show("Name: " + DefFont.Name + 
                         "\r\nSize: " + DefFont.SizeInPoints.ToString(),
                         "Font Information",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
      }
	}
}
