using System;

namespace NBCExample.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public decimal Price { get; set; }
    }
}