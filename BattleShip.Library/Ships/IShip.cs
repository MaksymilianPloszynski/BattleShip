namespace BattleShip.Library.Ships
{
    public interface IShip
    {
        int Hits { get; }
        string Name { get; }
        int Width { get; }

        void Hit();
        bool IsSunk();
    }
}