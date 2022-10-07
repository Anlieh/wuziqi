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
        public static void Insert(Chess chess)
        {
            string color = chess.Color.Equals(Color.Black) ? "Black" : "White";
            string time = chess.Time.ToString("yy-MM-dd HH:mm:ss");
            string sql = $"insert into chess(id, x, y, r, color, time, board_id) values({chess.Id}, {chess.X}, {chess.Y}, {chess.R}, '{color}','{time}', {chess.BoardId})";
            SqlService.Insert(sql);
        }

      
        public static void Insert(Board board)
        {
            string startTime = board.Start.ToString("yy-MM-dd HH:mm:ss");
            string sql = $"insert into board(id, start) values({board.Id}, '{startTime}')";
            SqlService.Insert(sql);
        }


        public static void UpDateBoard(int id, Color color, DateTime end, int count)
        {
            string colorStr = color.Equals(Color.Black) ? "Black" : "White";

            string endTimeStr = end.ToString("yy-MM-dd HH:mm:ss");

            string sql = $"update board set end='{endTimeStr}', result='{colorStr}', count={count} where id={id}";

            SqlService.Update(sql);
        }

       public static DataSet GetFilledDataSet(string table)
        {
            string sql = $"select * from {table}";

            DataSet ds = SqlService.FillDataSet(sql);

            return ds;
        }

        internal static DataSet GetChessDataSetOnCondition(int id)
        {
            string sql = $"select * from chess where board_id={id}";

            DataSet ds = SqlService.FillDataSet(sql);

            return ds;
        }
    }
}
