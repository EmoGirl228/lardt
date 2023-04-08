using System;
using System.Collections.Generic;

namespace Domain.Models
{

    public partial class Review
    {
        public int Userid { get; set; }

        public int? Rating { get; set; }

        public string? Comment { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
