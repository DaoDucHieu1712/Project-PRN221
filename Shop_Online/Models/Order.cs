using System;
using System.Collections.Generic;

namespace Shop_Online.Models
{
    public partial class Order
    {
        public Order()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public int Pid { get; set; }
        public int? Quatity { get; set; }

        public virtual Product PidNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
