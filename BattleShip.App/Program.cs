﻿using BattleShip.Library.Fields;
using BattleShip.Library.Helpers.PlaceShips;
using BattleShip.Library.Helpers.Position;
using BattleShip.Library.Helpers.Print;
using BattleShip.Library.Ships;
using System;

namespace BattleShip.App
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IShipPlacer shipPlacer = new ShipPlacer();
            IPositionConverter  positionConverter = new PositionConverter();
            var field = new Battlefield(shipPlacer, positionConverter);

            field.AddShip(new Destroyer());
            field.AddShip(new Destroyer());
            field.AddShip(new Destroyer());
            field.AddShip(new Destroyer());
            field.AddShip(new Battleship());
            //sdsds

            field.PrepareField();

            var printer = new ConsolePrinter();



            field.GetHit("A", 1);
            field.GetHit("B", 1);
            field.GetHit("C", 1);
            field.GetHit("D", 1);
            field.GetHit("E", 1);
            field.GetHit("F", 1);
            field.GetHit("G", 1);
            field.GetHit("H", 1);
            field.GetHit("I", 1);

            printer.Print(field);


            Console.ReadKey();
        }
    }
}
