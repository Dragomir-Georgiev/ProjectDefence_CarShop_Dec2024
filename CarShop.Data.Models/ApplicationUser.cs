using Microsoft.AspNetCore.Identity;

namespace CarShop.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            this.Id = Guid.NewGuid();
        }

        public ICollection<ApplicationUserRental> ApplicationUserRentals { get; set; } = new HashSet<ApplicationUserRental>();
        public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
    }
}
