using System;
using System.Collections.Generic;

namespace shoppingAPI.Models.EF
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int PId { get; set; }
        public string? PName { get; set; }
        public string? PCategory { get; set; }
        public int? PPrice { get; set; }
        public bool? PIsAvailable { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
