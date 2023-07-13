using OralHistoryBooth.Models;
using OralHistoryBooth.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.WebUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Timer implementation is from 
//https://social.msdn.microsoft.com/Forums/windowsapps/en-US/03b701f9-f78a-4df1-98db-05b752fab920/count-down-timer-by-button-windows-phone-81-c?forum=wpdevelop

namespace OralHistoryBooth
{
    public sealed partial class MainPage : Page
    {
        private bool isInfoEntered = false;
       
        private AudioRecorderViewModel audio = new AudioRecorderViewModel();
        private FileViewModel Edit;
        UserData data;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
#pragma warning disable IDE0019 // Use pattern matching
            data = e.Parameter as UserData;
            if (data == null)
            {
                isInfoEntered = false;
            }
            else
            {
                isInfoEntered = true;
         }    
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isInfoEntered)
            {
              this.Frame.Navigate(typeof(disclaimerPage));
            }

        }


        


        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = new FileViewModel();
            Edit.EditFile(data);
            
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = new FileViewModel();
            Edit.DeleteFile();
            startRecording.IsEnabled = true;
            stopRecording.IsEnabled = false;
        }

        private void AdminSignIn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignInPage));
        }


    }
}
