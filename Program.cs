using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;

            int screenWidth = Console.WindowWidth;
            int screenHeight = Console.WindowHeight;

            Game game = new Game(screenWidth, screenHeight);
            game.Run();
        }
    }
}