using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Basket
    {
        public string? Product { get; set; }

        public int ProductId { get; set; }

        public int Discount { get; set; }

        public virtual ICollection<BuyHistory> BuyHistories { get; } = new List<BuyHistory>();

        public virtual ICollection<Product> Products { get; } = new List<Product>();

        public virtual User? User { get; set; }
    }
}
