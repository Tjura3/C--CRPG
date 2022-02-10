using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class BasicItem
    {
        public Items Details;
        public int Quantity;

        public BasicItem(Items details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }

    }
}
