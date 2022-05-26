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
        public Weapon CurrentWeapon;
        public List<Weapon> Weapons = new List<Weapon>();


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
            //CurrentHitPoints = (CurrentHitPoints <= MaximumHitPoints) ? CurrentHitPoints++ : CurrentHitPoints += 0; //Does this
            if (CurrentHitPoints < MaximumHitPoints) //Equal this?
            {
                CurrentHitPoints = MaximumHitPoints;
            }
            CurrentLocation = loc;
            GameEngine.QuestProcessor(this, loc);
            GameEngine.MonsterProcessor(this, loc);
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
                Console.WriteLine("You cant go North.");
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
                Console.WriteLine("You cant go South.");
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
                Console.WriteLine("You cant go East.");
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
                Console.WriteLine("You cant go West");
            }
        }
        #endregion

        #region Coppied code in V003 03
        ////////////////////////////
        //this is where quests work
        /////////////////////////////
        public bool HasThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (BasicItem bi in Inventory)
                {
                    if (bi.Details.ID == qci.Details.ID) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (bi.Quantity < qci.Quantity) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (BasicItem bi in Inventory)
                {
                    if (bi.Details.ID == qci.Details.ID)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        bi.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }


        public void AddItemToInventory(Items itemToAdd)
        {
            foreach (BasicItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    ii.Quantity++;

                    return; // We added the item, and are done, so get out of this function
                }
            }

            // They didn't have the item, so add it to their inventory, with a quantity of 1
            Inventory.Add(new BasicItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list
            foreach (PlayerQuest pq in Quests)
            {
                if (pq.Details.ID == quest.ID)
                {
                    // Mark it as completed
                    pq.IsCompleted = true;

                    return; // We found the quest, and marked it complete, so get out of this function
                }
            }
        }

        #endregion

        // /////////////////////WEAPON WORK
        public void UseWeapon(Weapon weapon)
        {
            Monster _currentMonster = GameEngine._currentMonster;
            Weapon currentWeapon = weapon;
            string fightMessage = "";

            // Determine the amount of damage to do to the monster
            int damageToMonster = RandomNumberGenorator.NumberBetween(currentWeapon.MinDamage, currentWeapon.MaxDamage);

            // Apply the damage to the monster's CurrentHitPoints
            _currentMonster.CurrentHitPoints -= damageToMonster;

            // Display message
            fightMessage += "You hit the " + _currentMonster.Name + " for " + damageToMonster.ToString() + " points." + Environment.NewLine;
            Console.WriteLine(fightMessage);

            // Check if the monster is dead
            if (_currentMonster.CurrentHitPoints <= 0)
            {
                // Monster is dead
                fightMessage += Environment.NewLine;
                fightMessage += "You defeated the " + _currentMonster.Name + Environment.NewLine;

                // Give player experience points for killing the monster
                ExperiencePoints += _currentMonster.RewardExperiencePoints;
                fightMessage += "You receive " + _currentMonster.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;

                // Give player gold for killing the monster 
                Gold += _currentMonster.RewardGold;
                fightMessage += "You receive " + _currentMonster.RewardGold.ToString() + " gold" + Environment.NewLine;


                // Get random loot items from the monster
                List<BasicItem> lootedItems = new List<BasicItem>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (LootItem lootItem in _currentMonster.LootTable)
                {
                    if (RandomNumberGenorator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new BasicItem(lootItem.Details, 1));
                    }
                }

                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _currentMonster.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new BasicItem(lootItem.Details, 1));
                        }
                    }
                }

                // Add the looted items to the player's inventory
                foreach (BasicItem inventoryItem in lootedItems)
                {
                    AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        fightMessage += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        fightMessage += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                    }
                }



                // Add a blank line to the messages box, just for appearance.
                fightMessage += Environment.NewLine;
                Console.WriteLine(fightMessage);

                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(CurrentLocation);
            }
            else
            {
                // Monster is still alive

                // Determine the amount of damage the monster does to the player
                int damageToPlayer = RandomNumberGenorator.NumberBetween(0, _currentMonster.MaxDamage);

                // Display message
                fightMessage += "The " + _currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                // Subtract damage from player
                CurrentHitPoints -= damageToPlayer;

                Console.WriteLine(fightMessage);

                if (CurrentHitPoints <= 0)
                {
                    // Display message
                    fightMessage += "The " + _currentMonster.Name + " killed you." + Environment.NewLine;
                    Console.WriteLine(fightMessage);

                    // Move player to "Home"
                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }
            }

        }//use weapon

        public void UpdateWeapons()
        {
            Weapons.Clear();
            foreach(BasicItem basicItem in this.Inventory)
            {
                if(basicItem.Details is Weapon)
                {
                    if(basicItem.Quantity > 0)
                    {
                        Weapons.Add((Weapon)basicItem.Details);
                        
                    }
                }
            }
        }


    }//class player
}
