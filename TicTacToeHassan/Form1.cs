using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeHassan
{

    public partial class GameScreen : Form
    {
        bool isComputerTurn = false;
        public Dictionary<Button,EventHandler> btns_evt_handlers = new Dictionary<Button, EventHandler>();
        //(different Buttons) key is unique and EventHandler is a delegate points to same method(not unique)

        List<int[]> winningCombos;
        public int emptySpots;
        int player_score;
        int computer_score;

        public int Player_score { get => player_score; set => player_score = value; }
        public int Computer_score { get => computer_score; set => computer_score = value; }
              

        public Button RandomComputerChoice()
        {
            Random a = new Random();
            int randomChoice = a.Next(0, 8);
            Button computerChosenBtn = btns[randomChoice];

            while (computerChosenBtn.Text != "") { 
                //computerChosenBtn = btns[4] /*middle spot*/ ;
                randomChoice = a.Next(0, 8);
                computerChosenBtn = btns[randomChoice];
            }
            return computerChosenBtn;
        }

        private void play_a_turn(object sender, EventArgs e)
        {
            
            Button btn = sender as Button;//cast sender as button if btn is anything else than button null is used
            if(isComputerTurn==false) //player always X
            {
                btn.ForeColor = System.Drawing.Color.Red;
                btn.Text = "X";
                btn.Click -= btns_evt_handlers[btn];
                emptySpots--;
                
                isComputerTurn = !isComputerTurn;

                if (emptySpots > 0)
                {
                    btn = RandomComputerChoice();
                    btn.Invoke(btns_evt_handlers[btn]);
                }

            }
            else //computer's turn
            {

                btn.ForeColor = System.Drawing.Color.Lime;
                btn.Text = "O";
                btn.Click -= btns_evt_handlers[btn];
                emptySpots--;

                isComputerTurn = !isComputerTurn;

               
                // btn.Enabled = false;
                //isComputerTurn = true;
            }
           // isComputerTurn = !isComputerTurn;//not boolean of computer's turn

            // a play has been made

            bool player_won = false;
            bool computer_won = false;
            foreach (int[] winningCombo in winningCombos)
            {
                int Index1 = winningCombo[0];
                int Index2 = winningCombo[1];
                int Index3 = winningCombo[2];
                if (btns[Index1].Text == "X" && btns[Index2].Text == "X" && btns[Index3].Text == "X")
                {
                    Console.WriteLine("Player won ! " + Index1 + Index2 + Index3);
                    player_won = true;
                    break;
                }
            }

            if ( !player_won)
            {

                foreach (int[] winningCombo in winningCombos)
                {
                    int Index1 = winningCombo[0];
                    int Index2 = winningCombo[1];
                    int Index3 = winningCombo[2];
                    if (btns[Index1].Text == "O" && btns[Index2].Text == "O" && btns[Index3].Text == "O")
                    {
                        Console.WriteLine("Computer won ! " + Index1 + Index2 + Index3);
                        computer_won = true;
                        break;
                    }
                }
            }

            if(player_won)
            {
                Player_score++;
                MessageBox.Show("Player Won !");
                player1ScoreTxt.Text = "" + Player_score;

                clear_board();
            }else if (computer_won)
            {
                 
                computer_score++;
                MessageBox.Show("Computer Won !");
                player2ScoreTxt.Text = "" + computer_score;

                clear_board();
            }else if(emptySpots == 0)
            {

                MessageBox.Show("A Draw !");
                clear_board();
            }

        }

        private void clear_board()
        {
            this.tableLayoutPanel1.Controls.Clear();
            emptySpots = 9;
            isComputerTurn = false;


            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    int i = r * 3 + c;
                    btns[i] = new Button();
                    btns[i].Text = "";

                    btns[i].AutoSize = true;
                    btns[i].Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btns[i].Location = new System.Drawing.Point(330, 3);
                    btns[i].Size = new System.Drawing.Size(321, 243);
                    btns[i].TabIndex = 1 + i;
                    btns[i].UseVisualStyleBackColor = true;

                    btns_evt_handlers[btns[i]] = new System.EventHandler(this.play_a_turn);
                    btns[i].Click += btns_evt_handlers[btns[i]];
                    this.tableLayoutPanel1.Controls.Add(this.btns[i], r, c);
                }
            }
        }


        public GameScreen()
        {
            btns = new Button[9];

            winningCombos = new List<int[]>();
            winningCombos.Add(new int[] { 0, 1, 2 }); //012 - 1
            winningCombos.Add(new int[] { 3, 4, 5 }); //345 - 2
            winningCombos.Add(new int[] { 6, 7, 8 }); //678 - 3
            winningCombos.Add(new int[] { 0, 3, 6 }); //036 - 4
            winningCombos.Add(new int[] { 1, 4, 7 }); //147 - 5
            winningCombos.Add(new int[] { 2, 5, 8 }); //258 - 6
            winningCombos.Add(new int[] { 0, 4, 8 }); //048 - 7
            winningCombos.Add(new int[] { 2, 4, 6 }); //246 - 8 (there should be 8

            Player_score = 0;
            computer_score = 0;

            // can put buttons in array
            //Initialize UI
            InitializeComponent();
            
            this.tableLayoutPanel1.Controls.Clear();

            player1ScoreTxt.Text = "0";
            player2ScoreTxt.Text = "0";

            clear_board();
            
            //Start the Game

           
            //array avoids this
            //this.btn1.Text = "";
            //this.btn2.Text = "";
            //this.btn3.Text = "";
            //this.btn4.Text = "";
            //this.btn5.Text = "";
            //this.btn6.Text = "";
            //this.btn7.Text = "";
            //this.btn8.Text = "";
            //this.btn9.Text = "";

            //Boolean keepPlaying = true;
            //while (keepPlaying)
            //{
            //    // clear all boxes..
            //    // reset color to black

            //    //check for winners /losers
            //    //keep track of score
            //    keepPlaying = false;

            //}
            //Console.WriteLine("Thank you for playing");
        }
        
    }
}
