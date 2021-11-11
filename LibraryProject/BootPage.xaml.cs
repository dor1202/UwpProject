using DAL.Classes;
using DAL.Classes.Exceptions;
using LibraryProject.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LibraryProject
{
    // The entire project is working on logic class, i tried to move those classes to Class library 3 times but didn't suceed.
    public sealed partial class BootPage : Page
    {
        ///<summary>
        /// Page use:
        /// 1. The page is for booting the data inside the app.
        /// 2. Adding a dealay use for future uses,if i use serilize or data base.
        /// </summary>
        BookLib _manage;
        public BootPage()
        {
            this.InitializeComponent();
            // Window size:
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 360, Height = 640 });
            ApplicationView.PreferredLaunchViewSize = new Size(360, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            _manage = new BookLib();
            CalendarDatePicker dp = new CalendarDatePicker();
            dp.Date = DateTime.Now;
            List<genre> tmp = new List<genre>() { genre.ActionAndAdventure, genre.Crime };
            try
            {
                _manage.Collection.AddBook("Waylaid", "Ruth J. Hartman", "dor", tmp, 6, 32, new Uri("ms-appx:///Assets/Books/Untitled-2-1.jpg"));
                _manage.Collection.AddBook("Invation", "Sean Platt", "dor", tmp, 6, 32, new Uri("ms-appx:///Assets/Books/Untitled-2-10.jpg"));
                _manage.Collection.AddBook("After Math", "Owen Baillie", "dor", tmp, 6, 32, new Uri("ms-appx:///Assets/Books/Untitled-2-11.jpg"));
                _manage.Collection.AddBook("What About Alice?", "Karen Ranney", "dor", tmp, 6, 32, new Uri("ms-appx:///Assets/Books/Untitled-2-2.jpg"));
                _manage.Collection.AddBook("This Slide Of Forever", "dor", "Jo Chandler", tmp, 6, 32, new Uri("ms-appx:///Assets/Books/Untitled-2-3.jpg"));
                _manage.Collection.AddBook("Unearthed", "Jerri Drennen", "dor", tmp, 6, 32, new Uri("ms-appx:///Assets/Books/Untitled-2-5.jpg"));
                _manage.Collection.AddJournal("Aging and Physical Activities", dp, "Human Kinetics", tmp, 6, 32, new Uri("ms-appx:///Assets/Journals/japa_cover.jpg"));
                _manage.Collection.AddJournal("Theological Studies", dp, "Oxford", tmp, 6, 32, new Uri("ms-appx:///Assets/Journals/jsep_cover.jpg"));
            }
            catch (ItemExceptions)
            {
                problem.Visibility = Visibility.Visible;
            }
            wait();
            // In this constractor we "booting" the system, planned it to work with serialize.
            // we can't come back to this page inside the app.
        }
        private async void wait()
        {
            await Task.Delay(1500);
            continuBtn.Visibility = Visibility.Visible;
            progRing.Visibility = Visibility.Collapsed;
            // Make it feel like loading, for Big Data apps.
        }
        private void continuBtn_Click(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(StartScreen), _manage);
    }
}
