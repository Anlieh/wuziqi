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
    static class DBMySql
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
                Console.WriteLine("[Insert] MySQL连接正常");
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
                Console.WriteLine("[Update] MySQL连接正常");
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
                Console.WriteLine("[Delete] MySQL连接正常");
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
                Console.WriteLine("[FillDataSet] MySQL连接正常");
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
                Console.WriteLine("[Query] MySQL连接正常");
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


        /// <summary>
        /// 查询 Board
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Board 对象</returns>
        internal static Board QueryBoard(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[QueryBoard] MySQL连接正常");
                //往表内添加记录
                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
               
                        while(reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetInt32(0));
                            DateTime startTime = Convert.ToDateTime(reader.GetDateTime(1));
                            DateTime endTime = Convert.ToDateTime(reader.GetDateTime(2));
                            string result = Convert.ToString(reader.GetString(3));
                            int count = Convert.ToInt32(reader.GetInt32(4));
                            Board board = new Board(id, startTime, endTime, result, count);
                            return board;
                        }
                
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



        /// <summary>
        /// 查询所有棋子
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        internal static List<Chess> GetChessByBoardId(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[QueryChess] MySQL连接正常");
                //往表内添加记录
                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Chess> list = new List<Chess>();
              
                        while (reader.Read())
                        {
                            long id = Convert.ToInt64(reader.GetInt64(0));
                            int x = Convert.ToInt32(reader.GetInt32(1));
                            int y = Convert.ToInt32(reader.GetInt32(2));
                            int r = Convert.ToInt32(reader.GetInt32(3));
                            string colorStr = Convert.ToString(reader.GetString(4));
                            Color color = ModelConvertHelper<Color>.ConvertColor(colorStr);
                            DateTime time = Convert.ToDateTime(reader.GetDateTime(5));
                            int boardId = Convert.ToInt32(reader.GetInt32(6));
                            Chess chees = new Chess(id, x, y, r, color, time, boardId);
                            list.Add(chees);
                        }
                 
                return list;
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
