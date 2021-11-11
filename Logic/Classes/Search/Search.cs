using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Logic.Classes.Search
{
    static class Search
    {
        public static void textChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args,
            RadioButton nameBtn, RadioButton publisherBtn, RadioButton genreBtn, RadioButton authorBtn,BookLib _manage)
        {
            var Auto = sender;
            object Suggestion = 0;
            if (nameBtn.IsChecked == true)
                Suggestion = _manage.collection.ItemList.Where(p => p.Name.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (publisherBtn.IsChecked == true)
                Suggestion = _manage.collection.ItemList.Where(p => p.Publisher.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (genreBtn.IsChecked == true)
            {
                Suggestion = _manage.collection[Auto.Text];
            }
            if (authorBtn.IsChecked == true)
            {
                List<AbstractItem> tmp = _manage.collection.ItemList.Where((p) => p is Book).ToList();
                List<Book> b = tmp.ConvertAll((x) => x as Book);
                Suggestion = b.Where((x) => x.Author.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
            }
            Auto.ItemsSource = Suggestion;
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
                foreach (AbstractItem item in _manage.collection.ItemList)
                {
                    if (item.ToString() == sender.Text)
                    {
                        item.PopUpEvent?.Invoke(item.pic, new Windows.UI.Xaml.Input.TappedRoutedEventArgs());
                        return;
                    }
                }
            }
            else
            {
                // Use args.QueryText to determine what to do.
            }
        }
    }
}
