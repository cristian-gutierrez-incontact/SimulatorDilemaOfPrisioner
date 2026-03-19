using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class OverlyForgivingTests
    {
        [Fact]
        public void OverlyForgiving_AlmostAlwaysCooperates()
        {
            // Arrange
            var strategy = new OverlyForgiving { Name = "OverlyForgiving" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void OverlyForgiving_CooperatesEvenAfterBetrayal()
        {
            // Arrange
            var strategy = new OverlyForgiving { Name = "OverlyForgiving" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void OverlyForgiving_CooperatesWithMixedHistory()
        {
            // Arrange
            var strategy = new OverlyForgiving { Name = "OverlyForgiving" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void OverlyForgiving_RarelyDefectsEvenWhenHeavilyExploited()
        {
            // Arrange
            var strategy = new OverlyForgiving { Name = "OverlyForgiving" };
            var history = new List<Set>();

            // Create history with 95% opponent defections (19 defections, 1 cooperation out of 20)
            for (int i = 0; i < 20; i++)
            {
                history.Add(new Set { OpponentDecision = i == 0 }); // Only first one cooperates
            }

            // Act - Call strategy, it will check history.Count which is now 20
            // When totalRounds > 10 and opponentDefections > totalRounds * 0.9 (19 > 18), 
            // it returns history.Count % 10 != 0
            var decision = strategy.MakeDecision(history);

            // Assert - With history count of 20, 20 % 10 == 0, so should defect (return false)
            Assert.False(decision);
        }

        [Fact]
        public void OverlyForgiving_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new OverlyForgiving { Name = "CustomForgiving" };

            // Assert
            Assert.Equal("CustomForgiving", strategy.Name);
        }
    }
}
