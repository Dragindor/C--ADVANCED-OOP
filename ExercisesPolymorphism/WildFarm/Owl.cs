using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingsize) : base(name, weight, foodEaten, wingsize)
        {
        }
        public void Sound()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override void Eat(string type, int quantity)
        {
            if (type.ToLower() == "meat")
            {
                Weight += 0.25 * quantity;
                FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"Owl does not eat {type}!");
            }
        }
        public override string ToString()
        {
            return $"{typeof(Owl).Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}