using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class WorstOfBothWorlds : IStrategy
    {
        public string Name { get; set; }

        public WorstOfBothWorlds()
        {
        }

        public bool MakeDecision(List<Set> history)
        {
            // This strategy does the opposite of what would be beneficial
            // If opponent is cooperating, we defect (missing out on mutual cooperation)
            // If opponent is defecting, we cooperate (getting exploited)
            
            if (history.Count == 0)
            {
                return false; // Start with defection
            }

            var lastSet = history.Last();
            
            // Do the opposite of what the opponent did
            // This is terrible because:
            // - When opponent cooperates, we defect (losing mutual cooperation benefits)
            // - When opponent defects, we cooperate (getting the sucker's payoff)
            return !lastSet.OpponentDecision;
        }
    }
}