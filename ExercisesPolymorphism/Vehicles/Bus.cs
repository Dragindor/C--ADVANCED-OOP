using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public class Bus
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double Campacity { get; set; }

        public Bus(double fuelQuantity, double fuelConsumption, double campacity)
        {
            if (fuelQuantity > campacity)
            {
                fuelQuantity = 0;
            }
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Campacity = campacity;

        }
        internal void Drive(double fuelConsumption,double v)
        {
            if (FuelQuantity - fuelConsumption * v < 0)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                FuelQuantity -= fuelConsumption * v;
                Console.WriteLine($"Bus travelled {v} km");
            }
        }
        internal void Refuel(double v)
        {
            if (v> 0)
            {
                if (Campacity < FuelQuantity + v)
                {
                    Console.WriteLine($"Cannot fit {v} fuel in the tank");
                }
                else
                {
                    FuelQuantity += v;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            

        }
    }
}
