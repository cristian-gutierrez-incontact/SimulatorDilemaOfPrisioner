using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class GrudgerTests
    {
        [Fact]
        public void Grudger_StartsWithCooperation()
        {
            // Arrange
            var strategy = new Grudger { Name = "Grudger" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void Grudger_CooperatesWhileOpponentCooperates()
        {
            // Arrange
            var strategy = new Grudger { Name = "Grudger" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void Grudger_DefectsAfterOpponentDefects()
        {
            // Arrange
            var strategy = new Grudger { Name = "Grudger" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.False(decision);
        }

        [Fact]
        public void Grudger_NeverForgivesAfterBetrayal()
        {
            // Arrange
            var strategy = new Grudger { Name = "Grudger" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Even though opponent cooperated again, Grudger never forgives
            Assert.False(decision);
        }

        [Fact]
        public void Grudger_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new Grudger { Name = "CustomGrudger" };

            // Assert
            Assert.Equal("CustomGrudger", strategy.Name);
        }
    }
}
