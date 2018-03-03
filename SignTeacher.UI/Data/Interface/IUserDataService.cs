using System.Threading.Tasks;
using SignTeacher.Model.AppModel;

namespace SignTeacher.UI.Data.Interface
{
    public interface IUserDataService
    {
        Task<User> GetByIdAsync(int userId);
        Task SaveAsync(User user);
    }
}