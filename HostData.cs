using System.Net;

namespace IpScanner
{
    public class HostData
    {
        public string hostName { get; set; }
        public string ipAddress { get; set; }        
        public string[] hostNameArray { get; set; }

        public HostData(IPHostEntry host, string ipaddress)
        {
            hostNameArray = host.HostName.ToString().Split('.');
            this.hostName = hostNameArray[0];
            this.ipAddress = ipAddress;
        }
    }
}
