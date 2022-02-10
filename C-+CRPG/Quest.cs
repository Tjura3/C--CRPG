using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class Quest
    {
        public int ID;
        public string Name;
        public int Description;
        public int RewardExperiencePoints;
        public int RewardGold;
        public Items RewardItem; //was taken out of constructor in V2:04
        public List<QuestCompletionItem> QuestCompletionItems;  //plural

        public Quest(int iD, string name, int description, int rewardExperiencePoints, int rewardGold, Items rewardItem     /*,List<QuestCompletionItem> questCompletionItems*/)
        {
            ID = iD;
            Name = name;
            Description = description;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            //RewardItem = rewardItem;
            //QuestCompletionItems = questCompletionItems;
            QuestCompletionItems = new List<QuestCompletionItem>();

        }

    }
}
