using FastFood.Domain.Entities.CustomerIdentification;
using FastFood.Domain.Entities.CustomerIdentification.ValueObjects;
using FastFood.Domain.Ports.Common;
using FastFood.Domain.Ports.CustomerIdentification;

namespace FastFood.Application.Services.CustomerIdentification
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAppService(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> IdentifyByCpfAsync(string cpf)
        {
            var existing = await _repository.GetByCpfAsync(cpf);
            if (existing == null)
                throw new ApplicationException("Cliente não encontrado.");

            return existing;
        }

        public async Task<Customer> RegisterCustomerAsync(string name, string email, string cpf)
        {
            if (await _repository.ExistsCpfAsync(cpf))
                throw new ApplicationException("CPF já cadastrado.");

            var customer = new Customer(
                Guid.NewGuid(),
                name,
                new Email(email),
                new Cpf(cpf),
                EnumCustomerType.Identified
            );

            await _repository.AddAsync(customer);
            var success = await _unitOfWork.CommitAsync();

            if (!success)
                throw new ApplicationException("Erro ao salvar cliente.");

            return customer;
        }

        public async Task<Customer> RegisterAnonymousAsync()
        {
            var anonymous = new Customer(
                Guid.NewGuid(),
                null,
                null,
                null,
                EnumCustomerType.Anonymous
            );

            await _repository.AddAsync(anonymous);
            var success = await _unitOfWork.CommitAsync();

            if (!success)
                throw new ApplicationException("Erro ao salvar cliente anônimo.");

            return anonymous;
        }
    }
}
