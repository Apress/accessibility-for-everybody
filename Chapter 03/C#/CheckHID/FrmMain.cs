using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DxVBLibA;

namespace CheckHID
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
         this.Text = "Display HID Status";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
         this.Load += new System.EventHandler(this.frmMain_Load);
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

      //DirectX objects.
      private DirectX8 DX8;                       //DirectX 8 Object
      private DirectInput8 DI8;                   //DirectInput 8 Object
      private DirectInputDeviceInstance8 DIDI8;   //DirectInput 8 Device

      private void frmMain_Load(object sender, System.EventArgs e)
      {
         //Initialize the DirectX objects.
         DX8 = new DirectX8Class();
         DI8 = DX8.DirectInputCreate();
      }

      private void btnTest_Click(object sender, System.EventArgs e)
      {
         //Make sure the DirectInput 8 Device Instance is empty.
         if (DIDI8 != null)
            DIDI8 = null;

         //Get the device information.
         CreateInputDeviceInstance("Mouse");

         //Display the status information.
         if ((DIDI8.GetDevType() & (UInt32)CONST_DI8DEVICESUBTYPE.DIDEVTYPE_HID)
                                 == (UInt32)CONST_DI8DEVICESUBTYPE.DIDEVTYPE_HID)
            MessageBox.Show("Mouse is a HID");
         else
            MessageBox.Show("Mouse is not a HID");
      }

      private void CreateInputDeviceInstance(String DeviceName)
      {
         DirectInputEnumDevices8 Devs;         //DirectInput device enumeration.
         DirectInputDeviceInstance8 DevInst;   //A single device instance.
         Int32 Counter;                        //Loop counter

         //Create a list of devices for this machine.
         Devs = DI8.GetDIDevices(CONST_DI8DEVICETYPE.DI8DEVCLASS_ALL,
                                 CONST_DIENUMDEVICESFLAGS.DIEDFL_ATTACHEDONLY);

         //Search for the correct GUID. Remember to start the 
         //Counter at 1 for VB.
         for (Counter = 1; Counter <= Devs.GetCount(); Counter++)
         {
            //Get a device instance.
            DevInst = Devs.GetItem(Counter);

            if (DevInst.GetProductName().ToUpper() == DeviceName.ToUpper())
            {
               DIDI8 = DevInst;
               break;
            }
         }
      }

      private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         // Clean up the objects.
         DIDI8 = null;
         DI8 = null;
         DX8 = null;
      }
   }
}
