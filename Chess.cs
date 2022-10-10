using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wuziqi
{
	/**
	 * 摘要: 封装一个棋子类
	 */
    class Chess 
    {
		public long Id { get; set; } // 毫秒级时间戳自动生成

		public int X { get; set; } // 横坐标

		public int Y { get; set; } // 纵坐标

		public int R { get; set; } // 棋子半径

		public Color Color { get; set; } // 棋子颜色

		public DateTime Time;

        public int BoardId;

		public Chess() { }

		public Chess(int X, int Y, int R, Color Color, DateTime nowTime, int BoardId)
		{
			// this.Id = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
			Id = (long)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
			this.X = X;
			this.Y = Y;
			this.R = R;		
			this.Color = Color;
			this.Time = nowTime;
			this.BoardId = BoardId;
		}

        public Chess(long id, int x, int y, int r, Color color, DateTime time, int boardId)
        {
            Id = id;
            X = x;
            Y = y;
            R = r;
            Color = color;
            Time = time;
            BoardId = boardId;
        }

        public override string ToString()
        {
            return base.ToString();
        }


        // 显示棋子
        public void Draw(Graphics g)
		{
			g.FillEllipse(new SolidBrush(Color), X - R, Y - R, 2 * R, 2 * R);
		}


        public bool ColorEquals(object obj)
        {
            return obj is Chess chess &&
                  EqualityComparer<Color>.Default.Equals(Color, chess.Color);
        }
    }
}
