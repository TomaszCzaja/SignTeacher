﻿using System.Windows;
using SignTeacher.UI.ViewModel;

namespace SignTeacher.UI
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _viewModel.Load();
        }
    }
}
