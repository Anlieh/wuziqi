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
    class SqlService
    {
        public static string DBCONNSTR = "server=localhost; user=root; database=wuziqi; port=3306; password=root123";

        public static MySqlConnection sqlConn = new MySqlConnection(DBCONNSTR);


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
                sqlConn.Open();
                Console.WriteLine("[Insert] 连接正常");
                //往表内添加记录
                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                //执行sql添加语句    
                result = cmd.ExecuteNonQuery();
            } 
            catch (MySqlException e)
            {   
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return result;
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[Update] 连接正常");
                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return 0;
        }


        public static int Delete(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[Delete] 连接正常");
                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return 0;
        }


        public static DataSet FillDataSet(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[FillDataSet] 连接正常");
                //创建适配器
                MySqlDataAdapter msda = new MySqlDataAdapter(sql, sqlConn);
                //创建数据集
                DataSet ds = new DataSet();
                msda.Fill(ds);
                return ds;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return null;
        }

             
        public static MySqlDataReader Query(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[Query] 与数据库已建立连接");
                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
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
                sqlConn.Close();
            }
            return null;
        }

     
    }
    
}
