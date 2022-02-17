using System;

namespace C__CRPG
{
    //Hi, My name is Thomas, I am a VGD stuedent in AM

    class Program
    {

        //private static Player _player = new Player();
        private static Player _player = new Player("Hiro the Dense", 10, 10, 20, 0, 1);

        static void Main(string[] args)
        {
            GameEngine.Initialize();
                                                                                            //_player.Name = "Hiro the Dense"; Obsilete since V2 05
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            BasicItem sword = new BasicItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1); //this adds an item to the inventory
            _player.Inventory.Add(sword);
            
            
            //Console.WriteLine(RandomNumberGenorator.NumberBetween(4, 10)); rng test



           while (true)
           {
                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    continue;
                }
                string cleanedInput = userInput.ToLower();

                if (cleanedInput == "exit") 
                {
                    break;
                }
                ParseInput(cleanedInput);

           }//while

           


        }//main


        public static void ParseInput(String input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (input.Contains("help"))
            {
                Console.WriteLine("Help is coming later... stay tuned");
            }
            else if (input.Contains("look"))
            {
                DisplayCurrentLocation();
            }
            else if (input.Contains("north") || input == "n")
            {
                _player.MoveNorth();
            }
            else if (input.Contains("south") || input == "s")                       //These if statements look HORRENDUS.
            {
                _player.MoveSouth();
            }
            else if (input.Contains("east") || input == "e")
            {
                _player.MoveEast();
            }
            else if (input.Contains("west") || input == "w")
            {
                _player.MoveWest();
            }
            else if (input.Contains("debug"))
            {
                GameEngine.DebugInfo();
            }
            else if (input == "inventory" || input == "i")
            {
                Console.WriteLine("\n_____Current__Inventory_____");
                foreach(BasicItem invItem in _player.Inventory)
                {
                    Console.WriteLine($"\t{invItem.Details.Name}: {invItem.Quantity}");
                }
            }else if(input == "stats")
            {
                Console.WriteLine($"\n\t{_player.Name}'s Stats");
                Console.WriteLine("\tCurrent HP:\t{0}", _player.CurrentHitPoints);
                Console.WriteLine("\tMaximum HP:\t{0}", _player.MaximumHitPoints);
                Console.WriteLine("\tXP:\t\t{0}", _player.ExperiencePoints);
                Console.WriteLine("\tLevel:\t\t{0}", _player.Level);
                Console.WriteLine("\tGold:\t\t{0}", _player.Gold);
            }
            
            else
            {
                Console.WriteLine("I dont understand the language of tom.");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }//parse
        
        public static void DisplayCurrentLocation()
        {
            Console.Write("You are at: {0}\n", _player.CurrentLocation.Name);
            if(_player.CurrentLocation.Description != " ")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description);
            }
        }


    }

}
