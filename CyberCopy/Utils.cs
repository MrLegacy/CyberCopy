using System;
using Microsoft.Win32;

namespace CyberCopy
{
    internal class Utils
    {
        public static void LoadSettings()
        {
            //Startup
            var startupVal = GetValue("Startup");
            Program.StartAtStartup =!string.IsNullOrEmpty(startupVal) && Convert.ToBoolean(startupVal);
            //AutoCopy
            var autoCopyVal = GetValue("AutoCopy");
            Program.AutoCopy =!string.IsNullOrEmpty(autoCopyVal) && Convert.ToBoolean(autoCopyVal);
            //Beep
            var beepVal = GetValue("Beep");
            Program.BeepOnFailure = !string.IsNullOrEmpty(beepVal) && Convert.ToBoolean(beepVal);
            //BringMainForm
            var bringMainFormVal = GetValue("BringMainForm");
            Program.BringMainForm = !string.IsNullOrEmpty(bringMainFormVal) && Convert.ToBoolean(bringMainFormVal);
            //English
            var englishVal = GetValue("English");
            Program.English = !string.IsNullOrEmpty(englishVal) && Convert.ToBoolean(englishVal);

            //Arabic
            var arabicVal = GetValue("Arabic");
            Program.Arabic = !string.IsNullOrEmpty(arabicVal) && Convert.ToBoolean(arabicVal);

            if (Program.English || Program.Arabic) return;
            Program.English = true;
            SetKey("English",true.ToString());
        }


        private const string RegistryPath = @"SOFTWARE\CyberCopy"; // Replace with your desired path

        public static void SetKey(string name, string value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(RegistryPath))
            {
                key?.SetValue(name, value);
            }
        }

        public static string GetValue(string key)
        {
            try
            {
                using (var registryKey = Registry.CurrentUser.OpenSubKey(RegistryPath))
                {
                    if (registryKey == null) return string.Empty;
                    var value = registryKey.GetValue(key);
                    return value?.ToString() ?? string.Empty;
                }
            }
            catch{
                //
            }
            return string.Empty;
        }
    }
}
