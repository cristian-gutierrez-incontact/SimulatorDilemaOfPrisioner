using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class WorstOfBothWorldsTests
    {
        [Fact]
        public void WorstOfBothWorlds_StartsWithDefection()
        {
            // Arrange
            var strategy = new WorstOfBothWorlds { Name = "WorstOfBothWorlds" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.False(decision);
        }

        [Fact]
        public void WorstOfBothWorlds_DefectsWhenOpponentCooperates()
        {
            // Arrange
            var strategy = new WorstOfBothWorlds { Name = "WorstOfBothWorlds" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Does opposite, so defects
            Assert.False(decision);
        }

        [Fact]
        public void WorstOfBothWorlds_CooperatesWhenOpponentDefects()
        {
            // Arrange
            var strategy = new WorstOfBothWorlds { Name = "WorstOfBothWorlds" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Does opposite, so cooperates (gets exploited)
            Assert.True(decision);
        }

        [Fact]
        public void WorstOfBothWorlds_AlwaysDoesOpposite()
        {
            // Arrange
            var strategy = new WorstOfBothWorlds { Name = "WorstOfBothWorlds" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Last opponent decision was true, so do false
            Assert.False(decision);
        }

        [Fact]
        public void WorstOfBothWorlds_ConsistentlyPoorStrategy()
        {
            // Arrange
            var strategy = new WorstOfBothWorlds { Name = "WorstOfBothWorlds" };
            var history = new List<Set>();

            // Test sequence: cooperate, defect, cooperate
            history.Add(new Set { OpponentDecision = true });
            var decision1 = strategy.MakeDecision(history);

            history.Add(new Set { OpponentDecision = false });
            var decision2 = strategy.MakeDecision(history);

            history.Add(new Set { OpponentDecision = true });
            var decision3 = strategy.MakeDecision(history);

            // Assert - Always opposite
            Assert.False(decision1); // Opponent cooperated, we defect
            Assert.True(decision2);  // Opponent defected, we cooperate
            Assert.False(decision3); // Opponent cooperated, we defect
        }

        [Fact]
        public void WorstOfBothWorlds_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new WorstOfBothWorlds { Name = "CustomWorst" };

            // Assert
            Assert.Equal("CustomWorst", strategy.Name);
        }
    }
}
