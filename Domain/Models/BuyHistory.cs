using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class BuyHistory
    {
        public int ProductId { get; set; }

        public int Userid { get; set; }

        public DateTime Buyid { get; set; }

        public virtual Basket Product { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
