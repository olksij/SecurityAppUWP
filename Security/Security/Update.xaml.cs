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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Security
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Update : Page
    {
        public Update()
        {
            this.InitializeComponent();
        }

        public PackageId packageId { get; private set; }

        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            CheckButton.Visibility = Visibility.Collapsed;
            pb.Visibility = Visibility.Visible;

            // Please, help me how to download files. I used tutorials, but dont work. 
            // All my trying you can see bellow 
            //
            //      V      V      V
            //      V      V      V
            //      V      V      V




            /*
            try
            {

                Uri source = new Uri("https://raw.githubusercontent.com/DrAlexOne/SecurityAppUWP/master/Security/Security/AppPackages/Security_0.2.7.0_Test/");
                var uri = new Uri("ms-appx:///Security_0.2.7.0_x86_x64_arm.appxbundle");
                var destination = await StorageFile.GetFileFromApplicationUriAsync(uri);
                CheckButton.Content = destination;

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile appx = await storageFolder.CreateFileAsync("Security_0.2.7.0_x86_x64_arm.appxbundle", Windows.Storage.CreationCollisionOption.ReplaceExisting);


 //               StorageFile destinationFile = await destinationFile.CreateFileAsync(destination.ToString(), Windows.Storage.CreationCollisionOption.ReplaceExisting);


                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(source, destination);
            }
            catch (Exception ex)
            {
                
            }
            */


            // Please, help me how to download files. I used tutorials, but dont work. 
            // All my trying you can see little up 


            await Task.Delay(TimeSpan.FromSeconds(5));
                CheckButton.Content = "Right now its developing. Look source code, and try to help me..";
                CheckButton.Visibility = Visibility.Visible;
                pb.Visibility = Visibility.Collapsed;
            

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
