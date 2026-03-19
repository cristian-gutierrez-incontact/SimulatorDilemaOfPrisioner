using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class AlvaroT : IStrategy
    {

        public string Name { get; set; }
        private readonly Random _random;
        private bool _hasBeenBetrayed = false;

        public AlvaroT()
        {
            Name = "AlvaroT";
            _random = new Random();
        }

        public bool MakeDecision(List<Set> history)
        {
            if (history.Count < 100)
            {
                return _random.Next(0, 100) >= 50;
            }
            else
            {
                return _random.Next(0, 100) >= 10;
            }
        }
    }
}
