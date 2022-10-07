using System;
using System.Collections.Generic;
using System.Data;

namespace SievePOS.Services.Db
{
    public class dalCommon
    {
        public static int NextTableMaxNumber(string idColumn, string tableName)
        {
            string sql = $"SELECT MAX(CAST({idColumn} AS INT))MAX_ID FROM {tableName}";
            var args = new Dictionary<string, object>
             {
                  {"@ID",0}
             };
            DataTable dt = DatabaseSQLite.Execute(sql, args);
            if (dt == null || dt.Rows.Count == 0)
            {
                return 0;
            }
            var val = dt.Rows[0]["max_id"] == DBNull.Value ? "0" : dt.Rows[0]["max_id"];
            return Convert.ToInt32(val) + 1;
        }
    }
}
