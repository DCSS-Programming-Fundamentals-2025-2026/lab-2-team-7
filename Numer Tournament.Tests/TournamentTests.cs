using NUnit.Framework;

[TestFixture]
public class TournamentTests
{
    [Test]
    public void RunTournament_WhenLessThanTwoPlayers_ReturnsNull()
    {
        var tournament = new Tournament();
        string[] players = { "Alice" };

        var result = tournament.RunTournament(players, 1);

        Assert.IsNull(result);
    }
}