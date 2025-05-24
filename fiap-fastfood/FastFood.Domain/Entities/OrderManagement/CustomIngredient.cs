using FastFood.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Entities.OrderManagement
{
    public class CustomIngredient
    {
        public Guid Id { get; private set; }

        public string? Name { get; private set; }
        public decimal Price { get; private set; }

        public CustomIngredient(Guid? id, string name, decimal price)
        {
            Id = id ?? Guid.NewGuid();
            SetProperties(name, price);
        }

        public void AddCustomIngredient(string name, decimal price)
        {
            Id = Guid.NewGuid();
            SetProperties(name, price);
        }

        private void SetProperties(string name, decimal price)
        {
            DomainValidation.ThrowIfNullOrWhiteSpace(name, "Name is required.");
            /*
            if (price <= 0)
            {
                throw new DomainException("Price must be greater than zero.");
            }*/

            Name = name;
            Price = price;
        }

    }
}
