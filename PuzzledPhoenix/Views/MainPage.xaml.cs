using System;

using PuzzledPhoenix.ViewModels;

using Windows.UI.Xaml.Controls;

namespace PuzzledPhoenix.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
