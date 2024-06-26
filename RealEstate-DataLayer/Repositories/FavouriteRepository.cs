﻿using Microsoft.EntityFrameworkCore;
using RealEstate_DataLayer.Context;
using RealEstate_Domain.Entities.Common;
using RealEstate_Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_DataLayer.Repositories
{
    public class FavouriteRepository : IFavouriteRepository
    {
        #region constractor

        private readonly ApplicationDbContext _context;

        public FavouriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<Favourite?> IsExistFavourite(string userId, int estateId)
        {
            return await _context.Favourites.FirstOrDefaultAsync(f => f.UserId == userId && f.EstateId == estateId);
        }

        public async Task<Favourite?> GetFavouriteById(int id)
        {
            return await _context.Favourites.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddFavourite(Favourite favourite)
        {
            await _context.Favourites.AddAsync(favourite);
        }

        public async Task<List<Favourite>> GetAllFavourites(string userId)
        {
            return await _context.Favourites.Include(f => f.Estate).Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task RemoveFavourite(Favourite favourite)
        {
             _context.Favourites.Remove(favourite);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
