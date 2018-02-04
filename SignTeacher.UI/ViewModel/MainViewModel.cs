using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SignTeacher.Model;
using SignTeacher.UI.Data;

namespace SignTeacher.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IUserDataService _userDataService;

        public MainViewModel(IUserDataService userDataService)
        {
            Users = new ObservableCollection<User>();

            _userDataService = userDataService;
        }

        public async Task LoadAsync()
        {
            var users = await _userDataService.GetAllAsync();

            Users.Clear();

            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public ObservableCollection<User> Users { get; set; }
    }
}