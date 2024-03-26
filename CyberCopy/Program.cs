using System;
using System.Windows.Forms;

namespace CyberCopy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Utils.LoadSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        public static bool StartAtStartup { get; set; }
        public static bool AutoCopy { get; set; }
        public static bool BeepOnFailure { get; set; }
        public static bool BringMainForm { get; set; }
        public static bool English { get; set; }
        public static bool Arabic { get; set; }
    }
}
