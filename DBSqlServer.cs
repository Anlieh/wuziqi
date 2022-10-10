using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace wuqizi
{
    class DBSqlServer
    {
        //第一种连接: sql server 的 Windows 身份验证
        //public string connStr = "server=.;database=DBName;Trusted_Connection=SSPI";
       
        //第二种连接: sql server身份验证
        public static string connStr = "server=.;database=DBName;uid=userName;pwd=userPassword";

        public static SqlConnection conn = new SqlConnection(connStr);


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
                conn.Open();
                Console.WriteLine("[Insert] SqlServer连接正常");
                //往表内添加记录
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行sql添加语句    
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
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
                conn.Open();
                Console.WriteLine("[Update] SqlServer连接正常");
                SqlCommand cmd = new SqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }


        public static int Delete(string sql)
        {
            try
            {
                conn.Open();
                Console.WriteLine("[Delete] SqlServer连接正常");
                SqlCommand cmd = new SqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
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
                conn.Open();
                Console.WriteLine("[FillDataSet] SqlServer连接正常");
                //创建适配器
                SqlDataAdapter msda = new SqlDataAdapter(sql, conn);
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
                conn.Close();
            }
            return null;
        }


        public static SqlDataReader Query(string sql)
        {           
            try
            {
                conn.Open();
                Console.WriteLine("[Query] SqlServer连接正常");
                SqlCommand cmd = new SqlCommand(sql, conn);
                // 读取结果
                SqlDataReader read = cmd.ExecuteReader();

                return read;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

    }
}
