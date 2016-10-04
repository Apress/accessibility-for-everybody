Imports DxVBLibA
Imports System.IO
Imports System.Text

Public Class frmMain
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

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
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   Friend WithEvents btnTest As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.btnQuit = New System.Windows.Forms.Button()
      Me.btnTest = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'btnQuit
      '
      Me.btnQuit.Location = New System.Drawing.Point(208, 8)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 0
      Me.btnQuit.Text = "Quit"
      '
      'btnTest
      '
      Me.btnTest.Location = New System.Drawing.Point(208, 40)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 1
      Me.btnTest.Text = "Test"
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnTest, Me.btnQuit})
      Me.Name = "frmMain"
      Me.Text = "Display HID Status"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      'Exit the application
      End
   End Sub

   'DirectX objects.
   Private DX8 As DirectX8                      'DirectX 8 Object
   Private DI8 As DirectInput8                  'DirectInput 8 Object
   Private DIDI8 As DirectInputDeviceInstance8  'DirectInput 8 Device

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      'Initialize the DirectX objects.
      DX8 = New DirectX8Class()
      DI8 = DX8.DirectInputCreate()

   End Sub

   Private Sub btnTest_Click(ByVal sender As System.Object, _
                             ByVal e As System.EventArgs) Handles btnTest.Click
      'Make sure the DirectInput 8 Device Instance is empty.
      If (DIDI8 Is Nothing) Then
         DIDI8 = Nothing
      End If

      'Get the device information.
      CreateInputDeviceInstance("Mouse")

      'Display the status information.
      If ((DIDI8.GetDevType() And CONST_DI8DEVICESUBTYPE.DIDEVTYPE_HID) _
                              = CONST_DI8DEVICESUBTYPE.DIDEVTYPE_HID) Then
         MessageBox.Show("Mouse is a HID")
      Else
         MessageBox.Show("Mouse is not a HID")
      End If
   End Sub

   Private Sub CreateInputDeviceInstance(ByVal DeviceName As String)
      Dim Devs As DirectInputEnumDevices8        'DirectInput device enumeration.
      Dim DevInst As DirectInputDeviceInstance8  'A single device instance.
      Dim Counter As Integer                     'Loop counter

      'Create a list of devices for this machine.
      Devs = DI8.GetDIDevices(CONST_DI8DEVICETYPE.DI8DEVCLASS_ALL, _
                              CONST_DIENUMDEVICESFLAGS.DIEDFL_ATTACHEDONLY)

      'Search for the correct GUID. Remember to start the 
      'Counter at 1 for VB.
      For Counter = 1 To Devs.GetCount()
         'Get a device instance.
         DevInst = Devs.GetItem(Counter)

         If (DevInst.GetProductName().ToUpper() = DeviceName.ToUpper()) Then
            DIDI8 = DevInst
            Exit For
         End If
      Next
   End Sub

   Protected Overrides Sub OnClosing( _
      ByVal e As System.ComponentModel.CancelEventArgs)
      'Clean up the objects.
      DIDI8 = Nothing
      DI8 = Nothing
      DX8 = Nothing
   End Sub
End Class
