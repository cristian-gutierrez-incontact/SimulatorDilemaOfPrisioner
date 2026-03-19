using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class BernardoTests
    {
        [Fact]
        public void Bernardo_WithEmptyHistory_DefectsOrCooperates()
        {
            // Arrange
            var strategy = new Bernardo { Name = "Bernardo" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - With empty history, average is 0, so should cooperate
            Assert.True(decision);
        }

        [Fact]
        public void Bernardo_WhenOpponentCooperatesMoreThan50Percent_Cooperates()
        {
            // Arrange
            var strategy = new Bernardo { Name = "Bernardo" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - 2/3 = 0 with integer division, so cooperate
            Assert.True(decision);
        }

        [Fact]
        public void Bernardo_WhenOpponentDefectsMoreThan50Percent_Cooperates()
        {
            // Arrange
            var strategy = new Bernardo { Name = "Bernardo" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - 1/3 = 0.33 < 0.5, so cooperate
            Assert.True(decision);
        }

        [Fact]
        public void Bernardo_WhenOpponentExactly50Percent_Cooperates()
        {
            // Arrange
            var strategy = new Bernardo { Name = "Bernardo" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - 1/2 = 0 with integer division, so cooperate
            Assert.True(decision);
        }

        [Fact]
        public void Bernardo_TracksOpponentCooperationRate()
        {
            // Arrange
            var strategy = new Bernardo { Name = "Bernardo" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - 4/4 = 1.0 >= 0.5, so defect
            Assert.False(decision);
        }

        [Fact]
        public void Bernardo_NameIsSetCorrectly()
        {
            // Arrange & Act
            var strategy = new Bernardo();

            // Assert
            Assert.Equal("Randomness Doesn't Exist", strategy.Name);
        }

        [Fact]
        public void Bernardo_NameCanBeChanged()
        {
            // Arrange & Act
            var strategy = new Bernardo { Name = "CustomBernardo" };

            // Assert
            Assert.Equal("CustomBernardo", strategy.Name);
        }
    }
}
