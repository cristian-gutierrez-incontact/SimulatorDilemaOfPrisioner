using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;

namespace ServerDilemaDelPrisioner.Strategies
{
    public class RandomStrategy : IStrategy
    {
        public string Name { get; set; }
        private readonly System.Random random;

        public RandomStrategy()
        {
            Name = "RandomStrategy";
            random = new System.Random();
        }

        public bool MakeDecision(List<Set> history)
        {
            // 50% chance to cooperate, 50% chance to defect
            return random.NextDouble() < 0.5;
        }
    }
}