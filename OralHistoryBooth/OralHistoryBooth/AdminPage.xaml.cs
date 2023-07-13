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
using OralHistoryBooth.Models;
using System.ComponentModel;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OralHistoryBooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class AdminPage : Page
    {
        
        public AudioRecorderViewModel AudioRecord { get; set; }

        public AdminPage()
        {
            this.InitializeComponent();
            AudioRecord = new AudioRecorderViewModel();
            logOutTimer();

        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void changePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewPasswordPage));

        }

        private async void logOutTimer()
        {
            try
            {
                AudioRecord.StartTimerLogOut();
               // this.Frame.Navigate(typeof(SignInPage));
            }
            catch (System.Exception)
            {

            }
           
        }
    }
}
