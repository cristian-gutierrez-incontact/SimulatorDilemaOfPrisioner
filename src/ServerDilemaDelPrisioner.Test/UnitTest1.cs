using ServerDilemaDelPrisioner;
using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test
{
    public class IntegrationTests
    {
        [Fact]
        public void FullTournament_WithMultipleStrategies_RunsSuccessfully()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "TitForTat" },
                new Grudger { Name = "Grudger" },
                new Pavlov { Name = "Pavlov" },
                new RandomStrategy { Name = "Random" }
            };
            var manager = new MatchManager(strategies, 10);

            // Act
            manager.CreateTournament();
            manager.PlayAllMatches();
            var scores = manager.GetTotalScores();

            // Assert
            Assert.Equal(4, scores.Count);
            Assert.All(scores.Values, score => Assert.True(score > 0));
        }

        [Fact]
        public void Match_BetweenDifferentStrategies_ProducesExpectedOutcomes()
        {
            // Arrange - TitForTat always cooperates with itself
            var player1 = new TitForTat { Name = "TitForTat1" };
            var player2 = new TitForTat { Name = "TitForTat2" };
            var match = new Match(player1, player2, 10);

            // Act
            match.PlayAllSets();

            // Assert - Both should score 30 (3 points * 10 rounds)
            Assert.Equal(30, match.Player1Score);
            Assert.Equal(30, match.Player2Score);
        }

        [Fact]
        public void Match_GrudgerVsAlwaysDefect_StrategyBehavior()
        {
            // Arrange
            var grudger = new Grudger { Name = "Grudger" };
            var suspicious = new SuspiciousTitForTat { Name = "Suspicious" };
            var match = new Match(grudger, suspicious, 5);

            // Act
            match.PlayAllSets();

            // Assert - Both strategies will have some score after 5 rounds
            Assert.True(match.Player1Score > 0);
            Assert.True(match.Player2Score > 0);
        }
    }
}
