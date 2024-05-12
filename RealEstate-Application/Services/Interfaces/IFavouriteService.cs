using RealEstate_Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Services.Interfaces
{
    public interface IFavouriteService
    {
        Task<Favourite> IsExistFavourite(string userId, int estateId);

        Task CreateFavourite(Favourite favourite);

    }
}
