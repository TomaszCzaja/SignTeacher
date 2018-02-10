using System.Linq;
using System.Windows;
using Leap;
using SignTeacher.UI.ViewModel;

namespace SignTeacher.UI
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            Controller controller = new Controller();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += MainWindow_Loaded;
            controller.FrameReady += newFrameHandler;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs routedEventArgs)
        {
            await _viewModel.LoadAsync();
        }

        void newFrameHandler(object sender, FrameEventArgs eventArgs)
        {
            Frame frame = eventArgs.frame;
            //The following are Label controls added in design view for the form
            if (frame.Hands.Any(hand => hand.IsLeft))
            {
                var foo = 5;
            }
        }
    }
}
