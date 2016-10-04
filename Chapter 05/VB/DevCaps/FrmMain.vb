Imports System.Runtime.InteropServices
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
   Friend WithEvents btnTest As System.Windows.Forms.Button
   Friend WithEvents btnQuit As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.btnTest = New System.Windows.Forms.Button()
      Me.btnQuit = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'btnTest
      '
      Me.btnTest.Location = New System.Drawing.Point(208, 40)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.TabIndex = 3
      Me.btnTest.Text = "Test"
      '
      'btnQuit
      '
      Me.btnQuit.Location = New System.Drawing.Point(208, 8)
      Me.btnQuit.Name = "btnQuit"
      Me.btnQuit.TabIndex = 2
      Me.btnQuit.Text = "Quit"
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnTest, Me.btnQuit})
      Me.Name = "frmMain"
      Me.Text = "GetDeviceCaps() Demonstration"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
      ' Exit the application.
      End
   End Sub

   ' The purpose of this function is to retrieve a device context
   ' essentially a drawing area for the application.
   <DllImport("User32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)> _
   Public Shared Function GetDC(ByVal hWnd As IntPtr) As IntPtr
   End Function

   ' Use this function to release the device context.
   <DllImport("User32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)> _
   Public Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Int32
   End Function

   ' Device Parameters for GetDeviceCaps() 
   Public Enum DevCapParm
      ' General device capabilities.
      DRIVERVERSION = 0     ' Device driver version                    
      TECHNOLOGY = 2        ' Device classification                    
      HORZSIZE = 4          ' Horizontal size in millimeters           
      VERTSIZE = 6          ' Vertical size in millimeters             
      HORZRES = 8           ' Horizontal width in pixels               
      VERTRES = 10          ' Vertical height in pixels                
      BITSPIXEL = 12        ' Number of bits per pixel                 
      PLANES = 14           ' Number of planes                         
      NUMBRUSHES = 16       ' Number of brushes the device has         
      NUMPENS = 18          ' Number of pens the device has            
      NUMMARKERS = 20       ' Number of markers the device has         
      NUMFONTS = 22         ' Number of fonts the device has           
      NUMCOLORS = 24        ' Number of colors the device supports     
      PDEVICESIZE = 26      ' Size required for device descriptor      
      CURVECAPS = 28        ' Curve capabilities                       
      LINECAPS = 30         ' Line capabilities                        
      POLYGONALCAPS = 32    ' Polygonal capabilities                   
      TEXTCAPS = 34         ' Text capabilities                        
      CLIPCAPS = 36         ' Clipping capabilities                    
      RASTERCAPS = 38       ' Bitblt capabilities                      
      ASPECTX = 40          ' Length of the X leg                      
      ASPECTY = 42          ' Length of the Y leg                      
      ASPECTXY = 44         ' Length of the hypotenuse                 
      LOGPIXELSX = 88       ' Logical pixels/inch in X                 
      LOGPIXELSY = 90       ' Logical pixels/inch in Y                 
      SIZEPALETTE = 104     ' Number of entries in physical palette    
      NUMRESERVED = 106     ' Number of reserved entries in palette    
      COLORRES = 108        ' Actual color resolution                  

      ' Printing related DeviceCaps. These replace the appropriate Escapes
      PHYSICALWIDTH = 110   ' Physical Width in device units           
      PHYSICALHEIGHT = 111  ' Physical Height in device units          
      PHYSICALOFFSETX = 112 ' Physical Printable Area x margin         
      PHYSICALOFFSETY = 113 ' Physical Printable Area y margin         
      SCALINGFACTORX = 114  ' Scaling factor x                         
      SCALINGFACTORY = 115  ' Scaling factor y                         

      ' Display driver specific
      VREFRESH = 116         ' Current vertical refresh rate of the    
                             ' display device (for displays only) in Hz
      DESKTOPVERTRES = 117   ' Horizontal width of entire desktop in   
                             ' pixels                                  
      DESKTOPHORZRES = 118   ' Vertical height of entire desktop in    
                             ' pixels                                  
      BLTALIGNMENT = 119     ' Preferred blt alignment                 

      SHADEBLENDCAPS = 120   ' Shading and blending caps               
      COLORMGMTCAPS = 121    ' Color Management caps          
   End Enum

   ' Device Capability Masks: 

   ' Device Technologies 
   Public Enum DevTech
      DT_PLOTTER = 0            ' Vector plotter                   
      DT_RASDISPLAY = 1         ' Raster display                   
      DT_RASPRINTER = 2         ' Raster printer                   
      DT_RASCAMERA = 3          ' Raster camera                    
      DT_CHARSTREAM = 4         ' Character-stream, PLP            
      DT_METAFILE = 5           ' Metafile, VDM                    
      DT_DISPFILE = 6           ' Display-file                     
   End Enum

   ' Curve Capabilities 
   Public Enum CurveCap
      CC_NONE = 0               ' Curves not supported             
      CC_CIRCLES = 1            ' Can do circles                   
      CC_PIE = 2                ' Can do pie wedges                
      CC_CHORD = 4              ' Can do chord arcs                
      CC_ELLIPSES = 8           ' Can do ellipese                  
      CC_WIDE = 16              ' Can do wide lines                
      CC_STYLED = 32            ' Can do styled lines              
      CC_WIDESTYLED = 64        ' Can do wide styled lines         
      CC_INTERIORS = 128        ' Can do interiors                 
      CC_ROUNDRECT = 256        '                                  
   End Enum

   ' Line Capabilities 
   Public Enum LineCap
      LC_NONE = 0               ' Lines not supported              
      LC_POLYLINE = 2           ' Can do polylines                 
      LC_MARKER = 4             ' Can do markers                   
      LC_POLYMARKER = 8         ' Can do polymarkers               
      LC_WIDE = 16              ' Can do wide lines                
      LC_STYLED = 32            ' Can do styled lines              
      LC_WIDESTYLED = 64        ' Can do wide styled lines         
      LC_INTERIORS = 128        ' Can do interiors                 
   End Enum

   ' Polygonal Capabilities 
   Public Enum PolygonCap
      PC_NONE = 0               ' Polygonals not supported         
      PC_POLYGON = 1            ' Can do polygons                  
      PC_RECTANGLE = 2          ' Can do rectangles                
      PC_WINDPOLYGON = 4        ' Can do winding polygons          
      PC_TRAPEZOID = 4          ' Can do trapezoids                
      PC_SCANLINE = 8           ' Can do scanlines                 
      PC_WIDE = 16              ' Can do wide borders              
      PC_STYLED = 32            ' Can do styled borders            
      PC_WIDESTYLED = 64        ' Can do wide styled borders       
      PC_INTERIORS = 128        ' Can do interiors                 
      PC_POLYPOLYGON = 256      ' Can do polypolygons              
      PC_PATHS = 512            ' Can do paths                     
   End Enum

   ' Clipping Capabilities 
   Public Enum ClippingCap
      CP_NONE = 0               ' No clipping of output            
      CP_RECTANGLE = 1          ' Output clipped to rects          
      CP_REGION = 2             ' obsolete                         
   End Enum

   ' Text Capabilities 
   Public Enum TextCap
      TC_OP_CHARACTER = &H1             ' Can do OutputPrecision   CHARACTER      
      TC_OP_STROKE = &H2                ' Can do OutputPrecision   STROKE         
      TC_CP_STROKE = &H4                ' Can do ClipPrecision     STROKE         
      TC_CR_90 = &H8                    ' Can do CharRotAbility    90             
      TC_CR_ANY = &H10                  ' Can do CharRotAbility    ANY            
      TC_SF_X_YINDEP = &H20             ' Can do ScaleFreedom      X_YINDEPENDENT 
      TC_SA_DOUBLE = &H40               ' Can do ScaleAbility      DOUBLE         
      TC_SA_INTEGER = &H80              ' Can do ScaleAbility      INTEGER        
      TC_SA_CONTIN = &H100              ' Can do ScaleAbility      CONTINUOUS     
      TC_EA_DOUBLE = &H200              ' Can do EmboldenAbility   DOUBLE         
      TC_IA_ABLE = &H400                ' Can do ItalisizeAbility  ABLE           
      TC_UA_ABLE = &H800                ' Can do UnderlineAbility  ABLE           
      TC_SO_ABLE = &H1000               ' Can do StrikeOutAbility  ABLE           
      TC_RA_ABLE = &H2000               ' Can do RasterFontAble    ABLE           
      TC_VA_ABLE = &H4000               ' Can do VectorFontAble    ABLE           
      TC_RESERVED = &H8000
      TC_SCROLLBLT = &H10000            ' Don't do text scroll with blt           
   End Enum

   ' Raster Capabilities 
   Public Enum RasterCap
      RC_NONE = 0
      RC_BITBLT = 1                 ' Can do standard BLT.             
      RC_BANDING = 2                ' Device requires banding support  
      RC_SCALING = 4                ' Device requires scaling support  
      RC_BITMAP64 = 8               ' Device can support >64K bitmap   
      RC_GDI20_OUTPUT = &H10        ' has 2.0 output calls         
      RC_GDI20_STATE = &H20
      RC_SAVEBITMAP = &H40
      RC_DI_BITMAP = &H80           ' supports DIB to memory       
      RC_PALETTE = &H100            ' supports a palette           
      RC_DIBTODEV = &H200           ' supports DIBitsToDevice      
      RC_BIGFONT = &H400            ' supports >64K fonts          
      RC_STRETCHBLT = &H800         ' supports StretchBlt          
      RC_FLOODFILL = &H1000         ' supports FloodFill           
      RC_STRETCHDIB = &H2000        ' supports StretchDIBits       
      RC_OP_DX_OUTPUT = &H4000
      RC_DEVBITS = &H8000
   End Enum

   ' Shading and blending caps 
   Public Enum ShadeAndBlendCap
      SB_NONE = &H0
      SB_CONST_ALPHA = &H1
      SB_PIXEL_ALPHA = &H2
      SB_PREMULT_ALPHA = &H4
      SB_GRAD_RECT = &H10
      SB_GRAD_TRI = &H20
   End Enum

   ' Color Management caps 
   Public Enum ColorMngCap
      CM_NONE = &H0
      CM_DEVICE_ICM = &H1
      CM_GAMMA_RAMP = &H2
      CM_CMYK_COLOR = &H4
   End Enum

   ' This function returns the device capability value specified
   ' by the requested index value.
   <DllImport("GDI32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)> _
   Public Shared Function GetDeviceCaps(ByVal hdc As IntPtr, ByVal nIndex As Int32) As Int32
   End Function

   Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
      Dim hDC As IntPtr             ' Device context for current window.
      Dim Result As Int32           ' The result of the call.
      Dim Output As StringBuilder   ' The output for the method.

      ' Obtain a device context for the current application.
      hDC = GetDC(Me.Handle)

      ' Check for errors.
      If (hDC.ToInt32() = IntPtr.Zero.ToInt32()) Then
         ' Display an error message.
         MessageBox.Show("Couldn't obtain device context!", _
                         "Application Error", _
                         MessageBoxButtons.OK, _
                         MessageBoxIcon.Error)

         Return
      End If

      ' Obtain the current display capability.
      Output = New StringBuilder()
      Result = GetDeviceCaps(hDC, DevCapParm.DESKTOPHORZRES)
      Output.Append("The horizontal resolution: " + Result.ToString())
      Result = GetDeviceCaps(hDC, DevCapParm.DESKTOPVERTRES)
      Output.Append(vbCrLf + "The vertical resolution: " + Result.ToString())
      Result = GetDeviceCaps(hDC, DevCapParm.BITSPIXEL)
      Output.Append(vbCrLf + "The bits/pixel value: " + Result.ToString())

      ' Display the results.
      MessageBox.Show(Output.ToString(), _
                      "Current Display Capabilities", _
                      MessageBoxButtons.OK, _
                      MessageBoxIcon.Information)

      ' Release the device context when finished.
      ReleaseDC(Me.Handle, hDC)
   End Sub
End Class
