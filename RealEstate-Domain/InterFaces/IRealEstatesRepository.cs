using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.Entities.RealEstate;
using RealEstate_Domain.ViewModels.Admin.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.InterFaces
{
    public interface IRealEstatesRepository
    {
        Task<List<RealEstateAdminViewModel>> GetAllRealEstates();

        List<SelectListItem> GetAllCategories();

        Task<Category?> GetCategoryById(int id);

        Task<Estate?> GetEstateById(int id);

        void AddRealEstate(Estate estate);

        void EditRealEstate(Estate estate);

        Task SaveChanges();
    }
}
