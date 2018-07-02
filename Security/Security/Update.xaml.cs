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
using Windows;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Web.Http;
using System.Reflection;
using Windows.ApplicationModel;
using System.Threading.Tasks;
using System.Net;
using System.Globalization;
using System.Threading;
using Windows.Web;
using Windows.ApplicationModel.Background;
using System.Net.Http;
using Windows.UI;


// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Security
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 
    public sealed partial class Update : Page
    {
        private List<DownloadOperation> activeDownloads;
        private CancellationTokenSource cts;
        string color = "light";
        string version = "0.4.1.0";

        public Update()
        {
            this.InitializeComponent();
        }

        public PackageId packageId { get; private set; }
        public IEnumerable<string> MobileUserAgent { get; private set; }

        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            CheckButton.Visibility = Visibility.Collapsed;
            pb.Visibility = Visibility.Visible;


            // Please, help me how to download files.
            // All my trying you can see bellow 
            //
            //      V      V      V
            //      V      V      V
            //      V      V      V
            //





            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("Security_" + version + "_x64.appxbundle", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            Write();
        }

        private async void Write()
        {
            var uri = "https://raw.githubusercontent.com/DrAlexOne/SecurityAppUWP/master/Security/Security/AppPackages/Security_" + version + "_Test/Security_" + version + "_x86_x64_arm.appxbundle";

            try
            {
                var handler = new HttpClientHandler { AllowAutoRedirect = true };
                var client = new System.Net.Http.HttpClient(handler);
                client.DefaultRequestHeaders.Add("user-agent", MobileUserAgent);
                Uri requestUri = new Uri(uri);
                var response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                var html = await response.Content.ReadAsStringAsync();

                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("Security_" + version + "_x64.appxbundle");


                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, html);

            }
            catch
            {
                CheckButton.Content = "Its only developing.. .";
                CheckButton.Visibility = Visibility.Visible;
                pb.Visibility = Visibility.Collapsed;
            }
        }

        private void ToHome1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), color);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            color = e.Parameter.ToString();

            Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
            myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
            if (color == "light")
            {
                myBrush.TintColor = Windows.UI.Colors.WhiteSmoke;
                myBrush.FallbackColor = Windows.UI.Colors.WhiteSmoke;
                RequestedTheme = ElementTheme.Light;
                HomeIcon.Foreground = new SolidColorBrush(Colors.Black);
            }
            if (color == "dark")
            {
                myBrush.TintColor = Color.FromArgb(255, 50, 50, 50);
                myBrush.FallbackColor = Color.FromArgb(255, 50, 50, 50);
                RequestedTheme = ElementTheme.Dark;
                HomeIcon.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                color = "light";
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
