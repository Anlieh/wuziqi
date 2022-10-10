using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;


namespace wuziqi
{
    public static class Setting
    {
        public static string username = "";
    }

    public static class DBclass
    {
        public static string connect = @"Data Source=47.105.75.249;Initial Catalog=WZQ;Integrated Security=False;user=testR;password=jisuanji888";

        //public DBclass()
        //{
        //    connect = @"Data Source=47.105.75.249;Initial Catalog=WZQ;Integrated Security=False;user=testR;password=jisuanji888";
        //}

        public static SqlConnection Getconnect()
        {
            SqlConnection con = new SqlConnection(connect);
            return con;
        }


        public static SqlDataAdapter GetAdapter(string SelectSentence)
        {
            SqlConnection con = Getconnect();
            SqlDataAdapter adapter = new SqlDataAdapter(SelectSentence, con);
            return adapter;
        }


        public static DataTable GetTable(string SelectSentence)
        {
            SqlDataAdapter adapter = GetAdapter(SelectSentence);
            DataTable table = new DataTable();
            table.TableName = "tablename";
            if (table != null) adapter.Fill(table);
            return table;
        }


        public static void ExcuteNonQuery(string sql)
        {
            SqlConnection connect = Getconnect();
            connect.Open();
            SqlCommand command = new SqlCommand(sql, connect);
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            connect.Close();
        }

    }
}
