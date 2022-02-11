using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class LootItem
    {
        public Items Details;
        public int DropPercentage;
        public bool IsDefaultItem;

        public LootItem(Items details, int dropPercentage, bool isDefaultItem)
        {
            Details = details;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }


    }
}
