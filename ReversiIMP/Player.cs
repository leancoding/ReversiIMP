using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiIMP
{
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
}
