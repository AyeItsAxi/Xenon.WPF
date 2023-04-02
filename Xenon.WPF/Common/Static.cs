using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using Xenon.WPF.ViewModels;

namespace Xenon.WPF.Common
{
    internal class Static
    {
        public static UiPage AuthFlow = new Xenon.WPF.ViewModels.AuthFlowViewModel();
        public static UiPage Home = new Xenon.WPF.ViewModels.HomeViewModel();
        public static Window MainWindow;
        public static string? AuthToken;
        public static Grid AuthFlowMainGrid;
        public static Grid HomeViewMainGrid;
        public static Grid HomeFeedModalGrid;
        public static Grid HomeViewNavigationGrid;
    }
}
