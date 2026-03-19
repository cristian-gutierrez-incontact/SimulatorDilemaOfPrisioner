using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class JesusTests
    {
        [Fact]
        public void Jesus_StartsWithCooperation()
        {
            // Arrange
            var strategy = new Jesus { Name = "Jesus" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void Jesus_MirrorsLastOpponentDecision_Cooperation()
        {
            // Arrange
            var strategy = new Jesus { Name = "Jesus" };
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
        public void Jesus_MirrorsLastOpponentDecision_Defection()
        {
            // Arrange
            var strategy = new Jesus { Name = "Jesus" };
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
        public void Jesus_OnlyLooksAtLastMove()
        {
            // Arrange
            var strategy = new Jesus { Name = "Jesus" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Only looks at last move (true)
            Assert.True(decision);
        }

        [Fact]
        public void Jesus_HandlesNullHistory()
        {
            // Arrange
            var strategy = new Jesus { Name = "Jesus" };

            // Act
            var decision = strategy.MakeDecision(null);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void Jesus_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new Jesus { Name = "CustomJesus" };

            // Assert
            Assert.Equal("CustomJesus", strategy.Name);
        }
    }
}
