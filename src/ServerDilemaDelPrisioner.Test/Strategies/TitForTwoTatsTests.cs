using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class TitForTwoTatsTests
    {
        [Fact]
        public void TitForTwoTats_StartsWithCooperation()
        {
            // Arrange
            var strategy = new TitForTwoTats { Name = "TitForTwoTats" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void TitForTwoTats_CooperatesWithOnlyOneRound()
        {
            // Arrange
            var strategy = new TitForTwoTats { Name = "TitForTwoTats" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Needs two defections before retaliating
            Assert.True(decision);
        }

        [Fact]
        public void TitForTwoTats_CooperatesAfterOneDefection()
        {
            // Arrange
            var strategy = new TitForTwoTats { Name = "TitForTwoTats" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void TitForTwoTats_DefectsAfterTwoConsecutiveDefections()
        {
            // Arrange
            var strategy = new TitForTwoTats { Name = "TitForTwoTats" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.False(decision);
        }

        [Fact]
        public void TitForTwoTats_ForgivesAfterOpponentCooperates()
        {
            // Arrange
            var strategy = new TitForTwoTats { Name = "TitForTwoTats" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Last two are not both defections
            Assert.True(decision);
        }

        [Fact]
        public void TitForTwoTats_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new TitForTwoTats { Name = "CustomTitForTwoTats" };

            // Assert
            Assert.Equal("CustomTitForTwoTats", strategy.Name);
        }
    }
}
