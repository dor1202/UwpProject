using DAL.Classes;
using DAL.Classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace LibraryProject.Classes
{
    class ItemCollection
    {
        public AbstractItem _lastSelectedImg;
        public List<AbstractItem> _itemList = new List<AbstractItem>();
        public static int _id { get;private set; }
        static ItemCollection()
        {
            _id = 0;
        }
        public List<genre> this[string name]
        {
            get
            {
                string[] enumArray = Enum.GetNames(typeof(genre));
                string[] obj = enumArray.Where(p => p.StartsWith(name, StringComparison.OrdinalIgnoreCase)).ToArray();
                List<genre> result = new List<genre>();
                for (int i = 0; i < enumArray.Length; i++)
                {
                    for (int j = 0; j < obj.Length; j++)
                    {
                        if (enumArray[i].ToString() == obj[j].ToString())
                            result.Add((genre)i);
                    }
                }
                return result;
            }
            // In this indexer we are finding geners(enum) that start with the text(string).
            // By using enums as strings.
        }
        public void AddBook(string name,string author,string publisher,List<genre> geners,int edition,int price,Uri uri)
        {
            try
            {
                _itemList.Add(new Book(name, author, publisher, geners, edition, price, uri));
                _itemList.Last().Pop = CreateXML.CreateStorePopUp(_itemList.Last(), this);
                _itemList.Last().pic.Tapped += img_tapped;
                _itemList.Last().PopUpEvent += img_tapped;
                _id++;
            }
            catch(Exception)
            {
                throw new ItemExceptions("couldn't add a book.");
            }
        }
        public void AddBook(Book book)
        {
            _itemList.Add(book);
            _itemList.Last().Pop = CreateXML.CreateStorePopUp(_itemList.Last(), this);
            _itemList.Last().pic.Tapped += img_tapped;
            _itemList.Last().PopUpEvent += img_tapped;
            _id++;
        }
        public void AddJournal(string name, CalendarDatePicker publishedDate, string publisher, List<genre> geners, int edition, int price, Uri uri)
        {
            try
            {
                _itemList.Add(new Journal(name, publishedDate, publisher, geners, edition, price, uri));
                _itemList.Last().Pop = CreateXML.CreateStorePopUp(_itemList.Last(), this);
                _itemList.Last().pic.Tapped += img_tapped;
                _itemList.Last().PopUpEvent += img_tapped;
                _id++;
            }
            catch(Exception)
            {
                throw new ItemExceptions("couldn't add a journal.");
            }
        }
        public void AddJournal(Journal journal)
        {
            _itemList.Add(journal);
            _itemList.Last().Pop = CreateXML.CreateStorePopUp(_itemList.Last(), this);
            _itemList.Last().pic.Tapped += img_tapped;
            _itemList.Last().PopUpEvent += img_tapped;
            _id++;
        }
        // All the methods above use this method as event and delegate, event for click and dele for pick on the search bar.
        public void img_tapped(object sender, TappedRoutedEventArgs e)
        {
            Image img = (Image)sender;
            foreach (AbstractItem item in _itemList)
            {
                if (item.pic == img)
                    if (!item.Pop.IsOpen)
                    {
                        _lastSelectedImg = item;
                        item.Pop.IsOpen = true;
                        return;
                    }
            }
        }
        public void RemoveItem(string name)
        {
            foreach (var item in _itemList)
            {
                if (item.Name == name)
                {
                    _itemList.Remove(item);
                    return;
                }
            }
        }
        //don't really need that.
        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            foreach (AbstractItem item in _itemList)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
