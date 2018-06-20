using System;
using Windows.UI.ViewManagement;
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
using Windows.ApplicationModel.Core;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Security
{
    public sealed partial class ContentDialog1 : ContentDialog
    {
        public ContentDialog1()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            tgswitch.IsOn = true;
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (tgswitch.IsOn==true)
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.ForegroundColor = Windows.UI.Colors.Black;
                titleBar.BackgroundColor = Windows.UI.Colors.WhiteSmoke;
                titleBar.ButtonForegroundColor = Windows.UI.Colors.Black;
                titleBar.ButtonBackgroundColor = Windows.UI.Colors.WhiteSmoke;
                //var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
                //coreTitleBar.ExtendViewIntoTitleBar = true;
            }

            else
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.ForegroundColor = null;
                titleBar.BackgroundColor = null;
                titleBar.ButtonForegroundColor = null;
                titleBar.ButtonBackgroundColor = null;
                //var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
                //coreTitleBar.ExtendViewIntoTitleBar = false;
            }
        }
    }
}
