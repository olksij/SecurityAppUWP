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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Security
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 
    public sealed partial class Update : Page
    {
        private CancellationTokenSource cts;
        private IProgress<DownloadOperation> progressCallback;

        public Update()
        {
            this.InitializeComponent();

    }

    public PackageId packageId { get; private set; }

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

            try
            {
                var serverAddressField = "https://raw.githubusercontent.com/DrAlexOne/SecurityAppUWP/master/Security/Security/AppPackages/Security_0.2.8.0_Test/";
                Uri source = new Uri(serverAddressField);
                string destination = "Security_0.2.8.0_x86_x64_arm.appxbundle";

                StorageFile destinationFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.CreateFileAsync(destination, Windows.Storage.CreationCollisionOption.ReplaceExisting);

                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(source, destinationFile);

                await download.StartAsync().AsTask(cts.Token, progressCallback);
            }  
            catch (Exception ex)
            {
                CheckButton.Content = "Its only developing.. . Error: " + ex;
                CheckButton.Visibility = Visibility.Visible;
                pb.Visibility = Visibility.Collapsed;
            }

            


            //CheckButton.Content = "Downloaded!";
            //CheckButton.Visibility = Visibility.Visible;
            //pb.Visibility = Visibility.Collapsed;



            /*
                                 await Task.Delay(TimeSpan.FromSeconds(5));

*/
        }

        private void HandleDownloadAsync(DownloadOperation download, bool v)
        {
            throw new NotImplementedException();
        }

        private Task<StorageFile> CreateFileAsync(string v)
        {
            throw new NotImplementedException();
        }

        private Task<StorageFile> CreateFileAsync(string v, CreationCollisionOption generateUniqueName)
        {
            throw new NotImplementedException();
        }

        private void ToHome1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
