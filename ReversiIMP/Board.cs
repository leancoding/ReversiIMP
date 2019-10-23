using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiIMP
{
    public enum Tile
    {
        Empty = 0,
        Red = 1,
        Blue = -1
    }

    public class Player
    {
        String name;
        Tile color { get; }

        public Player(String n, Tile t)
        {
            name = n;
            color = t;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class Board
    {
        #region  Members

        const int BOARD_SIZE = 6;

        private Player currentPlayer; 
        private int redCount = 0;
        private int blueCount = 0;

        // Array om het bord te representeren
        private Tile[,] tileMatrix;

        #endregion

        #region Constructors

        public Board()
        {
            ResetBoard();
            // currentPlayer = ;
        }

        // Indien de speler wenst een stap terug te zetten, kan de vorige spelconfiguratie worden gebruikt

        public Board(Board b)
        {
            tileMatrix = new Tile[BOARD_SIZE, BOARD_SIZE];

            // Bord kopiëren van Board object
            for (int i = 0; i < BOARD_SIZE; i++)
                for (int j = 0; j < BOARD_SIZE; j++)
                    tileMatrix[i, j] = b.Matrix[i, j];

            redCount = b.redCount;
            blueCount = b.blueCount;

            currentPlayer = b.currentPlayer;

        }
        #endregion

        #region Properties
        public Tile[,] Matrix
        {
            get { return tileMatrix; }
        }

        public int BoardSize
        {
            get { return BOARD_SIZE; }
        }

        #endregion

        #region Methods
        // Twijfel wat later handiger is, points of row/column
        public Tile RetrieveTileValue(int row, int col)
        {
            return tileMatrix[row, col];
        }

        public Tile RetrieveTileValue(Point p)
        {
            return tileMatrix[p.X, p.Y];
        }

        public void SetTileValue(int row, int col, Tile t)
        {
            tileMatrix[row, col] = t;
        }

        public void SetTileValue(Point p, Tile t)
        {
            tileMatrix[p.X, p.Y] = t;
        }

        private void ResetBoard()
        {
            tileMatrix = new Tile[BOARD_SIZE, BOARD_SIZE];

            // Nieuw bord initialiseren
            tileMatrix[BOARD_SIZE / 2 - 1, BOARD_SIZE / 2 - 1] = Tile.Blue;
            tileMatrix[BOARD_SIZE / 2, BOARD_SIZE / 2] = Tile.Blue;
            tileMatrix[BOARD_SIZE / 2, BOARD_SIZE / 2 - 1] = Tile.Red;
            tileMatrix[BOARD_SIZE / 2 - 1, BOARD_SIZE / 2] = Tile.Red;
        }

        #endregion
    }
}
