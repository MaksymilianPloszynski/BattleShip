using BattleShip.Library.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Players
{
    public abstract class Player : IPlayer
    {
        public string Name { get; }
        public IBattlefield Board { get; }
        public IFiringBoard FiringBoard { get; }
        public abstract bool GetShot(string target);
        public abstract string MakeShot();
        public abstract void MarkAsHit(string target);
    }

}
