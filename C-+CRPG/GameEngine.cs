using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public static class GameEngine
    { 
        public static string Version = "0.0.1.1";
       
        public static void Initialize()
        {
            Console.WriteLine("Initializing Game Engine {0}", Version);
            Console.WriteLine("\n\nWelcome to the world of {0}", World.WorldName);
            Console.WriteLine();
            World.ListLocation();
        }

    }
}
 