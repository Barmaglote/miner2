using System.Data.Entity;

namespace EDU.Miner.Core.DataContext
{
    public class HistoryDataContext : DbContext
    {
        public HistoryDataContext()
            : base("name=HistoryDataModel")
        {
        }

        public virtual DbSet<HistoricalRecord> HistoryRecords { get; set; }
    }
}