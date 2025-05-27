using FastFood.Domain.Ports.Common;
using FastFood.Infra.Data.Context;

namespace FastFood.Infra.Data.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FastFoodDbContext _context;

        public UnitOfWork(FastFoodDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
