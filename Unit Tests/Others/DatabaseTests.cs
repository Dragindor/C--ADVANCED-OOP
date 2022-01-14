using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }
        [Test]
        public void Add()
        {
            database.Add(1);
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddThrowsExeptionWhenFull()
        {
            database = new Database.Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(()=> database.Add(17));
        }
        [Test]
        public void Remove()
        {
            database = new Database.Database(1);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(0));
        }
        [Test]
        public void RemoveThrowsExeptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(()=>database.Remove());
        }
        [Test]
        public void RemovesLastElements()
        {
            int element = 2;
            for (int i = 0; i < 3; i++)
            {
                database.Add(i);
            }
            database.Remove();
            var copy = database.Fetch();

            Assert.IsFalse(copy.Contains(element));
        }

        [Test]
        public void Fetch()
        {
            database.Add(1);
            database.Add(2);
            var firstCopy = database.Fetch();
            database.Add(3);
            var secondCopy = database.Fetch();
            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }
        [Test]
        public void CtorAdding()
        {
            int[] elements =new int[3];
            elements[0] = 1;
            elements[1] = 2;
            elements[2] = 3;
            database = new Database.Database(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }
        [Test]
        public void CtorThrowsExeptionWhenArrayIsOverSixteen()
        {
            Assert.Throws<InvalidOperationException>(() => database=new Database.Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17));
        }
    }
}