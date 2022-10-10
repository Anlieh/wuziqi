using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using wuziqi;
using System.Drawing;

namespace wuqizi
{
    class DBSqlServer
    {
        //第一种连接: sql server 的 Windows 身份验证
        //public string connStr = "server=.;database=DBName;Trusted_Connection=SSPI";
       
        //第二种连接: sql server身份验证
        //public static string connStr = "server=.;database=DBName;uid=userName;pwd=userPassword";
        public static string connStr = "Data Source=47.105.75.249;Initial Catalog=WZQ;Integrated Security=False;user=testR;password=jisuanji888";

        public static SqlConnection sqlConn = new SqlConnection(connStr);


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
                Console.WriteLine("[Insert] SqlServer连接正常");
                //往表内添加记录
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                //执行sql添加语句    
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
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
        /// <param name="sql">要执行的 sql 语句</param>
        /// <returns>执行结果</returns>
        public static int Update(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[Update] SqlServer连接正常");
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException e)
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
                Console.WriteLine("[Delete] SqlServer连接正常");
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return 0;
        }

        /// <summary>
        /// 返回一个填充的 DataSet 数据集
        /// </summary>
        public static DataSet FillDataSet(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[FillDataSet] SqlServer连接正常");
                //创建适配器
                SqlDataAdapter msda = new SqlDataAdapter(sql, sqlConn);
                //创建数据集
                DataSet ds = new DataSet();
                msda.Fill(ds);
                return ds;
            }
            catch (SqlException e)
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
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
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
            catch (SqlException e)
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
        public static List<Chess> GetChessByBoardId(string sql)
        {
            try
            {
                sqlConn.Open();
                Console.WriteLine("[QueryChess] MySQL连接正常");
                //往表内添加记录
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
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
            catch (SqlException e)
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
