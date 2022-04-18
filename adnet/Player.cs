using System;
using System.Collections.Generic;

namespace adnet
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public decimal Price { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;

    }

}
