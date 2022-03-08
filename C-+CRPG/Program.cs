using System;
using System.Linq;

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
            else if (input == "quests")
            {
                if(_player.Quests.Count == 0)
                {
                    Console.WriteLine("You live a Quest-free life.");
                }
                else
                {
                    foreach(PlayerQuest playerQuest in _player.Quests)
                    {
                        Console.WriteLine($"{playerQuest.Details.Name}: {0}", playerQuest.IsCompleted ? "completed" : "Incomplete");
                    }
                }
            }
            else if (input.Contains("attack"))
            {
                if(_player.CurrentLocation.MonsterLivingHere == null)
                {
                    Console.WriteLine("There is nothing here to attack!");
                }
                else
                {
                    if (_player.CurrentWeapon == null)
                    {
                        Console.WriteLine("You arnt holding a weapon!");
                    }
                    else
                    {
                        _player.UseWeapon(_player.CurrentWeapon);
                    }
                }
            }
            else if(input.StartsWith("equip "))
            {
                _player.UpdateWeapons();
                string inputWeaponName = input.Substring(6).Trim();
                if (string.IsNullOrEmpty(inputWeaponName))
                {
                    Console.WriteLine("You need to enter the name of the weapon, to equip it.");
                }
                else
                {
                    Weapon weaponToEquip = _player.Weapons.SingleOrDefault(x => x.Name.ToLower() == inputWeaponName
                    || x.NamePlural.ToLower() == inputWeaponName);

                    if(weaponToEquip == null)
                    {
                        Random wepFalse = new Random();
                        int Tfalwep = wepFalse.Next(1,4);  //for some reason, this uses minval, but not maxval. so 1,4 is really 1,3... I have no clue why this is.
                        
                        switch (Tfalwep)
                        {
                            case 1: Console.WriteLine("You dont have that currently"); 
                                break;
                                
                            case 2:
                                Console.WriteLine("You dont have a {0}", inputWeaponName); 
                                break;
                            case 3:
                                Console.WriteLine("{0} was all in your imagination.", inputWeaponName);
                                break;
                            
                        }
                        
                    }
                }
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
