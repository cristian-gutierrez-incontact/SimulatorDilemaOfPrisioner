using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class TitForTwoTats : IStrategy
    {
        public string Name { get; }

        public TitForTwoTats(string name)
        {
            Name = name;
        }

        public bool MakeDecision(List<Set> history)
        {
            // Start with cooperation
            if (history.Count < 2)
                return true;

            // Only defect if opponent defected in the last two rounds
            var lastTwoSets = history.TakeLast(2).ToList();
            bool opponentDefectedBoth = lastTwoSets.All(set => !set.OpponentDecision);
            
            return !opponentDefectedBoth; // Cooperate unless opponent defected twice in a row
        }
    }
}