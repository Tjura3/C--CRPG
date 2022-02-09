using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class HealingPotion : Items
    {
        public int AmountOfHealing;

        public HealingPotion(int iD, string name, string namePlural, int amountOfHealing) : base(iD, name, namePlural)
        {
            AmountOfHealing = amountOfHealing;
        }
    }
}
