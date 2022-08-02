using System;

using PuzzledPhoenix.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PuzzledPhoenix.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
