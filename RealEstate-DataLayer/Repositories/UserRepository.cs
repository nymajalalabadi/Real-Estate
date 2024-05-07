using Microsoft.EntityFrameworkCore;
using RealEstate_DataLayer.Context;
using RealEstate_Domain.Entities.Account;
using RealEstate_Domain.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region constractor

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<List<UserModel>> GetUserForRole()
        {
          return await _context.Users.ToListAsync();
        }
    }
}
