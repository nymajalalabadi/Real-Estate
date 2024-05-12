using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.Entities.Account;
using RealEstate_Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Services.Implementations
{
    public class UserService : IUserService
    {
        #region consractor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        public async Task<List<UserModel>> GetUserForRole()
        {
            return await _userRepository.GetUserForRole();
        }

        public async Task<UserModel?> GetUserByUserName(string userName)
        {
            return await _userRepository.GetUserByUserName(userName);
        }

    }
}
