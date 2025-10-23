using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class SpitefulRandom : IStrategy
    {
        public string Name { get; set; }
        private readonly Random _random;
        private bool _hasBeenBetrayed = false;

        public SpitefulRandom()
        {
            Name = "SpitefulRandom";
            _random = new Random();
        }

        public bool MakeDecision(List<Set> history)
        {
            // Check if we've been betrayed
            if (!_hasBeenBetrayed && history.Any(set => !set.OpponentDecision))
            {
                _hasBeenBetrayed = true;
            }

            // If betrayed, defect 80% of the time randomly
            if (_hasBeenBetrayed)
            {
                return _random.Next(0, 100) >= 80; // 20% chance to cooperate
            }

            // Before betrayal, still randomly defect 40% of the time
            return _random.Next(0, 100) >= 40; // 60% chance to cooperate
        }
    }
}