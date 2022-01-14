using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public class Truck
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double Campacity { get; set; }

        public Truck(double fuelQuantity, double fuelConsumption, double campacity)
        {
            if (fuelQuantity > campacity)
            {
                fuelQuantity = 0;
            }
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Campacity = campacity;

        }
        internal void Drive(double v)
        {
            if (FuelQuantity - FuelConsumption * v < 0)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                FuelQuantity -= FuelConsumption * v;
                Console.WriteLine($"Truck travelled {v} km");
            }
        }
        internal void Refuel(double v)
        {
            if (v> 0)
            {
                if (Campacity < FuelQuantity + v / 100 * 95)
                {
                    Console.WriteLine($"Cannot fit {v} fuel in the tank");
                }
                else
                {
                    FuelQuantity += v / 100 * 95;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }


        }
    }
}

