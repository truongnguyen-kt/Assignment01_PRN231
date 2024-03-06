using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utils.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Price { get; set; }
        public string? CategoryId { get; set; }
    }
}
