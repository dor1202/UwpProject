using DAL.Classes;
using LibraryProject.Classes;
using LibraryProject.Classes.Discount;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LibraryProject
{
    public sealed partial class DiscountPage : Page
    {
        BookLib _manage;
        DiscountLogic _logic;
        genre gen;
        float prec;
        public DiscountPage()
        {
            this.InitializeComponent();
            // Window size:
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 360, Height = 640 });
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            _logic = new DiscountLogic();
            // In this contractor we declare the logic class.
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _manage = (BookLib)e.Parameter;
            CreateXML.CreateComboBoxGeneres(generComboBox, gen);
            // In this method we recive the data and fill the genere combobox base the genere enum.
        }
        private void cancelBtn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(LibrarianPage), _manage);
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => prec = _logic.PrecentChangedOtherMethod(sender, e);
        private void All_ComboBoxItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) => _logic.All();
        private void Books_ComboBoxItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) => _logic.ByBooks();
        private void Journals_ComboBoxItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) => _logic.ByJournal();
        private void ByGenere_ComboBoxItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) => _logic.ComboBoxGenereTapped(generTxt,generComboBox,byNameTxtBox,byNameTxt, datePicker);
        private void ByName_ComboBoxItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) => _logic.ComboBoxNameTapped(generTxt, generComboBox, byNameTxtBox, byNameTxt, datePicker);
        private void ByPublisher_ComboBoxItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) => _logic.ComboBoxPublisherTapped(generTxt, generComboBox, byNameTxtBox, byNameTxt, datePicker);
        private void ByDate_ComboBoxItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) => _logic.ComboBoxDateTapped(generTxt, generComboBox, byNameTxtBox, byNameTxt, datePicker);
        // All the combo box methods above indecite using the bool signs what are we using and showing the text box or calender picker.
        private void byStringTxtBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            if(options.SelectionBoxItem.ToString() == "By name")
                _logic.searchTextByName(sender, e, _manage);
            else
                _logic.searchTextByPublisher(sender, e, _manage);
            // In this method we check in with form the text box is: publisher/ name.
            // Search inside.
        }
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            if(prec == 0) Frame.Navigate(typeof(LibrarianPage), _manage);
            _logic.Submit(_manage, prec, gen, byNameTxtBox, generTxt, datePicker);
            Frame.Navigate(typeof(LibrarianPage), _manage);
            // In this method we check if the precentage is valid, if not we do nothing.
            // If he is we submit and change the price by the criteria.
        }
    }
}
