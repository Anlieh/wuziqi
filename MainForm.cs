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
    public partial class MainForm : Form
    {
        private Bitmap bitMap;
        private Graphics graphics;
        private Board board;


        public MainForm()
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
            DBService.Insert(board);
            boardPictureBox.Enabled = true;
        }

        private void BoardPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            double i = Convert.ToDouble(e.X) / board.Grid;
            double j = Convert.ToDouble(e.Y) / board.Grid;

            Chess chess = new Chess((int)(Math.Round(i) * board.Grid),
                                (int)(Math.Round(j) * board.Grid),
                                (int)(0.45 * board.Grid),
                                Color.Black,
                                board.Id);
            if (board.Exists(chess))
            {
                MessageBox.Show("不能在同一个位置添加棋子!");
                return;
            }
            board.Add(chess);
            board.Draw(graphics);

            DBService.Insert(chess);

            boardPictureBox.Image = bitMap;

            if(board.Win())
            {
                MessageBox.Show(chess.Color.ToString() + "方获胜!");
                boardPictureBox.Enabled = false;

                // 更新对局情况：胜负等
                DBService.UpDateBoard(board.Id, chess.Color, DateTime.Now, board.list.Count);
                return;
            }
        }


        public void HuiqiBtnClick(object sender, EventArgs e)
        {
            board.RemoveLast();
            board.Draw(graphics);
            boardPictureBox.Image = bitMap;
        }


        public void Reset(object sender, EventArgs e)
        {
            this.InitBoard();
            board.Draw(graphics);
            boardPictureBox.Image = bitMap;
        }

    }
}
