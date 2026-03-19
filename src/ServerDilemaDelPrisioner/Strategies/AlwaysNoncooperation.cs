using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class AlwaysNoncooperation : IStrategy
    {
        public string Name { get; set; }
        public AlwaysNoncooperation()
        {
            Name = "AlwaysNoncooperation";
        }   
        public bool MakeDecision(List<Base.Set> history)
        {
            return false;
        }   
    }
}
