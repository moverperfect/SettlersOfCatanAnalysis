using System;
using SettlersOfCatanAnalysis.Objects;

namespace SettlersOfCatanAnalysis
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this Analysis of Settlers of Catan");
            Console.WriteLine("Written in C# By Jack Moorhouse advised by Eleanor Partington");

            var game = new Game(true);
            game.Start();
        }
    }
}