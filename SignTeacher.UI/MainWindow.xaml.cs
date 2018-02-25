using System.Windows;
using Leap;
using SignTeacher.UI.LeapMotion.Interface;
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
