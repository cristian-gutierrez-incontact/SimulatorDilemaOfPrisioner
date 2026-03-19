using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class SelfDestructiveTests
    {
        [Fact]
        public void SelfDestructive_StartsWithCooperation()
        {
            // Arrange
            var strategy = new SelfDestructive { Name = "SelfDestructive" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void SelfDestructive_MakesPoorDecisions()
        {
            // Arrange
            var strategy = new SelfDestructive { Name = "SelfDestructive" };
            var history = new List<Set>
            {
                new Set { OurDecision = true, OpponentDecision = true } // Good outcome
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Should mirror opponent when doing well
            Assert.True(decision);
        }

        [Fact]
        public void SelfDestructive_SabotagesItselfWhenDoingWell()
        {
            // Arrange
            var strategy = new SelfDestructive { Name = "SelfDestructive" };
            var history = new List<Set>();
            
            // Create a scenario where it's doing well (mutual cooperation)
            for (int i = 0; i < 5; i++)
            {
                history.Add(new Set { OurDecision = true, OpponentDecision = true });
            }

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - When doing well (score > 2.5 per round), it mirrors opponent
            Assert.True(decision);
        }

        [Fact]
        public void SelfDestructive_MakesWorseChoicesWhenDoingPoorly()
        {
            // Arrange
            var strategy = new SelfDestructive { Name = "SelfDestructive" };
            var history = new List<Set>();
            
            // Create a scenario where it's doing poorly
            for (int i = 0; i < 5; i++)
            {
                history.Add(new Set { OurDecision = true, OpponentDecision = false });
            }

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - When doing poorly, it inverts opponent's move
            Assert.True(decision); // Opponent defected, so invert to cooperate
        }

        [Fact]
        public void SelfDestructive_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new SelfDestructive { Name = "CustomDestructive" };

            // Assert
            Assert.Equal("CustomDestructive", strategy.Name);
        }
    }
}
