using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SignTeacher.DataAccess;
using SignTeacher.Model.AppModel;
using SignTeacher.UI.Data.Interface;

namespace SignTeacher.UI.Data
{
    public class LookupDataService : IUserLookupDataService
    {
        private readonly Func<SignTeacherDbContext> _contextCreator;

        public LookupDataService(Func<SignTeacherDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetUserLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Users
                    .AsNoTracking()
                    .Select(user =>
                        new LookupItem()
                        {
                            Id = user.Id,
                            DisplayMember = user.FirstName + " " + user.LastName
                        })
                    .ToListAsync();
            }
        }
    }
}