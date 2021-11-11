using LibraryProject.Classes;
using LibraryProject.Classes.Logic_For_Pages.Remove_Item;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LibraryProject
{
    public sealed partial class RemoveItemFrame : Page
    {
        /// <summary>
        /// Page use:
        /// 1. Can remove an item from the list by checking the check box.
        /// </summary>
        BookLib _manage;
        bool[] chosen;
        RemoveItemLogic _logic;
        public RemoveItemFrame()
        {
            this.InitializeComponent();
            // Window size:
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 360, Height = 640 });
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            _logic = new RemoveItemLogic();
            // In this contractor we declare the logic class.
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _manage = (BookLib)e.Parameter;
            chosen = new bool[_manage.Collection._itemList.Count + 1];
            CreateXML.CreateRemoveList(chosen, ScrollItems, _manage);
            // In this method we recive the data, declare the bool array for indexes for the removing method
            //and create a visual view of the entire items and removing them.
        }
        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            _logic.Submit(_manage,chosen);
            Frame.Navigate(typeof(LibrarianPage), _manage);
            // In this method we submit, updating the data items and the indexes.
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(LibrarianPage), _manage);
    }
}
