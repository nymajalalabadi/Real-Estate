using RealEstate_Domain.Entities.RealEstate;
using RealEstate_Domain.ViewModels.Admin.RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.ViewModels.Favourite
{
    public class FavouritesViewModel
    {
        public int Id { get; set; }

        public int EstateId { get; set; }

        public string UserId { get; set; }

        public List<Estate> estates { get; set; }
    }
}
