using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TesseractOCR;
using TesseractOCR.Enums;

namespace CyberCopy
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            var hook = new KeyboardHook();
            // register the event that is fired after the key press.
            hook.KeyPressed += Hook_KeyPressed;
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(CyberCopy.ModifierKeys.Control | CyberCopy.ModifierKeys.Alt, Keys.Z);
            HideClock();
            notifyIcon1.ShowBalloonTip(3000);
        }
        public static string GetText(Image imgSource)
        {
            try
            {
                using (var img = TesseractOCR.Pix.Image.LoadFromMemory(ImageToByteArray(imgSource)))
                {

                    //English
                    var englishResult="";
                    var englishConfidence=0f;
                    if (Program.English)
                    {
                        using (var engine = new Engine(Path.Combine(Application.StartupPath, @"tessdata"), Language.English, engineMode: EngineMode.Default))
                        {
                            using (var page = engine.Process(img))
                            {
                                Console.WriteLine(@"Mean confidence: {0}", page.MeanConfidence);
                                englishConfidence = page.MeanConfidence;
                                Console.WriteLine(@"Text: {0}", page.Text);

                                englishResult = page.Text;
                            }
                        }
                    }

                    //Arabic
                    var arabicResult="";
                    var arabicConfidence=0f;
                    if (Program.Arabic)
                    {
                        using (var engine = new Engine(Path.Combine(Application.StartupPath, @"tessdata"), Language.Arabic, engineMode: EngineMode.Default))
                        {
                            using (var page = engine.Process(img))
                            {
                                Console.WriteLine(@"Mean confidence: {0}", page.MeanConfidence);
                                Console.WriteLine(@"Text: {0}", page.Text);

                                arabicConfidence = page.MeanConfidence;
                                arabicResult = page.Text;
                            }
                        }
                    }

                    return arabicConfidence > englishConfidence ? arabicResult : englishResult;
                }

            }
            catch
            {
                // ignored
            }

            return string.Empty;
        }
        public static byte[] ImageToByteArray(Image imageIn)
        {
            var imageConverter = new ImageConverter();
            var xByte = (byte[])imageConverter.ConvertTo(imageIn, typeof(byte[]));
            return xByte;
        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            var capForm = new FrmCapture();
            if (DialogResult.OK != capForm.ShowDialog()) return;
            picCapture.Image = capForm.CapImage;
            if(Program.BringMainForm)
                mnuRestore.PerformClick();
            txtResult.Text = "";
            var text = GetText(capForm.CapImage as Bitmap);
            if (string.IsNullOrEmpty(text))
            {
                if(Program.BeepOnFailure)
                    Console.Beep();
                return;
            }
            txtResult.Text = text;
            if(Program.AutoCopy)
                Clipboard.SetText(text);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void HideClock()
        {
            Visible = false;

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            Hide();
        }

        private void MnuRestore_Click(object sender, EventArgs e)
        {
            Show();

            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Visible = true;
            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=true;
            
            HideClock();
            
        }

        private void MnuSave_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {

                Filter = @"text files (*.txt)|*.txt|All files (*.*)|*.*",
            };
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            using (var fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(txtResult.Text);
                }
            }
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog();
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            new FrmOptions().ShowDialog(this);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            mnuRestore.PerformClick();
        }

        private void mnuSnap_Click(object sender, EventArgs e)
        {
            Hook_KeyPressed(sender, null);
        }
    }
}
