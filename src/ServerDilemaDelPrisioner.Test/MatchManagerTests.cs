using ServerDilemaDelPrisioner;
using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;

namespace ServerDilemaDelPrisioner.Test
{
    public class MatchManagerTests
    {
        [Fact]
        public void MatchManager_Constructor_InitializesCorrectly()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "TitForTat1" },
                new TitForTat { Name = "TitForTat2" }
            };
            int setsPerMatch = 100;

            // Act
            var manager = new MatchManager(strategies, setsPerMatch);

            // Assert
            Assert.Equal(setsPerMatch, manager.SetsPerMatch);
            Assert.Empty(manager.GetMatches());
        }

        [Fact]
        public void CreateTournament_CreatesCorrectNumberOfMatches()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "Strategy1" },
                new TitForTat { Name = "Strategy2" },
                new TitForTat { Name = "Strategy3" }
            };
            var manager = new MatchManager(strategies, 10);

            // Act
            manager.CreateTournament();

            // Assert
            // With 3 strategies, we should have 3 matches (1 vs 2, 1 vs 3, 2 vs 3)
            Assert.Equal(3, manager.GetMatches().Count);
        }

        [Fact]
        public void CreateTournament_WithFourStrategies_CreatesSixMatches()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "Strategy1" },
                new TitForTat { Name = "Strategy2" },
                new TitForTat { Name = "Strategy3" },
                new TitForTat { Name = "Strategy4" }
            };
            var manager = new MatchManager(strategies, 10);

            // Act
            manager.CreateTournament();

            // Assert
            // Formula: n*(n-1)/2 = 4*3/2 = 6
            Assert.Equal(6, manager.GetMatches().Count);
        }

        [Fact]
        public void CreateTournament_ClearsPreviousMatches()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "Strategy1" },
                new TitForTat { Name = "Strategy2" }
            };
            var manager = new MatchManager(strategies, 10);
            manager.CreateTournament();

            // Act
            manager.CreateTournament();

            // Assert
            Assert.Single(manager.GetMatches());
        }

        [Fact]
        public void PlayAllMatches_ExecutesAllMatches()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "Strategy1" },
                new TitForTat { Name = "Strategy2" }
            };
            var manager = new MatchManager(strategies, 5);
            manager.CreateTournament();

            // Act
            manager.PlayAllMatches();

            // Assert
            var matches = manager.GetMatches();
            Assert.All(matches, m =>
            {
                Assert.True(m.Player1Score > 0 || m.Player2Score > 0);
                Assert.Equal(5, m.SetResultsForPlayer1.Count);
            });
        }

        [Fact]
        public void GetTotalScores_CalculatesCorrectly()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "Strategy1" },
                new TitForTat { Name = "Strategy2" }
            };
            var manager = new MatchManager(strategies, 10);
            manager.CreateTournament();
            manager.PlayAllMatches();

            // Act
            var scores = manager.GetTotalScores();

            // Assert
            Assert.Equal(2, scores.Count);
            Assert.True(scores.ContainsKey("Strategy1"));
            Assert.True(scores.ContainsKey("Strategy2"));
            // Both cooperate always, so 3 points * 10 sets = 30
            Assert.Equal(30, scores["Strategy1"]);
            Assert.Equal(30, scores["Strategy2"]);
        }

        [Fact]
        public void GetTotalScores_WithMultipleMatches_AccumulatesScores()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "Strategy1" },
                new TitForTat { Name = "Strategy2" },
                new TitForTat { Name = "Strategy3" }
            };
            var manager = new MatchManager(strategies, 10);
            manager.CreateTournament();
            manager.PlayAllMatches();

            // Act
            var scores = manager.GetTotalScores();

            // Assert
            Assert.Equal(3, scores.Count);
            // Each plays 2 matches * 10 sets * 3 points = 60
            Assert.Equal(60, scores["Strategy1"]);
            Assert.Equal(60, scores["Strategy2"]);
            Assert.Equal(60, scores["Strategy3"]);
        }

        [Fact]
        public void GetMatchResults_ReturnsAllMatchSummaries()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "Strategy1" },
                new TitForTat { Name = "Strategy2" }
            };
            var manager = new MatchManager(strategies, 5);
            manager.CreateTournament();
            manager.PlayAllMatches();

            // Act
            var results = manager.GetMatchResults();

            // Assert
            Assert.Single(results);
            Assert.Contains("Strategy1 vs Strategy2", results[0]);
        }

        [Fact]
        public void GetAllSetsIntoTournament_ReturnsAllSetDetails()
        {
            // Arrange
            var strategies = new List<IStrategy>
            {
                new TitForTat { Name = "Strategy1" },
                new TitForTat { Name = "Strategy2" }
            };
            var manager = new MatchManager(strategies, 3);
            manager.CreateTournament();
            manager.PlayAllMatches();

            // Act
            var allSets = manager.GetAllSetsIntoTournament();

            // Assert
            Assert.Equal(3, allSets.Count);
            Assert.All(allSets, s => Assert.Contains("Strategy1 vs Strategy2", s));
        }

        [Fact]
        public void MatchManager_DefaultSetsPerMatch_Is200()
        {
            // Arrange
            var strategies = new List<IStrategy> { new TitForTat { Name = "Strategy1" } };

            // Act
            var manager = new MatchManager(strategies);

            // Assert
            Assert.Equal(200, manager.SetsPerMatch);
        }
    }
}
