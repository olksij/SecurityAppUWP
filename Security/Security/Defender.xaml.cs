using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Security
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Defender : Page
    {
        string color = "light";
        public Defender()
        {
            this.InitializeComponent();

            UpdateColors();
        }
        bool checking = false;

        private void txtBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }



        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (checking==false)
            {
                txtBlockD.Text = "Checking your PC on viruses";
                CheckButton.Visibility = Visibility.Collapsed;
                progresB.Visibility = Visibility.Visible;
                checking = true;
                await Task.Delay(TimeSpan.FromSeconds(5));
                checking = false;
                txtBlockD.Text = "Seems all good";
                progresB.Visibility = Visibility.Collapsed;
                CheckButton.Visibility=Visibility.Visible;


            }
        }

        private void ToHome1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), color);
        }

        void UpdateColors()
        {
            string theme = AppSettings.Theme;
            Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
            myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
            if (theme == "light")
            {
                myBrush.TintColor = Windows.UI.Colors.WhiteSmoke;
                myBrush.FallbackColor = Windows.UI.Colors.WhiteSmoke;
                RequestedTheme = ElementTheme.Light;
                HomeIcon.Foreground = new SolidColorBrush(Colors.Black);
            }
            if (theme == "dark")
            {
                myBrush.TintColor = Color.FromArgb(255, 50, 50, 50);
                myBrush.FallbackColor = Color.FromArgb(255, 50, 50, 50);
                RequestedTheme = ElementTheme.Dark;
                HomeIcon.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                theme = "light";
                myBrush.TintColor = Windows.UI.Colors.WhiteSmoke;
                myBrush.FallbackColor = Windows.UI.Colors.WhiteSmoke;
                RequestedTheme = ElementTheme.Light;
                HomeIcon.Foreground = new SolidColorBrush(Colors.Black);
            }
            myBrush.TintOpacity = 0.7;
            RectangleAcrylic.Fill = myBrush;
        }
    }
}
