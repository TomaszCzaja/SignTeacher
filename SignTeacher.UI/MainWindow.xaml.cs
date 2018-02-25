using System.Windows;
using SignTeacher.UI.ViewModel;

namespace SignTeacher.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
