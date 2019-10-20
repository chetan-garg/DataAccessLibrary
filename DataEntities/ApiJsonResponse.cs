using System;
using System.Collections.Generic;
using System.Text;

namespace Unibet.DataEntities
{
    public class Rootobject
    {
        public bool success { get; set; }
        public int timestamp { get; set; }
        public string _base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }
    }

    public class Rates
    {
        public float AUD { get; set; }
        public float GBP { get; set; }
        public float SEK { get; set; }
        public float USD { get; set; }
    }

}
