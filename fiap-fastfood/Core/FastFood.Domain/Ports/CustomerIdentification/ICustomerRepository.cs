using FastFood.Domain.Entities.CustomerIdentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Ports.CustomerIdentification
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByCpfAsync(string cpf);
        Task<Customer?> GetByIdAsync(Guid id);
        Task AddAsync(Customer customer);
        Task<bool> ExistsCpfAsync(string cpf);
        Task SaveChangesAsync();
    }
}
