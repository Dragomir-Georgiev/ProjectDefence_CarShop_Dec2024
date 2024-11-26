using CarShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Web.ViewModels.Car
{
    using AutoMapper;
    using CarShop.Data.Models;
    public class DeleteCarViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public string Id { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, DeleteCarViewModel>()
                .ForMember(c => c.CategoryName, x => x.MapFrom(s => s.CarCategory.CategoryName));
        }
    }
}
