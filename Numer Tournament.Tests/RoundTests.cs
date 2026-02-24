using NUnit.Framework;

[TestFixture]
public class RoundTests
{
    [Test]
    public void CountPoints_WhenRepeatsIsZero_ReturnsZero()
    {
        var round = new Round();

        int result = round.CountPoints(0);

        Assert.AreEqual(0, result);
    }

    [Test]
    public void CountPoints_WhenRepeatsIsPositive_ReturnsSquare()
    {
        var round = new Round();

        int result = round.CountPoints(3);

        Assert.AreEqual(9, result);
    }

    [Test]
    public void CountPoints_WhenRepeatsIsFive_ReturnsTwentyFive()
    {
        var round = new Round();

        int result = round.CountPoints(5);

        Assert.AreEqual(25, result);
    }
}