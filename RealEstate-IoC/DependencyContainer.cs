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


            #endregion

            #region repositories

            services.AddScoped<IUserRepository, UserRepository>();


            #endregion


            #region tools

            #endregion
        }
    }
}
