using System.Threading.Tasks;
using SignTeacher.Model;
using SignTeacher.UI.Data.Interface;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class UserDetailViewModel : ViewModelBase, IUserDetailViewModel
    {
        private readonly IUserDataService _userDataService;
        private User _user;

        public UserDetailViewModel(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task LoadAsync(int userId)
        {
            User = await _userDataService.GetByIdAsync(userId);
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
    }
}