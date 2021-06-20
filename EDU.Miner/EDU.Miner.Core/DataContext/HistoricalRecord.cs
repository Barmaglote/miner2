using System;

namespace EDU.Miner.Core.DataContext
{
    public class HistoricalRecord
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int TotalTimeInSeconds { get; set; }
    }
}
