using CarShop.Web.ViewModels.Car;
using System.Runtime.CompilerServices;

namespace CarShop.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<AllCarsIndexViewModel>> IndexGetAllAsync();

        Task AddCarAsync(AddCarViewModel carModel);

        Task<CarDetailsViewModel?> GetCarDetailsByIdAsync(Guid Id);
    }
}
