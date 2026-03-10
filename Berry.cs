using System;

namespace Snake
{
    class Berry
    {
        private Random random = new Random();
        public int X { get; private set; }
        public int Y { get; private set; }

        private int screenWidth;
        private int screenHeight;

        public Berry(int screenWidth, int screenHeight, Snake snake)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            RespawnBerry(snake);
        }

        public void RespawnBerry(Snake snake)
        {
            while (true)
            {
                X = random.Next(1, screenWidth - 2);
                Y = random.Next(1, screenHeight - 2);

                if (snake == null || !IsOnSnake(snake))
                    break;
            }
        }

        private bool IsOnSnake(Snake snake)
        {
            if (snake.Head.X == X && snake.Head.Y == Y)
                return true;
            foreach (var segment in snake.GetBody())
                if (segment.X == X && segment.Y == Y)
                    return true;
            return false;
        }
    }
}