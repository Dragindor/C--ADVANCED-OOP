namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        [SetUp]
        public void SetUp()
        {
            robot = new Robot("test", 100);
            robotManager = new RobotManager(10);
        }
        [Test]
        public void RobotCtorWorks()
        {
            Assert.That(robot,Is.Not.Null);
            Assert.That(robotManager,Is.Not.Null);
        }
        [Test]
        public void RobotCtorInitializeCorrectly()
        {
            Assert.AreEqual(robot.Name, "test");
            Assert.AreEqual(robot.MaximumBattery, 100);
        }

        [Test]
        public void RobotManagerCapThrowsEx()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        public void RobotManagerCapWorks()
        {
            Assert.AreEqual(10, robotManager.Capacity);
        }
        [Test]
        public void Count()
        {
            robotManager.Add(robot);
            Assert.AreEqual(1, robotManager.Count);
        }
        [Test]
        public void AddThrowsEx()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }
        [Test]
        public void AddThrowsCapEx()
        {
            robotManager = new RobotManager(2);
            robotManager.Add(new Robot("m", 2));
            robotManager.Add(new Robot("g", 2));
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }
        [Test]
        public void RobotManagerRemoveWorks()
        {
            robotManager.Add(robot);
            Assert.AreEqual(robotManager.Count, 1);
            robotManager.Remove(robot.Name);
            Assert.AreEqual(robotManager.Count,0);
        }
        [Test]
        public void RobotManagerRemoveThrowsExceptionNull()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("TEST"));
        }
        [Test]
        public void RobotManagerWorkExceptionNameNull()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("TEST","Useless",10));
        }
        [Test]
        public void RobotManagerWorkExceptionBattery()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot.Name, "Useless", 101));
        }
        [Test]
        public void RobotManagerWork()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "Useless", 10);
            Assert.AreEqual(robot.Battery,90);
        }
        [Test]
        public void RobotManagerChargeExceptionNull()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("TEST"));
        }
        [Test]
        public void RobotManagerChargeWorks()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "Useless", 10);
            Assert.AreEqual(robot.Battery,90);
            robotManager.Charge(robot.Name);
            Assert.AreEqual(robot.Battery,robot.MaximumBattery);
        }


    }
}
