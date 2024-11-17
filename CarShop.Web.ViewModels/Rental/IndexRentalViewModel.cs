using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Rental
{
    public class IndexRentalViewModel : IValidatableObject
    {
        [Required]
        public string CarId { get; set; } = null!;

        [Display(Name = "Car Make")]
        public string Make { get; set; } = string.Empty;

        [Display(Name = "Car Model")]
        public string Model { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("End date must be greater than the start date.", new[] { "EndDate" });
            }
        }
    }
}
