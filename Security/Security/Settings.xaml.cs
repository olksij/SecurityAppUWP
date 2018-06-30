using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Power;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Security
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        private void ShowTitleBar(object sender, RoutedEventArgs e)
        {
            if (ShowTitleBar1.IsOn == true)
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
                coreTitleBar.ExtendViewIntoTitleBar = false;
                if (ColorTitleBar1.IsOn == true)
                {
                    if (ShowTitleBar1.IsOn == true)
                    {
                        titleBar.ForegroundColor = null;
                        titleBar.BackgroundColor = null;
                        titleBar.ButtonForegroundColor = null;
                        titleBar.ButtonBackgroundColor = null;
                    }
                }
                else
                {
                    titleBar.ForegroundColor = Windows.UI.Colors.Black;
                    titleBar.BackgroundColor = Windows.UI.Colors.WhiteSmoke;
                    titleBar.ButtonForegroundColor = Windows.UI.Colors.Black;
                    titleBar.ButtonBackgroundColor = Windows.UI.Colors.WhiteSmoke;
                }
            }
            else
            {
                CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
                ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                titleBar.ForegroundColor = Windows.UI.Colors.Black;
                titleBar.ButtonForegroundColor = Windows.UI.Colors.Black;
            }

        }

        private void ColorTitleBar(object sender, RoutedEventArgs e)
        {
            if (ColorTitleBar1.IsOn == true)
            {
                if (ShowTitleBar1.IsOn==true)
                {
                    var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                    titleBar.ForegroundColor = null;
                    titleBar.BackgroundColor = null;
                    titleBar.ButtonForegroundColor = null;
                    titleBar.ButtonBackgroundColor = null;
                }
            }
            else
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.ForegroundColor = Windows.UI.Colors.Black;
                titleBar.BackgroundColor = Windows.UI.Colors.WhiteSmoke;
                titleBar.ButtonForegroundColor = Windows.UI.Colors.Black;
                titleBar.ButtonBackgroundColor = Windows.UI.Colors.WhiteSmoke;
            }
        }

        private void ToHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
