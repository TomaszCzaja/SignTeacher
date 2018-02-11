using System.Linq;
using System.Windows;
using Leap;
using SignTeacher.UI.LeapMotion.Interface;
using SignTeacher.UI.ViewModel;

namespace SignTeacher.UI
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel, IFrameHandler frameHandler, Controller controller)
        {
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += MainWindow_Loaded;
            controller.FrameReady += frameHandler.Handle;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs routedEventArgs)
        {
            await _viewModel.LoadAsync();
        }
    }
}
