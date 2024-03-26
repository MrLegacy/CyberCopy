using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CyberCopy
{
    public partial class FrmCapture : Form
    {

        private static class Win32Native
        {
            public const int DesktopVertres = 0x75;
            public const int DesktopHorzres = 0x76;

            [DllImport("gdi32.dll")]
            public static extern int GetDeviceCaps(IntPtr hDc, int index);
        }

        public FrmCapture()
        {
            InitializeComponent();
            _selectPen = new Pen(Color.Red, 1);

            int width, height;
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var hDc = g.GetHdc();
                width = Win32Native.GetDeviceCaps(hDc, Win32Native.DesktopHorzres);
                height = Win32Native.GetDeviceCaps(hDc, Win32Native.DesktopVertres);
                g.ReleaseHdc(hDc);
            }


            //Create the Bitmap
            using (var printScreen = new Bitmap(width, height))//Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (var graphics = Graphics.FromImage(printScreen))
                {
                    graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);


                    //Create a temporal memory stream for the image
                    using (var s = new MemoryStream())
                    {
                        //save graphic variable into memory
                        printScreen.Save(s, ImageFormat.Bmp);
                        pictureBox1.Size = new Size(Width, Height);
                        //set the picture box with temporary stream
                        pictureBox1.Image = Image.FromStream(s);
                    }

                }
            }

        
            
        }
        //These variables control the mouse position
        private int _selectX;
        private int _selectY;
        private int _selectWidth;
        private int _selectHeight;
        private readonly Pen _selectPen;

        //This variable control when you start the right click
        private bool _start;
        private void Form2_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //validate if there is an image
            if (pictureBox1.Image == null)
                return;
            //validate if right-click was trigger
            if(e.Button != MouseButtons.Left)
                return;
            if (!_start) return;
            //refresh picture box
            pictureBox1.Refresh();
            //set corner square to mouse coordinates
            _selectWidth = e.X - _selectX;
            _selectHeight = e.Y - _selectY;
            //draw dotted rectangle
            pictureBox1.CreateGraphics().DrawRectangle(_selectPen, _selectX, _selectY, _selectWidth, _selectHeight);


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //validate when user right-click
            if (!_start)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //starts coordinates for rectangle
                    _selectX = e.X;
                    _selectY = e.Y;
                    
                    _selectPen.DashStyle = DashStyle.DashDotDot;
                }
                //refresh picture box
                pictureBox1.Refresh();
                //start control variable for draw rectangle
                _start = true;
            }
            else
            {
                //validate if there is image
                if (pictureBox1.Image == null)
                    return;
                //same functionality when mouse is over
                if (e.Button == MouseButtons.Left)
                {
                    pictureBox1.Refresh();
                    _selectWidth = e.X - _selectX;
                    _selectHeight = e.Y - _selectY;
                    pictureBox1.CreateGraphics().DrawRectangle(_selectPen, _selectX, _selectY, _selectWidth, _selectHeight);
                }
                _start = false;
                //function save image to clipboard
                SaveImage();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SaveImage();
            }
        }

        public Image CapImage { set; get; }

        private void SaveImage()
        {
            //validate if something selected
            if (_selectWidth > 0)
            {
                var rect = new Rectangle(_selectX, _selectY, _selectWidth, _selectHeight);
                //create bitmap with original dimensions
                var originalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                //create bitmap with selected dimensions
                var img = new Bitmap(_selectWidth, _selectHeight);
                //create graphic variable
                var g = Graphics.FromImage(img);
                //set graphic attributes
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(originalImage, 0, 0, rect, GraphicsUnit.Pixel);
                //insert image stream into clipboard
                //Clipboard.SetImage(img);
                CapImage = img;
                DialogResult = DialogResult.OK;
            }
            //End application
            Close();
            //Application.Exit();
        }

        private void FrmCapture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmCapture_Leave(object sender, EventArgs e)
        {
            Close();
        }

    }
}
