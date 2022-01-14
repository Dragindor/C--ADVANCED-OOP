using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        public string type;

        public double weight;
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public Topping(string type, double weight)
        {
            Type = type;

            Weight = weight;
        }
        public double ToppingCallories()
        {
            double typeCallories = 0;
            
            if (Type.ToLower() == "meat")
            {
                typeCallories = 1.2;
            }
            else if (Type.ToLower() == "veggies")
            {
                typeCallories = 0.8;
            }
            else if (Type.ToLower() == "cheese")
            {
                typeCallories = 1.1;
            }
            else if (Type.ToLower()  == "sauce")
            {
                typeCallories = 0.9;
            }

            return typeCallories  * weight * 2;
        }
    }
}
