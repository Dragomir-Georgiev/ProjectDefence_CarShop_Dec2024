using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Feedback
{
    using CarShop.Data.Models;
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime FeedbackDate { get; set; }
        public bool IsOwner { get; set; }
    }
}
