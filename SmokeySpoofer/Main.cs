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
using System.Security.Principal;
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
        private static Random rnd = new Random();
        static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[rnd.Next(chars.Length)]);
            }
            return sb.ToString();
        }
        public Main()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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

        private void button1_Click(object sender, EventArgs e) // Clean Traces
        {
            try
            {
                console.Clear();
                console.AppendText("Scanning Local System.. Please Wait!");
                // Blizzard/Battle.net
                // REDACTED
                    // GTAV/FiveM
                    // REDACTED
                    // (EAC) EasyAntiCheat
                    // REDACTED
                    // Fortnite
                    // REDACTED
                }
                Process process = Process.Start(tempFilename);
                process.WaitForExit();
                File.Delete(tempFilename);
                console.AppendText("\nAll Traces Have Been Deleted If Any Were Found!");
            }
            catch 
            {
                console.Clear();
                console.AppendText("Clean Traces Failed.. Please Try Again and or Run as Admin!");
            }
        }

        private void button3_Click(object sender, EventArgs e) // List HWIDs
        {
            try
            {
                console.Clear();
                console.AppendText("Scanning Local System.. Please Wait!\n");
                // Windows Profile GUID/HWID
                // REDACTED
                // Windows PC/Machine GUID/HWID
                // REDACTED
                // Windows PC/Machine ID/HWID
                // REDACTED
                // Windows Product ID/HWID
                // REDACTED
                // Windows Update GUID/HWID
                // REDACTED
                // Windows PC/Machine Hardware IDs
                // REDACTED
                // TODO: Add Hard Drive/SSD HWIDs
                console.AppendText("\nAll HWIDs that have been Found have been Listed!");
            }
            catch 
            {
                console.Clear();
                console.AppendText("Listing HWIDs Failed.. Please Try Again and or Run as Admin!");
            }
        }

        private void button4_Click(object sender, EventArgs e) // Spoof HWIDs
        {
            try
            {
                console.Clear();
                console.AppendText("Scanning Local System.. Please Wait!\n");
                // Windows Profile GUID/HWID
                // REDACTED
                // Windows PC/Machine GUID/HWID
// REDACTED
                // Windows PC/Machine ID/HWID
// REDACTED
                // Windows Product ID/HWID
// REDACTED
                // Windows Update GUID/HWID
// REDACTED
                // Windows PC/Machine Hardware IDs
                // REDACTED          
                // List all the Hardware IDs/HWIDs
// REDACTED
                // Spoof the IDs/HWIDs we Found
// REDACTED
                // ReList all the Hardware IDs/HWIDs that are now Spoofed!
// REDACTED
                console.AppendText("\nAll HWIDs that have been Found have been Spoofed!");
            }
            catch
            {
                console.Clear();
                console.AppendText("Spoof HWIDs Failed.. Please Try Again and or Run as Admin!");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Proxy IP
        {
            try
            {
                console.Clear();
                console.AppendText("Coming Soon!");

            }
            catch
            {
                console.Clear();
                console.AppendText("Proxy IP Failed.. Please Try Again and or Run as Admin!");
            }
        }
    }
}
