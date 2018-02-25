using System;
using System.Windows.Input;
using Autofac.Features.Indexed;
using Prism.Commands;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IDetailViewModel _detailViewModel;
        private readonly IIndex<string, IDetailViewModel> _detailViewModelCreator;

        public MainViewModel(IIndex<string, IDetailViewModel> detailViewModelCreator)
        {
            _detailViewModelCreator = detailViewModelCreator;

            CreateDetailViewCommand = new DelegateCommand<Type>(OnCreateDetailView);
        }

        public ICommand CreateDetailViewCommand { get; }

        public IDetailViewModel DetailViewModel
        {
            get => _detailViewModel;
            private set
            {
                _detailViewModel = value;
                OnPropertyChanged();
            }
        }

        private void OnCreateDetailView(Type viewModelType)
        {
            DetailViewModel?.UpdateLeapMotionHandler();
            DetailViewModel = _detailViewModelCreator[viewModelType.Name];
        }
    }
}