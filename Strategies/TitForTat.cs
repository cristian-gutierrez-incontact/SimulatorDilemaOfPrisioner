using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class TitForTat : IStrategy
    {
        public string Name { get; }

        public TitForTat(string name)
        {
            Name = name;
        }

        public bool MakeDecision(List<Set> history)
        {
            // Start with cooperation
            if (history.Count == 0)
                return true;

            // Copy the opponent's last move
            var lastSet = history.Last();
            return lastSet.OpponentDecision;
        }
    }
}