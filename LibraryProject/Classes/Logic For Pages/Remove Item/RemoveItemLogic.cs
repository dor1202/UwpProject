namespace LibraryProject.Classes.Logic_For_Pages.Remove_Item
{
    class RemoveItemLogic
    {
        public void Submit(BookLib _manage, bool[] chosen)
        {
            for (int i = 0; i < chosen.Length; i++)
            {
                if (chosen[i] == true)
                {
                    _manage.Collection._itemList.RemoveAt(i);
                    MoveTheArrayBy1(chosen);
                    i--;
                    // Every time we removing an item all the other items we align and have new indexes.
                }
            }
        }
        private void MoveTheArrayBy1(bool[] chosen)
        {
            for (int i = 1; i < chosen.Length; i++)
                chosen[i - 1] = chosen[i];
        }
    }
}
