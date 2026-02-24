using NUnit.Framework;

[TestFixture]
public class RoundBaseTests
{
    [SetUp]
    public void Setup()
    {
        RoundBase.ResetRounds();
    }

    [Test]
    public void Round_Number_Increments_ForEachNewRound()
    {
        var r1 = new Round();
        var r2 = new Round();
        var r3 = new Round();

        Assert.AreEqual(1, r1.number_of_round);
        Assert.AreEqual(2, r2.number_of_round);
        Assert.AreEqual(3, r3.number_of_round);
    }

    [Test]
    public void ResetRounds_SetsCounterBackToOne()
    {
        var r1 = new Round();
        var r2 = new Round();

        RoundBase.ResetRounds();

        var r3 = new Round();

        Assert.AreEqual(1, r3.number_of_round);
    }
}