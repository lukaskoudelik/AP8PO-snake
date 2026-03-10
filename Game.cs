using System;

namespace Snake
{
    class Game
    {
        private int screenWidth;
        private int screenHeight;
        private Snake snake;
        private Berry berry;
        private Renderer renderer;
        private InputHandler inputHandler;
        private int score = 0;
        private bool isGameOver = false;

        public Game(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            snake = new Snake(screenWidth, screenHeight);
            berry = new Berry(screenWidth, screenHeight, snake);
            renderer = new Renderer(screenWidth, screenHeight);
            inputHandler = new InputHandler();
        }

        public void Run()
        {
            Direction currentDirection = Direction.Right;

            while (!isGameOver)
            {
                currentDirection = inputHandler.GetNewDirection(currentDirection);

                snake.Move(currentDirection);

                if (snake.EatBerry(berry))
                {
                    score++;
                    berry.RespawnBerry(snake);
                }

                CheckWallCollision();
                CheckSelfCollision();

                Console.Clear();
                renderer.DrawBorders();
                renderer.DrawBerry(berry);
                renderer.DrawSnake(snake);

                System.Threading.Thread.Sleep(500);
            }

            renderer.ShowGameOver(score);
        }

        private void CheckWallCollision()
        {
            var head = snake.Head;
            if (head.X == 0 || head.X == screenWidth - 1 ||
                head.Y == 0 || head.Y == screenHeight - 1)
            {
                isGameOver = true;
            }
        }

        private void CheckSelfCollision()
        {
            foreach (var segment in snake.GetBody())
            {
                if (segment.X == snake.Head.X && segment.Y == snake.Head.Y)
                {
                    isGameOver = true;
                }
            }
        }
    }
}