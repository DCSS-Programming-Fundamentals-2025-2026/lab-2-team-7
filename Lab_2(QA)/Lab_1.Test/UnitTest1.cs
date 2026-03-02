using NUnit.Framework;
using System;

namespace Number_tournament.Tests
{
    [TestFixture]
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
            RoundBase.ResetRounds();
        }

        [Test]
        public void Round_CountPoints_ReturnsSquareOfRepeats()
        {
            // Arrange
            var round = new Round();
            int repeats = 3;
            int expectedPoints = 9; 

            // Act
            int actualPoints = round.CountPoints(repeats);

            // Assert
            Assert.That(actualPoints, Is.EqualTo(expectedPoints), "Нарахування балів повинно буто квадратом серії вгадуваннь");
        }

        [Test]
        public void Round_Constructor_IncrementsGlobalRoundCounter()
        {
            // Act
            var round1 = new Round();
            var round2 = new Round();

            // Assert
            Assert.That(round1.number_of_round, Is.EqualTo(1));
            Assert.That(round2.number_of_round, Is.EqualTo(2), "Номер раунда повинен збільшуватись автоматично");
        }

        [Test]
        public void ResetRounds_SetsCounterToZero()
        {
            // Arrange
            new Round();
            new Round();

            // Act
            RoundBase.ResetRounds();
            var newRound = new Round();

            // Assert
            Assert.That(newRound.number_of_round, Is.EqualTo(1), "Після скидання нумерація повинна починатись з 1");
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(5, 25)]
        public void Round_CountPoints_MultipleScenarios(int repeats, int expected)
        {
            var round = new Round();
            Assert.That(round.CountPoints(repeats), Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class TournamentLogicTests
    {
        [Test]
        public void RunTournament_WithLessThanTwoPlayers_ReturnsNull()
        {
            // Arrange
            var tournament = new Tournament();
            string[] players = { "Player1" };

            // Act
            var result = tournament.RunTournament(players, 1);

            // Assert
            Assert.That(result, Is.Null, "Турнір не повинен початись якщо гравців менше 2");
        }
    }
}