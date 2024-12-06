using CarShop.Web.ViewModels.Car;
using CarShop.Web.ViewModels.CarCategories;
using System.Runtime.CompilerServices;

namespace CarShop.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<AllCarsIndexViewModel>> IndexGetAllAsync(AllCarSearchFilterViewModel inputModel);

        Task<AddCarViewModel> GetCarCategoriesAsync();

        Task AddCarAsync(AddCarViewModel carModel);

        Task<CarDetailsViewModel?> GetCarDetailsByIdAsync(Guid Id);

        Task<EditCarViewModel?> GetEditCarModelAsync(Guid id);

        Task<bool> UpdateCarAsync(Guid id, EditCarViewModel carModel);

        Task<DeleteCarViewModel?> GetDeleteCarModelAsync(Guid id);

        Task SoftDeleteCarAsync(Guid id);

        Task<int> GetCarsCountByFilterAsync(AllCarSearchFilterViewModel inputModel);
	}
}
