using System.Collections.Generic;
using System.Threading.Tasks;
using SignTeacher.Model.AppModel;

namespace SignTeacher.UI.Data.Interface
{
    public interface IUserLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetUserLookupAsync();
    }
}