using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Players
{
    public class UserPlayer : Player
    {
        private string alfa = "ABCDEFGHIJ";
        private List<string> _hitPlaces;
        public override string MakeShot()
        {
            bool valueIsProper;
            string target;
            do
            {
                target = ReadTarget();

                var collumnName = target[0].ToString();

                int.TryParse(target.Substring(1, target.Length), out int rowNumber);

                valueIsProper = RowNameIsProper(rowNumber) && CollumnNameIsProper(collumnName);
                if (!valueIsProper) Console.WriteLine("Nieprawidłowe pole");
            } while (valueIsProper);

            return target;
        }

        private string ReadTarget()
        {
            Console.WriteLine("Podaj cel");
            return Console.ReadLine();
        }

        private bool RowNameIsProper(int rowNumber)
        {
            return rowNumber <= 10 && rowNumber > 0;
        }

        private bool CollumnNameIsProper(string target)
        {
            return alfa.Contains(target);
        }

        public override bool GetShot(string target)
        {
            throw new NotImplementedException();
        }

        public override void MarkAsHit(string target)
        {

            throw new NotImplementedException();
        }
    }
}
