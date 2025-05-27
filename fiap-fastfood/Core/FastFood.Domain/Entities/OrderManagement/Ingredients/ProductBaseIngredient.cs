using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Entities.OrderManagement.Ingredients
{
    public class ProductBaseIngredient : CustomIngredient
    {
        public Guid ProductId { get; private set; }

        protected ProductBaseIngredient() { }

        public ProductBaseIngredient(Guid id, string? name, decimal price, Guid productId)
            : base(id, name, price)
        {
            ProductId = productId;
        }
    }
}
