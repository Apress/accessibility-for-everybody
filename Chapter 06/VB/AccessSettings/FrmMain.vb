Imports AccessFuncs.AccessFuncs
Imports System.Runtime.InteropServices
Imports System.Text

Public Class frmMain
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   ' Data structures or Boolean values used track accessibility
   ' status in this application.
   Private AT As ACCESSTIMEOUT        ' Access Timeout
   Private FK As FILTERKEYS           ' FilterKeys
   Private HC As HIGHCONTRAST         ' High Contrast
   Private MK As MOUSEKEYS            ' MouseKeys
   Private SR As Boolean              ' ScreenReader
   Private SC As SERIALKEYS           ' SerialKeys
   Private SSound As Boolean          ' ShowSounds
   Private SSentry As SOUNDSENTRY     ' SoundSentry
   Private SK As STICKYKEYS           ' StickyKeys
   Private TK As TOGGLEKEYS           ' ToggleKeys

   Public Sub New()
      MyBase.New()
      Dim DataSize As Int32                ' Size of the data structure.

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Initialize the data structures.
      AT = New ACCESSTIMEOUT       ' Access Timeout
      FK = New FILTERKEYS          ' FilterKeys
      HC = New HIGHCONTRAST        ' High Contrast
      MK = New MOUSEKEYS           ' MouseKeys
      SR = False                   ' ScreenReader
      SC = New SERIALKEYS          ' SerialKeys
      SSound = False               ' ShowSounds
      SSentry = New SOUNDSENTRY    ' SoundSentry
      SK = New STICKYKEYS          ' StickyKeys
      TK = New TOGGLEKEYS          ' ToggleKeys

      ' Initialize the data structures and Choose menu options. The
      ' process includes getting the current option status (which
      ' fills out the data structure) and then comparing the flag
      ' values to see if the option is on.

      ' Access Timeout
      DataSize = Marshal.SizeOf(AT)
      AT.cbSize = Convert.ToUInt32(DataSize)
      AT = GetAccessibleOption( _
                           AT, _
                           DataSize, _
                           AccessType.SPI_GETACCESSTIMEOUT, _
                           WinIniFlags.SPIF_NONE)
      If ((AT.dwFlags & AccessTimeoutFlags.ATF_TIMEOUTON) = _
                        AccessTimeoutFlags.ATF_TIMEOUTON) Then
         mnuChooseAccessTimeout.Checked = True
      End If

      ' FilterKeys
      DataSize = Marshal.SizeOf(FK)
      FK.cbSize = Convert.ToUInt32(DataSize)
      FK = GetAccessibleOption( _
                           FK, _
                           DataSize, _
                           AccessType.SPI_GETFILTERKEYS, _
                           WinIniFlags.SPIF_NONE)
         if ((FK.dwFlags & FilterKeysFlags.FKF_FILTERKEYSON) = _
                           FilterKeysFlags.FKF_FILTERKEYSON) then
         mnuChooseFilterKeys.Checked = True
      End If

      ' High Contrast
      DataSize = Marshal.SizeOf(HC)
      HC.cbSize = Convert.ToUInt32(DataSize)
      HC = GetAccessibleOption( _
                           HC, _
                           DataSize, _
                           AccessType.SPI_GETHIGHCONTRAST, _
                           WinIniFlags.SPIF_NONE)
         if ((HC.dwFlags & HighContrastFlags.HCF_HIGHCONTRASTON) = _
                           HighContrastFlags.HCF_HIGHCONTRASTON) then
         mnuChooseHighContrast.Checked = True
      End If

      ' MouseKeys
      DataSize = Marshal.SizeOf(MK)
      MK.cbSize = Convert.ToUInt32(DataSize)
      MK = GetAccessibleOption( _
                        MK, _
                        DataSize, _
                        AccessType.SPI_GETMOUSEKEYS, _
                        WinIniFlags.SPIF_NONE)
      If ((Convert.ToInt32(MK.dwFlags) And MouseKeysFlags.MKF_MOUSEKEYSON) = _
                        MouseKeysFlags.MKF_MOUSEKEYSON) Then
         mnuChooseMouseKeys.Checked = True
      End If

      ' Screen Reader
      DataSize = Marshal.SizeOf(SR)
      SR = GetAccessibleOption( _
                  SR, _
                  DataSize, _
                  AccessType.SPI_GETSCREENREADER, _
                  WinIniFlags.SPIF_NONE)
      If (SR) Then
         mnuChooseScreenReader.Checked = True
      End If

      ' SerialKeys
      DataSize = Marshal.SizeOf(SC)
      SC.cbSize = Convert.ToUInt32(DataSize)
      SC = GetAccessibleOption( _
                        SC, _
                        DataSize, _
                        AccessType.SPI_GETSERIALKEYS, _
                        WinIniFlags.SPIF_NONE)
      If ((SC.dwFlags And SerialKeysFlags.SERKF_SERIALKEYSON) = _
                        SerialKeysFlags.SERKF_SERIALKEYSON) Then
         mnuChooseSerialKeys.Checked = True
      ElseIf (SC.lpszActivePort = Nothing) Then

         ' This is one of the few accessibility options not supported
         ' under Windows 2000/XP. Microsoft changed this behavior to
         ' ensure that SerialKeys devices would appear as standard
         ' input devices to the application.  The lpszActivePort member
         ' will always contain a value for operating systems that
         ' support the SerialKeys feature.
         mnuChooseSerialKeys.Enabled = False
      End If

      ' ShowSounds
      DataSize = Marshal.SizeOf(SSound)
      SSound = GetAccessibleOption( _
                        SSound, _
                        DataSize, _
                        AccessType.SPI_GETSHOWSOUNDS, _
                        WinIniFlags.SPIF_NONE)
      If (SSound) Then
         mnuChooseShowSounds.Checked = True
      End If

      ' SoundSentry
      DataSize = Marshal.SizeOf(SSentry)
      SSentry.cbSize = Convert.ToUInt32(DataSize)
      SSentry = GetAccessibleOption( _
                              SSentry, _
                              DataSize, _
                              AccessType.SPI_GETSOUNDSENTRY, _
                              WinIniFlags.SPIF_NONE)
      If ((SSentry.dwFlags And SoundSentryFlags.SSF_SOUNDSENTRYON) = _
                             SoundSentryFlags.SSF_SOUNDSENTRYON) Then
         mnuChooseSoundSentry.Checked = True
      End If

      ' StickyKeys
      DataSize = Marshal.SizeOf(SK)
      SK.cbSize = Convert.ToUInt32(DataSize)
      SK = GetAccessibleOption( _
                        SK, _
                        DataSize, _
                        AccessType.SPI_GETSTICKYKEYS, _
                        WinIniFlags.SPIF_NONE)
      If ((SK.dwFlags And StickyKeysFlags.SKF_STICKYKEYSON) = _
                        StickyKeysFlags.SKF_STICKYKEYSON) Then
         mnuChooseStickyKeys.Checked = True
      End If

      ' ToggleKeys
      DataSize = Marshal.SizeOf(TK)
      TK.cbSize = Convert.ToUInt32(DataSize)
      TK = GetAccessibleOption( _
                        TK, _
                        DataSize, _
                        AccessType.SPI_GETTOGGLEKEYS, _
                        WinIniFlags.SPIF_NONE)
      If ((TK.dwFlags And ToggleKeysFlags.TKF_TOGGLEKEYSON) = _
                        ToggleKeysFlags.TKF_TOGGLEKEYSON) Then
         mnuChooseToggleKeys.Checked = True
      End If

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
   Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
   Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChoose As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseAccessTimeout As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseFilterKeys As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseHighContrast As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseMouseKeys As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseScreenReader As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseSerialKeys As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseShowSounds As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseSoundSentry As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseStickyKeys As System.Windows.Forms.MenuItem
   Friend WithEvents mnuChooseToggleKeys As System.Windows.Forms.MenuItem
   Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.mnuMain = New System.Windows.Forms.MainMenu
      Me.mnuFile = New System.Windows.Forms.MenuItem
      Me.mnuFileExit = New System.Windows.Forms.MenuItem
      Me.mnuChoose = New System.Windows.Forms.MenuItem
      Me.mnuChooseAccessTimeout = New System.Windows.Forms.MenuItem
      Me.mnuChooseFilterKeys = New System.Windows.Forms.MenuItem
      Me.mnuChooseHighContrast = New System.Windows.Forms.MenuItem
      Me.mnuChooseMouseKeys = New System.Windows.Forms.MenuItem
      Me.mnuChooseScreenReader = New System.Windows.Forms.MenuItem
      Me.mnuChooseSerialKeys = New System.Windows.Forms.MenuItem
      Me.mnuChooseShowSounds = New System.Windows.Forms.MenuItem
      Me.mnuChooseSoundSentry = New System.Windows.Forms.MenuItem
      Me.mnuChooseStickyKeys = New System.Windows.Forms.MenuItem
      Me.mnuChooseToggleKeys = New System.Windows.Forms.MenuItem
      Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
      '
      'mnuMain
      '
      Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuChoose})
      '
      'mnuFile
      '
      Me.mnuFile.Index = 0
      Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileExit})
      Me.mnuFile.Text = "&File"
      '
      'mnuFileExit
      '
      Me.mnuFileExit.Index = 0
      Me.mnuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4
      Me.mnuFileExit.Text = "E&xit"
      '
      'mnuChoose
      '
      Me.mnuChoose.Index = 1
      Me.mnuChoose.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuChooseAccessTimeout, Me.mnuChooseFilterKeys, Me.mnuChooseHighContrast, Me.mnuChooseMouseKeys, Me.mnuChooseScreenReader, Me.mnuChooseSerialKeys, Me.mnuChooseShowSounds, Me.mnuChooseSoundSentry, Me.mnuChooseStickyKeys, Me.mnuChooseToggleKeys})
      Me.mnuChoose.Text = "&Choose Feature"
      '
      'mnuChooseAccessTimeout
      '
      Me.mnuChooseAccessTimeout.Index = 0
      Me.mnuChooseAccessTimeout.Shortcut = System.Windows.Forms.Shortcut.F2
      Me.mnuChooseAccessTimeout.Text = "&Access Timeout"
      '
      'mnuChooseFilterKeys
      '
      Me.mnuChooseFilterKeys.Index = 1
      Me.mnuChooseFilterKeys.Shortcut = System.Windows.Forms.Shortcut.F3
      Me.mnuChooseFilterKeys.Text = "&FilterKeys"
      '
      'mnuChooseHighContrast
      '
      Me.mnuChooseHighContrast.Index = 2
      Me.mnuChooseHighContrast.Shortcut = System.Windows.Forms.Shortcut.F4
      Me.mnuChooseHighContrast.Text = "&High Contrast"
      '
      'mnuChooseMouseKeys
      '
      Me.mnuChooseMouseKeys.Index = 3
      Me.mnuChooseMouseKeys.Shortcut = System.Windows.Forms.Shortcut.F5
      Me.mnuChooseMouseKeys.Text = "&MouseKeys"
      '
      'mnuChooseScreenReader
      '
      Me.mnuChooseScreenReader.Index = 4
      Me.mnuChooseScreenReader.Shortcut = System.Windows.Forms.Shortcut.F6
      Me.mnuChooseScreenReader.Text = "&ScreenReader"
      '
      'mnuChooseSerialKeys
      '
      Me.mnuChooseSerialKeys.Index = 5
      Me.mnuChooseSerialKeys.Shortcut = System.Windows.Forms.Shortcut.F7
      Me.mnuChooseSerialKeys.Text = "S&erialKeys"
      '
      'mnuChooseShowSounds
      '
      Me.mnuChooseShowSounds.Index = 6
      Me.mnuChooseShowSounds.Shortcut = System.Windows.Forms.Shortcut.F8
      Me.mnuChooseShowSounds.Text = "Sh&owSounds"
      '
      'mnuChooseSoundSentry
      '
      Me.mnuChooseSoundSentry.Index = 7
      Me.mnuChooseSoundSentry.Shortcut = System.Windows.Forms.Shortcut.F9
      Me.mnuChooseSoundSentry.Text = "Sound&Sentry"
      '
      'mnuChooseStickyKeys
      '
      Me.mnuChooseStickyKeys.Index = 8
      Me.mnuChooseStickyKeys.Shortcut = System.Windows.Forms.Shortcut.F10
      Me.mnuChooseStickyKeys.Text = "Sticky&Keys"
      '
      'mnuChooseToggleKeys
      '
      Me.mnuChooseToggleKeys.Index = 9
      Me.mnuChooseToggleKeys.Shortcut = System.Windows.Forms.Shortcut.F11
      Me.mnuChooseToggleKeys.Text = "&ToggleKeys"
      '
      'ToolTip
      '
      Me.ToolTip.AutomaticDelay = 300
      Me.ToolTip.AutoPopDelay = 7000
      Me.ToolTip.InitialDelay = 300
      Me.ToolTip.ReshowDelay = 60
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Menu = Me.mnuMain
      Me.Name = "frmMain"
      Me.Text = "Accessibility Functionality Demonstration"

   End Sub

#End Region

   Private Function GetAccessibleOption(ByVal Struct As Object, _
                                        ByVal StructSize As Int32, _
                                        ByVal AccessType As AccessType, _
                                        ByVal IniFlag As WinIniFlags) As Object
      Dim ReturnValue As Object      ' The return data.

      ' Allocate enough memory to create an unmanaged version
      ' of the data structure.
      Dim DataPtr As IntPtr = Marshal.AllocHGlobal(StructSize)

      ' Point to the managed data stucture using the unmanaged
      ' memory pointer.
      Marshal.StructureToPtr(Struct, DataPtr, True)

      ' Call the SystemParametersInfo() function using the
      ' unmanaged data structure pointer.
      Accessible.SystemParametersInfo(AccessType, _
                                      Convert.ToUInt32(StructSize), _
                                      DataPtr, _
                                      IniFlag)

      ' Move the data retrieved from the umnanaged environment to
      ' the managed data structure and return this data structure
      ' as an object.
      ReturnValue = Marshal.PtrToStructure(DataPtr, Struct.GetType())

      ' Deallocate the memory we previously allocated.
      Marshal.FreeHGlobal(DataPtr)

      ' Return the data.
      Return ReturnValue
   End Function

   Private Function SetAccessibleOption(ByVal Struct As Object, _
                                        ByVal StructSize As Int32, _
                                        ByVal AccessType As AccessType, _
                                        ByVal IniFlag As WinIniFlags) As Boolean
      Dim ReturnValue As Boolean     ' The return value of this method.

      ' Allocate enough memory to create an unmanaged version
      ' of the data structure.
      Dim DataPtr As IntPtr = Marshal.AllocHGlobal(StructSize)

      ' Point to the managed data stucture using the unmanaged
      ' memory pointer.
      Marshal.StructureToPtr(Struct, DataPtr, True)

      ' Return true if the SystemParametersInfo() function call
      ' successfully modifies the Windows Accessibility features
      ' using the data in the data structure.
      ReturnValue = Accessible.SystemParametersInfo( _
         AccessType, _
         Convert.ToUInt32(StructSize), _
         DataPtr, _
         IniFlag)

      ' Deallocate the memory we previously allocated.
      Marshal.FreeHGlobal(DataPtr)

      ' Return the data.
      Return ReturnValue
   End Function

   Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
      ' Exit the application.
      End
   End Sub

   Private Sub mnuChooseAccessTimeout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseAccessTimeout.Click
      Dim DataSize As Int32    ' Size of the data structure.

      ' Set the flag value as needed to toggle the feature on or off.
      If ((AT.dwFlags & AccessTimeoutFlags.ATF_TIMEOUTON) = _
                        AccessTimeoutFlags.ATF_TIMEOUTON) Then
         AT.dwFlags = AT.dwFlags Or _
            AccessTimeoutFlags.ATF_TIMEOUTON
      Else
         AT.dwFlags = AT.dwFlags And _
            AccessTimeoutFlags.ATF_TIMEOUTON
      End If

      ' Call on the library function to set the new FilterKeys status.
      DataSize = Marshal.SizeOf(AT)

      ' If the function fails, display an error message.
      If (Not SetAccessibleOption(AT, _
                               DataSize, _
                               AccessType.SPI_SETACCESSTIMEOUT, _
                               WinIniFlags.SPIF_NONE)) Then
         MessageBox.Show("Could not set the Access Timeout option", _
                         "Accessibility Option Error", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Error)

         ' If the function succeeds, display a success message and change
         ' the menu setting.
      Else
         mnuChooseAccessTimeout.Checked = Not mnuChooseAccessTimeout.Checked
      End If
   End Sub

   Private Sub mnuChooseFilterKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseFilterKeys.Click
      Dim DataSize As Int32    ' Size of the data structure.

      ' Set the flag value as needed to toggle the feature on or off.
      If ((FK.dwFlags & FilterKeysFlags.FKF_FILTERKEYSON) = _
                        FilterKeysFlags.FKF_FILTERKEYSON) Then
         FK.dwFlags = FK.dwFlags Or _
            FilterKeysFlags.FKF_FILTERKEYSON
      Else
         FK.dwFlags = FK.dwFlags And _
            FilterKeysFlags.FKF_FILTERKEYSON
      End If

      ' Call on the library function to set the new FilterKeys status.
      DataSize = Marshal.SizeOf(FK)

      ' If the function fails, display an error message.
      If (Not SetAccessibleOption(FK, _
                               DataSize, _
                               AccessType.SPI_SETFILTERKEYS, _
                               WinIniFlags.SPIF_NONE)) Then
         MessageBox.Show("Could not set the FilterKeys option", _
                         "Accessibility Option Error", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Error)

         ' If the function succeeds, display a success message and change
         ' the menu setting.
      Else
         mnuChooseFilterKeys.Checked = Not mnuChooseFilterKeys.Checked
      End If
   End Sub

   Private Sub mnuChooseHighContrast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseHighContrast.Click
      Dim DataSize As Int32    ' Size of the data structure.

      ' Set the flag value as needed to toggle the feature on or off.
      If ((HC.dwFlags & HighContrastFlags.HCF_HIGHCONTRASTON) = _
                        HighContrastFlags.HCF_HIGHCONTRASTON) Then
         HC.dwFlags = HC.dwFlags Or _
            HighContrastFlags.HCF_HIGHCONTRASTON
      Else
         HC.dwFlags = HC.dwFlags And _
            HighContrastFlags.HCF_HIGHCONTRASTON
      End If

      ' Call on the library function to set the new FilterKeys status.
      DataSize = Marshal.SizeOf(HC)

      ' If the function fails, display an error message.
      If (Not SetAccessibleOption(HC, _
                               DataSize, _
                               AccessType.SPI_SETHIGHCONTRAST, _
                               WinIniFlags.SPIF_NONE)) Then
         MessageBox.Show("Could not set the High Contrast option", _
                            "Accessibility Option Error", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)

         ' If the function succeeds, display a success message and change
         ' the menu setting.
      Else
         mnuChooseHighContrast.Checked = Not mnuChooseHighContrast.Checked
      End If
   End Sub

   Private Sub mnuChooseMouseKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseMouseKeys.Click
      Dim DataSize As Int32    ' Size of the data structure.

      ' Set the flag value as needed to toggle the feature on or off.
      If ((Convert.ToInt32(MK.dwFlags) & MouseKeysFlags.MKF_MOUSEKEYSON) = _
                                         MouseKeysFlags.MKF_MOUSEKEYSON) Then
         MK.dwFlags = Convert.ToUInt32(Convert.ToInt32(MK.dwFlags) Or _
            MouseKeysFlags.MKF_MOUSEKEYSON)
      Else
         MK.dwFlags = Convert.ToUInt32(Convert.ToInt32(MK.dwFlags) And _
            MouseKeysFlags.MKF_MOUSEKEYSON)
      End If

      ' Call on the library function to set the new FilterKeys status.
      DataSize = Marshal.SizeOf(MK)

      ' If the function fails, display an error message.
      If (Not SetAccessibleOption(MK, _
                               DataSize, _
                               AccessType.SPI_SETMOUSEKEYS, _
                               WinIniFlags.SPIF_NONE)) Then
         MessageBox.Show("Could not set the MouseKeys option", _
                         "Accessibility Option Error", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Error)

         ' If the function succeeds, display a success message and change
         ' the menu setting.
      Else
         mnuChooseMouseKeys.Checked = Not mnuChooseMouseKeys.Checked
      End If
   End Sub

   Private Sub mnuChooseScreenReader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseScreenReader.Click
      ' You can't turn the screen reader on and off using a menu option.
      MessageBox.Show("This is a status indicator only. Set the screen " + _
                      "reader on using the Narrator application on the " + _
                      "Accessibility menu.", _
                      "Accessibility Option Status", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub

   Private Sub mnuChooseSerialKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseSerialKeys.Click
      ' You shouldn't turn SerialKeys on and off using a menu option.
      MessageBox.Show("This is a status indicator only. Set " + _
                      "SerialKeys on by adding a SerialKeys " + _
                      "device to your system and modifying " + _
                      "the Control Panel setting.", _
                      "Accessibility Option Status", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)
   End Sub

   Private Sub mnuChooseShowSounds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseShowSounds.Click
      Dim DataSize As Int32    ' Size of the data structure.

      ' Set the flag value as needed to toggle the feature on or off.
      SSound = Not SSound

      ' Call on the library function to set the new FilterKeys status.
      DataSize = Marshal.SizeOf(SSound)

      ' If the function fails, display an error message.
      If (Not SetAccessibleOption(IntPtr.Zero, _
                               Convert.ToInt32(SSound), _
                               AccessType.SPI_SETSHOWSOUNDS, _
                               WinIniFlags.SPIF_NONE)) Then
         MessageBox.Show("Could not set the ShowSounds option", _
                         "Accessibility Option Error", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Error)

         ' If the function succeeds, display a success message and change
         ' the menu setting.
      Else
         mnuChooseShowSounds.Checked = Not mnuChooseShowSounds.Checked
      End If
   End Sub

   Private Sub mnuChooseSoundSentry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseSoundSentry.Click
      Dim DataSize As Int32    ' Size of the data structure.

      ' Set the flag value as needed to toggle the feature on or off.
      If ((SSentry.dwFlags & SoundSentryFlags.SSF_SOUNDSENTRYON) = _
                             SoundSentryFlags.SSF_SOUNDSENTRYON) Then
         SSentry.dwFlags = SSentry.dwFlags Or _
            SoundSentryFlags.SSF_SOUNDSENTRYON
      Else
         SSentry.dwFlags = SSentry.dwFlags And _
            SoundSentryFlags.SSF_SOUNDSENTRYON
         SSentry.iWindowsEffect = SoundSentryWindowsEffects.SSWF_TITLE
      End If

      ' Call on the library function to set the new FilterKeys status.
      DataSize = Marshal.SizeOf(SSentry)

      ' If the function fails, display an error message.
      If (Not SetAccessibleOption(SSentry, _
                               DataSize, _
                               AccessType.SPI_SETSOUNDSENTRY, _
                               WinIniFlags.SPIF_NONE)) Then
         MessageBox.Show("Could not set the SoundSentry option", _
                         "Accessibility Option Error", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Error)

         ' If the function succeeds, display a success message and change
         ' the menu setting.
      Else
         mnuChooseSoundSentry.Checked = Not mnuChooseSoundSentry.Checked
      End If
   End Sub

   Private Sub mnuChooseStickyKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseStickyKeys.Click
      Dim DataSize As Int32    ' Size of the data structure.

      ' Set the flag value as needed to toggle the feature on or off.
      If ((SK.dwFlags & StickyKeysFlags.SKF_STICKYKEYSON) = _
                        StickyKeysFlags.SKF_STICKYKEYSON) Then
         SK.dwFlags = SK.dwFlags Or _
            StickyKeysFlags.SKF_STICKYKEYSON
      Else
         SK.dwFlags = SK.dwFlags And _
            StickyKeysFlags.SKF_STICKYKEYSON
      End If

      ' Call on the library function to set the new FilterKeys status.
      DataSize = Marshal.SizeOf(SK)

      ' If the function fails, display an error message.
      If (Not SetAccessibleOption(SK, _
                               DataSize, _
                               AccessType.SPI_SETSTICKYKEYS, _
                               WinIniFlags.SPIF_NONE)) Then
         MessageBox.Show("Could not set the StickyKeys option", _
                         "Accessibility Option Error", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Error)

         ' If the function succeeds, display a success message and change
         ' the menu setting.
      Else
         mnuChooseStickyKeys.Checked = Not mnuChooseStickyKeys.Checked
      End If
   End Sub

   Private Sub mnuChooseToggleKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChooseToggleKeys.Click
      Dim DataSize As Int32    ' Size of the data structure.

      ' Set the flag value as needed to toggle the feature on or off.
      If ((TK.dwFlags & ToggleKeysFlags.TKF_TOGGLEKEYSON) = _
                        ToggleKeysFlags.TKF_TOGGLEKEYSON) Then
         TK.dwFlags = TK.dwFlags Or _
            ToggleKeysFlags.TKF_TOGGLEKEYSON
      Else
         TK.dwFlags = TK.dwFlags And _
            ToggleKeysFlags.TKF_TOGGLEKEYSON
      End If

      ' Call on the library function to set the new FilterKeys status.
      DataSize = Marshal.SizeOf(TK)

      ' If the function fails, display an error message.
      If (Not SetAccessibleOption(TK, _
                               DataSize, _
                               AccessType.SPI_SETTOGGLEKEYS, _
                               WinIniFlags.SPIF_NONE)) Then
         MessageBox.Show("Could not set the ToggleKeys option", _
                         "Accessibility Option Error", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Error)

         ' If the function succeeds, display a success message and change
         ' the menu setting.
      Else
         mnuChooseToggleKeys.Checked = Not mnuChooseToggleKeys.Checked
      End If
   End Sub
End Class
