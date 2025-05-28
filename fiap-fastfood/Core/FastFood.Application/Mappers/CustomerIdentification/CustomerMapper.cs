using FastFood.Application.Models.CustomerIdentification;
using FastFood.Domain.Entities.CustomerIdentification;

namespace FastFood.Application.Mappers.CustomerIdentification
{
    public static class CustomerMapper
    {
        public static CustomerModel ToModel(this Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email?.Value,
                Cpf = customer.Cpf?.Value,
                CustomerType = customer.CustomerType.ToString()
            };
        }
    }
}
