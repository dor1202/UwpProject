using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace DAL.Classes
{
    public class Journal : AbstractItem
    {
        public CalendarDatePicker PublishedDate { get; set; }
        public Journal(string name, CalendarDatePicker PublishedDate, string publisher, List<genre> geners, int edition, int price,Uri img) : base()
        {
            Name = name;
            this.PublishedDate = PublishedDate;
            Publisher = publisher;
            Genres = geners;
            CurrentPrice = price;
            Edition = edition;
            image = img;
            pic.Source = new BitmapImage(img);
            FullPrice = CurrentPrice;
        }

        public override string ToString()
        {
            return $"Journal: {Name}, {Publisher}, Price: {CurrentPrice:C2}.";
        }
    }
}
