using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }
        public void Sound()
        {
            Console.WriteLine("Woof!");
        }
        public override void Eat(string type, int quantity)
        {
            if (type.ToLower() == "meat")
            {
                Weight += 0.40 * quantity;
                FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"Dog does not eat {type}!");
            }
        }
        public override string ToString()
        {
            return $"{typeof(Dog).Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}