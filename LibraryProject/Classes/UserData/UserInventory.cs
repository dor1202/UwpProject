using DAL.Classes;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;

namespace LibraryProject.Classes
{
    class UserInventory
    {
        public List<AbstractItem> _myList;
        List<int> _timerCheck;
        public AbstractItem _lastSelectedImg;
        DispatcherTimer Timer;
        int TimeCounter;
        public UserInventory()
        {
            _myList = new List<AbstractItem>();
            _timerCheck = new List<int>();
            Timer = new DispatcherTimer();
            Timer.Interval = new System.TimeSpan(0,0,0,1);
            Timer.Tick += Tmp_Tick;
            Timer.Start();
        }
        public void AddToMyItem(AbstractItem item)
        {
            _myList.Add(item);
            _myList.Last().MyCollectionPop = CreateXML.CreatePopUpMyItemsMenu(_myList.Last(), this);
            _timerCheck.Add(TimeCounter + 10);
            // In this method we add an item, addin him a popup for "MyCollection" page.
            // Still need work on the timer.
        }
        private void Tmp_Tick(object sender, object e)
        {
            if (_timerCheck.Contains(TimeCounter))
            {
                int place = _timerCheck.IndexOf(TimeCounter);
                if (_myList[place].MyCollectionPop.IsOpen == true) _myList[place].MyCollectionPop.IsOpen = false;
                _myList[place].MyCollectionPop = CreateXML.CreateLatePopUp(_myList.Last(), this);
                _timerCheck.Remove(TimeCounter);
            }
            else
                TimeCounter++;
        }
        public void ReturnMyItem(string item, ItemCollection collection)
        {
            int place = _myList.FindIndex((x) => x.Name == item);
            AbstractItem tmp = _myList[place];
            if (place != -1)
            {
                if (tmp is Book)
                {
                    Book tmp1 = tmp as Book;
                    collection.AddBook(tmp1);
                }
                else
                {
                    Journal tmp1 = tmp as Journal;
                    collection.AddJournal(tmp1);
                }
                _myList.RemoveAt(place);
            }
        }
        public bool IsEmpty() => _myList.Count > 0 ? false : true;
    }
}
