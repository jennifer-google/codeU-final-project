using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PersonalWikiSearch
    
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        static StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        public SignUpPage()
        {
            this.InitializeComponent();
        }
        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProfilePage));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void PreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PreferencesPage));
        }
        private async void SubmitUser_Click(object sender, RoutedEventArgs e)
        {
            if (!PasswordInput.Text.Equals(CheckPasswordInput.Text))
            {
                MessageDialog dialog = new MessageDialog("Passwords do not match", "Password mismatch");
                await dialog.ShowAsync();
                return;
            }
            else
            {
                User currentUser = new User(UsernameInput.Text, PasswordInput.Text);
                MessageDialog dialog = new MessageDialog("Please close this box and sign in", "Account Created!");
                await dialog.ShowAsync();

                StorageFolder _UsersFolder = await _localFolder.CreateFolderAsync("Users", CreationCollisionOption.OpenIfExists);

                var data = JsonConvert.SerializeObject(currentUser);
                await _UsersFolder.CreateFileAsync($"{UsernameInput.Text}.txt");

                var file= await _UsersFolder.GetFileAsync($"{UsernameInput.Text}.txt");

                await FileIO.WriteTextAsync(file, data);

                UsernameInput.Text = "Username...";
                PasswordInput.Text = "Password...";
                CheckPasswordInput.Text = "Retype Password...";
                return;
            }
        }
    }
}
