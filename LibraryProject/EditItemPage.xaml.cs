using DAL.Classes;
using LibraryProject.Classes;
using LibraryProject.Classes.Edit_Item;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LibraryProject
{
    public sealed partial class EditItemPage : Page
    {
        /// <summary>
        /// Page use:
        /// 1. Can edit an item by picking by name.
        /// </summary>
        List<genre> _list = new List<genre>();
        BookLib _manage;
        EditItemLogic _logic;
        public EditItemPage()
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
            CreateXML.ComboBoxOptions(itemComboBox, _manage);
            CreateXML.CreateGenerListForAddScreen(_list, generList);
            _logic = new EditItemLogic(_list,_manage);
            // In this method we recive the data and fill the item combobox with the names of the items.
            // Creating the genere list in the menu fly out button.
            // Declare the logic class.
        }
        private void itemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
            _logic.itemComboBoxSelectionChanged(sender, priceTxt, editionTxt, imageTxt, generList, autorTxt, caleDate, autorOrDate, nameTxt, publisherTxt);
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tmp = sender as TextBox;
            if(tmp != null)
                _logic.TextChanged(tmp);
        }
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            _logic.Submit(imageTxt,autorOrDate,nameTxt,autorTxt,publisherTxt,editionTxt,priceTxt,caleDate);
            Frame.Navigate(typeof(LibrarianPage), _manage);
        }
        private void cancelBtn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(LibrarianPage), _manage);
        // end of code.
    }
}
