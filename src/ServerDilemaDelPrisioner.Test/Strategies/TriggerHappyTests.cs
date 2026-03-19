using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies
{
    public class TriggerHappyTests
    {
        [Fact]
        public void TriggerHappy_StartsWithCooperation()
        {
            // Arrange
            var strategy = new TriggerHappy { Name = "TriggerHappy" };
            var history = new List<Set>();

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert
            Assert.True(decision);
        }

        [Fact]
        public void TriggerHappy_CooperatesBeforeTrigger()
        {
            // Arrange
            var strategy = new TriggerHappy { Name = "TriggerHappy" };
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
        public void TriggerHappy_DefectsAfterTwoConsecutiveCooperations()
        {
            // Arrange
            var strategy = new TriggerHappy { Name = "TriggerHappy" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true }
            };

            // Act
            var firstDecision = strategy.MakeDecision(history);
            var secondDecision = strategy.MakeDecision(history);

            // Assert - After detecting two cooperations, always defect
            Assert.False(firstDecision);
            Assert.False(secondDecision);
        }

        [Fact]
        public void TriggerHappy_DoesNotTriggerOnSingleCooperation()
        {
            // Arrange
            var strategy = new TriggerHappy { Name = "TriggerHappy" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = false },
                new Set { OpponentDecision = true }
            };

            // Act
            var decision = strategy.MakeDecision(history);

            // Assert - Needs two consecutive cooperations to trigger
            Assert.True(decision);
        }

        [Fact]
        public void TriggerHappy_OnceTriggeredAlwaysDefects()
        {
            // Arrange
            var strategy = new TriggerHappy { Name = "TriggerHappy" };
            var history = new List<Set>
            {
                new Set { OpponentDecision = true },
                new Set { OpponentDecision = true }
            };

            // Act - Trigger the strategy
            strategy.MakeDecision(history);
            
            // Add more cooperation to history
            history.Add(new Set { OpponentDecision = true });
            history.Add(new Set { OpponentDecision = true });
            
            var decision = strategy.MakeDecision(history);

            // Assert - Should still defect after being triggered
            Assert.False(decision);
        }

        [Fact]
        public void TriggerHappy_NameCanBeSet()
        {
            // Arrange & Act
            var strategy = new TriggerHappy { Name = "CustomTriggerHappy" };

            // Assert
            Assert.Equal("CustomTriggerHappy", strategy.Name);
        }
    }
}
