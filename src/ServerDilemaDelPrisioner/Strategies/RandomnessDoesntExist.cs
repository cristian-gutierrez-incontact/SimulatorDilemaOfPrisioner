using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class Bernardo : IStrategy
    {
        public string Name { get; set; }

        public Bernardo()
        {
            Name = "Randomness Doesn't Exist";
        }

        public bool MakeDecision(List<Set> history)
        {
            int sum = history.Select(h => h.OpponentDecision ? 1 : 0).Sum();
            int promedio = sum / (history.Count == 0 ? 1 : history.Count);

            if (promedio >= 0.5)
                return false;
            else
                return true;
        }
    }
}
