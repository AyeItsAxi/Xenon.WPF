using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.ServiceModel.Syndication;
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
using System.Xml;
using Xenon.WPF.Common;
using Microsoft.SyndicationFeed.Rss;

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
            PullStaticWebContent();
        }

        public void PullStaticWebContent()
        {
            
            for (int i = 0; i < Common.Static.asd.Count; i++)
            {
                listBox.Items.Add(Common.Static.asd[i].Title.Text);
            }
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

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExpandedForumPost.Opacity = 0;
            ExpandedForumTitle.Content = Common.Static.asd[listBox.SelectedIndex].Title.Text;
            ExpandedForumPostDetails.Text = Common.Static.asd[listBox.SelectedIndex].Summary.Text.Replace("&nbsp;", " ");
            ExpandedForumPost.Visibility = Visibility.Visible;
            AnimationHandler.FadeAnimation(ExpandedForumPost, 0.2, ExpandedForumPost.Opacity, 1);
        }
    }
}
