using DAL.Classes;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LibraryProject.Classes.Discount
{
    class DiscountLogic
    {
        // In this class we use bools using questions for knowing what the user chose.
        public bool _isAll { get; set; }
        public bool? _isBookOrJournal { get; set; }
        public bool _isPublisher { get; set; }
        public bool _data { get; set; }
        public DiscountLogic()
        {
            _isAll = false;
            _isBookOrJournal = null;
            _isPublisher = false;
            _data = false;
        }
        public void All() => _isAll = true;
        public void ByBooks()
        {
            _isAll = false;
            _isBookOrJournal = true;
        }
        public void ByJournal()
        {
            _isAll = false;
            _isBookOrJournal = false;
        }
        public float PrecentChangedOtherMethod(object sender, TextChangedEventArgs e)
        {
            TextBox tmp = sender as TextBox;
            if (tmp != null)
                tmp.Text = new String(tmp.Text.Where(char.IsDigit).ToArray());
            if (tmp.Text == string.Empty) tmp.Text = "0";
            return float.Parse(tmp.Text);
            // In this method we allow only digits, and only 2 chars.
            // If the input isnt a digit, make the input 0.
        }
        public void Submit(BookLib _manage, float prec, genre gen, AutoSuggestBox byNameTxtBox, TextBlock generTxt,CalendarDatePicker dp)
        {
            if (_isAll)
            {
                Discount.DisAll(_manage, prec);
            }
            else if (_isBookOrJournal == null)
            {
                if (generTxt.Visibility == Visibility.Visible)
                    Discount.DisGenere(_manage, prec, gen);
                else
                {
                    if(_data == false)
                    {
                        if (!_isPublisher)
                            Discount.DisName(_manage, prec, byNameTxtBox.Text);
                        else
                            Discount.DisPublisher(_manage, prec, byNameTxtBox.Text);
                    }
                    else
                        Discount.DisDate(_manage, prec, dp);
                }
            }
            else
            {
                if (_isBookOrJournal == true)
                    Discount.DisBook(_manage, prec);
                else
                    Discount.DisJournal(_manage, prec);
            }
            // In this method we are using the booleans for knowing on what criteria we use the discount.
        }
        // visibillity:
        public void ComboBoxGenereTapped(TextBlock generTxt, ComboBox generComboBox, AutoSuggestBox byNameTxtBox, TextBlock byNameTxt, CalendarDatePicker dp)
        {
            ByNameOrGenereTapped();
            generTxt.Visibility = Visibility.Visible;
            generComboBox.Visibility = Visibility.Visible;
            byNameTxtBox.Visibility = Visibility.Collapsed;
            byNameTxt.Visibility = Visibility.Collapsed;
            dp.Visibility = Visibility.Collapsed;
        }
        public void ComboBoxNameTapped(TextBlock generTxt, ComboBox generComboBox, AutoSuggestBox byStringTxtBox, TextBlock byStringTxt, CalendarDatePicker dp)
        {
            ByNameOrGenereTapped();
            byStringTxtBox.Visibility = Visibility.Visible;
            byStringTxt.Visibility = Visibility.Visible;
            byStringTxt.Text = "Name:";
            generTxt.Visibility = Visibility.Collapsed;
            generComboBox.Visibility = Visibility.Collapsed;
            dp.Visibility = Visibility.Collapsed;
        }
        private void ByNameOrGenereTapped()
        {
            _isAll = false;
            _isBookOrJournal = null;
        }
        public void ComboBoxPublisherTapped(TextBlock generTxt, ComboBox generComboBox, AutoSuggestBox byStringTxtBox, TextBlock byStringTxt, CalendarDatePicker dp)
        {
            ByPublisher();
            byStringTxtBox.Visibility = Visibility.Visible;
            byStringTxt.Visibility = Visibility.Visible;
            byStringTxt.Text = "Publisher:";
            generTxt.Visibility = Visibility.Collapsed;
            generComboBox.Visibility = Visibility.Collapsed;
            dp.Visibility = Visibility.Collapsed;
        }
        private void ByPublisher()
        {
            _isAll = false;
            _isBookOrJournal = null;
            _isPublisher = true;
        }
        public void ComboBoxDateTapped(TextBlock generTxt, ComboBox generComboBox, AutoSuggestBox byStringTxtBox, TextBlock byStringTxt,CalendarDatePicker dp)
        {
            ByDate();
            byStringTxtBox.Visibility = Visibility.Collapsed;
            byStringTxt.Visibility = Visibility.Visible;
            byStringTxt.Text = "Date:";
            generTxt.Visibility = Visibility.Collapsed;
            generComboBox.Visibility = Visibility.Collapsed;
            dp.Visibility = Visibility.Visible;
        }
        private void ByDate()
        {
            _data = true;
            _isAll = false;
            _isBookOrJournal = null;
            _isPublisher = false;
        }
        // search:
        public void searchTextByName(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs e, BookLib _manage)
        {
            var Auto = sender;
            object Suggestion = 0;
            var tmp = _manage.Collection._itemList.Where(p => p.Name.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            string[] tmp1 = new string[tmp.Length];
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp1[i] = tmp[i].Name;
            }
            Array.Sort(tmp1);
            Suggestion = tmp1;
            Auto.ItemsSource = Suggestion;
        }
        public void searchTextByPublisher(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs e, BookLib _manage)
        {
            var Auto = sender;
            object Suggestion = 0;
            var tmp = _manage.Collection._itemList.Where(p => p.Publisher.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            string[] tmp1 = new string[tmp.Length];
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp1[i] = tmp[i].Publisher;
            }
            Array.Sort(tmp1);
            Suggestion = tmp1;
            Auto.ItemsSource = Suggestion;
        }
        // In those two method same as "search" class, we are bulding an object containning the string that start with the input string.
    }
}
