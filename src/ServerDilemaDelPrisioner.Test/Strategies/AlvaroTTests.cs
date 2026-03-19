using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class AlvaroTTests
    {
        [Fact]
        public void AlvaroT_ReturnsBoolean()
        {
            // Arrange
            var strategy = new AlvaroT { Name = "AlvaroT" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.IsType<bool>(decision);
        }

        [Fact]
        public void AlvaroT_Before100Rounds_50PercentChance()
        {
            // Arrange
            var strategy = new AlvaroT { Name = "AlvaroT" };
            var history = new List<Set>();
            
            // Add 50 sets to history
            for (int i = 0; i < 50; i++)
            {
                history.Add(new Set { OpponentDecision = true });
            }
            
            var decisions = new List<bool>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                decisions.Add(strategy.MakeDecision(history));
            }

            // Assert - Should have roughly 50% of each
            var cooperations = decisions.Count(d => d);
            Assert.True(cooperations > 30 && cooperations < 70); // Allow for variance
        }

        [Fact]
        public void AlvaroT_After100Rounds_MostlyCooperates()
        {
            // Arrange
            var strategy = new AlvaroT { Name = "AlvaroT" };
            var history = new List<Set>();

            // Add 100+ sets to history
            for (int i = 0; i < 100; i++)
            {
                history.Add(new Set { OpponentDecision = true });
            }

            var decisions = new List<bool>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                decisions.Add(strategy.MakeDecision(history));
            }

            // Assert - After 100 rounds, cooperates when random >= 10 (90% chance)
            var cooperations = decisions.Count(d => d);
            Assert.True(cooperations > 75); // At least 75% cooperation
        }

        [Fact]
        public void AlvaroT_WorksWithEmptyHistory()
        {
            // Arrange
            var strategy = new AlvaroT { Name = "AlvaroT" };
            var history = new List<Set>();

            // Act & Assert
            var decision = strategy.MakeDecision(history);
            Assert.IsType<bool>(decision);
        }

        [Fact]
        public void AlvaroT_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new AlvaroT { Name = "CustomAlvaroT" };

            // Assert
            Assert.Equal("CustomAlvaroT", strategy.Name);
        }
    }
}
