using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ColorCheck
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmMain : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.PictureBox pbSample;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuFileOpen;
        private System.Windows.Forms.MenuItem mnuFileExit;
        private System.Windows.Forms.MenuItem mnuColor;
        private System.Windows.Forms.MenuItem mnuColorNormal;
        private System.Windows.Forms.MenuItem mnuColorProtanopia;
        private System.Windows.Forms.MenuItem mnuColorDeuteranopia;
        private System.Windows.Forms.MenuItem mnuColorTritanopia;
        private System.Windows.Forms.MenuItem mnuEdit;
        private System.Windows.Forms.MenuItem mnuEditCut;
        private System.Windows.Forms.MenuItem mnuEditCopy;
        private System.Windows.Forms.MenuItem mnuEditPaste;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Define the transformation arrays.
        private Color[,,]   aProtanopia = new Color[6, 6, 6];
        private Color[,,]   aDeuteranopia = new Color[6, 6, 6];
        private Color[,,]   aTritanopia = new Color[6, 6, 6];

        public frmMain()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // Fill the color arrays.
            aProtanopia = FillColorArray(aProtanopiaData);
            aDeuteranopia = FillColorArray(aDeuteranopiaData);
            aTritanopia = FillColorArray(aTritanopiaData);
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuFileOpen = new System.Windows.Forms.MenuItem();
            this.mnuFileExit = new System.Windows.Forms.MenuItem();
            this.mnuEdit = new System.Windows.Forms.MenuItem();
            this.mnuEditCut = new System.Windows.Forms.MenuItem();
            this.mnuEditCopy = new System.Windows.Forms.MenuItem();
            this.mnuEditPaste = new System.Windows.Forms.MenuItem();
            this.mnuColor = new System.Windows.Forms.MenuItem();
            this.mnuColorNormal = new System.Windows.Forms.MenuItem();
            this.mnuColorProtanopia = new System.Windows.Forms.MenuItem();
            this.mnuColorDeuteranopia = new System.Windows.Forms.MenuItem();
            this.mnuColorTritanopia = new System.Windows.Forms.MenuItem();
            this.pbSample = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.mnuFile,
                                                                                      this.mnuEdit,
                                                                                      this.mnuColor});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                    this.mnuFileOpen,
                                                                                    this.mnuFileExit});
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Index = 0;
            this.mnuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Index = 1;
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 1;
            this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                    this.mnuEditCut,
                                                                                    this.mnuEditCopy,
                                                                                    this.mnuEditPaste});
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditCut
            // 
            this.mnuEditCut.Index = 0;
            this.mnuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mnuEditCut.Text = "Cu&t";
            this.mnuEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Index = 1;
            this.mnuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.mnuEditCopy.Text = "&Copy";
            this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
            // 
            // mnuEditPaste
            // 
            this.mnuEditPaste.Index = 2;
            this.mnuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.mnuEditPaste.Text = "&Paste";
            this.mnuEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
            // 
            // mnuColor
            // 
            this.mnuColor.Enabled = false;
            this.mnuColor.Index = 2;
            this.mnuColor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.mnuColorNormal,
                                                                                     this.mnuColorProtanopia,
                                                                                     this.mnuColorDeuteranopia,
                                                                                     this.mnuColorTritanopia});
            this.mnuColor.Text = "&Color Setting";
            // 
            // mnuColorNormal
            // 
            this.mnuColorNormal.Checked = true;
            this.mnuColorNormal.Index = 0;
            this.mnuColorNormal.RadioCheck = true;
            this.mnuColorNormal.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.mnuColorNormal.Text = "&Normal";
            this.mnuColorNormal.Click += new System.EventHandler(this.mnuColorNormal_Click);
            // 
            // mnuColorProtanopia
            // 
            this.mnuColorProtanopia.Index = 1;
            this.mnuColorProtanopia.RadioCheck = true;
            this.mnuColorProtanopia.Shortcut = System.Windows.Forms.Shortcut.F2;
            this.mnuColorProtanopia.Text = "&Protanopia (Red Loss)";
            this.mnuColorProtanopia.Click += new System.EventHandler(this.mnuColorProtanopia_Click);
            // 
            // mnuColorDeuteranopia
            // 
            this.mnuColorDeuteranopia.Index = 2;
            this.mnuColorDeuteranopia.RadioCheck = true;
            this.mnuColorDeuteranopia.Shortcut = System.Windows.Forms.Shortcut.F4;
            this.mnuColorDeuteranopia.Text = "&Deuteranopia (Green Loss)";
            this.mnuColorDeuteranopia.Click += new System.EventHandler(this.mnuColorDeuteranopia_Click);
            // 
            // mnuColorTritanopia
            // 
            this.mnuColorTritanopia.Index = 3;
            this.mnuColorTritanopia.RadioCheck = true;
            this.mnuColorTritanopia.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.mnuColorTritanopia.Text = "&Tritanopia (Blue Loss)";
            this.mnuColorTritanopia.Click += new System.EventHandler(this.mnuColorTritanopia_Click);
            // 
            // pbSample
            // 
            this.pbSample.AccessibleDescription = "The image that the developer wants to test.";
            this.pbSample.AccessibleName = "Sample Image";
            this.pbSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSample.Location = new System.Drawing.Point(0, 0);
            this.pbSample.Name = "pbSample";
            this.pbSample.Size = new System.Drawing.Size(320, 226);
            this.pbSample.TabIndex = 0;
            this.pbSample.TabStop = false;
            // 
            // frmMain
            // 
            this.AccessibleDescription = "This application modifies the display to simulate various types of color blindnes" +
                "s.";
            this.AccessibleName = "Application Color Blindness Tester";
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(320, 226);
            this.Controls.Add(this.pbSample);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.Text = "Application Color Blindness Tester";
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

        #region File Menu
        private void mnuFileExit_Click(object sender, System.EventArgs e)
        {
            // Exit the application.
            Close();
        }

        private void mnuFileOpen_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog	Dlg;		// File Open Dialog
            String			File2Open;	// Selected Filename
            Bitmap          Graphic;    // The opened bitmap.
            PixelFormat     PF;         // The standard pixel format.
            Bitmap          Sample;     // Holds sample color table.

            // Set up the File Open Dialog
            Dlg = new OpenFileDialog();
            Dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp|" +
                "Enhanced Metafile (*.emf)|*.emf|" +
                "Graphics Interchange Format File (*.gif)|*.gif|" +
                "Windows Icon (*.ico)|*.ico|" +
                "Joint Photographic Experts Group (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png|" +
                "Windows Metafile (*.wmf)|*.wmf";
            Dlg.DefaultExt = ".gif";
            Dlg.Title = "Open File Dialog";

            // Display the File Open Dialog and obtain the name of a file and
            // the file information.
            if (Dlg.ShowDialog() == DialogResult.OK)
            {
                File2Open = Dlg.FileName;
            }
            else
            {
                // If the user didn't select anything, return.
                return;
            }

            // Open the document and make a copy.
            Graphic = new Bitmap(File2Open, true);

            // Change the title bar.
            frmMain.ActiveForm.Text = 
                "Application Color Blindness Tester - " + File2Open;

            // Draw a graphic normally.
            pbSample.Image = Graphic;

            // Store the color palette used for this image.
            if (Graphic.Palette.Entries.Length > 0)
            {
                // Use the color palette stored in the image if possible.
                CPNormal = Graphic.Palette;

                // Create the alternate palettes.
                CreatePalettes(Graphic.Palette);
            }
            else
            {
                // Create a sample graphic.
                PF = PixelFormat.Format8bppIndexed;
                Sample = new Bitmap(1, 1, PF);

                // Use this generic bitmap for the palette it contains.
                CPNormal = Sample.Palette;

                // Create the alternate palettes.
                CreatePalettes(Sample.Palette);
            }

            // Enable the Color Setting menu.
            mnuColor.Enabled = true;
            CheckThis(mnuColorNormal);
        }
        #endregion

        #region Edit Menu
        private void mnuEditCut_Click(object sender, System.EventArgs e)
        {
            // Copy the current image to the clipboard and clear the image.
            Clipboard.SetDataObject(pbSample.Image);

            // Clear the image.
            pbSample.Image = null;

            // Disable the Color Setting menu.
            mnuColor.Enabled = false;
        }

        private void mnuEditCopy_Click(object sender, System.EventArgs e)
        {
            // Copy the current image to the clipboard.
            Clipboard.SetDataObject(pbSample.Image);
        }

        private void mnuEditPaste_Click(object sender, System.EventArgs e)
        {
            IDataObject     oData;      // The clipboard data.
            Bitmap          Graphic;    // The image to display.
            PixelFormat     PF;         // The standard pixel format.
            Bitmap          Sample;     // Holds sample color table.

            // Get the clipboard data.
            oData = Clipboard.GetDataObject();

            // Make sure there is some data present.
            if (oData.GetDataPresent(DataFormats.Bitmap))
            {
                // Place the data on screen.
                pbSample.Image = (Bitmap)oData.GetData(DataFormats.Bitmap);
                Graphic = (Bitmap)oData.GetData(DataFormats.Bitmap);

                // Store the color palette used for this image.
                if (Graphic.Palette.Entries.Length > 0)
                {
                    // Use the color palette stored in the image if possible.
                    CPNormal = Graphic.Palette;

                    // Create the alternate palettes.
                    CreatePalettes(Graphic.Palette);
                }
                else
                {
                    // Create a sample graphic.
                    PF = PixelFormat.Format8bppIndexed;
                    Sample = new Bitmap(1, 1, PF);

                    // Use this generic bitmap for the palette it contains.
                    CPNormal = Sample.Palette;

                    // Create the alternate palettes.
                    CreatePalettes(Sample.Palette);
                }

                // Enable the Color Setting menu.
                mnuColor.Enabled = true;
                CheckThis(mnuColorNormal);
            }
        }
        #endregion

        #region Palette Manipulation
        // Color variable use to store the current color settings.
        ColorPalette    CPNormal;
        ColorPalette    CPProtanopia;
        ColorPalette    CPDeuteranopia;
        ColorPalette    CPTritanopia;

        private void CreatePalettes(ColorPalette CP)
        {
            // Create each of the color palettes in turn.
            CPProtanopia = CreateModifiedPalette(CP, aProtanopia);
            CPDeuteranopia = CreateModifiedPalette(CP, aDeuteranopia);
            CPTritanopia = CreateModifiedPalette(CP, aTritanopia);
        }

        private ColorPalette CreateModifiedPalette(ColorPalette CP, Color[,,] Data)
        {
            ColorPalette    Temp;   // Temporary data holder.
            PixelFormat     PF;     // The standard pixel format.
            Bitmap          Sample; // Holds sample color table.
            Int32           Red;    // Red value index.
            Int32           Blue;   // Blue value index.
            Int32           Green;  // Green value index.
            Double          RConv;  // Red conversion value.
            Double          BConv;  // Blue conversion value.
            Double          GConv;  // Green conversion value.

            // Create a temporary palette.
            // Begin by creating a sample graphic.
            PF = PixelFormat.Format8bppIndexed;
            Sample = new Bitmap(1, 1, PF);

            // Use this generic bitmap for the palette it contains.
            Temp = Sample.Palette;
 
            // Modify the entires to simulate color blindness.
            for (int Counter = 0; Counter < CP.Entries.Length; Counter++)
            {
                // Obtain the current color values.
                RConv = CP.Entries[Counter].R;
                GConv = CP.Entries[Counter].G;
                BConv = CP.Entries[Counter].B;

                // Define the index value used for looking up the conversion
                // colors.
                Red = Convert.ToInt32(5 - RConv / 51);
                Green = Convert.ToInt32(5 - GConv / 51);
                Blue = Convert.ToInt32(5 - BConv / 51);

                // Obtain the entry from the lookup table and place it in the
                // new palette.
                Temp.Entries[Counter] = Data[Red, Green, Blue];
            }

            // Return the result.
            return Temp;
        }
        #endregion

        #region Color Menu
        private void CheckThis(MenuItem MenuOption)
        {
            // Clear the current checks.
            mnuColorNormal.Checked = false;
            mnuColorProtanopia.Checked = false;
            mnuColorDeuteranopia.Checked = false;
            mnuColorTritanopia.Checked = false;

            // Check the selected menu option.
            MenuOption.Checked = true;
        }

        private void mnuColorNormal_Click(object sender, System.EventArgs e)
        {
            // Check this option on the menu.
            CheckThis(mnuColorNormal);

            // Restore the image.
            pbSample.Image.Palette = CPNormal;
            pbSample.Invalidate();
        }

        private void mnuColorProtanopia_Click(object sender, System.EventArgs e)
        {
            // Check this option on the menu.
            CheckThis(mnuColorProtanopia);

            // Modify the image palette to match.
            pbSample.Image.Palette = CPProtanopia;
            pbSample.Invalidate();
        }

        private void mnuColorDeuteranopia_Click(object sender, System.EventArgs e)
        {
            // Check this option on the menu.
            CheckThis(mnuColorDeuteranopia);

            // Modify the image palette to match.
            pbSample.Image.Palette = CPDeuteranopia;
            pbSample.Invalidate();
        }

        private void mnuColorTritanopia_Click(object sender, System.EventArgs e)
        {
            // Check this option on the menu.
            CheckThis(mnuColorTritanopia);

            // Modify the image palette to match.
            pbSample.Image.Palette = CPTritanopia;
            pbSample.Invalidate();
        }
        #endregion

        #region Data Arrays
        private Color[,,] FillColorArray(int[,] InputData)
        {
            int         DataCounter = 0;            // Data array counter.
            Color[,,]   Temp = new Color[6,6,6];    // Color array.

            // Loop through the various count value until the Protanopia array
            // is filled.
            for (int RCount = 0; RCount < 6; RCount++)
                for (int GCount = 0; GCount < 6; GCount++)
                    for (int BCount = 0; BCount < 6; BCount++)
                    {
                        // Get the array value.
                        Temp[RCount,GCount,BCount] = 
                            Color.FromArgb(InputData[DataCounter, 0],
                            InputData[DataCounter, 1],
                            InputData[DataCounter, 2]);

                        // Increment the data counter.
                        DataCounter++;
                    }

            // Return the results.
            return Temp;
        }

        private int[,]  aProtanopiaData =  {{255, 250, 250},
                                            {255, 242, 200},
                                            {255, 237, 162},
                                            {255, 234, 134},
                                            {255, 233, 117},
                                            {255, 232, 113},
                                            {207, 215, 255},
                                            {222, 216, 210},
                                            {229, 214, 157},
                                            {233, 212, 105},
                                            {236, 212, 053},
                                            {236, 211, 015},
                                            {170, 189, 255},
                                            {177, 184, 224},
                                            {189, 182, 168},
                                            {196, 180, 112},
                                            {199, 180, 058},
                                            {200, 179, 023},
                                            {152, 178, 255},
                                            {130, 160, 246},
                                            {153, 157, 185},
                                            {165, 155, 124},
                                            {170, 154, 066},
                                            {172, 154, 030},
                                            {150, 177, 255},
                                            {119, 157, 255},
                                            {122, 142, 206},
                                            {143, 140, 139},
                                            {152, 139, 074},
                                            {154, 139, 035},
                                            {150, 177, 255},
                                            {123, 160, 255},
                                            {110, 137, 215},
                                            {136, 136, 146},
                                            {147, 135, 078},
                                            {150, 135, 038},
                                            {248, 244, 248},
                                            {255, 241, 197},
                                            {255, 235, 151},
                                            {255, 232, 115},
                                            {255, 231, 092},
                                            {255, 230, 085},
                                            {196, 206, 255},
                                            {207, 203, 203},
                                            {215, 201, 151},
                                            {219, 199, 100},
                                            {221, 198, 049},
                                            {221, 198, 000},
                                            {152, 177, 255},
                                            {158, 168, 215},
                                            {170, 165, 160},
                                            {177, 164, 106},
                                            {181, 163, 054},
                                            {181, 162, 014},
                                            {135, 167, 255},
                                            {100, 140, 235},
                                            {127, 136, 175},
                                            {140, 134, 117},
                                            {146, 133, 060},
                                            {148, 132, 021},
                                            {138, 170, 255},
                                            {067, 135, 255},
                                            {082, 117, 200},
                                            {112, 115, 135},
                                            {123, 113, 070},
                                            {126, 113, 027},
                                            {140, 171, 255},
                                            {093, 145, 255},
                                            {053, 111, 213},
                                            {100, 109, 144},
                                            {116, 108, 076},
                                            {120, 108, 030},
                                            {239, 236, 244},
                                            {247, 233, 193},
                                            {251, 231, 144},
                                            {254, 230, 094},
                                            {255, 229, 050},
                                            {255, 228, 028},
                                            {185, 197, 250},
                                            {196, 193, 198},
                                            {203, 191, 147},
                                            {207, 189, 097},
                                            {209, 188, 047},
                                            {210, 188, 000},
                                            {131, 164, 255},
                                            {143, 156, 206},
                                            {155, 152, 153},
                                            {162, 150, 101},
                                            {165, 149, 050},
                                            {166, 149, 000},
                                            {112, 155, 255},
                                            {073, 123, 223},
                                            {106, 119, 165},
                                            {120, 116, 109},
                                            {126, 114, 055},
                                            {127, 114, 013},
                                            {125, 162, 255},
                                            {000, 122, 246},
                                            {000, 094, 191},
                                            {080, 091, 128},
                                            {095, 089, 065},
                                            {099, 089, 019},
                                            {131, 166, 255},
                                            {039, 130, 255},
                                            {000, 103, 208},
                                            {057, 083, 143},
                                            {085, 081, 074},
                                            {090, 081, 023},
                                            {234, 231, 240},
                                            {241, 228, 191},
                                            {246, 226, 141},
                                            {248, 225, 093},
                                            {250, 224, 042},
                                            {250, 224, 000},
                                            {178, 190, 245},
                                            {189, 187, 193},
                                            {196, 184, 143},
                                            {200, 182, 094},
                                            {202, 181, 045},
                                            {202, 181, 000},
                                            {110, 152, 254},
                                            {133, 147, 199},
                                            {145, 143, 147},
                                            {152, 140, 097},
                                            {155, 139, 047},
                                            {155, 139, 000},
                                            {081, 141, 255},
                                            {050, 110, 213},
                                            {089, 105, 156},
                                            {104, 102, 102},
                                            {109, 100, 050},
                                            {111, 099, 000},
                                            {110, 154, 255},
                                            {000, 116, 234},
                                            {000, 089, 180},
                                            {050, 070, 118},
                                            {070, 067, 058},
                                            {074, 066, 011},
                                            {122, 161, 255},
                                            {000, 124, 248},
                                            {000, 101, 202},
                                            {000, 071, 142},
                                            {050, 055, 072},
                                            {060, 054, 015},
                                            {231, 229, 239},
                                            {238, 226, 189},
                                            {243, 223, 140},
                                            {245, 222, 092},
                                            {247, 221, 041},
                                            {247, 221, 000},
                                            {174, 187, 242},
                                            {185, 183, 191},
                                            {192, 180, 142},
                                            {196, 178, 093},
                                            {198, 178, 044},
                                            {198, 177, 000},
                                            {105, 147, 250},
                                            {127, 142, 195},
                                            {140, 138, 144},
                                            {146, 135, 094},
                                            {149, 134, 046},
                                            {149, 134, 000},
                                            {037, 129, 255},
                                            {032, 103, 205},
                                            {080, 097, 149},
                                            {094, 093, 097},
                                            {100, 091, 047},
                                            {101, 091, 000},
                                            {096, 148, 255},
                                            {000, 112, 225},
                                            {000, 084, 170},
                                            {025, 055, 106},
                                            {052, 051, 051},
                                            {055, 050, 000},
                                            {115, 157, 255},
                                            {000, 121, 242},
                                            {000, 098, 196},
                                            {000, 070, 139},
                                            {000, 036, 072},
                                            {030, 027, 008},
                                            {230, 228, 238},
                                            {237, 225, 189},
                                            {242, 223, 140},
                                            {245, 221, 092},
                                            {246, 221, 041},
                                            {246, 220, 000},
                                            {173, 186, 242},
                                            {184, 182, 191},
                                            {191, 179, 141},
                                            {195, 178, 093},
                                            {197, 177, 043},
                                            {197, 176, 000},
                                            {103, 146, 248},
                                            {126, 141, 194},
                                            {138, 137, 143},
                                            {144, 134, 094},
                                            {147, 133, 045},
                                            {148, 133, 000},
                                            {000, 126, 254},
                                            {026, 102, 204},
                                            {078, 095, 147},
                                            {092, 091, 095},
                                            {097, 089, 046},
                                            {099, 088, 000},
                                            {091, 145, 255},
                                            {000, 111, 222},
                                            {000, 083, 166},
                                            {013, 051, 102},
                                            {046, 046, 048},
                                            {049, 044, 000},
                                            {113, 156, 255},
                                            {000, 120, 240},
                                            {000, 096, 193},
                                            {000, 068, 135},
                                            {000, 035, 070},
                                            {000, 000, 000}};

    private int[,] aDeuteranopiaData = {{255, 232, 239},
                                        {255, 223, 200},
                                        {255, 218, 173},
                                        {255, 215, 157},
                                        {255, 213, 148},
                                        {255, 213, 146},
                                        {225, 216, 253},
                                        {241, 210, 203},
                                        {252, 205, 153},
                                        {255, 202, 111},
                                        {255, 200, 087},
                                        {255, 199, 080},
                                        {176, 188, 249},
                                        {197, 181, 199},
                                        {210, 176, 149},
                                        {218, 172, 098},
                                        {222, 171, 042},
                                        {223, 170, 000},
                                        {133, 167, 245},
                                        {160, 159, 195},
                                        {177, 153, 146},
                                        {187, 149, 094},
                                        {191, 147, 034},
                                        {192, 147, 000},
                                        {103, 155, 242},
                                        {138, 146, 193},
                                        {157, 139, 143},
                                        {167, 135, 092},
                                        {173, 132, 028},
                                        {174, 134, 000},
                                        {094, 152, 241},
                                        {131, 143, 192},
                                        {151, 136, 142},
                                        {162, 131, 091},
                                        {168, 128, 026},
                                        {169, 130, 000},
                                        {255, 234, 253},
                                        {255, 222, 204},
                                        {255, 216, 171},
                                        {255, 212, 151},
                                        {255, 211, 140},
                                        {255, 211, 137},
                                        {203, 204, 255},
                                        {222, 198, 205},
                                        {234, 193, 155},
                                        {241, 190, 106},
                                        {245, 188, 059},
                                        {246, 198, 000},
                                        {143, 174, 251},
                                        {170, 167, 201},
                                        {186, 161, 152},
                                        {196, 157, 101},
                                        {201, 155, 050},
                                        {202, 154, 000},
                                        {076, 151, 246},
                                        {123, 141, 197},
                                        {145, 134, 148},
                                        {158, 129, 097},
                                        {164, 126, 043},
                                        {166, 127, 000},
                                        {000, 141, 239},
                                        {087, 126, 194},
                                        {118, 117, 145},
                                        {133, 111, 095},
                                        {140, 108, 039},
                                        {143, 109, 000},
                                        {000, 140, 236},
                                        {075, 122, 192},
                                        {110, 113, 144},
                                        {126, 106, 094},
                                        {133, 103, 038},
                                        {136, 105, 000},
                                        {244, 228, 255},
                                        {255, 221, 208},
                                        {255, 214, 169},
                                        {255, 210, 145},
                                        {255, 209, 132},
                                        {255, 208, 128},
                                        {185, 196, 255},
                                        {206, 189, 207},
                                        {219, 184, 157},
                                        {228, 181, 108},
                                        {232, 179, 063},
                                        {233, 178, 042},
                                        {111, 164, 253},
                                        {146, 155, 204},
                                        {166, 148, 154},
                                        {178, 144, 104},
                                        {183, 142, 055},
                                        {166, 149, 000},
                                        {000, 144, 243},
                                        {080, 127, 199},
                                        {115, 118, 150},
                                        {132, 112, 100},
                                        {140, 109, 049},
                                        {142, 108, 000},
                                        {000, 141, 232},
                                        {000, 115, 194},
                                        {073, 097, 146},
                                        {098, 089, 097},
                                        {108, 085, 045},
                                        {112, 086, 000},
                                        {000, 140, 229},
                                        {000, 115, 192},
                                        {056, 091, 144},
                                        {087, 083, 095},
                                        {099, 078, 044},
                                        {103, 079, 000},
                                        {235, 223, 255},
                                        {255, 221, 211},
                                        {255, 213, 167},
                                        {255, 208, 139},
                                        {255, 207, 124},
                                        {255, 206, 121},
                                        {173, 190, 255},
                                        {195, 183, 209},
                                        {210, 178, 159},
                                        {218, 174, 110},
                                        {223, 172, 066},
                                        {224, 172, 046},
                                        {081, 156, 254},
                                        {128, 147, 205},
                                        {151, 140, 156},
                                        {164, 135, 106},
                                        {170, 133, 059},
                                        {172, 132, 033},
                                        {000, 144, 238},
                                        {000, 118, 201},
                                        {088, 106, 152},
                                        {111, 099, 103},
                                        {121, 095, 053},
                                        {123, 094, 017},
                                        {000, 140, 228},
                                        {000, 118, 194},
                                        {000, 089, 149},
                                        {061, 071, 099},
                                        {079, 064, 049},
                                        {083, 064, 000},
                                        {000, 139, 225},
                                        {000, 118, 191},
                                        {000, 090, 148},
                                        {037, 061, 096},
                                        {063, 053, 047},
                                        {069, 053, 000},
                                        {231, 221, 255},
                                        {252, 219, 212},
                                        {255, 212, 166},
                                        {255, 207, 136},
                                        {255, 205, 120},
                                        {255, 205, 116},
                                        {167, 187, 255},
                                        {189, 180, 209},
                                        {204, 174, 160},
                                        {214, 171, 111},
                                        {218, 169, 067},
                                        {219, 168, 048},
                                        {057, 153, 255},
                                        {117, 143, 206},
                                        {143, 135, 157},
                                        {157, 130, 107},
                                        {164, 128, 060},
                                        {165, 134, 000},
                                        {000, 144, 236},
                                        {000, 120, 201},
                                        {067, 099, 154},
                                        {097, 091, 104},
                                        {109, 087, 055},
                                        {112, 086, 023},
                                        {000, 140, 226},
                                        {000, 120, 194},
                                        {000, 093, 153},
                                        {000, 059, 101},
                                        {055, 049, 051},
                                        {061, 047, 009},
                                        {000, 139, 223},
                                        {000, 118, 191},
                                        {000, 093, 150},
                                        {000, 063, 103},
                                        {019, 030, 048},
                                        {034, 026, 000},
                                        {230, 220, 255},
                                        {251, 218, 212},
                                        {255, 211, 166},
                                        {255, 207, 135},
                                        {255, 205, 119},
                                        {255, 205, 114},
                                        {165, 187, 255},
                                        {187, 179, 209},
                                        {203, 174, 160},
                                        {212, 170, 111},
                                        {217, 168, 068},
                                        {218, 168, 049},
                                        {051, 152, 255},
                                        {114, 142, 207},
                                        {141, 134, 157},
                                        {155, 129, 108},
                                        {162, 126, 061},
                                        {163, 126, 037},
                                        {000, 144, 236},
                                        {000, 120, 201},
                                        {061, 098, 154},
                                        {094, 090, 105},
                                        {106, 085, 056},
                                        {109, 084, 024},
                                        {000, 140, 226},
                                        {000, 120, 194},
                                        {000, 094, 154},
                                        {000, 062, 104},
                                        {047, 045, 052},
                                        {054, 042, 012},
                                        {000, 139, 223},
                                        {000, 118, 190},
                                        {000, 094, 151},
                                        {000, 065, 104},
                                        {000, 033, 053},
                                        {000, 000, 000}};

        private int[,] aTritanopiaData =   {{244, 240, 255},
                                            {253, 239, 255},
                                            {255, 234, 249},
                                            {255, 230, 245},
                                            {255, 229, 243},
                                            {255, 228, 242},
                                            {251, 209, 225},
                                            {255, 202, 216},
                                            {255, 196, 209},
                                            {255, 192, 205},
                                            {255, 191, 202},
                                            {255, 190, 202},
                                            {246, 169, 181},
                                            {252, 159, 170},
                                            {255, 153, 162},
                                            {255, 149, 158},
                                            {255, 148, 157},
                                            {255, 148, 156},
                                            {242, 135, 145},
                                            {248, 121, 129},
                                            {253, 110, 116},
                                            {255, 102, 108},
                                            {255, 101, 106},
                                            {255, 101, 105},
                                            {240, 113, 120},
                                            {247, 094, 099},
                                            {251, 076, 079},
                                            {254, 061, 062},
                                            {255, 051, 050},
                                            {255, 051, 049},
                                            {240, 106, 113},
                                            {246, 085, 090},
                                            {250, 064, 066},
                                            {253, 043, 040},
                                            {254, 026, 000},
                                            {254, 028, 000},
                                            {203, 239, 255},
                                            {211, 239, 255},
                                            {217, 238, 255},
                                            {221, 238, 255},
                                            {224, 238, 255},
                                            {224, 238, 255},
                                            {198, 209, 225},
                                            {206, 202, 217},
                                            {211, 196, 211},
                                            {215, 193, 207},
                                            {216, 191, 205},
                                            {217, 190, 204},
                                            {191, 169, 182},
                                            {199, 159, 171},
                                            {205, 152, 162},
                                            {208, 146, 157},
                                            {210, 144, 154},
                                            {211, 143, 153},
                                            {187, 135, 145},
                                            {195, 121, 130},
                                            {201, 110, 117},
                                            {204, 101, 108},
                                            {206, 096, 103},
                                            {207, 095, 101},
                                            {184, 113, 120},
                                            {193, 094, 100},
                                            {198, 076, 080},
                                            {202, 061, 063},
                                            {204, 051, 052},
                                            {204, 048, 048},
                                            {183, 106, 113},
                                            {192, 085, 090},
                                            {198, 064, 067},
                                            {202, 043, 043},
                                            {203, 023, 011},
                                            {204, 022, 000},
                                            {166, 239, 255},
                                            {172, 239, 255},
                                            {176, 238, 255},
                                            {180, 238, 255},
                                            {181, 237, 255},
                                            {182, 237, 255},
                                            {145, 209, 225},
                                            {156, 202, 217},
                                            {163, 196, 211},
                                            {168, 193, 207},
                                            {170, 191, 205},
                                            {171, 190, 205},
                                            {134, 169, 182},
                                            {146, 159, 171},
                                            {154, 151, 163},
                                            {159, 146, 157},
                                            {162, 144, 154},
                                            {162, 143, 153},
                                            {126, 135, 145},
                                            {140, 121, 130},
                                            {148, 109, 117},
                                            {154, 101, 108},
                                            {156, 096, 103},
                                            {157, 095, 102},
                                            {122, 112, 120},
                                            {136, 093, 100},
                                            {145, 076, 081},
                                            {150, 061, 064},
                                            {153, 051, 053},
                                            {154, 048, 050},
                                            {121, 106, 113},
                                            {135, 085, 091},
                                            {144, 064, 068},
                                            {150, 043, 044},
                                            {152, 022, 018},
                                            {153, 017, 000},
                                            {136, 239, 255},
                                            {139, 239, 255},
                                            {142, 238, 255},
                                            {144, 238, 255},
                                            {146, 237, 255},
                                            {146, 237, 255},
                                            {087, 209, 225},
                                            {107, 202, 217},
                                            {119, 196, 211},
                                            {126, 193, 207},
                                            {129, 191, 205},
                                            {130, 190, 205},
                                            {062, 169, 182},
                                            {090, 159, 171},
                                            {105, 151, 163},
                                            {113, 146, 157},
                                            {116, 144, 154},
                                            {117, 143, 154},
                                            {034, 135, 145},
                                            {077, 121, 130},
                                            {094, 109, 117},
                                            {103, 101, 108},
                                            {107, 096, 103},
                                            {108, 095, 102},
                                            {000, 113, 121},
                                            {068, 093, 100},
                                            {088, 076, 081},
                                            {098, 061, 065},
                                            {102, 051, 054},
                                            {103, 048, 051},
                                            {000, 107, 115},
                                            {066, 084, 091},
                                            {086, 063, 068},
                                            {096, 043, 045},
                                            {101, 022, 021},
                                            {102, 011, 000},
                                            {116, 239, 255},
                                            {118, 239, 255},
                                            {120, 238, 255},
                                            {121, 238, 255},
                                            {122, 237, 255},
                                            {122, 237, 255},
                                            {000, 209, 224},
                                            {062, 202, 217},
                                            {084, 196, 211},
                                            {094, 193, 207},
                                            {099, 191, 205},
                                            {100, 191, 215},
                                            {000, 171, 183},
                                            {000, 160, 172},
                                            {057, 151, 163},
                                            {073, 146, 157},
                                            {079, 144, 154},
                                            {081, 143, 154},
                                            {000, 144, 153},
                                            {000, 127, 135},
                                            {020, 109, 118},
                                            {053, 101, 109},
                                            {063, 096, 104},
                                            {065, 095, 102},
                                            {000, 129, 135},
                                            {000, 106, 112},
                                            {000, 080, 086},
                                            {038, 060, 065},
                                            {051, 050, 054},
                                            {054, 048, 051},
                                            {000, 124, 130},
                                            {000, 100, 105},
                                            {000, 071, 075},
                                            {033, 042, 045},
                                            {048, 021, 023},
                                            {051, 006, 000},
                                            {110, 239, 255},
                                            {112, 239, 255},
                                            {114, 238, 255},
                                            {115, 238, 255},
                                            {115, 237, 255},
                                            {115, 237, 255},
                                            {000, 208, 223},
                                            {041, 202, 217},
                                            {071, 196, 211},
                                            {084, 193, 207},
                                            {089, 191, 205},
                                            {090, 191, 205},
                                            {000, 172, 183},
                                            {000, 161, 172},
                                            {031, 151, 163},
                                            {057, 146, 157},
                                            {066, 144, 154},
                                            {068, 143, 154},
                                            {000, 146, 154},
                                            {000, 130, 138},
                                            {000, 114, 122},
                                            {021, 101, 109},
                                            {042, 096, 104},
                                            {045, 095, 102},
                                            {000, 131, 137},
                                            {000, 111, 116},
                                            {000, 089, 094},
                                            {000, 067, 071},
                                            {010, 050, 054},
                                            {023, 048, 051},
                                            {000, 127, 133},
                                            {000, 106, 110},
                                            {000, 081, 085},
                                            {000, 055, 057},
                                            {000, 028, 029},
                                            {000, 000, 000}};
    #endregion
    }
}
