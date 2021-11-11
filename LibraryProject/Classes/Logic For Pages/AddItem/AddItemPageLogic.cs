using DAL.Classes;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LibraryProject.Classes.Logic_For_Pages.AddItem
{
    class AddItemPageLogic
    {
        public CalendarDatePicker _datePicker { get; set; }
        public List<genre> _list { get; set; }
        string[] _inputs;
        public AddItemPageLogic()
        {
            _inputs = new string[6];
            _list = new List<genre>();
        }
        public bool NumberValid(TextBox priceTxt)
        {
            int tmp;
            return int.TryParse(priceTxt.Text, out tmp);
            // In this method we check if the text box holding only numbers.
        }
        public void TextChanged(object sender)
        {
            TextBox tmp = sender as TextBox;
            switch (tmp.Name)
            {
                case "nameTxt":
                    _inputs[0] = tmp.Text;
                    break;
                case "publisherTxt":
                    _inputs[1] = tmp.Text;
                    break;
                case "autorTxt":
                    _inputs[2] = tmp.Text;
                    break;
                case "priceTxt":
                    _inputs[3] = tmp.Text;
                    break;
                case "imageTxt":
                    _inputs[4] = tmp.Text;
                    break;
                case "editionTxt":
                    _inputs[5] = tmp.Text;
                    break;
            }
        }
        public void AuthorOrDateChanger(ToggleSwitch kindSwitch, TextBlock autorOrDate, CalendarDatePicker caleDate, TextBox autorTxt)
        {
            if (kindSwitch.IsOn)
            {
                autorOrDate.Text = "Author:";
                caleDate.Visibility = Visibility.Collapsed;
                autorTxt.Visibility = Visibility.Visible;
            }
            else
            {
                autorOrDate.Text = "Date";
                autorTxt.Visibility = Visibility.Collapsed;
                caleDate.Visibility = Visibility.Visible;
            }
        }
        public void Submit(ToggleSwitch kindSwitch, BookLib _manage)
        {
            try
            {
                Uri tmp = new Uri(_inputs[4]);
            }
            catch (Exception)
            {
                _inputs[4] = "ms-appx:///Assets/StoreLogo.png";
            }
            if (_inputs[3] == "0") return;
            if (kindSwitch.IsOn)
                _manage.Collection.AddBook(_inputs[0], _inputs[2], _inputs[1], _list, Convert.ToInt32(_inputs[5]), Convert.ToInt32(_inputs[3]), new Uri(_inputs[4]));
            else
                _manage.Collection.AddJournal(_inputs[0], _datePicker, _inputs[1], _list, Convert.ToInt32(_inputs[5]), Convert.ToInt32(_inputs[3]), new Uri(_inputs[4]));
            // In this method we check if the image source is valid, if he isn't change to a known image.
            // Add item to the collection.
        }
    }
}
