using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 5, 100);
        }

        [Test]

        [TestCase("", "Model", 5, 100)]
        [TestCase(null, "Model", 5, 100)]

        [TestCase("Make", "", 5, 100)]
        [TestCase("Make", null, 5, 100)]

        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -1, 100)]

        [TestCase("Make", "Model", 5, 0)]
        [TestCase("Make", "Model", 5, -1)]

        public void CtorThrowsExceptionWithIncorrectValues(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
            
        }
        [Test]
        public void CtorFuelAmmountIsZero()
        {
            Assert.That(car.FuelAmount,Is.EqualTo(0));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void ReFuelNegativeValues(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        
        }
        [Test]
        public void ReFuelCampacity()
        {
            car.Refuel(120);
            Assert.That(car.FuelAmount,Is.EqualTo(car.FuelCapacity));
        }
        [Test]
        public void ReFuelWorksCorrectly()
        {
            double fuel = 60.5;
            car.Refuel(fuel);
            Assert.That(car.FuelAmount, Is.EqualTo(fuel));
        }
        [Test]
        public void DriveInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(()=>car.Drive(10));
        }
        [Test]
        public void DriveWorksCorrectly()
        {
            double fuel = 100;
            car.Refuel(fuel);
            double distance = 50;
            double fuelNeeded = (distance/100) * car.FuelConsumption;
            car.Drive(distance);
            Assert.That(car.FuelAmount,Is.EqualTo(fuel-fuelNeeded));
        }
    }
}