﻿using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public static class GameEngine
    { 
        public static string Version = "0.0.1";
       
        public static void Initialize()
        {
            Console.WriteLine("Initializing Game Engine {0}", Version);
            Console.WriteLine();
        }

    }
}
 