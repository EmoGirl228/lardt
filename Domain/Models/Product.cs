using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Product
    {
        public int Categoryid { get; set; }

        public int Productid { get; set; }

        public int Price { get; set; }

        public virtual Category Category { get; set; } = null!;

        public virtual Basket ProductNavigation { get; set; } = null!;
    }
}
