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

        protected CustomIngredient()
        {
        }

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
            Name = name;
            Price = price;
        }

    }
}
