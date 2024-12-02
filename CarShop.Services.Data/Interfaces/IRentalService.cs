using CarShop.Web.ViewModels.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Data.Interfaces
{
    public interface IRentalService
    {
        Task<IndexRentalViewModel?> GetRentalIndexAsync(Guid carId);
        Task<ConfirmRentalViewModel?> GetConfirmRentalIndexAsync(IndexRentalViewModel viewModel, Guid carId);
        Task<bool> AddRentalAsync(ConfirmRentalViewModel viewModel, Guid userId, Guid carId);
        Task<List<RentedCarViewModel>> GetRentedCarsAsync(Guid userId);
        Task<bool> RemoveRentalAsync(Guid rentalId, Guid userId);
    }
}
