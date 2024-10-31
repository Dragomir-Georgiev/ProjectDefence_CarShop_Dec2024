using Microsoft.AspNetCore.Identity;

namespace CarShop.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            this.Id = Guid.NewGuid();
        }

        public ICollection<Rental> Rentals { get; set; } = new HashSet<Rental>();
        public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
    }
}
