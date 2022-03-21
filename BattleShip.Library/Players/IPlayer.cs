using BattleShip.Library.Fields;

namespace BattleShip.Library.Players
{
    public interface IPlayer
    {
        IBattlefield Board { get; }
        IFiringBoard FiringBoard { get; }
        string Name { get; }
        string MakeShot();
        bool GetShot(string target);
        void MarkAsHit(string target);
    }
}