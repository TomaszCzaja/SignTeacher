using System.Collections.Generic;
using System.Threading.Tasks;
using SignTeacher.Model;

namespace SignTeacher.UI.Data
{
    public interface IUserDataService
    {
        Task<List<User>> GetAllAsync();
    }
}