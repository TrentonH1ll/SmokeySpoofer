using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmokeySpoofer
{
    public partial class Main : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        private void DeleteDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    console.AppendText($"\nFound & Deleted -> {path}");
                }
            } catch { }
        }
        private void DeleteRegistryKey(string keyPath)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, true))
                {
                    if (key != null)
                    {
                        foreach (string subKeyName in key.GetSubKeyNames())
                        {
                            key.DeleteSubKeyTree(subKeyName);
                            console.AppendText($"\nFound & Deleted -> {subKeyName}");
                        }
                        Registry.LocalMachine.DeleteSubKey(keyPath, false);
                        console.AppendText($"\nFound & Deleted -> {keyPath}");
                    }
                }
            } catch { }
        }
        public Main()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Mini Spoof
        {
            try
            {
                console.Clear();
                console.AppendText("Scanning Local System.. Please Wait!");
                // Blizzard/Battle.net
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Blizzard Entertainment"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Battle.net"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Battle.net"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Blizzard Entertainment"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\data_0.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\data_1.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\data_2.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\data_3.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\f_000001.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\index.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\index"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\data_0"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\data_1"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\data_2"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\data_3"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\f_000001"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\GPUCache\\index"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\index.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\data_0.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\data_1.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\data_2.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\data_3.dcache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\data_0"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\data_1"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\data_2"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\BrowserCache\\Cache\\data_3"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\Cache"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\Logs"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\WidevineCdm"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Battle.net\\CachedData"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Blizzard Entertainment"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Roaming\\Battle.net"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Battle.net"));
                DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Blizzard Entertainment"));
                // Easy Anti Cheat (EAC) // DeleteRegisteryKey might not be working..
                DeleteRegistryKey("SOFTWARE\\WOW6432Node\\EasyAntiCheat");
                DeleteRegistryKey("SYSTEM\\ControlSet001\\Services\\EasyAntiCheat");
                DeleteRegistryKey("SYSTEM\\ControlSet001\\Services\\EasyAntiCheat\\Security");
                DeleteRegistryKey("SOFTWARE\\WOW6432Node\\EasyAntiCheat");
                DeleteRegistryKey("SYSTEM\\ControlSet001\\Services\\EasyAntiCheat");
                DeleteRegistryKey("SOFTWARE\\WOW6432Node\\EasyAntiCheat");
                DeleteRegistryKey("SYSTEM\\ControlSet001\\Services\\EasyAntiCheat_EOS");
                // FiveM
                string tempFilename = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
                using (StreamWriter writer = new StreamWriter(tempFilename))
                {
                    writer.WriteLine(@"echo off");
                    writer.WriteLine("cls");
                    writer.WriteLine("taskkill /f /im Steam.exe /t");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"set hostspath=%windir%\System32\drivers\etc\hosts");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSLicensing\HardwareID / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSLicensing\Store / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CURRENT_USER\Software\WinRAR\ArcHistory / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\bam\State\UserSettings\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / va / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETEH KEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FeatureUsage\ShowJumpView / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETEH KEY_CURRENT_USER\Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CURRENT_USER\Software\WinRAR\ArcHistory / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FeatureUsage\AppSwitched / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CLASSES_ROOT\Local Settings\Software\Microsoft\Windows\Shell\MuiCache / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FeatureUsage\ShowJumpView / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\bam\State\UserSettings\S - 1 - 5 - 21 - 332004695 - 2829936588 - 140372829 - 1002 / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CLASSES_ROOT\Local Settings\Software\Microsoft\Windows\Shell\MuiCache / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CURRENT_USER\Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FeatureUsage\AppSwitched / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\bam\State\UserSettings\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / f");
                    writer.WriteLine("cls");
                    writer.WriteLine(@"REG DELETE HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FeatureUsage\AppSwitched / f");
                    writer.WriteLine("cls");
                }
                Process process = Process.Start(tempFilename);
                process.WaitForExit();
                File.Delete(tempFilename);
                console.AppendText("\nAll Traces Have Been Deleted If Any Were Found!");
            }
            catch 
            {
                console.Clear();
                console.AppendText("Mini Spoof Failed.. Please Try Again and or Run as Admin!");
            }
        }

        private void button3_Click(object sender, EventArgs e) // List HWIDs
        {
            try
            {
                console.Clear();
                console.AppendText("Scanning Local System.. Please Wait!");
                
            }
            catch 
            {
                console.Clear();
                console.AppendText("Listing HWIDs Failed.. Please Try Again and or Run as Admin!");
            }
        }
    }
}
