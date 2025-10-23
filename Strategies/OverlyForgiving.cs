using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class OverlyForgiving : IStrategy
    {
        public string Name { get; }

        public OverlyForgiving(string name)
        {
            Name = name;
        }

        public bool MakeDecision(List<Set> history)
        {
            // This strategy always cooperates no matter what
            // Even if the opponent has been defecting constantly
            // It's bad because it can be easily exploited by always-defect strategies
            
            // Count how many times opponent has defected
            int opponentDefections = history.Count(set => !set.OpponentDecision);
            int totalRounds = history.Count;
            
            // Even if opponent defects 90% of the time, still cooperate
            // This makes it extremely exploitable
            if (totalRounds > 10 && opponentDefections > totalRounds * 0.9)
            {
                // Even when heavily exploited, only defect 10% of the time
                return history.Count % 10 != 0;
            }
            
            return true; // Always cooperate
        }
    }
}