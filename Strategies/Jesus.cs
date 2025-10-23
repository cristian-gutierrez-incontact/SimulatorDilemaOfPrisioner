using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class Jesus : IStrategy
    {
        public string Name { get; set; }

        public Jesus()
        {
            Name = "Jesus";
        }

        public bool MakeDecision(List<Set> history)
        {
            if (history == null || history.Count == 0)
                return true; 

            return history[^1].OpponentDecision;
        }
    }
}