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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OralHistoryBooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignInPage : Page
    {
        public AudioRecorderViewModel AudioRecorder { get; set; }
        
        public SignInPage()
        {
            this.InitializeComponent();
            AudioRecorder = new AudioRecorderViewModel();
           
        }


        //error: Not showing message of incorrect user and password when one of both is correct.
        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            if (string.IsNullOrEmpty(UsernameTextBox.Text) ) {
                userNullWarning.Visibility = Visibility.Visible;
            }else
            {
                userNullWarning.Visibility = Visibility.Collapsed;
            }

            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                passwordNullWarning.Visibility = Visibility.Visible;
            }
            else
            {
                passwordNullWarning.Visibility = Visibility.Collapsed;
            }


            if (UsernameTextBox.Text != AudioRecorder.Username && passwordBox.Password != AudioRecorder.Password &&
                (string.IsNullOrEmpty(UsernameTextBox.Text)) == false && (string.IsNullOrEmpty(passwordBox.Password)) == false)
            {
                incorrectWarning.Visibility = Visibility.Visible;
            } else
            {
                incorrectWarning.Visibility = Visibility.Collapsed;
            }


            if (UsernameTextBox.Text == AudioRecorder.Username && passwordBox.Password == AudioRecorder.Password)
            {
                this.Frame.Navigate(typeof(AdminPage));
            }
      
           
        }
    }

}
