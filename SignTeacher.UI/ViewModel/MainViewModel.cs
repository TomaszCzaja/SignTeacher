using System.Threading.Tasks;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel(INavigationViewModel navigationViewModel, IUserDetailViewModel userDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            UserDetailViewModel = userDetailViewModel;
        }

        public INavigationViewModel NavigationViewModel { get; }

        public IUserDetailViewModel UserDetailViewModel { get; }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
    }
}