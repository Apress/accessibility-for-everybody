using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace AccessFuncs
{
   #region Enumerations

   /// <summary>
   /// This enumeration contains a list of common constants used
   /// to interact with the Windows Accessibility features.
   /// </summary>
   [Description("This enumeration contains a list of common constants used " + 
                "to interact with the Windows Accessibility features.")]
   public enum AccessType : uint
   {
      /// <summary>
      /// Gets the high contrast information using the
      /// HIGHCONTRAST data structure.
      /// </summary>
      [Description("Gets the high contrast information using the " +
                   "HIGHCONTRAST data structure.")]
      SPI_GETHIGHCONTRAST  = 0x0042,
      /// <summary>
      /// Sets the high contrast information using the
      /// HIGHCONTRAST data structure.
      /// </summary>
      [Description("Sets the high contrast information using the " +
                   "HIGHCONTRAST data structure.")]
      SPI_SETHIGHCONTRAST  = 0x0043,
      /// <summary>
      /// Gets the screen readers status. Unlike some other
      /// accessibility settings, this one relies on a BOOL,
      /// rather than a data structure for input.
      /// </summary>
      [Description("Gets the screen readers status. Unlike some other " +
                   "accessibility settings, this one relies on a BOOL," +
                   "rather than a data structure for input.")]
      SPI_GETSCREENREADER  = 0x0046,
      /// <summary>
      /// Sets the screen readers status. Unlike some other
      /// accessibility settings, this one relies on a BOOL,
      /// rather than a data structure for input.
      /// </summary>
      [Description("Sets the screen readers status. Unlike some other " +
                   "accessibility settings, this one relies on a BOOL," +
                   "rather than a data structure for input.")]
      SPI_SETSCREENREADER  = 0x0047,
      /// <summary>
      /// Gets the FilterKeys information using the
      /// FILTERKEYS data structure.
      /// </summary>
      [Description("Gets the FilterKeys information using the " +
                   "FILTERKEYS data structure.")]
      SPI_GETFILTERKEYS    = 0x0032,
      /// <summary>
      /// Sets the FilterKeys information using the
      /// FILTERKEYS data structure.
      /// </summary>
      [Description("Sets the FilterKeys information using the " +
                   "FILTERKEYS data structure.")]
      SPI_SETFILTERKEYS    = 0x0033,
      /// <summary>
      /// Gets the ToggleKeys information using the
      /// TOGGLEKEYS data structure.
      /// </summary>
      [Description("Gets the ToggleKeys information using the " +
                   "TOGGLEKEYS data structure.")]
      SPI_GETTOGGLEKEYS    = 0x0034,
      /// <summary>
      /// Sets the ToggleKeys information using the
      /// TOGGLEKEYS data structure.
      /// </summary>
      [Description("Sets the ToggleKeys information using the " +
                   "TOGGLEKEYS data structure.")]
      SPI_SETTOGGLEKEYS    = 0x0035,
      /// <summary>
      /// Gets the MouseKeys information using the
      /// MOUSEKEYS data structure.
      /// </summary>
      [Description("Gets the MouseKeys information using the " +
                   "MOUSEKEYS data structure.")]
      SPI_GETMOUSEKEYS     = 0x0036,
      /// <summary>
      /// Sets the MouseKeys information using the
      /// MOUSEKEYS data structure.
      /// </summary>
      [Description("Sets the MouseKeys information using the " +
                   "MOUSEKEYS data structure.")]
      SPI_SETMOUSEKEYS     = 0x0037,
      /// <summary>
      /// Gets the ShowSounds status. Unlike some other
      /// accessibility settings, this one relies on a BOOL,
      /// rather than a data structure for input. Microsoft
      /// recommends using the GetSystemMetrics(SM_SHOWSOUNDS)
      /// function in place of this call.
      /// </summary>
      [Description("Gets the ShowSounds status. Unlike some other " +
                   "accessibility settings, this one relies on a BOOL, " +
                   "rather than a data structure for input. Microsoft " +
                   "recommends using the GetSystemMetrics(SM_SHOWSOUNDS) " +
                   "function in place of this call.")]
      SPI_GETSHOWSOUNDS    = 0x0038,
      /// <summary>
      /// Sets the ShowSounds status. Unlike some other
      /// accessibility settings, this one relies on a BOOL,
      /// rather than a data structure for input. Microsoft
      /// recommends using the GetSystemMetrics(SM_SHOWSOUNDS)
      /// function in place of this call.
      /// </summary>
      [Description("Sets the ShowSounds status. Unlike some other " +
                   "accessibility settings, this one relies on a BOOL, " +
                   "rather than a data structure for input. Microsoft " +
                   "recommends using the GetSystemMetrics(SM_SHOWSOUNDS) " +
                   "function in place of this call.")]
      SPI_SETSHOWSOUNDS    = 0x0039,
      /// <summary>
      /// Gets the StickyKeys information using the
      /// STICKYKEYS data structure.
      /// </summary>
      [Description("Gets the StickyKeys information using the " +
                   "STICKYKEYS data structure.")]
      SPI_GETSTICKYKEYS    = 0x003A,
      /// <summary>
      /// Sets the StickyKeys information using the
      /// STICKYKEYS data structure.
      /// </summary>
      [Description("Sets the StickyKeys information using the " +
                   "STICKYKEYS data structure.")]
      SPI_SETSTICKYKEYS    = 0x003B,
      /// <summary>
      /// Gets the Windows Accessibility Timeout information 
      /// using the ACCESSTIMEOUT data structure.
      /// </summary>
      [Description("Gets the Windows Accessibility Timeout information " +
                   "using the ACCESSTIMEOUT data structure.")]
      SPI_GETACCESSTIMEOUT = 0x003C,
      /// <summary>
      /// Sets the Windows Accessibility Timeout information 
      /// using the ACCESSTIMEOUT data structure.
      /// </summary>
      [Description("Sets the Windows Accessibility Timeout information " +
                   "using the ACCESSTIMEOUT data structure.")]
      SPI_SETACCESSTIMEOUT = 0x003D,
      /// <summary>
      /// Gets the SerialKeys information using the
      /// SERIALKEYS data structure.
      /// </summary>
      [Description("Gets the SerialKeys information using the " +
                   "SERIALKEYS data structure.")]
      SPI_GETSERIALKEYS    = 0x003E,
      /// <summary>
      /// Sets the SerialKeys information using the
      /// SERIALKEYS data structure.
      /// </summary>
      [Description("Sets the SerialKeys information using the " +
                   "SERIALKEYS data structure.")]
      SPI_SETSERIALKEYS    = 0x003F,
      /// <summary>
      /// Gets the SoundSentry information using the
      /// SOUNDSENTRY data structure.
      /// </summary>
      [Description("Gets the SoundSentry information using the " +
                   "SOUNDSENTRY data structure.")]
      SPI_GETSOUNDSENTRY   = 0x0040,
      /// <summary>
      /// Gets the SoundSentry information using the
      /// SOUNDSENTRY data structure.
      /// </summary>
      [Description("Gets the SoundSentry information using the " +
                   "SOUNDSENTRY data structure.")]
      SPI_SETSOUNDSENTRY   = 0x0041
   }

   /// <summary>
   /// This enumeration contains the flags used to control
   /// update of the user profile. Select SPIF_NONE if the
   /// application does not need to update the profile.
   /// </summary>
   [Description("This enumeration contains the flags used to control " +
                "update of the user profile. Select SPIF_NONE if the " +
                "application does not need to update the profile.")]
   public enum WinIniFlags
   {
      /// <summary>
      /// Doesn't perform any type of profile update.
      /// </summary>
      [Description("Doesn't perform any type of profile update.")]
      SPIF_NONE             = 0x0000,
      /// <summary>
      /// Writes the update to the user profile.
      /// </summary>
      [Description("Writes the update to the user profile.")]
      SPIF_UPDATEINIFILE    = 0x0001,
      /// <summary>
      /// Writes the update to the user profile and
      /// broadcasts the WM_SETTINGCHANGE message.
      /// </summary>
      [Description("Writes the update to the user profile and " +
                   "broadcasts the WM_SETTINGCHANGE message.")]
      SPIF_SENDWININICHANGE = 0x0002,
      /// <summary>
      /// Writes the update to the user profile and
      /// broadcasts the WM_SETTINGCHANGE message.
      /// </summary>
      [Description("Writes the update to the user profile and " +
                   "broadcasts the WM_SETTINGCHANGE message.")]
      SPIF_SENDCHANGE       = SPIF_SENDWININICHANGE
   }

   /// <summary>
   /// A listing of HighContrast accessibility flags.
   /// </summary>
   [Description("A listing of HighContrast accessibility flags.")]
   public enum HighContrastFlags
   {
      /// <summary>
      /// HighContrast is On
      /// </summary>
      [Description("HighContrast is On")]
      HCF_HIGHCONTRASTON  = 0x00000001,
      /// <summary>
      /// HighContrast is available for use.
      /// </summary>
      [Description("HighContrast is availble for use.")]
      HCF_AVAILABLE       = 0x00000002,
      /// <summary>
      /// HighContrast has the hot key selected.
      /// </summary>
      [Description("HighContrast has the hot key selected.")]
      HCF_HOTKEYACTIVE    = 0x00000004,
      /// <summary>
      /// Confirmation dialog box displayed for 
      /// the HighContrast hot key.
      /// </summary>
      [Description("Confirmation dialog box displayed for " +
                   "the HighContrast hot key.")]
      HCF_CONFIRMHOTKEY   = 0x00000008,
      /// <summary>
      /// Make a sound when HighContrast is selected.
      /// </summary>
      [Description("Make a sound when HighContrast is selected.")]
      HCF_HOTKEYSOUND     = 0x00000010,
      /// <summary>
      /// Display an indicator when HighContrast is selected.
      /// </summary>
      [Description("Display an indicator when HighContrast is selected.")]
      HCF_INDICATOR       = 0x00000020,
      /// <summary>
      /// HighContrast hot key is available.
      /// </summary>
      [Description("HighContrast hot key is available.")]
      HCF_HOTKEYAVAILABLE = 0x00000040
   }

   /// <summary>
   /// A listing of FilterKeys accessibility flags.
   /// </summary>
   [Description("A listing of FilterKeys accessibility flags.")]
   public enum FilterKeysFlags
   {
      /// <summary>
      /// FilterKeys is On
      /// </summary>
      [Description("FilterKeys is On")]
      FKF_FILTERKEYSON    = 0x00000001,
      /// <summary>
      /// FilterKeys is available for use.
      /// </summary>
      [Description("FilterKeys is available for use.")]
      FKF_AVAILABLE       = 0x00000002,
      /// <summary>
      /// The FilterKeys hotkey is active.
      /// </summary>
      [Description("The FilterKeys is active.")]
      FKF_HOTKEYACTIVE    = 0x00000004,
      /// <summary>
      /// Confirmation dialog box displayed for 
      /// the FilterKeys hot key.
      /// </summary>
      [Description("Confirmation dialog box displayed for " +
                   "the FilterKeys hot key.")]
      FKF_CONFIRMHOTKEY   = 0x00000008,
      /// <summary>
      /// Make a sound when changing the FilterKeys status.
      /// </summary>
      [Description("Make a sound when changing the FilterKeys status.")]
      FKF_HOTKEYSOUND     = 0x00000010,
      /// <summary>
      /// Display an indicator when changing the FilterKeys status.
      /// </summary>
      [Description("Display an indicator when changing the FilterKeys status.")]
      FKF_INDICATOR       = 0x00000020,
      /// <summary>
      /// The FilterKeys click is set to on.
      /// </summary>
      [Description("The FilterKeys click is set to on.")]
      FKF_CLICKON         = 0x00000040
   }

   /// <summary>
   /// A listing of ToggleKeys accessibility flags.
   /// </summary>
   [Description("A listing of ToggleKeys accessibility flags.")]
   public enum ToggleKeysFlags
   {
      /// <summary>
      /// ToggleKeys is On
      /// </summary>
      [Description("ToggleKeys is On")]
      TKF_TOGGLEKEYSON    = 0x00000001,
      /// <summary>
      /// ToggleKeys is available for use.
      /// </summary>
      [Description("ToggleKeys is available for use.")]
      TKF_AVAILABLE       = 0x00000002,
      /// <summary>
      /// The ToggleKeys hotkey is active.
      /// </summary>
      [Description("The ToggleKeys is active.")]
      TKF_HOTKEYACTIVE    = 0x00000004,
      /// <summary>
      /// Confirmation dialog box displayed for 
      /// the ToggleKeys hot key.
      /// </summary>
      [Description("Confirmation dialog box displayed for " +
                   "the ToggleKeys hot key.")]
      TKF_CONFIRMHOTKEY   = 0x00000008,
      /// <summary>
      /// Make a sound when changing the ToggleKeys status.
      /// </summary>
      [Description("Make a sound when changing the ToggleKeys status.")]
      TKF_HOTKEYSOUND     = 0x00000010,
      /// <summary>
      /// Display an indicator when changing the ToggleKeys status.
      /// </summary>
      [Description("Display an indicator when changing the ToggleKeys status.")]
      TKF_INDICATOR       = 0x00000020
   }

   /// <summary>
   /// A listing of MouseKeys accessibility flags.
   /// </summary>
   [Description("A listing of MouseKeys accessibility flags.")]
   public enum MouseKeysFlags : uint
   {
      /// <summary>
      /// MouseKeys is On
      /// </summary>
      [Description("MouseKeys is On")]
      MKF_MOUSEKEYSON     = 0x00000001,
      /// <summary>
      /// MouseKeys is available for use.
      /// </summary>
      [Description("MouseKeys is available for use.")]
      MKF_AVAILABLE       = 0x00000002,
      /// <summary>
      /// The MouseKeys hotkey is active.
      /// </summary>
      [Description("The MouseKeys is active.")]
      MKF_HOTKEYACTIVE    = 0x00000004,
      /// <summary>
      /// Confirmation dialog box displayed for 
      /// the MouseKeys hot key.
      /// </summary>
      [Description("Confirmation dialog box displayed for " +
                   "the MouseKeys hot key.")]
      MKF_CONFIRMHOTKEY   = 0x00000008,
      /// <summary>
      /// Make a sound when changing the MouseKeys status.
      /// </summary>
      [Description("Make a sound when changing the MouseKeys status.")]
      MKF_HOTKEYSOUND     = 0x00000010,
      /// <summary>
      /// Display an indicator when changing the MouseKeys status.
      /// </summary>
      [Description("Display an indicator when changing the MouseKeys status.")]
      MKF_INDICATOR       = 0x00000020,
      /// <summary>
      /// Use the Ctrl key to speed the mouse up and the 
      /// Shift key to slow the mouse down.
      /// </summary>
      [Description("Use the Ctrl key to speed the mouse up and the" +
                   "Shift key to slow the mouse down.")]
      MKF_MODIFIERS       = 0x00000040,
      /// <summary>
      /// The numeric keypad moves the mouse when Num Lock is
      /// on when set.
      /// </summary>
      [Description("The numeric keypad moves the mouse when Num Lock is" +
                   "on when set.")]
      MKF_REPLACENUMBERS  = 0x00000080,
      /// <summary>
      /// The user wants to use the left button to select.
      /// </summary>
      [Description("The user wants to use the left button to select.")]
      MKF_LEFTBUTTONSEL   = 0x10000000,
      /// <summary>
      /// The user wants to use the right button to select.
      /// </summary>
      [Description("The user wants to use the right button to select.")]
      MKF_RIGHTBUTTONSEL  = 0x20000000,
      /// <summary>
      /// The left button to down.
      /// </summary>
      [Description("The left button to down.")]
      MKF_LEFTBUTTONDOWN  = 0x01000000,
      /// <summary>
      /// The right button to down.
      /// </summary>
      [Description("The right button to down.")]
      MKF_RIGHTBUTTONDOWN = 0x02000000,
      /// <summary>
      /// The system is processing numeric keypad input as mouse movement.
      /// </summary>
      [Description("The system is processing numeric keypad input as mouse movement.")]
      MKF_MOUSEMODE       = 0x80000000
   }

   /// <summary>
   /// A listing of StickyKeys accessibility flags.
   /// </summary>
   [Description("A listing of StickyKeys accessibility flags.")]
   public enum StickyKeysFlags : uint
   {
      /// <summary>
      /// StickyKeys is On
      /// </summary>
      [Description("StickyKeys is On")]
      SKF_STICKYKEYSON      = 0x00000001,
      /// <summary>
      /// StickyKeys is available for use.
      /// </summary>
      [Description("StickyKeys is available for use.")]
      SKF_AVAILABLE         = 0x00000002,
      /// <summary>
      /// The StickyKeys hotkey is active.
      /// </summary>
      [Description("The StickyKeys is active.")]
      SKF_HOTKEYACTIVE      = 0x00000004,
      /// <summary>
      /// Confirmation dialog box displayed for 
      /// the StickyKeys hot key.
      /// </summary>
      [Description("Confirmation dialog box displayed for " +
                   "the StickyKeys hot key.")]
      SKF_CONFIRMHOTKEY     = 0x00000008,
      /// <summary>
      /// Make a sound when changing the StickyKeys status.
      /// </summary>
      [Description("Make a sound when changing the StickyKeys status.")]
      SKF_HOTKEYSOUND       = 0x00000010,
      /// <summary>
      /// Display an indicator when changing the StickyKeys status.
      /// </summary>
      [Description("Display an indicator when changing the StickyKeys status.")]
      SKF_INDICATOR         = 0x00000020,
      /// <summary>
      /// The system plays a sound when the control keys change status.
      /// </summary>
      [Description("The system plays a sound when the control keys change status.")]
      SKF_AUDIBLEFEEDBACK   = 0x00000040,
      /// <summary>
      /// Pressing a key twice locks it--a third time releases it.
      /// </summary>
      [Description("Pressing a key twice locks it--a third time releases it.")]
      SKF_TRISTATE          = 0x00000080,
      /// <summary>
      /// Pressing a control and another key together turns of StickyKeys.
      /// </summary>
      [Description("Pressing a control and another key together turns of StickyKeys.")]
      SKF_TWOKEYSOFF        = 0x00000100,
      /// <summary>
      /// The left Alt key is latched.
      /// </summary>
      [Description("The left Alt key is latched.")]
      SKF_LALTLATCHED       = 0x10000000,
      /// <summary>
      /// The left Ctrl key is latched.
      /// </summary>
      [Description("The left Ctrl key is latched.")]
      SKF_LCTLLATCHED       = 0x04000000,
      /// <summary>
      /// The left Shift key is latched.
      /// </summary>
      [Description("The left Shift key is latched.")]
      SKF_LSHIFTLATCHED     = 0x01000000,
      /// <summary>
      /// The right Alt key is latched.
      /// </summary>
      [Description("The right Alt key is latched.")]
      SKF_RALTLATCHED       = 0x20000000,
      /// <summary>
      /// The right Ctrl key is latched.
      /// </summary>
      [Description("The right Ctrl key is latched.")]
      SKF_RCTLLATCHED       = 0x08000000,
      /// <summary>
      /// The right Shift key is latched.
      /// </summary>
      [Description("The right Shift key is latched.")]
      SKF_RSHIFTLATCHED     = 0x02000000,
      /// <summary>
      /// The left Windows key is latched.
      /// </summary>
      [Description("The left Windows key is latched.")]
      SKF_LWINLATCHED       = 0x40000000,
      /// <summary>
      /// The right Windows key is latched.
      /// </summary>
      [Description("The right Windows key is latched.")]
      SKF_RWINLATCHED       = 0x80000000,
      /// <summary>
      /// The left Alt key is locked.
      /// </summary>
      [Description("The left Alt key is locked.")]
      SKF_LALTLOCKED        = 0x00100000,
      /// <summary>
      /// The left Ctrl key is locked.
      /// </summary>
      [Description("The left Ctrl key is locked.")]
      SKF_LCTLLOCKED        = 0x00040000,
      /// <summary>
      /// The left Shift key is locked.
      /// </summary>
      [Description("The left Shift key is locked.")]
      SKF_LSHIFTLOCKED      = 0x00010000,
      /// <summary>
      /// The right Alt key is locked.
      /// </summary>
      [Description("The right Alt key is locked.")]
      SKF_RALTLOCKED        = 0x00200000,
      /// <summary>
      /// The right Ctrl key is locked.
      /// </summary>
      [Description("The right Ctrl key is locked.")]
      SKF_RCTLLOCKED        = 0x00080000,
      /// <summary>
      /// The right Shift key is locked.
      /// </summary>
      [Description("The right Shift key is locked.")]
      SKF_RSHIFTLOCKED      = 0x00020000,
      /// <summary>
      /// The left Windows key is locked.
      /// </summary>
      [Description("The left Windows key is locked.")]
      SKF_LWINLOCKED        = 0x00400000,
      /// <summary>
      /// The right Windows key is locked.
      /// </summary>
      [Description("The right Windows key is locked.")]
      SKF_RWINLOCKED        = 0x00800000
   }

   /// <summary>
   /// A listing of Windows Accessibility timeout flags.
   /// </summary>
   [Description("A listing of Windows Accessibility timeout flags.")]
   public enum AccessTimeoutFlags
   {
      /// <summary>
      /// If this flag is set, the user has set a timeout value
      /// and the Windows Accessibility features will turn off
      /// after a given time period. If this flag is cleared, the
      /// Windows Accessibility features are always available.
      /// </summary>
      [Description("If this flag is set, the user has set a timeout value " +
                   "and the Windows Accessibility features will turn off " +
                   "after a given time period. If this flag is cleared, the " +
                   "Windows Accessibility features are always available.")]
      ATF_TIMEOUTON       = 0x00000001,
      /// <summary>
      /// Make a sound when changing the timeout status.
      /// </summary>
      [Description("Make a sound when changing the timeout status.")]
      ATF_ONOFFFEEDBACK   = 0x00000002
   }

   /// <summary>
   /// A listing of SerialKeys accessibility flags.
   /// </summary>
   [Description("A listing of SerialKeys accessibility flags.")]
   public enum SerialKeysFlags
   {
      /// <summary>
      /// SerialKeys is On
      /// </summary>
      [Description("SerialKeys is On")]
      SERKF_SERIALKEYSON  = 0x00000001,
      /// <summary>
      /// SerialKeys is available for use. This flag is not
      /// implemented
      /// </summary>
      [Description("SerialKeys is available for use. This flag is not " +
                   "implemented")]
      SERKF_AVAILABLE     = 0x00000002,
      /// <summary>
      /// Display an indicator when changing the SerialKeys status.
      /// </summary>
      [Description("Display an indicator when changing the SerialKeys status.")]
      SERKF_INDICATOR     = 0x00000004
   }

   /// <summary>
   /// A listing of SoundSentry accessibility flags.
   /// </summary>
   [Description("A listing of SoundSentry accessibility flags.")]
   public enum SoundSentryFlags
   {
      /// <summary>
      /// SoundSentry is On
      /// </summary>
      [Description("SoundSentry is On")]
      SSF_SOUNDSENTRYON   = 0x00000001,
      /// <summary>
      /// SoundSentry is available for use. This flag is not
      /// implemented
      /// </summary>
      [Description("SoundSentry is available for use. This flag is not " +
                   "implemented")]
      SSF_AVAILABLE       = 0x00000002,
      /// <summary>
      /// Display an indicator when changing the SoundSentry
      /// status.
      /// </summary>
      [Description("Display an indicator when changing the SoundSentry " +
                   "status.")]
      SSF_INDICATOR       = 0x00000004
   }

   /// <summary>
   /// Contains a list of the possible screen effects for a
   /// full screen DOS text mode application.
   /// </summary>
   [Description("Contains a list of the possible screen effects for a " +
                "full screen DOS text mode application.")]
   public enum SoundSentryTextEffects
   {
      /// <summary>
      /// Don't display an effect.
      /// </summary>
      [Description("Don't display an effect.")]
      SSTF_NONE       = 0,
      /// <summary>
      /// Flash the characters in the corner of the screen.
      /// </summary>
      [Description("Flash the characters in the corner of the screen.")]
      SSTF_CHARS      = 1,
      /// <summary>
      /// Flash the border (overscan area) of the screen.
      /// </summary>
      [Description("Flash the border (overscan area) of the screen.")]
      SSTF_BORDER     = 2,
      /// <summary>
      /// Flash the entire screen.
      /// </summary>
      [Description("Flash the entire screen.")]
      SSTF_DISPLAY    = 3
   }

   /// <summary>
   /// Contains a list of the possible screen effects for a
   /// full screen DOS graphics mode application.
   /// </summary>
   [Description("Contains a list of the possible screen effects for a " +
                "full screen DOS graphics mode application.")]
   public enum SoundSentryGraphicEffects
   {
      /// <summary>
      /// Don't display an effect.
      /// </summary>
      [Description("Don't display an effect.")]
      SSGF_NONE       = 0,
      /// <summary>
      /// Flash the entire screen.
      /// </summary>
      [Description("Flash the entire screen.")]
      SSGF_DISPLAY    = 3
   }

   /// <summary>
   /// Contains a list of the possible screen effects for a
   /// Windows application.
   /// </summary>
   [Description("Contains a list of the possible screen effects for a " +
                "Windows application.")]
   public enum SoundSentryWindowsEffects
   {
      /// <summary>
      /// Don't display an effect.
      /// </summary>
      [Description("Don't display an effect.")]
      SSWF_NONE     = 0,
      /// <summary>
      /// Flash the title bar of the active application.
      /// </summary>
      [Description("Flash the title bar of the active application.")]
      SSWF_TITLE    = 1,
      /// <summary>
      /// Flash the entire active application window.
      /// </summary>
      [Description("Flash the entire active application window.")]
      SSWF_WINDOW   = 2,
      /// <summary>
      /// Flash the entire screen.
      /// </summary>
      [Description("Flash the entire screen.")]
      SSWF_DISPLAY  = 3,
      /// <summary>
      /// Use the custom flashing method specified by the
      /// SoundSentryProc() function found in the DLL
      /// specified by the iFSWindowsEffectDLL member.
      /// </summary>
      [Description("Use the custom flashing method specified by the " +
                   "SoundSentryProc() function found in the DLL " +
                   "specified by the iFSWindowsEffectDLL member. ")]
      SSWF_CUSTOM   = 4
   }
   #endregion

   #region Data Structures
   /// <summary>
   /// Contains the HighContrast accessibility setting information.
   /// </summary>
   [Description("Contains the HighContrast accessibility setting information.")]
   [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
   public struct HIGHCONTRAST
   {
      /// <summary>
      /// Contains the size of the data structure.
      /// </summary>
      [Description("Contains the size of the data structure.")]
      public UInt32   cbSize;
      /// <summary>
      /// Contains the settings flags for the data structure.
      /// </summary>
      [Description("Contains the settings flags for the data structure.")]
      public Int32    dwFlags;
      /// <summary>
      /// Contains a text description of the current scheme.
      /// </summary>
      [Description("Contains a text description of the current scheme.")]
      [MarshalAs(UnmanagedType.LPWStr, SizeConst=80)]
      public String   lpszDefaultScheme;
   }

   /// <summary>
   /// Contains the FilterKeys accessibility setting information.
   /// </summary>
   [Description("Contains the FilterKeys accessibility setting information.")]
   [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
   public struct FILTERKEYS
   {
      /// <summary>
      /// Contains the size of the data structure.
      /// </summary>
      [Description("Contains the size of the data structure.")]
      public UInt32  cbSize;
      /// <summary>
      /// Contains the settings flags for the data structure.
      /// </summary>
      [Description("Contains the settings flags for the data structure.")]
      public Int32   dwFlags;
      /// <summary>
      /// Defines the Acceptance Delay value.
      /// </summary>
      [Description("Defines the Acceptance Delay value.")]
      public Int32   iWaitMSec;
      /// <summary>
      /// Defines the Delay Until Repeat value.
      /// </summary>
      [Description("Defines the Delay Until Repeat value.")]
      public Int32   iDelayMSec;
      /// <summary>
      /// Defines the Repeat Rate value.
      /// </summary>
      [Description("Defines the Repeat Rate value.")]
      public Int32   iRepeatMSec;
      /// <summary>
      /// Defines the Debounce Time value.
      /// </summary>
      [Description("Defines the Debounce Time value.")]
      public Int32   iBounceMSec;
   }

   /// <summary>
   /// Contains the ToggleKeys accessibility setting information.
   /// </summary>
   [Description("Contains the ToggleKeys accessibility setting information.")]
   [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
   public struct TOGGLEKEYS
   {
      /// <summary>
      /// Contains the size of the data structure.
      /// </summary>
      [Description("Contains the size of the data structure.")]
      public UInt32  cbSize;
      /// <summary>
      /// Contains the settings flags for the data structure.
      /// </summary>
      [Description("Contains the settings flags for the data structure.")]
      public Int32   dwFlags;
   }

   /// <summary>
   /// Contains the MouseKeys accessibility setting information.
   /// </summary>
   [Description("Contains the MouseKeys accessibility setting information.")]
   [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
   public struct MOUSEKEYS
   {
      /// <summary>
      /// Contains the size of the data structure.
      /// </summary>
      [Description("Contains the size of the data structure.")]
      public UInt32  cbSize;
      /// <summary>
      /// Contains the settings flags for the data structure.
      /// </summary>
      [Description("Contains a the settings flags for the data structure.")]
      public UInt32  dwFlags;
      /// <summary>
      /// Contains the maximum speed setting of the mouse.
      /// </summary>
      [Description("Contains the maximum speed setting of the mouse.")]
      public Int32   iMaxSpeed;
      /// <summary>
      /// Contains the acceleration setting of the mouse.
      /// </summary>
      [Description("Contains the acceleration setting of the mouse.")]
      public Int32   iTimeToMaxSpeed;
      /// <summary>
      /// Contains the control speed setting of the mouse.
      /// Ignored if MKF_MODIFIERS is not set.
      /// </summary>
      [Description("Contains the control speed setting of the mouse. " +
                   "Ignored if MKF_MODIFIERS is not set.")]
      public Int32   iCtrlSpeed;
      /// <summary>
      /// Reserved--Do Not Use
      /// </summary>
      [Description("Reserved--Do Not Use")]
      public Int32   dwReserved1;
      /// <summary>
      /// Reserved--Do Not Use
      /// </summary>
      [Description("Reserved--Do Not Use")]
      public Int32   dwReserved2;
   }

   /// <summary>
   /// Contains the StickyKeys accessibility setting information.
   /// </summary>
   [Description("Contains the StickyKeys accessibility setting information.")]
   [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
   public struct STICKYKEYS
   {
      /// <summary>
      /// Contains the size of the data structure.
      /// </summary>
      [Description("Contains the size of the data structure.")]
      public UInt32  cbSize;
      /// <summary>
      /// Contains the settings flags for the data structure.
      /// </summary>
      [Description("Contains the settings flags for the data structure.")]
      public Int32   dwFlags;
   }

   /// <summary>
   /// Contains the Windows Accessibility timeout setting information.
   /// </summary>
   [Description("Contains the Windows Accessibility timeout setting information")]
   [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
   public struct ACCESSTIMEOUT
   {
      /// <summary>
      /// Contains the size of the data structure.
      /// </summary>
      [Description("Contains the size of the data structure.")]
      public UInt32   cbSize;
      /// <summary>
      /// Contains the settings flags for the data structure.
      /// </summary>
      [Description("Contains the settings flags for the data structure.")]
      public Int32    dwFlags;
      /// <summary>
      /// Contains the timeout value for automatic shutdown in ms.
      /// </summary>
      [Description("Contains the timeout value for automatic shutdown in ms.")]
      public Int32    iTimeOutMSec;
   }

   /// <summary>
   /// Contains the SerialKeys accessibility setting information.
   /// </summary>
   [Description("Contains the SerialKeys accessibility setting information.")]
   [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
   public struct SERIALKEYS
   {
      /// <summary>
      /// Contains the size of the data structure.
      /// </summary>
      [Description("Contains the size of the data structure.")]
      public UInt32   cbSize;
      /// <summary>
      /// Contains the settings flags for the data structure.
      /// </summary>
      [Description("Contains the settings flags for the data structure.")]
      public Int32    dwFlags;
      /// <summary>
      /// Provides the name of the port used to receive 
      /// serial communications. If there is no port in 
      /// use, this member is zero. If the port is set to
      /// scan all inputs, then this value returns AUTO.
      /// </summary>
      [Description("Provides the name of the port used to receive " +
                   "serial communications. If there is no port in " +
                   "use, this member is zero. If the port is set to" +
                   "scan all inputs, then this value returns AUTO.")]
      [MarshalAs(UnmanagedType.LPWStr, SizeConst=80)]
      public String   lpszActivePort;
      /// <summary>
      /// Reserved--Do Not Use
      /// </summary>
      [Description("Reserved--Do Not Use")]
      [MarshalAs(UnmanagedType.LPWStr, SizeConst=80)]
      public String   lpszPort;
      /// <summary>
      /// Contains the SerialKeys baud rate setting.
      /// </summary>
      [Description("Contains the SerialKeys baud rate setting.")]
      public UInt32   iBaudRate;
      /// <summary>
      /// Contains a number that indicates the current 
      /// port state. 0 = All input ignored, 1 = Input is
      /// watched for SerialKeys activation when no other
      /// application has the port open, 2 = All input is
      /// treated as SerialKeys commands.
      /// </summary>
      [Description("Contains a number that indicates the current " +
                   "port state. 0 = All input ignored, 1 = Input is " +
                   "watched for SerialKeys activation when no other " +
                   "application has the port open, 2 = All input is " +
                   "treated as SerialKeys commands.")]
      public UInt32   iPortState;
      /// <summary>
      /// Contains the number of the active port.
      /// </summary>
      [Description("Contains the number of the active port.")]
      public UInt32   iActive;
   }

   /// <summary>
   /// Contains the SoundSentry accessibility setting information.
   /// </summary>
   [Description("Contains the SoundSentry accessibility setting information.")]
   [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
   public struct SOUNDSENTRY
   {
      /// <summary>
      /// Contains the size of the data structure.
      /// </summary>
      [Description("Contains the size of the data structure.")]
      public UInt32   cbSize;
      /// <summary>
      /// Contains the settings flags for the data structure.
      /// </summary>
      [Description("Contains the settings flags for the data structure.")]
      public Int32    dwFlags;
      /// <summary>
      /// Determines the type of text effect used to display
      /// information on screen. Use with the
      /// SoundSentryTextEffects enumeration.
      /// </summary>
      [Description("Determines the type of text effect used to display " +
                   "information on screen. Use with the " +
                   "SoundSentryTextEffects enumeration.")]
      public Int32    iFSTextEffect;
      /// <summary>
      /// Determines the duration of the text screen 
      /// effect in ms.
      /// </summary>
      [Description("Determines the duration of the text screen " +
                   "effect in ms.")]
      public Int32    iFSTextEffectMSec;
      /// <summary>
      /// Determines the RGB color used to display a 
      /// text screen effect.
      /// </summary>
      [Description("Determines the RGB color used to display a " +
                   "text screen effect.")]
      public Int32    iFSTextEffectColorBits;
      /// <summary>
      /// Determines the type of graphic effect used to display
      /// information on screen. Use with the
      /// SoundSentryGraphicEffects enumeration.
      /// </summary>
      [Description("Determines the type of grahic effect used to display " +
                   "information on screen. Use with the " +
                   "SoundSentryGraphicEffects enumeration.")]
      public Int32    iFSGrafEffect;
      /// <summary>
      /// Determines the duration of the graphics screen 
      /// effect in ms.
      /// </summary>
      [Description("Determines the duration of the graphics screen " +
                   "effect in ms.")]
      public Int32    iFSGrafEffectMSec;
      /// <summary>
      /// Determines the RGB color used to display a 
      /// graphics screen effect.
      /// </summary>
      [Description("Determines the RGB color used to display a " +
                   "graphics screen effect.")]
      public Int32    iFSGrafEffectColor;
      /// <summary>
      /// Determines the type of Windows application effect
      /// used to display information on screen. Use with
      /// the SoundSentryWindowsEffects enumeration.
      /// </summary>
      [Description("Determines the type of Windows application effect " +
                   "used to display information on screen. Use with " +
                   "the SoundSentryWindowsEffects enumeration.")]
      public Int32    iWindowsEffect;
      /// <summary>
      /// Determines the duration of the Windows application 
      /// screen effect in ms.
      /// </summary>
      [Description("Determines the duration of the Windows application " +
                   "screen effect in ms.")]
      public Int32    iWindowsEffectMSec;
      /// <summary>
      /// Defines the name of the DLL that contains the
      /// SoundSentryProc callback function. This member 
      /// contains NULL if no DLL is used.
      /// </summary>
      [Description("Defines the name of the DLL that contains the " +
                   "SoundSentryProc callback function. This member " +
                   "contains NULL if no DLL is used.")]
      [MarshalAs(UnmanagedType.LPWStr, SizeConst=Accessible.MAX_PATH)]
      public String   lpszWindowsEffectDLL;
      /// <summary>
      /// Reserved--Do Not Use
      /// </summary>
      [Description("Reserved--Do Not Use")]
      public Int32    iWindowsEffectOrdinal;
   }
   #endregion

   #region Accessible Class
   /// <summary>
	/// This class contains the functions required to work with the
	/// Windows Accessibility features.
	/// </summary>
   [Description("This class contains the functions required to work with the" +
                "Windows Accessibility features.")]
	public class Accessible
	{
      /// <summary>
      /// Accessible class constructor.
      /// </summary>
      [Description("Accessible class constructor.")]
		public Accessible()
		{
		}

      /// <summary>
      /// This constant contains the maximum path length
      /// used by Windows.
      /// </summary>
      [Description("This constant contains the maximum path length " +
                   "used by Windows.")]
      public const Int32 MAX_PATH = 260;

      /// <summary>
      /// This function gets or sets the Windows Accessibility
      /// setting selected by uiAction. It can optionally
      /// update the user profile to match the new settings.
      /// </summary>
      /// <param name="uiAction">The AccessType enumeration member 
      /// that reflects the accessibility option you want to modify.</param>
      /// <param name="uiParam">The actual size of the data structure.</param>
      /// <param name="pvParam">A pointer to the local copy of the data structure.</param>
      /// <param name="fWinIni">One of the WinIniFlag values that reflects 
      /// the user profile update status.</param>
      /// <returns>True if the call is successful.</returns>
      [Description("This function gets or sets the Windows Accessibility" +
                   "setting selected by uiAction. It can optionally" +
                   "update the user profile to match the new settings.")]
      [DllImport("User32.DLL", CharSet=CharSet.Auto, SetLastError=true)]
      public static extern bool SystemParametersInfo(AccessType uiAction,
                                                     UInt32 uiParam,
                                                     IntPtr pvParam,
                                                     WinIniFlags fWinIni);

      /// <summary>
      /// This is the constant used to obtain information about
      /// ShowSounds using the GetSystemMetrics() function.
      /// </summary>
      [Description("This is the constant used to obtain information about " +
                   "ShowSounds using the GetSystemMetrics() function.")]
      public const Int32 SM_SHOWSOUNDS = 70;

      /// <summary>
      /// The GetSystemMatrics function can retrieve a variety of 
      /// system metrics information, along with some types of
      /// system configuration information.
      /// </summary>
      /// <param name="nIndex">The index of the metric to retrieve.</param>
      /// <returns>A number indicating the value of the metric.</returns>
      [Description("The GetSystemMatrics function can retrieve a variety of " + 
                   "system metrics information, along with some types of " +
                   "system configuration information.")]
      [DllImport("User32.DLL", CharSet=CharSet.Auto, SetLastError=true)]
      public static extern Int32 GetSystemMetrics(Int32 nIndex);
	}
   #endregion
}
