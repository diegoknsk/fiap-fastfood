﻿using FastFood.Domain.Common.Exceptions;
using FastFood.Domain.Entities.CustomerIdentification.ValueObjects;

namespace FastFood.Domain.Entities.CustomerIdentification
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public Email? Email { get; private set; }

        public Cpf? Cpf { get; private set; }
        public EnumCustomerType CustomerType { get; private set; }

        protected Customer() //apenas para o ef
        {
            
        }

        public Customer(Guid id, string? name, Email? email, Cpf? cpf, EnumCustomerType customerType)
        {
            Id = id;
            SetProperties(name, email, cpf, customerType);
        }

        public void AddCustomer(string? name, Email? email, Cpf? cpf, EnumCustomerType customerType)
        {
            Id = Guid.NewGuid();
            SetProperties(name, email, cpf, customerType);
        }

        private void SetProperties(string? name, Email? email, Cpf? cpf, EnumCustomerType customerType)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            CustomerType = customerType;
        }

    }
}
