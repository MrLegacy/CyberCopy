using System;
using System.Windows.Forms;

namespace CyberCopy
{
    public partial class FrmOptions : Form
    {
        public FrmOptions()
        {
            InitializeComponent();
            cboStartOnStartup.Checked = Program.StartAtStartup;
            cboClipboard.Checked = Program.AutoCopy;
            cboBeep.Checked = Program.BeepOnFailure;
            cboMainForm.Checked = Program.BringMainForm;
            cboEnglish.Checked = Program.English;
            cboArabic.Checked = Program.Arabic;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Startup
            Program.StartAtStartup = cboStartOnStartup.Checked;
            Utils.SetKey("Startup", cboStartOnStartup.Checked.ToString());
            if (cboStartOnStartup.Checked)
                StartupHelper.AddToStartup();
            else
                StartupHelper.RemoveFromStartup();
            //AutoCopy
            Program.AutoCopy = cboClipboard.Checked;
            Utils.SetKey("AutoCopy", cboStartOnStartup.Checked.ToString());
            //Beep
            Program.BeepOnFailure = cboBeep.Checked;
            Utils.SetKey("Beep", cboStartOnStartup.Checked.ToString());
            //Main Form
            Program.BringMainForm = cboMainForm.Checked;
            Utils.SetKey("BringMainForm", cboMainForm.Checked.ToString());
            //English
            Program.English = cboEnglish.Checked;
            Utils.SetKey("English", cboEnglish.Checked.ToString());
            //Arabic
            Program.Arabic = cboArabic.Checked;
            Utils.SetKey("Arabic", cboArabic.Checked.ToString());
            Close();
        }

        private void btnRevertToDefault_Click(object sender, EventArgs e)
        {
            //startup
            cboStartOnStartup.Checked = false;
            Utils.SetKey("Startup",false.ToString());
            StartupHelper.RemoveFromStartup();
            Program.StartAtStartup = false;
            //AutoCopy
            cboClipboard.Checked = true;
            Utils.SetKey("AutoCopy", true.ToString());
            Program.AutoCopy = true;
            //beep
            cboBeep.Checked = true;
            Utils.SetKey("Beep",true.ToString());
            Program.BeepOnFailure=true;
            //Main Form
            cboMainForm.Checked = false;
            Utils.SetKey("BringMainForm", false.ToString());
            Program.BringMainForm=false;
            //English
            cboEnglish.Checked = true;
            Utils.SetKey("English", false.ToString());
            Program.English = true;
            //Arabic
            cboArabic.Checked = false;
            Utils.SetKey("Arabic", false.ToString());
            Program.Arabic = false;
        }

    }
}
