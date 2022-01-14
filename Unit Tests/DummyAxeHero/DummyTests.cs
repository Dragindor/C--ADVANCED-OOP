using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(10, 10);
        dummy = new Dummy(100, 10);
    }

    [Test]
    public void DummyTakesDamage()
    {
        //Axe axe = new Axe(10, 10);
        //Dummy dummy = new Dummy(100, 10);
        int startingHealth = dummy.Health;
        axe.Attack(dummy);
        Assert.That(dummy.Health == startingHealth - axe.AttackPoints, "Dummy takes damage");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        //Hero hero = new Hero("Hiro");
        //Axe axe = new Axe(10, 10);
        dummy = new Dummy(0, 10);
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));

    }

    [Test]
    public void DeadDummyCanGiveExp()
    {
        //Hero hero = new Hero("Hiro");
        //Axe axe = new Axe(10, 10);
        dummy = new Dummy(10, 10);
        axe.Attack(dummy);
        int exp = dummy.GiveExperience();
        Assert.That(exp, Is.Not.EqualTo(0), "Dummy gives exp");
    }

    [Test]
    public void AliveDummyCantGiveExp()
    {
        //Hero hero = new Hero("Hiro");
        //Axe axe = new Axe(10, 10);
        //Dummy dummy = new Dummy(100, 10);
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
