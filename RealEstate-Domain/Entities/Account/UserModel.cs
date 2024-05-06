﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }

}
