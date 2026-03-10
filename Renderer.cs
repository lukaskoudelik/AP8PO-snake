using System;

namespace Snake
{
    class Renderer
    {
        private const string PixelSymbol = "■";

        private int screenWidth;
        private int screenHeight;

        public Renderer(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public void DrawBorders()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0); Console.Write(PixelSymbol);
                Console.SetCursorPosition(i, screenHeight - 1); Console.Write(PixelSymbol);
            }

            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i); Console.Write(PixelSymbol);
                Console.SetCursorPosition(screenWidth - 1, i); Console.Write(PixelSymbol);
            }
        }

        public void DrawSnake(Snake snake)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var segment in snake.GetBody())
            {
                Console.SetCursorPosition(segment.X, segment.Y);
                Console.Write(PixelSymbol);
            }

            Console.ForegroundColor = snake.Head.Color;
            Console.SetCursorPosition(snake.Head.X, snake.Head.Y);
            Console.Write(PixelSymbol);
        }

        public void DrawBerry(Berry berry)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(berry.X, berry.Y);
            Console.Write(PixelSymbol);
        }

        public void ShowGameOver(int score)
        {
            Console.Clear();
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: " + score);
        }
    }
}