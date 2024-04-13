using System;
using System.Management;

namespace usb
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            watcher.EventArrived += USBInserted;

            watcher.Query = query;
            watcher.Start();

            Console.WriteLine("enter your USB");
            Console.ReadKey();
 
            watcher.Stop();
        }

        static void USBInserted(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("ok");
            string programPath = "mspaint.exe"; 
            System.Diagnostics.Process.Start(programPath);
        }

        static string FindPaintShortcut()
        {
            string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            string[] paintShortcuts = Directory.GetFiles(startMenuPath, "Paint.lnk", SearchOption.AllDirectories);
            if (paintShortcuts.Length > 0)
            {
                return paintShortcuts[0];
            }

            return null;
        }
    }
}