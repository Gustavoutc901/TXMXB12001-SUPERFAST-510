using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TXMXB12001_SUPERFAST_510.DataAccess.DB;
using TXMXB12001_SUPERFAST_510.DataAccess.InsertTables;

namespace TXMXB12001_SUPERFAST_510
{
    public partial class File510Process
    {
        private static bool _existError;
        private static int _lineError;
        private static int _totalLine;

        const string VALUENEWTRANSACTION = "00817";
        const string VALUELINEHEADER = "HEADER";
        const string VALUELINETRAILER = "TRAILER";
        private static Guid _detalle510;

        public static tError510Info tError510Info { get; set; }

        public bool Execute()
        {
            TXMXB12001_SUPERFAST_510.DataAccess.InsertFile dataAccess = new DataAccess.InsertFile();

            //VAMOS POR LOS ARCHIVOS
            string ruta = Helpers.AppSettings.AppSettings.ftp();
            FtpWebRequest requesWt = (FtpWebRequest)WebRequest.Create(ruta + "*");
            requesWt.Method = WebRequestMethods.Ftp.ListDirectory;
            requesWt.Credentials = new NetworkCredential(Helpers.AppSettings.AppSettings.FtpUser(), Helpers.AppSettings.AppSettings.FtpPassword());

            FtpWebResponse response = (FtpWebResponse)requesWt.GetResponse();
            StreamReader readerFile = new StreamReader(response.GetResponseStream());

            List<string> _fwiles = new List<string>();

            string line;
            while ((line = readerFile.ReadLine()) != null)
            {
                _fwiles.Add(ruta + line);

            }
            foreach (var item in _fwiles)
            {
                if (item.Contains(".scr")|| item.Contains(".Ink"))
                {
                    continue;
                }
                string[] Filed = item.Split('/');
                if (dataAccess.FileProcess(Filed[4]))
                {
                    FtpWebRequest downy = (FtpWebRequest)WebRequest.Create(item);
                    downy.Method = WebRequestMethods.Ftp.DownloadFile;
                    FtpWebResponse _response = (FtpWebResponse)downy.GetResponse();
                    Stream _responseStream = _response.GetResponseStream();
                    StreamReader file = new StreamReader(_responseStream);
                    Dictionary<string, KeyMapLayout> detailDictionary = new Dictionary<string, KeyMapLayout>();
                    Dictionary<string, KeyMapLayout> detailAttachmentDictionary = new Dictionary<string, KeyMapLayout>();
                    InitKeysLayoutDetail(detailDictionary);
                    InitKeysLayoutAttachmentDetail(detailAttachmentDictionary);
                    //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\maprado\Documents\ENROLAMIENTO\510\I0798.B0817EMI.TXS.200326");
                    //string[] lines = System.IO.File.ReadAllLines(item);


                    //AQUI GUARDAR EL HEADER Y OBTENET EL idHeader
                    Guid idHeader = Guid.NewGuid();
                    List<tHeader510> tHeader510 = new List<tHeader510>();
                    List<tDetalle510> tDetalle510s = new List<tDetalle510>();
                    List<tAnexo510> tAnexo510s = new List<tAnexo510>();
                    List<tError510> tError510s = new List<tError510>();
                    List<tError510Info> tError510Infos = new List<tError510Info>();

                    int lin = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        lin++;
                        if (line.StartsWith(VALUELINEHEADER))
                        {
                            AddHeader(idHeader, tHeader510, Filed[4]);
                            //INSERTA Header
                            using (DataTable dataTable = new DataTable() { TableName = "tHeader510" })
                            {
                                #region tHeader510
                                using (ObjectReader reader = ObjectReader.Create(tHeader510,
                                                                                "IdHeader510",
                                                                                "NameFile",
                                                                                "IdStatus",
                                                                                "DateProcessing",
                                                                                "DateProcess",
                                                                                "Status",
                                                                                "CreateDate",
                                                                                "UpdateDate",
                                                                                "CreateUser",
                                                                                "UpdateUser"))
                                #endregion tHeader510
                                {
                                    dataTable.Load(reader);
                                }
                                try
                                {
                                    dataAccess.Header510(dataTable);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            continue;
                        }
                        if (line.StartsWith(VALUELINETRAILER))
                        {
                            _totalLine = Convert.ToInt32(line.Substring(8, 8).Trim());
                            break;
                        }
                        bool isNewTDetalle510 = line.StartsWith(VALUENEWTRANSACTION);
                        MapValues(isNewTDetalle510 ? detailDictionary : detailAttachmentDictionary, line);
                        if (!(isNewTDetalle510 ?
                            AddTDetalle510(detailDictionary, tDetalle510s, idHeader) :
                            AddTAnexo510(detailAttachmentDictionary, tAnexo510s)))
                        {
                            tError510Info.IdHeader510 = idHeader;
                            tError510Info.Line = _lineError = lin + 1;
                            tError510Info.Text = line;
                            tError510Info.IdtError510Info = Guid.NewGuid();

                            tError510Infos.Add(tError510Info);
                            //SAVE tError510Info
                            using (DataTable dataTable = new DataTable() { TableName = "tError510Info" })
                            {
                                #region tError510Info
                                using (ObjectReader reader = ObjectReader.Create(tError510Infos,
                                                                                "IdtError510Info",
                                                                                "IdHeader510",
                                                                                "Field",
                                                                                "Value",
                                                                                "StartLine",
                                                                                "EndLine",
                                                                                "Line",
                                                                                "Text"))
                                #endregion tError510Info
                                {
                                    dataTable.Load(reader);
                                }
                                try
                                {
                                    dataAccess.Error510Info(dataTable);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            break;
                        }
                        else
                        {
                            _existError = false;
                        }
                    }
                    #region for
                    //for (int i = 0; i < lines.Length; i++)
                    //{
                    //    if (lines[i].StartsWith(VALUELINEHEADER))
                    //    {
                    //        continue;
                    //    }
                    //    if (lines[i].StartsWith(VALUELINETRAILER))
                    //    {
                    //        AddHeader(idHeader, tHeader510, "p1");
                    //        break;
                    //    }
                    //    bool isNewTDetalle510 = lines[i].StartsWith(VALUENEWTRANSACTION);
                    //    MapValues(isNewTDetalle510 ? detailDictionary : detailAttachmentDictionary, lines[i]);
                    //    if (!(isNewTDetalle510 ?
                    //        AddTDetalle510(detailDictionary, tDetalle510s, idHeader) :
                    //        AddTAnexo510(detailAttachmentDictionary, tAnexo510s)))
                    //    {
                    //        _lineError = i + 1;
                    //        break;
                    //    }
                    //}
                    #endregion for
                    #region original
                    //if (!_existError)
                    //{
                    //    //INSERTA Header

                    //    using (DataTable dataTable = new DataTable() { TableName = "tHeader510" })
                    //    {
                    //        #region tHeader510
                    //        using (ObjectReader reader = ObjectReader.Create(tHeader510,
                    //                                                        "IdHeader510",
                    //                                                        "NameFile",
                    //                                                        "IdStatus",
                    //                                                        "DateProcessing",
                    //                                                        "DateProcess",
                    //                                                        "Status",
                    //                                                        "CreateDate",
                    //                                                        "UpdateDate",
                    //                                                        "CreateUser",
                    //                                                        "UpdateUser"))
                    //        #endregion tHeader510
                    //        {
                    //            dataTable.Load(reader);
                    //        }
                    //        try
                    //        {
                    //            if (dataAccess.Header510(dataTable))
                    //            {
                    //                //SALVAR detalle              
                    //                using (DataTable dataTableDetalle = new DataTable() { TableName = "tDetalle510" })
                    //                {
                    //                    #region tDetalle510
                    //                    using (ObjectReader reader = ObjectReader.Create(tDetalle510s,
                    //                                                                    "IdDetalle510",
                    //                                                                    "IdHeader510",
                    //                                                                    "Bancoemisor",
                    //                                                                    "NoCuenta",
                    //                                                                    "NaturalezaContable",
                    //                                                                    "MarcaProducto",
                    //                                                                    "FechaConsumo",
                    //                                                                    "HoraConsumo",
                    //                                                                    "FechaProceso",
                    //                                                                    "TipoTransaccion",
                    //                                                                    "NumeroLiquidacion",
                    //                                                                    "ImporteOrigenTotal",
                    //                                                                    "ImporteOrigenConsumo",
                    //                                                                    "ClaveMonedaImporteOrigen",
                    //                                                                    "ImporteDestinoTotal",
                    //                                                                    "ImporteDestinoConsumo",
                    //                                                                    "ClaveMonedaDestino",
                    //                                                                    "ParidadDestino",
                    //                                                                    "ImporteLiquidacionTotal",
                    //                                                                    "ImporteLiquidacionConsumo",
                    //                                                                    "ClaveMonedaLiquidacion",
                    //                                                                    "ParidadLiquidacion",
                    //                                                                    "ImporteCuotaIntercambio",
                    //                                                                    "IvaCuotaIntercambio",
                    //                                                                    "ImporteCalculadoParaAplicacionTH",
                    //                                                                    "ImporteCalculadoAplicacionTH",
                    //                                                                    "PorcentajeComisionAplicacionTH",
                    //                                                                    "Clavecomercio",
                    //                                                                    "MccoGiroComercio",
                    //                                                                    "NombreComercio",
                    //                                                                    "DireccionComercio",
                    //                                                                    "PaisOrigenTX",
                    //                                                                    "CodigoPostal",
                    //                                                                    "PoblacionComercio",
                    //                                                                    "PorcentajeCuotaIntercambio",
                    //                                                                    "FamiliaComercio",
                    //                                                                    "RFCComercio",
                    //                                                                    "EstatusComercio",
                    //                                                                    "NumeroFuente",
                    //                                                                    "NumeroAutorizacion",
                    //                                                                    "BancoReceptor",
                    //                                                                    "ReferenciaTransaccion",
                    //                                                                    "ModoAutorizacion",
                    //                                                                    "IndicadorMedioAcceso",
                    //                                                                    "PagosDiferidos",
                    //                                                                    "PagosDiferidosParcializacion",
                    //                                                                    "PagosDiferidosTipoPlan",
                    //                                                                    "Sobretasa",
                    //                                                                    "IvaSobretasa",
                    //                                                                    "PorcentajeSobreTasa",
                    //                                                                    "PagosDiferidosIndicadorCobroA",
                    //                                                                    "FiidEmisor",
                    //                                                                    "ComercioElectroniCoidct",
                    //                                                                    "ComercioElectronicoIce",
                    //                                                                    "AuthenticationCollectorIndicator",
                    //                                                                    "ComercioElectronicoTc",
                    //                                                                    "ComercioElectronicoIta",
                    //                                                                    "ComercioElectronicoTid",
                    //                                                                    "PosentryMode",
                    //                                                                    "IndicadorCV2",
                    //                                                                    "ComercioElectronicoIcavv",
                    //                                                                    "FiidAdquiriente",
                    //                                                                    "IndicadorPagoInterbancario",
                    //                                                                    "ServiceCode",
                    //                                                                    "Status",
                    //                                                                    "CreateDate",
                    //                                                                    "UpdateDate",
                    //                                                                    "CreateUser",
                    //                                                                    "UpdateUser"))
                    //                    #endregion tDetalle510
                    //                    {
                    //                        dataTableDetalle.Load(reader);
                    //                    }
                    //                    try
                    //                    {
                    //                        if (dataAccess.Detalle510(dataTableDetalle))
                    //                        {
                    //                            //Salvar Anexos
                    //                            using (DataTable dataTableAnexo = new DataTable() { TableName = "tAnexo510" })
                    //                            {
                    //                                #region tAnexo510
                    //                                using (ObjectReader reader = ObjectReader.Create(tAnexo510s,
                    //                                                                                "IdAnexo510",
                    //                                                                                "IdDetalle510",
                    //                                                                                "NoAutorizacion",
                    //                                                                                "NoCuenta",
                    //                                                                                "TipoRegistro",
                    //                                                                                "ApplicationC",
                    //                                                                                "Cryptogram",
                    //                                                                                "IssuerAD",
                    //                                                                                "UnpredictableNumber",
                    //                                                                                "AplicationTransactionCounter",
                    //                                                                                "TerminalVerificationResult",
                    //                                                                                "TransactionDate",
                    //                                                                                "TransactionType",
                    //                                                                                "AmountAuthorized",
                    //                                                                                "TransactionCurrencyCode",
                    //                                                                                "ApplicationInterchangeProfile",
                    //                                                                                "TerminalCountryCode",
                    //                                                                                "AmountOther",
                    //                                                                                "CardholderVerificationMethod",
                    //                                                                                "TeminalCapabilities",
                    //                                                                                "TerminalType",
                    //                                                                                "InterfaceDeviceSerialNumber",
                    //                                                                                "DedicatedFileName",
                    //                                                                                "TerminalApplicationVersionNumber",
                    //                                                                                "IssuerAuthenticationData",
                    //                                                                                "Status",
                    //                                                                                "CreateDate",
                    //                                                                                "UpdateDate",
                    //                                                                                "CreateUser",
                    //                                                                                "UpdateUser"))
                    //                                #endregion tAnexo510
                    //                                {
                    //                                    dataTableAnexo.Load(reader);
                    //                                }
                    //                                try
                    //                                {
                    //                                    if (dataAccess.Anexo510(dataTableAnexo))
                    //                                    {
                    //                                        //actualiza fecha de process THEADER510
                    //                                        dataAccess.UpdateDateHeader(idHeader);
                    //                                    }

                    //                                }
                    //                                catch (Exception ex)
                    //                                {

                    //                                }

                    //                            }
                    //                        }

                    //                    }
                    //                    catch (Exception ex)
                    //                    {

                    //                    }

                    //                }

                    //            }

                    //        }
                    //        catch (Exception ex)
                    //        {

                    //        }

                    //    }
                    //    return true;
                    //}
                    #endregion original
                    if (!_existError && _totalLine == tDetalle510s.Count)
                    {
                        // traemos los cipher de las tarjetas
                        CipherData cipherData = new CipherData();
                        Dictionary<long, byte[]> listTo = cipherData.GetCardCiphered();
                        Dictionary<Guid, byte[]> listFrom = new Dictionary<Guid, byte[]>();
                        using (System.Security.Cryptography.SHA512 sHA512 = System.Security.Cryptography.SHA512.Create())
                        {
                            foreach (tDetalle510 tarjeta in tDetalle510s)
                            {
                                listFrom.Add(tarjeta.IdDetalle510, sHA512.ComputeHash(Encoding.UTF8.GetBytes(tarjeta.NoCuenta)));
                            }
                        }
                        using (Vantis.SearchHash.FindMatchs<Guid, long> findMatchs = new Vantis.SearchHash.FindMatchs<Guid, long>())
                        {
                            Dictionary<Guid, long> matchHashes = findMatchs.Search(new Vantis.SearchHash.Values<Guid, long>
                            {
                                ListFrom = listFrom,
                                ListTo = listTo
                            });
                            foreach (tDetalle510 tarjeta in tDetalle510s)
                            {
                                if (matchHashes.ContainsKey(tarjeta.IdDetalle510))
                                {
                                    tarjeta.IdCardCipher = matchHashes[tarjeta.IdDetalle510];
                                    tarjeta.NoCuenta = string.Empty;
                                }
                            }
                        }



                        //SALVAR detalle              
                        using (DataTable dataTableDetalle = new DataTable() { TableName = "tDetalle510" })
                        {
                            #region tDetalle510
                            using (ObjectReader reader = ObjectReader.Create(tDetalle510s,
                                                                            "IdDetalle510",
                                                                            "IdHeader510",
                                                                            "Bancoemisor",
                                                                            "IdCardCipher",
                                                                            "NoCuenta",
                                                                            "NaturalezaContable",
                                                                            "MarcaProducto",
                                                                            "FechaConsumo",
                                                                            "HoraConsumo",
                                                                            "FechaProceso",
                                                                            "TipoTransaccion",
                                                                            "NumeroLiquidacion",
                                                                            "ImporteOrigenTotal",
                                                                            "ImporteOrigenConsumo",
                                                                            "ClaveMonedaImporteOrigen",
                                                                            "ImporteDestinoTotal",
                                                                            "ImporteDestinoConsumo",
                                                                            "ClaveMonedaDestino",
                                                                            "ParidadDestino",
                                                                            "ImporteLiquidacionTotal",
                                                                            "ImporteLiquidacionConsumo",
                                                                            "ClaveMonedaLiquidacion",
                                                                            "ParidadLiquidacion",
                                                                            "ImporteCuotaIntercambio",
                                                                            "IvaCuotaIntercambio",
                                                                            "ImporteCalculadoParaAplicacionTH",
                                                                            "ImporteCalculadoAplicacionTH",
                                                                            "PorcentajeComisionAplicacionTH",
                                                                            "Clavecomercio",
                                                                            "MccoGiroComercio",
                                                                            "NombreComercio",
                                                                            "DireccionComercio",
                                                                            "PaisOrigenTX",
                                                                            "CodigoPostal",
                                                                            "PoblacionComercio",
                                                                            "PorcentajeCuotaIntercambio",
                                                                            "FamiliaComercio",
                                                                            "RFCComercio",
                                                                            "EstatusComercio",
                                                                            "NumeroFuente",
                                                                            "NumeroAutorizacion",
                                                                            "BancoReceptor",
                                                                            "ReferenciaTransaccion",
                                                                            "ModoAutorizacion",
                                                                            "IndicadorMedioAcceso",
                                                                            "PagosDiferidos",
                                                                            "PagosDiferidosParcializacion",
                                                                            "PagosDiferidosTipoPlan",
                                                                            "Sobretasa",
                                                                            "IvaSobretasa",
                                                                            "PorcentajeSobreTasa",
                                                                            "PagosDiferidosIndicadorCobroA",
                                                                            "FiidEmisor",
                                                                            "ComercioElectroniCoidct",
                                                                            "ComercioElectronicoIce",
                                                                            "AuthenticationCollectorIndicator",
                                                                            "ComercioElectronicoTc",
                                                                            "ComercioElectronicoIta",
                                                                            "ComercioElectronicoTid",
                                                                            "PosentryMode",
                                                                            "IndicadorCV2",
                                                                            "ComercioElectronicoIcavv",
                                                                            "FiidAdquiriente",
                                                                            "IndicadorPagoInterbancario",
                                                                            "ServiceCode",
                                                                            "Status",
                                                                            "CreateDate",
                                                                            "UpdateDate",
                                                                            "CreateUser",
                                                                            "UpdateUser",
                                                                            "DescrpEstado"))
                            #endregion tDetalle510
                            {
                                dataTableDetalle.Load(reader);
                            }
                            try
                            {

                                if (dataAccess.Detalle510(dataTableDetalle))
                                {
                                    //Salvar Anexos
                                    using (DataTable dataTableAnexo = new DataTable() { TableName = "tAnexo510" })
                                    {
                                        #region tAnexo510
                                        using (ObjectReader reader = ObjectReader.Create(tAnexo510s,
                                                                                        "IdAnexo510",
                                                                                        "IdDetalle510",
                                                                                        "NoAutorizacion",
                                                                                        "NoCuenta",
                                                                                        "TipoRegistro",
                                                                                        "ApplicationC",
                                                                                        "Cryptogram",
                                                                                        "IssuerAD",
                                                                                        "UnpredictableNumber",
                                                                                        "AplicationTransactionCounter",
                                                                                        "TerminalVerificationResult",
                                                                                        "TransactionDate",
                                                                                        "TransactionType",
                                                                                        "AmountAuthorized",
                                                                                        "TransactionCurrencyCode",
                                                                                        "ApplicationInterchangeProfile",
                                                                                        "TerminalCountryCode",
                                                                                        "AmountOther",
                                                                                        "CardholderVerificationMethod",
                                                                                        "TeminalCapabilities",
                                                                                        "TerminalType",
                                                                                        "InterfaceDeviceSerialNumber",
                                                                                        "DedicatedFileName",
                                                                                        "TerminalApplicationVersionNumber",
                                                                                        "IssuerAuthenticationData",
                                                                                        "Status",
                                                                                        "CreateDate",
                                                                                        "UpdateDate",
                                                                                        "CreateUser",
                                                                                        "UpdateUser"))
                                        #endregion tAnexo510
                                        {
                                            dataTableAnexo.Load(reader);
                                        }
                                        try
                                        {
                                            if (dataAccess.Anexo510(dataTableAnexo))
                                            {
                                                //actualiza fecha de process THEADER510
                                                dataAccess.UpdateDateHeader(idHeader);
                                                Clear();

                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                        }

                                    }
                                }

                            }
                            catch (Exception ex)
                            {

                            }

                        }
                        //return true;
                    }
                    else
                    {
                        //INSERTA TError510
                        AddError(tError510s, idHeader, _lineError);
                        using (DataTable dataTableError = new DataTable() { TableName = "tError510" })
                        {
                            #region tError510s
                            using (ObjectReader reader = ObjectReader.Create(tError510s,
                                                                            "IdError510",
                                                                            "IdHeader510",
                                                                            "Line",
                                                                            "Status",
                                                                            "CreateDate",
                                                                            "UpdateDate",
                                                                            "CreateUser",
                                                                            "UpdateUser"))
                            #endregion tError510s
                            {
                                dataTableError.Load(reader);
                            }
                            try
                            {
                                if (dataAccess.Error510(dataTableError))
                                {
                                    dataAccess.UpdateDateHeaderError(idHeader);
                                    Clear();

                                }

                            }
                            catch (Exception ex)
                            {

                            }

                        }
                    }
                    //salvar error
                }
                Clear();
            }
            return true;

        }
        private void Clear()
        {
            _existError = false;
            _lineError = 0;
            _totalLine = 0;
        }

        private static bool AddTAnexo510(Dictionary<string, KeyMapLayout> dictionary, List<tAnexo510> list)
        {
            tAnexo510 tAnexo510 = CreateIntance<tAnexo510>(dictionary, typeof(EnumLayoutAttachmentDetail));
            if (tAnexo510 !=null)
            {
                tAnexo510.IdDetalle510 = _detalle510;
                tAnexo510.IdAnexo510 = Guid.NewGuid();
                tAnexo510.Status = 1;
                tAnexo510.CreateDate = DateTime.Now;
                tAnexo510.UpdateDate = DateTime.Now;
                tAnexo510.CreateUser = 1;
                tAnexo510.UpdateUser = 1;
                list.Add(tAnexo510);

            }
            return !_existError;

        }

        private static T CreateIntance<T>(Dictionary<string, KeyMapLayout> dictionary, Type enumCustom) where T : class
        {
            T instance = (T)Activator.CreateInstance(typeof(T), null);
            foreach (Enum item in Enum.GetValues(enumCustom))
            {
                File510MapValidationAttribute file510MapValidationAttribute = EnumExtensions.GetAttribute<File510MapValidationAttribute>(item);
                switch (file510MapValidationAttribute.NameValidation)
                {
                    case "ValidationLong":
                        if (file510MapValidationAttribute.IsRequired)
                        {
                            instance.GetType().GetProperty(item.ToString()).SetValue(instance, (long)ValidationLong(dictionary[item.ToString()].Value, file510MapValidationAttribute.IsRequired));
                            if (_existError)
                            {
                                MapError510Info(dictionary, item);
                                return null;
                            }
                        }
                        else
                        {
                            instance.GetType().GetProperty(item.ToString()).SetValue(instance, ValidationLong(dictionary[item.ToString()].Value, file510MapValidationAttribute.IsRequired));
                            if (_existError)
                            {
                                MapError510Info(dictionary, item);
                                return null;
                            }
                        }
                        break;
                    case "ValidationTime":
                        if (file510MapValidationAttribute.IsRequired)
                        {
                            instance.GetType().GetProperty(item.ToString()).SetValue(instance, (TimeSpan)ValidationTime(dictionary[item.ToString()].Value, file510MapValidationAttribute.IsRequired));
                            if (_existError)
                            {
                                MapError510Info(dictionary, item);
                                return null;
                            }
                        }
                        else
                        {
                            instance.GetType().GetProperty(item.ToString()).SetValue(instance, ValidationTime(dictionary[item.ToString()].Value, file510MapValidationAttribute.IsRequired));
                            if (_existError)
                            {
                                MapError510Info(dictionary, item);
                                return null;
                            }
                        }
                        break;
                    case "ValidationDecimal":
                        if (file510MapValidationAttribute.IsRequired)
                        {
                            instance.GetType().GetProperty(item.ToString()).SetValue(instance, (decimal)ValidationDecimal(dictionary[item.ToString()].Value, file510MapValidationAttribute.Integers, file510MapValidationAttribute.Decimals, file510MapValidationAttribute.IsRequired));
                            if (_existError)
                            {
                                MapError510Info(dictionary, item);
                                return null;
                            }
                        }
                        else
                        {
                            instance.GetType().GetProperty(item.ToString()).SetValue(instance, ValidationDecimal(dictionary[item.ToString()].Value, file510MapValidationAttribute.Integers, file510MapValidationAttribute.Decimals, file510MapValidationAttribute.IsRequired));
                            if (_existError)
                            {
                                MapError510Info(dictionary, item);
                                return null;
                            }
                        }
                        break;
                    case "ValidationDate":
                        if (file510MapValidationAttribute.IsRequired)
                        {
                            instance.GetType().GetProperty(item.ToString()).SetValue(instance, (DateTime)ValidationDate(dictionary[item.ToString()].Value, file510MapValidationAttribute.IsRequired));
                            if (_existError)
                            {
                                MapError510Info(dictionary, item);
                                return null;
                            }
                        }
                        else
                        {
                            instance.GetType().GetProperty(item.ToString()).SetValue(instance, ValidationDate(dictionary[item.ToString()].Value, file510MapValidationAttribute.IsRequired));
                            if (_existError)
                            {
                                MapError510Info(dictionary, item);
                                return null;
                            }
                        }
                        break;
                    case "ValidationContains":
                        instance.GetType().GetProperty(item.ToString()).SetValue(instance, ValidationContains(dictionary[item.ToString()].Value, file510MapValidationAttribute.ValidValues.Split(',', StringSplitOptions.RemoveEmptyEntries), file510MapValidationAttribute.DefaultValueIsWhiteSpace));
                        if (_existError)
                        {
                            MapError510Info(dictionary, item);
                            return null;
                        }
                        break;
                    case "ValidationContainsLong":
                        string[] validValues = file510MapValidationAttribute.ValidValues.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        List<long> validValuesLong = new List<long>();
                        foreach (string value in validValues)
                        {
                            if (long.TryParse(value, out long returnValue))
                            {
                                validValuesLong.Add(returnValue);
                            }
                            else
                            {
                                throw new Exception("The array validValues not conteins values longs.");
                            }
                        }
                        instance.GetType().GetProperty(item.ToString()).SetValue(instance, ValidationContainsLong(dictionary[item.ToString()].Value, validValuesLong.ToArray()));
                        if (_existError)
                        {
                            MapError510Info(dictionary, item);
                            return null;
                        }
                        break;
                    case "ValidationOnlyNumbers":
                        instance.GetType().GetProperty(item.ToString()).SetValue(instance, ValidationOnlyNumbers(dictionary[item.ToString()].Value, file510MapValidationAttribute.IsRequired));
                        if (_existError)
                        {
                            MapError510Info(dictionary, item);
                            return null;
                        }
                        break;
                    case "ValidationRequirement":
                        instance.GetType().GetProperty(item.ToString()).SetValue(instance, ValidationRequirement(dictionary[item.ToString()].Value, file510MapValidationAttribute.DefaultValueIsWhiteSpace));
                        if (_existError)
                        {
                            MapError510Info(dictionary, item);
                            return null;
                        }
                        break;
                    case "None":
                        instance.GetType().GetProperty(item.ToString()).SetValue(instance, dictionary[item.ToString()].Value.Trim());
                        if (_existError)
                        {
                            MapError510Info(dictionary, item);
                            return null;
                        }
                        break;
                    default:
                        throw new Exception("Name validation in attribute not found.");
                }
            }
            return instance;
        }

        private static void MapError510Info(Dictionary<string, KeyMapLayout> dictionary, Enum item)
        {
            if (tError510Info == null)
            {
                tError510Info = new tError510Info();
            }
            tError510Info.Field = item.ToString();
            tError510Info.Value = dictionary[item.ToString()].Value;
            tError510Info.StartLine = dictionary[item.ToString()].Start + 1;
            tError510Info.EndLine = dictionary[item.ToString()].End;
        }

        private static bool AddTDetalle510(Dictionary<string, KeyMapLayout> dictionary, List<tDetalle510> list, Guid idHeader)
        {
            tDetalle510 tDetalle510 = CreateIntance<tDetalle510>(dictionary, typeof(EnumLayoutDetail));
            if (tDetalle510 != null)
            {
                tDetalle510.IdHeader510 = idHeader;//Guid.Parse("b098e356-73cb-4b7f-81b7-7212c5f7ce02");//
                tDetalle510.IdDetalle510 = Guid.NewGuid();
                tDetalle510.Status = 1;
                tDetalle510.CreateDate = DateTime.Now;
                tDetalle510.UpdateDate = DateTime.Now;
                tDetalle510.CreateUser = 1;
                tDetalle510.UpdateUser = 1;
                _detalle510 = tDetalle510.IdDetalle510;
                list.Add(tDetalle510);

            }
            return !_existError;
        }

        private static void MapValues(Dictionary<string, KeyMapLayout> dictionary, string line)
        {

            Parallel.ForEach(dictionary, t =>
            {
                t.Value.Value = line[t.Value.Start..t.Value.End];
            });

        }

        private static void InitKeysLayoutAttachmentDetail(Dictionary<string, KeyMapLayout> dictionary)
        {
            foreach (EnumLayoutAttachmentDetail item in Enum.GetValues(typeof(EnumLayoutAttachmentDetail)))
            {
                File510PointsAttribute file510PointsAttribute = EnumExtensions.GetAttribute<File510PointsAttribute>(item);
                dictionary.Add(item.ToString(), new KeyMapLayout((EnumTypeLayout)file510PointsAttribute.EnumTypeLayout, file510PointsAttribute.Start, file510PointsAttribute.End));
            }
        }

        private static void InitKeysLayoutDetail(Dictionary<string, KeyMapLayout> dictionary)
        {
            foreach (EnumLayoutDetail item in Enum.GetValues(typeof(EnumLayoutDetail)))
            {
                File510PointsAttribute file510PointsAttribute = EnumExtensions.GetAttribute<File510PointsAttribute>(item);
                dictionary.Add(item.ToString(), new KeyMapLayout((EnumTypeLayout)file510PointsAttribute.EnumTypeLayout, file510PointsAttribute.Start, file510PointsAttribute.End));
            }
        }
        private static bool AddHeader(Guid IdHeader510, List<tHeader510> list, string NameFile)
        {
            try
            {
                tHeader510 tHeader510 = new tHeader510();
                tHeader510.IdHeader510 = IdHeader510;
                tHeader510.NameFile = NameFile;
                tHeader510.IdStatus = 1;
                tHeader510.DateProcess = DateTime.Now;
                tHeader510.DateProcessing = DateTime.Now;//UPDATE
                tHeader510.Status = 1;
                tHeader510.CreateDate = DateTime.Now;
                tHeader510.UpdateDate = DateTime.Now;
                tHeader510.CreateUser = 1;
                tHeader510.UpdateUser = 1;
                list.Add(tHeader510);

                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
        private static bool AddError(List<tError510> list, Guid idHeader, int line)
        {
            try
            {
                tError510 tError510s = new tError510();
                tError510s.IdError510 = Guid.NewGuid();
                tError510s.IdHeader510 = idHeader;
                tError510s.Line = line;
                tError510s.Status = 3;
                tError510s.CreateDate = DateTime.Now;
                tError510s.UpdateDate = DateTime.Now;
                tError510s.CreateUser = 1;
                tError510s.UpdateUser = 1;
                list.Add(tError510s);

                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
      
    }
}
