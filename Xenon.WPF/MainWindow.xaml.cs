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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using Xenon.WPF.Common;
using Xenon.WPF.ViewModels;

namespace Xenon.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Static.AuthFlow = new ViewModels.AuthFlowViewModel();
            Static.MainWindow = this;
        }

        private void TitleBarMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
                return;
            this.WindowState = WindowState.Normal;
            this.DragMove();
        }

        private void MinimizeClick(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void MaximizeClick(object sender, RoutedEventArgs e) => this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        private void CloseClick(object sender, RoutedEventArgs e) => Application.Current.Shutdown(0);

        private void XenonLoaded(object sender, RoutedEventArgs e)
        {
            ContentPresenter.Children.Clear();
            AuthFlowViewModel authflow = new() { Content = null };
            ContentPresenter.Children.Add(authflow.MainGrid);
        }
    }
}
