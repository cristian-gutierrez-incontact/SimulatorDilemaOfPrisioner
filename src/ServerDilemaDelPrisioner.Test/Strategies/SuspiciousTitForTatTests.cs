using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class SuspiciousTitForTatTests
    {
        [Fact]
        public void SuspiciousTitForTat_StartsWithDefection()
        {
            // Arrange
            var strategy = new SuspiciousTitForTat { Name = "SuspiciousTitForTat" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.False(decision);
        }

        [Fact]
        public void SuspiciousTitForTat_CooperatesAfterOpponentCooperates()
        {
            // Arrange
            var strategy = new SuspiciousTitForTat { Name = "SuspiciousTitForTat" };
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
        public void SuspiciousTitForTat_DefectsAfterOpponentDefects()
        {
            // Arrange
            var strategy = new SuspiciousTitForTat { Name = "SuspiciousTitForTat" };
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
        public void SuspiciousTitForTat_FollowsOpponentLastMove()
        {
            // Arrange
            var strategy = new SuspiciousTitForTat { Name = "SuspiciousTitForTat" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.False(decision);
        }

        [Fact]
        public void SuspiciousTitForTat_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new SuspiciousTitForTat { Name = "CustomSuspicious" };

            // Assert
            Assert.Equal("CustomSuspicious", strategy.Name);
        }
    }
}
