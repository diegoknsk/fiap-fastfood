using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Entities.OrderManagement.Ingredients
{
    public class AddedIngredient : CustomIngredient
    {
        public Guid OrderedProductId { get; private set; }

        protected AddedIngredient() { }

        public AddedIngredient(Guid id, string? name, decimal price, Guid orderedProductId)
            : base(id, name, price)
        {
            OrderedProductId = orderedProductId;
        }
    }
}
