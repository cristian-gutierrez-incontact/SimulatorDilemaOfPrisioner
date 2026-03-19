using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class AlvaroR : IStrategy
    {
        public string Name { get; set; }
        private readonly System.Random random;

        public AlvaroR()
        {
            Name = "AlvaroR";
            random = new System.Random();
        }

        public bool MakeDecision(List<Set> history)
        {
            // Start with cooperation
            if (history.Count == 0)
                return true;

            var positiveDecisions = history.Count(x=> x.OpponentDecision == true);
            var negativeDecisions = history.Count(x=> x.OpponentDecision == false);
            
            if (positiveDecisions < negativeDecisions)
            {
                // If the opponent has defected more than cooperated, defect
                return false;
            }
            int p = random.Next(1, 101);
            if (p <= 20)
                return false;
            else
            {
                return true;
            }
        }
    }
}