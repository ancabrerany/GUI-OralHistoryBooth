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
    public sealed partial class NewPasswordPage : Page
    {
        public AudioRecorderViewModel AudioRecorder { get; set; }

        public NewPasswordPage()
        {
            this.InitializeComponent();
            AudioRecorder = new AudioRecorderViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordOldBox.Password) == true ||
                string.IsNullOrEmpty(passwordNewBox.Password) == true ||
                string.IsNullOrEmpty(passwordConfirmBox.Password) == true           
                )
            {
                allPasswordWarning.Visibility = Visibility.Visible;
            }else
            {
                allPasswordWarning.Visibility = Visibility.Collapsed;

                if(passwordOldBox.Password != AudioRecorder.Password)
                {
                    oldPasswordWarning.Visibility = Visibility.Visible;
                }
                else
                {
                    oldPasswordWarning.Visibility = Visibility.Collapsed;
                }

                if (passwordNewBox.Password != passwordConfirmBox.Password)
                {
                    newPasswordWarning.Visibility = Visibility.Visible;
                }
                else
                {
                    newPasswordWarning.Visibility = Visibility.Collapsed;
                }
            }

            if(passwordOldBox.Password == AudioRecorder.Password &&
                passwordNewBox.Password == passwordConfirmBox.Password)
            {
                AudioRecorder.Password = passwordOldBox.Password;
                this.Frame.Navigate(typeof(SignInPage));
            }
        }
    }
}
