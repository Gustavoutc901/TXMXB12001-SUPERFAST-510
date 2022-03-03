using System;
using System.Collections.Generic;
using System.Text;

namespace TXMXB12001_SUPERFAST_510.Helpers
{
    public class AppConfigurationObject
    {
        public string connectionStringSqlServer { get; set; }
        public string rutaArchivo { get; set; }
        public string RutaWSBalance { get; set; }
        public string UserWS { get; set; }
        public string passwordWS { get; set; }
        public string dspWS { get; set; }
        public string usuarioDebit { get; set; }
        public string serverUrl { get; set; }
        public string CorreProceso { get; set; }
        public string ftp { get; set; }
        public string FtpUser { get; set; }
        public string FtpPassword { get; set; }

    }
}
