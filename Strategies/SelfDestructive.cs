using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class SelfDestructive : IStrategy
    {
        public string Name { get; set; }

        public SelfDestructive()
        {
            Name = "SelfDestructive";
        }

        public bool MakeDecision(List<Set> history)
        {
            // This strategy actively tries to hurt its own score
            // It cooperates when it should defect and defects when it should cooperate
            
            if (history.Count == 0)
            {
                return true; // Start cooperating
            }
            
            // Calculate our current score to see how we're doing
            int ourScore = 0;
            foreach (var set in history)
            {
                if (set.OurDecision && set.OpponentDecision)
                {
                    ourScore += 3; // Mutual cooperation
                }
                else if (set.OurDecision && !set.OpponentDecision)
                {
                    ourScore += 0; // We cooperated, opponent defected (sucker)
                }
                else if (!set.OurDecision && set.OpponentDecision)
                {
                    ourScore += 5; // We defected, opponent cooperated (temptation)
                }
                else
                {
                    ourScore += 1; // Mutual defection
                }
            }
            
            // If we're doing well (high score), start defecting against cooperators
            // If we're doing poorly, keep cooperating against defectors
            var lastSet = history.Last();
            
            if (ourScore > history.Count * 2.5) // We're doing well
            {
                // Sabotage ourselves by cooperating against defectors
                return lastSet.OpponentDecision;
            }
            else
            {
                // We're already doing poorly, make it worse by defecting against cooperators
                return !lastSet.OpponentDecision;
            }
        }
    }
}