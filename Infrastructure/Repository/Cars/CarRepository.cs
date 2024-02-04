using Infrastructure.Database.SqlDatabase;

namespace Infrastructure.Repository.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly SqlServer _sqlServer;

        public CarRepository(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

    }
}
