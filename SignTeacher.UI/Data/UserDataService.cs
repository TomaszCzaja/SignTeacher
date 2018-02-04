using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SignTeacher.DataAccess;
using SignTeacher.Model;

namespace SignTeacher.UI.Data
{
    public class UserDataService : IUserDataService
    {
        private readonly Func<SignTeacherDbContext> _contextCreator;

        public UserDataService(Func<SignTeacherDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<User>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Users.AsNoTracking().ToListAsync();
            }
        }
    }
}