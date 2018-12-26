using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JQProvider.DataSecure
{
   public class JQSecureData
    {
        private string path = ConfigurationManager.AppSettings["AuthorizePath"].ToString() + "QDataSecure.dat";
        public bool ReadSecureData()
        {
            string machineName = GetMachineProperty();
            string cipherDataValue = string.Empty;
            string plainDataValue = string.Empty;
            List<string> authorizeDataList = new List<string>();
            bool isAllow = false;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((cipherDataValue = sr.ReadLine()) != null)
                {
                    plainDataValue = Decrypt(cipherDataValue);
                }
            }
            authorizeDataList = plainDataValue.Split(',').ToList();
            if (authorizeDataList == null && authorizeDataList.Count <= 0)
                return isAllow;
            if (authorizeDataList.Exists(x => x.ToUpper() == machineName.ToUpper()))
                isAllow = true;

            return isAllow;
        }

        private string GetMachineProperty()
        {
            return Environment.MachineName + ":" + GetIPAddress();
        }
        public string GetIPAddress()
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

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "IProtectCodeNotHack";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x4d, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x6e });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
