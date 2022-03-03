using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TXMXB12001_SUPERFAST_510.Helpers.AppSettings
{
    public class AppSettings
    {
        public static AppConfigurationObject _aco;

        public static void Init()
        {
            _aco = new AppConfigurationObject();

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            string path = null;
            IConfigurationRoot root = null;

            /*-------------------------------------------------------------------------------------------*/

            path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");


            configurationBuilder.AddJsonFile(path, false);

            root = configurationBuilder.Build();

#if DEBUG

            _aco.connectionStringSqlServer = root.GetConnectionString("QA");

#else
                       _aco.connectionStringSqlServer = root.GetConnectionString("ConnectionQA");

#endif

            _aco.ftp = root.GetSection("Rutas").GetSection("ftp").Value;
            _aco.FtpUser = root.GetSection("Rutas").GetSection("user").Value;
            _aco.FtpPassword = root.GetSection("Rutas").GetSection("password").Value;
            _aco.CorreProceso = root.GetSection("TiempoCarga").GetSection("CorreProceso").Value;

            //_aco.rutaArchivo = root.GetSection("RutaArchivo").GetSection("ruta").Value;
            //_aco.RutaWSBalance = root.GetSection("Rutas").GetSection("RutaWSBalance").Value;
            //_aco.UserWS = root.GetSection("Rutas").GetSection("UserWS").Value;
            //_aco.passwordWS = root.GetSection("Rutas").GetSection("passwordWS").Value;
            //_aco.dspWS = root.GetSection("Rutas").GetSection("dsp").Value;
            //_aco.usuarioDebit = root.GetSection("Rutas").GetSection("usuario").Value;
            //_aco.serverUrl = root.GetSection("Rutas").GetSection("serverUrl").Value;


            /*-------------------------------------------------------------------------------------------*/
        }
        public static string ftp()
        {
            return _aco.ftp;
        }
        public static string FtpUser()
        {
            return _aco.FtpUser;
        }
        public static string FtpPassword()
        {
            return _aco.FtpPassword;
        }
        public static string ConnectionStringSqlServer()
        {
            return _aco.connectionStringSqlServer;
        }
        public static string CorreProceso()
        {
            return _aco.CorreProceso;
        }
        //public static string RutaArchivo()
        //{
        //    return _aco.rutaArchivo;
        //}
        //public static string RutaWSBalance()
        //{
        //    return _aco.RutaWSBalance;
        //}
        //public static string UserWS()
        //{
        //    return _aco.UserWS;
        //}
        //public static string passwordWS()
        //{
        //    return _aco.passwordWS;
        //}
        //public static string dspWS()
        //{
        //    return _aco.dspWS;
        //}
        //public static string usuarioDebit()
        //{
        //    return _aco.usuarioDebit;
        //}

        //public static string serverUrl()
        //{
        //    return _aco.serverUrl;
        //}
     
    }
}
