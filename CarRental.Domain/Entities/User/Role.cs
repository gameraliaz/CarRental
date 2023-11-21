using CarRental.Domain.Entities.Base;

namespace CarRental.Domain.Entities.User
{
    public class Role:BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
    }
}
