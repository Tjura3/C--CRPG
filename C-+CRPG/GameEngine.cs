using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public static class GameEngine
    { 
       
        public static string Version = "0.0.4";
       
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
        }
        
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

    }
}
 