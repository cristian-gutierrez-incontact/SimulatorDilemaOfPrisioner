using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class GenerousTitForTatTests
    {
        [Fact]
        public void GenerousTitForTat_StartsWithCooperation()
        {
            // Arrange
            var strategy = new GenerousTitForTat { Name = "GenerousTitForTat" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void GenerousTitForTat_CooperatesAfterOpponentCooperates()
        {
            // Arrange
            var strategy = new GenerousTitForTat { Name = "GenerousTitForTat" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void GenerousTitForTat_SometimesForgives()
        {
            // Arrange
            var strategy = new GenerousTitForTat { Name = "GenerousTitForTat" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false }
            };
            var decisions = new List<bool>();

            // Act - Test multiple times due to randomness
            for (int i = 0; i < 100; i++)
            {
                decisions.Add(strategy.MakeDecision(history));
            }

            // Assert - Should have at least one forgiveness (cooperation) but mostly defections
            Assert.Contains(true, decisions);
            Assert.Contains(false, decisions);
            // Most should be false (defection)
            var defections = decisions.Count(d => !d);
            Assert.True(defections > 70); // At least 70% defection with 10% forgiveness rate
        }

        [Fact]
        public void GenerousTitForTat_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new GenerousTitForTat { Name = "CustomGenerous" };

            // Assert
            Assert.Equal("CustomGenerous", strategy.Name);
        }
    }
}
