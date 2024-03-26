using System;
using Microsoft.Win32;

namespace CyberCopy
{
    internal class StartupHelper
    {
        private const string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string AppKeyName = "CyberCopy"; // Replace with your application's name

        public static bool AddToStartup()
        {
            try
            {
                var assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                using (var key = Registry.CurrentUser.OpenSubKey(RegistryPath, true))
                {
                    if (key == null)//create
                    {
                        // Create the key if it doesn't exist
                        var key1 = Registry.CurrentUser.CreateSubKey(RegistryPath);
                        key1?.SetValue(AppKeyName, assemblyLocation);
                    }
                    else
                    {
                        key.SetValue(AppKeyName, assemblyLocation);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Handle potential exceptions (e.g., insufficient permissions)
                Console.WriteLine($@"Error adding application to startup: {ex.Message}");
                return false;
            }
        }

        public static bool RemoveFromStartup()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath, true))
                {
                    if (key != null)
                    {
                        key.DeleteValue(AppKeyName, false); // Don't throw exception if missing
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle potential exceptions
                Console.WriteLine($@"Error removing application from startup: {ex.Message}");
                return false;
            }

            return false; // Not removed if key didn't exist
        }
    }
}
