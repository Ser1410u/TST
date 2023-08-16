using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace RestSRV.Classes
{
    public static class Utils
    {
        public static List<T> ListFromReader<T>(SqlDataReader reader)
        {
            List<T> list = new List<T>();
            PropertyInfo[] buff = new PropertyInfo[reader.FieldCount];
            PropertyInfo[] Props = typeof(T).GetProperties();
            string colName = "";
            for (int i = 0; i < reader.FieldCount; i++)
            {
                colName = reader.GetName(i);
                var z = Props.FirstOrDefault(x => x.Name.ToLower() == colName.ToLower());
                buff[i] = z;
            }
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T item = (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (buff[i] != null)
                        {
                            buff[i].SetValue(item, reader[buff[i].Name] == DBNull.Value ? null : reader[buff[i].Name]);
                        }
                    }
                    list.Add(item);
                }
            }
            reader.NextResult();
            return list;
        }

        public static void CheckDB(IConfiguration conf)
        {
            using (var connection = new SqlConnection(conf["ConnectionString"] ?? ""))
            {
                try
                {
                    connection.Open();
                }
                catch(SqlException err)
                {
                    conf["AlertString"] = "Укажите правильную строку соединения (ConnectionString в appsettings.json). На выбранном сервере создайте БД \"tstAppPavlov\",выполнив скрипт \\SQL\\DB.sql. Перезапустите проект."
                        + "(\n\n\n" + err.Message+")\n\n\n Строка соединения:\n" + conf["ConnectionString"] ?? "";
                }
                catch (Exception exc)
                {
                    conf["AlertString"] = exc.Message;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
