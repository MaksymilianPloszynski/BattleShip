using BattleShip.Library.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Fields
{
    public class Field
    {
        private string emptyField = "| |";
        private string fieldWithShip = "|O|";
        private string fieldWithHitSHip = "|X|";
        private string fieldHitWhitoutSHip = "|+|";
        public bool HasBeenHit { get; private set; }
        public Ship Ship { get; private set; }
        public Field()
        {

        }
        public Field(Ship ship)
        {
            Ship = ship;
        }

        public void Hit()
        {
            HasBeenHit = true;
            if (Ship != null)
            {
                Ship.Hit();
            }
        }

        public override string ToString()
        {
            if (Ship == null && HasBeenHit) return fieldHitWhitoutSHip;
            if (Ship != null && !HasBeenHit) return fieldWithShip;
            if (Ship != null && HasBeenHit) return fieldWithHitSHip;
            return emptyField;
        }
    }
}
