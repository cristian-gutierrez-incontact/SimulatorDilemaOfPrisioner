using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test.Strategies.Base
{
    public class SetTests
    {
        [Fact]
        public void Set_PropertiesCanBeSet()
        {
            // Arrange
            var set = new Set();

            // Act
            set.SetNumber = 5;
            set.OurName = "TestPlayer";
            set.OurDecision = true;
            set.OurScore = 3;
            set.TotalOurScore = 15;
            set.LengthHistoricalOur = 4;
            set.OpponentName = "Opponent";
            set.OpponentDecision = false;
            set.OpponentScore = 5;
            set.TotalOpponentScore = 20;
            set.LengthHistoricalOpponent = 4;

            // Assert
            Assert.Equal(5, set.SetNumber);
            Assert.Equal("TestPlayer", set.OurName);
            Assert.True(set.OurDecision);
            Assert.Equal(3, set.OurScore);
            Assert.Equal(15, set.TotalOurScore);
            Assert.Equal(4, set.LengthHistoricalOur);
            Assert.Equal("Opponent", set.OpponentName);
            Assert.False(set.OpponentDecision);
            Assert.Equal(5, set.OpponentScore);
            Assert.Equal(20, set.TotalOpponentScore);
            Assert.Equal(4, set.LengthHistoricalOpponent);
        }

        [Fact]
        public void Set_DefaultValues()
        {
            // Act
            var set = new Set();

            // Assert
            Assert.Equal(0, set.SetNumber);
            Assert.Null(set.OurName);
            Assert.False(set.OurDecision);
            Assert.Equal(0, set.OurScore);
            Assert.Equal(0, set.TotalOurScore);
            Assert.Equal(0, set.LengthHistoricalOur);
            Assert.Null(set.OpponentName);
            Assert.False(set.OpponentDecision);
            Assert.Equal(0, set.OpponentScore);
            Assert.Equal(0, set.TotalOpponentScore);
            Assert.Equal(0, set.LengthHistoricalOpponent);
        }
    }
}
