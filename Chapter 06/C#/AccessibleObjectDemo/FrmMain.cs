using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace AccessibleObjectDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button btnQuit;
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtMessage;
      private System.ComponentModel.IContainer components;

		public frmMain()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// Initialize the accessible objects.
         btnQuit.AccessibleDefaultActionDescription =
            "Press to exit the application.";
         btnTest.AccessibleDefaultActionDescription =
            "Press to test the application.";
         txtMessage.AccessibleDefaultActionDescription =
            "Type to change test message.";
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
         this.txtMessage = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // btnQuit
         // 
         this.btnQuit.AccessibleDescription = "This button lets you to exit the application.";
         this.btnQuit.AccessibleName = "Exit the Application";
         this.btnQuit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnQuit.Location = new System.Drawing.Point(208, 40);
         this.btnQuit.Name = "btnQuit";
         this.btnQuit.TabIndex = 3;
         this.btnQuit.Text = "&Quit";
         this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
         this.btnQuit.MouseHover += new System.EventHandler(this.SpecialTip);
         // 
         // btnTest
         // 
         this.btnTest.AccessibleDescription = "This button tests application functionality.";
         this.btnTest.AccessibleName = "Test the Application";
         this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnTest.Location = new System.Drawing.Point(208, 8);
         this.btnTest.Name = "btnTest";
         this.btnTest.TabIndex = 2;
         this.btnTest.Text = "&Test";
         this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
         this.btnTest.MouseHover += new System.EventHandler(this.SpecialTip);
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 8);
         this.label1.Name = "label1";
         this.label1.TabIndex = 4;
         this.label1.Text = "Test &Messsage";
         // 
         // txtMessage
         // 
         this.txtMessage.AccessibleDescription = "Contains the message you want to display during test.";
         this.txtMessage.AccessibleName = "Application Test Message";
         this.txtMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
         this.txtMessage.Location = new System.Drawing.Point(8, 32);
         this.txtMessage.Name = "txtMessage";
         this.txtMessage.Size = new System.Drawing.Size(176, 20);
         this.txtMessage.TabIndex = 5;
         this.txtMessage.Text = "This is a test message box.";
         this.txtMessage.MouseHover += new System.EventHandler(this.SpecialTip);
         // 
         // frmMain
         // 
         this.AcceptButton = this.btnTest;
         this.AccessibleDescription = "This application demonstrates use of the AccessibleObject class.";
         this.AccessibleName = "Accessible Object Demonstration";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnQuit;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.txtMessage);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnQuit);
         this.Controls.Add(this.btnTest);
         this.Name = "frmMain";
         this.Text = "AccessibleObject Demonstration";
         this.MouseHover += new System.EventHandler(this.SpecialTip);
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
         // Display a message box.
         MessageBox.Show(txtMessage.Text,
                         "Test Message",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
      }

      private void SpecialTip(object sender, System.EventArgs e)
      {
         Control           Ctrl;    // The control in question.
         AccessibleObject  AO;      // The accessibility information.
         ToolTip           TT;      // Special ToolTip
         StringBuilder     Output;  // ToolTip Output String.

         // Initialize the ToolTip.
         TT = new ToolTip();
         TT.AutoPopDelay = 7000;
         TT.AutomaticDelay = 300;

         // Get the sender information.
         Ctrl = (Control)sender;

         // Obtain access to the accessibility information.
         AO = Ctrl.AccessibilityObject;

         // Create the output string.
         Output = new StringBuilder();
         Output.Append("Name: ");
         Output.Append(AO.Name);
         Output.Append("\r\nRole: ");
         Output.Append(AO.Role);
         Output.Append("\r\nDescription: ");
         Output.Append(AO.Description);
         Output.Append("\r\nDefault Action: ");
         if (AO.DefaultAction == null)
            Output.Append("None");
         else
            Output.Append(AO.DefaultAction);
         Output.Append("\r\nKeyboard Shortcut: ");
         if (AO.KeyboardShortcut == null)
            Output.Append("None");
         else
            Output.Append(AO.KeyboardShortcut);
         Output.Append("\r\nState: ");
         Output.Append(AO.State);
         Output.Append("\r\nValue: ");
         if (AO.Value == null)
            Output.Append("None");
         else
            Output.Append(AO.Value);

         // Display the information on screen.
         TT.SetToolTip(Ctrl, Output.ToString());
         TT.Active = true;
      }
	}
}
