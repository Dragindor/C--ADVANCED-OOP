using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            int count = 0;
            while (true)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (line[0] == "End")
                {
                    break;
                }
                if (count % 2 == 0)
                {
                    if (line[0] == "Hen")
                    {
                        Hen animal = new Hen(line[1],double.Parse(line[2]),0,double.Parse(line[3]));
                        animal.Sound();
                        animals.Add(animal);
                    }
                    else if (line[0] == "Owl")
                    {
                        Owl animal = new Owl(line[1], double.Parse(line[2]), 0, double.Parse(line[3]));
                        animal.Sound();
                        animals.Add(animal);
                    }
                    else if (line[0] == "Cat")
                    {
                        Cat animal = new Cat(line[1], double.Parse(line[2]), 0, line[3],line[4]);
                        animal.Sound();
                        animals.Add(animal);
                    }
                    else if (line[0] == "Tiger")
                    {
                        Tiger animal = new Tiger(line[1], double.Parse(line[2]),0, line[3], line[4]);
                        animal.Sound();
                        animals.Add(animal);
                    }
                    else if (line[0] == "Dog")
                    {
                        Dog animal = new Dog(line[1], double.Parse(line[2]),0, line[3]);
                        animal.Sound();
                        animals.Add(animal);
                    }
                    else if (line[0] == "Mouse")
                    {
                        Mouse animal = new Mouse(line[1], double.Parse(line[2]),0, line[3]);
                        animal.Sound();
                        animals.Add(animal);
                    }
                }
                else
                {
                    if (animals.Count!=0)
                    {
                        
                        
                        string type = line[0];
                        int quantity = int.Parse(line[1]);
                        animals[animals.Count - 1].Eat(type,quantity);
                    }
                    else
                    {
                        continue;
                    }
                }
                count++;
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }

        }
    }
}
