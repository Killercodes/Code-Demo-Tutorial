using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleInheritanceDemo
{
    interface IHouse
    {
    }

    interface IBoat
    {
    }

    class HouseBoat : IHouse, IBoat
    {
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            HouseBoat o = new HouseBoat();
            o.HoldHouseParty();
            o.DoBoatRace();
        }
    }

    static class MyExtensions
    {
        public static void HoldHouseParty(this IHouse house)
        {
            Console.WriteLine("Holding house party...");
        }

        public static void DoBoatRace(this IBoat boat)
        {
            Console.WriteLine("Doing a boat race...");
        }
    }
}
