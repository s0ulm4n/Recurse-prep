using System.Drawing;

namespace Recurse_prep;

class Program
{
    static void Main(string[] args)
    {
        // .....
        // ..#..
        // .###.
        // ..#..
        // .....
        Game game = new Game(5, 5, new Point[] {
            new Point {X = 2, Y = 2},
            new Point {X = 3, Y = 2},
            new Point {X = 1, Y = 2},
            new Point {X = 2, Y = 3},
            new Point {X = 2, Y = 1},
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
