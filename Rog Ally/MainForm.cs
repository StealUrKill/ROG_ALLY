using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Rog_Ally
{
    public partial class MainForm : Form
    {
        readonly string psexecPath = Path.Combine(Path.GetTempPath(), "PsExec.exe");

        public MainForm()
        {
            InitializeComponent();

            this.FormClosing += MainForm_FormClosing;

            if (!File.Exists(psexecPath))
            {
                if (MessageBox.Show("PsExec.exe is required to perform the operation. Would you like to extract it to the temp folder?", "PsExec.exe Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Rog_Ally.PsExec.exe"))
                    {
                        if (resourceStream != null)
                        {
                            byte[] buffer = new byte[resourceStream.Length];
                            resourceStream.Read(buffer, 0, buffer.Length);
                            File.WriteAllBytes(psexecPath, buffer);
                        }
                        else
                        {
                            MessageBox.Show("Failed to extract PsExec.exe from embedded resource.", "Error");
                        }
                    }
                }
            }
        }


        private void BtnModifyRegistry_Click(object sender, EventArgs e)
        {
            string registryKey = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerSettings\54533251-82be-4824-96c1-47b60b740d00\be337238-0d82-4146-a960-4f3749d470c7";
            string valueName = "Attributes";
            int valueData = 2;

            try
            {
                Registry.SetValue(registryKey, valueName, valueData, RegistryValueKind.DWord);
                MessageBox.Show("Registry value modified successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modifying registry value: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModifyRegistrySilentDisabled_Click(object sender, EventArgs e)
        {
            //SETTING THIS AS A SYSTEM WIDE VARIABLE
            //string psexecPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PsExec.exe");
            if (!File.Exists(psexecPath))
            {
                if (MessageBox.Show("PsExec.exe is required to perform the operation. Would you like to extract it to the temp folder?", "PsExec.exe Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Rog_Ally.PsExec.exe"))
                    {
                        if (resourceStream != null)
                        {
                            byte[] buffer = new byte[resourceStream.Length];
                            resourceStream.Read(buffer, 0, buffer.Length);
                            File.WriteAllBytes(psexecPath, buffer);
                        }
                        else
                        {
                            MessageBox.Show("Failed to extract PsExec.exe from embedded resource.", "Error");
                        }
                    }
                }
            }
            string registryKeyPath1 = @"HKEY_LOCAL_MACHINE\System\ControlSet001\Control\Power\User\PowerSchemes\64a64f24-65b9-4b56-befd-5ec1eaced9b3\54533251-82be-4824-96c1-47b60b740d00\be337238-0d82-4146-a960-4f3749d470c7";
            string registryKeyPath2 = @"HKEY_LOCAL_MACHINE\System\ControlSet001\Control\Power\User\PowerSchemes\64a64f24-65b9-4b56-befd-5ec1eaced9b3\0012ee47-9041-4b5d-9b77-535fba8b1442\6738e2c4-e8a5-4a42-b16a-e040e769756e";
            string valueName = "DCSettingIndex";
            int valueData1 = 0;
            int valueData2 = 60;

            string command1 = $"\"\"{psexecPath}\" -s -i /accepteula cmd /c \"reg add {registryKeyPath1} /v {valueName} /t REG_DWORD /d {valueData1} /f\"\"";
            string command2 = $"\"\"{psexecPath}\" -s -i /accepteula cmd /c \"reg add {registryKeyPath2} /v {valueName} /t REG_DWORD /d {valueData2} /f\"\"";

            ProcessStartInfo startInfo1 = new ProcessStartInfo("cmd.exe", "/c " + command1);
            startInfo1.UseShellExecute = false;
            startInfo1.CreateNoWindow = true;

            ProcessStartInfo startInfo2 = new ProcessStartInfo("cmd.exe", "/c " + command2);
            startInfo2.UseShellExecute = false;
            startInfo2.CreateNoWindow = true;

            using (Process process1 = new Process())
            {
                process1.StartInfo = startInfo1;
                process1.Start();
                process1.WaitForExit();
                int exitCode1 = process1.ExitCode;

                using (Process process2 = new Process())
                {
                    process2.StartInfo = startInfo2;
                    process2.Start();
                    process2.WaitForExit();
                    int exitCode2 = process2.ExitCode;

                    if (exitCode1 == 0 && exitCode2 == 0)
                    {
                        MessageBox.Show("Silent Disabled completed successfully", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Silent Disabled failed with exit code: " + (exitCode1 != 0 ? "1" : "2"), "Failure");
                    }
                }
            }
        }

        private void BtnModifyRegistrySilentAgressive_Click(object sender, EventArgs e)
        {
            if (!File.Exists(psexecPath))
            {
                if (MessageBox.Show("PsExec.exe is required to perform the operation. Would you like to extract it to the temp folder?", "PsExec.exe Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Rog_Ally.PsExec.exe"))
                    {
                        if (resourceStream != null)
                        {
                            byte[] buffer = new byte[resourceStream.Length];
                            resourceStream.Read(buffer, 0, buffer.Length);
                            File.WriteAllBytes(psexecPath, buffer);
                        }
                        else
                        {
                            MessageBox.Show("Failed to extract PsExec.exe from embedded resource.", "Error");
                        }
                    }
                }
            }
            string registryKeyPath1 = @"HKEY_LOCAL_MACHINE\System\ControlSet001\Control\Power\User\PowerSchemes\64a64f24-65b9-4b56-befd-5ec1eaced9b3\54533251-82be-4824-96c1-47b60b740d00\be337238-0d82-4146-a960-4f3749d470c7";
            string registryKeyPath2 = @"HKEY_LOCAL_MACHINE\System\ControlSet001\Control\Power\User\PowerSchemes\64a64f24-65b9-4b56-befd-5ec1eaced9b3\0012ee47-9041-4b5d-9b77-535fba8b1442\6738e2c4-e8a5-4a42-b16a-e040e769756e";
            string valueName = "DCSettingIndex";
            int valueData1 = 2;
            int valueData2 = 60;

            string command1 = $"\"\"{psexecPath}\" -s -i /accepteula cmd /c \"reg add {registryKeyPath1} /v {valueName} /t REG_DWORD /d {valueData1} /f\"\"";
            string command2 = $"\"\"{psexecPath}\" -s -i /accepteula cmd /c \"reg add {registryKeyPath2} /v {valueName} /t REG_DWORD /d {valueData2} /f\"\"";

            ProcessStartInfo startInfo1 = new ProcessStartInfo("cmd.exe", "/c " + command1);
            startInfo1.UseShellExecute = false;
            startInfo1.CreateNoWindow = true;

            ProcessStartInfo startInfo2 = new ProcessStartInfo("cmd.exe", "/c " + command2);
            startInfo2.UseShellExecute = false;
            startInfo2.CreateNoWindow = true;

            using (Process process1 = new Process())
            {
                process1.StartInfo = startInfo1;
                process1.Start();
                process1.WaitForExit();
                int exitCode1 = process1.ExitCode;

                using (Process process2 = new Process())
                {
                    process2.StartInfo = startInfo2;
                    process2.Start();
                    process2.WaitForExit();
                    int exitCode2 = process2.ExitCode;

                    if (exitCode1 == 0 && exitCode2 == 0)
                    {
                        MessageBox.Show("Silent Agressive completed successfully", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Silent Agressive failed with exit code: " + (exitCode1 != 0 ? "1" : "2"), "Failure");
                    }
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(psexecPath))
            {
                try
                {
                    File.Delete(psexecPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting PsExec.exe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
