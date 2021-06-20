namespace EDU.Miner.Core.Migrations
{ 
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EDU.Miner.Core.DataContext.HistoryDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EDU.Miner.Core.DataContext.HistoryDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
