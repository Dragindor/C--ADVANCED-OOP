using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;

        private int nextLeftX;
        private int nextTopY;
        private const char snakeSymbol='\u25CF';
        private int foodIndex;
        private const char emptySpace=' ';

        private int RandomFoodNumber=>new Random().Next(0,this.foods.Length);

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            this.foodIndex = RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            GetNextPoint(direction,currentSnakeHead);

            bool IsPointOfSnake = this.snakeElements
                .Any(x=>x.LeftX==nextLeftX && x.TopY==nextTopY);
            if (IsPointOfSnake)
            {
                return false;
            }
            Point snakeNewHead = new Point(this.nextLeftX,this.nextTopY);
            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }
            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);
            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction,currentSnakeHead);

            }
            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);
            return true;
        }
        private void Eat(Point direction,Point currentSnakeHead)
        {
            int length = this.foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(this.nextLeftX,this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }
            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
            
        }
        private void CreateSnake()
        {
            for (int topY = 1; topY <=6 ; topY++)
            {
                this.snakeElements.Enqueue(new Point(2,topY));
            }
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }
        private void GetFoods()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);
        }
        private void GetNextPoint(Point direction,Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
        
    }
}
