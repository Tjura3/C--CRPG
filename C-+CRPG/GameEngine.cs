using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public static class GameEngine
    { 
        public static string Version = "0.0.3.1";
       
        public static void Initialize()
        {
            Console.WriteLine("Initializing Game Engine {0}", Version);
            Console.WriteLine("\n\nWelcome to the world of {0}", World.WorldName);
            Console.WriteLine();

            //  V2:05 Aparently, this is used for debugging?     
            World.ListLocations(); //World.ListLocation();
            World.ListMonsters();
            World.ListQuests();
            World.ListItems();
        }

    }
}
 