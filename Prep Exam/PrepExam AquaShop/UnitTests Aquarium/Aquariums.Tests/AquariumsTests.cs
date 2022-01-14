namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            fish = new Fish("TestSubject");
            aquarium = new Aquarium("ExperimentZone",10);
        }
        
        [Test]
        public void FishCtorTestWorks()
        {
            fish = new Fish("gosho");
            Assert.That(fish.Name == "gosho" && fish.Available == true); ;
        }
        [Test]
        public void AquaruiumCtorTestWorks()
        {
            aquarium = new Aquarium("Pirdop", 10);
            Assert.That(aquarium.Name == "Pirdop" && aquarium.Capacity==10); 
        }
        [Test]
        public void AquaruiumCtorTestExceptionsName()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(String.Empty, 10));           
        }
        [Test]
        public void AquaruiumCtorTestExceptionsCapacity()
        {           
            Assert.Throws<ArgumentException>(() => new Aquarium("pass", -1));
        }
        [Test]
        public void AquaruiumCountPlusAddworks()
        {
            aquarium.Add(fish);
            Assert.That(aquarium.Count,Is.EqualTo(1));
        }
        [Test]
        public void AquaruiumAddException()
        {
            aquarium = new Aquarium("test",0);
            Assert.Throws<InvalidOperationException>(()=>aquarium.Add(fish));
        }
        [Test]
        public void AquaruiumRemoveworks()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish("TestSubject");
            Assert.AreEqual(aquarium.Count,0);
        }
        [Test]
        public void AquaruiumRemoveException()
        {
            Assert.Throws<InvalidOperationException>(()=> aquarium.RemoveFish(null));
        }
        [Test]
        public void AquaruiumSellFishWorks()
        {
            aquarium.Add(fish);
            aquarium.SellFish("TestSubject");
            Assert.AreEqual(fish.Name, "TestSubject" );
            Assert.AreEqual(fish.Available,false);
        }
        [Test]
        public void AquaruiumSellFishException()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }
        [Test]
        public void AquaruiumReport()
        {
            //Fish fish2 = new Fish("test2");
            //Fish fish3 = new Fish("test3");
            //Fish fish4 = new Fish("test4");
            //
            aquarium.Add(fish);
            //aquarium.Add(fish2);
            //aquarium.Add(fish3);
            //aquarium.Add(fish4);
            //
            //List<Fish> fishes = new List<Fish>();
            //
            //fishes.Add(fish);
            //fishes.Add(fish2);
            //fishes.Add(fish3);
            //fishes.Add(fish4);
            //
            //string fishNames = string.Join(", ", fishes.Select(f => f.Name));
            string report = $"Fish available at {aquarium.Name}: {fish.Name}";
            Assert.AreEqual(aquarium.Report(),report);
        }
    }
}

