using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class Location
    {
        public int ID;
        public string Name;
        public string Description;
        public Items ItemRequiredToEnter;
        public Quest QuestAvalibleHere;
        public Monster MonsterLivingHere;
        public Location LocationToNorth;
        public Location LocationToSouth;
        public Location LocationToEast;
        public Location LocationToWest;


        //Constructor
        public Location(int iD, string name, string description, Items itemRequiredToEnter = null, Quest questAvailableHere = null, Monster monsterLivingHere=null)
        {
            ID = iD;
            Name = name;
            Description = description;
        }
        public Location() { }
       

    }
}
