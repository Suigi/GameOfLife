using System;
using System.Linq;
using GameOfLife.HorribleOutsideWorld;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var stable = false;
            var game =
                new GameSeeder(RandomNumbers.FromSeed(new Random().Next()), 0.2).Create(40, 40);
            var printer = new GamePrinter();
            while (!stable)
            {
                Console.Clear();
                Console.Write(printer.Print(game));
                var aliveCellsBefore = game.AliveCells.ToList();
                game = game.Next();
                var aliveCellsAfter = game.AliveCells.ToList();

                if (!aliveCellsAfter.Except(aliveCellsBefore).Any())
                {
                    stable = true;
                }
                
                Console.ReadLine();
            }

            Console.WriteLine(
                game.AliveCells.Any()
                    ? "Game is stable"
                    : "They are all gone :("
            );
        }
    }
}