using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class GonzaloStratTests
    {
        [Fact]
        public void GonzaloStrat_StartsWithDefection()
        {
            // Arrange
            var strategy = new GonzaloStrat { Name = "GonzaloStrat" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.False(decision);
        }

        [Fact]
        public void GonzaloStrat_CooperatesWhenOpponentAlwaysDefects()
        {
            // Arrange
            var strategy = new GonzaloStrat { Name = "GonzaloStrat" };
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
        public void GonzaloStrat_DefectsWhenOpponentAlwaysCooperates()
        {
            // Arrange
            var strategy = new GonzaloStrat { Name = "GonzaloStrat" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.False(decision);
        }

        [Fact]
        public void GonzaloStrat_CooperatesWhenOpponentDefectsMoreThanHalf()
        {
            // Arrange
            var strategy = new GonzaloStrat { Name = "GonzaloStrat" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - 3 defections > 4/2, so cooperate
            Assert.True(decision);
        }

        [Fact]
        public void GonzaloStrat_DefectsWhenOpponentCooperatesMoreThanHalf()
        {
            // Arrange
            var strategy = new GonzaloStrat { Name = "GonzaloStrat" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - 1 defection < 4/2, so defect
            Assert.False(decision);
        }

        [Fact]
        public void GonzaloStrat_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new GonzaloStrat { Name = "CustomGonzalo" };

            // Assert
            Assert.Equal("CustomGonzalo", strategy.Name);
        }
    }
}
