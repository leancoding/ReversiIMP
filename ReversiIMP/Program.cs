using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ReversiIMP
{
    class Program
    {
        #region testMethods

        static void showBoard(Board b)
        {
            String res = " ";
            for (int i = 0; i < b.BoardSize; i++) res += i.ToString();
            res += "\n"; 

            for (int i = 0; i < b.BoardSize; i++)
            {
                res += i.ToString();
                for (int j = 0; j < b.BoardSize; j++)
                {
                    if (b.Matrix[j, i] == Tile.Empty)
                        res += "-";
                    else
                        res += b.Matrix[j, i] == Tile.Blue ? "*" : "O";
                }
                res += "\n";
            }
            Console.WriteLine(res);
        }


        #endregion
        static void Main(string[] args)
        {

            // Testen van de classes
            Board test = new Board();
            Console.WriteLine(test.Matrix[2, 2]);

            Board testBCopy = new Board(test);
            Console.WriteLine(testBCopy.Matrix[3, 4]);

            // Kijken of variabelen niet mee veranderen
            // test.Matrix[3, 4] = Tile.Blue;
            Console.WriteLine(test.Matrix[2, 4]);
            Console.WriteLine(testBCopy.Matrix[3, 4]);

            // Bord laten zien
            // (3,4) is niet veranderd :)
            showBoard(test);
            showBoard(testBCopy);

            // Checken of een zet mogelijk is?
            GameCore core = new GameCore();
            core.NewGame();

            Console.WriteLine("IsInbounds (3,4) " + core.IsInBounds(new Point(3, 4)));

            Console.WriteLine("Check (2,4) " + core.IsValidMove(new Point(2, 4), test.Matrix, Tile.Blue, Tile.Red) + "\n") ;

            // Alle mogelijke posities
            Point[] temp = core.PossibleMoves(test.Matrix, Tile.Red, Tile.Blue);
            Console.WriteLine(temp.Length); 
            foreach (Point p in temp)
                 Console.WriteLine(p.X + " " + p.Y);

            // Game finished?
            Console.WriteLine("Is het spel afgelopen: " + core.GameFinished(test.Matrix));

            // Flipping stones, klinkt als een liedje
            test.Matrix[1, 3] = Tile.Blue;
            core.FlipStones(new Point(1, 3), test.Matrix, Tile.Blue, Tile.Red);
            showBoard(test);

            test.Matrix[1,4] = Tile.Red;
            core.FlipStones(new Point(1, 4), test.Matrix, Tile.Red, Tile.Blue);
            showBoard(test);

            test.Matrix[2, 4] = Tile.Blue;
            core.FlipStones(new Point(2, 4), test.Matrix, Tile.Blue, Tile.Red);
            showBoard(test);

            test.Matrix[1, 2] = Tile.Red;
            core.FlipStones(new Point(1, 2), test.Matrix, Tile.Red, Tile.Blue);

            showBoard(test);

            // Dit klopt dus helaas niet.. 
            /*  012345
                0------
                1------
                2-OOO--
                3-OO*--
                4-O*---
                5------
                */
            Console.ReadLine();

        }

        
    }
}
