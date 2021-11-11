using System;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Logic.Classes
{
    class UserInventory
    {
        // timer is final yet.
        public List<AbstractItem> MyList;
        DispatcherTimer Timer;
        int currentTime;
        List<int> timerCheck;
        public UserInventory()
        {
            MyList = new List<AbstractItem>();
            timerCheck = new List<int>();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            Timer.Tick += Tmp_Tick;
            Timer.Start();
        }

        private void Tmp_Tick(object sender, object e)
        {
            currentTime++;
            foreach (int item in timerCheck)
            {
                if (currentTime == item)
                    Notify(timerCheck.IndexOf(item));
            }
        }

        public void AddToMyItem(AbstractItem item)
        {
            MyList.Add(item);
            timerCheck.Add(currentTime + 15);
        }
        public void ReturnMyItem(string item)
        {
            int place = MyList.FindIndex((x) => x.Name == item);
            if(place != -1)
                MyList.RemoveAt(place);
        }
        public void Notify(int place)
        {
            string s = MyList[place].ToString();
        }
    }
}
