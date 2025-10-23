using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class Grudger : IStrategy
    {
        public string Name { get; set; }
        private bool hasBeenBetrayed = false;

        public Grudger()
        {
            Name = "Grudger";
        }

        public bool MakeDecision(List<Set> history)
        {
            // Once betrayed, never cooperate again
            if (hasBeenBetrayed)
                return false;

            // Check if opponent has ever defected
            foreach (var set in history)
            {
                if (!set.OpponentDecision) // Opponent defected
                {
                    hasBeenBetrayed = true;
                    return false;
                }
            }

            // Cooperate if never betrayed
            return true;
        }
    }
}