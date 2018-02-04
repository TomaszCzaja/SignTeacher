using System.Threading.Tasks;
using Prism.Events;
using SignTeacher.Model;
using SignTeacher.UI.Data.Interface;
using SignTeacher.UI.Event;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class UserDetailViewModel : ViewModelBase, IUserDetailViewModel
    {
        private readonly IUserDataService _userDataService;
        private readonly IEventAggregator _eventAggregator;
        private User _user;

        public UserDetailViewModel(IUserDataService userDataService, IEventAggregator eventAggregator)
        {
            _userDataService = userDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenUserDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);
        }

        private async void OnOpenFriendDetailView(int userId)
        {
            await LoadAsync(userId);
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