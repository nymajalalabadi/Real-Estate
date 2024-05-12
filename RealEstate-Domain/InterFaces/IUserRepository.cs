using RealEstate_Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.InterFaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUserForRole();

        Task<UserModel?> GetUserByUserName(string userName);
    }
}
