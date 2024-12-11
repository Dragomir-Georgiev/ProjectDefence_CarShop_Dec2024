using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Common.EntityValidationConstants.Feedback;
using static CarShop.Common.EntityValidationMessages.Feedback;
namespace CarShop.Web.ViewModels.Feedback
{
    public class AddFeedbackViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength, ErrorMessage = CommentRequiredMessage)]
        public string Comment { get; set; } = null!;
        [Required]
        [Range(RatingMinRange, RatingMaxRange , ErrorMessage = RatingRequiredMessage)]
        public int Rating { get; set; }
    }
}
