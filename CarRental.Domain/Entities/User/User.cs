using CarRental.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities.User
{
    public class User:BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public ICollection<UserInRole> UserInRole { get; set;}
    }
}
