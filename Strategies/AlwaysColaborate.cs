using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class AlwaysColaborate : IStrategy
    {
        public string Name { get;}
        public AlwaysColaborate(string name)
        {
            Name = name;
        }   
        public bool MakeDecision(List<Base.Set> history)
        {
            return true;
        }   
    }
}
