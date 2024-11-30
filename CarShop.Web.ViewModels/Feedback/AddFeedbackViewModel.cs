using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.Feedback;
namespace CarShop.Web.ViewModels.Feedback
{
    public class AddFeedbackViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength, ErrorMessage = "Your comment should be between 10 and 250 characters long.")]
        public string Comment { get; set; } = null!;
        [Required]
        [Range(RatingMinRange, RatingMaxRange , ErrorMessage = "Your rating should be between 1 and 5 included.")]
        public int Rating { get; set; }
    }
}
