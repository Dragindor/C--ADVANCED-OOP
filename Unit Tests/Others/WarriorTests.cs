using NUnit.Framework;
using System;

namespace FightingArena
{
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("TestSubject", 10, 100);
        }

        [Test]
        [TestCase("", 10, 100)]
        [TestCase(" ", 10, 100)]
        [TestCase(null, 10, 100)]
        [TestCase("TestSubject", 0, 100)]
        [TestCase("TestSubject", -1, 100)]
        [TestCase("TestSubject", 10, -1)]
        public void CtorInvalidValues(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, damage, hp));
        }
        [Test]
        public void CtorWorks()
        {
            Assert.That(warrior.Name, Is.EqualTo("TestSubject"));
            Assert.That(warrior.Damage, Is.EqualTo(10));
            Assert.That(warrior.HP, Is.EqualTo(100));
        }
        [Test]

        public void AttackNotEnoughtHp()
        {
            Warrior AttackedWarrior = new Warrior("AttackedWarrior", 10, 100);
            warrior = new Warrior("TestSubject", 10, 30);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(AttackedWarrior));
        }
        [Test]

        [TestCase("AttackedWarrior", 10, 10)]
        [TestCase("AttackedWarrior", 101, 100)]
        public void AttackInvalidTarget(string name, int damage, int hp)
        {
            Warrior AttackedWarrior = new Warrior(name,damage,hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(AttackedWarrior));
        }
        [Test]
        public void SuccessfullAttack()
        {
            Warrior AttackedWarrior = new Warrior("AttackedWarrior", 10, 100);
            warrior.Attack(AttackedWarrior);
            Assert.That(warrior.HP,Is.EqualTo(90));
            Assert.That(AttackedWarrior.HP,Is.EqualTo(90));
        }
        [Test]
        public void SuccessfullAttackDeath()
        {
            Warrior AttackedWarrior = new Warrior("AttackedWarrior", 100, 100);
            warrior = new Warrior("TestSubject", 200, 100);
            warrior.Attack(AttackedWarrior);
            Assert.That(warrior.HP, Is.EqualTo(0));
            Assert.That(AttackedWarrior.HP, Is.EqualTo(0));
        }

    }
}