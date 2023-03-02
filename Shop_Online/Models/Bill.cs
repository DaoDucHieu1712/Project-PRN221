using System;
using System.Collections.Generic;

namespace Shop_Online.Models
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int Oid { get; set; }
        public int Uid { get; set; }
        public int TotalPrice { get; set; }

        public virtual Order OidNavigation { get; set; }
        public virtual User UidNavigation { get; set; }
    }
}
