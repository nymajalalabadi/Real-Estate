using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using RealEstate_Application.Extentions;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Application.Utils;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.Entities.RealEstate;
using RealEstate_Domain.InterFaces;
using RealEstate_Domain.ViewModels.Admin.RealEstate;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RealEstate_Application.Services.Implementations
{
    public class RealEstatesService : IRealEstatesService
    {
        #region consractor

        private readonly IRealEstatesRepository _realEstatesRepository;

        public RealEstatesService(IRealEstatesRepository realEstatesRepository) 
        {
            _realEstatesRepository = realEstatesRepository;
        }

        #endregion

        public async Task<List<RealEstateAdminViewModel>> GetAllRealEstates()
        {
           return await _realEstatesRepository.GetAllRealEstates();
        }

        public List<SelectListItem> GetAllCategories()
        {
            return _realEstatesRepository.GetAllCategories();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _realEstatesRepository.GetCategoryById(id);
        }

        public async Task CreateRealEstate(CreateRealEstateViewModel create, int categoryId)
        {
            var newEstate = new Estate()
            {
                Address = create.Address,
                Description = create.Description,
                Title = create.Title,
                Metrage = create.Metrage,
                Price = create.Price,
            };

            if (create.ImgUp != null && create.ImgUp.IsImage())
            {
                var nameImage = Guid.NewGuid().ToString("N") + Path.GetExtension(create.ImgUp.FileName);

                create.ImgUp.AddImageToServer(nameImage, PathExtensions.EstateOrginServer, 150, 150, PathExtensions.EstateThumbServer);

                newEstate.Image = nameImage;
            }

            newEstate.CategoryId = categoryId;

            _realEstatesRepository.AddRealEstate(newEstate);

            await _realEstatesRepository.SaveChanges();
        }
    }
}
