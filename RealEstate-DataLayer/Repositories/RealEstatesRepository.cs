﻿using Microsoft.EntityFrameworkCore;
using RealEstate_DataLayer.Context;
using RealEstate_Domain.Entities.RealEstate;
using RealEstate_Domain.InterFaces;
using RealEstate_Domain.ViewModels.Admin.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_DataLayer.Repositories
{
    public class RealEstatesRepository : IRealEstatesRepository
    {
        #region constractor

        private readonly ApplicationDbContext _context;

        public RealEstatesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<List<RealEstateAdminViewModel>> GetAllRealEstates()
        {
            return await _context.Estates.Select(c => new RealEstateAdminViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Address = c.Address,
                Image = c.Image,
                Metrage = c.Metrage,
                Price = c.Price,
            }).ToListAsync();
        }
    }
}
