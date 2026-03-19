using ServerDilemaDelPrisioner;
using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test
{
    public class MatchTests
    {
        [Fact]
        public void Match_Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            var player1 = new TitForTat { Name = "Player1" };
            var player2 = new TitForTat { Name = "Player2" };
            int sets = 10;

            // Act
            var match = new Match(player1, player2, sets);

            // Assert
            Assert.NotNull(match.Player1Strategy);
            Assert.NotNull(match.Player2Strategy);
            Assert.Equal(player1.Name, match.Player1Strategy.Name);
            Assert.Equal(player2.Name, match.Player2Strategy.Name);
            Assert.Equal(sets, match.Sets);
            Assert.Equal(0, match.Player1Score);
            Assert.Equal(0, match.Player2Score);
            Assert.Empty(match.SetResultsForPlayer1);
            Assert.Empty(match.SetResultsForPlayer2);
        }

        [Fact]
        public void PlaySet_BothCooperate_BothGetThreePoints()
        {
            // Arrange
            var player1 = new TitForTat { Name = "Player1" };
            var player2 = new TitForTat { Name = "Player2" };
            var match = new Match(player1, player2, 1);

            // Act
            match.PlaySet(1);

            // Assert - Both start by cooperating in TitForTat
            Assert.Equal(3, match.Player1Score);
            Assert.Equal(3, match.Player2Score);
            Assert.Single(match.SetResultsForPlayer1);
            Assert.Single(match.SetResultsForPlayer2);
        }

        [Fact]
        public void PlaySet_RecordsSetHistory()
        {
            // Arrange
            var player1 = new TitForTat { Name = "Player1" };
            var player2 = new TitForTat { Name = "Player2" };
            var match = new Match(player1, player2, 1);

            // Act
            match.PlaySet(1);

            // Assert
            var set1 = match.SetResultsForPlayer1[0];
            Assert.Equal(1, set1.SetNumber);
            Assert.Equal("Player1", set1.OurName);
            Assert.Equal("Player2", set1.OpponentName);

            var set2 = match.SetResultsForPlayer2[0];
            Assert.Equal(1, set2.SetNumber);
            Assert.Equal("Player2", set2.OurName);
            Assert.Equal("Player1", set2.OpponentName);
        }

        [Fact]
        public void PlayAllSets_PlaysCorrectNumberOfSets()
        {
            // Arrange
            var player1 = new TitForTat { Name = "Player1" };
            var player2 = new TitForTat { Name = "Player2" };
            int numberOfSets = 5;
            var match = new Match(player1, player2, numberOfSets);

            // Act
            match.PlayAllSets();

            // Assert
            Assert.Equal(numberOfSets, match.SetResultsForPlayer1.Count);
            Assert.Equal(numberOfSets, match.SetResultsForPlayer2.Count);
        }

        [Fact]
        public void PlayAllSets_AccumulatesScores()
        {
            // Arrange
            var player1 = new TitForTat { Name = "Player1" };
            var player2 = new TitForTat { Name = "Player2" };
            var match = new Match(player1, player2, 10);

            // Act
            match.PlayAllSets();

            // Assert - Both always cooperate, so 3 points per set
            Assert.Equal(30, match.Player1Score);
            Assert.Equal(30, match.Player2Score);
        }

        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var player1 = new TitForTat { Name = "Player1" };
            var player2 = new TitForTat { Name = "Player2" };
            var match = new Match(player1, player2, 2);
            match.PlayAllSets();

            // Act
            var result = match.ToString();

            // Assert
            Assert.Equal("Player1 vs Player2: 6-6", result);
        }

        [Fact]
        public void ToStringTotalSets_ReturnsAllSetDetails()
        {
            // Arrange
            var player1 = new TitForTat { Name = "Player1" };
            var player2 = new TitForTat { Name = "Player2" };
            var match = new Match(player1, player2, 3);
            match.PlayAllSets();

            // Act
            var result = match.ToStringTotalSets();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Contains("Player1 vs Player2", result[0]);
        }
    }
}
