using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wuziqi;

namespace wuqizi
{
    class SqlServerController
    {
        /// <summary>
        /// 向数据库中添加一条棋子的记录
        /// </summary>
        public static void Insert(Chess chess)
        {
            string color = chess.Color.Equals(Color.Black) ? "Black" : "White";
            string time = chess.Time.ToString("yy-MM-dd HH:mm:ss");
            string sql = $"insert into chess(id, x, y, r, color, time, board_id) values({chess.Id}, {chess.X}, {chess.Y}, {chess.R}, '{color}','{time}', {chess.BoardId})";
            DBSqlServer.Insert(sql);
        }


        /// <summary>
        /// 向数据库中添加棋局的初始信息
        /// </summary>
        public static void Insert(Board board)
        {
            string startTime = board.Start.ToString("yy-MM-dd HH:mm:ss");
            string sql = $"insert into board(id, start_time, user_name) values({board.Id}, '{startTime}', 'yanchaowen')";
            DBSqlServer.Insert(sql);
        }


        /// <summary>
        /// 根据 id 删除要悔棋的棋子
        /// </summary>
        /// <param name="id">棋子id</param>
        internal static int DeleteChessById(long id)
        {
            string sql = $"delete from chess where id={id}";
            int result = DBSqlServer.Delete(sql);
            return result;
        }


        /// <summary>
        /// 根据 id 删除对应的记录
        /// </summary>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static int DeleteById(string table, long id)
        {
            string sql = $"delete from {table} where id={id}";
            int result = DBSqlServer.Delete(sql);
            return result;
        }


        /// <summary>
        /// 更新棋局的对弈信息
        /// </summary>
        /// <param name="id">棋局的id属性</param>
        /// <param name="color">获胜方</param>
        /// <param name="end">结束时间</param>
        /// <param name="count">棋子总数</param>
        public static void UpDateBoard(Board board, string result)
        {
            int id = board.Id;
            int count = board.list.Count;
            string endTimeStr = board.End.ToString("yy-MM-dd HH:mm:ss");

            string sql = $"update board set result='{result}', end_time='{endTimeStr}', count={count} where id={id}";
            
            DBSqlServer.Update(sql);
        }


        /// <summary>
        /// 设置 DataGridView 中的 DataSource
        /// </summary>
        /// <param name="table">要获取记录的表的名称</param>
        /// <returns>DataSet 集合</returns>
        public static DataSet GetFilledDataSet(string table)
        {
            string sql = $"select * from {table}";
            DataSet ds = DBSqlServer.FillDataSet(sql);
            return ds;
        }


        /// <summary>
        /// 用于根据棋局 id 查找该局的所有棋子
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static DataSet GetChessDataSetByBoard(int boardId)
        {
            string sql = $"select * from chess where board_id={boardId}";
            DataSet ds = DBSqlServer.FillDataSet(sql);
            return ds;
        }


        /// <summary>
        /// 根据棋局 id 查找其对应的所有棋子
        /// </summary>
        /// <param name="boardId"></param>
        /// <returns></returns>
        public static List<Chess> FindLastAll(int boardId)
        {
            //DataSet ds = GetChessDataSetByBoard(boardId);
            //DataTable dt = ds.Tables[0];

            //// 从 DataTable 读出数据 ===> List<Chess>
            //List<Chess> list = ModelConvertHelper<Chess>.DataTable2List(dt);

            string sql = $"select * from chess where board_id={boardId}";
            List<Chess> list = DBSqlServer.GetChessByBoardId(sql);
            return list;
        }


        /// <summary>
        /// 查找最后一局棋局的 id
        /// </summary>
        /// <returns></returns>
        internal static Board FindLastBoard()
        {
            string sql = "SELECT * FROM board ORDER BY id DESC LIMIT 1;";
            Board board = DBSqlServer.QueryBoard(sql);
            return board;
        }
    }
}
