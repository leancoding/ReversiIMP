using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ReversiIMP
{
    /// <summary>
    /// Class om de spel logica te kunnen verwerken
    /// </summary>
    class GameCore
    {
        #region members
        private Board board;
        private Board backupBoard; 
        private int boardSize;
        private Player[] players;

        #endregion

        public void NewGame()
        {
            board = new Board();
            boardSize = board.BoardSize;
        }

        public void ShowBoard()
        {
            String res = " ";
            for (int i = 0; i < boardSize; i++) res += i.ToString();
            res += "\n";

            for (int i = 0; i < boardSize; i++)
            {
                res += i.ToString();
                for (int j = 0; j < boardSize; j++)
                {
                    if (board.RetrieveTileValue(j,i) == Tile.Empty)
                        res += "-";
                    else
                        res += board.RetrieveTileValue(j,i) == Tile.Blue ? "*" : "O";
                }
                res += "\n";
            }
            Console.WriteLine(res);
        }
        
        public int Boardsize
        {
            get 
            {
                return boardSize;
            }

        }

        public bool IsInBounds(Point p)
        {
            if (p.X >= 0 && p.X < boardSize && p.Y >= 0 && p.Y < boardSize)
            {
                // Console.WriteLine(p.X + " " + p.Y);
                return true;
            }
            return false;
        }

        /*
         * Werkwijze:
         * Kijk voor alle richtingen [-1,1] en [-1,1] in respectievelijk x en y richting
         * Begin loop die alle richtingen op gaat: 
         * 1. Maak nieuw tijdelijk Point aan in de richting van (i,j) 
         * 2. Check of inBounds en vak niet van speler zelf is of leeg, anders -> continue; 
         * 2. While loop zolang inBounds, zo niet -> return false; 
         *         1. Is het Tile.Empty ? -> break; 
         *         2. Andere speler? Ga richting (i,j) en vervolg
         *         3. CurrentPlayer? return true; 
         */
                  
        public bool IsValidMove(Point p, Tile cp, Tile op)
        {
            // Console.WriteLine("Searching tiles around " + p.X + " " + p.Y); 
            for (int i = - 1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {

                    Point temp = new Point(p.X + i, p.Y + j);
                    // Console.WriteLine(temp.X + " " + temp.Y);
                    // Console.WriteLine(IsInBounds(temp)); 

                    if (IsInBounds(temp))
                        if (board.RetrieveTileValue(temp) == Tile.Empty || board.RetrieveTileValue(temp) == cp)
                            continue;

                    while(IsInBounds(temp))
                    {
                        if (board.RetrieveTileValue(temp) == Tile.Empty)
                            break;

                        if (board.RetrieveTileValue(temp) == op)
                        {
                            temp.X += i; temp.Y += j;
                            continue;
                        }

                        if (board.RetrieveTileValue(temp) == cp)
                            return true;
                    }
                }
            return false;
        }


        // Wordt aangeroepen indien de gebruiker op Help drukt
        public Point[] PossibleMoves(Tile cp, Tile op)
        {
            List<Point> possiblePoints = new List<Point>();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Point tempPoint = new Point(i, j);
                    if (board.RetrieveTileValue(tempPoint) == Tile.Empty)
                        if (IsValidMove(tempPoint, cp, op))
                            possiblePoints.Add(tempPoint);
                }
            }
            return possiblePoints.ToArray();
        }

        public void FlipStones(Point p, Tile cp, Tile op)
        {
            // Dit moet makkelijker kunnen, is namelijk gewoon een directe kopie van isValidMove
            Console.WriteLine("Flipping stones around " + p.X + " " + p.Y);
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    Point temp = new Point(p.X + i, p.Y + j);

                    if (IsInBounds(temp))
                        if (board.RetrieveTileValue(temp) == Tile.Empty || board.RetrieveTileValue(temp) == cp)
                            continue;

                    while (IsInBounds(temp))
                    {
                        if (board.RetrieveTileValue(temp) == Tile.Empty)
                            break;

                        if (board.RetrieveTileValue(temp) == op)
                        {
                            temp.X += i; temp.Y += j;
                            continue;
                        }

                        if (board.RetrieveTileValue(temp) == cp)
                        {
                            while (temp != p)
                            {
                                board.SetTileValue(temp, cp);
                                temp.X -= i; temp.Y -= j;
                                Console.WriteLine("Changing tile" + temp.X + temp.Y);
                            }
                            break;
                        }
                    }
                }
        }

        // Controleert of speler nog een zet kan doen
        public bool HasMovesLeft(Tile cp, Tile op)
        {
            if (PossibleMoves(cp, op).Length > 0)
                return true;

            return false;
        }

        // Is het spel afgelopen?
        public bool GameFinished
        {
            get
            {
                if (PossibleMoves(Tile.Blue, Tile.Red).Length == 0 || PossibleMoves(Tile.Red, Tile.Blue).Length == 0)
                    return true;
                return false;
            }
        }

        public void MoveRecord()
        {
            Board b;
        }

        public void playerMadeMove(Point p, Tile cp, Tile op)
        {
            if(IsValidMove(p, cp, op))
            {
                board.SetTileValue(p, cp);
                FlipStones(p, cp, op);


                if (HasMovesLeft(op, cp)) ;
                    // verander beurt

            }
        }

    }
}