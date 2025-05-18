using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Entities.OrderManagement
{
    [Table("Produtos")]
    public class Product
    {
        [Key] 
        public Guid? Id { get; private set; }
        public string? Name { get; private set; }
        public EnumProductCategory Category { get; private set; }
        public List<Ingredient>? Ingredients { get; private set; }



    }
}
