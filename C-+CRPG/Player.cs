using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class Player : LivingCreature
    {
        public string Name;
        public int Gold;
        public int ExperiencePoints;
        public int Level;
        public Location CurrentLocation;
        public List<BasicItem> Inventory;
        public List<PlayerQuest> Quests;

        public Player(string name, int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level) :base(currentHitPoints,maximumHitPoints)
        {
            Name = name;
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;
            Inventory = new List<BasicItem>();
            Quests = new List<PlayerQuest>();
        }

        public Player() { }

        public void MoveTo(Location loc)
        {
            //check to make sure the player has any required items that would gate the progress
            if(loc.ItemRequiredToEnter != null)
            {
                //check for the item
                bool playerHasRequiredItem = false;
                foreach(BasicItem bi in this.Inventory)
                {
                    if (bi.Details.ID == loc.ItemRequiredToEnter.ID)
                    {
                        playerHasRequiredItem = true;
                        break;
                    }
                }

                if (!playerHasRequiredItem)
                {
                    Console.WriteLine("You need to have a {0} to go this way.", loc.ItemRequiredToEnter.Name);
                    return;
                }

            }//item check
            CurrentLocation = loc;
        }//move method



        #region Movement in cardinal direcitons.

        public void MoveNorth()
        {
            if(CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
                Program.DisplayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You cant go there.");
            }
        }


        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
            {
                MoveTo(CurrentLocation.LocationToSouth);
                Program.DisplayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You cant go there.");
            }
        }

        public void MoveEast()
        {
            if (CurrentLocation.LocationToEast != null)
            {
                MoveTo(CurrentLocation.LocationToEast);
                Program.DisplayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You cant go there.");
            }
        }

        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
            {
                MoveTo(CurrentLocation.LocationToWest);
                Program.DisplayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You cant go there.");
            }
        }
        #endregion

    }//class player
}
