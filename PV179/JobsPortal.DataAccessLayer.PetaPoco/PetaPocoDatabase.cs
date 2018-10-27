using AsyncPoco;

namespace JobsPortal.DataAccessLayer.PetaPoco
{
    public class PetapocoDatabase
    {
        private const string ConnectionString = "Data source=(localdb)\\mssqllocaldb;Database=DemoEshopDatabaseSample;Trusted_Connection=True;MultipleActiveResultSets=true";

        private const string ProviderName = "System.Data.SqlClient";

        public IDatabase GetConnection() => new Database(ConnectionString, ProviderName);
    }
}
