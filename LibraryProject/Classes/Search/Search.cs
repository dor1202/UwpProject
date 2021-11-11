using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace LibraryProject.Classes.Search
{
    static class Search
    {
        public static void textChanged(AutoSuggestBox sender, RadioButton nameBtn, RadioButton publisherBtn,
            RadioButton genreBtn, RadioButton authorBtn,BookLib _manage)
        {
            var Auto = sender;
            object Suggestion = 0;
            if (nameBtn.IsChecked == true)
                Suggestion = _manage.Collection._itemList.Where(p => p.Name.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (publisherBtn.IsChecked == true)
                Suggestion = _manage.Collection._itemList.Where(p => p.Publisher.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (genreBtn.IsChecked == true)
            {
                if (sender.Text == string.Empty) return;
                List<genre> options = _manage.Collection[Auto.Text];
                for (int i = 0; i < options.Count; i++)
                {
                    Suggestion = _manage.Collection._itemList.Where(p => p.Genres.Contains(options[i])).ToArray();
                }
            }
            if (authorBtn.IsChecked == true)
            {
                List<AbstractItem> tmp = _manage.Collection._itemList.Where((p) => p is Book).ToList();
                List<Book> b = tmp.ConvertAll((x) => x as Book);
                Suggestion = b.Where((x) => x.Author.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            }
            Auto.ItemsSource = Suggestion;
            // In this method we check which radio button is checked and search based on him.
        }
        public static void SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = args.SelectedItem.ToString();
            sender.Text = "chosen";
        }
        public static void QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args,
        RadioButton nameBtn, RadioButton publisherBtn, RadioButton genreBtn, RadioButton authorBtn, BookLib _manage)
        {
            if (args.ChosenSuggestion != null)
            {
                sender.Text = args.ChosenSuggestion.ToString();
                foreach (AbstractItem item in _manage.Collection._itemList)
                {
                    if (item.ToString() == sender.Text)
                    {
                        item.PopUpEvent?.Invoke(item.pic, new TappedRoutedEventArgs());
                        return;
                    }
                }
            }
            else
            {

            }
            // In this method we fined the string to the collection and invoke the delegate of the pop up.
        }
    }
}
