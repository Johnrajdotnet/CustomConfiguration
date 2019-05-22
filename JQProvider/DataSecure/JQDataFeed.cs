using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQProvider.DataSecure
{
    public class JQDataFeed
    {
        private static List<string> ipAddress = new List<string>();
        protected JQDataFeed() {
        }
        public static string GetFeed() {

            ipAddress.Add("INDT4016:172.18.49.9");
            ipAddress.Add("INBLRRWEB01:172.16.4.17");
            ipAddress.Add("INBLRRDEV01:172.16.4.27");

            ipAddress.Add("INDT2233:172.18.50.106");
            ipAddress.Add("BLRDT0384:172.18.50.220");
            ipAddress.Add("INDT2245:172.18.50.197");
            ipAddress.Add("INDT2158:172.18.50.27");
            ipAddress.Add("INDT2233:172.18.50.106");
            ipAddress.Add("INDT2220:172.18.50.145");
            ipAddress.Add("INDT4016:172.18.49.9");

            ipAddress.Add("BLRDT0729:172.18.50.217");
            ipAddress.Add("BLRDT0755:172.18.50.141");
            ipAddress.Add("BLRDT0774:172.18.50.219");
            ipAddress.Add("BLRDT0746:172.18.50.35");
            ipAddress.Add("BLRDT0733:172.18.50.215");
            return string.Join(",",ipAddress);
        }
    }
}
