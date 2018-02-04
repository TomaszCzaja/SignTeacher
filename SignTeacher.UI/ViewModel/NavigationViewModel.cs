using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Events;
using SignTeacher.Model;
using SignTeacher.UI.Data.Interface;
using SignTeacher.UI.Event;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly IUserLookupDataService _userLookupDataService;
        private readonly IEventAggregator _eventAggregator;
        private LookupItem _selectedUser;

        public NavigationViewModel(IUserLookupDataService userLookupDataService, IEventAggregator eventAggregator)
        {
            _userLookupDataService = userLookupDataService;
            _eventAggregator = eventAggregator;

            Users = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _userLookupDataService.GetUserLookupAsync();

            Users.Clear();
            foreach (var item in lookup)
            {
                Users.Add(item);
            }
        }

        public ObservableCollection<LookupItem> Users { get; }

        public LookupItem SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();

                if (_selectedUser != null)
                {
                    _eventAggregator.GetEvent<OpenUserDetailViewEvent>()
                        .Publish(_selectedUser.Id);
                }
            }
        }
    }
}