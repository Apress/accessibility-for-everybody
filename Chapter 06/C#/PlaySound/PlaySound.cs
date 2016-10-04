using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PlaySound
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class PlaySound : Component
	{
      #region Private field values.
      // Determines if the system will make a sound.
      private bool _MakeSound;
      // Contains the name of the file to play.
      private string _SoundFileName;
      // Describes the sound to the person using ShowSounds.
      private string _ShowSoundsDescription;
      // Determines the hover delay for the tooltip
      // displaying the sound description.
      private int _AutomaticDelay;
      // Determines the amount of time the tooltip
      // will appear on screen.
      private int _AutoPopDelay;

      // Sound Text Description ToolTip
      private ToolTip  TT;

      // This special object controls the disappearance of
      // the sound description tooltip.
      private Timer NoShow;
      #endregion

      /// <summary>
      /// PlaySound constructor.
      /// </summary>
		public PlaySound()
		{
         // Initialize the property values.
         _MakeSound = true;
         _SoundFileName = "";
         _ShowSoundsDescription = "The System Plays a Sound";
         _AutomaticDelay = 300;
         _AutoPopDelay = 7000;
         NoShow = new Timer();
		}

      #region PlaySound Events
      /// <summary>
      /// This event fires when the system displays a
      /// ShowSounds message.
      /// </summary>
      [Description("This event fires when the system displays a " +
                   "ShowSounds message.")]
      public event EventHandler SoundDisplayed;

      /// <summary>
      /// This event fires when the system generates a
      /// sound.
      /// </summary>
      [Description("This event fires when the system generates a" +
                   "sound.")]
      public event EventHandler SoundGenerated;
      #endregion

      #region PlaySound Properties
      // Each of these properties gets and/or sets a private
      // field within the component.

      /// <summary>
      /// Determines if the system will make a sound.
      /// </summary>
      [Description("Determines if the system will make a sound.")]
      public bool MakeSound
      {
         get {return _MakeSound;}
         set {_MakeSound = value;}
      }

      // This property requires a special editor to ensure it works
      // as intended.
      /// <summary>
      /// Contains the name of the file to play.
      /// </summary>
      [Description("Contains the name of the file to play.")]
      [EditorAttribute(typeof(FileNameEditor), typeof(UITypeEditor))]
      public string SoundFileName
      {
         get
         {
            return _SoundFileName;
         }
         set
         {
            _SoundFileName = value;
         }
      }

      /// <summary>
      /// Describes the sound to the person using ShowSounds.
      /// </summary>
      [Description("Describes the sound to the person using ShowSounds.")]
      public string ShowSoundsDescription
      {
         get {return _ShowSoundsDescription;}
         set
         {
            if (value != null)
               _ShowSoundsDescription = value;
         }
      }

      /// <summary>
      /// Determines the hover delay for the tooltip
      /// displaying the sound description. (1 ms minimum)
      /// </summary>
      [Description("Determines the hover delay for the tooltip " +
                   "displaying the sound description. (1 ms minimum)")]
      public int AutomaticDelay
      {
         get {return _AutomaticDelay;}
         set
         {
            if (value >= 1)
               _AutomaticDelay = value;
         }
      }

      /// <summary>
      /// Determines the amount of time the tooltip
      /// will appear on screen. (3000 ms minimum)
      /// </summary>
      [Description("Determines the amount of time the tooltip " +
                   "will appear on screen. (3000 ms minimum)")]
      public int AutoPopDelay
      {
         get {return _AutoPopDelay;}
         set
         {
            if (value >= 3000)
               _AutoPopDelay = value;
         }
      }
      #endregion

      #region PlaySound Methods
      /// <summary>
      /// Outputs a sound and/or a sound description based
      /// upon the current ShowSound Windows Accessiblity setting.
      /// </summary>
      /// <param name="Parent">The control hosting the sound.</param>
      [Description("Plays the sound requested by the user " +
                   "or displays a text equivlaent.")]
      public void GenerateSound(Control Parent)
      {
         System.EventArgs  EA;   // Used When Raising an Event.

         // Initialize the EventArgs.
         EA = new EventArgs();

         // Initialize the ToolTip.
         TT = new ToolTip();
         TT.AutomaticDelay = _AutomaticDelay;
         TT.AutoPopDelay = _AutoPopDelay;

         // Intitialze the Timer.
         NoShow.Interval = _AutoPopDelay;
         NoShow.Tick += new EventHandler(this.NoShow_Tick);

         // If the ShowSounds option is selected, display text.
         if (IsShowSoundsSelected())
         {
            // Display the information on screen.
            TT.SetToolTip(Parent, _ShowSoundsDescription);
            TT.Active = true;
            NoShow.Start();

            // Fire the event.
            if (SoundDisplayed != null)
               SoundDisplayed(this, EA);
         }

         if (_MakeSound)
         {
            // Play a sound only when the user requests it.
            WinPlaySound(@_SoundFileName, 
               0, 
               SND_FILENAME | SND_ASYNC);

            // Fire the event.
            if (SoundGenerated != null)
               SoundGenerated(this, EA);
         }
      }

      /// <summary>
      /// Obtains the current status of the ShowSounds
      /// Windows Accessibility setting.
      /// </summary>
      /// <returns>True or False depending on setting value</returns>
      [Description("Returns true when the user has ShowSounds enabled.")]
      public bool IsShowSoundsSelected()
      {
         return SystemInformation.ShowSounds;
      }
      #endregion

      #region Win32 API Code
      // Define some constants for using the PlaySound() function.
      private const int SND_SYNC = 0x0000;
      private const int SND_ASYNC = 0x0001;
      private const int SND_FILENAME = 0x00020000;

      // Import the Windows PlaySound() function.
      [DllImport("winmm.dll", 
          EntryPoint="PlaySound", CharSet=CharSet.Auto, SetLastError=true)]
      private static extern bool WinPlaySound(string pszSound,  
                                              int hmod,     
                                              int fdwSound);
      #endregion
	
      #region EventHandlers
      private void NoShow_Tick(Object sender, System.EventArgs e)
      {
         // Stop displaying the sound description.
         TT.Active = false;

         // Stop the timer.
         NoShow.Stop();
      }
      #endregion
   }
}
