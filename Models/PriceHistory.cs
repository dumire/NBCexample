using System;

namespace NBCExample.Models
{
    public class PriceHistory {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal NewPrice { get; set; }
    }
}