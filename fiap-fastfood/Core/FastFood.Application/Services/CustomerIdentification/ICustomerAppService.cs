using FastFood.Domain.Entities.CustomerIdentification;

namespace FastFood.Application.Services.CustomerIdentification
{
    public interface ICustomerAppService
    {
        Task<Customer> IdentifyByCpfAsync(string cpf);
        Task<Customer> RegisterCustomerAsync(string name, string email, string cpf);
        Task<Customer> RegisterAnonymousAsync();
    }
}
