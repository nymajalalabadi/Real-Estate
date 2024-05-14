﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.Entities.Role
{
    public static class Roles
    {
        public const string Admin = "admin";
        public const string User = "user";
    }

    public static class AuthorizationPolicies
    {
        public const string AdminPolicy = "adminpolicy";
    }

}
