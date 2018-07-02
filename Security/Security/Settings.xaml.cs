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
        string color = "light";
        public Settings()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
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
            if (ShowTitleBar1.IsOn == true)
            {
                if (ColorTitleBar1.IsOn == true)
                {
                    if (ShowTitleBar1.IsOn == true)
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
                    if (color == "light")
                    {
                        var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                        titleBar.ForegroundColor = Windows.UI.Colors.Black;
                        titleBar.BackgroundColor = Windows.UI.Colors.WhiteSmoke;
                        titleBar.ButtonForegroundColor = Windows.UI.Colors.Black;
                        titleBar.ButtonBackgroundColor = Windows.UI.Colors.WhiteSmoke;
                    }
                    else
                    {
                        var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                        titleBar.ForegroundColor = Windows.UI.Colors.White;
                        titleBar.BackgroundColor = Color.FromArgb(255, 50, 50, 50);
                        titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
                        titleBar.ButtonBackgroundColor = Color.FromArgb(255, 50, 50, 50);
                    }
                }
            }
        }

        private void ToHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), color);
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (RBdefault.IsChecked == true)
            {
                color = "light";
            }

            RefreshColors();

        }

        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            if (RBdark.IsChecked == true)
            {
                color = "dark";
            }

            RefreshColors();
        }

        void RefreshColors()
        {
            Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
            myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
            if (color == "light")
            {
                myBrush.TintColor = Windows.UI.Colors.WhiteSmoke;
                myBrush.FallbackColor = Windows.UI.Colors.WhiteSmoke;
                RequestedTheme = ElementTheme.Light;
                HomeIcon.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                myBrush.TintColor = Color.FromArgb(255, 50, 50, 50);
                myBrush.FallbackColor = Color.FromArgb(255, 50, 50, 50);
                RequestedTheme = ElementTheme.Dark;
                HomeIcon.Foreground = new SolidColorBrush(Colors.White);
            }
            myBrush.TintOpacity = 0.7;
            RectangleAcrylic.Fill = myBrush;


            if (ShowTitleBar1.IsOn == true)
            {
                if (ColorTitleBar1.IsOn == true)
                {
                    if (ShowTitleBar1.IsOn == true)
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
                    if (color == "light")
                    {
                        var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                        titleBar.ForegroundColor = Windows.UI.Colors.Black;
                        titleBar.BackgroundColor = Windows.UI.Colors.WhiteSmoke;
                        titleBar.ButtonForegroundColor = Windows.UI.Colors.Black;
                        titleBar.ButtonBackgroundColor = Windows.UI.Colors.WhiteSmoke;
                    }
                    else
                    {
                        var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                        titleBar.ForegroundColor = Windows.UI.Colors.White;
                        titleBar.BackgroundColor = Color.FromArgb(255, 50, 50, 50);
                        titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
                        titleBar.ButtonBackgroundColor = Color.FromArgb(255, 50, 50, 50);
                    }
                }
            }
        }
    }
}
