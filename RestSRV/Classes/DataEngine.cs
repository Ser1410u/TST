using System;
using System.Data;
using System.Data.SqlClient;

namespace RestSRV.Classes
{
    public static class DataEngine
    {

        public static Result<T> D<T>(ILogger Log, string constr, string procName, SqlParameter[] parm)
        {
            Result<T> retVal = new Result<T>();
            using (var connection = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand(procName, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parm != null && parm.Length > 0) cmd.Parameters.AddRange(parm);
                    SqlDataReader reader = null;
                    try
                    {
                        connection.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            retVal.Payload = Utils.ListFromReader<T>(reader);
                            if (retVal.Payload.Count > 0)
                            {
                                retVal.setError(code: -1,description: "Запись удалить не удалось.");
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
        public static Result<T> S<T>(ILogger Log, string constr, string procName, SqlParameter[] parm)
        {
            var retVal = new Result<T>();

            using (var connection = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand(procName, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parm != null && parm.Length > 0) cmd.Parameters.AddRange(parm);
                    SqlDataReader reader = null;
                    try
                    {
                        connection.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            retVal.Payload = Utils.ListFromReader<T>(reader);
                            
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
        public static Result<T> IU<T>(ILogger Log, string constr, string procName, SqlParameter[] parm)
        {
            var retVal = new Result<T>();
            using (var connection = new SqlConnection(constr))
            {
                using (var cmd = new SqlCommand(procName, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parm != null && parm.Length > 0) cmd.Parameters.AddRange(parm);
                    SqlDataReader reader = null;
                    try
                    {
                        connection.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            retVal.Payload = Utils.ListFromReader<T>(reader);
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
