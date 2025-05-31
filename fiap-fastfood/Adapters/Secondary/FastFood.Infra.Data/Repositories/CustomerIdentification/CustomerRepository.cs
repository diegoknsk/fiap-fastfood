using FastFood.Domain.Entities.CustomerIdentification;
using FastFood.Domain.Ports.CustomerIdentification;
using FastFood.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infra.Data.Repositories.CustomerIdentification
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FastFoodDbContext _context;

        public CustomerRepository(FastFoodDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByCpfAsync(string cpf)
        {
            return await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Cpf != null && c.Cpf.Value == cpf);
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task<bool> ExistsCpfAsync(string cpf)
        {
            return await _context.Customers
                .AnyAsync(c => c.Cpf != null && c.Cpf.Value == cpf);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
