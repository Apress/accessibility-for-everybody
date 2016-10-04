using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccControl
{
	/// <summary>
	/// This class provides the functionality for the "Add Time to the 
	/// Timer" dialog box.
	/// </summary>
	public class FrmMoreTime : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lblCurrentTime;
      private System.Windows.Forms.NumericUpDown txtNewValue;
      private System.Windows.Forms.ToolTip MoreTimeToolTip;
      private System.ComponentModel.IContainer components;

      /// <summary>
      /// The constructor for the form that allows the user to
      /// select more time.
      /// </summary>
      /// <param name="CurrentTime">The current timer value.</param>
      [Description("The constructor for the form that allows the user " +
                   "to select more time.")]
		public FrmMoreTime(Int32 CurrentTime)
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// Initize the current time value.
         lblCurrentTime.Text = "The Current Time is: " 
            + CurrentTime.ToString();

         // Initialize the up/down control value.
         txtNewValue.Value = CurrentTime;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.lblCurrentTime = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.txtNewValue = new System.Windows.Forms.NumericUpDown();
         this.MoreTimeToolTip = new System.Windows.Forms.ToolTip(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.txtNewValue)).BeginInit();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.AccessibleDescription = "This button accepts the changed time value.";
         this.btnOK.AccessibleName = "Timer Value Change Accept";
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(208, 8);
         this.btnOK.Name = "btnOK";
         this.btnOK.TabIndex = 1;
         this.btnOK.Text = "&OK";
         this.MoreTimeToolTip.SetToolTip(this.btnOK, "This button accepts the changed time value.");
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleDescription = "This button cancels any change to the timer value.";
         this.btnCancel.AccessibleName = "Timer Value Change Cancel";
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(208, 40);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "&Cancel";
         this.MoreTimeToolTip.SetToolTip(this.btnCancel, "This button cancels any change to the timer value.");
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // lblCurrentTime
         // 
         this.lblCurrentTime.AccessibleDescription = "This label tells how many seconds are left on the current timer.";
         this.lblCurrentTime.AccessibleName = "Current Timer Value";
         this.lblCurrentTime.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
         this.lblCurrentTime.Location = new System.Drawing.Point(8, 16);
         this.lblCurrentTime.Name = "lblCurrentTime";
         this.lblCurrentTime.Size = new System.Drawing.Size(176, 40);
         this.lblCurrentTime.TabIndex = 3;
         this.lblCurrentTime.Text = "label1";
         this.MoreTimeToolTip.SetToolTip(this.lblCurrentTime, "This label tells how many seconds are left on the current timer.");
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 64);
         this.label2.Name = "label2";
         this.label2.TabIndex = 0;
         this.label2.Text = "&New Timer Value";
         // 
         // txtNewValue
         // 
         this.txtNewValue.AccessibleDescription = "Use this control to change the value of the timer interval in seconds.";
         this.txtNewValue.AccessibleName = "Timer Value Change";
         this.txtNewValue.AccessibleRole = System.Windows.Forms.AccessibleRole.SpinButton;
         this.txtNewValue.Location = new System.Drawing.Point(8, 88);
         this.txtNewValue.Name = "txtNewValue";
         this.txtNewValue.TabIndex = 0;
         this.MoreTimeToolTip.SetToolTip(this.txtNewValue, "Use this control to change the value of the timer interval in seconds.");
         // 
         // FrmMoreTime
         // 
         this.AcceptButton = this.btnOK;
         this.AccessibleDescription = "This dialog box enables the user to add more time to the timer interval.";
         this.AccessibleName = "Add Time to the Timer";
         this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.Add(this.txtNewValue);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.lblCurrentTime);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Name = "FrmMoreTime";
         this.Text = "Add Time to the Timer";
         this.MoreTimeToolTip.SetToolTip(this, "This dialog box enables the user to add more time to the timer interval.");
         ((System.ComponentModel.ISupportInitialize)(this.txtNewValue)).EndInit();
         this.ResumeLayout(false);

      }
		#endregion

      // Internal time track variable and associated public property.
      private  Int32    _NewTime;

      /// <summary>
      /// The new time value the user selected for the automatic
      /// click value.
      /// </summary>
      [Description("The new time value the user selected for the " +
                   "automatic click value.")]
      public   Int32    NewTime
      {
         get { return _NewTime; }
      }

      private void btnOK_Click(object sender, System.EventArgs e)
      {
         // Save the new value.
         _NewTime = Convert.ToInt32(txtNewValue.Value);

         // Exit the form.
         Close();
      }

      private void btnCancel_Click(object sender, System.EventArgs e)
      {
         // Exit the form.
         Close();
      }
	}
}
