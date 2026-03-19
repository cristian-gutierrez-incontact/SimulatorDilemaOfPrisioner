using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner
{
    public class MatchManager
    {
        private List<Match> matches;
        private List<IStrategy> _listOfStrategies;
        public int SetsPerMatch { get; }

        public MatchManager(List<IStrategy> listOfStrategies, int setsPerMatch = 200)
        {
            matches = new List<Match>();
            _listOfStrategies = listOfStrategies;
            SetsPerMatch = setsPerMatch;
        }
        public void CreateTournament()
        {
            matches.Clear();

            for (int i = 0; i < _listOfStrategies.Count; i++)
            {
                for (int j = i + 1; j < _listOfStrategies.Count; j++)
                {
                    var match = new Match(_listOfStrategies[i], _listOfStrategies[j], SetsPerMatch);
                    matches.Add(match);
                }
            }
        }

        public void PlayAllMatches()
        {
            foreach (var match in matches)
            {
                match.PlayAllSets();
            }
        }

        public Dictionary<string, int> GetTotalScores()
        {
            var totalScores = new Dictionary<string, int>();

            foreach (var match in matches)
            {
                totalScores.TryAdd(match.Player1Strategy.Name, 0);
                totalScores.TryAdd(match.Player2Strategy.Name, 0);

                totalScores[match.Player1Strategy.Name] += match.Player1Score;
                totalScores[match.Player2Strategy.Name] += match.Player2Score;
            }

            return totalScores;
        }

        public List<string> GetAllSetsIntoTournament()
        {
            var list = new List<string>();
            foreach (var match in matches)
            {
                list.AddRange(match.ToStringTotalSets());
            }
            return list;
        }

        public List<string> GetMatchResults()
        {
            return matches.Select(m => m.ToString()).ToList();
        }

        public List<Match> GetMatches()
        {
            return new List<Match>(matches);
        }
    }
}