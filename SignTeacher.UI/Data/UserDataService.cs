using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<User> GetAll()
        {
            using (var ctx = _contextCreator())
            {
                return ctx.Users.AsNoTracking().ToList();
            }
        }
    }
}