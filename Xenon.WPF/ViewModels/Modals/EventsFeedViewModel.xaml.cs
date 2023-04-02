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
using Xenon.WPF.Common;

namespace Xenon.WPF.ViewModels.Modals
{
    /// <summary>
    /// Interaction logic for EventsFeedViewModel.xaml
    /// </summary>
    public partial class EventsFeedViewModel : Page
    {
        public EventsFeedViewModel()
        {
            InitializeComponent();
        }

        private void ForumPost1_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void ForumPost1_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.None;
        }

        private void ForumPost1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ExpandedForumPost.Opacity = 0;
            ExpandedForumPost.Visibility = Visibility.Visible;
            AnimationHandler.FadeAnimation(ExpandedForumPost, 0.2, ExpandedForumPost.Opacity, 1);
        }

        private async void SymbolIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AnimationHandler.FadeAnimation(ExpandedForumPost, 0.2, ExpandedForumPost.Opacity, 0);
            await Task.Delay(200);
            ExpandedForumPost.Visibility = Visibility.Hidden;
        }
    }
}
