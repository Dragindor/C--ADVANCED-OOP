using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingsize) 
            : base(name, weight, foodEaten, wingsize)
        {
        }
        public void Sound()
        {
            Console.WriteLine("Cluck");
        }
        public override void Eat(string type, int quantity)
        {
            Weight += 0.35 * quantity;
            FoodEaten += quantity;
        }
        public override string ToString()
        {
            return $"{typeof(Hen).Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}