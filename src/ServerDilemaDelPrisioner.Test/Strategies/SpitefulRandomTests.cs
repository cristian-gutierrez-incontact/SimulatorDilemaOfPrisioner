using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class SpitefulRandomTests
    {
        [Fact]
        public void SpitefulRandom_ReturnsBoolean()
        {
            // Arrange
            var strategy = new SpitefulRandom { Name = "SpitefulRandom" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.IsType<bool>(decision);
        }

        [Fact]
        public void SpitefulRandom_BeforeBetrayal_CooperatesMore()
        {
            // Arrange
            var strategy = new SpitefulRandom { Name = "SpitefulRandom" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true }
            };
            var decisions = new List<bool>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                decisions.Add(strategy.MakeDecision(history));
            }

            // Assert - Should have more cooperations before betrayal (60%)
            var cooperations = decisions.Count(d => d);
            Assert.True(cooperations > 40); // Should be around 60%
        }

        [Fact]
        public void SpitefulRandom_AfterBetrayal_DefectsMore()
        {
            // Arrange
            var strategy = new SpitefulRandom { Name = "SpitefulRandom" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false } // Betrayal
            };
            var decisions = new List<bool>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                decisions.Add(strategy.MakeDecision(history));
            }

            // Assert - Should have more defections after betrayal (80%)
            var defections = decisions.Count(d => !d);
            Assert.True(defections > 60); // Should be around 80%
        }

        [Fact]
        public void SpitefulRandom_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new SpitefulRandom { Name = "CustomSpiteful" };

            // Assert
            Assert.Equal("CustomSpiteful", strategy.Name);
        }
    }
}
