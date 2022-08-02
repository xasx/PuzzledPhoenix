using System;

using PuzzledPhoenix.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PuzzledPhoenix.Views
{
    public sealed partial class MyselfDetailControl : UserControl
    {
        public SampleOrder ListMenuItem
        {
            get { return GetValue(ListMenuItemProperty) as SampleOrder; }
            set { SetValue(ListMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListMenuItemProperty = DependencyProperty.Register("ListMenuItem", typeof(SampleOrder), typeof(MyselfDetailControl), new PropertyMetadata(null, OnListMenuItemPropertyChanged));

        public MyselfDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyselfDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
