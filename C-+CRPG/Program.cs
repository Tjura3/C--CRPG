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

            Console.ReadLine();
        }
    }
}
