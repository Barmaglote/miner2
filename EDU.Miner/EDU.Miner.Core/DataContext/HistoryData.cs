using EDU.Miner.Core.Model.Factory;
using System.Collections.Generic;
using System.Linq;

namespace EDU.Miner.Core.DataContext
{
    public class HistoryData: IHistoryDataProvider
    {
        private static HistoryData _UniqueInstance = null;
        private IAbstractFactory _Factory = null;
        private static int _MaxRecords = 10;

        private HistoryData()
        {
            this._Factory = new ConcreteFactory();
        }

        public static HistoryData GetInstance()
        {
            if (_UniqueInstance == null)
            {
                _UniqueInstance = new HistoryData();
            }

            return _UniqueInstance;
        }

        public void AddNewRecord(HistoricalRecord record)
        {
            using (var dbContext = this._Factory.CreateHistoryDataModelContext())
            {
                if (dbContext.HistoryRecords.Count() < _MaxRecords || dbContext.HistoryRecords.Any(rec => rec.TotalTimeInSeconds > record.TotalTimeInSeconds))
                {
                    dbContext.HistoryRecords.Add(record);
                    dbContext.SaveChanges();
                }

                if (dbContext.HistoryRecords.Count() > _MaxRecords)
                {
                    var toDelete = dbContext.HistoryRecords.OrderByDescending(r => r.TotalTimeInSeconds).First();
                    dbContext.HistoryRecords.Remove(toDelete);
                    dbContext.SaveChanges();
                }
            } 
        }

        public IEnumerable<HistoricalRecord> Records 
        {
            get {
                var result = new List<HistoricalRecord>();
                using (var dbContext = this._Factory.CreateHistoryDataModelContext())
                {
                    if (dbContext?.HistoryRecords != null && dbContext.HistoryRecords.Any()) {
                        result.AddRange(dbContext.HistoryRecords.ToList());
                    }
                }

                return result;
            }
        }
    }
}
