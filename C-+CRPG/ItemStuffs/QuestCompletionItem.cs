using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class QuestCompletionItem
    {
        public Items Details;
        public int Quantity;

        public QuestCompletionItem(Items details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
