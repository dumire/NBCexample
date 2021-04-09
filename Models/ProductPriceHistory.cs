using System.Collections.Generic;
using System;

namespace NBCExample.Models
{
    public class ProductPriceHistory {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public List<PriceChange> PriceChanges { get; set; }

        public ProductPriceHistory(Product product,List<PriceHistory> priceHistories)
        {
            Id = product.Id;
            Name = product.Name;
            Created = product.Created;

            var changes = new List<PriceChange>();
            foreach (var history in priceHistories)
            {
                changes.Add(new PriceChange(history));
            }
            PriceChanges = changes;
        }
    }

    public class PriceChange
    {
        public DateTime Date { get; set; }
        public decimal NewPrice { get; set; }

        public PriceChange(PriceHistory history)
        {
            Date = history.Date;
            NewPrice = history.NewPrice;
        }
    }
    
}