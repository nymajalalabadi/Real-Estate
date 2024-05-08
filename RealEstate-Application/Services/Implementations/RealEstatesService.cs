using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.Entities.RealEstate;
using RealEstate_Domain.InterFaces;
using RealEstate_Domain.ViewModels.Admin.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
