using System;

using PuzzledPhoenix.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PuzzledPhoenix.Views
{
    public sealed partial class MyselfPage : Page
    {
        public MyselfViewModel ViewModel { get; } = new MyselfViewModel();

        public MyselfPage()
        {
            InitializeComponent();
            Loaded += MyselfPage_Loaded;
        }

        private async void MyselfPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(ListDetailsViewControl.ViewState);
        }
    }
}
