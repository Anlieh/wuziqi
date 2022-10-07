using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wuziqi;

namespace wuqizi
{
    public partial class DuiyiForm : Form
    {
        private Bitmap bitMap;
        private Graphics graphics;
        private Board board;


        public DuiyiForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            bitMap = new Bitmap(boardPictureBox.Width, boardPictureBox.Height);
            graphics = Graphics.FromImage(bitMap);
            graphics.Clear(color: Color.LightGray);

            this.InitBoard();

            board.Draw(graphics);
            boardPictureBox.Image = bitMap;
        }

        public void InitBoard()
        {
            board = new Board(DateTime.Now);
            board.list.Clear();
            MySqlController.Insert(board);
            boardPictureBox.Enabled = true;
        }

        private void BoardPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            double i = Convert.ToDouble(e.X) / board.Grid;
            double j = Convert.ToDouble(e.Y) / board.Grid;
            DateTime nowTime = DateTime.Now;
            Chess chess = new Chess((int)(Math.Round(i) * board.Grid),
                                (int)(Math.Round(j) * board.Grid),
                                (int)(0.45 * board.Grid),
                                Color.Black,
                                nowTime,
                                board.Id);

            if (board.Exists(chess))
            {
                MessageBox.Show("该位置已存在棋子!");
                return;
            }

            // 添加并绘制棋子
            board.Add(chess);
            board.Draw(graphics);
            boardPictureBox.Image = bitMap;

            MySqlController.Insert(chess);

            // 判断是否已有一方获胜
            if (board.Win())
            {
                string winColor = chess.Color.Equals(Color.Black) ? "Black" : "White";
                MessageBox.Show(winColor + "方获胜!");
                boardPictureBox.Enabled = false;
                board.End = nowTime;
                // 更新对弈结果
                MySqlController.UpDateBoard(board, winColor);
                return;
            }
        }


        public void HuiqiBtnClick(object sender, EventArgs e)
        {
            Chess last = board.RemoveLast();
            board.Draw(graphics);
            boardPictureBox.Image = bitMap;
            MySqlController.DeleteById("chess", last.Id);
        }


        public void Reset(object sender, EventArgs e)
        {
            this.InitBoard();
            board.Draw(graphics);
            boardPictureBox.Image = bitMap;
        }

    }
}
