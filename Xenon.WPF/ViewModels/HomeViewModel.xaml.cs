using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.TaskBar;

namespace Xenon.WPF.ViewModels
{
    /// <summary>
    /// Interaction logic for HomePageViewModel.xaml
    /// </summary>
    public partial class HomeViewModel : Wpf.Ui.Controls.UiPage
    {
        public HomeViewModel()
        {
            InitializeComponent();
            navigationFrame.Children.Clear();
            navigationFrame.Children.Add(new Modals.HomeFeedModal() { Content = null }.MainGrid);
        }

        private void NavigationItem_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new AuthFlowViewModel() { Content = null }.MainGrid);
        }

        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {
            navigationFrame.Children.Clear();
            navigationFrame.Children.Add(new ViewModels.Modals.EventsFeedViewModel() {  Content = null }.MainGrid);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            navigationFrame.Children.Clear();
            navigationFrame.Children.Add(new Modals.HomeFeedModal() { Content = null }.MainGrid);
        }

        private void InboxButton_Click(object sender, RoutedEventArgs e)
        {
            navigationFrame.Children.Clear();
            navigationFrame.Children.Add(new Modals.NotificationViewModel() { Content = null }.MainGrid);
        }
    }
}
