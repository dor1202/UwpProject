namespace LibraryProject.Classes.Logic_For_Pages.End_Discount_Logic
{
    class EndDiscountLogic
    {
        public void Submit(bool[] chosen, BookLib _manage)
        {
            for (int i = 0; i < chosen.Length; i++)
            {
                if (chosen[i] == true)
                {
                    Discount.Discount.ReveresTheDis(_manage, i);
                    MoveTheArrayBy1(chosen);
                }
                // Every time we removing an item all the other items we align and have new indexes.
            }
        }
        private void MoveTheArrayBy1(bool [] chosen)
        {
            for (int i = 1; i < chosen.Length; i++)
                chosen[i - 1] = chosen[i];
        }
    }
}
