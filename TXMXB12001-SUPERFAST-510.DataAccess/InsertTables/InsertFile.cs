using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TXMXB12001_SUPERFAST_510.DataAccess.DataBase;

namespace TXMXB12001_SUPERFAST_510.DataAccess
{
    public class InsertFile
    {
        //HEADER
        public bool Header510(DataTable tHeader510)
        {
            try
            {
                ContextDb contextDb = new ContextDb();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(contextDb.connectionString))
                {
                    bulkCopy.DestinationTableName = tHeader510.TableName;
                    bulkCopy.WriteToServer(tHeader510);
                }
                return true;

            }
            catch (Exception ex)
            {

            }
            return true;
        }
        //DETALLE
        public bool Detalle510(DataTable tDetalle510)
        {
            try
            {
                ContextDb contextDb = new ContextDb();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(contextDb.connectionString))
                {
                    bulkCopy.DestinationTableName = tDetalle510.TableName;
                    bulkCopy.BulkCopyTimeout= 900;
                    bulkCopy.WriteToServer(tDetalle510);
                }
                return true;

            }
            catch (Exception ex)
            {

            }
            return true;
        }
        //ANEXO
        public bool Anexo510(DataTable Anexo510)
        {
            try
            {
                ContextDb contextDb = new ContextDb();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(contextDb.connectionString))
                {
                    bulkCopy.DestinationTableName = Anexo510.TableName;
                    bulkCopy.WriteToServer(Anexo510);
                }
                return true;

            }
            catch (Exception ex)
            {

            }
            return true;
        }
        public bool UpdateDateHeader(Guid IdHeader510)
        {
            try
            {
                using (ContextDb de = new ContextDb())
                {
                    var qry = (from r in de.tHeader510
                               where r.IdHeader510 == IdHeader510
                               select r).FirstOrDefault();
                    if (qry != null)
                    {
                        qry.DateProcess = DateTime.Now;
                        qry.IdStatus = 2;
                    }

                    de.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //ERROR
        public bool Error510(DataTable tError510)
        {
            try
            {
                ContextDb contextDb = new ContextDb();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(contextDb.connectionString))
                {
                    bulkCopy.DestinationTableName = tError510.TableName;
                    bulkCopy.WriteToServer(tError510);
                }
                return true;

            }
            catch (Exception ex)
            {

            }
            return true;
        }
        public bool UpdateDateHeaderError(Guid IdHeader510)
        {
            try
            {
                using (ContextDb de = new ContextDb())
                {
                    var qry = (from r in de.tHeader510
                               where r.IdHeader510 == IdHeader510
                               select r).FirstOrDefault();
                    if (qry != null)
                    {
                        qry.UpdateDate = DateTime.Now;
                        qry.IdStatus = 3;
                    }

                    de.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool FileProcess(string name)
        {
            try
            {
                using (ContextDb de = new ContextDb())
                {
                    var qry = (from r in de.tHeader510
                               where r.NameFile == name //&& r.IdStatus ==  1 
                               select r).FirstOrDefault();
                    if (qry != null)
                    {
                        return false;
                    }
                    return true;

                }

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        //ERROR
        public bool Error510Info(DataTable tError510Info)
        {
            try
            {
                ContextDb contextDb = new ContextDb();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(contextDb.connectionString))
                {
                    bulkCopy.DestinationTableName = tError510Info.TableName;
                    bulkCopy.WriteToServer(tError510Info);
                }
                return true;

            }
            catch (Exception ex)
            {

            }
            return true;
        }
    }
}
