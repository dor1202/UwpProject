using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;

namespace Logic.Classes
{
    class Book : AbstractItem
    {
        public string Author { get; set; }
        public Book(string name, string author, string publisher,List<genre> geners,int edition,int price,Uri img):base()
        {
            Name = name;
            Author = author;
            Publisher = publisher;
            Genres = geners;
            Price = price;
            Edition = edition;
            image = img;
            pic.Source = new BitmapImage(img);
        }
        public override string ToString()
        {
            return $"Book: {Name}, {Author}, Price: {Price:C2}.";
        }
    }       
}           
            
            