using System;
using System.Collections.Generic;
using System.Text;

namespace C__CRPG
{
    public class Player
    {
        public string Name { set; get; }
        public Location CurrentLocation { set; get; }
       
        public void MoveTo(Location loc)
        {
            CurrentLocation = loc;
        }



        #region Movement in cardinal direcitons.

        public void MoveNorth()
        {
            if(CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
            }
            else
            {
                Console.WriteLine("You cant go there.");
            }
        }


        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
            {
                MoveTo(CurrentLocation.LocationToSouth);
            }
            else
            {
                Console.WriteLine("You cant go there.");
            }
        }

        public void MoveEast()
        {
            if (CurrentLocation.LocationToEast != null)
            {
                MoveTo(CurrentLocation.LocationToEast);
            }
            else
            {
                Console.WriteLine("You cant go there.");
            }
        }

        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
            {
                MoveTo(CurrentLocation.LocationToWest);
            }
            else
            {
                Console.WriteLine("You cant go there.");
            }
        }
        #endregion

    }//class player
}
