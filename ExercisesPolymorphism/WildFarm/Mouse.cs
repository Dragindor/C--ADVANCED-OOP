using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }
        public void Sound()
        {
            Console.WriteLine("Squeak");
        }
        public override void Eat(string type, int quantity)
        {
            if (type.ToLower() == "vegetable" || type.ToLower() == "fruit")
            {
                Weight += 0.10 * quantity;
                FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"Mouse does not eat {type}!");
            }
        }
        public override string ToString()
        {
            return $"{typeof(Mouse).Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}