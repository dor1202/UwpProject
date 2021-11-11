using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LibraryProject.Classes.Edit_Item
{
    class EditItemLogic
    {
        int _itemIndex;
        List<genre> _list;
        BookLib _manage;
        public EditItemLogic(List<genre> list, BookLib manage)
        {
            _itemIndex = 0;
            _list = list;
            _manage = manage;
        }
        public void itemComboBoxSelectionChanged(object sender, TextBox priceTxt, TextBox editionTxt,
            TextBox imageTxt, MenuFlyout generList, TextBox autorTxt, CalendarDatePicker caleDate, TextBlock autorOrDate,
            TextBox nameTxt, TextBox publisherTxt)
        {
            ComboBox tmp = sender as ComboBox;
            if (tmp != null)
                foreach (var item in _manage.Collection._itemList)
                {
                    if (tmp.SelectedItem.ToString() == item.Name)
                    {
                        _itemIndex = _manage.Collection._itemList.IndexOf(item);
                        priceTxt.Text = item.CurrentPrice.ToString();
                        editionTxt.Text = item.Edition.ToString();
                        imageTxt.Text = item.image.ToString();
                        CreateXML.CreateGenerListForAddScreenWithPick(_list, generList, item.Genres);
                        if (item is Book)
                        {
                            autorTxt.Visibility = Visibility.Visible;
                            caleDate.Visibility = Visibility.Collapsed;
                            autorOrDate.Text = "Author:";
                            Book tmp1 = item as Book;
                            autorTxt.Text = tmp1.Author.ToString();
                        }
                        else
                        {
                            autorTxt.Visibility = Visibility.Collapsed;
                            caleDate.Visibility = Visibility.Visible;
                            autorOrDate.Text = "Date:";
                            Journal tmp1 = item as Journal;
                            caleDate.Date = tmp1.PublishedDate.Date;
                        }
                        nameTxt.Text = item.Name.ToString();
                        publisherTxt.Text = item.Publisher.ToString();
                    }
                }
            // In this method we recive the name of the item, find the item himself in the collcetion and updating the screen with his data.
            // changes won't happen if we don't press submit.
        }
        public void Submit(TextBox imageTxt, TextBlock autorOrDate, TextBox nameTxt, TextBox autorTxt, TextBox publisherTxt,
            TextBox editionTxt, TextBox priceTxt, CalendarDatePicker caleDate)
        {
            try
            {
                Uri tmp = new Uri(imageTxt.Text);
            }
            catch (Exception)
            {
                imageTxt.Text = "ms-appx:///Assets/StoreLogo.png";
            }
            if (autorOrDate.Text == "Author:")
            {
                Book tmp = new Book(nameTxt.Text, autorTxt.Text, publisherTxt.Text, _list, Convert.ToInt32(editionTxt.Text), Convert.ToInt32(priceTxt.Text), new Uri(imageTxt.Text));
                _manage.Collection._itemList[_itemIndex] = tmp;
                _manage.Collection._itemList[_itemIndex].Pop = CreateXML.CreateStorePopUp(_manage.Collection._itemList[_itemIndex], _manage.Collection);
                _manage.Collection._itemList[_itemIndex].pic.Tapped += _manage.Collection.img_tapped;
                _manage.Collection._itemList[_itemIndex].PopUpEvent += _manage.Collection.img_tapped;
            }
            else
            {
                Journal tmp = new Journal(nameTxt.Text, caleDate, publisherTxt.Text, _list, Convert.ToInt32(editionTxt.Text), Convert.ToInt32(priceTxt.Text), new Uri(imageTxt.Text));
                _manage.Collection._itemList[_itemIndex] = tmp;
                _manage.Collection._itemList[_itemIndex].Pop = CreateXML.CreateStorePopUp(_manage.Collection._itemList[_itemIndex], _manage.Collection);
                _manage.Collection._itemList[_itemIndex].pic.Tapped += _manage.Collection.img_tapped;
                _manage.Collection._itemList[_itemIndex].PopUpEvent += _manage.Collection.img_tapped;
            }
            // In this method we are editing the item fully, if the image source isnt valid we add the defualt image.
            // Because the "TextChanged" method we can use "Convert.ToInt32" witout crushing.
            // Updating the PopUp and the event.
        }
        public void TextChanged(TextBox priceTxt)
        {
            if (priceTxt != null)
                priceTxt.Text = new String(priceTxt.Text.Where(char.IsDigit).ToArray());
            if (priceTxt.Text == string.Empty) priceTxt.Text = "0";
            // In this method we allow only digits.
            // If the input isnt a digit, make the input 0.
        }
    }
}
