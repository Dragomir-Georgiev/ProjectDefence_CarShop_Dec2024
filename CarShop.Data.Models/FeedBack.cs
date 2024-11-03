using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.Feedback;

namespace CarShop.Data.Models
{
    public class Feedback
    {
        [Key]
        [Comment("Feedback unique identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        public Guid ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]
        [MaxLength(CommentMaxLength)]
        [Comment("Feedback comment from user for the car")]
        public string Comment { get; set; } = null!;
        [Required]
        public int Rating { get; set; }
        [Required]
        public DateTime FeedbackDate { get; set; }
    }
}
