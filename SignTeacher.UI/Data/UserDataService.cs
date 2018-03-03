using System;
using System.Data.Entity;
using System.Threading.Tasks;
using SignTeacher.DataAccess;
using SignTeacher.Model.AppModel;
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

        public async Task SaveAsync(User user)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Users.Attach(user);
                ctx.Entry(user).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}