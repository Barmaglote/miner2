using System.Collections.Generic;

namespace EDU.Miner.Core.DataContext
{
    /// <summary>
    /// Provider of data for storing history if records.
    /// </summary>
    public interface IHistoryDataProvider
    {
        IEnumerable<HistoricalRecord> Records { get; }
        void AddNewRecord(HistoricalRecord record);
    }
}
