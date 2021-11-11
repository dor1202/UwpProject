using LibraryProject.Classes;
using LibraryProject.Classes.Logic_For_Pages.AddItem;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LibraryProject
{
    public sealed partial class AddItemFrame : Page
    {
        /// <summary>
        /// Page use:
        /// 1. Can add items by item type (book / journal).
        /// </summary>
        BookLib _manage;
        AddItemPageLogic _logic;
        public AddItemFrame()
        {
            this.InitializeComponent();
            // Window size:
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 360, Height = 640 });
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            _logic = new AddItemPageLogic();
            CreateXML.CreateGenerListForAddScreen(_logic._list, generList);
            // In this contractor we declare the logic class, and the generes on a menu fly out.
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) => _manage = (BookLib)e.Parameter;
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e) => _logic.AuthorOrDateChanger(kindSwitch, autorOrDate, caleDate, autorTxt);
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tmp = sender as TextBox;
            if(tmp != null)
            {
                if (_logic.NumberValid(tmp))
                    Txt_TextChanged(sender, e);
                else if(tmp.Text.Length >= 1)
                    tmp.Text = $"{tmp.Text.Remove(tmp.Text.Length - 1):C2}";
            }
            // In this method we check if the input is only numbers, if he isn't we delete the letter, if the user enter a letter again,
            // then the entire text will delete.
            // If the input is valid, then save the number.
        }
        private void Txt_TextChanged(object sender, TextChangedEventArgs e) => _logic.TextChanged(sender);
        // This method is saving all the inputs.
        private void caleDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args) => _logic._datePicker = sender;
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            _logic.Submit(kindSwitch, _manage);
            Frame.Navigate(typeof(LibrarianPage), _manage);
        }
        private void cancelBtn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(LibrarianPage), _manage);
        // end of code.
    }
}
