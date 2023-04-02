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
using System.Windows.Shell;
using Wpf.Ui.Controls;
using Wpf.Ui.TaskBar;

namespace Xenon.WPF.ViewModels
{
    /// <summary>
    /// Interaction logic for AuthFlowViewModel.xaml
    /// </summary>
    public partial class AuthFlowViewModel : UiPage
    {
        public AuthFlowViewModel()
        {
            InitializeComponent();
            XETextLayer.Visibility = Visibility.Visible;
        }

        //one more naming rule violation and im throwing my monitor out the window
        private async void authflowCommence_Click(object sender, RoutedEventArgs e)
        {
            AuthFlowInProgressGrid.Visibility = Visibility.Visible;
            Common.AnimationHandler.FadeIn(AuthFlowInProgressGrid, 0.2);
            Common.AnimationHandler.FadeAnimation(XETextLayer, 1, XETextLayer.Opacity, 0.3);
            await Task.Delay(200);
            bool loginResp = await Common.OnlineSubsystem.Login(usernameBox.Text, passwordBox.Password);
            Common.Static.AuthToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(usernameBox.Text + ":" + passwordBox.Password));
            if (loginResp == true)
            {
                PageContentHoster.Children.Clear();
                HomeViewModel homeview = new() { Content = null };
                PageContentHoster.Children.Add(homeview.MainGrid);
                PageContentHoster.Opacity = 0;
                PageContentHoster.Visibility = Visibility.Visible;
                Common.AnimationHandler.FadeIn(PageContentHoster, 0.3);
                Common.AnimationHandler.FadeAnimation(XETextLayer, 0.2, XETextLayer.Opacity, 0);
                Common.AnimationHandler.FadeOut(AuthFlowInProgressGrid, 0.2);
                await Task.Delay(200);
                AuthFlowInProgressGrid.Visibility = Visibility.Hidden;
                return;
            }
        }

        private void CheckLoginIsValid(object sender, TextChangedEventArgs e)
        {
            if (usernameBox.Text.Length >= 4 && passwordBox.Text.Length >= 8)
            {
                authflowCommence.IsEnabled = true;
            }
            else
            {
                authflowCommence.IsEnabled = false;
            }
        }
    }
}
