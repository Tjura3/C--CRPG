using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class World
    {
        public static readonly string WorldName = "Bjork";
        public static readonly List<Location> Locations = new List<Location>(); 

        //Start providing IDs for locations
        public const int LOCATION_ID_HOME = 1;     //constants are almost always upercase, and use the underscore
        public const int LOCATION_ID_FOREST_PATH = 2;
        public const int LOCATION_ID_LAB = 3;


        //constructor for the world
        static World()
        {
           PopulateLocations();
        }

        private static void PopulateLocations()
        {
            Location home = new Location(1, "Home", "Your house is a mess.");
            Location forestPath = new Location(LOCATION_ID_FOREST_PATH,
                "Forest Path",
                "A wodded path with a lot of ferns.");
            Location lab = new Location(LOCATION_ID_LAB, "Lab", "A wack smelling lab with mystery juice and rodent tails.");

            //Link locations togehter...
            home.LocationToNorth = forestPath;
            forestPath.LocationToEast = lab;
            lab.LocationToWest = forestPath;
            forestPath.LocationToSouth = home;      //When you go north when you cant go north, system returns null.

            //Create our LISTS of locations.
            Locations.Add(home);
            Locations.Add(forestPath);
            Locations.Add(lab);
            
        }

        public static Location LocationByID(int ID)     //Gives us location if we know its ID
        {
            foreach (Location loc in Locations)
            {
                if(loc.ID == ID)
                {
                    return loc;   //loc is a type of location
                }
            }
            return null;
        }

        public static void ListLocation()
        {
            Console.WriteLine("These are the locations in the world");
            foreach(Location loc in Locations)
            {
                Console.WriteLine($"\t{loc.Name}");
            }
        }


    }
}