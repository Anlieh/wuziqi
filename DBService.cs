using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wuziqi;
using MySql.Data.MySqlClient;

namespace wuqizi
{
    class DBService
    {

        public static void Insert(Chess chess)
        {
            string color = chess.Color.Equals(Color.Black) ? "Black" : "White";
            string time = chess.Time.ToString("yy-MM-dd HH:mm:ss");
            //string sql = $"insert into chess(id, x, y, r, color) values({chess.id}, {chess.x}, {chess.y}, {chess.r}, '{chess.color}')";
            string sql = $"insert into chess(id, x, y, r, color, time, board_id) values({chess.Id}, {chess.X}, {chess.Y}, {chess.R}, '{color}','{time}', {chess.BoardId})";
            DBExec.Insert(sql);
        }

        public static void QueryById(int id)
        {
            string sql = $"select * from chess where id={id}";
            MySqlDataReader reader = DBExec.QueryById(sql);
        }

        public static List<Chess> getAll()
        {
            string sql = "select * from chess";
            MySqlDataReader reader = DBExec.Query(sql);
            List<Chess> list = new List<Chess>();
            while (reader.Read())
            {
                list.Add(new Chess()
                {
                    Id = Convert.ToInt32(reader.GetValue(0).ToString()),
                    X = Convert.ToInt32(reader.GetValue(1).ToString()),
                    Y = Convert.ToInt32(reader.GetValue(2).ToString()),
                    R = Convert.ToInt32(reader.GetValue(3).ToString()),
                    Color = reader.GetValue(4).ToString() == "Black" ? Color.Black : Color.White
                });
            }
            return list;
        }

        public static void Insert(Board board)
        {
            string startTime = board.Start.ToString("yy-MM-dd HH:mm:ss");
            string sql = $"insert into board(id, start) values({board.Id}, '{startTime}')";
            DBExec.Insert(sql);
        }


        public static void UpDateBoard(int id, Color color, DateTime end, int count)
        {
            string colorStr = color.Equals(Color.Black) ? "Black" : "White";

            string endTimeStr = end.ToString("yy-MM-dd HH:mm:ss");

            string sql = $"update board set end='{endTimeStr}', result='{colorStr}', count={count} where id={id}";

            DBExec.Update(sql);
        }

    }
}
