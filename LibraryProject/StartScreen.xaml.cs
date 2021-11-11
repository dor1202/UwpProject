using LibraryProject.Classes;
using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DAL.Classes.PasswordCheck;
using DAL.Classes.Exceptions;

namespace LibraryProject
{
    public sealed partial class StartScreen : Page
    {
        BookLib _manage;
        PasswordBank _check;
        string _pass;
        /// <summary>
        /// Page use:
        /// 1. A user option screen.
        /// 2. Move to user page.
        /// 3. Move to worker page.
        /// 4. Check password for workers.
        /// </summary>
        public StartScreen()
        {
            this.InitializeComponent();
            // Window size:
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 360, Height = 640 });
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            _check = new PasswordBank();
            // In this constractor we add the password bank class for checking the input.
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) => _manage = (BookLib)e.Parameter;
        // "OnNavigatedTo" method exist in all the pages, to catch the BookLib class, transfer the data from one page to the other.
        private void DeleteConfirmation_Click(object sender, RoutedEventArgs e) => about_btn.Flyout.Hide();
        private void UserBtn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(MainPage),_manage);
        private void PasswordBx_PasswordChanged(object sender, RoutedEventArgs e) => _pass = PasswordBx.Password;
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
        }
        private async void SubmitPopupClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_check.Valid(_pass) == true)
                    Frame.Navigate(typeof(LibrarianPage),_manage);
                else
                {
                    wrongJumper.Text = "Incorrect password!";
                    wrongJumper.Visibility = Visibility.Visible;
                    await Task.Delay(1500);
                    wrongJumper.Visibility = Visibility.Collapsed;
                }
            }
            catch(WrongPassException exc)
            {
                wrongJumper.Text = exc.Message;
                wrongJumper.Visibility = Visibility.Visible;
                await Task.Delay(1500);
                wrongJumper.Visibility = Visibility.Collapsed;
            }
            // In this method we have several options, if the number is a number and if the number isn't a number.
            // if he is, and the number is the correct password, continue.
            // if he is, and the number isn't the correct password, show a message box to notify,
            // if he isn't, show a message box to notify.
        }
    }
}
