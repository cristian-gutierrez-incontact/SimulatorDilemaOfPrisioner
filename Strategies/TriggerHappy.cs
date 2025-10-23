using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class TriggerHappy : IStrategy
    {
        public string Name { get; }
        private bool _triggered = false;

        public TriggerHappy(string name)
        {
            Name = name;
        }

        public bool MakeDecision(List<Set> history)
        {
            // If we haven't been triggered yet, check if opponent has cooperated twice in a row
            if (!_triggered && history.Count >= 2)
            {
                var lastTwo = history.TakeLast(2).ToList();
                if (lastTwo.All(set => set.OpponentDecision)) // Opponent cooperated twice
                {
                    _triggered = true;
                }
            }

            // Once triggered by opponent's cooperation, always defect
            if (_triggered)
            {
                return false;
            }

            // Before triggering, cooperate
            return true;
        }
    }
}