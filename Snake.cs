using System;
using System.Collections.Generic;

namespace Snake
{
    class Snake
    {
        public SnakeSegment Head { get; private set; }
        private List<SnakeSegment> body = new List<SnakeSegment>();
        private int screenWidth;
        private int screenHeight;
        private int length = 5;

        public Snake(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            Head = new SnakeSegment(screenWidth / 2, screenHeight / 2, ConsoleColor.Red);
        }

        public void Move(Direction direction)
        {
            body.Add(new SnakeSegment(Head.X, Head.Y, ConsoleColor.Green));

            switch (direction)
            {
                case Direction.Up: Head.Y--; break;
                case Direction.Down: Head.Y++; break;
                case Direction.Left: Head.X--; break;
                case Direction.Right: Head.X++; break;
            }

            if (body.Count > length)
            {
                body.RemoveAt(0);
            }

        }

        public bool EatBerry(Berry berry)
        {
            if (Head.X == berry.X && Head.Y == berry.Y)
            {
                length++;
                return true;
            }
            return false;
        }

        public List<SnakeSegment> GetBody()
        {
            return body;
        }
    }
}