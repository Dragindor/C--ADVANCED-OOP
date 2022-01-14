using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        public List<Topping> toppings;
        int max = 10;

        public Dought dought { get; set; }
        public double Callories { get; set; }

        public string name;
        public string Name 
        { 
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length<1 || value.Length>15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }
        public void AddToppings(Topping topping)
        {
            if (max>toppings.Count)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
        
    }
}
