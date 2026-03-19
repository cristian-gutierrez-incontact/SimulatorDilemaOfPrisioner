using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class TitForTatTests
    {
        [Fact]
        public void TitForTat_StartsWithCooperation()
        {
            // Arrange
            var strategy = new TitForTat { Name = "TitForTat" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void TitForTat_CooperatesAfterOpponentCooperates()
        {
            // Arrange
            var strategy = new TitForTat { Name = "TitForTat" };
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
        public void TitForTat_DefectsAfterOpponentDefects()
        {
            // Arrange
            var strategy = new TitForTat { Name = "TitForTat" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.False(decision);
        }

        [Fact]
        public void TitForTat_FollowsOpponentLastMove()
        {
            // Arrange
            var strategy = new TitForTat { Name = "TitForTat" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Should copy last opponent decision (true)
            Assert.True(decision);
        }

        [Fact]
        public void TitForTat_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new TitForTat { Name = "CustomName" };

            // Assert
            Assert.Equal("CustomName", strategy.Name);
        }
    }
}
