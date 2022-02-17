using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public static class GameEngine
    { 
       
        public static string Version = "0.0.4";
        public static Monster _currentMonster;
       

        public static void Initialize()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Initializing Game Engine {0}", Version);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\nWelcome to the world of {0}", World.WorldName);
            Console.WriteLine();

            //  V2:05 Aparently, this is used for debugging?     
            //World.ListLocations(); //World.ListLocation();
            //World.ListMonsters();
            //World.ListQuests();
            //World.ListItems();
        }

        public static void DebugInfo()
        {
            World.ListLocations();
            World.ListMonsters();
            World.ListQuests();
            World.ListItems();
            if (_currentMonster != null)
            {
                Console.WriteLine("Current Monster: {0}", _currentMonster.Name);
            }
            else Console.WriteLine("No current monster");
        }




        /*      old quest processor... why was I told to delete this?
        public static void QuestProcessor(Player player, Location location)
        {
            //does this location have a quest?
            if(location.QuestAvalibleHere != null)
            {
                bool playerAlreadyHasQuest = false;
                bool playerAlreadyCompletedQuest = false;
                Console.WriteLine("DEBUG: Q here!:::");
                Console.WriteLine("\t{0}", location.QuestAvalibleHere.Description);
                foreach(PlayerQuest playerQuest in player.Quests)
                {
                    if(playerQuest.Details.ID == location.QuestAvalibleHere.ID)
                    {
                        playerAlreadyHasQuest = true;
                        if (playerQuest.IsCompleted)
                        {
                            playerAlreadyCompletedQuest = true;
                        }
                    }
                }//foreach

            }//location.QuestAvallibleHere
        }//quest processor
        */



        public static void QuestProcessor(Player _player, Location newLocation)
        {
            string questMessage;
            // Does the location have a quest?
            if (newLocation.QuestAvalibleHere != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvalibleHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvalibleHere);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvalibleHere);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            questMessage = Environment.NewLine;
                            questMessage += "You complete the '" + newLocation.QuestAvalibleHere.Name + "' quest." + Environment.NewLine;

                            // Remove quest items from inventory
                            _player.RemoveQuestCompletionItems(newLocation.QuestAvalibleHere);

                            // Give quest rewards
                            questMessage += "You receive: " + Environment.NewLine;
                            questMessage += newLocation.QuestAvalibleHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                            questMessage += newLocation.QuestAvalibleHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            questMessage += newLocation.QuestAvalibleHere.RewardItem.Name + Environment.NewLine;
                            questMessage += Environment.NewLine;
                            Console.WriteLine(questMessage);

                            _player.ExperiencePoints += newLocation.QuestAvalibleHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvalibleHere.RewardGold;

                            // Add the reward item to the player's inventory
                            _player.AddItemToInventory(newLocation.QuestAvalibleHere.RewardItem);

                            // Mark the quest as completed
                            _player.MarkQuestCompleted(newLocation.QuestAvalibleHere);
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    questMessage = "You receive the " + newLocation.QuestAvalibleHere.Name + " quest." + Environment.NewLine;
                    questMessage += newLocation.QuestAvalibleHere.Description + Environment.NewLine;
                    questMessage += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvalibleHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            questMessage += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            questMessage += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    questMessage += Environment.NewLine;
                    Console.WriteLine(questMessage);

                    // Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvalibleHere, false));
                }
            }

        } //QuestProcessor


        public static void MonsterProcessor(Player _player, Location newLocation)
        {
            string monsterMessage = " ";
            if (newLocation.MonsterLivingHere != null)
            {
                monsterMessage += $"You see a {newLocation.MonsterLivingHere.Name}\n";
                Console.WriteLine(monsterMessage);

                //make a new monster
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);
                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaxDamage, standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                foreach(LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }
                
            }else { _currentMonster = null; }




        }//Monster Processor



    }
}
 