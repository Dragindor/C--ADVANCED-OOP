using System;
using System.Collections.Generic;

namespace ShoopingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool stop = true;
            List<Person> People = new List<Person>();
            List<Product> Products = new List<Product>();
            string[] people = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            
            string[] products = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < people.Length; i+=2)
            {
                try
                {
                    Person person = new Person(people[i],double.Parse(people[i+1]));
                    People.Add(person);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    stop = false;
                }
            }
            if (stop)
            {
                for (int i = 0; i < products.Length; i += 2)
                {
                    try
                    {
                        Product product = new Product(products[i], double.Parse(products[i + 1]));
                        Products.Add(product);
                    }
                    catch (ArgumentException ae)
                    {

                        Console.WriteLine(ae.Message);
                        stop = false;
                    }
                }
            }
            
            while (stop)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0]=="END")
                {
                    break;
                }
                string PersonName = command[0];
                string ProductName = command[1];
                Person buyer = People.Find(x => x.Name == PersonName);
                Product bought=Products.Find(x => x.Name == ProductName);
                if (buyer.CanBuy(buyer,bought))
                {
                    Console.WriteLine($"{buyer.name} bought {bought.name}");
                }
                else
                {
                    Console.WriteLine($"{buyer.name} can't afford {bought.name}");
                }
                
            }
            if (stop)
            {
                foreach (var item in People)
                {
                    Console.Write($"{item.Name} - ");
                    if (item.products.Count == 0)
                    {
                        Console.WriteLine("Nothing bought");
                    }
                    for (int i = 0; i < item.products.Count; i++)
                    {
                        if (i == item.products.Count - 1)
                        {
                            Console.Write($"{item.products[i].Name}");
                        }                                     
                        else                                  
                        {                                     
                            Console.Write($"{item.products[i].Name}, ");
                        }

                    }
                    Console.WriteLine();
                }
            }
            

        }

        
    }
}
