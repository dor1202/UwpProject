using LibraryProject.Classes;
using LibraryProject.Classes.Search;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LibraryProject
{
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Page use:
        /// 1. For showing like a showcase of books.
        /// 2. Can buy a book and add to the the my library.
        /// 3. Can return a book from my library.
        /// </summary>
        BookLib _manage;
        public MainPage()
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
            CreateXML.NormalUserXMLCreate(_manage,itemShowen,_manage.Collection,_manage.MyInventory);
            // In this method we catch the "BookLib" and based on him, creating a visual look using the "CreateXML" class.
        }
        private void SearchBar_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args) => Search.SuggestionChosen(sender, args);
        private void SearchBar_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args) => Search.textChanged(sender, nameBtn, publisherBtn, genreBtn, authorBtn, _manage);
        private void SearchBar_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args) => Search.QuerySubmitted(sender, args, nameBtn, publisherBtn, genreBtn, authorBtn, _manage);
        // The searchBar is working on the "Search" class.
        private void menu_btn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(StartScreen), _manage);
        private void return_book_btn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(MyItemsPage), _manage);
        private void ExitApp_Click(object sender, RoutedEventArgs e) => CoreApplication.Exit();
        // end of code.
    }
}
