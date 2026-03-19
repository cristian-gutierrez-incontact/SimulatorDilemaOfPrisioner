using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class RandomStrategyTests
    {
        [Fact]
        public void RandomStrategy_ReturnsBoolean()
        {
            // Arrange
            var strategy = new RandomStrategy { Name = "Random" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.IsType<bool>(decision);
        }

        [Fact]
        public void RandomStrategy_ProducesBothTrueAndFalse()
        {
            // Arrange
            var strategy = new RandomStrategy { Name = "Random" };
            var history = new List<Set>();
            var decisions = new List<bool>();

            // Act - Make many decisions
            for (int i = 0; i < 100; i++)
            {
                decisions.Add(strategy.MakeDecision(history));
            }

            // Assert - Should have both true and false (statistically very likely)
            Assert.Contains(true, decisions);
            Assert.Contains(false, decisions);
        }

        [Fact]
        public void RandomStrategy_WorksWithEmptyHistory()
        {
            // Arrange
            var strategy = new RandomStrategy { Name = "Random" };
            var history = new List<Set>();

            // Act & Assert - Should not throw
            var decision = strategy.MakeDecision(history);
            Assert.IsType<bool>(decision);
        }

        [Fact]
        public void RandomStrategy_WorksWithHistory()
        {
            // Arrange
            var strategy = new RandomStrategy { Name = "Random" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };

            // Act & Assert - Should not throw
            var decision = strategy.MakeDecision(history);
            Assert.IsType<bool>(decision);
        }

        [Fact]
        public void RandomStrategy_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new RandomStrategy { Name = "CustomRandom" };

            // Assert
            Assert.Equal("CustomRandom", strategy.Name);
        }
    }
}
