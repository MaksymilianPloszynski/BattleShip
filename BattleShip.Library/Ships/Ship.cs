using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Ships
{
    public abstract class Ship : IShip
    {
        public string Name { get; protected set; }
        public int Width { get; protected set; }
        public int Hits { get; private set; }
        public bool IsSunk()
        {
            return Hits >= Width;
        }
        public void Hit()
        {
            Hits++;
        }
    }
}
