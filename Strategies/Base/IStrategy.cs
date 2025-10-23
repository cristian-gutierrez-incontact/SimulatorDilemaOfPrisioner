using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDilemaDelPrisioner.Strategies.Base
{
    public interface IStrategy
    {
        public string Name { get; }
        public bool MakeDecision(List<Set> history);
    }
}
