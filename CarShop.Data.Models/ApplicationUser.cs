using Microsoft.AspNetCore.Identity;

namespace CarShop.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            this.Id = Guid.NewGuid();
        }
    }
}
