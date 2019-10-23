using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReversiIMP
{
    class ReversiForm : Form
    {
        #region Members
        GameCore core;
        private List<Button> buttonList;
        private Panel board;

        private bool player1Turn;
        private bool gameEnded;
        
        int redStones;
        int blueStones;

        #endregion

        ReversiForm()
        {
            ClientSize = new Size();
            Text = "Reversi";
            StartPosition = FormStartPosition.CenterScreen;

            core = new GameCore(); 

            #region Buttons
            Button newGameBtn= new Button()
            {
                Text = "New Game",
                Size = new Size()
            };
            newGameBtn.Click += NewGameButton_Click;

            Button helpBtn = new Button()
            {
                Text = "Help",
                Size = new Size()
            };
            helpBtn.Click += HelpButton_Click;
            #endregion

            #region Labels

            Label redStonesLbl = new Label()
            {
                Text = redStones.ToString() + " stones"
            };

            Label blueStonesLbl = new Label()
            {
                Text = blueStones.ToString() + " stones"
            };

            Label nextPlayerLbl = new Label()
            {
                Text = "Next player is" // + nextPlayer
            };

            #endregion

            Controls.AddRange(new Control[]
            {
                newGameBtn,
                helpBtn,
                redStonesLbl,
                blueStonesLbl,
                nextPlayerLbl
            });

        }

        private void BoardCreator()
        {
            board = new Panel();
            buttonList = new List<Button>();
            for (int i = 0; i < core.Boardsize; i++)
            {
                for (int j = 0; j < core.Boardsize; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(40, 40);
                    btn.Location = new Point(i * 40, j * 40);
                    btn.Click += Button_Click;
                    buttonList.Add(btn);
                }
            }
            board.Controls.AddRange(buttonList.ToArray());
        }


        private void HelpButton_Click(object sender, EventArgs e)
        {
            // core.PossibleMoves(); 
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            core.NewGame();
            Invalidate();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            
            /*
             * Wanneer de speler op een vak klikt, moeten de volgende gebeurtenissen plaatsvinden:
             * 1.   Is het spel afgelopen?
             * 
             * In GameCore:
             * 1.	Controleer of de zet correct is: IsValidMove()
             * 2.	Verander kleur van vak: board.SetTileValue(p, color)
             * 3.	Verander stenen die omringd zijn: flipStones(point, cp, op)
             * 4.	Verander beurt 
             * 5.	Controleer of andere partij een zet kan maken, zo niet verander terug: HasMoves(cp)
             * 6.	Controleer of het spel is afgelopen GameFinished()
             * 7.	Werk scores bij: updateScores()
            */

            if (core.GameFinished)
            {
                MessageBox.Show("The game has ended");
                return;
            }
                       
            // Kopie maken van knop, om er achter te komen wie Button_Click heeft aangeroepen. 
            Button button = (Button)sender;
            int index = buttonList.IndexOf(button);

            Point newMove = new Point(index % core.Boardsize, index / core.Boardsize);

            core.playerMadeMove(newMove); 

            //// Afhankelijk van huidige speler, geef vak een waarde
            //results[index] = player1Turn ? Player1.Tile : Player2.;

            // Verandert hem telkens om de beurt
            player1Turn ^= true; // player1Turn = !player1Turn; 


        }

        private void UpdateCounts()
        {
            
        }




    }
}
