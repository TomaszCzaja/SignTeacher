using System.Windows;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.UI.ViewModel;

namespace SignTeacher.UI
{
    public partial class MainWindow : Window
    {
        private readonly IClassifier _classifier;

        public MainWindow(MainViewModel viewModel, IClassifier classifier)
        {
            InitializeComponent();

            DataContext = viewModel;
            _classifier = classifier;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _classifier.Learn();
        }
    }
}
