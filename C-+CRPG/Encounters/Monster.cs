using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class Monster : LivingCreature
    {
        public int ID;
        public string Name;
        public int MaxDamage;
        public int RewardExperiencePoints;
        public int RewardGold;
        public List<LootItem> LootTable;

        public Monster(int iD, string name, int maxDamage, int rewardExperiencePoints, int rewardGold, int currentHitPoints, int maximumHitPoints):base(currentHitPoints,maximumHitPoints)
        {
            ID = iD;
            Name = name;
            MaxDamage = maxDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();
        }
    }
}
