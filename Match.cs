using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;

namespace ServerDilemaDelPrisioner
{
    public class Match
    {
        public IStrategy Player1Strategy { get; set; }
        public IStrategy Player2Strategy { get; set; }
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }
        public int Sets { get; }
        public List<Set> SetResultsForPlayer1 { get; }
        public List<Set> SetResultsForPlayer2 { get; }

        public Match(IStrategy player1Strategy, IStrategy player2Strategy, int sets)
        {
            Player1Strategy = player1Strategy;
            Player2Strategy = player2Strategy;
            Sets = sets;
            SetResultsForPlayer1 = new List<Set>();
            SetResultsForPlayer2 = new List<Set>();
            Player1Score = 0;
            Player2Score = 0;
        }

        public void PlaySet(int numberSet)
        {
            
            Type type1 = Player1Strategy.GetType();
            IStrategy instance1 = (IStrategy)Activator.CreateInstance(type1);
            instance1.Name= Player1Strategy.Name;
            Type type2 = Player2Strategy.GetType();
            IStrategy instance2 = (IStrategy)Activator.CreateInstance(type2);
            instance2.Name = Player2Strategy.Name;

            bool player1Cooperates = instance1.MakeDecision(SetResultsForPlayer1);
            bool player2Cooperates = instance2.MakeDecision(SetResultsForPlayer2);
            
            int score1, score2;

            if (player1Cooperates && player2Cooperates)
            {
                score1 = score2 = 3;
            }
            else
            {
                if (!player1Cooperates && !player2Cooperates)
                {
                    score1 = score2 = 1;
                }
                else
                {
                    if (player1Cooperates && !player2Cooperates)
                    {
                        score1 = 0;
                        score2 = 5;
                    }
                    else
                    {
                        score1 = 5;
                        score2 = 0;
                    }
                }
            }
            
            Player1Score += score1;
            Player2Score += score2;
                       
            var setForPlayer1 = new Set 
            { 
                SetNumber = numberSet,
                OurName = Player1Strategy.Name,
                OurDecision = player1Cooperates,
                OurScore=score1,
                TotalOurScore= Player1Score,
                LengthHistoricalOur= SetResultsForPlayer1.Count,
                OpponentName = Player2Strategy.Name,
                OpponentDecision = player2Cooperates,
                OpponentScore=score2,
                TotalOpponentScore= Player2Score,
                LengthHistoricalOpponent = SetResultsForPlayer2.Count,

            };
            
            var setForPlayer2 = new Set 
            { 
                SetNumber = numberSet,
                OurName = Player2Strategy.Name,
                OurDecision = player2Cooperates,
                OurScore = score2,
                TotalOurScore= Player2Score,
                LengthHistoricalOur = SetResultsForPlayer2.Count,
                OpponentName = Player1Strategy.Name,
                OpponentDecision = player1Cooperates,
                OpponentScore = score1,
                TotalOpponentScore= Player1Score,
                LengthHistoricalOpponent= SetResultsForPlayer1.Count,
            };
            
            SetResultsForPlayer1.Add(setForPlayer1);
            SetResultsForPlayer2.Add(setForPlayer2);
        }

        public void PlayAllSets()
        {
            for (int i = 1; i <= Sets; i++)
            {
                PlaySet(i);
            }
        }

        public List<string> ToStringTotalSets()
        {
            List<string> textOfSets = new();
            foreach (var set in SetResultsForPlayer1) 
            {
                textOfSets.Add($"{set.SetNumber}, {set.OurName} vs {set.OpponentName}: {set.OurDecision}-{set.OpponentDecision}, point {set.OurScore}-{set.OpponentScore}, totalscore {set.TotalOurScore}-{set.TotalOpponentScore}, Listhistorial legth {set.LengthHistoricalOur}-{set.LengthHistoricalOpponent}");
            }
            return textOfSets;
        }

        public override string ToString()
        {
            return $"{Player1Strategy.Name} vs {Player2Strategy.Name}: {Player1Score}-{Player2Score}";
        }
    }
}