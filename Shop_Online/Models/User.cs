using System;
using System.Collections.Generic;

namespace Shop_Online.Models
{
    public partial class User
    {
        public User()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
