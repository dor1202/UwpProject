using LibraryProject.Classes;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LibraryProject
{
    public sealed partial class LibrarianPage : Page
    {
        /// <summary>
        /// Page use:
        /// 1. Display uses in buttons and in the menu inside the utility fly out.
        /// 2. Can add item to the library.
        /// 3. Can delete item from the library.
        /// 4. Can add discount.
        /// 5. Can stop discount.
        /// 6. Can see a daily update.
        /// </summary>
        BookLib _manage;
        public LibrarianPage()
        {
            this.InitializeComponent();
            // Window size:
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 360, Height = 640 });
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _manage = (BookLib)e.Parameter;
            CreateXML.UpdateFlyOut(BooksAvilableTxt, JournalsAvilableTxt, ItemsAvilableTxt, ItemsSoldTxt, ItemSumTxt, _manage);
            // In this method we recive the data and update the fly out item using the "CreateXML" class.
        }
        private void menu_btn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(StartScreen), _manage);
        private void create_dicount_btn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(DiscountPage), _manage);
        private void Add_Item_Button_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(AddItemFrame), _manage);
        private void Remove_Item_Button_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(RemoveItemFrame), _manage);
        private void edit_item_btn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(EditItemPage), _manage);
        private void end_dicount_btn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(EndDiscountPage), _manage);
        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e) => CoreApplication.Exit();
        //end of code.
    }
}
