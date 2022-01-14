using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get;   set; }
        public double Weight { get;  set; }
        public int FoodEaten { get;  set; }
        public virtual void Eat(string type, int quantity)
        {
            
        }
    }
}
