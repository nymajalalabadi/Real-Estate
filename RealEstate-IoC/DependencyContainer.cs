using Microsoft.Extensions.DependencyInjection;
using RealEstate_Application.Services.Implementations;
using RealEstate_Application.Services.Interfaces;
using RealEstate_DataLayer.Repositories;
using RealEstate_Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_IoC
{
    public class DependencyContainer
    {
        public static void RejosterService(IServiceCollection services)
        {
            #region services

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRealEstatesService, RealEstatesService>();

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IFavouriteService, FavouriteService>();

            #endregion

            #region repositories

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRealEstatesRepository, RealEstatesRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IFavouriteRepository, FavouriteRepository>();

            #endregion


            #region tools

            #endregion
        }
    }
}
