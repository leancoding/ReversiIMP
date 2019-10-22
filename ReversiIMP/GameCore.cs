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

        private Board reversiBoard;
        private int boardSize;

        public void NewGame()
        {
            reversiBoard = new Board();
            boardSize = reversiBoard.BoardSize;
        }
        
        bool IsValidMoveRedundant(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            if (matrix[p.X, p.Y] != Tile.Empty)
                return false;

            // Controleren of er een steen van een andere kleur ergens om het punt zit
            // List geven van functies die alle zijden checkt en in een for loop stoppen, i.p.v. alles handmatig aanroepen?

            if (TileUp(p, matrix, cp, op) || TileUpRight(p, matrix, cp, op) || TileRight(p, matrix, cp, op) || TileDownRight(p, matrix, cp, op) || TileDown(p, matrix, cp, op) || TileDownLeft(p, matrix, cp, op) || TileLeft(p, matrix, cp, op) || TileUpLeft(p, matrix, cp, op))
                return true;

            return false;
        }

        #region TileLookupMethods
        //
        // PROBLEM SOLVED: Deze omslachtige methode niet meer nodig!! 
        // WERKTE UBERHAUPT NIET ZO
        //
        // Geen zin om dit telkens te moeten kopiëren, dus manier verzinnen waardoor hij meer vormen aan kan nemen. 
        // Nu maar volgens deze manier...
        /* 
         * Up: p.Y == 0; p.Y - 1, p.Y 
         * Up right: p.Y == 0; p.X - 1, p.Y - 1
         */

        public bool TileUp(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            // Indien het y-coördinaat 0 is, kan er niks boven bevinden
            if (p.Y == 0)
                return false;

            // Indien er een steen van de andere partij boven zit, controleer op een nabijgelegen eigen steen
            else if (matrix[p.X, p.Y - 1] == op)
            {
                for (int i = 1; p.Y - i >= 0; i++)
                {
                    if (matrix[p.X, p.Y - 1 - i] == cp)
                        return true;
                    else if (matrix[p.X, p.Y - 1 - i] == Tile.Empty)
                        return false;
                }
            }
            return false;
        }

        public bool TileUpRight(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            // Indien het y-coördinaat 0 is, kan er niks boven bevinden
            if (p.Y == 0 || p.X == boardSize - 1)
                return false;

            // Indien er een steen van de andere partij boven zit, controleer op een nabijgelegen eigen steen
            else if (matrix[p.X + 1, p.Y - 1] == op)
            {
                for (int i = 1; p.Y >= 0; i++)
                {
                    if (matrix[p.X + 1 + i, p.Y - 1 - i] == cp)
                        return true;
                    else if (matrix[p.X + 1 + i, p.Y - 1 - i] == Tile.Empty)
                        return false;
                }
            }
            return false;
        }

        public bool TileRight(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            // Indien e.g. 7, kan niks naast zitten
            if (p.X == boardSize - 1)
                return false;

            else if (matrix[p.X + 1, p.Y] == op)
            {
                for (int i = 1; p.X < boardSize; i++)
                {
                    if (matrix[p.X + 1 + i, p.Y] == cp)
                        return true;
                    else if (matrix[p.X + 1 + i, p.Y] == Tile.Empty)
                        return false;
                }
            }
            return false;
        }

        public bool TileDownRight(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            if (p.Y == boardSize - 1 || p.X == boardSize - 1)
                return false;

            else if (matrix[p.X + 1, p.Y + 1] == op)
            {
                for (int i = 1; p.X + 1 < boardSize; i++)
                {
                    if (matrix[p.X + 1 + i, p.Y + 1 + i] == cp)
                        return true;
                    else if (matrix[p.X + 1 + i, p.Y + 1 + i] == Tile.Empty)
                        return false;
                }
            }
            return false;
        }

        public bool TileDown(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            if (p.Y == boardSize - 1)
                return false;

            else if (matrix[p.X, p.Y + 1] == op)
            {
                for (int i = 1; p.Y + 1 < boardSize; i++)
                {
                    if (matrix[p.X, p.Y + 1 - i] == cp)
                        return true;
                    else if (matrix[p.X, p.Y + 1 - i] == Tile.Empty)
                        return false;
                }
            }
            return false;
        }

        public bool TileDownLeft(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            if (p.Y == boardSize - 1 || p.X == 0)
                return false;

            else if (matrix[p.X - 1, p.Y + 1] == op)
            {
                for (int i = 1; p.X - 1 >= 0; i++)
                {
                    if (matrix[p.X - 1 - i, p.Y + 1 + i] == cp)
                        return true;
                    else if (matrix[p.X - 1 + i, p.Y + 1 + i] == Tile.Empty)
                        return false;
                }
            }
            return false;
        }


        public bool TileLeft(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            if (p.X == 0)
                return false;

            else if (matrix[p.X - 1, p.Y] == op)
            {
                for (int i = 1; p.X >= 0; i++)
                {
                    if (matrix[p.X - 1 - i, p.Y] == cp)
                        return true;
                    else if (matrix[p.X - 1 - i, p.Y] == Tile.Empty)
                        return false;
                }
            }
            return false;
        }

        public bool TileUpLeft(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            if (p.Y == 0 || p.X == 0)
                return false;

            else if (matrix[p.X - 1, p.Y - 1] == op)
            {
                for (int i = 1; p.X >= 0; i++)
                {
                    if (matrix[p.X - 1 - i, p.Y - 1 - i] == cp)
                        return true;
                    else if (matrix[p.X - 1 - i, p.Y - 1 - i] == Tile.Empty)
                        return false;
                }
            }
            return false;
        }

        #endregion

        // Dit moet bovenstaande methoden opsommen en simplificeren
        // Snap niet waarom ik daar aan begon -.- 

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
         
        public bool IsValidMove(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            // Console.WriteLine("Searching tiles around " + p.X + " " + p.Y); 
            for (int i = - 1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {

                    Point temp = new Point(p.X + i, p.Y + j);
                    // Console.WriteLine(temp.X + " " + temp.Y);
                    // Console.WriteLine(IsInBounds(temp)); 

                    if (IsInBounds(temp))
                        if (matrix[temp.X, temp.Y] == Tile.Empty || matrix[temp.X, temp.Y] == cp)
                            continue;

                    while(IsInBounds(temp))
                    {
                        if (matrix[temp.X, temp.Y] == Tile.Empty)
                            // return false;
                            break;

                        if (matrix[temp.X, temp.Y] == op)
                        {
                            temp.X += i; temp.Y += j;
                            continue;
                        }

                        if (matrix[temp.X, temp.Y] == cp)
                            return true;
                    }
                }
            return false;
        }

        public void FlipStones(Point p, Tile[,] matrix, Tile cp, Tile op)
        {
            // Dit moet makkelijker kunnen, is namelijk gewoon een dIrecte kopie van isValidMove
            Console.WriteLine("Flipping stones around " + p.X + " " + p.Y); 
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    Point temp = new Point(p.X + i, p.Y + j);

                    if (IsInBounds(temp))
                        if (matrix[temp.X, temp.Y] == Tile.Empty || matrix[temp.X, temp.Y] == cp)
                            continue;

                    while (IsInBounds(temp))
                    {
                        if (matrix[temp.X, temp.Y] == Tile.Empty)
                            break;

                        if (matrix[temp.X, temp.Y] == op)
                        {
                            temp.X += i; temp.Y += j;
                            continue;
                        }

                        if (matrix[temp.X, temp.Y] == cp)
                        {
                            while(temp != p)
                            {
                                matrix[temp.X, temp.Y] = cp;
                                temp.X -= i; temp.Y -= j;
                                Console.WriteLine("Changing tile" + temp.X + temp.Y);
                            }
                            break;
                        }
                    }
                }
        }


        // Wordt aangeroepen indien de gebruiker op Help drukt
        // Deze werkte niet eens... 
        public Point[] PossibleMovesRedundant(Tile[,] matrix, Tile cp, Tile op)
        {
            List<Point> possiblePoints = new List<Point>();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Point tempPoint = new Point(i, j);
                    if (matrix[i, j] == Tile.Empty)
                        if (TileUp(tempPoint, matrix, cp, op) || TileUpRight(tempPoint, matrix, cp, op) || TileRight(tempPoint, matrix, cp, op) || TileDownRight(tempPoint, matrix, cp, op) || TileDown(tempPoint, matrix, cp, op) || TileDownLeft(tempPoint, matrix, cp, op) || TileLeft(tempPoint, matrix, cp, op) || TileUpLeft(tempPoint, matrix, cp, op))
                            possiblePoints.Add(tempPoint);
                }
            }
            return possiblePoints.ToArray();
        }


        // Wordt aangeroepen indien de gebruiker op Help drukt
        public Point[] PossibleMoves(Tile[,] matrix, Tile cp, Tile op)
        {
            List<Point> possiblePoints = new List<Point>();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Point tempPoint = new Point(i, j);
                    if (matrix[i,j] == Tile.Empty)
                        if (IsValidMove(tempPoint, matrix, cp, op))
                            possiblePoints.Add(tempPoint);
                }
            }
            return possiblePoints.ToArray();
        }

        // Controleert of speler nog een zet kan doen
        public bool HasMovesLeft(Tile[,] matrix, Tile cp, Tile op)
        {
            if (PossibleMoves(matrix, cp, op).Length > 0)
                return true;

            return false;
        }

        // TO-DO: Misschien hier een property van maken, heeft niks meer nodig dan de bord matrix
        // Is het spel afgelopen?
        public bool GameFinished(Tile[,] matrix)
        {
            if (PossibleMoves(matrix, Tile.Blue, Tile.Red).Length == 0 || PossibleMoves(matrix, Tile.Red, Tile.Blue).Length == 0)
                return true;

            return false;
        }

    }
}