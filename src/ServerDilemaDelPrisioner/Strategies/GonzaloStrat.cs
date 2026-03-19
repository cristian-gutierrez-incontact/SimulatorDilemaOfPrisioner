using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class GonzaloStrat : IStrategy
    {
        private object random;

        public string Name { get; set ; }

        public bool MakeDecision(List<Set> history)
        {
            int total = history.Count;

            if (history.Count == 0)
                return false;

            if (history.Where(x => x.OpponentDecision == false).Count() == total)
                return true;

            if (history.Where(x => x.OpponentDecision == true).Count() == total)
                return false;

            if (history.Where(x => x.OpponentDecision == false).Count() > total / 2)
                return true;
            else
                return false;

        }
    }
}
