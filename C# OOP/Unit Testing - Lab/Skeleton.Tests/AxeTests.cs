using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durabolity = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durabolity);
        dummy = new Dummy(5, 6);
    }


    [Test]
    public void WhenAxeAttackAndDurabilityProvidedShouldBeSetCorecctly()
    {

        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durabolity);
    }

    [Test]
    public void When_AxeAttacksShouldLoseDurabolityPoints()
    {
        axe.Attack(dummy);

        Assert.AreEqual(durabolity - 1, axe.DurabilityPoints);
    }

    [Test]

    public void When_AxeDuabilityPointAreZero_ShouldThrowExeption()
    {
        dummy = new Dummy(5000, 5000);

        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        });

        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }

    [Test]

    public void Wen_AxeAttackIsCalledWithNullDummy_ShouldThrowNullRef()
    {
        Assert.Throws<NullReferenceException>(() =>
        {
            axe.Attack(null);
        });
    }
}