using OralHistoryBooth.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace OralHistoryBooth
{
  
    public sealed partial class infoPage : Page
    {
        public infoPage()
        {
            this.InitializeComponent();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(firstnameTextBox.Text))
            {
                firstNameWarning.Visibility = Visibility.Visible;
            }
            else
            {
                firstNameWarning.Visibility = Visibility.Collapsed;
            }
            if (string.IsNullOrEmpty(lastnameTextBox.Text))
            {
                lastNameWarning.Visibility = Visibility.Visible;

            }
            else
            {
                lastNameWarning.Visibility = Visibility.Collapsed;
            }
            if (isHardingStudentComboBox.SelectedItem == null)
            {
                studentWarning.Visibility = Visibility.Visible;
            }
            else
            {
                studentWarning.Visibility = Visibility.Collapsed;
            }
            if (string.IsNullOrEmpty(decadeTextBox.Text))
            {
                decadeWarning.Visibility = Visibility.Visible;
            }
            else
            {
                decadeWarning.Visibility = Visibility.Collapsed;
            }

            // If User fills out entire form
            if(string.IsNullOrEmpty(firstnameTextBox.Text) == false && string.IsNullOrEmpty(lastnameTextBox.Text) == false && 
                isHardingStudentComboBox.SelectedIndex != -1 && string.IsNullOrEmpty(decadeTextBox.Text) == false){
                UserData data = new UserData();
                data.firstName = firstnameTextBox.Text;
                data.lastName = lastnameTextBox.Text;
                
                if(isHardingStudentComboBox.SelectedIndex == 2)
                {
                    data.isHardingStudent = true;
                }
                else
                {
                    data.isHardingStudent = false;
                }
                data.decade = int.Parse(decadeTextBox.Text);


                firstNameWarning.Visibility = Visibility.Collapsed;
                lastNameWarning.Visibility = Visibility.Collapsed;
                studentWarning.Visibility = Visibility.Collapsed;
                this.Frame.Navigate(typeof(MainPage), data);
            }

        }

        private void decadeTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args) 
        {

            // Code below from: https://stackoverflow.com/questions/52624066/textbox-with-only-numbers
            // Prevents user from entering characters that aren't numbers
            int pos = sender.SelectionStart;
            sender.Text = new String(sender.Text.Where(char.IsDigit).ToArray());
            sender.SelectionStart = pos;
        }
    }
}
