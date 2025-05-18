using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Entities.OrderManagement
{
    public class Ingredient
    {
        [Key]
        public int Id { get; private set; }

        public string? Name { get; private set; }
    }
}
