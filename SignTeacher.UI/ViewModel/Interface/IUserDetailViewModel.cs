using System.Threading.Tasks;

namespace SignTeacher.UI.ViewModel.Interface
{
    public interface IUserDetailViewModel
    {
        Task LoadAsync(int userId);
    }
}