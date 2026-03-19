using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class PavlovTests
    {
        [Fact]
        public void Pavlov_StartsWithCooperation()
        {
            // Arrange
            var strategy = new Pavlov { Name = "Pavlov" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void Pavlov_RepeatsAfterMutualCooperation()
        {
            // Arrange
            var strategy = new Pavlov { Name = "Pavlov" };
            var history = new List<Set>
            {
                new Set { OurDecision = true, OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Got 3 points (good), so repeat cooperation
            Assert.True(decision);
        }

        [Fact]
        public void Pavlov_ChangesAfterSuckerPayoff()
        {
            // Arrange
            var strategy = new Pavlov { Name = "Pavlov" };
            var history = new List<Set>
            {
                new Set { OurDecision = true, OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Got 0 points (bad), so change to defection
            Assert.False(decision);
        }

        [Fact]
        public void Pavlov_ChangesAfterMutualDefection()
        {
            // Arrange
            var strategy = new Pavlov { Name = "Pavlov" };
            var history = new List<Set>
            {
                new Set { OurDecision = false, OpponentDecision = false }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Got 1 point (bad), so change to cooperation
            Assert.True(decision);
        }

        [Fact]
        public void Pavlov_RepeatsAfterSuccessfulDefection()
        {
            // Arrange
            var strategy = new Pavlov { Name = "Pavlov" };
            var history = new List<Set>
            {
                new Set { OurDecision = false, OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Got 5 points (good), so repeat defection
            Assert.False(decision);
        }

        [Fact]
        public void Pavlov_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new Pavlov { Name = "CustomPavlov" };

            // Assert
            Assert.Equal("CustomPavlov", strategy.Name);
        }
    }
}
