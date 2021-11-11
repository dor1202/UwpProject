using System.Collections.Generic;
using Windows.UI.Xaml.Controls.Primitives;

namespace LibraryProject.Classes
{
    class BookLib
    {
        public ItemCollection Collection { get;private set; }
        public UserInventory MyInventory { get; set; }
        public List<Popup> PopList { get; set; }
        
        public BookLib()
        {
            MyInventory = new UserInventory();
            Collection = new ItemCollection();
        }
    }
}
