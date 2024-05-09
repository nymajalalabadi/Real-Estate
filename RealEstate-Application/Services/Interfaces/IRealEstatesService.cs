using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.Entities.RealEstate;
using RealEstate_Domain.ViewModels.Admin.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Services.Interfaces
{
    public interface IRealEstatesService
    {
        Task<List<RealEstateAdminViewModel>> GetAllRealEstates();

        List<SelectListItem> GetAllCategories();

        Task<Category?> GetCategoryById(int id);

        Task CreateRealEstate(CreateRealEstateViewModel create, int categoryId);

        Task<Estate> GetEstateById(int id);

        Task EditRealEstate(EditRealEstateViewModel edit, int categoryId);
    }
}
