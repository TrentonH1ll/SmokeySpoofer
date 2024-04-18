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

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/pbEwTG4BrC");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                console.Clear();
                console.AppendText("Scanning Local System.. Please Wait!");
                // Motherboard
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject motherboard in searcher.Get())
                {
                    string serialNumber = motherboard["SerialNumber"].ToString();
                    console.AppendText($"\nMotherboard Serial Number: {serialNumber}");
                    searcher.Dispose();
                    motherboard.Dispose();
                }
                // CPU
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher("SELECT ProcessorID FROM Win32_Processor");
                ManagementObjectCollection collection = searcher2.Get();
                Console.WriteLine("CPU Serial Numbers:");
                foreach (ManagementObject obj in collection)
                {
                    string cpuSerialNumber = obj["ProcessorID"].ToString();
                    console.AppendText($"\nCPU Serial Number: {cpuSerialNumber}");
                    searcher2.Dispose();
                    collection.Dispose();
                    obj.Dispose();
                }
                // RAM
                ManagementObjectSearcher searcher3 = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                ManagementObjectCollection results = searcher3.Get();
                foreach (ManagementObject obj2 in results)
                {
                    string serialNumber = obj2["SerialNumber"].ToString();
                    console.AppendText("\nRAM Serial Number: " + serialNumber);
                    searcher3.Dispose();
                    results.Dispose();
                    obj2.Dispose();
                }
                // Hard Drives/SSDs
                ManagementObjectSearcher searcher4 = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject disk in searcher4.Get())
                {
                    string serialNumber = disk["SerialNumber"]?.ToString();
                    console.AppendText($"\nHard Drive/SSD Serial Number: {serialNumber}");
                    searcher4.Dispose();
                    disk.Dispose();
                }
                //
            }
            catch 
            {
                console.Clear();
                console.AppendText("Listing HWIDs Failed.. Please Try Again and or Run as Admin!");
            }
        }
    }
}
