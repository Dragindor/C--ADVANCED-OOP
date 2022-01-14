using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
            present = new Present("name",1.0);
        }
        [Test]
        public void CtorBag()
        {
            Assert.That(bag, Is.Not.Null);
        }
        [Test]
        [TestCase(null)]
        public void CreateThrowsExceptionWhenNull(Present present)
        {
            Assert.Throws<ArgumentNullException>(()=>bag.Create(present));
        }
        [Test]
        public void CreateThrowsExceptionWhenPresentExists()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>((() => bag.Create(present)));
        }
        [Test]
        public void CreateAndGetPresentWork()
        {
            bag.Create(present);
            Assert.That(present, Is.EqualTo(bag.GetPresent(present.Name)));
        }
        [Test]
        public void CreateReturnsMessege()
        {
            
            string expected = $"Successfully added present {present.Name}.";

            string actual = bag.Create(present);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveWorks()
        {

            bag.Create(present);
            bag.Remove(present);

            Assert.That(bag.GetPresent(present.Name), Is.Null);
        }
        [Test]
        public void GetPresentWithLeastMagic()
        {
            Present presentOne = new Present("name", 200);
            Present presentTwo = new Present("asd", 12);
            Present presentThree = new Present("dsa", 15);

            bag.Create(presentOne);
            bag.Create(presentTwo);
            bag.Create(presentThree);

            Assert.That(presentTwo, Is.EqualTo(bag.GetPresentWithLeastMagic()));
        }
        [Test]
        public void GetPresentReturnsPresent()
        {
            bag.Create(present);
            Assert.AreEqual(present, bag.GetPresent(present.Name));
        }
        [Test]
        public void GetPresentsAsReadOnly()
        {
            Assert.That(bag.GetPresents(), Is.InstanceOf<IReadOnlyCollection<Present>>());
        }

    }
}
