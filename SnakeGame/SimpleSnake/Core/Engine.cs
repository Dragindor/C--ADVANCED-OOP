using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointOfDirection;
        private Direction direction;
        private Snake snake;
        private double sleepTime;
        private Wall wall;

        public Engine(Wall wall,Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;
            this.pointOfDirection = new Point[4];
        }
        public void Run()
        {
            this.CreateDireaction();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(this.pointOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX+2;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");
            Console.SetCursorPosition(leftX+8, topY+1);
            ConsoleKeyInfo input = Console.ReadKey();
            

            if ((Char.ToLower(input.KeyChar)) == 'y')
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20,10);

            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void CreateDireaction()
        {
            this.pointOfDirection[0] = new Point (1,0); //right
            this.pointOfDirection[1] = new Point (-1,0);//left
            this.pointOfDirection[2] = new Point (0,1); //up
            this.pointOfDirection[3] = new Point (0,-1);//down
        }
        private void GetNextDirection()
        {
            ConsoleKeyInfo userInpit = Console.ReadKey();
            if (userInpit.Key==ConsoleKey.LeftArrow)
            {
                if (direction !=Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInpit.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInpit.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInpit.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            Console.CursorVisible = false;
        }

    }
}
