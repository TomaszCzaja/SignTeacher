using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SignTeacher.Model;
using SignTeacher.UI.Data.Interface;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private readonly IUserLookupDataService _userLookupDataService;

        public NavigationViewModel(IUserLookupDataService userLookupDataService)
        {
            _userLookupDataService = userLookupDataService;

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
    }
}