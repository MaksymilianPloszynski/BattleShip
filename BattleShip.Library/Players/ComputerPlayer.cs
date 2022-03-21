using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Players
{
    public class ComputerPlayer : Player
    {
        private string _collumns = "ABCDEFGHIJ";

        public override bool GetShot(string target)
        {
            throw new NotImplementedException();
        }

        public override string MakeShot()
        {
            throw new NotImplementedException();
        }

        public override void MarkAsHit(string target)
        {
            throw new NotImplementedException();
        }
    }
}
