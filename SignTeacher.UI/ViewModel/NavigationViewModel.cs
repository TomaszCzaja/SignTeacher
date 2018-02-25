using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Events;
using SignTeacher.UI.Data.Interface;
using SignTeacher.UI.Event;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    [Obsolete]
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly IUserLookupDataService _userLookupDataService;
        private readonly IEventAggregator _eventAggregator;
        private NavigationItemViewModel _selectedUser; 

        public NavigationViewModel(IUserLookupDataService userLookupDataService, IEventAggregator eventAggregator)
        {
            _userLookupDataService = userLookupDataService;
            _eventAggregator = eventAggregator;

            Users = new ObservableCollection<NavigationItemViewModel>();

            _eventAggregator.GetEvent<AfterUserSaveEvent>().Subscribe(AfterUserSaved);
        }

        public ObservableCollection<NavigationItemViewModel> Users { get; }

        public NavigationItemViewModel SelectedUser
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

        public async Task LoadAsync()
        {
            var lookup = await _userLookupDataService.GetUserLookupAsync();

            Users.Clear();
            foreach (var item in lookup)
            {
                Users.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

        private void AfterUserSaved(AfterUserSavedEventArgs obj)
        {
            var navigationItem = Users.Single(user => user.Id == obj.Id);
            navigationItem.DisplayMember = obj.DisplayMember;
        }

    }
}