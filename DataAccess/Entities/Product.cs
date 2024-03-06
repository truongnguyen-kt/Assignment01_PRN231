using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public double Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
