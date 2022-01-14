using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            bool stop = true;
            string[] pizzaName = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Pizza pizza = null;
            try
            {
                if (pizzaName.Length==1)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    stop = false;
                }
                else
                {
                    pizza = new Pizza(pizzaName[1]);
                } 
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
                stop = false;
            }
            if (stop)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Dought dought = new Dought(line[1], line[2], double.Parse(line[3]));
                    double result = dought.DoughCallories();
                    pizza.Callories += result;
                    pizza.dought = dought;
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    stop = false;
                }
                while (stop)
                {
                    string[] lines = Console.ReadLine().Split();
                    if (lines[0] == "END")
                    {
                        if (pizza.toppings.Count == 0)
                        {
                            Console.WriteLine("Number of toppings should be in range [0..10].");
                            stop = false;
                        }
                        break;
                    }
                    try
                    {
                        string type = lines[1];
                        Topping topping = new Topping(type, double.Parse(lines[2]));
                        double result = topping.ToppingCallories();
                        pizza.AddToppings(topping);
                        pizza.Callories += result;


                    }
                    catch (ArgumentException ae)
                    {

                        Console.WriteLine(ae.Message);
                        stop = false;
                    }



                }
            }
            
            if (stop)
            {
                Console.WriteLine($"{pizza.name} - {pizza.Callories:f02} Calories.");
            }
            
        }
    }
}
