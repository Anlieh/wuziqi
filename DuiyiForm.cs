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

            // 获得上局对弈详情
            this.board = this.GetLastBoard();
            
            board.Draw(graphics);
            boardPictureBox.Image = bitMap;

            // 不能修改上局信息
            boardPictureBox.Enabled = false;
            huiqiBtn.Enabled = false;
            
        }


        /// <summary>
        /// 构造新的棋局对象
        /// </summary>
        public void InitDuiyiForm()
        {
            board = new Board(DateTime.Now);
            board.list.Clear();
            boardPictureBox.Enabled = true;
            huiqiBtn.Enabled = true;

            MySqlController.Insert(board);
            //SqlServerController.Insert(board);
        }


        /// <summary>
        /// 确认是否开始新的一局
        /// </summary>
        private bool CheckForNew()
        {
            // 让用户选择点击
            DialogResult result = MessageBox.Show("确认开始新的一局?", "确认你的选择",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // 判断是否确认
            if (result == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 查找上一局的对弈详情
        /// </summary>
        private Board GetLastBoard()
        {
            Board lastBoard = MySqlController.FindLastBoard();
            lastBoard.Grid = 60;
            lastBoard.Row = 10;
            lastBoard.Col = 10;
            int lastId = lastBoard.Id;
            List<Chess> ts = MySqlController.FindLastAll(lastId);
            lastBoard.list = ts;
            return lastBoard;
        }


        /// <summary>
        /// 棋盘表格点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            #region 添加并绘制棋子
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
                        
            board.Add(chess);
            board.Draw(graphics);
            boardPictureBox.Image = bitMap;

            MySqlController.Insert(chess);
            //SqlServerController.Insert(chess);

            #endregion

            // 判断是否已有一方获胜
            if (board.Win())
            {
                string winColor = chess.Color.Equals(Color.Black) ? "Black" : "White";
                MessageBox.Show(winColor + "方获胜!");
                boardPictureBox.Enabled = false;
                board.End = nowTime;

                // 更新对弈结果
                MySqlController.UpDateBoard(board, winColor);
                //SqlServerController.UpDateBoard(board, winColor);

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
            if(CheckForNew())
            {
                this.InitDuiyiForm();
                board.Draw(graphics);
                boardPictureBox.Image = bitMap;
                boardPictureBox.Enabled = true;
            }
            
        }

    }
}
