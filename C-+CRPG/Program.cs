using System;

namespace C__CRPG
{
    //Hi, My name is Thomas, I am a VGD stuedent in AM

    class Program
    {

        private static Player _player = new Player();


        static void Main(string[] args)
        {
            GameEngine.Initialize();
            _player.Name = "Hiro the Dense";
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));

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
            if (input.Contains("help"))
            {
                Console.WriteLine("Help is coming later... stay tuned");
            }else if(input.Contains("look"))
            {
                DisplayCurrentLocation();
            }else if (input.Contains("north"))
            {
                _player.MoveNorth();
            }
            else if (input.Contains("south"))                       //These if statements look HORRENDUS.
            {
                _player.MoveSouth();
            }
            else if (input.Contains("east"))
            {
                _player.MoveEast();
            }
            else if (input.Contains("west"))
            {
                _player.MoveWest();
            }
            else
            {
                Console.WriteLine("I dont understand the language of tom.");
            }

        }//parse
        
        private static void DisplayCurrentLocation()
        {
            Console.WriteLine("You are at: {0}", _player.CurrentLocation.Name);
            if(_player.CurrentLocation.Description != " ")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description);
            }
        }


    }

}
