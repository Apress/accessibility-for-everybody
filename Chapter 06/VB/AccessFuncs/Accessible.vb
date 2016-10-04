Imports System.Runtime.InteropServices
Imports System.Text
Imports System.ComponentModel

Namespace AccessFuncs
#Region "Enumerations"

   <Description("This enumeration contains a list of common constants used " + _
                "to interact with the Windows Accessibility features.")> _
   Public Enum AccessType : uint
      <Description("Gets the high contrast information using the " + _
                   "HIGHCONTRAST data structure.")> _
      SPI_GETHIGHCONTRAST = &H42
      <Description("Sets the high contrast information using the " + _
                   "HIGHCONTRAST data structure.")> _
      SPI_SETHIGHCONTRAST = &H43
      <Description("Gets the screen readers status. Unlike some other " + _
                   "accessibility settings, this one relies on a BOOL," + _
                   "rather than a data structure for input.")> _
      SPI_GETSCREENREADER = &H46
      <Description("Sets the screen readers status. Unlike some other " + _
                   "accessibility settings, this one relies on a BOOL," + _
                   "rather than a data structure for input.")> _
      SPI_SETSCREENREADER = &H47
      <Description("Gets the FilterKeys information using the " + _
                   "FILTERKEYS data structure.")> _
      SPI_GETFILTERKEYS = &H32
      <Description("Sets the FilterKeys information using the " + _
                   "FILTERKEYS data structure.")> _
      SPI_SETFILTERKEYS = &H33
      <Description("Gets the ToggleKeys information using the " + _
                   "TOGGLEKEYS data structure.")> _
      SPI_GETTOGGLEKEYS = &H34
      <Description("Sets the ToggleKeys information using the " + _
                   "TOGGLEKEYS data structure.")> _
      SPI_SETTOGGLEKEYS = &H35
      <Description("Gets the MouseKeys information using the " + _
                   "MOUSEKEYS data structure.")> _
      SPI_GETMOUSEKEYS = &H36
      <Description("Sets the MouseKeys information using the " + _
                   "MOUSEKEYS data structure.")> _
      SPI_SETMOUSEKEYS = &H37
      <Description("Gets the ShowSounds status. Unlike some other " + _
                   "accessibility settings, this one relies on a BOOL, " + _
                   "rather than a data structure for input. Microsoft " + _
                   "recommends using the GetSystemMetrics(SM_SHOWSOUNDS) " + _
                   "function in place of this call.")> _
      SPI_GETSHOWSOUNDS = &H38
      <Description("Sets the ShowSounds status. Unlike some other " + _
                   "accessibility settings, this one relies on a BOOL, " + _
                   "rather than a data structure for input. Microsoft " + _
                   "recommends using the GetSystemMetrics(SM_SHOWSOUNDS) " + _
                   "function in place of this call.")> _
      SPI_SETSHOWSOUNDS = &H39
      <Description("Gets the StickyKeys information using the " + _
                   "STICKYKEYS data structure.")> _
      SPI_GETSTICKYKEYS = &H3A
      <Description("Sets the StickyKeys information using the " + _
                   "STICKYKEYS data structure.")> _
      SPI_SETSTICKYKEYS = &H3B
      <Description("Gets the Windows Accessibility Timeout information " + _
                   "using the ACCESSTIMEOUT data structure.")> _
      SPI_GETACCESSTIMEOUT = &H3C
      <Description("Sets the Windows Accessibility Timeout information " + _
                   "using the ACCESSTIMEOUT data structure.")> _
      SPI_SETACCESSTIMEOUT = &H3D
      <Description("Gets the SerialKeys information using the " + _
                   "SERIALKEYS data structure.")> _
      SPI_GETSERIALKEYS = &H3E
      <Description("Sets the SerialKeys information using the " + _
                   "SERIALKEYS data structure.")> _
      SPI_SETSERIALKEYS = &H3F
      <Description("Gets the SoundSentry information using the " + _
                   "SOUNDSENTRY data structure.")> _
      SPI_GETSOUNDSENTRY = &H40
      <Description("Gets the SoundSentry information using the " + _
                   "SOUNDSENTRY data structure.")> _
      SPI_SETSOUNDSENTRY = &H41
   End Enum

   <Description("This enumeration contains the flags used to control " + _
                "update of the user profile. Select SPIF_NONE if the " + _
                "application does not need to update the profile.")> _
   Public Enum WinIniFlags
      <Description("Doesn't perform any type of profile update.")> _
      SPIF_NONE = &H0
      <Description("Writes the update to the user profile.")> _
      SPIF_UPDATEINIFILE = &H1
      <Description("Writes the update to the user profile and " + _
                   "broadcasts the WM_SETTINGCHANGE message.")> _
      SPIF_SENDWININICHANGE = &H2
      <Description("Writes the update to the user profile and " + _
                   "broadcasts the WM_SETTINGCHANGE message.")> _
      SPIF_SENDCHANGE = SPIF_SENDWININICHANGE
   End Enum

   <Description("A listing of HighContrast accessibility flags.")> _
   Public Enum HighContrastFlags
      <Description("HighContrast is On")> _
      HCF_HIGHCONTRASTON = &H1
      <Description("HighContrast is availble for use.")> _
      HCF_AVAILABLE = &H2
      <Description("HighContrast has the hot key selected.")> _
      HCF_HOTKEYACTIVE = &H4
      <Description("Confirmation dialog box displayed for " + _
                   "the HighContrast hot key.")> _
      HCF_CONFIRMHOTKEY = &H8
      <Description("Make a sound when HighContrast is selected.")> _
      HCF_HOTKEYSOUND = &H10
      <Description("Display an indicator when HighContrast is selected.")> _
      HCF_INDICATOR = &H20
      <Description("HighContrast hot key is available.")> _
      HCF_HOTKEYAVAILABLE = &H40
   End Enum

   <Description("A listing of FilterKeys accessibility flags.")> _
   Public Enum FilterKeysFlags
      <Description("FilterKeys is On")> _
      FKF_FILTERKEYSON = &H1
      <Description("FilterKeys is available for use.")> _
      FKF_AVAILABLE = &H2
      <Description("The FilterKeys is active.")> _
      FKF_HOTKEYACTIVE = &H4
      <Description("Confirmation dialog box displayed for " + _
                   "the FilterKeys hot key.")> _
      FKF_CONFIRMHOTKEY = &H8
      <Description("Make a sound when changing the FilterKeys status.")> _
      FKF_HOTKEYSOUND = &H10
      <Description("Display an indicator when changing the FilterKeys status.")> _
      FKF_INDICATOR = &H20
      <Description("The FilterKeys click is set to on.")> _
      FKF_CLICKON = &H40
   End Enum

   <Description("A listing of ToggleKeys accessibility flags.")> _
   Public Enum ToggleKeysFlags
      <Description("ToggleKeys is On")> _
      TKF_TOGGLEKEYSON = &H1
      <Description("ToggleKeys is available for use.")> _
      TKF_AVAILABLE = &H2
      <Description("The ToggleKeys is active.")> _
      TKF_HOTKEYACTIVE = &H4
      <Description("Confirmation dialog box displayed for " + _
                   "the ToggleKeys hot key.")> _
      TKF_CONFIRMHOTKEY = &H8
      <Description("Make a sound when changing the ToggleKeys status.")> _
      TKF_HOTKEYSOUND = &H10
      <Description("Display an indicator when changing the ToggleKeys status.")> _
      TKF_INDICATOR = &H20
   End Enum

   <Description("A listing of MouseKeys accessibility flags.")> _
   Public Enum MouseKeysFlags : uint
      <Description("MouseKeys is On")> _
      MKF_MOUSEKEYSON = &H1
      <Description("MouseKeys is available for use.")> _
      MKF_AVAILABLE = &H2
      <Description("The MouseKeys is active.")> _
      MKF_HOTKEYACTIVE = &H4
      <Description("Confirmation dialog box displayed for " + _
                   "the MouseKeys hot key.")> _
      MKF_CONFIRMHOTKEY = &H8
      <Description("Make a sound when changing the MouseKeys status.")> _
      MKF_HOTKEYSOUND = &H10
      <Description("Display an indicator when changing the MouseKeys status.")> _
      MKF_INDICATOR = &H20
      <Description("Use the Ctrl key to speed the mouse up and the" + _
                   "Shift key to slow the mouse down.")> _
      MKF_MODIFIERS = &H40
      <Description("The numeric keypad moves the mouse when Num Lock is" + _
                   "on when set.")> _
      MKF_REPLACENUMBERS = &H80
      <Description("The user wants to use the left button to select.")> _
      MKF_LEFTBUTTONSEL = &H10000000
      <Description("The user wants to use the right button to select.")> _
      MKF_RIGHTBUTTONSEL = &H20000000
      <Description("The left button to down.")> _
      MKF_LEFTBUTTONDOWN = &H1000000
      <Description("The right button to down.")> _
      MKF_RIGHTBUTTONDOWN = &H2000000
      <Description("The system is processing numeric keypad input as mouse movement.")> _
      MKF_MOUSEMODE = &H80000000
   End Enum

   <Description("A listing of StickyKeys accessibility flags.")> _
   Public Enum StickyKeysFlags : uint
      <Description("StickyKeys is On")> _
      SKF_STICKYKEYSON = &H1
      <Description("StickyKeys is available for use.")> _
      SKF_AVAILABLE = &H2
      <Description("The StickyKeys is active.")> _
      SKF_HOTKEYACTIVE = &H4
      <Description("Confirmation dialog box displayed for " + _
                   "the StickyKeys hot key.")> _
      SKF_CONFIRMHOTKEY = &H8
      <Description("Make a sound when changing the StickyKeys status.")> _
      SKF_HOTKEYSOUND = &H10
      <Description("Display an indicator when changing the StickyKeys status.")> _
      SKF_INDICATOR = &H20
      <Description("The system plays a sound when the control keys change status.")> _
      SKF_AUDIBLEFEEDBACK = &H40
      <Description("Pressing a key twice locks it--a third time releases it.")> _
      SKF_TRISTATE = &H80
      <Description("Pressing a control and another key together turns of StickyKeys.")> _
      SKF_TWOKEYSOFF = &H100
      <Description("The left Alt key is latched.")> _
      SKF_LALTLATCHED = &H10000000
      <Description("The left Ctrl key is latched.")> _
      SKF_LCTLLATCHED = &H4000000
      <Description("The left Shift key is latched.")> _
      SKF_LSHIFTLATCHED = &H1000000
      <Description("The right Alt key is latched.")> _
      SKF_RALTLATCHED = &H20000000
      <Description("The right Ctrl key is latched.")> _
      SKF_RCTLLATCHED = &H8000000
      <Description("The right Shift key is latched.")> _
      SKF_RSHIFTLATCHED = &H2000000
      <Description("The left Windows key is latched.")> _
      SKF_LWINLATCHED = &H40000000
      <Description("The right Windows key is latched.")> _
      SKF_RWINLATCHED = &H80000000
      <Description("The left Alt key is locked.")> _
      SKF_LALTLOCKED = &H100000
      <Description("The left Ctrl key is locked.")> _
      SKF_LCTLLOCKED = &H40000
      <Description("The left Shift key is locked.")> _
      SKF_LSHIFTLOCKED = &H10000
      <Description("The right Alt key is locked.")> _
      SKF_RALTLOCKED = &H200000
      <Description("The right Ctrl key is locked.")> _
      SKF_RCTLLOCKED = &H80000
      <Description("The right Shift key is locked.")> _
      SKF_RSHIFTLOCKED = &H20000
      <Description("The left Windows key is locked.")> _
      SKF_LWINLOCKED = &H400000
      <Description("The right Windows key is locked.")> _
      SKF_RWINLOCKED = &H800000
   End Enum

   <Description("A listing of Windows Accessibility timeout flags.")> _
   Public Enum AccessTimeoutFlags
      <Description("If this flag is set, the user has set a timeout value " + _
                   "and the Windows Accessibility features will turn off " + _
                   "after a given time period. If this flag is cleared, the " + _
                   "Windows Accessibility features are always available.")> _
      ATF_TIMEOUTON = &H1
      <Description("Make a sound when changing the timeout status.")> _
      ATF_ONOFFFEEDBACK = &H2
   End Enum

   <Description("A listing of SerialKeys accessibility flags.")> _
   Public Enum SerialKeysFlags
      <Description("SerialKeys is On")> _
      SERKF_SERIALKEYSON = &H1
      <Description("SerialKeys is available for use. This flag is not " + _
                   "implemented")> _
      SERKF_AVAILABLE = &H2
      <Description("Display an indicator when changing the SerialKeys status.")> _
      SERKF_INDICATOR = &H4
   End Enum

   <Description("A listing of SoundSentry accessibility flags.")> _
   Public Enum SoundSentryFlags
      <Description("SoundSentry is On")> _
      SSF_SOUNDSENTRYON = &H1
      <Description("SoundSentry is available for use. This flag is not " + _
                   "implemented")> _
      SSF_AVAILABLE = &H2
      <Description("Display an indicator when changing the SoundSentry " + _
                   "status.")> _
      SSF_INDICATOR = &H4
   End Enum

   <Description("Contains a list of the possible screen effects for a " + _
                "full screen DOS text mode application.")> _
   Public Enum SoundSentryTextEffects
      <Description("Don't display an effect.")> _
      SSTF_NONE = 0
      <Description("Flash the characters in the corner of the screen.")> _
      SSTF_CHARS = 1
      <Description("Flash the border (overscan area) of the screen.")> _
      SSTF_BORDER = 2
      <Description("Flash the entire screen.")> _
      SSTF_DISPLAY = 3
   End Enum

   <Description("Contains a list of the possible screen effects for a " + _
                "full screen DOS graphics mode application.")> _
   Public Enum SoundSentryGraphicEffects
      <Description("Don't display an effect.")> _
      SSGF_NONE = 0
      <Description("Flash the entire screen.")> _
      SSGF_DISPLAY = 3
   End Enum

   <Description("Contains a list of the possible screen effects for a " + _
                "Windows application.")> _
   Public Enum SoundSentryWindowsEffects
      <Description("Don't display an effect.")> _
      SSWF_NONE = 0
      <Description("Flash the title bar of the active application.")> _
      SSWF_TITLE = 1
      <Description("Flash the entire active application window.")> _
      SSWF_WINDOW = 2
      <Description("Flash the entire screen.")> _
      SSWF_DISPLAY = 3
      <Description("Use the custom flashing method specified by the " + _
                   "SoundSentryProc() function found in the DLL " + _
                   "specified by the iFSWindowsEffectDLL member. ")> _
      SSWF_CUSTOM = 4
   End Enum
#End Region

#Region "Data Structures"
   <Description("Contains the HighContrast accessibility setting information."), _
    StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Auto)> _
   Public Structure HIGHCONTRAST
      <Description("Contains the size of the data structure.")> _
      Public cbSize As UInt32
      <Description("Contains the settings flags for the data structure.")> _
      Public dwFlags As Int32
      <Description("Contains a text description of the current scheme."), _
       MarshalAs(UnmanagedType.LPWStr, SizeConst:=80)> _
      Public lpszDefaultScheme As String
   End Structure

   <Description("Contains the FilterKeys accessibility setting information."), _
    StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Auto)> _
   Public Structure FILTERKEYS
      <Description("Contains the size of the data structure.")> _
      Public cbSize As UInt32
      <Description("Contains the settings flags for the data structure.")> _
      Public dwFlags As Int32
      <Description("Defines the Acceptance Delay value.")> _
      Public iWaitMSec As Int32
      <Description("Defines the Delay Until Repeat value.")> _
      Public iDelayMSec As Int32
      <Description("Defines the Repeat Rate value.")> _
      Public iRepeatMSec As Int32
      <Description("Defines the Debounce Time value.")> _
      Public iBounceMSec As Int32
   End Structure

   <Description("Contains the ToggleKeys accessibility setting information."), _
    StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Auto)> _
   Public Structure TOGGLEKEYS
      <Description("Contains the size of the data structure.")> _
      Public cbSize As UInt32
      <Description("Contains the settings flags for the data structure.")> _
      Public dwFlags As Int32
   End Structure

   <Description("Contains the MouseKeys accessibility setting information."), _
    StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Auto)> _
   Public Structure MOUSEKEYS
      <Description("Contains the size of the data structure.")> _
      Public cbSize As UInt32
      <Description("Contains a the settings flags for the data structure.")> _
      Public dwFlags As UInt32
      <Description("Contains the maximum speed setting of the mouse.")> _
      Public iMaxSpeed As Int32
      <Description("Contains the acceleration setting of the mouse.")> _
      Public iTimeToMaxSpeed As Int32
      <Description("Contains the control speed setting of the mouse. " + _
                   "Ignored if MKF_MODIFIERS is not set.")> _
      Public iCtrlSpeed As Int32
      <Description("Reserved--Do Not Use")> _
      Public dwReserved1 As Int32
      <Description("Reserved--Do Not Use")> _
      Public dwReserved2 As Int32
   End Structure

   <Description("Contains the StickyKeys accessibility setting information."), _
    StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Auto)> _
   Public Structure STICKYKEYS
      <Description("Contains the size of the data structure.")> _
      Public cbSize As UInt32
      <Description("Contains the settings flags for the data structure.")> _
      Public dwFlags As Int32
   End Structure

   <Description("Contains the Windows Accessibility timeout setting information"), _
    StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Auto)> _
   Public Structure ACCESSTIMEOUT
      <Description("Contains the size of the data structure.")> _
      Public cbSize As UInt32
      <Description("Contains the settings flags for the data structure.")> _
      Public dwFlags As Int32
      <Description("Contains the timeout value for automatic shutdown in ms.")> _
      Public iTimeOutMSec As Int32
   End Structure

   <Description("Contains the SerialKeys accessibility setting information."), _
    StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Auto)> _
   Public Structure SERIALKEYS
      <Description("Contains the size of the data structure.")> _
      Public cbSize As UInt32
      <Description("Contains the settings flags for the data structure.")> _
      Public dwFlags As Int32
      <Description("Provides the name of the port used to receive " + _
                   "serial communications. If there is no port in " + _
                   "use, this member is zero. If the port is set to" + _
                   "scan all inputs, then this value returns AUTO."), _
       MarshalAs(UnmanagedType.LPWStr, SizeConst:=80)> _
      Public lpszActivePort As String
      <Description("Reserved--Do Not Use"), _
       MarshalAs(UnmanagedType.LPWStr, SizeConst:=80)> _
      Public lpszPort As String
      <Description("Contains the SerialKeys baud rate setting.")> _
      Public iBaudRate As UInt32
      <Description("Contains a number that indicates the current " + _
                   "port state. 0 = All input ignored, 1 = Input is " + _
                   "watched for SerialKeys activation when no other " + _
                   "application has the port open, 2 = All input is " + _
                   "treated as SerialKeys commands.")> _
      Public iPortState As UInt32
      <Description("Contains the number of the active port.")> _
      Public iActive As UInt32
   End Structure

   <Description("Contains the SoundSentry accessibility setting information."), _
    StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Auto)> _
   Public Structure SOUNDSENTRY
      <Description("Contains the size of the data structure.")> _
      Public cbSize As UInt32
      <Description("Contains the settings flags for the data structure.")> _
      Public dwFlags As Int32
      <Description("Determines the type of text effect used to display " + _
                   "information on screen. Use with the " + _
                   "SoundSentryTextEffects enumeration.")> _
      Public iFSTextEffect As Int32
      <Description("Determines the duration of the text screen " + _
                   "effect in ms.")> _
      Public iFSTextEffectMSec As Int32
      <Description("Determines the RGB color used to display a " + _
                   "text screen effect.")> _
      Public iFSTextEffectColorBits As Int32
      <Description("Determines the type of grahic effect used to display " + _
                   "information on screen. Use with the " + _
                   "SoundSentryGraphicEffects enumeration.")> _
      Public iFSGrafEffect As Int32
      <Description("Determines the duration of the graphics screen " + _
                   "effect in ms.")> _
      Public iFSGrafEffectMSec As Int32
      <Description("Determines the RGB color used to display a " + _
                   "graphics screen effect.")> _
      Public iFSGrafEffectColor As Int32
      <Description("Determines the type of Windows application effect " + _
                   "used to display information on screen. Use with " + _
                   "the SoundSentryWindowsEffects enumeration.")> _
      Public iWindowsEffect As Int32
      <Description("Determines the duration of the Windows application " + _
                   "screen effect in ms.")> _
      Public iWindowsEffectMSec As Int32
      <Description("Defines the name of the DLL that contains the " + _
                   "SoundSentryProc callback function. This member " + _
                   "contains NULL if no DLL is used."), _
       MarshalAs(UnmanagedType.LPWStr, SizeConst:=Accessible.MAX_PATH)> _
      Public lpszWindowsEffectDLL As String
      <Description("Reserved--Do Not Use")> _
      Public iWindowsEffectOrdinal As Int32
   End Structure
#End Region

#Region "Accessible Class"
   <Description("This class contains the functions required to work with the" + _
                "Windows Accessibility features.")> _
   Public Class Accessible
      <Description("Accessible class constructor.")> _
      Public Sub Accessible()
      End Sub

      <Description("This constant contains the maximum path length " + _
                   "used by Windows.")> _
      Public Const MAX_PATH As Int32 = 260

      <Description("This function gets or sets the Windows Accessibility" + _
                   "setting selected by uiAction. It can optionally" + _
                   "update the user profile to match the new settings."), _
       DllImport("User32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)> _
      Public Shared Function SystemParametersInfo(ByVal uiAction As AccessType, _
                                                  ByVal uiParam As UInt32, _
                                                  ByVal pvParam As IntPtr, _
                                                  ByVal fWinIni As WinIniFlags) As Boolean
      End Function

      <Description("This is the constant used to obtain information about " + _
                   "ShowSounds using the GetSystemMetrics() function.")> _
      Public Const SM_SHOWSOUNDS As Int32 = 70

      <Description("The GetSystemMatrics function can retrieve a variety of " + _
                   "system metrics information, along with some types of " + _
                   "system configuration information."), _
       DllImport("User32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)> _
      Public Shared Function GetSystemMetrics(ByVal nIndex As Int32) As Int32
      End Function
   End Class
#End Region
End Namespace
