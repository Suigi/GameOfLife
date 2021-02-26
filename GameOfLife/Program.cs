using System;
using System.Linq;
using GameOfLife.HorribleOutsideWorld;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunInteractive();
            RunBig(1000, 100, 100);
        }

        private static void RunBig(int iterations = 1_000, int rows = 100, int columns = 100)
        {
            var stable = false;
            var game =
                new GameSeeder(RandomNumbers.FromSeed(new Random().Next()), 0.2).Create(
                    rows,
                    columns
                );
            var currentIteration = 0;
            while (!stable)
            {
                currentIteration++;
                if (currentIteration % 100 == 0)
                {
                    Console.WriteLine($"Current iteration: {currentIteration}, {game.AliveCells.Count()} cells alive.");
                }
                game = game.Next();
            }

            Console.WriteLine(
                $"Alive cells after {iterations} iterations: {game.AliveCells.Count()}"
            );
        }

        private static void RunInteractive()
        {
            var stable = false;
            var game = new GameSeeder(RandomNumbers.FromSeed(new Random().Next()), 0.2).Create(40, 40);
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