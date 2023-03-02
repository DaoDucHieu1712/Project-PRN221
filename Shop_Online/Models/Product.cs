using System;
using System.Collections.Generic;

namespace Shop_Online.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int Cid { get; set; }

        public virtual Category CidNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
