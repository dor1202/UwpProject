using LibraryProject.Classes;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LibraryProject
{
    public sealed partial class MyItemsPage : Page
    {
        /// <summary>
        /// Page use:
        /// 1. Show my books like a showcase.
        /// 2. can return a book.
        /// 3. future -> Can show how much time left for delaying the return.
        /// </summary>
        BookLib _manage;
        public MyItemsPage()
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
            CreateXML.MyItemsXMLCreate(_manage.MyInventory, itemShowenGrid);
            // In this method we recive the data and create a visual look for the item we have using "CreateXML" class.
        }
        private void menu_btn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(StartScreen), _manage);
        // end of code.
    }
}
