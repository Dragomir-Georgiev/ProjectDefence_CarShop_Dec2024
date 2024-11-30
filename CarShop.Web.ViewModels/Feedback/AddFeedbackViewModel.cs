using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Feedback
{
    public class AddFeedbackViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
