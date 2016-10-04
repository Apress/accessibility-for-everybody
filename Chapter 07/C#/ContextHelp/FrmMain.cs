using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ContextHelp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.HelpProvider ControlHelp;
      private System.Windows.Forms.ToolTip ControlToolTip;
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Button btnQuit;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtMessage;
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
         this.ControlHelp = new System.Windows.Forms.HelpProvider();
         this.btnTest = new System.Windows.Forms.Button();
         this.btnQuit = new System.Windows.Forms.Button();
         this.txtMessage = new System.Windows.Forms.TextBox();
         this.ControlToolTip = new System.Windows.Forms.ToolTip(this.components);
         this.label1 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // ControlHelp
         // 
         this.ControlHelp.HelpNamespace = "D:\\0125 - Source Code\\Chapter 07\\HelpFiles\\ContextHelp.chm";
         // 
         // btnTest
         // 
         this.btnTest.AccessibleDescription = "This button starts the test function of the application.";
         this.btnTest.AccessibleName = "Application Test";
         this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.ControlHelp.SetHelpKeyword(this.btnTest, "Test Button");
         this.ControlHelp.SetHelpNavigator(this.btnTest, System.Windows.Forms.HelpNavigator.Index);
         this.ControlHelp.SetHelpString(this.btnTest, "This is the Test button. You use it to test the application. Modify the Test Mess" +
            "age data field to change the message.");
         this.btnTest.Location = new System.Drawing.Point(208, 8);
         this.btnTest.Name = "btnTest";
         this.ControlHelp.SetShowHelp(this.btnTest, true);
         this.btnTest.TabIndex = 1;
         this.btnTest.Text = "&Test";
         this.ControlToolTip.SetToolTip(this.btnTest, "This button starts the test function of the application.");
         this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
         // 
         // btnQuit
         // 
         this.btnQuit.AccessibleDescription = "This button exits the application.";
         this.btnQuit.AccessibleName = "Application Quit";
         this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.ControlHelp.SetHelpKeyword(this.btnQuit, "Quit Button");
         this.ControlHelp.SetHelpNavigator(this.btnQuit, System.Windows.Forms.HelpNavigator.Index);
         this.ControlHelp.SetHelpString(this.btnQuit, "This is the Quit button. You use it to exit the application.");
         this.btnQuit.Location = new System.Drawing.Point(208, 40);
         this.btnQuit.Name = "btnQuit";
         this.ControlHelp.SetShowHelp(this.btnQuit, true);
         this.btnQuit.TabIndex = 2;
         this.btnQuit.Text = "&Quit";
         this.ControlToolTip.SetToolTip(this.btnQuit, "This button exits the application.");
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         // 
         // txtMessage
         // 
         this.txtMessage.AccessibleDescription = "Contains the test message that you want to display.";
         this.txtMessage.AccessibleName = "Test Message Entry";
         this.txtMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
         this.ControlHelp.SetHelpKeyword(this.txtMessage, "Test Message Field");
         this.ControlHelp.SetHelpNavigator(this.txtMessage, System.Windows.Forms.HelpNavigator.Index);
         this.ControlHelp.SetHelpString(this.txtMessage, "This is the Test Message data field. It contains the test message displayed when " +
            "you click the Test button.");
         this.txtMessage.Location = new System.Drawing.Point(8, 32);
         this.txtMessage.Name = "txtMessage";
         this.ControlHelp.SetShowHelp(this.txtMessage, true);
         this.txtMessage.Size = new System.Drawing.Size(168, 20);
         this.txtMessage.TabIndex = 0;
         this.txtMessage.Text = "This is a test message.";
         this.ControlToolTip.SetToolTip(this.txtMessage, "Contains the test message that you want to display.");
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 8);
         this.label1.Name = "label1";
         this.label1.TabIndex = 0;
         this.label1.Text = "Test &Message";
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnTest;
         this.AccessibleDescription = "This application demonstrates the use of context sensitive help.";
         this.AccessibleName = "Context Sensitive Help Demonstration";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnQuit;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.txtMessage);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.btnQuit);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.HelpButton = true;
         this.ControlHelp.SetHelpKeyword(this, "Overview");
         this.ControlHelp.SetHelpString(this, "Overview");
         this.KeyPreview = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "frmMain";
         this.ControlHelp.SetShowHelp(this, true);
         this.Text = "Context Sensitive Help";
         this.ControlToolTip.SetToolTip(this, "This application demonstrates the use of context sensitive help.");
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
         // Display the message box.
         MessageBox.Show(txtMessage.Text,
                         "Test Message",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
      }
	}
}
