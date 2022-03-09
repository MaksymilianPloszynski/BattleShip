using BattleShip.Library.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Helpers.Print
{
    public class ConsolePrinter : IBattlefieldPrinter
    {
        private const string _letters = "ABCDEFGHIJ";
        public void Print(Field[,] battlefield)
        {
            Console.Write("  ");
            foreach (var character in _letters)
            {
                Console.Write(" ");
                Console.Write(character);
                Console.Write(" ");
            }
            Console.WriteLine();

            for (int i = 0; i < battlefield.GetLength(0); i++)
            {
                int rowNumber = i + 1;
                if (rowNumber < 10)
                    Console.Write($" {rowNumber}");
                else
                    Console.Write(rowNumber);

                for (int j = 0; j < battlefield.GetLength(1); j++)
                {
                    var field = battlefield[i, j];
                    Console.Write(field);
                }
                Console.WriteLine();
            }
        }
    }
}
