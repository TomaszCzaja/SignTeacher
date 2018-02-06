using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
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
            SaveCommand = new DelegateCommand(OnSaveExecute, onSaveCanExecute);

            _eventAggregator.GetEvent<OpenUserDetailViewEvent>()
                .Subscribe(OnOpenUserDetailView);
        }

        public ICommand SaveCommand { get; }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadAsync(int userId)
        {
            User = await _userDataService.GetByIdAsync(userId);
        }

        private async void OnSaveExecute()
        {
            await _userDataService.SaveAsync(User);
            _eventAggregator.GetEvent<AfterUserSaveEvent>().Publish(
                new AfterUserSavedEventArgs()
                {
                    Id = User.Id,
                    DisplayMember = $"{User.FirstName} {User.LastName}"
                });
        }

        private bool onSaveCanExecute() => true;

        private async void OnOpenUserDetailView(int userId)
        {
            await LoadAsync(userId);
        }
    }
}