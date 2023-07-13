using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OralHistoryBooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class disclaimerPage : Page
    {
        public disclaimerPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkbox1.IsChecked == true && checkbox2.IsChecked == true && checkbox3.IsChecked == true && checkbox4.IsChecked == true)
            {
                warningMessage.Visibility = Visibility.Collapsed;
                this.Frame.Navigate(typeof(infoPage));
            }
            else
            {
                warningMessage.Visibility = Visibility.Visible;
                await Task.Delay(100);
                warningMessage.Visibility = Visibility.Collapsed;
                await Task.Delay(100);
                warningMessage.Visibility = Visibility.Visible;
                await Task.Delay(100);
                warningMessage.Visibility = Visibility.Collapsed;
                await Task.Delay(100);
                warningMessage.Visibility = Visibility.Visible;

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("disclaimer");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("disclaimer");

        }
    }
}
