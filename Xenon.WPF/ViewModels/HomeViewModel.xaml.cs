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
        }

        private void NavigationItem_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
