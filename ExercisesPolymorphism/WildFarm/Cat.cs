using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }
        public void Sound()
        {
            Console.WriteLine("Meow");
        }
        public override void Eat(string type,int quantity)
        {
            if (type.ToLower()=="vegetable" || type.ToLower() == "meat")
            {
                Weight += 0.30 * quantity;
                FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"Cat does not eat {type}!");
            }
        }
        public override string ToString()
        {
            return $"{typeof(Cat).Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }

}