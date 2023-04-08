using System;
using System.Collections.Generic;

namespace Domain.Models
{

    public partial class User
    {
        public int Userid { get; set; }

        public string Login1 { get; set; } = null!;

        public string Password1 { get; set; } = null!;

        public string Role1 { get; set; } = null!;

        public virtual ICollection<BuyHistory> BuyHistories { get; } = new List<BuyHistory>();

        public virtual Review? Review { get; set; }

        public virtual Basket UserNavigation { get; set; } = null!;
    }
}
