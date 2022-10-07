using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace SievePOS.Services.Db
{
    public class DatabaseSQLite
    {
        public static string DB_PATH = @"Data Source=./Assets/sievepos.db;";
        public static void ExecuteWrite(string query, Dictionary<string, object> args)
        {

            //setup the connection to the database
            using (var con = new SQLiteConnection(DB_PATH))
            {
                con.Open();

                //open a new command
                using (var cmd = new SQLiteCommand(query, con))
                {
                    //set the arguments given in the query
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static DataTable Execute(string query, Dictionary<string, object> args)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;

            using (var con = new SQLiteConnection(DB_PATH))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(query, con))
                {
                    foreach (KeyValuePair<string, object> entry in args)
                    {
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }

                    var da = new SQLiteDataAdapter(cmd);

                    var dt = new DataTable();
                    da.Fill(dt);

                    da.Dispose();
                    return dt;
                }
            }
        }


    }
}
