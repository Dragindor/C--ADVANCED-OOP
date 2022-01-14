using NUnit.Framework;
using System;
using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase dbPeople;
        [SetUp]
        public void Setup()
        {
            dbPeople = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void CtorAddingWorks()
        {
            var people = new Person[16];
            int expectedCount = 16;
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name {i}");
            }

            dbPeople = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.That(dbPeople.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public void CtorAddingOverCampacity()
        {
            var people = new Person[17];

            Assert.Throws<ArgumentException>(() => dbPeople = new ExtendedDatabase.ExtendedDatabase(people));
        }
        [Test]
        public void CtorAddingSamePersonName()
        {
            var people = new Person[2];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name");
            }
            Assert.Throws<InvalidOperationException>(() => dbPeople = new ExtendedDatabase.ExtendedDatabase(people));
        }
        [Test]
        public void CtorAddingSamePersonId()
        {
            var people = new Person[2];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(1, $"Name {i}");
            }
            Assert.Throws<InvalidOperationException>(() => dbPeople = new ExtendedDatabase.ExtendedDatabase(people));
        }
        [Test]
        public void AddingWorks()
        {
            var people = new Person[2];
            int expectedCount = 2;
            for (int i = 0; i < people.Length; i++)
            {
                dbPeople.Add(new Person(i, $"Name {i}"));
            }
            Assert.That(dbPeople.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public void AddingOverCampacity()
        {
            var people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name {i}");
            }
            
            dbPeople = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(() => dbPeople.Add(new Person(100, "pesho")));
        }
        
        [Test]
        public void AddSameName()
        {

            dbPeople.Add(new Person(1, $"Name"));

            Assert.Throws<InvalidOperationException>(() => dbPeople.Add(new Person(2, $"Name")));
        }
        [Test]
        public void AddSameId()
        {

            dbPeople.Add(new Person(1, $"Name"));

            Assert.Throws<InvalidOperationException>(() => dbPeople.Add(new Person(1, $"Name2")));
        }
        [Test]
        public void RemoveThrowsExeptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => dbPeople.Remove());
        }
        [Test]
        public void Remove()
        {
            dbPeople.Add(new Person(1, $"Name"));
            dbPeople.Remove();
            Assert.That( dbPeople.Count,Is.EqualTo(0));
        }
        [Test]
        public void FindByUserName()
        { 
            var person = new Person(1, $"Name");
            dbPeople.Add(person);
            var found = dbPeople.FindByUsername(person.UserName);
            Assert.That(person, Is.EqualTo(found));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUserNameStringEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => dbPeople.FindByUsername(username));
        }
        [Test]
        public void FindByUserNameDoesNotExists()
        {  
            Assert.Throws<InvalidOperationException>(() => dbPeople.FindByUsername("name"));
        }
        [Test]
        public void FindById()
        {
            var person = new Person(1, $"Name");
            dbPeople.Add(person);
            var found = dbPeople.FindById(person.Id);
            Assert.That(person, Is.EqualTo(found));
        }
        [Test]
        public void FindByIdLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => dbPeople.FindById(-1));
        }
        [Test]
        public void FindByIdNotExists()
        {
            dbPeople.Add(new Person(1, $"Name"));
            Assert.Throws<InvalidOperationException>(() => dbPeople.FindById(2));
        }
    }
}