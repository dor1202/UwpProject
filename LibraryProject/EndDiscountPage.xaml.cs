using LibraryProject.Classes;
using LibraryProject.Classes.Logic_For_Pages.End_Discount_Logic;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LibraryProject
{
    public sealed partial class EndDiscountPage : Page
    {
        /// <summary>
        /// Page use:
        /// 1. End discounts my checking the combo box.
        /// </summary>
        BookLib _manage;
        bool[] _chosen;
        EndDiscountLogic _logic;
        public EndDiscountPage()
        {
            this.InitializeComponent();
            // Window size:
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 360, Height = 640 });
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            _logic = new EndDiscountLogic();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _manage = (BookLib)e.Parameter;
            _chosen = new bool[_manage.Collection._itemList.Count + 1];
            CreateXML.CreateRemoveDiscountList(_chosen, ScrollItems, _manage);
            // In this method we recive the data, declare the bool array for indexes for the "submit" method
            //and create a visual view of the entire discounted items only.
            // Similar to the "RemoveItem" page.
        }
        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            _logic.Submit(_chosen, _manage);
            Frame.Navigate(typeof(LibrarianPage), _manage);
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(LibrarianPage), _manage);
        // end of code.
    }
}
