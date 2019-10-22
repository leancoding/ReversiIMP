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
        GameCore c;
        private bool player1Turn;

        private bool gameEnded;
        int redStones;
        int blueStones; 


        ReversiForm()
        {
            ClientSize = new Size();
            this.Text = "Reversi";

            c = new GameCore(); 

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

            GroupBox board = new GroupBox();

            PictureBox[,] tiles = new PictureBox[6, 6];

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            // c.PossibleMoves(); 
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            c.NewGame();
            Invalidate();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            /*
             * Wanneer de speler op een vak klikt, moeten de volgende gebeurtenissen plaatsvinden:
             * * Is het spel afgelopen?
             * 1.	Controleer of de zet correct is: IsValidMove()
             * 2.	Verander kleur van vak: board.SetTileValue(p, color)
             * 3.	Verander stenen die omringd zijn: flipStones(point, cp, op)
             * 4.	Verander beurt 
             * 5.	Controleer of andere partij een zet kan maken, zo niet verander terug: HasMoves(cp)
             * 6.	Controleer of het spel is afgelopen GameFinished()
             * 7.	Werk scores bij
            */

            /*
            if (c.GameFinished())
            {
                MessageBox.Show("The game has ended");
                return;
            } */

            // Kopie maken van knop, om er achter te komen wie Button_Click heeft aangeroepen. 
            Button button = (Button)sender;

            //// Afhankelijk van huidige speler, geef vak een waarde
            //results[index] = player1Turn ? Player1.Tile : Player2.;

            //// Zorg er voor dat de PictureBox ook desbetreffende kleur krijgt


            // Verandert hem telkens om de beurt
            player1Turn ^= true; // player1Turn = !player1Turn; 
        }

        private void updateCounts()
        {

        }



    }
}
