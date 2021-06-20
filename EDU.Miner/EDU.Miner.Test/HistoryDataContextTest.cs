using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDU.Miner.Core.Model.Factory;
using System;
using EDU.Miner.Core.DataContext;
using System.Diagnostics;

namespace EDU.Miner.Test
{
    [TestClass]
    public class HistoryDataContextTest
    {
        [TestMethod]
        public void CanAddHistoryRecords()
        {
            var _Factory = new ConcreteFactory();
            var dbContext = _Factory.CreateHistoryDataModelContext();

            var dt = DateTime.Now;
            var recordTimeIsSeconds = 666;
            var gameRecord = new HistoricalRecord() { Time = dt, TotalTimeInSeconds = recordTimeIsSeconds };

            dbContext.HistoryRecords.Add(gameRecord);
            dbContext.SaveChanges();

            var founded = dbContext.HistoryRecords.SqlQuery($"Select * From dbo.HistoricalRecords Where TotalTimeInSeconds = {recordTimeIsSeconds}");

            Debug.WriteLine($"Total = {founded.ToListAsync().Result.Count.ToString()}");

            foreach (var item in founded.ToListAsync().Result)
            {
                Debug.WriteLine($"Id = {item.Id}, Time = {item.Time}, TotalTimeInSeconds = {item.TotalTimeInSeconds}");
            }

            var result = founded.ContainsAsync(gameRecord);

            Assert.IsTrue(result.Result);
        }
    }
}
