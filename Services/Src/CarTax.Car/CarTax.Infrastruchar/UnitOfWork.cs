using System.Threading.Tasks;

using CarTax.Car.Infrastruchar;
using Library_EF;

namespace CarTax.Car.Infrastruchar
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CarDBContext _dbContext;

        public UnitOfWork(CarDBContext dbContext)
            => _dbContext = dbContext;

        public async Task<int> Commit() => await _dbContext.SaveChangesAsync();

    }
}