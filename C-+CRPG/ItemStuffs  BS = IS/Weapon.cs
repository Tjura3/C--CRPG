using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class Weapon : Items
    {
        public int MaxDamage;
        public int MinDamage;

        public Weapon(int iD, string name, string namePlural, int maxDamage, int minDamage):base(iD,name,namePlural)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }
    }
}
