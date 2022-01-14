using System;
using Vehicle;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carFuel = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] truckFuel = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] BusFuel = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carFuel[1]),double.Parse(carFuel[2])+0.9,double.Parse(carFuel[3]));
            Truck truck = new Truck(double.Parse(truckFuel[1]),double.Parse(truckFuel[2]) + 1.6, double.Parse(truckFuel[3]));
            Bus bus = new Bus(double.Parse(BusFuel[1]),double.Parse(BusFuel[2]), double.Parse(BusFuel[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (command[0]=="Drive")
                {
                    if (command[1] =="Car")
                    {
                        car.Drive(double.Parse(command[2]));
                    }
                    else if (command[1] =="Truck")
                    {
                        truck.Drive( double.Parse(command[2]));
                    }
                    else if (command[1] == "Bus")
                    {
                        bus.Drive(bus.FuelConsumption+1.4,double.Parse(command[2]));
                    }
                }
                else if (command[0] =="Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                    else if (command[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(command[2]));
                    }
                }
                else if (command[0]== "DriveEmpty")
                {
                    bus.Drive(bus.FuelConsumption,double.Parse(command[2]));
                }
                
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f02}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f02}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f02}");
        }
    }
}
