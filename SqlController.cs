using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wuziqi;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace wuqizi
{
    class SqlController
    {
        /// <summary>
        /// 向数据库中添加一条棋子的记录
        /// </summary>
        public static void Insert(Chess chess)
        {
            string color = chess.Color.Equals(Color.Black) ? "Black" : "White";
            string time = chess.Time.ToString("yy-MM-dd HH:mm:ss");
            string sql = $"insert into chess(id, x, y, r, color, time, board_id) values({chess.Id}, {chess.X}, {chess.Y}, {chess.R}, '{color}','{time}', {chess.BoardId})";
            SqlService.Insert(sql);
        }

      
        /// <summary>
        /// 向数据库中添加棋局的初始信息
        /// </summary>
        public static void Insert(Board board)
        {
            string startTime = board.Start.ToString("yy-MM-dd HH:mm:ss");
            string sql = $"insert into board(id, start) values({board.Id}, '{startTime}')";
            SqlService.Insert(sql);
        }


        /// <summary>
        /// 删除要悔棋的棋子
        /// </summary>
        /// <param name="id">棋子id</param>
        internal static int DeleteChessById(int id)
        {
            string sql = $"delete from chess where id={id}";
            int result = SqlService.Delete(sql);
            return result;
        }


        internal static int DeleteById(string table, int id)
        {
            string sql = $"delete from {table} where id={id}";
            int result = SqlService.Delete(sql);
            return result;
        }


        /// <summary>
        /// 更新棋局的对弈信息
        /// </summary>
        /// <param name="id">棋局的id属性</param>
        /// <param name="color">获胜方</param>
        /// <param name="end">结束时间</param>
        /// <param name="count">棋子总数</param>
        public static void UpDateBoard(int id, Color color, DateTime end, int count)
        {
            string colorStr = color.Equals(Color.Black) ? "Black" : "White";
            string endTimeStr = end.ToString("yy-MM-dd HH:mm:ss");
            string sql = $"update board set end='{endTimeStr}', result='{colorStr}', count={count} where id={id}";
            SqlService.Update(sql);
        }


        public static void UpDateBoard(Board board, string result)
        {
            int id = board.Id;
            int count = board.list.Count;
            string endStr = board.End.ToString("yy-MM-dd HH:mm:ss");

            string sql = $"update board set end='{endStr}', result='{result}', count={count} where id={id}";
            SqlService.Update(sql);
        }

        /// <summary>
        /// 设置 DataGridView 中的 DataSource
        /// </summary>
        /// <param name="table">要获取记录的表的名称</param>
        /// <returns>DataSet 集合</returns>
        public static DataSet GetFilledDataSet(string table)
        {
            string sql = $"select * from {table}";
            DataSet ds = SqlService.FillDataSet(sql);
            return ds;
        }

        
        /// <summary>
        /// 用于根据棋局 id 查找该局的所有棋子
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static DataSet GetChessDataSetOnCondition(int id)
        {
            string sql = $"select * from chess where board_id={id}";
            DataSet ds = SqlService.FillDataSet(sql);
            return ds;
        }
    }
}
