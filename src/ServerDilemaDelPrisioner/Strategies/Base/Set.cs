using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDilemaDelPrisioner.Strategies.Base
{
    public class Set
    {
        public int SetNumber { get; set; }
        public string OurName { get; set; }
        public bool OurDecision { get; set; }
        public int OurScore { get; set; }
        public int TotalOurScore { get; set; }
        public int LengthHistoricalOur { get; set; }
        public string OpponentName { get; set; }
        public bool OpponentDecision { get; set; }
        public int OpponentScore { get;set; }
        public int TotalOpponentScore { get; set; }
        public int LengthHistoricalOpponent { get; set; }
    }
}
