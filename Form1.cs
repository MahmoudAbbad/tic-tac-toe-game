using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGeme.Properties;

namespace TicTacToeGeme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw
        }
        enum enPlayer
        {
            Player1,
            Player2
        }
        struct stGameStatus
        {
            public byte GameRounds;
            public enWinner Winner;
            public bool GameOver;
        }

        stGameStatus GameStatus;
        enPlayer PlayerTurn;
        void EndGame()
        {
            lblTurn.Text = "Game Over";

            if (GameStatus.GameOver)
            {
                switch (GameStatus.Winner)
                {
                    case enWinner.Player1:
                        lblWinner.Text = "  Player 1";
                        break;
                    case enWinner.Player2:
                        lblWinner.Text = "  Player 2";
                        break;
                    default:
                        lblWinner.Text = "   Draw";
                        break;

                }


                MessageBox.Show("Game Over!", "Game Over", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                panel1.Enabled = false;
            }
        }
        void ChangeImage(Button button)
        {
            if (button.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        button.Image = Resources.X;
                        lblTurn.Text = "Player 2";
                        button.Tag = "x";
                        PlayerTurn = enPlayer.Player2;
                        GameStatus.GameRounds++;
                        CheckWinner();
                        break;

                    case enPlayer.Player2:

                        button.Image = Resources.O;
                        lblTurn.Text = "Player 1";
                        button.Tag = "o";
                        PlayerTurn = enPlayer.Player1;
                        GameStatus.GameRounds++;
                        CheckWinner();
                        break;

            }   }
            else
            {
                MessageBox.Show("Wrong Choise", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(GameStatus.GameRounds == 9)
            {
                GameStatus.GameOver = true;
                EndGame();
            }
        }
        void ResetButton(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.Tag = "?";
            btn.Image = Resources.question_mark_96;    
        }
        void ResetGame()
        {
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);
            GameStatus.GameRounds = 0;
            GameStatus.Winner = enWinner.Draw;
            GameStatus.GameOver = false;
            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            lblWinner.Text = "In Progress";
            panel1.Enabled = true;
        }
        bool CheckValues(Button btn1,Button btn2 ,Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() ==
                btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "x")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else if(btn1.Tag.ToString() == "o") 
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.Winner = enWinner.Draw;
            GameStatus.GameOver = false;
            return false;
            }
        void CheckWinner()
        {
            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

        }
        private void lblRestartGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }   
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;
            Pen Pen = new Pen(White);

            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //row line
            e.Graphics.DrawLine(Pen, 380, 420, 840, 420);
            e.Graphics.DrawLine(Pen, 380, 280, 840, 280);
            //column line
            e.Graphics.DrawLine(Pen, 515, 175, 515, 535);
            e.Graphics.DrawLine(Pen, 685, 175, 685, 535);
        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

        private void btnRestartGame_MouseEnter(object sender, EventArgs e)
        {
            btnRestartGame.BackColor = Color.Gray;
        }

        private void btnRestartGame_MouseLeave(object sender, EventArgs e)
        {
            btnRestartGame.BackColor = Color.Black;
        }

    }
}
