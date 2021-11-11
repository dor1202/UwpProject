using DAL.Classes;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace LibraryProject.Classes.Discount
{
    static class Discount
    {
        // All the method have the same use, finding the item
        // Update the current price based the full price.
        // Updating the pop up.
        // Check if the item already have discount, if true the check what is the bigger precentage and use it.
        public static void DisDate(BookLib _manage, float presentage,CalendarDatePicker dp)
        {
            foreach (var item in _manage.Collection._itemList)
            {
                if (item is Journal)
                {
                    Journal tmp = item as Journal;
                    if(tmp.PublishedDate.Date ==  dp.Date)
                        if (item.DiscountPrecentage < presentage)
                        {
                            item.DiscountPrecentage = presentage;
                            float precOutNumber = (presentage * item.FullPrice) / 100;
                            item.FullPrice = item.CurrentPrice;
                            item.CurrentPrice -= precOutNumber;
                            item.Pop = CreateXML.CreateStorePopUp(item, _manage.Collection);
                        }
                }
                // In this method we only discount journals that match the date.
            }
        }
        public static void DisAll(BookLib _manage,float presentage)
        {
            foreach (var item in _manage.Collection._itemList)
            {
                if(item.DiscountPrecentage < presentage)
                {
                    item.DiscountPrecentage = presentage;
                    float precOutNumber = (presentage * item.FullPrice) / 100;
                    item.CurrentPrice = item.FullPrice - precOutNumber;
                    item.Pop = CreateXML.CreateStorePopUp(item,_manage.Collection);
                }
            }
            // In this method we discount all.
        }
        public static void DisGenere(BookLib _manage, float presentage,genre gen)
        {
            AbstractItem[] Suggestion = _manage.Collection._itemList.FindAll(p => p.Genres.Contains(gen)).ToArray();
            if(Suggestion != null)
            {
                for (int i = 0; i < Suggestion.Length; i++)
                {
                    if(_manage.Collection._itemList[i].DiscountPrecentage < presentage)
                    {
                        _manage.Collection._itemList[i].DiscountPrecentage = presentage;
                        float precOutNumber = presentage * (_manage.Collection._itemList[i].FullPrice) / 100;
                        _manage.Collection._itemList[i].CurrentPrice = _manage.Collection._itemList[i].FullPrice - precOutNumber;
                        _manage.Collection._itemList[i].Pop = CreateXML.CreateStorePopUp(_manage.Collection._itemList[i],
                            _manage.Collection);
                    }
                }
            }
            // In this method we only discount based the generes picked.
        }
        public static void DisName(BookLib _manage, float presentage, string name)
        {
            AbstractItem Suggestion = _manage.Collection._itemList.First(p => p.Name == name);
            if(Suggestion != null)
            {
                int place = _manage.Collection._itemList.IndexOf(Suggestion);
                if(_manage.Collection._itemList[place].DiscountPrecentage < presentage)
                {
                    _manage.Collection._itemList[place].DiscountPrecentage = presentage;
                    float precOutNumber = presentage * (_manage.Collection._itemList[place].FullPrice) / 100;
                    _manage.Collection._itemList[place].CurrentPrice = _manage.Collection._itemList[place].FullPrice - precOutNumber;
                    _manage.Collection._itemList[place].Pop = CreateXML.CreateStorePopUp(_manage.Collection._itemList[place],
                        _manage.Collection);
                }
            }
            // In this method we only discount based the name picked.
        }
        public static void DisPublisher(BookLib _manage, float presentage, string publisher)
        {
            AbstractItem Suggestion = _manage.Collection._itemList.First(p => p.Publisher == publisher);
            if (Suggestion != null)
            {
                int place = _manage.Collection._itemList.IndexOf(Suggestion);
                if (_manage.Collection._itemList[place].DiscountPrecentage < presentage)
                {
                    _manage.Collection._itemList[place].DiscountPrecentage = presentage;
                    float precOutNumber = presentage * (_manage.Collection._itemList[place].FullPrice) / 100;
                    _manage.Collection._itemList[place].CurrentPrice = _manage.Collection._itemList[place].FullPrice - precOutNumber;
                    _manage.Collection._itemList[place].Pop = CreateXML.CreateStorePopUp(_manage.Collection._itemList[place],
                        _manage.Collection);
                }
            }
            // In this method we only discount based the publisher picked.
        }
        public static void DisBook(BookLib _manage, float presentage)
        {
            foreach (var item in _manage.Collection._itemList)
            {
                if(item is Book)
                {
                    if(item.DiscountPrecentage < presentage)
                    {
                        item.DiscountPrecentage = presentage;
                        float precOutNumber = (presentage * item.FullPrice) / 100;
                        item.CurrentPrice = item.FullPrice - precOutNumber;
                        item.Pop = CreateXML.CreateStorePopUp(item, _manage.Collection);
                    }
                }
            }
            // In this method we only discount only books.
        }
        public static void DisJournal(BookLib _manage, float presentage)
        {
            foreach (var item in _manage.Collection._itemList)
            {
                if (item is Journal)
                {
                    if (item.DiscountPrecentage < presentage)
                    {
                        item.DiscountPrecentage = presentage;
                        float precOutNumber = (presentage * item.FullPrice) / 100;
                        item.FullPrice = item.CurrentPrice;
                        item.CurrentPrice -= precOutNumber;
                        item.Pop = CreateXML.CreateStorePopUp(item, _manage.Collection);
                    }
                }
            }
            // In this method we only discount only journals.
        }
        public static void ReveresTheDis(BookLib _manage, int place)
        {
            _manage.Collection._itemList[place].CurrentPrice = _manage.Collection._itemList[place].FullPrice;
            _manage.Collection._itemList[place].DiscountPrecentage = 0;
            _manage.Collection._itemList[place].Pop = CreateXML.CreateStorePopUp(_manage.Collection._itemList[place],
                   _manage.Collection);
            // In this method we reverse the discount.
        }
    }
}
