using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wuqizi;

namespace wuziqi
{
    /**
     * 摘要: 封装一个棋盘类
     */
    class Board
    {
        public int Id { get; set; }

        public int Grid { get; set; } // 棋盘格子的边长

        public int Row { get; set; }// 棋盘行数

        public int Col { get; set; } // 棋盘列数

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public List<Chess> list = new List<Chess>(); // 棋子列表


        public Board(DateTime dateTime)
        {
            this.Id = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            this.Grid = 60;
            this.Row = 20;
            this.Col = 20;
            this.Start = dateTime;
        }

        /// <summary>
        /// 绘制棋盘
        /// </summary>
        /// <param name="Grid">格子边长</param>
        /// <param name="Row">棋盘行数</param>
        /// <param name="Col">棋盘列数</param>
        public Board(int Grid, int Row, int Col)
        {
            this.Grid = Grid;
            this.Row = Row;
            this.Col = Col;
            this.Start = DateTime.Now;
        }


        /// <summary>
        /// 绘制棋盘及其上的所有棋子
        /// </summary>
        public void Draw(Graphics graphics)
        {
            graphics.Clear(Color.LightGray);
            // 绘制格线
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    graphics.DrawRectangle(Pens.DarkGreen, i * Grid, j * Grid, Grid, Grid);
                }
            }
            this.DrawAll(graphics);
        }


        /// <summary>
        /// 绘制所有棋子
        /// </summary>
        public void DrawAll(Graphics graphics)
        {
            foreach (Chess chess in list)
            {
                chess.Draw(graphics);
            }
        }


        /// <summary>
        /// 下棋: 向队列中添加棋子
        /// </summary>
        public void Add(Chess chess)
        {
            int count = list.Count;
            if (count > 0 && list[count - 1].Color == Color.Black)
            {
                chess.Color = Color.White;
            }
            list.Add(chess);
        }


        /// <summary>
        /// 悔棋: 返回中队列的最后一项并将其移除
        /// </summary>
        public Chess RemoveLast()
        {
            if (list.Count == 0)
            {
                MessageBox.Show("当前棋局已无棋子!");
                return null;
            }
            int lastIndex = list.Count - 1;
            Chess last = list[lastIndex];
            list.RemoveAt(lastIndex);
            return last;
        }


        /// <summary>
        /// 判断当前坐标是否有棋子 
        /// </summary>
        public bool Exists(Chess chess)
        {
            foreach (Chess item in list)
            {
                if (item.X == chess.X && item.Y == chess.Y)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 在链表中搜索当前棋子
        /// </summary>
        public Chess Search(int x, int y)
        {
            foreach (Chess item in list)
            {
                if (x == item.X && y == item.Y)
                {
                    return item;
                }
            }
            return null;
        }


        /// <summary>
        /// 构造棋子的二维数组
        /// </summary>
        public Chess[,] Convert2Array()
        {
            Chess[,] arr = new Chess[this.Row, this.Col];
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    arr[i, j] = null;
                }
            }
            foreach (Chess chess in list)
            {
                int j = chess.X / Grid;
                int i = chess.Y / Grid;
                arr[i, j] = chess;
            }
            return arr;
        }


        /// <summary>
        /// 判断输赢
        /// </summary>
        public bool Win()
        {
            foreach (Chess chess in list)
            {
                if (WinRow(chess) || WinCol(chess) ||
                    WinRightDiangle(chess) || WinLeftDiangle(chess))
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 判断棋子上面是否有4列格线
        /// </summary>
        public bool isTop(Chess chess)
        {
            if(chess.X - 5 < 0)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 判断棋子左侧是否有4列格线
        /// </summary>
        public bool isLeft(Chess chess)
        {
            if (chess.Y - 5 < 0)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 判断棋子下面是否有4列格线
        /// </summary>
        public bool isBottom(Chess chess)
        {
            if (this.Row - chess.X < 4)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 判断棋子右侧是否有4列格线
        /// </summary>
        public bool isRight(Chess chess)
        {
            if (this.Col - chess.Y < 4)
            {
                return false;
            }
            return true;
        }

        
        /// <summary>
        /// 行
        /// </summary>
        public bool WinRow(Chess chess)
        {
            int col = chess.X / Grid;
            int row = chess.Y / Grid;
            Color color = chess.Color;

            Chess[,] array = Convert2Array();

            // 先判断是否有无 5 个连续的棋子
            if (array[row, col + 1] == null || array[row, col + 2] == null ||
                array[row, col + 3] == null || array[row, col + 4] == null)
            {
                return false;
            }

            // 再判断颜色是否相同
            if (array[row, col + 1].Color == color && array[row, col + 2].Color == color &&
                array[row, col + 3].Color == color && array[row, col + 4].Color == color)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 列
        /// </summary>
        public bool WinCol(Chess chess)
        {
            int col = chess.X / Grid;
            int row = chess.Y / Grid;
            Color color = chess.Color;

            Chess[,] arr = this.Convert2Array();

            // 先判断是否有无 5 个连续的棋子
            if (arr[row + 1, col] == null || arr[row + 2, col] == null ||
                arr[row + 3, col] == null || arr[row + 4, col] == null)
            {
                return false;
            }

            // 再判断颜色是否相同
            if (arr[row + 1, col].Color == color && arr[row + 2,col].Color == color &&
                arr[row + 3, col].Color == color && arr[row + 4, col].Color == color)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 左对角线
        /// </summary>
        public bool WinLeftDiangle(Chess chess)
        {
            int col = chess.X / Grid;
            int row = chess.Y / Grid;
            Color color = chess.Color;
            Chess[,] arr = this.Convert2Array();

            if (arr[row - 1, col + 1] == null || arr[row - 2, col - 2] == null ||
               arr[row - 3, col + 3] == null || arr[row - 4, col - 4] == null)
            {
                return false;
            }

            if (arr[row - 1, col + 1].Color == color && arr[row - 2, col - 2].Color == color &&
               arr[row - 3, col + 3].Color == color && arr[row - 4, col - 4].Color == color)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 右对角线
        /// </summary>
        public bool WinRightDiangle(Chess chess)
        {
            int col = chess.X / Grid;
            int row = chess.Y / Grid;
            Color color = chess.Color;
            Chess[,] arr = this.Convert2Array();

            if (arr[row + 1, col+ 1] == null || arr[row + 2, col + 2] == null ||
              arr[row + 3, col + 3] == null || arr[row + 4, col + 4] == null)
            {
                return false;
            }

            if (arr[row + 1, col + 1].Color == color && arr[row + 2, col+ 2].Color == color &&
               arr[row + 3, col + 3].Color == color && arr[row + 4, col + 4].Color == color)
            {
                return true;
            }
            return false;
        }

    }
}
