using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AccessFuncs;
using System.Runtime.InteropServices;
using System.Text;

namespace AccessSettings
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
      private System.Windows.Forms.MainMenu mnuMain;
      private System.Windows.Forms.ToolTip ToolTip;
      private System.Windows.Forms.MenuItem mnuFile;
      private System.Windows.Forms.MenuItem mnuFileExit;
      private System.Windows.Forms.MenuItem mnuChoose;
      private System.Windows.Forms.MenuItem mnuChooseAccessTimeout;
      private System.Windows.Forms.MenuItem mnuChooseFilterKeys;
      private System.Windows.Forms.MenuItem mnuChooseHighContrast;
      private System.Windows.Forms.MenuItem mnuChooseMouseKeys;
      private System.Windows.Forms.MenuItem mnuChooseScreenReader;
      private System.Windows.Forms.MenuItem mnuChooseSerialKeys;
      private System.Windows.Forms.MenuItem mnuChooseShowSounds;
      private System.Windows.Forms.MenuItem mnuChooseSoundSentry;
      private System.Windows.Forms.MenuItem mnuChooseStickyKeys;
      private System.Windows.Forms.MenuItem mnuChooseToggleKeys;
      private System.ComponentModel.IContainer components;

      // Data structures or Boolean values used track accessibility
      // status in this application.
      ACCESSTIMEOUT  AT;      // Access Timeout
      FILTERKEYS     FK;      // FilterKeys
      HIGHCONTRAST   HC;      // High Contrast
      MOUSEKEYS      MK;      // MouseKeys
      bool           SR;      // ScreenReader
      SERIALKEYS     SC;      // SerialKeys
      bool           SSound;  // ShowSounds
      SOUNDSENTRY    SSentry; // SoundSentry
      STICKYKEYS     SK;      // StickyKeys
      TOGGLEKEYS     TK;      // ToggleKeys

		public frmMain()
		{
         Int32             DataSize;   // Size of the data structure.

			// Required for Windows Form Designer support
			InitializeComponent();

         // Initialize the data structures.
         AT = new ACCESSTIMEOUT();     // Access Timeout
         FK = new FILTERKEYS();        // FilterKeys
         HC = new HIGHCONTRAST();      // High Contrast
         MK = new MOUSEKEYS();         // MouseKeys
         SR = false;                   // ScreenReader
         SC = new SERIALKEYS();        // SerialKeys
         SSound = false;               // ShowSounds
         SSentry = new SOUNDSENTRY();  // SoundSentry
         SK = new STICKYKEYS();        // StickyKeys
         TK = new TOGGLEKEYS();        // ToggleKeys

         // Initialize the data structures and Choose menu options. The
         // process includes getting the current option status (which
         // fills out the data structure) and then comparing the flag
         // values to see if the option is on.

         // Access Timeout
         DataSize = Marshal.SizeOf(AT);
         AT.cbSize = Convert.ToUInt32(DataSize);
         AT = (ACCESSTIMEOUT)GetAccessibleOption(
                              AT, 
                              DataSize, 
                              AccessType.SPI_GETACCESSTIMEOUT, 
                              WinIniFlags.SPIF_NONE);
         if ((AT.dwFlags & (Int32)AccessTimeoutFlags.ATF_TIMEOUTON) ==
                           (Int32)AccessTimeoutFlags.ATF_TIMEOUTON)
            mnuChooseAccessTimeout.Checked = true;

         // FilterKeys
         DataSize = Marshal.SizeOf(FK);
         FK.cbSize = Convert.ToUInt32(DataSize);
         FK = (FILTERKEYS)GetAccessibleOption(
                           FK, 
                           DataSize, 
                           AccessType.SPI_GETFILTERKEYS, 
                           WinIniFlags.SPIF_NONE);
         if ((FK.dwFlags & (Int32)FilterKeysFlags.FKF_FILTERKEYSON) ==
                           (Int32)FilterKeysFlags.FKF_FILTERKEYSON)
            mnuChooseFilterKeys.Checked = true;

         // High Contrast
         DataSize = Marshal.SizeOf(HC);
         HC.cbSize = Convert.ToUInt32(DataSize);
         HC = (HIGHCONTRAST)GetAccessibleOption(
                              HC, 
                              DataSize, 
                              AccessType.SPI_GETHIGHCONTRAST, 
                              WinIniFlags.SPIF_NONE);
         if ((HC.dwFlags & (Int32)HighContrastFlags.HCF_HIGHCONTRASTON) ==
                           (Int32)HighContrastFlags.HCF_HIGHCONTRASTON)
            mnuChooseHighContrast.Checked = true;

         // MouseKeys
         DataSize = Marshal.SizeOf(MK);
         MK.cbSize = Convert.ToUInt32(DataSize);
         MK = (MOUSEKEYS)GetAccessibleOption(
                           MK, 
                           DataSize, 
                           AccessType.SPI_GETMOUSEKEYS, 
                           WinIniFlags.SPIF_NONE);
         if ((MK.dwFlags & (Int32)MouseKeysFlags.MKF_MOUSEKEYSON) ==
                           (Int32)MouseKeysFlags.MKF_MOUSEKEYSON)
            mnuChooseMouseKeys.Checked = true;

         // Screen Reader
         DataSize = Marshal.SizeOf(SR);
         SR = (bool)GetAccessibleOption(
                     SR, 
                     DataSize, 
                     AccessType.SPI_GETSCREENREADER, 
                     WinIniFlags.SPIF_NONE);
         if (SR)
            mnuChooseScreenReader.Checked = true;

         // SerialKeys
         DataSize = Marshal.SizeOf(SC);
         SC.cbSize = Convert.ToUInt32(DataSize);
         SC = (SERIALKEYS)GetAccessibleOption(
                           SC, 
                           DataSize, 
                           AccessType.SPI_GETSERIALKEYS, 
                           WinIniFlags.SPIF_NONE);
         if ((SC.dwFlags & (Int32)SerialKeysFlags.SERKF_SERIALKEYSON) ==
            (Int32)SerialKeysFlags.SERKF_SERIALKEYSON)
            mnuChooseSerialKeys.Checked = true;
         else if (SC.lpszActivePort == null)

            // This is one of the few accessibility options not supported
            // under Windows 2000/XP. Microsoft changed this behavior to
            // ensure that SerialKeys devices would appear as standard
            // input devices to the application.  The lpszActivePort member
            // will always contain a value for operating systems that
            // support the SerialKeys feature.
            mnuChooseSerialKeys.Enabled = false;

         // ShowSounds
         DataSize = Marshal.SizeOf(SSound);
         SSound = (bool)GetAccessibleOption(
                           SSound, 
                           DataSize, 
                           AccessType.SPI_GETSHOWSOUNDS, 
                           WinIniFlags.SPIF_NONE);
         if (SSound)
            mnuChooseShowSounds.Checked = true;

         // SoundSentry
         DataSize = Marshal.SizeOf(SSentry);
         SSentry.cbSize = Convert.ToUInt32(DataSize);
         SSentry = (SOUNDSENTRY)GetAccessibleOption(
                                 SSentry, 
                                 DataSize, 
                                 AccessType.SPI_GETSOUNDSENTRY, 
                                 WinIniFlags.SPIF_NONE);
         if ((SSentry.dwFlags & (Int32)SoundSentryFlags.SSF_SOUNDSENTRYON) ==
                                (Int32)SoundSentryFlags.SSF_SOUNDSENTRYON)
            mnuChooseSoundSentry.Checked = true;

         // StickyKeys
         DataSize = Marshal.SizeOf(SK);
         SK.cbSize = Convert.ToUInt32(DataSize);
         SK = (STICKYKEYS)GetAccessibleOption(
                           SK, 
                           DataSize, 
                           AccessType.SPI_GETSTICKYKEYS, 
                           WinIniFlags.SPIF_NONE);
         if ((SK.dwFlags & (Int32)StickyKeysFlags.SKF_STICKYKEYSON) ==
                           (Int32)StickyKeysFlags.SKF_STICKYKEYSON)
            mnuChooseStickyKeys.Checked = true;

         // ToggleKeys
         DataSize = Marshal.SizeOf(TK);
         TK.cbSize = Convert.ToUInt32(DataSize);
         TK = (TOGGLEKEYS)GetAccessibleOption(
                           TK, 
                           DataSize, 
                           AccessType.SPI_GETTOGGLEKEYS, 
                           WinIniFlags.SPIF_NONE);
         if ((TK.dwFlags & (Int32)ToggleKeysFlags.TKF_TOGGLEKEYSON) ==
                           (Int32)ToggleKeysFlags.TKF_TOGGLEKEYSON)
            mnuChooseToggleKeys.Checked = true;
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
         this.mnuMain = new System.Windows.Forms.MainMenu();
         this.mnuFile = new System.Windows.Forms.MenuItem();
         this.mnuFileExit = new System.Windows.Forms.MenuItem();
         this.mnuChoose = new System.Windows.Forms.MenuItem();
         this.mnuChooseAccessTimeout = new System.Windows.Forms.MenuItem();
         this.mnuChooseFilterKeys = new System.Windows.Forms.MenuItem();
         this.mnuChooseHighContrast = new System.Windows.Forms.MenuItem();
         this.mnuChooseMouseKeys = new System.Windows.Forms.MenuItem();
         this.mnuChooseScreenReader = new System.Windows.Forms.MenuItem();
         this.mnuChooseSerialKeys = new System.Windows.Forms.MenuItem();
         this.mnuChooseShowSounds = new System.Windows.Forms.MenuItem();
         this.mnuChooseSoundSentry = new System.Windows.Forms.MenuItem();
         this.mnuChooseStickyKeys = new System.Windows.Forms.MenuItem();
         this.mnuChooseToggleKeys = new System.Windows.Forms.MenuItem();
         this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
         // 
         // mnuMain
         // 
         this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this.mnuFile,
                                                                                this.mnuChoose});
         // 
         // mnuFile
         // 
         this.mnuFile.Index = 0;
         this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this.mnuFileExit});
         this.mnuFile.Text = "&File";
         // 
         // mnuFileExit
         // 
         this.mnuFileExit.Index = 0;
         this.mnuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
         this.mnuFileExit.Text = "E&xit";
         this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
         // 
         // mnuChoose
         // 
         this.mnuChoose.Index = 1;
         this.mnuChoose.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.mnuChooseAccessTimeout,
                                                                                  this.mnuChooseFilterKeys,
                                                                                  this.mnuChooseHighContrast,
                                                                                  this.mnuChooseMouseKeys,
                                                                                  this.mnuChooseScreenReader,
                                                                                  this.mnuChooseSerialKeys,
                                                                                  this.mnuChooseShowSounds,
                                                                                  this.mnuChooseSoundSentry,
                                                                                  this.mnuChooseStickyKeys,
                                                                                  this.mnuChooseToggleKeys});
         this.mnuChoose.Text = "&Choose Feature";
         // 
         // mnuChooseAccessTimeout
         // 
         this.mnuChooseAccessTimeout.Index = 0;
         this.mnuChooseAccessTimeout.Shortcut = System.Windows.Forms.Shortcut.F2;
         this.mnuChooseAccessTimeout.Text = "&Access Timeout";
         this.mnuChooseAccessTimeout.Click += new System.EventHandler(this.mnuChooseAccessTimeout_Click);
         // 
         // mnuChooseFilterKeys
         // 
         this.mnuChooseFilterKeys.Index = 1;
         this.mnuChooseFilterKeys.Shortcut = System.Windows.Forms.Shortcut.F3;
         this.mnuChooseFilterKeys.Text = "&FilterKeys";
         this.mnuChooseFilterKeys.Click += new System.EventHandler(this.mnuChooseFilterKeys_Click);
         // 
         // mnuChooseHighContrast
         // 
         this.mnuChooseHighContrast.Index = 2;
         this.mnuChooseHighContrast.Shortcut = System.Windows.Forms.Shortcut.F4;
         this.mnuChooseHighContrast.Text = "&High Contrast";
         this.mnuChooseHighContrast.Click += new System.EventHandler(this.mnuChooseHighContrast_Click);
         // 
         // mnuChooseMouseKeys
         // 
         this.mnuChooseMouseKeys.Index = 3;
         this.mnuChooseMouseKeys.Shortcut = System.Windows.Forms.Shortcut.F5;
         this.mnuChooseMouseKeys.Text = "&MouseKeys";
         this.mnuChooseMouseKeys.Click += new System.EventHandler(this.mnuChooseMouseKeys_Click);
         // 
         // mnuChooseScreenReader
         // 
         this.mnuChooseScreenReader.Index = 4;
         this.mnuChooseScreenReader.Shortcut = System.Windows.Forms.Shortcut.F6;
         this.mnuChooseScreenReader.Text = "&ScreenReader";
         this.mnuChooseScreenReader.Click += new System.EventHandler(this.mnuChooseScreenReader_Click);
         // 
         // mnuChooseSerialKeys
         // 
         this.mnuChooseSerialKeys.Index = 5;
         this.mnuChooseSerialKeys.Shortcut = System.Windows.Forms.Shortcut.F7;
         this.mnuChooseSerialKeys.Text = "S&erialKeys";
         this.mnuChooseSerialKeys.Click += new System.EventHandler(this.mnuChooseSerialKeys_Click);
         // 
         // mnuChooseShowSounds
         // 
         this.mnuChooseShowSounds.Index = 6;
         this.mnuChooseShowSounds.Shortcut = System.Windows.Forms.Shortcut.F8;
         this.mnuChooseShowSounds.Text = "Sh&owSounds";
         this.mnuChooseShowSounds.Click += new System.EventHandler(this.mnuChooseShowSounds_Click);
         // 
         // mnuChooseSoundSentry
         // 
         this.mnuChooseSoundSentry.Index = 7;
         this.mnuChooseSoundSentry.Shortcut = System.Windows.Forms.Shortcut.F9;
         this.mnuChooseSoundSentry.Text = "Sound&Sentry";
         this.mnuChooseSoundSentry.Click += new System.EventHandler(this.mnuChooseSoundSentry_Click);
         // 
         // mnuChooseStickyKeys
         // 
         this.mnuChooseStickyKeys.Index = 8;
         this.mnuChooseStickyKeys.Shortcut = System.Windows.Forms.Shortcut.F10;
         this.mnuChooseStickyKeys.Text = "Sticky&Keys";
         this.mnuChooseStickyKeys.Click += new System.EventHandler(this.mnuChooseStickyKeys_Click);
         // 
         // mnuChooseToggleKeys
         // 
         this.mnuChooseToggleKeys.Index = 9;
         this.mnuChooseToggleKeys.Shortcut = System.Windows.Forms.Shortcut.F11;
         this.mnuChooseToggleKeys.Text = "&ToggleKeys";
         this.mnuChooseToggleKeys.Click += new System.EventHandler(this.mnuChooseToggleKeys_Click);
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
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(357, 256);
         this.Menu = this.mnuMain;
         this.Name = "frmMain";
         this.Text = "Accessibility Functionality Demonstration";

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

      private Object GetAccessibleOption(Object Struct, 
                                         Int32 StructSize, 
                                         AccessType AccessType, 
                                         WinIniFlags IniFlag)
      {
         Object   ReturnValue;   // The return data.

         // Allocate enough memory to create an unmanaged version
         // of the data structure.
         IntPtr   DataPtr = Marshal.AllocHGlobal(StructSize);

         // Point to the managed data stucture using the unmanaged
         // memory pointer.
         Marshal.StructureToPtr(Struct, DataPtr, true);

         // Call the SystemParametersInfo() function using the
         // unmanaged data structure pointer.
         Accessible.SystemParametersInfo(AccessType,
                                         Convert.ToUInt32(StructSize),
                                         DataPtr,
                                         IniFlag);

         // Move the data retrieved from the umnanaged environment to
         // the managed data structure and return this data structure
         // as an object.
         ReturnValue = Marshal.PtrToStructure(DataPtr, Struct.GetType());

         // Deallocate the memory we previously allocated.
         Marshal.FreeHGlobal(DataPtr);

         // Return the data.
         return ReturnValue;
      }

      private bool SetAccessibleOption(Object Struct, 
                                       Int32 StructSize, 
                                       AccessType AccessType, 
                                       WinIniFlags IniFlag)
      {
         bool  ReturnValue;   // The return value of this method.

         // Allocate enough memory to create an unmanaged version
         // of the data structure.
         IntPtr   DataPtr = Marshal.AllocHGlobal(StructSize);

         // Point to the managed data stucture using the unmanaged
         // memory pointer.
         Marshal.StructureToPtr(Struct, DataPtr, true);

         // Return true if the SystemParametersInfo() function call
         // successfully modifies the Windows Accessibility features
         // using the data in the data structure.
         ReturnValue = Accessible.SystemParametersInfo(
            AccessType,
            Convert.ToUInt32(StructSize),
            DataPtr,
            IniFlag);

         // Deallocate the memory we previously allocated.
         Marshal.FreeHGlobal(DataPtr);

         // Return the data.
         return ReturnValue;
      }

      private void mnuFileExit_Click(object sender, System.EventArgs e)
      {
         // Exit the application.
         Close();
      }

      private void mnuChooseAccessTimeout_Click(object sender, System.EventArgs e)
      {
         Int32 DataSize;   // Size of the data structure.

         // Set the flag value as needed to toggle the feature on or off.
         if ((AT.dwFlags & (Int32)AccessTimeoutFlags.ATF_TIMEOUTON) ==
                           (Int32)AccessTimeoutFlags.ATF_TIMEOUTON)
            AT.dwFlags = AT.dwFlags ^ 
               (Int32)AccessTimeoutFlags.ATF_TIMEOUTON;
         else
            AT.dwFlags = AT.dwFlags | 
               (Int32)AccessTimeoutFlags.ATF_TIMEOUTON;

         // Call on the library function to set the new FilterKeys status.
         DataSize = Marshal.SizeOf(AT);

         // If the function fails, display an error message.
         if (!SetAccessibleOption(AT, 
                                  DataSize, 
                                  AccessType.SPI_SETACCESSTIMEOUT, 
                                  WinIniFlags.SPIF_NONE))
            MessageBox.Show("Could not set the Access Timeout option",
                            "Accessibility Option Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

         // If the function succeeds, display a success message and change
         // the menu setting.
         else
            mnuChooseAccessTimeout.Checked = !mnuChooseAccessTimeout.Checked;
      }

      private void mnuChooseFilterKeys_Click(object sender, System.EventArgs e)
      {
         Int32 DataSize;   // Size of the data structure.

         // Set the flag value as needed to toggle the feature on or off.
         if ((FK.dwFlags & (Int32)FilterKeysFlags.FKF_FILTERKEYSON) ==
                           (Int32)FilterKeysFlags.FKF_FILTERKEYSON)
            FK.dwFlags = FK.dwFlags ^ 
               (Int32)FilterKeysFlags.FKF_FILTERKEYSON;
         else
            FK.dwFlags = FK.dwFlags | 
               (Int32)FilterKeysFlags.FKF_FILTERKEYSON;

         // Call on the library function to set the new FilterKeys status.
         DataSize = Marshal.SizeOf(FK);

         // If the function fails, display an error message.
         if (!SetAccessibleOption(FK, 
                                  DataSize, 
                                  AccessType.SPI_SETFILTERKEYS, 
                                  WinIniFlags.SPIF_NONE))
            MessageBox.Show("Could not set the FilterKeys option",
                            "Accessibility Option Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

         // If the function succeeds, display a success message and change
         // the menu setting.
         else
            mnuChooseFilterKeys.Checked = !mnuChooseFilterKeys.Checked;
      }

      private void mnuChooseHighContrast_Click(object sender, System.EventArgs e)
      {
         Int32 DataSize;   // Size of the data structure.

         // Set the flag value as needed to toggle the feature on or off.
         if ((HC.dwFlags & (Int32)HighContrastFlags.HCF_HIGHCONTRASTON) ==
                           (Int32)HighContrastFlags.HCF_HIGHCONTRASTON)
            HC.dwFlags = HC.dwFlags ^ 
               (Int32)HighContrastFlags.HCF_HIGHCONTRASTON;
         else
            HC.dwFlags = HC.dwFlags | 
               (Int32)HighContrastFlags.HCF_HIGHCONTRASTON;

         // Call on the library function to set the new FilterKeys status.
         DataSize = Marshal.SizeOf(HC);

         // If the function fails, display an error message.
         if (!SetAccessibleOption(HC, 
                                  DataSize, 
                                  AccessType.SPI_SETHIGHCONTRAST, 
                                  WinIniFlags.SPIF_NONE))
            MessageBox.Show("Could not set the High Contrast option",
                            "Accessibility Option Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

         // If the function succeeds, display a success message and change
         // the menu setting.
         else
            mnuChooseHighContrast.Checked = !mnuChooseHighContrast.Checked;
      }

      private void mnuChooseMouseKeys_Click(object sender, System.EventArgs e)
      {
         Int32 DataSize;   // Size of the data structure.

         // Set the flag value as needed to toggle the feature on or off.
         if ((MK.dwFlags & (Int32)MouseKeysFlags.MKF_MOUSEKEYSON) ==
                           (Int32)MouseKeysFlags.MKF_MOUSEKEYSON)
            MK.dwFlags = MK.dwFlags ^ 
               (Int32)MouseKeysFlags.MKF_MOUSEKEYSON;
         else
            MK.dwFlags = MK.dwFlags | 
               (Int32)MouseKeysFlags.MKF_MOUSEKEYSON;

         // Call on the library function to set the new FilterKeys status.
         DataSize = Marshal.SizeOf(MK);

         // If the function fails, display an error message.
         if (!SetAccessibleOption(MK, 
                                  DataSize, 
                                  AccessType.SPI_SETMOUSEKEYS, 
                                  WinIniFlags.SPIF_NONE))
            MessageBox.Show("Could not set the MouseKeys option",
                            "Accessibility Option Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

         // If the function succeeds, display a success message and change
         // the menu setting.
         else
            mnuChooseMouseKeys.Checked = !mnuChooseMouseKeys.Checked;
      }

      private void mnuChooseScreenReader_Click(object sender, System.EventArgs e)
      {
         // You can't turn the screen reader on and off using a menu option.
         MessageBox.Show("This is a status indicator only. Set the screen " +
                         "reader on using the Narrator application on the " +
                         "Accessibility menu.",
                         "Accessibility Option Status",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
      }

      private void mnuChooseSerialKeys_Click(object sender, System.EventArgs e)
      {
         // You shouldn't turn SerialKeys on and off using a menu option.
         MessageBox.Show("This is a status indicator only. Set " +
                         "SerialKeys on by adding a SerialKeys " +
                         "device to your system and modifying " +
                         "the Control Panel setting.",
                         "Accessibility Option Status",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
      }

      private void mnuChooseShowSounds_Click(object sender, System.EventArgs e)
      {
         Int32 DataSize;   // Size of the data structure.

         // Set the flag value as needed to toggle the feature on or off.
         SSound = !SSound;

         // Call on the library function to set the new FilterKeys status.
         DataSize = Marshal.SizeOf(SSound);

         // If the function fails, display an error message.
         if (!SetAccessibleOption(IntPtr.Zero, 
                                  Convert.ToInt32(SSound), 
                                  AccessType.SPI_SETSHOWSOUNDS, 
                                  WinIniFlags.SPIF_NONE))
            MessageBox.Show("Could not set the ShowSounds option",
                            "Accessibility Option Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

         // If the function succeeds, display a success message and change
         // the menu setting.
         else
            mnuChooseShowSounds.Checked = !mnuChooseShowSounds.Checked;
      }

      private void mnuChooseSoundSentry_Click(object sender, System.EventArgs e)
      {
         Int32 DataSize;   // Size of the data structure.

         // Set the flag value as needed to toggle the feature on or off.
         if ((SSentry.dwFlags & (Int32)SoundSentryFlags.SSF_SOUNDSENTRYON) ==
            (Int32)SoundSentryFlags.SSF_SOUNDSENTRYON)
            SSentry.dwFlags = SSentry.dwFlags ^ 
               (Int32)SoundSentryFlags.SSF_SOUNDSENTRYON;
         else
         {
            SSentry.dwFlags = SSentry.dwFlags | 
               (Int32)SoundSentryFlags.SSF_SOUNDSENTRYON;
            SSentry.iWindowsEffect = (Int32)SoundSentryWindowsEffects.SSWF_TITLE;
         }

         // Call on the library function to set the new FilterKeys status.
         DataSize = Marshal.SizeOf(SSentry);

         // If the function fails, display an error message.
         if (!SetAccessibleOption(SSentry, 
                                  DataSize, 
                                  AccessType.SPI_SETSOUNDSENTRY, 
                                  WinIniFlags.SPIF_NONE))
            MessageBox.Show("Could not set the SoundSentry option",
                            "Accessibility Option Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

         // If the function succeeds, display a success message and change
         // the menu setting.
         else
            mnuChooseSoundSentry.Checked = !mnuChooseSoundSentry.Checked;
      }

      private void mnuChooseStickyKeys_Click(object sender, System.EventArgs e)
      {
         Int32 DataSize;   // Size of the data structure.

         // Set the flag value as needed to toggle the feature on or off.
         if ((SK.dwFlags & (Int32)StickyKeysFlags.SKF_STICKYKEYSON) ==
                           (Int32)StickyKeysFlags.SKF_STICKYKEYSON)
            SK.dwFlags = SK.dwFlags ^ 
               (Int32)StickyKeysFlags.SKF_STICKYKEYSON;
         else
            SK.dwFlags = SK.dwFlags | 
               (Int32)StickyKeysFlags.SKF_STICKYKEYSON;

         // Call on the library function to set the new FilterKeys status.
         DataSize = Marshal.SizeOf(SK);

         // If the function fails, display an error message.
         if (!SetAccessibleOption(SK, 
                                  DataSize, 
                                  AccessType.SPI_SETSTICKYKEYS, 
                                  WinIniFlags.SPIF_NONE))
            MessageBox.Show("Could not set the StickyKeys option",
                            "Accessibility Option Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

         // If the function succeeds, display a success message and change
         // the menu setting.
         else
            mnuChooseStickyKeys.Checked = !mnuChooseStickyKeys.Checked;
      }

      private void mnuChooseToggleKeys_Click(object sender, System.EventArgs e)
      {
         Int32 DataSize;   // Size of the data structure.

         // Set the flag value as needed to toggle the feature on or off.
         if ((TK.dwFlags & (Int32)ToggleKeysFlags.TKF_TOGGLEKEYSON) ==
                           (Int32)ToggleKeysFlags.TKF_TOGGLEKEYSON)
            TK.dwFlags = TK.dwFlags ^ 
               (Int32)ToggleKeysFlags.TKF_TOGGLEKEYSON;
         else
            TK.dwFlags = TK.dwFlags | 
               (Int32)ToggleKeysFlags.TKF_TOGGLEKEYSON;

         // Call on the library function to set the new FilterKeys status.
         DataSize = Marshal.SizeOf(TK);

         // If the function fails, display an error message.
         if (!SetAccessibleOption(TK, 
                                  DataSize, 
                                  AccessType.SPI_SETTOGGLEKEYS, 
                                  WinIniFlags.SPIF_NONE))
            MessageBox.Show("Could not set the ToggleKeys option",
                            "Accessibility Option Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

         // If the function succeeds, display a success message and change
         // the menu setting.
         else
            mnuChooseToggleKeys.Checked = !mnuChooseToggleKeys.Checked;
      }
	}
}
