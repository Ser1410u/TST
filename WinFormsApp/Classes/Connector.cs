using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestSRV.Classes;
using WFApp.Properties;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json; //не десереализует классы сложнее class{public int i{get;set;}}
namespace WFApp.Classes
{
    internal static class Connector
    {
        
        /*private static HttpClient httpClient()
        {
            HttpClientHandler ch = new HttpClientHandler();
            ch.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient c = new HttpClient(ch);
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            c.BaseAddress = new Uri(Settings.Default.ServiceURL);
            return c;
        }*/
        /*public static bool serviceExists()
        {
            bool result = false;
            try
            {
                using (var client = httpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(1);
                    using (var resp = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "home")).Result)
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
        }*/
        public static bool sqlExists()
        {
            bool retVal = false;
            try
            {
                using var connection = new SqlConnection(Settings.Default.ConnectionString);
                try
                {
                    connection.Open();
                    retVal = true;
                }
                catch (SqlException)
                {
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            catch
            {

            }

            return retVal;
        }

        public static async Task<Result> D(ILogger Log, string procName, SqlParameter[] parm)
        {
            Result retVal = new Result();

            using (var connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var cmd = new SqlCommand(procName, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parm != null && parm.Length > 0) cmd.Parameters.AddRange(parm);
                    SqlDataReader? reader = null;
                    try
                    {
                        await connection.OpenAsync();
                        reader = await cmd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            retVal.Table.Load(reader);
                            if (retVal.Table.Rows.Count > 0)
                            {
                                retVal.setError(code: -1, description: "Запись удалить не удалось.");
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Log.Log(LogLevel.Error, exception.HResult, exception, cmd.CommandText);
                        retVal.setError(code: exception.HResult, description: exception.Message);
                    }
                    finally
                    {
                        if (reader != null && !reader.IsClosed)
                            reader.Close();
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return retVal;
        }
        public static async Task<Result> S(ILogger Log, DataTable table, string procName, SqlParameter[] parm)
        {
            var retVal = new Result();
            table.Clear();
            retVal.Table = table;
            retVal.Table.Clear();
            using (var connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var cmd = new SqlCommand(procName, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parm != null && parm.Length > 0) cmd.Parameters.AddRange(parm);
                    SqlDataReader? reader = null;
                    try
                    {
                        await connection.OpenAsync();
                        reader = await cmd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            retVal.Table.Load(reader,LoadOption.OverwriteChanges);
                        }
                    }
                    catch (Exception exception)
                    {
                        Log.Log(LogLevel.Error, 0, exception, cmd.CommandText);
                        retVal.setError(code: exception.HResult, description: exception.Message);
                    }
                    finally
                    {
                        if (reader != null && !reader.IsClosed)
                            reader.Close();
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return retVal;
        }
        public static async Task<Result> IU(ILogger Log, string procName, SqlParameter[] parm)
        {
            var retVal = new Result();
            using (var connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var cmd = new SqlCommand(procName, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parm != null && parm.Length > 0) cmd.Parameters.AddRange(parm);
                    SqlDataReader? reader = null;
                    try
                    {
                        await connection.OpenAsync();
                        reader = await cmd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            retVal.Table.Load(reader);
                        }
                        else
                        {
                            retVal.setError(code: -1, description: "Опеация завершилась неудачно.");
                        }
                    }
                    catch (Exception exception)
                    {
                        Log.Log(LogLevel.Error, 0, exception, cmd.CommandText);
                        retVal.setError(code: exception.HResult, description: exception.Message);
                    }
                    finally
                    {
                        if (reader != null && !reader.IsClosed)
                            reader.Close();
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return retVal;
        }
    }

}
