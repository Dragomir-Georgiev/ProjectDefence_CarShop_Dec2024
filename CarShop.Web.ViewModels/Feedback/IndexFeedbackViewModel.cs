using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Feedback
{
    public class IndexFeedbackViewModel
    {
        public Guid CarId { get; set; }
        public string CarMakeModel { get; set; } = string.Empty;
        public List<FeedbackViewModel> Feedbacks { get; set; } = new List<FeedbackViewModel>();

    }
}
