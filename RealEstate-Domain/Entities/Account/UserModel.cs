using Microsoft.AspNetCore.Identity;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.Entities.Account
{
    public class UserModel : IdentityUser
    {
        [Required(ErrorMessage = "لطفا نام کامل خود را وارد کنید")]
        [MaxLength(100, ErrorMessage = "نام کامل شما نمی تواند از 100 کاراکتر بیشتر باشد")]
        public string FullName { get; set; }

        #region Relation

        public ICollection<Favourite> Favourite { get; set; }

        #endregion
    }

}
