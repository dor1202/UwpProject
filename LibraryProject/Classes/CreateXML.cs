using DAL.Classes;
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace LibraryProject.Classes
{
    static class CreateXML
    {
        static ItemCollection _itemCollection;
        static UserInventory _myInventory;
        static Image _image;
        // static data members are for remember the clickes in internal methods inside the static class.

        // screen looks:
        public static void NormalUserXMLCreate(BookLib _manage, Grid itemShowen,ItemCollection collection, UserInventory inventory)
        {
            _itemCollection = collection;
            _myInventory = inventory;
            int bookCounter = 0;
            int journalCouner = 0;
            int bookMargin = -270;
            int bookHightMargin = -480;
            int journalMargin = -270;
            int journalHightMargin = 0;
            foreach (AbstractItem item in _manage.Collection._itemList)
            {
                try
                {
                    CreatingTheImages(item,itemShowen,ref bookCounter, ref journalCouner, ref bookMargin, ref bookHightMargin, ref journalMargin, ref journalHightMargin);
                }
                catch (Exception e)
                {
                    // Still don't know why it crashes here inside the add grid, lines 63 and 79.
                    var x = e.Message;
                }
            }
            // In this method we create a grid filled with images base on the margin.
        }
        public static void CreatingTheImages(AbstractItem item, Grid itemShowenGrid, ref int bookCounter, ref int journalCouner, ref int bookMargin, ref int bookHightMargin,
            ref int journalMargin, ref int journalHightMargin)
        {
            Image img = new Image();
            if (item is Book)
            // book:
            {
                if (bookCounter == 10) return;
                // image:
                img = item.pic;
                img.Width = 60; img.Height = 80;
                img.Margin = new Thickness(bookMargin, bookHightMargin, 0, 0);
                img.Visibility = Visibility.Visible;
                bookMargin += 140;
                if (bookMargin == 430)
                {
                    bookMargin = -270;
                    bookHightMargin += 240;
                }
                itemShowenGrid.Children.Add(img);
                bookCounter++;
            }
            else
            // journal:
            {
                if (journalCouner == 10) return;
                img = item.pic;
                img.Width = 60; img.Height = 80;
                img.Margin = new Thickness(journalMargin, journalHightMargin, 0, 0);
                journalMargin += 140;
                if (journalMargin == 430)
                {
                    journalMargin = -270;
                    journalHightMargin += 240;
                }
                itemShowenGrid.Children.Add(img);
                journalCouner++;
            }
            // In this method we create the images.
        }
        public static void MyItemsXMLCreate(UserInventory Inventory, Grid itemShowenGrid)
        {
            if (Inventory.IsEmpty()) return;
            int bookCounter = 0;
            int journalCouner = 0;
            int bookMargin = -270;
            int bookHightMargin = -480;
            int journalMargin = -270;
            int journalHightMargin = 0;
            foreach (var item in Inventory._myList)
            {
                Image img = new Image();
                if (item is Book)
                // book:
                {
                    if (bookCounter == 10) return;
                    // image:
                    img.Source = new BitmapImage(item.image);
                    img.Width = 60; img.Height = 80;
                    img.Margin = new Thickness(bookMargin, bookHightMargin, 0, 0);
                    img.Visibility = Visibility.Visible;
                    bookMargin += 140;
                    if (bookMargin == 430)
                    {
                        bookMargin = -270;
                        bookHightMargin += 240;
                    }
                    img.Tapped += img_tapped;
                    itemShowenGrid.Children.Add(img);
                    bookCounter++;
                }
                else
                // journal:
                {
                    if (journalCouner == 10) return;
                    img.Source = new BitmapImage(item.image);
                    img.Width = 60; img.Height = 80;
                    img.Margin = new Thickness(journalMargin, journalHightMargin, 0, 0);
                    journalMargin += 140;
                    if (journalMargin == 430)
                    {
                        journalMargin = -270;
                        journalHightMargin += 240;
                    }
                    img.Tapped += img_tapped;
                    itemShowenGrid.Children.Add(img);
                    journalCouner++;
                }
            }
            void img_tapped(object sender, TappedRoutedEventArgs e)
            {
                Image img = (Image)sender;
                foreach (AbstractItem item in Inventory._myList)
                {
                    var bit = img.Source as BitmapImage;
                    if (item.image.ToString() == bit.UriSource.ToString())
                        if (!item.MyCollectionPop.IsOpen)
                        {
                            _myInventory._lastSelectedImg = item;
                            _image = img;
                            item.MyCollectionPop.IsOpen = true;
                            return;
                        }
                }
            }
            // Same as "NormalUserXMLCreate" method, creating a grid filled with images. for some unknown reason not working
            // with "CreatingTheImages" method like "NormalUserXMLCreate", crash when we add the image to the grid in lines: 226, 242.
        }
        public static void CreateGenerListForAddScreen(List<genre> list,MenuFlyout generList)
        {
            var myEnumMemberCount = Enum.GetNames(typeof(genre)).Length;
            for (int i = 0; i < myEnumMemberCount; i++)
            {
                ToggleMenuFlyoutItem item = new ToggleMenuFlyoutItem() { Text = $"{(genre)i}", IsChecked = false };
                item.Click += on_click;
                generList.Items.Add(item);
            }
            // In this method we create a genere list for menu fly outs, and an internal method for picking a genere.
            void on_click(object sender, RoutedEventArgs e)
            {
                ToggleMenuFlyoutItem tmp = (ToggleMenuFlyoutItem)sender;
                if (tmp.IsChecked == true)
                {
                    string s = tmp.ToString();
                    string[] s1 = Enum.GetNames(typeof(genre));
                    int place = 0;
                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i] == s)
                            place = i;
                    }
                    list.Add((genre)place);
                }
                else
                {
                    string s = tmp.ToString();
                    string[] s1 = Enum.GetNames(typeof(genre));
                    int place = 0;
                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i] == s)
                            place = i;
                    }
                    list.Remove((genre)place);
                }
            }
        }
        public static void CreateGenerListForAddScreenWithPick(List<genre> list, MenuFlyout generList,List<genre> pickedList)
        {
            var myEnumMemberCount = Enum.GetNames(typeof(genre)).Length;
            generList.Items.Clear();
            for (int i = 0; i < myEnumMemberCount; i++)
            {
                ToggleMenuFlyoutItem item = new ToggleMenuFlyoutItem() { Text = $"{(genre)i}", IsChecked = false };
                if (pickedList.Contains((genre)i) == true) item.IsChecked = true;
                item.Click += on_click;
                generList.Items.Add(item);
            }
            // Remined the "CreateGenerListForAddScreen" method but filled with exist item generes.
            void on_click(object sender, RoutedEventArgs e)
            {
                ToggleMenuFlyoutItem tmp = (ToggleMenuFlyoutItem)sender;
                if (tmp.IsChecked == true)
                {
                    string s = tmp.ToString();
                    string[] s1 = Enum.GetNames(typeof(genre));
                    int place = 0;
                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i] == s)
                            place = i;
                    }
                    list.Add((genre)place);
                }
                else
                {
                    string s = tmp.ToString();
                    string[] s1 = Enum.GetNames(typeof(genre));
                    int place = 0;
                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i] == s)
                            place = i;
                    }
                    list.Remove((genre)place);
                }
            }
        }
        public static void CreateRemoveList(bool[] chosen, StackPanel ScrollItems, BookLib _manage)
        {
            int place = 0;
            foreach (var item in _manage.Collection._itemList)
            {
                StackPanel stack = new StackPanel() { Orientation = Orientation.Horizontal };
                TextBlock txt = new TextBlock() { Name = $"{place}", Text = $"{item}", Width = 150, Height = 60, TextWrapping = TextWrapping.Wrap };
                CheckBox check = new CheckBox() { IsChecked = false, HorizontalAlignment = HorizontalAlignment.Right };
                check.Checked += HandleCheck;
                check.Unchecked += HandleUnchecked;
                stack.Children.Add(txt);
                stack.Children.Add(check);
                ScrollItems.Children.Add(stack);
                place++;
                // In this method we create a list like look for a scroll panel filled with the items and checkboxs.
                void HandleCheck(object sender, RoutedEventArgs e)
                {
                    chosen[Convert.ToInt32(txt.Name)] = true;
                    txt.Foreground = new SolidColorBrush(Colors.Red);
                }
                void HandleUnchecked(object sender, RoutedEventArgs e)
                {
                    chosen[place] = false;
                    txt.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
        }
        public static void ComboBoxOptions(ComboBox itemComboBox, BookLib _manage)
        {
            _manage.Collection._itemList.Sort((x, y) => string.Compare(x.Name, y.Name));
            foreach (var item in _manage.Collection._itemList)
            {
                itemComboBox.Items.Add(item.Name);
            }
            // In this method we create item for a combo box.
        }
        public static void CreateComboBoxGeneres(ComboBox box, genre output)
        {
            var myEnumMemberCount = Enum.GetNames(typeof(genre)).Length;
            for (int i = 0; i < myEnumMemberCount; i++)
            {
                ComboBoxItem item = new ComboBoxItem() { Content = $"{(genre)i}"};
                item.Tapped += on_click;
                box.Items.Add(item);
            }
            // In this method we create items base the enum genre and add it to a combo box.
            void on_click(object sender, RoutedEventArgs e)
            {
                ComboBoxItem tmp = sender as ComboBoxItem;
                if(tmp != null)
                    for (int i = 0; i < myEnumMemberCount; i++)
                    {
                        if (tmp.Content.ToString() == ((genre)i).ToString())
                            output = (genre)i;
                    }
            }
        }
        public static void CreateRemoveDiscountList(bool[] chosen, StackPanel ScrollItems, BookLib _manage)
        {
            int place = 0;
            foreach (var item in _manage.Collection._itemList)
            {
                if (item.DiscountPrecentage != 0)
                {
                    StackPanel stack = new StackPanel() { Orientation = Orientation.Horizontal };
                    TextBlock txt = new TextBlock() { Name = $"{place}", Text = $"{item}", Width = 150, Height = 60, TextWrapping = TextWrapping.Wrap };
                    CheckBox check = new CheckBox() { IsChecked = false, HorizontalAlignment = HorizontalAlignment.Right };
                    check.Checked += HandleCheck;
                    check.Unchecked += HandleUnchecked;
                    stack.Children.Add(txt);
                    stack.Children.Add(check);
                    ScrollItems.Children.Add(stack);
                    void HandleCheck(object sender, RoutedEventArgs e)
                    {
                        chosen[Convert.ToInt32(txt.Name)] = true;
                        txt.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    void HandleUnchecked(object sender, RoutedEventArgs e)
                    {
                        chosen[place] = false;
                        txt.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }
                place++;
            }
            // In this method we create a list filled with iten that already have a discount.
        }
        public static void UpdateFlyOut(TextBlock BooksAvilableTxt, TextBlock JournalsAvilableTxt,
            TextBlock ItemsAvilableTxt, TextBlock ItemsSoldTxt, TextBlock ItemSumTxt, BookLib _manage)
        {
            int count = 0;
            foreach (var item in _manage.Collection._itemList)
                if (item is Book) count++;
            BooksAvilableTxt.Text += $" {count}";
            JournalsAvilableTxt.Text += $" {_manage.Collection._itemList.Count - count}";
            ItemsAvilableTxt.Text += $" {_manage.Collection._itemList.Count}";
            ItemsSoldTxt.Text += $" {_manage.MyInventory._myList.Count}";
            ItemSumTxt.Text += $" {_manage.MyInventory._myList.Count + _manage.Collection._itemList.Count}";
            // In this method we update the fly out.
        }
        // popups
        public static Popup CreateStorePopUp(AbstractItem item, ItemCollection collection)
        {
            //poppup
            Popup pop = new Popup()
            {
                Name = item.Name,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 261,
                Height = 186
            };
            Border border = new Border() { Background = new SolidColorBrush(Colors.LightGoldenrodYellow), Width = 280, Height = 285 };
            StackPanel stackPanel = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            Image img1 = new Image() { Source = new BitmapImage(item.image), Width = 60, Height = 80, Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Top };
            TextBlock name = new TextBlock()
            {
                Text = $"Name: {item.Name}",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Ink Free"),
                VerticalAlignment = VerticalAlignment.Center
            };
            TextBlock price = new TextBlock()
            {
                Text = $"price: {item.CurrentPrice:C2}",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Ink Free"),
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel.Children.Add(img1);
            stackPanel.Children.Add(name);
            stackPanel.Children.Add(price);
            if (item is Book)
            {
                Book tmp = (Book)item;
                TextBlock author = new TextBlock()
                {
                    Text = $"autor: {tmp.Author}",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Ink Free"),
                    VerticalAlignment = VerticalAlignment.Center
                };
                stackPanel.Children.Add(author);
            }
            else
            {
                Journal tmp = (Journal)item;
                TextBlock publisher = new TextBlock()
                {
                    Text = $"publisher: {tmp.Publisher}",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Ink Free"),
                    VerticalAlignment = VerticalAlignment.Center
                };
                stackPanel.Children.Add(publisher);
                TextBlock publishedDate = new TextBlock()
                {
                    Text = $"published Date: {tmp.PublishedDate.Date.Value.Day}/{tmp.PublishedDate.Date.Value.Month}/{tmp.PublishedDate.Date.Value.Year}",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Ink Free"),
                    VerticalAlignment = VerticalAlignment.Center
                };
                stackPanel.Children.Add(publishedDate);
            }
            Button buy = new Button() {Width = 70, Height = 40 ,Content = "buy", Name = $"{item.Name}" + "buyBtn",
            VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(0,0,80,0)};
            Button ret = new Button() {Width = 70, Height = 40, Content = "return", Name = $"{item.Name}" + "returnBtn",
            VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(80,-40,0,0)};
            StackPanel stackPanelButtons = new StackPanel() { };
            stackPanelButtons.Children.Add(buy);
            stackPanelButtons.Children.Add(ret);
            ret.Click += close;
            buy.Click += buyItem;
            stackPanel.Children.Add(stackPanelButtons);
            border.Child = stackPanel;
            pop.Child = border;
            return pop;
            // In this method we create a store pop up.
              void close(object sender, RoutedEventArgs e)
              {
                Button tmp = (Button)sender;
                string[] arr = tmp.Name.Split(" ");
                if (item.Name == item.Name)
                    if (item.Pop.IsOpen)
                    {
                        item.Pop.IsOpen = false;
                        return;
                    }
              }
             void buyItem(object sender, RoutedEventArgs e)
             {
                close(sender, e);
                _itemCollection._lastSelectedImg.pic.Visibility = Visibility.Collapsed;
                _myInventory.AddToMyItem(item);
                collection.RemoveItem(item.Name);
             }
        }
        public static Popup CreatePopUpMyItemsMenu(AbstractItem item, UserInventory MyInventory)
        {
            //poppup
            Popup pop = new Popup()
            {
                Name = item.Name,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 261,
                Height = 186
            };
            Border border = new Border() { Background = new SolidColorBrush(Colors.LightGoldenrodYellow), Width = 280, Height = 285 };
            StackPanel stackPanel = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            Image img1 = new Image() { Source = new BitmapImage(item.image), Width = 60, Height = 80, Margin = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Top };
            TextBlock name = new TextBlock()
            {
                Text = $"Name: {item.Name}",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Ink Free"),
                VerticalAlignment = VerticalAlignment.Center
            };
            TextBlock price = new TextBlock()
            {
                Text = $"price: {item.CurrentPrice:C2}",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Ink Free"),
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel.Children.Add(img1);
            stackPanel.Children.Add(name);
            stackPanel.Children.Add(price);
            if (item is Book)
            {
                Book tmp = (Book)item;
                TextBlock author = new TextBlock()
                {
                    Text = $"autor: {tmp.Author}",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Ink Free"),
                    VerticalAlignment = VerticalAlignment.Center
                };
                stackPanel.Children.Add(author);
            }
            else
            {
                Journal tmp = (Journal)item;
                TextBlock publisher = new TextBlock()
                {
                    Text = $"publisher: {tmp.Publisher}",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Ink Free"),
                    VerticalAlignment = VerticalAlignment.Center
                };
                TextBlock publishedDate = new TextBlock()
                {
                    Text = $"published Date: {tmp.PublishedDate:d/MM/yyyy}",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Ink Free"),
                    VerticalAlignment = VerticalAlignment.Center
                };
                stackPanel.Children.Add(publisher);
                stackPanel.Children.Add(publishedDate);
            }
            Button ret = new Button() {Width = 70, Height = 40, Content = "return", Name = $"{item.Name}" + "returnBtn",
            VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(0,-60,80,0)};
            Button clos = new Button() {Width = 70, Height = 40, Content = "close", Name = $"{item.Name}" + "closeBtn",
            VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(80,-60,0,0)};
            StackPanel stackPanelButtons = new StackPanel() {
                HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(0,100,0,0)
            };
            stackPanelButtons.Children.Add(clos);
            stackPanelButtons.Children.Add(ret);
            clos.Click += close;
            ret.Click += ReturnItem;
            stackPanel.Children.Add(stackPanelButtons);
            border.Child = stackPanel;
            pop.Child = border;
            return pop;
            // In this method we create a pop up for went we buy an item.
            void close(object sender, RoutedEventArgs e)
            {
                Button tmp = (Button)sender;
                string[] arr = tmp.Name.Split(" ");
                if (item.Name == item.Name)
                    if (item.MyCollectionPop.IsOpen)
                    {
                        item.MyCollectionPop.IsOpen = false;
                        return;
                    }
            }
            void ReturnItem(object sender, RoutedEventArgs e)
            {
                close(sender, e);
                _image.Visibility = Visibility.Collapsed;
                MyInventory.ReturnMyItem(item.Name, _itemCollection);
            }
        }
        public static Popup CreateLatePopUp(AbstractItem item, UserInventory MyInventory)
        {
            //poppup
            Popup pop = new Popup()
            {
                Name = item.Name,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 261,
                Height = 186
            };
            Border b = new Border() { Background = new SolidColorBrush(Colors.LightGoldenrodYellow), Width = 280, Height = 285 };
            StackPanel p = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            TextBlock late = new TextBlock()
            {
                Text = $"You are late on returnning: {item.Name}",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Ink Free"),
                VerticalAlignment = VerticalAlignment.Center
            };
            Button ret = new Button()
            {
                Content = "return",
                Name = $"{item.Name}" + "returnBtn",
                HorizontalAlignment = HorizontalAlignment.Left
            };
            StackPanel s = new StackPanel() { };
            s.Children.Add(ret);
            ret.Click += @return;
            p.Children.Add(late);
            p.Children.Add(s);
            b.Child = p;
            pop.Child = b;
            return pop;
            // In this method we are changing the MyItem pop up to a late pop up if the rent time expired.
            void @return(object sender, RoutedEventArgs e)
            {
                Button tmp = (Button)sender;
                string[] arr = tmp.Name.Split(" ");
                if (item.Name == item.Name)
                    if (item.MyCollectionPop.IsOpen)
                    {
                        item.MyCollectionPop.IsOpen = false;
                    }
                _image.Visibility = Visibility.Collapsed;
                MyInventory.ReturnMyItem(item.Name, _itemCollection);
            }
        }
    }
}
