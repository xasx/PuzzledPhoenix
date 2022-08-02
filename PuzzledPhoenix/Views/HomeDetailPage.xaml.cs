using System;

using Microsoft.Toolkit.Uwp.UI.Animations;

using PuzzledPhoenix.Services;
using PuzzledPhoenix.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PuzzledPhoenix.Views
{
    public sealed partial class HomeDetailPage : Page
    {
        public HomeDetailViewModel ViewModel { get; } = new HomeDetailViewModel();

        public HomeDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.RegisterElementForConnectedAnimation("animationKeyHome", itemHero);
            if (e.Parameter is long orderID)
            {
                await ViewModel.InitializeAsync(orderID);
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
