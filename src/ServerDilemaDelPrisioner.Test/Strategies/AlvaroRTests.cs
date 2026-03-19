using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class AlvaroRTests
    {
        [Fact]
        public void AlvaroR_StartsWithCooperation()
        {
            // Arrange
            var strategy = new AlvaroR { Name = "AlvaroR" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void AlvaroR_DefectsWhenOpponentDefectsMore()
        {
            // Arrange
            var strategy = new AlvaroR { Name = "AlvaroR" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - 3 defections vs 1 cooperation, should defect
            Assert.False(decision);
        }

        [Fact]
        public void AlvaroR_RandomBehaviorWhenOpponentCooperatesMore()
        {
            // Arrange
            var strategy = new AlvaroR { Name = "AlvaroR" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };
            var decisions = new List<bool>();

            // Act - Test multiple times due to randomness
            for (int i = 0; i < 100; i++)
            {
                decisions.Add(strategy.MakeDecision(history));
            }

            // Assert - Should have both true and false (80% cooperation, 20% defection)
            Assert.Contains(true, decisions);
            Assert.Contains(false, decisions);
            var cooperations = decisions.Count(d => d);
            Assert.True(cooperations > 60); // Should be around 80%
        }

        [Fact]
        public void AlvaroR_DefectsWhenEqualDefectionsAndCooperations()
        {
            // Arrange
            var strategy = new AlvaroR { Name = "AlvaroR" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };
            var decisions = new List<bool>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                decisions.Add(strategy.MakeDecision(history));
            }

            // Assert - When equal, uses random with 80% cooperation
            Assert.Contains(true, decisions);
        }

        [Fact]
        public void AlvaroR_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new AlvaroR { Name = "CustomAlvaroR" };

            // Assert
            Assert.Equal("CustomAlvaroR", strategy.Name);
        }
    }
}
