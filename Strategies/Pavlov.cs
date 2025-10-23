using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class Pavlov : IStrategy
    {
        public string Name { get; }

        public Pavlov(string name)
        {
            Name = name;
        }

        public bool MakeDecision(List<Set> history)
        {
            // Start with cooperation
            if (history.Count == 0)
                return true;

            var lastSet = history.Last();
            
            // Calculate last round's payoff
            int myScore;
            if (lastSet.OurDecision && lastSet.OpponentDecision) // Both cooperated
                myScore = 3;
            else if (!lastSet.OurDecision && !lastSet.OpponentDecision) // Both defected
                myScore = 1;
            else if (lastSet.OurDecision && !lastSet.OpponentDecision) // I cooperated, opponent defected
                myScore = 0;
            else // I defected, opponent cooperated
                myScore = 5;

            // If I got a good score (3 or 5), repeat last action (Win-Stay)
            // If I got a bad score (0 or 1), change action (Lose-Shift)
            if (myScore >= 3)
                return lastSet.OurDecision; // Repeat last action
            else
                return !lastSet.OurDecision; // Change action
        }
    }
}