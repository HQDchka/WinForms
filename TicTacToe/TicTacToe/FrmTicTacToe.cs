using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class FrmTicTacToe : Form
    {
        private Panel[,] cells = new Panel[3, 3];
        private string[,] cellMarks = new string[3, 3];
        private bool playerTurn = true;
        private bool vsCpu = true;

        private int playerScore = 0;
        private int cpuScore = 0;

        public FrmTicTacToe()
        {
            InitializeComponent();
            InitializeGameCells();
            labelWhooseTurn.Text = "Игрок";
        }

        private void InitializeGameCells()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    string name = $"panelCell{row}_{col}";
                    var panel = Controls.Find(name, true)[0] as Panel;
                    panel.BackColor = Color.Indigo;
                    panel.Tag = new Point(row, col);
                    panel.Click += Cell_Click;
                    panel.MouseEnter += (s, e) => CellMouseOver(s);
                    panel.MouseLeave += (s, e) => CellMouseOut(s);
                    cells[row, col] = panel;
                    cellMarks[row, col] = "";
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            Point pos = (Point)panel.Tag;
            if (cellMarks[pos.X, pos.Y] != "") return;

            string mark = playerTurn ? "X" : "O";
            cellMarks[pos.X, pos.Y] = mark;
            DrawMark(panel, mark);

            if (CheckWin(mark))
            {
                if (playerTurn)
                {
                    playerScore++;
                    labelPlayer1Score.Text = playerScore.ToString();
                    MessageBox.Show("Игрок победил!");
                }
                else
                {
                    cpuScore++;
                    labelPlayer2Score.Text = cpuScore.ToString();
                    MessageBox.Show(vsCpu ? "Компьютер победил!" : "Игрок 2 победил!");
                }
                ResetBoard();
                return;
            }

            if (IsBoardFull())
            {
                MessageBox.Show("Ничья!");
                ResetBoard();
                return;
            }

            playerTurn = !playerTurn;
            labelWhooseTurn.Text = playerTurn ? "Игрок" : vsCpu ? "Компьютер" : "Игрок 2";

            if (vsCpu && !playerTurn)
            {
                this.Enabled = false;
                Timer t = new Timer();
                t.Interval = 500;
                t.Tick += (s, ev) =>
                {
                    t.Stop();
                    ComputerMove();
                    this.Enabled = true;
                };
                t.Start();
            }
        }

        private void DrawMark(Panel panel, string mark)
        {
            Label lbl = new Label
            {
                Text = mark,
                Font = new Font("Franklin Gothic Medium", 24),
                ForeColor = mark == "X" ? Color.Gold : Color.Fuchsia,
                AutoSize = false,
                Size = panel.Size,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(lbl);
        }

        private bool CheckWin(string mark)
        {
            for (int i = 0; i < 3; i++)
            {
                if (cellMarks[i, 0] == mark && cellMarks[i, 1] == mark && cellMarks[i, 2] == mark) return true;
                if (cellMarks[0, i] == mark && cellMarks[1, i] == mark && cellMarks[2, i] == mark) return true;
            }
            if (cellMarks[0, 0] == mark && cellMarks[1, 1] == mark && cellMarks[2, 2] == mark) return true;
            if (cellMarks[0, 2] == mark && cellMarks[1, 1] == mark && cellMarks[2, 0] == mark) return true;
            return false;
        }

        private bool IsBoardFull()
        {
            foreach (var mark in cellMarks)
                if (mark == "") return false;
            return true;
        }

        private void ResetBoard()
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                {
                    cellMarks[r, c] = "";
                    cells[r, c].Controls.Clear();
                }
            playerTurn = true;
            labelWhooseTurn.Text = "Игрок";
        }

        private void ComputerMove()
        {
            Random rnd = new Random();
            int r, c;
            do
            {
                r = rnd.Next(3);
                c = rnd.Next(3);
            } while (cellMarks[r, c] != "");
            Cell_Click(cells[r, c], EventArgs.Empty);

        }

        // Цвет при наведении
        private void CellMouseOver(object sender)
        {
            Panel p = sender as Panel;
            if (p != null && cellMarks[((Point)p.Tag).X, ((Point)p.Tag).Y] == "")
                p.BackColor = Color.MediumPurple;
        }

        private void CellMouseOut(object sender)
        {
            Panel p = sender as Panel;
            if (p != null && cellMarks[((Point)p.Tag).X, ((Point)p.Tag).Y] == "")
                p.BackColor = Color.Indigo;
        }

        // Закрытие
        private void panelCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelCloseButton_MouseEnter(object sender, EventArgs e)
        {
            panelCloseButton.BackColor = Color.Purple;
            Cursor = Cursors.Hand;
        }

        private void panelCloseButton_MouseLeave(object sender, EventArgs e)
        {
            panelCloseButton.BackColor = Color.Indigo;
            Cursor = Cursors.Default;
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            panelCloseButton.BackColor = Color.Purple;
            Cursor = Cursors.Hand;
        }

        // Кнопки: сброс, новая игра, режимы
        private void panelReset_Click(object sender, EventArgs e)
        {
            ResetBoard();
        }

        private void panelNewGame_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            cpuScore = 0;
            labelPlayer1Score.Text = "0";
            labelPlayer2Score.Text = "0";
            ResetBoard();
        }

        private void panelPlayerVsCpu_Click(object sender, EventArgs e)
        {
            vsCpu = true;
            labelPlayer2Name.Text = "Компьютер:";
            ResetBoard();
        }

        private void panelPlayerVsPlayer_Click(object sender, EventArgs e)
        {
            vsCpu = false;
            labelPlayer2Name.Text = "Игрок 2:";
            ResetBoard();
        }
    }
}
