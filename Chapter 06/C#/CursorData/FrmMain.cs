using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace CursorData
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.ToolTip ToolTip;
      private System.Windows.Forms.Button btnQuit;
      private System.Windows.Forms.Button btnGetCursor;
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
         this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
         this.btnGetCursor = new System.Windows.Forms.Button();
         this.btnQuit = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // ToolTip
         // 
         this.ToolTip.AutomaticDelay = 300;
         this.ToolTip.AutoPopDelay = 7000;
         this.ToolTip.InitialDelay = 300;
         this.ToolTip.ReshowDelay = 60;
         // 
         // btnGetCursor
         // 
         this.btnGetCursor.AccessibleDescription = "This button tests the Get Cursor feature of the application.";
         this.btnGetCursor.AccessibleName = "Get Cursor Test Button";
         this.btnGetCursor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnGetCursor.Location = new System.Drawing.Point(208, 8);
         this.btnGetCursor.Name = "btnGetCursor";
         this.btnGetCursor.TabIndex = 6;
         this.btnGetCursor.Text = "&Get Cursor";
         this.ToolTip.SetToolTip(this.btnGetCursor, "This button tests the Get Cursor feature of the application.");
         this.btnGetCursor.Click += new System.EventHandler(this.btnGetCursor_Click);
         // 
         // btnQuit
         // 
         this.btnQuit.AccessibleDescription = "This button exits the application.";
         this.btnQuit.AccessibleName = "Application Quit";
         this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnQuit.Location = new System.Drawing.Point(208, 40);
         this.btnQuit.Name = "btnQuit";
         this.btnQuit.TabIndex = 7;
         this.btnQuit.Text = "&Quit";
         this.ToolTip.SetToolTip(this.btnQuit, "This button exits the application.");
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnGetCursor;
         this.AccessibleDescription = "This application shows how to obtain cursor information.";
         this.AccessibleName = "Cursor Statistics Demonstration";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnQuit;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.btnGetCursor);
         this.Controls.Add(this.btnQuit);
         this.Name = "frmMain";
         this.Text = "Cursor Statistics Demonstration";
         this.ToolTip.SetToolTip(this, "This application shows how to obtain cursor information.");
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

      private void btnGetCursor_Click(object sender, System.EventArgs e)
      {
         StringBuilder  CursorData; // Cursor information.

         // Initialize the StringBuilder
         CursorData = new StringBuilder();

         // Get the cursor information.
         CursorData.Append("The current cursor size is:\r\n\r\nHeight: ");
         CursorData.Append(SystemInformation.CursorSize.Height.ToString());
         CursorData.Append("\r\nWidth: ");
         CursorData.Append(SystemInformation.CursorSize.Width.ToString());

         // Display the information.
         MessageBox.Show(CursorData.ToString(),
                         "Cursor Data",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
      }
	}
}
