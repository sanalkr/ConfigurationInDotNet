using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Console
{
    public class AppSettings
    {
        public string ApiUrl { get; set; }
        public int TimeoutInSeconds { get; set; }
        public EmailConfig EmailConfig { get; set; }
        public IpAddress[] IpAddress { get; set; }
    }
    public class IpAddress
    {
        public string Ip { get; set; }
        public bool Status { get; set; }
    }

    public class EmailConfig
    {
        public string Hostname { get; set; }
        public string From { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
