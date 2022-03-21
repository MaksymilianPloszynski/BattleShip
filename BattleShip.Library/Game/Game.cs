using BattleShip.Library.Helpers.Print;
using BattleShip.Library.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Game
{
    public class Game : IGame
    {
        private readonly IPlayer _user;
        private readonly IPlayer _computer;
        private readonly IBattlefieldPrinter _displayer;
        public Game(IPlayer user, IPlayer computer)
        {
            _user = user;
            _computer = computer;
        }
        public void Play()
        {
            IPlayer winner;
            do
            {
                string target = _user.MakeShot();
                if (_computer.GetShot(target)) _user.MarkAsHit(target);

                target = _computer.MakeShot();
                if (_user.GetShot(target)) _computer.MarkAsHit(target);

                ShowBoards();

                winner = GetWinner();

            } while (winner == null);


            Console.WriteLine($"The winner is {winner.Name}");

        }

        private void ShowBoards()
        {
            _displayer.Print(_user.Board);
            _displayer.Print(_user.FiringBoard);
        }

        private IPlayer GetWinner()
        {
            if (_computer.Board.AllShipsAreSunk()) return _user;
            if (_user.Board.AllShipsAreSunk()) return _computer;
            return null;
        }
    }
}
