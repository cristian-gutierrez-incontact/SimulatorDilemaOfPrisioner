using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class Grudger : IStrategy
    {
        public string Name { get; }
        private bool hasBeenBetrayed = false;

        public Grudger(string name)
        {
            Name = name;
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