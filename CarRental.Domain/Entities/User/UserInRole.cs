using CarRental.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Domain.Entities.User
{
    [PrimaryKey(nameof(UserId),nameof(RoleId))]
    public class UserInRole : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
