using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate_Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_DataLayer.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }

}
