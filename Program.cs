using System.Drawing;

namespace Recurse_prep;

class Program
{
    static void Main(string[] args)
    {
        //  Y
        // X 0123456789
        //  0..........
        //  1...#####..
        //  2...#...#..
        //  3.......#..
        //  4...#####..
        //  5..........
        //  6..........
        Game game = new Game(10, 7, new Point[] {
            new Point {X = 3, Y = 1},
            new Point {X = 4, Y = 1},
            new Point {X = 5, Y = 1},
            new Point {X = 6, Y = 1},
            new Point {X = 7, Y = 1},
            new Point {X = 3, Y = 2},
            new Point {X = 7, Y = 2},
            new Point {X = 7, Y = 3},
            new Point {X = 3, Y = 4},
            new Point {X = 4, Y = 4},
            new Point {X = 5, Y = 4},
            new Point {X = 6, Y = 4},
            new Point {X = 7, Y = 4},
            });

        while (true)
        {
            Console.Clear();

            game.Render();

            ConsoleKeyInfo input = Console.ReadKey();

            game.HandleInput(input.Key);
        }
    }
}
