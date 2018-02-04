using System.Collections.ObjectModel;
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

        public void Load()
        {
            var users = _userDataService.GetAll();

            Users.Clear();

            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public ObservableCollection<User> Users { get; set; }
    }
}