using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace DAL.Classes
{
    public delegate void dele(object sender, TappedRoutedEventArgs e);
    public abstract class AbstractItem
    {
        public dele PopUpEvent;
        public Image pic = new Image();
        public float FullPrice { get; set; }
        public float DiscountPrecentage { get; set; }
        public string Publisher { get; set; }
        public string Name { get; set; }
        public List<genre> Genres { get; set; }
        public float CurrentPrice { get; set; }
        public int Edition { get; set; }
        public static int ID { get; set; }
        public Uri image { get; set; }
        public Popup Pop { get; set; }
        public Popup MyCollectionPop { get; set; }
    }
}
