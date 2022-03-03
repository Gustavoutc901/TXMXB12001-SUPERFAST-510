using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TXMXB12001_SUPERFAST_510.DataAccess.DataBase;

namespace TXMXB12001_SUPERFAST_510.DataAccess.InsertTables
{
    public class CipherData
    {
        ContextDb contextDb = new ContextDb();


        public Dictionary<long, byte[]> GetCardCiphered()
        {
            using (SqlConnection sqlConnection = new SqlConnection(contextDb.connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT IdCardsCipher, CardNumberHash FROM tCardsCipher", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Dictionary<long, byte[]> returnValue = new Dictionary<long, byte[]>();

                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                returnValue.Add(sqlDataReader.GetInt64(0), (byte[])sqlDataReader.GetValue(1));
                            }
                        }
                        return returnValue;
                    }
                }
            }
        }
    }
}
