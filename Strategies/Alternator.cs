using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class Alternator : IStrategy
    {
        public string Name { get; }

        public Alternator(string name)
        {
            Name = name;
        }

        public bool MakeDecision(List<Set> history)
        {
            // Alternate between cooperation and defection
            // Start with cooperation on round 0, defect on round 1, cooperate on round 2, etc.
            return history.Count % 2 == 0;
        }
    }
}