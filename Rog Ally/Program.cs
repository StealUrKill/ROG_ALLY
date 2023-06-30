using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rog_Ally
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "AddRegistryKey")
            {
                if (args.Length >= 4)
                {
                    string registryKeyPath = args[1];
                    string valueName = args[2];
                    int valueData = 0;
                    int.TryParse(args[3], out valueData);

                    AddRegistryKeyAsSystem(registryKeyPath, valueName, valueData);
                }

                return;
            }

            Application.Run(new MainForm());
        }

        private static void AddRegistryKeyAsSystem(string registryKeyPath, string valueName, int valueData)
        {
            // Create or open the registry key
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKeyPath, true))
            {
                if (key == null)
                {
                    // Key doesn't exist, create it
                    using (RegistryKey newKey = Registry.LocalMachine.CreateSubKey(registryKeyPath))
                    {
                        // Set the value data
                        newKey.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    }
                }
                else
                {
                    // Key already exists, update the value data
                    key.SetValue(valueName, valueData, RegistryValueKind.DWord);
                }
            }
        }

    }
}
