using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate_Domain.Entities.Account;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.Entities.Common;
using RealEstate_Domain.Entities.RealEstate;
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

        public DbSet<Estate> Estates { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Favourite> Favourites { get; set; }
    }

}
