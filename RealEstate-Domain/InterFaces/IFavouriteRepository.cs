using RealEstate_Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.InterFaces
{
    public interface IFavouriteRepository
    {
        Task<Favourite> IsExistFavourite(string userId, int estateId);

        Task AddFavourite(Favourite favourite);

        Task SaveChanges();
    }
}
