using RealEstate_Domain.Entities.Account;
using RealEstate_Domain.Entities.RealEstate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.Entities.Common
{
    public class Favourite
    {
        public int Id { get; set; }

        public int EstateId { get; set; }

        public string UserId { get; set; }

        #region Relation

        [ForeignKey(nameof(EstateId))]
        public Estate Estate { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserModel User { get; set; }

        #endregion
    }

}
