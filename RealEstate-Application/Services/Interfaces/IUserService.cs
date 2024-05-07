using RealEstate_Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUserForRole();
    }
}
