using CarShop.Web.ViewModels.DamageReport;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Data.Interfaces
{
    public interface IDamageReportService
    {
        Task<DamageReportIndexViewModel?> GetDamageReportsByCarIdAsync(Guid carId);
        Task AddDamageReportAsync(DamageReportEditViewModel form);
        Task<DamageReportEditViewModel?> GetDamageReportForEditAsync(Guid reportId);
        Task EditDamageReportAsync(DamageReportEditViewModel form);
        Task RemoveDamageReportAsync(Guid reportId);
        Task<IEnumerable<DamageReportIndexViewModel>> GetAllCarsWithDamageReportsAsync();
    }
}
