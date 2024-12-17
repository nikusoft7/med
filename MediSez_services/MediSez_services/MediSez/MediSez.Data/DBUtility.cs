using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace MediSez.Data
{
    public static class DBUtility
    {
        public static async Task<string> GetjsonData(string connectionString, string sp, Dictionary<string, object> sqlparMediSez)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sp, sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = sqlConnection.ConnectionTimeout
                    };
                    foreach (KeyValuePair<string, object> parametar in sqlparMediSez)
                        sqlCommand.Parameters.AddWithValue(parametar.Key, parametar.Value);

                    DataTable dt = new DataTable();
                    (new SqlDataAdapter(sqlCommand)).Fill(dt);
                    sqlCommand.Parameters.Clear();

                    return JsonConvert.SerializeObject(dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static async Task<string> GetjsonDataFromDataset(string connectionString, string sp, Dictionary<string, object> sqlparMediSez)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sp, sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = sqlConnection.ConnectionTimeout
                    };
                    foreach (KeyValuePair<string, object> parametar in sqlparMediSez)
                        sqlCommand.Parameters.AddWithValue(parametar.Key, parametar.Value);

                    DataSet ds = new DataSet();
                    (new SqlDataAdapter(sqlCommand)).Fill(ds);
                    sqlCommand.Parameters.Clear();
                    string str = JsonConvert.SerializeObject(ds, Formatting.Indented);
                    return str;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static DataTable GetDataTable(string connectionString, string sp, Dictionary<string, object> sqlparMediSez)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sp, sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = sqlConnection.ConnectionTimeout
                    };
                    foreach (KeyValuePair<string, object> parametar in sqlparMediSez)
                        sqlCommand.Parameters.AddWithValue(parametar.Key, parametar.Value);

                    DataTable dt = new DataTable();
                    (new SqlDataAdapter(sqlCommand)).Fill(dt);
                    sqlCommand.Parameters.Clear();

                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
