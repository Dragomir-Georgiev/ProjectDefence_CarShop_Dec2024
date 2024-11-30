using CarShop.Web.ViewModels.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Data.Interfaces
{
    public interface IFeedbackService
    {
        Task<IndexFeedbackViewModel?> GetFeedbacksByCarIdAsync(Guid carId, Guid userId);
        Task<bool> AddFeedbackAsync(AddFeedbackViewModel viewModel, Guid userId);
        Task<AddFeedbackViewModel?> GetFeedbackForEditAsync(Guid feedbackId, Guid userId);
        Task<bool> EditFeedbackAsync(AddFeedbackViewModel form, Guid userId);
        Task<bool> RemoveFeedbackAsync(Guid feedbackId, Guid userId);
    }
}
