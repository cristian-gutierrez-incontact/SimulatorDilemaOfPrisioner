using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class SuspiciousTitForTat : IStrategy
    {
        public string Name { get; set; }

        public SuspiciousTitForTat()
        {
            Name = "SuspiciousTitForTat";
        }

        public bool MakeDecision(List<Set> history)
        {
            // Start with defection (suspicious)
            if (history.Count == 0)
                return false;

            // Copy the opponent's last move
            var lastSet = history.Last();
            return lastSet.OpponentDecision;
        }
    }
}