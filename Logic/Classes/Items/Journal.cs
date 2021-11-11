using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Logic.Classes
{
    class Journal : AbstractItem
    {
        public CalendarDatePicker PublishedDate { get; set; }
        public Journal(string name, CalendarDatePicker PublishedDate, string publisher, List<genre> geners, int edition, int price,Uri img) : base()
        {
            Name = name;
            this.PublishedDate = PublishedDate;
            Publisher = publisher;
            Genres = geners;
            Price = price;
            Edition = edition;
            image = img;
            pic.Source = new BitmapImage(img);
        }
        public override string ToString()
        {
            return $"Journal: {Name}, {Publisher}, Price: {Price:C2}.";
        }
    }
}
