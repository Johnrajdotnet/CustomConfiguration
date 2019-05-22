using QDALSecure;
using JQProvider.DataAcess.AppCore.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CustomConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            QDataSecure qDataSecure = new QDataSecure();
            //Console.Write(Dns.GetHostAddresses(Environment.MachineName)[0].ToString());
            //Console.WriteLine(Environment.MachineName + ":" + GetIPAddress());
            qDataSecure.GenerateSecureData();
            AccountManagerDAL accountManagerDAL = new AccountManagerDAL();

           //qDataSecure.ReadSecureData();
           // FindDrive();
           Console.ReadKey();

            Console.WriteLine(Environment.MachineName + ":" + Dns.GetHostAddresses(Environment.MachineName)[0].ToString());
            return;
            string title = BlogSettings.Settings.Title;
            Console.Write(title);
        }

        public static string GetIPAddress()
        {
            string ipAddress = null;

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530); //Google public DNS and port
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                ipAddress = endPoint.Address.ToString();
            }

            return ipAddress;
        }
        private static void FindDrive() {

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                }
            }
        }
    }
}
