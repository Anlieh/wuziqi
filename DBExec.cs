using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wuziqi;

namespace wuqizi
{
    class DBExec
    {
        private static string DBCONNSTR = "server=localhost; user=root; database=wuziqi; port=3306; password=root123";

        public static MySqlConnection mysqlConn = new MySqlConnection(DBCONNSTR);

        //public static SqlConnection sqlClientConn = new SqlConnection(DBCONNSTR);

        /// <summary>
        /// 向数据库中插入一组字段
        /// </summary>
        /// <param name="sql">插入的 sql 语句</param>
        /// <returns>插入成功返回1，插入失败返回0</returns>
        public static int Insert(string sql)
        {
            int result = 0;
            try
            {
                mysqlConn.Open();
                Console.WriteLine("[Insert] 与数据库已建立连接");
                //往表内添加记录
                MySqlCommand cmd = new MySqlCommand(sql, mysqlConn);
                //执行sql添加语句    
                result = cmd.ExecuteNonQuery();
            } 
            catch (MySqlException e)
            {   
                Console.WriteLine(e.Message);
            }
            finally
            {
                mysqlConn.Close();
            }
            return result;
        }


        public static MySqlDataReader QueryById(string sql)
        {
            try
            {
                mysqlConn.Open();
                Console.WriteLine("[QueryById] 与数据库已建立连接");
                MySqlCommand cmd = new MySqlCommand(sql, mysqlConn);
                // 读取结果
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                mysqlConn.Close();
            }
            return null;
        }

        public static MySqlDataReader Query(string sql)
        {
            try
            {
                mysqlConn.Open();
                Console.WriteLine("[Query] 与数据库已建立连接");
                MySqlCommand cmd = new MySqlCommand(sql, mysqlConn);
                // 读取结果
                MySqlDataReader read = cmd.ExecuteReader();
                return read;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                mysqlConn.Close();
            }
            return null;
        }

        public static int Update(string sql)
        {
            int result = 0;
            try
            {
                mysqlConn.Open();
                Console.WriteLine("[Update] 与数据库已建立连接");

                MySqlCommand cmd = new MySqlCommand(sql, mysqlConn);

                result = cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                mysqlConn.Close();
            }
            return result;
        }
    }
}
