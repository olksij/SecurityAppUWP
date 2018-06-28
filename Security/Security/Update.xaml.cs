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

            //            try
            //            {

            
            var serverAddressField = "https://raw.githubusercontent.com/DrAlexOne/SecurityAppUWP/master/Security/Security/AppPackages/Security_0.2.9.0_Test/";
            Uri source = new Uri(serverAddressField);
            string destination = "Security_0.2.9.0_x86_x64_arm.appxbundle";

            

            StorageFile destinationFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.CreateFileAsync(destination, CreationCollisionOption.GenerateUniqueName);

            BackgroundDownloader downloader = new BackgroundDownloader();
            DownloadOperation download = downloader.CreateDownload(source, destinationFile);

            download.Priority = BackgroundTransferPriority.Default;

            await Task.Delay(TimeSpan.FromSeconds(2));
            CheckButton.Content = "Its only developing.. .";
            CheckButton.Visibility = Visibility.Visible;
            pb.Visibility = Visibility.Collapsed;

            /*

            //            }  
                        catch (Exception ex)
                        {
                            CheckButton.Content = "Its only developing.. . Error: " + ex;
                            CheckButton.Visibility = Visibility.Visible;
                            pb.Visibility = Visibility.Collapsed;
                        }




            //CheckButton.Content = "Downloaded!";
            //CheckButton.Visibility = Visibility.Visible;
            //pb.Visibility = Visibility.Collapsed;



            
                                 await Task.Delay(TimeSpan.FromSeconds(5));

*/
        }

        private void ToHome1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async Task HandleDownloadAsync(DownloadOperation download, bool start)
        {
            try
            {

                // Store the download so we can pause/resume.
                activeDownloads.Add(download);

                Progress<DownloadOperation> progressCallback = new Progress<DownloadOperation>(DownloadProgress);
                if (start)
                {
                    // Start the download and attach a progress handler.
                    await download.StartAsync().AsTask(cts.Token, progressCallback);
                }
                else
                {
                    // The download was already running when the application started, re-attach the progress handler.
                    await download.AttachAsync().AsTask(cts.Token, progressCallback);
                }

                ResponseInformation response = download.GetResponseInformation();

                // GetResponseInformation() returns null for non-HTTP transfers (e.g., FTP).
                string statusCode = response != null ? response.StatusCode.ToString() : String.Empty;
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                activeDownloads.Remove(download);
            }
        }


        private void DownloadProgress(DownloadOperation download)
        {
            // DownloadOperation.Progress is updated in real-time while the operation is ongoing. Therefore,
            // we must make a local copy so that we can have a consistent view of that ever-changing state
            // throughout this method's lifetime.
            BackgroundDownloadProgress currentProgress = download.Progress;


            double percent = 100;
            if (currentProgress.TotalBytesToReceive > 0)
            {
                percent = currentProgress.BytesReceived * 100 / currentProgress.TotalBytesToReceive;
            }



            if (currentProgress.HasRestarted)
            {
            }

            if (currentProgress.HasResponseChanged)
            {
                // We have received new response headers from the server.
                // Be aware that GetResponseInformation() returns null for non-HTTP transfers (e.g., FTP).
                ResponseInformation response = download.GetResponseInformation();
                int headersCount = response != null ? response.Headers.Count : 0;


                // If you want to stream the response data this is a good time to start.
                // download.GetResultStreamAt(0);
            }
        }
    }
}
