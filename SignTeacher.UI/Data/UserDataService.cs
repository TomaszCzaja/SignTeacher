using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SignTeacher.DataAccess;
using SignTeacher.Model;
using SignTeacher.UI.Data.Interface;

namespace SignTeacher.UI.Data
{
    public class UserDataService : IUserDataService
    {
        private readonly Func<SignTeacherDbContext> _contextCreator;

        public UserDataService(Func<SignTeacherDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Users.AsNoTracking().SingleAsync(user => user.Id == userId);
            }
        }
    }
}