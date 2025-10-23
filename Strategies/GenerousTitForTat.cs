using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class GenerousTitForTat : IStrategy
    {
        public string Name { get; set; }
        private readonly System.Random random;

        public GenerousTitForTat()
        {
            Name = "GenerousTitForTat";
            random = new System.Random();
        }

        public bool MakeDecision(List<Set> history)
        {
            // Start with cooperation
            if (history.Count == 0)
                return true;

            var lastSet = history.Last();
            
            // If opponent cooperated last time, cooperate
            if (lastSet.OpponentDecision)
                return true;

            // If opponent defected, forgive with 10% probability
            if (random.NextDouble() < 0.1)
                return true; // Forgive and cooperate
            else
                return false; // Retaliate
        }
    }
}