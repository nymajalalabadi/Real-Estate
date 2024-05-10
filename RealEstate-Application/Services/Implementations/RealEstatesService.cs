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

        public async Task<Estate> GetEstateById(int id)
        {
             var esate = await _realEstatesRepository.GetEstateById(id);

            if (esate == null)
            {
                return null;
            }

            return esate;
        }

        public async Task EditRealEstate(EditRealEstateViewModel edit, int categoryId)
        {
            var estate = await _realEstatesRepository.GetEstateById(edit.Id);

            if (estate == null)
            {
                return;
            }

            estate.Title = edit.Title;
            estate.Description = edit.Description;
            estate.Price = edit.Price;
            estate.Address = edit.Address;
            estate.Metrage = edit.Metrage;

            if (edit.ImgUp != null && edit.ImgUp.IsImage())
            {
                var nameImage = Guid.NewGuid().ToString("N") + Path.GetExtension(edit.ImgUp.FileName);

                edit.ImgUp.AddImageToServer(nameImage, PathExtensions.EstateOrginServer, 150, 150, PathExtensions.EstateThumbServer, estate.Image);

                estate.Image = nameImage;
            }

            estate.CategoryId = categoryId;

            _realEstatesRepository.EditRealEstate(estate);

            await _realEstatesRepository.SaveChanges();
        }

        public async Task DeleteRealEstate(DetailRealEstateViewModel edit)
        {
            var estate = await _realEstatesRepository.GetEstateById(edit.Id);

            if (estate == null)
            {
                return;
            }

            if (edit.Image != null)
            {
                string saveDir = PathExtensions.EstateOrginServer;

                string deletePath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, edit.Image);

                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }
            }

             _realEstatesRepository.DeleteRealEstate(estate);

            await _realEstatesRepository.SaveChanges();
        }

    }
}
