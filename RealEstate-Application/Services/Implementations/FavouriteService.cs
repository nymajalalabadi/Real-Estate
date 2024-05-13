using RealEstate_Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RealEstate_Domain.Entities.Common;
using RealEstate_Domain.InterFaces;
using RealEstate_Domain.ViewModels.Favourite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Services.Implementations
{
    public class FavouriteService : IFavouriteService
    {
        #region consractore

        private readonly IFavouriteRepository _favouriteRepository;

        public FavouriteService(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }

        #endregion

        public async Task<Favourite> IsExistFavourite(string userId, int estateId)
        {
            return await _favouriteRepository.IsExistFavourite(userId, estateId);
        }

        public async Task CreateFavourite(string userId, int estateId)
        {
            var favourite = new Favourite()
            {
                UserId = userId,
                EstateId = estateId
            };

            await _favouriteRepository.AddFavourite(favourite);

            await _favouriteRepository.SaveChanges();
        }

        public async Task<List<Favourite>> GetFavourites(string userId)
        {
            return await _favouriteRepository.GetAllFavourites(userId);
        }
    }
}
