using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion, breed)
        {
        }
        public void Sound()
        {
            Console.WriteLine("ROAR!!!");
        }
        public override void Eat(string type, int quantity)
        {
            if (type.ToLower() == "meat")
            {
                Weight += 1.00 * quantity;
                FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"Tiger does not eat {type}!");
            }
        }
        public override string ToString()
        {
            return $"{typeof(Tiger).Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}