using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using LibraryProject.Classes;

namespace Logic.Classes
{
    class BookLib
    {
        public ItemCollection collection { get;private set; }
        public List<Popup> popList { get; set; }
        
        public BookLib()
        {
            collection = new ItemCollection();
        }
        // buy method.
        public void DailyReport(FlipView dailyFlipView)
        {
            //item taken:num.
            //dailyFlipView.ItemsSource = item;
        }
        
    }
}
